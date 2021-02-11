USE [Projeto_Lab_Web]
GO

ALTER TABLE [dbo].[Servicos_Pacotes] DROP CONSTRAINT [FK_Servicos_Pacotes_Servicos]
GO

ALTER TABLE [dbo].[Servicos_Pacotes] DROP CONSTRAINT [FK_Servicos_Pacotes_Pacotes]
GO

/****** Object:  Table [dbo].[Servicos_Pacotes]    Script Date: 10/02/2021 15:26:17 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Servicos_Pacotes]') AND type in (N'U'))
DROP TABLE [dbo].[Servicos_Pacotes]
GO

/****** Object:  Table [dbo].[Servicos_Pacotes]    Script Date: 10/02/2021 15:26:17 ******/
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


