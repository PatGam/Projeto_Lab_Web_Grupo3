USE [master]
GO
/****** Object:  Database [Projeto_Lab_Web]    Script Date: 11/02/2021 11:26:10 ******/
CREATE DATABASE [Projeto_Lab_Web]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Projeto_Lab_Web', FILENAME = N'C:\Users\vital\Projeto_Lab_Web.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Projeto_Lab_Web_log', FILENAME = N'C:\Users\vital\Projeto_Lab_Web_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Projeto_Lab_Web] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Projeto_Lab_Web].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Projeto_Lab_Web] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Projeto_Lab_Web] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Projeto_Lab_Web] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Projeto_Lab_Web] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Projeto_Lab_Web] SET ARITHABORT OFF 
GO
ALTER DATABASE [Projeto_Lab_Web] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Projeto_Lab_Web] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Projeto_Lab_Web] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Projeto_Lab_Web] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Projeto_Lab_Web] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Projeto_Lab_Web] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Projeto_Lab_Web] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Projeto_Lab_Web] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Projeto_Lab_Web] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Projeto_Lab_Web] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Projeto_Lab_Web] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Projeto_Lab_Web] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Projeto_Lab_Web] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Projeto_Lab_Web] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Projeto_Lab_Web] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Projeto_Lab_Web] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Projeto_Lab_Web] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Projeto_Lab_Web] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Projeto_Lab_Web] SET  MULTI_USER 
GO
ALTER DATABASE [Projeto_Lab_Web] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Projeto_Lab_Web] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Projeto_Lab_Web] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Projeto_Lab_Web] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Projeto_Lab_Web] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Projeto_Lab_Web] SET QUERY_STORE = OFF
GO
USE [Projeto_Lab_Web]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [Projeto_Lab_Web]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 11/02/2021 11:26:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[Cliente_Id] [int] NOT NULL,
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
/****** Object:  Table [dbo].[Contratos]    Script Date: 11/02/2021 11:26:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contratos](
	[Contrato_Id] [int] NOT NULL,
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
/****** Object:  Table [dbo].[Funcionarios]    Script Date: 11/02/2021 11:26:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Funcionarios](
	[Funcionario_Id] [int] NOT NULL,
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
/****** Object:  Table [dbo].[Pacotes]    Script Date: 11/02/2021 11:26:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pacotes](
	[Pacote_Id] [int] NOT NULL,
	[Nome] [nvarchar](100) NOT NULL,
	[Descricao] [nvarchar](1000) NULL,
	[Preco] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Pacotes] PRIMARY KEY CLUSTERED 
(
	[Pacote_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Promocoes]    Script Date: 11/02/2021 11:26:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Promocoes](
	[Promocoes_Id] [int] NOT NULL,
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
/****** Object:  Table [dbo].[Promocoes_Pacotes]    Script Date: 11/02/2021 11:26:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Promocoes_Pacotes](
	[Pacote_Id] [int] NOT NULL,
	[Promocoes_Id] [int] NOT NULL,
	[Promocoes_Pacotes_Id] [int] NOT NULL,
	[Nome_Pacote] [nvarchar](100) NOT NULL,
	[Nome_Promocoes] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Promocoes_Pacotes] PRIMARY KEY CLUSTERED 
(
	[Promocoes_Pacotes_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Servicos]    Script Date: 11/02/2021 11:26:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Servicos](
	[Servico_Id] [int] NOT NULL,
	[Nome] [nvarchar](100) NOT NULL,
	[Descricao] [nvarchar](1000) NULL,
	[Tipo_Servico] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Servicos] PRIMARY KEY CLUSTERED 
(
	[Servico_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Servicos_Pacotes]    Script Date: 11/02/2021 11:26:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Servicos_Pacotes](
	[Servico_Id] [int] NOT NULL,
	[Pacote_Id] [int] NOT NULL,
	[Sevico_Pacote_Id] [int] NOT NULL,
 CONSTRAINT [PK_Servicos_Pacotes] PRIMARY KEY CLUSTERED 
(
	[Sevico_Pacote_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Clientes_Email]    Script Date: 11/02/2021 11:26:11 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Clientes_Email] ON [dbo].[Clientes]
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Clientes_NIF]    Script Date: 11/02/2021 11:26:11 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Clientes_NIF] ON [dbo].[Clientes]
(
	[NIF] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Clientes_Telemovel]    Script Date: 11/02/2021 11:26:11 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Clientes_Telemovel] ON [dbo].[Clientes]
(
	[Telemovel] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Operadores_Email]    Script Date: 11/02/2021 11:26:11 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Operadores_Email] ON [dbo].[Funcionarios]
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Operadores_Telemovel]    Script Date: 11/02/2021 11:26:11 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Operadores_Telemovel] ON [dbo].[Funcionarios]
(
	[Telemovel] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
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
ALTER TABLE [dbo].[Clientes]  WITH CHECK ADD  CONSTRAINT [CK_Clientes_Codigo_Postal] CHECK  (([Codigo_Postal] like '[0-9][0-9][0-9][0-9]-[0-9][0-9][0-9]'))
GO
ALTER TABLE [dbo].[Clientes] CHECK CONSTRAINT [CK_Clientes_Codigo_Postal]
GO
ALTER TABLE [dbo].[Clientes]  WITH CHECK ADD  CONSTRAINT [CK_Clientes_NIF] CHECK  (([NIF] like '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'))
GO
ALTER TABLE [dbo].[Clientes] CHECK CONSTRAINT [CK_Clientes_NIF]
GO
ALTER TABLE [dbo].[Clientes]  WITH CHECK ADD  CONSTRAINT [CK_Clientes_Telemovel] CHECK  (([Telemovel] like '9[1236][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'))
GO
ALTER TABLE [dbo].[Clientes] CHECK CONSTRAINT [CK_Clientes_Telemovel]
GO
ALTER TABLE [dbo].[Contratos]  WITH CHECK ADD  CONSTRAINT [CK_Contratos] CHECK  (([Preco_Final]>(0)))
GO
ALTER TABLE [dbo].[Contratos] CHECK CONSTRAINT [CK_Contratos]
GO
ALTER TABLE [dbo].[Contratos]  WITH CHECK ADD  CONSTRAINT [CK_Contratos_Telefone] CHECK  (([Telefone] like '2[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'))
GO
ALTER TABLE [dbo].[Contratos] CHECK CONSTRAINT [CK_Contratos_Telefone]
GO
ALTER TABLE [dbo].[Funcionarios]  WITH CHECK ADD  CONSTRAINT [CK_Funcionarios_Codigo_Postal] CHECK  (([Codigo_Postal] like '[0-9][0-9][0-9][0-9]-[0-9][0-9][0-9]'))
GO
ALTER TABLE [dbo].[Funcionarios] CHECK CONSTRAINT [CK_Funcionarios_Codigo_Postal]
GO
ALTER TABLE [dbo].[Funcionarios]  WITH CHECK ADD  CONSTRAINT [CK_Funcionarios_Telemovel] CHECK  (([Telemovel] like '9[1236][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'))
GO
ALTER TABLE [dbo].[Funcionarios] CHECK CONSTRAINT [CK_Funcionarios_Telemovel]
GO
ALTER TABLE [dbo].[Pacotes]  WITH CHECK ADD  CONSTRAINT [CK_Pacotes] CHECK  (([Preco]>(0)))
GO
ALTER TABLE [dbo].[Pacotes] CHECK CONSTRAINT [CK_Pacotes]
GO
ALTER TABLE [dbo].[Promocoes]  WITH CHECK ADD  CONSTRAINT [CK_Promocoes] CHECK  (([Promocao_desc]>(0)))
GO
ALTER TABLE [dbo].[Promocoes] CHECK CONSTRAINT [CK_Promocoes]
GO
USE [master]
GO
ALTER DATABASE [Projeto_Lab_Web] SET  READ_WRITE 
GO
