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
	@CONTADOR INT = 0 OUTPUT,
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
	@funDescripcion varchar(100) = 'null',
	@contadorFunRol int = 0 OUTPUT,
	@idFunRol int = 0,
	@perFunDescripcion varchar(100) = 'null',
	@perFunValor bit = 0,
	@tipPermisoId int = 0,
	@tipPermisoDescripcion varchar(100) = 'null',
	@perFunId int = 0,
	@contadorPermisoFunRol int = 0 OUTPUT,
	--Fin Parametros Funciones

	--PARAMETROS LOGIN
	@nick varchar(100) = 'null',
	@email varchar(100) = 'null',
	@pssw varchar(200) = 'null',
	@ReturnusuNick varchar(100) = 'null' OUTPUT,
	@ReturnusuCorreo varchar(100) = 'null' OUTPUT,
	@ReturnrolId int = 0 OUTPUT,
	@ReturnrolDescripcion varchar(100) = 'null' OUTPUT,
	@var bit =0 OUTPUT
	--FIN PARAMETROS LOGIN

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

	IF @accion = 'VERIFICAR_USUARIO_NICK'
	BEGIN
	SELECT @CONTADOR = COUNT(Usuario.usuNick)
	FROM Usuario 
	WHERE Usuario.usuNick = @usuNick
	END

	IF @accion = 'VERIFICAR_USUARIO_EMAIL'
	BEGIN
	SELECT @CONTADOR = COUNT(Usuario.usuCorreo)
	FROM Usuario 
	WHERE Usuario.usuCorreo = @usuCorreo
	END

	IF @accion = 'VERIFICAR_USUARIO_TELEFONO'
	BEGIN
	SELECT @CONTADOR = COUNT(Usuario.usuTelefono)
	FROM Usuario 
	WHERE Usuario.usuTelefono = @usuTelefono
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
		SELECT TOP 1 @returnId = [usuId]
			  FROM [dbo].[Usuario] ORDER BY usuId DESC
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
		SELECT [rolId]  AS 'ID'
      ,[rolDescripcion] AS 'ROL'
		FROM [supermercados].[dbo].[Rol]
	END

	IF @accion = 'SELECT_LAST_ID_ROL'
	BEGIN 
		SELECT TOP 1 @returnId = Rol.rolId
			  FROM [dbo].Rol ORDER BY rolId DESC
			  RETURN
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
	IF @accion = 'INS_FUNCION'
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

	IF @accion = 'SELECT_GRID_FUNCIONES_ROL'
	BEGIN 
		SELECT FuncionesRoles.funRolesId AS 'ID', Rol.rolId AS 'ID ROL', Rol.rolDescripcion AS 'ROL', Funciones.funId as 'ID FUNC', Funciones.funDescripcion AS 'FUNCION'
		FROM FuncionesRoles INNER JOIN Rol ON FuncionesRoles.rolId = Rol.rolId INNER JOIN Funciones ON FuncionesRoles.funId = Funciones.funId
		WHERE Funciones.funId = @idFuncion
	END

	IF @accion = 'VERIFICAR_EXISTENCIA_FUNCION_ROL'
	BEGIN 
		SELECT @contadorFunRol = COUNT(FuncionesRoles.funRolesId)
		FROM FuncionesRoles INNER JOIN Rol ON FuncionesRoles.rolId = Rol.rolId INNER JOIN Funciones ON FuncionesRoles.funId = Funciones.funId
		WHERE FuncionesRoles.rolId = @rolId AND FuncionesRoles.funId = @idFuncion
		RETURN
	END

	IF @accion ='INS_FUNCION_ROL'
	BEGIN
		INSERT INTO FuncionesRoles
           (rolId,funId)
     VALUES
           (@rolId,@idFuncion)
	END

	IF @accion = 'DLT_FUNCION_ROL'
	BEGIN
		
	DELETE FROM [dbo].FuncionesRoles
		  WHERE FuncionesRoles.funRolesId = @idFunRol
	END

--FIN TODO FUNCIONES DE USUARIO



