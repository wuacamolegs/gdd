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
DROP PROCEDURE [OOZMA_KAPPA].[DeleteSuscripcionesAfterFacturacion]
GO
DROP PROCEDURE [OOZMA_KAPPA].[TraerListadoCuentaCompleto]
GO
DROP PROCEDURE [OOZMA_KAPPA].[TraerListadoCuentaPorUsuarioID]
GO
DROP PROCEDURE OOZMA_KAPPA.traerListadoCuentaConFiltros 
GO
DROP PROCEDURE OOZMA_KAPPA.TraerListadoTipoDocumento
GO
DROP PROCEDURE OOZMA_KAPPA.traerListadoPaisesCompleto
GO
DROP PROCEDURE OOZMA_KAPPA.traerListadoTipoCuentaCompleto
GO
DROP PROCEDURE OOZMA_KAPPA.InsertFactura
GO
DROP PROCEDURE OOZMA_KAPPA.TraerListadoFacturaUltimaGenerada
GO
DROP PROCEDURE OOZMA_KAPPA.UpdateCuenta
GO
DROP PROCEDURE OOZMA_KAPPA.InsertCuenta
GO
DROP PROCEDURE OOZMA_KAPPA.TraerProximaCuentaID
GO
DROP PROCEDURE OOZMA_KAPPA.TraerListadoCuentaCantidadTransaccionesAPagar
GO




----- Crear Stored Procedures -----
CREATE PROCEDURE [OOZMA_KAPPA].traerUsuarioActivoPorUsername
    @Username nvarchar(255)
AS
BEGIN 
    SELECT *
    FROM OOZMA_KAPPA.Usuario
    WHERE usuario_username = @Username AND usuario_estado = 1;
END
GO

CREATE PROCEDURE [OOZMA_KAPPA].traerListadoRolesPorId_Usuario
	@usuario_id nvarchar(255)
AS
BEGIN
	SELECT r.rol_id as rol_id, r.rol_nombre as rol_nombre , r.rol_estado as rol_estado FROM OOZMA_KAPPA.Usuario_rol ur, OOZMA_KAPPA.Rol r 
	WHERE usuario_id = @usuario_id  AND ur.rol_id = r.rol_id and r.rol_eliminado = 0 ;
END
GO

CREATE PROCEDURE [OOZMA_KAPPA].traerListadoFuncionalidadesPorId_Rol
    @id_Rol int
AS
BEGIN 
    SELECT funcionalidades_id, funcionalidades_nombre 
    FROM OOZMA_KAPPA.Funcionalidades f , OOZMA_KAPPA.Funcionalidades_rol fr
    WHERE f.funcionalidades_id = fr.funcionalidad_id AND fr.rol_id = @id_Rol;
END
GO

CREATE PROCEDURE [OOZMA_KAPPA].[deshabilitarUsuario]
	@usuario_id int
AS
BEGIN
	UPDATE [OOZMA_KAPPA].Usuario SET usuario_estado = 0 WHERE usuario_id = @usuario_id;	
END
GO

CREATE PROCEDURE [OOZMA_KAPPA].[updateUsuario]
	@id_Usuario numeric(18,0),
	@Username nvarchar(255),
	@Clave nvarchar(255),
	@Estado bit
AS
BEGIN
	UPDATE [OOZMA_KAPPA].Usuario SET usuario_username=@Username, usuario_password=@Clave, usuario_estado = @Estado 
	WHERE usuario_id=@id_Usuario	
END
GO


CREATE PROCEDURE [OOZMA_KAPPA].[traerListadoRoles]
AS
BEGIN
	SELECT rol_id as id_Rol, rol_nombre as Nombre, rol_estado FROM OOZMA_KAPPA.Rol WHERE rol_eliminado = 0;
END
GO

CREATE PROCEDURE [OOZMA_KAPPA].[traerListadoClienteCompleto]
AS
BEGIN
	SELECT cliente_id as cliente_id,(cliente_apellido +' '+ cliente_nombre) as cliente_nombre, cliente_numero_documento as cliente_documento FROM OOZMA_KAPPA.Cliente where cliente_estado = 1;
END
GO

CREATE PROCEDURE [OOZMA_KAPPA].[traerListadoClientePorUsuarioID]
	@usuario_id numeric(18,0)
