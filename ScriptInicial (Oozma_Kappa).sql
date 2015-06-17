--- DROP TABLES ---

USE GD1C2015

BEGIN TRANSACTION

DROP TABLE [OOZMA_KAPPA].[Banco]
GO
DROP TABLE [OOZMA_KAPPA].[Cheque]
GO
DROP TABLE [OOZMA_KAPPA].[Deposito]
GO
DROP TABLE [OOZMA_KAPPA].[Factura]
GO
DROP TABLE [OOZMA_KAPPA].[Funcionalidades]
GO
DROP TABLE [OOZMA_KAPPA].[Funcionalidades_rol]
GO
DROP TABLE [OOZMA_KAPPA].[Item_factura]
GO
DROP TABLE [OOZMA_KAPPA].[Login]
GO
DROP TABLE [OOZMA_KAPPA].[Moneda]
GO
DROP TABLE [OOZMA_KAPPA].[Pais]
GO
DROP TABLE [OOZMA_KAPPA].[Retiro]
GO
DROP TABLE [OOZMA_KAPPA].[Rol]
GO
DROP TABLE [OOZMA_KAPPA].[Tarjeta]
GO
DROP TABLE [OOZMA_KAPPA].[Tipo_cuenta]
GO
DROP TABLE [OOZMA_KAPPA].[Tipo_documento]
GO
DROP TABLE [OOZMA_KAPPA].[Transferencia]
GO
DROP TABLE [OOZMA_KAPPA].[Usuario]
GO
DROP TABLE [OOZMA_KAPPA].[Administrador]
GO
DROP TABLE [OOZMA_KAPPA].[Usuario_rol]
GO
DROP TABLE [OOZMA_KAPPA].[Cliente]
GO
DROP TABLE [OOZMA_KAPPA].[Cuenta]
GO


--- DROP SCHEMA ---

DROP SCHEMA [OOZMA_KAPPA] 
GO

COMMIT


----- Script creación esquema y tablas -----

CREATE SCHEMA [OOZMA_KAPPA] AUTHORIZATION [gd];
GO
BEGIN TRANSACTION

USE [GD1C2015]


--- TABLA ADMINISTRADOR ---

CREATE TABLE [OOZMA_KAPPA].[Administrador](
	[administrador_id] numeric(18, 0) IDENTITY (1,1),
	[administrador_estado] numeric(18, 0)NOT NULL,   
	[administrador_username] [varchar](255) NOT NULL,
	[administrador_usuario_id] numeric(18, 0)NOT NULL,
)

--- TABLA BANCO ---

CREATE TABLE [OOZMA_KAPPA].[Banco](
	[banco_id] numeric(18, 0) NOT NULL,
	[banco_nombre] [varchar](255) NOT NULL,
	[banco_direccion] [varchar](255) NOT NULL,
)
--- TABLA CHEQUE ---

