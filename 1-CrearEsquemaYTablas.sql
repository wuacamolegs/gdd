----- Script creaci�n esquema y tablas -----
CREATE SCHEMA [OOZMA_KAPPA] AUTHORIZATION [gd];
GO
BEGIN TRANSACTION

USE [GD1C2015]

--- TABLA USER ---

CREATE TABLE [OOZMA_KAPPA].[User](
	[user_id] int IDENTITY (1,1),
	[user_username] [varchar](50) NOT NULL,
	[user_rol] [int] NOT NULL,
	[user_fecha_creacion] [datetime] NOT NULL,
	[user_fecha_ultima_modificacion] [datetime] NOT NULL,
	[user_pregunta_secreta] [varchar](50) NOT NULL,
	[user_respuesta_secreta] [varchar](50) NOT NULL,
)

--- TABLA TRANSFERENCIA ---

CREATE TABLE [OOZMA_KAPPA].[Transferencia](
	[transferencia_id] int IDENTITY (1,1),
	[transferencia_origen_cuenta_id] [int] NOT NULL,
	[transferencia_destino_cuenta_id] [int] NOT NULL,
	[transferencia_importe] [int] NOT NULL,
	[transferencia_costo] [int] NOT NULL,
)

--- TABLA TIPO_DOCUMENTO ---

CREATE TABLE [OOZMA_KAPPA].[Tipo_documento](
	[tipo_documento_id] int IDENTITY (1,1),
	[tipo_documento_descripcion] [varchar](50) NOT NULL,
)

INSERT INTO [OOZMA_KAPPA].[Tipo_documento] (tipo_documento_descripcion) VALUES ('DNI');
INSERT INTO [OOZMA_KAPPA].[Tipo_documento] (tipo_documento_descripcion) VALUES ('CI');
INSERT INTO [OOZMA_KAPPA].[Tipo_documento] (tipo_documento_descripcion) VALUES ('LC');
INSERT INTO[OOZMA_KAPPA].[Tipo_documento] (tipo_documento_descripcion) VALUES ('LE');

--- TABLA TIPO_CUENTA ---

CREATE TABLE [OOZMA_KAPPA].[Tipo_cuenta](
	[tipo_cuenta_id] int IDENTITY (1,1),
	[tipo_cuenta_nombre] [varchar](50) NOT NULL,
	[tipo_cuenta_costo] [int] NOT NULL,
)

--- TABLA TARJETA  ---

CREATE TABLE [OOZMA_KAPPA].[Tarjeta](
	[tarjeta_id] int IDENTITY (1,1),
	[tarjeta_codigo_seguridad] [int] NOT NULL,
	[tarjeta_fecha_emision] [datetime] NOT NULL,
	[tarjeta_vencimiento] [datetime] NOT NULL,
	[tarjeta_emisor_banco_id] [int] NOT NULL,
)

--- TABLA RETIRO ---

CREATE TABLE [OOZMA_KAPPA].[Retiro](
	[retiro_id] int IDENTITY (1,1),
	[retiro_cuenta_id] [int] NOT NULL,
	[retiro_importe] [int] NOT NULL,
	[retiro_cheque_id] [int] NOT NULL,
	[retiro_fecha] [datetime] NOT NULL,
	[retiro_costo] [int] NOT NULL,
)

--- TABLA PAIS ---

CREATE TABLE [OOZMA_KAPPA].[Pais](
	[pais_id] int IDENTITY (1,1),
	[pais_nombre] [varchar](50) NOT NULL,
)

--- TABLA MONEDA ---

CREATE TABLE [OOZMA_KAPPA].[Moneda](
	[moneda_id] int IDENTITY (1,1),
	[moneda_nombre] [varchar](50) NOT NULL,
)

--- TABLA LOGIN ---

CREATE TABLE [OOZMA_KAPPA].[Login](
	[login_id] int IDENTITY (1,1),
	[login_user_id] [int] NOT NULL,
	[login_estado] [int] NOT NULL,
	[login_cant_intentos] [int] NOT NULL,
	[login_fecha_hora] [datetime] NOT NULL,
)

--- TABLA ITEM_FACTURA ---

CREATE TABLE [OOZMA_KAPPA].[Item_factura](
	[item_factura_id] int IDENTITY (1,1),
	[item_factura_desc] [varchar](50) NOT NULL,
	[item_factura_costo] numeric(18, 2) NOT NULL,
	[item_factura_cant] [int] NOT NULL,
	[item_factura_fecha] [datetime] NOT NULL,
)

--- TABLA FUNCIONALIDADES_CLIENTES ---

