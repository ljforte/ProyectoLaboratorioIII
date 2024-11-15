CREATE DATABASE  compumundo_hipermegared;
GO
USE compumundo_hipermegared;
GO
CREATE TABLE  cliente (
    id_cliente INT NOT NULL  IDENTITY PRIMARY KEY,
    nombre VARCHAR(30),
    apellido VARCHAR(30),
    direccion VARCHAR(30),
    provincia VARCHAR(30),
);
GO
CREATE TABLE  impuesto (
    id_impuesto INT NOT NULL  IDENTITY PRIMARY KEY,
    tipo CHAR(1) NOT NULL,
    nombre VARCHAR(30) NOT NULL
);
GO
CREATE TABLE  vendedor (
    id_vendedor INT NOT NULL  IDENTITY PRIMARY KEY,
    nombre VARCHAR(30) NOT NULL,
    apellido VARCHAR(30) NOT NULL,
    comision INT NOT NULL,
    estado INT NOT NULL
);
GO
CREATE TABLE  proveedor (
    id_proveedor INT NOT NULL  IDENTITY PRIMARY KEY,
    nombre VARCHAR(30) NOT NULL,
    direccion VARCHAR(30) NOT NULL,
    provincia VARCHAR(30) NOT NULL,
    pais VARCHAR(30) NOT NULL
);
GO
CREATE TABLE  categoria_producto (
	id_categoria INT NOT NULL  IDENTITY PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL
    );
    GO
CREATE TABLE  producto (
    sku INT NOT NULL  IDENTITY PRIMARY KEY,
    marca VARCHAR(30) NOT NULL,
    modelo VARCHAR(255) NOT NULL,
    id_categoria INT NOT NULL,
    precio INT NOT NULL,
    id_proveedor INT NOT NULL,
    estado INT NOT NULL,
    FOREIGN KEY (id_proveedor) REFERENCES proveedor (id_proveedor),
	FOREIGN KEY (id_categoria) REFERENCES categoria_producto (id_categoria)
);
GO
CREATE TABLE  sitio (
    id_sitio INT NOT NULL  IDENTITY PRIMARY KEY,
    nombre VARCHAR(30) NOT NULL
);
GO
create TABLE  factura (
    id_factura INT NOT NULL  IDENTITY PRIMARY KEY,
    id_impuesto INT NOT NULL,
    id_cliente INT NOT NULL,
    monto INT NOT NULL,
    id_vendedor INT NOT NULL,
    date DATE NOT NULL,
    FOREIGN KEY (id_cliente) REFERENCES cliente (id_cliente),
    FOREIGN KEY (id_impuesto) REFERENCES impuesto (id_impuesto),
    FOREIGN KEY (id_vendedor) REFERENCES vendedor (id_vendedor),
);
GO
CREATE TABLE  stock (
    sku INT NOT NULL,
    id_sitio INT NOT NULL,
    stock INT NOT NULL,
    FOREIGN KEY (sku) REFERENCES producto (sku),
    FOREIGN KEY (id_sitio) REFERENCES sitio (id_sitio)
);
GO
create TABLE  detalle_factura (
    id_compra INT NOT NULL  IDENTITY PRIMARY KEY,
    id_factura INT NOT NULL,
    sku int not NULL,
    precio_unitario int not NULL,
    cantidad int not NULL,
    FOREIGN KEY (sku) REFERENCES producto (sku),
    FOREIGN KEY (id_factura) REFERENCES factura (id_factura)
);
GO
-- Tabla de clientes
INSERT INTO Clientes (Nombre, Apellido, DireccionID)
VALUES 
('Juan', 'P�rez', 1),
('Ana', 'L�pez', 2),
('Pedro', 'Gonz�lez', 3),
('Mar�a', 'Rodr�guez', 4),
('Luis', 'Fern�ndez', 5),
('Laura', 'Mart�nez', 6),
('Carlos', 'S�nchez', 7),
('Isabel', 'Torres', 8),
('Miguel', 'Hern�ndez', 9),
('Sof�a', 'D�az', 10),
('Daniel', 'Chavez', 11),
('Elena', 'G�mez', 12),
('Jos�', 'Vargas', 13),
('Raquel', 'Peralta', 14),
('Francisco', 'Mendoza', 15),
('Carolina', 'Lara', 16),
('Andr�s', 'Castillo', 17),
('Patricia', 'Rojas', 18),
('Roberto', 'P�rez', 19),
('Teresa', 'Silva', 20),
('Javier', 'L�pez', 21),
('Liliana', 'Gonz�lez', 22),
('Arturo', 'Fern�ndez', 23),
('Natalia', 'Mart�nez', 24),
('Manuel', 'S�nchez', 25),
('Beatriz', 'Torres', 26),
('Fernando', 'Hern�ndez', 27),
('Carmen', 'D�az', 28),
('Antonio', 'Chavez', 29),
('Eva', 'G�mez', 30),
('Juan', 'P�rez', 31),
('Mar�a', 'Gonz�lez', 32),
('Pedro', 'Rodr�guez', 33),
('Luc�a', 'Fern�ndez', 34),
('Jorge', 'Garc�a', 35),
('Ana', 'Mart�nez', 36),
('Luis', 'S�nchez', 37),
('Carla', 'D�az', 38),
('Diego', 'Torres', 39),
('Valentina', 'Ruiz', 40),
('Santiago', 'Acosta', 41),
('Camila', 'Romero', 42),
('Facundo', 'Su�rez', 43),
('Agustina', 'L�pez', 44),
('Gustavo', 'G�mez', 45),
('Florencia', 'Castro', 46),
('Ramiro', '�lvarez', 47),
('Micaela', 'Fern�ndez', 48),
('Tom�s', 'Garc�a', 49),
('Luciana', 'D�az', 50),
('Juan', 'P�rez', 51),
('Mar�a', 'Gonz�lez', 52),
('Pedro', 'Rodr�guez', 53),
('Luc�a', 'Fern�ndez', 54),
('Jorge', 'Garc�a', 55),
('Ana', 'Mart�nez', 56),
('Luis', 'S�nchez', 57),
('Carla', 'D�az', 58),
('Diego', 'Torres', 59),
('Valentina', 'Ruiz', 60);


