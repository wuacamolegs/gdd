USE [GD1C2014]
GO
CREATE SCHEMA [ATJ] AUTHORIZATION [gd]
GO


BEGIN TRANSACTION
GO
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT

BEGIN TRANSACTION
GO

-- Creacion tabla de datos Clientes
CREATE TABLE [ATJ].[Clientes]
	(
	id_Cliente int NOT NULL IDENTITY (1, 1),
	Tipo_Dni nvarchar(50) NOT NULL DEFAULT 'DNI',
	Dni numeric(18, 0) NOT NULL,
	Cuil nvarchar(50) NULL,
	Apellido nvarchar(255) NULL,
	Nombre nvarchar(255) NULL,
	Fecha_nac datetime NULL,
	Mail nvarchar(255) NULL,
	Telefono nvarchar(255) NULL,
	Dom_calle nvarchar(255) NULL,
	Dom_nro_calle numeric(18, 0) NULL,
	Dom_piso numeric(18, 0) NULL,
	Dom_depto nvarchar(50) NULL,
	Dom_cod_postal nvarchar(50) NULL,
	Dom_ciudad nvarchar(255) NULL,
	Activo bit NULL DEFAULT 1,
	id_Usuario int NULL,
	Reputacion numeric(18, 2) NULL,
	Eliminado bit NULL DEFAULT 0
	)  ON [PRIMARY]
GO

