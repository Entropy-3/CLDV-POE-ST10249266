using System.Data.SqlClient;

namespace CLDV_POE_ST10249266.Models
{
    public class productTBL
    {
        public static string con_string = "Server=tcp:st10249266-sql-server.database.windows.net,1433;Initial Catalog=CLDV-DBS;Persist Security Info=False;User ID=entropy-3;Password=hifr@220404;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public static SqlConnection con = new SqlConnection(con_string);

        public string productName { get; set; }

        public string productDescription { get; set; }

        public decimal productPrice { get; set; }

        public decimal productQuantity { get; set; }

        public bool productAvailability { get; set; }

        public string productImage { get; set; }

        public int insert_Product(productTBL m)
        {
            m.productAvailability = m.productQuantity > 0;
            string sql = "INSERT INTO tblProducts (productName, productDescription, productPrice, productQuantity, productAvailability, productImage) VALUES (@productName, @productDescription, @productPrice, @productQuantity, @productAvailability, @productImage)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@productName", m.productName);
            cmd.Parameters.AddWithValue("@productDescription", m.productDescription);
            cmd.Parameters.AddWithValue("@productPrice", m.productPrice);
            cmd.Parameters.AddWithValue("@productQuantity", m.productQuantity);
            cmd.Parameters.AddWithValue("@productAvailability", m.productAvailability);
            cmd.Parameters.AddWithValue("@productImage", m.productImage);
            con.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            con.Close();
            return rowsAffected;
        }
    }
}