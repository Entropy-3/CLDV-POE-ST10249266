using System.Data.SqlClient;

namespace CLDV_POE_ST10249266.Models
{
    public class ProductDisplayModel
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public decimal Quantity { get; set; }

        public bool Availability { get; set; }

        public string Image { get; set; }

        public ProductDisplayModel()
        { }

        public ProductDisplayModel(int id, string name, string description, decimal price, decimal quantity, bool availability, string image)
        {
            ID = id;
            Name = name;
            Description = description;
            Price = price;
            Quantity = quantity;
            Availability = availability;
            Image = image;
        }

        public static List<ProductDisplayModel> SelectProducts()
        {
            List<ProductDisplayModel> products = new List<ProductDisplayModel>();

            string con_string = "Server=tcp:st10249266-sql-server.database.windows.net,1433;Initial Catalog=CLDV-DBS;Persist Security Info=False;User ID=entropy-3;Password=hifr@220404;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            using (SqlConnection con = new SqlConnection(con_string))
            {
                string sql = "SELECT product_id, productName, productDescription, productPrice, productQuantity, productAvailability, productImage FROM tblProducts";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductDisplayModel product = new ProductDisplayModel();
                    product.ID = Convert.ToInt32(reader["product_id"]);
                    product.Name = Convert.ToString(reader["ProductName"]);
                    product.Description = Convert.ToString(reader["productDescription"]);
                    product.Price = Convert.ToDecimal(reader["ProductPrice"]);
                    product.Quantity = Convert.ToDecimal(reader["productQuantity"]);
                    product.Availability = Convert.ToBoolean(reader["ProductAvailability"]);
                    product.Image = Convert.ToString(reader["productImage"]);
                    products.Add(product);
                }
                reader.Close();
            }
            return products;
        }
    }
}