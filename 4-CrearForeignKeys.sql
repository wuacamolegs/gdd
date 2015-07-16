----- Crear Foreign Keys -----

BEGIN TRANSACTION

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

/*BEGIN TRASACTION
ALTER TABLE [OOZMA_KAPPA].[Item_Factura]
ADD FOREIGN KEY ([item_transaccion_id])
REFERENCES [OOZMA_KAPPA].[Transacciones_Pendientes](transaccion_pendiente_id);
COMMIT*/

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

ROLLBACK