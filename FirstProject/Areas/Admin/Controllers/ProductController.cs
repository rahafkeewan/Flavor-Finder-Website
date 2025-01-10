
using RecipesWeb.DataAccess.Repository.IRepository;
using RecipesWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using RecipesWeb.Models.ViewModols;
using RecipesWeb.Utility;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using RecipesWebsite.Modelss;

namespace BulkyBookWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]

    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<Product> objProductList = _unitOfWork.Product.GetAll(includeProperties:"Category").ToList();
            
            return View(objProductList);
        }

        public IActionResult upsert(int? id)
        {

            ProductVM ProductVM = new()
            { 
                CategoryList = _unitOfWork.Category
                .GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                Product = new Product(),
                ItemsList = _unitOfWork.Recipe
                .GetAll().Select(r => new SelectListItem
                {
                    Text = r.Name,  
                    Value = r.Id.ToString()
                })
            };
            if (id == null || id == 0)
            {
                return View(ProductVM);
            }

            else
            {
                ProductVM.Product = _unitOfWork.Product.Get(u=>u.Id == id, "RecipeXItem");
                ProductVM.SelectedItems = ProductVM.Product.RecipeXItem.Select(x=>x.RecipeId).ToList(); 
                return View(ProductVM);
            }
        }
        [HttpPost]
        public IActionResult upsert(ProductVM ProductVM, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"Images\Product");

                    if (!string.IsNullOrEmpty(ProductVM.Product.ImageUrl))
                    {
                        // delete all image
                        var OldImagePath = Path.Combine(wwwRootPath, ProductVM.Product.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(OldImagePath))
                        {
                            System.IO.File.Delete(OldImagePath);
                        }
                    }
                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName) , FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    ProductVM.Product.ImageUrl = @"\Images\Product\" + fileName;
                }
                ProductVM.Product.RecipeXItem = ProductVM.SelectedItems.Select(x => new RecipeXItem() { RecipeId = x }).ToList();
                if (ProductVM.Product.Id == 0)
                { 
                    _unitOfWork.Product.Add(ProductVM.Product);
                }
                else
                {
                    _unitOfWork.Product.Update(ProductVM.Product);

                }
                _unitOfWork.Save();
                TempData["success"] = "Product created successfully";
                return RedirectToAction("Index");
            }
            else
            {
                ProductVM.CategoryList = _unitOfWork.Category
                .GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });
                return View(ProductVM);
            }
            

        }

       
        #region API CALLS
        [HttpGet]
        public IActionResult GetAll() 
        {
            List<Product> objProductList = _unitOfWork.Product.GetAll(includeProperties: "Category").ToList();
            return Json(new { data = objProductList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var productToBeDeleted = _unitOfWork.Product.Get(u => u.Id == id);
            if (productToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error while deleting"});
            }

            var OldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, productToBeDeleted.ImageUrl.TrimStart('\\'));
            if (System.IO.File.Exists(OldImagePath))
            {
                System.IO.File.Delete(OldImagePath);
            }

            _unitOfWork.Product.Remove(productToBeDeleted);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Delete Successful" });

        }
        #endregion 
    }
}