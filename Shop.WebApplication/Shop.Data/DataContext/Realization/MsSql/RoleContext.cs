using Shop.Data.DataContext.Interfaces;
using Shop.Shared.Entities;
using Shop.Shared.Helpers;
using Shop.Shared.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using SqlConst = Shop.Data.Constants.SqlQueryConstants;

namespace Shop.Data.DataContext.Realization.MsSql
{
    public class RoleContext : IDataContext<RoleType>
    {
        public void DeleteById(int id)
        {
            using (var connection = new SqlConnection(SqlConst.ConnectionToShopString))
            {
                connection.Open();
                var command = new SqlCommand($"DELETE [Role] WHERE [Id] = {id}", connection);
                command.ExecuteNonQuery();
            }
        }

        public IReadOnlyCollection<RoleType> GetAll()
        {
            using (var connection = new SqlConnection(SqlConst.ConnectionToShopString))
            {
                connection.Open();
                List<RoleType> allRoles = new List<RoleType>();
                var command = new SqlCommand("SELECT * FROM [Role]", connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    allRoles.Add(EnumHelper.ParseEnum<RoleType>(reader["Name"].ToString()));
                }
                return allRoles;
            }
        }

        public RoleType GetById(int id)
        {
            using (var connection = new SqlConnection(SqlConst.ConnectionToShopString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand($"SELECT TOP 1 * FROM [Role] WHERE [Id] = {id}", connection);
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                return EnumHelper.ParseEnum<RoleType>(reader["Name"].ToString());
            }
        }

        public void Save(RoleType role)
        {
            using (var connection = new SqlConnection(SqlConst.ConnectionToShopString))
            {
                connection.Open();
                var command = new SqlCommand($"INSERT INTO [Role] (Name) VALUES ('{role.ToString()}')", connection);
                command.ExecuteNonQuery();
            }
        }
    }
}
