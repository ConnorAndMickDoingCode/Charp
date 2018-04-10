using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using CLC.Exceptions;
using CLC.Models;

namespace CLC.Services.Data
{
    public class GameStateDAO
    {
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;" +
                                          "Initial Catalog=CharpDB;" +
                                          "Integrated Security=True;" +
                                          "Connect Timeout=30" +
                                          ";Encrypt=False;" +
                                          "TrustServerCertificate=True;" +
                                          "ApplicationIntent=ReadWrite;" +
                                          "MultiSubnetFailover=False";

        public int Create(User user, string json)
        {
            try
            {
                // Setup SELECT query with parameters
                string query = "INSERT INTO dbo.Games (USERNAME, STATE) VALUES (@Username, @State)";

                // Create connection and command
                using (SqlConnection cn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    // Set query parameters and their values
                    cmd.Parameters.Add("@State", SqlDbType.VarChar).Value = json;
                    cmd.Parameters.Add("@Username", SqlDbType.VarChar).Value = user.Username;

                    // Open the connection, execute INSERT, and close the connection
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }

                // Setup SELECT query with parameters
                query = "SELECT ID FROM dbo.Games WHERE STATE = @State";

                // Create connection and command
                using (SqlConnection cn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    // Set query parameters and their values
                    cmd.Parameters.Add("@State", SqlDbType.VarChar).Value = json;

                    // Open the connection, execute SELECT, retrieve ID
                    cn.Open();
                    var reader = cmd.ExecuteReader();
                    reader.Read();
                    var result = reader.GetInt32(0);
                    cn.Close();
                    return result;
                }
            }
            catch (SqlException e)
            {
                throw new MSDataException(e);
            }
        }

        public void Update(string json, int id)
        {
            try
            {
                // Setup SELECT query with parameters
                string query = "UPDATE dbo.Games SET STATE = @State WHERE id = @Id";

                // Create connection and command
                using (SqlConnection cn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    // Set query parameters and their values
                    cmd.Parameters.Add("@State", SqlDbType.VarChar).Value = json;
                    cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = id;

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

        public void Delete(int id)
        {
            try
            {
                // Setup SELECT query with parameters
                string query = "DELETE FROM dbo.Games WHERE id = @Id";

                // Create connection and command
                using (SqlConnection cn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    // Set query parameters and their values
                    cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = id;

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

        public string Read(int id)
        {
            try
            {
                // Setup SELECT query with parameters
                string query = "SELECT * FROM dbo.Games WHERE ID=@Id";

                // Create connection and command
                using (SqlConnection cn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    // Set query parameters and their values
                    cmd.Parameters.Add("@Id", SqlDbType.VarChar, 50).Value = id;

                    // Open the connection
                    cn.Open();

                    // Using a DataReader see if query returns any rows
                    SqlDataReader reader = cmd.ExecuteReader();
                    var result = "";
                    if (reader.Read())
                    {
                        result = reader.GetString(2);

                        // Close the connection
                        cn.Close();
                    }

                    // Return result of finder
                    return result;
                }
            }
            catch (SqlException e)
            {
                throw new MSDataException(e);
            }
        }

        public List<string> Read(User user)
        {
            try
            {
                // Setup SELECT query with parameters
                string query = "SELECT * FROM dbo.Games WHERE USERNAME=@Name";

                // Create connection and command
                using (SqlConnection cn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    // Set query parameters and their values
                    cmd.Parameters.Add("@Name", SqlDbType.VarChar, 50).Value = user.Username;

                    // Open the connection
                    cn.Open();

                    // Using a DataReader see if query returns any rows
                    var result = new List<string>();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        result.Add(reader.GetString(2));
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