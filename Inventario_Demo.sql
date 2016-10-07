/* DYNAMICS - Web, Mobile And Desktop Solutions */
/* Creado por: Brandon Castro */
USE master
DROP DATABASE Inventario_Demo 
GO
CREATE DATABASE Inventario_Demo 
GO
USE Inventario_Demo 
GO

CREATE TABLE Empresa (
	IdEmpresa INT IDENTITY (1, 1) NOT NULL,
	Nombre VARCHAR (100) NOT NULL,
	Licencia VARCHAR (25) NOT NULL,
	Pass VARCHAR (200) NOT NULL,
	Clave VARCHAR (25) NOT NULL,
	Sucursales INT NOT NULL,
	Estado BIT NOT NULL,
	Direccion VARCHAR (200) NOT NULL,
	Telefono VARCHAR (20) NOT NULL,
	Correo VARCHAR (20) NOT NULL,
	PRIMARY KEY (IdEmpresa)
);

CREATE TABLE Equipo (
	IdEquipo INT IDENTITY (1, 1) NOT NULL, 
	IdEmpresa INT NOT NULL,
	Serial VARCHAR (100) NOT NULL,
	CodigoEquipo VARCHAR (100) NOT NULL
	CONSTRAINT PK_Equipo PRIMARY KEY (IdEquipo),
	CONSTRAINT FK_Equipo_Empresa FOREIGN KEY (IdEmpresa) REFERENCES Empresa (IdEmpresa)
);

CREATE TABLE Sucursal (
	IdSucursal INT IDENTITY (1,1) NOT NULL,
	IdEmpresa INT NOT NULL,
	Nombre VARCHAR (80) NOT NULL,
	Ubicacion VARCHAR (200) NOT NULL,
	Telefono INT NOT NULL,
	CONSTRAINT PK_Sucursal PRIMARY KEY (IdSucursal),
	CONSTRAINT FK_Sucursal_Empresa FOREIGN KEY (IdEmpresa) REFERENCES Empresa (IdEmpresa)
);

CREATE TABLE Modulo (
	IdModulo INT IDENTITY(1,1),
	Nombre VARCHAR (80) NOT NULL,
	Descripcion VARCHAR (255) DEFAULT NULL,
	CONSTRAINT PK_Modulo PRIMARY KEY (IdModulo) 
);

CREATE TABLE Rol(
	IdRol INT IDENTITY(1,1),
	Nombre VARCHAR(255) NOT NULL,
	Descripcion VARCHAR(255) DEFAULT NULL,
	CONSTRAINT PK_Rol PRIMARY KEY (IdRol)
);

CREATE TABLE Rol_Modulo(
	IdRol INT NOT NULL,
	IdModulo INT NOT NULL
	PRIMARY KEY (IdRol, IdModulo),
	FOREIGN KEY (IdRol) REFERENCES Rol (IdRol),
	FOREIGN KEY (IdModulo) REFERENCES Modulo (IdModulo)
);

CREATE TABLE Empleado (
	IdEmpleado INT IDENTITY (1, 1) NOT NULL,
	Nombre VARCHAR (100) NOT NULL,
	Apellido VARCHAR (100) NOT NULL,
	Correo VARCHAR (100) DEFAULT NULL,
	Telefono VARCHAR (100) NOT NULL,
	Genero VARCHAR (15) NOT NULL,
	Direccion VARCHAR (200) NOT NULL,
	Comentario VARCHAR (200) DEFAULT NULL,
	Dpi VARCHAR (255) NOT NULL,
	CONSTRAINT PK_Empleado PRIMARY KEY (IdEmpleado)
);

CREATE TABLE Usuario(
	IdUsuario INT IDENTITY (1, 1) NOT NULL,
	IdRol INT NOT NULL,
	IdEmpleado INT NOT NULL,
	Nick VARCHAR (50) NOT NULL,
	Pass VARCHAR (120) NOT NULL,
	PRIMARY KEY(IdUsuario),
	CONSTRAINT PK_Usuario_Rol FOREIGN KEY (IdRol) REFERENCES Rol (IdRol),
	CONSTRAINT FK_Usuario_Empleado FOREIGN KEY (IdEmpleado) REFERENCES Empleado (IdEmpleado)
);

CREATE TABLE Cliente (
	IdCliente INT IDENTITY (1, 1) NOT NULL,
	Nombre VARCHAR (100) NOT NULL,
	Apellido VARCHAR (100) DEFAULT NULL,
	Correo VARCHAR (100) DEFAULT NULL,
	Telefono VARCHAR (20) DEFAULT NULL,
	Nit VARCHAR (10) DEFAULT NULL,
	Dpi VARCHAR (20) DEFAULT NULL,
	CONSTRAINT PK_Cliente PRIMARY KEY (IdCliente)
);

