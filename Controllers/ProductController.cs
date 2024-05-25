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
            if (products == null)
            {
                TempData["AlertMessage"] = "Please fill in all fields.";
                return RedirectToAction("AddProduct", "Product");
            }
            var result2 = prodtbl.insert_Product(products);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult AddProduct()
        {
            //checks to see if user is logged in
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
            int? userID = HttpContext.Session.GetInt32("userID");
            ViewData["UserID"] = userID;

            //checks to see if user is logged in
            if (userID == null)
            {
                TempData["AlertMessage"] = "Please log in to view transaction history.";
                return RedirectToAction("Login", "User");
            }
            var transactions = TransactionTBL.GetTransactions((int)userID);
            return View(transactions);
        }
    }
}