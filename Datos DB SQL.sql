--Sentencia para crear la DB (Si no esta creada quitar el comentario de la siguiente linea caso contrario dejarlo comentado)
--CREATE DATABASE supermercados;

--Crear usuario que se utiliza en la conexion del sistema a la base de datos (quitar el comentario si no esta creado caso contrario dejarlo comentado)
--CREATE LOGIN "admin" WITH PASSWORD = 'admin@2020'

use supermercados;

CREATE TABLE [Usuario] ( 
  [usuId]        INT    NOT NULL Identity(1,1), 
  [usuNick]      VARCHAR(40)    NOT NULL, 
  [usuNombres]   VARCHAR(100)    NOT NULL, 
  [usuApellidos] VARCHAR(100)    NOT NULL, 
  [usuCorreo]    VARCHAR(100)    NOT NULL, 
  [usuTelefono]  CHAR(20)    NOT NULL, 
  [usuPassw]     VARCHAR(100)    NOT NULL, 
     PRIMARY KEY ( [usuId],[usuNick] ))


CREATE TABLE [Rol] ( 
  [rolId]          INT    NOT NULL Identity(1,1), 
  [rolDescripcion] VARCHAR(60)    NOT NULL, 
     PRIMARY KEY ( [rolId] ))
 
CREATE TABLE [RolesUsuario] ( 
  [rolUsuId] INT    NOT NULL Identity(1,1), 
  [rolId]    INT    NOT NULL, 
  [usuId]    INT    NOT NULL, 
  [usuNick]  VARCHAR(40)    NOT NULL, 
     PRIMARY KEY ( [rolUsuId] ))
CREATE NONCLUSTERED INDEX [IROLESUSUARIO1] ON [RolesUsuario] ( 
      [rolId])
CREATE NONCLUSTERED INDEX [IROLESUSUARIO2] ON [RolesUsuario] ( 
      [usuId], 
      [usuNick])
ALTER TABLE [RolesUsuario] 
 ADD CONSTRAINT [IROLESUSUARIO1] FOREIGN KEY ( [rolId] ) REFERENCES [Rol]([rolId])
ALTER TABLE [RolesUsuario] 
 ADD CONSTRAINT [IROLESUSUARIO2] FOREIGN KEY ( [usuId],[usuNick] ) REFERENCES [Usuario]([usuId],[usuNick])


 CREATE TABLE [TiposPermisos] ( 
  [tipPermisoId]          INT    NOT NULL identity(1,1), 
  [tipPermisoDescripcion] VARCHAR(100)    NOT NULL, 
     PRIMARY KEY ( [tipPermisoId] ))

CREATE TABLE [Funciones] ( 
  [funId]          INT    NOT NULL identity(1,1), 
  [funDescripcion] VARCHAR(100)    NOT NULL,
     PRIMARY KEY ( [funId] ))


CREATE TABLE [FuncionesRoles] ( 
  [funRolesId] INT    NOT NULL IDENTITY(1,1), 
  [rolId]      INT    NOT NULL, 
  [funId]      INT    NOT NULL, 
     PRIMARY KEY ( [funRolesId] ))
CREATE NONCLUSTERED INDEX [IFUNCIONESROLES1] ON [FuncionesRoles] ( 
      [rolId])
CREATE NONCLUSTERED INDEX [IFUNCIONESROLES2] ON [FuncionesRoles] ( 
      [funId])
ALTER TABLE [FuncionesRoles] 
 ADD CONSTRAINT [IFUNCIONESROLES1] FOREIGN KEY ( [rolId] ) REFERENCES [Rol]([rolId])
ALTER TABLE [FuncionesRoles] 
 ADD CONSTRAINT [IFUNCIONESROLES2] FOREIGN KEY ( [funId] ) REFERENCES [Funciones]([funId])


CREATE TABLE [FuncionesRolesPermisos] ( 
  [funRolesId]        INT    NOT NULL, 
  [perFunId]          INT    NOT NULL identity(1,1), 
  [perFunDescripcion] VARCHAR(100)    NOT NULL, 
  [perFunValor]       BIT    NOT NULL, 
  [tipPermisoId]      INT    NOT NULL, 
     PRIMARY KEY ([perFunId]))
CREATE NONCLUSTERED INDEX [IFUNCIONESROLESPERMISOS2] ON [FuncionesRolesPermisos] ( 
      [tipPermisoId])
ALTER TABLE [FuncionesRolesPermisos] 
 ADD CONSTRAINT [IFUNCIONESROLESPERMISOS1] FOREIGN KEY ( [funRolesId] ) REFERENCES [FuncionesRoles]([funRolesId])
ALTER TABLE [FuncionesRolesPermisos] 
 ADD CONSTRAINT [IFUNCIONESROLESPERMISOS2] FOREIGN KEY ( [tipPermisoId] ) REFERENCES [TiposPermisos]([tipPermisoId])


CREATE TABLE [Cliente] ( 
  [cliId]        INT    NOT NULL Identity(1,1), 
  [cliNombres]   VARCHAR(100)    NOT NULL, 
  [cliApellidos] VARCHAR(100)    NOT NULL, 
  [cliCorreo]    VARCHAR(100)    NOT NULL, 
  [cliTelefono]  CHAR(20)    NOT NULL, 
  [cliDireccion] VARCHAR(100)   NOT NULL, 
  [usuId]        INT    NOT NULL, 
     PRIMARY KEY ( [cliId] ))

CREATE TABLE [Impuestos] ( 
  [impId]          INT    NOT NULL Identity(1,1), 
  [impDescripcion] VARCHAR(90)    NOT NULL, 
  [impValor]       INT    NOT NULL, 
     PRIMARY KEY ( [impId] ))