CREATE TABLE [OOZMA_KAPPA].[Funcionalidades_clientes](
	[funcionalidades_cliente_id] int IDENTITY (1,1),
	[funcionalidades_cliente_nombre] [varchar](50) NOT NULL,
	[funcionalidades_cliente_descripcion] [varchar](50) NOT NULL,
)

--- TABLA FUNCIONALIDADES_ADMINISTRADOR ---

CREATE TABLE [OOZMA_KAPPA].[Funcionalidades_administrador](
	[funciononalidades_admin_id] int IDENTITY (1,1),
	[funcionalidades_admin_nombre] [varchar](50) NOT NULL,
	[funcionalidades_admin_detalle] [varchar](50) NOT NULL,
)

--- TABLA FACTURA ---

CREATE TABLE [OOZMA_KAPPA].[Factura](
	[factura_numero] int IDENTITY (1,1),
	[factura_importe] [int] NOT NULL,
	[factura_fecha] [datetime] NOT NULL,
	[factura_cliente_id] [int] NOT NULL,
	[factura_items_id] [int] NOT NULL,
)

--- TABLA DEPOSITO ---

CREATE TABLE [OOZMA_KAPPA].[Deposito](
	[deposito_id] int IDENTITY (1,1),
	[deposito_cuenta_id] [int] NOT NULL,
	[deposito_cliente_id] [int] NOT NULL,
	[deposito_importe] [int] NOT NULL,
	[deposito_moneda_id] [int] NOT NULL,
	[deposito_tarjeta_id] [int] NOT NULL,
	[deposito_fecha] [datetime] NOT NULL,
	[deposito_costo] [int] NOT NULL,
)

--- TABLA CUENTA ---

CREATE TABLE [OOZMA_KAPPA].[Cuenta](
	[cuenta_id] int IDENTITY (1,1),
	[cuenta_cliente_id] [int] NOT NULL,
	[cuenta_pais_id] [int] NOT NULL,
	[cuenta_moneda_id] [int] NOT NULL,
	[cuenta_tipo_cuenta_id] [int] NOT NULL,
	[cuenta_estado] [int] NOT NULL,
	[cuenta_saldo] [int] NOT NULL,
	[cuenta_fecha_apertura] [datetime] NOT NULL,
	[cuenta_fecha_cierre] [datetime] NOT NULL,
)

--- TABLA CLIENTE ---

CREATE TABLE [OOZMA_KAPPA].[Cliente](
	[cliente_id] int IDENTITY (1,1),
	[cliente_user_id] [int] NOT NULL,
	[cliente_rol] [int] NOT NULL,
	[cliente_apellido] [varchar](50) NOT NULL,
	[cliente_nombre] [varchar](50) NOT NULL,
	[cliente_fecha_nacimiento] [datetime] NOT NULL,
	[cliente_tipo_documento_id] [int] NOT NULL,
	[cliente_numero_documento] [int] NOT NULL,
	[cliente_nacionalidad] [varchar](50) NOT NULL,
	[cliente_pais_residente_id] [int] NOT NULL,
	[cliente_localidad] [varchar](50) NOT NULL,
	[cliente_calle] [varchar](50) NOT NULL,
	[cliente_numero] [int] NOT NULL,
	[cliente_piso] [int] NOT NULL,
	[cliente_depto] [varchar](50) NOT NULL,
	[cliente_estado_civil] [varchar](50) NOT NULL,
	[cliente_cuenta_id] [int] NOT NULL,
)

--- TABLA CHEQUE ---

CREATE TABLE [OOZMA_KAPPA].[Cheque](
	[cheque_id] int IDENTITY (1,1),
	[cheque_cuenta_id] [int] NOT NULL,
	[cheque_fecha] [datetime] NOT NULL,
	[cheque_importe] [int] NOT NULL,
	[cheque_banco_id] [int] NOT NULL,
	[cheque_destino_cliente_id] [int] NOT NULL,
)

--- TABLA BANCO ---

CREATE TABLE [OOZMA_KAPPA].[Banco](
	[banco_id] int NOT NULL,
	[banco_nombre] [varchar](50) NOT NULL,
	[banco_direccion] [varchar](50) NOT NULL,
)

--- TABLA ADMINISTRADOR ---

CREATE TABLE [OOZMA_KAPPA].[Administrador](
	[administrador_id] int IDENTITY (1,1),
	[administrador_rol] [int] NOT NULL,
	[administrador_estado] [int] NOT NULL,
	[administrador_username] [varchar](50) NOT NULL,
	[administrador_user_id] [int] NOT NULL,
)

COMMIT