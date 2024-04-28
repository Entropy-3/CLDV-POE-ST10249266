using CLDV_POE_ST10249266.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace CLDV_POE_ST10249266.Controllers
{
    public class ProductDisplayController : Controller
    {
        public class ProductsController : Controller
        {
            public IActionResult Index()
            {
                var products = ProductDisplayModel.SelectProducts();
                return View(products);
            }
        }
    }
}