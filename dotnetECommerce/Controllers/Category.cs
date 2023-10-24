using Microsoft.AspNetCore.Mvc;

namespace dotnetECommerce.Controllers;

public class Category : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}