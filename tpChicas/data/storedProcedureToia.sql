--Procedure traerListadoEmpresas 
CREATE PROCEDURE ATJ.traerListadoEmpresas
    
AS 
    SELECT *, (Dom_calle+' '+Convert(nvarchar(50),Dom_nro_calle)+' '+Convert(nvarchar(50),Dom_piso)+'° '+Dom_depto) AS Direccion
    FROM ATJ.Empresas  
    WHERE Eliminado = 0 
			
GO

--Procedure traerListadoClientes
CREATE PROCEDURE ATJ.traerListadoClientes
    
AS 
    SELECT *, (Dom_calle+' '+Convert(nvarchar(50),Dom_nro_calle)+' '+Convert(nvarchar(50),Dom_piso)+'° '+Dom_depto) AS Direccion
    FROM ATJ.Clientes
    WHERE Eliminado = 0
GO

--Procedure traerEmpresaConId 
CREATE PROCEDURE ATJ.traerEmpresaConId
    @id_Empresa int
AS 
    SELECT *
    FROM ATJ.Empresas
    WHERE	id_Empresa = @id_Empresa
GO
--Procedure traerClienteaConId 
CREATE PROCEDURE ATJ.traerClienteConId
    @id_Cliente int
AS 
    SELECT *
    FROM ATJ.Clientes 
    WHERE	id_Cliente = @id_Cliente  
			
GO

--Procedure updateEmpresa
CREATE PROCEDURE ATJ.updateEmpresa
	@id_empresa int,
	@Razon_social nvarchar(255) =null,
	@Cuit nvarchar(50) =null,
	@Mail nvarchar(50) =null,
	@Fecha_creacion datetime =null,
	@Telefono nvarchar(255) =null,
	@Dom_calle nvarchar(100) =null,
	@Dom_nro_calle numeric(18,0) =null,
	@Dom_piso numeric(18,0) =null,
	@Dom_depto nvarchar(50) =null,
	@Dom_cod_postal nvarchar(50) =null,
	@Dom_ciudad nvarchar(255) =null,
	@Nombre_contacto nvarchar(255) =null,
	@Activo bit
AS
	UPDATE ATJ.Empresas SET Razon_social = @Razon_social,
							Cuit = @Cuit,
							Fecha_creacion = @Fecha_creacion,
							Mail = @Mail,
							Telefono = @Telefono,
							Dom_calle = @Dom_calle,
							Dom_nro_calle = @Dom_nro_calle,
							Dom_piso = @Dom_piso,
							Dom_depto = @Dom_depto,
							Dom_cod_postal = @Dom_cod_postal,
							Dom_ciudad = @Dom_ciudad,
							Nombre_contacto = @Nombre_contacto,
							Activo = @Activo
							where id_Empresa = @id_empresa
GO
--Procedure deleteEmpresa
CREATE PROCEDURE ATJ.deleteEmpresa
	@id_empresa int
AS
	UPDATE ATJ.Empresas SET eliminado = 1
							where id_Empresa = @id_empresa
GO

--Procedure updateCliente
CREATE PROCEDURE ATJ.updateCliente
	@id_Cliente int,
	@id_Rol int,
	@Tipo_Dni nvarchar(50) =null,
	@Dni numeric(18,0) =null,
	@Cuil nvarchar(50) =null,
	@Apellido nvarchar(255) =null,
	@Nombre nvarchar(255) =null,
	@Fecha_nac datetime =null,
	@Mail nvarchar(255) =null,
	@Telefono nvarchar(255) =null,
	@Dom_calle nvarchar(255) =null,
	@Dom_nro_calle numeric(18,0) =null,
	@Dom_piso numeric(18,0) =null,
	@Dom_depto nvarchar(50) =null,
	@Dom_cod_postal nvarchar(50) =null,
	@Dom_ciudad nvarchar(255) =null,
	@Activo bit
AS
	UPDATE ATJ.Clientes SET Tipo_Dni = @Tipo_Dni,
							Dni = @Dni,
							Cuil = @Cuil,
							Apellido = @Apellido,
							Nombre = @Nombre,
							Fecha_nac = @Fecha_nac,
							Mail = @Mail,
							Telefono = @Telefono,
							Dom_calle = @Dom_calle,
							Dom_nro_calle = @Dom_nro_calle,
							Dom_piso = @Dom_piso,
							Dom_depto = @Dom_depto,
							Dom_cod_postal = @Dom_cod_postal,
							Dom_ciudad = @Dom_ciudad,
							Activo = @Activo
							where id_Cliente = @id_Cliente
