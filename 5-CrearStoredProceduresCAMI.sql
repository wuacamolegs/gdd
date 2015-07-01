----- DROP STORED PROCEDURES ------

USE [GD1C2015]
GO
DROP PROCEDURE [OOZMA_KAPPA].traerUsuarioActivoPorUsername
GO
DROP PROCEDURE [OOZMA_KAPPA].traerListadoRolesPorId_Usuario
GO
DROP PROCEDURE [OOZMA_KAPPA].traerListadoFuncionalidadesPorId_Rol
GO
DROP PROCEDURE [OOZMA_KAPPA].[deshabilitarUsuario]
GO
DROP PROCEDURE [OOZMA_KAPPA].[updateUsuario]
GO
DROP PROCEDURE [OOZMA_KAPPA].[traerListadoRoles]
GO
DROP PROCEDURE [OOZMA_KAPPA].[traerListadoClienteCompleto]
GO
DROP PROCEDURE [OOZMA_KAPPA].[traerListadoClientePorUsuarioID]
GO
DROP PROCEDURE [OOZMA_KAPPA].[traerListadoClientePorClienteID]
GO
DROP PROCEDURE [OOZMA_KAPPA].[traerListadoCuentaActivasPorClienteID]
GO
DROP PROCEDURE [OOZMA_KAPPA].[traerListadoCuentaPorClienteID]
GO
DROP PROCEDURE [OOZMA_KAPPA].[traerListadoCuentaporCuentaID]
GO
DROP PROCEDURE [OOZMA_KAPPA].[traerListadoBancoCompleto]
GO
DROP PROCEDURE [OOZMA_KAPPA].[insertCheque_RetornarID]
GO
DROP PROCEDURE [OOZMA_KAPPA].[insertRetiro_RetornarID]
GO
DROP PROCEDURE [OOZMA_KAPPA].[TraerListadoClienteTransferenciasAFacturar]
GO
DROP PROCEDURE [OOZMA_KAPPA].[TraerListadoClienteSuscripcionesPendientesAFacturarPorClienteIDYCuentaID]
GO
DROP PROCEDURE [OOZMA_KAPPA].[TraerListadoClienteModificacionesTCAFacturar]
GO
DROP PROCEDURE [OOZMA_KAPPA].[TraerListadoClienteCantidadSuscripcionesPendientesAFacturarPorClienteIDYCuentaID]
GO
DROP PROCEDURE [OOZMA_KAPPA].[TraerListadoCuentaAPagarPorClienteID]
GO
DROP PROCEDURE [OOZMA_KAPPA].[InsertItem_Factura]
GO
DROP PROCEDURE [OOZMA_KAPPA].[InsertFactura_RetornarID]
GO
DROP PROCEDURE [OOZMA_KAPPA].[DeleteSuscripcionesAfterFacturacion]
GO


----- Crear Stored Procedures -----

CREATE PROCEDURE [OOZMA_KAPPA].traerUsuarioActivoPorUsername
    @Username nvarchar(255)
AS 
    SELECT *
    FROM OOZMA_KAPPA.Usuario
    WHERE usuario_username = @Username AND usuario_estado = 0;
GO

CREATE PROCEDURE [OOZMA_KAPPA].traerListadoRolesPorId_Usuario
	@usuario_id nvarchar(255)
AS
	SELECT r.rol_id as rol_id, r.rol_nombre as rol_nombre , r.rol_estado as rol_estado FROM OOZMA_KAPPA.Usuario_rol ur, OOZMA_KAPPA.Rol r WHERE usuario_id = @usuario_id  AND ur.rol_id = r.rol_id;
GO

CREATE PROCEDURE [OOZMA_KAPPA].traerListadoFuncionalidadesPorId_Rol
    @id_Rol int
AS 
    SELECT funcionalidades_id, funcionalidades_nombre 
    FROM OOZMA_KAPPA.Funcionalidades f , OOZMA_KAPPA.Funcionalidades_rol fr
    WHERE f.funcionalidades_id = fr.funcionalidad_id AND fr.rol_id = @id_Rol;
