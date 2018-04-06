/* DYNAMICS - Web, Mobile And Desktop Solutions */
/* DYNAMICS PROGRESSIVE SYSTEMS */
/* Creado por: Brandon Castro */
/* Version en Ingles */
USE master
DROP DATABASE Inventario_Demo_En
GO
CREATE DATABASE Inventario_Demo_En
GO
USE Inventario_Demo_En
GO

CREATE TABLE Company (
	CompanyId INT IDENTITY (1, 1) NOT NULL,
	Name VARCHAR (100) NOT NULL,
	Licence VARCHAR (255) NOT NULL,
	Pass VARCHAR (200) NOT NULL,
	Code VARCHAR (255) NOT NULL,
	Branchs INT NOT NULL,
	Condition BIT NOT NULL,
	CompanyAddress VARCHAR (200) NOT NULL,
	Phone VARCHAR (20) NOT NULL,
	Email VARCHAR (20) NOT NULL,
	Nit VARCHAR (25) NOT NULL,
	CONSTRAINT PK_Company PRIMARY KEY (CompanyId)
);
GO 
CREATE TABLE Log_Company (
	CompanyId INT NULL,
	Name VARCHAR (100) NULL,
	Licence VARCHAR (255) NULL,
	Pass VARCHAR (200) NULL,
	Code VARCHAR (255) NULL,
	Branchs INT NULL,
	Condition BIT NULL,
	CompanyAddress VARCHAR (200) NULL,
	Phone VARCHAR (20) NULL,
	Email VARCHAR (20) NULL,
	Nit VARCHAR (25) NULL,
	--LOG
	LogDate DATETIME NULL,
	LogType VARCHAR (60) NULL,
	LogUser VARCHAR (60) NULL
);
GO
CREATE TRIGGER Log_Company_Trigger ON Company AFTER INSERT, UPDATE, DELETE
AS
SET NOCOUNT ON;
BEGIN
	INSERT INTO Log_Company (CompanyId, Name, Licence, Pass, Code, Branchs, 
		Condition, CompanyAddress, Phone, Email, Nit, LogDate, LogUser, LogType)
	SELECT
		D.CompanyId, D.Name, D.Licence, D.Pass, D.Code, D.Branchs,
		D.Condition, D.CompanyAddress, D.Phone, D.Email, D.Nit, GETDATE(), SYSTEM_USER,
		CASE WHEN I.CompanyId IS NULL THEN 'Eliminado' ELSE 'Modificado' END
	FROM
		DELETED D
		LEFT JOIN
		INSERTED I ON D.CompanyId = I.CompanyId
	UNION ALL
	SELECT
		I.CompanyId, I.Name, I.Licence, I.Pass, I.Code, I.Branchs,
		I.Condition, I.CompanyAddress, I.Phone, I.Email, I.Nit, GETDATE(), SYSTEM_USER, 'Insertado'
	FROM
		INSERTED I
		LEFT JOIN
		DELETED D ON D.CompanyId = I.CompanyId
	WHERE
		D.CompanyId IS NULL
END
GO
CREATE TABLE Equipment (
	EquipmentId INT IDENTITY (1, 1) NOT NULL, 
	CompanyId INT NOT NULL,
	Serial VARCHAR (100) NOT NULL,
	EquipmentCode VARCHAR (100) NOT NULL
	CONSTRAINT PK_Equipment PRIMARY KEY (EquipmentId),
	CONSTRAINT FK_Equipmet_Company FOREIGN KEY (CompanyId) REFERENCES Company (CompanyId)
);
GO
CREATE TABLE Log_Equipment (
	EquipmentId INT NULL, 
	CompanyId INT NULL,
	Serial VARCHAR (100) NULL,
	EquipmentCode VARCHAR (100) NULL,
	-- LOG
	LogDate DATETIME NULL,
	LogType VARCHAR (60) NULL,
	LogUser VARCHAR (60) NULL
);
GO
CREATE TRIGGER Log_Equipment_Trigger ON Equipment AFTER INSERT, UPDATE, DELETE
AS
SET NOCOUNT ON;
BEGIN
	INSERT INTO Log_Equipment (EquipmentId, CompanyId, Serial, EquipmentCode, LogDate, LogUser, LogType)
	SELECT
		D.EquipmentId, D.CompanyId, D.Serial, D.EquipmentCode, GETDATE(), SYSTEM_USER,
		CASE WHEN I.CompanyId IS NULL THEN 'Eliminado' ELSE 'Modificado' END
	FROM
		DELETED D
		LEFT JOIN
		INSERTED I ON D.EquipmentId = I.EquipmentId
	UNION ALL
	SELECT
		I.EquipmentId, I.CompanyId, I.Serial, I.EquipmentCode, GETDATE(), SYSTEM_USER, 'Insertado'
	FROM
		INSERTED I
		LEFT JOIN
		DELETED D ON D.EquipmentId = I.EquipmentId
	WHERE
		D.EquipmentId IS NULL
END
GO
CREATE TABLE BranchOffice (
	BranchOfficeId INT IDENTITY (1,1) NOT NULL,
	CompanyId INT NOT NULL,
	Name VARCHAR (80) NOT NULL,
	Direction VARCHAR (200) NOT NULL,
	Phone VARCHAR (100) DEFAULT NULL,
	CreationDate DATETIME DEFAULT GETDATE(),
	ModificationDate DATETIME DEFAULT GETDATE(),
	CONSTRAINT PK_BranchOffice PRIMARY KEY (BranchOfficeId),
	CONSTRAINT FK_BranchOffice_Company FOREIGN KEY (CompanyId) REFERENCES Company (CompanyId)
);
GO
CREATE TABLE Log_BranchOffice (
	BranchOfficeId INT NULL,
	CompanyId INT NULL,
	Name VARCHAR (80) NULL,
	Direction VARCHAR (200) NULL,
	Phone VARCHAR (100) NULL,
	CreationDate DATETIME NULL,
	ModificationDate DATETIME NULL,
	-- LOG
	LogDate DATETIME NULL,
	LogType VARCHAR (60) NULL,
	LogUser VARCHAR (60) NULL
);
GO
CREATE TRIGGER Log_BranchOffice_Trigger ON BranchOffice AFTER INSERT, UPDATE, DELETE
AS
SET NOCOUNT ON;
BEGIN
	INSERT INTO Log_BranchOffice(BranchOfficeId, CompanyId, Name, Direction, Phone, 
		CreationDate, ModificationDate,LogDate, LogUser, LogType)
	SELECT
		D.BranchOfficeId, D.CompanyId, D.Name, D.Direction, D.Phone, D.CreationDate,
		D.ModificationDate, GETDATE(), SYSTEM_USER,
		CASE WHEN I.BranchOfficeId IS NULL THEN 'Eliminado' ELSE 'Modificado' END
	FROM
		DELETED D
		LEFT JOIN
		INSERTED I ON D.BranchOfficeId = I.BranchOfficeId
	UNION ALL
	SELECT
		I.BranchOfficeId, I.CompanyId, I.Name, I.Direction, I.Phone, I.CreationDate,
		I.ModificationDate, GETDATE(), SYSTEM_USER, 'Insertado'
	FROM
		INSERTED I
		LEFT JOIN
		DELETED D ON D.BranchOfficeId = I.BranchOfficeId
	WHERE
		D.BranchOfficeId IS NULL