GO
--Procedure deleteCliente
CREATE PROCEDURE ATJ.deleteCliente
	@id_cliente int
AS
	UPDATE ATJ.Clientes SET eliminado = 1
							where id_Cliente = @id_cliente 
GO
CREATE PROCEDURE ATJ.insertEmpresa
	@Razon_social nvarchar(255) =null,
	@Cuit nvarchar(50) =null,
	@Mail nvarchar(50) =null,
	@Fecha_creacion datetime =null,
	@Telefono nvarchar(255) =null,
	@Dom_calle nvarchar(100) =null,
	@Dom_nro_calle numeric(18,0) =null,
	@Dom_piso numeric(18,0) =null,
	@Dom_depto nvarchar(50) =null,
	@Dom_cod_postal nvarchar(50) =null,
	@Dom_ciudad nvarchar(255) =null,
	@Nombre_contacto nvarchar(255) =null,
	@Activo bit,
	@id_Rol int,
	@id_Usuario int
	
AS
	INSERT INTO ATJ.Empresas 
	(Razon_social, Cuit, Fecha_creacion, Mail, Telefono, Dom_calle, Dom_nro_calle,
	Dom_piso, Dom_depto, Dom_cod_postal, Dom_ciudad, Nombre_contacto, Activo, id_Usuario)
	VALUES
	(@Razon_social, @Cuit, @Fecha_creacion, @Mail, @Telefono, @Dom_calle, @Dom_nro_calle,
	@Dom_piso, @Dom_depto, @Dom_cod_postal, @Dom_ciudad, @Nombre_contacto,@Activo, @id_Usuario)
	
	INSERT INTO ATJ.Rol_Usuario 
	(id_Rol, id_Usuario)
	VALUES
	(@id_Rol, @id_Usuario)
GO

--Procedure insertCliente
CREATE PROCEDURE ATJ.insertCliente
	@Tipo_Dni nvarchar(50) =null,
	@Dni numeric(18,0) =null,
	@Cuil nvarchar(50) =null,
	@Apellido nvarchar(255) =null,
	@Nombre nvarchar(255) =null,
	@Fecha_nac datetime =null,
	@Mail nvarchar(50) =null,
	@Telefono nvarchar(255) =null,
	@Dom_calle nvarchar(100) =null,
	@Dom_nro_calle numeric(18,0) =null,
	@Dom_piso numeric(18,0) =null,
	@Dom_depto nvarchar(50) =null,
	@Dom_cod_postal nvarchar(50) =null,
	@Dom_ciudad nvarchar(255) =null,
	@Activo bit,
	@id_Rol int,
	@id_Usuario int
	
AS
	INSERT INTO ATJ.Clientes
	(Tipo_Dni, Dni, Cuil, Apellido, Nombre, Fecha_nac, Mail, Telefono, Dom_calle, Dom_nro_calle,
	Dom_piso, Dom_depto, Dom_cod_postal, Dom_ciudad, Activo, id_Usuario)
	VALUES
	(@Tipo_Dni, @Dni, @Cuil, @Apellido, @Nombre, @Fecha_nac, @Mail, @Telefono, @Dom_calle, @Dom_nro_calle,
	@Dom_piso, @Dom_depto, @Dom_cod_postal, @Dom_ciudad, @Activo, @id_Usuario)

	INSERT INTO ATJ.Rol_Usuario 
	(id_Rol, id_Usuario)
	VALUES
	(@id_Rol, @id_Usuario)
GO

--Procedure traerListadoEmpresasConFiltros 
CREATE PROCEDURE ATJ.traerListadoEmpresasConFiltros
    @Razon_social nvarchar(255), 
    @Cuit nvarchar(50),
    @Mail nvarchar(50)
    
AS 
    SELECT *, (Dom_calle+' '+Convert(nvarchar(50),Dom_nro_calle)+' '+Convert(nvarchar(50),Dom_piso)+'° '+Dom_depto) AS Direccion
    FROM ATJ.Empresas
    WHERE	Razon_social LIKE( CASE WHEN @Razon_social <> '' THEN '%' + @Razon_social + '%' ELSE Razon_social END) 
    AND		Cuit = (CASE WHEN @Cuit <> '' THEN @Cuit ELSE Cuit END) 
	AND		Mail LIKE (CASE WHEN @Mail <> '' THEN '%' + @Mail + '%' ELSE Mail END)
	AND		Eliminado = 0
