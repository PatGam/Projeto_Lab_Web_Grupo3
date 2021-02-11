USE [Projeto_Lab_Web]
GO

ALTER TABLE [dbo].[Funcionarios] DROP CONSTRAINT [CK_Funcionarios_Telemovel]
GO

ALTER TABLE [dbo].[Funcionarios] DROP CONSTRAINT [CK_Funcionarios_Codigo_Postal]
GO

/****** Object:  Table [dbo].[Funcionarios]    Script Date: 10/02/2021 15:21:24 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Funcionarios]') AND type in (N'U'))
DROP TABLE [dbo].[Funcionarios]
GO

/****** Object:  Table [dbo].[Funcionarios]    Script Date: 10/02/2021 15:21:24 ******/
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

ALTER TABLE [dbo].[Funcionarios]  WITH CHECK ADD  CONSTRAINT [CK_Funcionarios_Codigo_Postal] CHECK  (([Codigo_Postal] like '[0-9][0-9][0-9][0-9]-[0-9][0-9][0-9]'))
GO

ALTER TABLE [dbo].[Funcionarios] CHECK CONSTRAINT [CK_Funcionarios_Codigo_Postal]
GO

ALTER TABLE [dbo].[Funcionarios]  WITH CHECK ADD  CONSTRAINT [CK_Funcionarios_Telemovel] CHECK  (([Telemovel] like '9[1236][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'))
GO

ALTER TABLE [dbo].[Funcionarios] CHECK CONSTRAINT [CK_Funcionarios_Telemovel]
GO