END
GO
CREATE TABLE Module (
	ModuleId INT IDENTITY(1,1) NOT NULL,
	Name VARCHAR (80) NOT NULL,
	Explanation VARCHAR (255) DEFAULT NULL,
	CONSTRAINT PK_Module PRIMARY KEY (ModuleId) 
);
GO
CREATE TABLE Log_Module (
	ModuleId INT NULL,
	Name VARCHAR (80)  NULL,
	Explanation VARCHAR (255) NULL,
	-- LOG
	LogDate DATETIME NULL,
	LogType VARCHAR (60) NULL,
	LogUser VARCHAR (60) NULL
);
GO
CREATE TRIGGER Log_Module_Trigger ON Module AFTER INSERT, UPDATE, DELETE
AS
SET NOCOUNT ON;
BEGIN
	INSERT INTO Log_Module (ModuleId, Name, Explanation, LogDate, LogUser, LogType)
	SELECT
		D.ModuleId, D.Name, D.Explanation, GETDATE(), SYSTEM_USER, 
		CASE WHEN I.ModuleId IS NULL THEN 'Eliminado' ELSE 'Modificado' END
	FROM
		DELETED D
		LEFT JOIN
		INSERTED I ON D.ModuleId = I.ModuleId
	UNION ALL
	SELECT 
		I.ModuleId, I.Name, I.Explanation, GETDATE(), SYSTEM_USER, 'Insertado'
	FROM
		INSERTED I
		LEFT JOIN
		DELETED D ON D.ModuleId = I.ModuleId
	WHERE
		D.ModuleId IS NULL
END
GO
CREATE TABLE Rol (
	RolId INT IDENTITY (1, 1) NOT NULL,
	Name VARCHAR(255) NOT NULL,
	Explanation VARCHAR(255) DEFAULT NULL,
	CONSTRAINT PK_Rol PRIMARY KEY (RolId)
);
GO
CREATE TABLE Log_Rol (
	RolId INT NULL,
	Name VARCHAR(255) NULL,
	Explanation VARCHAR(255) NULL,
	-- LOG
	LogDate DATETIME NULL,
	LogType VARCHAR (60) NULL,
	LogUser VARCHAR (60) NULL
);
GO
CREATE TRIGGER Log_Rol_Trigger ON Rol AFTER INSERT, UPDATE, DELETE
AS
SET NOCOUNT ON;
BEGIN
	INSERT INTO Log_Rol (RolId, Name, Explanation, LogDate, LogUser, LogType)
	SELECT
		D.RolId, D.Name, D.Explanation, GETDATE(), SYSTEM_USER,
		CASE WHEN I.RolId IS NULL THEN 'Eliminado' ELSE 'Modificado' END
	FROM
		DELETED D
		LEFT JOIN
		INSERTED I ON D.RolId = I.RolId
	UNION ALL
	SELECT 
		I.RolId, I.Name, I.Explanation, GETDATE(), SYSTEM_USER, 'Insertado'
	FROM
		INSERTED I
		LEFT JOIN
		DELETED D ON D.RolId = I.RolID
	WHERE
		D.RolId IS NULL
END
GO
CREATE TABLE Rol_Module (
	RolId INT NOT NULL,
	ModuleId INT NOT NULL,
	PRIMARY KEY (RolId, ModuleId),
	FOREIGN KEY (RolId) REFERENCES Rol (RolId),
	FOREIGN KEY (ModuleId) REFERENCES Module (ModuleId)
);
GO
CREATE TABLE Log_Rol_Module (
	RolId INT NULL,
	ModuleId INT NULL,
	-- LOG
	LogDate DATETIME NULL,
	LogType VARCHAR (60) NULL,
	LogUser VARCHAR (60) NULL
);
GO
CREATE TRIGGER Log_Rol_Module_Trigger ON Rol_Module AFTER INSERT, UPDATE, DELETE
AS
SET NOCOUNT ON;
BEGIN
	INSERT INTO Log_Rol_Module(RolId, ModuleId, LogDate, LogUser, LogType)
	SELECT
		D.RolId, D.ModuleId, GETDATE(), SYSTEM_USER,
		CASE WHEN I.RolId IS NULL AND I.ModuleId IS NULL THEN 'Eliminado' ELSE 'Modificado' END
	FROM
		DELETED D
		LEFT JOIN
		INSERTED I ON D.RolId = I.RolId AND D.ModuleId = I.ModuleId
	UNION ALL
	SELECT
		I.RolId, I.ModuleId, GETDATE(), SYSTEM_USER, 'Insertado'
	FROM
		INSERTED I
		LEFT JOIN
		DELETED D ON D.RolId = I.RolId AND D.ModuleId = I.ModuleId
	WHERE
		D.ModuleId IS NULL AND I.RolId IS NULL
END
GO
CREATE TABLE Employee (
	EmployeeId INT IDENTITY (1, 1) NOT NULL,
	Name VARCHAR (100) NOT NULL,
	LastName VARCHAR (100) NOT NULL,
	Email VARCHAR (100) DEFAULT NULL,
	Phone VARCHAR (100) DEFAULT NULL,
	Gender VARCHAR (15) NOT NULL,
	Direction VARCHAR (200) DEFAULT NULL,
	Comment VARCHAR (200) DEFAULT NULL,
	Dpi VARCHAR (255) NOT NULL,
	BirthDate DATE DEFAULT NULL,
	CreationDate DATETIME DEFAULT GETDATE(),
	ModificationDate DATETIME DEFAULT GETDATE(),
	CONSTRAINT PK_Employee PRIMARY KEY (EmployeeId)
);
GO
CREATE TABLE Log_Employee (
	EmployeeId INT NULL,
	Name VARCHAR (100) NULL,
	LastName VARCHAR (100) NULL,
	Email VARCHAR (100) NULL,
	Phone VARCHAR (100) NULL,
	Gender VARCHAR (15) NULL,
	Direction VARCHAR (200) NULL,
	Comment VARCHAR (200) NULL,
	Dpi VARCHAR (255) NULL,
	BirthDate DATE NULL,
	CreationDate DATETIME NULL,
	ModificationDate DATETIME NULL,
	-- LOG
	LogDate DATETIME NULL,
	LogType VARCHAR (60) NULL,
	LogUser VARCHAR (60) NULL
);
GO
CREATE TRIGGER Log_Employee_Trigger ON Employee AFTER INSERT, UPDATE, DELETE
AS
SET NOCOUNT ON;
BEGIN
	INSERT INTO Log_Employee(EmployeeId, Name, LastName, Email, Phone, Gender, Direction,
		Comment, Dpi, BirthDate, CreationDate, ModificationDate, LogDate, LogUser, LogType)
	SELECT
		D.EmployeeId, D.Name, D.LastName, D.Email, D.Phone, D.Gender, D.Direction, D.Comment,
		D.Dpi, D.BirthDate, D.CreationDate, D.ModificationDate, GETDATE(), SYSTEM_USER,
		CASE WHEN I.EmployeeId IS NULL THEN 'Eliminado' ELSE 'Modificado' END
	FROM 
		DELETED D
		LEFT JOIN
		INSERTED I ON D.EmployeeId = I.EmployeeId
	UNION ALL
	SELECT
		I.EmployeeId, I.Name, I.LastName, I.Email, I.Phone, I.Gender, I.Direction, I.Comment,
		I.Dpi, I.BirthDate, I.CreationDate, I.ModificationDate, GETDATE(), SYSTEM_USER, 'Insertado'
	FROM
		INSERTED I
		LEFT JOIN
		DELETED D ON D.EmployeeId = I.EmployeeId
	WHERE
		D.EmployeeId IS NULL
