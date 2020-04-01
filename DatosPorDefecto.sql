USE [supermercados]
GO
SET IDENTITY_INSERT [dbo].[Cliente] ON 

INSERT [dbo].[Cliente] ([cliId], [cliNombres], [cliApellidos], [cliCorreo], [cliTelefono], [cliDireccion], [usuId]) VALUES (1, N'GENERAL', N'N/A', N'N/A', N'N/A                 ', N'N/A', 5)
SET IDENTITY_INSERT [dbo].[Cliente] OFF
SET IDENTITY_INSERT [dbo].[Unidades] ON 

INSERT [dbo].[Unidades] ([uniId], [uniDescripcion]) VALUES (1, N'UNIDAD')
INSERT [dbo].[Unidades] ([uniId], [uniDescripcion]) VALUES (2, N'LIBRA')
INSERT [dbo].[Unidades] ([uniId], [uniDescripcion]) VALUES (3, N'KILOGRAMO')
SET IDENTITY_INSERT [dbo].[Unidades] OFF
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([usuId], [usuNick], [usuNombres], [usuApellidos], [usuCorreo], [usuTelefono], [usuPassw]) VALUES (5, N'admin', N'admin', N'admin', N'admin@test.com', N'98059636            ', N'QQBkAG0AaQBuAFQAbwB0AGEAbABAADIAMAAyADAA')
SET IDENTITY_INSERT [dbo].[Usuario] OFF
SET IDENTITY_INSERT [dbo].[Rol] ON 

INSERT [dbo].[Rol] ([rolId], [rolDescripcion]) VALUES (1, N'ADMIN')
INSERT [dbo].[Rol] ([rolId], [rolDescripcion]) VALUES (2, N'USER')
INSERT [dbo].[Rol] ([rolId], [rolDescripcion]) VALUES (3, N'CONTADOR')
SET IDENTITY_INSERT [dbo].[Rol] OFF
SET IDENTITY_INSERT [dbo].[RolesUsuario] ON 

INSERT [dbo].[RolesUsuario] ([rolUsuId], [rolId], [usuId], [usuNick]) VALUES (7, 1, 5, N'admin')
SET IDENTITY_INSERT [dbo].[RolesUsuario] OFF
SET IDENTITY_INSERT [dbo].[Funciones] ON 

INSERT [dbo].[Funciones] ([funId], [funDescripcion]) VALUES (1, N'Formulario Usuarios')
INSERT [dbo].[Funciones] ([funId], [funDescripcion]) VALUES (3, N'Formulario Clientes')
INSERT [dbo].[Funciones] ([funId], [funDescripcion]) VALUES (5, N'Formulario Facturacion')
INSERT [dbo].[Funciones] ([funId], [funDescripcion]) VALUES (6, N'Formulario Inventario')
INSERT [dbo].[Funciones] ([funId], [funDescripcion]) VALUES (7, N'Formulario Productos')
INSERT [dbo].[Funciones] ([funId], [funDescripcion]) VALUES (8, N'Formulario Compras De Producto')
INSERT [dbo].[Funciones] ([funId], [funDescripcion]) VALUES (9, N'Formulario Lista Roles Usuario')
INSERT [dbo].[Funciones] ([funId], [funDescripcion]) VALUES (10, N'Formulario Funciones')
INSERT [dbo].[Funciones] ([funId], [funDescripcion]) VALUES (11, N'Formulario Roles Funcion')
INSERT [dbo].[Funciones] ([funId], [funDescripcion]) VALUES (12, N'Formulario Permisos Funcion Rol')
INSERT [dbo].[Funciones] ([funId], [funDescripcion]) VALUES (13, N'Formulario Gestion Roles Permisos')
INSERT [dbo].[Funciones] ([funId], [funDescripcion]) VALUES (14, N'Formulario Roles')
INSERT [dbo].[Funciones] ([funId], [funDescripcion]) VALUES (15, N'Formulario Permisos')
INSERT [dbo].[Funciones] ([funId], [funDescripcion]) VALUES (16, N'Formulario Partidas Contables')
INSERT [dbo].[Funciones] ([funId], [funDescripcion]) VALUES (17, N'Formulario Gestion Cuentas')
INSERT [dbo].[Funciones] ([funId], [funDescripcion]) VALUES (18, N'Formulario Detalle Partida')
INSERT [dbo].[Funciones] ([funId], [funDescripcion]) VALUES (19, N'Formulario Tipo Cuentas')
INSERT [dbo].[Funciones] ([funId], [funDescripcion]) VALUES (20, N'Formulario Cuentas')
SET IDENTITY_INSERT [dbo].[Funciones] OFF
SET IDENTITY_INSERT [dbo].[FuncionesRoles] ON 

