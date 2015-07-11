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
   If (@cuenta_origen = @cuenta_destino)
      Begin
        Set @costo = 0;
      End
   Else 
      Begin
          Select @costo = tipo_cuenta_costo_transferencia 
              From OOZMA_KAPPA.Cuenta, OOZMA_KAPPA.Tipo_cuenta 
              Where cuenta_id = @cuenta_origen
      End
   Insert Into OOZMA_KAPPA.Transferencia(transferencia_origen_cuenta_id, transferencia_destino_cuenta_id, transferencia_importe, transferencia_costo ,transferencia_fecha)
          Values(@cuenta_origen, @cuenta_destino, @cuenta_importe, @costo, @cuenta_fecha)
End
Go

-- LISTADO ESTADISTICO (1) : Clientes que alguna de sus cuentas fueron inhabilitadas por no pagar los costos de transacción --

Create Procedure [OOZMA_KAPPA].listado_transacciones_superadas (@fechaDES date, @fechaHAS date)
As
Begin
  Select distinct cliente_id as ClienteID, cliente_apellido as Apellido, cliente_nombre as Nombre, historial_cuenta_id as CuentaID
	From OOZMA_KAPPA.Cliente Join OOZMA_KAPPA.Historial_clientes On (cliente_id = historial_cliente_id)
	Where historial_transacciones_superadas = 1
End
Go

Drop Procedure [OOZMA_KAPPA].listado_transacciones_superadas

-- LISTADO ESTADISTICO (2) : Clientes con mayor cantidad de comisiones facturadas en todas sus cuentas

Create Procedure [OOZMA_KAPPA].mayor_cant_comisiones (@fechaDES date, @fechaHAS date)
As
Begin
Select cliente_id, SUM(item_factura_costo)Comision
	From OOZMA_KAPPA.Cliente Join OOZMA_KAPPA.Factura On (cliente_id = factura_cliente_id)
	                         Join OOZMA_KAPPA.Item_factura On (factura_numero = item_factura_numero_factura)
    Where CONVERT(varchar(10), factura_fecha, 103) Between CONVERT(varchar(10), @fechaDES, 103) And CONVERT(varchar(10), @fechaHAS, 103)
    Group By cliente_id
    Order By SUM(item_factura_costo) DESC
End
Go

-- LISTADO ESTADISTICO (3) : Clientes con mayor cantidad de transacciones realizadas entre cuentas propias --
	
	
Create Procedure [OOZMA_KAPPA].cliente_con_mayor_cant_transacciones (@fechaDES date, @fechaHAS date)
As
Begin
	Select cliente_id, SUM(Transacciones)CantidadTotalDeTransacciones
	   From (Select cliente_id, c.cuenta_id, (Retiros+Transferencias+Depositos) as Transacciones
	            From OOZMA_KAPPA.Cliente Join OOZMA_KAPPA.Cuenta c On (cliente_id = cuenta_cliente_id)
	                                     Join (Select cuenta_id, COUNT(retiro_id)Retiros 
										          From OOZMA_KAPPA.Cuenta Join OOZMA_KAPPA.Retiro On (cuenta_id = retiro_cuenta_id) 
										          Where CONVERT(varchar(10), retiro_fecha, 103) Between CONVERT(varchar(10), @fechaDES, 103) And CONVERT(varchar(10), @fechaHAS, 103)
										          Group By cuenta_id)R On (c.cuenta_id = R.cuenta_id)
							             Join (Select cuenta_id, COUNT(transferencia_id)Transferencias
									            	From OOZMA_KAPPA.Cuenta Join OOZMA_KAPPA.Transferencia On (cuenta_id = transferencia_origen_cuenta_id)
									            	Where CONVERT(varchar(10), transferencia_fecha, 103) Between CONVERT(varchar(10), @fechaDES, 103) And CONVERT(varchar(10), @fechaHAS, 103)
									            	Group By cuenta_id)T On (c.cuenta_id = T.cuenta_id)
							             Join (Select cuenta_id, COUNT(deposito_id)Depositos
									            	From OOZMA_KAPPA.Cuenta Join OOZMA_KAPPA.Deposito On (cuenta_id = deposito_cuenta_id)
									            	Where CONVERT(varchar(10), deposito_fecha, 103) Between CONVERT(varchar(10), @fechaDES, 103) And CONVERT(varchar(10), @fechaHAS, 103)
									            	Group By cuenta_id)D On (c.cuenta_id = D.cuenta_id))Menjunje
      
	   Group By cliente_id
	   Order By CantidadTotalDeTransacciones DESC
	
