USE [Projeto_Lab_Web]
GO

ALTER TABLE [dbo].[Pacotes] DROP CONSTRAINT [CK_Pacotes]
GO

/****** Object:  Table [dbo].[Pacotes]    Script Date: 10/02/2021 15:22:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Pacotes]') AND type in (N'U'))
DROP TABLE [dbo].[Pacotes]
GO

/****** Object:  Table [dbo].[Pacotes]    Script Date: 10/02/2021 15:22:55 ******/
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

ALTER TABLE [dbo].[Pacotes]  WITH CHECK ADD  CONSTRAINT [CK_Pacotes] CHECK  (([Preco]>(0)))
GO

ALTER TABLE [dbo].[Pacotes] CHECK CONSTRAINT [CK_Pacotes]
GO


