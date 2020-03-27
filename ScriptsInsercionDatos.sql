-- SCRIPTS PARA INSERCION RAPIDA DE DATOS DE PRUEBA
USE [supermercados]


--Roles
GO
INSERT INTO [dbo].[Rol]
           ([rolDescripcion])
     VALUES
           ('ADMIN'),('USER'),('CONTADOR')
GO

--Usuarios dejar en blanco la contraseña editarla en la interfaz
GO
INSERT INTO [dbo].[Usuario]
           ([usuNick]
           ,[usuNombres]
           ,[usuApellidos]
           ,[usuCorreo]
           ,[usuTelefono]
           ,[usuPassw])
     VALUES
           ('admin','admin general','','admin@test.com','','')

GO

--Roles Usuario
GO
INSERT INTO [dbo].[RolesUsuario]
           ([rolId]
           ,[usuId]
           ,[usuNick])
     VALUES
           (1,2,'nclaros'),(1,3,'admin')
GO

--Funciones
GO
INSERT INTO [dbo].[Funciones]
           ([funDescripcion])
     VALUES
           ('Formulario Usuarios'),('Formulario de Roles')
GO

--Asignacion de roles a las funciones
GO
INSERT INTO [dbo].[FuncionesRoles]
           ([rolId]
           ,[funId])
     VALUES
           (1,1),(1,2)
GO

--Tipos de permiso
GO

INSERT INTO [dbo].[TiposPermisos]
           ([tipPermisoDescripcion])
     VALUES
           ('Insertar'), ('Editar'), ('Eliminar'), ('Visualizar')
GO

--Asignacion de permisos a las funciones
GO
INSERT INTO [dbo].[FuncionesRolesPermisos]
           ([funRolesId]
           ,[perFunDescripcion]
           ,[perFunValor]
           ,[tipPermisoId])
     VALUES
           (1,'Puede Insertar',1,1), (1,'Puede Editar',1,2), (1,'Puede Borrar',1,3), (1,'Puede Ver',1,4),
		   (2,'Puede Insertar',1,1), (2,'Puede Editar',1,2), (2,'Puede Borrar',1,3), (2,'Puede Ver',1,4)
GO
