--- DROP FOREIGN KEY ---
USE GD1C2015

BEGIN TRANSACTION

ALTER TABLE [OOZMA_KAPPA].[Retiro]
DROP CONSTRAINT  retiro_cuenta_id 
GO

ALTER TABLE [OOZMA_KAPPA].[Retiro]
DROP CONSTRAINT  retiro_cheque_id 
GO

ALTER TABLE [OOZMA_KAPPA].[Login]
DROP CONSTRAINT  login_user_id 
GO

ALTER TABLE [OOZMA_KAPPA].[Transferencia]
DROP CONSTRAINT  transferencia_origen_cuenta_id 
GO

ALTER TABLE [OOZMA_KAPPA].[Transferencia]
DROP CONSTRAINT  transferencia_destino_cuenta_id 
GO

ALTER TABLE [OOZMA_KAPPA].[Cuenta]
DROP CONSTRAINT  cuenta_cliente_id 
GO

ALTER TABLE [OOZMA_KAPPA].[Cuenta]
DROP CONSTRAINT  cuenta_pais_id 
GO

ALTER TABLE [OOZMA_KAPPA].[Cuenta]
DROP CONSTRAINT  cuenta_moneda_id 
GO

ALTER TABLE [OOZMA_KAPPA].[Cuenta]
DROP CONSTRAINT  cuenta_tipo_cuenta_id 
GO

ALTER TABLE [OOZMA_KAPPA].[Administrador]
DROP CONSTRAINT  administrador_user_id 
GO

ALTER TABLE [OOZMA_KAPPA].[Deposito]
DROP CONSTRAINT  deposito_moneda_id 
GO

ALTER TABLE [OOZMA_KAPPA].[Deposito]
DROP CONSTRAINT  deposito_cuenta_id 
GO

ALTER TABLE [OOZMA_KAPPA].[Deposito]
DROP CONSTRAINT  deposito_cliente_id 
GO

ALTER TABLE [OOZMA_KAPPA].[Deposito]
DROP CONSTRAINT  deposito_tarjeta_id 
GO

ALTER TABLE [OOZMA_KAPPA].[Cliente]
DROP CONSTRAINT  cliente_user_id 
GO

ALTER TABLE [OOZMA_KAPPA].[Cliente]
DROP CONSTRAINT  cliente_tipo_documento 
GO

ALTER TABLE [OOZMA_KAPPA].[Cliente]
DROP CONSTRAINT  cliente_pais_residente_id 
GO

ALTER TABLE [OOZMA_KAPPA].[Cliente]
DROP CONSTRAINT  cliente_cuenta_id 
GO

ALTER TABLE [OOZMA_KAPPA].[Factura]
DROP CONSTRAINT  factura_cliente_id 
GO

ALTER TABLE [OOZMA_KAPPA].[Tarjeta]
DROP CONSTRAINT  tarjeta_emisor_banco_id 
GO

--- DROP TABLES ---

DROP TABLE [OOZMA_KAPPA].[Administrador]
GO
DROP TABLE [OOZMA_KAPPA].[Banco]
GO
DROP TABLE [OOZMA_KAPPA].[Cheque]
GO
DROP TABLE [OOZMA_KAPPA].[Cliente]
GO
DROP TABLE [OOZMA_KAPPA].[Cuenta]
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
DROP TABLE [OOZMA_KAPPA].[User]
GO
DROP TABLE [OOZMA_KAPPA].[Usuario_rol]

--- DROP SCHEMA ---

DROP SCHEMA [OOZMA_KAPPA] 
GO

COMMIT