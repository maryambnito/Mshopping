﻿
namespace Petshop.Endpoint.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ProductRepository productRepository;
    private int pageSize = 2;
    public HomeController(ILogger<HomeController> logger, ProductRepository productRepository)
    {
        _logger = logger;
        this.productRepository = productRepository;
    }

    public IActionResult Index(string category = "", int pageNumber = 1)
    {
		ProductIndexViewModel viewModel = new ()
        {
            Search = category,
            Data = productRepository.GetAllProducts(pageNumber, pageSize, category)
        };
        return View(viewModel);
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