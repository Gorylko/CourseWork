using Shop.Data.DataContext.Interfaces;
using System.Collections.Generic;
using System.Data.SqlClient;
using SqlConst = Shop.Data.Constants.SqlQueryConstants;

namespace Shop.Data.DataContext.Realization.MsSql
{
    public class LocationContext : IProductDetailsContext<string>
    {
        public IReadOnlyCollection<string> GetAll() { return null; } //пока не нужно

        public int GetIdByName(string name)
        {
            using (var connection = new SqlConnection(SqlConst.ConnectionToShopString))
            {
                connection.Open();
                var command = new SqlCommand($"SELECT * FROM [Location] WHERE [Name] = '{name}'", connection);
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                try
                {
                    return (int)reader["Id"];
                }
                catch
                {
                    return 0;
                }
            }
        }

        public void Save(string location)
        {
            using (var connection = new SqlConnection(SqlConst.ConnectionToShopString))
            {
                connection.Open();
                var command = new SqlCommand($"INSERT INTO [Location] (Name) VALUES (@location)", connection);
                command.Parameters.AddWithValue("@location", location);
                command.ExecuteNonQuery();
            }
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