END
GO
CREATE TABLE Reader (
	ReaderId INT IDENTITY (1, 1) NOT NULL,
	RolId INT NOT NULL,
	EmployeeId INT NOT NULL,
	Nick VARCHAR (50) NOT NULL,
	Pass VARCHAR (120) NOT NULL,
	CreationDate DATETIME DEFAULT GETDATE(),
	ModificationDate DATETIME DEFAULT GETDATE(),
	PRIMARY KEY(ReaderId),
	CONSTRAINT PK_Reader_Rol FOREIGN KEY (RolId) REFERENCES Rol (RolId),
	CONSTRAINT FK_Reader_Employee FOREIGN KEY (EmployeeId) REFERENCES Employee (EmployeeId)
);
GO
CREATE TABLE Log_Reader (
	ReaderId INT NULL,
	RolId INT NULL,
	EmployeeId INT NULL,
	Nick VARCHAR (50) NULL,
	Pass VARCHAR (120) NULL,
	CreationDate DATETIME NULL,
	ModificationDate DATETIME NULL,
	-- LOG
	LogDate DATETIME NULL,
	LogType VARCHAR (60) NULL,
	LogUser VARCHAR (60) NULL
);
GO
CREATE TRIGGER Log_Reader_Trigger ON Reader AFTER INSERT, UPDATE, DELETE
AS
SET NOCOUNT ON;
BEGIN
	INSERT INTO Log_Reader (ReaderId, RolId, EmployeeId, Nick, Pass, CreationDate, ModificationDate, LogDate, LogUser, LogType)
	SELECT 
		D.ReaderId, D.RolId, D.EmployeeId, D.Nick, D.Pass, D.CreationDate, D.ModificationDate, GETDATE(), SYSTEM_USER,
		CASE WHEN I.ReaderId IS NULL THEN 'Eliminado' ELSE 'Modificado' END
	FROM
		DELETED D
		LEFT JOIN
		INSERTED I ON D.ReaderId = I.ReaderId
	UNION ALL
	SELECT
		I.ReaderId, I.RolId, I.EmployeeId, I.Nick, I.Pass, I.CreationDate, I.ModificationDate, GETDATE(), SYSTEM_USER, 'Insertado'
	FROM
		INSERTED I
		LEFT JOIN
		DELETED D ON D.ReaderId = I.ReaderId
	WHERE
		D.ReaderId IS NULL
END
GO
CREATE TABLE Customer (
	CustomerId INT IDENTITY (1, 1) NOT NULL,
	CustomerCode VARCHAR (20) DEFAULT NULL,
	Name VARCHAR (100) NOT NULL,
	LastName VARCHAR (100) DEFAULT NULL,
	Email VARCHAR (100) DEFAULT NULL,
	Phone VARCHAR (20) DEFAULT NULL,
	Direction VARCHAR (100) DEFAULT NULL,
	Nit VARCHAR (10) DEFAULT NULL,
	Dpi VARCHAR (20) DEFAULT NULL,
	CreationDate DATETIME DEFAULT GETDATE(),
	ModificationDate DATETIME DEFAULT GETDATE(),
	CONSTRAINT PK_Customer PRIMARY KEY (CustomerId)
);
GO
CREATE TABLE Log_Customer (
	CustomerId INT NULL,
	CustomerCode VARCHAR (20) NULL,
	Name VARCHAR (100) NULL,
	LastName VARCHAR (100) NULL,
	Email VARCHAR (100) NULL,
	Phone VARCHAR (20) NULL,
	Direction VARCHAR (100) NULL,
	Nit VARCHAR (10) NULL,
	Dpi VARCHAR (20) NULL,
	CreationDate DATETIME NULL,
	ModificationDate DATETIME NULL,
	-- LOG
	LogDate DATETIME NULL,
	LogType VARCHAR (60) NULL,
	LogUser VARCHAR (60) NULL
);
GO
CREATE TRIGGER Log_Customer_Trigger ON Customer AFTER INSERT, UPDATE, DELETE
AS
SET NOCOUNT ON;
BEGIN
	INSERT INTO Log_Customer (CustomerId, CustomerCode, Name, LastName, Email,
		Phone, Direction, Nit, Dpi, CreationDate, ModificationDate, LogDate, LogUser, LogType)
	SELECT
		D.CustomerId, D.CustomerCode, D.Name, D.LastName, D.Email, D.Phone, D.Direction,
		D.Nit, D.Dpi, D.CreationDate, D.ModificationDate, GETDATE(), SYSTEM_USER,
		CASE WHEN I.CustomerId IS NULL THEN 'Eliminado' ELSE 'Modificado' END
	FROM 
		DELETED D
		LEFT JOIN
		INSERTED I ON D.CustomerId = I.CustomerId
	UNION ALL
	SELECT 
		I.CustomerId, I.CustomerCode, I.Name, I.LastName, I.Email, I.Phone, I.Direction,
		I.Nit, I.Dpi, I.CreationDate, I.ModificationDate, GETDATE(), SYSTEM_USER, 'Insertado'
	FROM 
		INSERTED I
		LEFT JOIN
		DELETED D ON D.CustomerId = I.CustomerId
	WHERE
		D.CustomerId IS NULL
