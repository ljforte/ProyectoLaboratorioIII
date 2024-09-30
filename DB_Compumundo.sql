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
    pais VARCHAR(30)
);
CREATE TABLE  impuesto (
    id_impuesto INT NOT NULL  IDENTITY PRIMARY KEY,
    tipo CHAR(1) NOT NULL,
    nombre VARCHAR(30) NOT NULL
);
CREATE TABLE  vendedor (
    id_vendedor INT NOT NULL  IDENTITY PRIMARY KEY,
    nombre VARCHAR(30) NOT NULL,
    apellido VARCHAR(30) NOT NULL,
    comision INT NOT NULL,
    estado INT NOT NULL
);
CREATE TABLE  proveedor (
    id_proveedor INT NOT NULL  IDENTITY PRIMARY KEY,
    nombre VARCHAR(30) NOT NULL,
    direccion VARCHAR(30) NOT NULL,
    provincia VARCHAR(30) NOT NULL,
    pais VARCHAR(30) NOT NULL
);
CREATE TABLE  categoria_producto (
	id_categoria INT NOT NULL  IDENTITY PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL
    );
    
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
CREATE TABLE  sitio (
    id_sitio INT NOT NULL  IDENTITY PRIMARY KEY,
    nombre VARCHAR(30) NOT NULL
);


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


drop TABLE  stock (
    sku INT NOT NULL  IDENTITY PRIMARY KEY,
    id_sitio INT NOT NULL,
    stock INT NOT NULL,
    FOREIGN KEY (sku) REFERENCES producto (sku),
    FOREIGN KEY (id_sitio) REFERENCES sitio (id_sitio)
);

CREATE TABLE  stock (
    sku INT NOT NULL,
    id_sitio INT NOT NULL,
    stock INT NOT NULL,
    FOREIGN KEY (sku) REFERENCES producto (sku),
    FOREIGN KEY (id_sitio) REFERENCES sitio (id_sitio)
);

create TABLE  detalle_factura (
    id_compra INT NOT NULL  IDENTITY PRIMARY KEY,
    id_factura INT NOT NULL,
    sku int not NULL,
    precio_unitario int not NULL,
    cantidad int not NULL,
    FOREIGN KEY (sku) REFERENCES producto (sku),
    FOREIGN KEY (id_factura) REFERENCES factura (id_factura)
);

INSERT into detalle_factura (id_factura, sku, precio_unitario, cantidad) VALUES (3, 2, 7000, 1)

INSERT into factura (id_impuesto, id_cliente, monto, id_vendedor, date) VALUES (1, 10, 10000, 2, '2024-09-30')

SELECT f.id_factura, d.sku, d.cantidad, f.monto  from factura as f 
JOIN detalle_factura as d on d.id_factura = f.id_factura
where f.id_factura = 3

