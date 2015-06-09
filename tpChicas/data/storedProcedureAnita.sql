-- Procedure traerListadoUsuariosCompras
CREATE PROCEDURE [ATJ].[traerListadoUsuariosCompras] 
    @id_Usuario numeric(18,0)
AS
SELECT C.id_Compra AS id_Compra,C.cod_Publicacion AS cod_Publicacion,
Vendedor = (CASE WHEN E.id_Usuario IS NULL THEN S.Nombre+' '+S.Apellido ELSE E.Razon_social END), 
C.Fecha AS Fecha, C.Cantidad AS Cantidad
FROM ATJ.Compras C
LEFT JOIN ATJ.Empresas E ON C.id_Usuario_Vendedor = E.id_Usuario
LEFT JOIN ATJ.Clientes S ON C.id_Usuario_Vendedor = S.id_Usuario
WHERE id_Usuario_Comprador = @id_Usuario
GO

--Prodedure traerListadoUsuariosOfertas
CREATE PROCEDURE [ATJ].[traerListadoUsuariosOfertas]
	@id_Usuario numeric(18,0)
AS
SELECT O.id_Oferta AS id_Oferta, O.cod_Publicacion AS cod_Publicacion, 
Vendedor = (CASE WHEN E.id_Usuario IS NULL THEN C.Nombre+' '+C.Apellido ELSE E.Razon_social END),
O.gano_Subasta AS gano_Subasta, O.Fecha AS Fecha, O.Monto AS Monto
FROM ATJ.Ofertas O 
LEFT JOIN ATJ.Empresas E ON E.id_Usuario = O.id_Usuario_Vendedor
LEFT JOIN ATJ.Clientes C ON C.id_Usuario = O.id_Usuario_Vendedor
WHERE id_Usuario_Comprador = @id_Usuario
GO

--Procedure traerListadoUsuariosCalificacionesRecibidas
CREATE PROCEDURE [ATJ].[traerListadoUsuariosCalificacionesRecibidas]
	@id_Usuario numeric(18,0)
AS
SELECT C.cod_Calificacion AS cod_Calificacion, 
Calificador = (S.Nombre+' '+S.Apellido),
C.Cant_Estrellas AS cant_Estrellas, C.Descripcion AS Descripcion
FROM ATJ.Calificaciones C
INNER JOIN ATJ.Publicaciones P ON P.Codigo = C.cod_Publicacion
INNER JOIN ATJ.Clientes S ON S.id_Usuario = C.id_Usuario_Calificador
WHERE P.id_Usuario = @id_Usuario
GO

--Procedure traerListadoUsuariosCalificacionesOtorgadas
CREATE PROCEDURE [ATJ].[traerListadoUsuariosCalificacionesOtorgadas]
	@id_Usuario numeric(18,0)
AS
SELECT C.cod_Calificacion AS cod_Calificacion, 
Calificado = (CASE WHEN E.id_Usuario IS NULL THEN S.Nombre+' '+S.Apellido ELSE E.Razon_social END),
C.Cant_Estrellas AS cant_Estrellas, C.Descripcion AS Descripcion
FROM ATJ.Calificaciones C
INNER JOIN Publicaciones P ON P.Codigo = C.cod_Publicacion
LEFT JOIN ATJ.Empresas E ON E.id_Usuario = P.id_Usuario
LEFT JOIN ATJ.Clientes S ON S.id_Usuario = P.id_Usuario
WHERE C.id_Usuario_Calificador = @id_Usuario
GO

--Procedure traerListadoUsuariosConMayorCantidadDeProductosSinVender
CREATE PROCEDURE [ATJ].[traerListadoUsuariosConMayorCantidadDeProductosSinVender]
	@Fecha_Hasta datetime,
	@Fecha_Desde datetime,
	@Año nvarchar(4)
AS

