using Shop.Data.DataContext.Interfaces;
using Shop.Shared.Entities;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using SqlConst = Shop.Data.Constants.SqlQueryConstants;
using Typography = Shop.Shared.Constants.TypographyConstants;

namespace Shop.Data.DataContext.Realization.MsSql
{
    public class LocationContext : ILocationContext<Location>
    {
        public IReadOnlyCollection<Location> GetAll() { return null; } //пока не нужно

        public int GetId(Location location)
        {
            using (var connection = new SqlConnection(SqlConst.ConnectionToShopString))
            {
                connection.Open();
                var command = new SqlCommand(SqlConst.SelectLocationString + $"\nWHERE [Country].[Name] = @country AND [City].[Name] = @city AND [Address].[Name] = @address", connection);
                command.Parameters.AddWithValue("@country", location.Country.Name);
                command.Parameters.AddWithValue("@city", location.City.Name);
                command.Parameters.AddWithValue("@address", location.Address.Name);
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                return (int)reader["Id"];
            }
        }

        public void Save(Location location)
        {
            using (var connection = new SqlConnection(SqlConst.ConnectionToShopString))
            {
                connection.Open();
                var command = new SqlCommand("INSERT INTO [Location] (CountryId, CityId, AddressId) VALUES (@countryId, @cityId, @addressId)", connection);
                command.Parameters.AddWithValue("@countryId", SaveCountryAndGetId(location.Country));
                command.Parameters.AddWithValue("@cityId", SaveCityAndGetId(location.City));
                command.Parameters.AddWithValue("@addressId", SaveAddressAndGetId(location.Address));
                command.ExecuteNonQuery();
            }
        }

        public Location GetById(int id)
        {
            using (var connection = new SqlConnection(SqlConst.ConnectionToShopString))
            {
                connection.Open();
                var command = new SqlCommand(SqlConst.SelectLocationString + $"\nWHERE [Location].[Id] = {id}", connection);
                var reader = command.ExecuteReader();
                reader.Read();
                return MapLocation(reader);
            }
        }

        public void DeleteById(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool IsExists(Location location)
        {
            using (var connection = new SqlConnection(SqlConst.ConnectionToShopString))
            {
                connection.Open();
                var command = new SqlCommand(SqlConst.SelectLocationString, connection);
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    return true;
                }
                return false;
            }
        }


        #region PrivateMethods

        private Location MapLocation(SqlDataReader reader)
        {
            return new Location
            {
                Id = (int)reader["Id"],
                Address = new Address
                {
                    Id = (int)reader["AddressId"],
                    Name = (string)reader["AddressName"]
                },
                City = new City
                {
                    Id = (int)reader["CityId"],
                    Name = (string)reader["CityName"]
                },
                Country = new Country
                {
                    Id = (int)reader["CountryId"],
                    Name = (string)reader["CountryName"]
                }
            };
        }

        private int? SaveCountryAndGetId(Country country)
        {
            using (var connection = new SqlConnection(SqlConst.ConnectionToShopString))
            {
                connection.Open();
                if (!IsExists(country))
                {
                    var insertCommand = new SqlCommand("INSERT INTO [Country] (Name) VALUES (@country)", connection);
                    insertCommand.Parameters.AddWithValue("@country", country.Name);
                    insertCommand.ExecuteNonQuery();
                }
                var selectCommand = new SqlCommand($"SELECT * FROM [Country] WHERE [Name] = @country", connection);
                selectCommand.Parameters.AddWithValue("@country", country.Name);
                var reader = selectCommand.ExecuteReader();
                reader.Read();
                return (int?)reader["Id"];
            }
        }

        private int? SaveCityAndGetId(City city)
        {
            using (var connection = new SqlConnection(SqlConst.ConnectionToShopString))
            {
                connection.Open();
                if (!IsExists(city))
                {
                    var insertCommand = new SqlCommand("INSERT INTO [City] (Name) VALUES (@city)", connection);
                    insertCommand.Parameters.AddWithValue("@city", city.Name);
                    insertCommand.ExecuteNonQuery();
                }
                var selectCommand = new SqlCommand($"SELECT * FROM [City] WHERE [Name] = @city", connection);
                selectCommand.Parameters.AddWithValue("@city", city.Name);
                var reader = selectCommand.ExecuteReader();
                reader.Read();
                return (int?)reader["Id"];
            }
        }

        private int? SaveAddressAndGetId(Address address)
        {
            using (var connection = new SqlConnection(SqlConst.ConnectionToShopString))
            {
                connection.Open();
                if (!IsExists(address))
                {
                    var insertCommand = new SqlCommand("INSERT INTO [Address] (Name) VALUES (@address)", connection);
                    insertCommand.Parameters.AddWithValue("@address", address.Name);
                    insertCommand.ExecuteNonQuery();
                }
                var selectCommand = new SqlCommand($"SELECT * FROM [Address] WHERE [Name] = @address", connection);
                selectCommand.Parameters.AddWithValue("@address", address.Name);
                var reader = selectCommand.ExecuteReader();
                reader.Read();
                return (int?)reader["Id"];
            }
        }

        private bool IsExists(Address address)
        {
            using (var connection = new SqlConnection(SqlConst.ConnectionToShopString))
            {
                connection.Open();
                var command = new SqlCommand($"SELECT * FROM [Address] WHERE [Name] = @address", connection);
                command.Parameters.AddWithValue("@address", address.Name);
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    return true;
                }
                return false;
            }
        }

        private bool IsExists(City city)
        {
            using (var connection = new SqlConnection(SqlConst.ConnectionToShopString))
            {
                connection.Open();
                var command = new SqlCommand($"SELECT * FROM [City] WHERE [Name] = @city", connection);
                command.Parameters.AddWithValue("@city", city.Name);
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    return true;
                }
                return false;
            }
        }

        private bool IsExists(Country country)
        {
            using (var connection = new SqlConnection(SqlConst.ConnectionToShopString))
            {
                connection.Open();
                var command = new SqlCommand($"SELECT * FROM [Country] WHERE [Name] = @country", connection);
                command.Parameters.AddWithValue("@country", country.Name);
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    return true;
                }
                return false;
            }
        }
        #endregion
    }
}
