USE master;
GO

CREATE DATABASE InmuebleDB ON
(NAME = Sales_dat,
    FILENAME = 'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\inmuebledat.mdf',
    SIZE = 10,
    MAXSIZE = 50,
    FILEGROWTH = 5)
LOG ON
(NAME = Sales_log,
    FILENAME = 'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\inmueblelog.ldf',
    SIZE = 5 MB,
    MAXSIZE = 25 MB,
    FILEGROWTH = 5 MB);
GO

USE InmuebleDB
go
-- Tabla para almacenar información sobre los tipos de inmuebles
CREATE TABLE TipoInmueble (
    TipoInmuebleID INT PRIMARY KEY,
    Descripcion VARCHAR(200)
);

-- Tabla para almacenar información sobre los inmuebles
CREATE TABLE Inmueble (
    InmuebleID INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100),
	TipoInmuebleID INT,
    Descripcion VARCHAR(500),
    Direccion VARCHAR(255),
    Ciudad VARCHAR(100),
    Pais NVARCHAR(100),
    Precio MONEY,
    NumeroHabitaciones INT,
    NumeroBanos INT,
    AreaMetrosCuadrados DECIMAL(10, 2),
    AnioConstruccion INT,
	FOREIGN KEY (TipoInmuebleID) REFERENCES TipoInmueble(TipoInmuebleID),
);

INSERT INTO TipoInmueble (TipoInmuebleID, Descripcion) VALUES (1, 'Casa');
INSERT INTO TipoInmueble (TipoInmuebleID, Descripcion) VALUES (2, 'Departamento');
INSERT INTO TipoInmueble (TipoInmuebleID, Descripcion) VALUES (3, 'Oficina');


INSERT INTO Inmueble (Nombre, TipoInmuebleID, Descripcion, Direccion, Ciudad, Pais,  Precio, NumeroHabitaciones, NumeroBanos, AreaMetrosCuadrados, AnioConstruccion) VALUES ( 'Casa en la playa', 1, 'Hermosa casa frente al mar', 'Av. Costaverde Pucusana', 'Lima', 'Peru', 500000, 3, 2, 200, 10);
INSERT INTO Inmueble ( Nombre, TipoInmuebleID, Descripcion, Direccion, Ciudad, Pais,  Precio, NumeroHabitaciones, NumeroBanos, AreaMetrosCuadrados, AnioConstruccion) VALUES ( 'Departamento frente al Golf', 2, 'Hermoso departamento frente al Golf los Incas', 'Av. El Golf', 'Lima', 'Peru', 1200000, 5, 3, 350, 3);
INSERT INTO Inmueble ( Nombre, TipoInmuebleID, Descripcion, Direccion, Ciudad, Pais,  Precio, NumeroHabitaciones, NumeroBanos, AreaMetrosCuadrados, AnioConstruccion) VALUES ( 'Oficina New Horizont', 3, 'Hermoso oficina ubicada en Miraflores', 'Av. Pardo 320', 'Lima', 'Peru', 3000000, 5, 5, 350, 5);