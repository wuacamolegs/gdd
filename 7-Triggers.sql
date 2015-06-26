----- Triggers -----

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
	
	SELECT tipo_cuenta_costo_transferencia
	FROM OOZMA_KAPPA.Cuenta, OOZMA_KAPPA.Tipo_Cuenta
	WHERE tipo_cuenta_id =  cuenta_tipo_cuenta_id; 
	
	UPDATE OOZMA_KAPPA.Cuenta
	SET saldo = saldo + @Importe
	WHERE cuenta_id = @Cuenta;
	
	update OOZMA_KAPPA.Cuenta
	SET saldo = saldo - @Importe - @costo
	WHERE cuenta_id = @CuentaOrigen;
	COMMIT;
	GO


-- VALIDAR INHABILITADA AFTER TRANSACCION: contar cantidad de transacciones de la cuenta y blouqear si = 5.

	CREATE TRIGGER OOZMA_KAPPA.validarCuentaInhabilitadaAfterTransaccion ON OOZMA_KAPPA.Transaccion_Pendiente
	AFTER INSERT
	AS
	DECLARE @cliente numeric(18,0)
	DECLARE @cuenta numeric(18,0)
	DECLARE @contador tinyint
	
	SET @cliente = (SELECT Transaccion_Pendiente_Cliente FROM INSERTED)
	SET @cuenta = (SELECT Transaccion_Pendiente_Cuenta_Nro FROM INSERTED)
	SET @contador = (SELECT COUNT(*) CONTADOR FROM DEVGURUS.Transaccion_Pendiente WHERE Transaccion_Pendiente_Cliente = @cliente
	AND Transaccion_Pendiente_Cuenta_Nro = @cuenta)
	
	IF (@contador = 5)
	BEGIN
	update Cuenta_Estado SET Cuenta_Estado = 'Inhabilitado' WHERE Cuenta_Nro = @cuenta
	END
	GO	

