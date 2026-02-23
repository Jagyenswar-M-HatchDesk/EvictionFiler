using BlazorDownloadFile;
//using Blazored.SessionStorage;
using Blazored.Toast;
using EvictionFiler.Application;
using EvictionFiler.Application.Common.Interfaces;
using EvictionFiler.Application.DTOs;
using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Application.Interfaces.IRepository.MasterRepository;
using EvictionFiler.Application.Interfaces.IServices;
using EvictionFiler.Application.Interfaces.IServices.Master;
using EvictionFiler.Application.Interfaces.IUserRepository;
using EvictionFiler.Application.Services;
using EvictionFiler.Application.Services.Helper;
using EvictionFiler.Application.Services.Master;
using EvictionFiler.Client.AuthService;
using EvictionFiler.Client.SpinnerService;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Infrastructure;
using EvictionFiler.Infrastructure.DbContexts;
using EvictionFiler.Infrastructure.Extensions;
using EvictionFiler.Infrastructure.Identity;
using EvictionFiler.Infrastructure.Repositories;
using EvictionFiler.Server.Components;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Radzen;
using System.Security.Claims;
using static System.Net.WebRequestMethods;



var builder = WebApplication.CreateBuilder(args);


// Add services to the container
builder.Services.AddRazorPages()
    .AddMvcOptions(options =>
    {
        options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
    });
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();
builder.Services.AddServerSideBlazor()
    .AddCircuitOptions(options => { options.DetailedErrors = true; });

builder.Services.AddIdentity<User, Role>(options =>
{
    // Optional: customize password, lockout, etc.
    options.Password.RequireDigit = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
})
.AddEntityFrameworkStores<MainDbContext>()
.AddDefaultTokenProviders();
builder.Services.AddBlazorDownloadFile();
builder.Services.AddRadzenComponents();

builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();
builder.Services.AddScoped(sp =>
{
    var nav = sp.GetRequiredService<NavigationManager>();
    return new HttpClient { BaseAddress = new Uri(nav.BaseUri) };
});
builder.Services.AddRateLimiter(options =>
{
    options.AddFixedWindowLimiter("login", opt =>
    {
        opt.PermitLimit = 5;
        opt.Window = TimeSpan.FromMinutes(1);
        opt.QueueLimit = 0;
    });
});


builder.Services.AddDbContext<MainDbContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("Default"),
        sqlOptions => sqlOptions.MigrationsAssembly("EvictionFiler.Infrastructure")
    )

);
//builder.Services.AddBlazoredSessionStorage();


string ironKey = builder.Configuration["IronPdf:Key"]!;
License.LicenseKey = ironKey;
builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NavigationStateMessage>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<ContextMenuService>();

