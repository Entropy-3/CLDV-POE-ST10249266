﻿using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace CLDV_POE_ST10249266.Models
{
    public class userTBL
    {
        public static string con_string = "Server=tcp:st10249266-sql-server.database.windows.net,1433;Initial Catalog=CLDV-DBS;Persist Security Info=False;User ID=entropy-3;Password=hifr@220404;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public static SqlConnection con = new SqlConnection(con_string);
        
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int insert_User(userTBL m)
        {
            string sql = "INSERT INTO tblUsers (userName, userSurname, userEmail, userPassword) VALUES (@Name, @Surname, @Email, @Password)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Name", m.Name);
            cmd.Parameters.AddWithValue("@Surname", m.Surname);
            cmd.Parameters.AddWithValue("@Email", m.Email);
            cmd.Parameters.AddWithValue("@Password", m.Password);
            con.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            con.Close();
            return rowsAffected;
        }
    }
}