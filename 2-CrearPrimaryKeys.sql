----- Crear Primary Keys -----

BEGIN TRANSACTION

ALTER TABLE [OOZMA_KAPPA].[User]
ADD PRIMARY KEY ([user_id]);

ALTER TABLE [OOZMA_KAPPA].[Transferencia]
ADD PRIMARY KEY ([transferencia_id]);

ALTER TABLE [OOZMA_KAPPA].[Tipo_documento]
ADD PRIMARY KEY ([tipo_documento_id]);

ALTER TABLE [OOZMA_KAPPA].[Tipo_cuenta]
ADD PRIMARY KEY ([tipo_cuenta_id]);

ALTER TABLE [OOZMA_KAPPA].[Tarjeta]
ADD PRIMARY KEY ([tarjeta_id]);

ALTER TABLE [OOZMA_KAPPA].[Retiro]
ADD PRIMARY KEY ([retiro_id]);

ALTER TABLE [OOZMA_KAPPA].[Pais]
ADD PRIMARY KEY ([pais_id]);

ALTER TABLE [OOZMA_KAPPA].[Moneda]
ADD PRIMARY KEY ([moneda_id]);

ALTER TABLE [OOZMA_KAPPA].[Login]
ADD PRIMARY KEY ([login_id]);		

ALTER TABLE [OOZMA_KAPPA].[Item_factura]
ADD PRIMARY KEY ([item_factura_id]);	

ALTER TABLE [OOZMA_KAPPA].[Funcionalidades_clientes]
ADD PRIMARY KEY ([funcionalidades_cliente_id]);	

ALTER TABLE [OOZMA_KAPPA].[Funcionalidades_administrador]
ADD PRIMARY KEY ([funciononalidades_admin_id]);	

ALTER TABLE [OOZMA_KAPPA].[Factura]
ADD PRIMARY KEY ([factura_numero]);	

ALTER TABLE [OOZMA_KAPPA].[Deposito]
ADD PRIMARY KEY ([deposito_id]);	

ALTER TABLE [OOZMA_KAPPA].[Cuenta]
ADD PRIMARY KEY ([cuenta_id]);	

ALTER TABLE [OOZMA_KAPPA].[Cliente]
ADD PRIMARY KEY ([cliente_id]);	

ALTER TABLE [OOZMA_KAPPA].[Cheque]
ADD PRIMARY KEY ([cheque_id]);	

ALTER TABLE [OOZMA_KAPPA].[Banco]
ADD PRIMARY KEY ([banco_id]);	

ALTER TABLE [OOZMA_KAPPA].[Administrador]
ADD PRIMARY KEY ([administrador_id]);	

COMMIT