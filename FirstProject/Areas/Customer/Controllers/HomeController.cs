using RecipesWeb.DataAccess.Repository.IRepository;
using RecipesWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using RecipesWebsite.Modelss;
using RecipesWeb.DataAccess.Repository;
using RecipesWebsite.DataAccess.Migrations;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using RecipesWeb.Models.ViewModols;

namespace RecipesWebProject.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index(string command)
        {
            ProductVM ProductVM = new()
            {
                CategoryList = _unitOfWork.Category
               .GetAll().Select(u => new SelectListItem
               {
                   Text = u.Name,
                   Value = u.Id.ToString()
               }),
                Products = _unitOfWork.Product.GetAll(includeProperties: "Category,RecipeXItem").ToList(),
                ItemsList = _unitOfWork.Recipe
               .GetAll().Select(r => new SelectListItem
               {
                   Text = r.Name,
                   Value = r.Id.ToString()
               })
            };
            ViewBag.Command = command;
            return View(ProductVM);
        }
        [HttpGet]
        public IActionResult PartialRecipeList(string ItemsIds)
        {
            List<int> Ids = (ItemsIds != null)?ItemsIds.Split(",").Select(x=>int.Parse(x)).ToList():new List<int>();
            List<Product> ResultList = new List<Product>();
            IEnumerable<Product> productList = _unitOfWork.Product.GetAll(includeProperties: "Category,RecipeXItem");
            foreach (var product in productList) 
            {
                var CurrentRecipeXItem = product.RecipeXItem.Select(x => x.RecipeId).ToList();
                if (Ids.All(x => CurrentRecipeXItem.Contains(x))) 
                {
                    ResultList.Add(product);
                } 
            }
            return PartialView("_PartialRecipeList", ResultList);
        }
        public IActionResult Details(int id)
        {
            Product product = _unitOfWork.Product.Get(u=> u.Id==id,includeProperties: "Category");
            return View(product);
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
}