using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using static UglyUtility.Constants;

namespace UglyUtility
{
    internal class QueryContext
    {
        internal string ConnectionString { get; set; }

        internal QueryContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public void CreateAllTables()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = "USE[UglyExpressShop];" + NewLine +
                "CREATE TABLE[dbo].[Category]" + NewLine +
                "(" + NewLine +
                "[Id] INT IDENTITY(1,1) NOT NULL," + NewLine +
                "[Name] NVARCHAR(20) NOT NULL," + NewLine +


                " PRIMARY KEY CLUSTERED([Id] ASC)" + NewLine +
                ");" + NewLine +
                "CREATE TABLE[dbo].[Location]" + NewLine +
                "(" + NewLine +

                "[Id] INT IDENTITY(1,1) NOT NULL," + NewLine +

                "[Name] NVARCHAR(50) NOT NULL," + NewLine +
                "PRIMARY KEY CLUSTERED([Id]ASC)" + NewLine +
                ");" + NewLine +
                "CREATE TABLE[dbo].[State]" + NewLine +
                "(" + NewLine +

                "[Id] INT IDENTITY(1,1) NOT NULL," + NewLine +

                "[Name]NVARCHAR(40) NOT NULL," + NewLine +
                " PRIMARY KEY CLUSTERED([Id]ASC)" + NewLine +
                ");" + NewLine +
                "CREATE TABLE[dbo].[Role]" + NewLine +
                "(" + NewLine +

                "[Id] INT IDENTITY(1,1) NOT NULL," + NewLine +

                "[Name] NVARCHAR(20) NOT NULL," + NewLine +
                "PRIMARY KEY CLUSTERED([Id] ASC)" + NewLine +
                ");" + NewLine +
                "CREATE TABLE[dbo].[User]" + NewLine +
                "(" + NewLine +

                "[Id] INT IDENTITY(1,1) NOT NULL," + NewLine +

                "[RoleId] INT NOT NULL," + NewLine +

                "[Login] NVARCHAR(20) NOT NULL UNIQUE," + NewLine +

                "[Password] NVARCHAR(20) NOT NULL," + NewLine +

                "[Email] NVARCHAR(20) NOT NULL UNIQUE," + NewLine +

                "[PhoneNumber] NVARCHAR(15) NULL," + NewLine +

                "PRIMARY KEY CLUSTERED([Id] ASC)," + NewLine +

                "FOREIGN KEY(RoleId) REFERENCES[dbo].[Role] ([Id])" + NewLine +
                ");" + NewLine +
                "CREATE TABLE[dbo].[Product]" + NewLine +
                        "(" + NewLine +

                "[Id] INT IDENTITY(1,1) NOT NULL," + NewLine +

                "[UserId] INT NOT NULL," + NewLine +

                "[CategoryId] INT NOT NULL," + NewLine +

                "[LocationId] INT NOT NULL," + NewLine +

                "[StateId] INT NOT NULL," + NewLine +

                "[Name] NVARCHAR(MAX) NOT NULL," + NewLine +


                " [Description]NVARCHAR(MAX) NOT NULL," + NewLine +


                " [Price]DECIMAL NOT NULL," + NewLine +

                "[CreationDate] DATETIME NOT NULL," + NewLine +

                "[LastModifiedDate] DATETIME NOT NULL," + NewLine +

                "PRIMARY KEY CLUSTERED([Id]ASC)," + NewLine +

                "FOREIGN KEY([CategoryId]) REFERENCES[dbo].[Category] ([Id])," + NewLine +

                "FOREIGN KEY([LocationId]) REFERENCES[dbo].[Location] ([Id])," + NewLine +

                "FOREIGN KEY([StateId]) REFERENCES[dbo].[State] ([Id])," + NewLine +

                "FOREIGN KEY([UserId]) REFERENCES[dbo].[User] ([Id])" + NewLine +
                ");" + NewLine +
                "CREATE TABLE[dbo].[Purchase]" + NewLine +
                "(" + NewLine +

                "[Id] INT IDENTITY(1,1) NOT NULL," + NewLine +

                "[ProductId]INT NOT NULL," + NewLine +

                "[SellerId] INT NOT NULL," + NewLine +

                "[CustomerId] INT NOT NULL," + NewLine +

                "[Address] NVARCHAR(100)NOT NULL," + NewLine +


                " [Date]DATETIME NOT NULL," + NewLine +

                "PRIMARY KEY CLUSTERED([Id]ASC)," + NewLine +

                "FOREIGN KEY([SellerId])REFERENCES[dbo].[User] (Id)," + NewLine +

                "FOREIGN KEY([CustomerId])REFERENCES[dbo].[User] (Id)," + NewLine +

                ");";
                var command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
            }
        }

        public void InsertAll()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "USE[UglyExpressShop];" + NewLine +
                "INSERT INTO[dbo].[Category]" + NewLine +
        "([Name]) VALUES('Food')" + NewLine +
"INSERT INTO[dbo].[Category]" + NewLine +
        "([Name]) VALUES('Toys')" + NewLine +
"INSERT INTO[dbo].[Category]" + NewLine +
       "([Name]) VALUES('ForPets')" + NewLine +
"INSERT INTO[dbo].[Category]" + NewLine +
        "([Name]) VALUES('Laptops')" + NewLine +
"INSERT INTO[dbo].[Category]" + NewLine +
        "([Name]) VALUES('Phones')" + NewLine +
"INSERT INTO[dbo].[Category]" + NewLine +
        "([Name]) VALUES('Plants')" + NewLine +
