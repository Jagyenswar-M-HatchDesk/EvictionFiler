using System.Drawing.Printing;
using System.Globalization;
using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Infrastructure.DbContexts;
using EvictionFiler.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using EvictionFiler.Application.Constants;



namespace EvictionFiler.Infrastructure.Repositories
{
    public class CaseFormRepository : Repository<CaseForms>, ICaseFormRepository
    {
        private readonly MainDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _config;

        public CaseFormRepository(MainDbContext context, IHttpContextAccessor httpContextAccessor, IConfiguration config) : base(context)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _config = config;
        }

        public async Task<bool> GenerateWarrantNoticeAsync(Guid legalCaseId, string formTypeName, Guid createdBy)
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

                // --------------------
                // LOAD TEMPLATE
                // --------------------
                var template = await _context.MstFormTypes
    .Where(f => f.Name.Trim().ToLower() == formTypeName.Trim().ToLower())

       .Select(f => new { f.HTML, f.Id, f.Name })
       .FirstOrDefaultAsync();

                if (template == null)
                    throw new Exception("Form Type not found by name.");

                var caseDetails = await
            (
                from lc in _context.LegalCases

                join landlord in _context.LandLords
                    on lc.LandLordId equals landlord.Id into ll
                from landlord in ll.DefaultIfEmpty()

                join building in _context.Buildings
                    on lc.BuildingId equals building.Id into bl
                from building in bl.DefaultIfEmpty()

                join tenant in _context.Tenants
                    on lc.TenantId equals tenant.Id into tl
                from tenant in tl.DefaultIfEmpty()

                join court in _context.Courts
                    on lc.CourtLocationId equals court.Id into cl
                from court in cl.DefaultIfEmpty()

                join county in _context.MstCounties
                    on court.CountyId equals county.Id into col
                from county in col.DefaultIfEmpty()

                join marshal in _context.Marshal
                    on lc.MarshalId equals marshal.Id into ms
                from marshal in ms.DefaultIfEmpty()

                    // LEFT JOIN CaseNoticeInfo


                    // LEFT JOIN Ledger (only if notice exists)


                    // LEFT JOIN Tenancy Type


                where lc.Id == legalCaseId

                select new
                {
                    Id = lc.Id,
                    CaseCode = lc.Casecode,

                    LandlordName = landlord != null
                        ? landlord.FirstName + " " + landlord.LastName
                        : null,

                    LandlordAddress = landlord != null
                        ? landlord.Address1 + " " + landlord.Address2 + " " +
                          landlord.City + " " +
                          (landlord.State != null ? landlord.State.Name : "") + " " +
                          landlord.Zipcode
                        : null,

                    LandlordPhone = landlord.Phone,
                    LandlordEmail = landlord.Email,

                    PropertyAddress = building != null
                        ? building.Address1 + " " + building.Address2 + " " +
                          (building.Cities != null ? building.Cities.Name : "") + " " +
                          (building.State != null ? building.State.Name : "") + " " +
                          building.Zipcode
                        : null,

                    NumberofRoom = building != null
                        ? building.BuildingUnits.ToString()
                        : null,

                    TenantIds = lc.TenantId,
                    LeaseEnd = lc.LeaseEnd,

                    CityorCounty = county != null
                        ? county.Name
                        : building != null && building.Cities != null
                            ? building.Cities.Name
                            : null,



                    BuildingStreet = building != null
                        ? building.Address1 + " " + building.Address2
                        : null,

                    BuildingCity = building.Cities.Name,
                    BuildingState = building.State.Name,
                    BuildingZip = building.Zipcode,

                    BuildindAptno = tenant.UnitOrApartmentNumber,

                    leaseExpired = lc.DateNoticeServed,



                    County = county.Name,
                    Court = court.Court,
                    CourtAddress = court.Address,


                    IndexNo = lc.Index,
                    MarshalName = marshal.FirstName + " " + marshal.LastName,
                    MarshalPhone = marshal.Telephone,
                    MarshalAddress = marshal.OfficeAddress,
                    MarshalBadge = marshal.BadgeNumber,
                    marshalFax = marshal.Fax,
                    marshalDocket = marshal.DocketNo,

                }
            )
            .FirstOrDefaultAsync();

