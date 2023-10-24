using dotnetECommerce.Data;
using dotnetECommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnetECommerce.Controllers;

public class CategoryController : Controller
{
    private readonly ApplicationDbContext _db;

    public CategoryController(ApplicationDbContext db)
    {
        _db = db;
    }
    // GET
    public IActionResult Index()
    {
        List<Category> pbjCategoryList = _db.Categories.ToList();
        return View(pbjCategoryList);
    }
}