END
GO
CREATE TABLE Provider (
	ProviderId INT IDENTITY (1, 1) NOT NULL,
	ProviderCode VARCHAR (20) DEFAULT NULL,
	BusinessName VARCHAR (100) NOT NULL,
	PrincipalAddress VARCHAR (200) NOT NULL,
	Direction VARCHAR (200) DEFAULT NULL,
	Phone VARCHAR (20) DEFAULT NULL,
	Pbx VARCHAR (20) DEFAULT NULL,
	Email VARCHAR (50) DEFAULT NULL,
	Nit VARCHAR (10) NOT NULL,
	WebPage VARCHAR (200) DEFAULT NULL,
	Explanation VARCHAR (200) DEFAULT NULL,
	CreationDate DATETIME DEFAULT GETDATE(),
	ModificationDate DATETIME DEFAULT GETDATE(),
	CONSTRAINT PK_Provider PRIMARY KEY (ProviderId)
);
GO
CREATE TABLE Log_Provider (
	ProviderId INT NULL,
	ProviderCode VARCHAR (20) NULL,
	BusinessName VARCHAR (100) NULL,
	PrincipalAddress VARCHAR (200) NULL,
	Direction VARCHAR (200) NULL,
	Phone VARCHAR (20) NULL,
	Pbx VARCHAR (20) NULL,
	Email VARCHAR (50) NULL,
	Nit VARCHAR (10) NULL,
	WebPage VARCHAR (200) NULL,
	Explanation VARCHAR (200) NULL,
	CreationDate DATETIME NULL,
	ModificationDate DATETIME NULL,
	-- LOG
	LogDate DATETIME NULL,
	LogType VARCHAR (60) NULL,
	LogUser VARCHAR (60) NULL
);
GO
CREATE TRIGGER Log_Provider_Trigger ON Provider AFTER INSERT, UPDATE, DELETE
AS
SET NOCOUNT ON;
BEGIN
	INSERT INTO Log_Provider (ProviderId, ProviderCode, BusinessName, PrincipalAddress, Direction,
		Phone, Pbx, Email, Nit, WebPage, Explanation, CreationDate, ModificationDate, LogDate, LogUser, LogType)
	SELECT
		D.ProviderId, D.ProviderCode, D.BusinessName, D.PrincipalAddress, D.Direction, D.Phone, D.Pbx, D.Email, D.Nit,
		D.WebPage,D.Explanation,D.CreationDate,D.ModificationDate, GETDATE(), SYSTEM_USER,
		CASE WHEN I.ProviderId IS NULL THEN 'Eliminado' ELSE 'Modificado' END
	FROM
		DELETED D
		LEFT JOIN
		INSERTED I ON D.ProviderId = I.ProviderId
	UNION ALL
	SELECT 
		I.ProviderId, I.ProviderCode, I.BusinessName, I.PrincipalAddress, I.Direction, I.Phone, I.Pbx, I.Email, 
		I.Nit, I.WebPage, I.Explanation, I.CreationDate, I.ModificationDate, GETDATE(), SYSTEM_USER, 'Insertado'
	FROM 
		INSERTED I
		LEFT JOIN
		DELETED D ON D.ProviderId = I.ProviderId
	WHERE
		D.ProviderId IS NULL 
END
GO
CREATE TABLE Category (
	CategoryId INT IDENTITY (1, 1) NOT NULL,
	Name VARCHAR (100) NOT NULL,
	Explanation VARCHAR (200) DEFAULT NULL,
	CreationDate DATETIME DEFAULT GETDATE(),
	ModificationDate DATETIME DEFAULT GETDATE(),
	CONSTRAINT PK_Category PRIMARY KEY (CategoryId)
);
GO
CREATE TABLE Log_Category (
	CategoryId INT NULL,
	Name VARCHAR (100) NULL,
	Explanation VARCHAR (200) NULL,
	CreationDate DATETIME NULL,
	ModificationDate DATETIME NULL,
	-- LOG
	LogDate DATETIME NULL,
	LogType VARCHAR (60) NULL,
	LogUser VARCHAR (60) NULL
);
GO
CREATE TRIGGER Log_Category_Trigger ON Category AFTER INSERT, UPDATE, DELETE
AS
SET NOCOUNT ON;
BEGIN
	INSERT INTO Log_Category (CategoryId, Name, Explanation, CreationDate, ModificationDate,
		LogDate, LogUser, LogType)
	SELECT 
		D.CategoryId, D.Name, D.Explanation, D.CreationDate, D.ModificationDate, GETDATE(), SYSTEM_USER,
		CASE WHEN I.CategoryId IS NULL THEN 'Eliminado' ELSE 'Modificado' END
	FROM
		DELETED D
		LEFT JOIN	
		INSERTED I ON D.CategoryId = I.CategoryId
	UNION ALL
	SELECT
		I.CategoryId, I.Name, I.Explanation, I.CreationDate, I.ModificationDate, GETDATE(), SYSTEM_USER,
		'Insertado'
	FROM
		INSERTED I
		LEFT JOIN
		DELETED D ON D.CategoryId = I.CategoryId
	WHERE
		I.CategoryId IS NULL
END
GO
CREATE TABLE Product (
	ProductId INT IDENTITY (1, 1) NOT NULL,
	CategoryId INT NOT NULL,
	ProductCode VARCHAR (20) DEFAULT NULL,
	Name VARCHAR (100) NOT NULL,
	Explanation VARCHAR (200) DEFAULT NULL,
	ImageSrc VARCHAR (100) DEFAULT NULL,
	PurchasePrice DECIMAL (11, 2) DEFAULT NULL,
	UnitPrice DECIMAL (11, 2) NOT NULL,
	PricePerDozen DECIMAL (11, 2) DEFAULT 0.0,
	WholesalePrice DECIMAL (11, 2) DEFAULT 0.0,
	AddedDate DATETIME DEFAULT NULL,
	Tag VARCHAR (50) DEFAULT NULL,
	Review VARCHAR (50) DEFAULT NULL,
	AditionalInformation VARCHAR (100) DEFAULT NULL,
	Help VARCHAR (200) DEFAULT NULL,
	CreationDate DATETIME DEFAULT GETDATE(),
	ModificationDate DATETIME DEFAULT GETDATE(),
	CONSTRAINT PK_Product PRIMARY KEY (ProductId),
	CONSTRAINT FK_Product_Category FOREIGN KEY (CategoryId) REFERENCES Category (CategoryId)
);
GO
CREATE TABLE Log_Product (
	ProductId INT NULL,
	CategoryId INT NULL,
	ProductCode VARCHAR (20) NULL,
	Name VARCHAR (100) NULL,
	Explanation VARCHAR (200) NULL,
	ImageSrc VARCHAR (100) NULL,
	PurchasePrice DECIMAL (11, 2) NULL,
	UnitPrice DECIMAL (11, 2) NULL,
	PricePerDozen DECIMAL (11, 2) NULL,
	WholesalePrice DECIMAL (11, 2) NULL,
	AddedDate DATETIME NULL,
	Tag VARCHAR (50) NULL,
	Review VARCHAR (50) NULL,
	AditionalInformation VARCHAR (100) NULL,
	Help VARCHAR (200) NULL,
	CreationDate DATETIME NULL,
	ModificationDate DATETIME NULL,
	-- LOG
	LogDate DATETIME NULL,
	LogType VARCHAR (60) NULL,
	LogUser VARCHAR (60) NULL
);
GO
CREATE TRIGGER Log_Product_Trigger ON Product AFTER INSERT, UPDATE, DELETE
AS
SET NOCOUNT ON;
BEGIN
	INSERT INTO Log_Product(ProductId, CategoryId, ProductCode, Name, Explanation, ImageSrc, PurchasePrice,
		UnitPrice, PricePerDozen, WholesalePrice, AddedDate, Tag, Review, AditionalInformation, Help, CreationDate,
		ModificationDate, LogDate, LogUser, LogType)
	SELECT 
		D.ProductId, D.CategoryId, D.ProductCode, D.Name, D.Explanation, D.ImageSrc, D.PurchasePrice,
		D.UnitPrice, D.PricePerDozen, D.WholesalePrice, D.AddedDate, D.Tag, D.Review, D.AditionalInformation, 
		D.Help, D.CreationDate, D.ModificationDate, GETDATE(), SYSTEM_USER,
		CASE WHEN I.ProductId IS NULL THEN 'Eliminado' ELSE 'Modificado' END
	FROM 
		DELETED D
		INNER JOIN 
		INSERTED I ON D.ProductId = I.ProductId
	UNION ALL
	SELECT
		I.ProductId, I.CategoryId, I.ProductCode, I.Name, I.Explanation, I.ImageSrc, I.PurchasePrice,
		I.UnitPrice, I.PricePerDozen, I.WholesalePrice, I.AddedDate, I.Tag, I.Review, I.AditionalInformation, 
		I.Help, I.CreationDate, I.ModificationDate, GETDATE(), SYSTEM_USER, 'Insertado'
	FROM 
		INSERTED I
		INNER JOIN 
		DELETED D ON D.ProductId = I.ProductId
	WHERE
		I.ProductId IS NULL