-- Tabla de clientes
INSERT INTO cliente( nombre, apellido, direccion, provincia, pais) VALUES
			('Juan', 'Pérez', 'Calle 123', 'California', 'Estados Unidos'),
			('Ana', 'López', 'Avenida 456', 'Texas', 'Estados Unidos'),
			('Pedro', 'González', 'Calle Principal', 'Ciudad de México', 'México'),
			('María', 'Rodríguez', 'Calle Secundaria', 'São Paulo', 'Brasil'),
			('Luis', 'Fernández', 'Avenida Central', 'Ontario', 'Canadá'),
			('Laura', 'Martínez', 'Calle 789', 'Quebec', 'Canadá'),
			('Carlos', 'Sánchez', 'Calle de la Rosa', 'Ciudad de México', 'México'),
			('Isabel', 'Torres', 'Avenida del Sol', 'São Paulo', 'Brasil'),
			('Miguel', 'Hernández', 'Calle de la Luna', 'California', 'Estados Unidos'),
			('Sofía', 'Díaz', 'Avenida del Río', 'Texas', 'Estados Unidos'),
			('Daniel', 'Chavez', 'Calle de la Montaña', 'Ciudad de México', 'México'),
			('Elena', 'Gómez', 'Avenida del Mar', 'Ontario', 'Canadá'),
			('José', 'Vargas', 'Calle de la Playa', 'Quebec', 'Canadá'),
			('Raquel', 'Peralta', 'Avenida de la Selva', 'São Paulo', 'Brasil'),
			('Francisco', 'Mendoza', 'Calle del Viento', 'California', 'Estados Unidos'),
			('Carolina', 'Lara', 'Avenida del Fuego', 'Texas', 'Estados Unidos'),
			('Andrés', 'Castillo', 'Calle de la Nube', 'Ciudad de México', 'México'),
			('Patricia', 'Rojas', 'Avenida de las Estrellas', 'Ontario', 'Canadá'),
			('Roberto', 'Pérez', 'Calle del Bosque', 'Quebec', 'Canadá'),
			('Teresa', 'Silva', 'Avenida del Cielo', 'São Paulo', 'Brasil'),
			('Javier', 'López', 'Calle del Mar', 'California', 'Estados Unidos'),
			('Liliana', 'González', 'Avenida del Océano', 'Texas', 'Estados Unidos'),
			('Arturo', 'Fernández', 'Calle de la Montaña', 'Ciudad de México', 'México'),
			('Natalia', 'Martínez', 'Avenida del Sol', 'Ontario', 'Canadá'),
			('Manuel', 'Sánchez', 'Calle de la Luna', 'Quebec', 'Canadá'),
			('Beatriz', 'Torres', 'Avenida del Río', 'São Paulo', 'Brasil'),
			('Fernando', 'Hernández', 'Calle de la Rosa', 'California', 'Estados Unidos'),
			('Carmen', 'Díaz', 'Avenida del Mar', 'Texas', 'Estados Unidos'),
			('Antonio', 'Chavez', 'Calle de la Montaña', 'Ciudad de México', 'México'),
			('Eva', 'Gómez', 'Avenida del Río', 'Ontario', 'Canadá'),
			( 'Juan', 'Pérez', 'Calle 9 de Julio', 'Buenos Aires', 'Argentina'),
			('María', 'González', 'Avenida Corrientes', 'Córdoba', 'Argentina'),
			('Pedro', 'Rodríguez', 'Calle San Martín', 'Mendoza', 'Argentina'),
			('Lucía', 'Fernández', 'Avenida Belgrano', 'Salta', 'Argentina'),
			('Jorge', 'García', 'Calle Mitre', 'Tucumán', 'Argentina'),
			('Ana', 'Martínez', 'Avenida Pellegrini', 'Santa Fe', 'Argentina'),
			('Luis', 'Sánchez', 'Calle 25 de Mayo', 'Entre Ríos', 'Argentina'),
			('Carla', 'Díaz', 'Avenida Sarmiento', 'Chaco', 'Argentina'),
			('Diego', 'Torres', 'Calle San Lorenzo', 'Corrientes', 'Argentina'),
			('Valentina', 'Ruiz', 'Avenida San Martín', 'Jujuy', 'Argentina'),
			('Santiago', 'Acosta', 'Calle Florida', 'Buenos Aires', 'Argentina'),
			('Camila', 'Romero', 'Avenida Vélez Sarsfield', 'Córdoba', 'Argentina'),
			('Facundo', 'Suárez', 'Calle San Juan', 'Mendoza', 'Argentina'),
			('Agustina', 'López', 'Avenida San Martín', 'Salta', 'Argentina'),
			('Gustavo', 'Gómez', 'Calle 24 de Septiembre', 'Tucumán', 'Argentina'),
			('Florencia', 'Castro', 'Avenida Freyre', 'Santa Fe', 'Argentina'),
			('Ramiro', 'Álvarez', 'Calle 25 de Mayo', 'Entre Ríos', 'Argentina'),
			('Micaela', 'Fernández', 'Avenida 9 de Julio', 'Chaco', 'Argentina'),
			('Tomás', 'García', 'Calle San Juan', 'Corrientes', 'Argentina'),
			('Luciana', 'Díaz', 'Avenida San Martín', 'Jujuy', 'Argentina'),
			('Juan', 'Pérez', 'Calle Florida', 'Buenos Aires', 'Argentina'),
			('María', 'González', 'Avenida Vélez Sarsfield', 'Córdoba', 'Argentina'),
			('Pedro', 'Rodríguez', 'Calle San Martín', 'Mendoza', 'Argentina'),
			('Lucía', 'Fernández', 'Avenida Belgrano', 'Salta', 'Argentina'),
			('Jorge', 'García', 'Calle Mitre', 'Tucumán', 'Argentina'),
			('Ana', 'Martínez', 'Avenida Pellegrini', 'Santa Fe', 'Argentina'),
			('Luis', 'Sánchez', 'Calle 25 de Mayo', 'Entre Ríos', 'Argentina'),
			('Carla', 'Díaz', 'Avenida Sarmiento', 'Chaco', 'Argentina'),
			('Diego', 'Torres', 'Calle San Lorenzo', 'Corrientes', 'Argentina'),
			('Valentina', 'Ruiz', 'Avenida San Martín', 'Jujuy', 'Argentina');
