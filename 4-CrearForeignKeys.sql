----- Crear Foreign Keys -----

BEGIN TRANSACTION

ALTER TABLE [OOZMA_KAPPA].[Retiro]
ADD FOREIGN KEY ([retiro_cuenta_id])
REFERENCES [OOZMA_KAPPA].[Cuenta](cuenta_id);

ALTER TABLE [OOZMA_KAPPA].[Retiro]
ADD FOREIGN KEY ([retiro_cheque_id])
REFERENCES [OOZMA_KAPPA].[Cheque](cheque_id);

ALTER TABLE [OOZMA_KAPPA].[Cheque]
ADD FOREIGN KEY ([cheque_banco_id])
REFERENCES [OOZMA_KAPPA].[Banco](banco_id);

ALTER TABLE [OOZMA_KAPPA].[Login]
ADD FOREIGN KEY ([login_user_id])
REFERENCES [OOZMA_KAPPA].[User](user_id);

ALTER TABLE [OOZMA_KAPPA].[Transferencia]
ADD FOREIGN KEY ([transferencia_origen_cuenta_id])
REFERENCES [OOZMA_KAPPA].[Cuenta](cuenta_id);

ALTER TABLE [OOZMA_KAPPA].[Transferencia]
ADD FOREIGN KEY ([transferencia_destino_cuenta_id])
REFERENCES [OOZMA_KAPPA].[Cuenta](cuenta_id);

ALTER TABLE [OOZMA_KAPPA].[Cuenta]
ADD FOREIGN KEY ([cuenta_cliente_id])
REFERENCES [OOZMA_KAPPA].[Cliente](cliente_id);

ALTER TABLE [OOZMA_KAPPA].[Cuenta]
ADD FOREIGN KEY ([cuenta_pais_id])
REFERENCES [OOZMA_KAPPA].[Pais](pais_id);

ALTER TABLE [OOZMA_KAPPA].[Cuenta]
ADD FOREIGN KEY ([cuenta_moneda_id])
REFERENCES [OOZMA_KAPPA].[Moneda](moneda_id);

ALTER TABLE [OOZMA_KAPPA].[Cuenta]
ADD FOREIGN KEY ([cuenta_tipo_cuenta_id])
REFERENCES [OOZMA_KAPPA].[Tipo_cuenta](tipo_cuenta_id);

ALTER TABLE [OOZMA_KAPPA].[Administrador]
ADD FOREIGN KEY ([administrador_user_id])
REFERENCES [OOZMA_KAPPA].[User](user_id);

ALTER TABLE [OOZMA_KAPPA].[Deposito]
ADD FOREIGN KEY ([deposito_moneda_id])
REFERENCES [OOZMA_KAPPA].[Moneda](Moneda_id);

ALTER TABLE [OOZMA_KAPPA].[Deposito]
ADD FOREIGN KEY ([deposito_cuenta_id])
REFERENCES [OOZMA_KAPPA].[Cuenta](cuenta_id);

ALTER TABLE [OOZMA_KAPPA].[Deposito]
ADD FOREIGN KEY ([deposito_cliente_id])
REFERENCES [OOZMA_KAPPA].[Cliente](cliente_id);

ALTER TABLE [OOZMA_KAPPA].[Deposito]
ADD FOREIGN KEY ([deposito_tarjeta_id])
REFERENCES [OOZMA_KAPPA].[Tarjeta](tarjeta_id);

ALTER TABLE [OOZMA_KAPPA].[Cliente]
ADD FOREIGN KEY ([cliente_user_id])
REFERENCES [OOZMA_KAPPA].[User](user_id);

ALTER TABLE [OOZMA_KAPPA].[Cliente]
ADD FOREIGN KEY ([cliente_tipo_documento_id])
REFERENCES [OOZMA_KAPPA].[Tipo_documento](tipo_documento_id);

ALTER TABLE [OOZMA_KAPPA].[Cliente]
ADD FOREIGN KEY ([cliente_pais_residente_id])
REFERENCES [OOZMA_KAPPA].[Pais](pais_id);

ALTER TABLE [OOZMA_KAPPA].[Cliente]
ADD FOREIGN KEY ([cliente_cuenta_id])
REFERENCES [OOZMA_KAPPA].[Cuenta](cuenta_id);

ALTER TABLE [OOZMA_KAPPA].[Factura]
ADD FOREIGN KEY ([factura_cliente_id])
REFERENCES [OOZMA_KAPPA].[Cliente](cliente_id);

ALTER TABLE [OOZMA_KAPPA].[Tarjeta]
ADD FOREIGN KEY ([tarjeta_emisor_banco_id])
REFERENCES [OOZMA_KAPPA].[Banco](banco_id);


COMMIT