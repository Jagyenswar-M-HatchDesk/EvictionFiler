using System.Drawing.Printing;
using System.Globalization;
using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Infrastructure.DbContexts;
using EvictionFiler.Infrastructure.Repositories.Base;
using HtmlRendererCore.PdfSharp;
using Microsoft.EntityFrameworkCore;
using Syncfusion.HtmlConverter;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf;
using Syncfusion.Drawing;
using Microsoft.AspNetCore.Http;



namespace EvictionFiler.Infrastructure.Repositories
{
    public class CaseFormRepository : Repository<CaseForms>, ICaseFormRepository
    {
        private readonly MainDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CaseFormRepository(MainDbContext context, IHttpContextAccessor httpContextAccessor) : base(context)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }




        //public async Task<bool> GenerateNoticeAsync(Guid legalCaseId, Guid formTypeId, Guid createdBy)
        //{
        //    try
        //    {
        //        var template = await _context.MstFormTypes
        //            .Where(f => f.Id == formTypeId)
        //            .Select(f => new { f.HTML, f.Name })
        //            .FirstOrDefaultAsync();

        //        if (string.IsNullOrEmpty(template?.HTML))
        //            throw new Exception("Template not found.");

        //        DateTime noticeDate = CalculateNoticeDate(template.Name);

        //        var caseDetails = await (
        //                            from lc in _context.LegalCases

        //                            join landlord in _context.LandLords on lc.LandLordId equals landlord.Id
        //                            join building in _context.Buildings on lc.BuildingId equals building.Id
        //                            join tenant in _context.Tenants on lc.TenantId equals tenant.Id

        //                            join court in _context.Courts on lc.CourtId equals court.Id into cCourt
        //                            from court in cCourt.DefaultIfEmpty()

        //                            join county in _context.MstCounties on court.CountyId equals county.Id into cCounty
        //                            from county in cCounty.DefaultIfEmpty()

        //                            join rentdue in _context.MstDateRent on lc.RentDueEachMonthOrWeekId equals rentdue.Id into cRent
        //                            from rentdue in cRent.DefaultIfEmpty()

        //                            where lc.Id == legalCaseId

        //                            select new
        //                            {
        //                                CaseCode = lc.Casecode,
        //                                LandlordName = landlord.FirstName + " " + landlord.LastName,
        //                                LandlordAddress = landlord.Address1 + " " + landlord.Address2 + " " +
        //                                                  landlord.City + " " + landlord.State.Name + " " + landlord.Zipcode,
        //                                LandlordPhone = landlord.Phone,
        //                                LandlordEmail = landlord.Email,

        //                                PropertyAddress = building.Address1 + " " + building.Address2 + " " +
        //                                                  building.City + " " + building.State.Name + " " + building.Zipcode,
        //                                NumberofRoom = building.BuildingUnits.ToString(),

        //                                TenantIds = lc.TenantId,
        //                                LeaseEnd = lc.LeaseEnd,

        //                                CityorCounty = county != null ? county.Name : null,
        //                                RentOwned = lc.TotalRentOwed,
        //                                RentDate = rentdue != null ? rentdue.Name : null,
        //                                LastRent = lc.LastRentPaid,
        //                                NoticePeriod = lc.CalculatedNoticeLength,
        //                                VacateDate = lc.ExpirationDate,

        //                                BuildingStreet = building.Address1 + " " + building.Address2,
        //                                BuildingCity = building.City,
        //                                BuildingState = building.State.Name,
        //                                BuildingZip = building.Zipcode,
        //                                BuildindAptno = tenant.UnitOrApartmentNumber,
        //                            }
        //                        ).FirstOrDefaultAsync();

        //        if (caseDetails == null)
        //            throw new Exception("Case details not found.");

        //        List<Guid> tenantIds = new List<Guid>();


        //        if (caseDetails.TenantIds.HasValue)
        //        {
        //            tenantIds.Add(caseDetails.TenantIds.Value);
        //        }


        //        var tenants = await _context.Tenants
        //            .Where(t => tenantIds.Contains(t.Id))
        //            .Select(t => new
        //            {
        //                FullName = t.FirstName + " " + t.LastName,
        //                ApartmentNumber = t.UnitOrApartmentNumber
        //            })
        //            .ToListAsync();

