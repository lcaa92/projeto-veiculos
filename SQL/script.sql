USE [VeiculosDB]
GO
/****** Object:  Table [dbo].[fotos_veiculo]    Script Date: 29/09/2017 18:52:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[fotos_veiculo](
	[id_foto] [bigint] IDENTITY(1,1) NOT NULL,
	[nome] [varchar](40) NOT NULL,
	[id_veiculo] [bigint] NOT NULL,
	[arquivo] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_foto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tipos_veiculo]    Script Date: 29/09/2017 18:52:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tipos_veiculo](
	[id_tipo_veiculo] [bigint] IDENTITY(1,1) NOT NULL,
	[nome] [varchar](80) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_tipo_veiculo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[veiculos]    Script Date: 29/09/2017 18:52:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[veiculos](
	[id_veiculo] [bigint] IDENTITY(1,1) NOT NULL,
	[placa] [varchar](7) NOT NULL,
	[proprietario] [varchar](30) NOT NULL,
	[id_tipo_veiculo] [bigint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_veiculo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[fotos_veiculo] ON 

INSERT [dbo].[fotos_veiculo] ([id_foto], [nome], [id_veiculo], [arquivo]) VALUES (16, N'teste', 5, N'carro-tunado.jpg')
INSERT [dbo].[fotos_veiculo] ([id_foto], [nome], [id_veiculo], [arquivo]) VALUES (17, N'Nova foto', 5, N'carro-tunado.jpg')
SET IDENTITY_INSERT [dbo].[fotos_veiculo] OFF
SET IDENTITY_INSERT [dbo].[tipos_veiculo] ON 

INSERT [dbo].[tipos_veiculo] ([id_tipo_veiculo], [nome]) VALUES (1, N'Motocicleta')
INSERT [dbo].[tipos_veiculo] ([id_tipo_veiculo], [nome]) VALUES (2, N'Automóvel')
INSERT [dbo].[tipos_veiculo] ([id_tipo_veiculo], [nome]) VALUES (3, N'Microônibus')
INSERT [dbo].[tipos_veiculo] ([id_tipo_veiculo], [nome]) VALUES (4, N'Ônibus')
INSERT [dbo].[tipos_veiculo] ([id_tipo_veiculo], [nome]) VALUES (5, N'Caminhão')
INSERT [dbo].[tipos_veiculo] ([id_tipo_veiculo], [nome]) VALUES (6, N'Caminhão-Trator')
INSERT [dbo].[tipos_veiculo] ([id_tipo_veiculo], [nome]) VALUES (7, N'Caminhonete')
SET IDENTITY_INSERT [dbo].[tipos_veiculo] OFF
SET IDENTITY_INSERT [dbo].[veiculos] ON 

INSERT [dbo].[veiculos] ([id_veiculo], [placa], [proprietario], [id_tipo_veiculo]) VALUES (5, N'OOO6532', N'Zé', 1)
INSERT [dbo].[veiculos] ([id_veiculo], [placa], [proprietario], [id_tipo_veiculo]) VALUES (6, N'FFF2222', N'Hector', 2)
INSERT [dbo].[veiculos] ([id_veiculo], [placa], [proprietario], [id_tipo_veiculo]) VALUES (7, N'TTT9543', N'José', 7)
SET IDENTITY_INSERT [dbo].[veiculos] OFF
ALTER TABLE [dbo].[fotos_veiculo]  WITH CHECK ADD  CONSTRAINT [fk_fotos_veiculos] FOREIGN KEY([id_veiculo])
REFERENCES [dbo].[veiculos] ([id_veiculo])
GO
ALTER TABLE [dbo].[fotos_veiculo] CHECK CONSTRAINT [fk_fotos_veiculos]
GO
ALTER TABLE [dbo].[veiculos]  WITH CHECK ADD  CONSTRAINT [fk_veiculos_tipos_veiculo] FOREIGN KEY([id_tipo_veiculo])
REFERENCES [dbo].[tipos_veiculo] ([id_tipo_veiculo])
GO
ALTER TABLE [dbo].[veiculos] CHECK CONSTRAINT [fk_veiculos_tipos_veiculo]
GO
