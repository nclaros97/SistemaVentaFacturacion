--Sentencia para crear la DB (Si no esta creada quitar el comentario de la siguiente linea caso contrario dejarlo comentado)
--CREATE DATABASE supermercados

--Crear usuario que se utiliza en la conexion del sistema a la base de datos (quitar el comentario si no esta creado caso contrario dejarlo comentado)
--CREATE LOGIN "admin" WITH PASSWORD = 'admin@2020'

use supermercados;

CREATE TABLE [Usuario] ( 
  [usuId]        INT    NOT NULL, 
  [usuNick]      VARCHAR(40)    NOT NULL, 
  [usuNombres]   VARCHAR(100)    NOT NULL, 
  [usuApellidos] VARCHAR(100)    NOT NULL, 
  [usuCorreo]    VARCHAR(100)    NOT NULL, 
  [usuTelefono]  CHAR(20)    NOT NULL, 
  [usuPassw]     VARCHAR(100)    NOT NULL, 
     PRIMARY KEY ( [usuId],[usuNick] ))


CREATE TABLE [Rol] ( 
  [rolId]          INT    NOT NULL, 
  [rolDescripcion] VARCHAR(60)    NOT NULL, 
     PRIMARY KEY ( [rolId] ))

CREATE TABLE [RolesUsuario] ( 
  [rolUsuId] SMALLINT    NOT NULL, 
  [rolId]    INT    NOT NULL, 
  [usuId]    INT    NOT NULL, 
     PRIMARY KEY ( [rolUsuId] ))
CREATE NONCLUSTERED INDEX [IROLESUSUARIO1] ON [RolesUsuario] ( 
      [rolId])
ALTER TABLE [RolesUsuario] 
 ADD CONSTRAINT [IROLESUSUARIO1] FOREIGN KEY ( [rolId] ) REFERENCES [Rol]([rolId])

CREATE TABLE [Cliente] ( 
  [cliId]        INT    NOT NULL, 
  [cliNombres]   VARCHAR(100)    NOT NULL, 
  [cliApellidos] VARCHAR(100)    NOT NULL, 
  [cliCorreo]    VARCHAR(100)    NOT NULL, 
  [cliTelefono]  CHAR(20)    NOT NULL, 
  [usuId]        INT    NOT NULL, 
     PRIMARY KEY ( [cliId] ))

CREATE TABLE [Impuestos] ( 
  [impId]          INT    NOT NULL, 
  [impDescripcion] VARCHAR(90)    NOT NULL, 
  [impValor]       INT    NOT NULL, 
     PRIMARY KEY ( [impId] ))

CREATE TABLE [Unidades] ( 
  [uniId]          INT    NOT NULL, 
  [uniDescripcion] VARCHAR(100)    NOT NULL, 
     PRIMARY KEY ( [uniId] ))

CREATE TABLE [Categoria] ( 
  [catProductoId]          INT    NOT NULL, 
  [catProductoDescripcion] VARCHAR(100)    NOT NULL, 
     PRIMARY KEY ( [catProductoId] ))

CREATE TABLE [Producto] ( 
  [proId]          INT    NOT NULL, 
  [proNombre]      VARCHAR(40)    NOT NULL, 
  [proDescripcion] VARCHAR(60)    NOT NULL, 
  [proValor]       SMALLMONEY    NOT NULL, 
  [catProductoId]  INT    NOT NULL, 
  [uniId]          INT    NOT NULL, 
  [usuId]          INT    NOT NULL, 
  [impId]          INT    NOT NULL, 
     PRIMARY KEY ( [proId] ))
CREATE NONCLUSTERED INDEX [IPRODUCTO1] ON [Producto] ( 
      [catProductoId])
CREATE NONCLUSTERED INDEX [IPRODUCTO2] ON [Producto] ( 
      [uniId])
CREATE NONCLUSTERED INDEX [IPRODUCTO3] ON [Producto] ( 
      [impId])
ALTER TABLE [Producto] 
 ADD CONSTRAINT [IPRODUCTO1] FOREIGN KEY ( [catProductoId] ) REFERENCES [Categoria]([catProductoId])
ALTER TABLE [Producto] 
 ADD CONSTRAINT [IPRODUCTO2] FOREIGN KEY ( [uniId] ) REFERENCES [Unidades]([uniId])
ALTER TABLE [Producto] 
 ADD CONSTRAINT [IPRODUCTO3] FOREIGN KEY ( [impId] ) REFERENCES [Impuestos]([impId])

CREATE TABLE [ClasificacionCuenta] ( 
  [claCtaId]          INT    NOT NULL, 
  [claCtaDescripcion] VARCHAR(100)    NOT NULL, 
     PRIMARY KEY ( [claCtaId] ))

CREATE TABLE [Cuentas] ( 
  [ctaId]          VARCHAR(40)    NOT NULL, 
  [ctaDescripcion] VARCHAR(50)    NOT NULL, 
  [claCtaId]       INT    NOT NULL, 
     PRIMARY KEY ( [ctaId] ))
CREATE NONCLUSTERED INDEX [ICUENTAS1] ON [Cuentas] ( 
      [claCtaId])