                if (caseDetails == null)
                    throw new Exception("Case details not found.");

                List<Guid> tenantIds = new();

                if (caseDetails.TenantIds.HasValue)
                    tenantIds.Add(caseDetails.TenantIds.Value);

                var tenants = await _context.Tenants
                    .Where(t => tenantIds.Contains(t.Id))
                    .Select(t => new { FullName = t.FirstName + " " + t.LastName, ApartmentNumber = t.UnitOrApartmentNumber })
                    .ToListAsync();

                var additionalTenants = await _context.CaseAdditionalTenants
                    .Where(e => e.LegalCaseId == legalCaseId)
                    .Select(t => new { FullName = t.FirstName + " " + t.LastName, ApartmentNumber = "" })
                    .ToListAsync();

                tenants.AddRange(additionalTenants);

                var additionalOccupants = await _context.AdditionalOccupants
                    .Where(e => e.LegalCaseId == legalCaseId)
                    .Select(t => new { FullName = t.Name, ApartmentNumber = "" })
                    .ToListAsync();

                tenants.AddRange(additionalOccupants);

                Log($"Total Tenants found: {tenants.Count}");

                // --------------------
                // HTML VARIABLE REPLACEMENT
                // --------------------
                string firstTenantName = tenants.Count > 0 ? tenants[0].FullName : "";
                string firstApartmentNumber = tenants.Count > 0 ? tenants[0].ApartmentNumber : "";

                var otherTenantsList = additionalTenants.Select(x => x.FullName).ToList();

                // Occupants (already separate list)
                var occupantList = additionalOccupants.Select(x => x.FullName).ToList();

                string otherTenantsText = "";
                if (otherTenantsList.Any())
                {
                    otherTenantsText =

                        "<br>" + string.Join(",", otherTenantsList);
                }

                string occupantsText = "";
                if (occupantList.Any())
                {
                    occupantsText =

                       "<br>" + string.Join(",", occupantList);
                }

                string filledHtml = template.HTML;


                // ----------------------------------------------------------------------
                // ADD CSS TO REMOVE SCROLLBARS (IRONPDF limitation fix)
                // ----------------------------------------------------------------------
                string cssPatch = @"
        <style>
            html, body { overflow: visible !important; height: auto !important; }
            * { overflow: visible !important; }
        </style>
    ";

                filledHtml = filledHtml.Replace("</head>", cssPatch + "</head>");
                filledHtml = template.HTML
    .Replace("{{LandlordName}}", caseDetails.LandlordName ?? "")
    .Replace("{{Landlord_Name}}", caseDetails.LandlordName ?? "")
    .Replace("{{LandlordAddress}}", caseDetails.LandlordAddress ?? "")
    .Replace("{{Landlord_Address}}", caseDetails.LandlordAddress ?? "")
    .Replace("{{Notice_Date}}", DateTime.Now.ToString(DateFormats.Default))
    .Replace("{{PropertyAddress}}", caseDetails.PropertyAddress ?? "")
    .Replace("{{Premises_Address}}", caseDetails.PropertyAddress ?? "")
    .Replace("{{CurrentDate}}", DateTime.Now.ToString(DateFormats.Default))
    .Replace("{{NumberofRoom}}", caseDetails.NumberofRoom ?? "")
    .Replace("{{TenantName}}", firstTenantName)
    .Replace("{{Tenant_Names}}", firstTenantName)
                   .Replace("{{OtherTenants}}", otherTenantsText ?? "")
    //.Replace("{{UnderTenants_Name}}", occupantsText)
    .Replace("{{Occupants}}", occupantsText ?? "")
    .Replace("{{Court}}", caseDetails.Court ?? "")
    .Replace("{{County}}", caseDetails.County ?? "")
    .Replace("{{Court_Address}}", caseDetails.County ?? "")
    .Replace("{{Index}}", caseDetails.IndexNo ?? "")
    .Replace("{{Marshal_Name}}", caseDetails.MarshalName ?? "")
    .Replace("{{Marshal_Badge}}", caseDetails.MarshalBadge ?? "")
    .Replace("{{Marshal_Address}}", caseDetails.MarshalAddress ?? "")
    .Replace("{{Marshal_Fax}}", caseDetails.marshalFax ?? "")
    .Replace("{{Marshakl_Docket}}", caseDetails.marshalDocket ?? "")
    .Replace("{{marshal_Phone}}", caseDetails.MarshalPhone ?? "")
    ;
                Console.WriteLine("Filled Html - " + filledHtml);
                // --------------------
                // CREATE FOLDER
                // --------------------
                string root = Directory.GetCurrentDirectory();
                string caseFolder = Path.Combine(root, "CaseForms", caseDetails.CaseCode);
                Directory.CreateDirectory(caseFolder);