SELECT TOP 5 Vendedor = (CASE WHEN  (E.id_Usuario IS NULL AND s.id_Usuario IS null) THEN 'Admin' ELSE
(CASE WHEN  E.id_Usuario IS NULL THEN S.Nombre+' '+S.Apellido ELSE E.Razon_social END) END),
COUNT(P.Codigo) AS CantPublicNoVendidos
FROM ATJ.Publicaciones P
LEFT JOIN ATJ.Empresas E ON E.id_Usuario = P.id_Usuario
LEFT JOIN ATJ.Clientes S ON S.id_Usuario = P.id_Usuario
WHERE MONTH(P.Fecha_creacion) BETWEEN MONTH(@Fecha_Desde) AND MONTH(@Fecha_Hasta)
AND YEAR(P.Fecha_creacion) = @Año
AND(P.Codigo NOT IN (SELECT C.cod_Publicacion FROM ATJ.Compras C)
AND P.Codigo NOT IN (SELECT O.cod_Publicacion FROM ATJ.Ofertas O WHERE O.gano_Subasta = 1))
GROUP BY P.id_Usuario, E.id_Usuario, S.Nombre, S.Apellido, E.Razon_social, S.id_Usuario
ORDER BY CantPublicNoVendidos DESC
GO

--Procedure traerListadoUsuariosConMayorFacturacion
CREATE PROCEDURE [ATJ].[traerListadoUsuariosConMayorFacturacion]
	@Fecha_Hasta datetime,
	@Fecha_Desde datetime,
	@Año nvarchar(4)
AS

SELECT TOP 5 Vendedor = (CASE WHEN  E.id_Usuario IS NULL THEN S.Nombre+' '+S.Apellido ELSE E.Razon_social END),
SUM(P.Precio) AS Facturacion
FROM ATJ.Publicaciones P
LEFT JOIN ATJ.Empresas E ON E.id_Usuario = P.id_Usuario
LEFT JOIN ATJ.Clientes S ON S.id_Usuario = P.id_Usuario
WHERE MONTH(P.Fecha_creacion) BETWEEN MONTH(@Fecha_Desde) AND MONTH(@Fecha_Hasta)
AND YEAR(P.Fecha_creacion) = @Año
AND P.id_Usuario IN (SELECT F.id_Usuario FROM ATJ.Facturas F)
GROUP BY P.id_Usuario, E.id_Usuario, S.Nombre, S.Apellido, E.Razon_social
ORDER BY Facturacion DESC
GO

-- Procedure traerListadoUsuariosConMayorCalificacion
CREATE PROCEDURE [ATJ].[traerListadoUsuariosConMayorCalificacion]
	@Fecha_Hasta datetime,
	@Fecha_Desde datetime,
	@Año nvarchar(4)
AS

SELECT TOP 5 Vendedor = (CASE WHEN  E.id_Usuario IS NULL THEN S.Nombre+' '+S.Apellido ELSE E.Razon_social END),
CAST(AVG(C.Cant_Estrellas) AS numeric(18,2)) AS PromedioCalificaciones
FROM ATJ.Calificaciones C
INNER JOIN ATJ.Publicaciones P ON P.Codigo = C.cod_Publicacion
LEFT JOIN ATJ.Empresas E ON E.id_Usuario = P.id_Usuario
LEFT JOIN ATJ.Clientes S ON S.id_Usuario = P.id_Usuario
WHERE MONTH(P.Fecha_creacion) BETWEEN MONTH(@Fecha_Desde) AND MONTH(@Fecha_Hasta)
AND YEAR(P.Fecha_creacion) = @Año
GROUP BY P.id_Usuario, E.id_Usuario, S.Nombre, S.Apellido, E.Razon_social, S.id_Usuario 
ORDER BY PromedioCalificaciones DESC
GO

-- Procedure traerListadoUsuariosConMayorCantDePublicacionesSinCalificar
CREATE PROCEDURE [ATJ].[traerListadoUsuariosConMayorCantDePublicacionesSinCalificar]
	@Fecha_Hasta datetime,
	@Fecha_Desde datetime,
	@Año nvarchar(4)

AS

SELECT TOP 5 Cliente = (CASE WHEN  E.id_Usuario IS NULL THEN S.Nombre+' '+S.Apellido ELSE E.Razon_social END),
COUNT(P.Codigo) AS CantPubliSinClasificar
FROM ATJ.Publicaciones P
LEFT JOIN ATJ.Empresas E ON E.id_Usuario = P.id_Usuario
LEFT JOIN ATJ.Clientes S ON S.id_Usuario = P.id_Usuario
WHERE 
MONTH(P.Fecha_creacion) BETWEEN MONTH(@Fecha_Desde) AND MONTH(@Fecha_Hasta)
AND YEAR(P.Fecha_creacion) = @Año
and p.Codigo NOT IN (SELECT cod_Publicacion FROM ATJ.Calificaciones)
GROUP BY P.id_Usuario, E.id_Usuario, S.Nombre, S.Apellido, E.Razon_social
ORDER BY CantPubliSinClasificar DESC
GO

