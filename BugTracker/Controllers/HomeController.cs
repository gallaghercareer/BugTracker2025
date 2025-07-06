using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BugTracker.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using BugTracker.Core.DTO;


namespace BugTracker.Controllers;

[Authorize]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
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

    [HttpPost]
    public IActionResult CreateTicket(CreateTicketDto model)
    {
    
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
