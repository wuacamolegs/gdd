----- Crear Stored Procedures -----

-- TRAER LISTADO CLIENTE CON TODO --

CREATE PROCEDURE [OOZMA_KAPPA].[TraerListadoClienteConTodo]
AS
BEGIN TRANSACTION
SELECT * FROM OOZMA_KAPPA.Cliente
COMMIT;
GO

-- TRAER LISTADO CLIENTE CON FILTROS

CREATE PROCEDURE [OOZMA_KAPPA].[traerListadoClienteConFiltros]
   @nombre varchar(255) = '',
   @apellido varchar(255) = '', 
   @tipo_doc numeric(18,0) = '', 
   @nro_doc numeric(18,0) = '', 
   @mail varchar(255) = ''
AS
BEGIN TRANSACTION
  SELECT * FROM OOZMA_KAPPA.Cliente
     WHERE cliente_nombre LIKE (CASE WHEN @nombre <> '' THEN '%' + @nombre + '%' ELSE cliente_nombre END)
     AND cliente_apellido LIKE (CASE WHEN @apellido <> '' THEN '%' + @apellido + '%' ELSE cliente_apellido END)
     AND cliente_tipo_documento_id LIKE (CASE WHEN @tipo_doc <> '' THEN CAST(@tipo_doc AS numeric(18,0)) ELSE cliente_tipo_documento_id END)
     AND cliente_numero_documento LIKE (CASE WHEN @nro_doc <> '' THEN CAST(@nro_doc AS numeric(18,0)) ELSE cliente_numero_documento END)
     AND cliente_mail LIKE (CASE WHEN @mail <> '' THEN CAST(@mail AS numeric(18,0)) ELSE cliente_mail END)
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