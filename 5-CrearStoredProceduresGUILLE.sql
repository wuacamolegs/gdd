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

Create Procedure listado_estadistico_1 (@fechaDES date, @fechaHAS date)
As
Begin
  Select distinct cliente_id as ClienteID, cliente_apellido+','+cliente_nombre as ApellidoNombre, cuenta_id as CuentaID
	From OOZMA_KAPPA.Cliente Join OOZMA_KAPPA.Transacciones_Pendientes On (transaccion_pendiente_cliente_id = cliente_id)
	                         Join OOZMA_KAPPA.Cuenta On (cuenta_id = transaccion_pendiente_cuenta_id)
	Where cuenta_estado = 0 And CONVERT(varchar(10), transaccion_pendiente_fecha, 103) Between CONVERT(varchar(10), @fechaDES, 103) And CONVERT(varchar(10), @fechaHAS, 103);
End
Go

