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
	@RetornarStockActual float = 0 OUTPUT,
	@proNombre varchar(40) = 'null',
	@proDescripcion varchar(60) = 'null',
	@proValor smallmoney = 0,
	@uniId int = 0,
	@uniDescripcion varchar(100) = 'null',
	@comProDescripcion varchar(300) = 'null'

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    --TODO UNIDADES
	IF @accion = 'INS_UNIDADES'
	BEGIN
	INSERT Unidades VALUES(@uniDescripcion)
	END

	IF @accion = 'UPD_UNIDADES'
	BEGIN
	UPDATE Unidades SET uniDescripcion = @uniDescripcion WHERE uniId = @uniId
	END

	IF @accion = 'DLT_UNIDADES'
	BEGIN
	DELETE FROM Unidades WHERE uniId = @uniId
	END

	IF @accion = 'SELECT_GRID_UNIDADES'
	BEGIN
	SELECT uniId AS 'ID'
	,uniDescripcion AS 'UNIDAD'
	FROM Unidades
	END

	--FIN TODO UNIDADES


	--TODO CATEGORIAS
	IF @accion = 'INS_CATEGORIA'
	BEGIN
	INSERT Categoria(catProductoDescripcion) VALUES(@catProductoDescripcion)
	END

	IF @accion = 'UPD_CATEGORIA'
	BEGIN
	UPDATE Categoria SET catProductoDescripcion = @catProductoDescripcion WHERE catProductoId = @catProductoId
	END

	IF @accion = 'DLT_CATEGORIA'
	BEGIN
	DELETE FROM Categoria WHERE catProductoId = @catProductoId
	END

	IF @accion = 'SELECT_GRID_CATEGORIAS'
	BEGIN
	SELECT catProductoId AS 'ID'
	,catProductoDescripcion AS 'CATEGORIA'
	FROM Categoria
	END

	--FIN TODO CATEGORIAS



	--TODO IMPUESTOS
	IF @accion = 'INS_IMPUESTOS'
	BEGIN
	INSERT Impuestos(impDescripcion,impValor) VALUES(@impDescripcion,@impValor)
	END

	IF @accion = 'UPD_IMPUESTOS'
	BEGIN
	UPDATE Impuestos SET impDescripcion = @impDescripcion, impValor = @impValor WHERE impId = @impId
	END

	IF @accion = 'DLT_IMPUESTOS'
	BEGIN
	DELETE FROM Impuestos WHERE impId = @impId
	END

	IF @accion = 'SELECT_GRID_IMPUESTOS'
	BEGIN
	SELECT impId AS 'ID'
	,impDescripcion AS 'IMPUESTO'
	,impValor AS 'VALOR'
	FROM Impuestos
	END

	IF @accion = 'SELECT_CB_IMPUESTOS'
	BEGIN
	SELECT impId AS 'ID'
	,CONCAT(impDescripcion,' ', impValor, '%') AS 'IMPUESTO'
	FROM Impuestos
	END

	--FIN TODO IMPUESTOS



	--TODO CLIENTE

	IF @accion = 'INS_CLIENTE'
	BEGIN
	INSERT INTO [dbo].[Cliente]
           ([cliNombres]
           ,[cliApellidos]
           ,[cliCorreo]
           ,[cliTelefono]
           ,[cliDireccion]
           ,[usuId])
     VALUES
           (@cliNombres
           ,@cliApellidos
           ,@cliCorreo
           ,@cliTelefono
           ,@cliDireccion
           ,@usuId)
	END

	IF @accion = 'UPD_CLIENTE'
	BEGIN
	UPDATE [dbo].[Cliente]
	SET [cliNombres] = @cliNombres
      ,[cliApellidos] = @cliApellidos
      ,[cliCorreo] = @cliCorreo
      ,[cliTelefono] = @cliTelefono
      ,[cliDireccion] = @cliDireccion
      ,[usuId] = @usuId
	WHERE cliId = @cliId
	END

	IF @accion = 'DLT_CLIENTE'
	BEGIN
	DELETE FROM [dbo].[Cliente]
      WHERE cliId = @cliId
	END

	IF @accion = 'SELECT_GRID_CLIENTE'
	BEGIN
	SELECT [cliId] AS 'ID'
      ,[cliNombres] AS 'NOMBRES'
      ,[cliApellidos] AS 'APELLIDOS'
      ,[cliCorreo] AS 'CORREO'
      ,[cliTelefono] AS 'TELEFONO'
      ,[cliDireccion] AS 'DIRECCION'
	FROM [dbo].[Cliente]
	END

	IF @accion = 'SELECT_GRID_CLIENTE_ID'
	BEGIN
	SELECT [cliId] AS 'ID'
      ,[cliNombres] AS 'NOMBRES'
      ,[cliApellidos] AS 'APELLIDOS'
      ,[cliCorreo] AS 'CORREO'
      ,[cliTelefono] AS 'TELEFONO'
      ,[cliDireccion] AS 'DIRECCION'
	FROM [dbo].[Cliente]
	WHERE cliId = @cliId
	END

	IF @accion = 'SELECT_GRID_CLIENTE_PARAMETRO'
	BEGIN
	SELECT [cliId] AS 'ID'
      ,[cliNombres] AS 'NOMBRES'
      ,[cliApellidos] AS 'APELLIDOS'
      ,[cliCorreo] AS 'CORREO'
      ,[cliTelefono] AS 'TELEFONO'
      ,[cliDireccion] AS 'DIRECCION'
	FROM [dbo].[Cliente]
	WHERE (
	cliNombres LIKE '%'+@parametro+'%' OR
	cliApellidos LIKE '%'+@parametro+'%' OR
	cliCorreo LIKE '%'+@parametro+'%' OR
	cliTelefono LIKE '%'+@parametro+'%' OR
	cliDireccion LIKE '%'+@parametro+'%'
	)
	END

	--FIN TODO CLIENTE



	--TODO COMPRA PRODUCTOS

	IF @accion = 'INS_COMPRA'
	BEGIN
	INSERT INTO [dbo].[CompraProductos]
           ([comProFecha]
           ,[usuId]
           ,[comProMontoTotal]
		   ,[comProDescripcion])
     VALUES
           (@comProFecha
           ,@usuId
           ,@comProMontoTotal
		   ,@comProDescripcion)
	END

	IF @accion = 'UPD_COMPRA'
	BEGIN
	UPDATE [dbo].[CompraProductos]
	SET [comProFecha] = @comProFecha
      ,[usuId] = @usuId
      ,[comProMontoTotal] = @comProMontoTotal,
	  [comProDescripcion] = @comProDescripcion
	WHERE comProId = @comProId
	END

	IF @accion = 'DLT_COMPRA'
	BEGIN
	DELETE FROM [dbo].CompraProductos
      WHERE comProId = @comProId
	END

	IF @accion = 'SELECT_GRID_COMPRA'
	BEGIN
	SELECT [comProId] AS 'ID'
      ,[comProFecha] AS 'FECHA'
	  ,Usuario.usuNick AS 'USUARIO'
	  ,[comProDescripcion] AS 'DESCRIPCION'
      ,[comProMontoTotal] AS 'TOTAL COMPRA'
	FROM [dbo].[CompraProductos] INNER JOIN Usuario ON Usuario.usuId = CompraProductos.usuId
	END

	IF @accion = 'COMPRA_ID'
	BEGIN
	SELECT TOP 1 @idRetorno = CompraProductos.comProId
	FROM CompraProductos ORDER BY comProId DESC
	END

	IF @accion = 'SELECT_GRID_COMPRA_PARAMETRO'
	BEGIN
	SELECT [comProId] AS 'ID'
      ,[comProFecha] AS 'FECHA'
	  ,[comProDescripcion] AS 'DESCRIPCION'
      ,[comProMontoTotal] AS 'TOTAL COMPRA'
	FROM [dbo].[CompraProductos]
	WHERE (
	comProId LIKE '%'+@parametro+'%' OR
	comProFecha LIKE '%'+@parametro+'%' OR
	comProMontoTotal LIKE '%'+@parametro+'%'
	)
	END

	--FIN TODO COMPRA PRODUCTOS



	--TODO COMPRA PRODUCTOS DETALLE

	IF @accion = 'INS_DETALLE_COMPRA'
	BEGIN
	INSERT INTO [dbo].[CompraProductosDetalle]
           ([comProId]
           ,[proId]
           ,[detComProCantidad])
     VALUES
           (@comProId
           ,@proId
           ,@detComProCantidad)
	END

	IF @accion = 'UPD_DETALLE_COMPRA'
	BEGIN
	UPDATE [dbo].[CompraProductosDetalle]
	SET [comProId] = @comProId
      ,[proId] = @proId
      ,[detComProCantidad] = @detComProCantidad
	WHERE detComProId = @detComProId
	END

	IF @accion = 'DLT_DETALLE_COMPRA'
	BEGIN
	DELETE FROM [dbo].CompraProductosDetalle
      WHERE detComProId = @detComProId
	END

	IF @accion = 'SELECT_GRID_DETALLE_COMPRA'
	BEGIN
	SELECT CompraProductosDetalle.[detComProId] AS 'ID'
      ,Producto.[proId] AS 'ID PRODUCTO'
	  ,Producto.proNombre AS 'DESCRIPCION'
	  ,Unidades.uniDescripcion AS 'UNIDADES'
	  ,Categoria.catProductoDescripcion AS 'CATEGORIA'
	  ,Producto.proValor AS 'PRECIO'
      ,[detComProCantidad] AS 'CANTIDAD'
	  ,(Producto.proValor * [detComProCantidad]) AS 'SUB TOTAL'
	FROM [dbo].[CompraProductosDetalle] INNER JOIN Producto ON CompraProductosDetalle.proId = Producto.proId INNER JOIN Categoria ON Producto.catProductoId = Categoria.catProductoId
	INNER JOIN Unidades ON Producto.uniId = Unidades.uniId INNER JOIN Impuestos ON Impuestos.impId = Producto.uniId
	END

	IF @accion = 'SELECT_GRID_DETALLE_COMPRA_PARAMETRO'
	BEGIN
	SELECT CompraProductosDetalle.[detComProId] AS 'ID'
      ,Producto.[proId] AS 'ID PRODUCTO'
	  ,Producto.proNombre AS 'DESCRIPCION'
	  ,Unidades.uniDescripcion AS 'UNIDADES'
	  ,Categoria.catProductoDescripcion AS 'CATEGORIA'
	  ,Producto.proValor AS 'PRECIO'
      ,[detComProCantidad] AS 'CANTIDAD'
	  ,(Producto.proValor * [detComProCantidad]) AS 'SUB TOTAL'
	FROM [dbo].[CompraProductosDetalle] INNER JOIN Producto ON CompraProductosDetalle.proId = Producto.proId INNER JOIN Categoria ON Producto.catProductoId = Categoria.catProductoId
	INNER JOIN Unidades ON Producto.uniId = Unidades.uniId INNER JOIN Impuestos ON Impuestos.impId = Producto.uniId
	INNER JOIN CompraProductos ON CompraProductos.comProId = CompraProductosDetalle.comProId
	WHERE CompraProductos.comProId = @comProId
	END

	--FIN TODO COMPRA PRODUCTOS DETALLE



	--TODO FACTURAS

	IF @accion = 'INS_FACTURA'
	BEGIN
	INSERT INTO [dbo].[Factura]
           ([facFecha]
           ,[facMontoTotal]
           ,[cliId]
		   ,[usuId])
     VALUES
           (@facFecha
           ,@facMontoTotal
           ,@cliId
		   ,@usuId)
	END

	IF @accion = 'UPD_FACTURA'
	BEGIN
	UPDATE [dbo].[Factura]
	SET [facFecha] = @facFecha
      ,[facMontoTotal] = @facMontoTotal
      ,[cliId] = @cliId
	  ,[usuId] = @usuId
	WHERE facId = @facId
	END

	IF @accion = 'DLT_FACTURA'
	BEGIN
	DELETE FROM [dbo].Factura
      WHERE facId = @facId
	END
	
	IF @accion = 'SELECT_GRID_FACTURA'
	BEGIN
	SELECT [facId] AS 'ID'
      ,[facFecha] AS 'FECHA'
      ,CONCAT(Cliente.cliNombres, ' ', Cliente.cliApellidos) AS 'CLIENTE'
	  ,Cliente.cliId AS 'ID CLIENTE'
	  ,[facMontoTotal] AS 'MONTO TOTAL'
	FROM [dbo].[Factura] INNER JOIN Cliente ON Factura.cliId = Cliente.cliId
	END

	IF @accion = 'FACTURA_ID'
	BEGIN
	SELECT TOP 1 @idRetorno = facId
	FROM Factura ORDER BY facId DESC
	END

	IF @accion = 'SELECT_GRID_FACTURA_PARAMETRO'
	BEGIN
	SELECT [facId] AS 'ID'
      ,[facFecha] AS 'FECHA'
      ,CONCAT(Cliente.cliNombres, ' ', Cliente.cliApellidos) AS 'CLIENTE'
	  ,[facMontoTotal] AS 'MONTO TOTAL'
	FROM [dbo].[Factura] INNER JOIN Cliente ON Factura.cliId = Cliente.cliId
	WHERE (
	Factura.facId LIKE '%'+@parametro+'%' OR
	facFecha LIKE '%'+@parametro+'%' OR
	CONCAT(Cliente.cliNombres, ' ', Cliente.cliApellidos) LIKE '%'+@parametro+'%' OR
	Factura.facMontoTotal LIKE '%'+@parametro+'%'
	)
	END

	--FIN TODO FACTURAS



	--TODO DETALLE FACTURAS

	IF @accion = 'INS_DETALLE_FACTURA'
	BEGIN
	INSERT INTO [dbo].[FacturaDetalle]
           ([facId]
           ,[proId]
           ,[detFacCantidad])
     VALUES
           (@facId
           ,@proId
           ,@detFacCantidad)
	END

	IF @accion = 'UPD_DETALLE_FACTURA'
	BEGIN
	UPDATE [dbo].[FacturaDetalle]
	SET [facId] = @facId
      ,[proId] = @proId
      ,[detFacCantidad] = @detFacCantidad
	WHERE detFacId = @detFacId
	END

	IF @accion = 'DLT_DETALLE_FACTURA'
	BEGIN
	DELETE FROM [dbo].FacturaDetalle
      WHERE detFacId = @detFacId
	END

	IF @accion = 'SELECT_GRID_DETALLE_FACTURA_PARAMETRO'
	BEGIN
	SELECT [detFacId] AS 'ID DETALLE'
      ,Producto.[proId] AS 'ID PRODUCTO'
	  ,Producto.proNombre AS 'DESCRIPCION'
	  ,Unidades.uniDescripcion AS 'UNIDADES'
	  ,Categoria.catProductoDescripcion AS 'CATEGORIA'
	  ,Producto.proValor AS 'PRECIO'
	  ,FacturaDetalle.detFacCantidad AS 'CANTIDAD'
	  ,(Producto.proValor * FacturaDetalle.detFacCantidad) AS 'SUB TOTAL'
      ,[detFacCantidad]
	FROM [dbo].[FacturaDetalle] INNER JOIN Producto ON FacturaDetalle.proId = Producto.proId INNER JOIN Categoria ON Producto.catProductoId = Categoria.catProductoId
	INNER JOIN Unidades ON Producto.uniId = Unidades.uniId INNER JOIN Impuestos ON Impuestos.impId = Producto.uniId INNER JOIN Factura ON Factura.facId = FacturaDetalle.facId
	WHERE Factura.facId = @facId
	END

	--FIN TODO DETALLE FACTURAS



	--TODO INVENTARIO

	IF @accion = 'INS_INVENTARIO'
	BEGIN
	INSERT INTO [dbo].[Inventario]
           ([proId]
           ,[invStock]
           ,[invCantidadMinima]
           ,[invFechaCreacion]
           ,[invFechaUltimaAct])
     VALUES
           (@proId
           ,0
           ,5
           ,@invFechaCreacion
           ,@invFechaUltimaAct)
	END

	IF @accion = 'SELECT_GRID_INVENTARIO'
	BEGIN
	SELECT Inventario.[invId] AS 'ID'
      ,Producto.[proId] AS 'ID PRODUCTO'
	  ,Producto.proNombre AS 'PRODUCTO'
	  ,Unidades.uniDescripcion AS 'UNIDAD'
	  ,Categoria.catProductoDescripcion AS 'CATEGORIA'
      ,Inventario.[invStock] AS 'STOCK'
      ,Inventario.[invCantidadMinima] AS 'CANT MINIMA'
      ,Inventario.[invFechaCreacion] AS 'CREADO'
      ,Inventario.[invFechaUltimaAct] AS 'MODIFICADO'
	FROM [dbo].[Inventario] INNER JOIN Producto ON Producto.proId = Inventario.proId INNER JOIN Unidades ON Producto.uniId = Unidades.uniId INNER JOIN Categoria
	ON Categoria.catProductoId = Producto.catProductoId
	END

	IF @accion = 'STOCK_INV'
	BEGIN
	SELECT @RetornarStockActual = Inventario.[invStock]
	FROM [dbo].[Inventario] INNER JOIN Producto ON Producto.proId = Inventario.proId INNER JOIN Unidades ON Producto.uniId = Unidades.uniId INNER JOIN Categoria
	ON Categoria.catProductoId = Producto.catProductoId
	WHERE Producto.proId = @proId
	RETURN
	END

	IF @accion = 'UPD_INVENTARIO_STOCK'
	BEGIN
	UPDATE [dbo].[Inventario]
	SET [invStock] = @invStock
      ,[invFechaUltimaAct] = @invFechaUltimaAct
	WHERE Inventario.proId = @proId
	END

	--FIN TODO INVENTARIO



	--TODO PRODUCTOS
	IF @accion = 'INS_PRODUCTOS'
	BEGIN
	INSERT INTO [dbo].[Producto]
           ([proNombre]
           ,[proDescripcion]
           ,[proValor]
           ,[catProductoId]
           ,[uniId]
           ,[usuId]
           ,[impId])
     VALUES
           (@proNombre
           ,@proDescripcion
           ,@proValor
           ,@catProductoId
           ,@uniId
           ,@usuId
           ,@impId)
	END

	IF @accion = 'UPD_PRODUCTO'
	BEGIN
	UPDATE [dbo].[Producto]
	SET [proNombre] = @proNombre
      ,[proDescripcion] = @proDescripcion
      ,[proValor] = @proValor
      ,[catProductoId] = @catProductoId
      ,[uniId] = @uniId
      ,[usuId] = @usuId
      ,[impId] = @impId
	WHERE Producto.proId = @proId
	END

	IF @accion = 'DLT_PRODUCTO'
	BEGIN
	DELETE FROM [dbo].[Producto]
      WHERE Producto.proId = @proId
	END

	IF @accion = 'SELECT_GRID_PRODUCTO'
	BEGIN
	SELECT Producto.[proId] AS 'ID'
      ,Producto.[proNombre] AS 'NOMBRE'
      ,Producto.[proDescripcion] AS 'DESCRIPCION'
      ,Producto.[proValor] AS 'PRECIO'
	  ,Categoria.catProductoDescripcion AS 'CATEGORIA'
	  ,Unidades.uniDescripcion AS 'UNIDAD'
	  ,Impuestos.impDescripcion AS 'IMPUESTO'
	  ,Impuestos.impValor AS '%'
	  ,Inventario.invStock AS 'STOCK'
	  ,Inventario.invCantidadMinima AS 'CANTIDAD MINIMA'
	FROM [dbo].[Producto] INNER JOIN Categoria ON Producto.catProductoId = Categoria.catProductoId INNER JOIN Unidades ON Producto.uniId = Unidades.uniId
	INNER JOIN Inventario ON Producto.proId = Inventario.proId
	INNER JOIN Impuestos ON Producto.impId = Impuestos.impId 
	END

	IF @accion = 'SELECT_PRODUCTO'
	BEGIN
	SELECT Producto.[proId] AS 'ID'
      ,Producto.[proNombre] AS 'NOMBRE'
      ,Producto.[proDescripcion] AS 'DESCRIPCION'
      ,Producto.[proValor] AS 'PRECIO'
	  ,Categoria.catProductoDescripcion AS 'CATEGORIA'
	  ,Unidades.uniDescripcion AS 'UNIDAD'
	  ,Impuestos.impDescripcion AS 'IMPUESTO'
	  ,Impuestos.impValor AS '%'
	  ,Inventario.invStock AS 'STOCK'
	  ,Inventario.invCantidadMinima AS 'CANTIDAD MINIMA'
	FROM [dbo].[Producto] INNER JOIN Categoria ON Producto.catProductoId = Categoria.catProductoId INNER JOIN Unidades ON Producto.uniId = Unidades.uniId
	INNER JOIN Impuestos ON Producto.impId = Impuestos.impId INNER JOIN Inventario ON Producto.proId = Inventario.proId
	WHERE Producto.proId = @proId
	END

	IF @accion = 'PRODUCTO_ID'
	BEGIN
	SELECT TOP 1 @idRetorno = Producto.proId
	FROM Producto ORDER BY Producto.proId DESC
	END

	IF @accion = 'SELECT_GRID_PRODUCTO_PARAMETRO'
	BEGIN
	SELECT Producto.[proId] AS 'ID'
      ,Producto.[proNombre] AS 'NOMBRE'
      ,Producto.[proDescripcion] AS 'DESCRIPCION'
      ,Producto.[proValor] AS 'PRECIO'
	  ,Categoria.catProductoDescripcion AS 'CATEGORIA'
	  ,Unidades.uniDescripcion AS 'UNIDAD'
	  ,Impuestos.impDescripcion AS 'IMPUESTO'
	  ,Impuestos.impValor AS '%'
	FROM [dbo].[Producto] INNER JOIN Categoria ON Producto.catProductoId = Categoria.catProductoId INNER JOIN Unidades ON Producto.uniId = Unidades.uniId
	INNER JOIN Impuestos ON Producto.impId = Impuestos.impId
	WHERE (
	Producto.proId LIKE '%'+@parametro+'%' OR
	Producto.proNombre LIKE '%'+@parametro+'%' OR
	Producto.proDescripcion LIKE '%'+@parametro+'%' OR
	Producto.proValor LIKE '%'+@parametro+'%' OR
	Categoria.catProductoId LIKE '%'+@parametro+'%' OR
	Categoria.catProductoDescripcion LIKE '%'+@parametro+'%' OR
	Unidades.uniId LIKE '%'+@parametro+'%' OR
	Unidades.uniDescripcion LIKE '%'+@parametro+'%' OR
	Impuestos.impId LIKE '%'+@parametro+'%' OR
	Impuestos.impDescripcion LIKE '%'+@parametro+'%' OR
	Impuestos.impValor LIKE '%'+@parametro+'%'
	)
	END

	--FIN TODO PRODUCTOS

END
GO
