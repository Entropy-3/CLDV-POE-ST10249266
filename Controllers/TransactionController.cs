using CLDV_POE_ST10249266.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace CLDV_POE_ST10249266.Controllers
{
    public class TransactionController : Controller
    {
        TransactionTBL transtbl = new TransactionTBL();

        [HttpPost]
        public ActionResult AddTransaction(TransactionTBL transaction)
        {
            var result2 = transtbl.PlaceOrder(transaction);
            return RedirectToAction("Transactions", "Product");
        }
    }
}
