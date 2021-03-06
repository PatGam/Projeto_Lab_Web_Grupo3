USE [master]
GO
/****** Object:  Database [Projeto_Lab_WebContext]    Script Date: 12/02/2021 10:21:21 ******/
CREATE DATABASE [Projeto_Lab_WebContext]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Projeto_Lab_WebContext', FILENAME = N'C:\Users\xxx\Projeto_Lab_WebContext.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Projeto_Lab_WebContext_log', FILENAME = N'C:\Users\xxx\Projeto_Lab_WebContext_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Projeto_Lab_WebContext] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Projeto_Lab_WebContext].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Projeto_Lab_WebContext] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Projeto_Lab_WebContext] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Projeto_Lab_WebContext] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Projeto_Lab_WebContext] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Projeto_Lab_WebContext] SET ARITHABORT OFF 
GO
ALTER DATABASE [Projeto_Lab_WebContext] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Projeto_Lab_WebContext] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Projeto_Lab_WebContext] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Projeto_Lab_WebContext] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Projeto_Lab_WebContext] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Projeto_Lab_WebContext] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Projeto_Lab_WebContext] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Projeto_Lab_WebContext] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Projeto_Lab_WebContext] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Projeto_Lab_WebContext] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Projeto_Lab_WebContext] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Projeto_Lab_WebContext] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Projeto_Lab_WebContext] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Projeto_Lab_WebContext] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Projeto_Lab_WebContext] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Projeto_Lab_WebContext] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [Projeto_Lab_WebContext] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Projeto_Lab_WebContext] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Projeto_Lab_WebContext] SET  MULTI_USER 
GO
ALTER DATABASE [Projeto_Lab_WebContext] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Projeto_Lab_WebContext] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Projeto_Lab_WebContext] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Projeto_Lab_WebContext] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Projeto_Lab_WebContext] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Projeto_Lab_WebContext] SET QUERY_STORE = OFF
GO
USE [Projeto_Lab_WebContext]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [Projeto_Lab_WebContext]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 12/02/2021 10:21:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 12/02/2021 10:21:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[Cliente_Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](100) NOT NULL,
	[Data_Nascimento] [date] NOT NULL,
	[NIF] [int] NOT NULL,
	[Morada] [nvarchar](200) NOT NULL,
	[Telemovel] [int] NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Codigo_Postal] [nvarchar](8) NOT NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[Cliente_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contratos]    Script Date: 12/02/2021 10:21:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contratos](
	[Contrato_Id] [int] IDENTITY(1,1) NOT NULL,
	[Cliente_Id] [int] NOT NULL,
	[Funcionario_Id] [int] NOT NULL,
	[Data_inicio] [date] NOT NULL,
	[Preco_Final] [decimal](18, 2) NOT NULL,
	[Data_Fim] [date] NOT NULL,
	[Promocoes_Pacotes] [int] NOT NULL,
	[Preco_pacote] [decimal](18, 2) NOT NULL,
	[Promocao_desc] [decimal](18, 2) NOT NULL,
	[Nome_Cliente] [nvarchar](100) NOT NULL,
	[Nome_Funcionario] [nvarchar](100) NOT NULL,
	[Telefone] [int] NOT NULL,
 CONSTRAINT [PK_Contratos] PRIMARY KEY CLUSTERED 
(
	[Contrato_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Funcionarios]    Script Date: 12/02/2021 10:21:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Funcionarios](
	[Funcionario_Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](100) NOT NULL,
	[Data_Nascimento] [date] NOT NULL,
	[Morada] [nvarchar](500) NOT NULL,
	[Telemovel] [int] NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Codigo_Postal] [nvarchar](8) NOT NULL,
	[Role] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Funcionarios] PRIMARY KEY CLUSTERED 
(
	[Funcionario_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pacotes]    Script Date: 12/02/2021 10:21:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pacotes](
	[Pacote_Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](100) NOT NULL,
	[Descricao] [nvarchar](1000) NULL,
	[Preco] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Pacotes] PRIMARY KEY CLUSTERED 
(
	[Pacote_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Promocoes]    Script Date: 12/02/2021 10:21:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Promocoes](
	[Promocoes_Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](100) NOT NULL,
	[Descricao] [nvarchar](1000) NULL,
	[Data_inicio] [date] NOT NULL,
	[Data_fim] [date] NOT NULL,
	[Promocao_desc] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Promocoes] PRIMARY KEY CLUSTERED 
(
	[Promocoes_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Promocoes_Pacotes]    Script Date: 12/02/2021 10:21:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Promocoes_Pacotes](
	[Promocoes_Pacotes_Id] [int] IDENTITY(1,1) NOT NULL,
	[Pacote_Id] [int] NOT NULL,
	[Promocoes_Id] [int] NOT NULL,
	[Nome_Pacote] [nvarchar](100) NOT NULL,
	[Nome_Promocoes] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Promocoes_Pacotes] PRIMARY KEY CLUSTERED 
(
	[Promocoes_Pacotes_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Servicos]    Script Date: 12/02/2021 10:21:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Servicos](
	[Servico_Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](100) NOT NULL,
	[Descricao] [nvarchar](1000) NULL,
	[Tipo_Servico] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Servicos] PRIMARY KEY CLUSTERED 
