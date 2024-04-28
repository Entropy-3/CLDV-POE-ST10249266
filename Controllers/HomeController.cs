using CLDV_POE_ST10249266.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CLDV_POE_ST10249266.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // Retrieve all products from the database
            List<productTBL> products = productTBL.get_Products();

            // Pass products and userID to the view
            //ViewData["Products"] = products;
            int? userID = HttpContext.Session.GetInt32("userID");
            ViewData["UserID"] = userID;


            return View();
        }

        public IActionResult ContactUs()
        {
            return View();
        }

        public IActionResult AboutUs()
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