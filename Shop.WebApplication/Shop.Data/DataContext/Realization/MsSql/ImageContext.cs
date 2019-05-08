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
    public class ImageContext
    {
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
                    list.Add(
                        new Image
                        {
                            Id = (int)reader["Id"],
                            Data = (byte[])reader["Data"],
                            Extension = (string)reader["Extension"]
                        });
                }
                return list;
            }
        }
    }
}
