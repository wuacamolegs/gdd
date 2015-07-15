----- Crear Stored Procedures -----
-- TRAER CUENTA DESTINO DESDE UN CLIENTE DESTINO "TRANSFERENCIAS ENTRE CUENTAS"  --


CREATE PROCEDURE [OOZMA_KAPPA].[traerListadoCuentaPorCliente_NoCerradas]
	@cliente_id numeric(18,0), @fecha date 
AS
Begin	
	SELECT cuenta_id as cuenta_numero, cuenta_estado, cuenta_saldo, cuenta_fecha_apertura as fecha_apertura, cuenta_fecha_cierre as fecha_cierre 
	   FROM OOZMA_KAPPA.Cuenta 
	   WHERE cuenta_cliente_id = @cliente_id And CONVERT(varchar(10), cuenta_fecha_cierre, 103) > CONVERT(varchar(10), @fecha, 103)
End	                                         	                                        
GO

-- INSERTAR LA NUEVA TRANSFRRENCIA --

CREATE Procedure [OOZMA_KAPPA].insertTransferencia 
(@cuenta_origen numeric(18,0), @cuenta_destino numeric(18,0), @cuenta_importe numeric(18,2), @cuenta_fecha dateTime)
As
Begin
   Declare @costo numeric(18,2)
   If exists (select * from OOZMA_KAPPA.Cuenta C1, OOZMA_KAPPA.Cuenta C2 
		where c1.cuenta_id = @cuenta_origen and C2.cuenta_id = @cuenta_destino and C1.cuenta_cliente_id = C2.cuenta_cliente_id and C1.cuenta_id != C2.cuenta_id)
      Begin
        Set @costo = 0;
      End
   Else 
      Begin
          Select @costo = tipo_cuenta_costo_transferencia*@cuenta_importe 
              From OOZMA_KAPPA.Cuenta, OOZMA_KAPPA.Tipo_cuenta 
              Where cuenta_id = @cuenta_origen
      End
   Insert Into OOZMA_KAPPA.Transferencia(transferencia_origen_cuenta_id, transferencia_destino_cuenta_id, transferencia_importe, transferencia_costo ,transferencia_fecha)
          Values(@cuenta_origen, @cuenta_destino, @cuenta_importe, @costo, @cuenta_fecha)
End
Go

-- LISTADO ESTADISTICO (1) : Clientes que alguna de sus cuentas fueron inhabilitadas por no pagar los costos de transacción --

Create Procedure [OOZMA_KAPPA].TraerListadoClientesCuentasDeshabilitadasPorPendientesDeActivacion 
(@fechaDES date, @fechaHAS date)
As
Begin
  Select distinct TOP 5 cliente_apellido+','+cliente_nombre as cliente_nombre, cuenta_id as Cuenta
	From OOZMA_KAPPA.Cliente Join OOZMA_KAPPA.Transacciones_Pendientes On (transaccion_pendiente_cliente_id = cliente_id)
	                         Join OOZMA_KAPPA.Cuenta On (cuenta_id = transaccion_pendiente_cuenta_id)
	Where cuenta_estado = 0 And CONVERT(varchar(10), transaccion_pendiente_fecha, 103) Between CONVERT(varchar(10), @fechaDES, 103) And CONVERT(varchar(10), @fechaHAS, 103)
End
Go

-- LISTADO ESTADISTICO (2) : Clientes con mayor cantidad de comisiones facturadas en todas sus cuentas

Create Procedure [OOZMA_KAPPA].TraerListadoClientesConMayorCantidadDeComisionesFacturadasEnTodasSusCuentas 
(@fechaDES date, @fechaHAS date)
As
Begin
Select TOP 5 cliente_apellido+', '+cliente_nombre as cliente_nombre, COUNT(*) as Cantidad
	From OOZMA_KAPPA.Cliente, OOZMA_KAPPA.Factura, OOZMA_KAPPA.Item_factura 
	where cliente_id = factura_cliente_id and factura_numero = item_factura_numero_factura and
    item_factura_desc like 'Comisión%' and
    CONVERT(varchar(10), factura_fecha, 103) Between CONVERT(varchar(10), @fechaDES, 103) And CONVERT(varchar(10), @fechaHAS, 103)    
    Group By cliente_apellido, cliente_nombre
    Order By Cantidad DESC
End
Go