INSERT [dbo].[FuncionesRoles] ([funRolesId], [rolId], [funId]) VALUES (1, 1, 1)
INSERT [dbo].[FuncionesRoles] ([funRolesId], [rolId], [funId]) VALUES (5, 1, 3)
INSERT [dbo].[FuncionesRoles] ([funRolesId], [rolId], [funId]) VALUES (7, 1, 5)
INSERT [dbo].[FuncionesRoles] ([funRolesId], [rolId], [funId]) VALUES (8, 1, 6)
INSERT [dbo].[FuncionesRoles] ([funRolesId], [rolId], [funId]) VALUES (9, 1, 7)
INSERT [dbo].[FuncionesRoles] ([funRolesId], [rolId], [funId]) VALUES (10, 1, 8)
INSERT [dbo].[FuncionesRoles] ([funRolesId], [rolId], [funId]) VALUES (11, 1, 9)
INSERT [dbo].[FuncionesRoles] ([funRolesId], [rolId], [funId]) VALUES (12, 1, 10)
INSERT [dbo].[FuncionesRoles] ([funRolesId], [rolId], [funId]) VALUES (13, 1, 11)
INSERT [dbo].[FuncionesRoles] ([funRolesId], [rolId], [funId]) VALUES (14, 1, 12)
INSERT [dbo].[FuncionesRoles] ([funRolesId], [rolId], [funId]) VALUES (21, 1, 13)
INSERT [dbo].[FuncionesRoles] ([funRolesId], [rolId], [funId]) VALUES (23, 1, 14)
INSERT [dbo].[FuncionesRoles] ([funRolesId], [rolId], [funId]) VALUES (24, 1, 15)
INSERT [dbo].[FuncionesRoles] ([funRolesId], [rolId], [funId]) VALUES (25, 1, 16)
INSERT [dbo].[FuncionesRoles] ([funRolesId], [rolId], [funId]) VALUES (26, 1, 17)
INSERT [dbo].[FuncionesRoles] ([funRolesId], [rolId], [funId]) VALUES (27, 1, 18)
INSERT [dbo].[FuncionesRoles] ([funRolesId], [rolId], [funId]) VALUES (28, 1, 19)
INSERT [dbo].[FuncionesRoles] ([funRolesId], [rolId], [funId]) VALUES (29, 1, 20)
SET IDENTITY_INSERT [dbo].[FuncionesRoles] OFF
SET IDENTITY_INSERT [dbo].[TiposPermisos] ON 

INSERT [dbo].[TiposPermisos] ([tipPermisoId], [tipPermisoDescripcion]) VALUES (1, N'Insertar')
INSERT [dbo].[TiposPermisos] ([tipPermisoId], [tipPermisoDescripcion]) VALUES (2, N'Editar')
INSERT [dbo].[TiposPermisos] ([tipPermisoId], [tipPermisoDescripcion]) VALUES (3, N'Eliminar')
INSERT [dbo].[TiposPermisos] ([tipPermisoId], [tipPermisoDescripcion]) VALUES (4, N'Visualizar')
SET IDENTITY_INSERT [dbo].[TiposPermisos] OFF
SET IDENTITY_INSERT [dbo].[FuncionesRolesPermisos] ON 

INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (1, 1, N'Puede Insertar', 1, 1)
INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (1, 2, N'Puede Editar', 1, 2)
INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (1, 9, N'El usuario puede eliminar', 1, 3)
INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (11, 20, N'El usuario puede insertar', 1, 1)
INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (11, 21, N'El usuario puede editar', 1, 2)
INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (11, 22, N'El usuario puede eliminar', 1, 3)
INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (11, 23, N'El usuario puede visualizar', 1, 4)
INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (12, 31, N'El usuario puede insertar', 1, 1)
INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (12, 32, N'El usuario puede editar', 1, 2)
INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (12, 33, N'El usuario puede eliminar', 1, 3)
INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (12, 35, N'El usuario puede visualizar', 1, 4)
INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (13, 36, N'El usuario puede visualizar', 1, 4)
INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (13, 37, N'El usuario puede eliminar', 1, 3)
INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (13, 38, N'El usuario puede editar', 1, 2)
INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (13, 39, N'El usuario puede insertar', 1, 1)
INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (14, 40, N'El usuario puede insertar', 1, 1)
INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (14, 41, N'El usuario puede editar', 1, 2)
INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (14, 42, N'El usuario puede eliminar', 1, 3)
INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (14, 43, N'El usuario puede visualizar', 1, 4)
INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (1, 52, N'El usuario puede visualizar', 1, 4)
INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (21, 67, N'El usuario puede visualizar', 1, 4)
INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (5, 69, N'El usuario puede insertar', 1, 1)
INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (5, 70, N'El usuario puede editar', 1, 2)
INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (5, 71, N'El usuario puede eliminar', 1, 3)
INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (5, 72, N'El usuario puede visualizar', 1, 4)
INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (7, 77, N'El usuario puede insertar', 1, 1)
INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (7, 78, N'El usuario puede editar', 1, 2)
INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (7, 79, N'El usuario puede eliminar', 1, 3)
INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (7, 80, N'El usuario puede visualizar', 1, 4)
INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (8, 81, N'El usuario puede insertar', 1, 1)
INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (8, 82, N'El usuario puede editar', 1, 2)
INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (8, 83, N'El usuario puede eliminar', 1, 3)
INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (8, 84, N'El usuario puede visualizar', 1, 4)
INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (9, 85, N'El usuario puede insertar', 1, 1)
INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (9, 86, N'El usuario puede editar', 1, 2)
INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (9, 87, N'El usuario puede eliminar', 1, 3)
INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (9, 88, N'El usuario puede visualizar', 1, 4)
INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (10, 89, N'El usuario puede insertar', 1, 1)
INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (10, 90, N'El usuario puede editar', 1, 2)
INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (10, 91, N'El usuario puede eliminar', 1, 3)
INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (10, 92, N'El usuario puede visualizar', 1, 4)
INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (21, 93, N'El usuario puede insertar', 1, 1)
INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (21, 94, N'El usuario puede editar', 1, 2)
INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (21, 95, N'El usuario puede eliminar', 1, 3)
INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (23, 96, N'El usuario puede insertar', 1, 1)
INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (23, 97, N'El usuario puede editar', 1, 2)
INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (23, 98, N'El usuario puede eliminar', 1, 3)
INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (23, 99, N'El usuario puede visualizar', 1, 4)
INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (24, 100, N'El usuario puede insertar', 1, 1)
INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (24, 101, N'El usuario puede editar', 1, 2)
INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (24, 102, N'El usuario puede eliminar', 1, 3)
INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (24, 103, N'El usuario puede visualizar', 1, 4)
INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (25, 104, N'El usuario puede insertar', 1, 1)
INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (25, 105, N'El usuario puede editar', 1, 2)
INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (25, 106, N'El usuario puede eliminar', 1, 3)
INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (25, 107, N'El usuario puede visualizar', 1, 4)
INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (26, 108, N'El usuario puede insertar', 1, 1)
INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (26, 109, N'El usuario puede editar', 1, 2)
INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (26, 110, N'El usuario puede eliminar', 1, 3)
INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (26, 111, N'El usuario puede visualizar', 1, 4)
INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (27, 112, N'El usuario puede insertar', 1, 1)
INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (27, 113, N'El usuario puede editar', 1, 2)
INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (27, 114, N'El usuario puede eliminar', 1, 3)
INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (27, 115, N'El usuario puede visualizar', 1, 4)
INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (28, 116, N'El usuario puede insertar', 1, 1)
INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (28, 117, N'El usuario puede editar', 1, 2)
INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (28, 118, N'El usuario puede eliminar', 1, 3)
INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (28, 119, N'El usuario puede visualizar', 1, 4)
INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (29, 120, N'El usuario puede insertar', 1, 1)
INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (29, 121, N'El usuario puede editar', 1, 2)
INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (29, 122, N'El usuario puede eliminar', 1, 3)
INSERT [dbo].[FuncionesRolesPermisos] ([funRolesId], [perFunId], [perFunDescripcion], [perFunValor], [tipPermisoId]) VALUES (29, 123, N'El usuario puede visualizar', 1, 4)
SET IDENTITY_INSERT [dbo].[FuncionesRolesPermisos] OFF
SET IDENTITY_INSERT [dbo].[ClasificacionCuenta] ON 

INSERT [dbo].[ClasificacionCuenta] ([claCtaId], [claCtaDescripcion]) VALUES (1, N'ACTIVO')
INSERT [dbo].[ClasificacionCuenta] ([claCtaId], [claCtaDescripcion]) VALUES (2, N'PASIVO')
INSERT [dbo].[ClasificacionCuenta] ([claCtaId], [claCtaDescripcion]) VALUES (4, N'CAPITAL')
SET IDENTITY_INSERT [dbo].[ClasificacionCuenta] OFF
INSERT [dbo].[Cuentas] ([ctaId], [ctaDescripcion], [claCtaId]) VALUES (N'01', N'CAJA', 1)
INSERT [dbo].[Cuentas] ([ctaId], [ctaDescripcion], [claCtaId]) VALUES (N'02', N'CUENTAS POR COBRAR', 1)
INSERT [dbo].[Cuentas] ([ctaId], [ctaDescripcion], [claCtaId]) VALUES (N'03', N'INGRESOS', 2)