END
GO
CREATE TABLE Checkout (
	CheckoutId INT IDENTITY (1, 1) NOT NULL,
	ReaderId INT NOT NULL,
	BranchOfficeId INT NOT NULL,
	Balance DECIMAL (11, 2) NOT NULL,
	Total DECIMAL (11, 2) NOT NULL,
	CheckoutDate DATETIME NOT NULL,
	CreationDate DATETIME DEFAULT GETDATE(),
	ModificationDate DATETIME DEFAULT GETDATE(),
	CONSTRAINT PK_Checkout PRIMARY KEY (CheckoutId),
	CONSTRAINT FK_Checkout_Reader FOREIGN KEY (ReaderId) REFERENCES Reader (ReaderId),
	CONSTRAINT FK_Checkout_BranchOffice FOREIGN KEY (BranchOfficeId) REFERENCES BranchOffice (BranchOfficeId)
);
GO
CREATE TABLE Log_Checkout (
	CheckoutId INT  NULL,
	ReaderId INT NULL,
	BranchOfficeId INT NULL,
	Balance DECIMAL (11, 2) NULL,
	Total DECIMAL (11, 2) NULL,
	CheckoutDate DATETIME NULL,
	CreationDate DATETIME NULL,
	ModificationDate DATETIME NULL,
	-- LOG
	LogDate DATETIME NULL,
	LogType VARCHAR (60) NULL,
	LogUser VARCHAR (60) NULL
);
GO
CREATE TRIGGER Log_Checkout_Trigger ON Checkout AFTER INSERT, UPDATE, DELETE
AS
SET NOCOUNT ON;
BEGIN
	INSERT INTO Log_Checkout (CheckoutId, ReaderId, BranchOfficeId, Balance, Total, CheckoutDate,
		CreationDate, ModificationDate, LogDate, LogUser, LogType)
	SELECT
		D.CheckoutId, D.ReaderId, D.BranchOfficeId, D.Balance, D.Total, D.CheckoutDate,
		D.CreationDate, D.ModificationDate, GETDATE(), SYSTEM_USER, 
		CASE WHEN I.CheckoutId IS NULL THEN 'Eliminado' ELSE 'Modificado' END
	FROM
		DELETED D
		LEFT JOIN
		INSERTED I ON D.CheckoutId = I.CheckoutId
	UNION ALL
	SELECT 
		I.CheckoutId, I.ReaderId, I.BranchOfficeId, I.Balance, I.Total, I.CheckoutDate,
		I.CreationDate, I.ModificationDate, GETDATE(), SYSTEM_USER, 'Insertado'
	FROM 
		INSERTED I
		LEFT JOIN
		DELETED D ON D.CheckoutId = I.CheckoutId
	WHERE
		I.CheckoutId IS NULL
END
GO
CREATE TABLE CashOrder (
	CashOrderId INT IDENTITY (1, 1) NOT NULL,
	CustomerId INT NOT NULL,
	CheckoutId INT NOT NULL,
	CashOrderCode VARCHAR (20) NOT NULL,
	OrderDate DATETIME DEFAULT GETDATE(),
	DeliveryDate DATE NOT NULL,
	OrderStatus INT NOT NULL,
	Total INT NOT NULL,
	CreationDate DATETIME DEFAULT GETDATE(),
	ModificationDate DATETIME DEFAULT GETDATE(),
	CONSTRAINT PK_CashOrder PRIMARY KEY (CashOrderId),
	CONSTRAINT FK_CashOrder_Customer FOREIGN KEY (CustomerId) REFERENCES Customer (CustomerId),
	CONSTRAINT FK_CashOrder_Checkout FOREIGN KEY (CheckoutId) REFERENCES Checkout (CheckoutId)
);
GO
CREATE TABLE Log_CashOrder (
	CashOrderId INT NULL,
	CustomerId INT NULL,
	CheckoutId INT NULL,
	CashOrderCode VARCHAR (20) NULL,
	OrderDate DATE NULL,
	DeliveryDate DATE NULL,
	OrderStatus INT NULL,
	Total INT NULL,
	CreationDate DATETIME NULL,
	ModificationDate DATETIME NULL,
	-- LOG
	LogDate DATETIME NULL,
	LogType VARCHAR (60) NULL,
	LogUser VARCHAR (60) NULL
);
GO
CREATE TRIGGER Log_CashOrder_Trigger ON CashOrder AFTER INSERT, UPDATE, DELETE
AS
SET NOCOUNT ON;
BEGIN
	INSERT INTO Log_CashOrder(CashOrderId, CustomerId, CheckoutId, CashOrderCode, OrderDate, OrderStatus,
		Total, CreationDate, ModificationDate, LogDate, LogUser, LogType)
	SELECT 
		D.CashOrderId, D.CustomerId, D.CheckoutId, D.CashOrderCode, D.OrderDate, D.OrderStatus,
		D.Total, D.CreationDate, D.ModificationDate, GETDATE(), SYSTEM_USER, 
		CASE WHEN I.CashOrderId IS NULL THEN 'Eliminado' ELSE 'Modificado' END
	FROM
		DELETED D
		LEFT JOIN
		INSERTED I ON D.CashOrderId = I.CashOrderId
	UNION ALL
	SELECT
		I.CashOrderId, I.CustomerId, I.CheckoutId, I.CashOrderCode, I.OrderDate, I.OrderStatus,
		I.Total, I.CreationDate, I.ModificationDate, GETDATE(), SYSTEM_USER, 'Insertado'
	FROM 
		INSERTED I
		LEFT JOIN
		DELETED D ON D.CashOrderId = I.CashOrderId
	WHERE
		D.CashOrderId IS NULL