CREATE TABLE [Unidades] ( 
  [uniId]          INT    NOT NULL Identity(1,1), 
  [uniDescripcion] VARCHAR(100)    NOT NULL, 
     PRIMARY KEY ( [uniId] ))

CREATE TABLE [Categoria] ( 
  [catProductoId]          INT    NOT NULL, 
  [catProductoDescripcion] VARCHAR(100)    NOT NULL, 
     PRIMARY KEY ( [catProductoId] ))

CREATE TABLE [Producto] ( 
  [proId]          INT    NOT NULL Identity(1,1), 
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
  [claCtaId]          INT    NOT NULL Identity(1,1), 
  [claCtaDescripcion] VARCHAR(100)    NOT NULL, 
     PRIMARY KEY ( [claCtaId] ))

CREATE TABLE [Cuentas] ( 
  [ctaId]          VARCHAR(40)    NOT NULL unique, 
  [ctaDescripcion] VARCHAR(50)    NOT NULL, 
  [claCtaId]       INT    NOT NULL, 
     PRIMARY KEY ( [ctaId] ))
CREATE NONCLUSTERED INDEX [ICUENTAS1] ON [Cuentas] ( 
      [claCtaId])
ALTER TABLE [Cuentas] 
 ADD CONSTRAINT [ICUENTAS1] FOREIGN KEY ( [claCtaId] ) REFERENCES [ClasificacionCuenta]([claCtaId])


CREATE TABLE [PartidasContable] ( 
  [parId]          INT    NOT NULL Identity(1,1), 
  [parDescripcion] VARCHAR(100)    NOT NULL, 
  [parFecha]       DATETIME    NOT NULL, 
  [usuId]          INT    NOT NULL, 
     PRIMARY KEY ( [parId] ))

CREATE TABLE [PartidasContableDetalle] ( 
  [parId]          INT    NOT NULL Identity(1,1), 
  [parConDetId]    INT    NOT NULL, 
  [ctaId]          VARCHAR(40)    NOT NULL, 
  [parConDetDebe]  SMALLMONEY    NOT NULL, 
  [parConDetHaber] SMALLMONEY    NOT NULL, 
     PRIMARY KEY ( [parId],[parConDetId] ))
CREATE NONCLUSTERED INDEX [IPartidasContableDetalle2] ON [PartidasContableDetalle] ( 
      [ctaId])
ALTER TABLE [PartidasContableDetalle] 
 ADD CONSTRAINT [IPartidasContableDetalle3] FOREIGN KEY ( [parId] ) REFERENCES [PartidasContable]([parId])
ALTER TABLE [PartidasContableDetalle] 
 ADD CONSTRAINT [IPartidasContableDetalle2] FOREIGN KEY ( [ctaId] ) REFERENCES [Cuentas]([ctaId])

CREATE TABLE [CompraProductos] ( 
  [comProId]         INT    NOT NULL Identity(1,1), 
  [comProFecha]      DATETIME    NOT NULL, 
  [usuId]            INT    NOT NULL, 
  [comProMontoTotal] SMALLINT    NOT NULL, 
     PRIMARY KEY ( [comProId] ))

CREATE TABLE [CompraProductosDetalle] ( 
  [comProId]          INT    NOT NULL Identity(1,1), 
  [detComProId]       INT    NOT NULL, 
  [proId]             INT    NOT NULL, 
  [detComProCantidad] SMALLMONEY    NOT NULL, 
     PRIMARY KEY ( [comProId],[detComProId] ))
CREATE NONCLUSTERED INDEX [ICOMPRAPRODUCTOSDETALLE1] ON [CompraProductosDetalle] ( 
      [proId])
ALTER TABLE [CompraProductosDetalle] 
 ADD CONSTRAINT [ICOMPRAPRODUCTOSDETALLE2] FOREIGN KEY ( [comProId] ) REFERENCES [CompraProductos]([comProId])
ALTER TABLE [CompraProductosDetalle] 
 ADD CONSTRAINT [ICOMPRAPRODUCTOSDETALLE1] FOREIGN KEY ( [proId] ) REFERENCES [Producto]([proId])

CREATE TABLE [Inventario] ( 
  [invId]             INT    NOT NULL Identity(1,1), 
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
  [facId]         SMALLINT    NOT NULL Identity(1,1), 
  [facFecha]      SMALLINT    NOT NULL, 
  [facMontoTotal] SMALLINT    NOT NULL, 
  [cliId]         INT    NOT NULL, 
     PRIMARY KEY ( [facId] ))
CREATE NONCLUSTERED INDEX [IFACTURA1] ON [Factura] ( 
      [cliId])
ALTER TABLE [Factura] 
 ADD CONSTRAINT [IFACTURA1] FOREIGN KEY ( [cliId] ) REFERENCES [Cliente]([cliId])

CREATE TABLE [FacturaDetalle] ( 
  [facId]          SMALLINT    NOT NULL Identity(1,1), 
  [detFacId]       SMALLINT    NOT NULL, 
  [proId]          INT    NOT NULL, 
  [detFacCantidad] SMALLMONEY    NOT NULL, 
     PRIMARY KEY ( [facId],[detFacId] ))
CREATE NONCLUSTERED INDEX [IFACTURADETALLE1] ON [FacturaDetalle] ( 
      [proId])
ALTER TABLE [FacturaDetalle] 
 ADD CONSTRAINT [IFACTURADETALLE2] FOREIGN KEY ( [facId] ) REFERENCES [Factura]([facId])
ALTER TABLE [FacturaDetalle] 
 ADD CONSTRAINT [IFACTURADETALLE1] FOREIGN KEY ( [proId] ) REFERENCES [Producto]([proId])