AS
BEGIN
	SELECT cliente_id as cliente_id,(cliente_apellido +' '+ cliente_nombre) as cliente_nombre, cliente_numero_documento as cliente_documento FROM OOZMA_KAPPA.Cliente 
	WHERE cliente_usuario_id = @usuario_id and cliente_estado = 1;
END
GO

CREATE PROCEDURE [OOZMA_KAPPA].[traerListadoClientePorClienteID]
	@cliente_id numeric(18,0)
AS
BEGIN
	SELECT cliente_id, cliente_nombre, cliente_apellido, cliente_numero_documento, cliente_fecha_nacimiento 
	FROM OOZMA_KAPPA.Cliente WHERE cliente_id = @cliente_id and cliente_estado = 1;
END
GO


CREATE PROCEDURE [OOZMA_KAPPA].[traerListadoCuentaActivasPorClienteID]
	@cliente_id numeric(18,0),
	@Fecha datetime
AS
BEGIN
	SELECT cuenta_id as cuenta_numero, cuenta_estado, cuenta_saldo, cuenta_fecha_apertura as fecha_apertura, cuenta_fecha_cierre as fecha_cierre FROM OOZMA_KAPPA.Cuenta WHERE cuenta_cliente_id = @cliente_id AND cuenta_estado = 1 AND cuenta_cerrada = 0 AND cuenta_pendiente_activacion = 0;
END
GO

CREATE PROCEDURE [OOZMA_KAPPA].[traerListadoCuentaPorClienteID]
	@cliente_id numeric(18,0)
AS
BEGIN
	SELECT cuenta_id as cuenta_numero, cuenta_estado, cuenta_saldo, cuenta_fecha_apertura as fecha_apertura, cuenta_fecha_cierre as fecha_cierre FROM OOZMA_KAPPA.Cuenta WHERE cuenta_cliente_id = @cliente_id AND cuenta_cerrada = 0 AND cuenta_pendiente_activacion = 0;
END
GO

CREATE PROCEDURE [OOZMA_KAPPA].[traerListadoCuentaporCuentaID]
	@cuenta_id numeric(18,0)
AS
BEGIN
	SELECT cuenta_id, cuenta_cliente_id, cuenta_estado, cuenta_fecha_apertura, cuenta_fecha_cierre, cuenta_moneda_id, cuenta_pais_id, cuenta_saldo, cuenta_tipo_cuenta_id FROM [OOZMA_KAPPA].Cuenta WHERE cuenta_id = @cuenta_id;
END
GO


CREATE PROCEDURE [OOZMA_KAPPA].[traerListadoBancoCompleto]
AS
BEGIN
	SELECT banco_id, (banco_nombre + ' Sucursal : ' + CAST(banco_id as varchar)) as banco_nombre FROM OOZMA_KAPPA.Banco;
END
GO


CREATE PROCEDURE [OOZMA_KAPPA].[insertCheque_RetornarID]
	@cheque_cliente_id numeric(18,0),
	@cheque_cuenta_id numeric(18,0),
	@cheque_banco_id numeric(18,0),
	@cheque_fecha dateTime,
	@cheque_importe numeric(18,0)
AS
BEGIN
	INSERT INTO OOZMA_KAPPA.Cheque(cheque_banco_id,cheque_cuenta_id,cheque_destino_cliente_id,cheque_fecha,cheque_importe)
	VALUES (@cheque_banco_id,@cheque_cuenta_id,@cheque_cliente_id,@cheque_fecha,@cheque_importe );
	
	SELECT @@IDENTITY as cheque_id;

END
GO

CREATE PROCEDURE [OOZMA_KAPPA].[insertRetiro_RetornarID]
	@retiro_cheque_id numeric(18,0),
	@retiro_cuenta_id numeric(18,0),
	@retiro_fecha dateTime,
	@retiro_importe numeric(18,0)
AS
BEGIN
	INSERT INTO OOZMA_KAPPA.Retiro(retiro_cheque_id, retiro_cuenta_id, retiro_fecha, retiro_importe) 
	VALUES (@retiro_cheque_id, @retiro_cuenta_id, @retiro_fecha, @retiro_importe) ;
	
	SELECT @@IDENTITY as retiro_id;
END
GO

CREATE PROCEDURE [OOZMA_KAPPA].[TraerListadoClienteTransferenciasAFacturar]
	@cliente_id numeric(18,0)
AS
BEGIN	
	SELECT transaccion_pendiente_id , transaccion_pendiente_cliente_id, transaccion_pendiente_fecha, transaccion_pendiente_importe FROM OOZMA_KAPPA.Transacciones_Pendientes WHERE transaccion_pendiente_cliente_id = @cliente_id AND (transaccion_pendiente_descr = 'Comisión por transferencia');
