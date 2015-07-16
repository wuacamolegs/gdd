----- Crear Stored Procedures -----

-- TRAER LISTADO CLIENTE CON TODO --

CREATE PROCEDURE [OOZMA_KAPPA].[TraerListadoClienteConTodo]
AS
BEGIN TRANSACTION
SELECT * FROM OOZMA_KAPPA.Cliente where cliente_eliminado = 0
COMMIT;
GO

CREATE PROCEDURE [OOZMA_KAPPA].[traerListadoCliente]
AS
BEGIN TRANSACTION
SELECT * FROM OOZMA_KAPPA.Cliente
COMMIT;
GO

-- TRAER LISTADO CLIENTE CON TODO POR CLIENTE ID--

CREATE PROCEDURE [OOZMA_KAPPA].[TraerListadoClienteConTodoPorClienteID]
	@cliente_id numeric(18,0)
AS
BEGIN TRANSACTION
SELECT * FROM OOZMA_KAPPA.Cliente WHERE cliente_id = @cliente_id
COMMIT;
GO

-- TRAER LISTADO CLIENTE CON FILTROS

CREATE PROCEDURE [OOZMA_KAPPA].[traerListadoClienteConFiltros]
   @cliente_nombre varchar(255),
   @cliente_apellido varchar(255), 
   @cliente_tipo_documento_id numeric(18,0), 
   @cliente_numero_documento varchar(255), 
   @cliente_mail varchar(255)
AS
BEGIN TRANSACTION
  SELECT * FROM OOZMA_KAPPA.Cliente
     WHERE cliente_nombre LIKE (CASE WHEN @cliente_nombre <> '' THEN '%' + @cliente_nombre + '%' ELSE cliente_nombre END)
     AND cliente_apellido LIKE (CASE WHEN @cliente_apellido <> '' THEN '%' + @cliente_apellido + '%' ELSE cliente_apellido END)
     AND (@cliente_tipo_documento_id is null OR @cliente_tipo_documento_id = -1 OR CONVERT(VARCHAR(10), cliente_tipo_documento_id) LIKE '%' + CONVERT(VARCHAR(10), @cliente_tipo_documento_id) + '%')     
     AND (@cliente_numero_documento is null OR @cliente_numero_documento = 0 OR CONVERT(VARCHAR(10), cliente_numero_documento) LIKE '%' + CONVERT(VARCHAR(10), @cliente_numero_documento) + '%')
     AND cliente_mail LIKE (CASE WHEN @cliente_mail <> '' THEN '%' + @cliente_mail + '%' ELSE cliente_mail END)
     AND cliente_estado = 1
     AND cliente_eliminado = 0
COMMIT;
GO




-- MODIFICAR CLIENTE --

CREATE PROCEDURE [OOZMA_KAPPA].[updateCliente]
   @cliente_id numeric(18,0),
   @cliente_apellido varchar(255),
   @cliente_nombre varchar(255),
   @cliente_mail varchar(255),
   @cliente_pais_id numeric(18,0),
   @cliente_numero varchar(255),
   @cliente_calle varchar(255),
   @cliente_direccion numeric(18,0),
   @cliente_depto varchar(10),
   @cliente_estado bit
AS
BEGIN TRANSACTION
  UPDATE OOZMA_KAPPA.Cliente SET cliente_apellido = @cliente_apellido, 
                                 cliente_nombre = @cliente_nombre, 
                                 cliente_mail = @cliente_mail, 
                                 cliente_pais_residente_id = @cliente_pais_id, 
                                 cliente_numero = @cliente_numero, 
                                 cliente_calle = @cliente_calle,
                                 cliente_piso = @cliente_direccion, 
                                 cliente_depto = @cliente_depto, 
                                 cliente_estado = @cliente_estado
  WHERE cliente_id = @cliente_id
COMMIT;
GO

-- BORRAR CLIENTE POR CLIENTE_ID --

CREATE PROCEDURE  [OOZMA_KAPPA].[deleteCliente]  
   @cliente_id numeric(18,0)
AS
UPDATE OOZMA_KAPPA.Cliente SET cliente_estado = 1
WHERE cliente_id = @cliente_id
GO



-- INSERTAR UN NUEVO CLIENTE --

CREATE PROCEDURE [OOZMA_KAPPA].insertCliente 
   @cliente_usuario_id numeric(18,0), 
   @Tipo_Dni numeric(18,0), 
   @Dni numeric(18,0),
   @Apellido varchar(255), 
   @Nombre varchar(255), 
   @Fecha_nac datetime, 
   @Mail varchar(255),
   @Pais_id numeric(18,0),
   @Numero_calle varchar(255), 
   @Calle varchar(255), 
   @Dom_piso numeric(18,0),
   @Dom_depto varchar(10),
   @Estado bit
AS
BEGIN TRANSACTION
  INSERT INTO OOZMA_KAPPA.Cliente (cliente_usuario_id,cliente_tipo_documento_id,cliente_numero_documento,
  cliente_apellido, cliente_nombre,cliente_fecha_nacimiento,cliente_mail,cliente_pais_residente_id,cliente_numero,
  cliente_calle,cliente_piso, cliente_depto, cliente_estado)
  VALUES(@cliente_usuario_id, @Tipo_Dni,@Dni,@Apellido,@Nombre,@Fecha_nac,@Mail,@Pais_id,@Numero_calle,
  @Calle,@Dom_piso,@Dom_depto,@Estado);
COMMIT;
GO



-- VALIDAR DNI EN CLIENTE --

CREATE PROCEDURE [OOZMA_KAPPA].validarDniEnCliente
	@cliente_dni numeric(18,0)
AS
BEGIN TRANSACTION

   SELECT * FROM OOZMA_KAPPA.Cliente 
   WHERE cliente_numero_documento = @cliente_dni;

COMMIT;
GO


CREATE PROCEDURE [OOZMA_KAPPA].[InsertUsuario_RetornarID]
    @Username numeric(18,0),
    @Clave nvarchar(64),
    @Pregunta nvarchar(64),
    @Respuesta nvarchar(64),
    @Modificacion datetime,
    @Creacion datetime,
    @Nombre nvarchar(255)
AS
BEGIN 

	INSERT INTO OOZMA_KAPPA.Usuario (usuario_username, usuario_nombreYapellido, usuario_password, usuario_fecha_creacion, usuario_fecha_ultima_modificacion, usuario_pregunta_secreta, usuario_respuesta_secreta)
	VALUES(@Username, @Nombre, @Clave,@Creacion, @Modificacion, @Pregunta, @Respuesta);
	
	SELECT @@IDENTITY as usuario_id;

END
GO
