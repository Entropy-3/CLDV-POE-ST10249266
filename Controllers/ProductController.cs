using CLDV_POE_ST10249266.Models;
using Microsoft.AspNetCore.Mvc;

namespace CLDV_POE_ST10249266.Controllers
{
    public class ProductController : Controller
    {
       
        public productTBL prodtbl = new productTBL();

        [HttpPost]
        public ActionResult AddProduct(productTBL products)
        {
            var result2 = prodtbl.insert_Product(products);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult AddProduct()
        {
            if (HttpContext.Session.GetInt32("userID") == null)
            {
                TempData["AlertMessage"] = "Please log in to sell products.";
                return RedirectToAction("Login", "User");
            }
            return View(prodtbl);
        }

        public IActionResult MyWork()
        {
            int? userID = HttpContext.Session.GetInt32("userID");
            ViewData["UserID"] = userID;
            var products = ProductDisplayModel.SelectProducts();
            return View(products);
        }
        public IActionResult Transactions()
        {
            return View();
        }
    }
}