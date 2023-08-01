using Microsoft.Data.SqlClient;
using System.Data;

namespace Panchayat.Models
{
    public class Signup
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public static void AddUserInSignup(Signup signup)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=cdac;Integrated Security=True";
            conn.Open();
            try
            {
                SqlCommand cmd1 = conn.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = $"insert into Signups(Email, Password) values('{signup.Email}', '{signup.Password}')";
                cmd1.ExecuteNonQuery();
                

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { conn.Close(); }

        }
        public static List<Signup> getAllSignups()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=cdac;Integrated Security=True";
            List<Signup> list = new List<Signup>();
            conn.Open();
            try
            {
                SqlCommand cmd1 = conn.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = $"select * from Signups";
                SqlDataReader dr = cmd1.ExecuteReader(); 
                while(dr.Read())
                {
                    list.Add(new Signup { Email = (string)dr["Email"], Password = (string)dr["Password"] });
                }
                return list;


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            finally { conn.Close(); }
        }

        public static bool VerifyUser(Signup signup)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=cdac;Integrated Security=True";
            conn.Open();
            try
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = $"select * from Signups where Email = '{signup.Email}' and Password = '{signup.Password}'";
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                Signup user = new Signup();
                user.Email = (string)dr["Email"];
                user.Password = (string)dr["Password"];
                if (user.Email.Equals(signup.Email) && user.Password.Equals(signup.Password))
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
