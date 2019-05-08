USE[UglyExpressShop];
INSERT INTO [dbo].[Category]([Name]) VALUES('Food')
INSERT INTO [dbo].[Category]([Name]) VALUES('Toys')
INSERT INTO [dbo].[Category]([Name]) VALUES('ForPets')
INSERT INTO [dbo].[Category]([Name]) VALUES('Laptops')
INSERT INTO [dbo].[Category]([Name]) VALUES('Phones')
INSERT INTO [dbo].[Category]([Name]) VALUES('Plants')
INSERT INTO [dbo].[Category]([Name]) VALUES('ForSchool')
INSERT INTO [dbo].[Category]([Name]) VALUES('Cars')
INSERT INTO [dbo].[Category]([Name]) VALUES('Alcohol')

INSERT INTO [dbo].[Location]([Name]) VALUES('Авган')
INSERT INTO [dbo].[Location]([Name]) VALUES('Беларусь')
INSERT INTO [dbo].[Location]([Name]) VALUES('Чечня')
INSERT INTO [dbo].[Location]([Name]) VALUES('США')
INSERT INTO [dbo].[Location]([Name]) VALUES('Украина')
INSERT INTO [dbo].[Location]([Name]) VALUES('Италия')
INSERT INTO [dbo].[Location]([Name]) VALUES('Туркменистан')
INSERT INTO [dbo].[Location]([Name]) VALUES('Азербайджан')

INSERT INTO [dbo].[State]([Name]) VALUES('New')
INSERT INTO [dbo].[State]([Name]) VALUES('Old')

INSERT INTO [dbo].[Role]([Name]) VALUES ('User')
INSERT INTO [dbo].[Role]([Name]) VALUES ('Moderator')
INSERT INTO [dbo].[Role]([Name]) VALUES ('Administrator')

INSERT INTO [dbo].[User]([Login],[RoleId],[Password],[Email],[PhoneNumber]) VALUES('VlastelinValentin',3,'павук','pavyk@gmail.com','+365291725099')
INSERT INTO [dbo].[User]([Login],[RoleId],[Password],[Email],[PhoneNumber]) VALUES('Anatolya',2,'123','anatolik@gmail.com','+365441365099')
INSERT INTO [dbo].[User]([Login],[RoleId],[Password],[Email],[PhoneNumber]) VALUES('Vadimka12',1,'343221','vadimka@gmail.com','+3653317253467')
INSERT INTO [dbo].[User]([Login],[RoleId],[Password],[Email],[PhoneNumber]) VALUES('Valentinka48',1,'345','valik@gmail.com','+365565625045')
INSERT INTO [dbo].[User]([Login],[RoleId],[Password],[Email],[PhoneNumber]) VALUES('Genka15',1,'1234','genka@gmail.com','+365171479090')


INSERT INTO [dbo].[Product]([CategoryId],[LocationId],[StateId],[UserId],[Name],[Description],[Price],[CreationDate],[LastModifiedDate],[IsArchive])
VALUES(1,1,1,1,'СЯЛЁДКА','Пожилая сельдь, с озер украины прямо к вам на стол',123, 2019-02-04, 2019-02-04, 0)
INSERT INTO [dbo].[Product]([CategoryId],[LocationId],[StateId],[UserId],[Name],[Description],[Price],[CreationDate],[LastModifiedDate],[IsArchive])
VALUES(1,1,2,2,'Пожилой Самовар','Дадая, это именно он',123, 2019-02-05, 2019-02-05, 0)
INSERT INTO [dbo].[Product]([CategoryId],[LocationId],[StateId],[UserId],[Name],[Description],[Price],[CreationDate],[LastModifiedDate],[IsArchive]
VALUES(2,2,1,3,'Тухлый Тунец','Можно ограбить банк при помощи запаха',13, 2019-02-06, 2019-02-06, 0)
INSERT INTO [dbo].[Product]([CategoryId],[LocationId],[StateId],[UserId],[Name],[Description],[Price],[CreationDate],[LastModifiedDate],[IsArchive]
VALUES(2,3,2,4,'Картошка','Нету смысла писать где выращено',12, 2019-02-07, 2019-02-07, 0)
INSERT INTO [dbo].[Product]([CategoryId],[LocationId],[StateId],[UserId],[Name],[Description],[Price],[CreationDate],[LastModifiedDate],[IsArchive]
VALUES(2,4,1,5,'Цыбуля','Для дифирент дишс',12, 2019-02-08, 2019-02-08, 0)
INSERT INTO [dbo].[Product]([CategoryId],[LocationId],[StateId],[UserId],[Name],[Description],[Price],[CreationDate],[LastModifiedDate],[IsArchive]
VALUES(3,5,2,1,'Бурак','Возможны боли в области мозга после употребления',12, 2019-02-09, 2019-02-09, 0)
INSERT INTO [dbo].[Product]([CategoryId],[LocationId],[StateId],[UserId],[Name],[Description],[Price],[CreationDate],[LastModifiedDate],[IsArchive]
VALUES(2,1,2,2,'Небесный бульон','На вкус как облочко',12, 2019-02-09, 2019-02-09, 0)
INSERT INTO [dbo].[Product]([CategoryId],[LocationId],[StateId],[UserId],[Name],[Description],[Price],[CreationDate],[LastModifiedDate],[IsArchive]
VALUES(1,1,1,3,'Бульба','Гэта супер класс',12, 2019-02-09, 2019-02-09, 0)