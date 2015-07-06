USE [GD1C2015]
GO
DROP PROCEDURE [OOZMA_KAPPA].traerListadoRolesCompleto
GO
DROP PROCEDURE [OOZMA_KAPPA].insertDeposito
GO
DROP PROCEDURE [OOZMA_KAPPA].traerListadoMonedaCompleto
GO
DROP PROCEDURE [OOZMA_KAPPA].traerListadoTarjetaActivasPorClienteID
GO
DROP PROCEDURE [OOZMA_KAPPA].[updateRol]
GO
DROP PROCEDURE [OOZMA_KAPPA].deshabilitarRol
GO
DROP PROCEDURE [OOZMA_KAPPA].traerListadoFuncionalidades
GO
DROP PROCEDURE [OOZMA_KAPPA].deleteRol_Funcionalidad_PorIdRol
GO
DROP PROCEDURE [OOZMA_KAPPA].deleteRol
GO
DROP PROCEDURE [OOZMA_KAPPA].insertRol_retornarID
GO
DROP PROCEDURE [OOZMA_KAPPA].insertRol_Funcionalidad
GO
DROP PROCEDURE [OOZMA_KAPPA].validarRolEnUsuarios
GO
DROP PROCEDURE [OOZMA_KAPPA].traerListadoRolesConFiltros
GO
DROP PROCEDURE [OOZMA_KAPPA].insertTarjeta
GO
DROP PROCEDURE [OOZMA_KAPPA].updateTarjeta
GO
DROP PROCEDURE [OOZMA_KAPPA].deleteTarjeta
GO


---------------------------------------- Crear Stored Procedures -----

-----------SP ROLES Y FUNCIONALIDADES------------

CREATE PROCEDURE [OOZMA_KAPPA].traerListadoRolesCompleto
AS 
	SELECT rol_id , rol_nombre FROM OOZMA_KAPPA.Rol where rol_eliminado = 1;  ---rol_eliminado = 1 está activo (no eliminado)
GO

CREATE PROCEDURE OOZMA_KAPPA.updateRol
	@rol_id int,
	@rol_nombre nvarchar(255),
	@rol_estado bit
AS
	UPDATE OOZMA_KAPPA.Rol SET rol_nombre=@rol_nombre, rol_estado=@rol_estado
	WHERE rol_id = @rol_id
GO

CREATE PROCEDURE OOZMA_KAPPA.deshabilitarRol
	@rol_id int
AS
	UPDATE OOZMA_KAPPA.Rol SET rol_estado = 0   ---rol_estado = 0 es deshabilitado
	WHERE rol_id = @rol_id
GO

CREATE PROCEDURE OOZMA_KAPPA.deleteRol
	@rol_id int
AS
	UPDATE OOZMA_KAPPA.Rol SET rol_eliminado = 0  --rol_eliminado = 0 es baja lógica
	WHERE rol_id = @rol_id
GO

CREATE PROCEDURE OOZMA_KAPPA.deleteRol_Funcionalidad_PorIdRol
	@rol_id int
AS
	DELETE FROM OOZMA_KAPPA.Funcionalidades_rol WHERE rol_id = @rol_id
GO

CREATE PROCEDURE OOZMA_KAPPA.insertRol_RetornarID
	@rol_nombre nvarchar(255),
	@rol_estado bit
AS
	INSERT INTO OOZMA_KAPPA.Rol	(rol_nombre, rol_estado)
	VALUES(@rol_nombre, @rol_estado)
	
	SELECT @@IDENTITY AS id_Rol;
GO

CREATE PROCEDURE [OOZMA_KAPPA].[insertRol_Funcionalidad]
	@rol_id int,
	@funcionalidad_id int
AS
	INSERT INTO OOZMA_KAPPA.Funcionalidades_rol(rol_id, funcionalidad_id)
	VALUES(@rol_id, @funcionalidad_id)
GO

CREATE PROCEDURE OOZMA_KAPPA.validarRolEnUsuarios
	@rol_id int
AS
	SELECT * FROM OOZMA_KAPPA.Usuario_rol WHERE rol_id = @rol_id
GO

CREATE PROCEDURE [OOZMA_KAPPA].[traerListadoRolesConFiltros]  --SOLO PARA TRAER ROLES SEGUN NOMBRE O ESTADO. NO TIENE EN CUENTA TRAER ROLES ELIMINADOS CUANDO BUSCA POR NOMBRE
    @rol_nombre nvarchar(255),
	@rol_estado bit
AS 
	IF(@rol_nombre= '' Or @rol_nombre IS NULL)
		BEGIN
			SELECT * FROM [OOZMA_KAPPA].Rol WHERE rol_estado = @rol_estado and rol_eliminado = 1; --- si esta eliminado es 0, sino 1
		END	
	ELSE
		SELECT * FROM [OOZMA_KAPPA].Rol
			WHERE rol_nombre LIKE '%' + @rol_nombre + '%' AND rol_estado = @rol_estado and rol_eliminado = 1;

