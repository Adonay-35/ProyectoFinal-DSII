-- CREACION BASE DE DATOS
CREATE DATABASE SistemaVentas;
USE SistemaVentas;

-- CREACION TABLAS DEL SISTEMA
CREATE TABLE Roles(
	IDRol int auto_increment primary key,
	Rol varchar(50) not null
);

CREATE TABLE Empleados (
	IDEmpleado int auto_increment primary key,
    Nombres varchar(50) not null,
    Apellidos varchar (50) not null
);

CREATE TABLE Estados(
	IDEstado int auto_increment primary key,
	Estado boolean not null,
	Descripcion varchar(10) not null
);

CREATE TABLE Proveedores(
	IDProveedor int auto_increment primary key,
	Proveedor varchar(100) not null,
	Contacto double not null,
	Direccion varchar(200) not null,
	Email varchar(80) not null
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
    Stock int,
    Precio double not null,
    Descripcion text,
    IDProveedor int not null
);


CREATE TABLE Ventas (
    IDVenta varchar(20) primary key,
    FechaVenta datetime,
    IDUsuario int,
    IDProductos mediumtext,
    Total double
);

-- LLAVES FORANEAS
ALTER TABLE Productos ADD CONSTRAINT fk_producto_proveedor FOREIGN KEY (IDProveedor) REFERENCES Proveedores(IDProveedor);
ALTER TABLE Usuarios ADD CONSTRAINT fk_usuario_rol FOREIGN KEY (IDRol) REFERENCES Roles(IDRol);
ALTER TABLE Usuarios ADD CONSTRAINT fk_usuario_empleado FOREIGN KEY (IDEmpleado) REFERENCES Empleados(IDEmpleado);
ALTER TABLE Usuarios ADD CONSTRAINT fk_usuario_estado FOREIGN KEY (IDEstado) REFERENCES Estados(IDEstado);
ALTER TABLE Ventas ADD CONSTRAINT fk_venta_usuario FOREIGN KEY (IDUsuario) REFERENCES Usuarios(IDUsuario);

-- INSERCIONES 
INSERT INTO Roles VALUES ('1', "Administrador");
INSERT INTO Roles VALUES ('2', "Almacenista");
INSERT INTO Roles VALUES ('3', "Vendedor");

INSERT INTO Estados VALUES ('1', '0', "Inactivo");
INSERT INTO Estados VALUES ('2', '1', "Activo");

INSERT INTO Empleados VALUES (1, "Juan José", "López Pérez");
INSERT INTO Empleados VALUES (2, "María Elena", "García Martínez");
INSERT INTO Empleados VALUES (3, "Pedro Antonio", "Martínez López");
INSERT INTO Empleados VALUES (4, "Laura Isabel", "Pérez Rodríguez ");
INSERT INTO Empleados VALUES (5, "Carlos Andrés", "Hernández Bonilla");

INSERT INTO Usuarios VALUES ('1', "Admin", MD5('adm'), 1, 1, 1);
INSERT INTO Usuarios VALUES ('2', "Almacen", MD5('alm'), 2, 2, 2);
INSERT INTO Usuarios VALUES ('3', "Ventas", MD5('vnt'), 1, 3, 1);
INSERT INTO Usuarios VALUES ('4', "Laura", MD5('lau'), 3, 4, 2);
INSERT INTO Usuarios VALUES ('5', "Carlos", MD5('car'), 2, 5, 1);

INSERT INTO Proveedores VALUES ('1','Refrescos Delicia', 12345678, 'Calle Primavera #123, Ciudad del Sol', 'ventas@refrescosdelicia.com');
INSERT INTO Proveedores VALUES ('2','Distribuidora de Golosinas', 98765432, 'Avenida Central #456, Barrio Nuevo', 'ventas@golosinasdistribuidora.com');
INSERT INTO Proveedores VALUES ('3','Suministros Industriales Hermanos Pérez', 32178904, 'Calle Industria #789, Zona Industrial', 'ventas@suministroshermanosperez.com');
INSERT INTO Proveedores VALUES ('4','Electrodomésticos Vargas', 56789012, 'Calle Tecnología #234, Urbanización Moderna', 'ventas@electrodomesticosvargas.com');
INSERT INTO Proveedores VALUES ('5','Distribuidora de Juguetes Felices', 87654321, 'Avenida de los Niños #567, Barrio Jardín', 'ventas@juguetesfelices.com');

INSERT INTO Productos VALUES ('PROD001', "Refresco de cola", '100', '1.99', "Refresco de cola en lata de 355ml", '1');
INSERT INTO Productos VALUES ('PROD002', "Bolsa de papas fritas", '150', '0.99', "Bolsa de papas fritas de 100g", '2');
INSERT INTO Productos VALUES ('PROD003', "Jabón de manos", '200', '2.49', "Jabón líquido para manos con aroma a manzana", '3');
INSERT INTO Productos VALUES ('PROD004', "Caja de dulces surtidos", '80', '5.99', "Caja de dulces surtidos, ideal para regalo", '4');
INSERT INTO Productos VALUES ('PROD005', "Lápiz de colores", '300', '3.49', "Paquete de 12 lápices de colores surtidos", '5');

INSERT INTO Ventas VALUES ('VENTA001', '2024-05-01 08:30:00', '4', 'PROD001', '25.99');
INSERT INTO Ventas VALUES ('VENTA002', '2024-05-02 10:15:00', '4', 'PROD003', '12.49');
INSERT INTO Ventas VALUES ('VENTA003', '2024-05-03 13:45:00', '5', 'PROD004, PROD005', '9.48');
INSERT INTO Ventas VALUES ('VENTA004', '2024-05-04 15:20:00', '3', 'PROD001, PROD003, PROD005', '21.47');
INSERT INTO Ventas VALUES ('VENTA005', '2024-05-05 17:00:00', '5', 'PROD002, PROD004', '15.98');


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
CREATE PROCEDURE LoginUsuario(IN user varchar(50), pass varchar(10))
BEGIN
SELECT *
FROM usuarios
WHERE usuarios.usuario=user AND usuarios.contrasena=pass;
END