"INSERT INTO[dbo].[Category]" + NewLine +
        "([Name]) VALUES('ForSchool')" + NewLine +
"INSERT INTO[dbo].[Category]" + NewLine +
        "([Name]) VALUES('Cars')" + NewLine +
"INSERT INTO[dbo].[Category]" + NewLine +
        "([Name]) VALUES('Alcohol')" + NewLine +

"INSERT INTO[dbo].[Location]" + NewLine +
        "([Name]) VALUES('Авган')" + NewLine +
"INSERT INTO[dbo].[Location]" + NewLine +
        "([Name]) VALUES('Беларусь')" + NewLine +
"INSERT INTO[dbo].[Location]" + NewLine +
        "([Name]) VALUES('Чечня')" + NewLine +
"INSERT INTO[dbo].[Location]" + NewLine +
        "([Name]) VALUES('США')" + NewLine +
"INSERT INTO[dbo].[Location]" + NewLine +
        "([Name]) VALUES('Украина')" + NewLine +
"INSERT INTO[dbo].[Location]" + NewLine +
        "([Name]) VALUES('Италия')" + NewLine +
"INSERT INTO[dbo].[Location]" + NewLine +
        "([Name]) VALUES('Туркменистан')" + NewLine +
"INSERT INTO[dbo].[Location]" + NewLine +
        "([Name]) VALUES('Азербайджан')" + NewLine +

"INSERT INTO[dbo].[State]" + NewLine +
        "([Name]) VALUES('New')" + NewLine +
"INSERT INTO[dbo].[State]" + NewLine +
        "([Name]) VALUES('Old')" + NewLine +

"INSERT INTO[dbo].[Role]" + NewLine +
        "([Name]) VALUES('User')" + NewLine +
"INSERT INTO[dbo].[Role]" + NewLine +
        "([Name]) VALUES('Moderator')" + NewLine +
"INSERT INTO[dbo].[Role]" + NewLine +
        "([Name]) VALUES('Administrator')" + NewLine +

"INSERT INTO[dbo].[User]" + NewLine +
        "([Login],[RoleId],[Password],[Email],[PhoneNumber]) VALUES('VlastelinValentin',3,'павук','pavyk@gmail.com','+365291725099')" + NewLine +
"INSERT INTO[dbo].[User]" + NewLine +
        "([Login],[RoleId],[Password],[Email],[PhoneNumber]) VALUES('Anatolya',2,'123','anatolik@gmail.com','+365441365099')" + NewLine +
        "INSERT INTO[dbo].[User]" + NewLine +
        "([Login],[RoleId],[Password],[Email],[PhoneNumber]) VALUES('Vadimka12',1,'343221','vadimka@gmail.com','+3653317253467')" + NewLine +
"INSERT INTO[dbo].[User]" + NewLine +
        "([Login],[RoleId],[Password],[Email],[PhoneNumber]) VALUES('Valentinka48',1,'345','valik@gmail.com','+365565625045')" + NewLine +
"INSERT INTO[dbo].[User]" + NewLine +
        "([Login],[RoleId],[Password],[Email],[PhoneNumber]) VALUES('Genka15',1,'1234','genka@gmail.com','+365171479090')" + NewLine +


"INSERT INTO[dbo].[Product]" + NewLine +
        "([CategoryId],[LocationId],[StateId],[UserId],[Name],[Description],[Price],[CreationDate],[LastModifiedDate])" + NewLine +
"VALUES(1,1,1,1,'СЯЛЁДКА','Пожилая сельдь, с озер украины прямо к вам на стол',123, 2019-02-04, 2019-02-04)" + NewLine +
"INSERT INTO[dbo].[Product]" + NewLine +
        "([CategoryId],[LocationId],[StateId],[UserId],[Name],[Description],[Price],[CreationDate],[LastModifiedDate])" + NewLine +
"VALUES(1,1,2,2,'Пожилой Самовар','Дадая, это именно он',123, 2019-02-05, 2019-02-05)" + NewLine +
"INSERT INTO[dbo].[Product]" + NewLine +
        "([CategoryId],[LocationId],[StateId],[UserId],[Name],[Description],[Price],[CreationDate],[LastModifiedDate])" + NewLine +
"VALUES(2,2,1,3,'Тухлый Тунец','Можно ограбить банк при помощи запаха',13, 2019-02-06, 2019-02-06)" + NewLine +
"INSERT INTO[dbo].[Product]" + NewLine +
        "([CategoryId],[LocationId],[StateId],[UserId],[Name],[Description],[Price],[CreationDate],[LastModifiedDate])" + NewLine +
"VALUES(2,3,2,4,'Картошка','Нету смысла писать где выращено',12, 2019-02-07, 2019-02-07)" + NewLine +
"INSERT INTO[dbo].[Product]" + NewLine +
        "([CategoryId],[LocationId],[StateId],[UserId],[Name],[Description],[Price],[CreationDate],[LastModifiedDate])" + NewLine +
"VALUES(2,4,1,5,'Цыбуля','Для дифирент дишс',12, 2019-02-08, 2019-02-08)" + NewLine +
"INSERT INTO[dbo].[Product]" + NewLine +
        "([CategoryId],[LocationId],[StateId],[UserId],[Name],[Description],[Price],[CreationDate],[LastModifiedDate])" + NewLine +
"VALUES(3,5,2,1,'Бурак','Возможны боли в области мозга после употребления',12, 2019-02-09, 2019-02-09)";
                var command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
            }
        }
    }
}
