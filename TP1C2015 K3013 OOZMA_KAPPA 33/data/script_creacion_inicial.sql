
USE [GD1C2015]
GO


----------------------------------------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------CREACION TABLAS--------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------------------------------------


CREATE SCHEMA [OOZMA_KAPPA] AUTHORIZATION [gd];
GO

USE [GD1C2015]


--- TABLA ADMINISTRADOR ---

CREATE TABLE [OOZMA_KAPPA].[Administrador](
	[administrador_id] numeric(18, 0) IDENTITY (1,1),
	[administrador_estado] bit  NOT NULL DEFAULT (1),  --- 0 DESHABILITADO, 1 HABILITADO
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
	[cheque_destino_cliente_id] numeric(18, 0)NOT NULL,	
)												

--- TABLA CLIENTE ---

CREATE TABLE [OOZMA_KAPPA].[Cliente](
	[cliente_id] numeric(18, 0) IDENTITY (1,1),
	[cliente_usuario_id] numeric(18, 0)NOT NULL,
	[cliente_apellido] [varchar](255) NOT NULL,
	[cliente_nombre] [varchar](255) NOT NULL,
	[cliente_fecha_nacimiento] Date NOT NULL,
	[cliente_tipo_documento_id] numeric(18, 0)NOT NULL,
	[cliente_numero_documento] numeric(18, 0)NOT NULL,
	[cliente_pais_residente_id] numeric(18, 0)NOT NULL,
	[cliente_calle] [varchar](255) NOT NULL,
	[cliente_numero] numeric(18, 0)NOT NULL,
	[cliente_piso] numeric(18, 0)NOT NULL,
	[cliente_depto] [varchar](10) NOT NULL, 
	[cliente_mail] [varchar](255),
	[cliente_estado] bit NOT NULL DEFAULT (1), ---  0 deshabilitado 1 habilitado
	[cliente_eliminado] bit NOT NULL DEFAULT (0), --- 0 no eliminado, 1 eliminado
)

--- TABLA CUENTA ---

