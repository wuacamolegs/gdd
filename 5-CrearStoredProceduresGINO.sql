----- Crear Stored Procedures -----

-- TRAER LISTADO CLIENTE CON TODO --

CREATE PROCEDURE [OOZMA_KAPPA].[TraerListadoClienteConTodo]
AS
BEGIN TRANSACTION
SELECT * FROM OOZMA_KAPPA.Cliente
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
COMMIT;
GO


-- VALIDAR DNI EN CLIENTE --

CREATE PROCEDURE [OOZMA_KAPPA].[validarDniEnCliente]
   @nro_doc numeric(18,0)
AS
BEGIN TRANSACTION
  SELECT cliente_numero_documento FROM OOZMA_KAPPA.Cliente WHERE cliente_numero_documento = @nro_doc
COMMIT;
GO

-- MODIFICAR CLIENTE --

CREATE PROCEDURE [OOZMA_KAPPA].[updateCliente]
   @cliente_id numeric(18,0),
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
  UPDATE OOZMA_KAPPA.Cliente SET cliente_tipo_documento_id = @Tipo_Dni, 
                                 cliente_numero_documento = @Dni, 
                                 cliente_apellido = @Apellido, 
                                 cliente_nombre = @Nombre, 
                                 cliente_fecha_nacimiento = @Fecha_nac,
                                 cliente_mail = @Mail, 
                                 cliente_pais_residente_id = @Pais_id, 
                                 cliente_numero = @Numero_calle, 
                                 cliente_calle = @Calle,
                                 cliente_piso = @Dom_piso, 
                                 cliente_depto = @Dom_depto, 
                                 cliente_estado = @Estado
  WHERE cliente_id = @cliente_id
COMMIT;
GO

-- BORRAR CLIENTE POR CLIENTE_ID --

CREATE PROCEDURE  [OOZMA_KAPPA].[deleteCliente]  
   @cliente_id numeric(18,0)
AS
BEGIN TRANSACTION
DELETE FROM OOZMA_KAPPA.Cliente WHERE cliente_id = @cliente_id
COMMIT;
GO