GO

CREATE PROCEDURE [OOZMA_KAPPA].[deshabilitarUsuario]
	@usuario_id int
AS
	UPDATE [OOZMA_KAPPA].Usuario SET usuario_estado = 1 WHERE usuario_id = @usuario_id;
	
GO

CREATE PROCEDURE [OOZMA_KAPPA].[updateUsuario]
	@id_Usuario numeric(18,0),
	@Username nvarchar(255),
	@Clave nvarchar(255),
	@Estado bit
AS
	UPDATE [OOZMA_KAPPA].Usuario SET usuario_username=@Username, usuario_password=@Clave, usuario_estado = @Estado WHERE usuario_id=@id_Usuario	
GO


CREATE PROCEDURE [OOZMA_KAPPA].[traerListadoRoles]
AS
	SELECT rol_id as id_Rol, rol_nombre as Nombre FROM OOZMA_KAPPA.Rol;
GO

CREATE PROCEDURE [OOZMA_KAPPA].[traerListadoClienteCompleto]
AS
	SELECT cliente_id as cliente_id,(cliente_apellido +' '+ cliente_nombre) as cliente_nombre, cliente_numero_documento as cliente_documento FROM OOZMA_KAPPA.Cliente;
GO

CREATE PROCEDURE [OOZMA_KAPPA].[traerListadoClientePorUsuarioID]
	@usuario_id numeric(18,0)
AS
	SELECT cliente_id as cliente_id,(cliente_apellido +' '+ cliente_nombre) as cliente_nombre, cliente_numero_documento as cliente_documento FROM OOZMA_KAPPA.Cliente WHERE cliente_usuario_id = @usuario_id;
GO

CREATE PROCEDURE [OOZMA_KAPPA].[traerListadoClientePorClienteID]
	@cliente_id numeric(18,0)
AS
	SELECT cliente_id, cliente_nombre, cliente_apellido, cliente_numero_documento, cliente_fecha_nacimiento FROM OOZMA_KAPPA.Cliente WHERE cliente_id = @cliente_id;
GO


CREATE PROCEDURE [OOZMA_KAPPA].[traerListadoCuentaActivasPorClienteID]
	@cliente_id numeric(18,0),
	@Fecha datetime
AS
	SELECT cuenta_id as cuenta_numero, cuenta_estado, cuenta_saldo, cuenta_fecha_apertura as fecha_apertura, cuenta_fecha_cierre as fecha_cierre FROM OOZMA_KAPPA.Cuenta WHERE cuenta_cliente_id = @cliente_id AND cuenta_estado = 1 AND DATEDIFF(YEAR, cuenta_fecha_cierre, @Fecha) >= 0 AND DATEDIFF(MONTH, cuenta_fecha_cierre, @Fecha) >= 0;
GO

CREATE PROCEDURE [OOZMA_KAPPA].[traerListadoCuentaPorClienteID]
	@cliente_id numeric(18,0)
AS
	SELECT cuenta_id as cuenta_numero, cuenta_estado, cuenta_saldo, cuenta_fecha_apertura as fecha_apertura, cuenta_fecha_cierre as fecha_cierre FROM OOZMA_KAPPA.Cuenta WHERE cuenta_cliente_id = @cliente_id;
GO

CREATE PROCEDURE [OOZMA_KAPPA].[traerListadoCuentaporCuentaID]
	@cuenta_id numeric(18,0)
AS
	SELECT * FROM [OOZMA_KAPPA].Cuenta ;
GO


CREATE PROCEDURE [OOZMA_KAPPA].[traerListadoBancoCompleto]
AS
	SELECT banco_id, (banco_nombre + ' Sucursal : ' + CAST(banco_id as varchar)) as banco_nombre FROM OOZMA_KAPPA.Banco;
GO


CREATE PROCEDURE [OOZMA_KAPPA].[insertCheque_RetornarID]
	@cheque_cliente_id numeric(18,0),
	@cheque_cuenta_id numeric(18,0),
	@cheque_banco_id numeric(18,0),
	@cheque_fecha dateTime,
	@cheque_importe numeric(18,0)
