
using System.Drawing.Printing;
using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Infrastructure.DbContexts;
using EvictionFiler.Infrastructure.Repositories.Base;
using HtmlRendererCore.PdfSharp;
using Microsoft.EntityFrameworkCore;


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
                // 1. Get the template
                var template = await _context.MstFormTypes
                    .Where(f => f.Id == formTypeId)
                    .Select(f => new { f.HTML, f.Name })
                    .FirstOrDefaultAsync();

                if (string.IsNullOrEmpty(template?.HTML))
                    throw new Exception("Template not found.");

                DateTime noticeDate = CalculateNoticeDate(template.Name);

                // 2. Get case details (TenantIds are in LegalCase)
                var caseDetails = await (from lc in _context.LegalCases
                                         join landlord in _context.LandLords on lc.LandLordId equals landlord.Id
                                         join building in _context.Buildings on lc.BuildingId equals building.Id
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
                                             TenantIds = lc.TenantId // <-- List of tenant IDs from LegalCase
                                         }).FirstOrDefaultAsync();

                if (caseDetails == null)
                    throw new Exception("Case details not found.");

                // 3. Parse TenantIds
                List<Guid> tenantIds = new List<Guid>();
               

                if (caseDetails.TenantIds.HasValue)  // since it's Guid?
                {
                    tenantIds.Add(caseDetails.TenantIds.Value);
                }


                // 4. Fetch all tenants for this case
                var tenants = await _context.Tenants
                    .Where(t => tenantIds.Contains(t.Id))
                    .Select(t => new
                    {
                        FullName = t.FirstName + " " + t.LastName,
                        ApartmentNumber = t.UnitOrApartmentNumber
                    })
                    .ToListAsync();

                // 5. Get first tenant details for top section
                string firstTenantName = tenants.Count > 0 ? tenants[0].FullName : "";
                string firstApartmentNumber = tenants.Count > 0 ? tenants[0].ApartmentNumber : "";

                // 6. Fill HTML placeholders
                string filledHtml = template.HTML
                    .Replace("{{LandlordName}}", caseDetails.LandlordName ?? "")
                    .Replace("{{LandlordAddress}}", caseDetails.LandlordAddress ?? "")
                    .Replace("{{LandlordPhone}}", caseDetails.LandlordPhone ?? "")
                    .Replace("{{LandlordEmail}}", caseDetails.LandlordEmail ?? "")
                    .Replace("{{LandlordDate}}", noticeDate.ToString("dd/MM/yyyy"))
                    .Replace("{{PropertyAddress}}", caseDetails.PropertyAddress ?? "")
                    .Replace("{{ApartmentNumber}}", firstApartmentNumber ?? "")
                    .Replace("{{CurrentDate}}", DateTime.Now.ToString("dd/MM/yyyy"))
                    .Replace("{{NumberofRoom}}", caseDetails.NumberofRoom ?? "")
                    .Replace("{{TenantName}}", firstTenantName); // Single tenant for top

                // 7. Fill up to 12 tenant names dynamically
                for (int i = 0; i < 12; i++)
                {
                    string tenantValue = i < tenants.Count ? tenants[i].FullName : "";
                    filledHtml = filledHtml.Replace($"{{{{Tenant{i + 1}}}}}", tenantValue);
                }

               
              
                // 9. Generate PDF
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

                // 10. Save PDF to server
                var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "CaseForms", caseDetails.CaseCode);
                Directory.CreateDirectory(folderPath);

                var fileName = $"{Guid.NewGuid()}.pdf";
                var filePath = Path.Combine(folderPath, fileName);
                await File.WriteAllBytesAsync(filePath, pdfBytes);

                // 11. Save form record to DB
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
