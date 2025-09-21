using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BugTracker.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using BugTracker.Core.DTO;
using System.Net.Http;
using System.Text;

using System.Net.Http;
using System.Text.Json;

namespace BugTracker.Controllers;

[Authorize]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IHttpClientFactory _httpClientFactory;

   
    public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
    {
        _logger = logger;
        _httpClientFactory = httpClientFactory;
    }

    [AllowAnonymous]
    public IActionResult AccessDenied() => View();

    public IActionResult Index()
    {
        // Azure AD emits roles in a claim of type "roles"
        var roles = User.FindAll("roles").Select(c => c.Value);

        if (roles.Contains("Admin"))
            return RedirectToAction("Index", "AdminIndex");

        if (roles.Contains("Support"))
            return RedirectToAction("Index", "SupportIndex");
       
        if (roles.Contains("Customer"))
            return RedirectToAction("Index", "CustomerIndex");

        return View();
    }
   
    [HttpGet]
    public IActionResult CreateTicket()
    {
        return View("CreateTicket");
    }
    [HttpPost]
    public async Task<IActionResult> CreateTicket(CreateTicketDto model)
    {
        // This assumes your API and MVC run under the same domain/auth
        var client = _httpClientFactory.CreateClient();
        var content = new StringContent(
            JsonSerializer.Serialize(model),
            Encoding.UTF8,
            "application/json"
        );
        try
        {
            var response = await client.PostAsync("https://localhost:7001/api/tickets", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                var error = await response.Content.ReadAsStringAsync();
                ModelState.AddModelError("", $"API error: {response.StatusCode} {error}");
                return View(model);
            }
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", $"Exception: {ex.Message}");
            return View(model);
        }
    }
                                                [Authorize(Roles = "Admin")]
                                                public IActionResult Privacy()
                                                {
                                                    return View();
                                                }

                                                [Authorize(Roles = "Admin")]
                                                public IActionResult AdminIndex()
                                                {
                                                    return View();
                                                }
                                                [Authorize(Roles = "Support")]
                                                public IActionResult SupportIndex()
                                                {
                                                    return View();
                                                }
                                                [Authorize(Roles = "Customer")]
                                                public IActionResult CustomerIndex()
                                                {
                                                    return View();
                                                }

                                                        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
                                                        public IActionResult Error()
                                                        {
                                                            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
                                                        }
                                                    }
