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
                return View(prodtbl);
            }
        }
}