ALTER TABLE [ATJ].[Clientes] ADD CONSTRAINT
	PK_Clientes PRIMARY KEY CLUSTERED 
	(
	id_Cliente
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE [ATJ].[Clientes] SET (LOCK_ESCALATION = TABLE)
GO
------------------------------------------------------------------------------------------------------------------------------
-- Creacion tabla de datos Empresas

CREATE TABLE [ATJ].[Empresas]
	(
	id_Empresa int NOT NULL IDENTITY (1, 1),
	Cuit nvarchar(50) NULL,
	Razon_social nvarchar(255) NULL,
	Mail nvarchar(50) NULL,
	Fecha_creacion datetime NULL,
	Telefono nvarchar(255) NULL,
	Dom_calle nvarchar(100) NULL,
	Dom_nro_calle numeric(18, 0) NULL,
	Dom_piso numeric(18, 0) NULL,
	Dom_depto nvarchar(50) NULL,
	Dom_cod_postal nvarchar(50) NULL,
	Dom_ciudad nvarchar(255) NULL,
	Nombre_contacto nvarchar(255) NULL,
	Activo bit NULL DEFAULT 1,
	id_Usuario int NULL,
	Reputacion numeric(18, 2) NULL,
	Eliminado bit NULL DEFAULT 0
	)  ON [PRIMARY]
GO
ALTER TABLE [ATJ].[Empresas] ADD CONSTRAINT
	PK_Empresas PRIMARY KEY CLUSTERED 
	(
	id_Empresa
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE [ATJ].[Empresas] SET (LOCK_ESCALATION = TABLE)
GO
------------------------------------------------------------------------------------------------------------------------------
-- Creacion tabla de datos Usuarios

CREATE TABLE ATJ.Usuarios
	(
	id_Usuario int NOT NULL IDENTITY (1, 1),
	Username nvarchar(255) NOT NULL,
	Clave nvarchar(255) NOT NULL,
	ClaveAutoGenerada bit NOT NULL DEFAULT 1,
	Activo bit NOT NULL DEFAULT 1
	)  ON [PRIMARY]
GO
ALTER TABLE ATJ.Usuarios ADD CONSTRAINT
	PK_Usuarios PRIMARY KEY CLUSTERED 
	(
	id_Usuario
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE ATJ.Usuarios ADD UNIQUE (Username)
GO
ALTER TABLE ATJ.Usuarios SET (LOCK_ESCALATION = TABLE)
GO

------------------------------------------------------------------------------------------------------------------------------
-- Creacion tabla de datos Publicaciones

CREATE TABLE ATJ.Publicaciones
	(
	Codigo numeric(18, 0) NOT NULL IDENTITY (1, 1),
	id_Usuario int NOT NULL,
	Descripcion nvarchar(255) NULL,
	Stock numeric(18, 0) NULL DEFAULT 0,
	Fecha_creacion datetime NULL DEFAULT GETDATE(),
	Fecha_vencimiento datetime NULL,
	Precio numeric(18, 2) NULL DEFAULT 0.00,
	id_Tipo int NULL,
	cod_Visibilidad numeric(18, 0) NULL,
	id_Estado int NULL,
	permiso_Preguntas bit NULL DEFAULT 1
	)  ON [PRIMARY]
GO
ALTER TABLE ATJ.Publicaciones ADD CONSTRAINT
	PK_Publicaciones PRIMARY KEY CLUSTERED 
	(
	Codigo
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE ATJ.Publicaciones SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE ATJ.Publicaciones WITH NOCHECK ADD CONSTRAINT CK_STOCK CHECK(Stock>-1)
GO
------------------------------------------------------------------------------------------------------------------------------
-- Creacion tabla de datos Tipos_Publicacion

CREATE TABLE ATJ.Tipos_Publicacion
	(
	id_Tipo int NOT NULL IDENTITY (1, 1),
	Nombre nvarchar(255) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE ATJ.Tipos_Publicacion ADD CONSTRAINT
	PK_Tipos_Publicacion PRIMARY KEY CLUSTERED 
	(
	id_Tipo
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE ATJ.Tipos_Publicacion SET (LOCK_ESCALATION = TABLE)
GO
------------------------------------------------------------------------------------------------------------------------------
-- Creacion tabla de datos Visibilidades

CREATE TABLE ATJ.Visibilidades
	(
	cod_Visibilidad numeric(18, 0) NOT NULL IDENTITY (1, 1),
	Descripcion nvarchar(255) NULL,
	Precio numeric(18, 2) NULL DEFAULT 0.00,
	Porcentaje numeric(18, 2) NULL,
	Duracion int NULL,
	Activo bit NULL DEFAULT 1,
	Eliminado bit NULL DEFAULT 0
	)  ON [PRIMARY]
GO
ALTER TABLE ATJ.Visibilidades ADD CONSTRAINT
	PK_Visibilidades PRIMARY KEY CLUSTERED 
	(
	cod_Visibilidad
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE ATJ.Visibilidades SET (LOCK_ESCALATION = TABLE)
GO
------------------------------------------------------------------------------------------------------------------------------
-- Creacion tabla de datos Rubros

CREATE TABLE ATJ.Rubros
	(
	id_Rubro int NOT NULL IDENTITY (1, 1),
	Descripcion nvarchar(255) NULL,
	Activo bit NULL DEFAULT 1
	)  ON [PRIMARY]
GO
ALTER TABLE ATJ.Rubros ADD CONSTRAINT
	PK_Rubros PRIMARY KEY CLUSTERED 
	(
	id_Rubro
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE ATJ.Rubros SET (LOCK_ESCALATION = TABLE)
GO

-----------------------------------------------------------------------------------------------------------------------------
--Creacion de tabla de datos Rubros_Publicacion
CREATE TABLE [ATJ].[Rubros_Publicacion] (
	[id_Rubros_Publicacion] int IDENTITY (1,1),
	[id_Rubro] int NOT NULL,
	[cod_Publicacion] numeric(18,0) NOT NULL
);
GO
------------------------------------------------------------------------------------------------------------------------------
-- Creacion tabla de datos Preguntas

CREATE TABLE ATJ.Preguntas
	(
	id_Pregunta int NOT NULL IDENTITY (1, 1),
	id_Usuario int NOT NULL,
	Pregunta nvarchar(255) NULL,
	Respuesta nvarchar(255) NULL,
	cod_Publicacion numeric(18, 0) NOT NULL,
	Fecha_respuesta datetime NULL
	)  ON [PRIMARY]
GO
ALTER TABLE ATJ.Preguntas ADD CONSTRAINT
	PK_Preguntas PRIMARY KEY CLUSTERED 
	(
	id_Pregunta
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE ATJ.Preguntas SET (LOCK_ESCALATION = TABLE)
GO


------------------------------------------------------------------------------------------------------------------------------
-- Creacion tabla de datos Estados_Publicacion

CREATE TABLE ATJ.Estados_Publicacion
	(
	id_Estado int NOT NULL IDENTITY (1, 1),
	Nombre nvarchar(255) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE ATJ.Estados_Publicacion ADD CONSTRAINT
	PK_Estados_Publicacion PRIMARY KEY CLUSTERED 
	(
	id_Estado
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE ATJ.Estados_Publicacion SET (LOCK_ESCALATION = TABLE)
GO

------------------------------------------------------------------------------------------------------------------------------
-- Creacion tabla de datos Roles

CREATE TABLE ATJ.Roles
	(
	id_Rol int NOT NULL IDENTITY (1, 1),
	Nombre nvarchar(255) NULL,
	Habilitado bit NULL DEFAULT 1,
	Eliminado bit NULL DEFAULT 0
	)  ON [PRIMARY]
GO
ALTER TABLE ATJ.Roles ADD CONSTRAINT
	PK_Roles PRIMARY KEY CLUSTERED 
	(
	id_Rol
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE ATJ.Roles SET (LOCK_ESCALATION = TABLE)
GO

------------------------------------------------------------------------------------------------------------------------------
-- Creacion tabla de datos Rol_Usuario

CREATE TABLE ATJ.Rol_Usuario
	(
	id_Rol int NOT NULL,
	id_Usuario int NOT NULL,
	PRIMARY KEY (id_Rol, id_Usuario)
	)  ON [PRIMARY]
GO
ALTER TABLE ATJ.Rol_Usuario SET (LOCK_ESCALATION = TABLE)
GO

------------------------------------------------------------------------------------------------------------------------------
-- Creacion tabla de datos Funcionalidades

CREATE TABLE ATJ.Funcionalidades
	(
	id_Funcionalidad int NOT NULL IDENTITY (1, 1),
	Nombre nvarchar(255) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE ATJ.Funcionalidades ADD CONSTRAINT
	PK_Funcionalidades PRIMARY KEY CLUSTERED 
	(
	id_Funcionalidad
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE ATJ.Funcionalidades SET (LOCK_ESCALATION = TABLE)
GO

------------------------------------------------------------------------------------------------------------------------------
-- Creacion tabla de datos Rol_Funcionalidad

CREATE TABLE ATJ.Rol_Funcionalidad
	(
	id_Rol int NOT NULL,
	id_Funcionalidad int NOT NULL,
	PRIMARY KEY (id_Rol, id_Funcionalidad)
	)  ON [PRIMARY]
GO
ALTER TABLE ATJ.Rol_Funcionalidad SET (LOCK_ESCALATION = TABLE)
GO

------------------------------------------------------------------------------------------------------------------------------
-- Creacion tabla de datos Facturas

CREATE TABLE ATJ.Facturas
	(
	nro_Factura numeric(18, 0) NOT NULL IDENTITY (1, 1),
	Fecha datetime NULL DEFAULT GETDATE(),
	Precio_Total numeric(18, 2) NULL,
	id_Forma_Pago int NULL,
	id_Usuario int NOT NULL,
	Tarjeta nvarchar(255) NULL,
	Nro_Tarjeta numeric(18,0) NULL,
	Titular nvarchar(255) NULL,
	Fecha_Vencimiento datetime NULL,
	Dni numeric(18,0) NULL,
	Codigo_seg numeric(18,0) NULL	
	)  ON [PRIMARY]
GO

ALTER TABLE ATJ.Facturas ADD CONSTRAINT
	PK_Facturas PRIMARY KEY CLUSTERED 
	(
	nro_Factura
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE ATJ.Facturas SET (LOCK_ESCALATION = TABLE)
GO

------------------------------------------------------------------------------------------------------------------------------
-- Creacion tabla de datos Item_Factura

CREATE TABLE ATJ.Item_Factura
	(
	id_Item_Factura int NOT NULL IDENTITY (1, 1),
	nro_Factura numeric(18, 0) NOT NULL,
	cod_Publicacion numeric(18, 0) NOT NULL,
	Monto numeric(18, 2) NULL,
	Cantidad numeric(18, 0) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE ATJ.Item_Factura ADD CONSTRAINT
	PK_Item_Factura PRIMARY KEY CLUSTERED 
	(
	id_Item_Factura
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE ATJ.Item_Factura SET (LOCK_ESCALATION = TABLE)
GO

------------------------------------------------------------------------------------------------------------------------------
-- Creacion tabla de datos Formas_Pago
CREATE TABLE ATJ.Formas_Pago
	(
	id_Forma_Pago int NOT NULL IDENTITY (1, 1),
	Descripcion nvarchar(255) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE ATJ.Formas_Pago ADD CONSTRAINT
	PK_Formas_pago PRIMARY KEY CLUSTERED 
	(
	id_Forma_Pago
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE ATJ.Formas_Pago SET (LOCK_ESCALATION = TABLE)
GO
------------------------------------------------------------------------------------------------------------------------------
-- Creacion tabla de datos Compras
CREATE TABLE ATJ.Compras
	(
	id_Compra int NOT NULL IDENTITY (1, 1),
	cod_Publicacion numeric(18, 0) NOT NULL,
	id_Usuario_Vendedor int NOT NULL,
	id_Usuario_Comprador int NOT NULL,
	Fecha datetime NULL,
	Cantidad numeric(18, 0) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE ATJ.Compras ADD CONSTRAINT
	PK_Compras PRIMARY KEY CLUSTERED 
	(
	id_Compra
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE ATJ.Compras SET (LOCK_ESCALATION = TABLE)
GO
------------------------------------------------------------------------------------------------------------------------------
-- Creacion tabla de datos Ofertas
CREATE TABLE ATJ.Ofertas
	(
	id_Oferta int NOT NULL IDENTITY (1, 1),
	cod_Publicacion numeric(18, 0) NOT NULL,
	id_Usuario_Vendedor int NOT NULL,
	id_Usuario_Comprador int NOT NULL,
	gano_Subasta bit NULL DEFAULT 0,
	Fecha datetime NULL,
	Monto numeric(18, 2) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE ATJ.Ofertas ADD CONSTRAINT
	PK_Ofertas PRIMARY KEY CLUSTERED 
	(
	id_Oferta
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE ATJ.Ofertas SET (LOCK_ESCALATION = TABLE)
GO
------------------------------------------------------------------------------------------------------------------------------
-- Creacion tabla de datos Calificaciones
CREATE TABLE ATJ.Calificaciones
	(
	cod_Calificacion numeric(18, 0) NOT NULL IDENTITY (1, 1),
	id_Usuario_Calificador int NOT NULL,
	cod_Publicacion numeric(18,0) NOT NULL,
	Cant_Estrellas numeric(18, 0) NULL,
	Descripcion nvarchar(255) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE ATJ.Calificaciones ADD CONSTRAINT
	PK_Calificaciones PRIMARY KEY CLUSTERED 
	(
	cod_Calificacion
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE ATJ.Calificaciones SET (LOCK_ESCALATION = TABLE)
GO

COMMIT

-------------------------------------------------------------------------------------------------------------------------------
--- Creacion de foreign keys

BEGIN TRANSACTION
GO
	ALTER TABLE ATJ.Calificaciones
	ADD FOREIGN KEY (cod_Publicacion)
	REFERENCES ATJ.Publicaciones (Codigo);
	GO

	ALTER TABLE ATJ.Calificaciones
	ADD FOREIGN KEY (id_Usuario_Calificador)
	REFERENCES ATJ.Usuarios (id_Usuario);
	GO
	
	ALTER TABLE [ATJ].[Clientes]
	ADD FOREIGN KEY ([id_Usuario])
	REFERENCES [ATJ].[Usuarios] (id_Usuario);
	GO
	
	ALTER TABLE [ATJ].[Compras]
	ADD FOREIGN KEY ([cod_Publicacion])
	REFERENCES [ATJ].[Publicaciones] (Codigo);
	GO
	
	ALTER TABLE [ATJ].[Compras]
	ADD FOREIGN KEY ([id_Usuario_Vendedor])
	REFERENCES [ATJ].[Usuarios] (id_Usuario);
	GO
	
	ALTER TABLE [ATJ].[Compras]
	ADD FOREIGN KEY ([id_Usuario_Comprador])
	REFERENCES [ATJ].[Usuarios] (id_Usuario);
	GO
	
	ALTER TABLE [ATJ].[Empresas]
	ADD FOREIGN KEY ([id_Usuario])
	REFERENCES [ATJ].[Usuarios] (id_Usuario);
	GO
	
	ALTER TABLE [ATJ].[Rol_Funcionalidad]
	ADD FOREIGN KEY ([id_Funcionalidad])
	REFERENCES [ATJ].[Funcionalidades] (id_Funcionalidad);
	GO
	
	ALTER TABLE [ATJ].[Rol_Funcionalidad]
	ADD FOREIGN KEY ([id_Rol])
	REFERENCES [ATJ].[Roles] (id_Rol);
	GO
	
	ALTER TABLE [ATJ].[Item_Factura]
	ADD FOREIGN KEY ([nro_Factura])
	REFERENCES [ATJ].[Facturas] (nro_Factura);
	GO

	ALTER TABLE [ATJ].[Item_Factura]
	ADD FOREIGN KEY ([cod_Publicacion])
	REFERENCES [ATJ].[Publicaciones] (Codigo);
	GO
	
	ALTER TABLE [ATJ].[Ofertas]
	ADD FOREIGN KEY ([id_Usuario_Vendedor])
	REFERENCES [ATJ].[Usuarios] (id_Usuario);
	GO
	
	ALTER TABLE [ATJ].[Ofertas]
	ADD FOREIGN KEY ([id_Usuario_Comprador])
	REFERENCES [ATJ].[Usuarios] (id_Usuario);
	GO
	
	ALTER TABLE [ATJ].[Ofertas]
	ADD FOREIGN KEY ([cod_Publicacion])
	REFERENCES [ATJ].[Publicaciones] (Codigo);
	GO
	
	ALTER TABLE [ATJ].[Preguntas]
	ADD FOREIGN KEY ([cod_Publicacion])
	REFERENCES [ATJ].[Publicaciones] (Codigo);
	GO
	
	ALTER TABLE [ATJ].[Preguntas]
	ADD FOREIGN KEY ([id_Usuario])
	REFERENCES [ATJ].[Usuarios] (id_Usuario);
	GO
	
	ALTER TABLE [ATJ].[Publicaciones]
	ADD FOREIGN KEY ([id_Tipo])
	REFERENCES [ATJ].[Tipos_Publicacion] (id_Tipo);
	GO
	
	ALTER TABLE [ATJ].[Publicaciones]
	ADD FOREIGN KEY ([id_Usuario])
	REFERENCES [ATJ].[Usuarios] (id_Usuario);
	GO
	
	ALTER TABLE [ATJ].[Publicaciones]
	ADD FOREIGN KEY ([cod_Visibilidad])
	REFERENCES [ATJ].[Visibilidades] (cod_Visibilidad);
	GO
	
	ALTER TABLE [ATJ].[Publicaciones]
	ADD FOREIGN KEY ([id_Estado])
	REFERENCES [ATJ].[Estados_Publicacion] (id_Estado);
	GO
	
	ALTER TABLE [ATJ].[Rubros_Publicacion]
	ADD FOREIGN KEY ([id_Rubro])
	REFERENCES [ATJ].[Rubros] (id_Rubro);
	GO
	
	ALTER TABLE [ATJ].[Rubros_Publicacion]
	ADD FOREIGN KEY ([cod_Publicacion])
	REFERENCES [ATJ].[Publicaciones] (Codigo);
	GO
	
	ALTER TABLE [ATJ].[Rol_Usuario]
	ADD FOREIGN KEY ([id_Usuario])
	REFERENCES [ATJ].[Usuarios] (id_Usuario);
	GO
	
	ALTER TABLE [ATJ].[Rol_Usuario]
	ADD FOREIGN KEY ([id_Rol])
	REFERENCES [ATJ].[Roles] (id_Rol);
	GO
	
	ALTER TABLE [ATJ].[Facturas]
	ADD FOREIGN KEY ([id_Forma_Pago])
	REFERENCES [ATJ].[Formas_Pago] (id_Forma_Pago);
	GO
	
	ALTER TABLE [ATJ].[Facturas]
	ADD FOREIGN KEY ([id_Usuario])
	REFERENCES [ATJ].[Usuarios] (id_Usuario);
	GO
		
COMMIT

-- Migracion de datos
--------------------------------------------------------------------------------------------------------------------




-- Migracion de datos tabla Clientes
BEGIN TRANSACTION
GO
INSERT INTO ATJ.Clientes (Apellido, Dom_cod_postal, Dom_depto, Dni, Dom_calle, Fecha_nac, Mail,
 Nombre, Dom_nro_calle, Dom_piso )
(SELECT DISTINCT Publ_Cli_Apeliido, Publ_Cli_Cod_Postal, Publ_Cli_Depto, Publ_Cli_Dni, Publ_Cli_Dom_Calle, 
Publ_Cli_Fecha_Nac, Publ_Cli_Mail, Publ_Cli_Nombre, Publ_Cli_Nro_Calle, Publ_Cli_Piso
  FROM [gd_esquema].[Maestra] where Publ_Cli_Dni is not null)
  
  UNION 
  (
  SELECT DISTINCT Cli_Apeliido, Cli_Cod_Postal, Cli_Depto, Cli_Dni, Cli_Dom_Calle, 
  Cli_Fecha_Nac, Cli_Mail, Cli_Nombre, Cli_Nro_Calle, Cli_Piso
  FROM [gd_esquema].[Maestra] where Cli_Dni is not null);
 COMMIT
--------------------------------------------------------------------------------------------------------------------  
 --Migracion de datos tabla Empresas
 BEGIN TRANSACTION
 GO
 INSERT INTO ATJ.Empresas 
(Dom_cod_postal, Cuit, Dom_depto, Dom_calle, Fecha_creacion, Mail, Dom_nro_calle, Dom_piso, Razon_social)
(
SELECT DISTINCT Publ_Empresa_Cod_Postal, Publ_Empresa_Cuit, Publ_Empresa_Depto, Publ_Empresa_Dom_Calle, 
Publ_Empresa_Fecha_Creacion, Publ_Empresa_Mail, Publ_Empresa_Nro_Calle, Publ_Empresa_Piso, 
Publ_Empresa_Razon_Social 
from gd_esquema.Maestra where Publ_Empresa_Cuit is not null);
COMMIT

--------------------------------------------------------------------------------------------------------------------

--Creacion Usuario DEFAULT
--Password del admin: w23e
BEGIN TRANSACTION
GO
INSERT INTO ATJ.Usuarios (Username, Clave, ClaveAutoGenerada, Activo) VALUES ('Admin', '52D77462B24987175C8D7DAB901A5967E927FFC8D0B6E4A234E07A4AEC5E3724', 0, 1);
COMMIT

--migracion de datos Usuarios de clientes
--Password general: admin
BEGIN TRANSACTION
GO
INSERT INTO ATJ.USUARIOS (Username, Clave, ClaveAutoGenerada, Activo)
 (
 SELECT DISTINCT DNI AS USERNAME, '7523C62ABDB7628C5A9DAD8F97D8D8C5C040EDE36535E531A8A3748B6CAE7E00' AS Clave, 1 as ClaveAutoGenerada, 1 as Activo
 from ATJ.Clientes);
COMMIT
--------------------------------------------------------------------------------------------------------------------
-- Migracion de datos Usuarios de Empresas
--Password general: admin
BEGIN TRANSACTION
GO
INSERT INTO ATJ.USUARIOS (Username, Clave, ClaveAutoGenerada, Activo)
 (
 SELECT DISTINCT Cuit AS USERNAME, '7523C62ABDB7628C5A9DAD8F97D8D8C5C040EDE36535E531A8A3748B6CAE7E00' AS Clave, 1 as ClaveAutoGenerada, 1 as Activo
 from ATJ.Empresas);
COMMIT 
-------------------------------------------------------------------------------------------------------------------- 
 -- Agrego los id_Usuario a las tablas Clientes y Empresas
 BEGIN TRANSACTION
GO
 UPDATE ATJ.Clientes
SET id_Usuario = (SELECT id_Usuario FROM ATJ.Usuarios AS "U" WHERE U.Username = CAST(Clientes.Dni AS NVARCHAR(50)));

UPDATE ATJ.Empresas 
SET id_Usuario = (SELECT id_Usuario FROM ATJ.Usuarios AS "U" WHERE U.Username = CAST(Empresas.Cuit AS NVARCHAR(50)));
commit
--------------------------------------------------------------------------------------------------------------------
--Migracion de datos de tabla Rubros
BEGIN TRANSACTION
GO
INSERT INTO ATJ.Rubros (Descripcion, Activo) (SELECT DISTINCT Publicacion_Rubro_Descripcion, 1 as ACTIVO FROM [gd_esquema].[Maestra] where Publicacion_Rubro_Descripcion is not null);
COMMIT
 --------------------------------------------------------------------------------------------------------------------
--Migracion de datos tabla Visibilidades
BEGIN TRANSACTION
GO
DECLARE @number AS INT;
SET IDENTITY_INSERT ATJ.Visibilidades ON;

INSERT INTO ATJ.Visibilidades (cod_Visibilidad, Descripcion, Precio, Porcentaje, Duracion)
(SELECT DISTINCT [Publicacion_Visibilidad_Cod]
				,[Publicacion_Visibilidad_Desc]
				,[Publicacion_Visibilidad_Precio]
				,[Publicacion_Visibilidad_Porcentaje]
				,(SELECT DISTINCT DATEDIFF(day,Publicacion_Fecha,Publicacion_Fecha_Venc)
				  FROM gd_esquema.Maestra
				  WHERE Publicacion_Visibilidad_Cod = [Publicacion_Visibilidad_Cod])
FROM gd_esquema.Maestra 
WHERE Publicacion_Visibilidad_Cod is not null);

SET IDENTITY_INSERT ATJ.Visibilidades OFF;

SELECT @number = MAX(Publicacion_Visibilidad_Cod) FROM gd_esquema.Maestra
DBCC CHECKIDENT ('ATJ.Visibilidades', RESEED, @number);
COMMIT
 --------------------------------------------------------------------------------------------------------------------
--Migracion de datos tabla Tipos_Publicacion
BEGIN TRANSACTION
GO
INSERT INTO ATJ.Tipos_Publicacion(Nombre)
(SELECT DISTINCT Publicacion_tipo FROM [gd_esquema].[Maestra] where Publicacion_Cod is not null);
COMMIT
--------------------------------------------------------------------------------------------------------------------
--Migracion de Estados_Publicacion
BEGIN TRANSACTION
GO
INSERT INTO ATJ.Estados_Publicacion (Nombre)
SELECT DISTINCT Publicacion_Estado
FROM gd_esquema.Maestra where Publicacion_Estado is not null;
  
INSERT INTO ATJ.Estados_Publicacion
(Nombre)
VALUES
('Borrador'),
('Pausada'),
('Finalizada');
COMMIT
--------------------------------------------------------------------------------------------------------------------
--Migracion de datos tabla Publicaciones
BEGIN TRANSACTION
GO
DECLARE @number AS INT;
SET IDENTITY_INSERT ATJ.Publicaciones ON;

INSERT INTO ATJ.Publicaciones(Codigo,Descripcion, Fecha_creacion, Fecha_vencimiento, Precio, Stock,id_Tipo, 
cod_Visibilidad, id_Usuario, id_Estado)
(SELECT DISTINCT M.Publicacion_Cod, M.Publicacion_Descripcion, M.Publicacion_Fecha, M.Publicacion_Fecha_Venc,
M.Publicacion_Precio, M.Publicacion_Stock, TP.id_Tipo, M.Publicacion_Visibilidad_Cod, 
Entidad = (CASE WHEN Publ_Cli_Dni IS null THEN Uempresa.id_Usuario ELSE Ucliente.id_Usuario END), E.id_Estado
FROM [gd_esquema].[Maestra] as "M" 
INNER JOIN ATJ.Tipos_Publicacion as "TP" ON TP.Nombre = M.Publicacion_tipo
INNER JOIN ATJ.Estados_Publicacion AS "E" ON E.Nombre = 'Finalizada'
LEFT JOIN ATJ.Usuarios AS "Uempresa" ON Uempresa.Username = CAST(M.Publ_Empresa_Cuit AS NVARCHAR(50))
LEFT JOIN ATJ.Usuarios AS "Ucliente" ON Ucliente.Username = CAST(M.Publ_Cli_Dni AS NVARCHAR(50))
WHERE M.Publicacion_Cod is not null);

SET IDENTITY_INSERT ATJ.Publicaciones OFF;

SELECT @number = MAX(Publicacion_Cod) FROM gd_esquema.Maestra
DBCC CHECKIDENT ('ATJ.Publicaciones', RESEED, @number);;
commit

--------------------------------------------------------
--Migracion de Funcionalidades
BEGIN TRANSACTION
GO
INSERT INTO ATJ.Funcionalidades
(Nombre)
VALUES
('ABM_Clientes'),
('ABM_Empresas'),
('Administrar_Usuarios'),
('Cambiar_Clave'),
('ABM_Rol'),
('ABM_Visibilidad'),
('Generar_Publicaciones'),
('Mis_Publicaciones'),
('Comprar_Ofertar'),
('Calificar'),
('Facturar'),
('Historial_clientes'),
('Estadisticas');
commit
---------------------------------------------------
--Migracion de datos Calificaciones
BEGIN TRANSACTION
GO
SET IDENTITY_INSERT ATJ.Calificaciones ON;

	INSERT INTO ATJ.Calificaciones (cod_Calificacion, cod_Publicacion, id_Usuario_Calificador, Cant_Estrellas, Descripcion) (
		SELECT [Calificacion_Codigo],
			   [Publicacion_Cod],
			   (SELECT id_Usuario FROM ATJ.Usuarios U WHERE CONVERT(nvarchar(255), Cli_Dni) = U.Username),
		       CAST(ROUND([Calificacion_Cant_Estrellas]/2,0) AS INT),
		       [Calificacion_Descripcion]
		FROM gd_esquema.Maestra
		WHERE [Calificacion_Codigo] IS NOT NULL);
		
	SET IDENTITY_INSERT ATJ.Calificaciones OFF;

	DECLARE @maxIdCalificacion numeric(18,0);
	SELECT @maxIdCalificacion = MAX(Calificacion_Codigo) FROM gd_esquema.Maestra DBCC CHECKIDENT ('ATJ.Calificaciones', RESEED, @maxIdCalificacion);
COMMIT
--------------------------------------------------------------------------------------------------------------------
--Migracion de datos de tabla Roles
BEGIN TRANSACTION
GO
INSERT INTO ATJ.Roles(Nombre) VALUES ('Administrativo'),('Cliente'),('Empresa');
COMMIT

--------------------------------------------------------------------------------------------------------------------
--Migracion de datos de tabla Rubros_Publicacion
BEGIN TRANSACTION
GO
INSERT INTO [ATJ].[Rubros_Publicacion] (id_Rubro, cod_Publicacion) (
	SELECT DISTINCT
	(SELECT id_Rubro FROM ATJ.Rubros R WHERE R.Descripcion = Publicacion_Rubro_Descripcion),
	(SELECT P.Codigo FROM ATJ.Publicaciones P WHERE P.Codigo = Publicacion_Cod)
	FROM gd_esquema.Maestra
	WHERE Publicacion_Cod IS NOT NULL);
COMMIT

--------------------------------------------------------------------------------------------------------------------
--Migracion de datos de tabla Compras
BEGIN TRANSACTION
GO
INSERT INTO ATJ.Compras(cod_Publicacion, id_Usuario_Vendedor, id_Usuario_Comprador, Fecha, Cantidad)
(select distinct M.Publicacion_Cod, usuario_vende = (CASE WHEN M.Publ_Cli_Dni IS null THEN Uempresa.id_Usuario ELSE Ucliente.id_Usuario END),
Ucomprador.id_Usuario, M.Compra_Fecha, M.Compra_Cantidad 
from gd_esquema.Maestra as "M"
LEFT JOIN ATJ.Usuarios AS "Uempresa" ON Uempresa.Username = CAST(M.Publ_Empresa_Cuit AS NVARCHAR(50))
LEFT JOIN ATJ.Usuarios AS "Ucliente" ON Ucliente.Username = CAST(M.Publ_Cli_Dni AS NVARCHAR(50))
LEFT JOIN ATJ.Usuarios AS "Ucomprador" ON Ucomprador.Username = CAST(M.Cli_Dni AS NVARCHAR(50))
where Publicacion_Tipo = 'Compra Inmediata' AND Cli_Dni is not null AND Compra_Fecha IS NOT NULL);
COMMIT
--------------------------------------------------------------------------------------------------------------------
--Migracion de datos de tabla Ofertas
BEGIN TRANSACTION
GO
INSERT INTO ATJ.Ofertas(cod_Publicacion, id_Usuario_Vendedor, id_Usuario_Comprador, Fecha, Monto)
(select distinct M.Publicacion_Cod, usuario_vende = (CASE WHEN M.Publ_Cli_Dni IS null THEN Uempresa.id_Usuario ELSE Ucliente.id_Usuario END),
Ucomprador.id_Usuario, M.Oferta_Fecha, M.Oferta_Monto
from gd_esquema.Maestra as "M"
LEFT JOIN ATJ.Usuarios AS "Uempresa" ON Uempresa.Username = CAST(M.Publ_Empresa_Cuit AS NVARCHAR(50))
LEFT JOIN ATJ.Usuarios AS "Ucliente" ON Ucliente.Username = CAST(M.Publ_Cli_Dni AS NVARCHAR(50))
LEFT JOIN ATJ.Usuarios AS "Ucomprador" ON Ucomprador.Username = CAST(M.Cli_Dni AS NVARCHAR(50))
where Publicacion_Tipo = 'Subasta' AND Cli_Dni is not nulL AND Oferta_Monto IS not NULL AND Oferta_Fecha IS NOT NULL);

UPDATE ATJ.Ofertas  
SET gano_Subasta = (CASE WHEN Monto = (SELECT MAX(Oferta_Monto) FROM gd_esquema.Maestra AS "M" WHERE M.Publicacion_Cod = Ofertas.cod_Publicacion)
THEN '1' ELSE '0' END);

--Migracion de subastas ganadas a Tabla Compras
INSERT INTO ATJ.Compras(cod_Publicacion, id_Usuario_Vendedor, id_Usuario_Comprador, Fecha, Cantidad)
(select o.cod_Publicacion, o.id_Usuario_Vendedor, o.id_Usuario_Comprador, o.Fecha, p.Stock
from ATJ.Ofertas AS O
INNER JOIN ATJ.Publicaciones AS P ON P.Codigo = O.cod_Publicacion 
where gano_Subasta = 1);
COMMIT
--------------------------------------------------------------------------------------------------------------------

--Migracion de datos de tabla Rol_Usuario
BEGIN TRANSACTION
GO
INSERT INTO ATJ.Rol_Usuario 
(id_Rol, id_Usuario)
VALUES
(1, 1);

INSERT INTO ATJ.Rol_Usuario
(id_Usuario,id_Rol)
SELECT DISTINCT id_Usuario as idU, R.id_Rol as idR 
FROM ATJ.Usuarios U 
INNER JOIN gd_esquema.Maestra MCli ON U.Username = CAST(MCli.Publ_Cli_Dni AS NVARCHAR(50))
LEFT JOIN ATJ.Roles R ON R.Nombre = 'Cliente';

INSERT INTO ATJ.Rol_Usuario
(id_Usuario,id_Rol)
SELECT DISTINCT id_Usuario as idU, R.id_Rol as idR 
FROM ATJ.Usuarios U 
INNER JOIN gd_esquema.Maestra MEmpr ON U.Username = CAST(MEmpr.Publ_Empresa_Cuit AS NVARCHAR(50))
LEFT JOIN ATJ.Roles R ON R.Nombre = 'Empresa';
COMMIT

--------------------------------------------------------------------------------------------------------------------
--Migracion de datos tabla rol_Funcionalidad
BEGIN TRANSACTION
GO
INSERT INTO ATJ.Rol_Funcionalidad(id_Rol, id_Funcionalidad)
SELECT 1, id_Funcionalidad FROM ATJ.Funcionalidades;

INSERT INTO ATJ.Rol_Funcionalidad (id_Rol, id_Funcionalidad)
SELECT R.id_Rol, F.id_Funcionalidad  
FROM ATJ.Roles R
LEFT JOIN ATJ.Funcionalidades F ON F.Nombre 
In ('Cambiar_Clave','Generar_Publicaciones','Mis_Publicaciones','Comprar_Ofertar','Calificar','Facturar','Historial_clientes','Estadisticas')
WHERE R.Nombre = 'Cliente';

INSERT INTO ATJ.Rol_Funcionalidad (id_Rol, id_Funcionalidad)
SELECT R.id_Rol, F.id_Funcionalidad  
FROM ATJ.Roles R
LEFT JOIN ATJ.Funcionalidades F ON F.Nombre 
In ('Cambiar_Clave','Mis_Publicaciones','Generar_Publicaciones','Facturar','Historial_clientes', 'Estadisticas')
WHERE R.Nombre = 'Empresa';
COMMIT
-------------------------------------------------

--Migracion de datos tabla Facturas y Formas de pago
BEGIN TRANSACTION
GO
INSERT INTO ATJ.Formas_Pago
(Descripcion) 
VALUES
('Efectivo'),
('Tarjeta de Crédito'),
('Tarjeta de Débito');

SET IDENTITY_INSERT ATJ.Facturas ON;

INSERT INTO ATJ.Facturas
(nro_Factura, Fecha, Precio_Total, id_Forma_Pago, id_Usuario)
SELECT distinct M.Factura_Nro, M.Factura_Fecha, M.Factura_Total, FP.id_Forma_Pago, Entidad = (CASE WHEN Publ_Cli_Dni IS null THEN Uempresa.id_Usuario ELSE Ucliente.id_Usuario END)
FROM gd_esquema.Maestra M 
LEFT JOIN ATJ.Formas_Pago FP ON FP.Descripcion = M.Forma_Pago_Desc
LEFT JOIN ATJ.Usuarios AS "Uempresa" ON Uempresa.Username = CAST(M.Publ_Empresa_Cuit AS NVARCHAR(50))
LEFT JOIN ATJ.Usuarios AS "Ucliente" ON Ucliente.Username = CAST(M.Publ_Cli_Dni AS NVARCHAR(50))
where M.Factura_Nro is not null;

SET IDENTITY_INSERT ATJ.Facturas OFF;
DECLARE @number AS INT;
SELECT @number = MAX(Factura_Nro) FROM gd_esquema.Maestra
DBCC CHECKIDENT ('ATJ.Facturas', RESEED, @number);
COMMIT
-------------------------------------------------

--Migracion de datos tabla Item_Factura
BEGIN TRANSACTION
GO
INSERT INTO ATJ.Item_Factura (nro_Factura, cod_Publicacion, Monto, Cantidad)
SELECT F.nro_Factura, P.Codigo, M.Item_Factura_Monto, M.Item_Factura_Cantidad
FROM gd_esquema.Maestra M 
INNER JOIN ATJ.Facturas F ON F.nro_Factura = M.Factura_Nro
INNER JOIN ATJ.Publicaciones P ON P.Codigo = M.Publicacion_Cod;
COMMIT
--Seteo la Reputacion en la Tabla Clientes con los datos ya migrados
BEGIN TRANSACTION
GO
UPDATE ATJ.Clientes	
SET Reputacion = CAST(
				(SELECT SUM(C.Cant_Estrellas) 
				FROM ATJ.Usuarios U
				INNER JOIN ATJ.Publicaciones P ON U.id_Usuario = P.id_Usuario 
				INNER JOIN ATJ.Calificaciones C ON P.Codigo = C.cod_Publicacion
				WHERE u.id_Usuario = Clientes.id_Usuario)/
				(SELECT COUNT(*)
				FROM ATJ.Calificaciones C
				INNER JOIN ATJ.Publicaciones P ON C.cod_Publicacion = p.Codigo
				WHERE p.id_Usuario = Clientes.id_Usuario) 
				AS NUMERIC(18,2));
	
--Seteo la Reputacion en la Tabla Empresas con los datos ya migrados
UPDATE ATJ.Empresas 
SET Reputacion = CAST(
				(SELECT SUM(C.Cant_Estrellas) 
				FROM ATJ.Usuarios U
				INNER JOIN ATJ.Publicaciones P ON U.id_Usuario = P.id_Usuario 
				INNER JOIN ATJ.Calificaciones C ON P.Codigo = C.cod_Publicacion
				WHERE u.id_Usuario = Empresas.id_Usuario)/
				(SELECT COUNT(*)
				FROM ATJ.Calificaciones C
				INNER JOIN ATJ.Publicaciones P ON C.cod_Publicacion = p.Codigo
				WHERE p.id_Usuario = Empresas.id_Usuario) 
				AS NUMERIC(18,2));
				
COMMIT

BEGIN TRANSACTION
GO
--Procedure traerUsuarioPorUsernameYClave
CREATE PROCEDURE ATJ.traerUsuarioPorUsernameYClave 
    @Username nvarchar(255), 
    @Clave nvarchar(255) 
AS 
    SELECT *
    FROM ATJ.Usuarios
    WHERE Username = @Username AND Clave = @Clave;
GO

--Procedure traerUsuarioPorUsuarname
CREATE PROCEDURE ATJ.traerUsuarioPorUsername
    @Username nvarchar(255)
AS 
    SELECT *
    FROM ATJ.Usuarios
    WHERE Username = @Username
GO

--Procedure traerMayorOfertaPorCodPublicacion
CREATE PROCEDURE ATJ.traerMayorOfertaPorCodPublicacion
	@cod_Publicacion numeric(18,0)
AS	
	SELECT MAX(Monto) AS maxOferta FROM ATJ.Ofertas where cod_Publicacion = @cod_Publicacion
GO

--Procedure traerListadoRolesPorId_Usuario
CREATE PROCEDURE [ATJ].[traerListadoRolesPorId_Usuario] 
    @id_Usuario numeric(18,0) 
AS 
    SELECT R.id_Rol AS id_Rol, R.Nombre AS Nombre, R.Habilitado as Habilitado from ATJ.Roles R 
	INNER JOIN ATJ.Rol_Usuario RU ON RU.id_Rol = R.id_Rol
	INNER JOIN ATJ.Usuarios U ON U.id_Usuario = RU.id_Usuario
	WHERE U.id_Usuario = @id_Usuario AND R.Habilitado = 1 AND R.Eliminado = 0
GO

--Procedure deshabilitarUsuario
CREATE PROCEDURE [ATJ].[deshabilitarUsuario]
	@id_Usuario numeric(18,0)
AS
	UPDATE ATJ.Usuarios SET Activo = 0 where id_Usuario=@id_Usuario	
GO


--Procedure updateUsuario
CREATE PROCEDURE [ATJ].[updateUsuario]
	@id_Usuario numeric(18,0),
	@Username nvarchar(255),
	@Clave nvarchar(255),
	@ClaveAutoGenerada bit,
	@Activo bit
AS
	UPDATE ATJ.Usuarios SET Username=@Username, Clave=@Clave, ClaveAutoGenerada = @ClaveAutoGenerada, Activo = @Activo where id_Usuario=@id_Usuario	
GO


--Procedure traerListadoRoles
CREATE PROCEDURE [ATJ].[traerListadoRoles] 
AS 
    SELECT * FROM ATJ.ROLES WHERE Eliminado = 0;
GO


--Procedure traerListadoFuncionalidadesPorId_Rol
CREATE PROCEDURE ATJ.traerListadoFuncionalidadesPorId_Rol
	@id_Rol numeric(18,0)
AS	
	SELECT F.* FROM ATJ.Rol_Funcionalidad RF 
	INNER JOIN ATJ.Funcionalidades F ON F.id_Funcionalidad = RF.id_Funcionalidad
	WHERE RF.id_Rol = @id_Rol
GO

--Procedure traerListadoFuncionalidades
CREATE PROCEDURE ATJ.traerListadoFuncionalidades
AS	
	SELECT * FROM ATJ.Funcionalidades
GO

--Procedure traerListadoRubros
CREATE PROCEDURE ATJ.traerListadoRubros
AS	
	SELECT * FROM ATJ.Rubros
GO

--Procedure traerListadoRubrosPorCodPublicacion
CREATE PROCEDURE ATJ.traerListadoRubrosPorCodPublicacion
	@cod_Publicacion numeric(18,0)
AS	
	SELECT R.* FROM ATJ.Rubros R
	INNER JOIN Rubros_Publicacion RP ON RP.id_Rubro = R.id_Rubro
	WHERE RP.cod_Publicacion = @cod_Publicacion
GO


--Procedure insertRol_RetornarID
CREATE PROCEDURE ATJ.insertRol_RetornarID
	@Nombre nvarchar(255),
	@Habilitado bit
AS
	INSERT INTO ATJ.Roles
	(Nombre, Habilitado)
	VALUES 
	(@Nombre, @Habilitado)
	
	SELECT @@IDENTITY AS id_Rol;
GO

--Procedure insertRol_Funcionalidad
CREATE PROCEDURE [ATJ].[insertRol_Funcionalidad]
	@id_Rol int,
	@id_Funcionalidad int
AS
	INSERT INTO ATJ.Rol_Funcionalidad
	(id_Rol, id_Funcionalidad)
	VALUES 
	(@id_Rol, @id_Funcionalidad)
GO

--Procedure insertRubros_Publicacion
CREATE PROCEDURE [ATJ].[insertRubros_Publicacion]
	@cod_Publicacion numeric(18,0),
	@id_Rubro numeric(18,0)
AS
	INSERT INTO ATJ.Rubros_Publicacion
	(cod_Publicacion, id_Rubro)
	VALUES 
	(@cod_Publicacion, @id_Rubro)
GO
	
--Procedure deleteRol_FuncionalidadPorIdRol
CREATE PROCEDURE ATJ.deleteRol_Funcionalidad_PorIdRol
	@id_Rol int
AS
	DELETE FROM ATJ.Rol_Funcionalidad WHERE id_Rol = @id_Rol
GO

--Procedure deleteRubros_PublicacionPorCod_Publicacion
CREATE PROCEDURE ATJ.deleteRubros_PublicacionPorCod_Publicacion
	@cod_Publicacion numeric(18,0)
AS
	DELETE FROM ATJ.Rubros_Publicacion WHERE cod_Publicacion = @cod_Publicacion
GO

--Procedure updateRol
CREATE PROCEDURE ATJ.updateRol
	@id_Rol int,
	@Nombre nvarchar(255),
	@Habilitado bit
AS
	UPDATE ATJ.Roles SET Nombre=@Nombre, Habilitado=@Habilitado
	WHERE id_Rol = @id_Rol
GO

--Procedure deshabilitarRol
CREATE PROCEDURE ATJ.deshabilitarRol
	@id_Rol int
AS
	UPDATE ATJ.Roles SET Habilitado=0
	WHERE id_Rol = @id_Rol
GO

--Procedure deleteRol
CREATE PROCEDURE ATJ.deleteRol
	@id_Rol int
AS
	UPDATE ATJ.Roles SET Eliminado=1
	WHERE id_Rol = @id_Rol
GO

--Procedure validarVisibilidadEnPublicacion
CREATE PROCEDURE ATJ.validarVisibilidadEnPublicacion
	@cod_Visibilidad int
AS
	SELECT * FROM ATJ.Publicaciones WHERE cod_Visibilidad = @cod_Visibilidad
GO

--Procedure validarRolEnUsuarios
CREATE PROCEDURE ATJ.validarRolEnUsuarios
	@id_Rol int
AS
	SELECT * FROM ATJ.Rol_Usuario WHERE id_Rol = @id_Rol
GO



--Procedure deleteVisibilidad
CREATE PROCEDURE ATJ.deleteVisibilidad
	@cod_Visibilidad int
AS
	UPDATE ATJ.Visibilidades SET Eliminado=1
	WHERE cod_Visibilidad = @cod_Visibilidad
GO



--Procedure traerListadoRolesConFiltros
CREATE PROCEDURE [ATJ].[traerListadoRolesConFiltros] 
    @Nombre nvarchar(255),
	@Habilitado bit
AS 
	IF(@Nombre = '' Or @Nombre IS NULL)
		BEGIN
			SELECT * FROM ATJ.Roles where Habilitado = @Habilitado AND Eliminado = 0;
		END	
	ELSE
		SELECT * FROM ATJ.Roles 
			WHERE Nombre LIKE '%' + @Nombre + '%' AND Habilitado = @Habilitado AND Eliminado = 0;

GO


--Procedure deshabilitarVisibilidad
CREATE PROCEDURE ATJ.deshabilitarVisibilidad
	@cod_Visibilidad int
AS
	UPDATE ATJ.Visibilidades SET Activo=0
	WHERE cod_Visibilidad = @cod_Visibilidad
GO

--Procedure traerListadoVisibilidades
CREATE PROCEDURE [ATJ].[traerListadoVisibilidades] 
AS 
    SELECT * FROM ATJ.Visibilidades WHERE Eliminado = 0;
GO

--Procedure traerListadoVisibilidadesConFiltros
CREATE PROCEDURE [ATJ].[traerListadoVisibilidadesConFiltros] 
    @Descripcion nvarchar(255) = '',
	@Precio nvarchar(20)= '',
	@Porcentaje nvarchar(20) ='',
	@Duracion nvarchar(20) = '',
	@Activo bit
AS 
	SELECT * FROM ATJ.Visibilidades WHERE Eliminado = 0
	AND Descripcion LIKE (CASE WHEN @Descripcion <> '' THEN '%' + @Descripcion + '%' ELSE Descripcion END)
	AND Precio = (CASE WHEN @Precio <> '' THEN CAST(@Precio as numeric(18,2)) ELSE Precio END)
	AND Porcentaje = (CASE WHEN @Porcentaje <> '' THEN CAST(@Porcentaje as numeric(18,2)) ELSE Porcentaje END)
	AND Duracion = (CASE WHEN @Duracion <> '' THEN CAST(@Duracion as numeric(18,2)) ELSE Duracion END)
	AND Activo = @Activo
GO


--Procedure updateVisibilidad
CREATE PROCEDURE ATJ.updateVisibilidad
	@cod_Visibilidad int,
	@Descripcion nvarchar(255),
	@Precio numeric(18,2),
	@Porcentaje numeric(18,2),
	@Duracion int,
	@Activo bit
AS
	UPDATE ATJ.Visibilidades SET Descripcion = @Descripcion, Precio = @Precio, Porcentaje = @Porcentaje, Duracion = @Duracion, Activo = @Activo
	WHERE cod_Visibilidad = @cod_Visibilidad
GO

--Procedure updatePublicacion
CREATE PROCEDURE ATJ.updatePublicacion
	@Codigo int,
	@id_Usuario numeric(18,0),
	@Descripcion nvarchar(255),
	@Stock numeric(18,0),
	@Fecha_creacion datetime,
	@Fecha_vencimiento datetime,
	@Precio numeric(18,2),
	@id_Tipo numeric(18,0),
	@cod_Visibilidad numeric(18,0),
	@id_Estado numeric(18,0),
	@permiso_Preguntas bit
AS
	UPDATE ATJ.Publicaciones SET id_Usuario = @id_Usuario, Descripcion = @Descripcion, Stock = @Stock, Fecha_creacion = @Fecha_creacion, 
	Fecha_vencimiento = @Fecha_vencimiento,Precio = @Precio, id_Tipo = @id_Tipo, cod_Visibilidad = @cod_Visibilidad, id_Estado = @id_Estado, permiso_Preguntas = @permiso_Preguntas
	WHERE Codigo = @Codigo
GO


--Procedure insertVisibilidad_RetornarID
CREATE PROCEDURE ATJ.insertVisibilidad_RetornarID
	@Descripcion nvarchar(255),
	@Precio numeric(18,2),
	@Porcentaje numeric(18,2),
	@Duracion int,
	@Activo bit
AS
	INSERT INTO ATJ.Visibilidades
	(Descripcion, Precio, Porcentaje,Duracion, Activo)
	VALUES 
	(@Descripcion, @Precio, @Porcentaje, @Duracion, @Activo)
	
	SELECT @@IDENTITY AS cod_Visibilidad;
GO

--Procedure insertPublicacion_RetornarID
CREATE PROCEDURE ATJ.insertPublicacion_RetornarID
	@id_Usuario numeric(18,0),
	@Descripcion nvarchar(255),
	@Stock numeric(18,0),
	@Fecha_creacion datetime,
	@Fecha_vencimiento datetime,
	@Precio numeric(18,2),
	@id_Tipo numeric(18,0),
	@cod_Visibilidad numeric(18,0),
	@id_Estado numeric(18,0),
	@permiso_Preguntas bit
AS
	INSERT INTO ATJ.Publicaciones
	(id_Usuario, Descripcion, Stock, Fecha_creacion, Fecha_vencimiento, Precio, id_Tipo, cod_Visibilidad, id_Estado, permiso_Preguntas)
	VALUES 
	(@id_Usuario, @Descripcion, @Stock, @Fecha_creacion, @Fecha_vencimiento, @Precio, @id_Tipo, @cod_Visibilidad, @id_Estado, @permiso_Preguntas)
	
	SELECT @@IDENTITY AS Codigo;
GO


--Procedure insertOferta_RetornarID
CREATE PROCEDURE ATJ.insertOferta_RetornarID
	@cod_Publicacion numeric (18,0),
	@id_Usuario_Vendedor int,
	@id_Usuario_Comprador int,
	@Fecha datetime,
	@Monto numeric(18,2)
AS
	INSERT INTO ATJ.Ofertas
	(cod_Publicacion, id_Usuario_Vendedor, id_Usuario_Comprador, Fecha, Monto)
	VALUES 
	(@cod_Publicacion, @id_Usuario_Vendedor, @id_Usuario_Comprador, @Fecha, @Monto)
	
	SELECT @@IDENTITY AS id_Oferta;
GO

--Procedure insertCompra_RetornarID
CREATE PROCEDURE ATJ.insertCompra_RetornarID
	@cod_Publicacion numeric (18,0),
	@id_Usuario_Vendedor int,
	@id_Usuario_Comprador int,
	@Fecha datetime,
	@Cantidad numeric(18,0)
AS
	INSERT INTO ATJ.Compras
	(cod_Publicacion, id_Usuario_Vendedor, id_Usuario_Comprador, Fecha, Cantidad)
	VALUES 
	(@cod_Publicacion, @id_Usuario_Vendedor, @id_Usuario_Comprador, @Fecha, @Cantidad)
	
	SELECT @@IDENTITY AS id_Compra;
GO


--Procedure insertPregunta_RetornarID
CREATE PROCEDURE ATJ.insertPregunta_RetornarID
	@txtPregunta nvarchar(255),
	@id_Usuario int,
	@cod_Publicacion numeric(18,0)
AS
	INSERT INTO ATJ.Preguntas
	(Pregunta, id_Usuario,cod_Publicacion)
	VALUES 
	(@txtPregunta, @id_Usuario,@cod_Publicacion)
	
	SELECT @@IDENTITY AS id_Pregunta;
GO


--traerListadoFuncionalidadesPorNombre
CREATE PROCEDURE ATJ.traerListadoVisibilidadesPorDescripcion
	@Descripcion nvarchar(255)
AS
	SELECT * FROM ATJ.Visibilidades where Descripcion = @Descripcion AND Eliminado = 0
GO

--traerListadoRolesPorNombre
CREATE PROCEDURE ATJ.traerListadoRolesPorNombre
	@Nombre nvarchar(255)
AS
	SELECT * FROM ATJ.Roles where Nombre LIKE '%' + @Nombre + '%' AND Eliminado = 0
GO


--Procedure traerListadoRubrosPorId_Rubro
CREATE PROCEDURE [ATJ].[traerListadoRubrosPorId_Rubro] 
    @id_Rubro numeric(18,0) 
AS 
    SELECT * FROM ATJ.Rubros
	WHERE id_Rubro = @id_Rubro
GO

--Procedure traerListadoClientesPorId_Usuario
CREATE PROCEDURE [ATJ].[traerListadoClientesPorId_Usuario] 
    @id_Usuario numeric(18,0) 
AS 
    SELECT * FROM ATJ.Clientes
	WHERE id_Usuario = @id_Usuario
GO

--Procedure traerListadoEmpresasPorId_Usuario
CREATE PROCEDURE [ATJ].[traerListadoEmpresasPorId_Usuario] 
    @id_Usuario numeric(18,0) 
AS 
    SELECT * FROM ATJ.Empresas
	WHERE id_Usuario = @id_Usuario
GO

--Procedure traerListadoVisibilidadesPorCod_Visibilidad
CREATE PROCEDURE [ATJ].[traerListadoVisibilidadesPorCod_Visibilidad] 
    @cod_Visibilidad numeric(18,0) 
AS 
    SELECT * FROM ATJ.Visibilidades
	WHERE cod_Visibilidad = @cod_Visibilidad AND Eliminado = 0
GO

--Procedure traerListadoEstados_PublicacionPorId_Estado
CREATE PROCEDURE [ATJ].[traerListadoEstados_PublicacionPorId_Estado] 
    @id_Estado numeric(18,0) 
AS 
    SELECT * FROM ATJ.Estados_Publicacion
	WHERE id_Estado = @id_Estado
GO

--Procedure traerListadoEstados_Publicacion
CREATE PROCEDURE [ATJ].[traerListadoEstados_Publicacion] 
AS 
    SELECT * FROM ATJ.Estados_Publicacion
GO

--Procedure traerListadoTipos_PublicacionPorId_Tipo
CREATE PROCEDURE [ATJ].[traerListadoTipos_PublicacionPorId_Tipo] 
    @id_Tipo numeric(18,0) 
AS 
    SELECT * FROM ATJ.Tipos_Publicacion
	WHERE id_Tipo = @id_Tipo
GO

--Procedure traerListadoTipos_Publicacion
CREATE PROCEDURE [ATJ].[traerListadoTipos_Publicacion] 
AS 
    SELECT * FROM ATJ.Tipos_Publicacion
GO

--Procedure traerListadoUsuariosPorId_Usuario
CREATE PROCEDURE [ATJ].[traerListadoUsuariosPorId_Usuario] 
    @id_Usuario numeric(18,0) 
AS 
    SELECT * FROM ATJ.Usuarios
	WHERE id_Usuario = @id_Usuario
GO

--Procedure traerListadoPublicacionesPorCod_Publicacion
CREATE PROCEDURE [ATJ].[traerListadoPublicacionesPorCod_Publicacion] 
    @cod_Publicacion numeric(18,0) 
AS 
    SELECT * FROM ATJ.Publicaciones
	WHERE Codigo = @cod_Publicacion
GO

--Procedure traerListadoPublicacionesPorId_Usuario
CREATE PROCEDURE [ATJ].[traerListadoPublicacionesPorId_Usuario] 
    @id_Usuario numeric(18,0) 
AS 
    SELECT P.*
    FROM ATJ.Publicaciones P
	WHERE P.id_Usuario = @id_Usuario
GO


--Procedure traerListadoPublicacionesNoVendidasOrdenadoPorVisibilidad
CREATE PROCEDURE [ATJ].[traerListadoPublicacionesNoVendidasOrdenadoPorVisibilidad] 
	@Fecha_Vencimiento datetime
AS 
    SELECT P.*
    FROM ATJ.Publicaciones P
    INNER JOIN ATJ.Visibilidades V on V.cod_Visibilidad = P.cod_Visibilidad
    INNER JOIN ATJ.Estados_Publicacion E on E.id_Estado = P.id_Estado
	WHERE P.Fecha_Vencimiento > @Fecha_Vencimiento AND P.Stock > 0 AND E.Nombre IN ('Publicada')
	ORDER BY V.Precio DESC
GO

--Procedure traerListadoPublicaciones
CREATE PROCEDURE [ATJ].[traerListadoPublicacionesNoVendidasOrdenadoPorVisibilidadConFiltros] 
	@Fecha_Vencimiento datetime,
	@Descripcion nvarchar(255),
	@filtroRubros nvarchar(500)
AS 
    SELECT P.*
    FROM ATJ.Publicaciones P
    INNER JOIN ATJ.Visibilidades V on V.cod_Visibilidad = P.cod_Visibilidad
    INNER JOIN ATJ.Estados_Publicacion E on E.id_Estado = P.id_Estado
	INNER JOIN ATJ.Rubros_Publicacion RP on RP.cod_Publicacion = P.Codigo
    INNER JOIN ATJ.Rubros R on R.id_Rubro = RP.id_Rubro
	WHERE P.Fecha_Vencimiento > @Fecha_Vencimiento AND P.Stock > 0 AND E.Nombre IN ('Publicada')
	AND P.Descripcion LIKE (CASE WHEN @Descripcion <> '' THEN '%' + @Descripcion + '%' ELSE P.Descripcion END)
	AND R.Descripcion IN (CASE WHEN @filtroRubros <> '' THEN @filtroRubros ELSE R.Descripcion END)	
	ORDER BY V.Precio DESC
	
GO

--Procedure traerListadoPublicacionesPorId_UsuarioYFiltros
CREATE PROCEDURE [ATJ].[traerListadoPublicacionesPorId_UsuarioYFiltros] 
    @id_Usuario numeric(18,0),
	@Descripcion nvarchar(255)
AS 
    SELECT P.*
    FROM ATJ.Publicaciones P
	WHERE P.id_Usuario = @id_Usuario AND P.Descripcion LIKE '%' + @Descripcion + '%'
GO



--Procedure traerListadoEstados_PublicacionEditablesConPublicada
CREATE PROCEDURE [ATJ].[traerListadoEstados_PublicacionEditablesConPublicada] 
AS 
    SELECT * FROM ATJ.Estados_Publicacion
	WHERE Nombre IN ('Pausada', 'Finalizada', 'Publicada')
GO

--Procedure traerListadoUsuarios
CREATE PROCEDURE ATJ.traerListadoUsuarios
AS
	SELECT * FROM ATJ.Usuarios
	WHERE Activo = 1
GO

--Procedure traerListadoPublicacionesGratuitasPorId_Usuario
CREATE PROCEDURE ATJ.traerListadoPublicacionesGratuitasPorId_Usuario
	@id_Usuario numeric(18,0)
AS
	SELECT * FROM ATJ.Publicaciones P
	INNER JOIN ATJ.Visibilidades V ON V.cod_Visibilidad = P.cod_Visibilidad
	WHERE V.Descripcion = 'Gratis' AND P.id_Usuario = @id_Usuario
GO


--Procedure traerListadoEmpresas 
CREATE PROCEDURE ATJ.traerListadoEmpresas
    
AS 
    SELECT *, (Dom_calle+' '+Convert(nvarchar(50),Dom_nro_calle)+' '+Convert(nvarchar(50),Dom_piso)+'° '+Dom_depto) AS Direccion
    FROM ATJ.Empresas  
    WHERE Eliminado = 0 
			
GO

--Procedure traerListadoClientes
CREATE PROCEDURE ATJ.traerListadoClientes
    
AS 
    SELECT *, (Dom_calle+' '+Convert(nvarchar(50),Dom_nro_calle)+' '+Convert(nvarchar(50),Dom_piso)+'° '+Dom_depto) AS Direccion
    FROM ATJ.Clientes
    WHERE Eliminado = 0
GO

--Procedure traerEmpresaConId 
CREATE PROCEDURE ATJ.traerEmpresaConId
    @id_Empresa int
AS 
    SELECT *
    FROM ATJ.Empresas
    WHERE	id_Empresa = @id_Empresa
GO
--Procedure traerClienteaConId 
CREATE PROCEDURE ATJ.traerClienteConId
    @id_Cliente int
AS 
    SELECT *
    FROM ATJ.Clientes 
    WHERE	id_Cliente = @id_Cliente  
			
GO

--Procedure updateEmpresa
CREATE PROCEDURE ATJ.updateEmpresa
	@id_empresa int,
	@Razon_social nvarchar(255) =null,
	@Cuit nvarchar(50) =null,
	@Mail nvarchar(50) =null,
	@Fecha_creacion datetime =null,
	@Telefono nvarchar(255) =null,
	@Dom_calle nvarchar(100) =null,
	@Dom_nro_calle numeric(18,0) =null,
	@Dom_piso numeric(18,0) =null,
	@Dom_depto nvarchar(50) =null,
	@Dom_cod_postal nvarchar(50) =null,
	@Dom_ciudad nvarchar(255) =null,
	@Nombre_contacto nvarchar(255) =null,
	@Activo bit
AS
	UPDATE ATJ.Empresas SET Razon_social = @Razon_social,
							Cuit = @Cuit,
							Fecha_creacion = @Fecha_creacion,
							Mail = @Mail,
							Telefono = @Telefono,
							Dom_calle = @Dom_calle,
							Dom_nro_calle = @Dom_nro_calle,
							Dom_piso = @Dom_piso,
							Dom_depto = @Dom_depto,
							Dom_cod_postal = @Dom_cod_postal,
							Dom_ciudad = @Dom_ciudad,
							Nombre_contacto = @Nombre_contacto,
							Activo = @Activo
							where id_Empresa = @id_empresa
GO
--Procedure deleteEmpresa
CREATE PROCEDURE ATJ.deleteEmpresa
	@id_empresa int
AS
	UPDATE ATJ.Empresas SET eliminado = 1
							where id_Empresa = @id_empresa
GO

--Procedure updateCliente
CREATE PROCEDURE ATJ.updateCliente
	@id_Cliente int,
	@id_Rol int,
	@Tipo_Dni nvarchar(50) =null,
	@Dni numeric(18,0) =null,
	@Cuil nvarchar(50) =null,
	@Apellido nvarchar(255) =null,
	@Nombre nvarchar(255) =null,
	@Fecha_nac datetime =null,
	@Mail nvarchar(255) =null,
	@Telefono nvarchar(255) =null,
	@Dom_calle nvarchar(255) =null,
	@Dom_nro_calle numeric(18,0) =null,
	@Dom_piso numeric(18,0) =null,
	@Dom_depto nvarchar(50) =null,
	@Dom_cod_postal nvarchar(50) =null,
	@Dom_ciudad nvarchar(255) =null,
	@Activo bit
AS
	UPDATE ATJ.Clientes SET Tipo_Dni = @Tipo_Dni,
							Dni = @Dni,
							Cuil = @Cuil,
							Apellido = @Apellido,
							Nombre = @Nombre,
							Fecha_nac = @Fecha_nac,
							Mail = @Mail,
							Telefono = @Telefono,
							Dom_calle = @Dom_calle,
							Dom_nro_calle = @Dom_nro_calle,
							Dom_piso = @Dom_piso,
							Dom_depto = @Dom_depto,
							Dom_cod_postal = @Dom_cod_postal,
							Dom_ciudad = @Dom_ciudad,
							Activo = @Activo
							where id_Cliente = @id_Cliente
GO
--Procedure deleteCliente
CREATE PROCEDURE ATJ.deleteCliente
	@id_cliente int
AS
	UPDATE ATJ.Clientes SET eliminado = 1
							where id_Cliente = @id_cliente 
GO

--Proceddure insertEmpresa
CREATE PROCEDURE ATJ.insertEmpresa
	@Razon_social nvarchar(255) =null,
	@Cuit nvarchar(50) =null,
	@Mail nvarchar(50) =null,
	@Fecha_creacion datetime =null,
	@Telefono nvarchar(255) =null,
	@Dom_calle nvarchar(100) =null,
	@Dom_nro_calle numeric(18,0) =null,
	@Dom_piso numeric(18,0) =null,
	@Dom_depto nvarchar(50) =null,
	@Dom_cod_postal nvarchar(50) =null,
	@Dom_ciudad nvarchar(255) =null,
	@Nombre_contacto nvarchar(255) =null,
	@Activo bit,
	@id_Rol int,
	@id_Usuario int
	
AS
	INSERT INTO ATJ.Empresas 
	(Razon_social, Cuit, Fecha_creacion, Mail, Telefono, Dom_calle, Dom_nro_calle,
	Dom_piso, Dom_depto, Dom_cod_postal, Dom_ciudad, Nombre_contacto, Activo, id_Usuario)
	VALUES
	(@Razon_social, @Cuit, @Fecha_creacion, @Mail, @Telefono, @Dom_calle, @Dom_nro_calle,
	@Dom_piso, @Dom_depto, @Dom_cod_postal, @Dom_ciudad, @Nombre_contacto,@Activo, @id_Usuario)
	
	INSERT INTO ATJ.Rol_Usuario 
	(id_Rol, id_Usuario)
	VALUES
	(@id_Rol, @id_Usuario)
GO

--Procedure insertCliente
CREATE PROCEDURE ATJ.insertCliente
	@Tipo_Dni nvarchar(50) =null,
	@Dni numeric(18,0) =null,
	@Cuil nvarchar(50) =null,
	@Apellido nvarchar(255) =null,
	@Nombre nvarchar(255) =null,
	@Fecha_nac datetime =null,
	@Mail nvarchar(50) =null,
	@Telefono nvarchar(255) =null,
	@Dom_calle nvarchar(100) =null,
	@Dom_nro_calle numeric(18,0) =null,
	@Dom_piso numeric(18,0) =null,
	@Dom_depto nvarchar(50) =null,
	@Dom_cod_postal nvarchar(50) =null,
	@Dom_ciudad nvarchar(255) =null,
	@Activo bit,
	@id_Rol int,
	@id_Usuario int
	
AS
	INSERT INTO ATJ.Clientes
	(Tipo_Dni, Dni, Cuil, Apellido, Nombre, Fecha_nac, Mail, Telefono, Dom_calle, Dom_nro_calle,
	Dom_piso, Dom_depto, Dom_cod_postal, Dom_ciudad, Activo, id_Usuario)
	VALUES
	(@Tipo_Dni, @Dni, @Cuil, @Apellido, @Nombre, @Fecha_nac, @Mail, @Telefono, @Dom_calle, @Dom_nro_calle,
	@Dom_piso, @Dom_depto, @Dom_cod_postal, @Dom_ciudad, @Activo, @id_Usuario)

	INSERT INTO ATJ.Rol_Usuario 
	(id_Rol, id_Usuario)
	VALUES
	(@id_Rol, @id_Usuario)
GO

--Procedure traerListadoEmpresasConFiltros 
CREATE PROCEDURE ATJ.traerListadoEmpresasConFiltros
    @Razon_social nvarchar(255), 
    @Cuit nvarchar(50),
    @Mail nvarchar(50)
    
AS 
    SELECT *, (Dom_calle+' '+Convert(nvarchar(50),Dom_nro_calle)+' '+Convert(nvarchar(50),Dom_piso)+'° '+Dom_depto) AS Direccion
    FROM ATJ.Empresas
    WHERE	Razon_social LIKE( CASE WHEN @Razon_social <> '' THEN '%' + @Razon_social + '%' ELSE Razon_social END) 
    AND		Cuit = (CASE WHEN @Cuit <> '' THEN @Cuit ELSE Cuit END) 
	AND		Mail LIKE (CASE WHEN @Mail <> '' THEN '%' + @Mail + '%' ELSE Mail END)
	AND		Eliminado = 0
GO

--Procedure traerListadoClientesConFiltros
CREATE PROCEDURE ATJ.traerListadoClientesConFiltros 
    @Nombre nvarchar(255)=null, 
    @Apellido nvarchar(255)=null,
    @Tipo_Dni nvarchar(50)=null,
    @Dni numeric(18,0)=null,
    @Mail nvarchar(255)=null
AS 
    SELECT *
    FROM ATJ.Clientes
    WHERE	Nombre LIKE (CASE WHEN @Nombre <> '' THEN '%' + @Nombre + '%' ELSE Nombre END) 
    AND		Apellido LIKE (CASE WHEN @Apellido <> '' THEN '%' + @Apellido + '%' ELSE Apellido END) 
    AND		Tipo_Dni = (CASE WHEN @Tipo_Dni <> '' THEN @Tipo_Dni ELSE Tipo_Dni END) 
    AND		Mail LIKE (CASE WHEN @Mail <> '' THEN '%' + @Mail + '%' ELSE Mail END) 
    AND		(@Dni is null OR @Dni = 0 OR CONVERT(VARCHAR(10), Dni) LIKE '%' + CONVERT(VARCHAR(10), @Dni) + '%')
    AND		Eliminado = 0
GO

--Procedure deshabilitarEmpresa
CREATE PROCEDURE ATJ.deshabilitarEmpresa
	@id_Empresa int
AS
	UPDATE ATJ.Empresas SET Activo = 0 where id_Empresa = @id_Empresa	
GO

--Procedure deshabilitarCliente
CREATE PROCEDURE ATJ.deshabilitarCliente
	@id_Cliente int
AS
	UPDATE ATJ.Clientes SET Activo = 0 where id_Cliente = @id_Cliente	
GO
--Procedure insertUsuario
CREATE PROCEDURE ATJ.insertUsuario
	@Username nvarchar(255),
	@Clave nvarchar(255),
	@ClaveAutoGenerada bit,
	@Activo bit
AS
	INSERT INTO ATJ.Usuarios
	(Username, Clave, ClaveAutoGenerada, Activo)
	VALUES
	(@Username, @Clave, @ClaveAutoGenerada, @Activo)
GO

--Procedure insertUsuario_RetornarID
CREATE PROCEDURE ATJ.insertUsuario_RetornarID
	@Username nvarchar(255),
	@Clave nvarchar(255),
	@ClaveAutoGenerada bit,
	@Activo bit
AS 
	INSERT INTO ATJ.Usuarios
	(Username, Clave, ClaveAutoGenerada, Activo)
	VALUES
	(@Username, @Clave, @ClaveAutoGenerada, @Activo)
	
	SELECT @@IDENTITY AS id_Usuario;

GO

--------Procedure insertUsuario_RetornarID
------alter PROCEDURE ATJ.insertUsuario_RetornarID
------	@idRol int,
------	@Username nvarchar(255),
------	@Clave nvarchar(255),
------	@ClaveAutoGenerada bit,
------	@Activo bit
------AS 
  
------	INSERT INTO ATJ.Usuarios
------	(Username, Clave, ClaveAutoGenerada, Activo)
------	VALUES
------	(@Username, @Clave, @ClaveAutoGenerada, @Activo)
	
------DECLARE @id_Usuario int
------SET @id_Usuario = (SELECT id_Usuario FROM atj.Usuarios Where Username = @Username)

------	INSERT INTO ATJ.Rol_Usuario 
------	(id_Rol, id_Usuario)
------	VALUES
------	(@idRol, @id_Usuario)
	
------	SELECT @@IDENTITY AS id_Usuario;

------GO

--Procedure traerListadoPublicacionesConCodigo
CREATE PROCEDURE ATJ.traerListadoPublicacionesConCodigo
    @id_Publicacion int

AS 
    SELECT *
    FROM ATJ.Publicaciones 
    WHERE	Codigo = @id_Publicacion 
GO

--Procedure traerVendedorPorId_Usuario 
CREATE PROCEDURE ATJ.traerVendedorPorId_Usuario 
    @id_Usuario int
AS 
  
DECLARE @id_Rol int
SET @id_Rol = (SELECT id_Rol FROM atj.Rol_Usuario Where id_Usuario = @id_Usuario)
IF @id_rol = 2 
SELECT	C.*
    FROM ATJ.Usuarios U
    INNER JOIN ATJ.Clientes C ON u.id_Usuario = c.id_Cliente 
    WHERE u.id_Usuario = @id_Usuario
ELSE
SELECT E.*
	FROM ATJ.Usuarios U
	INNER JOIN ATJ.Empresas E ON U.id_Usuario = E.id_Usuario
	WHERE U.id_Usuario = @id_Usuario

GO

--Procedure traerPreguntasNoRespondidasPorUsuario
CREATE PROCEDURE ATJ.traerPreguntasNoRespondidasPorUsuario
    @id_Usuario int
AS 
    SELECT *
    FROM ATJ.Usuarios U 
    INNER JOIN ATJ.Publicaciones P ON U.id_Usuario = P.id_Usuario 
    INNER JOIN ATJ.Preguntas R ON R.cod_Publicacion = P.Codigo 
    WHERE	R.Respuesta IS NULL
	AND		U.id_Usuario = @id_Usuario		
GO
--Procedure updatePregunta
CREATE PROCEDURE ATJ.updatePregunta
    
	@id_Pregunta int,
	@Respuesta nvarchar(255),
	@Fecha_respuesta datetime
AS
	UPDATE ATJ.Preguntas SET Respuesta = @Respuesta,
							Fecha_respuesta = @Fecha_respuesta
							where id_Pregunta = @id_Pregunta 
	
GO
--Procedure traerPreguntasRespondidasPorUsuario
CREATE PROCEDURE ATJ.traerPreguntasRespondidasPorUsuario
    @id_Usuario int
AS 
    SELECT *
    FROM ATJ.Usuarios U 
    INNER JOIN ATJ.Publicaciones P ON U.id_Usuario = P.id_Usuario 
    INNER JOIN ATJ.Preguntas R ON R.cod_Publicacion = P.Codigo 
    WHERE	R.Respuesta IS NOT NULL
	AND		U.id_Usuario = @id_Usuario		
GO
--Procedure traerListadoUsuariosVendedoresSinCalificar
CREATE PROCEDURE ATJ.traerListadoUsuariosVendedoresSinCalificar
	@id_Usuario int
AS
	SELECT	c.cod_Publicacion,
			Vendedor = (CASE WHEN E.id_Usuario IS NULL THEN S.Nombre+' '+S.Apellido ELSE E.Razon_social END),
			T.Nombre, P.Descripcion, C.Fecha
	FROM ATJ.Compras C
	INNER JOIN ATJ.Publicaciones P ON P.Codigo = C.cod_Publicacion
	INNER JOIN ATJ.Tipos_Publicacion T ON T.id_Tipo = P.id_Tipo
	LEFT JOIN ATJ.Empresas E ON C.id_Usuario_Vendedor = E.id_Usuario
	LEFT JOIN ATJ.Clientes S ON C.id_Usuario_Vendedor = S.id_Usuario
	WHERE	id_Usuario_Comprador = @id_Usuario 
	AND		C.cod_Publicacion NOT IN (SELECT cod_Publicacion FROM ATJ.Calificaciones)
GO

--Procedure insertCalificacion
CREATE PROCEDURE ATJ.insertCalificacion
	@id_Usuario int,
	@cod_Publicacion int,
	@CantEstrellas numeric(18,0),
	@Descripcion nvarchar(255)
AS
	INSERT INTO ATJ.Calificaciones 
	(id_Usuario_Calificador, cod_Publicacion, Cant_Estrellas, Descripcion)
	VALUES
	(@id_Usuario, @cod_Publicacion, (@CantEstrellas * 2), @Descripcion)
GO

--Procedure validarTelefonoEnCliente
CREATE PROCEDURE ATJ.validarTelefonoEnCliente
	@Tipo_Dni nvarchar(50) =null,
	@Dni numeric(18,0) =null,
	@Cuil nvarchar(50) =null,
	@Apellido nvarchar(255) =null,
	@Nombre nvarchar(255) =null,
	@Fecha_nac datetime =null,
	@Mail nvarchar(50) =null,
	@Telefono nvarchar(255) =null,
	@Dom_calle nvarchar(100) =null,
	@Dom_nro_calle numeric(18,0) =null,
	@Dom_piso numeric(18,0) =null,
	@Dom_depto nvarchar(50) =null,
	@Dom_cod_postal nvarchar(50) =null,
	@Dom_ciudad nvarchar(255) =null,
	@Activo bit,
	@id_Rol int,
	@id_Cliente int =null,
	@id_Usuario int=null
	
AS
	SELECT * FROM ATJ.Clientes 
	WHERE Telefono = @Telefono
	AND (id_Cliente <> @id_Cliente OR @id_Cliente is null)
	AND (id_Usuario <> @id_Usuario OR @id_Usuario is null)
GO

--Procedure validarDniEnCliente
CREATE PROCEDURE ATJ.validarDniEnCliente
	@Tipo_Dni nvarchar(50) =null,
	@Dni numeric(18,0) =null,
	@Cuil nvarchar(50) =null,
	@Apellido nvarchar(255) =null,
	@Nombre nvarchar(255) =null,
	@Fecha_nac datetime =null,
	@Mail nvarchar(50) =null,
	@Telefono nvarchar(255) =null,
	@Dom_calle nvarchar(100) =null,
	@Dom_nro_calle numeric(18,0) =null,
	@Dom_piso numeric(18,0) =null,
	@Dom_depto nvarchar(50) =null,
	@Dom_cod_postal nvarchar(50) =null,
	@Dom_ciudad nvarchar(255) =null,
	@Activo bit,
	@id_Rol int,
	@id_Cliente int =null,
	@id_Usuario int=null
	
AS
	SELECT * FROM ATJ.Clientes 
	WHERE Dni = @Dni
	AND (id_Cliente <> @id_Cliente OR @id_Cliente is null)
	AND (id_Usuario <> @id_Usuario OR @id_Usuario is null)
	
GO

--Procedure validarCuitEnEmpresa
CREATE PROCEDURE ATJ.validarCuitEnEmpresa
	@Razon_social nvarchar(255) =null,
	@Cuit nvarchar(50) =null,
	@Mail nvarchar(50) =null,
	@Fecha_creacion datetime =null,
	@Telefono nvarchar(255) =null,
	@Dom_calle nvarchar(100) =null,
	@Dom_nro_calle numeric(18,0) =null,
	@Dom_piso numeric(18,0) =null,
	@Dom_depto nvarchar(50) =null,
	@Dom_cod_postal nvarchar(50) =null,
	@Dom_ciudad nvarchar(255) =null,
	@Nombre_contacto nvarchar(255) =null,
	@Activo bit,
	@id_Rol int =null,
	@id_Usuario int =null,
	@id_empresa int =null	
AS
	SELECT * FROM ATJ.Empresas
	WHERE Cuit = @Cuit
	AND (id_Empresa <> @id_empresa OR @id_empresa is null)
	AND (id_Usuario <> @id_Usuario OR @id_Usuario is null)
	
GO

--Procedure validarUsernameEnUsuario
CREATE PROCEDURE ATJ.validarUsernameEnUsuario
	@Username nvarchar(255)
	
AS
	SELECT * FROM ATJ.Usuarios WHERE Username = @Username 
GO

-- Procedure traerListadoUsuariosCompras
CREATE PROCEDURE [ATJ].[traerListadoUsuariosCompras] 
    @id_Usuario numeric(18,0)
AS
SELECT C.id_Compra AS id_Compra,C.cod_Publicacion AS cod_Publicacion,
Vendedor = (CASE WHEN E.id_Usuario IS NULL THEN S.Nombre+' '+S.Apellido ELSE E.Razon_social END), 
C.Fecha AS Fecha, C.Cantidad AS Cantidad
FROM ATJ.Compras C
LEFT JOIN ATJ.Empresas E ON C.id_Usuario_Vendedor = E.id_Usuario
LEFT JOIN ATJ.Clientes S ON C.id_Usuario_Vendedor = S.id_Usuario
WHERE id_Usuario_Comprador = @id_Usuario
GO

--Prodedure traerListadoUsuariosOfertas
CREATE PROCEDURE [ATJ].[traerListadoUsuariosOfertas]
	@id_Usuario numeric(18,0)
AS
SELECT O.id_Oferta AS id_Oferta, O.cod_Publicacion AS cod_Publicacion, 
Vendedor = (CASE WHEN E.id_Usuario IS NULL THEN C.Nombre+' '+C.Apellido ELSE E.Razon_social END),
O.gano_Subasta AS gano_Subasta, O.Fecha AS Fecha, O.Monto AS Monto
FROM ATJ.Ofertas O 
LEFT JOIN ATJ.Empresas E ON E.id_Usuario = O.id_Usuario_Vendedor
LEFT JOIN ATJ.Clientes C ON C.id_Usuario = O.id_Usuario_Vendedor
WHERE id_Usuario_Comprador = @id_Usuario
GO

--Procedure traerListadoUsuariosCalificacionesRecibidas
CREATE PROCEDURE [ATJ].[traerListadoUsuariosCalificacionesRecibidas]
	@id_Usuario numeric(18,0)
AS
SELECT C.cod_Calificacion AS cod_Calificacion, 
Calificador = (S.Nombre+' '+S.Apellido),
C.Cant_Estrellas AS cant_Estrellas, C.Descripcion AS Descripcion
FROM ATJ.Calificaciones C
INNER JOIN ATJ.Publicaciones P ON P.Codigo = C.cod_Publicacion
INNER JOIN ATJ.Clientes S ON S.id_Usuario = C.id_Usuario_Calificador
WHERE P.id_Usuario = @id_Usuario
GO

--Procedure traerListadoUsuariosCalificacionesOtorgadas
CREATE PROCEDURE [ATJ].[traerListadoUsuariosCalificacionesOtorgadas]
	@id_Usuario numeric(18,0)
AS
SELECT C.cod_Calificacion AS cod_Calificacion, 
Calificado = (CASE WHEN E.id_Usuario IS NULL THEN S.Nombre+' '+S.Apellido ELSE E.Razon_social END),
C.Cant_Estrellas AS cant_Estrellas, C.Descripcion AS Descripcion
FROM ATJ.Calificaciones C
INNER JOIN Publicaciones P ON P.Codigo = C.cod_Publicacion
LEFT JOIN ATJ.Empresas E ON E.id_Usuario = P.id_Usuario
LEFT JOIN ATJ.Clientes S ON S.id_Usuario = P.id_Usuario
WHERE C.id_Usuario_Calificador = @id_Usuario
GO

--Procedure traerListadoUsuariosConMayorCantidadDeProductosSinVender
CREATE PROCEDURE [ATJ].[traerListadoUsuariosConMayorCantidadDeProductosSinVender]
	@Fecha_Hasta datetime,
	@Fecha_Desde datetime,
	@Anio nvarchar(4)
AS

SELECT TOP 5 Vendedor = (CASE WHEN  (E.id_Usuario IS NULL AND s.id_Usuario IS null) THEN 'Admin' ELSE
(CASE WHEN  E.id_Usuario IS NULL THEN S.Nombre+' '+S.Apellido ELSE E.Razon_social END) END),
COUNT(P.Codigo) AS CantPublicNoVendidos
FROM ATJ.Publicaciones P
LEFT JOIN ATJ.Empresas E ON E.id_Usuario = P.id_Usuario
LEFT JOIN ATJ.Clientes S ON S.id_Usuario = P.id_Usuario
WHERE MONTH(P.Fecha_creacion) BETWEEN MONTH(@Fecha_Desde) AND MONTH(@Fecha_Hasta)
AND YEAR(P.Fecha_creacion) = @Anio
AND(P.Codigo NOT IN (SELECT C.cod_Publicacion FROM ATJ.Compras C))
GROUP BY P.id_Usuario, E.id_Usuario, S.Nombre, S.Apellido, E.Razon_social, S.id_Usuario
ORDER BY CantPublicNoVendidos DESC
GO

--Procedure traerListadoUsuariosConMayorFacturacion
CREATE PROCEDURE [ATJ].[traerListadoUsuariosConMayorFacturacion]
	@Fecha_Hasta datetime,
	@Fecha_Desde datetime,
	@Anio nvarchar(4)
AS

SELECT TOP 5 Vendedor = (CASE WHEN  E.id_Usuario IS NULL THEN S.Nombre+' '+S.Apellido ELSE E.Razon_social END),
SUM(P.Precio) AS Facturacion
FROM ATJ.Publicaciones P
LEFT JOIN ATJ.Empresas E ON E.id_Usuario = P.id_Usuario
LEFT JOIN ATJ.Clientes S ON S.id_Usuario = P.id_Usuario
WHERE MONTH(P.Fecha_creacion) BETWEEN MONTH(@Fecha_Desde) AND MONTH(@Fecha_Hasta)
AND YEAR(P.Fecha_creacion) = @Anio
AND P.id_Usuario IN (SELECT F.id_Usuario FROM ATJ.Facturas F)
GROUP BY P.id_Usuario, E.id_Usuario, S.Nombre, S.Apellido, E.Razon_social
ORDER BY Facturacion DESC
GO

-- Procedure traerListadoUsuariosConMayorCalificacion
CREATE PROCEDURE [ATJ].[traerListadoUsuariosConMayorCalificacion]
	@Fecha_Hasta datetime,
	@Fecha_Desde datetime,
	@Anio nvarchar(4)
AS

SELECT TOP 5 Vendedor = (CASE WHEN  E.id_Usuario IS NULL THEN S.Nombre+' '+S.Apellido ELSE E.Razon_social END),
CAST(AVG(C.Cant_Estrellas) AS numeric(18,2)) AS PromedioCalificaciones
FROM ATJ.Calificaciones C
INNER JOIN ATJ.Publicaciones P ON P.Codigo = C.cod_Publicacion
LEFT JOIN ATJ.Empresas E ON E.id_Usuario = P.id_Usuario
LEFT JOIN ATJ.Clientes S ON S.id_Usuario = P.id_Usuario
WHERE MONTH(P.Fecha_creacion) BETWEEN MONTH(@Fecha_Desde) AND MONTH(@Fecha_Hasta)
AND YEAR(P.Fecha_creacion) = @Anio
GROUP BY P.id_Usuario, E.id_Usuario, S.Nombre, S.Apellido, E.Razon_social, S.id_Usuario 
ORDER BY PromedioCalificaciones DESC
GO

-- Procedure traerListadoUsuariosConMayorCantDePublicacionesSinCalificar
CREATE PROCEDURE [ATJ].[traerListadoUsuariosConMayorCantDePublicacionesSinCalificar]
	@Fecha_Hasta datetime,
	@Fecha_Desde datetime,
	@Anio nvarchar(4)

AS

SELECT TOP 5 Cliente = (CASE WHEN  E.id_Usuario IS NULL THEN S.Nombre+' '+S.Apellido ELSE E.Razon_social END),
COUNT(P.Codigo) AS CantPubliSinClasificar
FROM ATJ.Publicaciones P
LEFT JOIN ATJ.Empresas E ON E.id_Usuario = P.id_Usuario
LEFT JOIN ATJ.Clientes S ON S.id_Usuario = P.id_Usuario
WHERE 
MONTH(P.Fecha_creacion) BETWEEN MONTH(@Fecha_Desde) AND MONTH(@Fecha_Hasta)
AND YEAR(P.Fecha_creacion) = @Anio
and p.Codigo NOT IN (SELECT cod_Publicacion FROM ATJ.Calificaciones)
GROUP BY P.id_Usuario, E.id_Usuario, S.Nombre, S.Apellido, E.Razon_social
ORDER BY CantPubliSinClasificar DESC
GO

--Procedure traerListadoUsuariosConMayorCantidadDeProductosSinVenderConFiltros
CREATE PROCEDURE [ATJ].[traerListadoUsuariosConMayorCantidadDeProductosSinVenderConFiltros]
	@Fecha_Hasta datetime,
	@Fecha_Desde datetime,
	@Anio nvarchar(4),
	@Mes nvarchar(2),
	@GradoVisibilidad nvarchar(255)
	
AS

SELECT TOP 5 Vendedor = (CASE WHEN  (E.id_Usuario IS NULL AND s.id_Usuario IS null) THEN 'Admin' 
ELSE(CASE WHEN  E.id_Usuario IS NULL THEN S.Nombre+' '+S.Apellido ELSE E.Razon_social END) END),
COUNT(P.Codigo) AS CantPublicNoVendidos
FROM ATJ.Publicaciones P
LEFT JOIN ATJ.Empresas E ON E.id_Usuario = P.id_Usuario
LEFT JOIN ATJ.Clientes S ON S.id_Usuario = P.id_Usuario
INNER JOIN ATJ.Visibilidades V ON P.cod_Visibilidad = V.cod_Visibilidad
WHERE MONTH(P.Fecha_creacion) BETWEEN MONTH(@Fecha_Desde) AND MONTH(@Fecha_Hasta)
AND YEAR(P.Fecha_creacion) = @Anio
AND(P.Codigo NOT IN (SELECT C.cod_Publicacion FROM ATJ.Compras C))
AND V.Descripcion = (CASE WHEN @GradoVisibilidad <> '' THEN @GradoVisibilidad ELSE V.Descripcion END) 
AND MONTH(P.Fecha_creacion) = (CASE WHEN @Mes <> '' THEN @Mes ELSE MONTH(P.Fecha_creacion) END)
GROUP BY P.id_Usuario, E.id_Usuario, S.Nombre, S.Apellido, E.Razon_social, S.id_Usuario 
ORDER BY CantPublicNoVendidos DESC
GO

--Procedure traerListadoPreguntasConRespuestasPorUsuarioYPublicacion
CREATE PROCEDURE ATJ.traerListadoPreguntasConRespuestasPorUsuarioYPublicacion
    @id_Usuario int,
    @cod_Publicacion numeric(18,0)

AS 
    SELECT R.id_Pregunta AS id_Pregunta, R.Pregunta AS Pregunta, R.Respuesta AS Respuesta, R.Fecha_respuesta AS Fecha_respuesta, 
    P.Codigo AS Codigo, P.Descripcion AS Descripcion, P.Stock AS Stock,P.Fecha_creacion AS Fecha_creacion, P.Fecha_vencimiento AS Fecha_Vencimiento, 
    P.Precio AS Precio
    FROM ATJ.Usuarios U 
    INNER JOIN ATJ.Publicaciones P ON U.id_Usuario = P.id_Usuario 
    INNER JOIN ATJ.Preguntas R ON R.cod_Publicacion = P.Codigo 
    WHERE	R.Respuesta IS NOT NULL
	AND		U.id_Usuario = @id_Usuario
	AND		P.Codigo = @cod_Publicacion
GO

--Procedure traerListadoPreguntasSinRespuestasPorUsuarioYPublicacion
CREATE PROCEDURE ATJ.traerListadoPreguntasSinRespuestasPorUsuarioYPublicacion
    @id_Usuario numeric(18,0),
    @cod_Publicacion numeric(18,0)

AS 
    SELECT R.id_Pregunta AS id_Pregunta, R.Pregunta AS Pregunta, R.Respuesta AS Respuesta, 
    R.Fecha_respuesta AS Fecha_respuesta, P.Codigo AS Codigo, P.Descripcion AS Descripcion, 
    P.Stock AS Stock,P.Fecha_creacion AS Fecha_creacion, P.Fecha_vencimiento AS Fecha_Vencimiento, 
    P.Precio AS Precio
    FROM ATJ.Usuarios U 
    INNER JOIN ATJ.Publicaciones P ON U.id_Usuario = P.id_Usuario 
    INNER JOIN ATJ.Preguntas R ON R.cod_Publicacion = P.Codigo 
    WHERE	R.Respuesta IS NULL
	AND		U.id_Usuario = @id_Usuario
	AND		P.Codigo = @cod_Publicacion
GO

--Procedure updatePreguntaConRespuesta
CREATE PROCEDURE ATJ.updatePreguntaConRespuesta
	@id_Pregunta int,
	@Respuesta nvarchar(255),
	@Fecha_respuesta datetime
	
AS

UPDATE ATJ.Preguntas SET	Respuesta = @Respuesta,
							Fecha_respuesta = @Fecha_respuesta
WHERE id_Pregunta = @id_Pregunta 
	
GO

--Procedure traerListadoFormas_Pago
CREATE PROCEDURE ATJ.traerListadoFormas_Pago
	
AS
	SELECT *
	FROM ATJ.Formas_Pago
GO

--Procedure traerListadoFormas_PagoPorId
CREATE PROCEDURE ATJ.traerListadoFormas_PagoPorId
	@id_Forma_Pago int
AS
	SELECT *
	FROM ATJ.Formas_Pago
	WHERE id_Forma_Pago = @id_Forma_Pago
GO

--Procedure traerListadoPublicacionesMasAntiguasARendirPorUsuario
CREATE PROCEDURE ATJ.traerListadoPublicacionesMasAntiguasARendirPorUsuario
	@Id_Usuario int,
	@Fecha datetime
	
AS

SELECT P.*
FROM ATJ.Publicaciones P
INNER JOIN ATJ.Compras C ON C.cod_Publicacion = P.Codigo
WHERE (P.Fecha_vencimiento <= @Fecha
OR P.Stock = 0)
AND P.id_Usuario = @Id_Usuario
AND P.Codigo NOT IN (SELECT I.cod_Publicacion FROM ATJ.Item_Factura I)
ORDER BY C.Fecha ASC
GO

--Procedure traerListadoItems_FacturaPorNroFactura
CREATE PROCEDURE ATJ.traerListadoItems_FacturaPorNroFactura
	@nro_Factura int
AS
SELECT *
FROM ATJ.Item_Factura
WHERE nro_Factura = @nro_Factura
GO

--Procedure insertFactura_RetornarID
CREATE PROCEDURE ATJ.insertFactura_RetornarID
    @Fecha datetime,
    @Precio_Total numeric(18,2),
    @id_Forma_Pago int,
    @id_Usuario int,
    @Tarjeta nvarchar(255) = null,
    @Nro_Tarjeta numeric(18,0) = null,
    @Titular nvarchar(255) = null,
    @Fecha_Vencimiento datetime = null,
    @Dni numeric(18,0) = null,
    @Codigo_seg numeric(18,0) = null
AS
INSERT INTO ATJ.Facturas
(Fecha,Precio_Total,id_Forma_Pago, id_Usuario, Tarjeta,Nro_Tarjeta,Titular,
Fecha_Vencimiento,Dni,Codigo_Seg)
VALUES
(@Fecha,@Precio_Total,@id_Forma_Pago,@id_Usuario, @Tarjeta, @Nro_Tarjeta, @Titular, 
@Fecha_Vencimiento,@Dni, @Codigo_seg)
SELECT @@IDENTITY AS nro_Factura;
GO

--Procedure insertItem_Factura
CREATE PROCEDURE ATJ.insertItem_Factura
	@nro_Factura numeric(18,0),
	@cod_Publicacion numeric(18,0),
	@Monto numeric(18,2),
	@Cantidad numeric(18,0)
AS
INSERT INTO ATJ.Item_Factura
(nro_Factura,cod_Publicacion,Monto,Cantidad)
VALUES
(@nro_Factura,@cod_Publicacion,@Monto,@Cantidad)
GO

--Procedure traerListadoComprasPorCodigoPublicacion
CREATE PROCEDURE ATJ.traerListadoComprasPorCodigoPublicacion
	@cod_Publicacion numeric(18,0)
AS

SELECT *
FROM ATJ.Compras C
WHERE C.cod_Publicacion = @cod_Publicacion
AND C.cod_Publicacion NOT IN (SELECT O.cod_Publicacion FROM ATJ.Ofertas O)
GO


--Procedure traerListadoOfertasGanadasPorCodigoPublicacion
CREATE PROCEDURE ATJ.traerListadoOfertasGanadasPorCodigoPublicacion
 @cod_Publicacion numeric(18,0)
AS

SELECT *
FROM ATJ.Ofertas
WHERE cod_Publicacion = @cod_Publicacion
AND  gano_Subasta = 1
GO
COMMIT
GO

CREATE TRIGGER UpdateReputacion
   ON  ATJ.Calificaciones
   FOR INSERT
AS 
BEGIN
	DECLARE @id_usuario int;
	SET @id_usuario = (SELECT P.id_Usuario FROM inserted I 
						INNER JOIN atj.Publicaciones P ON P.Codigo = I.cod_Publicacion)
	DECLARE @cantidadDeEstrellasObtenidas int;	
	SET @cantidadDeEstrellasObtenidas = (SELECT SUM(C.Cant_Estrellas) 
										FROM ATJ.Usuarios U
										INNER JOIN ATJ.Publicaciones P ON U.id_Usuario = P.id_Usuario 
										INNER JOIN ATJ.Calificaciones C ON P.Codigo = C.cod_Publicacion
										WHERE U.id_Usuario = @id_usuario)
	DECLARE @CantidadDeCalificaciones int;
	SET @CantidadDeCalificaciones = (SELECT COUNT(*)
									FROM ATJ.Calificaciones C
									INNER JOIN ATJ.Publicaciones P ON C.cod_Publicacion = p.Codigo
									WHERE p.id_Usuario = @id_usuario)										 
	IF EXISTS (SELECT id_usuario FROM ATJ.Clientes WHERE id_Usuario = @id_usuario)
    UPDATE ATJ.Clientes	SET Reputacion = CAST((@cantidadDeEstrellasObtenidas)/(@CantidadDeCalificaciones) AS NUMERIC(18,2))
						WHERE id_Usuario = @id_usuario
	ELSE
	UPDATE ATJ.Empresas SET Reputacion = CAST((@cantidadDeEstrellasObtenidas)/(@CantidadDeCalificaciones) AS NUMERIC(18,2))
						WHERE id_Usuario = @id_usuario
END
GO