ALTER TABLE [Cuentas] 
 ADD CONSTRAINT [ICUENTAS1] FOREIGN KEY ( [claCtaId] ) REFERENCES [ClasificacionCuenta]([claCtaId])


CREATE TABLE [PartidasContable] ( 
  [parId]          INT    NOT NULL, 
  [parDescripcion] VARCHAR(100)    NOT NULL, 
  [parFecha]       DATETIME    NOT NULL, 
  [usuId]          INT    NOT NULL, 
     PRIMARY KEY ( [parId] ))

CREATE TABLE [PartidasContablePartidasContab] ( 
  [parId]          INT    NOT NULL, 
  [parConDetId]    INT    NOT NULL, 
  [ctaId]          VARCHAR(40)    NOT NULL, 
  [parConDetDebe]  SMALLMONEY    NOT NULL, 
  [parConDetHaber] SMALLMONEY    NOT NULL, 
     PRIMARY KEY ( [parId],[parConDetId] ))
CREATE NONCLUSTERED INDEX [IPARTIDASCONTABLEPARTIDASCONT2] ON [PartidasContablePartidasContab] ( 
      [ctaId])
ALTER TABLE [PartidasContablePartidasContab] 
 ADD CONSTRAINT [IPARTIDASCONTABLEPARTIDASCONT3] FOREIGN KEY ( [parId] ) REFERENCES [PartidasContable]([parId])
ALTER TABLE [PartidasContablePartidasContab] 
 ADD CONSTRAINT [IPARTIDASCONTABLEPARTIDASCONT2] FOREIGN KEY ( [ctaId] ) REFERENCES [Cuentas]([ctaId])

CREATE TABLE [CompraProductos] ( 
  [comProId]         INT    NOT NULL, 
  [comProFecha]      DATETIME    NOT NULL, 
  [usuId]            INT    NOT NULL, 
  [comProMontoTotal] SMALLINT    NOT NULL, 
     PRIMARY KEY ( [comProId] ))

CREATE TABLE [CompraProductosDetalleCompraPr] ( 
  [comProId]          INT    NOT NULL, 
  [detComProId]       INT    NOT NULL, 
  [proId]             INT    NOT NULL, 
  [detComProCantidad] SMALLMONEY    NOT NULL, 
     PRIMARY KEY ( [comProId],[detComProId] ))
CREATE NONCLUSTERED INDEX [ICOMPRAPRODUCTOSDETALLECOMPRA1] ON [CompraProductosDetalleCompraPr] ( 
      [proId])
ALTER TABLE [CompraProductosDetalleCompraPr] 
 ADD CONSTRAINT [ICOMPRAPRODUCTOSDETALLECOMPRA2] FOREIGN KEY ( [comProId] ) REFERENCES [CompraProductos]([comProId])
ALTER TABLE [CompraProductosDetalleCompraPr] 
 ADD CONSTRAINT [ICOMPRAPRODUCTOSDETALLECOMPRA1] FOREIGN KEY ( [proId] ) REFERENCES [Producto]([proId])

CREATE TABLE [Inventario] ( 
  [invId]             INT    NOT NULL, 
  [proId]             INT    NOT NULL, 
  [invStock]          SMALLMONEY    NOT NULL, 
  [invCantidadMinima] SMALLMONEY    NOT NULL, 
  [invFechaCreacion]  DATETIME    NOT NULL, 
  [invFechaUltimaAct] DATETIME    NOT NULL, 
     PRIMARY KEY ( [invId] ))
CREATE NONCLUSTERED INDEX [IINVENTARIO1] ON [Inventario] ( 
      [proId])
ALTER TABLE [Inventario] 
 ADD CONSTRAINT [IINVENTARIO1] FOREIGN KEY ( [proId] ) REFERENCES [Producto]([proId])

CREATE TABLE [Factura] ( 
  [facId]         SMALLINT    NOT NULL, 
  [facFecha]      SMALLINT    NOT NULL, 
  [facMontoTotal] SMALLINT    NOT NULL, 
  [cliId]         INT    NOT NULL, 
     PRIMARY KEY ( [facId] ))
CREATE NONCLUSTERED INDEX [IFACTURA1] ON [Factura] ( 
      [cliId])
ALTER TABLE [Factura] 
 ADD CONSTRAINT [IFACTURA1] FOREIGN KEY ( [cliId] ) REFERENCES [Cliente]([cliId])

CREATE TABLE [FacturaDetalle] ( 
  [facId]          SMALLINT    NOT NULL, 
  [detFacId]       SMALLINT    NOT NULL, 
  [proId]          INT    NOT NULL, 
  [detFacCantidad] SMALLMONEY    NOT NULL, 
     PRIMARY KEY ( [facId],[detFacId] ))
CREATE NONCLUSTERED INDEX [IFACTURADETALLEFACTURA1] ON [FacturaDetalle] ( 
      [proId])
ALTER TABLE [FacturaDetalle] 
 ADD CONSTRAINT [IFACTURADETALLEFACTURA2] FOREIGN KEY ( [facId] ) REFERENCES [Factura]([facId])
ALTER TABLE [FacturaDetalle] 
 ADD CONSTRAINT [IFACTURADETALLEFACTURA1] FOREIGN KEY ( [proId] ) REFERENCES [Producto]([proId])