        //        var additionalTenants = await _context.AdditioanlTenants.Where(e => tenantIds.Contains(e.TenantId.Value)).Select(t => new
        //        {
        //            FullName = t.FirstName + " " + t.LastName,
        //            ApartmentNumber = " "

        //        }).ToListAsync();

        //        if (additionalTenants.Count > 0)
        //        {
        //            tenants.AddRange(additionalTenants);
        //        }

        //        var additionaloccupants = await _context.AdditionalOccupants.Where(e => e.LegalCaseId == legalCaseId).Select(t => new
        //        {
        //            FullName = t.Name + " ",
        //            ApartmentNumber = " "

        //        }).ToListAsync();

        //        if (additionaloccupants.Count > 0)
        //        {
        //            tenants.AddRange(additionaloccupants);
        //        }

        //        string firstTenantName = tenants.Count > 0 ? tenants[0].FullName : "";
        //        string firstApartmentNumber = tenants.Count > 0 ? tenants[0].ApartmentNumber : "";


        //        string lastRent = "";
        //        DateTime lastRentDate;

        //        if (DateTime.TryParseExact(caseDetails.LastRent, "MMM yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out lastRentDate) ||
        //            DateTime.TryParseExact(caseDetails.LastRent, "MMMM yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out lastRentDate))
        //        {
        //            DateTime nextMonthDate = lastRentDate.AddMonths(1);

        //            lastRent = nextMonthDate.ToString("MMMM");

        //        }

        //        string filledHtml = template.HTML
        //            .Replace("{{LandlordName}}", caseDetails.LandlordName ?? "")
        //            .Replace("{{Landlord_Name}}", caseDetails.LandlordName ?? "")
        //            .Replace("{{LandlordAddress}}", caseDetails.LandlordAddress ?? "")
        //            .Replace("{{Landlord_Address}}", caseDetails.LandlordAddress ?? "")
        //            .Replace("{{LandlordPhone}}", caseDetails.LandlordPhone ?? "")
        //            .Replace("{{Landlord_Phone}}", caseDetails.LandlordPhone ?? "")
        //            .Replace("{{LandlordEmail}}", caseDetails.LandlordEmail ?? "")
        //            .Replace("{{Landlord_Email}}", caseDetails.LandlordEmail ?? "")
        //            .Replace("{{LandlordDate}}", noticeDate.ToString("dd/MM/yyyy"))
        //            .Replace("{{Notice_Date}}", noticeDate.ToString("dd/MM/yyyy"))
        //            .Replace("{{PropertyAddress}}", caseDetails.PropertyAddress ?? "")
        //            .Replace("{{Premises_Address}}", caseDetails.PropertyAddress ?? "")
        //            .Replace("{{ApartmentNumber}}", firstApartmentNumber ?? "")
        //            .Replace("{{CurrentDate}}", DateTime.Now.ToString("dd/MM/yyyy"))
        //            .Replace("{{NumberofRoom}}", caseDetails.NumberofRoom ?? "")
        //            .Replace("{{TenantName}}", firstTenantName) // Single tenant for top
        //            .Replace("{{City_County}}", caseDetails.CityorCounty ?? "")
        //            .Replace("{{Rent_Owned}}", caseDetails.RentOwned.ToString() ?? "")
        //            .Replace("{{Rent_day}}", caseDetails.RentDate.ToString() ?? "")
        //            .Replace("{{month}}", lastRent ?? "")
        //            .Replace("{{year}}", DateTime.Now.ToString("yy") ?? "")
        //            .Replace("{{Vacate_Date}}", caseDetails.VacateDate.ToString() ?? "")
        //            .Replace("{{Notice_Period}}", caseDetails.NoticePeriod.ToString() ?? "")
        //            .Replace("{{Building_Street}}", caseDetails.BuildingStreet ?? "")
        //            .Replace("{{Building_State}}", caseDetails.BuildingState ?? "")
        //            .Replace("{{Building_AptNo}}", caseDetails.BuildindAptno ?? "")
        //            .Replace("{{Building_Zip}}", caseDetails.BuildingZip ?? "")
        //            .Replace("{{Building_City}}", caseDetails.BuildingCity ?? "")
        //            .Replace("{{Tenant_Names}}", firstTenantName);
        //        // 7. Fill up to 12 tenant names dynamically
        //        for (int i = 0; i < 12; i++)
        //        {
        //            string tenantValue = i < tenants.Count ? tenants[i].FullName : "";
        //            filledHtml = filledHtml.Replace($"{{{{TenantName{i + 1}}}}}", tenantValue);
        //        }