--Procedure traerListadoUsuariosConMayorCantidadDeProductosSinVenderConFiltros
CREATE PROCEDURE [ATJ].[traerListadoUsuariosConMayorCantidadDeProductosSinVenderConFiltros]
	@Fecha_Hasta datetime,
	@Fecha_Desde datetime,
	@Año nvarchar(4),
	@Mes nvarchar(2),
	@GradoVisibilidad nvarchar(255)
	
AS

SELECT TOP 5 Vendedor = (CASE WHEN  (E.id_Usuario IS NULL AND s.id_Usuario IS null) THEN 'Admin' 
ELSE(CASE WHEN  E.id_Usuario IS NULL THEN S.Nombre+' '+S.Apellido ELSE E.Razon_social END) END),
COUNT(P.Codigo) AS CantPublicNoVendidos
FROM ATJ.Publicaciones P
LEFT JOIN ATJ.Empresas E ON E.id_Usuario = P.id_Usuario
LEFT JOIN ATJ.Clientes S ON S.id_Usuario = P.id_Usuario
INNER JOIN ATJ.Visibilidades V ON P.cod_Visibilidad = V.cod_Visibilidad
WHERE MONTH(P.Fecha_creacion) BETWEEN MONTH(@Fecha_Desde) AND MONTH(@Fecha_Hasta)
AND YEAR(P.Fecha_creacion) = @Año
AND(P.Codigo NOT IN (SELECT C.cod_Publicacion FROM ATJ.Compras C)
AND P.Codigo NOT IN (SELECT O.cod_Publicacion FROM ATJ.Ofertas O WHERE O.gano_Subasta = 1))
AND V.Descripcion = (CASE WHEN @GradoVisibilidad <> '' THEN @GradoVisibilidad ELSE V.Descripcion END) 
AND MONTH(P.Fecha_creacion) = (CASE WHEN @Mes <> '' THEN @Mes ELSE MONTH(P.Fecha_creacion) END)
GROUP BY P.id_Usuario, E.id_Usuario, S.Nombre, S.Apellido, E.Razon_social, S.id_Usuario 
ORDER BY CantPublicNoVendidos DESC
GO

--Procedure traerListadoPreguntasConRespuestasPorUsuarioYPublicacion
CREATE PROCEDURE ATJ.traerListadoPreguntasConRespuestasPorUsuarioYPublicacion
    @id_Usuario int,
    @cod_Publicacion numeric(18,0)

AS 
    SELECT R.id_Pregunta AS id_Pregunta, R.Pregunta AS Pregunta, R.Respuesta AS Respuesta, R.Fecha_respuesta AS Fecha_respuesta, 
    P.Codigo AS Codigo, P.Descripcion AS Descripcion, P.Stock AS Stock,P.Fecha_creacion AS Fecha_creacion, P.Fecha_vencimiento AS Fecha_Vencimiento, 
    P.Precio AS Precio
    FROM ATJ.Usuarios U 
    INNER JOIN ATJ.Publicaciones P ON U.id_Usuario = P.id_Usuario 
    INNER JOIN ATJ.Preguntas R ON R.cod_Publicacion = P.Codigo 
    WHERE	R.Respuesta IS NOT NULL
	AND		U.id_Usuario = @id_Usuario
	AND		P.Codigo = @cod_Publicacion
GO

--Procedure traerListadoPreguntasSinRespuestasPorUsuarioYPublicacion
CREATE PROCEDURE ATJ.traerListadoPreguntasSinRespuestasPorUsuarioYPublicacion
    @id_Usuario numeric(18,0),
    @cod_Publicacion numeric(18,0)

