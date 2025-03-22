using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        //public string GetAllCategories()
        //{
        //    return "Return All Categories";
        //}

        //public string GetCategoriesByName(string name)
        //{
        //    return $"Return All Categories with Name : {name}";
        //}

        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
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
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["message"] = "Category created successfully!!";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["message"] = "Category edited successfully!!";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult DeletePOST(int? id)
        {
            Category? obj = _db.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["message"] = "Category deleted successfully!!";
            return RedirectToAction("Index");
        }


    }
}