END
GO

CREATE PROCEDURE [OOZMA_KAPPA].[TraerListadoClienteSuscripcionesPendientesAFacturarPorClienteIDYCuentaID]
	@cliente_id numeric(18,0),
	@cuenta_id numeric(18,0)
AS
BEGIN
	SELECT transaccion_pendiente_cliente_id,transaccion_pendiente_cuenta_id, transaccion_pendiente_fecha, transaccion_pendiente_importe FROM OOZMA_KAPPA.Transacciones_Pendientes WHERE transaccion_pendiente_cliente_id = @cliente_id AND transaccion_pendiente_cuenta_id = @cuenta_id AND (transaccion_pendiente_descr = 'Suscripciones por Apertura Cuenta');
END
GO

CREATE PROCEDURE [OOZMA_KAPPA].[TraerListadoClienteModificacionesTCAFacturar]
	@cliente_id numeric(18,0)
AS
BEGIN
	SELECT transaccion_pendiente_id ,transaccion_pendiente_cliente_id,transaccion_pendiente_fecha, transaccion_pendiente_importe FROM OOZMA_KAPPA.Transacciones_Pendientes WHERE transaccion_pendiente_cliente_id = @cliente_id AND (transaccion_pendiente_descr = 'Modificaciones Tipo Cuenta');
END
GO

CREATE PROCEDURE [OOZMA_KAPPA].[TraerListadoClienteCantidadSuscripcionesPendientesAFacturarPorClienteIDYCuentaID]
	@cliente_id numeric(18,0),
	@cuenta_id numeric(18,0)
AS
BEGIN 
	SELECT COUNT(transaccion_pendiente_cliente_id) as cantidadSuscripciones FROM OOZMA_KAPPA.Transacciones_Pendientes WHERE transaccion_pendiente_cliente_id = @cliente_id AND transaccion_pendiente_descr = 'Suscripciones por Apertura Cuenta' AND transaccion_pendiente_cuenta_id = @cuenta_id GROUP BY transaccion_pendiente_cliente_id
END
GO

CREATE PROCEDURE [OOZMA_KAPPA].[TraerListadoCuentaAPagarPorClienteID]
	@cliente_id numeric(18,0)
AS
BEGIN 
	SELECT DISTINCT transaccion_pendiente_cuenta_id as cuenta_id FROM OOZMA_KAPPA.Transacciones_Pendientes WHERE transaccion_pendiente_cliente_id = @cliente_id AND transaccion_pendiente_descr = 'Suscripciones por Apertura Cuenta';
END
GO

CREATE PROCEDURE [OOZMA_KAPPA].[InsertItem_Factura]
	@item_factura_numero numeric(18,0),
	@item_factura_tabla_items TVP_Item READONLY
	AS
BEGIN
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
END
GO

CREATE PROCEDURE [OOZMA_KAPPA].[InsertFactura]
	@factura_importe numeric(18,2),
	@factura_fecha datetime,
	@factura_cliente_id numeric(18,0),
	@tablaSuscripciones TVP_SuscripcionesABorrar READONLY	
AS
BEGIN TRANSACTION
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
		
		UPDATE OOZMA_KAPPA.Cuenta SET cuenta_estado = 1, cuenta_pendiente_activacion = 0 WHERE cuenta_id = @Cuenta
		
		FETCH NEXT FROM itemsSuscripciones INTO @Cliente, @Cuenta, @CantidadSuscripciones;
		
	 END
	 	
	
 	DELETE FROM OOZMA_KAPPA.Transacciones_Pendientes WHERE transaccion_pendiente_cliente_id = @factura_cliente_id AND transaccion_pendiente_descr <> 'Suscripciones por Apertura Cuenta';
	 
	CLOSE itemsSuscripciones;
	DEALLOCATE itemsSuscripciones;
	

	INSERT INTO OOZMA_KAPPA.Factura (factura_importe, factura_fecha, factura_cliente_id)
	VALUES (@factura_importe, @factura_fecha, @factura_cliente_id);
	
COMMIT
GO

CREATE PROCEDURE [OOZMA_KAPPA].[TraerListadoFacturaUltimaGenerada]
AS
BEGIN 
	SELECT TOP 1 factura_numero, factura_cliente_id, factura_importe, factura_fecha FROM OOZMA_KAPPA.Factura ORDER BY factura_numero DESC
