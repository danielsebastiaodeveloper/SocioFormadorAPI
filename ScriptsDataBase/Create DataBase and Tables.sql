-- Creación de la base de datos
CREATE DATABASE SocioFormadorDB;
USE SocioFormadorDB;

USE SocioFormadorDB;

CREATE TABLE Ciudades (
    Id BIGINT UNSIGNED NOT NULL AUTO_INCREMENT,
    Nombre VARCHAR(100),
    CreatedBy BIGINT UNSIGNED,
    CreatedAt DATETIME,
    PRIMARY KEY (Id)
);

CREATE TABLE Clientes (
    Id BIGINT UNSIGNED NOT NULL AUTO_INCREMENT,
    Nombre VARCHAR(100),
    Apellido VARCHAR(100),
    Email VARCHAR(100),
    CiudadId BIGINT UNSIGNED,
    CreatedBy BIGINT UNSIGNED,
    CreatedAt DATETIME,
    UpdatedBy BIGINT UNSIGNED NULL,
    UpdatedAt DATETIME NULL,
    PRIMARY KEY (Id),
    FOREIGN KEY (CiudadId) REFERENCES Ciudades(Id)
);

CREATE TABLE Pedidos (
    Id BIGINT UNSIGNED NOT NULL AUTO_INCREMENT,
    ClienteId BIGINT UNSIGNED,
    Total DECIMAL(10, 2),
    Cantidad INT,
    CreatedBy BIGINT UNSIGNED,
    CreatedAt DATETIME,
    UpdatedBy BIGINT UNSIGNED NULL,
    UpdatedAt DATETIME NULL,
    PRIMARY KEY (Id),
    FOREIGN KEY (ClienteId) REFERENCES Clientes(Id)
);