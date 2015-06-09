--Procedure traerUsuarioPorUsernameYClave
CREATE PROCEDURE ATJ.traerUsuarioPorUsernameYClave 
    @Username nvarchar(255), 
    @Clave nvarchar(255) 
AS 
    SELECT *
    FROM ATJ.Usuarios
    WHERE Username = @Username AND Clave = @Clave;
GO

--Procedure traerUsuarioPorUsuarname
CREATE PROCEDURE ATJ.traerUsuarioPorUsername
    @Username nvarchar(255)
AS 
    SELECT *
    FROM ATJ.Usuarios
    WHERE Username = @Username
GO

--Procedure traerListadoRolesPorId_Usuario
CREATE PROCEDURE [ATJ].[traerListadoRolesPorId_Usuario] 
    @id_Usuario numeric(18,0) 
AS 
    SELECT R.id_Rol AS id_Rol, R.Nombre AS Nombre, R.Habilitado as Habilitado from ATJ.Roles R 
	INNER JOIN ATJ.Rol_Usuario RU ON RU.id_Rol = R.id_Rol
	INNER JOIN ATJ.Usuarios U ON U.id_Usuario = RU.id_Usuario
	WHERE U.id_Usuario = @id_Usuario AND R.Habilitado = 1 AND R.Eliminado = 0
GO

--Procedure deshabilitarUsuario
CREATE PROCEDURE [ATJ].[deshabilitarUsuario]
	@id_Usuario numeric(18,0)
AS
	UPDATE ATJ.Usuarios SET Activo = 0 where id_Usuario=@id_Usuario	
GO


--Procedure updateUsuario
CREATE PROCEDURE [ATJ].[updateUsuario]
	@id_Usuario numeric(18,0),
	@Username nvarchar(255),
	@Clave nvarchar(255),
	@ClaveAutoGenerada bit,
	@Activo bit
AS
	UPDATE ATJ.Usuarios SET Username=@Username, Clave=@Clave, ClaveAutoGenerada = @ClaveAutoGenerada, Activo = @Activo where id_Usuario=@id_Usuario	
GO


--Procedure traerListadoRoles
CREATE PROCEDURE [ATJ].[traerListadoRoles] 
AS 
    SELECT * FROM ATJ.ROLES WHERE Eliminado = 0;
GO


--Procedure traerListadoFuncionalidadesPorId_Rol
CREATE PROCEDURE ATJ.traerListadoFuncionalidadesPorId_Rol
	@id_Rol numeric(18,0)
AS	
	SELECT F.* FROM ATJ.Rol_Funcionalidad RF 
	INNER JOIN ATJ.Funcionalidades F ON F.id_Funcionalidad = RF.id_Funcionalidad
	WHERE RF.id_Rol = @id_Rol
GO

--Procedure traerListadoFuncionalidades
CREATE PROCEDURE ATJ.traerListadoFuncionalidades
AS	
	SELECT * FROM ATJ.Funcionalidades
GO

--Procedure traerListadoRubros
CREATE PROCEDURE ATJ.traerListadoRubros
AS	
	SELECT * FROM ATJ.Rubros
GO

--Procedure traerListadoRubrosPorCodPublicacion
CREATE PROCEDURE ATJ.traerListadoRubrosPorCodPublicacion
	@cod_Publicacion numeric(18,0)
AS	
	SELECT R.* FROM ATJ.Rubros R
	INNER JOIN Rubros_Publicacion RP ON RP.id_Rubro = R.id_Rubro
	WHERE RP.cod_Publicacion = @cod_Publicacion
GO


--Procedure insertRol_RetornarID
CREATE PROCEDURE ATJ.insertRol_RetornarID
	@Nombre nvarchar(255),
	@Habilitado bit
AS
	INSERT INTO ATJ.Roles
	(Nombre, Habilitado)
	VALUES 
	(@Nombre, @Habilitado)
	
	SELECT @@IDENTITY AS id_Rol;
GO

--Procedure insertRol_Funcionalidad
CREATE PROCEDURE [ATJ].[insertRol_Funcionalidad]
	@id_Rol int,
	@id_Funcionalidad int
AS
	INSERT INTO ATJ.Rol_Funcionalidad
	(id_Rol, id_Funcionalidad)
	VALUES 
	(@id_Rol, @id_Funcionalidad)
GO

--Procedure insertRubros_Publicacion
CREATE PROCEDURE [ATJ].[insertRubros_Publicacion]
	@cod_Publicacion numeric(18,0),
	@id_Rubro numeric(18,0)
