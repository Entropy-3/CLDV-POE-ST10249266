using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace CLDV_POE_ST10249266.Models
{
    
    public class TransactionTBL
    {
        public static string con_string = "Server=tcp:st10249266-sql-server.database.windows.net,1433;Initial Catalog=CLDV-DBS;Persist Security Info=False;User ID=entropy-3;Password=hifr@220404;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public static SqlConnection con = new SqlConnection(con_string);

            public int transactionID { get; set; }
            public int UserID { get; set; }
            public int ProductID { get; set; }

            public string product_name { get; set; }
            public decimal product_price { get; set; }


        public int PlaceOrder(TransactionTBL m)
        {
            string sql = "INSERT INTO tblTransactions (user_id, product_id) VALUES (@UserID, @ProductID)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@UserID", m.UserID);
            cmd.Parameters.AddWithValue("@ProductID", m.ProductID);
            con.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            con.Close();
            return rowsAffected;
        }
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\\

        public static List<TransactionTBL> GetTransactions(int userid)
        {
            List<TransactionTBL> transactions = new List<TransactionTBL>();

            {
                string sql = "SELECT tblTransactions.transaction_id, tblTransactions.product_id, tblProducts.productName, tblProducts.productPrice\r\nFROM tblUsers\r\nJOIN tblTransactions ON tblUsers.user_id = tblTransactions.user_id\r\nJOIN tblProducts ON tblTransactions.product_id = tblProducts.product_id\r\nWHERE tblUsers.user_id = @user_id;";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@user_id", userid);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TransactionTBL transaction = new TransactionTBL();
                    transaction.transactionID = Convert.ToInt32(reader["transaction_id"]);
                    transaction.ProductID = Convert.ToInt32(reader["product_id"]);
                    transaction.product_name = Convert.ToString(reader["ProductName"]);
                    transaction.product_price = Convert.ToDecimal(reader["productPrice"]);
                    
                    transactions.Add(transaction);
                }
                reader.Close();
                con.Close();
            }
            return transactions;
        }
    }
}