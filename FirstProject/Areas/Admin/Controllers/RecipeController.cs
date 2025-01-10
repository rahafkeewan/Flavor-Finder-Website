using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipesWeb.DataAccess.Repository.IRepository;
using RecipesWeb.Models;
using RecipesWeb.Utility;
using System.Data;

namespace RecipesWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class RecipeController : Controller
    {
       
            private readonly IUnitOfWork _UnitOfWork;
            public RecipeController(IUnitOfWork UnitOfWork)
            {
                _UnitOfWork = UnitOfWork;
            }

            public IActionResult Index()
            {
            List<Recipe> ObjCategoryList = _UnitOfWork.Recipe.GetAll().ToList();

            return View(ObjCategoryList);
            }

            public IActionResult Create()
            {
                return View();
            }
            [HttpPost]
            public IActionResult Create(Recipe obj)
            {
                
                if (ModelState.IsValid)
                {
                    _UnitOfWork.Recipe.Add(obj);
                    _UnitOfWork.Save();
                    TempData["success"] = "Category created successfully";
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
            Recipe? categoryFromDb = _UnitOfWork.Recipe.Get(u => u.Id == id);
                if (categoryFromDb == null)
                {
                    return NotFound();
                }
                return View(categoryFromDb);
            }
            [HttpPost]
            public IActionResult Edit(Recipe obj)
            {
                if (ModelState.IsValid)
                {
                    _UnitOfWork.Recipe.update(obj);
                    _UnitOfWork.Save();
                    TempData["success"] = "Category Update successfully";
                    return RedirectToAction("Index");
                }
                return View();

            }
            [HttpGet]
            public IActionResult Delete(int? id)
            {
                if (id == null || id == 0)
                {
                    return NotFound();
                }
            Recipe? categoryFromDb = _UnitOfWork.Recipe.Get(u => u.Id == id);
                //Category? categoryFromDb1 = _db.Categories.RecipesWebOrDefault(u=>u.Id==id);
                //Category? categoryFromDb2 = _db.Categories.Where(u=>u.Id==id).RecipesWebOrDefault();

                if (categoryFromDb == null)
                {
                    return NotFound();
                }
                return View(categoryFromDb);
            }
            [HttpPost, ActionName("Delete")]
            public IActionResult DeletePOST(int? id)
            {
            Recipe? obj = _UnitOfWork.Recipe.Get(u => u.Id == id);
                if (obj == null)
                {
                    return NotFound();
                }
                _UnitOfWork.Recipe.Remove(obj);
                _UnitOfWork.Save();
                TempData["success"] = "Item Remove successfully";
                return RedirectToAction("Index");
            }

        }
    }

