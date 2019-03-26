USE ConsoleShop; 
SELECT Product.*, [Category].[Name] AS [Category], [Location].[Name] AS [Location], [State].[Name] AS [State], [Role].[Id] AS [RoleId], [User].[Login] AS [Login], [User].[Email] AS [Email], [User].[PhoneNumber] AS [PhoneNumber]
FROM [Product]
JOIN [Category] ON [Product].[CategoryId] = [Category].Id
JOIN [Location] ON [Product].[LocationId] = [Location].Id
JOIN [State] ON [Product].[StateId] = [State].Id
JOIN [User] ON [Product].[UserId] = [User].[Id]
JOIN [Role] ON [User].[RoleId] = [Role].[Id]