END
GO
CREATE TABLE Sale (
	SaleId INT IDENTITY (1, 1) NOT NULL,
	CashOrderId INT NOT NULL,
	CheckoutId INT NOT NULL,
	SaleDate DATETIME DEFAULT GETDATE(),
	CONSTRAINT PK_Sale PRIMARY KEY (SaleId),
	CONSTRAINT FK_Sale_CashOrder FOREIGN KEY (CashOrderId) REFERENCES CashOrder (CashOrderId),
	CONSTRAINT FK_Sale_Checkout FOREIGN KEY (CheckoutId) REFERENCES Checkout (CheckoutId)
);
GO
CREATE TABLE Log_Sale (
	SaleId INT NULL,
	CashOrderId INT NULL,
	CheckoutId INT NULL,
	SaleDate DATETIME NULL,
	-- LOG
	LogDate DATETIME NULL,
	LogType VARCHAR (60) NULL,
	LogUser VARCHAR (60) NULL
);
GO
CREATE TRIGGER Log_Sale_Trigger ON Sale AFTER INSERT, UPDATE, DELETE
AS
SET NOCOUNT ON;
BEGIN
	INSERT INTO Log_Sale (SaleId, CashOrderId, CheckoutId, SaleDate, LogDate, LogUser, LogType)
	SELECT
		D.SaleId, D.CashOrderId, D.CheckoutId, D.SaleDate, GETDATE(), SYSTEM_USER,
		CASE WHEN I.SaleId IS NULL THEN 'Eliminado' ELSE 'Modificado' END
	FROM
		DELETED D
		LEFT JOIN
		INSERTED I ON D.SaleId = I.SaleId
	UNION ALL
	SELECT
		I.SaleId, I.CashOrderId, I.CheckoutId, I.SaleDate, GETDATE(), SYSTEM_USER, 'Insertado'
	FROM
		INSERTED I
		LEFT JOIN
		DELETED D ON D.SaleId = I.SaleId
	WHERE
		D.SaleId IS NULL
END
GO
CREATE TABLE Purchase (
	PurchaseId INT IDENTITY (1, 1) NOT NULL,
	ProviderId INT NOT NULL,
	CheckoutId INT NOT NULL,
	PurchaseDate DATE DEFAULT GETDATE(),
	Total INT NOT NULL,
	CONSTRAINT PK_Purchase PRIMARY KEY (PurchaseId),
	CONSTRAINT FK_Purchase_Provider FOREIGN KEY (ProviderId) REFERENCES Provider (ProviderId),
	CONSTRAINT FK_Purchase_Checkout FOREIGN KEY (CheckoutId) REFERENCES CheckOut (CheckoutId)
);
GO
CREATE TABLE Log_Purchase (
	PurchaseId INT NULL,
	ProviderId INT NULL,
	CheckoutId INT NULL,
	PurchaseDate DATE NULL,
	Total INT NULL,
	-- LOG
	LogDate DATETIME NULL,
	LogType VARCHAR (60) NULL,
	LogUser VARCHAR (60) NULL
);
GO
CREATE TRIGGER Log_Purchase_Trigger ON Purchase AFTER INSERT, UPDATE, DELETE
AS
SET NOCOUNT ON;
BEGIN
	INSERT INTO Log_Purchase (PurchaseId, ProviderId, CheckoutId, PurchaseDate, Total,
		LogDate, LogUser, LogType)
	SELECT
		D.PurchaseId, D.ProviderId, D.CheckoutId, D.PurchaseDate, D.Total, GETDATE(), SYSTEM_USER,
		CASE WHEN I.PurchaseId IS NULL THEN 'Eliminado' ELSE 'Modificado' END
	FROM
		DELETED D
		LEFT JOIN
		INSERTED I ON D.PurchaseId = I.PurchaseId
	UNION ALL
	SELECT
		I.PurchaseId, I.ProviderId, I.CheckoutId, I.PurchaseDate, I.Total, GETDATE(), SYSTEM_USER, 'Insertado'
	FROM
		INSERTED I
		LEFT JOIN
		DELETED D ON D.PurchaseId = I.PurchaseId
	WHERE
		D.PurchaseId IS NULL
END
GO
CREATE TABLE Inventory (
	InventoryId INT IDENTITY (1, 1) NOT NULL,
	ReaderId INT NOT NULL,
	Title VARCHAR (50) DEFAULT NULL,
	InventoryDate DATE NOT NULL,
	InventoryState BIT DEFAULT 1,
	InventoryType VARCHAR (10) DEFAULT 'Compra', --Compra --Venta
	Entries INT DEFAULT 0,
	Departures INT DEFAULT 0,
	CreationDate DATE DEFAULT GETDATE(),
	ModificationDate DATE DEFAULT GETDATE(),
	CONSTRAINT PK_Inventary PRIMARY KEY(InventoryId),
	CONSTRAINT FK_Inventary_Reader FOREIGN KEY(ReaderId) REFERENCES Reader (ReaderId)
);
GO
CREATE TABLE Log_Inventory (
	InventoryId INT NULL,
	ReaderId INT NULL,
	Title VARCHAR (50) NULL,
	InventoryDate DATE NULL,
	InventoryState BIT NULL,
	InventoryType VARCHAR (10) NULL,
	Entries INT NULL,
	Departures INT NULL,
	CreationDate DATE NULL,
	ModificationDate DATE NULL,
	-- LOG
	LogDate DATETIME NULL,
	LogType VARCHAR (60) NULL,
	LogUser VARCHAR (60) NULL
); 
GO
CREATE TRIGGER Log_Inventory_Trigger ON Inventory AFTER INSERT, UPDATE, DELETE
AS
SET NOCOUNT ON;
BEGIN
	INSERT INTO Log_Inventory (InventoryId, ReaderId, Title, InventoryDate, InventoryState, InventoryType,
		Entries, Departures, CreationDate, ModificationDate, LogDate, LogUser, LogType)
	SELECT
		D.InventoryId, D.ReaderId, D.Title, D.InventoryDate, D.InventoryState, D.InventoryType,
		D.Entries, D.Departures, D.CreationDate, D.ModificationDate, GETDATE(), SYSTEM_USER,
		CASE WHEN I.InventoryId IS NULL THEN 'Eliminado' ELSE 'Modificado' END
	FROM
		DELETED D
		LEFT JOIN
		INSERTED I ON D.InventoryId = I.InventoryId
	UNION ALL
	SELECT
		I.InventoryId, I.ReaderId, I.Title, I.InventoryDate, I.InventoryState, I.InventoryType,
		I.Entries, I.Departures, I.CreationDate, I.ModificationDate, GETDATE(), SYSTEM_USER, 'Insertado'
	FROM 
		INSERTED I
		LEFT JOIN
		DELETED D ON D.InventoryId = I.InventoryId
	WHERE
		D.InventoryId IS NULL
