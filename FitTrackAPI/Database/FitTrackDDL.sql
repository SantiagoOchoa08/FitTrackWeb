CREATE DATABASE FitTrackDB;
GO
USE FitTrackDB;

CREATE TABLE Usuarios (
    Id INT PRIMARY KEY IDENTITY,
    Nombre NVARCHAR(100),
    Correo NVARCHAR(100),
    Password NVARCHAR(100)
);

CREATE TABLE Ejercicios (
    Id INT PRIMARY KEY IDENTITY,
    Nombre NVARCHAR(100),
    GrupoMuscular NVARCHAR(100),
    Descripcion NVARCHAR(200),
    DuracionSegundos INT,
    CaloriasEstimadas FLOAT
);

CREATE TABLE Rutinas (
    Id INT PRIMARY KEY IDENTITY,
    Nombre NVARCHAR(100),
    Descripcion NVARCHAR(200)
);

CREATE TABLE Progresos (
    Id INT PRIMARY KEY IDENTITY,
    UsuarioId INT,
    Fecha DATE,
    Peso FLOAT,
    FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id)
);
