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
        var aulas = _context.Aulas.ToList();
        return View(aulas);
    }

    public IActionResult SobreNos()
    {
        return View();
    }

    public IActionResult Servicos()
    {
        ServicoVM servicoVM = new() {
            Aulas = _context.Aulas.ToList(),
            Planos = _context.Planos.ToList()
        };
        return View(servicoVM);
    }

    public IActionResult Loja()
    {
        var Loja = _context.Products.ToList();
        return View(Loja);
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
