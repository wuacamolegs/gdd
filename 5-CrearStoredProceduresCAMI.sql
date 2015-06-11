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
	SELECT *
	FROM OOZMA_KAPPA.Rol
	WHERE (SELECT rol_id FROM OOZMA_KAPPA.Usuario_rol WHERE usuario_id = @usuario_id) = rol_id;
GO


CREATE PROCEDURE [OOZMA_KAPPA].traerListadoFuncionalidadesPorId_Rol
    @id_Rol int
AS 
    SELECT funcionalidades_id, funcionalidades_nombre 
    FROM OOZMA_KAPPA.Funcionalidades f , OOZMA_KAPPA.Funcionalidades_rol fr
    WHERE f.funcionalidades_id = fr.funcionalidad_id AND fr.rol_id = @id_Rol;
GO

CREATE PROCEDURE [OOZMA_KAPPA].[updateUsuario]
	@id_Usuario numeric(18,0),
	@Username nvarchar(255),
	@Clave nvarchar(255),
	@Estado bit
AS
	UPDATE [OOZMA_KAPPA].Usuario SET usuario_username=@Username, usuario_password=@Clave, usuario_estado = @Estado where usuario_id=@id_Usuario	
GO


select * from OOZMA_KAPPA.Funcionalidades_rol

select * from OOZMA_KAPPA.Rol
select * from OOZMA_KAPPA.Usuario_rol
select * from OOZMA_KAPPA.funcio


