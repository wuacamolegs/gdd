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

select * from OOZMA_KAPPA.Transacciones_Pendientes

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