GO

CREATE PROCEDURE OOZMA_KAPPA.traerListadoRolesPorNombre
	@rol_nombre nvarchar(255)
AS
	SELECT * FROM OOZMA_KAPPA.Rol where rol_nombre LIKE '%' + @rol_nombre + '%' and rol_eliminado = 1 
GO


CREATE PROCEDURE OOZMA_KAPPA.traerListadoFuncionalidades
AS	
	SELECT * FROM OOZMA_KAPPA.Funcionalidades
GO


--------- SP DEPOSITO----------
CREATE PROCEDURE [OOZMA_KAPPA].[insertDeposito] 
	@deposito_cuenta_id numeric (18,0),
	@deposito_cliente_id numeric (18,0),
	@deposito_importe numeric (18,0),
	@deposito_tarjeta_id numeric (18,0),
	@deposito_fecha datetime,
	@deposito_moneda numeric(18,0)
AS
	INSERT INTO OOZMA_KAPPA.Deposito(deposito_cuenta_id, deposito_cliente_id, deposito_importe, deposito_tarjeta_id, deposito_fecha, deposito_moneda_id)
	VALUES (@deposito_cuenta_id, @deposito_cliente_id, @deposito_importe, @deposito_tarjeta_id, @deposito_fecha, @deposito_moneda);
	
GO	




--------- SP TARJETA------------
CREATE PROCEDURE [OOZMA_KAPPA].[traerListadoTarjetaActivasPorClienteID]
	@cliente_id numeric (18,0),
	@Fecha datetime
AS
	SELECT tarjeta_id AS tarjeta_numero,tarjeta_emisor,tarjeta_fecha_emision,tarjeta_vencimiento FROM OOZMA_KAPPA.Tarjeta
	WHERE tarjeta_cliente_id = @cliente_id AND CONVERT(varchar(10), tarjeta_vencimiento, 103) > CONVERT(varchar(10),@Fecha, 103)
	AND tarjeta_estado = 1
GO

CREATE PROCEDURE [OOZMA_KAPPA].[insertTarjeta] 
	@tarjeta_id numeric (18,0), -----SE TIENE QUE ENCRIPTAR EL TARJETA_ID 16 digitos, solo ultimos 4 visibles.
	@tarjeta_codigo_seguridad varchar (3),
	@tarjeta_fecha_emision datetime,
	@tarjeta_vencimiento datetime,
	@tarjeta_emisor varchar(255),
	@cliente_id numeric (18,0)
	
AS
	INSERT INTO OOZMA_KAPPA.Tarjeta(tarjeta_id, tarjeta_codigo_seguridad, tarjeta_fecha_emision, tarjeta_vencimiento, tarjeta_emisor, tarjeta_cliente_id, tarjeta_estado)
	VALUES (@tarjeta_id, @tarjeta_codigo_seguridad, @tarjeta_fecha_emision, @tarjeta_vencimiento, @tarjeta_emisor, @cliente_id, 1);
	
GO	

CREATE PROCEDURE OOZMA_KAPPA.updateTarjeta
	@tarjeta_id numeric (18,0), -----SE TIENE QUE ENCRIPTAR EL TARJETA_ID 16 digitos, solo ultimos 4 visibles.
	@tarjeta_codigo_seguridad varchar (3),
	@tarjeta_fecha_emision datetime,
	@tarjeta_vencimiento datetime,
	@tarjeta_emisor varchar(255),
	@cliente_id numeric (18,0),
	@tarjeta_estado bit
AS
	UPDATE OOZMA_KAPPA.Tarjeta SET tarjeta_codigo_seguridad=@tarjeta_codigo_seguridad, tarjeta_fecha_emision=@tarjeta_fecha_emision,
	tarjeta_vencimiento=@tarjeta_vencimiento, tarjeta_emisor=@tarjeta_emisor, tarjeta_cliente_id=@cliente_id, @tarjeta_estado=tarjeta_estado
	WHERE tarjeta_id=@tarjeta_id
GO

CREATE PROCEDURE OOZMA_KAPPA.deleteTarjeta	
	@tarjeta_id numeric (18,0), -----SE TIENE QUE ENCRIPTAR EL TARJETA_ID 16 digitos, solo ultimos 4 visibles.
	@tarjeta_estado bit
AS
	UPDATE OOZMA_KAPPA.Tarjeta SET @tarjeta_estado = 0
	WHERE tarjeta_id = @tarjeta_id
GO



-------- SP MONEDA--------------
CREATE PROCEDURE [OOZMA_KAPPA].[traerListadoMonedaCompleto]
AS
	SELECT moneda_id as id_Moneda, moneda_nombre as Moneda FROM OOZMA_KAPPA.Moneda;
GO