        //        filledHtml = filledHtml.Replace("{{lease_expired_date}}", caseDetails.LeaseEnd?.ToString("dd/MM/yyyy") ?? "");
        //        if (caseDetails.LeaseEnd != null)
        //        {
        //            Console.WriteLine("Checkbox is ticked");
        //            filledHtml = filledHtml.Replace("{{lease_expired}}", "chceked");
        //        }

        //        var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "CaseForms", caseDetails.CaseCode);
        //        Directory.CreateDirectory(folderPath);

        //        var fileName = $"{Guid.NewGuid()}.pdf";
        //        var filePath = Path.Combine(folderPath, fileName);

        //        HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();

        //        BlinkConverterSettings settings = new BlinkConverterSettings
        //        {
        //            EnableJavaScript = true,
        //            //PrintBackground = true,
        //            Margin = new PdfMargins { All = 0 },
        //            PdfPageSize = PdfPageSize.A4,
        //            Orientation = PdfPageOrientation.Portrait,
        //            ViewPortSize = new Size(920, 0)
        //        };

        //        htmlConverter.ConverterSettings = settings;

        //        PdfDocument document = htmlConverter.Convert(filledHtml, "");

        //        using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
        //        {
        //            document.Save(fileStream);
        //        }

        //        document.Close(true);

        //        var fileUrl = $"/CaseForms/{caseDetails.CaseCode}/{fileName}";
        //        var caseForm = new CaseForms
        //        {
        //            Id = Guid.NewGuid(),
        //            LegalCaseId = legalCaseId,
        //            FormTypeId = formTypeId,
        //            HTML = filledHtml,
        //            File = fileUrl,
        //            CreatedOn = DateTime.UtcNow,
        //            IsDeleted = false,
        //            CreatedBy = createdBy,

        //        };

        //        _context.CaseForms.Add(caseForm);
        //        return await _context.SaveChangesAsync() > 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error generating notice: {ex.Message}");
        //        return false;
        //    }
        //}

        public async Task<bool> GenerateNoticeAsync(Guid legalCaseId, Guid formTypeId, Guid createdBy)
        {
            try
            {
                
                string logFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "pdf_errors.log");

                void Log(string msg)
                {
                    File.AppendAllText(logFile, $"[{DateTime.UtcNow}] {msg}\n");
                    Console.WriteLine(msg);
                }

                Log("=== GenerateNoticeAsync STARTED ===");


               
                var template = await _context.MstFormTypes
                    .Where(f => f.Id == formTypeId)
                    .Select(f => new { f.HTML, f.Name })
                    .FirstOrDefaultAsync();

                if (string.IsNullOrEmpty(template?.HTML))
                    throw new Exception("Template not found.");

                Log("Template loaded.");

                DateTime noticeDate = CalculateNoticeDate(template.Name);

                
                var caseDetails = await (
                    from lc in _context.LegalCases
                    join landlord in _context.LandLords on lc.LandLordId equals landlord.Id
                    join building in _context.Buildings on lc.BuildingId equals building.Id
                    join tenant in _context.Tenants on lc.TenantId equals tenant.Id
                    join court in _context.Courts on lc.CourtId equals court.Id into cCourt
                    from court in cCourt.DefaultIfEmpty()
                    join county in _context.MstCounties on court.CountyId equals county.Id into cCounty
                    from county in cCounty.DefaultIfEmpty()
                    join rentdue in _context.MstDateRent on lc.RentDueEachMonthOrWeekId equals rentdue.Id into cRent
                    from rentdue in cRent.DefaultIfEmpty()
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
                        TenantIds = lc.TenantId,
                        LeaseEnd = lc.LeaseEnd,
                        CityorCounty = county != null ? county.Name : null,
                        RentOwned = lc.TotalRentOwed,
                        RentDate = rentdue != null ? rentdue.Name : null,
                        LastRent = lc.LastRentPaid,
                        NoticePeriod = lc.CalculatedNoticeLength,
                        VacateDate = lc.ExpirationDate,
                        BuildingStreet = building.Address1 + " " + building.Address2,
                        BuildingCity = building.City,
                        BuildingState = building.State.Name,
                        BuildingZip = building.Zipcode,
                        BuildindAptno = tenant.UnitOrApartmentNumber
                    }
                ).FirstOrDefaultAsync();


