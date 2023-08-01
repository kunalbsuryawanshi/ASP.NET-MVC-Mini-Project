using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics;

namespace Panchayat.Models
{
    public class PanchayatActivity
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Activity name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Date is required.")]
        [Display(Name = "Date")]
        [RegularExpression(@"^(19|20)\d{2}-(0[1-9]|1[0-2])-(0[1-9]|[12][0-9]|3[01])$", ErrorMessage = "Invalid date format. Please use yyyy-MM-dd format.")]
        public string Date { get; set; }
        //public string Name { get; set; }
        //public string Description { get; set; }
        //public string Date { get; set; }

        public static void AddActivities(PanchayatActivity activity)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=cdac;Integrated Security=True";
            conn.Open();
            try
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = $"insert into PanchayatActivities(Name, Description, Date) values(@Name, @Description, @Date)";
                cmd.Parameters.AddWithValue("@Name", activity.Name);
                cmd.Parameters.AddWithValue("@Description", activity.Description);
                cmd.Parameters.AddWithValue("@Date", activity.Date);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally { conn.Close(); }
        }

        public static List<PanchayatActivity> GetAllActivities()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=cdac;Integrated Security=True";
            List<PanchayatActivity> list = new List<PanchayatActivity>();
            conn.Open();
            try
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from PanchayatActivities";
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    list.Add(new PanchayatActivity { Id = (int)dr["Id"], Name = (string)dr["Name"], Description = (string)dr["Description"], Date = (string)dr["Date"] });
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
        public static PanchayatActivity GetActivityById(int id)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=cdac;Integrated Security=True";
            conn.Open();
            try
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = $"select * from PanchayatActivities where Id ={id}";
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                PanchayatActivity activity = new PanchayatActivity();
                activity.Id = (int)dr["Id"];
                activity.Name = (string)dr["Name"];
                activity.Description = (string)dr["Description"];
                activity.Date = (string)dr["Date"];
                return activity;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally { conn.Close(); }
        }
        public static void UpdateActivity(int id, PanchayatActivity activity)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=cdac;Integrated Security=True";
            conn.Open();
            try
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = $"update PanchayatActivities set Name = '{activity.Name}', Description = '{activity.Description}', Date = '{activity.Date}' where Id ={id}";
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                
            }
            finally { conn.Close(); }

        }
        public static void DeleteActivity(int id)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=cdac;Integrated Security=True";
            conn.Open();
            try
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = $"delete from PanchayatActivities where Id ={id}";
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally { conn.Close(); }
        }
    }
}