                string fileName = $"{Guid.NewGuid()}.pdf";
                string filePath = Path.Combine(caseFolder, fileName);

                // --------------------
                // IRONPDF GENERATION
                // --------------------
                Log("IronPDF Rendering Start...");

                var renderer = new ChromePdfRenderer();
                renderer.RenderingOptions.MarginTop = 0;
                renderer.RenderingOptions.MarginBottom = 0;
                renderer.RenderingOptions.MarginLeft = 0;
                renderer.RenderingOptions.MarginRight = 0;

                renderer.RenderingOptions.EnableJavaScript = true;
                renderer.RenderingOptions.Timeout = 60000; // 60 seconds

                renderer.RenderingOptions.PaperSize = IronPdf.Rendering.PdfPaperSize.A4;

                // Convert HTML → PDF
                await Task.Delay(200);
                var pdf = renderer.RenderHtmlAsPdf(filledHtml);

                Log("IronPDF Rendering Success.");

                pdf.SaveAs(filePath);
                Log($"PDF Saved: {filePath}");
                // --------------------
                // SAVE DB ENTRY
                // --------------------
                var caseForm = new CaseForms
                {
                    Id = Guid.NewGuid(),
                    LegalCaseId = legalCaseId,
                    FormTypeId = template.Id,
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

                // --------------------
                // LOAD TEMPLATE
                // --------------------
                var template = await _context.MstFormTypes
                    .Where(f => f.Id == formTypeId)
                    .Select(f => new { f.HTML, f.Name })
                    .FirstOrDefaultAsync();

                if (string.IsNullOrEmpty(template?.HTML))
                    throw new Exception("Template not found.");

                Log("Template loaded.");

                DateTime noticeDate = CalculateNoticeDate(template.Name);

                // --------------------
                // LOAD CASE DATA
                // --------------------
                var testNotice = await _context.CaseNoticeInfo
    .Where(x =>
        x.LegalCaseId == legalCaseId &&
        x.FormtypeId == formTypeId
    )
    .ToListAsync();

                var caseDetails = await
             (
                 from lc in _context.LegalCases where lc.Id == legalCaseId

                 join landlord in _context.LandLords
                     on lc.LandLordId equals landlord.Id into ll
                 from landlord in ll.DefaultIfEmpty()

                 join building in _context.Buildings
                     on lc.BuildingId equals building.Id into bl
                 from building in bl.DefaultIfEmpty()

                 join tenant in _context.Tenants
                     on lc.TenantId equals tenant.Id into tl
                 from tenant in tl.DefaultIfEmpty()

                 join court in _context.Courts
                     on lc.CourtLocationId equals court.Id into cl
                 from court in cl.DefaultIfEmpty()

                 join county in _context.MstCounties
                     on court.CountyId equals county.Id into col
                 from county in col.DefaultIfEmpty()

                 join rentdue in _context.MstDateRent
                     on lc.RentDueEachMonthOrWeekId equals rentdue.Id into rl
                 from rentdue in rl.DefaultIfEmpty()

                 join tenancylc in _context.MstTenancyTypes
                    on lc.TenancyTypeId equals tenancylc.Id into ttlc
                 from tenancylc in ttlc.DefaultIfEmpty()

                 join courtPart in _context.CourtPart
                    on lc.CourtPartId equals courtPart.Id into cp
                 from courtPart in cp.DefaultIfEmpty()

                     // LEFT JOIN CaseNoticeInfo
                 join notice in _context.CaseNoticeInfo
                    on new { CaseId = (Guid?)lc.Id, FormTypeId = (Guid?)formTypeId }
                    equals new { CaseId = notice.LegalCaseId, FormTypeId = notice.FormtypeId }
                    into nl
                 from notice in nl.DefaultIfEmpty()


                     // LEFT JOIN Ledger (only if notice exists)
                 join ledger in _context.ArrearLedgers
                     on notice.Id equals ledger.CaseNoticeId into al
                 from ledger in al.DefaultIfEmpty()

                     // LEFT JOIN Tenancy Type
                 join tenancy in _context.MstTenancyTypes
                     on notice.TenancyTypeId equals tenancy.Id into ttl
                 from tenancy in ttl.DefaultIfEmpty()

                 join arrearledger in _context.ArrearLedgers
                 on lc.Id equals arrearledger.LegalCaseId into arrearLedgers


                 where lc.Id == legalCaseId

                 
                 select new
                 {
                     Id = lc.Id,
                     CaseCode = lc.Casecode,

                     LandlordName = landlord != null
        ? landlord.FirstName + " " + landlord.LastName
        : null,

                     LandlordAddress = landlord != null
        ? (landlord.Address1 ?? "") + " " +
          (landlord.Address2 ?? "") + " " +
          (landlord.City != null ? landlord.City.Name : "") + " " +
          (landlord.State != null ? landlord.State.Name : "") + " " +
          (landlord.Zipcode ?? "")
        : null,

                     LandlordPhone = landlord.Phone,
                     LandlordEmail = landlord.Email,

                     PropertyAddress = building != null
        ? (building.Address1 ?? "") + " " +
          (building.Address2 ?? "") + " " +
          (building.Cities != null ? building.Cities.Name : "") + " " +
          (building.State != null ? building.State.Name : "") + " " +
          (building.Zipcode ?? "")
        : null,

                     NumberofRoom = building != null
        ? building.BuildingUnits.ToString()
        : null,

                     TenantIds = lc.TenantId,
                     LeaseEnd = lc.LeaseEnd,

                     CityorCounty = county != null
        ? county.Name
        : (building.Cities != null ? building.Cities.Name : null),

                     RentOwned = lc.TotalRentOwed,
                     RentDate = rentdue.Name,

                     LastRent = notice.DateofLastPayment ?? lc.LastPaymentDate,

                     NoticePeriod = notice.CalcNoticeLength ?? lc.CalculatedNoticeLength,

                     Noticetype = notice.FormType!.Name,

                     VacateDate =
        notice != null &&
        notice.DateNoticeServed.HasValue &&
        lc.CalculatedNoticeLength.HasValue
            ? notice.DateNoticeServed.Value.AddDays(lc.CalculatedNoticeLength.Value)
            : (DateOnly?)null,

                     VacateDatelc = lc.CalculatedNoticeLength.HasValue
        ? DateTime.Now.AddDays(lc.CalculatedNoticeLength.Value)
        : (DateTime?)null,

                     BuildingStreet = building != null
        ? (building.Address1 ?? "") + " " + (building.Address2 ?? "")
        : null,

                     BuildingCity = building.Cities.Name,
                     BuildingState = building.State.Name,
                     BuildingZip = building.Zipcode,

                     BuildindAptno = tenant.UnitOrApartmentNumber,

                     NoticeDate = notice.DateNoticeServed,
                     LeaseExpired = lc.LeaseEnd,

                     TenancyType = tenancy.Name ?? tenancylc.Name,

                     County = county.Name,
                     Court = court.Court,
                     CourtAddress = court.Address,

                     TotalOwed = notice.Totalowed
        ?? (lc.TotalRentOwed.HasValue ? (int)lc.TotalRentOwed!.Value : 0),

                     IndexNo = lc.Index,
                     MonthlyRent = lc.MonthlyRent,
                     ArrearLedgers  = arrearLedgers.OrderBy(e=>e.Month).ToList(),
                     RentReulation = building.RegulationStatus!.Name,
                     ManagingAgent = building.ManagingAgent,
                     RegulationBasis = building.ExemptionBasis!.Name ?? building.ExemptionBasisOther,
                     GoodCauseAppliable = building.GoodCause == true ? "good cause applicable" : "not good cause applicable because",
                     GoodCauseExemption = building.ExemptionReason!.Name,
                     Room_Part = $"{courtPart.RoomNo} / {courtPart.Part}",
                     PrimisesType = building.PremiseType.Name,
                     MultipleDewlling = building.PremiseType.Name.Contains("Multiple Dwelling") ? $"There is a currently effective registration on file with HPD/DOF designating {building.ManagingAgent} as managing agent." : "",

                 }

             )
             .FirstOrDefaultAsync();


                if (caseDetails == null)
                    throw new Exception("Case details not found.");

                Log("Case data loaded.");

                // --------------------
                // LOAD TENANTS
                // --------------------
                List<Guid> tenantIds = new();

                if (caseDetails.TenantIds.HasValue)
                    tenantIds.Add(caseDetails.TenantIds.Value);

                var tenants = await _context.Tenants
                    .Where(t => tenantIds.Contains(t.Id))
                    .Select(t => new { FullName = t.FirstName + " " + t.LastName, ApartmentNumber = t.UnitOrApartmentNumber })
                    .ToListAsync();

                var additionalTenants = await _context.CaseAdditionalTenants
                    .Where(e => e.LegalCaseId == legalCaseId)
                    .Select(t => new { FullName = t.FirstName + " " + t.LastName, ApartmentNumber = "" })
                    .ToListAsync();

                tenants.AddRange(additionalTenants);

                var additionalOccupants = await _context.AdditionalOccupants
                    .Where(e => e.LegalCaseId == legalCaseId)
                    .Select(t => new { FullName = t.Name, ApartmentNumber = "" })
                    .ToListAsync();

                tenants.AddRange(additionalOccupants);

                Log($"Total Tenants found: {tenants.Count}");

                // --------------------
                // HTML VARIABLE REPLACEMENT
                // --------------------
                string firstTenantName = tenants.Count > 0 ? tenants[0].FullName : "";
                string firstApartmentNumber = tenants.Count > 0 ? tenants[0].ApartmentNumber : "";

                var otherTenantsList = additionalTenants.Select(x => x.FullName).ToList();

                // Occupants (already separate list)
                var occupantList = additionalOccupants.Select(x => x.FullName).ToList();

                string otherTenantsText = "";
                if (otherTenantsList.Any())
                {
                    otherTenantsText =

                        string.Join(",", otherTenantsList) + " (Tenant)";
                }

                string occupantsText = "";
                if (occupantList.Any())
                {
                    occupantsText =

                       "<br>" + string.Join(",", occupantList) + ", John Doe, Jane Doe (Under Tenant)";
                }


                // Parse last rent
                string lastRentMonth = "";
                string lastRentYear = "";
                if (caseDetails.LastRent != null)
                {
                    lastRentMonth = caseDetails.LastRent.Value.AddMonths(1).ToString("MMMM");
                    lastRentYear = caseDetails.LastRent.Value.ToString("yy");
                }

                string filledHtml = template.HTML
    .Replace("{{LandlordName}}", caseDetails.LandlordName ?? "")
    .Replace("{{Landlord_Name}}", caseDetails.LandlordName ?? "")
    .Replace("{{Landlord_NameDemand}}", caseDetails.LandlordName + " (LandLord)" ?? "")
    .Replace("{{LandlordAddress}}", caseDetails.LandlordAddress ?? "")
    .Replace("{{Landlord_Address}}", caseDetails.LandlordAddress ?? "")
    .Replace("{{LandlordPhone}}", caseDetails.LandlordPhone ?? "")
    .Replace("{{Landlord_Phone}}", caseDetails.LandlordPhone ?? "")
    .Replace("{{LandlordEmail}}", caseDetails.LandlordEmail ?? "")
    .Replace("{{Landlord_Email}}", caseDetails.LandlordEmail ?? "")
    .Replace("{{LandlordDate}}", noticeDate.ToString(DateFormats.Default))
    .Replace("{{Notice_Date}}", caseDetails.NoticeDate?.ToString(DateFormats.Default) ?? DateTime.Now.ToString(DateFormats.Default))
    .Replace("{{PropertyAddress}}", caseDetails.PropertyAddress ?? "")
    .Replace("{{Premises_Address}}", caseDetails.PropertyAddress ?? "")
    .Replace("{{ApartmentNumber}}", firstApartmentNumber ?? "")
    .Replace("{{CurrentDate}}", DateTime.Now.ToString(DateFormats.Default))
    .Replace("{{NumberofRoom}}", caseDetails.NumberofRoom ?? "")
    .Replace("{{TenantName}}", firstTenantName)
    .Replace("{{City_County}}", caseDetails.CityorCounty ?? "")
    .Replace("{{Rent_Owned}}", caseDetails.RentOwned.ToString())
    .Replace("{{Rent_day}}", caseDetails.RentDate ?? "")
    .Replace("{{month}}", lastRentMonth ?? "")
    .Replace("{{year}}", lastRentYear ?? "")
    .Replace("{{Vacate_Date}}", caseDetails.VacateDate?.ToString(DateFormats.Default) ?? caseDetails.VacateDatelc?.ToString(DateFormats.Default))
    .Replace("{{NP}}", caseDetails.NoticePeriod.ToString())
    .Replace("{{Building_Street}}", caseDetails.BuildingStreet ?? "")
    .Replace("{{Building_State}}", caseDetails.BuildingState ?? "")
    .Replace("{{Building_AptNo}}", caseDetails.BuildindAptno ?? "")
    .Replace("{{Building_Zip}}", caseDetails.BuildingZip ?? "")
    .Replace("{{Building_City}}", caseDetails.BuildingCity ?? "")
    //.Replace("{{LeaseExpiredDate}}", caseDetails.LeaseExpired.ToString())
    .Replace("{{RentalExpiredDate}}", "")
    .Replace("{{MoveOutDate}}", "")
    .Replace("{{Floors}}", "")
    .Replace("{{Tenancy_Type}}", caseDetails.TenancyType ?? "")
    .Replace("{{Tenant_Names}}", firstTenantName)
                   .Replace("{{OtherTenants}}", otherTenantsText ?? "")
    //.Replace("{{UnderTenants_Name}}", occupantsText)
    .Replace("{{Occupants}}", occupantsText ?? "")
    .Replace("{{Court}}", caseDetails.Court ?? "")
    .Replace("{{County}}", caseDetails.County ?? "")
    .Replace("{{COUNTY}}", caseDetails.County.ToUpper() ?? "")
    .Replace("{{Court_Address}}", caseDetails.County ?? "")
    .Replace("{{Index}}", caseDetails.IndexNo ?? "")
    .Replace("{{Ledger_Total}}", caseDetails.TotalOwed.ToString() ?? "00")
    .Replace("{{Monthly_Rent}}", caseDetails.MonthlyRent.ToString() ?? "00")
    .Replace("{{LastRentDate}}", caseDetails.LastRent?.ToString(DateFormats.Default) ?? "")
    .Replace("{{RentRegulationStatus}}", caseDetails.RentReulation ?? "")
    .Replace("{{RegulationBasis}}", caseDetails.RegulationBasis ?? "")
    .Replace("{{ManagingAgent}}", caseDetails.ManagingAgent ?? "")
    .Replace("{{GoodCauseApplicable}}", caseDetails.GoodCauseAppliable ?? "")
    .Replace("{{GoodCauseExemption}}", caseDetails.GoodCauseExemption ?? "")
    .Replace("{{Noticetype}}", caseDetails.Noticetype ?? "")
    .Replace("{{Rooom_Part}}", caseDetails.Room_Part ?? "")
    .Replace("{{PrimisesType}}", caseDetails.PrimisesType ?? "")
    .Replace("{{ifmultiple_dwelling}}", caseDetails.MultipleDewlling ?? "")
    ;


                for (int i = 0; i < 12; i++)
                {
                    string tenantValue = i < tenants.Count ? tenants[i].FullName : "";
                    filledHtml = filledHtml.Replace($"{{TenantName{i + 1}}}", tenantValue);
                }
                for (int i = 0; i < 12; i++)
                {
                    var ledger = i < caseDetails.ArrearLedgers.Count
                        ? caseDetails.ArrearLedgers[i]
                        : null;

                    string? arrearledgerAmount = null;

                    string? monthName = null;
                    string? year = null;
                    if (ledger != null)
                    {
                        arrearledgerAmount = ledger?.Amount.ToString();

                        if (!string.IsNullOrEmpty(ledger?.Month))
                        {
                            // Month value is in format yyyy-MM
                            var dt = DateTime.ParseExact(ledger.Month, "yyyy-MM", null);

                            monthName = dt.ToString("MMMM"); // e.g., November
                            year = dt.ToString("yy");      // e.g., 2025
                        }
                    }
                    

                    filledHtml = filledHtml.Replace($"{{{{arRent{i + 1}}}}}", arrearledgerAmount ?? "_____");
                    filledHtml = filledHtml.Replace($"{{{{arMonth{i + 1}}}}}", monthName ?? "_______");
                    filledHtml = filledHtml.Replace($"{{{{ary{i + 1}}}}}", year ?? "____");
                }

                if (caseDetails.LeaseEnd != null)
                    filledHtml = filledHtml.Replace("{{lease_expired}}", "checked");

                filledHtml = filledHtml.Replace("{{lease_expired_date}}",
                    caseDetails.LeaseEnd?.ToString(DateFormats.Default) ?? "");

                Log("HTML filled successfully.");

                // ----------------------------------------------------------------------
                // ADD CSS TO REMOVE SCROLLBARS (IRONPDF limitation fix)
                // ----------------------------------------------------------------------
                string fontPath = Path.Combine(
                                            Directory.GetCurrentDirectory(),
                                            "wwwroot", "fonts", "arialuni.otf"
                                        ).Replace("\\", "/");

                string fontUrl = $"file:///{fontPath}";

                string cssPatch = @"
        <style>
            html, body { overflow: visible !important; height: auto !important; }
            * { overflow: visible !important; }
        </style>
    ";

                filledHtml = filledHtml.Replace("</head>", cssPatch + "</head>");

                // --------------------
                // CREATE FOLDER
                // --------------------
                string root = Directory.GetCurrentDirectory();
                string caseFolder = Path.Combine(root, "CaseForms", caseDetails.CaseCode);
                Directory.CreateDirectory(caseFolder);

                string fileName = $"{Guid.NewGuid()}.pdf";
                string filePath = Path.Combine(caseFolder, fileName);

                // --------------------
                // IRONPDF GENERATION
                // --------------------
                Log("IronPDF Rendering Start...");

                var renderer = new ChromePdfRenderer();
                renderer.RenderingOptions.MarginTop = 0;
                renderer.RenderingOptions.MarginBottom = 0;
                renderer.RenderingOptions.MarginLeft = 0;
                renderer.RenderingOptions.MarginRight = 0;
                renderer.RenderingOptions.PaperSize = IronPdf.Rendering.PdfPaperSize.A4;

                // Convert HTML → PDF
                var pdf = renderer.RenderHtmlAsPdf(filledHtml);

                Log("IronPDF Rendering Success.");

                pdf.SaveAs(filePath);
                Log($"PDF Saved: {filePath}");

                // --------------------
                // SAVE DB ENTRY
                // --------------------
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
