using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AcademiaDynamic.Models;
using AcademiaDynamic.Data;

namespace AcademiaDynamic.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly AppDbContext _context;

    public HomeController(ILogger<HomeController> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        //var aulas = _context.Aulas.ToList();
        return View();
    }

    public IActionResult SobreNos()
    {
        return View();
    }

    public IActionResult Servicos()
    {
        return View();
    }

    public IActionResult Loja()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