END
GO
CREATE TABLE Invoice (
	InvoiceId INT IDENTITY (1, 1) NOT NULL,
	CustomerId INT NOT NULL,
	CheckoutId INT NOT NULL,
	InvoiceCode VARCHAR (100) NOT NULL,
	Serial VARCHAR (15) NOT NULL,
	InvoiceDate DATE DEFAULT GETDATE(),
	Explanation VARCHAR (255) DEFAULT NULL,
	Total DECIMAL (11, 2) DEFAULT 0.0,
	CONSTRAINT PK_Invoice PRIMARY KEY (InvoiceId),
	CONSTRAINT FK_Customer_Invoice FOREIGN KEY (CustomerId) REFERENCES Customer (CustomerId), 
	CONSTRAINT FK_Invoice_Checkout FOREIGN KEY (CheckoutId) REFERENCES Checkout (CheckoutId)
);
GO
CREATE TABLE Log_Invoice (
	InvoiceId INT NULL,
	CustomerId INT NULL,
	CheckoutId INT NULL,
	InvoiceCode VARCHAR (100) NULL,
	Serial VARCHAR (15) NULL,
	InvoiceDate DATE NULL,
	Explanation VARCHAR (255) NULL,
	Total DECIMAL (11, 2) NULL,
	-- LOG
	LogDate DATETIME NULL,
	LogType VARCHAR (60) NULL,
	LogUser VARCHAR (60) NULL
);
GO
CREATE TRIGGER Log_Invoice_Trigger ON Invoice AFTER INSERT, UPDATE, DELETE
AS
SET NOCOUNT ON;
BEGIN
	INSERT INTO Log_Invoice (InvoiceId, CustomerId, CheckoutId, InvoiceCode, Serial, InvoiceDate,
		Explanation, Total, LogDate, LogUser, LogType)
	SELECT
		D.InvoiceId, D.CustomerId, D.CheckoutId, D.InvoiceCode, D.Serial, D.InvoiceDate,
		D.Explanation, D.Total, GETDATE(), SYSTEM_USER, 
		CASE WHEN I.InvoiceId IS NULL THEN 'Eliminado' ELSE 'Modificado' END
	FROM
		DELETED D
		LEFT JOIN
		INSERTED I ON D.InvoiceId = I.InvoiceId
	UNION ALL
	SELECT
		I.InvoiceId, I.CustomerId, I.CheckoutId, I.InvoiceCode, I.Serial, I.InvoiceDate,
		I.Explanation, I.Total, GETDATE(), SYSTEM_USER, 'Insertado'
	FROM
		INSERTED I
		LEFT JOIN
		DELETED D ON D.InvoiceId = I.InvoiceId
	WHERE 
		D.InvoiceId IS NULL
END
GO
CREATE TABLE Product_Sale (
	ProductId INT NOT NULL,
	SaleId INT NOT NULL,
	Amount INT DEFAULT 1,
	Price DECIMAL (11, 2) NOT NULL,
	CONSTRAINT PK_Product_Sale PRIMARY KEY (ProductId, SaleId),
	CONSTRAINT FK_Product_Sale FOREIGN KEY (ProductId) REFERENCES Product (ProductId),
	CONSTRAINT FK_Sale FOREIGN KEY (SaleId) REFERENCES Sale (SaleId)
);
GO
CREATE TABLE Log_Product_Sale (
	ProductId INT NULL,
	SaleId INT NULL,
	Amount INT NULL,
	Price DECIMAL (11, 2) NULL,
	-- LOG
	LogDate DATETIME NULL,
	LogType VARCHAR (60) NULL,
	LogUser VARCHAR (60) NULL
);
GO
CREATE TRIGGER Log_Product_Sale_Trigger ON Product_Sale AFTER INSERT, UPDATE, DELETE
AS
SET NOCOUNT ON;
BEGIN
	INSERT INTO Log_Product_Sale (ProductId, SaleId, Amount, Price, LogDate, LogUser, LogType)
	SELECT
		D.ProductId, D.SaleId, D.Amount, D.Price, GETDATE(), SYSTEM_USER,
		CASE WHEN I.ProductId IS NULL AND I.SaleId IS NULL THEN 'Eliminado' ELSE 'Modificado' END
	FROM
		DELETED D
		LEFT JOIN
		INSERTED I ON D.ProductId = I.ProductId AND D.SaleId = I.SaleId
	UNION ALL
	SELECT 
		I.ProductId, I.SaleId, I.Amount, I.Price, GETDATE(), SYSTEM_USER, 'Insertado'
	FROM
		INSERTED I
		LEFT JOIN
		DELETED D ON D.ProductId = I.ProductId AND D.SaleId = I.SaleId 
	WHERE
		D.ProductId IS NULL AND D.SaleId IS NULL
END
GO
CREATE TABLE Product_Purchase (
	PurchaseId INT NOT NULL,
	ProductId INT NOT NULL,
	Amount INT NOT NULL,
	Price DECIMAL (11, 2) NOT NULL,
	CONSTRAINT PK_ProductPurchase PRIMARY KEY (PurchaseId, ProductId),
	CONSTRAINT FK_ProductPurchase_Product FOREIGN KEY (ProductId) REFERENCES Product (ProductId),
	CONSTRAINT FK_ProductPurchase_Purchase FOREIGN KEY (PurchaseId) REFERENCES Purchase (PurchaseId)
);
GO
CREATE TABLE Log_Product_Purchase (
	PurchaseId INT NULL,
	ProductId INT NULL,
	Amount INT NULL,
	Price DECIMAL (11, 2) NULL,
	-- LOG
	LogDate DATETIME NULL,
	LogType VARCHAR (60) NULL,
	LogUser VARCHAR (60) NULL
);
GO
CREATE TRIGGER Log_Product_Purchase_Trigger ON Product_Purchase AFTER INSERT, UPDATE, DELETE
AS
SET NOCOUNT ON;
BEGIN
	INSERT INTO Log_Product_Purchase (ProductId, PurchaseId, Amount, Price, LogDate, LogUser, LogType)
	SELECT
		D.ProductId, D.PurchaseId, D.Amount, D.Price, GETDATE(), SYSTEM_USER,
		CASE WHEN I.ProductId IS NULL AND I.PurchaseId IS NULL THEN 'Eliminado' ELSE 'Modificado' END
	FROM
		DELETED D
		LEFT JOIN
		INSERTED I ON D.ProductId = I.ProductId AND D.PurchaseId = I.PurchaseId
	UNION ALL
	SELECT 
		I.ProductId, I.PurchaseId, I.Amount, I.Price, GETDATE(), SYSTEM_USER, 'Insertado'
	FROM
		INSERTED I
		LEFT JOIN
		DELETED D ON D.ProductId = I.ProductId AND D.PurchaseId = I.PurchaseId 
	WHERE
		D.ProductId IS NULL AND D.PurchaseId IS NULL