End
Go

-- LISTADO ESTADISTICO (4) : Paises con mayor cantidad de movimientos tanto ingresos como egresos --


Create Procedure [OOZMA_KAPPA].paises_mayor_movimientos (@fechaDES date, @fechaHAS date)
As
Begin
Select d.Pais, (Depositado+Retirado+TransferenciaEnviada+TransferenciaRecivida)Ingresos_mas_Egresos
	From (Select cliente_pais_residente_id as Pais, SUM(deposito_importe)Depositado
	         From OOZMA_KAPPA.Cliente Join OOZMA_KAPPA.Deposito On (cliente_id = deposito_cliente_id)
	         Where CONVERT(varchar(10), deposito_fecha, 103) Between CONVERT(varchar(10), @fechaDES, 103) And CONVERT(varchar(10), @fechaHAS, 103)
	         Group By cliente_pais_residente_id) d Join (Select cuenta_pais_id as Pais, SUM(retiro_importe)Retirado
	                                                        From OOZMA_KAPPA.Cuenta Join OOZMA_KAPPA.Retiro On (cuenta_id = retiro_cuenta_id)
	                                                        Where CONVERT(varchar(10), retiro_fecha, 103) Between CONVERT(varchar(10), @fechaDES, 103) And CONVERT(varchar(10), @fechaHAS, 103)
	                                                        Group By cuenta_pais_id) r On (d.Pais = r.Pais)
	                                               Join (Select c1.cuenta_pais_id as Pais, SUM(transferencia_importe)TransferenciaEnviada
	                                                        From OOZMA_KAPPA.Transferencia Join OOZMA_KAPPA.Cuenta c1 On (transferencia_origen_cuenta_id = c1.cuenta_id)
	                                                                                       Join OOZMA_KAPPA.Cuenta c2 On (transferencia_destino_cuenta_id = c2.cuenta_id)
	                                                        Where c1.cuenta_pais_id != c2.cuenta_pais_id And (CONVERT(varchar(10), transferencia_fecha, 103) Between CONVERT(varchar(10), @fechaDES, 103) And CONVERT(varchar(10), @fechaHAS, 103))
	                                                        Group By c1.cuenta_pais_id) te On (d.Pais = te.Pais)
	                                               Join (Select c2.cuenta_pais_id as Pais, SUM(transferencia_importe)TransferenciaRecivida
	                                                        From OOZMA_KAPPA.Transferencia Join OOZMA_KAPPA.Cuenta c1 On (transferencia_origen_cuenta_id = c1.cuenta_id)
	                                                                                       Join OOZMA_KAPPA.Cuenta c2 On (transferencia_destino_cuenta_id = c2.cuenta_id)
	                                                        Where c1.cuenta_pais_id != c2.cuenta_pais_id And (CONVERT(varchar(10), transferencia_fecha, 103) Between CONVERT(varchar(10), @fechaDES, 103) And CONVERT(varchar(10), @fechaHAS, 103))
	                                                        Group By c2.cuenta_pais_id) tr On (d.Pais = tr.Pais)
	  Order By Ingresos_mas_Egresos DESC
End
Go

-- LISTADO ESTADISTICO (5) : Total facturado para los distintos tipos de cuentas --


Create Procedure [OOZMA_KAPPA].total_facturado_tipo_de_cuentas (@fechaDES date, @fechaHAS date)
As
Begin
   Select cuenta_tipo_cuenta_id, SUM(factura_importe)TotalFacturado
      From OOZMA_KAPPA.Cuenta Join OOZMA_KAPPA.Cliente On (cliente_id = cuenta_cliente_id)
                           Join OOZMA_KAPPA.Factura On (cliente_id = factura_cliente_id)
      Where CONVERT(varchar(10), factura_fecha, 103) Between CONVERT(varchar(10), @fechaDES, 103) And CONVERT(varchar(10), @fechaHAS, 103)
      Group By cuenta_tipo_cuenta_id
End
Go    