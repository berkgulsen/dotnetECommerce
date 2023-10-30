using dotnetECommerce.DataAccess.Data;
using dotnetECommerce.DataAccess.Repository.IRepository;
using dotnetECommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnetECommerce.Controllers;

public class CategoryController : Controller
{
    private readonly ICategoryRepository _categoryRepo;

    public CategoryController(ICategoryRepository db)
    {
        _categoryRepo = db;
    }
    // GET
    public IActionResult Index()
    {
        List<Category> pbjCategoryList = _categoryRepo.GetAll().ToList();
        return View(pbjCategoryList);
    }
    
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(Category obj)
    {
        if (ModelState.IsValid)
        {
            _categoryRepo.Add(obj);
            _categoryRepo.Save();
            TempData["success"] = "Category successfully created";
            return RedirectToAction("Index");
        }

        return View();
    }
    
    public IActionResult Edit(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }

        Category categoryFromDb = _categoryRepo.Get(u=>u.Id==id);
        if (categoryFromDb == null)
        {
            return NotFound();
        }
        return View(categoryFromDb);
    }
    [HttpPost]
    public IActionResult Edit(Category obj)
    {
        if (ModelState.IsValid)
        {
            _categoryRepo.Update(obj);
            _categoryRepo.Save();
            TempData["success"] = "Category successfully updated";
            return RedirectToAction("Index");
        }
        return View();
    }
    
    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }

        Category categoryFromDb = _categoryRepo.Get(u=>u.Id==id);
        if (categoryFromDb == null)
        {
            return NotFound();
        }
        return View(categoryFromDb);
    }
    [HttpPost, ActionName("Delete")]
    public IActionResult DeletePOST(int? id)
    {
        Category obj = _categoryRepo.Get(u=>u.Id==id);
        if (obj == null)
        {
            return NotFound();
        }

        _categoryRepo.Remove(obj);
        _categoryRepo.Save();
        TempData["success"] = "Category successfully deleted";
        return RedirectToAction("Index");
    }
}