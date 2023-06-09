-- Creación de la base de datos
CREATE DATABASE IF NOT EXISTS SocioFormadorDB;
USE SocioFormadorDB;

CREATE TABLE IF NOT EXISTS Ciudades (
    Id BIGINT UNSIGNED NOT NULL AUTO_INCREMENT,
    Nombre VARCHAR(100),
    CreatedBy BIGINT UNSIGNED,
    CreatedAt DATETIME,
    PRIMARY KEY (Id)
);

CREATE TABLE IF NOT EXISTS Clientes (
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

CREATE TABLE IF NOT EXISTS Pedidos (
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

INSERT INTO CIUDADES (Nombre, CreatedBy, CreatedAt) VALUES ('Ciudad de Mexico', 1 , NOW());
INSERT INTO CIUDADES (Nombre, CreatedBy, CreatedAt) VALUES ('Monterrey', 1 , NOW());