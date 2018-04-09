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
                string query = "INSERT INTO dbo.Leaderboards (USERNAME, TIME, SIZE) VALUES (@Username, @Time, @Size)";

                // Create connection and command
                using (SqlConnection cn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    // Set query parameters and their values
                    cmd.Parameters.Add("@Username", SqlDbType.VarChar).Value = game.Username;
                    cmd.Parameters.Add("@Time", SqlDbType.VarChar).Value = game.Time;
                    cmd.Parameters.Add("@Size", SqlDbType.VarChar).Value = game.Size;

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
    }
}