-- Tabla impuesto
INSERT INTO impuesto ( tipo, nombre) VALUES
			('A','RESPONSABLE INSCRIPTO'),
			('B','CONSUMIDOR FINAL'),
			('C','EXENTO');
-- Tabla vendedor
INSERT INTO vendedor ( nombre, apellido, comision, estado) VALUES
			('Diego Armando','Maradona',2,1),
			('Lionel Andres','Messi',1,1),
			('Mario Alberto','Kempes',2,0),
			('Gabriel Omar','Batistuta',2,1),
			('Leo','Matiolli',0,0);
-- Tabla de proveedores
INSERT INTO proveedor (nombre, direccion, provincia, pais) VALUES
			( 'HardwareTech', '123 Hardware Street', 'Buenos Aires', 'Argentina'),
			( 'TechPro', '456 Tech Avenue', 'Córdoba', 'Argentina'),
			( 'GadgetWorld', '789 Gadget Lane', 'Ciudad de Buenos Aires', 'Argentina'),
			( 'ElectroSupplies', '1 Electronics Road', 'Mendoza', 'Argentina'),
			( 'ComponentX', '42 Hardware Avenue', 'San Juan', 'Argentina'),
			( 'DataSolutions', '88 Tech Plaza', 'Tucumán', 'Argentina'),
			( 'TechGurus', '555 Tech Boulevard', 'Rosario', 'Argentina'),
			( 'InnovativeTech', '333 Innovation Street', 'Salta', 'Argentina'),
			( 'HardwarePlus', '777 Hardware Drive', 'Misiones', 'Argentina'),
			( 'ConnectIT', '22 Connection Road', 'San Luis', 'Argentina');
-- Tabla categoria/Categorias.
INSERT INTO categoria_producto ( nombre) VALUES
			( 'Memorias RAM'),
			( 'Procesadores'),
			( 'Tarjetas gráficas'),
			( 'Discos duros SSD'),
			( 'Discos duros HDD'),
			( 'Placas madre'),
			( 'Monitores'),
			( 'Teclados'),
			( 'Mouses'),
			( 'Auriculares'),
			( 'Micrófonos'),
			( 'Webcams'),
			( 'Sillas gaming'),
			( 'Escritorios gaming'),
			( 'Alfombrillas para mouse'),
			( 'Cables HDMI'),
			( 'Cables VGA'),
			( 'Cables de alimentación'),
			( 'Cables USB'),
			( 'Cables de red'),
			( 'Adaptadores de corriente'),
			( 'Ventiladores para PC'),
			( 'Fuentes de alimentación'),
			( 'Cajas de PC'),
			( 'Lectores de tarjetas'),
			( 'Unidades ópticas'),
			( 'Altavoces'),
			( 'Impresoras'),
			( 'Scanners'),
			( 'Proyectores');
			
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
INSERT INTO sitio (nombre) VALUES
			('Deposito'),
			('Salon'),
			('Baulera'),
			('Sector ACcesorios'),
			('Devoluciones');