AS
	INSERT INTO ATJ.Rubros_Publicacion
	(cod_Publicacion, id_Rubro)
	VALUES 
	(@cod_Publicacion, @id_Rubro)
GO
	
--Procedure deleteRol_FuncionalidadPorIdRol
CREATE PROCEDURE ATJ.deleteRol_Funcionalidad_PorIdRol
	@id_Rol int
AS
	DELETE FROM ATJ.Rol_Funcionalidad WHERE id_Rol = @id_Rol
GO

--Procedure deleteRubros_PublicacionPorCod_Publicacion
CREATE PROCEDURE ATJ.deleteRubros_PublicacionPorCod_Publicacion
	@cod_Publicacion numeric(18,0)
AS
	DELETE FROM ATJ.Rubros_Publicacion WHERE cod_Publicacion = @cod_Publicacion
GO

--Procedure updateRol
CREATE PROCEDURE ATJ.updateRol
	@id_Rol int,
	@Nombre nvarchar(255),
	@Habilitado bit
AS
	UPDATE ATJ.Roles SET Nombre=@Nombre, Habilitado=@Habilitado
	WHERE id_Rol = @id_Rol
GO

--Procedure deshabilitarRol
CREATE PROCEDURE ATJ.deshabilitarRol
	@id_Rol int
AS
	UPDATE ATJ.Roles SET Habilitado=0
	WHERE id_Rol = @id_Rol
GO

--Procedure deleteRol
CREATE PROCEDURE ATJ.deleteRol
	@id_Rol int
AS
	UPDATE ATJ.Roles SET Eliminado=1
	WHERE id_Rol = @id_Rol
GO

--Procedure validarVisibilidadEnPublicacion
CREATE PROCEDURE ATJ.validarVisibilidadEnPublicacion
	@cod_Visibilidad int
AS
	SELECT * FROM ATJ.Publicaciones WHERE cod_Visibilidad = @cod_Visibilidad
GO

--Procedure validarRolEnUsuarios
CREATE PROCEDURE ATJ.validarRolEnUsuarios
	@id_Rol int
AS
	SELECT * FROM ATJ.Rol_Usuario WHERE id_Rol = @id_Rol
GO



--Procedure deleteVisibilidad
CREATE PROCEDURE ATJ.deleteVisibilidad
	@cod_Visibilidad int
AS
	UPDATE ATJ.Visibilidades SET Eliminado=1
	WHERE cod_Visibilidad = @cod_Visibilidad
GO



--Procedure traerListadoRolesConFiltros
CREATE PROCEDURE [ATJ].[traerListadoRolesConFiltros] 
    @Nombre nvarchar(255),
	@Habilitado bit
AS 
	IF(@Nombre = '' Or @Nombre IS NULL)
		BEGIN
			SELECT * FROM ATJ.Roles where Habilitado = @Habilitado AND Eliminado = 0;
		END	
	ELSE
		SELECT * FROM ATJ.Roles 
			WHERE Nombre LIKE '%' + @Nombre + '%' AND Habilitado = @Habilitado AND Eliminado = 0;

GO


--Procedure deshabilitarVisibilidad
CREATE PROCEDURE ATJ.deshabilitarVisibilidad
	@cod_Visibilidad int
AS
	UPDATE ATJ.Visibilidades SET Activo=0
	WHERE cod_Visibilidad = @cod_Visibilidad
GO

--Procedure traerListadoVisibilidades
CREATE PROCEDURE [ATJ].[traerListadoVisibilidades] 
AS 
    SELECT * FROM ATJ.Visibilidades WHERE Eliminado = 0;
GO

--Procedure traerListadoVisibilidadesConFiltros
CREATE PROCEDURE [ATJ].[traerListadoVisibilidadesConFiltros] 
    @Descripcion nvarchar(255) = '',
	@Precio nvarchar(20)= '',
	@Porcentaje nvarchar(20) ='',
	@Duracion nvarchar(20) = '',
	@Activo bit
AS 
	SELECT * FROM ATJ.Visibilidades WHERE Eliminado = 0
	AND Descripcion LIKE (CASE WHEN @Descripcion <> '' THEN '%' + @Descripcion + '%' ELSE Descripcion END)
	AND Precio = (CASE WHEN @Precio <> '' THEN CAST(@Precio as numeric(18,2)) ELSE Precio END)
	AND Porcentaje = (CASE WHEN @Porcentaje <> '' THEN CAST(@Porcentaje as numeric(18,2)) ELSE Porcentaje END)
	AND Duracion = (CASE WHEN @Duracion <> '' THEN CAST(@Duracion as numeric(18,2)) ELSE Duracion END)
	AND Activo = @Activo
