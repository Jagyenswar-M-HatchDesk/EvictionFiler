using System.Text;
using EvictionFiler.Application;
using EvictionFiler.Application.DTOs;
using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Application.Interfaces.IServices;
using EvictionFiler.Application.Interfaces.IUserRepository;
using EvictionFiler.Application.Services;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Infrastructure;
using EvictionFiler.Infrastructure.DbContexts;
using EvictionFiler.Infrastructure.Extensions;
using EvictionFiler.Infrastructure.Repositories;
using EvictionFiler.Server.Components;
using EvictionFiler.Server.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Syncfusion.Blazor;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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

builder.Services.AddSyncfusionBlazor();
builder.Services.AddDbContext<MainDbContext>(
	options => options.UseSqlServer(
		builder.Configuration.GetConnectionString("Default"),
		sqlOptions => sqlOptions.MigrationsAssembly("EvictionFiler.Infrastructure")
	)

);

builder.Services.AddScoped<IUserservices, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICasesRepository, CasesRepository>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<ILandLordRepository, LandLordRepository>();
builder.Services.AddScoped<IBuildingRepository, BuildingRepository>();
builder.Services.AddScoped<ICodeGenratorRepository, CodeGenratorRepository>();
builder.Services.AddScoped<ITenantRepository, TenantRepository>();
builder.Services.AddScoped<IStateRepository, StateRepository>();
builder.Services.AddScoped<ITypeOwnerRepository, TypeOwnerRepository>();
builder.Services.AddScoped<IRegulationStatusRepository, RegulationStatusRepository>();
builder.Services.AddScoped<ICaseTypeRepository, CaseTypeRepository>();
builder.Services.AddScoped<ICaseSubTypeRepository, CaseSubTypeRepository>();
builder.Services.AddScoped<IClientRoleRepository, ClientRoleRepository>();
builder.Services.AddScoped<ILandlordTypeRepository, LandlordTypeRepository>();
builder.Services.AddScoped<IPremiseTypeRepository, PremiseTypeRepository>();
builder.Services.AddScoped<ILanguageRepository, LanguageRepository>();
builder.Services.AddScoped<AuthenticationStateProvider, JwtAuthStateProvider>();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<JwtAuthStateProvider>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<JwtAuthStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(provider =>
    provider.GetRequiredService<JwtAuthStateProvider>());
builder.Services.AddScoped<IUserservices , UserService>();
builder.Services.AddScoped<IClientService , ClientServices>();
builder.Services.AddScoped<ILandlordSevice  , LandlordService>();
builder.Services.AddScoped<IBuildingService , BuildingService>();
builder.Services.AddScoped<ITenantService, TenantService>();
builder.Services.AddScoped<ILegalCaseService  , LegalCaseService>();
builder.Services.AddScoped<NavigationDataService>();

builder.Services.AddScoped<IUnitOfWork , UnitOfWork>();
builder.Services.AddAuthorizationCore();


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
    };
});

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
app.UseStaticFiles();



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

app.Run();
