using EvictionFiler.Application.DTOs;
using EvictionFiler.Application.Interfaces.IServices;
using EvictionFiler.Application.Interfaces.IUserRepository;
using EvictionFiler.Application.Services;
using EvictionFiler.Client.Pages;
using EvictionFiler.Client.Services;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Infrastructure.DbContexts;
using EvictionFiler.Infrastructure.Repositories;
using EvictionFiler.Server.Components;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Multi_Talent_Architect.Services;
using Syncfusion.Blazor;
using System.Text;

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
builder.Services.AddDbContext<MainDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"),
        b => b.MigrationsAssembly("EvictionFiler.Infrastructure")));

//builder.Services.AddDbContextFactory<MainDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"),
//        b => b.MigrationsAssembly("EvictionFiler.Infrastructure")));

builder.Services.AddScoped<IUserservices, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICasesRepository, CasesRepository>();
//builder.Services.AddScoped<IClientService, ClientServices>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IApartmentRepository, ApartmentRepository>();
builder.Services.AddScoped<ILandLordRepository, LandLordRepository>();

builder.Services.AddScoped<ITenantRepository, TenantRepository>();
//builder.Services.AddScoped<ILegalCaseService, LegalCaseService>();
builder.Services.AddScoped<AuthenticationStateProvider, JwtAuthStateProvider>();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<JwtAuthStateProvider>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<JwtAuthStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(provider =>
    provider.GetRequiredService<JwtAuthStateProvider>());
builder.Services.AddScoped<UserServiceClient>();
builder.Services.AddScoped<ClientService>();
builder.Services.AddScoped<TenantService>();
builder.Services.AddScoped<ApartmentService>();
builder.Services.AddScoped<LandLordService>();
builder.Services.AddScoped<LegalCasesService>();
builder.Services.AddScoped<NavigationDataService>();

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

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(EvictionFiler.Client._Imports).Assembly);

app.Run();
