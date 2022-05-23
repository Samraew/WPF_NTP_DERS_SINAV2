CREATE DATABASE VT2022_sinav2
GO
USE VT2022_sinav2
GO
CREATE TABLE [dbo].[Kisi]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ad] VARCHAR(50) NULL, 
    [soyad] VARCHAR(50) NULL, 
    [tel] NCHAR(11) NULL, 
    [mail] VARCHAR(50) NULL, 
    [adres] VARCHAR(MAX) NULL,
    [tur] INT DEFAULT 1
)

CREATE TABLE [dbo].[Kisitur]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [tur] VARCHAR(50) NOT NULL
)

CREATE TABLE [dbo].[Hizmet]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [hizmetad] VARCHAR(50) NULL, 
    [fiyat] INT NULL
)

CREATE TABLE [dbo].[Islem]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [hizmet] INT NOT NULL, 
    [musteri] INT NOT NULL,
    [personel] INT NOT NULL,
    [tarih] VARCHAR(10) NOT NULL,
    [odeme] BIT DEFAULT 0
)

ALTER TABLE [dbo].[Kisi]
ADD CONSTRAINT [FK_Kisi_Tur] FOREIGN KEY ([tur]) REFERENCES [Kisitur]([Id])

ALTER TABLE [dbo].[Islem]
ADD CONSTRAINT [FK_Islem_Hizmet] FOREIGN KEY ([hizmet]) REFERENCES [Hizmet]([Id])

ALTER TABLE [dbo].[Islem]
ADD CONSTRAINT [FK_Islem_Musteri] FOREIGN KEY ([musteri]) REFERENCES [Kisi]([Id])

ALTER TABLE [dbo].[Islem]
ADD CONSTRAINT [FK_Islem_Personel] FOREIGN KEY ([personel]) REFERENCES [Kisi]([Id])

USE VT2022_sinav2
GO
INSERT INTO [Kisitur](tur) VALUES 
    ('Musteri'),
    ('Personel')

INSERT INTO [Hizmet](hizmetad,fiyat) VALUES 
    ('Hafif Temizlik',100),
    ('Normal Temizlik',200),
    ('Ağir Temizlik',300)

INSERT INTO [Kisi](ad,soyad,tel,mail,adres,tur) VALUES 
    ('mad1','msoyad1','5051234560','mail1','adres1',1),
    ('mad2','msoyad2','5051234561','mail2','adres2',1),
    ('pad3','psoyad3','5051234562','mail3','adres3',2),
    ('pad4','psoyad4','5051234563','mail4','adres4',2)

INSERT INTO Islem(hizmet,musteri,personel,tarih,odeme) VALUES 
    (1,1,3,'20.04.2022',0),
    (1,2,4,'21.04.2022',0),
    (2,2,4,'22.04.2022',0),
    (2,1,3,'23.04.2022',1),
    (3,2,3,'24.04.2022',0),
    (3,1,4,'25.04.2022',1)
    