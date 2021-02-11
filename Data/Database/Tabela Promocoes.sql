USE [Projeto_Lab_Web]
GO

ALTER TABLE [dbo].[Promocoes] DROP CONSTRAINT [CK_Promocoes]
GO

/****** Object:  Table [dbo].[Promocoes]    Script Date: 10/02/2021 15:24:34 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Promocoes]') AND type in (N'U'))
DROP TABLE [dbo].[Promocoes]
GO

/****** Object:  Table [dbo].[Promocoes]    Script Date: 10/02/2021 15:24:34 ******/
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

ALTER TABLE [dbo].[Promocoes]  WITH CHECK ADD  CONSTRAINT [CK_Promocoes] CHECK  (([Promocao_desc]>(0)))
GO

ALTER TABLE [dbo].[Promocoes] CHECK CONSTRAINT [CK_Promocoes]
GO


