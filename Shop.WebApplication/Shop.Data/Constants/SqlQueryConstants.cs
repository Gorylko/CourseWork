using Typography = Shop.Shared.Constants.TypographyConstants;

namespace Shop.Data.Constants
{
    public class SqlQueryConstants
    {
        public const string SelectAllProductInDbString = "USE [UglyExpressShop]" + Typography.NewLine +
        "SELECT Product.*, [Category].[Name] AS [Category], [State].[Name] AS [State], [Role].[Id] AS [RoleId], [User].[Login] AS [Login], [User].[Email] AS [Email], [User].[PhoneNumber] AS [PhoneNumber], [User].[Id] AS [UserId] " + Typography.NewLine +
        "FROM [Product]" + Typography.NewLine +
        "JOIN [Category] ON [Product].[CategoryId] = [Category].Id" + Typography.NewLine +
        "JOIN [Location] ON [Product].[LocationId] = [Location].Id" + Typography.NewLine +
        "JOIN [State] ON [Product].[StateId] = [State].Id" + Typography.NewLine +
        "JOIN [User] ON [Product].[UserId] = [User].[Id]" + Typography.NewLine +
        "JOIN [Role] ON [User].[RoleId] = [Role].[Id]";

        public const string SelectLocationString = "SELECT [Location].*, [Country].[Name] AS [CountryName], [City].[Name] AS [CityName], [Address].[Name] AS [AddressName]" + Typography.NewLine + 
        "FROM[Location]" + Typography.NewLine +
        "JOIN[Country] ON[Location].[CountryId] = [Country].[Id]" + Typography.NewLine +
        "JOIN[City] ON[Location].[CityId] = [City].[Id]" + Typography.NewLine +
        "JOIN[Address] ON[Location].[AddressId] = [Address].[Id]";

        public const string ConnectionToShopString = "Data Source=LAPTOP-P3338OQH;Initial Catalog=UglyExpressShop;Integrated Security=True"; //менять при необходимости

        public const string ConnectionToUsersString = "";
    }
}
