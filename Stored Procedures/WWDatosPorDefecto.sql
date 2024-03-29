-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE WWDEFAULTDATA
AS
BEGIN
-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DELETE FROM [dbo].[PartidasContableDetalle]
	DELETE FROM [dbo].[PartidasContable]
	DELETE FROM [dbo].[Cuentas]
	DELETE FROM [dbo].[ClasificacionCuenta]
	DELETE FROM [dbo].[FacturaDetalle]
	DELETE FROM [dbo].[Inventario]
	DELETE FROM [dbo].[CompraProductosDetalle]
	DELETE FROM [dbo].[CompraProductos]
	DELETE FROM [dbo].[Producto]
	DELETE FROM [dbo].[Categoria]
	DELETE FROM [dbo].[Unidades]
	DELETE FROM [dbo].[Impuestos]
	DELETE FROM [dbo].[Factura]
	DELETE FROM [dbo].[Cliente]
	DELETE FROM [dbo].[FuncionesRolesPermisos]
	DELETE FROM [dbo].[TiposPermisos]
	DELETE FROM [dbo].[FuncionesRoles]
	DELETE FROM [dbo].[Funciones]
	DELETE FROM [dbo].[RolesUsuario]
	DELETE FROM [dbo].[Rol]
	DELETE FROM [dbo].[Usuario]

	SET IDENTITY_INSERT [dbo].[Usuario] ON 

	INSERT [dbo].[Usuario] ([usuId], [usuNick], [usuNombres], [usuApellidos], [usuCorreo], [usuTelefono], [usuPassw]) VALUES (1, N'admin', N'admin', N'admin', N'admin@test.com', N'98059636            ', N'QQBkAG0AaQBuAFQAbwB0AGEAbABAADIAMAAyADAA')
	SET IDENTITY_INSERT [dbo].[Usuario] OFF
	SET IDENTITY_INSERT [dbo].[Rol] ON 

	INSERT [dbo].[Rol] ([rolId], [rolDescripcion]) VALUES (1, N'ADMIN')
	INSERT [dbo].[Rol] ([rolId], [rolDescripcion]) VALUES (2, N'USER')
	INSERT [dbo].[Rol] ([rolId], [rolDescripcion]) VALUES (3, N'CONTADOR')
	SET IDENTITY_INSERT [dbo].[Rol] OFF
	SET IDENTITY_INSERT [dbo].[RolesUsuario] ON 

	INSERT [dbo].[RolesUsuario] ([rolUsuId], [rolId], [usuId], [usuNick]) VALUES (1, 1, 1, N'admin')
	SET IDENTITY_INSERT [dbo].[RolesUsuario] OFF
	SET IDENTITY_INSERT [dbo].[Funciones] ON 

	INSERT [dbo].[Funciones] ([funId], [funDescripcion]) VALUES (1, N'Formulario Usuarios')
	INSERT [dbo].[Funciones] ([funId], [funDescripcion]) VALUES (2, N'Formulario Clientes')
	INSERT [dbo].[Funciones] ([funId], [funDescripcion]) VALUES (3, N'Formulario Facturacion')
	INSERT [dbo].[Funciones] ([funId], [funDescripcion]) VALUES (4, N'Formulario Inventario')
	INSERT [dbo].[Funciones] ([funId], [funDescripcion]) VALUES (5, N'Formulario Productos')
	INSERT [dbo].[Funciones] ([funId], [funDescripcion]) VALUES (6, N'Formulario Compras De Producto')
	INSERT [dbo].[Funciones] ([funId], [funDescripcion]) VALUES (7, N'Formulario Lista Roles Usuario')
	INSERT [dbo].[Funciones] ([funId], [funDescripcion]) VALUES (8, N'Formulario Funciones')
	INSERT [dbo].[Funciones] ([funId], [funDescripcion]) VALUES (9, N'Formulario Roles Funcion')
	INSERT [dbo].[Funciones] ([funId], [funDescripcion]) VALUES (10, N'Formulario Permisos Funcion Rol')
	INSERT [dbo].[Funciones] ([funId], [funDescripcion]) VALUES (11, N'Formulario Gestion Roles Permisos')
	INSERT [dbo].[Funciones] ([funId], [funDescripcion]) VALUES (12, N'Formulario Roles')
	INSERT [dbo].[Funciones] ([funId], [funDescripcion]) VALUES (13, N'Formulario Permisos')
	INSERT [dbo].[Funciones] ([funId], [funDescripcion]) VALUES (14, N'Formulario Partidas Contables')
	INSERT [dbo].[Funciones] ([funId], [funDescripcion]) VALUES (15, N'Formulario Gestion Cuentas')
	INSERT [dbo].[Funciones] ([funId], [funDescripcion]) VALUES (16, N'Formulario Detalle Partida')
	INSERT [dbo].[Funciones] ([funId], [funDescripcion]) VALUES (17, N'Formulario Tipo Cuentas')
	INSERT [dbo].[Funciones] ([funId], [funDescripcion]) VALUES (18, N'Formulario Cuentas')
	INSERT [dbo].[Funciones] ([funId], [funDescripcion]) VALUES (19, N'Formulario Categorias')
	INSERT [dbo].[Funciones] ([funId], [funDescripcion]) VALUES (20, N'Formulario Unidades')
	INSERT [dbo].[Funciones] ([funId], [funDescripcion]) VALUES (21, N'Formulario Impuestos')
	SET IDENTITY_INSERT [dbo].[Funciones] OFF
	SET IDENTITY_INSERT [dbo].[FuncionesRoles] ON 

	INSERT [dbo].[FuncionesRoles] ([funRolesId], [rolId], [funId]) VALUES (1, 1, 1)
	INSERT [dbo].[FuncionesRoles] ([funRolesId], [rolId], [funId]) VALUES (2, 1, 2)
	INSERT [dbo].[FuncionesRoles] ([funRolesId], [rolId], [funId]) VALUES (3, 1, 3)
	INSERT [dbo].[FuncionesRoles] ([funRolesId], [rolId], [funId]) VALUES (4, 1, 4)
	INSERT [dbo].[FuncionesRoles] ([funRolesId], [rolId], [funId]) VALUES (5, 1, 5)
	INSERT [dbo].[FuncionesRoles] ([funRolesId], [rolId], [funId]) VALUES (6, 1, 6)
	INSERT [dbo].[FuncionesRoles] ([funRolesId], [rolId], [funId]) VALUES (7, 1, 7)
	INSERT [dbo].[FuncionesRoles] ([funRolesId], [rolId], [funId]) VALUES (8, 1, 8)
	INSERT [dbo].[FuncionesRoles] ([funRolesId], [rolId], [funId]) VALUES (9, 1, 9)
	INSERT [dbo].[FuncionesRoles] ([funRolesId], [rolId], [funId]) VALUES (10, 1, 10)
	INSERT [dbo].[FuncionesRoles] ([funRolesId], [rolId], [funId]) VALUES (11, 1, 11)
	INSERT [dbo].[FuncionesRoles] ([funRolesId], [rolId], [funId]) VALUES (12, 1, 12)
	INSERT [dbo].[FuncionesRoles] ([funRolesId], [rolId], [funId]) VALUES (13, 1, 13)
	INSERT [dbo].[FuncionesRoles] ([funRolesId], [rolId], [funId]) VALUES (14, 1, 14)
	INSERT [dbo].[FuncionesRoles] ([funRolesId], [rolId], [funId]) VALUES (15, 1, 15)
	INSERT [dbo].[FuncionesRoles] ([funRolesId], [rolId], [funId]) VALUES (16, 1, 16)
	INSERT [dbo].[FuncionesRoles] ([funRolesId], [rolId], [funId]) VALUES (17, 1, 17)
	INSERT [dbo].[FuncionesRoles] ([funRolesId], [rolId], [funId]) VALUES (18, 1, 18)
	INSERT [dbo].[FuncionesRoles] ([funRolesId], [rolId], [funId]) VALUES (19, 1, 19)
	INSERT [dbo].[FuncionesRoles] ([funRolesId], [rolId], [funId]) VALUES (20, 1, 20)
	INSERT [dbo].[FuncionesRoles] ([funRolesId], [rolId], [funId]) VALUES (21, 1, 21)
	SET IDENTITY_INSERT [dbo].[FuncionesRoles] OFF
	SET IDENTITY_INSERT [dbo].[TiposPermisos] ON 

	INSERT [dbo].[TiposPermisos] ([tipPermisoId], [tipPermisoDescripcion]) VALUES (1, N'Insertar')
	INSERT [dbo].[TiposPermisos] ([tipPermisoId], [tipPermisoDescripcion]) VALUES (2, N'Editar')
	INSERT [dbo].[TiposPermisos] ([tipPermisoId], [tipPermisoDescripcion]) VALUES (3, N'Eliminar')
	INSERT [dbo].[TiposPermisos] ([tipPermisoId], [tipPermisoDescripcion]) VALUES (4, N'Visualizar')
	SET IDENTITY_INSERT [dbo].[TiposPermisos] OFF
	SET IDENTITY_INSERT [dbo].[FuncionesRolesPermisos] ON 

	INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (7, 1, N'Puede Insertar', 1, 1)
	INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (7, 2, N'Puede Editar', 1, 2)
	INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (7, 3, N'Puede Eliminar', 1, 3)
	INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (7, 4, N'Puede Visualizar', 1, 4)
	INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (1, 7, N'Puede Insertar', 1, 1)
	INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (1, 8, N'Puede Editar', 1, 2)
	INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (1, 9, N'Puede Eliminar', 1, 3)
	INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (1, 10, N'Puede Visualizar', 1, 4)
	INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (9, 12, N'Puede Insertar', 1, 1)
	INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (9, 14, N'Puede Editar', 1, 2)
	INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (9, 15, N'Puede Eliminar', 1, 3)
	INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (9, 16, N'Puede Visualizar', 1, 4)
	INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (8, 17, N'Puede Insertar', 1, 1)
	INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (8, 18, N'Puede Editar', 1, 2)
	INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (8, 19, N'Puede Eliminar', 1, 3)
	INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (8, 20, N'Puede Visualizar', 1, 4)
	INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (10, 21, N'Puede Insertar', 1, 1)
	INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (10, 22, N'Puede Editar', 1, 2)
	INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (10, 23, N'Puede Eliminar', 1, 3)
	INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (10, 24, N'Puede Visualizar', 1, 4)
	INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (2, 25, N'El usuario puede insertar', 1, 1)
	INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (2, 26, N'El usuario puede editar', 1, 2)
	INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (2, 27, N'El usuario puede eliminar', 1, 3)
	INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (2, 28, N'El usuario puede visualizar', 1, 4)
	INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (3, 29, N'El usuario puede insertar', 1, 1)
	INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (3, 30, N'El usuario puede editar', 1, 2)
	INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (3, 31, N'El usuario puede eliminar', 1, 3)
	INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (3, 32, N'El usuario puede visualizar', 1, 4)
	INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (4, 33, N'El usuario puede insertar', 1, 1)
	INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (4, 34, N'El usuario puede editar', 1, 2)
	INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (4, 35, N'El usuario puede eliminar', 1, 3)
	INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (4, 36, N'El usuario puede visualizar', 1, 4)
	INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (5, 37, N'El usuario puede insertar', 1, 1)
	INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (5, 38, N'El usuario puede editar', 1, 2)
	INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (5, 39, N'El usuario puede eliminar', 1, 3)
	INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (5, 40, N'El usuario puede visualizar', 1, 4)
	INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (6, 41, N'El usuario puede insertar', 1, 1)
	INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (6, 42, N'El usuario puede editar', 1, 2)
	INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (6, 43, N'El usuario puede eliminar', 1, 3)
	INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (6, 44, N'El usuario puede visualizar', 1, 4)
	INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (11, 45, N'El usuario puede insertar', 1, 1)
	INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (11, 46, N'El usuario puede editar', 1, 2)
	INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (11, 47, N'El usuario puede eliminar', 1, 3)
	INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (11, 48, N'El usuario puede visualizar', 1, 4)
	INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (12, 49, N'El usuario puede insertar', 1, 1)
	INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (12, 50, N'El usuario puede editar', 1, 2)
	INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (12, 51, N'El usuario puede eliminar', 1, 3)
	INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (12, 52, N'El usuario puede visualizar', 1, 4)
	INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (13, 53, N'El usuario puede insertar', 1, 1)
	INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (13, 54, N'El usuario puede editar', 1, 2)
	INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (13, 55, N'El usuario puede eliminar', 1, 3)
	INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (13, 56, N'El usuario puede visualizar', 1, 4)
	INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (14, 57, N'El usuario puede insertar', 1, 1)
	INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (14, 58, N'El usuario puede editar', 1, 2)
	INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (14, 59, N'El usuario puede eliminar', 1, 3)
	INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (14, 60, N'El usuario puede visualizar', 1, 4)
	INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (15, 61, N'El usuario puede insertar', 1, 1)
	INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (15, 62, N'El usuario puede editar', 1, 2)
	INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (15, 63, N'El usuario puede eliminar', 1, 3)
	INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (15, 64, N'El usuario puede visualizar', 1, 4)
	INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (16, 65, N'El usuario puede insertar', 1, 1)
	INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (16, 66, N'El usuario puede editar', 1, 2)
	INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (16, 67, N'El usuario puede eliminar', 1, 3)
	INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (16, 68, N'El usuario puede visualizar', 1, 4)
	INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (17, 69, N'El usuario puede insertar', 1, 1)
	INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (17, 70, N'El usuario puede editar', 1, 2)
	INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (17, 71, N'El usuario puede eliminar', 1, 3)
	INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (17, 72, N'El usuario puede visualizar', 1, 4)
	INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (18, 73, N'El usuario puede insertar', 1, 1)
	INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (18, 74, N'El usuario puede editar', 1, 2)
	INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (18, 75, N'El usuario puede eliminar', 1, 3)
	INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (18, 76, N'El usuario puede visualizar', 1, 4)
	INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (19, 77, N'El usuario puede insertar', 1, 1)
	INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (19, 78, N'El usuario puede editar', 1, 2)
	INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (19, 79, N'El usuario puede eliminar', 1, 3)
	INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (19, 80, N'El usuario puede visualizar', 1, 4)
	INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (20, 81, N'El usuario puede insertar', 1, 1)
	INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (20, 82, N'El usuario puede editar', 1, 2)
	INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (20, 83, N'El usuario puede eliminar', 1, 3)
	INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (20, 84, N'El usuario puede visualizar', 1, 4)
	INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (21, 85, N'El usuario puede insertar', 1, 1)
	INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (21, 86, N'El usuario puede editar', 1, 2)
	INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (21, 87, N'El usuario puede eliminar', 1, 3)
	INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (21, 88, N'El usuario puede visualizar', 1, 4)
	SET IDENTITY_INSERT [dbo].[FuncionesRolesPermisos] OFF
	SET IDENTITY_INSERT [dbo].[Cliente] ON 

	INSERT [dbo].[Cliente] ([cliId], [cliNombres], [cliApellidos], [cliCorreo], [cliTelefono], [cliDireccion], [usuId]) VALUES (1, N'CONSUMIDOR FINAL', N'', N'', N'                    ', N'', 1)
	SET IDENTITY_INSERT [dbo].[Cliente] OFF
	SET IDENTITY_INSERT [dbo].[Impuestos] ON 

	INSERT [dbo].[Impuestos] ([impId], [impDescripcion], [impValor]) VALUES (1, N'ISV', 15)
	INSERT [dbo].[Impuestos] ([impId], [impDescripcion], [impValor]) VALUES (2, N'N/A', 0)
	SET IDENTITY_INSERT [dbo].[Impuestos] OFF
	SET IDENTITY_INSERT [dbo].[Unidades] ON 

	INSERT [dbo].[Unidades] ([uniId], [uniDescripcion]) VALUES (1, N'UNIDAD')
	INSERT [dbo].[Unidades] ([uniId], [uniDescripcion]) VALUES (2, N'LIBRA')
	INSERT [dbo].[Unidades] ([uniId], [uniDescripcion]) VALUES (3, N'KILOGRAMO')
	SET IDENTITY_INSERT [dbo].[Unidades] OFF
	SET IDENTITY_INSERT [dbo].[Categoria] ON 

	INSERT [dbo].[Categoria] ([catProductoId], [catProductoDescripcion]) VALUES (1, N'LACTEOS')
	INSERT [dbo].[Categoria] ([catProductoId], [catProductoDescripcion]) VALUES (2, N'CARNES')
	INSERT [dbo].[Categoria] ([catProductoId], [catProductoDescripcion]) VALUES (3, N'BEBIDAS')
	INSERT [dbo].[Categoria] ([catProductoId], [catProductoDescripcion]) VALUES (4, N'BEBIDAS GASEOSAS')
	SET IDENTITY_INSERT [dbo].[Categoria] OFF
	SET IDENTITY_INSERT [dbo].[ClasificacionCuenta] ON 

	INSERT [dbo].[ClasificacionCuenta] ([claCtaId], [claCtaDescripcion]) VALUES (1, N'ACTIVO')
	INSERT [dbo].[ClasificacionCuenta] ([claCtaId], [claCtaDescripcion]) VALUES (2, N'PASIVO')
	INSERT [dbo].[ClasificacionCuenta] ([claCtaId], [claCtaDescripcion]) VALUES (3, N'CAPITAL')
	SET IDENTITY_INSERT [dbo].[ClasificacionCuenta] OFF
	INSERT [dbo].[Cuentas] ([ctaId], [ctaDescripcion], [claCtaId]) VALUES (N'1', N'CAJA', 1)
	INSERT [dbo].[Cuentas] ([ctaId], [ctaDescripcion], [claCtaId]) VALUES (N'2', N'CUENTAS POR COBRAR', 1)
	INSERT [dbo].[Cuentas] ([ctaId], [ctaDescripcion], [claCtaId]) VALUES (N'3', N'INGRESO POR VENTAS', 1)
	INSERT [dbo].[Cuentas] ([ctaId], [ctaDescripcion], [claCtaId]) VALUES (N'4', N'BANCOS', 1)
	INSERT [dbo].[Cuentas] ([ctaId], [ctaDescripcion], [claCtaId]) VALUES (N'5', N'EFECTIVO', 1)
	INSERT [dbo].[Cuentas] ([ctaId], [ctaDescripcion], [claCtaId]) VALUES (N'6', N'INVENTARIO', 1)

END
GO