GO
-- Tabla impuesto
INSERT INTO impuesto ( tipo, nombre) VALUES
			('A','RESPONSABLE INSCRIPTO'),
			('B','CONSUMIDOR FINAL'),
			('C','EXENTO');
            GO
-- Tabla vendedor
INSERT INTO vendedor ( nombre, apellido, comision, estado) VALUES
			('Diego Armando','Maradona',2,1),
			('Lionel Andres','Messi',1,1),
			('Mario Alberto','Kempes',2,0),
			('Gabriel Omar','Batistuta',2,1),
			('Leo','Matiolli',0,0);
            GO
-- Tabla de proveedores
INSERT INTO proveedor (nombre, direccion, provincia, pais) VALUES
			( 'HardwareTech', '123 Hardware Street', 'Buenos Aires', 'Argentina'),
			( 'TechPro', '456 Tech Avenue', 'C�rdoba', 'Argentina'),
			( 'GadgetWorld', '789 Gadget Lane', 'Ciudad de Buenos Aires', 'Argentina'),
			( 'ElectroSupplies', '1 Electronics Road', 'Mendoza', 'Argentina'),
			( 'ComponentX', '42 Hardware Avenue', 'San Juan', 'Argentina'),
			( 'DataSolutions', '88 Tech Plaza', 'Tucum�n', 'Argentina'),
			( 'TechGurus', '555 Tech Boulevard', 'Rosario', 'Argentina'),
			( 'InnovativeTech', '333 Innovation Street', 'Salta', 'Argentina'),
			( 'HardwarePlus', '777 Hardware Drive', 'Misiones', 'Argentina'),
			( 'ConnectIT', '22 Connection Road', 'San Luis', 'Argentina');
            GO
