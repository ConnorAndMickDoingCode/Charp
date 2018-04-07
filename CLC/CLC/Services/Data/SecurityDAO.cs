/*
 version 0.2
 Connor, Mick
 CST-256 
 January 28, 2018 
 This assignment was completed in collaboration with Connor Low, Mick Torres. 
 We used source code from the following websites to complete this assignment: N/ A 
 */

using System.Data;
using System.Data.SqlClient;
using CLC.Exceptions;
using CLC.Models;

namespace CLC.Services.Data
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

        /**
         * Checks for an existing user to log-in
         */
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
                    result = reader.HasRows;

                    // Close the connection
                    cn.Close();

                    // Return result of finder
                    return result;
                }
            }
            catch (SqlException e)
            {
                throw new MSDataException(e);
            }
        }

        /**
         * Checks for an existing username
         */
        public bool UsernameFound(User user)
        {
            bool result = false;

            try
            {
                // Setup SELECT query with parameters
                string query = "SELECT * FROM dbo.Users WHERE USERNAME=@Username";

                // Create connection and command
                using (SqlConnection cn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    // Set query parameters and their values
                    cmd.Parameters.Add("@Username", SqlDbType.VarChar, 50).Value = user.Username;

                    // Open the connection
                    cn.Open();

                    // Using a DataReader see if query returns any rows
                    SqlDataReader reader = cmd.ExecuteReader();
                    result = reader.HasRows;

                    // Close the connection
                    cn.Close();
                }
            }
            catch (SqlException e)
            {
                throw new MSDataException(e);
            }

            // Return result of finder
            return result;
        }

        /**
         * Registers a User
         */
        public bool Create(User user)
        {
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
                    cn.Close();
                    return rows == 1;
                }
            }
            catch (SqlException e)
            {
                throw new MSDataException(e);
            }

            // Return result of create
        }
    }
}