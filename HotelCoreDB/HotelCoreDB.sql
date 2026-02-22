CREATE DATABASE HotelCoreDB;
GO
USE HotelCoreDB;
GO

CREATE TABLE Cliente (
    ID_Cliente INT IDENTITY PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Documento_Identidad VARCHAR(20) NOT NULL UNIQUE,
    Correo VARCHAR(100) NOT NULL UNIQUE,
    Telefono VARCHAR(20)
);

CREATE TABLE Usuario (
    ID_Usuario INT IDENTITY PRIMARY KEY,
    Nombre_Usuario VARCHAR(50) NOT NULL UNIQUE,
    Password VARCHAR(255) NOT NULL,
    Rol VARCHAR(20) NOT NULL, -- Agregado para Casos de Uso (Admin/Recepcionista)
    Estado BIT NOT NULL
);

CREATE TABLE Categoria_Habitacion (
    ID_Categoria INT IDENTITY PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL,
    Descripcion VARCHAR(150),
    Capacidad_Max INT NOT NULL,
    Precio_Base DECIMAL(10,2) NOT NULL
);

CREATE TABLE Habitacion (
    ID_Habitacion INT IDENTITY PRIMARY KEY,
    Numero VARCHAR(10) NOT NULL UNIQUE,
    ID_Categoria INT NOT NULL,
    Estado VARCHAR(20) NOT NULL,
    Planta INT NOT NULL,
    CONSTRAINT FK_Habitacion_Categoria FOREIGN KEY (ID_Categoria) REFERENCES Categoria_Habitacion(ID_Categoria)
);

CREATE TABLE Tarifa (
    ID_Tarifa INT IDENTITY PRIMARY KEY,
    ID_Categoria INT NOT NULL,
    Temporada VARCHAR(50) NOT NULL,
    Precio DECIMAL(10,2) NOT NULL,
    Fecha_Vigencia DATE NOT NULL,
    CONSTRAINT FK_Tarifa_Categoria FOREIGN KEY (ID_Categoria) REFERENCES Categoria_Habitacion(ID_Categoria)
);

CREATE TABLE Reserva (
    ID_Reserva INT IDENTITY PRIMARY KEY,
    ID_Cliente INT NOT NULL,
    ID_Habitacion INT NOT NULL,
    Estado VARCHAR(20) NOT NULL,
    Fecha_Inicio DATE NOT NULL,
    Fecha_Fin DATE NOT NULL,
    CONSTRAINT FK_Reserva_Cliente FOREIGN KEY (ID_Cliente) REFERENCES Cliente(ID_Cliente),
    CONSTRAINT FK_Reserva_Habitacion FOREIGN KEY (ID_Habitacion) REFERENCES Habitacion(ID_Habitacion)
);

CREATE TABLE Servicio_Adicional (
    ID_Servicio INT IDENTITY PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Descripcion VARCHAR(150),
    Precio_Unitario DECIMAL(10,2) NOT NULL,
    Activo BIT NOT NULL
);

CREATE TABLE Reserva_Servicio (
    ID_Reserva_Servicio INT IDENTITY PRIMARY KEY,
    ID_Reserva INT NOT NULL,
    ID_Servicio INT NOT NULL,
    Cantidad INT NOT NULL,
    Subtotal DECIMAL(10,2) NOT NULL,
    CONSTRAINT FK_RS_Reserva FOREIGN KEY (ID_Reserva) REFERENCES Reserva(ID_Reserva),
    CONSTRAINT FK_RS_Servicio FOREIGN KEY (ID_Servicio) REFERENCES Servicio_Adicional(ID_Servicio)
);

CREATE TABLE Auditoria (
    ID_Auditoria INT IDENTITY PRIMARY KEY,
    ID_Usuario INT NOT NULL,
    Accion_Realizada VARCHAR(100) NOT NULL,
    Fecha_Hora DATETIME NOT NULL DEFAULT GETDATE(),
    Detalle_Operacion VARCHAR(255),
    CONSTRAINT FK_Auditoria_Usuario FOREIGN KEY (ID_Usuario) REFERENCES Usuario(ID_Usuario)
);







ALTER TABLE Reserva ADD CONSTRAINT CK_Reserva_Fechas CHECK (Fecha_Fin > Fecha_Inicio);
ALTER TABLE Reserva_Servicio ADD CONSTRAINT CK_RS_Cantidad CHECK (Cantidad > 0);
ALTER TABLE Tarifa ADD CONSTRAINT CK_Tarifa_Precio CHECK (Precio > 0);

CREATE INDEX IDX_Reserva_Fecha ON Reserva (Fecha_Inicio, Fecha_Fin);
CREATE INDEX IDX_Habitacion_Estado ON Habitacion (Estado);