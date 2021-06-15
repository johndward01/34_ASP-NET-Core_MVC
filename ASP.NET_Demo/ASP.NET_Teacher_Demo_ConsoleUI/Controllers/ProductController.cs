using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NET_Teacher_Demo_ConsoleUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Teacher_Demo_ConsoleUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _repo;

        public ProductController(IProductRepository repo)
        {
            this._repo = repo;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var products = _repo.GetAllProducts();

            return View(products);
        }

        public IActionResult ViewProduct(int id)
        {
            var product = _repo.GetProduct(id);

            return View(product);
        }

        public IActionResult UpdateProduct(int id)
        {
            Product prod = _repo.GetProduct(id);

            _repo.UpdateProduct(prod);

            if (prod == null)
            {
                return View("ProductNotFound");
            }

            return View(prod);
        }

        public IActionResult UpdateProductToDatabase(Product product)
        {
            _repo.UpdateProduct(product);

            return RedirectToAction("ViewProduct", new { id = product.ProductID });
        }

        public IActionResult InsertProduct()
        {
            var prod = _repo.AssignCategory();

            return View(prod);
        }

        public IActionResult InsertProductToDatabase(Product productToInsert)
        {
            _repo.InsertProduct(productToInsert);

            return RedirectToAction("Index");
        }

        public IActionResult DeleteProduct(Product product)
        {
            _repo.DeleteProduct(product);

            return RedirectToAction("Index");
        }



    }
}
