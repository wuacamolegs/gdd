----- DROP STORED PROCEDURES ------

USE [GD1C2015]
GO
DROP PROCEDURE [OOZMA_KAPPA].[insertRetiro_RetornarID]
GO
DROP PROCEDURE [OOZMA_KAPPA].[traerListadoCuentaActivasPorClienteID]
GO
DROP PROCEDURE [OOZMA_KAPPA].[traerListadoCuentaporCuentaID]
GO
DROP PROCEDURE [OOZMA_KAPPA].[traerListadoFuncionalidadesPorId_Rol]
GO
DROP PROCEDURE [OOZMA_KAPPA].[traerListadoClienteCompleto]
GO
DROP PROCEDURE [OOZMA_KAPPA].[traerListadoClientePorClienteID]
GO
DROP PROCEDURE [OOZMA_KAPPA].[traerListadoClientePorUsuarioID]
GO
DROP PROCEDURE [OOZMA_KAPPA].[traerListadoRolesPorId_Usuario]
GO
DROP PROCEDURE [OOZMA_KAPPA].[insertCheque_RetornarID]
GO
DROP PROCEDURE [OOZMA_KAPPA].[deshabilitarUsuario]
GO
DROP PROCEDURE [OOZMA_KAPPA].[traerUsuarioActivoPorUsername]
GO
DROP PROCEDURE [OOZMA_KAPPA].[updateUsuario]
GO
DROP PROCEDURE [OOZMA_KAPPA].[traerListadoBancoCompleto]
GO
DROP PROCEDURE [OOZMA_KAPPA].[traerListadoRoles]
GO
DROP PROCEDURE [OOZMA_KAPPA].[traerListadoRolesCompleto]
GO


----- Crear Stored Procedures -----
BEGIN TRANSACTION

GO

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
	@cliente_id numeric(18,0)
AS
	SELECT cuenta_id as cuenta_numero, cuenta_estado, cuenta_saldo, cuenta_fecha_apertura as fecha_apertura, cuenta_fecha_cierre as fecha_cierre FROM OOZMA_KAPPA.Cuenta WHERE cuenta_cliente_id = @cliente_id AND cuenta_estado = 1;
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
	SELECT item_factura_id, item_factura_desc, item_factura_cant, item_factura_costo, item_factura_fecha FROM OOZMA_KAPPA.Item_factura WHERE item_factura_cliente_id = @cliente_id AND (item_factura_desc = 'Comisión por transferencia.');
GO

CREATE PROCEDURE [OOZMA_KAPPA].[TraerListadoClienteAperturasCuentaAFacturar]
	@cliente_id numeric(18,0)
AS
	SELECT item_factura_id, item_factura_desc, item_factura_cant, item_factura_costo, item_factura_fecha FROM OOZMA_KAPPA.Item_factura WHERE item_factura_cliente_id = @cliente_id AND (item_factura_desc = 'Apertura Cuenta');
GO

CREATE PROCEDURE [OOZMA_KAPPA].[TraerListadoClienteModificacionesTCAFacturar]
	@cliente_id numeric(18,0)
AS
	SELECT item_factura_id, item_factura_desc, item_factura_cant, item_factura_costo, item_factura_fecha FROM OOZMA_KAPPA.Item_factura WHERE item_factura_cliente_id = @cliente_id AND (item_factura_desc = 'Modificaciones Tipo Cuenta');
GO

COMMIT


