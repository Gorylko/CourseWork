using System;
using System.Collections.Generic;
using Shop.Shared.Entities;
using System.Data.SqlClient;
using Typography = Shop.Shared.Constants.TypographyConstants;
using SqlConst = Shop.Data.Constants.SqlQueryConstants;
using Shop.Data.DataContext.Interfaces;

namespace Shop.Data.DataContext.Realization.MsSql
{
    public class ProductContext : IProductContext
    {
        UserContext _userContext = new UserContext();
        CategoryContext _categoryContext = new CategoryContext();
        StateContext _stateContext = new StateContext();
        LocationContext _locationContext = new LocationContext();

        public IReadOnlyCollection<Product> GetAllByName(string searchParameter, string searchQuery)
        {
            using (var connection = new SqlConnection(SqlConst.ConnectionToConsoleShopString))
            {
                connection.Open();
                List<Product> products = new List<Product>();
                var command = new SqlCommand(SqlConst.SelectAllProductInDbString, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (reader[searchParameter].ToString().Contains(searchQuery))
                    {
                        products.Add(GetProduct(reader));
                    }
                }
                return products;
            }
        }

        public IReadOnlyCollection<Product> GetByCategoryId(int categoryId)
        {
            List<Product> products = new List<Product>();
            using (var connection = new SqlConnection(SqlConst.ConnectionToConsoleShopString))
            {
                connection.Open();
                using (var command = new SqlCommand(SqlConst.SelectAllProductInDbString, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if ((int)reader["CategoryId"] == categoryId)
                            {
                                products.Add(GetProduct(reader));
                            }
                        }
                    }
                }

                return products;
            }
        }

        public IReadOnlyCollection<Product> GetByUserId(int userId)
        {
            List<Product> products = new List<Product>();
            using (var connection = new SqlConnection(SqlConst.ConnectionToConsoleShopString))
            {
                connection.Open();
                using (var command = new SqlCommand(SqlConst.SelectAllProductInDbString, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if ((int)reader["UserId"] == userId)
                            {
                                    products.Add(GetProduct(reader));
                            }
                        }
                    }
                }

                return products;
            }
        }

        public Product GetProduct(SqlDataReader reader)
        {
            return new Product
            {
                Id = (int)reader["Id"],
                Name = (string)reader["Name"],
                Description = (string)reader["Description"],
                Price = (decimal)reader["Price"],
                CreationDate = (DateTime)reader["CreationDate"],
                LastModifiedDate = (DateTime)reader["LastModifiedDate"],
                Category = new Category
                {
                    Id = (int)reader["CategoryId"],
                    Name = (string)reader["Category"]
                },
                Author = _userContext.GetUser(reader),
                LocationOfProduct = (string)reader["Location"],
                State = (string)reader["State"]
            };
        }

        public Product GetById(int id)
        {
            using (var connection = new SqlConnection(SqlConst.ConnectionToConsoleShopString))
            {
                connection.Open();
                List<Product> products = new List<Product>();
                string query = SqlConst.SelectAllProductInDbString + Typography.NewLine + $"WHERE [Product].[Id] = {id}";
                var command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                reader.Read();
                return GetProduct(reader);
            }
        }

        public IReadOnlyCollection<Product> GetAll()
        {
            List<Product> returnProducts = new List<Product>();
            using (var connection = new SqlConnection(SqlConst.ConnectionToConsoleShopString))
            {
                connection.Open();
                List<Product> products = new List<Product>();
                var command = new SqlCommand(SqlConst.SelectAllProductInDbString, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    try
                    {
                        returnProducts.Add(GetProduct(reader));
                    }
                    catch (SqlException)
                    {

                    }
                }
                return returnProducts;
            }
        }

        public void DeleteById(int id)
        {
            using (var connection = new SqlConnection(SqlConst.ConnectionToConsoleShopString))
            {
                connection.Open();
                var command = new SqlCommand($"DELETE [Product] WHERE [Id] = {id}", connection);
                command.ExecuteNonQuery();
            }
        }

        public void Save(Product product)
        {
            using (var connection = new SqlConnection(SqlConst.ConnectionToConsoleShopString))
            {
                connection.Open();
                var command = new SqlCommand($"INSERT INTO [dbo].[Product]([CategoryId],[LocationId],[StateId],[UserId],[ProductName],[Description],[Price],[CreationDate],[LastModifiedDate]) VALUES(@categoryId, @locationId, @stateId, @authorId, @productName, @description, @price, @creationDate, @lastModifiedDate");
                command.Parameters.AddWithValue("@categoryId", product.Category.Id);
                command.Parameters.AddWithValue("@locationId", _locationContext.GetIdByName(product.LocationOfProduct));
                command.Parameters.AddWithValue("@stateId", _stateContext.GetIdByName(product.State));
                command.Parameters.AddWithValue("@authorId", product.Author.Id);
                command.Parameters.AddWithValue("@productName", product.Name);
                command.Parameters.AddWithValue("@description", product.Description);
                command.Parameters.AddWithValue("@price", product.Price);
                command.Parameters.AddWithValue("@creationDate", product.CreationDate);
                command.Parameters.AddWithValue("@lastModifiedDate", product.LastModifiedDate);
                command.ExecuteNonQuery();
            }
        }


    }
}
