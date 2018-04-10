using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CLC.Exceptions;
using CLC.Models;

namespace CLC.Services.Data
{
    public class LeaderboardDAO
    {
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;" +
                                          "Initial Catalog=CharpDB;" +
                                          "Integrated Security=True;" +
                                          "Connect Timeout=30" +
                                          ";Encrypt=False;" +
                                          "TrustServerCertificate=True;" +
                                          "ApplicationIntent=ReadWrite;" +
                                          "MultiSubnetFailover=False";

        public void Create(GameStat game)
        {
            try
            {
                // Setup SELECT query with parameters
                string query =
                    "INSERT INTO dbo.Leaderboards (USERNAME, TIME, SIZE, COUNT) VALUES (@Username, @Time, @Size, @Count)";

                // Create connection and command
                using (SqlConnection cn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    // Set query parameters and their values
                    cmd.Parameters.Add("@Username", SqlDbType.VarChar).Value = game.Username;
                    cmd.Parameters.Add("@Time", SqlDbType.VarChar).Value = game.Time;
                    cmd.Parameters.Add("@Size", SqlDbType.VarChar).Value = game.Size;
                    cmd.Parameters.Add("@Count", SqlDbType.VarChar).Value = game.Count;

                    // Open the connection, execute INSERT, and close the connection
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }
            }
            catch (SqlException e)
            {
                throw new MSDataException(e);
            }
        }

        public List<string[]> Read()
        {
            try
            {
                // Setup SELECT query with parameters
                string query = "SELECT * FROM dbo.Leaderboards";

                // Create connection and command
                using (SqlConnection cn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    // Open the connection
                    cn.Open();

                    // Using a DataReader see if query returns any rows
                    var result = new List<string[]>();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string[] a =
                        {
                            reader.GetString(0),
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetString(3),
                            reader.GetString(4)
                        };
                        result.Add(a);
                    }

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
    }
}