                if (caseDetails == null)
                    throw new Exception("Case details not found.");

                Log("Case data loaded.");


                
                List<Guid> tenantIds = new();

                if (caseDetails.TenantIds.HasValue)
                    tenantIds.Add(caseDetails.TenantIds.Value);

                var tenants = await _context.Tenants
                    .Where(t => tenantIds.Contains(t.Id))
                    .Select(t => new { FullName = t.FirstName + " " + t.LastName, ApartmentNumber = t.UnitOrApartmentNumber })
                    .ToListAsync();

                var additionalTenants = await _context.AdditioanlTenants
                    .Where(e => tenantIds.Contains(e.TenantId.Value))
                    .Select(t => new { FullName = t.FirstName + " " + t.LastName, ApartmentNumber = " " })
                    .ToListAsync();

                tenants.AddRange(additionalTenants);

                var additionalOccupants = await _context.AdditionalOccupants
                    .Where(e => e.LegalCaseId == legalCaseId)
                    .Select(t => new { FullName = t.Name + " ", ApartmentNumber = " " })
                    .ToListAsync();

                tenants.AddRange(additionalOccupants);

                Log($"Total Tenants found: {tenants.Count}");


               
                string firstTenantName = tenants.Count > 0 ? tenants[0].FullName : "";
                string firstApartmentNumber = tenants.Count > 0 ? tenants[0].ApartmentNumber : "";

                string lastRent = "";
                if (DateTime.TryParseExact(caseDetails.LastRent, "MMM yyyy", CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out var lastRentDate) ||
                    DateTime.TryParseExact(caseDetails.LastRent, "MMMM yyyy", CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out lastRentDate))
                {
                    lastRent = lastRentDate.AddMonths(1).ToString("MMMM");
                }

                string filledHtml = template.HTML
                    .Replace("{{LandlordName}}", caseDetails.LandlordName ?? "")
                    .Replace("{{Landlord_Name}}", caseDetails.LandlordName ?? "")
                    .Replace("{{LandlordAddress}}", caseDetails.LandlordAddress ?? "")
                    .Replace("{{Landlord_Address}}", caseDetails.LandlordAddress ?? "")
                    .Replace("{{LandlordPhone}}", caseDetails.LandlordPhone ?? "")
                    .Replace("{{Landlord_Phone}}", caseDetails.LandlordPhone ?? "")
                    .Replace("{{LandlordEmail}}", caseDetails.LandlordEmail ?? "")
                    .Replace("{{Landlord_Email}}", caseDetails.LandlordEmail ?? "")
                    .Replace("{{LandlordDate}}", noticeDate.ToString("dd/MM/yyyy"))
                    .Replace("{{Notice_Date}}", noticeDate.ToString("dd/MM/yyyy"))
                    .Replace("{{PropertyAddress}}", caseDetails.PropertyAddress ?? "")
                    .Replace("{{Premises_Address}}", caseDetails.PropertyAddress ?? "")
                    .Replace("{{ApartmentNumber}}", firstApartmentNumber ?? "")
                    .Replace("{{CurrentDate}}", DateTime.Now.ToString("dd/MM/yyyy"))
                    .Replace("{{NumberofRoom}}", caseDetails.NumberofRoom ?? "")
                    .Replace("{{TenantName}}", firstTenantName)
                    .Replace("{{City_County}}", caseDetails.CityorCounty ?? "")
                    .Replace("{{Rent_Owned}}", caseDetails.RentOwned.ToString())
                    .Replace("{{Rent_day}}", caseDetails.RentDate ?? "")
                    .Replace("{{month}}", lastRent ?? "")
                    .Replace("{{year}}", DateTime.Now.ToString("yy"))
                    .Replace("{{Vacate_Date}}", caseDetails.VacateDate.ToString())
                    .Replace("{{Notice_Period}}", caseDetails.NoticePeriod.ToString())
                    .Replace("{{Building_Street}}", caseDetails.BuildingStreet ?? "")
                    .Replace("{{Building_State}}", caseDetails.BuildingState ?? "")
                    .Replace("{{Building_AptNo}}", caseDetails.BuildindAptno ?? "")
                    .Replace("{{Building_Zip}}", caseDetails.BuildingZip ?? "")
                    .Replace("{{Building_City}}", caseDetails.BuildingCity ?? "")
                    .Replace("{{Tenant_Names}}", firstTenantName);

