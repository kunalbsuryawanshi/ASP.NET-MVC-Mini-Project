using Microsoft.Data.SqlClient;
using System.Data;
using System;

namespace Panchayat.Models
{
    public class Admin
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public static bool AdminLogin(Admin admin)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=cdac;Integrated Security=True";
            
            conn.Open();
            try
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Admins";
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();

                string Username = (string)dr["Username"];
                string Password = (string)dr["Password"];
                if (Username.Equals(admin.Username) && Password.Equals(admin.Password))
                    return true;
                else
                    return false;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
               
            }
            finally { conn.Close(); }
        }

    }
}
