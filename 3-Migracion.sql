----- Migracion -----

-- TABLA BANCO --

BEGIN TRANSACTION
 INSERT INTO [OOZMA_KAPPA].[Banco] (banco_id, banco_nombre, banco_direccion)(
  SELECT DISTINCT Banco_Cogido
	  ,Banco_Nombre
	  ,Banco_Direccion
 FROM gd_esquema.Maestra
 WHERE Banco_Cogido IS NOT NULL);
 COMMIT
 
 -- TABLA ITEM FACTURA --
 
 BEGIN TRANSACTION
 INSERT INTO [OOZMA_KAPPA].[Item_factura] (item_factura_desc, item_factura_costo, item_factura_cant, item_factura_fecha)(
	SELECT Item_Factura_Descr
	  ,Item_Factura_Importe    --como en la tabla maestra solo hay un item factura por factura hago todo uno a uno, no sumo los item y sus importes
	  ,1
	  ,Factura_Fecha
 FROM gd_esquema.Maestra
 WHERE Item_Factura_Descr IS NOT NULL);
 COMMIT
  
 -- TABLA PAIS --
 
 BEGIN TRANSACTION
 
 SET IDENTITY_INSERT [OOZMA_KAPPA].[Pais] ON
 
 INSERT INTO [OOZMA_KAPPA].[Pais] (pais_id, pais_nombre)(
	SELECT DISTINCT Cli_Pais_Codigo,Cli_Pais_Desc FROM gd_esquema.Maestra WHERE Cli_Pais_Codigo IS NOT NULL
	UNION
	SELECT DISTINCT  Cuenta_Pais_Codigo, Cuenta_Pais_Desc FROM gd_esquema.Maestra WHERE Cuenta_Pais_Codigo IS NOT NULL
	);
 
 SET IDENTITY_INSERT [OOZMA_KAPPA].[Pais] OFF
 
 COMMIT

-- TABLA USUARIO -- 

BEGIN TRANSACTION
 
INSERT INTO [OOZMA_KAPPA].[User] ( user_username, user_password, user_fecha_creacion, user_fecha_ultima_modificacion, user_pregunta_secreta, user_respuesta_secreta)(
	SELECT DISTINCT 
	Cli_Nombre + ' ' + Cli_Apellido
	,'04f8996da763b7a969b1028ee3007569eaf3a635486ddab211d512c85b9df8fb'
	,Cuenta_Fecha_Creacion              --HABIAN DICHO QUE NO AGREGUEMOS DIRECTAMENTE LOS STRING, QUE LOS PASEMOS COMO PARAMETRO. COMO SE HACE?
	,Cuenta_Fecha_Creacion
	,'Cual es tu color preferido?'
	,'a4bd1d3a69aa0ea6ffb1298c8c26be4b333526cae7d27f2362f89857157701ce'
	FROM gd_esquema.Maestra	
	WHERE Cli_Nombre IS NOT NULL
	);
	
COMMIT
	
-- TABLA USUARIO ROL --

BEGIN TRANSACTION
 
INSERT INTO [OOZMA_KAPPA].Usuario_rol (usuario_id,rol_id)(
	SELECT
	user_id,
	2
	FROM [OOZMA_KAPPA].[User]
);

COMMIT


 -- TABLA DEPOSITO--
 
 BEGIN TRANSACTION
 
 SET IDENTITY_INSERT [OOZMA_KAPPA].[Deposito] ON
 
 INSERT INTO [OOZMA_KAPPA].[Deposito] (deposito_id, deposito_cuenta_id, deposito_cliente_id, 
                                       deposito_importe, deposito_moneda_id, deposito_tarjeta_id,
                                        deposito_fecha, deposito_costo)(
	SELECT DISTINCT Deposito_Codigo
	, Cuenta_Numero
	, (SELECT cliente_id FROM OOZMA_KAPPA.Cliente, gd_esquema.Maestra WHERE cliente_cuenta_id = Cuenta_Numero)
	, Deposito_Importe
	, 1
	, Tarjeta_Numero
	, Deposito_Fecha
	, 200                  -- NO SE DE DONDE SACARLO VER DESP --
    FROM gd_esquema.Maestra WHERE Deposito_Codigo IS NOT NULL
	
 
 SET IDENTITY_INSERT [OOZMA_KAPPA].[Deposito] OFF
 
 COMMIT



