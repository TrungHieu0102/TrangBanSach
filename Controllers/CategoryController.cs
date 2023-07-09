using Microsoft.AspNetCore.Mvc;
using System.Data.SqlTypes;
using WebBanSach.Data;
using WebBanSach.Models;

namespace WebBanSach.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }
        public IActionResult Create()
        {
            
            return View();
        }
        //post
        [HttpPost]
        [ValidateAntiForgeryToken]// chong hacker gia mao phuong thuc post
        public IActionResult Create(Category obj)
        {
            if(obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomError", "The Name must not same Display Order");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("index");
            }
            return View(obj);
        }
    }
}
