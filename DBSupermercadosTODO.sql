USE [master]
GO
/****** Object:  Database [supermercados]    Script Date: 29/3/2020 23:15:45 ******/
CREATE DATABASE [supermercados]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'supermercados', FILENAME = N'C:\SQLDATA\Data\supermercados.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'supermercados_log', FILENAME = N'C:\SQLDATA\Log\supermercados_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [supermercados] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [supermercados].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [supermercados] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [supermercados] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [supermercados] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [supermercados] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [supermercados] SET ARITHABORT OFF 
GO
ALTER DATABASE [supermercados] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [supermercados] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [supermercados] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [supermercados] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [supermercados] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [supermercados] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [supermercados] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [supermercados] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [supermercados] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [supermercados] SET  ENABLE_BROKER 
GO
ALTER DATABASE [supermercados] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [supermercados] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [supermercados] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [supermercados] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [supermercados] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [supermercados] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [supermercados] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [supermercados] SET RECOVERY FULL 
GO
ALTER DATABASE [supermercados] SET  MULTI_USER 
GO
ALTER DATABASE [supermercados] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [supermercados] SET DB_CHAINING OFF 
GO
ALTER DATABASE [supermercados] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [supermercados] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [supermercados] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'supermercados', N'ON'
GO
ALTER DATABASE [supermercados] SET QUERY_STORE = OFF
GO
USE [supermercados]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [supermercados]
GO
/****** Object:  User [admin]    Script Date: 29/3/2020 23:15:46 ******/
CREATE USER [admin] FOR LOGIN [admin] WITH DEFAULT_SCHEMA=[dbo].[supermercados]
GO
ALTER ROLE [db_owner] ADD MEMBER [admin]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [admin]
GO
ALTER ROLE [db_securityadmin] ADD MEMBER [admin]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [admin]
GO
ALTER ROLE [db_backupoperator] ADD MEMBER [admin]
GO
ALTER ROLE [db_datareader] ADD MEMBER [admin]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [admin]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 29/3/2020 23:15:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[catProductoId] [int] NOT NULL,
	[catProductoDescripcion] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[catProductoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClasificacionCuenta]    Script Date: 29/3/2020 23:15:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClasificacionCuenta](
	[claCtaId] [int] IDENTITY(1,1) NOT NULL,
	[claCtaDescripcion] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[claCtaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 29/3/2020 23:15:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[cliId] [int] IDENTITY(1,1) NOT NULL,
	[cliNombres] [varchar](100) NOT NULL,
	[cliApellidos] [varchar](100) NOT NULL,
	[cliCorreo] [varchar](100) NOT NULL,
	[cliTelefono] [char](20) NOT NULL,
	[cliDireccion] [varchar](100) NOT NULL,
	[usuId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[cliId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CompraProductos]    Script Date: 29/3/2020 23:15:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompraProductos](
	[comProId] [int] IDENTITY(1,1) NOT NULL,
	[comProFecha] [datetime] NOT NULL,
	[usuId] [int] NOT NULL,
	[comProMontoTotal] [smallint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[comProId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CompraProductosDetalle]    Script Date: 29/3/2020 23:15:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompraProductosDetalle](
	[comProId] [int] IDENTITY(1,1) NOT NULL,
	[detComProId] [int] NOT NULL,
	[proId] [int] NOT NULL,
	[detComProCantidad] [smallmoney] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[comProId] ASC,
	[detComProId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cuentas]    Script Date: 29/3/2020 23:15:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cuentas](
	[ctaId] [varchar](40) NOT NULL,
	[ctaDescripcion] [varchar](50) NOT NULL,
	[claCtaId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ctaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[ctaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Factura]    Script Date: 29/3/2020 23:15:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Factura](
	[facId] [smallint] IDENTITY(1,1) NOT NULL,
	[facFecha] [smallint] NOT NULL,
	[facMontoTotal] [smallint] NOT NULL,
	[cliId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[facId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FacturaDetalle]    Script Date: 29/3/2020 23:15:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FacturaDetalle](
	[facId] [smallint] IDENTITY(1,1) NOT NULL,
	[detFacId] [smallint] NOT NULL,
	[proId] [int] NOT NULL,
	[detFacCantidad] [smallmoney] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[facId] ASC,
	[detFacId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Funciones]    Script Date: 29/3/2020 23:15:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Funciones](
	[funId] [int] IDENTITY(1,1) NOT NULL,
	[funDescripcion] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[funId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FuncionesRoles]    Script Date: 29/3/2020 23:15:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FuncionesRoles](
	[funRolesId] [int] IDENTITY(1,1) NOT NULL,
	[rolId] [int] NOT NULL,
	[funId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[funRolesId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FuncionesRolesPermisos]    Script Date: 29/3/2020 23:15:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FuncionesRolesPermisos](
	[funRolesId] [int] NOT NULL,
	[perFunId] [int] IDENTITY(1,1) NOT NULL,
	[perFunDescripcion] [varchar](100) NOT NULL,
	[perFunValor] [bit] NOT NULL,
	[tipPermisoId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[perFunId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Impuestos]    Script Date: 29/3/2020 23:15:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Impuestos](
	[impId] [int] IDENTITY(1,1) NOT NULL,
	[impDescripcion] [varchar](90) NOT NULL,
	[impValor] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[impId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Inventario]    Script Date: 29/3/2020 23:15:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventario](
	[invId] [int] IDENTITY(1,1) NOT NULL,
	[proId] [int] NOT NULL,
	[invStock] [smallmoney] NOT NULL,
	[invCantidadMinima] [smallmoney] NOT NULL,
	[invFechaCreacion] [datetime] NOT NULL,
	[invFechaUltimaAct] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[invId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PartidasContable]    Script Date: 29/3/2020 23:15:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PartidasContable](
	[parId] [int] IDENTITY(1,1) NOT NULL,
	[parDescripcion] [varchar](100) NOT NULL,
	[parFecha] [datetime] NOT NULL,
	[usuId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[parId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PartidasContableDetalle]    Script Date: 29/3/2020 23:15:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PartidasContableDetalle](
	[parId] [int] NOT NULL,
	[parConDetId] [int] IDENTITY(1,1) NOT NULL,
	[ctaId] [varchar](40) NOT NULL,
	[parConDetDebe] [smallmoney] NOT NULL,
	[parConDetHaber] [smallmoney] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[parId] ASC,
	[parConDetId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 29/3/2020 23:15:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[proId] [int] IDENTITY(1,1) NOT NULL,
	[proNombre] [varchar](40) NOT NULL,
	[proDescripcion] [varchar](60) NOT NULL,
	[proValor] [smallmoney] NOT NULL,
	[catProductoId] [int] NOT NULL,
	[uniId] [int] NOT NULL,
	[usuId] [int] NOT NULL,
	[impId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[proId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rol]    Script Date: 29/3/2020 23:15:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol](
	[rolId] [int] IDENTITY(1,1) NOT NULL,
	[rolDescripcion] [varchar](60) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[rolId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RolesUsuario]    Script Date: 29/3/2020 23:15:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RolesUsuario](
	[rolUsuId] [int] IDENTITY(1,1) NOT NULL,
	[rolId] [int] NOT NULL,
	[usuId] [int] NOT NULL,
	[usuNick] [varchar](40) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[rolUsuId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TiposPermisos]    Script Date: 29/3/2020 23:15:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TiposPermisos](
	[tipPermisoId] [int] IDENTITY(1,1) NOT NULL,
	[tipPermisoDescripcion] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[tipPermisoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Unidades]    Script Date: 29/3/2020 23:15:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Unidades](
	[uniId] [int] IDENTITY(1,1) NOT NULL,
	[uniDescripcion] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[uniId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 29/3/2020 23:15:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[usuId] [int] IDENTITY(1,1) NOT NULL,
	[usuNick] [varchar](40) NOT NULL,
	[usuNombres] [varchar](100) NOT NULL,
	[usuApellidos] [varchar](100) NOT NULL,
	[usuCorreo] [varchar](100) NOT NULL,
	[usuTelefono] [char](20) NOT NULL,
	[usuPassw] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[usuId] ASC,
	[usuNick] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [ICOMPRAPRODUCTOSDETALLE1]    Script Date: 29/3/2020 23:15:46 ******/
CREATE NONCLUSTERED INDEX [ICOMPRAPRODUCTOSDETALLE1] ON [dbo].[CompraProductosDetalle]
(
	[proId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [ICUENTAS1]    Script Date: 29/3/2020 23:15:46 ******/
CREATE NONCLUSTERED INDEX [ICUENTAS1] ON [dbo].[Cuentas]
(
	[claCtaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IFACTURA1]    Script Date: 29/3/2020 23:15:46 ******/
CREATE NONCLUSTERED INDEX [IFACTURA1] ON [dbo].[Factura]
(
	[cliId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IFACTURADETALLE1]    Script Date: 29/3/2020 23:15:46 ******/
CREATE NONCLUSTERED INDEX [IFACTURADETALLE1] ON [dbo].[FacturaDetalle]
(
	[proId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IFUNCIONESROLES1]    Script Date: 29/3/2020 23:15:46 ******/
CREATE NONCLUSTERED INDEX [IFUNCIONESROLES1] ON [dbo].[FuncionesRoles]
(
	[rolId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IFUNCIONESROLES2]    Script Date: 29/3/2020 23:15:46 ******/
CREATE NONCLUSTERED INDEX [IFUNCIONESROLES2] ON [dbo].[FuncionesRoles]
(
	[funId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IFUNCIONESROLESPERMISOS2]    Script Date: 29/3/2020 23:15:46 ******/
CREATE NONCLUSTERED INDEX [IFUNCIONESROLESPERMISOS2] ON [dbo].[FuncionesRolesPermisos]
(
	[tipPermisoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IINVENTARIO1]    Script Date: 29/3/2020 23:15:46 ******/
CREATE NONCLUSTERED INDEX [IINVENTARIO1] ON [dbo].[Inventario]
(
	[proId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IPartidasContableDetalle2]    Script Date: 29/3/2020 23:15:46 ******/
CREATE NONCLUSTERED INDEX [IPartidasContableDetalle2] ON [dbo].[PartidasContableDetalle]
(
	[ctaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IPRODUCTO1]    Script Date: 29/3/2020 23:15:46 ******/
CREATE NONCLUSTERED INDEX [IPRODUCTO1] ON [dbo].[Producto]
(
	[catProductoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IPRODUCTO2]    Script Date: 29/3/2020 23:15:46 ******/
CREATE NONCLUSTERED INDEX [IPRODUCTO2] ON [dbo].[Producto]
(
	[uniId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IPRODUCTO3]    Script Date: 29/3/2020 23:15:46 ******/
CREATE NONCLUSTERED INDEX [IPRODUCTO3] ON [dbo].[Producto]
(
	[impId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IROLESUSUARIO1]    Script Date: 29/3/2020 23:15:46 ******/
CREATE NONCLUSTERED INDEX [IROLESUSUARIO1] ON [dbo].[RolesUsuario]
(
	[rolId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IROLESUSUARIO2]    Script Date: 29/3/2020 23:15:46 ******/
CREATE NONCLUSTERED INDEX [IROLESUSUARIO2] ON [dbo].[RolesUsuario]
(
	[usuId] ASC,
	[usuNick] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CompraProductosDetalle]  WITH CHECK ADD  CONSTRAINT [ICOMPRAPRODUCTOSDETALLE1] FOREIGN KEY([proId])
REFERENCES [dbo].[Producto] ([proId])
GO
ALTER TABLE [dbo].[CompraProductosDetalle] CHECK CONSTRAINT [ICOMPRAPRODUCTOSDETALLE1]
GO
ALTER TABLE [dbo].[CompraProductosDetalle]  WITH CHECK ADD  CONSTRAINT [ICOMPRAPRODUCTOSDETALLE2] FOREIGN KEY([comProId])
REFERENCES [dbo].[CompraProductos] ([comProId])
GO
ALTER TABLE [dbo].[CompraProductosDetalle] CHECK CONSTRAINT [ICOMPRAPRODUCTOSDETALLE2]
GO
ALTER TABLE [dbo].[Cuentas]  WITH CHECK ADD  CONSTRAINT [ICUENTAS1] FOREIGN KEY([claCtaId])
REFERENCES [dbo].[ClasificacionCuenta] ([claCtaId])
GO
ALTER TABLE [dbo].[Cuentas] CHECK CONSTRAINT [ICUENTAS1]
GO
ALTER TABLE [dbo].[Factura]  WITH CHECK ADD  CONSTRAINT [IFACTURA1] FOREIGN KEY([cliId])
REFERENCES [dbo].[Cliente] ([cliId])
GO
ALTER TABLE [dbo].[Factura] CHECK CONSTRAINT [IFACTURA1]
GO
ALTER TABLE [dbo].[FacturaDetalle]  WITH CHECK ADD  CONSTRAINT [IFACTURADETALLE1] FOREIGN KEY([proId])
REFERENCES [dbo].[Producto] ([proId])
GO
ALTER TABLE [dbo].[FacturaDetalle] CHECK CONSTRAINT [IFACTURADETALLE1]
GO
ALTER TABLE [dbo].[FacturaDetalle]  WITH CHECK ADD  CONSTRAINT [IFACTURADETALLE2] FOREIGN KEY([facId])
REFERENCES [dbo].[Factura] ([facId])
GO
ALTER TABLE [dbo].[FacturaDetalle] CHECK CONSTRAINT [IFACTURADETALLE2]
GO
ALTER TABLE [dbo].[FuncionesRoles]  WITH CHECK ADD  CONSTRAINT [IFUNCIONESROLES1] FOREIGN KEY([rolId])
REFERENCES [dbo].[Rol] ([rolId])
GO
ALTER TABLE [dbo].[FuncionesRoles] CHECK CONSTRAINT [IFUNCIONESROLES1]
GO
ALTER TABLE [dbo].[FuncionesRoles]  WITH CHECK ADD  CONSTRAINT [IFUNCIONESROLES2] FOREIGN KEY([funId])
REFERENCES [dbo].[Funciones] ([funId])
GO
ALTER TABLE [dbo].[FuncionesRoles] CHECK CONSTRAINT [IFUNCIONESROLES2]
GO
ALTER TABLE [dbo].[FuncionesRolesPermisos]  WITH CHECK ADD  CONSTRAINT [IFUNCIONESROLESPERMISOS1] FOREIGN KEY([funRolesId])
REFERENCES [dbo].[FuncionesRoles] ([funRolesId])
GO
ALTER TABLE [dbo].[FuncionesRolesPermisos] CHECK CONSTRAINT [IFUNCIONESROLESPERMISOS1]
GO
ALTER TABLE [dbo].[FuncionesRolesPermisos]  WITH CHECK ADD  CONSTRAINT [IFUNCIONESROLESPERMISOS2] FOREIGN KEY([tipPermisoId])
REFERENCES [dbo].[TiposPermisos] ([tipPermisoId])
GO
ALTER TABLE [dbo].[FuncionesRolesPermisos] CHECK CONSTRAINT [IFUNCIONESROLESPERMISOS2]
GO
ALTER TABLE [dbo].[Inventario]  WITH CHECK ADD  CONSTRAINT [IINVENTARIO1] FOREIGN KEY([proId])
REFERENCES [dbo].[Producto] ([proId])
GO
ALTER TABLE [dbo].[Inventario] CHECK CONSTRAINT [IINVENTARIO1]
GO
ALTER TABLE [dbo].[PartidasContableDetalle]  WITH CHECK ADD  CONSTRAINT [IPartidasContableDetalle2] FOREIGN KEY([ctaId])
REFERENCES [dbo].[Cuentas] ([ctaId])
GO
ALTER TABLE [dbo].[PartidasContableDetalle] CHECK CONSTRAINT [IPartidasContableDetalle2]
GO
ALTER TABLE [dbo].[PartidasContableDetalle]  WITH CHECK ADD  CONSTRAINT [IPartidasContableDetalle3] FOREIGN KEY([parId])
REFERENCES [dbo].[PartidasContable] ([parId])
GO
ALTER TABLE [dbo].[PartidasContableDetalle] CHECK CONSTRAINT [IPartidasContableDetalle3]
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [IPRODUCTO1] FOREIGN KEY([catProductoId])
REFERENCES [dbo].[Categoria] ([catProductoId])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [IPRODUCTO1]
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [IPRODUCTO2] FOREIGN KEY([uniId])
REFERENCES [dbo].[Unidades] ([uniId])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [IPRODUCTO2]
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [IPRODUCTO3] FOREIGN KEY([impId])
REFERENCES [dbo].[Impuestos] ([impId])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [IPRODUCTO3]
GO
ALTER TABLE [dbo].[RolesUsuario]  WITH CHECK ADD  CONSTRAINT [IROLESUSUARIO1] FOREIGN KEY([rolId])
REFERENCES [dbo].[Rol] ([rolId])
GO
ALTER TABLE [dbo].[RolesUsuario] CHECK CONSTRAINT [IROLESUSUARIO1]
GO
ALTER TABLE [dbo].[RolesUsuario]  WITH CHECK ADD  CONSTRAINT [IROLESUSUARIO2] FOREIGN KEY([usuId], [usuNick])
REFERENCES [dbo].[Usuario] ([usuId], [usuNick])
GO
ALTER TABLE [dbo].[RolesUsuario] CHECK CONSTRAINT [IROLESUSUARIO2]
GO
/****** Object:  StoredProcedure [dbo].[WWUsuarios]    Script Date: 29/3/2020 23:15:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[WWUsuarios]
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
		
		SELECT Usuario.usuNick, Usuario.usuCorreo, RolesUsuario.rolId, Rol.rolDescripcion, Funciones.funDescripcion , FuncionesRoles.funRolesId, Usuario.usuNombres ,Usuario.usuApellidos
		FROM Usuario INNER JOIN RolesUsuario ON Usuario.usuId = RolesUsuario.usuId INNER JOIN Rol ON RolesUsuario.rolId = Rol.rolId INNER JOIN FuncionesRoles on Rol.rolId = FuncionesRoles.rolId
		INNER JOIN Funciones ON FuncionesRoles.funId = Funciones.funId
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
USE [master]
GO
ALTER DATABASE [supermercados] SET  READ_WRITE 
GO