-- Tabla categoria/Categorias.
INSERT INTO categoria_producto ( nombre) VALUES
			( 'Memorias RAM'),
			( 'Procesadores'),
			( 'Tarjetas gr�ficas'),
			( 'Discos duros SSD'),
			( 'Discos duros HDD'),
			( 'Placas madre'),
			( 'Monitores'),
			( 'Teclados'),
			( 'Mouses'),
			( 'Auriculares'),
			( 'Micr�fonos'),
			( 'Webcams'),
			( 'Sillas gaming'),
			( 'Escritorios gaming'),
			( 'Alfombrillas para mouse'),
			( 'Cables HDMI'),
			( 'Cables VGA'),
			( 'Cables de alimentaci�n'),
			( 'Cables USB'),
			( 'Cables de red'),
			( 'Adaptadores de corriente'),
			( 'Ventiladores para PC'),
			( 'Fuentes de alimentaci�n'),
			( 'Cajas de PC'),
			( 'Lectores de tarjetas'),
			( 'Unidades �pticas'),
			( 'Altavoces'),
			( 'Impresoras'),
			( 'Scanners'),
			( 'Proyectores');
			GO
-- Tabla de productos
INSERT INTO producto (marca, modelo, id_categoria, precio, id_proveedor, estado) VALUES
			('Intel', 'Core i9-11900K', 2, 599, 1, 1),
			('AMD', 'Ryzen 5 5600X', 2, 299, 2, 1),
			('Nvidia', 'GeForce RTX 3060 Ti', 3, 399, 3, 1),
			('Gigabyte', 'AORUS GeForce RTX 3080 Ti', 3, 1499, 4, 1),
			('Corsair', 'RM850x', 7, 139, 5, 1),
			('EVGA', 'SuperNOVA 750 G5', 7, 129, 6, 1),
			('Asus', 'ROG Strix B450-F', 6, 129, 7, 1),
			('G.Skill', 'Ripjaws V', 1, 59, 8, 1),
			('Kingston', 'A2000', 4, 79, 9, 1),
			('Samsung', '860 EVO', 4, 99, 10, 1),
			('Seagate', 'FireCuda 520', 4, 199, 1, 1),
			('Western Digital', 'Black SN750', 4, 149, 2, 1),
			('Asus', 'TUF Gaming X570-PRO', 6, 219, 3, 1),
			('Gigabyte', 'B450M DS3H', 6, 79, 4, 1),
			('MSI', 'B450 TOMAHAWK MAX', 6, 129, 5, 1),
			('LG', '27GL83A-B', 7, 379, 6, 1),
			('Dell', 'S2721DGF', 7, 449, 7, 1),
			('Logitech', 'G Pro X', 9, 129, 8, 1),
			('HyperX', 'Cloud II', 10, 99, 9, 1),
			('Corsair', 'Vengeance RGB Pro', 1, 149, 1, 1),
			('Corsair', 'Vengeance LPX', 1, 79, 2, 1),
			('G.Skill', 'Trident Z5 RGB Series', 1, 119, 3, 1),
			('Crucial', 'Ballistix', 1, 99, 4, 1),
			('Kingston', 'HyperX Fury', 1, 89, 5, 1),
			('Patriot', 'Viper Steel', 1, 69, 6, 1),
			('Samsung', '970 EVO Plus', 4, 129, 7, 1),
			('Samsung', '870 QVO', 4, 89, 8, 1),
			('Western Digital', 'WD Blue', 5, 49, 9, 1),
			('Seagate', 'IronWolf', 5, 89, 10, 1),
			('Asus', 'ROG Strix X570-E', 6, 329, 1, 1),
			('Asus', 'ROG Strix B550-F', 6, 199, 2, 1),
			('Gigabyte', 'AORUS GeForce RTX 3080', 3, 899, 3, 1),
			('Nvidia', 'GeForce RTX 3070', 3, 499, 4, 1),
			('AMD', 'Radeon RX 6800 XT', 3, 649, 5, 1),
			('Gigabyte', 'AORUS GeForce RTX 3070', 3, 749, 6, 1),
			('Nvidia', 'GeForce GTX 1660', 3, 229, 7, 1),
			('Gigabyte', 'GeForce GTX 1650', 3, 169, 8, 1),
			('AMD', 'Ryzen 9 5900X', 2, 480, 9, 0),
			('Intel', 'Core i9-12900K', 2, 605, 10, 1),
			('Intel', 'Core i7-11700K', 2, 399, 1, 1),
			('Intel', 'Core i5-11600K', 2, 269, 2, 1),
			('AMD', 'Ryzen 7 5800X', 2, 399, 3, 1),
			('AMD', 'Radeon RX 6900 XT', 3, 999, 4, 1),
			('AMD', 'Radeon RX 6700 XT', 3, 479, 5, 1),
			('Crucial', 'MX500', 4, 69, 6, 1),
			('Samsung', '980 PRO', 4, 149, 7, 1),
			('Seagate', 'BarraCuda', 5, 59, 8, 1),
			('Western Digital', 'WD Black', 5, 139, 9, 1),
			('Seagate', 'Backup Plus Slim', 5, 59, 10, 1),
			('Asus', 'TUF Gaming B550M-PLUS', 6, 159, 1, 1);
