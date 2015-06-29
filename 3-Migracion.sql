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

 
 -- TABLA PAIS --
 
 BEGIN TRANSACTION
 
 SET IDENTITY_INSERT [OOZMA_KAPPA].[Pais] ON
 
 INSERT INTO [OOZMA_KAPPA].[Pais] (pais_id, pais_nombre)(
	SELECT DISTINCT Cli_Pais_Codigo,Cli_Pais_Desc FROM gd_esquema.Maestra WHERE Cli_Pais_Codigo IS NOT NULL 
	UNION
	SELECT DISTINCT  Cuenta_Pais_Codigo, Cuenta_Pais_Desc FROM gd_esquema.Maestra  WHERE Cuenta_Pais_Codigo IS NOT NULL 
	);
 
 SET IDENTITY_INSERT [OOZMA_KAPPA].[Pais] OFF
 
 COMMIT

-- TABLA USUARIO --   CAMBIE EL USERNAME POR EL DNI, CREO QUE LO HABIAMOS DICHO ASI

BEGIN TRANSACTION
 
INSERT INTO [OOZMA_KAPPA].[Usuario] ( usuario_username, usuario_nombreYapellido, usuario_password, usuario_fecha_creacion, usuario_fecha_ultima_modificacion, usuario_pregunta_secreta, usuario_respuesta_secreta)(
	SELECT DISTINCT 
	Cli_Nro_Doc
	,Cli_Nombre + ' ' + Cli_Apellido
	,'ECE6128060FCDA0AFC43C2D59109C410E89DE2BEF602D70ED62C0640FD795970'  --CONTRASE;A USER
	,Cuenta_Fecha_Creacion              --HABIAN DICHO QUE NO AGREGUEMOS DIRECTAMENTE LOS STRING, QUE LOS PASEMOS COMO PARAMETRO. COMO SE HACE?
	,Cuenta_Fecha_Creacion
	,'Cual es tu color preferido?'
	,'AF4C20351356D258C57B16291CCEB8BAEE3D4DEE410061EA66D7C636EFE075CC'
	FROM gd_esquema.Maestra	
	WHERE Cli_Nombre IS NOT NULL
	);
	
COMMIT

 -- TABLA CLIENTE --    ANTES VA USUARIO
 
 -- CREO QUE TENDRIAMOS QUE TENER CLIENTE NOMBRE Y QUE CONTENGA NOMBRE Y APELLIDO. O SEPARADOS, PERO QUE CONCUERDE EN USUARIO ASI ESTAN CON EL MISMO FORMATO
 
 BEGIN TRANSACTION
 
 INSERT INTO [OOZMA_KAPPA].[Cliente] (cliente_usuario_id, cliente_apellido, cliente_nombre, cliente_fecha_nacimiento,
				cliente_tipo_documento_id, cliente_numero_documento, cliente_pais_residente_id,
				 cliente_calle, cliente_numero, cliente_piso, cliente_depto, cliente_mail)(
	SELECT DISTINCT 0,
	Cli_Apellido, Cli_Nombre, Cli_Fecha_Nac, Cli_Tipo_Doc_Cod, Cli_Nro_Doc, Cli_Pais_Codigo, Cli_Dom_Calle, Cli_Dom_Nro,
	Cli_Dom_Piso, Cli_Dom_Depto,Cli_Mail
	FROM gd_esquema.Maestra
	WHERE Cuenta_Numero IS NOT NULL);
	
 COMMIT
 
 BEGIN TRANSACTION
 
	UPDATE OOZMA_KAPPA.Cliente
	SET cliente_usuario_id = (SELECT DISTINCT usuario_id FROM OOZMA_KAPPA.Usuario WHERE (cliente_numero_documento = usuario_username))
	
COMMIT

	--UN CLIENTE PUEDE TENER ASOCIADAS UNA O VARIAS CUENTAS.. SE PODRIA HACER UNA INTERMEDIA QUE SEA CUENTA - CLIENTE PARA TENER TIPO UN INDICE.
	--SACO CLIENTE_CUENTA DE TABLA CLIENTE
 
  -- TABLA ITEM FACTURA -- ANTES TIENE QUE IR CLIENTE
 
 BEGIN TRANSACTION
	INSERT INTO [OOZMA_KAPPA].[Item_factura] (item_factura_desc, item_factura_costo, item_factura_numero_factura,item_factura_cantidad)(
	SELECT Item_Factura_Descr, Item_Factura_Importe, Factura_Numero, 1 FROM gd_esquema.Maestra WHERE Item_Factura_Descr is not null);
 COMMIT
 
 
 ----TABLA CUENTA----   ANTES TIENE QUE IR CLIENTE
 
 BEGIN TRANSACTION
  
 SET IDENTITY_INSERT [OOZMA_KAPPA].[Cuenta] ON
  
 INSERT INTO [OOZMA_KAPPA].[Cuenta](cuenta_id, 
	cuenta_cliente_id, 
	cuenta_pais_id,
	cuenta_tipo_cuenta_id, 
	cuenta_saldo, cuenta_fecha_apertura, cuenta_fecha_cierre )(
	SELECT DISTINCT Cuenta_Numero
	,(SELECT cliente_id FROM OOZMA_KAPPA.Cliente WHERE Cli_Nro_Doc = cliente_numero_documento)
	,Cuenta_Pais_Codigo
	,4 --CONSIDERAMOS TODAS SON GRATUITAS (segun mail), y la gratuita tiene id 4
	,50000  --COMO NO ESTA EL MONTO DE CADA CUENTA CONSIDEREMOS ESTE VALOR PARA TODAS.
	,Cuenta_Fecha_Creacion   --cuenta moneda y estado les puse default 1(dolar) y "Habilitada"
	,(SELECT DATEADD(DAY,tipo_cuenta_dias_vigencia,Cuenta_Fecha_Creacion)FROM OOZMA_KAPPA.Tipo_cuenta WHERE tipo_cuenta_id = 4)    --segun el tipo cuenta la fecha de cierre
 FROM gd_esquema.Maestra
 WHERE Cuenta_Numero IS NOT NULL);
   
 SET IDENTITY_INSERT [OOZMA_KAPPA].[Cuenta] OFF
  
 COMMIT 
 

