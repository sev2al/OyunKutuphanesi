-- Veritabanı oluşturma (eğer yoksa)
IF NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = 'Oyun')
BEGIN
    CREATE DATABASE Oyun;
END
GO

USE Oyun;
GO

-- Kullanıcılar tablosunu oluşturma
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Kullanicilar' AND xtype='U')
BEGIN
    CREATE TABLE Kullanicilar (
        KullaniciID INT PRIMARY KEY IDENTITY(1,1),
        KullaniciAdi NVARCHAR(50) NOT NULL UNIQUE,
        Sifre NVARCHAR(50) NOT NULL,
        Email NVARCHAR(100) NOT NULL,
        Adi NVARCHAR(50) NOT NULL,
        Soyadi NVARCHAR(50) NOT NULL,
        KayitTarihi DATETIME NOT NULL DEFAULT GETDATE(),
        SonGirisTarihi DATETIME NULL
    );
END
GO

-- Örnek kullanıcı ekleme (Test için)
IF NOT EXISTS (SELECT * FROM Kullanicilar WHERE KullaniciAdi = 'admin')
BEGIN
    INSERT INTO Kullanicilar (KullaniciAdi, Sifre, Email, Adi, Soyadi)
    VALUES ('admin', 'admin123', 'admin@oyunkutuphanesi.com', 'Admin', 'Kullanıcı');
END
GO 