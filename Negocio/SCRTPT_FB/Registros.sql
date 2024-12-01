USE Compumundo_hipermegared
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


INSERT INTO direccion (direccionID, Calle, Codigo_postal, Ciudad, ProvinciaID) 
VALUES 
(1, 'Calle Ficticia 1', 10001, 'Ciudad A', 1),
(2, 'Calle Ficticia 2', 10002, 'Ciudad B', 2),
(3, 'Calle Ficticia 3', 10003, 'Ciudad C', 3),
(4, 'Calle Ficticia 4', 10004, 'Ciudad D', 4),
(5, 'Calle Ficticia 5', 10005, 'Ciudad E', 5),
(6, 'Calle Ficticia 6', 10006, 'Ciudad F', 6),
(7, 'Calle Ficticia 7', 10007, 'Ciudad G', 7),
(8, 'Calle Ficticia 8', 10008, 'Ciudad H', 8),
(9, 'Calle Ficticia 9', 10009, 'Ciudad I', 9),
(10, 'Calle Ficticia 10', 10010, 'Ciudad J', 10),
(11, 'Calle Ficticia 11', 10011, 'Ciudad K', 11),
(12, 'Calle Ficticia 12', 10012, 'Ciudad L', 12),
(13, 'Calle Ficticia 13', 10013, 'Ciudad M', 13),
(14, 'Calle Ficticia 14', 10014, 'Ciudad N', 14),
(15, 'Calle Ficticia 15', 10015, 'Ciudad O', 15),
(16, 'Calle Ficticia 16', 10016, 'Ciudad P', 16),
(17, 'Calle Ficticia 17', 10017, 'Ciudad Q', 17),
(18, 'Calle Ficticia 18', 10018, 'Ciudad R', 18),
(19, 'Calle Ficticia 19', 10019, 'Ciudad S', 19),
(20, 'Calle Ficticia 20', 10020, 'Ciudad T', 20);



INSERT INTO cliente (nombre, apellido, DireccionID) 
VALUES 
('Juan', 'P�rez', 1),
('Ana', 'Gonz�lez', 2),
('Luis', 'Mart�nez', 3),
('Marta', 'Rodr�guez', 4),
('Carlos', 'L�pez', 5),
('Sof�a', 'Hern�ndez', 6),
('Jos�', 'Garc�a', 7),
('Patricia', 'Fern�ndez', 8),
('Ricardo', 'Gonz�lez', 9),
('Laura', 'S�nchez', 10),
('David', 'Ram�rez', 11),
('Isabel', 'D�az', 12),
('Pedro', 'Torres', 13),
('Cristina', 'V�zquez', 14),
('Javier', 'Moreno', 15),
('Raquel', 'Jim�nez', 16),
('Antonio', 'Mart�n', 17),
('Dolores', 'Ruiz', 18),
('Manuel', 'Alvarez', 19),
('Carmen', 'G�mez', 20);




INSERT INTO impuesto ( tipo, nombre)
VALUES 
( 'A', 'IVA 21%'),
( 'B', 'IVA 10.5%'),
( 'A', 'IVA Exento'),
('C', 'Retenci�n Ganancias');




INSERT INTO vendedor (nombre, apellido, comision, estado)
VALUES 
('Fernando', 'L�pez', 10, 1),
('Roberto', 'Garc�a', 15, 1),
('Elena', 'Mart�nez', 20, 1),
('Carlos', 'S�nchez', 12, 1),
('Luc�a', 'Rodr�guez', 18, 1);


INSERT INTO sitio ( nombre)
VALUES 
( 'Deposito'),
( 'Baul'),
( 'Sal�n de Ventas'),
( 'Cajones');


INSERT INTO factura (id_impuesto, id_cliente, monto, id_vendedor, date)
VALUES 
(1, 1, 500, 1, '2024-11-10'),
(2, 2, 1500, 2, '2024-11-09'),
(3, 3, 300, 3, '2024-11-08'),
(4, 4, 1200, 4, '2024-11-07'),
(2, 5, 2000, 5, '2024-11-06');

