using Shop.Data.DataContext.Interfaces;
using Shop.Shared.Entities;
using System.Collections.Generic;
using System.Data.SqlClient;
using SqlConst = Shop.Data.Constants.SqlQueryConstants;

namespace Shop.Data.DataContext.Realization.MsSql
{
    public class StateContext : IProductDetailsContext<State>
    {
        public int GetIdByName(string name)
        {
            using (var connection = new SqlConnection(SqlConst.ConnectionToConsoleShopString))
            {
                connection.Open();
                var command = new SqlCommand($"SELECT * FROM [State] WHERE [Name] = '{name}'", connection);
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                return (int)reader["State"];
            }
        }

        public IReadOnlyCollection<State> GetAll()
        {
            using (var connection = new SqlConnection(SqlConst.ConnectionToConsoleShopString))
            {
                connection.Open();
                List<State> allCategories = new List<State>();
                var command = new SqlCommand("SELECT * FROM State", connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    allCategories.Add(new State
                    {
                        Id = (int)reader["Id"],
                        Name = (string)reader["Name"]
                    });
                }
                return allCategories;
            }
        }

        public State GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Save(State obj)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteById(int id)
        {
            using (var connection = new SqlConnection(SqlConst.ConnectionToConsoleShopString))
            {
                connection.Open();
                var command = new SqlCommand($"DELETE [State] WHERE [Id] = {id}", connection);
                command.ExecuteNonQuery();
            }
        }
    }
}
