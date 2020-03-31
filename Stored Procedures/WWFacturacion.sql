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
CREATE PROCEDURE WWFACTUACION
	-- Add the parameters for the stored procedure here
	@parametro varchar(100) = 'null',
	@accion varchar(100) = 'null',
	@idRetorno int = 0 OUTPUT,

	@catProductoId int =0,
	@catProductoDescripcion varchar(100) = 'null',

	@cliId int =0,
	@cliNombres varchar(100) = 'null',
	@cliApellidos varchar(100) = 'null',
	@cliCorreo varchar(100) = 'null',
	@cliTelefono varchar(20) = 'null',
	@cliDireccion varchar(100) = 'null',
	@usuId int = 0,

	@comProId int = 0,
	@comProFecha datetime = null,
	@comProMontoTotal money = 0,

	@detComProId int = 0,
	@proId int = 0,
	@detComProCantidad money = 0,

	@facId int  = 0,
	@facFecha datetime = null,
	@facMontoTotal money = 0,

	@detFacId int = 0,
	@detFacCantidad int = 0,

	@impId int = 0,
	@impDescripcion varchar(90) = 'null',
	@impValor int = 0,
 
	@invId int = 0,
	@invStock float = 0,
	@invCantidadMinima float = 0,
	@invFechaCreacion datetime = null,
	@invFechaUltimaAct datetime = null,

	@proNombre varchar(40) = 'null',
	@proDescripcion varchar(60) = 'null',
	@proValor smallmoney = 0,
	@uniId int = 0,

	@uniDescripcion varchar(100) = 'null'

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
END
GO
