using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using System.Security.Claims;
using BugTracker.Data.Context;
using Microsoft.EntityFrameworkCore;
using Azure.Identity;
using Azure.Extensions.AspNetCore.Configuration.Secrets;
using BugTracker.Api.Extensions;
using BugTracker.Data;
using BugTracker.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews(options =>
{
    var policy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
    options.Filters.Add(new AuthorizeFilter(policy));
});

//required for razor pages to use the redirect
builder.Services.AddRazorPages().AddMicrosoftIdentityUI();

// Register authentication
builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureAd"));

// Add Azure Key Vault secrets to configuration
builder.Configuration.AddAzureKeyVault(
    new Uri("https://connectionvault-09.vault.azure.net/"),
    new DefaultAzureCredential());

builder.Services.AddBugTrackerServices(builder.Configuration);

//BEGINTEST: Get the connection string from Key Vault
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

if (string.IsNullOrWhiteSpace(connectionString))
{
    throw new InvalidOperationException("Connection string is missing. Check Azure Key Vault or appsettings.");
}

Console.WriteLine("Connection string found: " + connectionString);
//ENDTEST

//add dbContext
builder.Services.AddPersistence(builder.Configuration);

//wire services business domain logic
builder.Services.AddDomainServices();

//Role-based authorization policies 
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAdmin", policy => policy.RequireRole("Admin"));
    options.AddPolicy("RequireRecruiter", policy => policy.RequireRole("HelpDesk"));
    options.AddPolicy("RequireViewer", policy => policy.RequireRole("Customer"));
});

//Access Denied, Configure<>() is a singleton
builder.Services.Configure<CookieAuthenticationOptions>(CookieAuthenticationDefaults.AuthenticationScheme, options =>
{
    options.AccessDeniedPath = "/AccessDenied";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    //In DEV will provide a more detailed exception on the html page itself
    app.UseDeveloperExceptionPage(); 
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();

//Enable Authorize annotation 
app.UseAuthorization();

//For api controllers
app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//required for razor pages to use the redirect Azure page
app.MapRazorPages();

//Console.WriteLine("AzureAd ClientId (runtime): " + builder.Configuration["AzureAd:ClientId"]);

app.Run();

//Console.WriteLine("Environment: " + app.Environment.EnvironmentName);