CREATE TABLE Proveedor (
	IdProveedor INT IDENTITY (1, 1) NOT NULL,
	CodigoProveedor VARCHAR (20) NOT NULL,
	RazonSocial VARCHAR (100) NOT NULL,
	DireccionPrincipal VARCHAR (200) NOT NULL,
	Direccion VARCHAR (200) DEFAULT NULL,
	Telefono VARCHAR (20) NOT NULL,
	Pbx VARCHAR (20) DEFAULT NULL,
	Correo VARCHAR (50) DEFAULT NULL,
	Nit VARCHAR (10) NOT NULL,
	PaginaWeb VARCHAR (200) DEFAULT NULL,
	CONSTRAINT PK_Proveedor PRIMARY KEY (IdProveedor)
);

CREATE TABLE Categoria (
	IdCategoria INT IDENTITY (1, 1) NOT NULL,
	Nombre VARCHAR (100) NOT NULL,
	Descripcion VARCHAR (200) NOT NULL,
	CONSTRAINT PK_Categoria PRIMARY KEY (IdCategoria)
);

CREATE TABLE Producto (
	IdProducto INT IDENTITY (1, 1) NOT NULL,
	IdCategoria INT NOT NULL,
	CodigoProducto VARCHAR (20) NOT NULL,
	Nombre VARCHAR (100) NOT NULL,
	Descripcion VARCHAR (200) DEFAULT NULL,
	Imagen VARCHAR (100) DEFAULT NULL,
	PrecioCompra DECIMAL (11, 2) DEFAULT NULL,
	PrecioUnitario DECIMAL (11, 2) NOT NULL,
	PrecioDocena DECIMAL (11, 2) DEFAULT 0.0,
	PrecioMayor DECIMAL (11, 2) DEFAULT 0.0,
	CONSTRAINT PK_Producto PRIMARY KEY (IdProducto),
	CONSTRAINT FK_Producto_Categoria FOREIGN KEY (IdCategoria) REFERENCES Categoria (IdCategoria)
);

CREATE TABLE Caja (
	IdCaja INT IDENTITY (1, 1) NOT NULL,
	IdUsuario INT NOT NULL,
	IdSucursal INT NOT NULL,
	SaldoInicial DECIMAL (11, 2) NOT NULL,
	Total DECIMAL (11, 2) NOT NULL,
	Fecha DATETIME NOT NULL,
	CONSTRAINT PK_Caja PRIMARY KEY (IdCaja),
	CONSTRAINT FK_Caja_Usuario FOREIGN KEY (IdUsuario) REFERENCES Usuario(IdUsuario),
	CONSTRAINT FK_Caja_Sucursal FOREIGN KEY (IdSucursal) REFERENCES Sucursal(IdSucursal)
);

CREATE TABLE Pedido (
	IdPedido INT IDENTITY (1, 1) NOT NULL,
	IdCliente INT NOT NULL,
	IdCaja INT NOT NULL,
	CodigoPedido VARCHAR (20) NOT NULL,
	FechaPedido DATE DEFAULT GETDATE(),
	FechaEntrega DATE NOT NULL,
	Estado INT NOT NULL,
	Total INT NOT NULL,
	CONSTRAINT PK_Pedido PRIMARY KEY (IdPedido),
	CONSTRAINT FK_Pedido_Cliente FOREIGN KEY (IdCliente) REFERENCES Cliente(IdCliente),
	CONSTRAINT PK_Pedido_Caja FOREIGN KEY (IdCaja) REFERENCES Caja (IdCaja)
);

CREATE TABLE Venta (
	IdVenta INT IDENTITY (1, 1) NOT NULL,
	IdPedido INT NOT NULL,
	IdCaja INT NOT NULL,
	Fecha DATETIME NOT NULL,
	CONSTRAINT PK_Venta PRIMARY KEY (IdVenta),
	CONSTRAINT FK_Venta_Pedido FOREIGN KEY (IdPedido) REFERENCES Pedido (IdPedido),
	CONSTRAINT FK_Venta_Caja FOREIGN KEY (IdCaja) REFERENCES Caja (IdCaja)
);

