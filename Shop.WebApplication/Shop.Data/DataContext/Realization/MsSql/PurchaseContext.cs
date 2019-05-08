using Shop.Data.DataContext.Interfaces;
using Shop.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using SqlConst = Shop.Data.Constants.SqlQueryConstants;

namespace Shop.Data.DataContext.Realization.MsSql
{
    public class PurchaseContext : IDataContext<Purchase>
    {
        UserContext _userContext = new UserContext();
        ProductContext _productContext = new ProductContext();

        public IReadOnlyCollection<Purchase> GetAll()
        {
            using (var connection = new SqlConnection(SqlConst.ConnectionToShopString))
            {
                connection.Open();
                List<Purchase> allPurchases = new List<Purchase>();
                var command = new SqlCommand("SELECT * FROM Purchase", connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    allPurchases.Add(GetPurchase(reader));
                }
                return allPurchases;
            }
        }

        public Purchase GetById(int id)
        {
            using (var connection = new SqlConnection(SqlConst.ConnectionToShopString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand($"SELECT TOP 1 * FROM [Purchase] WHERE [Id] = {id}", connection);
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                return GetPurchase(reader);
            }
        }

        public void DeleteById(int id)
        {
            using (var connection = new SqlConnection(SqlConst.ConnectionToShopString))
            {
                connection.Open();
                var command = new SqlCommand($"DELETE [Purchase] WHERE [Id] = {id}", connection);
                command.ExecuteNonQuery();
            }
        }

        public void Save(Purchase purchase)
        {
            using (var connection = new SqlConnection(SqlConst.ConnectionToShopString))
            {
                connection.Open();
                var command = new SqlCommand($"INSERT INTO [Purchase] (ProductId, SellerId, CustomerId, Address, Date) VALUES ({purchase.Product.Id}, {_userContext.GetIdByUser(purchase.Seller)}, {_userContext.GetIdByUser(purchase.Customer)}, '{purchase.Address}', @date)", connection);
                command.Parameters.AddWithValue("@date", purchase.Date);
                command.ExecuteNonQuery();
            }
        }

        public Purchase GetPurchase(SqlDataReader reader)
        {
            return new Purchase
            {
                Id = (int)reader["Id"],
                Seller = _userContext.GetById((int)reader["SellerId"]),
                Customer = _userContext.GetById((int)reader["CustomerId"]),
                Address = (string)reader["Address"],
                Date = (DateTime)reader["Date"],
                Product = _productContext.GetById((int)reader["ProductId"])
            };
        }

    }
}