AS
	INSERT INTO OOZMA_KAPPA.Cheque(cheque_banco_id,cheque_cuenta_id,cheque_destino_cliente_id,cheque_fecha,cheque_importe)
	VALUES (@cheque_banco_id,@cheque_cuenta_id,@cheque_cliente_id,@cheque_fecha,@cheque_importe );
	
	SELECT @@IDENTITY AS cheque_id;

GO

CREATE PROCEDURE [OOZMA_KAPPA].[insertRetiro_RetornarID]
	@retiro_cheque_id numeric(18,0),
	@retiro_cuenta_id numeric(18,0),
	@retiro_fecha dateTime,
	@retiro_importe numeric(18,0)
AS
	INSERT INTO OOZMA_KAPPA.Retiro(retiro_cheque_id, retiro_cuenta_id, retiro_fecha, retiro_importe) 
	VALUES (@retiro_cheque_id, @retiro_cuenta_id, @retiro_fecha, @retiro_importe) ;
	
	SELECT @@IDENTITY AS retiro_id;
GO

CREATE PROCEDURE [OOZMA_KAPPA].[TraerListadoClienteTransferenciasAFacturar]
	@cliente_id numeric(18,0)
AS	
	SELECT transaccion_pendiente_id , transaccion_pendiente_cliente_id, transaccion_pendiente_fecha, transaccion_pendiente_importe FROM OOZMA_KAPPA.Transacciones_Pendientes WHERE transaccion_pendiente_cliente_id = @cliente_id AND (transaccion_pendiente_descr = 'Comision por transferencia');
GO

CREATE PROCEDURE [OOZMA_KAPPA].[TraerListadoClienteSuscripcionesPendientesAFacturarPorClienteIDYCuentaID]
	@cliente_id numeric(18,0),
	@cuenta_id numeric(18,0)
AS
	SELECT transaccion_pendiente_cliente_id,transaccion_pendiente_cuenta_id, transaccion_pendiente_fecha, transaccion_pendiente_importe FROM OOZMA_KAPPA.Transacciones_Pendientes WHERE transaccion_pendiente_cliente_id = @cliente_id AND transaccion_pendiente_cuenta_id = @cuenta_id AND (transaccion_pendiente_descr = 'Suscripciones por Apertura Cuenta');
GO

CREATE PROCEDURE [OOZMA_KAPPA].[TraerListadoClienteModificacionesTCAFacturar]
	@cliente_id numeric(18,0)
AS
	SELECT transaccion_pendiente_id ,transaccion_pendiente_cliente_id,transaccion_pendiente_fecha, transaccion_pendiente_importe FROM OOZMA_KAPPA.Transacciones_Pendientes WHERE transaccion_pendiente_cliente_id = @cliente_id AND (transaccion_pendiente_descr = 'Modificaciones Tipo Cuenta');
GO

CREATE PROCEDURE [OOZMA_KAPPA].[TraerListadoClienteCantidadSuscripcionesPendientesAFacturarPorClienteIDYCuentaID]
	@cliente_id numeric(18,0),
	@cuenta_id numeric(18,0)
AS 
	SELECT COUNT(transaccion_pendiente_cliente_id) as cantidadSuscripciones FROM OOZMA_KAPPA.Transacciones_Pendientes WHERE transaccion_pendiente_cliente_id = @cliente_id AND transaccion_pendiente_descr = 'Suscripciones por Apertura Cuenta' AND transaccion_pendiente_cuenta_id = @cuenta_id GROUP BY transaccion_pendiente_cliente_id

GO

CREATE PROCEDURE [OOZMA_KAPPA].[TraerListadoCuentaAPagarPorClienteID]
	@cliente_id numeric(18,0)
AS 
	SELECT DISTINCT transaccion_pendiente_cuenta_id as cuenta_id FROM OOZMA_KAPPA.Transacciones_Pendientes WHERE transaccion_pendiente_cliente_id = @cliente_id;
GO

