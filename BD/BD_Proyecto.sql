-- CREACION BASE DE DATOS
CREATE DATABASE SistemaVentas;
USE SistemaVentas;

-- CREACION TABLAS DEL SISTEMA
CREATE TABLE Roles(
	IDRol int auto_increment primary key,
	Rol varchar(50) not null
);

CREATE TABLE Estados(
	IDEstado int auto_increment primary key,
	Estado boolean not null,
	Descripcion varchar(10) not null
);

CREATE TABLE Empleados (
	IDEmpleado int auto_increment primary key,
    Nombres varchar(50) not null,
    Apellidos varchar(50) not null,
    DUI varchar(10) not null,
    Direccion varchar(100) not null,
    Telefono varchar(9) not null,
    Correo varchar(50) not null
);

CREATE TABLE Clientes (
	IDCliente int auto_increment primary key,
    Nombres varchar(50) not null,
    Apellidos varchar(50) not null,
    Correo varchar(50) not null
);

CREATE TABLE Proveedores(
	IDProveedor int auto_increment primary key,
	Proveedor varchar(100) not null,
	Contacto double not null,
	Direccion varchar(200) not null,
	Email varchar(80) not null
);

CREATE TABLE Categorias(
	IDCategoria int auto_increment primary key,
    Categoria varchar(50) not null
);

CREATE TABLE Usuarios(
	IDUsuario int auto_increment primary key,
	Usuario varchar(50) not null,
	Clave varchar(32) not null,
	IDRol int not null,
	IDEmpleado int not null,
    IDEstado int not null
);

CREATE TABLE Productos (
    IDProducto varchar(100) primary key,
    Producto varchar(200) not null,
    Stock int not null,
    Precio double not null,
    FechaFabricacion datetime not null,
    FechaVencimiento datetime not null,
    Descripcion text not null,
    IDProveedor int not null,
    IDCategoria int not null
);


CREATE TABLE Ventas (
    IDVenta varchar(20) primary key,
    FechaVenta datetime not null,
    IDUsuario int not null,
    IDCliente int not null,
    IDProducto mediumtext not null,
    Cantidad int not null,
    Total double not null
);

-- LLAVES FORANEAS
ALTER TABLE Usuarios ADD CONSTRAINT fk_usuario_rol FOREIGN KEY (IDRol) REFERENCES Roles(IDRol);
ALTER TABLE Usuarios ADD CONSTRAINT fk_usuario_empleado FOREIGN KEY (IDEmpleado) REFERENCES Empleados(IDEmpleado);
ALTER TABLE Usuarios ADD CONSTRAINT fk_usuario_estado FOREIGN KEY (IDEstado) REFERENCES Estados(IDEstado);
ALTER TABLE Productos ADD CONSTRAINT fk_producto_proveedor FOREIGN KEY (IDProveedor) REFERENCES Proveedores(IDProveedor);
ALTER TABLE Productos ADD CONSTRAINT fk_producto_categoria FOREIGN KEY (IDCategoria) REFERENCES Categorias(IDCategoria);
ALTER TABLE Ventas ADD CONSTRAINT fk_venta_usuario FOREIGN KEY (IDUsuario) REFERENCES Usuarios(IDUsuario);
ALTER TABLE Ventas ADD CONSTRAINT fk_venta_cliente FOREIGN KEY (IDCliente) REFERENCES Clientes(IDCliente);
ALTER TABLE Ventas ADD CONSTRAINT fk_venta_producto FOREIGN KEY (IDProducto) REFERENCES Productos(IDProducto);

-- INSERCIONES 
INSERT INTO Roles (IDRol, Rol) VALUES
(1, "Administrador"),
(2, "Almacenista"),
(3, "Vendedor");

INSERT INTO Estados (IDEstado, Estado, Descripcion) VALUES
(1, '0', "Inactivo"),
(2, '1', "Activo");

