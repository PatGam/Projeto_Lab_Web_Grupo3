USE [Projeto_Lab_Web]
GO

ALTER TABLE [dbo].[Contratos] DROP CONSTRAINT [CK_Contratos_Telefone]
GO

ALTER TABLE [dbo].[Contratos] DROP CONSTRAINT [CK_Contratos]
GO

ALTER TABLE [dbo].[Contratos] DROP CONSTRAINT [FK_Contratos_Promocoes_Pacotes]
GO

ALTER TABLE [dbo].[Contratos] DROP CONSTRAINT [FK_Contratos_Funcionarios]
GO

ALTER TABLE [dbo].[Contratos] DROP CONSTRAINT [FK_Contratos_Clientes]
GO

/****** Object:  Table [dbo].[Contratos]    Script Date: 10/02/2021 15:20:30 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Contratos]') AND type in (N'U'))
DROP TABLE [dbo].[Contratos]
GO

/****** Object:  Table [dbo].[Contratos]    Script Date: 10/02/2021 15:20:30 ******/
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

ALTER TABLE [dbo].[Contratos]  WITH CHECK ADD  CONSTRAINT [CK_Contratos] CHECK  (([Preco_Final]>(0)))
GO

ALTER TABLE [dbo].[Contratos] CHECK CONSTRAINT [CK_Contratos]
GO

ALTER TABLE [dbo].[Contratos]  WITH CHECK ADD  CONSTRAINT [CK_Contratos_Telefone] CHECK  (([Telefone] like '2[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'))
GO

ALTER TABLE [dbo].[Contratos] CHECK CONSTRAINT [CK_Contratos_Telefone]
GO


