CREATE DATABASE Compumundo_hipermegared;
GO

USE Compumundo_hipermegared;
GO

CREATE TABLE Provincias (
    ProvinciaID INT PRIMARY KEY,
    Nombre NVARCHAR(50) NOT NULL
);
GO

CREATE TABLE direccion (
    direccionID INT PRIMARY KEY,
    Calle NVARCHAR(50) NOT NULL,
    Codigo_postal INT NOT NULL,
    Ciudad NVARCHAR(50) NOT NULL,
    ProvinciaID INT NOT NULL,
    FOREIGN KEY (ProvinciaID) REFERENCES Provincias(ProvinciaID)
);
GO

CREATE TABLE cliente (
    id_cliente INT NOT NULL IDENTITY PRIMARY KEY,
    nombre VARCHAR(30),
    apellido VARCHAR(30),
    DireccionID INT,
    FOREIGN KEY (DireccionID) REFERENCES direccion(direccionID)
);
GO

CREATE TABLE impuesto (
    id_impuesto INT NOT NULL IDENTITY PRIMARY KEY,
    tipo CHAR(1) NOT NULL,
    nombre VARCHAR(30) NOT NULL
);
GO

CREATE TABLE vendedor (
    id_vendedor INT NOT NULL IDENTITY PRIMARY KEY,
    nombre VARCHAR(30) NOT NULL,
    apellido VARCHAR(30) NOT NULL,
    comision INT NOT NULL,
    estado INT NOT NULL
);
GO

CREATE TABLE sitio (
    id_sitio INT NOT NULL IDENTITY PRIMARY KEY,
    nombre VARCHAR(30) NOT NULL
);
GO

CREATE TABLE proveedor (
    id_proveedor INT NOT NULL IDENTITY PRIMARY KEY,
    nombre VARCHAR(50),
    direccionID INT NOT NULL,
    FOREIGN KEY (direccionID) REFERENCES direccion(direccionID)
);
GO

CREATE TABLE categorias (
    idCategoria INT NOT NULL IDENTITY PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL UNIQUE
);
GO

CREATE TABLE marcas (
    idMarca INT NOT NULL IDENTITY PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL UNIQUE
);
GO

CREATE TABLE Articulos (
    id INT NOT NULL IDENTITY PRIMARY KEY,
    codigo VARCHAR(50) UNIQUE NOT NULL,
    nombre VARCHAR(255) NOT NULL,
    Descripcion VARCHAR(255) NOT NULL,
    idMarca INT NOT NULL,
    idCategoria INT NOT NULL,
    precio INT NOT NULL,
    id_proveedor INT DEFAULT 1,
    estado BIT NOT NULL,
    FOREIGN KEY (id_proveedor) REFERENCES proveedor(id_proveedor),
    FOREIGN KEY (idCategoria) REFERENCES categorias(idCategoria),
    FOREIGN KEY (idMarca) REFERENCES marcas(idMarca)
);
GO

CREATE TABLE factura (
    id_factura INT NOT NULL IDENTITY PRIMARY KEY,
    id_impuesto INT NOT NULL,
    id_cliente INT NOT NULL,
    monto INT NOT NULL,
    id_vendedor INT NOT NULL,
    date DATE NOT NULL,
    FOREIGN KEY (id_cliente) REFERENCES cliente(id_cliente),
    FOREIGN KEY (id_impuesto) REFERENCES impuesto(id_impuesto),
    FOREIGN KEY (id_vendedor) REFERENCES vendedor(id_vendedor)
);
GO

CREATE TABLE detalle_factura (
    id_compra INT NOT NULL IDENTITY PRIMARY KEY,
    id_factura INT NOT NULL,
    id_articulo INT NOT NULL,
    precio_unitario INT NOT NULL,
    cantidad INT NOT NULL,
    FOREIGN KEY (id_articulo) REFERENCES Articulos(id),
    FOREIGN KEY (id_factura) REFERENCES factura(id_factura)
);
GO

CREATE TABLE IMAGENES (
    Id INT NOT NULL IDENTITY PRIMARY KEY,
    IdArticulo INT,
    ImagenUrl VARCHAR(255),
    FOREIGN KEY (IdArticulo) REFERENCES Articulos(id)
);
GO

CREATE TABLE stock (
    id INT NOT NULL IDENTITY PRIMARY KEY,
    id_producto INT NOT NULL,
    id_sitio INT NOT NULL,
    stock INT NOT NULL,
    FOREIGN KEY (id_sitio) REFERENCES sitio(id_sitio),
    FOREIGN KEY (id_producto) REFERENCES Articulos(id)
);
GO