---- TABLA TRANFERENCIA ---

BEGIN TRANSACTION
 
INSERT INTO [OOZMA_KAPPA].[Transferencia] (transferencia_origen_cuenta_id, transferencia_destino_cuenta_id,
										transferencia_importe, transferencia_costo, transferencia_fecha)(
	SELECT Cuenta_Numero, Cuenta_Dest_Numero,  Trans_Importe, Trans_Costo_Trans, Transf_Fecha
	FROM gd_esquema.Maestra	
	WHERE transf_fecha IS NOT NULL
	);

COMMIT

  -- TABLA DEPOSITO--  NECESITA TABLA CLIENTES ANTES
  
 BEGIN TRANSACTION
 
 SET IDENTITY_INSERT [OOZMA_KAPPA].[Deposito] ON
 
 INSERT INTO [OOZMA_KAPPA].[Deposito] (deposito_id, deposito_cuenta_id, deposito_cliente_id, 
                                       deposito_importe, deposito_moneda_id, deposito_tarjeta_id,
                                        deposito_fecha)(
	SELECT DISTINCT Deposito_Codigo
	, Cuenta_Numero
	, 0
	, Deposito_Importe
	, 1
	, Tarjeta_Numero
	, Deposito_Fecha
    FROM gd_esquema.Maestra WHERE Deposito_Codigo IS NOT NULL);
	
 
 SET IDENTITY_INSERT [OOZMA_KAPPA].[Deposito] OFF
 
 COMMIT
 
BEGIN TRANSACTION
 
	UPDATE OOZMA_KAPPA.Deposito
	SET deposito_cliente_id = (SELECT DISTINCT cuenta_cliente_id FROM OOZMA_KAPPA.Cuenta WHERE (cuenta_id = deposito_cuenta_id))
	
COMMIT


--- TABLA EMISOR ---


BEGIN TRANSACTION

INSERT INTO [OOZMA_KAPPA].[Emisor] (emisor_descripcion) (
	SELECT DISTINCT Tarjeta_Emisor_Descripcion FROM gd_esquema.Maestra 
	WHERE Tarjeta_Emisor_Descripcion IS NOT NULL);
COMMIT	
	
  -- TABLA TARJETA --
 
 BEGIN TRANSACTION
 
 SET IDENTITY_INSERT [OOZMA_KAPPA].[Tarjeta] ON
 
 INSERT INTO [OOZMA_KAPPA].[Tarjeta] (tarjeta_id, tarjeta_codigo_seguridad, tarjeta_fecha_emision, tarjeta_vencimiento, tarjeta_emisor, tarjeta_cliente_id)(
	SELECT DISTINCT  CAST(Tarjeta_Numero AS numeric(18,0))
	, Tarjeta_Codigo_Seg
    , Tarjeta_Fecha_Emision
	, Tarjeta_Fecha_Vencimiento
	, Tarjeta_Emisor_Descripcion
	, (select cliente_id from [OOZMA_KAPPA].[Cliente] where Cli_Nro_Doc = cliente_numero_documento)
	FROM gd_esquema.Maestra
 WHERE Tarjeta_Numero IS NOT NULL);
 
 SET IDENTITY_INSERT [OOZMA_KAPPA].[Tarjeta] OFF
 
 COMMIT
 
 -- TABLA TIPO DOCUMENTO --
 
 BEGIN TRANSACTION
 
 SET IDENTITY_INSERT [OOZMA_KAPPA].[Tipo_documento] ON
 
 INSERT INTO [OOZMA_KAPPA].[Tipo_documento] (tipo_documento_id, tipo_documento_descripcion)(
	SELECT DISTINCT Cli_Tipo_Doc_Cod
	, Cli_Tipo_Doc_Desc
 FROM gd_esquema.Maestra
 WHERE Cli_Tipo_Doc_Cod IS NOT NULL);
 
 SET IDENTITY_INSERT [OOZMA_KAPPA].[Tipo_documento] OFF
 
 COMMIT
 
 --SE AGREGA SOLO EL PASAPORTE.. DNI CI LC LE SE AGREGARON MANUALMENTE. TODOS EN LA TABLA MAESTRA TIENEN PASAPORTE 
 
 --TABLA CHEQUE --

