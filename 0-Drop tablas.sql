--- DROP PROCEDURE --
BEGIN TRANSACTION
USE [GD1C2015]
GO
DROP PROCEDURE [OOZMA_KAPPA].[InsertItem_Factura]
GO
DROP PROCEDURE [OOZMA_KAPPA].[insertRetiro_RetornarID]
GO
DROP PROCEDURE [OOZMA_KAPPA].[insertRol_Funcionalidad]
GO
DROP PROCEDURE [OOZMA_KAPPA].[insertRol_RetornarID]
GO
DROP PROCEDURE [OOZMA_KAPPA].[insertTarjeta]
GO
DROP PROCEDURE [OOZMA_KAPPA].[insertTransferencia]
GO
DROP PROCEDURE [OOZMA_KAPPA].[mayor_cant_comisiones]
GO
DROP PROCEDURE [OOZMA_KAPPA].[listado_estadistico_1]
GO
DROP PROCEDURE [OOZMA_KAPPA].[traerListadoMonedaCompleto]
GO
DROP PROCEDURE [OOZMA_KAPPA].[traerListadoPaisesCompleto]
GO
DROP PROCEDURE [OOZMA_KAPPA].[paises_mayor_movimientos]
GO
DROP PROCEDURE [OOZMA_KAPPA].[cliente_con_mayor_cant_transacciones]
GO
DROP PROCEDURE [OOZMA_KAPPA].[deleteRol]
GO
DROP PROCEDURE [OOZMA_KAPPA].[deshabilitarRol]
GO
DROP PROCEDURE [OOZMA_KAPPA].[traerListadoRoles]
GO
DROP PROCEDURE [OOZMA_KAPPA].[traerListadoRolesCompleto]
GO
DROP PROCEDURE [OOZMA_KAPPA].[traerListadoRolesConFiltros]
GO
DROP PROCEDURE [OOZMA_KAPPA].[traerListadoRolesPorId_Usuario]
GO
DROP PROCEDURE [OOZMA_KAPPA].[traerListadoRolesPorNombre]
GO
DROP PROCEDURE [OOZMA_KAPPA].[updateRol]
GO
DROP PROCEDURE [OOZMA_KAPPA].[deleteTarjeta]
GO
DROP PROCEDURE [OOZMA_KAPPA].[traerListadoTarjetaActivasPorClienteID]
GO
DROP PROCEDURE [OOZMA_KAPPA].[updateTarjeta]
GO
DROP PROCEDURE [OOZMA_KAPPA].[InsertCuenta]
GO
DROP PROCEDURE [OOZMA_KAPPA].[traerListadoTipoCuentaCompleto]
GO
DROP PROCEDURE [OOZMA_KAPPA].[UpdateCuenta]
GO
DROP PROCEDURE [OOZMA_KAPPA].[TraerListadoTipoDocumento]
GO
DROP PROCEDURE [OOZMA_KAPPA].[total_facturado_tipo_de_cuentas]
GO
DROP PROCEDURE [OOZMA_KAPPA].[traerListadoBancoCompleto]
GO
DROP PROCEDURE [OOZMA_KAPPA].[TraerListadoClienteCantidadSuscripcionesPendientesAFacturarPorClienteIDYCuentaID]
GO
DROP PROCEDURE [OOZMA_KAPPA].[traerListadoClienteCompleto]
GO
DROP PROCEDURE [OOZMA_KAPPA].[TraerListadoClienteModificacionesTCAFacturar]
GO
DROP PROCEDURE [OOZMA_KAPPA].[traerListadoClientePorClienteID]
GO
DROP PROCEDURE [OOZMA_KAPPA].[traerListadoClientePorUsuarioID]
GO
DROP PROCEDURE [OOZMA_KAPPA].[TraerListadoClienteSuscripcionesPendientesAFacturarPorClienteIDYCuentaID]
GO
DROP PROCEDURE [OOZMA_KAPPA].[TraerListadoClienteTransferenciasAFacturar]
GO
DROP PROCEDURE [OOZMA_KAPPA].[traerListadoCuentaActivasPorClienteID]
GO
DROP PROCEDURE [OOZMA_KAPPA].[TraerListadoCuentaAPagarPorClienteID]
GO
DROP PROCEDURE [OOZMA_KAPPA].[TraerListadoCuentaCantidadTransaccionesAPagar]
GO
DROP PROCEDURE [OOZMA_KAPPA].[TraerListadoCuentaCompleto]
GO
DROP PROCEDURE [OOZMA_KAPPA].[traerListadoCuentaConFiltros]
GO
DROP PROCEDURE [OOZMA_KAPPA].[traerListadoCuentaPorCliente_NoCerradas]
GO
DROP PROCEDURE [OOZMA_KAPPA].[traerListadoCuentaPorClienteID]
GO
DROP PROCEDURE [OOZMA_KAPPA].[traerListadoCuentaporCuentaID]
GO
DROP PROCEDURE [OOZMA_KAPPA].[TraerListadoCuentaPorUsuarioID]
GO
DROP PROCEDURE [OOZMA_KAPPA].[TraerListadoFacturaUltimaGenerada]
GO
DROP PROCEDURE [OOZMA_KAPPA].[traerListadoFuncionalidades]
GO
DROP PROCEDURE [OOZMA_KAPPA].[traerListadoFuncionalidadesPorId_Rol]
GO
DROP PROCEDURE [OOZMA_KAPPA].[TraerProximaCuentaID]
GO
DROP PROCEDURE [OOZMA_KAPPA].[traerUsuarioActivoPorUsername]
GO
DROP PROCEDURE [OOZMA_KAPPA].[DeleteSuscripcionesAfterFacturacion]
GO
DROP TYPE [OOZMA_KAPPA].[TVP_Item]
GO
DROP TYPE [OOZMA_KAPPA].[TVP_SuscripcionesABorrar]
GO
DROP PROCEDURE [OOZMA_KAPPA].[updateUsuario]
GO
DROP PROCEDURE [OOZMA_KAPPA].[deshabilitarUsuario]
GO
DROP PROCEDURE [OOZMA_KAPPA].[validarRolEnUsuarios]
GO
DROP PROCEDURE [OOZMA_KAPPA].[insertCheque_RetornarID]
GO
DROP PROCEDURE [OOZMA_KAPPA].[DeleteCuenta]
GO
DROP PROCEDURE [OOZMA_KAPPA].[deleteRol_Funcionalidad_PorIdRol]
GO
DROP PROCEDURE [OOZMA_KAPPA].[insertDeposito]
GO
COMMIT