                for (int i = 0; i < 12; i++)
                {
                    string tenantValue = i < tenants.Count ? tenants[i].FullName : "";
                    filledHtml = filledHtml.Replace($"{{{{TenantName{i + 1}}}}}", tenantValue);
                }

                if (caseDetails.LeaseEnd != null)
                    filledHtml = filledHtml.Replace("{{lease_expired}}", "checked");

                filledHtml = filledHtml.Replace("{{lease_expired_date}}",
                    caseDetails.LeaseEnd?.ToString("dd/MM/yyyy") ?? "");


                Log("HTML filled successfully.");


              
                string root = Path.Combine(Directory.GetCurrentDirectory());
                string caseFolder = Path.Combine(root, "CaseForms", caseDetails.CaseCode);

                Directory.CreateDirectory(caseFolder);

                string fileName = $"{Guid.NewGuid()}.pdf";
                string filePath = Path.Combine(caseFolder, fileName);

                string baseUrl =
                    _httpContextAccessor.HttpContext.Request.Scheme + "://" +
                    _httpContextAccessor.HttpContext.Request.Host + "/";

                Log($"Base URL = {baseUrl}");

                
                HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();

                var settings = new BlinkConverterSettings
                {
                    EnableJavaScript = true,
                    // PrintBackground removed because your Syncfusion version doesn't have it
                    AdditionalDelay = 1500,                     
                    ViewPortSize = new Syncfusion.Drawing.Size(920, 0),
                    PdfPageSize = PdfPageSize.A4,
                    Orientation = PdfPageOrientation.Portrait,
                    Margin = new PdfMargins { Left = 0, Right = 0, Top = 0, Bottom = 0 }
                };

                htmlConverter.ConverterSettings = settings;

                PdfDocument pdf;

                try
                {
                    Log("Attempting HTML → PDF conversion...");
                    pdf = htmlConverter.Convert(filledHtml, baseUrl);
                    Log("HTML → PDF Success!");
                }
                catch (Exception ex)
                {
                    Log($"SYNCFUSION FAILURE: {ex}");
                    throw;
                }

                using (var fs = new FileStream(filePath, FileMode.Create))
                {
                    pdf.Save(fs);
                }

                pdf.Close(true);

                Log($"PDF Saved: {filePath}");

                var caseForm = new CaseForms
                {
                    Id = Guid.NewGuid(),
                    LegalCaseId = legalCaseId,
                    FormTypeId = formTypeId,
                    HTML = filledHtml,
                    File = $"/CaseForms/{caseDetails.CaseCode}/{fileName}",
                    CreatedOn = DateTime.UtcNow,
                    CreatedBy = createdBy,
                    IsDeleted = false
                };

                _context.CaseForms.Add(caseForm);
                await _context.SaveChangesAsync();

                Log("DB Save Success.");
                Log("=== GenerateNoticeAsync COMPLETED ===");

                return true;
            }
            catch (Exception ex)
            {
                string finalLog = $"ERROR in GenerateNoticeAsync: {ex}";
                File.AppendAllText(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "pdf_errors.log"), finalLog);
                Console.WriteLine(finalLog);

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
            else if (formName.ToLower().Contains("60 days"))
                noticeDays = 60;
            else if (formName.ToLower().Contains("30 days"))
                noticeDays = 30;


            return DateTime.Now.AddDays(noticeDays);
        }

        //public async Task<byte[]?> GetPdfBytesAsync(Guid id)
        //{
        //    var caseForm = await _context.CaseForms
        //        .FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted != true);

        //    if (caseForm == null || string.IsNullOrWhiteSpace(caseForm.HTML))
        //        return null;

        //    await new BrowserFetcher().DownloadAsync();
        //    await using var browser = await Puppeteer.LaunchAsync(new LaunchOptions
        //    {
        //        Headless = true,
        //        Args = new[] { "--no-sandbox" }
        //    });


        //    var page = await browser.NewPageAsync();
        //    await page.SetContentAsync(caseForm.HTML, new NavigationOptions
        //    {
        //        WaitUntil = new[] { WaitUntilNavigation.Networkidle0 }
        //    });

        //    var pdfBytes = await page.PdfDataAsync(new PdfOptions
        //    {
        //        Format = PaperFormat.A4,
        //        PrintBackground = true
        //    });

        //    return pdfBytes;
        //}
    }
}