GO


--Procedure updateVisibilidad
CREATE PROCEDURE ATJ.updateVisibilidad
	@cod_Visibilidad int,
	@Descripcion nvarchar(255),
	@Precio numeric(18,2),
	@Porcentaje numeric(18,2),
	@Duracion int,
	@Activo bit
AS
	UPDATE ATJ.Visibilidades SET Descripcion = @Descripcion, Precio = @Precio, Porcentaje = @Porcentaje, Duracion = @Duracion, Activo = @Activo
	WHERE cod_Visibilidad = @cod_Visibilidad
GO

--Procedure updatePublicacion
CREATE PROCEDURE ATJ.updatePublicacion
	@Codigo int,
	@id_Usuario numeric(18,0),
	@Descripcion nvarchar(255),
	@Stock numeric(18,0),
	@Fecha_creacion datetime,
	@Fecha_vencimiento datetime,
	@Precio numeric(18,2),
	@id_Tipo numeric(18,0),
	@cod_Visibilidad numeric(18,0),
	@id_Estado numeric(18,0),
	@permiso_Preguntas bit
AS
	UPDATE ATJ.Publicaciones SET id_Usuario = @id_Usuario, Descripcion = @Descripcion, Stock = @Stock, Fecha_creacion = @Fecha_creacion, 
	Fecha_vencimiento = @Fecha_vencimiento,Precio = @Precio, id_Tipo = @id_Tipo, cod_Visibilidad = @cod_Visibilidad, id_Estado = @id_Estado, permiso_Preguntas = @permiso_Preguntas
	WHERE Codigo = @Codigo
GO


--Procedure insertVisibilidad_RetornarID
CREATE PROCEDURE ATJ.insertVisibilidad_RetornarID
	@Descripcion nvarchar(255),
	@Precio numeric(18,2),
	@Porcentaje numeric(18,2),
	@Duracion int,
	@Activo bit
AS
	INSERT INTO ATJ.Visibilidades
	(Descripcion, Precio, Porcentaje,Duracion, Activo)
	VALUES 
	(@Descripcion, @Precio, @Porcentaje, @Duracion, @Activo)
	
	SELECT @@IDENTITY AS cod_Visibilidad;
GO

--Procedure insertPublicacion_RetornarID
CREATE PROCEDURE ATJ.insertPublicacion_RetornarID
	@id_Usuario numeric(18,0),
	@Descripcion nvarchar(255),
	@Stock numeric(18,0),
	@Fecha_creacion datetime,
	@Fecha_vencimiento datetime,
	@Precio numeric(18,2),
	@id_Tipo numeric(18,0),
	@cod_Visibilidad numeric(18,0),
	@id_Estado numeric(18,0),
	@permiso_Preguntas bit
AS
	INSERT INTO ATJ.Publicaciones
	(id_Usuario, Descripcion, Stock, Fecha_creacion, Fecha_vencimiento, Precio, id_Tipo, cod_Visibilidad, id_Estado, permiso_Preguntas)
	VALUES 
	(@id_Usuario, @Descripcion, @Stock, @Fecha_creacion, @Fecha_vencimiento, @Precio, @id_Tipo, @cod_Visibilidad, @id_Estado, @permiso_Preguntas)
	
	SELECT @@IDENTITY AS Codigo;
GO


--Procedure insertOferta_RetornarID
CREATE PROCEDURE ATJ.insertOferta_RetornarID
	@cod_Publicacion numeric (18,0),
	@id_Usuario_Vendedor int,
	@id_Usuario_Comprador int,
	@Fecha datetime,
	@Monto numeric(18,2)
AS
	INSERT INTO ATJ.Ofertas
	(cod_Publicacion, id_Usuario_Vendedor, id_Usuario_Comprador, Fecha, Monto)
	VALUES 
	(@cod_Publicacion, @id_Usuario_Vendedor, @id_Usuario_Comprador, @Fecha, @Monto)
	
	SELECT @@IDENTITY AS id_Oferta;
GO

--Procedure insertCompra_RetornarID
CREATE PROCEDURE ATJ.insertCompra_RetornarID
	@cod_Publicacion numeric (18,0),
	@id_Usuario_Vendedor int,
	@id_Usuario_Comprador int,
	@Fecha datetime,
	@Cantidad numeric(18,0)
