using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Data;
using Supermarket_mvp.Models;
using System.Data;

namespace Supermarket_mvp._Repositories
{
    internal class ProvidersRepository : BaseRepository, IProvidersRepository
    {
        public ProvidersRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public void Add(ProvidersModel providersModel)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "INSERT INTO Providers VALUES (@name,@observation)";
                command.Parameters.Add("@name", SqlDbType.NVarChar).Value = providersModel.Name;
                command.Parameters.Add("@observation", SqlDbType.NVarChar).Value = providersModel.Observation;
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "DELETE FROM Providers WHERE Providers_Id = @id";
                command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                command.ExecuteNonQuery();
            }
        }

        public void Edit(ProvidersModel providersModel)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"UPDATE Providers
                                   SET Providers_Name =@name,
                                   Providers_Observation = @observation
                                   WHERE Providers_Id = @id";
                command.Parameters.Add("@name", SqlDbType.NVarChar).Value = providersModel.Name;
                command.Parameters.Add("@observation", SqlDbType.NVarChar).Value = providersModel.Observation;
                command.Parameters.Add("@id", SqlDbType.Int).Value = providersModel.Id;
                command.ExecuteNonQuery();

            }
        }

        public IEnumerable<ProvidersModel> GetAll()
        {
            var providersModeList = new List<ProvidersModel>();
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM Providers ORDER BY Providers_Id Desc";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var providersModel = new ProvidersModel();
                        providersModel.Id = (int)reader["Providers_Id"];
                        providersModel.Name = reader["Providers_Name"].ToString();
                        providersModel.Observation = reader["Providers_Observation"].ToString();
                        providersModeList.Add(providersModel);
                    }
                }
            }
            return providersModeList;
        }

        public IEnumerable<ProvidersModel> GetByValue(string value)
        {
            var providersModeList = new List<ProvidersModel>();
            int providersId = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;
            string providersName = value;
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"SELECT * FROM Providers
                                        WHERE Providers_Id=@id or Providers_Name LIKE @name+ '%'
                                        ORDER By Providers_Id DESC";
                command.Parameters.Add("@id", SqlDbType.Int).Value = providersId;
                command.Parameters.Add("@name", SqlDbType.NVarChar).Value = providersName;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var providersModel = new ProvidersModel();
                        providersModel.Id = (int)reader["Providers_Id"];
                        providersModel.Name = reader["Providers_Name"].ToString();
                        providersModel.Observation = reader["Providers_Observation"].ToString();
                        providersModeList.Add(providersModel);
                    }
                }
            }
            return providersModeList;
        }
    }
}
