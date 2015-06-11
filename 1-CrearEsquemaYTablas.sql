----- Script creación esquema y tablas -----

CREATE SCHEMA [OOZMA_KAPPA] AUTHORIZATION [gd];
GO
BEGIN TRANSACTION

USE [GD1C2015]


--- TABLA ADMINISTRADOR ---

CREATE TABLE [OOZMA_KAPPA].[Administrador](
	[administrador_id] numeric(18, 0) IDENTITY (1,1),
	[administrador_estado] numeric(18, 0)NOT NULL,   --SACO EL ATRIBUTO ESTADO. ESTE TIENE QUE IR EN USUARIO!!
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
	[cheque_destino_cliente_id] numeric(18, 0)NOT NULL,	--creo que el cliente nos va a falicitar la performance al momento de hacer un cheque. si no cada vez que se hace un cheque hay que recorrer la tabla de clientes tambien para buscar su id. de ultima dsp lo sacamos! 
)												--y si lo dejamos va a ser mas facil hacer los cheques! 

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
	[cliente_depto] [varchar](10) NOT NULL,  --saco cliente cuenta id porq un cliente puede tener varias cuentas. sus varias cuentas se reflejan en la tabla cuentas.
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
	[deposito_costo] numeric(18, 0)NOT NULL,
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
	[item_factura_factura_numero] numeric(18, 0),
	[item_factura_desc] [varchar](255) NOT NULL,
	[item_factura_costo] numeric(18, 2) NOT NULL,
	[item_factura_cant] numeric(18, 0)NOT NULL,
	[item_factura_fecha] [datetime] NOT NULL,
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
	[tarjeta_id] numeric(18,0) IDENTITY (1,1),  --en la tabla tarjeta numero es varchar(16)
	[tarjeta_codigo_seguridad] varchar(3) NOT NULL,
	[tarjeta_fecha_emision] [datetime] NOT NULL,
	[tarjeta_vencimiento] [datetime] NOT NULL,
)

--- TABLA TIPO_CUENTA ---

CREATE TABLE [OOZMA_KAPPA].[Tipo_cuenta](
	[tipo_cuenta_id] numeric(18, 0) IDENTITY (1,1),
	[tipo_cuenta_nombre] [varchar](255) NOT NULL,
	[tipo_cuenta_costo_transferencia] numeric(18, 0)NOT NULL,
	[tipo_cuenta_costo_apertura] numeric(18, 0)NOT NULL,   --VER QUE NO FALTE NINGUN COSTO
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
	--VER QUE PASA CUANDO ESTA DESHABILITADO POR LOGINS, Y UN ROL PASA DE ACTIVO A NO ACTIVO Y LUEGO A ACTIVO OTRA VEZ!! 
	--tendria que haber un estado para cada cosa? estadoRol, estadoLogin, o solo estadoLogin e ir verificando que el rol este activo o no cuando se quiera iniciar sesion
	-- CREO QUE VA A CONVENIR que este estado represente solo el login, y que cuando inicie sesion no se muestren los roles inhabilitados y listo.
	-- TAMBIEN HAY QUE VER QUE PASA CUANDO SE DESACTIVA UNA CUENTA DE UN CLIENTE. SI SE BLOQUEA EL CLINETE O NO.
)


-- TABLA USUARIO_ROL --

CREATE TABLE [OOZMA_KAPPA].[Usuario_rol](
	[usuario_rol_id] numeric(18, 0) IDENTITY (1,1),
	[usuario_id] numeric(18, 0)NOT NULL,
	[usuario_username] numeric(18,0)NOT NULL,
	[rol_id] numeric(18, 0)NOT NULL,
)

COMMIT



