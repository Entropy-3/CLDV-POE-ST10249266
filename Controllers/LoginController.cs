﻿using CLDV_POE_ST10249266.Models;
using Microsoft.AspNetCore.Mvc;

namespace CLDV_POE_ST10249266.Controllers
{
    public class LoginController : Controller
    {
        private readonly LoginModel login;

        public LoginController()
        {
            login = new LoginModel();
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            var loginModel = new LoginModel();
            int userID = loginModel.SelectUser(email, password);
            if (userID != -1)
            {
                HttpContext.Session.SetInt32("userID", userID);
                return RedirectToAction("Index", "Home", new { userID = userID });
            }
            else
            {
                TempData["AlertMessage"] = "Username or password is incorrect!";
                return RedirectToAction("Login", "User");
            }
        }
    }
}