GO

--Procedure traerListadoClientesConFiltros
CREATE PROCEDURE ATJ.traerListadoClientesConFiltros 
    @Nombre nvarchar(255)=null, 
    @Apellido nvarchar(255)=null,
    @Tipo_Dni nvarchar(50)=null,
    @Dni numeric(18,0)=null,
    @Mail nvarchar(255)=null
AS 
    SELECT *
    FROM ATJ.Clientes
    WHERE	Nombre LIKE (CASE WHEN @Nombre <> '' THEN '%' + @Nombre + '%' ELSE Nombre END) 
    AND		Apellido LIKE (CASE WHEN @Apellido <> '' THEN '%' + @Apellido + '%' ELSE Apellido END) 
    AND		Tipo_Dni = (CASE WHEN @Tipo_Dni <> '' THEN @Tipo_Dni ELSE Tipo_Dni END) 
    AND		Mail LIKE (CASE WHEN @Mail <> '' THEN '%' + @Mail + '%' ELSE Mail END) 
    AND		(@Dni is null OR @Dni = 0 OR CONVERT(VARCHAR(10), Dni) LIKE '%' + CONVERT(VARCHAR(10), @Dni) + '%')
    AND		Eliminado = 0
GO

--Procedure deshabilitarEmpresa
CREATE PROCEDURE ATJ.deshabilitarEmpresa
	@id_Empresa int
AS
	UPDATE ATJ.Empresas SET Activo = 0 where id_Empresa = @id_Empresa	
GO

--Procedure deshabilitarCliente
CREATE PROCEDURE ATJ.deshabilitarCliente
	@id_Cliente int
AS
	UPDATE ATJ.Clientes SET Activo = 0 where id_Cliente = @id_Cliente	
GO
--Procedure insertUsuario
CREATE PROCEDURE ATJ.insertUsuario
	@Username nvarchar(255),
	@Clave nvarchar(255),
	@ClaveAutoGenerada bit,
	@Activo bit
AS
	INSERT INTO ATJ.Usuarios
	(Username, Clave, ClaveAutoGenerada, Activo)
	VALUES
	(@Username, @Clave, @ClaveAutoGenerada, @Activo)
GO

--Procedure insertUsuario_RetornarID
CREATE PROCEDURE ATJ.insertUsuario_RetornarID
	@Username nvarchar(255),
	@Clave nvarchar(255),
	@ClaveAutoGenerada bit,
	@Activo bit
AS 
	INSERT INTO ATJ.Usuarios
	(Username, Clave, ClaveAutoGenerada, Activo)
	VALUES
	(@Username, @Clave, @ClaveAutoGenerada, @Activo)
	
	SELECT @@IDENTITY AS id_Usuario;

GO

--------Procedure insertUsuario_RetornarID
------alter PROCEDURE ATJ.insertUsuario_RetornarID
------	@idRol int,
------	@Username nvarchar(255),
------	@Clave nvarchar(255),
------	@ClaveAutoGenerada bit,
------	@Activo bit
------AS 
  
------	INSERT INTO ATJ.Usuarios
------	(Username, Clave, ClaveAutoGenerada, Activo)
------	VALUES
------	(@Username, @Clave, @ClaveAutoGenerada, @Activo)
	
------DECLARE @id_Usuario int
------SET @id_Usuario = (SELECT id_Usuario FROM atj.Usuarios Where Username = @Username)

------	INSERT INTO ATJ.Rol_Usuario 
------	(id_Rol, id_Usuario)
------	VALUES
------	(@idRol, @id_Usuario)
	
------	SELECT @@IDENTITY AS id_Usuario;

------GO

--Procedure traerListadoPublicacionesConCodigo
CREATE PROCEDURE ATJ.traerListadoPublicacionesConCodigo
    @id_Publicacion int

AS 
    SELECT *
    FROM ATJ.Publicaciones 
    WHERE	Codigo = @id_Publicacion 
GO

