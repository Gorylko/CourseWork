using Shop.Data.DataContext.Interfaces;
using Shop.Shared.Entities;
using System.Collections.Generic;
using System.Data.SqlClient;
using SqlConst = Shop.Data.Constants.SqlQueryConstants;
using Typography = Shop.Shared.Constants.TypographyConstants;

namespace Shop.Data.DataContext.Realization.MsSql
{
    public class CategoryContext : ICategoryContext
    {
        public string GetAllString()
        {
            using (var connection = new SqlConnection(SqlConst.ConnectionToShopString))
            {
                connection.Open();
                string allCategories = "";
                var command = new SqlCommand("SELECT * FROM Category", connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        allCategories += reader.GetInt32(0) + "." + reader.GetString(1) + Typography.NewLine;
                    }
                }
                return allCategories;
            }
        }

        public IReadOnlyCollection<Category> GetAll()
        {
            using (var connection = new SqlConnection(SqlConst.ConnectionToShopString))
            {
                connection.Open();
                List<Category> allCategories = new List<Category>();
                var command = new SqlCommand("SELECT * FROM Category", connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    allCategories.Add(new Category
                    {
                        Id = (int)reader["Id"],
                        Name = (string)reader["Name"]
                    });
                }
                return allCategories;
            }
        }

        public Category GetById(int id)
        {
            using (var connection = new SqlConnection(SqlConst.ConnectionToShopString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand($"SELECT TOP 1 * FROM [Category] WHERE [Id] = {id}", connection);
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                return new Category
                {
                    Id = id,
                    Name = (string)reader["Name"]
                };
            }
        }

        public void DeleteById(int id)
        {
            using (var connection = new SqlConnection(SqlConst.ConnectionToShopString))
            {
                connection.Open();
                var command = new SqlCommand($"DELETE [Category] WHERE [Id] = {id}", connection);
                command.ExecuteNonQuery();
            }
        }

        public void Save(Category category)
        {
            using (var connection = new SqlConnection(SqlConst.ConnectionToShopString))
            {
                connection.Open();
                var command = new SqlCommand($"INSERT INTO [Category] (Name) VALUES ('{category.Name}')", connection);
                command.ExecuteNonQuery();
            }
        }

        public int GetIdByName(string name)
        {
            using (var connection = new SqlConnection(SqlConst.ConnectionToShopString))
            {
                connection.Open();
                var command = new SqlCommand($"SELECT * FROM [Category] WHERE [Name] = '{name}'", connection);
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                return (int)reader["Name"];
            }
        }
    }
}