AS 
    SELECT R.id_Pregunta AS id_Pregunta, R.Pregunta AS Pregunta, R.Respuesta AS Respuesta, 
    R.Fecha_respuesta AS Fecha_respuesta, P.Codigo AS Codigo, P.Descripcion AS Descripcion, 
    P.Stock AS Stock,P.Fecha_creacion AS Fecha_creacion, P.Fecha_vencimiento AS Fecha_Vencimiento, 
    P.Precio AS Precio
    FROM ATJ.Usuarios U 
    INNER JOIN ATJ.Publicaciones P ON U.id_Usuario = P.id_Usuario 
    INNER JOIN ATJ.Preguntas R ON R.cod_Publicacion = P.Codigo 
    WHERE	R.Respuesta IS NULL
	AND		U.id_Usuario = @id_Usuario
	AND		P.Codigo = @cod_Publicacion
GO

--Procedure updatePreguntaConRespuesta
CREATE PROCEDURE ATJ.updatePreguntaConRespuesta
	@id_Pregunta int,
	@Respuesta nvarchar(255),
	@Fecha_respuesta datetime
	
AS

UPDATE ATJ.Preguntas SET	Respuesta = @Respuesta,
							Fecha_respuesta = @Fecha_respuesta
WHERE id_Pregunta = @id_Pregunta 
	
GO

--Procedure traerListadoFormas_Pago
CREATE PROCEDURE ATJ.traerListadoFormas_Pago
	
AS
	SELECT *
	FROM ATJ.Formas_Pago
GO

--Procedure traerListadoFormas_PagoPorId
CREATE PROCEDURE ATJ.traerListadoFormas_PagoPorId
	@id_Forma_Pago int
AS
	SELECT *
	FROM ATJ.Formas_Pago
	WHERE id_Forma_Pago = @id_Forma_Pago
GO

--Procedure traerListadoPublicacionesMasAntiguasARendirPorUsuario
CREATE PROCEDURE ATJ.traerListadoPublicacionesMasAntiguasARendirPorUsuario
	@Id_Usuario int,
	@Fecha datetime
	
AS

SELECT P.*
FROM ATJ.Publicaciones P
INNER JOIN ATJ.Compras C ON C.cod_Publicacion = P.Codigo
WHERE (P.Fecha_vencimiento <= @Fecha
OR P.Stock <=	(SELECT SUM(C.Cantidad) FROM ATJ.Compras C
				 WHERE C.cod_Publicacion = P.Codigo
				 GROUP BY C.cod_Publicacion))
AND P.id_Usuario = @Id_Usuario
AND P.Codigo NOT IN (SELECT I.cod_Publicacion FROM ATJ.Item_Factura I)
ORDER BY C.Fecha ASC
GO

--Procedure traerListadoItems_FacturaPorNroFactura
CREATE PROCEDURE ATJ.traerListadoItems_FacturaPorNroFactura
	@nro_Factura int
AS
SELECT *
FROM ATJ.Item_Factura
WHERE nro_Factura = @nro_Factura
GO

--Procedure insertFactura_RetornarID
CREATE PROCEDURE ATJ.insertFactura_RetornarID
    @Fecha datetime,
    @Precio_Total numeric(18,2),
    @id_Forma_Pago int,
    @id_Usuario int
AS
INSERT INTO ATJ.Facturas
(Fecha,Precio_Total,id_Forma_Pago, id_Usuario)
VALUES
(@Fecha,@Precio_Total,@id_Forma_Pago,@id_Usuario)

SELECT @@IDENTITY AS nro_Factura;
GO

--Procedure insertItem_Factura
CREATE PROCEDURE ATJ.insertItem_Factura
	@nro_Factura numeric(18,0),
	@cod_Publicacion numeric(18,0),
	@Monto numeric(18,2),
	@Cantidad numeric(18,0)
AS
INSERT INTO ATJ.Item_Factura
(nro_Factura,cod_Publicacion,Monto,Cantidad)
VALUES
(@nro_Factura,@cod_Publicacion,@Monto,@Cantidad)
GO

--Procedure traerListadoComprasPorCodigoPubli
CREATE PROCEDURE ATJ.traerListadoComprasPorCodigoPubli
	@cod_Publicacion numeric(18,0)
AS

SELECT *
FROM ATJ.Compras 
WHERE cod_Publicacion = @cod_Publicacion
GO


--Procedure traerListadoOfertasPorCodigoPubli
CREATE PROCEDURE ATJ.traerListadoOfertasPorCodigoPubli
 @cod_Publicacion numeric(18,0)
AS

SELECT *
FROM ATJ.Ofertas
WHERE cod_Publicacion = @cod_Publicacion
AND  gano_Subasta = 1
GO