--el cheuqe lo hace un cliente para si mismo, entonces el cliente destino es esa misma persona que lo emite. 

 BEGIN TRANSACTION  --NECESITA CUENTA y CLIENTE ANTES
 
 SET IDENTITY_INSERT [OOZMA_KAPPA].[Cheque] ON

 INSERT INTO  [OOZMA_KAPPA].[Cheque] (cheque_id, cheque_cuenta_id, cheque_fecha, cheque_importe, cheque_banco_id, cheque_destino_cliente_id)(
 SELECT Cheque_Numero
 , Cuenta_Numero
 , Cheque_Fecha
 , Cheque_Importe
 , Banco_Cogido
 , (SELECT cuenta_cliente_id FROM OOZMA_KAPPA.Cuenta WHERE Cuenta_Numero = cuenta_id)
 FROM gd_esquema.Maestra	
 WHERE cheque_fecha IS NOT NULL);
 
 SET IDENTITY_INSERT [OOZMA_KAPPA].[Cheque] OFF
 
 COMMIT 
 
------TABLA RETIRO -----

 BEGIN TRANSACTION
 
 SET IDENTITY_INSERT [OOZMA_KAPPA].[Retiro] ON
 
 INSERT INTO [OOZMA_KAPPA].[Retiro] (retiro_id, retiro_cuenta_id, retiro_importe, retiro_cheque_id, retiro_fecha)(
	SELECT Retiro_Codigo, Cuenta_Numero, Retiro_Importe, Cheque_Numero, Retiro_Fecha 
 FROM gd_esquema.Maestra
 WHERE Retiro_Codigo IS NOT NULL);
 
 SET IDENTITY_INSERT [OOZMA_KAPPA].[Retiro] OFF
 
 COMMIT
 

  -- TABLA FACTURA --  NECESITA ITEM FACTURA, CLIENTES ANTES
 
 BEGIN TRANSACTION
 
 SET IDENTITY_INSERT [OOZMA_KAPPA].[Factura] ON
 
 INSERT INTO [OOZMA_KAPPA].[Factura] (factura_numero,factura_fecha, factura_cliente_id, factura_importe)(
	SELECT Factura_Numero
	,Factura_Fecha
	,(SELECT cliente_id FROM OOZMA_KAPPA.Cliente WHERE Cli_Nro_Doc = cliente_numero_documento)
	,Item_Factura_Importe
	FROM  gd_esquema.Maestra WHERE Factura_Numero IS NOT NULL);
 
 SET IDENTITY_INSERT [OOZMA_KAPPA].[Factura] OFF 
 
 COMMIT


-- TABLA USUARIO ROL -- completo todos los clientes

BEGIN TRANSACTION

INSERT INTO [OOZMA_KAPPA].Usuario_rol(usuario_id,usuario_username, rol_id)(
SELECT usuario_id, usuario_username, rol_id FROM OOZMA_KAPPA.Usuario, OOZMA_KAPPA.Rol WHERE rol_nombre = 'Cliente' );

COMMIT

-- CREACION DE USUARIOS DEFAULT admin --

--un usuario con username ADMIN y contrase;a w23e
-- y varios admin mas por lo que dice el enunciado. tomamos los primeros 5 usuarios de la tabla usuario y los hacemos administradores tambien.

BEGIN TRANSACTION   

INSERT INTO [OOZMA_KAPPA].Usuario
(usuario_username,usuario_nombreYapellido,usuario_password,usuario_fecha_creacion,usuario_fecha_ultima_modificacion, usuario_pregunta_secreta , usuario_respuesta_secreta)
 (SELECT 123,
  'administrador general',
  '52D77462B24987175C8D7DAB901A5967E927FFC8D0B6E4A234E07A4AEC5E3724', --contrase;a: w23e
  GETDATE(),GETDATE(),
  'Color preferido?',
  'AF4C20351356D258C57B16291CCEB8BAEE3D4DEE410061EA66D7C636EFE075CC'); --RESPUESTA SECRETA azul
  
COMMIT

--YA TODOS LOS USUARIOS DE LA TABLA MAESTRA ESTAN CREADOS CON CONTRASENA : user Y RESPUESTA SECRETA: azul ya encriptadas


-- TABLA USUARIO ROL --

BEGIN TRANSACTION  --agrego usuario rol del admin

INSERT INTO [OOZMA_KAPPA].Usuario_rol(usuario_id,usuario_username,rol_id) (SELECT DISTINCT usuario_id,123,1 FROM OOZMA_KAPPA.Usuario WHERE usuario_username = 123);

COMMIT

BEGIN TRANSACTION  --agrego rol cliente al admin

INSERT INTO [OOZMA_KAPPA].Usuario_rol(usuario_id,usuario_username,rol_id) (SELECT DISTINCT usuario_id,123,2 FROM OOZMA_KAPPA.Usuario WHERE usuario_username = 123);

COMMIT
