using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApiApp1.Models
{
    public class RegistrationDAL
    {
        string connectionString = "initial catalog=PathDB;data source=E1DV369;integrated security=false;User ID=sa;Password=path1234;";
        public IEnumerable<Registration> GetAllUsers()
        {
            try
            {
                List<Registration> lstusers = new List<Registration>();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("getUserList", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Registration users = new Registration();

                       
                        users.Password = rdr["Password"].ToString(); //Convert.ToInt32(rdr["EmployeeID"]);
                        users.PasswordSalt = rdr["PasswordSalt"].ToString();
                        users.FirstName = rdr["FirstName"].ToString();
                        users.LastName = rdr["LastName"].ToString();
                        users.IPAddress = rdr["IPAddress"].ToString();
                        users.Department = rdr["Department"].ToString();

                        lstusers.Add(users);
                    }
                    con.Close();
                }
                return lstusers;
            }
            catch
            {
                throw;
            }
        }

        public int AddUser(Registration Register)
        {
            //string connectionString = "initial catalog=pathDB;data source=WINDOWS-U8FSE45\\SQLEXPRESS;integrated security=true";

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spAddUser", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //cmd.Parameters.AddWithValue("@UserID", Register.UserID);
                    cmd.Parameters.AddWithValue("@Pwd", Register.Password);
                    cmd.Parameters.AddWithValue("@PwdSalt", Register.PasswordSalt);
                    cmd.Parameters.AddWithValue("@FName", Register.FirstName);
                    cmd.Parameters.AddWithValue("@LName", Register.LastName);
                    cmd.Parameters.AddWithValue("@IPadd", "HC_642 White Hague Avenue");
                    cmd.Parameters.AddWithValue("@Dept", Register.Department);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return 1;
            }
            catch
            {
                throw;
            }
        }
    }
}