INSERT INTO proveedor (nombre, direccionID) VALUES
	('Sin Proveedor asignado', 1),
    ('TechWorld Hardware', 1),
    ('CompuPro', 2),
    ('RedTech Solutions', 3),
    ('HardDrive Inc.', 4),
    ('Digital Systems', 5),
    ('ByteCraft Electronics', 6),
    ('PowerTech Components', 7),
    ('CircuitLab Supplies', 8),
    ('GigaGear Systems', 9),
    ('PixelCore Technologies', 10);
GO

INSERT INTO MARCAS (nombre) VALUES
    ('Logitech'),
    ('Razer'),
    ('Corsair'),
    ('HP'),
    ('MSI'),
    ('Acer'),
    ('Gigabyte'),
    ('Asus'),
    ('Kingston'),
    ('Seagate');
GO

INSERT INTO Categorias (nombre) VALUES
    ('Placas Base'),
    ('Tarjetas Gr�ficas'),
    ('Memoria RAM'),
    ('Discos Duros'),
    ('Perif�ricos'),
    ('Teclados'),
    ('Monitores'),
    ('Sistemas de Refrigeraci�n'),
    ('Fuentes de Alimentaci�n'),
    ('Componentes de Red');
GO

INSERT INTO Articulos (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio, id_proveedor, estado) VALUES
    ('A001', 'Placa Base ASUS Z490', 'Placa base para procesadores Intel de d�cima generaci�n', 1, 1, 150.00, 1, 1),
    ('A002', 'Placa Base MSI B450', 'Placa base para procesadores AMD Ryzen', 2, 1, 120.00, 2, 1),
    ('A003', 'Tarjeta Gr�fica Nvidia RTX 3080', 'Tarjeta gr�fica de alto rendimiento para juegos', 3, 2, 700.00, 3, 1),
    ('A004', 'Tarjeta Gr�fica AMD Radeon RX 6800', 'Tarjeta gr�fica para gaming y tareas gr�ficas exigentes', 4, 2, 650.00, 4, 1),
    ('A005', 'Memoria RAM Corsair Vengeance 16GB', 'Memoria RAM DDR4 16GB, 3200MHz', 5, 3, 80.00, 5, 1),
    ('A006', 'Memoria RAM G.SKILL Ripjaws 32GB', 'Memoria RAM DDR4 32GB, 3600MHz', 6, 3, 150.00, 6, 1),
    ('A007', 'Disco Duro Seagate 1TB', 'Disco duro HDD de 1TB para almacenamiento masivo', 7, 4, 50.00, 7, 1),
    ('A008', 'Disco Duro Western Digital 2TB', 'Disco duro externo de 2TB', 8, 4, 90.00, 8, 1),
    ('A009', 'Teclado Logitech G Pro X', 'Teclado mec�nico para gamers con switches intercambiables', 9, 5, 100.00, 9, 1),
    ('A010', 'Teclado Razer Huntsman', 'Teclado mec�nico �ptico para gamers', 10, 5, 120.00, 10, 1),
    ('A011', 'Monitor Dell UltraSharp 27"', 'Monitor 4K de 27 pulgadas para dise�o gr�fico y productividad', 1, 7, 350.00, 1, 1),
    ('A012', 'Monitor Acer Predator X34', 'Monitor ultrapanor�mico para juegos, 34" 144Hz', 2, 7, 800.00, 2, 1),
    ('A013', 'Sistema de Refrigeraci�n NZXT Kraken Z73', 'Sistema de refrigeraci�n l�quida AIO para CPUs', 3, 8, 200.00, 3, 1),
    ('A014', 'Sistema de Refrigeraci�n Corsair iCUE H150i', 'Sistema de refrigeraci�n l�quida para alto rendimiento', 4, 8, 170.00, 4, 1),
    ('A015', 'Fuente de Alimentaci�n EVGA SuperNOVA 650 G5', 'Fuente de alimentaci�n de 650W, eficiencia 80 Plus Gold', 5, 9, 90.00, 5, 1),
    ('A016', 'Fuente de Alimentaci�n Corsair RM850x', 'Fuente de alimentaci�n de 850W, 80 Plus Gold', 6, 9, 130.00, 6, 1),
    ('A017', 'Router TP-Link Archer AX6000', 'Router Wi-Fi 6 con velocidad de 6 Gbps', 7, 10, 250.00, 7, 1),
    ('A018', 'Router Asus RT-AC88U', 'Router Wi-Fi AC3100 con 8 puertos Gigabit', 8, 10, 180.00, 8, 1),
    ('A019', 'Placa Base ASUS ROG Crosshair VIII Hero', 'Placa base para AMD Ryzen con soporte para overclocking', 1, 1, 300.00, 1, 1),
    ('A020', 'Placa Base Gigabyte Z590 AORUS', 'Placa base para Intel de 11� generaci�n', 2, 1, 250.00, 2, 1),
    ('A021', 'Disco Duro Kingston A2000 500GB', 'Disco SSD NVMe de 500GB', 3, 4, 60.00, 3, 1),
    ('A022', 'Disco SSD Samsung 970 Evo 1TB', 'Disco SSD NVMe de 1TB', 4, 4, 150.00, 4, 1),
    ('A023', 'Tarjeta Gr�fica MSI GeForce GTX 1650', 'Tarjeta gr�fica para juegos de nivel medio', 5, 2, 180.00, 5, 1),
    ('A024', 'Tarjeta Gr�fica Zotac GTX 1660 Super', 'Tarjeta gr�fica para gaming de nivel medio', 6, 2, 200.00, 6, 1),
    ('A025', 'Memoria RAM HyperX Fury 8GB', 'Memoria RAM DDR4 de 8GB, 3200MHz', 7, 3, 40.00, 7, 1),
    ('A026', 'Memoria RAM TeamGroup T-Force 16GB', 'Memoria RAM DDR4 16GB, 3600MHz', 8, 3, 75.00, 8, 1),
    ('A027', 'Teclado Cooler Master MK730', 'Teclado mec�nico con switches Cherry MX', 9, 5, 90.00, 9, 1),
    ('A028', 'Teclado SteelSeries Apex Pro', 'Teclado mec�nico con ajustes de actuation', 10, 5, 160.00, 10, 1),
    ('A029', 'Monitor Samsung Odyssey G7', 'Monitor curvado 240Hz para gaming', 1, 7, 600.00, 1, 1),
    ('A030', 'Monitor LG UltraGear 27GN950', 'Monitor 4K de 27 pulgadas, 144Hz', 2, 7, 700.00, 2, 1);
GO

INSERT INTO stock (id_producto, id_sitio, stock)
VALUES 
(1, 1, 100),
(1,2,50),
(1, 1, 50),
(2, 3, 75),
(3, 4, 120),
(3,2,50),
(4, 1, 30),
(5, 2, 60),
(6, 3, 150),
(7, 4, 200),
(8, 1, 80),
(9, 2, 110),
(10, 3, 90),
(11, 4, 30),
(12, 1, 200),
(13, 2, 150),
(14, 3, 180),
(15, 4, 75),
(16, 1, 100),
(17, 2, 50),
(18, 3, 120),
(19, 4, 140),
(20, 1, 110),
(21, 2, 80),
(22, 3, 90),
(23, 4, 130),
(24, 1, 75),
(25, 2, 120),
(26, 3, 80),
(27, 4, 100),
(28, 1, 90),
(29, 2, 140);
GO



INSERT INTO detalle_factura (id_factura, id_articulo, precio_unitario, cantidad)
VALUES 
(1, 11, 100, 5),
(1, 12, 50, 4),
(2, 13, 150, 3),
(2, 14, 200, 2),
(3, 15, 75, 4),
(4, 16, 250, 2),
(4, 17, 300, 1),
(5, 18, 400, 5);

