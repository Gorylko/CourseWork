using System.Data.SqlClient;
using SqlConst = Shop.Data.Constants.SqlQueryConstants;
using Shop.Data.DataContext.Interfaces;
using Shop.Shared.Entities;
using System.Collections.Generic;

namespace Shop.Data.DataContext.Realization.MsSql
{
    public class LocationContext : IProductDetailsContext<string>
    {
        public IReadOnlyCollection<string> GetAll() { return null; } //пока не нужно

        public int GetIdByName(string name)
        {
            using (var connection = new SqlConnection(SqlConst.ConnectionToConsoleShopString))
            {
                connection.Open();
                var command = new SqlCommand($"SELECT * FROM [Location] WHERE [Name] = '{name}'", connection);
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                return (int)reader["Id"];
            }
        }

        public void Save(string obj)
        {
            throw new System.NotImplementedException();
        }

        public string GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new System.NotImplementedException();
        }

    }
}