INSERT INTO Clientes (IDCliente, Nombres, Apellidos, Correo) VALUES
(1, "Juan Daniel", "López Pérez", "cliente1@correo.com"),
(2, "Pedro Armando", "Escamoso Barrientos", "cliente2@correo.com"),
(3, "José María", "Zotelo Bran", "cliente3@correo.com"),
(4, "María José", "Pérez Zosa", "cliente4@correo.com"),
(5, "Flor Del Carmen", "Najarro Hernádez", "cliente5@correo.com");

INSERT INTO Empleados (IDEmpleado, Nombres, Apellidos, DUI, Direccion, Telefono, Correo) VALUES
(1, "Juan José", "López Pérez", "11111111-1", "Colonia 1, Caserío 1, casa 1", "1234-5678", "empleado1@correo.com"),
(2, "María Elena", "García Martínez", "22222222-2", "Colonia 2, Caserío 2, casa 2", "2234-5678", "empleado2@correo.com"),
(3, "Pedro Antonio", "Martínez López", "33333333-3", "Colonia 3, Caserío 3, casa 3", "3234-5678", "empleado3@correo.com"),
(4, "Laura Isabel", "Pérez Rodríguez", "44444444-4", "Colonia 4, Caserío 4, casa 4", "4234-5678", "empleado4@correo.com"),
(5, "Carlos Andrés", "Hernández Bonilla", "55555555-5", "Colonia 5, Caserío 5, casa 5", "5234-5678", "empleado5@correo.com");

INSERT INTO Proveedores (IDProveedor, Proveedor, Contacto, Direccion, Email) VALUES
(1,'Refrescos Delicia', 12345678, 'Calle Primavera #123, Ciudad del Sol', 'ventas@refrescosdelicia.com'),
(2,'Distribuidora de Golosinas', 98765432, 'Avenida Central #456, Barrio Nuevo', 'ventas@golosinasdistribuidora.com'),
(3,'Suministros Industriales Hermanos Pérez', 32178904, 'Calle Industria #789, Zona Industrial', 'ventas@suministroshermanosperez.com'),
(4,'Electrodomésticos Vargas', 56789012, 'Calle Tecnología #234, Urbanización Moderna', 'ventas@electrodomesticosvargas.com'),
(5,'Distribuidora de Juguetes Felices', 87654321, 'Avenida de los Niños #567, Barrio Jardín', 'ventas@juguetesfelices.com');

INSERT INTO Categorias (IDCategoria, Categoria) VALUES
(1, 'Lácteos'),
(2, 'Carnes'),/*(pollo, res, cerdo)*/
(3, 'Mariscos'),/*(pescado, camarón, etc.)*/
(4, 'Alimentos enlatados'),
(5, 'Bebidas embotelladas'),/*(plastico y vidrio)*/
(6, 'Bebidas enlatadas'),
(7, 'Bebidas para preparar'),/*(cafe en polvo, Tang, Yus, etc.)*/
(8, 'Cereales'), /*(maiz, frijol, arroz, etc)*/
(9, 'Frutas'),
(10, 'Pastas'),/*(spaggeti, lasagña, etc.)*/
(11, 'Hortalizas'),/*(incluye verduras y legumbres)*/
(12, 'Desechables'),
(13, 'Cocina'),/*(utensilios)*/
(14, 'Postres'),
(15, 'Golosinas'),
(16, 'Deporte'),
(17, 'Belleza'),
(18, 'Electrodomésticos'),
(19, 'Limpieza'),
(20, 'Escolares'),
(21, 'Juguetes'),
(22, 'Mascotas');/*(Comida y accesorios para mascotas)*/

INSERT INTO Usuarios VALUES
(1, "Admin", MD5('adm'), 1, 1, 1),
(2, "Almacen", MD5('alm'), 2, 2, 2),
(3, "Ventas", MD5('vnt'), 1, 3, 1),
(4, "Laura", MD5('lau'), 3, 4, 2),
(5, "Carlos", MD5('car'), 2, 5, 1);