--Procedure traerVendedorPorId_Usuario 
CREATE PROCEDURE ATJ.traerVendedorPorId_Usuario 
    @id_Usuario int
AS 
  
DECLARE @id_Rol int
SET @id_Rol = (SELECT id_Rol FROM atj.Rol_Usuario Where id_Usuario = @id_Usuario)
IF @id_rol = 2 
SELECT	C.*
    FROM ATJ.Usuarios U
    INNER JOIN ATJ.Clientes C ON u.id_Usuario = c.id_Cliente 
    WHERE u.id_Usuario = @id_Usuario
ELSE
SELECT E.*
	FROM ATJ.Usuarios U
	INNER JOIN ATJ.Empresas E ON U.id_Usuario = E.id_Usuario
	WHERE U.id_Usuario = @id_Usuario

GO

--Procedure traerPreguntasNoRespondidasPorUsuario
CREATE PROCEDURE ATJ.traerPreguntasNoRespondidasPorUsuario
    @id_Usuario int
AS 
    SELECT *
    FROM ATJ.Usuarios U 
    INNER JOIN ATJ.Publicaciones P ON U.id_Usuario = P.id_Usuario 
    INNER JOIN ATJ.Preguntas R ON R.cod_Publicacion = P.Codigo 
    WHERE	R.Respuesta IS NULL
	AND		U.id_Usuario = @id_Usuario		
GO
--Procedure updatePregunta
CREATE PROCEDURE ATJ.updatePregunta
    
	@id_Pregunta int,
	@Respuesta nvarchar(255),
	@Fecha_respuesta datetime
AS
	UPDATE ATJ.Preguntas SET Respuesta = @Respuesta,
							Fecha_respuesta = @Fecha_respuesta
							where id_Pregunta = @id_Pregunta 
	
GO
--Procedure traerPreguntasRespondidasPorUsuario
CREATE PROCEDURE ATJ.traerPreguntasRespondidasPorUsuario
    @id_Usuario int
AS 
    SELECT *
    FROM ATJ.Usuarios U 
    INNER JOIN ATJ.Publicaciones P ON U.id_Usuario = P.id_Usuario 
    INNER JOIN ATJ.Preguntas R ON R.cod_Publicacion = P.Codigo 
    WHERE	R.Respuesta IS NOT NULL
	AND		U.id_Usuario = @id_Usuario		
GO
--Procedure traerListadoUsuariosVendedoresSinCalificar
CREATE PROCEDURE ATJ.traerListadoUsuariosVendedoresSinCalificar
	@id_Usuario int
AS
	SELECT	o.cod_Publicacion,
			Vendedor = (CASE WHEN E.id_Usuario IS NULL THEN S.Nombre+' '+S.Apellido ELSE E.Razon_social END),
			T.Nombre, P.Descripcion, O.Fecha
	FROM ATJ.Ofertas O
	INNER JOIN ATJ.Publicaciones P ON P.Codigo = O.cod_Publicacion
	INNER JOIN ATJ.Tipos_Publicacion T ON T.id_Tipo = P.id_Tipo
	LEFT JOIN ATJ.Empresas E ON O.id_Usuario_Vendedor = E.id_Usuario
	LEFT JOIN ATJ.Clientes S ON O.id_Usuario_Vendedor = S.id_Usuario
	WHERE	O.id_Usuario_Comprador = @id_Usuario 
	AND		O.gano_Subasta = 1
	AND		O.cod_Publicacion NOT IN (SELECT cod_Publicacion FROM ATJ.Calificaciones)
	
	UNION
	
	SELECT	c.cod_Publicacion,
			Vendedor = (CASE WHEN E.id_Usuario IS NULL THEN S.Nombre+' '+S.Apellido ELSE E.Razon_social END),
			T.Nombre, P.Descripcion, C.Fecha
	FROM ATJ.Compras C
	INNER JOIN ATJ.Publicaciones P ON P.Codigo = C.cod_Publicacion
	INNER JOIN ATJ.Tipos_Publicacion T ON T.id_Tipo = P.id_Tipo
	LEFT JOIN ATJ.Empresas E ON C.id_Usuario_Vendedor = E.id_Usuario
	LEFT JOIN ATJ.Clientes S ON C.id_Usuario_Vendedor = S.id_Usuario
	WHERE	id_Usuario_Comprador = @id_Usuario 
	AND		C.cod_Publicacion NOT IN (SELECT cod_Publicacion FROM ATJ.Calificaciones)