CREATE TABLE [OOZMA_KAPPA].[Cuenta](
	[cuenta_id] numeric(18, 0) IDENTITY (1,1),
	[cuenta_cliente_id] numeric(18, 0)NOT NULL,
	[cuenta_pais_id] numeric(18, 0)NOT NULL,
	[cuenta_moneda_id] numeric(18, 0)NOT NULL DEFAULT(1),
	[cuenta_tipo_cuenta_id] numeric(18, 0)NOT NULL,
	[cuenta_saldo] numeric(18, 0)NOT NULL DEFAULT(0),
	[cuenta_fecha_apertura] [datetime] NOT NULL,
	[cuenta_fecha_cierre] [datetime] NOT NULL,
	[cuenta_estado] bit NOT NULL DEFAULT(1),  --0 es false deshabilitada , 1 true habilitada
	[cuenta_cerrada] bit NOT NULL DEFAULT (0),  --- 0 false, 1 true
	[cuenta_pendiente_activacion] bit NOT NULL DEFAULT(1), --- 0 false 1 true
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
	[factura_fecha] [datetime] NOT NULL,
	[factura_importe] numeric(18, 2 )NOT NULL,
	[factura_cliente_id] numeric(18, 0)NOT NULL,
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


--- TABLA LOGIN ---

CREATE TABLE [OOZMA_KAPPA].[Login](
	[login_id] numeric(18, 0) IDENTITY (1,1),
	[login_usuario_id] numeric(18, 0)NOT NULL,
	[login_estado] varchar(50) NOT NULL,  
	[login_cant_intentos] numeric(18, 0)NOT NULL,
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
	[rol_estado] bit NOT NULL DEFAULT(1),   --DESHABILITADO 0, HABILITADO 1
	[rol_eliminado] bit NOT NULL DEFAULT (0), --ELIMINADO 1 (BAJA LOGICA), NO ELIMINADO 0
)

INSERT INTO[OOZMA_KAPPA].[Rol] (rol_nombre) VALUES ('Administrador');
INSERT INTO[OOZMA_KAPPA].[Rol] (rol_nombre) VALUES ('Cliente');

---- TABLA EMISOR ----

CREATE TABLE [OOZMA_KAPPA].[Emisor](
	[emisor_id] numeric (18,0) IDENTITY (1,1),
	[emisor_descripcion] varchar(255) NOT NULL,
	
)

--- TABLA TARJETA  ---

CREATE TABLE [OOZMA_KAPPA].[Tarjeta](
	[tarjeta_id] numeric(18,0) IDENTITY (1,1),  --en la tabla tarjeta numero es varchar(16)
	[tarjeta_codigo_seguridad] varchar(3) NOT NULL,
	[tarjeta_fecha_emision] [datetime] NOT NULL,
	[tarjeta_vencimiento] [datetime] NOT NULL,
	[tarjeta_emisor] numeric(18,0) NOT NULL,
	[tarjeta_cliente_id] numeric (18,0) NOT NULL,
	[tarjeta_estado] bit NOT NULL DEFAULT (1) --0 con baja logica (vencida, desasociada), 1 activa
)

--- TABLA TIPO_CUENTA ---

CREATE TABLE [OOZMA_KAPPA].[Tipo_cuenta](
	[tipo_cuenta_id] numeric(18, 0) IDENTITY (1,1),
	[tipo_cuenta_nombre] [varchar](255) NOT NULL,
	[tipo_cuenta_dias_vigencia] numeric(18,0) NOT NULL,
	[tipo_cuenta_costo_transferencia] numeric(18, 2)NOT NULL,
	[tipo_cuenta_costo_apertura] numeric(18, 2)NOT NULL,   
	[tipo_cuenta_costo_modificacion] numeric(18, 2)NOT NULL,
)


-- los costos se los puse yo --
INSERT INTO[OOZMA_KAPPA].[Tipo_cuenta](tipo_cuenta_nombre, tipo_cuenta_costo_transferencia,tipo_cuenta_costo_apertura, tipo_cuenta_dias_vigencia, tipo_cuenta_costo_modificacion) 
VALUES ('ORO',0.1,500,120,100);
INSERT INTO[OOZMA_KAPPA].[Tipo_cuenta](tipo_cuenta_nombre, tipo_cuenta_costo_transferencia,tipo_cuenta_costo_apertura, tipo_cuenta_dias_vigencia, tipo_cuenta_costo_modificacion) 
VALUES ('PLATA',0.1,400,90,50);
INSERT INTO[OOZMA_KAPPA].[Tipo_cuenta](tipo_cuenta_nombre, tipo_cuenta_costo_transferencia,tipo_cuenta_costo_apertura, tipo_cuenta_dias_vigencia, tipo_cuenta_costo_modificacion) 
VALUES ('BRONCE',0.05,300,60,25);
INSERT INTO[OOZMA_KAPPA].[Tipo_cuenta](tipo_cuenta_nombre, tipo_cuenta_costo_transferencia,tipo_cuenta_costo_apertura, tipo_cuenta_dias_vigencia, tipo_cuenta_costo_modificacion) 
VALUES ('GRATUITA',0.05,0,30,10);

--- TABLA TIPO_DOCUMENTO ---

CREATE TABLE [OOZMA_KAPPA].[Tipo_documento](
	[tipo_documento_id] numeric(18, 0) IDENTITY (1,1),
	[tipo_documento_descripcion] [varchar](255) NOT NULL,
)

INSERT INTO[OOZMA_KAPPA].[Tipo_documento] (tipo_documento_descripcion) VALUES ('DNI');
INSERT INTO[OOZMA_KAPPA].[Tipo_documento] (tipo_documento_descripcion) VALUES ('CI');
INSERT INTO[OOZMA_KAPPA].[Tipo_documento] (tipo_documento_descripcion) VALUES ('LC');
INSERT INTO[OOZMA_KAPPA].[Tipo_documento] (tipo_documento_descripcion) VALUES ('LE');

--- TRANSACCIONES PENDIENTES ---

CREATE TABLE [OOZMA_KAPPA].Transacciones_Pendientes(	
	[transaccion_pendiente_id] numeric(18,0) IDENTITY (1,1),
	[transaccion_pendiente_importe] numeric (18,2)NOT NULL,
	[transaccion_pendiente_descr] varchar(255) NOT NULL,
	[transaccion_pendiente_cliente_id] numeric(18,0) NOT NULL,
	[transaccion_pendiente_fecha] datetime NOT NULL,
	[transaccion_pendiente_cuenta_id] numeric (18,0),
	[transaccion_pendiente_transferencia_id] numeric (18,0),
)


--- TABLA TRANSFERENCIA ---

CREATE TABLE [OOZMA_KAPPA].[Transferencia](
	[transferencia_id] numeric(18, 0) IDENTITY (1,1),
	[transferencia_origen_cuenta_id] numeric(18, 0)NOT NULL,
	[transferencia_destino_cuenta_id] numeric(18, 0)NOT NULL,
	[transferencia_importe] numeric(18, 2)NOT NULL,
	[transferencia_costo] numeric(18, 2)NOT NULL,
	[transferencia_fecha] datetime NOT NULL,
)


--- TABLA ITEM_FACTURA ---

CREATE TABLE [OOZMA_KAPPA].[Item_factura](
	[item_factura_id] numeric(18, 0) IDENTITY (1,1),
	[item_factura_desc] [varchar](255) NOT NULL,
	[item_factura_costo] numeric(18, 2) NOT NULL,
	[item_factura_numero_factura] numeric(18,0) NOT NULL,
	[item_factura_cantidad] numeric(18,0) NOT NULL,
	[item_factura_transferencia_id] numeric (18,0),
	[item_factura_numero_cuenta] numeric (18,0) 
	
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
	[usuario_respuesta_secreta] [nvarchar](64) NOT NULL,   
	[usuario_estado] bit NOT NULL DEFAULT(1),  -- 0 deshabilitado, 1 habilitado
)


-- TABLA USUARIO_ROL --

CREATE TABLE [OOZMA_KAPPA].[Usuario_rol](
	[usuario_rol_id] numeric(18, 0) IDENTITY (1,1),
	[usuario_id] numeric(18, 0)NOT NULL,
	[usuario_username] numeric(18,0)NOT NULL,
	[rol_id] numeric(18, 0)NOT NULL,
)


--CREO TYPE TABLE VALUE PARAMETERS PARA TABLA SUSCRIPCIONES

CREATE TYPE [OOZMA_KAPPA].[TVP_SuscripcionesABorrar] AS TABLE(
 [tvp_cliente_id] numeric(18,0) NOT NULL,
 [tvp_cuenta_id] numeric(18,0) NOT NULL ,
 [tvp_cantidad_Suscripciones] numeric(18,0) NOT NULL,
 [tvp_costo] numeric(18,0) NOT NULL
)
GO


-- TABLA DE HISTORIAL CLIENTE --

CREATE TABLE [OOZMA_KAPPA].[Historial_cuentas]
(
[historial_id] numeric(18,0) IDENTITY(1,1),
[historial_pendientes_de_activacion] bit NOT NULL DEFAULT(0),     -- 1 por este motivo, 0 NO --
[historial_transacciones_superadas] bit NOT NULL DEFAULT(0),      -- 1 por este motivo, 0 NO --
[historial_falta_de_pago] bit NOT NULL DEFAULT(0),                -- 1 por este motivo, 0 NO --
[historial_cliente_id] numeric(18,0) NOT NULL,
[historial_cuenta_id] numeric(18,0) NOT NULL,
[historial_fecha] [datetime] NOT NULL,
)

----------------------------------------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------CREACION PRIMARY KEYS--------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------------------------------------

BEGIN TRANSACTION
ALTER TABLE [OOZMA_KAPPA].[Usuario]
ADD PRIMARY KEY ([usuario_id]);
COMMIT


BEGIN TRANSACTION
ALTER TABLE [OOZMA_KAPPA].[Usuario_rol]
ADD PRIMARY KEY ([usuario_rol_id]);
COMMIT

BEGIN TRANSACTION
ALTER TABLE [OOZMA_KAPPA].[Transacciones_pendientes]
ADD PRIMARY KEY ([transaccion_pendiente_id]);
COMMIT


BEGIN TRANSACTION
ALTER TABLE [OOZMA_KAPPA].[Transferencia]
ADD PRIMARY KEY ([transferencia_id]);
COMMIT


BEGIN TRANSACTION
ALTER TABLE [OOZMA_KAPPA].[Tipo_documento]
ADD PRIMARY KEY ([tipo_documento_id]);
COMMIT


BEGIN TRANSACTION
ALTER TABLE [OOZMA_KAPPA].[Tipo_cuenta]
ADD PRIMARY KEY ([tipo_cuenta_id]);
COMMIT



BEGIN TRANSACTION
ALTER TABLE [OOZMA_KAPPA].[Emisor]
ADD PRIMARY KEY ([emisor_id]);
COMMIT

BEGIN TRANSACTION
ALTER TABLE [OOZMA_KAPPA].[Tarjeta]
ADD PRIMARY KEY ([tarjeta_id]);
COMMIT


BEGIN TRANSACTION
ALTER TABLE [OOZMA_KAPPA].[Rol]
ADD PRIMARY KEY ([rol_id]);
COMMIT


BEGIN TRANSACTION
ALTER TABLE [OOZMA_KAPPA].[Retiro]
ADD PRIMARY KEY ([retiro_id]);
COMMIT


BEGIN TRANSACTION
ALTER TABLE [OOZMA_KAPPA].[Pais]
ADD PRIMARY KEY ([pais_id]);
COMMIT


BEGIN TRANSACTION
ALTER TABLE [OOZMA_KAPPA].[Moneda]
ADD PRIMARY KEY ([moneda_id]);
COMMIT


BEGIN TRANSACTION
ALTER TABLE [OOZMA_KAPPA].[Login]
ADD PRIMARY KEY ([login_id]);
COMMIT
		

BEGIN TRANSACTION
ALTER TABLE [OOZMA_KAPPA].[Item_factura]
ADD PRIMARY KEY ([item_factura_id]);
COMMIT
	

BEGIN TRANSACTION
ALTER TABLE [OOZMA_KAPPA].[Funcionalidades_rol]
ADD PRIMARY KEY ([funcionalidades_rol_id]);
COMMIT
	

BEGIN TRANSACTION
ALTER TABLE [OOZMA_KAPPA].[Funcionalidades]
ADD PRIMARY KEY ([funcionalidades_id]);
COMMIT

BEGIN TRANSACTION
ALTER TABLE [OOZMA_KAPPA].[Factura]
ADD PRIMARY KEY ([factura_numero]);
COMMIT


BEGIN TRANSACTION
ALTER TABLE [OOZMA_KAPPA].[Deposito]
ADD PRIMARY KEY ([deposito_id]);
COMMIT
	

BEGIN TRANSACTION
ALTER TABLE [OOZMA_KAPPA].[Cuenta]
ADD PRIMARY KEY ([cuenta_id]);
COMMIT
	

BEGIN TRANSACTION
ALTER TABLE [OOZMA_KAPPA].[Cliente]
ADD PRIMARY KEY ([cliente_id]);
COMMIT
	

BEGIN TRANSACTION
ALTER TABLE [OOZMA_KAPPA].[Cheque]
ADD PRIMARY KEY ([cheque_id]);
COMMIT


BEGIN TRANSACTION
ALTER TABLE [OOZMA_KAPPA].[Banco]
ADD PRIMARY KEY ([banco_id]);
COMMIT
	

BEGIN TRANSACTION
ALTER TABLE [OOZMA_KAPPA].[Administrador]
ADD PRIMARY KEY ([administrador_id]);
COMMIT
	
	
BEGIN TRANSACTION
ALTER TABLE [OOZMA_KAPPA].[Historial_cuentas]
ADD PRIMARY KEY ([historial_id]);
COMMIT

----------------------------------------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------MIGRACION--------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------------------------------------



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

-- TABLA USUARIO --   

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

 -- TABLA CLIENTE --  
 
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

  
 ----TABLA CUENTA---- 
 
 BEGIN TRANSACTION
  
 SET IDENTITY_INSERT [OOZMA_KAPPA].[Cuenta] ON
  
 INSERT INTO [OOZMA_KAPPA].[Cuenta](cuenta_id, 
	cuenta_cliente_id, 
	cuenta_pais_id,
	cuenta_tipo_cuenta_id, 
	cuenta_saldo, cuenta_fecha_apertura, cuenta_fecha_cierre, cuenta_pendiente_activacion )(
	SELECT DISTINCT Cuenta_Numero
	,(SELECT cliente_id FROM OOZMA_KAPPA.Cliente WHERE Cli_Nro_Doc = cliente_numero_documento)
	,Cuenta_Pais_Codigo
	,4 --CONSIDERAMOS TODAS SON GRATUITAS (segun mail), y la gratuita tiene id 4
	,50000  --COMO NO ESTA EL MONTO DE CADA CUENTA CONSIDEREMOS ESTE VALOR PARA TODAS.
	,Cuenta_Fecha_Creacion   --cuenta moneda y estado les puse default 1(dolar) y "Habilitada"
	,(SELECT DATEADD(DAY,tipo_cuenta_dias_vigencia,Cuenta_Fecha_Creacion)FROM OOZMA_KAPPA.Tipo_cuenta WHERE tipo_cuenta_id = 4)    --segun el tipo cuenta la fecha de cierre
	,0
 FROM gd_esquema.Maestra
 WHERE Cuenta_Numero IS NOT NULL);
   
 SET IDENTITY_INSERT [OOZMA_KAPPA].[Cuenta] OFF
  
 COMMIT 
 

---- TABLA TRANFERENCIA ---

BEGIN TRANSACTION
 
INSERT INTO [OOZMA_KAPPA].[Transferencia] (transferencia_origen_cuenta_id, transferencia_destino_cuenta_id,
										transferencia_importe, transferencia_costo, transferencia_fecha)(
	SELECT Cuenta_Numero, Cuenta_Dest_Numero,  Trans_Importe, Trans_Costo_Trans, Transf_Fecha
	FROM gd_esquema.Maestra	WHERE Item_Factura_Descr is not null);
	
COMMIT

  -- TABLA ITEM FACTURA --  	
 
BEGIN TRANSACTION
	INSERT INTO [OOZMA_KAPPA].[Item_factura] (item_factura_desc,item_factura_costo, item_factura_numero_factura,item_factura_cantidad, item_factura_numero_cuenta ,item_factura_transferencia_id)(
	SELECT DISTINCT Item_Factura_Descr, 				
					Item_Factura_Importe,
					Factura_Numero, 
					1,
					Cuenta_Numero,
					t.transferencia_id 
	FROM gd_esquema.Maestra m LEFT JOIN OOZMA_KAPPA.Transferencia t ON t.transferencia_fecha = m.Transf_Fecha AND t.transferencia_costo = m.Trans_Costo_Trans AND t.transferencia_importe = m.Trans_Importe AND  t.transferencia_origen_cuenta_id = m.Cuenta_Numero AND t.transferencia_destino_cuenta_id = m.Cuenta_Dest_Numero
	WHERE Item_Factura_Descr IS NOT NULL);
COMMIT
GO


  -- TABLA DEPOSITO--  
  
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


--- TABLA EMISOR ---


BEGIN TRANSACTION

INSERT INTO [OOZMA_KAPPA].[Emisor] (emisor_descripcion) (
	SELECT DISTINCT Tarjeta_Emisor_Descripcion FROM gd_esquema.Maestra 
	WHERE Tarjeta_Emisor_Descripcion IS NOT NULL);
COMMIT	
	
  -- TABLA TARJETA --
 
 BEGIN TRANSACTION
 
 SET IDENTITY_INSERT [OOZMA_KAPPA].[Tarjeta] ON
 
 INSERT INTO [OOZMA_KAPPA].[Tarjeta] ( tarjeta_id, tarjeta_codigo_seguridad, tarjeta_fecha_emision, tarjeta_vencimiento, tarjeta_emisor, tarjeta_cliente_id)(
	SELECT DISTINCT Tarjeta_numero
	, Tarjeta_Codigo_Seg
    , Tarjeta_Fecha_Emision
    , Tarjeta_Fecha_Vencimiento
	, (SELECT emisor_id FROM OOZMA_KAPPA.Emisor WHERE emisor_descripcion = Tarjeta_Emisor_Descripcion)
	, (SELECT cliente_id FROM [OOZMA_KAPPA].[Cliente] WHERE Cli_Nro_Doc = cliente_numero_documento)
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

 BEGIN TRANSACTION  
 
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
 

  -- TABLA FACTURA --  
 
 BEGIN TRANSACTION
 
 SET IDENTITY_INSERT [OOZMA_KAPPA].[Factura] ON
 
 INSERT INTO [OOZMA_KAPPA].[Factura] (factura_numero,factura_fecha, factura_importe, factura_cliente_id)(
	SELECT Factura_Numero
	,Factura_Fecha
	,Item_Factura_Importe
	,(SELECT cliente_id FROM OOZMA_KAPPA.Cliente WHERE Cli_Nro_Doc = cliente_numero_documento)
	FROM  gd_esquema.Maestra WHERE Factura_Numero IS NOT NULL);
 
 SET IDENTITY_INSERT [OOZMA_KAPPA].[Factura] OFF 
 
 COMMIT




---------------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
----------------------------------- CREACION DE USUARIOS DEFAULT  ---------------------------------

--HAGO QUE TODOS LOS USUARIOS SEAN CLIENTES, Y QUE SOLO LOS PRIMEROS 5 SEAN TAMBIEN ADMINS

BEGIN TRANSACTION

INSERT INTO [OOZMA_KAPPA].Usuario_rol(usuario_id,usuario_username, rol_id)(
SELECT usuario_id, usuario_username, rol_id FROM OOZMA_KAPPA.Usuario, OOZMA_KAPPA.Rol WHERE rol_nombre = 'Cliente' );

COMMIT
GO

BEGIN TRANSACTION

INSERT INTO [OOZMA_KAPPA].Usuario_rol(usuario_id,usuario_username,rol_id) (SELECT TOP 5 usuario_id,usuario_username,1 FROM OOZMA_KAPPA.Usuario);

COMMIT
GO

-- un usuario con username ADMIN y contrase;a w23e

BEGIN TRANSACTION   

INSERT INTO [OOZMA_KAPPA].Usuario
(usuario_username,usuario_nombreYapellido,usuario_password,usuario_fecha_creacion,usuario_fecha_ultima_modificacion, usuario_pregunta_secreta , usuario_respuesta_secreta)
 (SELECT 123,
  'administrador general',
  '52D77462B24987175C8D7DAB901A5967E927FFC8D0B6E4A234E07A4AEC5E3724', --RESPUESTA w23e
  GETDATE(),GETDATE(),
  'Color preferido?',
  'AF4C20351356D258C57B16291CCEB8BAEE3D4DEE410061EA66D7C636EFE075CC'); --RESPUESTA SECRETA azul
COMMIT

--YA TODOS LOS USUARIOS DE LA TABLA MAESTRA ESTAN CREADOS CON CONTRASENA : user Y RESPUESTA SECRETA: azul ya encriptadas

-- TABLA USUARIO ROL --

BEGIN TRANSACTION  --agrego usuario rol del admin

INSERT INTO [OOZMA_KAPPA].Usuario_rol(usuario_id,usuario_username,rol_id) (SELECT DISTINCT usuario_id,123,1 FROM OOZMA_KAPPA.Usuario WHERE usuario_username = 123);

COMMIT


INSERT INTO [OOZMA_KAPPA].Administrador(administrador_username, administrador_usuario_id)(SELECT TOP 5 usuario_username,usuario_id FROM OOZMA_KAPPA.Usuario);

INSERT INTO [OOZMA_KAPPA].Administrador(administrador_username, administrador_usuario_id)(SELECT usuario_username, usuario_id FROM OOZMA_KAPPA.Usuario WHERE usuario_username = 123);



----------------------------------------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------FOREIGN KEY------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------------------------------------


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
ALTER TABLE [OOZMA_KAPPA].[Item_Factura]
ADD FOREIGN KEY ([item_factura_numero_factura])
REFERENCES [OOZMA_KAPPA].[Factura](factura_numero);
COMMIT

BEGIN TRANSACTION
ALTER TABLE [OOZMA_KAPPA].[Item_Factura]
ADD FOREIGN KEY ([item_factura_transferencia_id])
REFERENCES [OOZMA_KAPPA].[Transferencia](transferencia_id);
COMMIT

BEGIN TRANSACTION
ALTER TABLE [OOZMA_KAPPA].[Factura]
ADD FOREIGN KEY ([factura_cliente_id])
REFERENCES [OOZMA_KAPPA].[Cliente](cliente_id);
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


BEGIN TRANSACTION
ALTER TABLE [OOZMA_KAPPA].[Tarjeta]
ADD FOREIGN KEY (tarjeta_cliente_id)
REFERENCES [OOZMA_KAPPA].[Cliente](cliente_id);
COMMIT

BEGIN TRANSACTION
ALTER TABLE [OOZMA_KAPPA].[Tarjeta]
ADD FOREIGN KEY ([tarjeta_emisor])
REFERENCES [OOZMA_KAPPA].[Emisor](emisor_id);
COMMIT


BEGIN TRANSACTION
ALTER TABLE [OOZMA_KAPPA].[Transacciones_pendientes]
ADD FOREIGN KEY (transaccion_pendiente_cliente_id)
REFERENCES [OOZMA_KAPPA].[Cliente](cliente_id);
COMMIT


BEGIN TRANSACTION
ALTER TABLE [OOZMA_KAPPA].[Transacciones_pendientes]
ADD FOREIGN KEY (transaccion_pendiente_cuenta_id)
REFERENCES [OOZMA_KAPPA].[Cuenta](cuenta_id);
COMMIT

BEGIN TRANSACTION
ALTER TABLE [OOZMA_KAPPA].[Historial_cuentas]
ADD FOREIGN KEY ([historial_cliente_id])
REFERENCES [OOZMA_KAPPA].[Cliente](cliente_id);
COMMIT

BEGIN TRANSACTION
ALTER TABLE [OOZMA_KAPPA].[Historial_cuentas]
ADD FOREIGN KEY ([historial_cuenta_id])
REFERENCES [OOZMA_KAPPA].[Cuenta](cuenta_id);
COMMIT


----------------------------------------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------PROCEDIMIENTOS---------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------------------------------------



CREATE PROCEDURE [OOZMA_KAPPA].traerListadoRolesCompleto
AS 
	SELECT rol_id , rol_nombre FROM OOZMA_KAPPA.Rol where rol_eliminado = 0;  ---rol_eliminado = 0 está activo (no eliminado)
GO

CREATE PROCEDURE OOZMA_KAPPA.updateRol
	@rol_id int,
	@rol_nombre nvarchar(255),
	@rol_estado bit
AS
	UPDATE OOZMA_KAPPA.Rol SET rol_nombre=@rol_nombre, rol_estado=@rol_estado
	WHERE rol_id = @rol_id
GO

CREATE PROCEDURE OOZMA_KAPPA.deshabilitarRol
	@rol_id int
AS
	UPDATE OOZMA_KAPPA.Rol SET rol_estado = 0   ---rol_estado = 0 es deshabilitado
	WHERE rol_id = @rol_id
GO

CREATE PROCEDURE OOZMA_KAPPA.deleteRol
	@rol_id int
AS
	UPDATE OOZMA_KAPPA.Rol SET rol_eliminado = 1  --rol_eliminado = 1 es baja lógica
	WHERE rol_id = @rol_id
GO

CREATE PROCEDURE OOZMA_KAPPA.deleteRol_Funcionalidad_PorIdRol
	@rol_id int
AS
	DELETE FROM OOZMA_KAPPA.Funcionalidades_rol WHERE rol_id = @rol_id
GO

CREATE PROCEDURE OOZMA_KAPPA.insertRol_RetornarID
	@rol_nombre nvarchar(255),
	@rol_estado bit
AS
	INSERT INTO OOZMA_KAPPA.Rol	(rol_nombre, rol_estado)
	VALUES(@rol_nombre, @rol_estado)
	
	SELECT @@IDENTITY AS rol_id;
GO

CREATE PROCEDURE [OOZMA_KAPPA].[insertRol_Funcionalidad]
	@rol_id int,
	@funcionalidad_id int
AS
	INSERT INTO OOZMA_KAPPA.Funcionalidades_rol(rol_id, funcionalidad_id)
	VALUES(@rol_id, @funcionalidad_id)
GO

CREATE PROCEDURE OOZMA_KAPPA.validarRolEnUsuarios
	@rol_id int
AS
	SELECT * FROM OOZMA_KAPPA.Usuario_rol WHERE rol_id = @rol_id
GO

CREATE PROCEDURE [OOZMA_KAPPA].[traerListadoRolesConFiltros] 
    @rol_nombre nvarchar(255),
	@rol_estado bit
AS 
	IF(@rol_nombre= '' Or @rol_nombre IS NULL)
		BEGIN
			SELECT * FROM [OOZMA_KAPPA].Rol WHERE rol_estado = @rol_estado and rol_eliminado = 0; --- si esta eliminado es 1, sino 0
		END	
	ELSE
		SELECT * FROM [OOZMA_KAPPA].Rol
			WHERE rol_nombre LIKE '%' + @rol_nombre + '%' AND rol_estado = @rol_estado and rol_eliminado = 0;

GO

CREATE PROCEDURE OOZMA_KAPPA.traerListadoRolesPorNombre
	@rol_nombre nvarchar(255)
AS
	SELECT * FROM OOZMA_KAPPA.Rol where rol_nombre LIKE '%' + @rol_nombre + '%' and rol_eliminado = 0 
GO


CREATE PROCEDURE OOZMA_KAPPA.traerListadoFuncionalidades
AS	
	SELECT * FROM OOZMA_KAPPA.Funcionalidades
GO


--------- SP DEPOSITO----------
CREATE PROCEDURE [OOZMA_KAPPA].[insertDeposito] 
	@deposito_cuenta_id numeric (18,0),
	@deposito_cliente_id numeric (18,0),
	@deposito_importe numeric (18,0),
	@deposito_tarjeta_id numeric (18,0),
	@deposito_fecha datetime,
	@deposito_moneda numeric(18,0)
AS
	INSERT INTO OOZMA_KAPPA.Deposito(deposito_cuenta_id, deposito_cliente_id, deposito_importe, deposito_tarjeta_id, deposito_fecha, deposito_moneda_id)
	VALUES (@deposito_cuenta_id, @deposito_cliente_id, @deposito_importe, @deposito_tarjeta_id, @deposito_fecha, @deposito_moneda);
	
GO	


--------- SP TARJETA------------
CREATE PROCEDURE [OOZMA_KAPPA].[traerListadoTarjetaActivasPorClienteID]
	@cliente_id numeric (18,0),
	@Fecha datetime
AS
	SELECT tarjeta_id AS tarjeta_numero, '************' + RIGHT(tarjeta_id,4) AS tarjeta_visible,tarjeta_emisor,tarjeta_fecha_emision,tarjeta_vencimiento, tarjeta_estado FROM OOZMA_KAPPA.Tarjeta
	WHERE tarjeta_cliente_id = @cliente_id AND CONVERT(varchar(10), tarjeta_vencimiento, 103) > CONVERT(varchar(10),@Fecha, 103)
	AND tarjeta_estado = 1
GO

CREATE PROCEDURE [OOZMA_KAPPA].[traerListadoTarjetaPorClienteID]
	@cliente_id numeric(18,0)
AS
	SELECT tarjeta_id AS tarjeta_numero, '************' + RIGHT(tarjeta_id,4) AS tarjeta_visible,tarjeta_emisor,tarjeta_fecha_emision,tarjeta_vencimiento, tarjeta_estado FROM OOZMA_KAPPA.Tarjeta WHERE tarjeta_cliente_id = @cliente_id;
GO


CREATE PROCEDURE [OOZMA_KAPPA].[insertTarjeta] 
	@Fecha datetime,
	@tarjeta_emisor varchar(255),
	@cliente_id numeric (18,0)
	
AS
	INSERT INTO OOZMA_KAPPA.Tarjeta(tarjeta_fecha_emision, tarjeta_vencimiento, tarjeta_emisor, tarjeta_cliente_id, tarjeta_estado, tarjeta_codigo_seguridad)
	VALUES (@Fecha, DATEADD(year,1,@Fecha), @tarjeta_emisor, @cliente_id, 1,
			(SELECT TOP 1 (tarjeta_codigo_seguridad +1)  FROM OOZMA_KAPPA.Tarjeta ORDER BY tarjeta_codigo_seguridad DESC));
GO	

CREATE PROCEDURE OOZMA_KAPPA.updateTarjeta
	@tarjeta_id numeric (18,0), 
	@tarjeta_emisor varchar(255),
	@tarjeta_estado bit
AS
	UPDATE OOZMA_KAPPA.Tarjeta SET tarjeta_emisor=@tarjeta_emisor, tarjeta_estado = @tarjeta_estado
	WHERE tarjeta_id=@tarjeta_id
GO


CREATE PROCEDURE OOZMA_KAPPA.deshabilitarTarjeta
	@tarjeta_id numeric(18,0)
AS
BEGIN
	UPDATE OOZMA_KAPPA.Tarjeta SET tarjeta_estado = 0 WHERE tarjeta_id = @tarjeta_id;
END
GO

-------- SP MONEDA--------------
CREATE PROCEDURE [OOZMA_KAPPA].[traerListadoMonedaCompleto]
AS
	SELECT moneda_id as id_Moneda, moneda_nombre as Moneda FROM OOZMA_KAPPA.Moneda;
GO


----SP CUENTA---

CREATE PROCEDURE[OOZMA_KAPPA].[traerListadoCuentaExiste]
@cuenta_id numeric(18,0)
AS
	SELECT * FROM OOZMA_KAPPA.Cuenta where @cuenta_id = cuenta_id
	
GO	

---SP QUE CUANDO HAYA TRANSACCIONES PENDIENTES A FACTURAR DE HACE 45 DÌAS LA CUENTA SE BLOQUEE POR FALTA DE PAGO--
---CUANDO SE INICIA SESION SE USA ESTE PROCEDIMIENTO PARA SABER SI HAY CUENTAS PARA INHABILITAR POR FALTA DE PAGO--

CREATE PROCEDURE [OOZMA_KAPPA].[insertHistorial] 
AS
BEGIN TRANSACTION
	INSERT INTO OOZMA_KAPPA.Historial_cuentas(historial_cliente_id, 
	historial_cuenta_id,
	historial_fecha, 
	historial_falta_de_pago, 
	historial_pendientes_de_activacion, 
	historial_transacciones_superadas)
	(SELECT transaccion_pendiente_cliente_id, 
	transaccion_pendiente_cuenta_id, 
	GETDATE(), 
	1, 
	0, 
	0
	FROM OOZMA_KAPPA.Transacciones_Pendientes
	WHERE DATEDIFF(day, transaccion_pendiente_fecha, GETDATE()) > 45 ) 
COMMIT
GO	


-- TRAER LISTADO CLIENTE CON TODO --

CREATE PROCEDURE [OOZMA_KAPPA].[TraerListadoClienteConTodo]
AS
BEGIN TRANSACTION
SELECT * FROM OOZMA_KAPPA.Cliente where cliente_eliminado = 0
COMMIT;
GO

CREATE PROCEDURE [OOZMA_KAPPA].[traerListadoCliente]
AS
BEGIN TRANSACTION
SELECT * FROM OOZMA_KAPPA.Cliente WHERE cliente_eliminado = 0
COMMIT;
GO

-- TRAER LISTADO CLIENTE CON TODO POR CLIENTE ID--

CREATE PROCEDURE [OOZMA_KAPPA].[TraerListadoClienteConTodoPorClienteID]
	@cliente_id numeric(18,0)
AS
BEGIN TRANSACTION
SELECT * FROM OOZMA_KAPPA.Cliente WHERE cliente_id = @cliente_id AND cliente_eliminado = 0
COMMIT;
GO

-- TRAER LISTADO CLIENTE CON FILTROS

CREATE PROCEDURE [OOZMA_KAPPA].[traerListadoClienteConFiltros]
   @cliente_nombre varchar(255),
   @cliente_apellido varchar(255), 
   @cliente_tipo_documento_id numeric(18,0), 
   @cliente_numero_documento varchar(255), 
   @cliente_mail varchar(255)
AS
BEGIN TRANSACTION
  SELECT * FROM OOZMA_KAPPA.Cliente
     WHERE cliente_nombre LIKE (CASE WHEN @cliente_nombre <> '' THEN '%' + @cliente_nombre + '%' ELSE cliente_nombre END)
     AND cliente_apellido LIKE (CASE WHEN @cliente_apellido <> '' THEN '%' + @cliente_apellido + '%' ELSE cliente_apellido END)
     AND (@cliente_tipo_documento_id is null OR @cliente_tipo_documento_id = -1 OR CONVERT(VARCHAR(10), cliente_tipo_documento_id) LIKE '%' + CONVERT(VARCHAR(10), @cliente_tipo_documento_id) + '%')     
     AND (@cliente_numero_documento is null OR @cliente_numero_documento = 0 OR CONVERT(VARCHAR(10), cliente_numero_documento) LIKE '%' + CONVERT(VARCHAR(10), @cliente_numero_documento) + '%')
     AND cliente_mail LIKE (CASE WHEN @cliente_mail <> '' THEN '%' + @cliente_mail + '%' ELSE cliente_mail END)
     AND cliente_estado = 1
     AND cliente_eliminado = 0
COMMIT;
GO




-- MODIFICAR CLIENTE --

CREATE PROCEDURE [OOZMA_KAPPA].[updateCliente]
   @cliente_id numeric(18,0),
   @cliente_apellido varchar(255),
   @cliente_nombre varchar(255),
   @cliente_mail varchar(255),
   @cliente_pais_id numeric(18,0),
   @cliente_numero varchar(255),
   @cliente_calle varchar(255),
   @cliente_direccion numeric(18,0),
   @cliente_depto varchar(10),
   @Tipo_Dni numeric(18,0),
   @cliente_estado bit
AS
BEGIN TRANSACTION
  UPDATE OOZMA_KAPPA.Cliente SET cliente_apellido = @cliente_apellido, 
                                 cliente_nombre = @cliente_nombre, 
                                 cliente_mail = @cliente_mail, 
                                 cliente_pais_residente_id = @cliente_pais_id, 
                                 cliente_numero = @cliente_numero, 
                                 cliente_calle = @cliente_calle,
                                 cliente_piso = @cliente_direccion, 
                                 cliente_depto = @cliente_depto, 
                                 cliente_estado = @cliente_estado,
                                 cliente_tipo_documento_id = @Tipo_Dni
  WHERE cliente_id = @cliente_id
COMMIT;
GO

-- BORRAR CLIENTE POR CLIENTE_ID --

CREATE PROCEDURE  [OOZMA_KAPPA].[deleteCliente]  
   @cliente_id numeric(18,0)
AS
UPDATE OOZMA_KAPPA.Cliente SET cliente_eliminado = 1
WHERE cliente_id = @cliente_id
GO



-- INSERTAR UN NUEVO CLIENTE --

CREATE PROCEDURE [OOZMA_KAPPA].insertCliente 
   @cliente_usuario_id numeric(18,0), 
   @Tipo_Dni numeric(18,0), 
   @Dni numeric(18,0),
   @Apellido varchar(255), 
   @Nombre varchar(255), 
   @Fecha_nac datetime, 
   @Mail varchar(255),
   @Pais_id numeric(18,0),
   @Numero_calle varchar(255), 
   @Calle varchar(255), 
   @Dom_piso numeric(18,0),
   @Dom_depto varchar(10),
   @Estado bit
AS
BEGIN TRANSACTION
  INSERT INTO OOZMA_KAPPA.Cliente (cliente_usuario_id,cliente_tipo_documento_id,cliente_numero_documento,
  cliente_apellido, cliente_nombre,cliente_fecha_nacimiento,cliente_mail,cliente_pais_residente_id,cliente_numero,
  cliente_calle,cliente_piso, cliente_depto, cliente_estado)
  VALUES(@cliente_usuario_id, @Tipo_Dni,@Dni,@Apellido,@Nombre,@Fecha_nac,@Mail,@Pais_id,@Numero_calle,
  @Calle,@Dom_piso,@Dom_depto,@Estado);
COMMIT;
GO



-- VALIDAR DNI EN CLIENTE --

CREATE PROCEDURE [OOZMA_KAPPA].validarDniEnCliente
	@cliente_dni numeric(18,0)
AS
BEGIN TRANSACTION

   SELECT * FROM OOZMA_KAPPA.Cliente 
   WHERE cliente_numero_documento = @cliente_dni;

COMMIT;
GO


CREATE PROCEDURE [OOZMA_KAPPA].[InsertUsuario_RetornarID]
    @Username numeric(18,0),
    @Clave nvarchar(64),
    @Pregunta nvarchar(64),
    @Respuesta nvarchar(64),
    @Modificacion datetime,
    @Creacion datetime,
    @Nombre nvarchar(255)
AS
BEGIN 

	INSERT INTO OOZMA_KAPPA.Usuario (usuario_username, usuario_nombreYapellido, usuario_password, usuario_fecha_creacion, usuario_fecha_ultima_modificacion, usuario_pregunta_secreta, usuario_respuesta_secreta)
	VALUES(@Username, @Nombre, @Clave,@Creacion, @Modificacion, @Pregunta, @Respuesta);
	
	SELECT @@IDENTITY as usuario_id;

END
GO

-- TRAER CUENTA DESTINO DESDE UN CLIENTE DESTINO "TRANSFERENCIAS ENTRE CUENTAS"  --


CREATE PROCEDURE [OOZMA_KAPPA].[traerListadoCuentaPorCliente_NoCerradas]
	@cliente_id numeric(18,0), @fecha date 
AS
Begin	
	SELECT cuenta_id as cuenta_numero, cuenta_estado, cuenta_saldo, cuenta_fecha_apertura as fecha_apertura, cuenta_fecha_cierre as fecha_cierre 
	   FROM OOZMA_KAPPA.Cuenta 
	   WHERE cuenta_cliente_id = @cliente_id and cuenta_cerrada = 0 and cuenta_estado = 1
End	                                         	                                        
GO

-- INSERTAR LA NUEVA TRANSFRRENCIA --

CREATE Procedure [OOZMA_KAPPA].insertTransferencia 
(@cuenta_origen numeric(18,0), @cuenta_destino numeric(18,0), @cuenta_importe numeric(18,2), @cuenta_fecha dateTime)
As
Begin
   Declare @costo numeric(18,2)
   If exists (select * from OOZMA_KAPPA.Cuenta C1, OOZMA_KAPPA.Cuenta C2 
		where c1.cuenta_id = @cuenta_origen and C2.cuenta_id = @cuenta_destino and C1.cuenta_cliente_id = C2.cuenta_cliente_id and C1.cuenta_id != C2.cuenta_id)
      Begin
        Set @costo = 0;
      End
   Else 
      Begin
          Select @costo = tipo_cuenta_costo_transferencia*@cuenta_importe 
              From OOZMA_KAPPA.Cuenta, OOZMA_KAPPA.Tipo_cuenta 
              Where cuenta_id = @cuenta_origen
      End
   Insert Into OOZMA_KAPPA.Transferencia(transferencia_origen_cuenta_id, transferencia_destino_cuenta_id, transferencia_importe, transferencia_costo ,transferencia_fecha)
          Values(@cuenta_origen, @cuenta_destino, @cuenta_importe, @costo, @cuenta_fecha)
End
Go

-- LISTADO ESTADISTICO (1) : Clientes que alguna de sus cuentas fueron inhabilitadas por no pagar los costos de transacción --
CREATE PROCEDURE [OOZMA_KAPPA].TraerListadoClientesCuentasDeshabilitadasPorPendientesDeActivacion 
(@fechaDES date, @fechaHAS date)
AS
BEGIN
  SELECT DISTINCT TOP 5 cliente_apellido+','+cliente_nombre AS Cliente, COUNT (*) AS Cantidad
	FROM OOZMA_KAPPA.Historial_cuentas, OOZMA_KAPPA.Cliente 
	WHERE historial_falta_de_pago = 1
	AND cliente_id = historial_cliente_id
	AND MONTH(historial_fecha) BETWEEN MONTH(@fechaDES) AND MONTH(@fechaHAS)
    AND YEAR(historial_fecha) = YEAR(@fechaDES)
	GROUP BY cliente_apellido, cliente_nombre
	ORDER BY Cantidad DESC
END
GO

-- LISTADO ESTADISTICO (2) : Clientes con mayor cantidad de comisiones facturadas en todas sus cuentas

Create Procedure [OOZMA_KAPPA].TraerListadoClientesConMayorCantidadDeComisionesFacturadasEnTodasSusCuentas 
(@fechaDES date, @fechaHAS date)
As
Begin
Select TOP 5 cliente_apellido+', '+cliente_nombre as Cliente, COUNT(*) as Cantidad
	From OOZMA_KAPPA.Cliente, OOZMA_KAPPA.Factura, OOZMA_KAPPA.Item_factura 
	where cliente_id = factura_cliente_id and factura_numero = item_factura_numero_factura and
    item_factura_desc like 'Comisión%' 
  --  CONVERT(varchar(10), factura_fecha, 103) Between CONVERT(varchar(10), @fechaDES, 103) And CONVERT(varchar(10), @fechaHAS, 103)    --
   	AND MONTH(factura_fecha) BETWEEN MONTH(@fechaDES) AND MONTH(@fechaHAS)
    AND YEAR(factura_fecha) = YEAR(@fechaDES)
    Group By cliente_apellido, cliente_nombre
    Order By Cantidad DESC
End
Go

-- LISTADO ESTADISTICO (3) : Clientes con mayor cantidad de transacciones realizadas entre cuentas propias --
	
	
CREATE PROCEDURE [OOZMA_KAPPA].TraerListadoClientesConMayorCantidadDeTransaccionesRealizadasEntreCuentasPropias 
(@fechaDES DATE, @fechaHAS DATE)
AS
BEGIN
SELECT TOP 5 cliente_apellido+', '+cliente_nombre AS Cliente, COUNT(*) AS Cantidad
FROM OOZMA_KAPPA.Cliente, OOZMA_KAPPA.Cuenta C1, OOZMA_KAPPA.Cuenta C2, OOZMA_KAPPA.Transferencia
WHERE cliente_id = c1.cuenta_cliente_id
AND cliente_id = C2.cuenta_cliente_id  
AND C1.cuenta_id != C2.cuenta_id
AND transferencia_destino_cuenta_id = C1.cuenta_id 
AND transferencia_origen_cuenta_id = C2.cuenta_id
-- AND CONVERT(varchar(10), transferencia_fecha, 103)Between CONVERT(varchar(10), @fechaDES, 103) And CONVERT(varchar(10), @fechaHAS, 103) --
AND MONTH(transferencia_fecha) BETWEEN MONTH(@fechaDES) AND MONTH(@fechaHAS)
AND YEAR(transferencia_fecha) = YEAR(@fechaDES)
GROUP BY cliente_apellido, cliente_nombre
ORDER BY Cantidad DESC							  
END
GO

-- LISTADO ESTADISTICO (4) : Paises con mayor cantidad de movimientos tanto ingresos como egresos --


Create Procedure [OOZMA_KAPPA].TraerListadoPaisesConMayorCantidadDeMovimientosTantoIngresosComoEgresos 
(@fechaDES date, @fechaHAS date)
As
Begin
Select TOP 5 pais_nombre, (Depositados+Retirados+TransferenciasEnviadas+TransferenciasRecibidas) as cantidad_movimientos
	From (Select cliente_pais_residente_id as Pais, COUNT(deposito_importe) as Depositados
	         From OOZMA_KAPPA.Cliente Join OOZMA_KAPPA.Deposito On (cliente_id = deposito_cliente_id)
	         Where 	MONTH(deposito_fecha) BETWEEN MONTH(@fechaDES) AND MONTH(@fechaHAS) AND YEAR(deposito_fecha) = YEAR(@fechaDES)
	         Group By cliente_pais_residente_id) d Join (Select cuenta_pais_id as Pais, COUNT(retiro_importe)Retirados
	                                                        From OOZMA_KAPPA.Cuenta Join OOZMA_KAPPA.Retiro On (cuenta_id = retiro_cuenta_id)
	                                                        Where MONTH(retiro_fecha) BETWEEN MONTH(@fechaDES) AND MONTH(@fechaHAS) AND YEAR(retiro_fecha) = YEAR(@fechaDES)
	                                                        Group By cuenta_pais_id) r On (d.Pais = r.Pais)
	                                               Join (Select c1.cuenta_pais_id as Pais, COUNT(transferencia_importe)TransferenciasEnviadas
	                                                        From OOZMA_KAPPA.Transferencia Join OOZMA_KAPPA.Cuenta c1 On (transferencia_origen_cuenta_id = c1.cuenta_id)
	                                                                                       Join OOZMA_KAPPA.Cuenta c2 On (transferencia_destino_cuenta_id = c2.cuenta_id)
	                                                        Where c1.cuenta_pais_id != c2.cuenta_pais_id And MONTH(transferencia_fecha) BETWEEN MONTH(@fechaDES) AND MONTH(@fechaHAS) AND YEAR(transferencia_fecha) = YEAR(@fechaDES)
	                                                        Group By c1.cuenta_pais_id) te On (d.Pais = te.Pais)
	                                               Join (Select c2.cuenta_pais_id as Pais, COUNT(transferencia_importe)TransferenciasRecibidas
	                                                        From OOZMA_KAPPA.Transferencia Join OOZMA_KAPPA.Cuenta c1 On (transferencia_origen_cuenta_id = c1.cuenta_id)
	                                                                                       Join OOZMA_KAPPA.Cuenta c2 On (transferencia_destino_cuenta_id = c2.cuenta_id)
	                                                        Where c1.cuenta_pais_id != c2.cuenta_pais_id And MONTH(transferencia_fecha) BETWEEN MONTH(@fechaDES) AND MONTH(@fechaHAS) AND YEAR(transferencia_fecha) = YEAR(@fechaDES)
	                                                        Group By c2.cuenta_pais_id) tr On (d.Pais = tr.Pais)
	                                               Join Pais On (d.Pais = pais_id)
	  Order By cantidad_movimientos DESC
End
Go

-- LISTADO ESTADISTICO (5) : Total facturado para los distintos tipos de cuentas --


Create Procedure [OOZMA_KAPPA].TraerListadoTotalFacturadoParaLosDistintosTiposDeCuentas 
(@fechaDES date, @fechaHAS date)
As
Begin
   Select cuenta_tipo_cuenta_id, SUM(factura_importe) as TotalFacturado
      From OOZMA_KAPPA.Cuenta Join OOZMA_KAPPA.Cliente On (cliente_id = cuenta_cliente_id)
                           Join OOZMA_KAPPA.Factura On (cliente_id = factura_cliente_id)
      Where MONTH(factura_fecha) BETWEEN MONTH(@fechaDES) AND MONTH(@fechaHAS) AND YEAR(factura_fecha) = YEAR(@fechaDES)
      Group By cuenta_tipo_cuenta_id
End
Go    


----- Crear Stored Procedures -----
CREATE PROCEDURE [OOZMA_KAPPA].traerUsuarioActivoPorUsername
    @Username nvarchar(255)
AS
BEGIN 
    SELECT *
    FROM OOZMA_KAPPA.Usuario
    WHERE usuario_username = @Username AND usuario_estado = 1;
END
GO

CREATE PROCEDURE [OOZMA_KAPPA].traerListadoRolesPorId_Usuario
	@usuario_id nvarchar(255)
AS
BEGIN
	SELECT r.rol_id as rol_id, r.rol_nombre as rol_nombre , r.rol_estado as rol_estado FROM OOZMA_KAPPA.Usuario_rol ur, OOZMA_KAPPA.Rol r 
	WHERE usuario_id = @usuario_id  AND ur.rol_id = r.rol_id and r.rol_eliminado = 0 ;
END
GO

CREATE PROCEDURE [OOZMA_KAPPA].traerListadoFuncionalidadesPorId_Rol
    @id_Rol int
AS
BEGIN 
    SELECT funcionalidades_id, funcionalidades_nombre 
    FROM OOZMA_KAPPA.Funcionalidades f , OOZMA_KAPPA.Funcionalidades_rol fr
    WHERE f.funcionalidades_id = fr.funcionalidad_id AND fr.rol_id = @id_Rol;
END
GO

CREATE PROCEDURE [OOZMA_KAPPA].[deshabilitarUsuario]
	@usuario_id int
AS
BEGIN
	UPDATE [OOZMA_KAPPA].Usuario SET usuario_estado = 0 WHERE usuario_id = @usuario_id;	
END
GO

CREATE PROCEDURE [OOZMA_KAPPA].[updateUsuario]
	@id_Usuario numeric(18,0),
	@Username nvarchar(255),
	@Clave nvarchar(255),
	@Estado bit
AS
BEGIN
	UPDATE [OOZMA_KAPPA].Usuario SET usuario_username=@Username, usuario_password=@Clave, usuario_estado = @Estado 
	WHERE usuario_id=@id_Usuario	
END
GO


CREATE PROCEDURE [OOZMA_KAPPA].[traerListadoRoles]
AS
BEGIN
	SELECT rol_id as id_Rol, rol_nombre as Nombre, rol_estado FROM OOZMA_KAPPA.Rol WHERE rol_eliminado = 0;
END
GO

CREATE PROCEDURE [OOZMA_KAPPA].[traerListadoClienteCompleto]
AS
BEGIN
	SELECT cliente_id as cliente_id,(cliente_apellido +' '+ cliente_nombre) as cliente_nombre, cliente_numero_documento as cliente_documento FROM OOZMA_KAPPA.Cliente where cliente_estado = 1 AND cliente_eliminado = 0;
END
GO

CREATE PROCEDURE [OOZMA_KAPPA].[traerListadoClientePorUsuarioID]
	@usuario_id numeric(18,0)
AS
BEGIN
	SELECT cliente_id as cliente_id,(cliente_apellido +' '+ cliente_nombre) as cliente_nombre, cliente_numero_documento as cliente_documento FROM OOZMA_KAPPA.Cliente 
	WHERE cliente_usuario_id = @usuario_id and cliente_estado = 1 AND cliente_eliminado = 0;
END
GO

CREATE PROCEDURE [OOZMA_KAPPA].[traerListadoClientePorClienteID]
	@cliente_id numeric(18,0)
AS
BEGIN
	SELECT cliente_id, cliente_nombre, cliente_apellido, cliente_numero_documento, cliente_fecha_nacimiento 
	FROM OOZMA_KAPPA.Cliente WHERE cliente_id = @cliente_id and cliente_estado = 1 AND cliente_eliminado = 0;
END
GO


CREATE PROCEDURE [OOZMA_KAPPA].[traerListadoCuentaActivasPorClienteID]
	@cliente_id numeric(18,0),
	@Fecha datetime
AS
BEGIN
	SELECT cuenta_id as cuenta_numero, cuenta_estado, cuenta_saldo, cuenta_fecha_apertura as fecha_apertura, cuenta_fecha_cierre as fecha_cierre FROM OOZMA_KAPPA.Cuenta WHERE cuenta_cliente_id = @cliente_id AND cuenta_estado = 1 AND cuenta_cerrada = 0 AND cuenta_pendiente_activacion = 0;
END
GO

CREATE PROCEDURE [OOZMA_KAPPA].[traerListadoCuentaPorClienteID]
	@cliente_id numeric(18,0)
AS
BEGIN
	SELECT cuenta_id as cuenta_numero, cuenta_estado, cuenta_saldo, cuenta_fecha_apertura as fecha_apertura, cuenta_fecha_cierre as fecha_cierre FROM OOZMA_KAPPA.Cuenta WHERE cuenta_cliente_id = @cliente_id AND cuenta_cerrada = 0 AND cuenta_pendiente_activacion = 0;
END
GO

CREATE PROCEDURE [OOZMA_KAPPA].[traerListadoCuentaporCuentaID]
	@cuenta_id numeric(18,0)
AS
BEGIN
	SELECT cuenta_id, cuenta_cliente_id, cuenta_estado, cuenta_fecha_apertura, cuenta_fecha_cierre, cuenta_moneda_id, cuenta_pais_id, cuenta_saldo, cuenta_tipo_cuenta_id FROM [OOZMA_KAPPA].Cuenta WHERE cuenta_id = @cuenta_id;
END
GO


CREATE PROCEDURE [OOZMA_KAPPA].[traerListadoBancoCompleto]
AS
BEGIN
	SELECT banco_id, (banco_nombre + ' Sucursal : ' + CAST(banco_id as varchar)) as banco_nombre FROM OOZMA_KAPPA.Banco;
END
GO


CREATE PROCEDURE [OOZMA_KAPPA].[insertCheque_RetornarID]
	@cheque_cliente_id numeric(18,0),
	@cheque_cuenta_id numeric(18,0),
	@cheque_banco_id numeric(18,0),
	@cheque_fecha dateTime,
	@cheque_importe numeric(18,0)
AS
BEGIN
	INSERT INTO OOZMA_KAPPA.Cheque(cheque_banco_id,cheque_cuenta_id,cheque_destino_cliente_id,cheque_fecha,cheque_importe)
	VALUES (@cheque_banco_id,@cheque_cuenta_id,@cheque_cliente_id,@cheque_fecha,@cheque_importe );
	
	SELECT @@IDENTITY as cheque_id;

END
GO

CREATE PROCEDURE [OOZMA_KAPPA].[insertRetiro_RetornarID]
	@retiro_cheque_id numeric(18,0),
	@retiro_cuenta_id numeric(18,0),
	@retiro_fecha dateTime,
	@retiro_importe numeric(18,0)
AS
BEGIN
	INSERT INTO OOZMA_KAPPA.Retiro(retiro_cheque_id, retiro_cuenta_id, retiro_fecha, retiro_importe) 
	VALUES (@retiro_cheque_id, @retiro_cuenta_id, @retiro_fecha, @retiro_importe) ;
	
	SELECT @@IDENTITY as retiro_id;
END
GO

ALTER PROCEDURE [OOZMA_KAPPA].[TraerListadoClienteTransferenciasAFacturar]
	@cliente_id numeric(18,0)
AS
BEGIN	
	SELECT transaccion_pendiente_id ,transaccion_pendiente_transferencia_id, transaccion_pendiente_cliente_id, transaccion_pendiente_fecha, transaccion_pendiente_importe FROM OOZMA_KAPPA.Transacciones_Pendientes WHERE transaccion_pendiente_cliente_id = @cliente_id AND (transaccion_pendiente_descr = 'Comisión por transferencia');
END
GO

CREATE PROCEDURE [OOZMA_KAPPA].[TraerListadoClienteSuscripcionesPendientesAFacturarPorClienteIDYCuentaID]
	@cliente_id numeric(18,0),
	@cuenta_id numeric(18,0)
AS
BEGIN
	SELECT transaccion_pendiente_cliente_id,transaccion_pendiente_cuenta_id, transaccion_pendiente_fecha, transaccion_pendiente_importe FROM OOZMA_KAPPA.Transacciones_Pendientes WHERE transaccion_pendiente_cliente_id = @cliente_id AND transaccion_pendiente_cuenta_id = @cuenta_id AND (transaccion_pendiente_descr = 'Suscripciones por Apertura Cuenta');
END
GO

CREATE PROCEDURE [OOZMA_KAPPA].[TraerListadoClienteModificacionesTCAFacturar]
	@cliente_id numeric(18,0)
AS
BEGIN
	SELECT transaccion_pendiente_id ,transaccion_pendiente_cliente_id,transaccion_pendiente_fecha, transaccion_pendiente_importe, transaccion_pendiente_cuenta_id FROM OOZMA_KAPPA.Transacciones_Pendientes WHERE transaccion_pendiente_cliente_id = @cliente_id AND (transaccion_pendiente_descr = 'Modificaciones Tipo Cuenta');
END
GO

CREATE PROCEDURE [OOZMA_KAPPA].[TraerListadoClienteCantidadSuscripcionesPendientesAFacturarPorClienteIDYCuentaID]
	@cliente_id numeric(18,0),
	@cuenta_id numeric(18,0)
AS
BEGIN 
	SELECT COUNT(transaccion_pendiente_cliente_id) as cantidadSuscripciones FROM OOZMA_KAPPA.Transacciones_Pendientes WHERE transaccion_pendiente_cliente_id = @cliente_id AND transaccion_pendiente_descr = 'Suscripciones por Apertura Cuenta' AND transaccion_pendiente_cuenta_id = @cuenta_id GROUP BY transaccion_pendiente_cliente_id
END
GO

CREATE PROCEDURE [OOZMA_KAPPA].[TraerListadoCuentaAPagarPorClienteID]
	@cliente_id numeric(18,0)
AS
BEGIN 
	SELECT DISTINCT transaccion_pendiente_cuenta_id as cuenta_id FROM OOZMA_KAPPA.Transacciones_Pendientes WHERE transaccion_pendiente_cliente_id = @cliente_id AND transaccion_pendiente_descr = 'Suscripciones por Apertura Cuenta';
END
GO


CREATE PROCEDURE [OOZMA_KAPPA].[InsertFactura]
	@factura_importe numeric(18,2),
	@factura_fecha datetime,
	@factura_cliente_id numeric(18,0),
	@tablaSuscripciones TVP_SuscripcionesABorrar READONLY	
AS
BEGIN TRANSACTION
	 DECLARE @Cliente numeric(18,0)
	 DECLARE @Cuenta numeric(18,0)
	 DECLARE @CantidadSuscripciones int
	 DECLARE @Costo numeric(18,2)
	 DECLARE @Factura numeric(18,0)
	 DECLARE itemsSuscripciones CURSOR FOR (SELECT tvp_cliente_id, tvp_cuenta_id, tvp_cantidad_Suscripciones FROM @tablaSuscripciones)
	 
	 OPEN itemsSuscripciones;
	 
	 INSERT INTO OOZMA_KAPPA.Factura (factura_importe, factura_fecha, factura_cliente_id)
	 VALUES (@factura_importe, @factura_fecha, @factura_cliente_id);
	 SET @Factura = (SELECT TOP 1 factura_numero FROM OOZMA_KAPPA.Factura ORDER BY factura_numero DESC);
	 
	 FETCH NEXT FROM itemsSuscripciones INTO @Cliente, @Cuenta, @CantidadSuscripciones, @Costo;
	 
	 WHILE @@FETCH_STATUS = 0
	 BEGIN
	 
		WITH suscripciones AS (SELECT TOP (@CantidadSuscripciones) * 
							 FROM OOZMA_KAPPA.Transacciones_Pendientes WHERE  transaccion_pendiente_cliente_id = @Cliente AND
																			  transaccion_pendiente_cuenta_id = @Cuenta
															   				  ORDER BY transaccion_pendiente_fecha)
		DELETE FROM suscripciones;
		
		UPDATE OOZMA_KAPPA.Cuenta SET cuenta_estado = 1, cuenta_pendiente_activacion = 0 WHERE cuenta_id = @Cuenta
		
		INSERT INTO OOZMA_KAPPA.Item_factura(item_factura_numero_cuenta,item_factura_numero_factura, item_factura_cantidad, item_factura_costo, item_factura_desc)
		VALUES (@Cuenta, @Factura, @CantidadSuscripciones, @Costo, 'Suscripciones por Apertura Cuenta');
		
		FETCH NEXT FROM itemsSuscripciones INTO @Cliente, @Cuenta, @CantidadSuscripciones, @Costo;
		
	END
	 	
	
 	DELETE FROM OOZMA_KAPPA.Transacciones_Pendientes WHERE transaccion_pendiente_cliente_id = @factura_cliente_id AND transaccion_pendiente_descr <> 'Suscripciones por Apertura Cuenta';
	 
	CLOSE itemsSuscripciones;
	DEALLOCATE itemsSuscripciones;
	
COMMIT
GO

CREATE PROCEDURE [OOZMA_KAPPA].[TraerListadoFacturaUltimaGenerada]
AS
BEGIN 
	SELECT TOP 1 factura_numero, factura_cliente_id, factura_importe, factura_fecha FROM OOZMA_KAPPA.Factura ORDER BY factura_numero DESC
END
GO


CREATE PROCEDURE [OOZMA_KAPPA].[DeleteSuscripcionesAfterFacturacion]
	@cuenta_id numeric(18,0),
	@cantidadSuscripciones numeric(18,0)
AS
BEGIN
	DELETE FROM OOZMA_KAPPA.Transacciones_Pendientes WHERE transaccion_pendiente_cuenta_id = @cuenta_id;

END
GO

CREATE PROCEDURE [OOZMA_KAPPA].[TraerListadoCuentaCompleto]
AS
BEGIN
	SELECT cuenta_id, cliente_id, (cliente_nombre + ' ' + cliente_apellido) as cliente_nombre, cuenta_estado, cuenta_fecha_apertura, cuenta_fecha_cierre, cuenta_moneda_id, cuenta_pais_id, cuenta_saldo, cuenta_tipo_cuenta_id FROM OOZMA_KAPPA.Cuenta, OOZMA_KAPPA.Cliente WHERE cliente_id = cuenta_cliente_id AND cuenta_cerrada = 0 ;
END
GO

CREATE PROCEDURE [OOZMA_KAPPA].[TraerListadoCuentaPorUsuarioID]
	@usuario_id numeric(18,0)
AS
BEGIN
	SELECT cuenta_id, cliente_id, (cliente_nombre + ' ' + cliente_apellido) as cliente_nombre, cuenta_estado, cuenta_fecha_apertura, cuenta_fecha_cierre, cuenta_moneda_id, cuenta_pais_id, cuenta_saldo, cuenta_tipo_cuenta_id FROM OOZMA_KAPPA.Cuenta, OOZMA_KAPPA.Cliente WHERE cliente_id = cuenta_cliente_id AND cliente_usuario_id = @usuario_id AND cuenta_cerrada = 0 ;
END
GO

CREATE PROCEDURE OOZMA_KAPPA.traerListadoCuentaConFiltros 
    @Nombre nvarchar(255) = null, 
    @Apellido nvarchar(255) = null,
    @Tipo_Dni numeric(18,0) = null,
    @Dni numeric(18,0) = null
AS 
BEGIN
    SELECT cuenta_id, cliente_id, (cliente_nombre + ' ' + cliente_apellido) as cliente_nombre, cuenta_estado, cuenta_fecha_apertura, cuenta_fecha_cierre, cuenta_moneda_id, cuenta_pais_id, cuenta_saldo, cuenta_tipo_cuenta_id 
    FROM OOZMA_KAPPA.Cuenta, OOZMA_KAPPA.Cliente
    WHERE	cuenta_cliente_id = cliente_id
    AND     cliente_nombre LIKE (CASE WHEN @Nombre <> '' THEN '%' + @Nombre + '%' ELSE cliente_nombre END) 
    AND		cliente_apellido LIKE (CASE WHEN @Apellido <> '' THEN '%' + @Apellido + '%' ELSE cliente_apellido END) 
    AND		(@Tipo_Dni is null OR @Tipo_Dni = -1 OR CONVERT(VARCHAR(10), cliente_tipo_documento_id) LIKE '%' + CONVERT(VARCHAR(10), @Tipo_Dni) + '%')     
    AND		(@Dni is null OR @Dni = 0 OR CONVERT(VARCHAR(10), cliente_numero_documento) LIKE '%' + CONVERT(VARCHAR(10), @Dni) + '%')
    AND		cuenta_cerrada = 0;
END
GO

CREATE PROCEDURE OOZMA_KAPPA.TraerListadoTipoDocumento
AS
BEGIN
	SELECT tipo_documento_id as td_id, tipo_documento_descripcion as td_descripcion FROM OOZMA_KAPPA.Tipo_documento;
END
GO

CREATE PROCEDURE OOZMA_KAPPA.traerListadoPaisesCompleto
AS
BEGIN
	SELECT pais_id, pais_nombre FROM OOZMA_KAPPA.Pais
	ORDER BY pais_nombre ASC
END
GO

CREATE PROCEDURE OOZMA_KAPPA.traerListadoTipoCuentaCompleto
AS
BEGIN
	SELECT tipo_cuenta_id, tipo_cuenta_nombre FROM OOZMA_KAPPA.Tipo_cuenta;
END
GO

CREATE PROCEDURE OOZMA_KAPPA.UpdateCuenta
	@Cuenta_id numeric(18,0),
	@Cliente_id numeric(18,0),   
	@Pais numeric(18,0),
	@Moneda numeric(18,0),
	@Tipo_Cuenta numeric(18,0),
	@Fecha datetime
AS
BEGIN
	
	SELECT DATEADD(DAY,tipo_cuenta_dias_vigencia,@Fecha)
	FROM OOZMA_KAPPA.Tipo_cuenta WHERE tipo_cuenta_id = @Tipo_Cuenta;

	UPDATE [OOZMA_KAPPA].Cuenta SET cuenta_pais_id = @Pais,
									cuenta_moneda_id = @Moneda,
									cuenta_tipo_cuenta_id = @Tipo_Cuenta,
									cuenta_fecha_cierre = @Fecha
	WHERE cuenta_id = @Cuenta_id;
END
GO

CREATE PROCEDURE OOZMA_KAPPA.InsertCuenta
	@Cliente_id numeric(18,0),
	@Pais numeric(18,0),
	@Moneda numeric(18,0),
	@Tipo_Cuenta numeric(18,0),
	@Fecha datetime
AS
BEGIN
	INSERT INTO OOZMA_KAPPA.Cuenta (cuenta_cliente_id, cuenta_pais_id, cuenta_moneda_id, cuenta_tipo_cuenta_id,cuenta_fecha_apertura, cuenta_fecha_cierre)(
	SELECT @Cliente_id, @Pais, @Moneda, @Tipo_Cuenta,@Fecha, DATEADD(DAY,tipo_cuenta_dias_vigencia,@Fecha)
	FROM OOZMA_KAPPA.Tipo_cuenta WHERE tipo_cuenta_id = @Tipo_Cuenta);
END
GO


CREATE PROCEDURE OOZMA_KAPPA.TraerProximaCuentaID
AS
BEGIN
	SELECT TOP 1 cuenta_id + 1 as proxID FROM OOZMA_KAPPA.Cuenta ORDER BY cuenta_id DESC;
END
GO

CREATE PROCEDURE OOZMA_KAPPA.TraerListadoCuentaCantidadTransaccionesAPagar
	@cuenta_id numeric(18,0)
AS
	SELECT ISNULL(COUNT(transaccion_pendiente_cuenta_id),0) as cantidad FROM OOZMA_KAPPA.Transacciones_Pendientes WHERE transaccion_pendiente_cuenta_id = @cuenta_id GROUP BY transaccion_pendiente_cuenta_id 
GO

CREATE PROCEDURE OOZMA_KAPPA.DeleteCuenta
	@cuenta_id numeric(18,0)
AS
BEGIN
	UPDATE OOZMA_KAPPA.Cuenta SET cuenta_cerrada = 1 WHERE cuenta_id = @cuenta_id;
END
GO

CREATE PROCEDURE OOZMA_KAPPA.TraerListadoClienteConCosasAFacturar
AS
BEGIN
	SELECT DISTINCT cliente_id as cliente_id,(cliente_apellido +' '+ cliente_nombre) as cliente_nombre, cliente_numero_documento as cliente_documento FROM Transacciones_Pendientes, Cliente WHERE transaccion_pendiente_cliente_id = cliente_id;
END
GO

CREATE PROCEDURE OOZMA_KAPPA.TraerListadoClienteConCosasAFacturarPorUsuarioID
	@usuario_id numeric(18,0)
AS
BEGIN
	SELECT cliente_id as cliente_id,(cliente_apellido +' '+ cliente_nombre) as cliente_nombre, cliente_numero_documento as cliente_documento FROM OOZMA_KAPPA.Transacciones_Pendientes, OOZMA_KAPPA.Cliente WHERE cliente_id = transaccion_pendiente_cliente_id AND cliente_usuario_id = @usuario_id AND cliente_eliminado = 0;
END
GO

CREATE PROCEDURE OOZMA_KAPPA.TraerListadoEmisorTarjeta
AS
BEGIN
	SELECT emisor_id, emisor_descripcion FROM OOZMA_KAPPA.Emisor;
END
GO

CREATE PROCEDURE OOZMA_KAPPA.InsertLogin
	@usuario_id numeric(18,0),
	@Estado varchar(50),
	@Intentos int,
	@Fecha datetime
AS
BEGIN
	INSERT INTO OOZMA_KAPPA.Login(login_usuario_id,login_estado, login_cant_intentos, login_fecha_hora)
	VALUES(@usuario_id,@Estado, @Intentos, @Fecha);
END
GO
                        

	
----------------------------------------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------TRIGGERS---------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------------------------------------

--update SALDO AFTER DEPOSITO: luego de hacer un deposito sumar importe a cuenta

CREATE TRIGGER OOZMA_KAPPA.updateSaldoAfterDeposito ON [OOZMA_KAPPA].[Deposito]
AFTER INSERT
AS BEGIN TRANSACTION

	DECLARE @Importe numeric(15, 2);
	DECLARE @Cuenta numeric(16, 0);

	-- Necesito la última fila insertada.
	SELECT TOP 1 @Importe = deposito_importe, @Cuenta = deposito_cuenta_id 
	FROM inserted 
	ORDER BY deposito_id DESC;

	UPDATE [OOZMA_KAPPA].Cuenta
	SET cuenta_saldo = cuenta_saldo + @Importe
	WHERE cuenta_id = @Cuenta;
COMMIT;

GO

-- update SALDO AFTER RETIRO: luego de hacer un retiro restar saldo

CREATE TRIGGER OOZMA_KAPPA.updateSaldoAfterRetiro ON OOZMA_KAPPA.Cheque
AFTER INSERT
AS BEGIN TRANSACTION

	DECLARE @Importe numeric(15, 2);
	DECLARE @Cuenta numeric(16, 0);

	SELECT TOP 1 @Importe = cheque_importe, @Cuenta = cheque_cuenta_id
	FROM inserted 
	ORDER BY cheque_id DESC;

	UPDATE OOZMA_KAPPA.Cuenta
	SET cuenta_saldo = cuenta_saldo - @Importe
	WHERE cuenta_id = @Cuenta;
	COMMIT;
GO

-- update SALDO AFTER TRANSFERENCIA: actualizar saldo after transferencia

CREATE TRIGGER OOZMA_KAPPA.updateSaldoAfterTransferencia ON OOZMA_KAPPA.Transferencia
AFTER INSERT
AS BEGIN TRANSACTION

	DECLARE @Importe numeric(15, 2);
	DECLARE @Cuenta numeric(16, 0);
	DECLARE @CuentaOrigen numeric(16, 0);
	DECLARE @costo int;

	SELECT TOP 1 @Importe = transferencia_importe, @Cuenta = transferencia_destino_cuenta_id, @CuentaOrigen = transferencia_origen_cuenta_id
	FROM inserted 
	ORDER BY transferencia_id DESC;

	SELECT @costo = tipo_cuenta_costo_transferencia
	FROM OOZMA_KAPPA.Cuenta, OOZMA_KAPPA.Tipo_Cuenta
	WHERE tipo_cuenta_id =  cuenta_tipo_cuenta_id AND cuenta_id = @Cuenta; 

	UPDATE OOZMA_KAPPA.Cuenta
	SET cuenta_saldo = cuenta_saldo + @Importe
	WHERE cuenta_id = @Cuenta;

	UPDATE OOZMA_KAPPA.Cuenta
	SET cuenta_saldo = cuenta_saldo - @Importe - @costo
	WHERE cuenta_id = @CuentaOrigen;
	COMMIT;
GO


-- update TRANSACCIONES AFTER MODIFICACION TIPO CUENTA: agregar modificacion cuenta a transacciones pendientes

CREATE TRIGGER OOZMA_KAPPA.updateTransaccionesAfterModificacionCuenta ON OOZMA_KAPPA.Cuenta
AFTER UPDATE 
AS BEGIN TRANSACTION

	IF(UPDATE(cuenta_tipo_cuenta_id))
	BEGIN
		DECLARE @Cliente numeric(18,0);
		DECLARE @Cuenta numeric(18,0);
		DECLARE @Fecha DateTime;
		DECLARE @Costo int = 0;
		DECLARE @DiasVigencia int;
		DECLARE @Contador int = 0;
		DECLARE @CostoPorSuscripcion numeric(18,2)
		
		SELECT TOP 1 @Cuenta = cuenta_id, @Cliente = cuenta_cliente_id, @Fecha = cuenta_fecha_apertura
		FROM inserted 
		ORDER BY cuenta_fecha_apertura DESC;
		
		SELECT @Costo = tipo_cuenta_costo_apertura
		FROM OOZMA_KAPPA.Cuenta, OOZMA_KAPPA.Tipo_Cuenta
		WHERE tipo_cuenta_id =  cuenta_tipo_cuenta_id AND cuenta_id = @Cuenta;
		
		--ANADIR SUSCRIPCIONES A TRANSACCIONES PENDIENTES
		SELECT @Costo = tipo_cuenta_costo_apertura, @CostoPorSuscripcion = tipo_cuenta_costo_modificacion / tipo_cuenta_dias_vigencia, @DiasVigencia = tipo_cuenta_dias_vigencia
		FROM OOZMA_KAPPA.Cuenta, OOZMA_KAPPA.Tipo_Cuenta
		WHERE tipo_cuenta_id =  cuenta_tipo_cuenta_id AND cuenta_id = @Cuenta;  
		
		WHILE @Contador <= @DiasVigencia
		BEGIN 
			INSERT INTO OOZMA_KAPPA.Transacciones_Pendientes (transaccion_pendiente_importe, transaccion_pendiente_descr, transaccion_pendiente_cliente_id, transaccion_pendiente_fecha, transaccion_pendiente_cuenta_id)
			VALUES(@CostoPorSuscripcion, 'Suscripciones por Apertura Cuenta', @Cliente, @Fecha, @Cuenta)
			SET @Contador = @Contador + 1;
		END
		
		INSERT INTO OOZMA_KAPPA.Transacciones_Pendientes (transaccion_pendiente_importe, transaccion_pendiente_descr, transaccion_pendiente_cliente_id, transaccion_pendiente_fecha, transaccion_pendiente_cuenta_id)
		VALUES (@Costo, 'Modificaciones Tipo Cuenta', @Cliente, @Fecha, @Cuenta);
	END

COMMIT;

GO
-- update TRANSACCIONES AFTER APERTURA CUENTA: agregar creacion cuenta a transacciones pendientes

CREATE TRIGGER OOZMA_KAPPA.updateTransaccionesAfterAperturaCuenta ON OOZMA_KAPPA.Cuenta
AFTER INSERT
AS BEGIN TRANSACTION

	DECLARE @Cliente numeric(18,0);
	DECLARE @Cuenta numeric(18,0);
	DECLARE @Fecha DateTime;
	DECLARE @Costo int = 0;
	DECLARE @CostoPorSuscripcion int;
	DECLARE @DiasVigencia int;
	DECLARE @Contador int = 0;

	SELECT TOP 1 @Cuenta = cuenta_id, @Cliente = cuenta_cliente_id, @Fecha = cuenta_fecha_apertura
	FROM inserted 
	ORDER BY cuenta_fecha_apertura DESC;

	SELECT @Costo = tipo_cuenta_costo_apertura, @CostoPorSuscripcion = tipo_cuenta_costo_apertura / tipo_cuenta_dias_vigencia, @DiasVigencia = tipo_cuenta_dias_vigencia
	FROM OOZMA_KAPPA.Cuenta, OOZMA_KAPPA.Tipo_Cuenta
	WHERE tipo_cuenta_id =  cuenta_tipo_cuenta_id AND cuenta_id = @Cuenta; 

	WHILE @Contador <= @DiasVigencia
		BEGIN 
			INSERT INTO OOZMA_KAPPA.Transacciones_Pendientes (transaccion_pendiente_importe, transaccion_pendiente_descr, transaccion_pendiente_cliente_id, transaccion_pendiente_fecha, transaccion_pendiente_cuenta_id)
			VALUES(@CostoPorSuscripcion, 'Suscripciones por Apertura Cuenta', @Cliente, @Fecha, @Cuenta)
			SET @Contador = @Contador + 1;
		END
		
	INSERT INTO OOZMA_KAPPA.Transacciones_Pendientes (transaccion_pendiente_importe, transaccion_pendiente_descr, transaccion_pendiente_cliente_id, transaccion_pendiente_fecha, transaccion_pendiente_cuenta_id)
		VALUES (@Costo, 'Modificaciones Tipo Cuenta', @Cliente, @Fecha, @Cuenta);

COMMIT;
GO


-- update TRANSACCIONES AFTER TRANSFERENCIA: agregar deposito a transacciones pendientes

ALTER TRIGGER OOZMA_KAPPA.updateTransaccionesAfterTransferencia ON OOZMA_KAPPA.Transferencia
AFTER INSERT
AS BEGIN TRANSACTION

	DECLARE @Cliente numeric(18,0);
	DECLARE @Cuenta numeric(18,0);
	DECLARE @Fecha DateTime;
	DECLARE @Costo int;
	DECLARE @Transferencia numeric(18,0);
	
	SELECT TOP 1 @Cuenta = transferencia_origen_cuenta_id, @Fecha = transferencia_fecha, @Costo = transferencia_costo,@Transferencia = transferencia_id
	FROM inserted 
	ORDER BY transferencia_id DESC;

	SELECT @Cliente = cuenta_cliente_id
	FROM OOZMA_KAPPA.Cuenta 
	WHERE cuenta_id = @Cuenta;
		
	INSERT INTO OOZMA_KAPPA.Transacciones_Pendientes (transaccion_pendiente_importe, transaccion_pendiente_descr, transaccion_pendiente_cliente_id, transaccion_pendiente_fecha, transaccion_pendiente_cuenta_id, transaccion_pendiente_transferencia_id)
	VALUES (@Costo, 'Comisión por transferencia', @Cliente, @Fecha, @Cuenta, @Transferencia);

COMMIT;
GO


-- VALIDAR INHABILITADA AFTER TRANSACCION: contar cantidad de transacciones de la cuenta y blouqear si = 5.

CREATE TRIGGER OOZMA_KAPPA.validarCuentaInhabilitadaAfterTransaccion ON OOZMA_KAPPA.Transacciones_Pendientes
AFTER INSERT
AS
BEGIN TRANSACTION
	DECLARE @cliente numeric(18,0)
	DECLARE @cuenta numeric(18,0)
	DECLARE @contador tinyint

	SET @cliente = (SELECT transaccion_pendiente_cliente_id FROM INSERTED)
	SET @cuenta = (SELECT transaccion_pendiente_cuenta_id FROM INSERTED)
	SET @contador = (SELECT COUNT(*) FROM OOZMA_KAPPA.Transacciones_Pendientes WHERE transaccion_pendiente_cliente_id = @cliente
	AND transaccion_pendiente_cuenta_id = @cuenta)

	IF (@contador = 5)
	BEGIN
	UPDATE OOZMA_KAPPA.Cuenta SET cuenta_estado = 0 WHERE cuenta_id = @cuenta
	END
	
	IF(@contador = 5)
	BEGIN
	INSERT INTO OOZMA_KAPPA.Historial_cuentas(historial_transacciones_superadas,historial_pendientes_de_activacion,historial_falta_de_pago ,historial_cliente_id,historial_cuenta_id,historial_fecha)
	VALUES(1,0,0,@cliente,@cuenta,GETDATE ())	
	END 
	
COMMIT
GO
	
--delete TRANSACCION AFTER INSERT FACTURA: al facturar, busco las transacciones pendientes para ese cliente, 
-- se le facuraran todas las transferencias y modificaciones cuenta que tenga y solo x suscripciones de cuenta.

CREATE TRIGGER OOZMA_KAPPA.deleteTransaccionAfeterInsertFactura ON [OOZMA_KAPPA].[Factura]
AFTER INSERT
AS BEGIN TRANSACTION

	DECLARE @Cliente_id numeric(18,0)

	SELECT TOP 1 factura_cliente_id FROM inserted ORDER BY factura_cliente_id DESC;	

	DELETE FROM OOZMA_KAPPA.Transacciones_Pendientes WHERE transaccion_pendiente_cliente_id = @Cliente_id AND transaccion_pendiente_descr = 'Comisión por transferencia' OR transaccion_pendiente_descr = 'Modificaciones Tipo Cuenta';

COMMIT;

GO

-- UPDATE ESTADO CUENTA AFTER FACTURACION --
-- Luego de facturar a un cliente, se habrán pagado los costos por apertura/modificacion cuenta, por lo que tengo que activar aquellas cuentas que hayan sido abonadas.
-- me fijo cuando se sacan las transacciones de la tabla transacciones_pendientes. ahi tengo los datos cuenta y cliente

CREATE TRIGGER OOZMA_KAPPA.updateEstadoCuentaAfterFacturacion ON [OOZMA_KAPPA].[Transacciones_Pendientes]
AFTER DELETE
AS 
BEGIN TRANSACTION
	
	DECLARE @Cliente numeric(18,0)
	DECLARE @Cuenta numeric(18,0)
	DECLARE @Descripcion varchar(255)
	DECLARE transaccionesCursor CURSOR FOR (SELECT transaccion_pendiente_cliente_id, transaccion_pendiente_cuenta_id, transaccion_pendiente_descr FROM DELETED)
	
	OPEN transaccionesCursor;
	
	FETCH NEXT FROM transaccionesCursor INTO @Cliente, @Cuenta, @Descripcion;
	
	WHILE @@FETCH_STATUS = 0
	BEGIN
		IF(@Descripcion LIKE 'Modificaciones Tipo Cuenta')
		BEGIN
			UPDATE OOZMA_KAPPA.Cuenta 
			SET cuenta_pendiente_activacion = 0,
			cuenta_estado = 1
			WHERE cuenta_id = @Cuenta;
		END
	FETCH NEXT FROM transaccionesCursor INTO @Cliente, @Cuenta, @Descripcion;
	END
	
	CLOSE transaccionesCursor;
	DEALLOCATE transaccionesCursor;

COMMIT
GO

-- TRIGGER DESHABILITAR/HABILITAR CLIENTE POR CAMBIO ESTADO ROL --

CREATE TRIGGER deshabilitar_clientes_porRol
ON [OOZMA_KAPPA].[Rol]
AFTER UPDATE
AS
BEGIN TRANSACTION
  DECLARE @estado bit, @nombre_rol varchar(255)
  SELECT @estado = rol_eliminado, @nombre_rol = rol_nombre From inserted
  
  IF (@nombre_rol = 'Cliente')
    UPDATE OOZMA_KAPPA.Cliente SET cliente_estado = @estado;
  IF (@nombre_rol = 'Administrador')
    UPDATE OOZMA_KAPPA.Administrador SET administrador_estado = @estado;
COMMIT
GO

----TRIGGER UPDATEHISTORIAL_CUENTAS para que cuando se crea una cuenta nueva, se actualice el historial por estar pendiente de activacion---


CREATE TRIGGER OOZMA_KAPPA.updateHistorial ON OOZMA_KAPPA.Cuenta
AFTER INSERT
AS BEGIN TRANSACTION

	INSERT INTO OOZMA_KAPPA.Historial_cuentas(historial_pendientes_de_activacion,historial_transacciones_superadas,historial_falta_de_pago,historial_cliente_id,historial_cuenta_id,historial_fecha)
	(SELECT 1,0,0,cuenta_cliente_id,cuenta_id,cuenta_fecha_apertura FROM INSERTED);
	COMMIT;
GO
 
-- TRIGGER INSERT ITEM AFTER DELETE TRANSACCION --

CREATE TRIGGER insertItemAfterDeleteTransaccion
ON [OOZMA_KAPPA].[Transacciones_Pendientes]
AFTER DELETE
AS
BEGIN TRANSACTION

	DECLARE @Cliente numeric(18,0)
	DECLARE @Cuenta numeric(18,0)
	DECLARE @Descripcion varchar(255)
	DECLARE @Transferencia numeric(18,0)
	DECLARE @Factura numeric(18,0)
	DECLARE @Costo numeric(18,2)
	
	DECLARE transaccionesCursor CURSOR FOR (SELECT transaccion_pendiente_cliente_id, transaccion_pendiente_cuenta_id, transaccion_pendiente_descr,transaccion_pendiente_transferencia_id, transaccion_pendiente_importe FROM DELETED
											WHERE transaccion_pendiente_descr != 'Suscripciones por Apertura Cuenta');
	
	OPEN transaccionesCursor;
	
	FETCH NEXT FROM transaccionesCursor INTO @Cliente, @Cuenta, @Descripcion, @Transferencia, @Costo;
	
	WHILE @@FETCH_STATUS = 0
		BEGIN
			SET @Factura = (SELECT TOP 1 factura_numero FROM OOZMA_KAPPA.Factura WHERE factura_cliente_id = @Cliente ORDER BY factura_cliente_id DESC);
			
			INSERT INTO [OOZMA_KAPPA].[Item_Factura] (item_factura_numero_factura, item_factura_desc, item_factura_costo, item_factura_cantidad, item_factura_transferencia_id, item_factura_numero_cuenta)
			VALUES (@Factura,@Descripcion,@Costo, 1,@Transferencia,@Cuenta);
			
		    FETCH NEXT FROM transaccionesCursor INTO @Cliente, @Cuenta, @Descripcion, @Transferencia, @Costo;
		END
		CLOSE transaccionesCursor;
	    DEALLOCATE transaccionesCursor;
	    COMMIT;
GO


----Despues de que el procedimiento insertHistorial registro que habia transacciones impagas hacia mas de 45 dìas,
----actualizo el historial de cuentas para cuentas cerradas por falta de pago. Aca, se deshabilita la cuenta
---propiamente dicha

CREATE TRIGGER OOZMA_KAPPA.updateCuenta_estado ON [OOZMA_KAPPA].[Historial_cuentas]
AFTER INSERT
AS BEGIN TRANSACTION
	UPDATE OOZMA_KAPPA.Cuenta
	SET cuenta_estado = 0 
	WHERE cuenta_id = (SELECT historial_cuenta_id FROM INSERTED)
	COMMIT;
GO
