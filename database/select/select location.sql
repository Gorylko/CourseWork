USE [UglyExpressShop]
GO

SELECT [Location].*, [Country].[Name] AS CountryName, [City].[Name] AS CityName, [Address].[Name] AS AddressName
FROM[Location]
JOIN[Country] ON[Location].[CountryId] = [Country].[Id]
JOIN[City] ON[Location].[CityId] = [City].[Id]
JOIN[Address] ON[Location].[AddressId] = [Address].[Id]