--TODO PERMISOS DE LAS FUNCIONES
	IF @accion ='INS_FUNCION_ROL_PERMISO'
	BEGIN
		INSERT INTO FuncionesRolesPermisos
           (funRolesId,perFunDescripcion,perFunValor,tipPermisoId)
     VALUES
           (@idFunRol,@perFunDescripcion,@perFunValor,@tipPermisoId)
	END

	IF @accion = 'DLT_FUNCION_ROL_PERMISO'
	BEGIN	
	DELETE FROM [dbo].FuncionesRolesPermisos
		  WHERE FuncionesRolesPermisos.perFunId = @perFunId
	END

	IF @accion = 'SELECT_GRID_FUNCIONES_ROL_PERMISOS'
	BEGIN 
		SELECT FuncionesRolesPermisos.perFunId AS 'ID', TiposPermisos.tipPermisoId AS 'ID PERMISO', TiposPermisos.tipPermisoDescripcion AS 'DESCRIPCION', FuncionesRolesPermisos.perFunValor AS 'PERMITIDO'
		
		FROM FuncionesRolesPermisos INNER JOIN TiposPermisos ON FuncionesRolesPermisos.tipPermisoId = TiposPermisos.tipPermisoId
		WHERE FuncionesRolesPermisos.funRolesId = @idFunRol
	END

	IF @accion = 'SELECT_GRID_FUNCIONES_ROL_PERMISOS_BUSQUEDA'
	BEGIN 
		SELECT TiposPermisos.tipPermisoId AS 'ID PERMISO', TiposPermisos.tipPermisoDescripcion AS 'DESCRIPCION', FuncionesRolesPermisos.perFunValor AS 'PERMITIDO'
		FROM FuncionesRolesPermisos INNER JOIN TiposPermisos ON FuncionesRolesPermisos.tipPermisoId = TiposPermisos.tipPermisoId
		WHERE FuncionesRolesPermisos.funRolesId = @idFunRol AND (TiposPermisos.tipPermisoId like '%'+@parametro+'%' or TiposPermisos.tipPermisoDescripcion like '%'+@parametro+'%')
	END
	
	IF @accion = 'SELECT_GRID_PERMISOS_FUNCIONES'
	BEGIN 
		SELECT 
		[FuncionesRolesPermisos].[perFunId] AS 'ID'
	   ,[TiposPermisos].[tipPermisoDescripcion] AS 'PERMISO'
	   ,[Funciones].[funDescripcion] AS 'FUNCION'
	   ,FuncionesRolesPermisos.perFunValor AS 'ACCION'
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

	IF @accion = 'CB_PERMISOS'
	BEGIN 
		SELECT TiposPermisos.tipPermisoId AS 'ID'
      ,TiposPermisos.tipPermisoDescripcion AS 'PERMISO'
		FROM TiposPermisos
	END

	IF @accion = 'VERIFICAR_EXISTENCIA_PERMISO_FUNCION_ROL'
	BEGIN 
		SELECT @contadorPermisoFunRol = COUNT(FuncionesRolesPermisos.perFunId)
		FROM FuncionesRolesPermisos
		WHERE FuncionesRolesPermisos.funRolesId = @idFunRol AND FuncionesRolesPermisos.tipPermisoId = @tipPermisoId
		RETURN
	END

	IF @accion = 'UPD_VALOR_PERMISO'
	BEGIN
		UPDATE [dbo].[FuncionesRolesPermisos]
		SET perFunValor = @perFunValor
		WHERE perFunId = @perFunId
	END

--FIN TODO PERMISOS DE LAS FUNCIONES

-- TODO PERMISOS

	IF @accion ='INS_PERMISO'
	BEGIN
		INSERT INTO [dbo].TiposPermisos
           (tipPermisoDescripcion)
     VALUES
           (@tipPermisoDescripcion)
	END
	
	IF @accion = 'UPD_PERMISO'
	BEGIN
		UPDATE [dbo].TiposPermisos
		SET tipPermisoDescripcion = @tipPermisoDescripcion
		WHERE TiposPermisos.tipPermisoId = @tipPermisoId
	END

	IF @accion = 'DLT_PERMISO'
	BEGIN
		
	DELETE FROM [dbo].TiposPermisos
		  WHERE TiposPermisos.tipPermisoId = @tipPermisoId
	END

	--LAST ID
	IF @accion = 'SELECT_LAST_ID_PERMISO'
	BEGIN 
		SELECT TOP 1 @returnId = TiposPermisos.tipPermisoId
			  FROM [dbo].TiposPermisos ORDER BY TiposPermisos.tipPermisoId DESC
			  RETURN
	END

-- FIN TODO PERMISOS

--INICIO DE SESION
	
	 IF @accion = 'LOGIN'
	 BEGIN
		
		SET @var = (SELECT Usuario.usuId 
		FROM Usuario WHERE (usuNick = @usuNick OR usuCorreo = @email) AND usuPassw = @usuPassw)
		RETURN
	 END

	 IF @accion = 'GET_DATA_USER'
	 BEGIN
		SELECT Usuario.usuNick, Usuario.usuCorreo, RolesUsuario.rolId, Rol.rolDescripcion, Funciones.funDescripcion , FuncionesRoles.funRolesId, Usuario.usuNombres,
		Usuario.usuApellidos, Usuario.usuId
		FROM Usuario LEFT JOIN RolesUsuario ON Usuario.usuId = RolesUsuario.usuId LEFT JOIN Rol ON RolesUsuario.rolId = Rol.rolId LEFT JOIN FuncionesRoles on Rol.rolId = FuncionesRoles.rolId
		LEFT JOIN Funciones ON FuncionesRoles.funId = Funciones.funId
		 WHERE (Usuario.usuNick = @usuNick OR Usuario.usuCorreo = @email) AND Usuario.usuPassw = @usuPassw
	 END

	 IF @accion = 'GET_PERMISOS_USER'
	 BEGIN
		
		SELECT Funciones.funDescripcion, TiposPermisos.tipPermisoDescripcion, FuncionesRolesPermisos.perFunValor
		FROM FuncionesRoles INNER JOIN FuncionesRolesPermisos ON FuncionesRoles.funRolesId = FuncionesRolesPermisos.funRolesId INNER JOIN Funciones ON FuncionesRoles.funId = Funciones.funId
		INNER JOIN TiposPermisos ON TiposPermisos.tipPermisoId = FuncionesRolesPermisos.tipPermisoId
		 WHERE FuncionesRolesPermisos.funRolesId = @idFunRol
	 END

--FIN INCIO DE SESION

END
GO


