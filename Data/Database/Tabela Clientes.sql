USE [Projeto_Lab_Web]
GO

ALTER TABLE [dbo].[Clientes] DROP CONSTRAINT [CK_Clientes_Telemovel]
GO

ALTER TABLE [dbo].[Clientes] DROP CONSTRAINT [CK_Clientes_NIF]
GO

ALTER TABLE [dbo].[Clientes] DROP CONSTRAINT [CK_Clientes_Codigo_Postal]
GO

/****** Object:  Table [dbo].[Clientes]    Script Date: 10/02/2021 15:19:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Clientes]') AND type in (N'U'))
DROP TABLE [dbo].[Clientes]
GO

/****** Object:  Table [dbo].[Clientes]    Script Date: 10/02/2021 15:19:43 ******/
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


