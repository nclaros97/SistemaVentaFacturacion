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
ALTER PROCEDURE WWPartidasContables
	-- Add the parameters for the stored procedure here
	@parId int =0,
	@parDescripcion varchar(100) = 'null',
	@parFecha Date = null,
	@usuId int =0,
	@parConDetId int = 0,
	@ctaId varchar(40) = '',
	@parConDetDebe smallmoney = 0,
	@parConDetHaber smallmoney = 0,
	@claCtaId int = 0,
	@claCtaDescripcion varchar(100) = '',
	@ctaDescripcion varchar(50) = '',
	@parametro varchar(100) = '',
	@accion varchar(40) = '',
	@IdRetorno  INT =0 OUTPUT,
	@IdRetornoString VARCHAR(100) = '' OUTPUT,
	@UserId INT = 0,
	@CantidadRegistros INT = 0 OUTPUT

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	--TODO CUENTAS

	IF @accion = 'INS_CUENTA'
	BEGIN 
		INSERT INTO [dbo].[Cuentas]
           ([ctaId]
           ,[ctaDescripcion]
           ,[claCtaId])
     VALUES
           (@ctaId
           ,@ctaDescripcion
           ,@claCtaId)
	END

	IF @accion = 'UPD_CUENTA'
	BEGIN 
		UPDATE [dbo].[Cuentas]
		SET [ctaDescripcion] = @ctaDescripcion
		,[claCtaId] = @claCtaId
		WHERE ctaId = @ctaId
	END

	IF @accion = 'DLT_CUENTA'
	BEGIN 
		DELETE FROM [dbo].[Cuentas]
		WHERE ctaId = @ctaId
	END

	IF @accion = 'SELECT_GRID_CUENTAS'
	BEGIN 
		SELECT Cuentas.[ctaId] AS 'ID CTA'
		,Cuentas.[ctaDescripcion] AS 'DESCRIPCION'
		,ClasificacionCuenta.claCtaId AS 'ID TIPO'
		,ClasificacionCuenta.claCtaDescripcion AS 'TIPO'
		 FROM [dbo].[Cuentas] INNER JOIN ClasificacionCuenta ON Cuentas.claCtaId = ClasificacionCuenta.claCtaId
	END

	IF @accion = 'SELECT_GRID_CUENTA_ID'
	BEGIN 
		SELECT Cuentas.[ctaId] AS 'ID CTA'
		,Cuentas.[ctaDescripcion] AS 'DESCRIPCION'
		,ClasificacionCuenta.claCtaId AS 'ID TIPO'
		,ClasificacionCuenta.claCtaDescripcion AS 'TIPO'
		 FROM [dbo].[Cuentas] INNER JOIN ClasificacionCuenta ON Cuentas.claCtaId = ClasificacionCuenta.claCtaId
		 WHERE Cuentas.ctaId = @ctaId
	END

	IF @accion = 'SELECT_GRID_CUENTAS_PARAMETRO'
	BEGIN 

	SELECT [ctaId] AS 'ID CTA'
		,[ctaDescripcion] AS 'DESCRIPCION'
		,ClasificacionCuenta.claCtaDescripcion AS 'TIPO'
		 FROM [dbo].[Cuentas] INNER JOIN ClasificacionCuenta ON Cuentas.claCtaId = ClasificacionCuenta.claCtaId
		 WHERE ctaId LIKE '%'+@parametro+'%' OR ClasificacionCuenta.claCtaDescripcion LIKE '%'+@parametro+'%' OR ctaDescripcion LIKE '%'+@parametro+'%'

	END

	IF @accion = 'VERIFICAR_EXISTENCIA_CUENTA'
	BEGIN 
		SELECT @CantidadRegistros = COUNT(ctaId)
		FROM Cuentas
		WHERE ctaId = @ctaId
		RETURN
	END

	--FIN TODO CUENTAS



	--TODO TIPO CUENTAS

	IF @accion = 'INS_TIPO_CUENTA'
	BEGIN 
	INSERT INTO ClasificacionCuenta(claCtaDescripcion) VALUES(@claCtaDescripcion)
	END

	IF @accion = 'UPD_TIPO_CUENTA'
	BEGIN 
	UPDATE ClasificacionCuenta SET claCtaDescripcion = @claCtaDescripcion WHERE claCtaId = @claCtaId
	END

	IF @accion = 'DLT_TIPO_CUENTA'
	BEGIN 
	DELETE FROM ClasificacionCuenta WHERE claCtaId = @claCtaId
	END

	IF @accion = 'SELECT_GRID_TIPO_CUENTAS'
	BEGIN 
	SELECT claCtaId AS 'ID'
	,claCtaDescripcion AS 'TIPO'
	FROM ClasificacionCuenta
	END

	IF @accion = 'SELECT_GRID_TIPO_CUENTAS_PARAMETRO'
	BEGIN 
	SELECT claCtaId AS 'ID'
	,claCtaDescripcion AS 'TIPO'
	FROM ClasificacionCuenta
	WHERE claCtaId LIKE '%'+@parametro+'%' OR claCtaDescripcion LIKE '%'+@parametro+'%'
	END

	IF @accion = 'SELECT_LAST_ID_TIPO_CUENTA'
	BEGIN 
	SELECT TOP 1 @IdRetorno = claCtaId
	FROM ClasificacionCuenta ORDER BY claCtaId DESC
	RETURN
	END

	--FIN TODO TIPO CUENTAS



	--TODO PARTIDAS

	IF @accion = 'INS_PARTIDA'
	BEGIN 
	INSERT INTO [dbo].[PartidasContable]
           ([parDescripcion]
           ,[parFecha]
           ,[usuId])
     VALUES
           (@parDescripcion
           ,@parFecha
           ,@UserId)
	END

	IF @accion = 'UPD_PARTIDA'
	BEGIN 
	UPDATE [dbo].[PartidasContable]
    SET [parDescripcion] = @parDescripcion
      ,[parFecha] = @parFecha
      ,[usuId] = @UserId
	WHERE parId = @parId
	END

	IF @accion = 'DLT_PARTIDA'
	BEGIN 
	DELETE FROM PartidasContable WHERE parId = @parId
	END

	IF @accion = 'SELECT_GRID_PARTIDAS'
	BEGIN 
	SELECT parId AS 'ID'
	,parDescripcion AS 'DESCRIPCION'
	,parFecha AS 'FECHA'
	FROM PartidasContable
	END

	IF @accion = 'SELECT_GRID_PARTIDAS_PARAMETRO'
	BEGIN 
	SELECT parId AS 'ID'
	,parDescripcion AS 'DESCRIPCION'
	,parFecha AS 'FECHA'
	FROM PartidasContable
	WHERE parId LIKE '%'+@parametro+'%' OR parDescripcion LIKE '%'+@parametro+'%' OR parFecha LIKE '%'+@parametro+'%'
	END

	IF @accion = 'SELECT_LAST_ID_PARTIDA'
	BEGIN 
	SELECT TOP 1 @IdRetorno = parId
	FROM PartidasContable ORDER BY parId DESC

	RETURN
	END

	--FIN TODO PARTIDAS


	--TODO DETALLE PARTIDAS

	IF @accion = 'INS_DETALLE_PARTIDA'
	BEGIN 
	INSERT INTO [dbo].[PartidasContableDetalle]
           ([parId]
           ,[ctaId]
           ,[parConDetDebe]
           ,[parConDetHaber])
     VALUES
           (@parId
           ,@ctaId
           ,@parConDetDebe
           ,@parConDetHaber)
	END

	IF @accion = 'UPD_DETALLE_PARTIDA'
	BEGIN 
	UPDATE [dbo].[PartidasContableDetalle]
    SET [parId] = @parId
      ,[ctaId] = @ctaId
      ,[parConDetDebe] = @parConDetDebe
      ,[parConDetHaber] = @parConDetHaber
	WHERE parConDetId = @parConDetId
	END

	IF @accion = 'DLT_DETALLE_PARTIDA'
	BEGIN 
	DELETE FROM PartidasContableDetalle WHERE parConDetId = @parConDetId
	END

	IF @accion = 'SELECT_GRID_DETALLE_PARTIDAS'
	BEGIN 
	SELECT
       PartidasContableDetalle.[parConDetId] AS 'DETALLE ID'
      ,Cuentas.[ctaId] AS 'CUENTA ID'
	  ,Cuentas.ctaDescripcion AS 'DESCRIPCION'
	  ,ClasificacionCuenta.claCtaDescripcion AS 'TIPO'
      ,[parConDetDebe] AS 'DEBE'
      ,[parConDetHaber] AS 'HABER'
	FROM [dbo].[PartidasContableDetalle] INNER JOIN Cuentas ON Cuentas.ctaId = PartidasContableDetalle.ctaId INNER JOIN ClasificacionCuenta ON ClasificacionCuenta.claCtaId = Cuentas.claCtaId
	WHERE PartidasContableDetalle.parId = @parId
	END

	IF @accion = 'SELECT_GRID_DETALLE_PARTIDAS_PARAMETRO'
	BEGIN 
	SELECT [parId] AS 'PARTIDA ID'
      ,[parConDetId] AS 'DET PARTIDA ID'
      ,[ctaId] AS 'CUENTA ID'
      ,[parConDetDebe] AS 'DEBE'
      ,[parConDetHaber] AS 'HABER'
	FROM [dbo].[PartidasContableDetalle]
	WHERE parId LIKE '%'+@parametro+'%' OR parConDetId LIKE '%'+@parametro+'%' OR ctaId LIKE '%'+@parametro+'%' OR parConDetDebe LIKE '%'+@parametro+'%' OR parConDetHaber LIKE '%'+@parametro+'%'
	END

	IF @accion = 'SELECT_LAST_ID_DETALLE_PARTIDA'
	BEGIN 
	SELECT TOP 1 parConDetId
	FROM PartidasContableDetalle ORDER BY parConDetId DESC
	END

	--FIN TODO DETALLE PARTIDAS
	
END
GO
