using System.Data.SqlClient;

namespace CLDV_POE_ST10249266.Models
{
    public class ProductDisplayModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public decimal Quantity { get; set; }

        public bool Availability { get; set; }

        public string Image { get; set; }

        public ProductDisplayModel()
        { }

        public ProductDisplayModel(string name, string description, decimal price, decimal quantity, bool availability, string image)
        {
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
                string sql = "SELECT productName, productDescription, productPrice, productQuantity, productAvailability, productImage FROM tblProducts";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //ProductDisplayModel product = new ProductDisplayModel();
                    //product.Name = Convert.ToString(reader["ProductName"]);
                    //product.Description = Convert.ToString(reader["productDescription"]);
                    //product.Price = Convert.ToDecimal(reader["ProductPrice"]);
                    //product.Quantity = Convert.ToDecimal(reader["productQuantity"]);
                    //product.Availability = Convert.ToBoolean(reader["ProductAvailability"]);
                    //product.Image = Convert.ToString(reader["productImage"]);
                    //products.Add(product);
                    products.Add(new ProductDisplayModel
                    {
                        Name = Convert.ToString(reader["productName"]),
                        Description = Convert.ToString(reader["productDescription"]),
                        Price = Convert.ToDecimal(reader["productPrice"]),
                        Quantity = Convert.ToDecimal(reader["productQuantity"]),
                        Availability = Convert.ToBoolean(reader["productAvailability"]),
                        Image = reader["productImage"] as string, // Change this line
                    });
                }
                reader.Close();
            }
            return products;
        }
    }
}