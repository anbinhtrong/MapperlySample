using ProductCatalog.Web.App_Start;
using ProductCatalog.Web.Repositories;
using ProductCatalog.Web.Services;
using ProductCatalog.Web.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ProductCatalog.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _service;

        public ProductController()
        {
            var repo = new ProductRepository();
            var mapper = AutoMapperConfig.Mapper;
            _service = new ProductService(repo, mapper);
        }

        // GET: /Product
        public ActionResult Index()
        {
            var products = _service.GetAllProducts();
            return View(products);
        }

        // GET: /Product/Detail/5
        public ActionResult Detail(int id)
        {
            var product = _service.GetProduct(id);
            if (product == null) return HttpNotFound();
            return View(product);
        }

        // GET: /Product/Create
        public ActionResult Create()
        {
            var model = new ProductCreateViewModel
            {
                Categories = new List<CategoryViewModel>
            {
                new CategoryViewModel { Id = 1, Name = "Laptop" },
                new CategoryViewModel { Id = 2, Name = "Phụ kiện" },
                new CategoryViewModel { Id = 3, Name = "Màn hình" },
            }
            };
            return View(model);
        }

        // POST: /Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductCreateViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            _service.CreateProduct(model);
            return RedirectToAction("Index");
        }
    }
}