using CLDV_POE_ST10249266.Models;
using Microsoft.AspNetCore.Mvc;

namespace CLDV_POE_ST10249266.Controllers
{
    public class UserController : Controller
    {
        public userTBL usrtbl = new userTBL();

        [HttpPost]
        public ActionResult SignUp(userTBL Users)
        {
            var result = usrtbl.insert_User(Users);
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("userID");
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public ActionResult SignUp()
        {
            return View(usrtbl);
        }
        public ActionResult Login()
        {
            return View(usrtbl);
        }
    }
}