(
	[Servico_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Servicos_Pacotes]    Script Date: 12/02/2021 10:21:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Servicos_Pacotes](
	[Sevico_Pacote_Id] [int] IDENTITY(1,1) NOT NULL,
	[Servico_Id] [int] NOT NULL,
	[Pacote_Id] [int] NOT NULL,
 CONSTRAINT [PK_Servicos_Pacotes] PRIMARY KEY CLUSTERED 
(
	[Sevico_Pacote_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [IX_Contratos_Cliente_Id]    Script Date: 12/02/2021 10:21:21 ******/
CREATE NONCLUSTERED INDEX [IX_Contratos_Cliente_Id] ON [dbo].[Contratos]
(
	[Cliente_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Contratos_Funcionario_Id]    Script Date: 12/02/2021 10:21:21 ******/
CREATE NONCLUSTERED INDEX [IX_Contratos_Funcionario_Id] ON [dbo].[Contratos]
(
	[Funcionario_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Contratos_Promocoes_Pacotes]    Script Date: 12/02/2021 10:21:21 ******/
CREATE NONCLUSTERED INDEX [IX_Contratos_Promocoes_Pacotes] ON [dbo].[Contratos]
(
	[Promocoes_Pacotes] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Promocoes_Pacotes_Pacote_Id]    Script Date: 12/02/2021 10:21:21 ******/
CREATE NONCLUSTERED INDEX [IX_Promocoes_Pacotes_Pacote_Id] ON [dbo].[Promocoes_Pacotes]
(
	[Pacote_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Promocoes_Pacotes_Promocoes_Id]    Script Date: 12/02/2021 10:21:21 ******/
CREATE NONCLUSTERED INDEX [IX_Promocoes_Pacotes_Promocoes_Id] ON [dbo].[Promocoes_Pacotes]
(
	[Promocoes_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Servicos_Pacotes_Pacote_Id]    Script Date: 12/02/2021 10:21:21 ******/
CREATE NONCLUSTERED INDEX [IX_Servicos_Pacotes_Pacote_Id] ON [dbo].[Servicos_Pacotes]
(
	[Pacote_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Servicos_Pacotes_Servico_Id]    Script Date: 12/02/2021 10:21:21 ******/
CREATE NONCLUSTERED INDEX [IX_Servicos_Pacotes_Servico_Id] ON [dbo].[Servicos_Pacotes]
(
	[Servico_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Contratos]  WITH CHECK ADD  CONSTRAINT [FK_Contratos_Clientes] FOREIGN KEY([Cliente_Id])
REFERENCES [dbo].[Clientes] ([Cliente_Id])
GO
ALTER TABLE [dbo].[Contratos] CHECK CONSTRAINT [FK_Contratos_Clientes]
GO
ALTER TABLE [dbo].[Contratos]  WITH CHECK ADD  CONSTRAINT [FK_Contratos_Funcionarios] FOREIGN KEY([Funcionario_Id])
REFERENCES [dbo].[Funcionarios] ([Funcionario_Id])
GO
ALTER TABLE [dbo].[Contratos] CHECK CONSTRAINT [FK_Contratos_Funcionarios]
GO
ALTER TABLE [dbo].[Contratos]  WITH CHECK ADD  CONSTRAINT [FK_Contratos_Promocoes_Pacotes] FOREIGN KEY([Promocoes_Pacotes])
REFERENCES [dbo].[Promocoes_Pacotes] ([Promocoes_Pacotes_Id])
GO
ALTER TABLE [dbo].[Contratos] CHECK CONSTRAINT [FK_Contratos_Promocoes_Pacotes]
GO
ALTER TABLE [dbo].[Promocoes_Pacotes]  WITH CHECK ADD  CONSTRAINT [FK_Promocoes_Pacotes_Pacotes] FOREIGN KEY([Pacote_Id])
REFERENCES [dbo].[Pacotes] ([Pacote_Id])
GO
ALTER TABLE [dbo].[Promocoes_Pacotes] CHECK CONSTRAINT [FK_Promocoes_Pacotes_Pacotes]
GO
ALTER TABLE [dbo].[Promocoes_Pacotes]  WITH CHECK ADD  CONSTRAINT [FK_Promocoes_Pacotes_Promocoes] FOREIGN KEY([Promocoes_Id])
REFERENCES [dbo].[Promocoes] ([Promocoes_Id])
GO
ALTER TABLE [dbo].[Promocoes_Pacotes] CHECK CONSTRAINT [FK_Promocoes_Pacotes_Promocoes]
GO
ALTER TABLE [dbo].[Servicos_Pacotes]  WITH CHECK ADD  CONSTRAINT [FK_Servicos_Pacotes_Pacotes] FOREIGN KEY([Pacote_Id])
REFERENCES [dbo].[Pacotes] ([Pacote_Id])
GO
ALTER TABLE [dbo].[Servicos_Pacotes] CHECK CONSTRAINT [FK_Servicos_Pacotes_Pacotes]
GO
ALTER TABLE [dbo].[Servicos_Pacotes]  WITH CHECK ADD  CONSTRAINT [FK_Servicos_Pacotes_Servicos] FOREIGN KEY([Servico_Id])
REFERENCES [dbo].[Servicos] ([Servico_Id])
GO
ALTER TABLE [dbo].[Servicos_Pacotes] CHECK CONSTRAINT [FK_Servicos_Pacotes_Servicos]
GO
USE [master]
GO
ALTER DATABASE [Projeto_Lab_WebContext] SET  READ_WRITE 
GO