END
GO
CREATE TABLE Product_Inventory (
	ProductInventoryId INT IDENTITY (1, 1) NOT NULL,
	ProductId INT NOT NULL,
	InventoryId INT NOT NULL,
	Amount INT DEFAULT 1,
	RegisterType VARCHAR (10) DEFAULT 'Compra',--Compra --Venta
	CreationDate DATE DEFAULT GETDATE(),
	ModificationDate DATE DEFAULT GETDATE(),
	CONSTRAINT PK_ProductInventory PRIMARY KEY (ProductInventoryId),
	CONSTRAINT FK_ProductInventory_Product FOREIGN KEY (ProductId) REFERENCES Product (ProductId),
	CONSTRAINT FK_ProductInventory_Inventary FOREIGN KEY (InventoryId) REFERENCES Inventory (InventoryId)
);
GO
CREATE TABLE Log_Product_Inventory (
	ProductInventoryId INT NULL,
	ProductId INT NULL,
	InventoryId INT NULL,
	Amount INT NULL,
	RegisterType VARCHAR (10) NULL,
	CreationDate DATE NULL,
	ModificationDate DATE NULL,
	-- LOG
	LogDate DATETIME NULL,
	LogType VARCHAR (60) NULL,
	LogUser VARCHAR (60) NULL
);
GO
CREATE TRIGGER Log_Product_Inventory_Trigger ON Product_Inventory AFTER INSERT, UPDATE, DELETE
AS
SET NOCOUNT ON;
BEGIN
	INSERT INTO Log_Product_Inventory (ProductInventoryId, ProductId, InventoryId, Amount, 
		RegisterType, CreationDate, ModificationDate, LogDate, LogUser, LogType)
	SELECT
		 D.ProductInventoryId, D.ProductId, D.InventoryId, D.Amount,
		 D.RegisterType, D.CreationDate, D.ModificationDate, GETDATE(), SYSTEM_USER,
		CASE WHEN I.ProductInventoryId IS NULL THEN 'Eliminado' ELSE 'Modificado' END
	FROM
		DELETED D
		LEFT JOIN
		INSERTED I ON D.ProductInventoryId = I.ProductInventoryId
	UNION ALL
	SELECT 
		I.ProductInventoryId, I.ProductId, I.InventoryId, I.Amount,
		I.RegisterType, I.CreationDate, I.ModificationDate, GETDATE(), SYSTEM_USER, 'Insertado'
	FROM
		INSERTED I
		LEFT JOIN
		DELETED D ON D.ProductInventoryId = I.ProductInventoryId
	WHERE
		D.ProductInventoryId IS NULL
END
GO
CREATE TABLE Report (
	ReportId INT IDENTITY (1, 1) NOT NULL,
	CompanyId INT NOT NULL,
	ReportCode VARCHAR (25) NOT NULL,
	Name VARCHAR (50) NOT NULL,
	Explanation VARCHAR (200) DEFAULT NULL,
	ReportType VARCHAR (20) DEFAULT NULL,
	CreationDate DATETIME DEFAULT GETDATE(),
	ModificationDate DATETIME DEFAULT GETDATE(),
	CONSTRAINT PK_Report PRIMARY KEY (ReportId),
	CONSTRAINT FK_Repore_Company FOREIGN KEY (CompanyId) REFERENCES Company (CompanyId)
);
GO
CREATE TABLE Log_Report (
	ReportId INT NULL,
	CompanyId INT NULL,
	ReportCode VARCHAR (25) NULL,
	Name VARCHAR (50) NULL,
	Explanation VARCHAR (200) NULL,
	ReportType VARCHAR (20) DEFAULT NULL,
	CreationDate DATETIME DEFAULT GETDATE(),
	ModificationDate DATETIME DEFAULT GETDATE(),
	-- LOG
	LogDate DATETIME NULL,
	LogType VARCHAR (60) NULL,
	LogUser VARCHAR (60) NULL
);
GO
CREATE TRIGGER Log_Report_Triger ON Report AFTER INSERT, UPDATE, DELETE
AS
SET NOCOUNT ON;
BEGIN
	INSERT INTO Log_Report (ReportId, CompanyId, ReportCode, Name, Explanation, 
		ReportType, CreationDate, ModificationDate, LogDate, LogUser, LogType)
	SELECT
		 D.ReportId, D.CompanyId, D.ReportCode, D.Name, D.Explanation, 
		 D.ReportType, D.CreationDate, D.ModificationDate, GETDATE(), SYSTEM_USER,
		 CASE WHEN I.ReportId IS NULL THEN 'Eliminado' ELSE 'Modificado' END
	FROM
		DELETED D
		LEFT JOIN
		INSERTED I ON D.ReportId = I.ReportId
	UNION ALL
	SELECT
		D.ReportId, D.CompanyId, D.ReportCode, D.Name, D.Explanation, 
		D.ReportType, D.CreationDate, D.ModificationDate, GETDATE(), SYSTEM_USER, 'Insertado'
	FROM
		INSERTED I
		LEFT JOIN
		DELETED D ON D.ReportId = I.ReportId
	WHERE
		D.ReportId IS NULL	
END
GO
--Rol
INSERT INTO Rol(Name, Explanation) VALUES ('SuperAdmin', 'SuperAdministrador');

--Employee
INSERT INTO Employee (Name, LastName, Email, Phone, Gender, Direction, Comment, Dpi, BirthDate) VALUES ('Super', 'Admin', 'bralecastropez@gmail.com', '59505705', 'Masculino', 'Direccion', 'Ninguno', '0000-00000-0000', GETDATE());

--User
INSERT INTO Reader(RolId, EmployeeId, Nick, Pass) VALUES (1, 1, 'admin', '3cf108a4e0a498347a5a75a792f23212');

--Category
INSERT INTO Category (Name, Explanation) VALUES ('Equipo de Computo', 'Servidores y Computadoras Personales');

--Product
INSERT INTO Product (CategoryId, ProductCode, Name, Explanation, ImageSrc, PurchasePrice, UnitPrice, PricePerDozen, WholesalePrice, AddedDate, Tag, Review, AditionalInformation, Help) 
				VALUES (1, 'Ninguno', 'Laptop Asus', 'Ninguna', '/', 0, 0, 0, 0 , GETDATE(), 'Ninguna', 'Ninguna', 'Ninguna', 'Ninguna');


/* V 1.8 */