CREATE DATABASE Kutuphane;

USE Kutuphane;

CREATE TABLE Yazar(
	ID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Isim VARCHAR(MAX) NOT NULL
)

CREATE TABLE Kitap(
	ID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Isim VARCHAR(MAX) NOT NULL,
	Sayfa INT NOT NULL,
	YazarID INT NOT NULL
	FOREIGN KEY (YazarID) REFERENCES Yazar(ID)
)

