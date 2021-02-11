USE [Projeto_Lab_Web]
GO

ALTER TABLE [dbo].[Promocoes_Pacotes] DROP CONSTRAINT [FK_Promocoes_Pacotes_Promocoes]
GO

ALTER TABLE [dbo].[Promocoes_Pacotes] DROP CONSTRAINT [FK_Promocoes_Pacotes_Pacotes]
GO

/****** Object:  Table [dbo].[Promocoes_Pacotes]    Script Date: 10/02/2021 15:25:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Promocoes_Pacotes]') AND type in (N'U'))
DROP TABLE [dbo].[Promocoes_Pacotes]
GO

/****** Object:  Table [dbo].[Promocoes_Pacotes]    Script Date: 10/02/2021 15:25:07 ******/
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


