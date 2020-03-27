USE [supermercados]
GO

/****** Object:  StoredProcedure [dbo].[WWUsuarios]    Script Date: 26/3/2020 15:16:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE WWUsuarios
	-- Add the parameters for the stored procedure here

	--Parametros Usuario
	@idUsuario int = 0, 
	@accion varchar(200) = 'INS',
	@parametro varchar(200) = 'null',
	@returnId int = 0 OUTPUT,
	@usuNick varchar(40) = 'null',
	@usuNombres varchar(100) = 'null',
	@usuApellidos varchar(100) = 'null',
	@usuCorreo varchar(100) = 'null',
	@usuTelefono char(20) = 'null',
	@usuPassw varchar(100) = 'null',
	--Fin Parametros Usuario

	--Parametros Roles de Usuario
	@idRoleUser int = 0,
	@returnIdRoleUser int = 0 OUTPUT,
	@rolId int =0,
	@contadorRolesUser int =0 OUTPUT,
	@rolDescripcion varchar(60) = 'null',
	--Fin Parametros Roles Usuario

	--Parametros Funciones
	@idFuncion int =0,
	@contadorFunciones int = 0 OUTPUT,
	@funDescripcion varchar(100) = 'null'
	--Fin Parametros Funciones

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here

--TODO DE USUARIOS
	IF @accion ='INS'
	BEGIN
		INSERT INTO [dbo].[Usuario]
           ([usuNick]
           ,[usuNombres]
           ,[usuApellidos]
           ,[usuCorreo]
           ,[usuTelefono]
           ,[usuPassw])
     VALUES
           (@usuNick
           ,@usuNombres
           ,@usuApellidos
           ,@usuCorreo
           ,@usuTelefono
           ,@usuPassw)
	END

	IF @accion = 'UPD'
	BEGIN
		IF @usuPassw = ''
		BEGIN
			UPDATE [dbo].[Usuario]
		SET [usuNick] = @usuNick
      ,[usuNombres] = @usuNombres
      ,[usuApellidos] = @usuApellidos
      ,[usuCorreo] = @usuCorreo
      ,[usuTelefono] = @usuTelefono
		WHERE usuId = @idUsuario
		END

		IF @usuPassw != ''
		BEGIN
			UPDATE [dbo].[Usuario]
		SET [usuNick] = @usuNick
      ,[usuNombres] = @usuNombres
      ,[usuApellidos] = @usuApellidos
      ,[usuCorreo] = @usuCorreo
      ,[usuTelefono] = @usuTelefono
      ,[usuPassw] = @usuPassw
		WHERE usuId = @idUsuario
		END

	END

	IF @accion = 'DLT'
	BEGIN
		
	DELETE FROM [dbo].[RolesUsuario]
		  WHERE [RolesUsuario].[usuId] = @idUsuario

		DELETE FROM [dbo].[Usuario]
		WHERE usuId = @idUsuario
	END

	IF @accion = 'SELECT_GRID_USER'
	BEGIN
		SELECT [usuId] AS 'ID'
			  ,[usuNick] AS 'NICK'
			  ,[usuNombres] AS 'NOMBRES'
			  ,[usuApellidos] AS 'APELLIDOS'
			  ,[usuCorreo] AS 'CORREO'
			  ,[usuTelefono] AS 'TELEFONO'
			  FROM [dbo].[Usuario]
	END

	IF @accion = 'SELECT_GRID_USER_PARAMETRO'
	BEGIN 
		SELECT [usuId] AS 'ID'
			  ,[usuNick] AS 'NICK'
			  ,[usuNombres] AS 'NOMBRES'
			  ,[usuApellidos] AS 'APELLIDOS'
			  ,[usuCorreo] AS 'CORREO'
			  ,[usuTelefono] AS 'TELEFONO'
			  FROM [dbo].[Usuario]
			  WHERE ([usuId] like '%'+ @parametro +'%' or [usuNick] like '%'+ @parametro +'%' or [usuNombres] like '%'+ @parametro +'%' or [usuApellidos] like '%'+ @parametro +'%'
			  or [usuCorreo] like '%'+ @parametro +'%' or [usuTelefono] like '%'+ @parametro +'%')
	END

	IF @accion = 'SELECT_LAST_ID_USER'
	BEGIN 
		SELECT @returnId = COUNT([usuId])
			  FROM [dbo].[Usuario]
			  RETURN
	END
--FIN TODO USUARIOS


--TODO ROLES
	IF @accion ='INS_ROL'
	BEGIN
		INSERT INTO [dbo].[Rol]
           ([rolDescripcion])
     VALUES
           (@rolDescripcion)
	END
	
	IF @accion = 'UPD_ROL'
	BEGIN
		UPDATE [dbo].[Rol]
		SET [rolDescripcion] = @rolDescripcion
		WHERE [Rol].[rolId] = @rolId
	END

	IF @accion = 'DLT_ROL'
	BEGIN
		
	DELETE FROM [dbo].Rol
		  WHERE Rol.rolId = @rolId
	END

	IF @accion = 'SELECT_GRID_ROL'
	BEGIN
		SELECT [rolId] AS 'ID'
      ,[rolDescripcion] AS 'ROL'
		FROM [supermercados].[dbo].[Rol]
	END

	IF @accion = 'SELECT_GRID_ROL_PARAMETRO'
	BEGIN
		SELECT [rolId] AS 'ID'
      ,[rolDescripcion] AS 'ROL'
		FROM [supermercados].[dbo].[Rol]
		WHERE (rolId like '%'+ @parametro +'%' or rolDescripcion like '%'+@parametro+'%')
	END
	
	IF @accion = 'CB_ROLES'
	BEGIN 
		SELECT [rolId] 
      ,[rolDescripcion]
		FROM [supermercados].[dbo].[Rol]
	END
--FIN TODO ROLES


--TODO DE ROLES DE USUARIO
	IF @accion ='INS_ROL_USER'
	BEGIN
		INSERT INTO [dbo].[RolesUsuario]
           ([rolId]
           ,[usuId]
           ,[usuNick])
     VALUES
           (@rolId
           ,@idUsuario
           ,@usuNick)
	END

	IF @accion = 'UPD_ROL_USER'
	BEGIN
		UPDATE [dbo].[RolesUsuario]
	 SET [rolId] = @rolId
      ,[usuId] = @idUsuario
      ,[usuNick] = @usuNick
		WHERE [rolUsuId] = @idRoleUser
	END

	IF @accion = 'DLT_ROL_USER'
	BEGIN
		DELETE FROM [dbo].[RolesUsuario]
		WHERE [rolUsuId] = @idRoleUser
	END

	IF @accion = 'SELECT_GRID_ROLES'
	BEGIN 
		SELECT [RolesUsuario].[rolUsuId] as 'ID'
		,[Rol].[rolId] AS 'ID ROL'
      ,[Rol].[rolDescripcion] AS 'DESCRIPCION'
		FROM [dbo].[Rol] INNER JOIN [dbo].[RolesUsuario] ON [dbo].[Rol].[rolId] = [dbo].[RolesUsuario].[rolId] INNER JOIN [dbo].[Usuario] ON [dbo].[RolesUsuario].[usuId] = [dbo].[Usuario].[usuId]
		WHERE [dbo].[Usuario].[usuId] = @idUsuario
	END

	IF @accion = 'VERIFICAR_EXISTENCIA_ROLE_USUARIO'
	BEGIN 
		SELECT @contadorRolesUser = COUNT([RolesUsuario].[rolUsuId])
		FROM [dbo].[Rol] INNER JOIN [dbo].[RolesUsuario] ON [dbo].[Rol].[rolId] = [dbo].[RolesUsuario].[rolId] INNER JOIN [dbo].[Usuario] ON [dbo].[RolesUsuario].[usuId] = [dbo].[Usuario].[usuId]
		WHERE [dbo].[Usuario].[usuId] = @idUsuario AND [Rol].[rolId] = @rolId
		RETURN
	END

	IF @accion = 'SELECT_GRID_ROLES_PARAMETRO'
	BEGIN 
		SELECT [RolesUsuario].[rolUsuId] as 'ID'
		,[Rol].[rolId] AS 'ID ROL'
      ,[Rol].[rolDescripcion] AS 'DESCRIPCION'
		FROM [dbo].[Rol] INNER JOIN [dbo].[RolesUsuario] ON [dbo].[Rol].[rolId] = [dbo].[RolesUsuario].[rolId] INNER JOIN [dbo].[Usuario] ON [dbo].[RolesUsuario].[usuId] = [dbo].[Usuario].[usuId]
		WHERE  [dbo].[Usuario].[usuId] = @idUsuario AND ([RolesUsuario].[rolUsuId] like '%'+ @parametro +'%' or [Rol].[rolId] like '%'+ @parametro +'%' or [Rol].[rolDescripcion] like '%'+@parametro+'%')
	END

	IF @accion = 'SELECT_LAST_ID_USER_ROLE'
	BEGIN 
		SELECT @returnIdRoleUser = COUNT([RolesUsuario].[rolUsuId])
			  FROM [dbo].[RolesUsuario]
			  RETURN
	END

--FIN TODO ROLES DE USUARIO


--TODO FUNCIONES DE USUARIO
	IF @accion ='INS_FUNCION'
	BEGIN
		INSERT INTO [dbo].[Funciones]
           ([funDescripcion])
     VALUES
           (@funDescripcion)
	END
	
	IF @accion = 'UPD_FUNCION'
	BEGIN
		UPDATE [dbo].[Funciones]
		SET [funDescripcion] = @funDescripcion
		WHERE [Funciones].[funId] = @idFuncion
	END

	IF @accion = 'DLT_FUNCION'
	BEGIN
		
	DELETE FROM [dbo].Funciones
		  WHERE Funciones.funId = @idFuncion
	END

	IF @accion = 'SELECT_GRID_FUNCIONES'
	BEGIN
		SELECT Funciones.funId AS 'ID', Funciones.funDescripcion AS 'FUNCION'
		FROM Funciones

	END

	IF @accion = 'SELECT_LAST_ID_FUNCION'
	BEGIN 
		SELECT @contadorFunciones = COUNT(Funciones.funId)
			  FROM [dbo].Funciones
			  RETURN
	END

	IF @accion = 'SELECT_GRID_FUNCIONES_PARAMETRO'
	BEGIN
		SELECT Funciones.funId AS 'ID', Funciones.funDescripcion AS 'FUNCION'
		FROM Funciones WHERE (funId like '%'+ @parametro +'%' or funDescripcion like '%'+@parametro+'%')

	END

	IF @accion = 'SELECT_GRID_FUNCIONES_USER'
	BEGIN 
		SELECT [FuncionesRoles].[funRolesId] AS 'ID'
      ,[Funciones].[funDescripcion] AS 'FUNCION'
	  ,[Rol].rolDescripcion AS 'ROL'
		FROM [dbo].[FuncionesRoles] INNER JOIN [dbo].[Rol] ON [dbo].[FuncionesRoles].[rolId] = [dbo].[Rol].[rolId] INNER JOIN [Funciones] ON [FuncionesRoles].[funId] = [Funciones].[funId]
		WHERE [Rol].[rolId] = @rolId
	END
--FIN TODO FUNCIONES DE USUARIO



--TODO PERMISOS DE LAS FUNCIONES
	IF @accion = 'SELECT_GRID_PERMISOS_FUNCIONES'
	BEGIN 
		SELECT 
		[FuncionesRolesPermisos].[perFunId] AS 'ID'
	   ,[TiposPermisos].[tipPermisoDescripcion] AS 'PERMISO'
	   ,[Funciones].[funDescripcion] AS 'FUNCION'
  FROM [FuncionesRolesPermisos] INNER JOIN [TiposPermisos] ON [FuncionesRolesPermisos].[tipPermisoId] = [TiposPermisos].[tipPermisoId]
  INNER JOIN [FuncionesRoles] ON [FuncionesRoles].[funRolesId] = [FuncionesRolesPermisos].[funRolesId] INNER JOIN [Funciones] ON [FuncionesRoles].[funId] = [Funciones].[funId]
  WHERE FuncionesRoles.funRolesId = @idFuncion
	END

	IF @accion = 'SELECT_GRID_PERMISOS_FUNCIONES_PARAMETRO'
	BEGIN 
		SELECT 
		[FuncionesRolesPermisos].[perFunId] AS 'ID'
	   ,[TiposPermisos].[tipPermisoDescripcion] AS 'PERMISO'
	   ,[Funciones].[funDescripcion] AS 'FUNCION'
  FROM [FuncionesRolesPermisos] INNER JOIN [TiposPermisos] ON [FuncionesRolesPermisos].[tipPermisoId] = [TiposPermisos].[tipPermisoId]
  INNER JOIN [FuncionesRoles] ON [FuncionesRoles].[funRolesId] = [FuncionesRolesPermisos].[funRolesId] INNER JOIN [Funciones] ON [FuncionesRoles].[funId] = [Funciones].[funId]
  WHERE FuncionesRoles.funRolesId = @idFuncion AND ([FuncionesRolesPermisos].[perFunId] like '%'+ @parametro +'%' OR [TiposPermisos].[tipPermisoDescripcion] like '%'+@parametro+'%' 
  OR [Funciones].[funDescripcion] like '%'+@parametro+'%')
	END
--FIN TODO PERMISOS DE LAS FUNCIONES

END
GO