INSERT INTO factura (id_impuesto, id_cliente, monto, id_vendedor, date, sku)
VALUES
			( 1, 1, 100, 1, '2023-09-25', 1),
			( 2, 2, 150, 2, '2023-09-26', 2),
			( 3, 3, 200, 3, '2023-09-27', 3),
			( 1, 22, 120, 4, '2023-09-28', 4),
			( 2, 25, 180, 5, '2023-09-29', 5),
			( 3, 27, 250, 1, '2023-09-30', 6),
			( 1, 1, 100, 1, '2023-09-25', 1),
			( 2, 2, 150, 2, '2023-09-26', 2),
			( 3, 3, 200, 3, '2023-09-27', 3),
			( 1, 10, 120, 4, '2023-09-28', 4),
			( 2, 9, 180, 5, '2023-09-29', 5),
			( 3, 5, 250, 1, '2023-09-30', 6),
			( 1, 7, 100, 1, '2023-09-25', 1),
			( 2, 8, 150, 2, '2023-09-26', 8),
			( 3, 3, 200, 3, '2023-09-27', 18),
			( 1, 19, 120, 4, '2023-09-28', 13),
			( 2, 22, 180, 5, '2023-09-29', 15),
			( 3, 23, 250, 1, '2023-09-30', 19),
			( 1, 30, 220, 5, '2023-10-20', 20),
			( 1, 25, 100, 1, '2023-09-25', 1),
			( 2, 28, 150, 2, '2023-09-26', 2),
			( 3, 3, 200, 3, '2023-09-27', 3),
			( 1, 4, 120, 4, '2023-09-28', 4),
			( 2, 5, 180, 5, '2023-09-29', 19),
			( 3, 6, 250, 1, '2023-09-30', 18),
			( 1, 1, 100, 1, '2023-09-25', 17),
			( 2, 2, 150, 2, '2023-09-26', 2),
			( 3, 3, 200, 3, '2023-09-27', 3),
			( 1, 4, 120, 4, '2023-09-28', 4),
            ( 1, 1, 100, 1, '2023-09-25', 1),
			( 2, 2, 150, 2, '2023-09-26', 2),
			( 3, 3, 200, 3, '2023-09-27', 3),
			( 1, 22, 120, 4, '2023-09-28', 4),
			( 2, 25, 180, 5, '2023-09-29', 5),
			( 3, 27, 250, 1, '2023-09-30', 6),
			( 1, 1, 100, 1, '2023-09-25', 1),
			( 2, 2, 150, 2, '2023-09-26', 2),
			( 3, 3, 200, 3, '2023-09-27', 3),
			( 1, 10, 120, 4, '2023-09-28', 4),
			( 2, 9, 180, 5, '2023-09-29', 5),
			( 3, 5, 250, 1, '2023-09-30', 6),
			( 1, 7, 100, 1, '2023-09-25', 1),
			( 2, 8, 150, 2, '2023-09-26', 8),
			( 3, 3, 200, 3, '2023-09-27', 18),
			( 1, 19, 120, 4, '2023-09-28', 13),
			( 2, 22, 180, 5, '2023-09-29', 15),
			( 3, 23, 250, 1, '2023-09-30', 19),
			( 1, 30, 220, 5, '2023-10-20', 20),
			( 1, 25, 100, 1, '2023-09-25', 1),
			( 2, 28, 150, 2, '2023-09-26', 2),
			( 3, 3, 200, 3, '2023-09-27', 3),
			( 1, 4, 120, 4, '2023-09-28', 4),
			( 2, 5, 180, 5, '2023-09-29', 19),
			( 3, 6, 250, 1, '2023-09-30', 18),
			( 1, 1, 100, 1, '2023-09-25', 17),
			( 2, 2, 150, 2, '2023-09-26', 2),
			( 3, 3, 200, 3, '2023-09-27', 3),
			( 1, 4, 120, 4, '2023-09-28', 4),
			( 2, 5, 180, 5, '2023-09-29', 19),
			( 3, 6, 250, 1, '2023-09-30', 18),
			( 1, 1, 100, 1, '2023-09-25', 1),
			( 2, 2, 150, 2, '2023-09-26', 2),
			( 3, 3, 200, 3, '2023-09-27', 3),
			( 1, 4, 120, 4, '2023-09-28', 4),
			( 2, 5, 180, 5, '2023-09-29', 19),
			( 3, 6, 250, 1, '2023-09-30', 18);
-- Tabla stock
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