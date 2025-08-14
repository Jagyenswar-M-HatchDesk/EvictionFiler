
using System.Drawing.Printing;
using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Infrastructure.DbContexts;
using EvictionFiler.Infrastructure.Repositories.Base;
using HtmlRendererCore.PdfSharp;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using PdfSharpCore;
using PdfSharpCore.Pdf;

using PuppeteerSharp;
using PuppeteerSharp.Media;



namespace EvictionFiler.Infrastructure.Repositories
{
	public class CaseFormRepository:Repository<CaseForms>, ICaseFormRepository
    {
        private readonly MainDbContext _context;

	public CaseFormRepository(MainDbContext context) : base(context)
	{
		_context = context;
	}


		public async Task<bool> GenerateNoticeAsync(Guid legalCaseId, Guid formTypeId)
		{
			try
			{
				
				var template = await _context.MstFormTypes
					.Where(f => f.Id == formTypeId)
					.Select(f => new { f.HTML, f.Name })
					.FirstOrDefaultAsync();

				if (string.IsNullOrEmpty(template?.HTML))
					throw new Exception("Template not found.");

				DateTime noticeDate = CalculateNoticeDate(template.Name);

		
				var caseDetails = await (from lc in _context.LegalCases
										 join landlord in _context.LandLords on lc.LandLordId equals landlord.Id
										 join building in _context.Buildings on lc.BuildingId equals building.Id
										 join tenant in _context.Tenants on lc.TenantId equals tenant.Id
										 where lc.Id == legalCaseId
										 select new
										 {
											 CaseCode = lc.Casecode,
											 LandlordName = landlord.FirstName + " " + landlord.LastName,
											 LandlordAddress = landlord.Address1 + " " + landlord.Address2 + " " +
															   landlord.City + " " + landlord.State.Name + " " + landlord.Zipcode,
											 LandlordPhone = landlord.Phone,
											 LandlordEmail = landlord.Email,
											 PropertyAddress = building.Address1 + " " + building.Address2 + " " +
															   building.City + " " + building.State.Name + " " + building.Zipcode,
											 NumberofRoom = building.BuildingUnits.ToString(),
											 ApartmentNumber = tenant.UnitOrApartmentNumber,
											 TenantName = tenant.FirstName + " " + tenant.LastName
										 }).FirstOrDefaultAsync();

				if (caseDetails == null)
					throw new Exception("Case details not found.");

				// 3. Fill HTML
				string filledHtml = template.HTML
					.Replace("{{LandlordName}}", caseDetails.LandlordName ?? "")
					.Replace("{{LandlordAddress}}", caseDetails.LandlordAddress ?? "")
					.Replace("{{LandlordPhone}}", caseDetails.LandlordPhone ?? "")
					.Replace("{{LandlordEmail}}", caseDetails.LandlordEmail ?? "")
					.Replace("{{LandlordDate}}", noticeDate.ToString("dd/MM/yyyy"))
					.Replace("{{PropertyAddress}}", caseDetails.PropertyAddress ?? "")
					.Replace("{{ApartmentNumber}}", caseDetails.ApartmentNumber ?? "")
					.Replace("{{CurrentDate}}", DateTime.Now.ToString("dd/MM/yyyy"))
					.Replace("{{NumberofRoom}}", caseDetails.NumberofRoom ?? "")
					.Replace("{{TenantName}}", caseDetails.TenantName ?? "");

			
				await new BrowserFetcher().DownloadAsync();
				await using var browser = await Puppeteer.LaunchAsync(new LaunchOptions
				{
					Headless = true,
					Args = new[] { "--no-sandbox" }
				});

				var page = await browser.NewPageAsync();
				await page.SetContentAsync(filledHtml, new NavigationOptions
				{
					WaitUntil = new[] { WaitUntilNavigation.Networkidle0 }
				});

				var pdfBytes = await page.PdfDataAsync(new PdfOptions
				{
					Format = PaperFormat.A4,
					PrintBackground = true
				});

				
				var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "CaseForms", caseDetails.CaseCode);
				Directory.CreateDirectory(folderPath);

				var fileName = $"{Guid.NewGuid()}.pdf";
				var filePath = Path.Combine(folderPath, fileName);
				await File.WriteAllBytesAsync(filePath, pdfBytes);

				
				var fileUrl = $"/CaseForms/{caseDetails.CaseCode}/{fileName}";

			
				var caseForm = new CaseForms
				{
					Id = Guid.NewGuid(),
					LegalCaseId = legalCaseId,
					FormTypeId = formTypeId,
					HTML = filledHtml,
					File = fileUrl,
					CreatedOn = DateTime.UtcNow,
					IsDeleted = false
				};

				_context.CaseForms.Add(caseForm);
				return await _context.SaveChangesAsync() > 0;
			}
			catch (Exception ex)
			{
				
				Console.WriteLine($"Error generating notice: {ex.Message}");
				return false;
			}
		}


		private DateTime CalculateNoticeDate(string formName)
		{
			int noticeDays = 0;

			if (string.IsNullOrEmpty(formName))
				return DateTime.Now;

			if (formName.ToLower().Contains("90 days"))
				noticeDays = 90;
			else if (formName.ToLower().Contains("5 days"))
				noticeDays = 5;
			else if (formName.ToLower().Contains("30 days"))
				noticeDays = 30;
		

			return DateTime.Now.AddDays(noticeDays);
		}

		public async Task<byte[]?> GetPdfBytesAsync(Guid id)
		{
			var caseForm = await _context.CaseForms
				.FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted != true);

			if (caseForm == null || string.IsNullOrWhiteSpace(caseForm.HTML))
				return null;

			await new BrowserFetcher().DownloadAsync();
			await using var browser = await Puppeteer.LaunchAsync(new LaunchOptions
			{
				Headless = true,
				Args = new[] { "--no-sandbox" }
			});

			
			var page = await browser.NewPageAsync();
			await page.SetContentAsync(caseForm.HTML, new NavigationOptions
			{
				WaitUntil = new[] { WaitUntilNavigation.Networkidle0 }
			});

			var pdfBytes = await page.PdfDataAsync(new PdfOptions
			{
				Format = PaperFormat.A4,
				PrintBackground = true
			});

			return pdfBytes;
		}
	}
}
