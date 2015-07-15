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

-- update TRANSACCIONES AFTER DEPOSITO: agregar deposito a transacciones pendientes

CREATE TRIGGER OOZMA_KAPPA.updateTransaccionesAfterDeposito ON OOZMA_KAPPA.Deposito
AFTER INSERT
AS BEGIN TRANSACTION

	DECLARE @Cliente numeric(18,0);
	DECLARE @Cuenta numeric(18,0);
	DECLARE @Fecha DateTime;
	DECLARE @Costo int = 0;

	SELECT TOP 1 @Cuenta = deposito_cuenta_id, @Cliente = deposito_cliente_id, @Fecha = deposito_fecha
	FROM inserted 
	ORDER BY deposito_id DESC;
		
	INSERT INTO OOZMA_KAPPA.Transacciones_Pendientes (transaccion_pendiente_importe, transaccion_pendiente_descr, transaccion_pendiente_cliente_id, transaccion_pendiente_fecha, transaccion_pendiente_cuenta_id)
	VALUES (@Costo, 'Comisión por Deposito', @Cliente, @Fecha, @Cuenta);

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

CREATE TRIGGER OOZMA_KAPPA.updateTransaccionesAfterTransferencia ON OOZMA_KAPPA.Transferencia
AFTER INSERT
AS BEGIN TRANSACTION

	DECLARE @Cliente numeric(18,0);
	DECLARE @Cuenta numeric(18,0);
	DECLARE @Fecha DateTime;
	DECLARE @Costo int = 0;
	
	SELECT TOP 1 @Cuenta = transferencia_origen_cuenta_id, @Fecha = transferencia_fecha
	FROM inserted 
	ORDER BY transferencia_id DESC;

	SELECT @Cliente = cuenta_cliente_id
	FROM OOZMA_KAPPA.Cuenta 
	WHERE cuenta_id = @Cuenta;
		
	INSERT INTO OOZMA_KAPPA.Transacciones_Pendientes (transaccion_pendiente_importe, transaccion_pendiente_descr, transaccion_pendiente_cliente_id, transaccion_pendiente_fecha, transaccion_pendiente_cuenta_id)
	VALUES (@Costo, 'Comisión por transferencia', @Cliente, @Fecha, @Cuenta);

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

-- TRIGGER DESHABILITAR --

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
  
  