CREATE TABLE [OOZMA_KAPPA].[Cheque](
	[cheque_id] numeric(18, 0) IDENTITY (1,1),
	[cheque_cuenta_id] numeric(18, 0)NOT NULL,
	[cheque_fecha] [datetime] NOT NULL,
	[cheque_importe] numeric(18, 2)NOT NULL,
	[cheque_banco_id] numeric(18, 0)NOT NULL,
	[cheque_destino_cliente_id] numeric(18, 0)NOT NULL,	--creo que el cliente nos va a falicitar la performance al momento de hacer un cheque. si no cada vez que se hace 
	--un cheque hay que recorrer la tabla de clientes tambien para buscar su id. 


--- TABLA CLIENTE ---

CREATE TABLE [OOZMA_KAPPA].[Cliente](
	[cliente_id] numeric(18, 0) IDENTITY (1,1),
	[cliente_usuario_id] numeric(18, 0)NOT NULL,
	[cliente_apellido] [varchar](255) NOT NULL,
	[cliente_nombre] [varchar](255) NOT NULL,
	[cliente_fecha_nacimiento] [datetime] NOT NULL,
	[cliente_tipo_documento_id] numeric(18, 0)NOT NULL,
	[cliente_numero_documento] numeric(18, 0)NOT NULL,
	[cliente_pais_residente_id] numeric(18, 0)NOT NULL,
	[cliente_calle] [varchar](255) NOT NULL,
	[cliente_numero] numeric(18, 0)NOT NULL,
	[cliente_piso] numeric(18, 0)NOT NULL,
	[cliente_depto] [varchar](10) NOT NULL,  
	[cliente_mail] [varchar](255),
)

--- TABLA CUENTA ---

CREATE TABLE [OOZMA_KAPPA].[Cuenta](
	[cuenta_id] numeric(18, 0) IDENTITY (1,1),
	[cuenta_cliente_id] numeric(18, 0)NOT NULL,
	[cuenta_pais_id] numeric(18, 0)NOT NULL,
	[cuenta_moneda_id] numeric(18, 0)NOT NULL DEFAULT(1),
	[cuenta_tipo_cuenta_id] numeric(18, 0)NOT NULL,
	[cuenta_estado] bit NOT NULL DEFAULT(1),  --0 es false , 1 true
	[cuenta_saldo] numeric(18, 0)NOT NULL DEFAULT(0),
	[cuenta_fecha_apertura] [datetime] NOT NULL DEFAULT(getdate()),
	[cuenta_fecha_cierre] [datetime] NOT NULL,
)


--- TABLA DEPOSITO ---

CREATE TABLE [OOZMA_KAPPA].[Deposito](
	[deposito_id] numeric(18, 0) IDENTITY (1,1),
	[deposito_cuenta_id] numeric(18, 0)NOT NULL,
	[deposito_cliente_id] numeric(18, 0)NOT NULL,
	[deposito_importe] numeric(18, 2) NOT NULL,
	[deposito_moneda_id] numeric(18, 0)NOT NULL,
	[deposito_tarjeta_id] numeric(18, 0)NOT NULL,
	[deposito_fecha] [datetime] NOT NULL,
	)

--- TABLA FACTURA ---

CREATE TABLE [OOZMA_KAPPA].[Factura](
	[factura_numero] numeric(18, 0) IDENTITY (1,1),
	[factura_importe] numeric(18, 0)NOT NULL,
	[factura_fecha] [datetime] NOT NULL,
	[factura_cliente_id] numeric(18, 0)NOT NULL,
	[factura_items_id] numeric(18, 0)NOT NULL,
)

--- TABLA FUNCIONALIDADES ---

CREATE TABLE [OOZMA_KAPPA].[Funcionalidades](
	[funcionalidades_id] numeric(18, 0) IDENTITY (1,1),
	[funcionalidades_nombre] [varchar](255) NOT NULL,
)

INSERT INTO[OOZMA_KAPPA].[Funcionalidades] (funcionalidades_nombre) VALUES ('ABM de Rol');
INSERT INTO[OOZMA_KAPPA].[Funcionalidades] (funcionalidades_nombre) VALUES ('ABM de Usuario');
INSERT INTO[OOZMA_KAPPA].[Funcionalidades] (funcionalidades_nombre) VALUES ('ABM de Cliente');
INSERT INTO[OOZMA_KAPPA].[Funcionalidades] (funcionalidades_nombre) VALUES ('ABM de Cuenta');
INSERT INTO[OOZMA_KAPPA].[Funcionalidades] (funcionalidades_nombre) VALUES ('Depositos');
INSERT INTO[OOZMA_KAPPA].[Funcionalidades] (funcionalidades_nombre) VALUES ('Retiro de Efectivo');
INSERT INTO[OOZMA_KAPPA].[Funcionalidades] (funcionalidades_nombre) VALUES ('Transferencias entre cuentas');
INSERT INTO[OOZMA_KAPPA].[Funcionalidades] (funcionalidades_nombre) VALUES ('Facturacion de Costos');
INSERT INTO[OOZMA_KAPPA].[Funcionalidades] (funcionalidades_nombre) VALUES ('Consulta de saldos');
INSERT INTO[OOZMA_KAPPA].[Funcionalidades] (funcionalidades_nombre) VALUES ('Listado Estadistico');

--- TABLA FUNCIONALIDADES_ROL ---

CREATE TABLE [OOZMA_KAPPA].[Funcionalidades_rol](
	[funcionalidades_rol_id] numeric(18, 0) IDENTITY (1,1),
	[funcionalidad_id] numeric(18, 0)NOT NULL,
	[rol_id] numeric(18, 0)NOT NULL,
)

INSERT INTO[OOZMA_KAPPA].[Funcionalidades_rol] (funcionalidad_id, rol_id)  VALUES (4,2);
INSERT INTO[OOZMA_KAPPA].[Funcionalidades_rol] (funcionalidad_id, rol_id)  VALUES (5,2);
INSERT INTO[OOZMA_KAPPA].[Funcionalidades_rol] (funcionalidad_id, rol_id)  VALUES (6,2);
INSERT INTO[OOZMA_KAPPA].[Funcionalidades_rol] (funcionalidad_id, rol_id)  VALUES (7,2);
INSERT INTO[OOZMA_KAPPA].[Funcionalidades_rol] (funcionalidad_id, rol_id)  VALUES (8,2);
INSERT INTO[OOZMA_KAPPA].[Funcionalidades_rol] (funcionalidad_id, rol_id)  VALUES (9,2);--EL DOS ES CLIENTE
INSERT INTO[OOZMA_KAPPA].[Funcionalidades_rol] (funcionalidad_id, rol_id)  VALUES (1,1);
INSERT INTO[OOZMA_KAPPA].[Funcionalidades_rol] (funcionalidad_id, rol_id)  VALUES (2,1);
INSERT INTO[OOZMA_KAPPA].[Funcionalidades_rol] (funcionalidad_id, rol_id)  VALUES (3,1);
INSERT INTO[OOZMA_KAPPA].[Funcionalidades_rol] (funcionalidad_id, rol_id)  VALUES (4,1);--EL UNO ES ADMIN
INSERT INTO[OOZMA_KAPPA].[Funcionalidades_rol] (funcionalidad_id, rol_id)  VALUES (5,1);
INSERT INTO[OOZMA_KAPPA].[Funcionalidades_rol] (funcionalidad_id, rol_id)  VALUES (6,1);
INSERT INTO[OOZMA_KAPPA].[Funcionalidades_rol] (funcionalidad_id, rol_id)  VALUES (7,1);
INSERT INTO[OOZMA_KAPPA].[Funcionalidades_rol] (funcionalidad_id, rol_id)  VALUES (8,1);
INSERT INTO[OOZMA_KAPPA].[Funcionalidades_rol] (funcionalidad_id, rol_id)  VALUES (9,1);
INSERT INTO[OOZMA_KAPPA].[Funcionalidades_rol] (funcionalidad_id, rol_id)  VALUES (10,1);


--- TABLA ITEM_FACTURA ---

CREATE TABLE [OOZMA_KAPPA].[Item_factura](
	[item_factura_id] numeric(18, 0) IDENTITY (1,1),
	[item_factura_desc] [varchar](255) NOT NULL,
	[item_factura_costo] numeric(18, 2) NOT NULL,
	[item_factura_cant] numeric(18, 0)NOT NULL,
	[item_factura_fecha] [datetime] NOT NULL,
	[item_factura_numero_factura] numeric(18,0) NOT NULL,
	[item_factura_cliente_id] numeric(18,0) NOT NULL,
)

--- TABLA LOGIN ---

CREATE TABLE [OOZMA_KAPPA].[Login](
	[login_id] numeric(18, 0) IDENTITY (1,1),
	[login_usuario_id] numeric(18, 0)NOT NULL,
	[login_estado] numeric(18, 0)NOT NULL,
	[login_cant_numeric(18, 0)entos] numeric(18, 0)NOT NULL,
	[login_fecha_hora] [datetime] NOT NULL,
)

--- TABLA MONEDA ---

CREATE TABLE [OOZMA_KAPPA].[Moneda](
	[moneda_id] numeric(18, 0) IDENTITY (1,1),
	[moneda_nombre] [varchar](255) NOT NULL,
)

INSERT INTO[OOZMA_KAPPA].[Moneda] (moneda_nombre) VALUES ('Dolar');

--- TABLA PAIS ---

CREATE TABLE [OOZMA_KAPPA].[Pais](
	[pais_id] numeric(18, 0) IDENTITY (1,1),
	[pais_nombre] [varchar](250) NOT NULL,
)

--- TABLA RETIRO ---

CREATE TABLE [OOZMA_KAPPA].[Retiro](
	[retiro_id] numeric(18, 0) IDENTITY (1,1),
	[retiro_cuenta_id] numeric(18, 0)NOT NULL,
	[retiro_importe] numeric(18, 2)NOT NULL,
	[retiro_cheque_id] numeric(18, 0)NOT NULL,
	[retiro_fecha] [datetime] NOT NULL,
)

-- TABLA ROL --

CREATE TABLE [OOZMA_KAPPA].[Rol](
	[rol_id] numeric(18, 0) IDENTITY (1,1),
	[rol_nombre] [nvarchar](255) NOT NULL,
	[rol_estado] bit NOT NULL DEFAULT(0),   --puede estar activo 0 o no activo 1
)

INSERT INTO[OOZMA_KAPPA].[Rol] (rol_nombre, rol_estado) VALUES ('Administrador',0);
INSERT INTO[OOZMA_KAPPA].[Rol] (rol_nombre, rol_estado) VALUES ('Cliente',0);

--- TABLA TARJETA  ---

CREATE TABLE [OOZMA_KAPPA].[Tarjeta](
	[tarjeta_id] numeric(18,0) IDENTITY (1,1),  
	[tarjeta_codigo_seguridad] varchar(3) NOT NULL,
	[tarjeta_fecha_emision] [datetime] NOT NULL,
	[tarjeta_vencimiento] [datetime] NOT NULL,
	
)

--- TABLA TIPO_CUENTA ---

CREATE TABLE [OOZMA_KAPPA].[Tipo_cuenta](
	[tipo_cuenta_id] numeric(18, 0) IDENTITY (1,1),
	[tipo_cuenta_nombre] [varchar](255) NOT NULL,
	[tipo_cuenta_costo_transferencia] numeric(18, 0)NOT NULL,
	[tipo_cuenta_costo_apertura] numeric(18, 0)NOT NULL,   
)

-- los costos se los puse yo (CAMI) --
INSERT INTO[OOZMA_KAPPA].[Tipo_cuenta](tipo_cuenta_nombre, tipo_cuenta_costo_transferencia,tipo_cuenta_costo_apertura) 
VALUES ('ORO',500,500);
INSERT INTO[OOZMA_KAPPA].[Tipo_cuenta](tipo_cuenta_nombre, tipo_cuenta_costo_transferencia,tipo_cuenta_costo_apertura) 
VALUES ('PLATA',400,400);
INSERT INTO[OOZMA_KAPPA].[Tipo_cuenta](tipo_cuenta_nombre, tipo_cuenta_costo_transferencia,tipo_cuenta_costo_apertura)
VALUES ('BRONCE',300,300);
INSERT INTO[OOZMA_KAPPA].[Tipo_cuenta](tipo_cuenta_nombre, tipo_cuenta_costo_transferencia,tipo_cuenta_costo_apertura)
VALUES ('GRATUITA',0,0);

--- TABLA TIPO_DOCUMENTO ---

CREATE TABLE [OOZMA_KAPPA].[Tipo_documento](
	[tipo_documento_id] numeric(18, 0) IDENTITY (1,1),
	[tipo_documento_descripcion] [varchar](255) NOT NULL,
)

INSERT INTO[OOZMA_KAPPA].[Tipo_documento] (tipo_documento_descripcion) VALUES ('DNI');
INSERT INTO[OOZMA_KAPPA].[Tipo_documento] (tipo_documento_descripcion) VALUES ('CI');
INSERT INTO[OOZMA_KAPPA].[Tipo_documento] (tipo_documento_descripcion) VALUES ('LC');
INSERT INTO[OOZMA_KAPPA].[Tipo_documento] (tipo_documento_descripcion) VALUES ('LE');

--- TABLA TRANSFERENCIA ---

CREATE TABLE [OOZMA_KAPPA].[Transferencia](
	[transferencia_id] numeric(18, 0) IDENTITY (1,1),
	[transferencia_origen_cuenta_id] numeric(18, 0)NOT NULL,
	[transferencia_destino_cuenta_id] numeric(18, 0)NOT NULL,
	[transferencia_importe] numeric(18, 2)NOT NULL,
	[transferencia_costo] numeric(18, 2)NOT NULL,
	[transferencia_fecha] datetime NOT NULL,
)

--- TABLA USUARIO ---

CREATE TABLE [OOZMA_KAPPA].[Usuario](
	[usuario_id] numeric(18, 0) IDENTITY (1,1),
	[usuario_username] numeric(18,0) NOT NULL,
	[usuario_nombreYapellido] [nvarchar](255) NOT NULL,
	[usuario_password] [nvarchar] (64) NOT NULL,
	[usuario_fecha_creacion] [datetime] NOT NULL,
	[usuario_fecha_ultima_modificacion] [datetime] NOT NULL,
	[usuario_pregunta_secreta] [nvarchar](64) NOT NULL,
	[usuario_respuesta_secreta] [nvarchar](64) NOT NULL,   -- 0 habilitado, 1 deshabilitado
	[usuario_estado] bit NOT NULL DEFAULT(0),  --puede estar habilitado como no habilitado, ya sea por el estado del rol, o por logins incorrectos
	
)


-- TABLA USUARIO_ROL --

CREATE TABLE [OOZMA_KAPPA].[Usuario_rol](
	[usuario_rol_id] numeric(18, 0) IDENTITY (1,1),
	[usuario_id] numeric(18, 0)NOT NULL,
	[usuario_username] numeric(18,0)NOT NULL,
	[rol_id] numeric(18, 0)NOT NULL,
)

COMMIT

----- Migracion -----

-- TABLA BANCO --

BEGIN TRANSACTION
 INSERT INTO [OOZMA_KAPPA].[Banco] (banco_id, banco_nombre, banco_direccion)(
  SELECT DISTINCT Banco_Cogido
	  ,Banco_Nombre
	  ,Banco_Direccion
 FROM gd_esquema.Maestra
 WHERE Banco_Cogido IS NOT NULL);
COMMIT

 
 -- TABLA PAIS --
 
 BEGIN TRANSACTION
 
 SET IDENTITY_INSERT [OOZMA_KAPPA].[Pais] ON
 
 INSERT INTO [OOZMA_KAPPA].[Pais] (pais_id, pais_nombre)(
	SELECT DISTINCT Cli_Pais_Codigo,Cli_Pais_Desc FROM gd_esquema.Maestra WHERE Cli_Pais_Codigo IS NOT NULL 
	UNION
	SELECT DISTINCT  Cuenta_Pais_Codigo, Cuenta_Pais_Desc FROM gd_esquema.Maestra  WHERE Cuenta_Pais_Codigo IS NOT NULL 
	);
 
 SET IDENTITY_INSERT [OOZMA_KAPPA].[Pais] OFF
 
 COMMIT

-- TABLA USUARIO --   CAMBIE EL USERNAME POR EL DNI

BEGIN TRANSACTION
 
INSERT INTO [OOZMA_KAPPA].[Usuario] ( usuario_username, usuario_nombreYapellido, usuario_password, usuario_fecha_creacion, usuario_fecha_ultima_modificacion, usuario_pregunta_secreta, usuario_respuesta_secreta)(
	SELECT DISTINCT 
	Cli_Nro_Doc
	,Cli_Nombre + ' ' + Cli_Apellido
	,'ECE6128060FCDA0AFC43C2D59109C410E89DE2BEF602D70ED62C0640FD795970'  --CONTRASE;A USER
	,Cuenta_Fecha_Creacion              
	,Cuenta_Fecha_Creacion
	,'Cual es tu color preferido?'
	,'AF4C20351356D258C57B16291CCEB8BAEE3D4DEE410061EA66D7C636EFE075CC'
	FROM gd_esquema.Maestra	
	WHERE Cli_Nombre IS NOT NULL
	);
	
COMMIT

 -- TABLA CLIENTE --    ANTES VA USUARIO
 
 
 
 BEGIN TRANSACTION
 
 INSERT INTO [OOZMA_KAPPA].[Cliente] (cliente_usuario_id, cliente_apellido, cliente_nombre, cliente_fecha_nacimiento,
				cliente_tipo_documento_id, cliente_numero_documento, cliente_pais_residente_id,
				 cliente_calle, cliente_numero, cliente_piso, cliente_depto, cliente_mail)(
	SELECT DISTINCT 0,
	Cli_Apellido, Cli_Nombre, Cli_Fecha_Nac, Cli_Tipo_Doc_Cod, Cli_Nro_Doc, Cli_Pais_Codigo, Cli_Dom_Calle, Cli_Dom_Nro,
	Cli_Dom_Piso, Cli_Dom_Depto,Cli_Mail
	FROM gd_esquema.Maestra
	WHERE Cuenta_Numero IS NOT NULL);
	
 COMMIT
 
 BEGIN TRANSACTION
 
	UPDATE OOZMA_KAPPA.Cliente
	SET cliente_usuario_id = (SELECT DISTINCT usuario_id FROM OOZMA_KAPPA.Usuario WHERE (cliente_numero_documento = usuario_username))
	
COMMIT

	
 
  -- TABLA ITEM FACTURA -- ANTES TIENE QUE IR CLIENTE
 
 BEGIN TRANSACTION
 INSERT INTO [OOZMA_KAPPA].[Item_factura] (item_factura_numero_factura,item_factura_desc, item_factura_costo, item_factura_cant, item_factura_fecha, item_factura_cliente_id)(
	SELECT Factura_Numero,
	  Item_Factura_Descr
	  ,Item_Factura_Importe    --como en la tabla maestra solo hay un item factura por factura hago todo uno a uno, no sumo los item y sus importes
	  ,1
	  ,Factura_Fecha
	  ,(SELECT cliente_id FROM OOZMA_KAPPA.Cliente WHERE cliente_numero_documento = Cli_Nro_Doc)
 FROM gd_esquema.Maestra
 WHERE Item_Factura_Descr IS NOT NULL);
 COMMIT
 
 
 ----TABLA CUENTA----   ANTES TIENE QUE IR CLIENTE
 
 BEGIN TRANSACTION
  
 SET IDENTITY_INSERT [OOZMA_KAPPA].[Cuenta] ON
  
 INSERT INTO [OOZMA_KAPPA].[Cuenta](cuenta_id, 
	cuenta_cliente_id, 
	cuenta_pais_id,
	cuenta_tipo_cuenta_id, 
	cuenta_saldo, cuenta_fecha_apertura, cuenta_fecha_cierre )(
	SELECT DISTINCT Cuenta_Numero
	,(SELECT cliente_id FROM OOZMA_KAPPA.Cliente WHERE Cli_Nro_Doc = cliente_numero_documento)
	,Cuenta_Pais_Codigo
	,4 --CONSIDERAMOS TODAS SON GRATUITAS (segun mail), y la gratuita tiene id 4
	,50000  --COMO NO ESTA EL MONTO DE CADA CUENTA CONSIDEREMOS ESTE VALOR PARA TODAS.
	,Cuenta_Fecha_Creacion   --cuenta moneda y estado les puse default 1(dolar) y "Habilitada"
	,DATEADD(year,1,Cuenta_Fecha_Creacion)    --COMO FECHA CIERRE ESTA EN NULL le ponemos como fecha desde la apertura un año mas.
 FROM gd_esquema.Maestra
 WHERE Cuenta_Numero IS NOT NULL);
   
 SET IDENTITY_INSERT [OOZMA_KAPPA].[Cuenta] OFF
  
 COMMIT 
 

---- TABLA TRANFERENCIA ---

BEGIN TRANSACTION
 
INSERT INTO [OOZMA_KAPPA].[Transferencia] (transferencia_origen_cuenta_id, transferencia_destino_cuenta_id,
										transferencia_importe, transferencia_costo, transferencia_fecha)(
	SELECT Cuenta_Numero, Cuenta_Dest_Numero,  Trans_Importe, Trans_Costo_Trans, Transf_Fecha
	FROM gd_esquema.Maestra	
	WHERE transf_fecha IS NOT NULL
	);

COMMIT

  -- TABLA DEPOSITO--  NECESITA TABLA CLIENTES ANTES
  
 BEGIN TRANSACTION
 
 SET IDENTITY_INSERT [OOZMA_KAPPA].[Deposito] ON
 
 INSERT INTO [OOZMA_KAPPA].[Deposito] (deposito_id, deposito_cuenta_id, deposito_cliente_id, 
                                       deposito_importe, deposito_moneda_id, deposito_tarjeta_id,
                                        deposito_fecha)(
	SELECT DISTINCT Deposito_Codigo
	, Cuenta_Numero
	, 0
	, Deposito_Importe
	, 1
	, Tarjeta_Numero
	, Deposito_Fecha
    FROM gd_esquema.Maestra WHERE Deposito_Codigo IS NOT NULL);
	
 
 SET IDENTITY_INSERT [OOZMA_KAPPA].[Deposito] OFF
 
 COMMIT
 
BEGIN TRANSACTION
 
	UPDATE OOZMA_KAPPA.Deposito
	SET deposito_cliente_id = (SELECT DISTINCT cuenta_cliente_id FROM OOZMA_KAPPA.Cuenta WHERE (cuenta_id = deposito_cuenta_id))
	
COMMIT

  -- TABLA TARJETA --
 
 BEGIN TRANSACTION
 
 SET IDENTITY_INSERT [OOZMA_KAPPA].[Tarjeta] ON
 
 INSERT INTO [OOZMA_KAPPA].[Tarjeta] (tarjeta_id, tarjeta_codigo_seguridad, tarjeta_fecha_emision, tarjeta_vencimiento)(
	SELECT DISTINCT  CAST(Tarjeta_Numero AS numeric(18,0))
	, Tarjeta_Codigo_Seg
    , Tarjeta_Fecha_Emision
	, Tarjeta_Fecha_Vencimiento
	FROM gd_esquema.Maestra
 WHERE Tarjeta_Numero IS NOT NULL);
 
 SET IDENTITY_INSERT [OOZMA_KAPPA].[Tarjeta] OFF
 
 COMMIT
 
 -- TABLA TIPO DOCUMENTO --
 
 BEGIN TRANSACTION
 
 SET IDENTITY_INSERT [OOZMA_KAPPA].[Tipo_documento] ON
 
 INSERT INTO [OOZMA_KAPPA].[Tipo_documento] (tipo_documento_id, tipo_documento_descripcion)(
	SELECT DISTINCT Cli_Tipo_Doc_Cod
	, Cli_Tipo_Doc_Desc
 FROM gd_esquema.Maestra
 WHERE Cli_Tipo_Doc_Cod IS NOT NULL);
 
 SET IDENTITY_INSERT [OOZMA_KAPPA].[Tipo_documento] OFF
 
 COMMIT
 
 --SE AGREGA SOLO EL PASAPORTE.. DNI CI LC LE SE AGREGARON MANUALMENTE. TODOS EN LA TABLA MAESTRA TIENEN PASAPORTE 
 
 --TABLA CHEQUE --

--el cheuqe lo hace un cliente para si mismo, entonces el cliente destino es esa misma persona que lo emite. 

 BEGIN TRANSACTION  --NECESITA CUENTA y CLIENTE ANTES
 
 SET IDENTITY_INSERT [OOZMA_KAPPA].[Cheque] ON

 INSERT INTO  [OOZMA_KAPPA].[Cheque] (cheque_id, cheque_cuenta_id, cheque_fecha, cheque_importe, cheque_banco_id, cheque_destino_cliente_id)(
 SELECT Cheque_Numero
 , Cuenta_Numero
 , Cheque_Fecha
 , Cheque_Importe
 , Banco_Cogido
 , (SELECT cuenta_cliente_id FROM OOZMA_KAPPA.Cuenta WHERE Cuenta_Numero = cuenta_id)
 FROM gd_esquema.Maestra	
 WHERE cheque_fecha IS NOT NULL);
 
 SET IDENTITY_INSERT [OOZMA_KAPPA].[Cheque] OFF
 
 COMMIT 
 
------TABLA RETIRO -----

 BEGIN TRANSACTION
 
 SET IDENTITY_INSERT [OOZMA_KAPPA].[Retiro] ON
 
 INSERT INTO [OOZMA_KAPPA].[Retiro] (retiro_id, retiro_cuenta_id, retiro_importe, retiro_cheque_id, retiro_fecha)(
	SELECT Retiro_Codigo, Cuenta_Numero, Retiro_Importe, Cheque_Numero, Retiro_Fecha 
 FROM gd_esquema.Maestra
 WHERE Retiro_Codigo IS NOT NULL);
 
 SET IDENTITY_INSERT [OOZMA_KAPPA].[Retiro] OFF
 
 COMMIT
 

  -- TABLA FACTURA --  NECESITA ITEM FACTURA, CLIENTES ANTES
 
 BEGIN TRANSACTION
 
 SET IDENTITY_INSERT [OOZMA_KAPPA].[Factura] ON
 
 INSERT INTO [OOZMA_KAPPA].[Factura] (factura_numero,factura_fecha, factura_cliente_id, factura_items_id, factura_importe)(
	SELECT Factura_Numero
	,Factura_Fecha
	,(SELECT cliente_id FROM OOZMA_KAPPA.Cliente WHERE Cli_Nro_Doc = cliente_numero_documento)
	,(SELECT i.item_factura_id FROM OOZMA_KAPPA.Item_factura i WHERE i.item_factura_numero_factura = Factura_Numero)
	,Item_Factura_Importe
	FROM  gd_esquema.Maestra WHERE Factura_Numero IS NOT NULL);
 
 SET IDENTITY_INSERT [OOZMA_KAPPA].[Factura] OFF 
 
 COMMIT
 
 --sacar columna item factura numero factura
 BEGIN TRANSACTION
 GO
 ALTER TABLE [OOZMA_KAPPA].[Item_factura] DROP COLUMN item_factura_numero_factura;
 COMMIT
 

-- TABLA USUARIO ROL -- completo todos los clientes

BEGIN TRANSACTION

INSERT INTO [OOZMA_KAPPA].Usuario_rol(usuario_id,usuario_username, rol_id)(
SELECT usuario_id, usuario_username, rol_id FROM OOZMA_KAPPA.Usuario, OOZMA_KAPPA.Rol WHERE rol_nombre = 'Cliente' );

COMMIT

-- CREACION DE USUARIOS DEFAULT admin --

--un usuario con username ADMIN y contrase;a w23e
-- y varios admin mas por lo que dice el enunciado. tomamos los primeros 5 usuarios de la tabla usuario y los hacemos administradores tambien.

BEGIN TRANSACTION   

INSERT INTO [OOZMA_KAPPA].Usuario
(usuario_username,usuario_nombreYapellido,usuario_password,usuario_fecha_creacion,usuario_fecha_ultima_modificacion, usuario_pregunta_secreta , usuario_respuesta_secreta)
 (SELECT 123,
  'administrador general',
  '52D77462B24987175C8D7DAB901A5967E927FFC8D0B6E4A234E07A4AEC5E3724', --contrase;a: w23e
  GETDATE(),GETDATE(),
  'Color preferido?',
  'AF4C20351356D258C57B16291CCEB8BAEE3D4DEE410061EA66D7C636EFE075CC'); --RESPUESTA SECRETA azul
  
COMMIT

--YA TODOS LOS USUARIOS DE LA TABLA MAESTRA ESTAN CREADOS CON CONTRASENA : user Y RESPUESTA SECRETA: azul ya encriptadas


-- TABLA USUARIO ROL --

BEGIN TRANSACTION  --agrego usuario rol del admin

INSERT INTO [OOZMA_KAPPA].Usuario_rol(usuario_id,usuario_username,rol_id) (SELECT DISTINCT usuario_id,123,1 FROM OOZMA_KAPPA.Usuario WHERE usuario_username = 123);

COMMIT

BEGIN TRANSACTION  --agrego rol cliente al admin

INSERT INTO [OOZMA_KAPPA].Usuario_rol(usuario_id,usuario_username,rol_id) (SELECT DISTINCT usuario_id,123,2 FROM OOZMA_KAPPA.Usuario WHERE usuario_username = 123);

COMMIT



----- Crear Foreign Keys -----

BEGIN TRANSACTION
ALTER TABLE [OOZMA_KAPPA].[Retiro]
ADD FOREIGN KEY ([retiro_cuenta_id])
REFERENCES [OOZMA_KAPPA].[Cuenta](cuenta_id);
COMMIT


BEGIN TRANSACTION
ALTER TABLE [OOZMA_KAPPA].[Retiro]
ADD FOREIGN KEY ([retiro_cheque_id])
REFERENCES [OOZMA_KAPPA].[Cheque](cheque_id);
COMMIT


BEGIN TRANSACTION
ALTER TABLE [OOZMA_KAPPA].[Cheque]
ADD FOREIGN KEY ([cheque_banco_id])
REFERENCES [OOZMA_KAPPA].[Banco](banco_id);
COMMIT


BEGIN TRANSACTION
ALTER TABLE [OOZMA_KAPPA].[Login]
ADD FOREIGN KEY ([login_usuario_id])
REFERENCES [OOZMA_KAPPA].[Usuario](usuario_id);
COMMIT


BEGIN TRANSACTION
ALTER TABLE [OOZMA_KAPPA].[Transferencia]
ADD FOREIGN KEY ([transferencia_origen_cuenta_id])
REFERENCES [OOZMA_KAPPA].[Cuenta](cuenta_id);
COMMIT


BEGIN TRANSACTION
ALTER TABLE [OOZMA_KAPPA].[Transferencia]
ADD FOREIGN KEY ([transferencia_destino_cuenta_id])
REFERENCES [OOZMA_KAPPA].[Cuenta](cuenta_id);
COMMIT


BEGIN TRANSACTION
ALTER TABLE [OOZMA_KAPPA].[Cuenta]
ADD FOREIGN KEY ([cuenta_cliente_id])
REFERENCES [OOZMA_KAPPA].[Cliente](cliente_id);
COMMIT


BEGIN TRANSACTION
ALTER TABLE [OOZMA_KAPPA].[Cuenta]
ADD FOREIGN KEY ([cuenta_pais_id])
REFERENCES [OOZMA_KAPPA].[Pais](pais_id);
COMMIT


BEGIN TRANSACTION
ALTER TABLE [OOZMA_KAPPA].[Cuenta]
ADD FOREIGN KEY ([cuenta_moneda_id])
REFERENCES [OOZMA_KAPPA].[Moneda](moneda_id);
COMMIT


BEGIN TRANSACTION
ALTER TABLE [OOZMA_KAPPA].[Cuenta]
ADD FOREIGN KEY ([cuenta_tipo_cuenta_id])
REFERENCES [OOZMA_KAPPA].[Tipo_cuenta](tipo_cuenta_id);
COMMIT


BEGIN TRANSACTION
ALTER TABLE [OOZMA_KAPPA].[Administrador]
ADD FOREIGN KEY ([administrador_usuario_id])
REFERENCES [OOZMA_KAPPA].[Usuario](usuario_id);
COMMIT


BEGIN TRANSACTION
ALTER TABLE [OOZMA_KAPPA].[Deposito]
ADD FOREIGN KEY ([deposito_moneda_id])
REFERENCES [OOZMA_KAPPA].[Moneda](Moneda_id);
COMMIT


BEGIN TRANSACTION
ALTER TABLE [OOZMA_KAPPA].[Deposito]
ADD FOREIGN KEY ([deposito_cuenta_id])
REFERENCES [OOZMA_KAPPA].[Cuenta](cuenta_id);
COMMIT


BEGIN TRANSACTION
ALTER TABLE [OOZMA_KAPPA].[Deposito]
ADD FOREIGN KEY ([deposito_cliente_id])
REFERENCES [OOZMA_KAPPA].[Cliente](cliente_id);
COMMIT


BEGIN TRANSACTION
ALTER TABLE [OOZMA_KAPPA].[Deposito]
ADD FOREIGN KEY ([deposito_tarjeta_id])
REFERENCES [OOZMA_KAPPA].[Tarjeta](tarjeta_id);
COMMIT


BEGIN TRANSACTION
ALTER TABLE [OOZMA_KAPPA].[Cliente]
ADD FOREIGN KEY ([cliente_usuario_id])
REFERENCES [OOZMA_KAPPA].[Usuario](usuario_id);
COMMIT


BEGIN TRANSACTION
ALTER TABLE [OOZMA_KAPPA].[Cliente]
ADD FOREIGN KEY ([cliente_tipo_documento_id])
REFERENCES [OOZMA_KAPPA].[Tipo_documento](tipo_documento_id);
COMMIT


BEGIN TRANSACTION
ALTER TABLE [OOZMA_KAPPA].[Cliente]
ADD FOREIGN KEY ([cliente_pais_residente_id])
REFERENCES [OOZMA_KAPPA].[Pais](pais_id);
COMMIT


BEGIN TRANSACTION
ALTER TABLE [OOZMA_KAPPA].[Factura]
ADD FOREIGN KEY ([factura_cliente_id])
REFERENCES [OOZMA_KAPPA].[Cliente](cliente_id);
COMMIT

BEGIN TRANSACTION
ALTER TABLE [OOZMA_KAPPA].[Factura]
ADD FOREIGN KEY ([factura_items_id])
REFERENCES [OOZMA_KAPPA].[Item_factura](item_factura_id);
COMMIT

BEGIN TRANSACTION
ALTER TABLE [OOZMA_KAPPA].[Factura]
ADD PRIMARY KEY ([factura_numero],[factura_items_id]);
COMMIT

BEGIN TRANSACTION
ALTER TABLE [OOZMA_KAPPA].[Funcionalidades_rol]
ADD FOREIGN KEY ([funcionalidad_id])
REFERENCES [OOZMA_KAPPA].[Funcionalidades](funcionalidades_id);
COMMIT


BEGIN TRANSACTION
ALTER TABLE [OOZMA_KAPPA].[Funcionalidades_rol]
ADD FOREIGN KEY ([rol_id])
REFERENCES [OOZMA_KAPPA].[Rol](rol_id);
COMMIT


BEGIN TRANSACTION
ALTER TABLE [OOZMA_KAPPA].[Usuario_rol]
ADD FOREIGN KEY ([usuario_id])
REFERENCES [OOZMA_KAPPA].[Usuario](usuario_id);
COMMIT


BEGIN TRANSACTION
ALTER TABLE [OOZMA_KAPPA].[Usuario_rol]
ADD FOREIGN KEY ([rol_id])
REFERENCES [OOZMA_KAPPA].[Rol](rol_id);
COMMIT