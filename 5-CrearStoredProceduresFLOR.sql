----- Crear Stored Procedures -----


CREATE PROCEDURE [OOZMA_KAPPA].traerListadoRolesCompleto
AS 
	SELECT rol_id , rol_nombre FROM OOZMA_KAPPA.Rol;
GO




----SP insertDeposito--------//deposito_moneda_id es por default 1 (Dólar)
CREATE PROCEDURE [OOZMA_KAPPA].[insertDeposito] 
	@deposito_cuenta_id numeric (18,0),
	@deposito_cliente_id numeric (18,0),
	@deposito_importe numeric (18,0),
	@deposito_tarjeta_id numeric (18,0),
	@deposito_fecha datetime
AS
	INSERT INTO OOZMA_KAPPA.Deposito(deposito_cuenta_id, deposito_cliente_id, deposito_importe, deposito_tarjeta_id, deposito_fecha)
	VALUES (@deposito_cuenta_id, @deposito_cliente_id, @deposito_importe, @deposito_tarjeta_id, @deposito_fecha);
	
GO
	


----SP traerListadoMonedaCompleto----
CREATE PROCEDURE [OOZMA_KAPPA].[traerListadoMonedaCompleto]
AS
	SELECT moneda_id as id_Moneda, moneda_nombre as Moneda FROM OOZMA_KAPPA.Moneda;
GO


