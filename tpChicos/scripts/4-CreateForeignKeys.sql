BEGIN TRANSACTION
ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Calificacion]
ADD FOREIGN KEY ([ID_Publicacion])
REFERENCES [LA_BANDA_DEL_CHAVO].[TL_Publicacion](ID_Publicacion);

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Calificacion]
ADD FOREIGN KEY ([ID_Comprador])
REFERENCES [LA_BANDA_DEL_CHAVO].[TL_Usuario](ID_Usuario);

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Cliente]
ADD FOREIGN KEY ([ID_Usuario])
REFERENCES [LA_BANDA_DEL_CHAVO].[TL_Usuario](ID_Usuario);

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Compra]
ADD FOREIGN KEY ([ID_Publicacion])
REFERENCES [LA_BANDA_DEL_CHAVO].[TL_Publicacion](ID_Publicacion);

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Compra]
ADD FOREIGN KEY ([ID_Usuario])
REFERENCES [LA_BANDA_DEL_CHAVO].[TL_Usuario](ID_Usuario);

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Empresa]
ADD FOREIGN KEY ([ID_Usuario])
REFERENCES [LA_BANDA_DEL_CHAVO].[TL_Usuario](ID_Usuario);

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Empresa]
ADD UNIQUE ([Razon_Social]);

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Empresa]
ADD UNIQUE ([CUIT]);

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Funcionalidad_Rol]
ADD FOREIGN KEY ([ID_Funcionalidad])
REFERENCES [LA_BANDA_DEL_CHAVO].[TL_Funcionalidad](ID_Funcionalidad);

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Funcionalidad_Rol]
ADD FOREIGN KEY ([ID_Rol])
REFERENCES [LA_BANDA_DEL_CHAVO].[TL_Rol](ID_Rol);

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Item_Factura]
ADD FOREIGN KEY ([ID_Factura])
REFERENCES [LA_BANDA_DEL_CHAVO].[TL_Factura](ID_Factura);

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Item_Factura]
ADD FOREIGN KEY ([ID_Publicacion])
REFERENCES [LA_BANDA_DEL_CHAVO].[TL_Publicacion](ID_Publicacion);

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Oferta]
ADD FOREIGN KEY ([ID_Usuario])
REFERENCES [LA_BANDA_DEL_CHAVO].[TL_Usuario](ID_Usuario);

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Oferta]
ADD FOREIGN KEY ([ID_Publicacion])
REFERENCES [LA_BANDA_DEL_CHAVO].[TL_Publicacion](ID_Publicacion);

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Pregunta]
ADD FOREIGN KEY ([ID_Publicacion])
REFERENCES [LA_BANDA_DEL_CHAVO].[TL_Publicacion](ID_Publicacion);

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Pregunta]
ADD FOREIGN KEY ([ID_Usuario])
REFERENCES [LA_BANDA_DEL_CHAVO].[TL_Usuario](ID_Usuario);

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Publicacion]
ADD FOREIGN KEY ([ID_Tipo_Publicacion])
REFERENCES [LA_BANDA_DEL_CHAVO].[TL_Tipo_Publicacion](ID_Tipo_Publicacion);

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Publicacion]
ADD FOREIGN KEY ([ID_Usuario])
REFERENCES [LA_BANDA_DEL_CHAVO].[TL_Usuario](ID_Usuario);

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Publicacion]
ADD FOREIGN KEY ([ID_Visibilidad])
REFERENCES [LA_BANDA_DEL_CHAVO].[TL_Visibilidad](ID_Visibilidad);

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Publicacion]
ADD FOREIGN KEY ([ID_Estado_Publicacion])
REFERENCES [LA_BANDA_DEL_CHAVO].[TL_Estado_Publicacion](ID_Estado_Publicacion);

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Respuesta]
ADD FOREIGN KEY ([ID_Pregunta])
REFERENCES [LA_BANDA_DEL_CHAVO].[TL_Pregunta](ID_Pregunta);

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Rubro_Publicacion]
ADD FOREIGN KEY ([ID_Rubro])
REFERENCES [LA_BANDA_DEL_CHAVO].[TL_Rubro](ID_Rubro);

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Rubro_Publicacion]
ADD FOREIGN KEY ([ID_Publicacion])
REFERENCES [LA_BANDA_DEL_CHAVO].[TL_Publicacion](ID_Publicacion);

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Usuario_Rol]
ADD FOREIGN KEY ([ID_Usuario])
REFERENCES [LA_BANDA_DEL_CHAVO].[TL_Usuario](ID_Usuario);

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Usuario_Rol]
ADD FOREIGN KEY ([ID_Rol])
REFERENCES [LA_BANDA_DEL_CHAVO].[TL_Rol](ID_Rol);

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Usuario_Visibilidad]
ADD FOREIGN KEY ([ID_Usuario])
REFERENCES [LA_BANDA_DEL_CHAVO].[TL_Usuario](ID_Usuario);

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Usuario_Visibilidad]
ADD FOREIGN KEY ([ID_Visibilidad])
REFERENCES [LA_BANDA_DEL_CHAVO].[TL_Visibilidad](ID_Visibilidad);

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Tarjeta_Credito]
ADD FOREIGN KEY ([ID_Factura])
REFERENCES [LA_BANDA_DEL_CHAVO].[TL_Factura](ID_Factura);

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Cliente]
ADD FOREIGN KEY ([ID_Tipo_Documento])
REFERENCES [LA_BANDA_DEL_CHAVO].[TL_Tipo_Documento](ID_Tipo_Documento);

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Factura]
ADD FOREIGN KEY ([ID_Usuario])
REFERENCES [LA_BANDA_DEL_CHAVO].[TL_Usuario](ID_Usuario);
COMMIT