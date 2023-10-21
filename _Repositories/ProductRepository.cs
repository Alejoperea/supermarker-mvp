﻿using System;
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
    internal class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public void Add(ProductsModel productsModel)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(ProductsModel productsModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductsModel> GetAll()
        {
            var productList = new List<ProductsModel>();
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM Products ORDER BY Products_Id Desc";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var productsModel = new ProductsModel();
                        productsModel.Id = (int)reader["Products_Id"];
                        productsModel.Name = reader["Products_Name"].ToString();
                        productsModel.Observation = reader["Products_Observation"].ToString();
                        productList.Add(productsModel);
                    }
                }
            }
            return productList;
        }

        public IEnumerable<ProductsModel> GetByValue(string value)
        {
            var productList = new List<ProductsModel>();
            int productId = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;
            string payModeName = value;
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"SELECT * FROM Products
                                        WHERE Pay_Mode_Id=@id or Pay_Mode_Name LIKE @name+ '%'
                                        ORDER By Pay_Mode_Id DESC";
                command.Parameters.Add("@id", SqlDbType.Int).Value = productId;
                command.Parameters.Add("@name", SqlDbType.NVarChar).Value = payModeName;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var productsModel = new ProductsModel();
                        productsModel.Id = (int)reader["Products_Id"];
                        productsModel.Name = reader["Products_Name"].ToString();
                        productsModel.Observation = reader["Products_Observation"].ToString();
                        productList.Add(productsModel);
                    }
                }
            }
            return productList;
        }
    }
}
