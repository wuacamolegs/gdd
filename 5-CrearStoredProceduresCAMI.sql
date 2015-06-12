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
	SELECT r.rol_id as id_Rol, r.rol_nombre as Nombre FROM OOZMA_KAPPA.Usuario_rol ur, OOZMA_KAPPA.Rol r WHERE usuario_id = @usuario_id  AND ur.rol_id = r.rol_id;
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


