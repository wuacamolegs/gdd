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
	FROM OOZMA_KAPPA.Usuario_rol
	WHERE usuario_id = @usuario_id;
GO
