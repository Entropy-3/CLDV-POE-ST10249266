using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace CLDV_POE_ST10249266.Models
{
    
    public class TransactionTBL
    {
        public static string con_string = "Server=tcp:st10249266-sql-server.database.windows.net,1433;Initial Catalog=CLDV-DBS;Persist Security Info=False;User ID=entropy-3;Password=hifr@220404;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public static SqlConnection con = new SqlConnection(con_string);

            public int UserID { get; set; }
            public int ProductID { get; set; }


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

    }
}