/*A los productos que no venzan se les pondrá como año de vencimiento "2100-01-01" y a los productos tales como frutas u hortalizas
que no tengan fechas especificadas se les dará un aproximado de vida de 10 días a partir de
su ingreso al sistema (se debe verificar su estado de manera física)*/
INSERT INTO Productos (IDProducto, Producto, Stock, Precio, FechaFabricacion, FechaVencimiento,Descripcion, IDProveedor, IDCategoria) VALUES
('PROD001', "Refresco de cola", 100, 1.99, "2024-01-01 13:00:00", "2025-01-01 13:00:00", "Refresco de cola en lata de 355ml", 1, 6),
('PROD002', "Bolsa de papas fritas", 150, 0.99, "2024-01-01 14:00:00", "2024-01-02 14:00:00", "Bolsa de papas fritas de 100g", 2, 15),
('PROD003', "Jabón de manos", 200, 2.49, "2023-01-01 15:00:00", "2026-01-01 15:00:00", "Jabón líquido para manos con aroma a manzana", 3, 19),
('PROD004', "Caja de dulces surtidos", 80, 5.99, "2024-01-01 16:00:00", "2024-05-01 16:00:00", "Caja de dulces surtidos, ideal para regalo", 4, 15),
('PROD005', "Lápiz de colores", '300', 3.49, 1.99, "2022-01-01 17:00:00", "2100-01-01 17:00:00", "Paquete de 12 lápices de colores surtidos", 5, 21);

INSERT INTO Ventas (IDVenta, FechaVenta, IDUsuario, IDCliente, IDProducto, Cantidad, Total) VALUES
('VENTA001', '2024-05-01 08:30:00', 4, 1, 'PROD001', 4 , '7.96'),
('VENTA002', '2024-05-02 10:15:00', 4, 2, 'PROD003', 3 , '7.47'),
('VENTA003', '2024-05-03 13:45:00', 5, 3, 'PROD004', 5 , '29.95'),
('VENTA004', '2024-05-04 15:20:00', 3, 4, 'PROD001', 4 , '7.96'),
('VENTA005', '2024-05-05 17:00:00', 5, 5, 'PROD002', 7 , '6.93');


/* PROCEDIMIENTOS ALMACENADOS */

/* ESTADOS */
DELIMITER $$
CREATE PROCEDURE ObtenerEstados()
BEGIN
SELECT * 
FROM estados;
END $$

/* PERMISOS */
DELIMITER $$
CREATE PROCEDURE ObtenerRoles()
BEGIN
SELECT *
FROM roles;
END $$

/* PERMISOS */
DELIMITER $$
CREATE PROCEDURE ObtenerPermisos()
BEGIN
SELECT *
FROM permisos;
END $$

/* USUARIOS */
DELIMITER $$
CREATE PROCEDURE ObtenerUsuarios()
BEGIN
SELECT *
FROM usuarios;
END

DELIMITER $$
CREATE PROCEDURE BuscarUsuario(IN usuario varchar(200))
BEGIN
SELECT *
FROM usuarios
WHERE nomUsuario LIKE CONCAT(usuario,'%');
END

DELIMITER $$
CREATE PROCEDURE InsertarUsuario(IN nomUsuario varchar(200), usuario varchar(50), contrasena varchar(10), idPermiso int, idEstado int)
BEGIN
INSERT INTO usuarios (nomUsuario, usuario, contrasena, idPermiso, idEstado)
VALUES (nomUsuario, usuario, contrasena, idPermiso, idEstado);
END

DELIMITER $$
CREATE PROCEDURE ActualizarUsuario(IN id int, nomUsuario varchar(200), usuario varchar(50), contrasena varchar(10), idPermiso int, idEstado int)
BEGIN
UPDATE usuarios 
SET nomUsuario=nomUsuario, usuario=usuario, contrasena=contrasena, idPermiso=idPermiso, idEstado=idEstado
WHERE idUsuario=id;
END

/* PROVEEDORES */
DELIMITER $$
CREATE PROCEDURE ObtenerProveedores()
BEGIN
SELECT *
FROM proveedores;
END

/* PROVEEDORES */
DELIMITER $$
CREATE PROCEDURE ObtenerCategorias()
BEGIN
SELECT *
FROM categorias;
END

DELIMITER $$
CREATE PROCEDURE BuscarProveedor(IN proveedor varchar(100))
BEGIN
SELECT *
FROM proveedores
WHERE nomProveedor LIKE CONCAT(proveedor,'%');
END

