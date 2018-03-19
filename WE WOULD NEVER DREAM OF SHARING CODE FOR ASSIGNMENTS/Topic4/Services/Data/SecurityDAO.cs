using System;
using System.Data;
using System.Data.SqlClient;
using Topic4.Models;

namespace Topic4.Services.Data
{
    public class SecurityDAO
    {
        private static readonly SuperSecretHolder HolderOfSecrets = new SuperSecretHolder();

        private readonly String C_STRING = @"Data Source=(localdb)\MSSQLLocalDB;" +
                                           @"Initial Catalog=Funny;" +
                                           @"Integrated Security=True;" +
                                           @"Connect Timeout=30;" +
                                           @"Encrypt=False;" +
                                           @"TrustServerCertificate=True;" +
                                           @"ApplicationIntent=ReadWrite;" +
                                           @"MultiSubnetFailover=False";

        public bool FindByUser(UserModel user)
        {
            bool result = false;

            try
            {
                // Setup SELECT query with parameters
                var query = @"SELECT * FROM CalvinsFriends " +
                                  @"WHERE USERNAME = '" + user.Username + @"' AND " +
                                  @"PASSWORD = '" + user.Password + @"'";

                // Create connection and command
                using (SqlConnection cn = new SqlConnection(C_STRING))
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

        public bool Create(UserModel user)
        {
            bool result = false;

            try
            {
                // Setup INSERT query with parameters
                string query = @"INSERT INTO CalvinsFriends (USERNAME, PASSWORD) "+
                               @"VALUES (@Username, @Password)";

                // Create connection and command
                using (SqlConnection cn = new SqlConnection(C_STRING))
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