CREATE PROCEDURE [OOZMA_KAPPA].[InsertItem_Factura]
	@item_factura_numero numeric(18,0),
	@item_factura_tabla_items TVP_Items READONLY
	AS
	 DECLARE @item_descr varchar(255)
	 DECLARE @item_cantidad numeric(18,0)
	 DECLARE @item_costo numeric(18,2)
	 DECLARE itemsCursor CURSOR FOR (SELECT * FROM @item_factura_tabla_items)
	 
	 OPEN itemsCursor;
	 
	 FETCH NEXT FROM itemsCursor INTO @item_descr, @item_cantidad, @item_costo;
	 
	 WHILE @@FETCH_STATUS = 0
	 BEGIN
		
		IF(@item_descr = 1)
		BEGIN
		SET @item_descr= 'Comision por transferencia'
		END
		ELSE IF(@item_descr = 2)
		BEGIN
		SET @item_descr = 'Modificaciones Tipo Cuenta'
		END
		ELSE IF(@item_descr = 3)
		BEGIN 
		SET @item_descr = 'Suscripciones por Apertura Cuenta'
		END
		
		INSERT INTO OOZMA_KAPPA.Item_factura (item_factura_numero_factura, item_factura_desc, item_factura_cantidad, item_factura_costo)
		VALUES (@item_factura_numero, @item_descr, @item_cantidad, @item_costo);
		
		FETCH NEXT FROM itemsCursor INTO @item_descr, @item_cantidad, @item_costo;
	 END
	 
	 CLOSE itemsCursor;
	 DEALLOCATE itemsCursor;
GO

CREATE PROCEDURE [OOZMA_KAPPA].[InsertFactura_RetornarID]
	@factura_importe numeric(18,2),
	@factura_fecha datetime,
	@factura_cliente_id numeric(18,0),
	@factura_id numeric(18,0) = NULL OUTPUT,
	@tablaSuscripciones TVP_SuscripcionesABorrar READONLY	
AS
	 DECLARE @Cliente numeric(18,0)
	 DECLARE @Cuenta numeric(18,0)
	 DECLARE @CantidadSuscripciones int
	 DECLARE itemsSuscripciones CURSOR FOR (SELECT * FROM @tablaSuscripciones)
	 
	 OPEN itemsSuscripciones;
	 
	 FETCH NEXT FROM itemsSuscripciones INTO @Cliente, @Cuenta, @CantidadSuscripciones;
	 
	 WHILE @@FETCH_STATUS = 0
	 BEGIN
	 
		WITH suscripciones AS (SELECT TOP (@CantidadSuscripciones) * 
					 FROM OOZMA_KAPPA.Transacciones_Pendientes WHERE  transaccion_pendiente_cliente_id = @Cliente AND
																	  transaccion_pendiente_cuenta_id = @Cuenta
																   	  ORDER BY transaccion_pendiente_fecha)
		DELETE FROM suscripciones;
		
		FETCH NEXT FROM itemsSuscripciones INTO @Cliente, @Cuenta, @CantidadSuscripciones;
	 END
	 	
	
 	DELETE FROM OOZMA_KAPPA.Transacciones_Pendientes WHERE transaccion_pendiente_cliente_id = @factura_cliente_id AND transaccion_pendiente_descr <> 'Suscripciones por Apertura Cuenta';
	 
	CLOSE itemsSuscripciones;
	DEALLOCATE itemsSuscripciones;

	INSERT INTO OOZMA_KAPPA.Factura (factura_importe, factura_fecha, factura_cliente_id)
	VALUES (@factura_importe, @factura_fecha, @factura_cliente_id);
	
	SET @factura_id = @@IDENTITY;

GO

CREATE PROCEDURE [OOZMA_KAPPA].[DeleteSuscripcionesAfterFacturacion]
	@cuenta_id numeric(18,0),
	@cantidadSuscripciones numeric(18,0)
AS
	DELETE FROM OOZMA_KAPPA.Transacciones_Pendientes WHERE transaccion_pendiente_cuenta_id = @cuenta_id;

GO

