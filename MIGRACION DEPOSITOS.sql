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