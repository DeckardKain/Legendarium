using Blazored.LocalStorage;
using Blazored.Toast;
using LegendariumData;
using LegendariumUI.Repositories.Authentication;
using LegendariumUI.Services;
using LegendariumUI.Services.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using OpenAI.GPT3.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


var cs = builder.Configuration.GetConnectionString("DefaultConnection");




builder.Services.AddDbContext<LegendariumDbContext>(
    options =>
    options.UseSqlServer(cs));
//,ServiceLifetime.Scoped);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddBlazoredToast();
builder.Services.AddOpenAIService();

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7172") });
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddTransient<ICharacterRepository, CharacterRepository>();
builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();
builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddScoped<IPlanetRepository, PlanetRepository>();
builder.Services.AddScoped<ICardRepository, CardRepository>();
builder.Services.AddScoped<IAdventureRepository, AdventureRepository>();

builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddScoped<IPlanetService, PlanetService>();
builder.Services.AddScoped<ICharacterService, CharacterService>();
builder.Services.AddScoped<IPowerService, PowerService>();
builder.Services.AddScoped<IVisionService, VisionService>();
builder.Services.AddScoped<IUtilityService, UtilityService>();
builder.Services.AddScoped<ICardService, CardService>();
builder.Services.AddScoped<IAdventureService, AdventureService>();
builder.Services.AddScoped<IAIService, AIService>();
builder.Services.AddBootstrapBlazor();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
.AddCookie(options =>
{
    options.ExpireTimeSpan = TimeSpan.FromDays(20);
});

builder.Services.AddAuthenticationCore();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["AppSettings:Issuer"],
            ValidAudience = builder.Configuration["AppSettings:Audeince"],
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes(
                builder.Configuration["AppSettings:Token"]))
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication(); // Order matters here. You need to authenticate before you can authorize.
app.UseAuthorization();


app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