END
GO


CREATE PROCEDURE [OOZMA_KAPPA].[DeleteSuscripcionesAfterFacturacion]
	@cuenta_id numeric(18,0),
	@cantidadSuscripciones numeric(18,0)
AS
BEGIN
	DELETE FROM OOZMA_KAPPA.Transacciones_Pendientes WHERE transaccion_pendiente_cuenta_id = @cuenta_id;

END
GO

CREATE PROCEDURE [OOZMA_KAPPA].[TraerListadoCuentaCompleto]
AS
BEGIN
	SELECT cuenta_id, cliente_id, (cliente_nombre + ' ' + cliente_apellido) as cliente_nombre, cuenta_estado, cuenta_fecha_apertura, cuenta_fecha_cierre, cuenta_moneda_id, cuenta_pais_id, cuenta_saldo, cuenta_tipo_cuenta_id FROM OOZMA_KAPPA.Cuenta, OOZMA_KAPPA.Cliente WHERE cliente_id = cuenta_cliente_id AND cuenta_cerrada = 0 ;
END
GO

CREATE PROCEDURE [OOZMA_KAPPA].[TraerListadoCuentaPorUsuarioID]
	@usuario_id numeric(18,0)
AS
BEGIN
	SELECT cuenta_id, cliente_id, (cliente_nombre + ' ' + cliente_apellido) as cliente_nombre, cuenta_estado, cuenta_fecha_apertura, cuenta_fecha_cierre, cuenta_moneda_id, cuenta_pais_id, cuenta_saldo, cuenta_tipo_cuenta_id FROM OOZMA_KAPPA.Cuenta, OOZMA_KAPPA.Cliente WHERE cliente_id = cuenta_cliente_id AND cliente_usuario_id = @usuario_id AND cuenta_cerrada = 0 ;
END
GO

CREATE PROCEDURE OOZMA_KAPPA.traerListadoCuentaConFiltros 
    @Nombre nvarchar(255) = null, 
    @Apellido nvarchar(255) = null,
    @Tipo_Dni numeric(18,0) = null,
    @Dni numeric(18,0) = null
AS 
BEGIN
    SELECT cuenta_id, cliente_id, (cliente_nombre + ' ' + cliente_apellido) as cliente_nombre, cuenta_estado, cuenta_fecha_apertura, cuenta_fecha_cierre, cuenta_moneda_id, cuenta_pais_id, cuenta_saldo, cuenta_tipo_cuenta_id 
    FROM OOZMA_KAPPA.Cuenta, OOZMA_KAPPA.Cliente
    WHERE	cuenta_cliente_id = cliente_id
    AND     cliente_nombre LIKE (CASE WHEN @Nombre <> '' THEN '%' + @Nombre + '%' ELSE cliente_nombre END) 
    AND		cliente_apellido LIKE (CASE WHEN @Apellido <> '' THEN '%' + @Apellido + '%' ELSE cliente_apellido END) 
    AND		(@Tipo_Dni is null OR @Tipo_Dni = -1 OR CONVERT(VARCHAR(10), cliente_tipo_documento_id) LIKE '%' + CONVERT(VARCHAR(10), @Tipo_Dni) + '%')     
    AND		(@Dni is null OR @Dni = 0 OR CONVERT(VARCHAR(10), cliente_numero_documento) LIKE '%' + CONVERT(VARCHAR(10), @Dni) + '%')
    AND		cuenta_cerrada = 0;
END
GO

CREATE PROCEDURE OOZMA_KAPPA.TraerListadoTipoDocumento
AS
BEGIN
	SELECT tipo_documento_id as td_id, tipo_documento_descripcion as td_descripcion FROM OOZMA_KAPPA.Tipo_documento;
END
GO

CREATE PROCEDURE OOZMA_KAPPA.traerListadoPaisesCompleto
AS
BEGIN
	SELECT pais_id, pais_nombre FROM OOZMA_KAPPA.Pais
END
GO

CREATE PROCEDURE OOZMA_KAPPA.traerListadoTipoCuentaCompleto
AS
BEGIN
	SELECT tipo_cuenta_id, tipo_cuenta_nombre FROM OOZMA_KAPPA.Tipo_cuenta;
END
GO