AS
	INSERT INTO ATJ.Compras
	(cod_Publicacion, id_Usuario_Vendedor, id_Usuario_Comprador, Fecha, Cantidad)
	VALUES 
	(@cod_Publicacion, @id_Usuario_Vendedor, @id_Usuario_Comprador, @Fecha, @Cantidad)
	
	SELECT @@IDENTITY AS id_Compra;
GO


--Procedure insertPregunta_RetornarID
CREATE PROCEDURE ATJ.insertPregunta_RetornarID
	@txtPregunta nvarchar(255),
	@id_Usuario int,
	@cod_Publicacion numeric(18,0)
AS
	INSERT INTO ATJ.Preguntas
	(Pregunta, id_Usuario,cod_Publicacion)
	VALUES 
	(@txtPregunta, @id_Usuario,@cod_Publicacion)
	
	SELECT @@IDENTITY AS id_Pregunta;
GO


--traerListadoFuncionalidadesPorNombre
CREATE PROCEDURE ATJ.traerListadoVisibilidadesPorDescripcion
	@Descripcion nvarchar(255)
AS
	SELECT * FROM ATJ.Visibilidades where Descripcion = @Descripcion AND Eliminado = 0
GO

--traerListadoRolesPorNombre
CREATE PROCEDURE ATJ.traerListadoRolesPorNombre
	@Nombre nvarchar(255)
AS
	SELECT * FROM ATJ.Roles where Nombre LIKE '%' + @Nombre + '%' AND Eliminado = 0
GO


--Procedure traerListadoRubrosPorId_Rubro
CREATE PROCEDURE [ATJ].[traerListadoRubrosPorId_Rubro] 
    @id_Rubro numeric(18,0) 
AS 
    SELECT * FROM ATJ.Rubros
	WHERE id_Rubro = @id_Rubro
GO

--Procedure traerListadoClientesPorId_Usuario
CREATE PROCEDURE [ATJ].[traerListadoClientesPorId_Usuario] 
    @id_Usuario numeric(18,0) 
AS 
    SELECT * FROM ATJ.Clientes
	WHERE id_Usuario = @id_Usuario
GO

--Procedure traerListadoEmpresasPorId_Usuario
CREATE PROCEDURE [ATJ].[traerListadoEmpresasPorId_Usuario] 
    @id_Usuario numeric(18,0) 
AS 
    SELECT * FROM ATJ.Empresas
	WHERE id_Usuario = @id_Usuario
GO

--Procedure traerListadoVisibilidadesPorCod_Visibilidad
CREATE PROCEDURE [ATJ].[traerListadoVisibilidadesPorCod_Visibilidad] 
    @cod_Visibilidad numeric(18,0) 
AS 
    SELECT * FROM ATJ.Visibilidades
	WHERE cod_Visibilidad = @cod_Visibilidad AND Eliminado = 0
GO

--Procedure traerListadoEstados_PublicacionPorId_Estado
CREATE PROCEDURE [ATJ].[traerListadoEstados_PublicacionPorId_Estado] 
    @id_Estado numeric(18,0) 
AS 
    SELECT * FROM ATJ.Estados_Publicacion
	WHERE id_Estado = @id_Estado
GO

--Procedure traerListadoEstados_Publicacion
CREATE PROCEDURE [ATJ].[traerListadoEstados_Publicacion] 
AS 
    SELECT * FROM ATJ.Estados_Publicacion
GO

--Procedure traerListadoTipos_PublicacionPorId_Tipo
CREATE PROCEDURE [ATJ].[traerListadoTipos_PublicacionPorId_Tipo] 
    @id_Tipo numeric(18,0) 
AS 
    SELECT * FROM ATJ.Tipos_Publicacion
	WHERE id_Tipo = @id_Tipo
GO

--Procedure traerListadoTipos_Publicacion
CREATE PROCEDURE [ATJ].[traerListadoTipos_Publicacion] 
AS 
    SELECT * FROM ATJ.Tipos_Publicacion
GO

--Procedure traerListadoUsuariosPorId_Usuario
CREATE PROCEDURE [ATJ].[traerListadoUsuariosPorId_Usuario] 
    @id_Usuario numeric(18,0) 
AS 
    SELECT * FROM ATJ.Usuarios
	WHERE id_Usuario = @id_Usuario
GO

