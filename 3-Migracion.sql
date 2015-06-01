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

---- TABLA TRANFERENCIA ---

<<<<<<< HEAD
<<<<<<< HEAD
BEGIN TRANSACTION
 
INSERT INTO [OOZMA_KAPPA].[Tranferencia] (tranferencia_origen_cuenta_id, tranferencia_destino_cuenta_id,
											 tranferencia_importe, tranferencia_costo, transferencia_fecha)(
	SELECT Cuenta_Numero, Cuenta_Dest_Numero,  Trans_Importe, Trans_Costo_Trans, Transf_Fecha
	FROM gd_esquema.Maestra	
	WHERE transferencia_fecha IS NOT NULL
	);

COMMIT 
 
---TABLA CHEQUES----
 
 
BEGIN TRANSACTION
=======
=======
>>>>>>> origin/master
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
 
 
   -- TABLA FACTURA --
 
 BEGIN TRANSACTION
 INSERT INTO [OOZMA_KAPPA].[Factura] (factura_numero, factura_importe, factura_fecha, factura_cliente_id, factura_items_id)(
	SELECT Factura_Numero
	, (SELECT SUM(item_factura_costo) FROM OOZMA_KAPPA.Item_factura, gd_esquema.Maestra HAVING item_factura_id = Factura_Numero)
    , Factura_Fecha
	, (SELECT cliente_id FROM OOZMA_KAPPA.Cliente WHERE cliente_nombre = Cli_Nombre AND cliente_apellido = Cli_Apellido AND cliente_fecha_nacimiento = Cli_Fecha_Nac)
	, (SELECT item_factura_id FROM OOZMA_KAPPA.Item_factura, gd_esquema.Maestra WHERE item_factura_id = Factura_Numero)
 FROM gd_esquema.Maestra
 WHERE Factura_Numero IS NOT NULL);
 COMMIT
 
 
  -- TABLA TARJETA --
 
 BEGIN TRANSACTION
 INSERT INTO [OOZMA_KAPPA].[Tarjeta] (tarjeta_id, tarjeta_codigo_seguridad, tarjeta_fecha_emision, tarjeta_vencimiento, tarjeta_emisor_banco_id)(
	SELECT Tarjeta_Numero
	, Tarjeta_Codigo_Seg
    , Tarjeta_Fecha_Emision
	, Tarjeta_Fecha_Vencimiento
	, (SELECT banco_id FROM OOZMA_KAPPA.Banco WHERE banco_id = Banco_Cogido)
 FROM gd_esquema.Maestra
 WHERE Tarjeta_Numero IS NOT NULL);
 COMMIT
<<<<<<< HEAD
=======

>>>>>>> origin/master

  -- TABLA TIPO DOCUMENTO --
 
 BEGIN TRANSACTION
 INSERT INTO [OOZMA_KAPPA].[Tipo_documento] (tipo_documento_id, tipo_documento_descripcion)(
	SELECT Cli_Tipo_Doc_Cod
	, Cli_Tipo_Doc_Desc
 FROM gd_esquema.Maestra
 WHERE Cli_Tipo_Doc_Cod IS NOT NULL);
 COMMIT

  -- TABLA TIPO DOCUMENTO --
 
 BEGIN TRANSACTION
 INSERT INTO [OOZMA_KAPPA].[Tipo_documento] (tipo_documento_id, tipo_documento_descripcion)(
	SELECT Cli_Tipo_Doc_Cod
	, Cli_Tipo_Doc_Desc
 FROM gd_esquema.Maestra
 WHERE Cli_Tipo_Doc_Cod IS NOT NULL);
 COMMIT
>>>>>>> origin/master

INSERT INTO  [OOZMA_KAPPA].[Cheque] (cheque_id, cheque_cuenta_id, cheque_fecha, cheque_importe, cheque_banco_id)
SELECT Cheque_Numero, Cuenta_Numero, Cheque_Fecha, Cheque_Importe, Banco_Cogido
FROM gd_esquema.Maestra	
WHERE cheque_fecha IS NOT NULL
	);

 
------TABLA RETIRO -----

 BEGIN TRANSACTION
 INSERT INTO [OOZMA_KAPPA].[Retiro] (retiro_id, retiro_cuenta_id, retiro_importe, retiro_cheque_id, retiro_fecha)(
	SELECT Retiro_Codigo, Cuenta_Numero, Retiro_Importe, Cheque_Numero, Retiro_Fecha 
 FROM gd_esquema.Maestra
 WHERE Retiro_Fecha IS NOT NULL);
 COMMIT
 
 
 ----TABLA CUENTA---- TERMINAR: VER BLOCK DE NOTAS------
  BEGIN TRANSACTION
 INSERT INTO [OOZMA_KAPPA].[Cuenta] (cuenta_id, cuenta_cliente_id, cuenta_pais_id, cuenta_moneda_id, cuenta_estado, 
		cuenta_saldo, cuenta_fecha_apertura, cuenta_fecha_cierre )(
	SELECT Cuenta_Numero, , Cuenta_Pais_Codigo, , Cuenta_Estado, , Cuenta_Fecha_Creacion, Cuenta_Fecha_Cierre
 FROM gd_esquema.Maestra
 WHERE Cuenta_Numero IS NOT NULL);
 COMMIT