CREATE PROCEDURE OOZMA_KAPPA.UpdateCuenta
	@Cuenta_id numeric(18,0),
	@Cliente_id numeric(18,0),   
	@Pais numeric(18,0),
	@Moneda numeric(18,0),
	@Tipo_Cuenta numeric(18,0),
	@Fecha datetime
AS
BEGIN
	
	SELECT DATEADD(DAY,tipo_cuenta_dias_vigencia,@Fecha)
	FROM OOZMA_KAPPA.Tipo_cuenta WHERE tipo_cuenta_id = @Tipo_Cuenta;

	UPDATE [OOZMA_KAPPA].Cuenta SET cuenta_pais_id = @Pais,
									cuenta_moneda_id = @Moneda,
									cuenta_tipo_cuenta_id = @Tipo_Cuenta,
									cuenta_fecha_cierre = @Fecha
	WHERE cuenta_id = @Cuenta_id;
END
GO

CREATE PROCEDURE OOZMA_KAPPA.InsertCuenta
	@Cliente_id numeric(18,0),
	@Pais numeric(18,0),
	@Moneda numeric(18,0),
	@Tipo_Cuenta numeric(18,0),
	@Fecha datetime
AS
BEGIN
	INSERT INTO OOZMA_KAPPA.Cuenta (cuenta_cliente_id, cuenta_pais_id, cuenta_moneda_id, cuenta_tipo_cuenta_id,cuenta_fecha_apertura, cuenta_fecha_cierre)(
	SELECT @Cliente_id, @Pais, @Moneda, @Tipo_Cuenta,@Fecha, DATEADD(DAY,tipo_cuenta_dias_vigencia,@Fecha)
	FROM OOZMA_KAPPA.Tipo_cuenta WHERE tipo_cuenta_id = @Tipo_Cuenta);
END
GO


CREATE PROCEDURE OOZMA_KAPPA.TraerProximaCuentaID
AS
BEGIN
	SELECT TOP 1 cuenta_id + 1 as proxID FROM OOZMA_KAPPA.Cuenta ORDER BY cuenta_id DESC;
END
GO

CREATE PROCEDURE OOZMA_KAPPA.TraerListadoCuentaCantidadTransaccionesAPagar
	@cuenta_id numeric(18,0)
AS
	SELECT ISNULL(COUNT(transaccion_pendiente_cuenta_id),0) as cantidad FROM OOZMA_KAPPA.Transacciones_Pendientes WHERE transaccion_pendiente_cuenta_id = @cuenta_id GROUP BY transaccion_pendiente_cuenta_id 
GO

CREATE PROCEDURE OOZMA_KAPPA.DeleteCuenta
	@cuenta_id numeric(18,0)
AS
BEGIN
	UPDATE OOZMA_KAPPA.Cuenta SET cuenta_cerrada = 0 WHERE cuenta_id = @cuenta_id;
END
GO

CREATE PROCEDURE OOZMA_KAPPA.TraerListadoClienteConCosasAFacturar
AS
BEGIN
	SELECT DISTINCT cliente_id as cliente_id,(cliente_apellido +' '+ cliente_nombre) as cliente_nombre, cliente_numero_documento as cliente_documento FROM Transacciones_Pendientes, Cliente WHERE transaccion_pendiente_cliente_id = cliente_id;
END
GO



CREATE PROCEDURE OOZMA_KAPPA.TraerListadoClienteConCosasAFacturarPorUsuarioID
	@usuario_id numeric(18,0)
AS
BEGIN
	SELECT cliente_id as cliente_id,(cliente_apellido +' '+ cliente_nombre) as cliente_nombre, cliente_numero_documento as cliente_documento FROM OOZMA_KAPPA.Transacciones_Pendientes, OOZMA_KAPPA.Cliente WHERE cliente_id = transaccion_pendiente_cliente_id AND cliente_usuario_id = @usuario_id;
END
GO

CREATE PROCEDURE OOZMA_KAPPA.TraerListadoEmisorTarjeta
AS
BEGIN
	SELECT emisor_id, emisor_descripcion FROM OOZMA_KAPPA.Emisor;
END
GO

CREATE PROCEDURE OOZMA_KAPPA.InsertLogin
	@usuario_id numeric(18,0),
	@Estado varchar(50),
	@Intentos int,
	@Fecha datetime
AS
BEGIN
	INSERT INTO OOZMA_KAPPA.Login(login_usuario_id,login_estado, login_cant_intentos, login_fecha_hora)
	VALUES(@usuario_id,@Estado, @Intentos, @Fecha);
END
GO


