using CLDV_POE_ST10249266.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace CLDV_POE_ST10249266.Controllers
{
    public class TransactionController : Controller
    {
        TransactionTBL transtbl = new TransactionTBL();

        [HttpGet]
        public IActionResult Transactions()
        {
            int? userID = HttpContext.Session.GetInt32("userID");
            var transactions = TransactionTBL.GetTransactions((int)userID);
            return View(transactions);
        }
        [HttpPost]
        public ActionResult AddTransaction(TransactionTBL transaction)
        {
            var result2 = transtbl.PlaceOrder(transaction);
            return RedirectToAction("MyWork", "Product");
        }
    }
}