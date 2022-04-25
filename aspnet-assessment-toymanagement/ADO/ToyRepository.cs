using aspnet_assessment.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace aspnet_assessment.ADO
{
    public class ToyRepository
    {
        string connectionString = @"data source=(localdb)\MSSQLLocalDB;database=ToyDB;integrated security=SSPI";
        public void AddToy(Toy toy)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "sp_AddToy";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Connection = connection;
                    // open the sql connection.
                    connection.Open();

                    SqlParameter paramName = new SqlParameter { ParameterName = "@name", SqlDbType = SqlDbType.VarChar, Value = toy.Name };
                    SqlParameter paramCategory = new SqlParameter { ParameterName = "category", SqlDbType = SqlDbType.VarChar, Value = toy.Category };
                    SqlParameter paramDescription = new SqlParameter { ParameterName = "@description", SqlDbType = SqlDbType.VarChar, Value = toy.Description };
                    
                    SqlParameter paramAmount = new SqlParameter { ParameterName = "@amount", SqlDbType = SqlDbType.VarChar, Value = toy.Amount };
                    //Adding parameter instance to sql command.
                    command.Parameters.Add(paramName);
                    command.Parameters.Add(paramCategory);
                    command.Parameters.Add(paramDescription);
                    command.Parameters.Add(paramAmount);
                    command.ExecuteNonQuery();

                }
            }
        }

        public List<Toy> GetToys()
        {
            List<Toy> toyList = new List<Toy>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "sp_ViewAllToy";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Connection = connection;
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Toy toy = new Toy();
                        toy.Id = Convert.ToInt32(reader["ToyId"]);
                        toy.Name = Convert.ToString(reader["ToyName"]);
                        toy.Category = Convert.ToString(reader["ToyCategory"]);
                        toy.Description = Convert.ToString(reader["ToyDescription"]);
                        toy.Amount = Convert.ToInt32((reader["ToyAmount"]));
                        toyList.Add(toy);
                    }
                }

            }
            return toyList;
        }

        public void RemoveToy(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "sp_DeleteToy";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Connection = connection;
                    connection.Open();
                    SqlParameter paramId = new SqlParameter { ParameterName = "@id", SqlDbType = SqlDbType.Int, Value = id };
                    command.Parameters.Add(paramId);
                    command.ExecuteNonQuery();

                }
            }
        }

    }
}