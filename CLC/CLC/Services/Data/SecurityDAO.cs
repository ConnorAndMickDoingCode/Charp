using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MSWA_Milestone2.Models;

namespace MSWA_Milestone2.Services.Data
{
    public class SecurityDAO
    {
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;" +
                                          "Initial Catalog=CharpDB;" +
                                          "Integrated Security=True;" +
                                          "Connect Timeout=30" +
                                          ";Encrypt=False;" +
                                          "TrustServerCertificate=True;" +
                                          "ApplicationIntent=ReadWrite;" +
                                          "MultiSubnetFailover=False";

        public bool FindByUser(User user)
        {
            bool result = false;

            try
            {
                // Setup SELECT query with parameters
                string query = "SELECT * FROM dbo.Users WHERE USERNAME=@Username AND PASSWORD=@Password";

                // Create connection and command
                using (SqlConnection cn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    // Set query parameters and their values
                    cmd.Parameters.Add("@Username", SqlDbType.VarChar, 50).Value = user.Username;
                    cmd.Parameters.Add("@Password", SqlDbType.VarChar, 50).Value = user.Password;

                    // Open the connection
                    cn.Open();

                    // Using a DataReader see if query returns any rows
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                        result = true;
                    else
                        result = false;

                    // Close the connection
                    cn.Close();
                }

            }
            catch (SqlException e)
            {
                // TODO: should log exception and then throw a custom exception
                throw e;
            }

            // Return result of finder
            return result;
        }

        public bool Create(User user)
        {
            bool result = false;

            try
            {
                // Setup INSERT query with parameters
                string query = "INSERT INTO dbo.Users (USERNAME, PASSWORD) VALUES (@Username, @Password)";

                // Create connection and command
                using (SqlConnection cn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    // Set query parameters and their values
                    cmd.Parameters.Add("@Username", SqlDbType.VarChar, 50).Value = user.Username;
                    cmd.Parameters.Add("@Password", SqlDbType.VarChar, 50).Value = user.Password;

                    // Open the connection, execute INSERT, and close the connection
                    cn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    if (rows == 1)
                        result = true;
                    else
                        result = false;
                    cn.Close();
                }

            }
            catch (SqlException e)
            {
                // TODO: should log exception and then throw a custom exception
                throw e;
            }

            // Return result of create
            return result;
        }
    }
}