GO

--Procedure insertCalificacion
CREATE PROCEDURE ATJ.insertCalificacion
	@id_Usuario int,
	@cod_Publicacion int,
	@CantEstrellas numeric(18,0),
	@Descripcion nvarchar(255)
AS
	INSERT INTO ATJ.Calificaciones 
	(id_Usuario_Calificador, cod_Publicacion, Cant_Estrellas, Descripcion)
	VALUES
	(@id_Usuario, @cod_Publicacion, (@CantEstrellas * 2), @Descripcion)
GO

--Procedure validarTelefonoEnCliente
CREATE PROCEDURE ATJ.validarTelefonoEnCliente
	@Tipo_Dni nvarchar(50) =null,
	@Dni numeric(18,0) =null,
	@Cuil nvarchar(50) =null,
	@Apellido nvarchar(255) =null,
	@Nombre nvarchar(255) =null,
	@Fecha_nac datetime =null,
	@Mail nvarchar(50) =null,
	@Telefono nvarchar(255) =null,
	@Dom_calle nvarchar(100) =null,
	@Dom_nro_calle numeric(18,0) =null,
	@Dom_piso numeric(18,0) =null,
	@Dom_depto nvarchar(50) =null,
	@Dom_cod_postal nvarchar(50) =null,
	@Dom_ciudad nvarchar(255) =null,
	@Activo bit,
	@id_Rol int,
	@id_Cliente int =null,
	@id_Usuario int=null
	
AS
	SELECT * FROM ATJ.Clientes 
	WHERE Telefono = @Telefono
	AND (id_Cliente <> @id_Cliente OR @id_Cliente is null)
	AND (id_Usuario <> @id_Cliente OR @id_Usuario is null)
GO

--Procedure validarDniEnCliente
CREATE PROCEDURE ATJ.validarDniEnCliente
	@Tipo_Dni nvarchar(50) =null,
	@Dni numeric(18,0) =null,
	@Cuil nvarchar(50) =null,
	@Apellido nvarchar(255) =null,
	@Nombre nvarchar(255) =null,
	@Fecha_nac datetime =null,
	@Mail nvarchar(50) =null,
	@Telefono nvarchar(255) =null,
	@Dom_calle nvarchar(100) =null,
	@Dom_nro_calle numeric(18,0) =null,
	@Dom_piso numeric(18,0) =null,
	@Dom_depto nvarchar(50) =null,
	@Dom_cod_postal nvarchar(50) =null,
	@Dom_ciudad nvarchar(255) =null,
	@Activo bit,
	@id_Rol int,
	@id_Cliente int =null,
	@id_Usuario int=null
	
AS
	SELECT * FROM ATJ.Clientes 
	WHERE Dni = @Dni
	AND (id_Cliente <> @id_Cliente OR @id_Cliente is null)
	AND (id_Usuario <> @id_Cliente OR @id_Usuario is null)
	
GO

--Procedure validarUsernameEnUsuario
CREATE PROCEDURE ATJ.validarUsernameEnUsuario
	@Username nvarchar(255)
	
AS
	SELECT * FROM ATJ.Usuarios WHERE Username = @Username 
GO

--Procedure validarCuitEnEmpresa
CREATE PROCEDURE ATJ.validarCuitEnEmpresa
	@Razon_social nvarchar(255) =null,
	@Cuit nvarchar(50) =null,
	@Mail nvarchar(50) =null,
	@Fecha_creacion datetime =null,
	@Telefono nvarchar(255) =null,
	@Dom_calle nvarchar(100) =null,
	@Dom_nro_calle numeric(18,0) =null,
	@Dom_piso numeric(18,0) =null,
	@Dom_depto nvarchar(50) =null,
	@Dom_cod_postal nvarchar(50) =null,
	@Dom_ciudad nvarchar(255) =null,
	@Nombre_contacto nvarchar(255) =null,
	@Activo bit,
	@id_Rol int =null,
	@id_Usuario int =null,
	@id_empresa int =null	
AS
	SELECT * FROM ATJ.Empresas
	WHERE Cuit = @Cuit
	AND (id_Empresa <> @id_empresa OR @id_empresa is null)
	AND (id_Usuario <> @id_Usuario OR @id_Usuario is null)
	
GO