CREATE TABLE Compra (
	IdCompra INT IDENTITY (1, 1) NOT NULL,
	IdProveedor INT NOT NULL,
	IdCaja INT NOT NULL,
	Fecha DATE DEFAULT GETDATE(),
	Total INT NOT NULL,
	CONSTRAINT PK_Compra PRIMARY KEY (IdCompra),
	CONSTRAINT PK_Compra_Proveedor FOREIGN KEY (IdProveedor) REFERENCES Proveedor (IdProveedor),
	CONSTRAINT PK_Compra_Caja FOREIGN KEY (IdCaja) REFERENCES Caja (IdCaja)
);

CREATE TABLE Inventario (
	IdInventario INT IDENTITY (1, 1) NOT NULL,
	IdUsuario INT NOT NULL,
	Titulo VARCHAR (50) DEFAULT NULL,
	Fecha DATE NOT NULL,
	Estado BIT DEFAULT 1,
	Tipo VARCHAR (10) DEFAULT 'Compra', --Compra --Venta
	Entradas INT DEFAULT 0,
	Salidas INT DEFAULT 0,
	CONSTRAINT PK_Inventario PRIMARY KEY(IdInventario),
	CONSTRAINT FK_Inventario_Usuario FOREIGN KEY(IdUsuario) REFERENCES Usuario (IdUsuario)
);

CREATE TABLE Factura (
	IdFactura INT IDENTITY (1, 1) NOT NULL,
	IdCliente INT NOT NULL,
	IdCaja INT NOT NULL,
	NoFactura VARCHAR (100) NOT NULL,
	Serie VARCHAR (15) NOT NULL,
	Fecha DATE DEFAULT GETDATE(),
	Descripcion VARCHAR (255) DEFAULT NULL,
	Total DECIMAL (11, 2) DEFAULT 0.0,
	CONSTRAINT PK_Factura PRIMARY KEY (IdFactura),
	CONSTRAINT FK_Cliente_Factura FOREIGN KEY (IdCliente) REFERENCES Cliente (IdCliente), 
	CONSTRAINT FK_Factura_Caja FOREIGN KEY (IdCaja) REFERENCES Caja (IdCaja)
);

CREATE TABLE Producto_Factura(
	IdProducto INT NOT NULL,
	IdFactura INT NOT NULL,
	Cantidad INT DEFAULT 1,
	Precio DECIMAL (11, 2) NOT NULL,
	CONSTRAINT PK_Producto_Factura PRIMARY KEY (IdProducto, IdFactura),
	CONSTRAINT FK_Producto_Factura FOREIGN KEY (IdProducto) REFERENCES Producto (IdProducto),
	CONSTRAINT FK_Factura FOREIGN KEY (IdFactura) REFERENCES Factura (IdFactura)
);

CREATE TABLE Producto_Compra (
	IdCompra INT NOT NULL,
	IdProducto INT NOT NULL,
	Cantidad INT NOT NULL,
	Precio DECIMAL (11, 2) NOT NULL,
	CONSTRAINT PK_ProductoCompra PRIMARY KEY (IdCompra, IdProducto),
	CONSTRAINT FK_ProductoCompra_Producto FOREIGN KEY (IdProducto) REFERENCES Producto (IdProducto),
	CONSTRAINT FK_ProductoCompra_Compra FOREIGN KEY (IdCompra) REFERENCES Compra (IdCompra)
);

CREATE TABLE Producto_Inventario (
	IdProductoInventario INT IDENTITY (1, 1) NOT NULL,
	IdProducto INT NOT NULL,
	IdInventario INT NOT NULL,
	Cantidad INT DEFAULT 1,
	Tipo VARCHAR (1) DEFAULT 'C',--Compra --Venta
	CONSTRAINT PK_ProductoInventario PRIMARY KEY (IdProductoInventario),
	CONSTRAINT FK_ProductoInventario_Producto FOREIGN KEY (IdProducto) REFERENCES Producto (IdProducto),
	CONSTRAINT FK_ProductoInventario_Inventario FOREIGN KEY (IdInventario) REFERENCES Inventario (IdInventario)
);

CREATE TABLE Reporte (
	IdReporte INT IDENTITY (1, 1) NOT NULL,
	IdEmpresa INT NOT NULL,
	Nombre VARCHAR (50) NOT NULL,
	Descripcion VARCHAR (200) DEFAULT NULL,
	CONSTRAINT PK_Reporte PRIMARY KEY (IdReporte),
	CONSTRAINT FK_Reporte_Empresa FOREIGN KEY (IdEmpresa) REFERENCES Empresa (IdEmpresa)
);

--Empleado
--Usuario
--Rol



/* V 1.1 */