DELIMITER $$
CREATE PROCEDURE InsertarProveedor(IN nomProveedor varchar(100), numContacto double, direccion varchar(200), email varchar(80))
BEGIN
INSERT INTO proveedores (nomProveedor, numContacto, direccion, email)
VALUES (nomProveedor, numContacto, direccion, email);
END

DELIMITER $$
CREATE PROCEDURE ActualizarProveedor(IN id int, nomProveedor varchar(100), numContacto double, direccion varchar(200), email varchar(80))
BEGIN
UPDATE proveedores 
SET nomProveedor=nomProveedor, numContacto=numContacto, direccion=direccion, email=email
WHERE idProveedor=id;
END

/* PRODUCTOS */
DELIMITER $$
CREATE PROCEDURE ObtenerProductos()
BEGIN
SELECT prod.*, prov.nomProveedor
FROM productos prod
INNER JOIN proveedores prov ON prod.idProveedor=prov.idProveedor;
END

DELIMITER $$
CREATE PROCEDURE InsertarProducto(IN idProducto int, nomProducto varchar(200), stock int, precio double, descripcion text, idProveedor int)
BEGIN
INSERT INTO productos (idProducto, nomProducto, stock, precio, descripcion, idProveedor)
VALUES (idProducto, nomProducto, stock, precio, descripcion, idProveedor);
END

DELIMITER $$
CREATE PROCEDURE ActualizarProducto(IN id int, nomProducto varchar(200), stock int, precio double, descripcion text, idProveedor int)
BEGIN
UPDATE productos 
SET nomProducto=nomProducto, stock=stock, precio=precio, descripcion=descripcion, idProveedor=idProveedor
WHERE idProducto=id;
END

DELIMITER $$
CREATE PROCEDURE BuscarProducto(IN producto varchar(200))
BEGIN
SELECT prod.*, prov.nomProveedor
FROM productos prod
INNER JOIN proveedores prov ON prod.idProveedor=prov.idProveedor
WHERE idProducto LIKE CONCAT(producto,'%') OR nomProducto LIKE CONCAT(producto, '%');
END

DELIMITER $$
CREATE PROCEDURE BuscarProductoVenta(IN codigo varchar(200))
BEGIN
SELECT idProducto, nomProducto, stock, precio, descripcion
FROM productos
WHERE idProducto LIKE CONCAT(codigo,'%');
END

DELIMITER $$
CREATE PROCEDURE ObtenerNombreProducto(IN codigo varchar(200))
BEGIN
SELECT idProducto, nomProducto, descripcion
FROM productos
WHERE idProducto LIKE CONCAT(codigo,'%');
END

/* VENTAS */
DELIMITER $$
CREATE PROCEDURE InsertarVenta(IN idVenta varchar(20), fechaVenta datetime, idUsuario int, idProductos mediumtext, total double)
BEGIN
INSERT INTO ventas(idVenta, fechaVenta, idUsuario, idProductos, total)
VALUES (idVenta, fechaVenta, idUsuario, idProductos, total);
END

DELIMITER $$
CREATE PROCEDURE ActualizarStock(IN codigo varchar(100), cantidad int)
BEGIN
UPDATE productos
SET stock=stock-cantidad
WHERE idProducto=codigo;
END

/* REPORTES */
DELIMITER $$
CREATE PROCEDURE ObtenerVentas(IN fechaInicial varchar(20), fechaFinal varchar(20))
BEGIN
SELECT ventas.*, usuarios.nomUsuario 
FROM ventas 
INNER JOIN usuarios ON ventas.idUsuario=usuarios.idUsuario
WHERE idVenta BETWEEN (fechaInicial) AND (fechaFinal);
END

/* PROCEDIMIENTO ALMACENADO LOGIN */
DELIMITER $$
CREATE PROCEDURE LoginUsuario(IN Usuario varchar(50), Clave varchar(32))
BEGIN
SELECT *
FROM Usuarios
WHERE Usuarios.Usuario=Usuario AND Usuarios.Clave=Clave;
END