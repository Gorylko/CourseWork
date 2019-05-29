using Shop.Data.DataContext.Interfaces;
using Shop.Shared.Entities;
using Shop.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using SqlConst = Shop.Data.Constants.SqlQueryConstants;
using Typography = Shop.Shared.Constants.TypographyConstants;
using Shop.Shared.Entities.Images;

namespace Shop.Data.DataContext.Realization.MsSql
{
    public class ImageContext : IImageContext
    {
        private Image MapImage(SqlDataReader reader)
        {
            return new Image
            {
                Id = (int)reader["Id"],
                Data = (byte[])reader["Data"],
                Extension = (string)reader["Extension"]
            };
        }

        public IReadOnlyCollection<Image> GetAllByProductId(int id)
        {
            using (var connection = new SqlConnection(SqlConst.ConnectionToShopString))
            {
                connection.Open();
                var list = new List<Image>();
                var command = new SqlCommand($"SELECT * FROM [Image] WHERE [ProductId] = {id}", connection);
                var reader = command.ExecuteReader();
                while(reader.Read())
                {
                    list.Add(MapImage(reader));
                }
                return list;
            }
        }

        public IReadOnlyCollection<Image> GetAllByUserId(int id)
        {
            using (var connection = new SqlConnection(SqlConst.ConnectionToShopString))
            {
                connection.Open();
                var list = new List<Image>();
                var command = new SqlCommand($"SELECT * FROM [Image] WHERE [UserId] = {id}", connection);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(MapImage(reader));
                }
                return list;
            }
        }

        public void DeleteAllByUserId(int userId)
        {
            using (var connection = new SqlConnection(SqlConst.ConnectionToShopString))
            {
                connection.Open();
                var command = new SqlCommand("DELETE [Image] WHERE [UserId] = @userId", connection);
                command.Parameters.AddWithValue("@userId", userId);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteAllByProductId(int productId)
        {
            using (var connection = new SqlConnection(SqlConst.ConnectionToShopString))
            {
                connection.Open();
                var command = new SqlCommand("DELETE [Image] WHERE [ProductId] = @productId", connection);
                command.Parameters.AddWithValue("@productId", productId);
                command.ExecuteNonQuery();
            }
        }

        public Image GetById(int id)
        {
            using (var connection = new SqlConnection(SqlConst.ConnectionToShopString))
            {
                connection.Open();
                var command = new SqlCommand($"SELECT * FROM [Image] WHERE [Id] = {id}", connection);
                var reader = command.ExecuteReader();
                reader.Read();
                return MapImage(reader);
            }
        }

        public void Save(Image image, object owner)
        {
            using (var connection = new SqlConnection(SqlConst.ConnectionToShopString))
            {
                connection.Open();
                string productId = "null";
                string userId = "null";

                if(owner is Product product)
                {
                    productId = product.Id.ToString();
                }

                else if(owner is User user)
                {
                    userId = user.Id.ToString();
                }

                var command = new SqlCommand($"INSERT INTO [Image] ([Data], [Extension], [ProductId], [UserId]) VALUES (@data, @extension, {productId}, {userId})", connection);
                command.Parameters.AddWithValue("@data", image.Data);
                command.Parameters.AddWithValue("@extension", image.Extension);

                command.ExecuteNonQuery();
            }
        }
    }
}