-- Tabla sitio/lugares
GO
INSERT INTO sitio (nombre) VALUES
			('Deposito'),
			('Salon'),
			('Baulera'),
			('Sector ACcesorios'),
			('Devoluciones');
-- Tabla stock
GO
INSERT INTO stock (sku, id_sitio, stock) VALUES
            (20, 2, 19),
            (20, 1, 10),
            (21, 1, 15),
            (22, 1, 5),
            (22, 1, 20),
            (24, 1, 0),
            (25, 1, 10),
            (26, 2, 15),
            (27, 2, 20),
            (28, 2, 5),
            (29, 2, 0),
            (30, 2, 10),
            (32, 3, 15),
            (32, 3, 20),
            (33, 3, 5),
            (34, 3, 10),
            (35, 3, 1),
            (36, 4, 10),
            (37, 4, 15),
            (38, 4, 5),
            (39, 4, 20),
            (40, 4, 1),
            (41, 5, 10),
            (41, 2, 15),
            (41, 1, 5),
            (44, 1, 20),
            (45, 1, 0),
            (46, 1, 10),
            (47, 1, 15),
            (48, 1, 5),
            (50, 3, 20),
            (50, 1, 0);
            GO
INSERT INTO factura (id_impuesto, id_cliente, monto, id_vendedor, date)
VALUES
    ( 1, 1, 1695, 1, '2023-09-25'),
    ( 2, 2, 897, 2, '2023-09-26'),
    ( 3, 3, 318, 3, '2023-09-27'),
    ( 1, 22, 447, 4, '2023-09-28'),
    ( 2, 25, 2055, 5, '2023-09-29'),
    ( 3, 27, 690, 1, '2023-09-30'),
    ( 1, 1, 129, 1, '2023-09-25');
    GO
INSERT into detalle_factura (id_factura, sku, precio_unitario, cantidad) VALUES 
(1, 2, 299, 3),
(1,3,399,2),
(2, 2, 299, 3),
(3,50,159,2),
(4, 20, 149, 3),
(5,15,129,2),
(5, 1, 599, 3),
(6,25,69,10),
(7, 7, 129, 1);
GO

CREATE TABLE Provincias (
    ProvinciaID INT PRIMARY KEY,
    Nombre NVARCHAR(50) NOT NULL
);
GO

CREATE TABLE direccion (
    direccionID INT PRIMARY KEY,
    Calle NVARCHAR(50) NOT NULL,
    Codigo_postal int not NULL,
    Ciudad NVARCHAR(50) NOT NULL
    ProvinciaID int not NULL
    FOREIGN KEY (ProvinciaID) REFERENCES Provincias(ProvinciaID)
);
GO

