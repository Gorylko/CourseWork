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
        LocationContext _locationContex = new LocationContext();

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
                    allPurchases.Add(MapPurchase(reader));
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
                return MapPurchase(reader);
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
                var command = new SqlCommand($"INSERT INTO [Purchase] (ProductId, SellerId, CustomerId, LocationId, Date) VALUES (@productId, @sellerId, @customerId, @locationId, @date)", connection);
                command.Parameters.AddWithValue("@productId", purchase.Product.Id);
                command.Parameters.AddWithValue("@sellerId", purchase.Seller.Id);
                command.Parameters.AddWithValue("@customerId", purchase.Customer.Id);
                command.Parameters.AddWithValue("@locationId", purchase.Location.Id);
                command.Parameters.AddWithValue("@date", purchase.Date);

                command.ExecuteNonQuery();
            }
        }

        public Purchase MapPurchase(SqlDataReader reader)
        {
            return new Purchase
            {
                Id = (int)reader["Id"],
                Seller = _userContext.GetById((int)reader["SellerId"]),
                Customer = _userContext.GetById((int)reader["CustomerId"]),
                Location = _locationContex.GetById((int)reader["LocationId"]),
                Date = (DateTime)reader["Date"],
                Product = _productContext.GetById((int)reader["ProductId"])
            };
        }

    }
}