--- DROP TABLES ---

USE GD1C2015

BEGIN TRANSACTION

DROP TABLE [OOZMA_KAPPA].[Banco]
GO
DROP TABLE [OOZMA_KAPPA].[Cheque]
GO
DROP TABLE [OOZMA_KAPPA].[Deposito]
GO
DROP TABLE [OOZMA_KAPPA].[Emisor]
GO
DROP TABLE [OOZMA_KAPPA].[Factura]
GO
DROP TABLE [OOZMA_KAPPA].[Funcionalidades]
GO
DROP TABLE [OOZMA_KAPPA].[Funcionalidades_rol]
GO
DROP TABLE [OOZMA_KAPPA].[Item_factura]
GO
DROP TABLE [OOZMA_KAPPA].[Login]
GO
DROP TABLE [OOZMA_KAPPA].[Moneda]
GO
DROP TABLE [OOZMA_KAPPA].[Pais]
GO
DROP TABLE [OOZMA_KAPPA].[Retiro]
GO
DROP TABLE [OOZMA_KAPPA].[Rol]
GO
DROP TABLE [OOZMA_KAPPA].[Tarjeta]
GO
DROP TABLE [OOZMA_KAPPA].[Tipo_cuenta]
GO
DROP TABLE [OOZMA_KAPPA].[Tipo_documento]
GO
DROP TABLE [OOZMA_KAPPA].[Transacciones_pendientes]
GO
DROP TABLE [OOZMA_KAPPA].[Transferencia]
GO
DROP TABLE [OOZMA_KAPPA].[Usuario]
GO
DROP TABLE [OOZMA_KAPPA].[Administrador]
GO
DROP TABLE [OOZMA_KAPPA].[Usuario_rol]
GO
DROP TABLE [OOZMA_KAPPA].[Cliente]
GO
DROP TABLE [OOZMA_KAPPA].[Cuenta]
GO
DROP TABLE [OOZMA_KAPPA].[Historial_cuentas]
GO
COMMIT

--- DROP SCHEMA ---

BEGIN TRANSACTION
DROP SCHEMA [OOZMA_KAPPA] 
GO

COMMIT