INSERT INTO direccion (Calle, Codigo_postal, Ciudad, ProvinciaID) 
VALUES
('Calle 123', 1648, 'Tigre', 1),
('Avenida 456', 1646, 'San Fernando', 1),
('Calle Principal', 1642, 'San Isidro', 1),
('Calle Secundaria', 1832, 'Lomas de Zamora', 1),
('Avenida Central', 1824, 'Avellaneda', 1),
('Calle 789', 1702, 'Lan�s', 1),
('Calle de la Rosa', 1706, 'Quilmes', 1),
('Avenida del Sol', 1870, 'Vicente L�pez', 1),
('Calle de la Luna', 1708, 'Berazategui', 1),
('Avenida del R�o', 1640, 'Tigre', 1),
('Calle de la Monta�a', 1644, 'San Fernando', 1),
('Avenida del Mar', 1646, 'San Isidro', 1),
('Calle de la Playa', 1834, 'Lomas de Zamora', 1),
('Avenida de la Selva', 1872, 'Avellaneda', 1),
('Calle del Viento', 1704, 'Lan�s', 1),
('Avenida del Fuego', 1706, 'Quilmes', 1),
('Calle de la Nube', 1870, 'Vicente L�pez', 1),
('Avenida de las Estrellas', 1708, 'Berazategui', 1),
('Calle del Bosque', 1648, 'Tigre', 1),
('Avenida del Cielo', 1646, 'San Fernando', 1),
('Calle del Mar', 1642, 'San Isidro', 1),
('Avenida del Oc�ano', 1832, 'Lomas de Zamora', 1),
('Calle de la Monta�a', 1824, 'Avellaneda', 1),
('Avenida del Sol', 1702, 'Lan�s', 1),
('Calle de la Luna', 1706, 'Quilmes', 1),
('Avenida del R�o', 1870, 'Vicente L�pez', 1),
('Calle 9 de Julio', 1640, 'Tigre', 1),
('Avenida Corrientes', 1644, 'San Fernando', 1),
('Calle San Mart�n', 1646, 'San Isidro', 1),
('Avenida Belgrano', 1832, 'Lomas de Zamora', 1),
('Calle Mitre', 1872, 'Avellaneda', 1),
('Avenida Pellegrini', 1704, 'Lan�s', 1),
('Calle 25 de Mayo', 1706, 'Quilmes', 1),
('Avenida Sarmiento', 1870, 'Vicente L�pez', 1),
('Calle San Lorenzo', 1708, 'Berazategui', 1),
('Avenida San Mart�n', 1648, 'Tigre', 1),
('Calle Florida', 1646, 'San Fernando', 1),
('Avenida V�lez Sarsfield', 1642, 'San Isidro', 1),
('Calle San Juan', 1832, 'Lomas de Zamora', 1),
('Avenida San Mart�n', 1824, 'Avellaneda', 1),
('Calle 24 de Septiembre', 1702, 'Lan�s', 1),
('Avenida Freyre', 1706, 'Quilmes', 1),
('Calle 25 de Mayo', 1870, 'Vicente L�pez', 1),
('Avenida 9 de Julio', 1708, 'Berazategui', 1),
('Calle San Juan', 1648, 'Tigre', 1),
('Avenida San Mart�n', 1646, 'San Fernando', 1);


GO

INSERT INTO Provincias (ProvinciaID, Nombre)
VALUES 
(1, 'Buenos Aires'),
(2, 'Catamarca'),
(3, 'Chaco'),
(4, 'Chubut'),
(5, 'C�rdoba'),
(6, 'Corrientes'),
(7, 'Entre R�os'),
(8, 'Formosa'),
(9, 'Jujuy'),
(10, 'La Pampa'),
(11, 'La Rioja'),
(12, 'Mendoza'),
(13, 'Misiones'),
(14, 'Neuqu�n'),
(15, 'R�o Negro'),
(16, 'Salta'),
(17, 'San Juan'),
(18, 'San Luis'),
(19, 'Santa Cruz'),
(20, 'Santa Fe'),
(21, 'Santiago del Estero'),
(22, 'Tierra del Fuego'),
(23, 'Tucum�n');