builder.Services.AddScoped<ICourtService, CourtService>();
builder.Services.AddScoped<ICourtRepository, CourtRepository>();
builder.Services.AddScoped<ICaseHearingRepository, CaseHearingRepository>();
builder.Services.AddScoped<ICaseHearingService, CaseHearingService>();
builder.Services.AddScoped<IUserservices, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICasesRepository, CasesRepository>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<ILandLordRepository, LandLordRepository>();
builder.Services.AddScoped<IBuildingRepository, BuildingRepository>();
builder.Services.AddScoped<ICodeGenratorRepository, CodeGenratorRepository>();
builder.Services.AddScoped<ICaseFormRepository, CaseFormRepository>();
builder.Services.AddScoped<ITenantRepository, TenantRepository>();
builder.Services.AddScoped<IStateRepository, StateRepository>();
builder.Services.AddScoped<ITypeOwnerRepository, TypeOwnerRepository>();
builder.Services.AddScoped<IDateRentRepository, DateRentRepository>();
builder.Services.AddScoped<IRegulationStatusRepository, RegulationStatusRepository>();
builder.Services.AddScoped<IAdditionalTenantsRepository, AdditionalTenantsRepository>();
builder.Services.AddScoped<ICaseTypeRepository, CaseTypeRepository>();
builder.Services.AddScoped<ICaseSubTypeRepository, CaseSubTypeRepository>();
builder.Services.AddScoped<IClientRoleRepository, ClientRoleRepository>();
builder.Services.AddScoped<ILandlordTypeRepository, LandlordTypeRepository>();
builder.Services.AddScoped<IPremiseTypeRepository, PremiseTypeRepository>();
builder.Services.AddScoped<IAdditionalOccupantsRepository, AdditionalOccupantsRepository>();
builder.Services.AddScoped<IDashBoardRepository, DashBoardRepository>();
builder.Services.AddScoped<ILanguageRepository, LanguageRepository>();
builder.Services.AddScoped<IUnitIllegalRepository, UnitIllegalRepository>();
builder.Services.AddScoped<ITenancyTypeRepository, TenancyTypeRepository>();
builder.Services.AddScoped<IFormTypesRepository, FormTypesRepository>();
builder.Services.AddScoped<ICountyRepository, CountyRepository>();
builder.Services.AddScoped<IRenewalStatusRepository, RenewalStatusRepository>();
builder.Services.AddScoped<IReasonHoldoverRepository, ReasonHoldoverRepository>();
builder.Services.AddScoped<ICaseTypePerDiemRepository, CaseTypePerDiemRepository>();
builder.Services.AddScoped<IDocumentIntructionsTypesRepository, DocumentIntructionsTypesRepository>();
builder.Services.AddScoped<IAppearanceTypePerDiemRepository, AppearanceTypePerDiemRepository>();
builder.Services.AddScoped<IHarassmentTypeRepository, HarassmentTypeRepository>();
builder.Services.AddScoped<IReportingTypePerDiemRepository, ReportingTypePerDiemRepository>();
builder.Services.AddScoped<IRemainderCenterRepository, RemainderCenterRepository>();
builder.Services.AddScoped<IDefenseTypeRepository, DefenseTypeRepository>();
builder.Services.AddScoped<IReliefPetitionerTypeRepository, ReliefPetitionerTypeRepository>();
builder.Services.AddScoped<IReliefRespondenTypeRepository, ReliefRespondenTypeRepository>();
builder.Services.AddScoped<IAppearanceTypeRepository, AppearanceTypeRepository>();
builder.Services.AddScoped<IRemainderTypeRepository, RemainderTypeRepository>();
builder.Services.AddScoped<IDefenseTypeRepository, DefenseTypeRepository>();
builder.Services.AddScoped<IManageFormRepository, ManageFormRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICalanderRepository, CalanderRepository>();
builder.Services.AddScoped<ICaseProgramRepository, CaseProgramRepository>();
builder.Services.AddScoped<IAdditionalOccupantsRepository, AdditionalOccupantsRepository>();
builder.Services.AddScoped<IAdditionalOccupantsService, AdditionalOccupantsService>();
builder.Services.AddScoped<IAdditionalTenantsRepository, AdditionalTenantsRepository>();
builder.Services.AddScoped<ICaseTypeHPDRepository, CaseTypeHPDRepository>();
builder.Services.AddScoped<IAdditionalTenantService, AdditionalTenantService>();
builder.Services.AddScoped<IRemianderCenterService, RemianderCenterService>();
builder.Services.AddScoped<ICourtpartServices, CourtpartServices>();
builder.Services.AddScoped<ICourtpartRepository, CourtpartRepository>();
builder.Services.AddScoped<IUnitRepository, UnitRepository>();
builder.Services.AddScoped<ICaseDocument, CaseDocumentRepository>();
builder.Services.AddScoped<IReminderCategoryRepository, ReminderCategoryRepository>();
builder.Services.AddScoped<IReminderEscalateRepository, ReminderEscalateRepository>();
//builder.Services.AddAuthentication(IdentityConstants.ApplicationScheme)
//    .AddIdentityCookies();
builder.Services.AddScoped<IMarshalRepositroy, MarshalRepository>();
builder.Services.AddScoped<IFilingMethodRepository, FilingMethodRepository>();
builder.Services.AddScoped<IServiceMethodRepository, ServiceMethodRepository>();
builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.AddScoped<ISubCaseTypeRepository, SubCaseTypeRepository>();
builder.Services.AddScoped<IArrearLedgerRepository, ArrearRepository>();
builder.Services.AddScoped<IMarshalService, MarshalService>();
builder.Services.AddScoped<ICaseAdditionalTenantRepository, CaseAdditionalTenantRepository>();
builder.Services.AddScoped<ICaseAdditionalTenantService, CaseAdditionalTenantService>();
builder.Services.AddScoped<ICaseNoticeInfoRepository, CaseNoticeInfoRepository>();
builder.Services.AddScoped<IAppearanceModeRepository, AppearanceModeRepository>();
builder.Services.AddScoped<IVirtualPlatformRepository, VirtualPlatformRepository>();
builder.Services.AddScoped<IAppearanceTypeForHearingRepository, AppearanceTypeForHearingRepository>();
builder.Services.AddScoped<ITenancyTypeForBuildingRepository, TenancytypeForBuildingRepository>();
builder.Services.AddScoped<IExemptionReasonRepository, ExemptionReasonRepository>();
builder.Services.AddScoped<IExemptionBasicRepository, ExemptionBasicRepository>();
builder.Services.AddScoped<IDocumentTypeRepository, DocumentTypeRepository>();
builder.Services.AddScoped<ICourtTodayTypeRepository, CourtTodayTypeRepository>();
builder.Services.AddScoped<ICaseNoticeInfoService, CaseNoticeInfoService>();
builder.Services.AddScoped<ICaseNotesRepository, CaseNotesRepository>();
builder.Services.AddScoped<IRolesService,RolesService>();
builder.Services.AddScoped<IRolesRepository, RolesRepository>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<ICloverService, CloverService>();
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();