--Procedure traerListadoPublicacionesPorCod_Publicacion
CREATE PROCEDURE [ATJ].[traerListadoPublicacionesPorCod_Publicacion] 
    @cod_Publicacion numeric(18,0) 
AS 
    SELECT * FROM ATJ.Publicaciones
	WHERE Codigo = @cod_Publicacion
GO

--Procedure traerListadoPublicacionesPorId_Usuario
CREATE PROCEDURE [ATJ].[traerListadoPublicacionesPorId_Usuario] 
    @id_Usuario numeric(18,0) 
AS 
    SELECT P.*
    FROM ATJ.Publicaciones P
	WHERE P.id_Usuario = @id_Usuario
GO


--Procedure traerListadoPublicacionesNoVendidasOrdenadoPorVisibilidad
CREATE PROCEDURE [ATJ].[traerListadoPublicacionesNoVendidasOrdenadoPorVisibilidad] 
	@Fecha_Vencimiento datetime
AS 
    SELECT P.*
    FROM ATJ.Publicaciones P
    INNER JOIN ATJ.Visibilidades V on V.cod_Visibilidad = P.cod_Visibilidad
    INNER JOIN ATJ.Estados_Publicacion E on E.id_Estado = P.id_Estado
	WHERE P.Fecha_Vencimiento > @Fecha_Vencimiento AND P.Stock > 0 AND E.Nombre IN ('Publicada')
	ORDER BY V.Precio DESC
GO

--Procedure traerListadoPublicaciones
CREATE PROCEDURE [ATJ].[traerListadoPublicacionesNoVendidasOrdenadoPorVisibilidadConFiltros] 
	@Fecha_Vencimiento datetime,
	@Descripcion nvarchar(255),
	@filtroRubros nvarchar(500)
AS 
    SELECT P.*
    FROM ATJ.Publicaciones P
    INNER JOIN ATJ.Visibilidades V on V.cod_Visibilidad = P.cod_Visibilidad
    INNER JOIN ATJ.Estados_Publicacion E on E.id_Estado = P.id_Estado
	INNER JOIN ATJ.Rubros_Publicacion RP on RP.cod_Publicacion = P.Codigo
    INNER JOIN ATJ.Rubros R on R.id_Rubro = RP.id_Rubro
	WHERE P.Fecha_Vencimiento > @Fecha_Vencimiento AND P.Stock > 0 AND E.Nombre IN ('Publicada')
	AND P.Descripcion LIKE (CASE WHEN @Descripcion <> '' THEN '%' + @Descripcion + '%' ELSE P.Descripcion END)
	AND R.Descripcion IN (CASE WHEN @filtroRubros <> '' THEN @filtroRubros ELSE R.Descripcion END)	
	ORDER BY V.Precio DESC
	
GO

--Procedure traerListadoPublicacionesPorId_UsuarioYFiltros
CREATE PROCEDURE [ATJ].[traerListadoPublicacionesPorId_UsuarioYFiltros] 
    @id_Usuario numeric(18,0),
	@Descripcion nvarchar(255)
AS 
    SELECT P.*
    FROM ATJ.Publicaciones P
	WHERE P.id_Usuario = @id_Usuario AND P.Descripcion LIKE '%' + @Descripcion + '%'
GO



--Procedure traerListadoEstados_PublicacionEditablesConPublicada
CREATE PROCEDURE [ATJ].[traerListadoEstados_PublicacionEditablesConPublicada] 
AS 
    SELECT * FROM ATJ.Estados_Publicacion
	WHERE Nombre IN ('Pausada', 'Finalizada', 'Publicada')
GO

--Procedure traerListadoUsuarios
CREATE PROCEDURE ATJ.traerListadoUsuarios
AS
	SELECT * FROM ATJ.Usuarios
	WHERE Activo = 1
GO

--Procedure traerListadoPublicacionesGratuitasPorId_Usuario
CREATE PROCEDURE ATJ.traerListadoPublicacionesGratuitasPorId_Usuario
	@id_Usuario numeric(18,0)
AS
	SELECT * FROM ATJ.Publicaciones P
	INNER JOIN ATJ.Visibilidades V ON V.cod_Visibilidad = P.cod_Visibilidad
	WHERE V.Descripcion = 'Gratis' AND P.id_Usuario = @id_Usuario
GO

CREATE PROCEDURE ATJ.traerMayorOfertaPorCodPublicacion
	@cod_Publicacion numeric(18,0)
AS	
	SELECT MAX(Monto) AS maxOferta FROM ATJ.Ofertas where cod_Publicacion = @cod_Publicacion
GO