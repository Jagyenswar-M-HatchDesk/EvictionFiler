
using System.Drawing.Printing;
using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Infrastructure.DbContexts;
using EvictionFiler.Infrastructure.Repositories.Base;
using HtmlRendererCore.PdfSharp;
using Microsoft.EntityFrameworkCore;
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
			// 1. Template fetch
			var template = await _context.MstFormTypes
				.Where(f => f.Id == formTypeId)
				.Select(f => f.HTML)
				.FirstOrDefaultAsync();

			if (string.IsNullOrEmpty(template))
				throw new Exception("Template not found.");

			// 2. Case + landlord + property details
			var caseDetails = await (from lc in _context.LegalCases
									 join landlord in _context.LandLords on lc.LandLordId equals landlord.Id
									 join building in _context.Buildings on lc.BuildingId equals building.Id
									 join tenant in _context.Tenants on lc.TenantId equals tenant.Id
									 where lc.Id == legalCaseId
									 select new
									 {
										 LandlordName = landlord.FirstName + " " + landlord.LastName,
										 LandlordAddress = landlord.Address1 + " " + landlord.Address2 + " " +
														   landlord.City + " " + landlord.State.Name + " " + landlord.Zipcode,
										 LandlordPhone = landlord.Phone,
										 LandlordDate  = landlord.CreatedOn,
										 LandlordEmail = landlord.Email,
										 PropertyAddress = building.Address1 + " " + building.Address2 + " " +
														   building.City + " " + building.State.Name + " " + building.Zipcode,
										 NumberofRoom = building.BuildingUnits.ToString(),
										 ApartmentNumber = tenant.UnitOrApartmentNumber,
										 TenantName = tenant.FirstName + "" + tenant.LastName
									 }).FirstOrDefaultAsync();

			if (caseDetails == null)
				throw new Exception("Case details not found.");



			// 4. Replace placeholders in template
			string filledHtml = template
				.Replace("{{LandlordName}}", caseDetails.LandlordName ?? "")
				.Replace("{{LandlordAddress}}", caseDetails.LandlordAddress ?? "")
				.Replace("{{LandlordPhone}}", caseDetails.LandlordPhone ?? "")
				.Replace("{{LandlordEmail}}", caseDetails.LandlordEmail ?? "")
				.Replace("{{LandlordDate}}", caseDetails.LandlordDate.ToString("MM/dd/yyyy"))
				.Replace("{{PropertyAddress}}", caseDetails.PropertyAddress ?? "")
				.Replace("{{ApartmentNumber}}", caseDetails.ApartmentNumber ?? "")
				.Replace("{{NumberofRoom}}", caseDetails.NumberofRoom ?? "")
			.Replace("{{TenantName}}", caseDetails.TenantName ?? "");


			// 6. Save to CaseForms
			var caseForm = new CaseForms
			{
				Id = Guid.NewGuid(),
				LegalCaseId = legalCaseId,
				FormTypeId = formTypeId,
				HTML = filledHtml,
				File = null,
				CreatedOn = DateTime.UtcNow,
				IsDeleted = false
			};

			_context.CaseForms.Add(caseForm);
			return await _context.SaveChangesAsync() > 0;
		}

		//public async Task<byte[]> GetPdfBytesAsync(Guid id)
		//{
		//	var caseForm = await _context.CaseForms
		//		.FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted != true);

		//	if (caseForm == null || string.IsNullOrEmpty(caseForm.HTML))
		//		return null;

		//	var converter = new HtmlToPdf();
		//	var pdfDoc = converter.RenderHtmlAsPdf(caseForm.HTML);

		//	using var ms = pdfDoc.Stream;
		//	return ms.ToArray();
		//}


		//public async Task<byte[]?> GetPdfBytesAsync(Guid id)
		//{
		//	var caseForm = await _context.CaseForms
		//		.FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted != true);

		//	if (caseForm == null || string.IsNullOrWhiteSpace(caseForm.HTML))
		//		return null;

		//	// Directly generate PDF from HTML
		//	var pdf = PdfGenerator.GeneratePdf(caseForm.HTML, PageSize.A4);

		//	using var stream = new MemoryStream();
		//	pdf.Save(stream, false);
		//	return stream.ToArray();
		//}

		public async Task<byte[]?> GetPdfBytesAsync(Guid id)
		{
			var caseForm = await _context.CaseForms
				.FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted != true);

			if (caseForm == null || string.IsNullOrWhiteSpace(caseForm.HTML))
				return null;

			// Download Chromium (first time only)
			await new BrowserFetcher().DownloadAsync();

			// Launch headless browser (will use downloaded Chromium)
			await using var browser = await Puppeteer.LaunchAsync(new LaunchOptions
			{
				Headless = true,
				Args = new[] { "--no-sandbox" } // required on some servers
			});

			// Open new page
			var page = await browser.NewPageAsync();
			await page.SetContentAsync(caseForm.HTML, new NavigationOptions
			{
				WaitUntil = new[] { WaitUntilNavigation.Networkidle0 }
			});

			// Generate PDF (multi-page, full CSS support)
			var pdfBytes = await page.PdfDataAsync(new PdfOptions
			{
				Format = PaperFormat.A4,
				PrintBackground = true
			});

			return pdfBytes;
		}
	}
}