builder.Services.AddAuthorization();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<AuthenticationStateProvider, ServerAuthenticationStateProvider>();



//builder.Services.ConfigureApplicationCookie(options =>
//{
//    options.LoginPath = "/";
//    options.AccessDeniedPath = "/unauthorized";

//    options.Cookie.HttpOnly = true;  // OK
//    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
//    options.Cookie.SameSite = SameSiteMode.None;
//});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/";
    options.AccessDeniedPath = "/unauthorized";

    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    options.SlidingExpiration = true;

    options.Cookie.HttpOnly = true;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    options.Cookie.SameSite = SameSiteMode.None;
});


builder.Services.AddScoped<SpinnerService>();
builder.Services.AddScoped<UserContextService>();
builder.Services.AddScoped<IUserservices, UserService>();
builder.Services.AddScoped<ICaseFormService, CaseFormService>();
builder.Services.AddScoped<ILegalCaseService, LegalCaseService>();
builder.Services.AddScoped<IClientService, ClientServices>();
builder.Services.AddScoped<ITenantService, TenantService>();
builder.Services.AddScoped<IBuildingService, BuildingService>();
builder.Services.AddScoped<ILandlordSevice, LandlordService>();
builder.Services.AddScoped<IManageFormService, ManageFormService>();
builder.Services.AddScoped<ICaseTypeService, CaseTypeService>();
builder.Services.AddScoped<ILandlordTypeService, LandlordTypeService>();
builder.Services.AddScoped<ICalanderService, CalanderService>();
builder.Services.AddScoped<ICountyService, CountyService>();
builder.Services.AddScoped<ILanguageService, LanguageService>();
builder.Services.AddScoped<IManageFormService, ManageFormService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IOwnerService, OwnerService>();
builder.Services.AddScoped<IPremiseTypeService, PremiseTypeService>();
builder.Services.AddScoped<IReasonHoldoverService, ReasonHoldoverService>();
builder.Services.AddScoped<IRenewalStatusService, RenewalStatusService>();
builder.Services.AddScoped<IRentRegulationService, RentRegulationService>();
builder.Services.AddScoped<IStateService, StateService>();
builder.Services.AddScoped<ITenancyTypeService, TenancyTypeService>();
builder.Services.AddScoped<IUnitIllegalService, UnitIllegalService>();
builder.Services.AddScoped<ICourtTypeRepository, CourtTypeRepository>();
builder.Services.AddScoped<ICasePetitionerRepository, CasePetitionerRepository>();
builder.Services.AddScoped<ICaseRespondentRepository, CaseRespondentRepository>();
builder.Services.AddSingleton<SuccessMessageService>();
builder.Services.AddBlazoredToast();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
// Repository Registrations (in EvictionFiler.Infrastructure)
builder.Services.AddScoped<IFeesCatalogRepository, FeesCatalogRepository>();
builder.Services.AddScoped<IFeesCatalogCourtAppearanceRepository, FeesCatalogCourtAppearanceRepository>();
builder.Services.AddScoped<IFeesCatalogAttorneyRosterRepository, FeesCatalogAttorneyRosterRepository>();