-- LISTADO ESTADISTICO (3) : Clientes con mayor cantidad de transacciones realizadas entre cuentas propias --
	
	
CREATE PROCEDURE [OOZMA_KAPPA].TraerListadoClientesConMayorCantidadDeTransaccionesRealizadasEntreCuentasPropias 
(@fechaDES DATE, @fechaHAS DATE)
AS
BEGIN
SELECT TOP 5 cliente_apellido+', '+cliente_nombre AS cliente_nombre, COUNT(*) AS Cantidad
FROM OOZMA_KAPPA.Cliente, OOZMA_KAPPA.Cuenta C1, OOZMA_KAPPA.Cuenta C2, OOZMA_KAPPA.Transferencia
WHERE cliente_id = c1.cuenta_cliente_id
AND cliente_id = C2.cuenta_cliente_id  
AND C1.cuenta_id != C2.cuenta_id
AND transferencia_destino_cuenta_id = C1.cuenta_id 
AND transferencia_origen_cuenta_id = C2.cuenta_id
AND CONVERT(varchar(10), transferencia_fecha, 103)Between CONVERT(varchar(10), @fechaDES, 103) And CONVERT(varchar(10), @fechaHAS, 103)
GROUP BY cliente_apellido, cliente_nombre
ORDER BY Cantidad DESC							  
END
GO

-- LISTADO ESTADISTICO (4) : Paises con mayor cantidad de movimientos tanto ingresos como egresos --


Create Procedure [OOZMA_KAPPA].TraerListadoPaisesConMayorCantidadDeMovimientosTantoIngresosComoEgresos 
(@fechaDES date, @fechaHAS date)
As
Begin
Select TOP 5 pais_nombre, (Depositados+Retirados+TransferenciasEnviadas+TransferenciasRecibidas) as cantidad_movimientos
	From (Select cliente_pais_residente_id as Pais, COUNT(deposito_importe) as Depositados
	         From OOZMA_KAPPA.Cliente Join OOZMA_KAPPA.Deposito On (cliente_id = deposito_cliente_id)
	         Where CONVERT(varchar(10), deposito_fecha, 103) Between CONVERT(varchar(10), @fechaDES, 103) And CONVERT(varchar(10), @fechaHAS, 103)
	         Group By cliente_pais_residente_id) d Join (Select cuenta_pais_id as Pais, COUNT(retiro_importe)Retirados
	                                                        From OOZMA_KAPPA.Cuenta Join OOZMA_KAPPA.Retiro On (cuenta_id = retiro_cuenta_id)
	                                                        Where CONVERT(varchar(10), retiro_fecha, 103) Between CONVERT(varchar(10), @fechaDES, 103) And CONVERT(varchar(10), @fechaHAS, 103)
	                                                        Group By cuenta_pais_id) r On (d.Pais = r.Pais)
	                                               Join (Select c1.cuenta_pais_id as Pais, COUNT(transferencia_importe)TransferenciasEnviadas
	                                                        From OOZMA_KAPPA.Transferencia Join OOZMA_KAPPA.Cuenta c1 On (transferencia_origen_cuenta_id = c1.cuenta_id)
	                                                                                       Join OOZMA_KAPPA.Cuenta c2 On (transferencia_destino_cuenta_id = c2.cuenta_id)
	                                                        Where c1.cuenta_pais_id != c2.cuenta_pais_id And (CONVERT(varchar(10), transferencia_fecha, 103) Between CONVERT(varchar(10), @fechaDES, 103) And CONVERT(varchar(10), @fechaHAS, 103))
	                                                        Group By c1.cuenta_pais_id) te On (d.Pais = te.Pais)
	                                               Join (Select c2.cuenta_pais_id as Pais, COUNT(transferencia_importe)TransferenciasRecibidas
	                                                        From OOZMA_KAPPA.Transferencia Join OOZMA_KAPPA.Cuenta c1 On (transferencia_origen_cuenta_id = c1.cuenta_id)
	                                                                                       Join OOZMA_KAPPA.Cuenta c2 On (transferencia_destino_cuenta_id = c2.cuenta_id)
	                                                        Where c1.cuenta_pais_id != c2.cuenta_pais_id And (CONVERT(varchar(10), transferencia_fecha, 103) Between CONVERT(varchar(10), @fechaDES, 103) And CONVERT(varchar(10), @fechaHAS, 103))
	                                                        Group By c2.cuenta_pais_id) tr On (d.Pais = tr.Pais)
	                                               Join Pais On (d.Pais = pais_id)
	  Order By cantidad_movimientos DESC
End
Go

-- LISTADO ESTADISTICO (5) : Total facturado para los distintos tipos de cuentas --


Create Procedure [OOZMA_KAPPA].TraerListadoTotalFacturadoParaLosDistintosTiposDeCuentas 
(@fechaDES date, @fechaHAS date)
As
Begin
   Select cuenta_tipo_cuenta_id, SUM(factura_importe) as TotalFacturado
      From OOZMA_KAPPA.Cuenta Join OOZMA_KAPPA.Cliente On (cliente_id = cuenta_cliente_id)
                           Join OOZMA_KAPPA.Factura On (cliente_id = factura_cliente_id)
      Where CONVERT(varchar(10), factura_fecha, 103) Between CONVERT(varchar(10), @fechaDES, 103) And CONVERT(varchar(10), @fechaHAS, 103)
      Group By cuenta_tipo_cuenta_id
End
Go    