// Service Registrations (in EvictionFiler.Application)
builder.Services.AddScoped<IFeesCatalogService, FeesCatalogService>();
builder.Services.AddScoped<IFeesCatalogCourtAppearanceService, FeesCatalogCourtAppearanceService>();
builder.Services.AddScoped<IFeesCatalogAttorneyRosterService, FeesCatalogAttorneyRosterService>();
builder.Services.AddScoped<ICaseWarrantService, CaseWarrantService>();
builder.Services.AddScoped<ICaseWarrantRepository, CaseWarrantRepository>();
builder.Services.AddScoped<IAdjournedReasonRepository, AdjournedReasonsRepository>();
builder.Services.AddScoped<ICaseAppearanceRepository, CaseAppreanceRepository>();
builder.Services.AddScoped<ICaseAppearanceService, CaseAppearanceService>();
builder.Services.AddScoped<IChatGptService, ChatGptService>();
builder.Services.AddScoped<ICaseFilingRepository, CaseFilingRepository>();
builder.Services.AddScoped<IFirmService, FirmService>();
builder.Services.AddScoped<IFirmRepository, FirmRepository>();
builder.Services.AddScoped<ISubscriptionTypeRepository, SubscriptionTypeRepository>();
builder.Services.AddScoped<ILoggedInUserService, LoggedInUserService>();
builder.Services.AddScoped<IRegisterRepository, RegisterRepository>();
builder.Services.AddScoped<IRegisterService, RegisterService>();
builder.Services.AddScoped<IFormCategoryRepository, FormCategoryRepository>();
builder.Services.AddScoped<
    IUserClaimsPrincipalFactory<User>,
    ApplicationUserClaimsPrincipalFactory>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

await app.ConfigureDataContext();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();


app.UseStaticFiles();



var caseFormsPath = Path.Combine(app.Environment.ContentRootPath, "CaseForms");
if (!Directory.Exists(caseFormsPath))
    Directory.CreateDirectory(caseFormsPath);

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(caseFormsPath),
    RequestPath = "/CaseForms",
    ServeUnknownFileTypes = true
});
using var scope = app.Services.CreateScope();

var services = scope.ServiceProvider;
try
{
    var identityContext = services.GetRequiredService<MainDbContext>();
    await identityContext.Database.MigrateAsync();
}
catch (Exception ex)
{
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occursed during migration");
}


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(EvictionFiler.Client._Imports).Assembly);


app.MapPost("/api/auth/logout", async (HttpContext http, SignInManager<User> signInManager) =>
{
    await signInManager.SignOutAsync();
    await http.SignOutAsync(IdentityConstants.ApplicationScheme);
    http.Response.Cookies.Delete(".AspNetCore.Identity.Application");
    return Results.Ok();
});
app.MapGet("/api/casefile/{**relativePath}", async (string relativePath) =>
{
    var filePath = Path.Combine(caseFormsPath, relativePath);

    if (!System.IO.File.Exists(filePath))
        return Results.NotFound($"File '{relativePath}' not found.");

    var stream = System.IO.File.OpenRead(filePath);
    var contentType = "application/octet-stream";
    return Results.File(stream, contentType, Path.GetFileName(filePath));
});

app.MapPost("/api/auth/impersonate/{userId:guid}", async (
    Guid userId,
    UserManager<User> userManager,
    SignInManager<User> signInManager, HttpContext http,
    IHttpContextAccessor accessor) =>
{
    var adminId = accessor.HttpContext!.User.FindFirstValue(ClaimTypes.NameIdentifier);
    if (adminId == null) return Results.Unauthorized();

    var targetUser = await userManager.FindByIdAsync(userId.ToString());
    if (targetUser == null) return Results.NotFound("User not found");

    await signInManager.SignOutAsync();

    var principal = await signInManager.CreateUserPrincipalAsync(targetUser);
    var identity = (ClaimsIdentity)principal.Identity!;

    // 3. ADD impersonation claims BEFORE writing cookie
    identity.AddClaim(new Claim("ImpersonatedBy", adminId));
    identity.AddClaim(new Claim("OriginalAdminId", adminId));

    // 4. WRITE THE COOKIE MANUALLY (do NOT call SignInManager.SignInAsync again)
    await http.SignInAsync(
        IdentityConstants.ApplicationScheme,
        new ClaimsPrincipal(identity),
        new AuthenticationProperties { IsPersistent = false }
    );

    return Results.Ok(new { message = "Impersonation started" });
})
.RequireAuthorization();
app.MapPost("/api/auth/revert", async (
    UserManager<User> userManager,
    SignInManager<User> signInManager,
    IHttpContextAccessor accessor) =>
{
    var http = accessor.HttpContext!;
    var adminId = http.User.FindFirstValue("OriginalAdminId");

    if (adminId == null)
        return Results.BadRequest("Not impersonating anyone");

    var admin = await userManager.FindByIdAsync(adminId);
    if (admin == null)
        return Results.NotFound("Admin not found");

    await signInManager.SignOutAsync();
    await signInManager.SignInAsync(admin, isPersistent: false);

    return Results.Ok(new { message = "Reverted to super admin" });
})
.RequireAuthorization();


app.MapRazorPages();
app.MapFallbackToFile("index.html");

app.Run();
