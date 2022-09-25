USE [master]
GO

CREATE DATABASE [traderapp_qatar]
GO

USE [traderapp_qatar]
GO
/****** Object:  Table [dbo].[cat_status_juego]    Script Date: 24/09/2022 18:47:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cat_status_juego](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
	[fecha_creacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cat_tipo_liga]    Script Date: 24/09/2022 18:47:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cat_tipo_liga](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_cat_tipo_liga] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cat_tipo_usuario]    Script Date: 24/09/2022 18:47:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cat_tipo_usuario](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tipo] [varchar](50) NOT NULL,
	[fecha_creacion] [datetime] NULL,
 CONSTRAINT [PK_cat_tipo_usuario] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[equipo]    Script Date: 24/09/2022 18:47:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[equipo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](255) NOT NULL,
	[grupo] [int] NOT NULL,
	[pj] [int] NOT NULL,
	[pg] [int] NOT NULL,
	[pe] [int] NOT NULL,
	[pp] [int] NOT NULL,
	[puntos] [int] NOT NULL,
	[fecha_creacion] [datetime] NOT NULL,
	[fecha_modificacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[estadio]    Script Date: 24/09/2022 18:47:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[estadio](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[fecha_creacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[fasegrupos]    Script Date: 24/09/2022 18:47:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[fasegrupos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[equipoa] [int] NOT NULL,
	[equipob] [int] NOT NULL,
	[grupo] [int] NOT NULL,
	[fechayhora] [datetime] NULL,
	[estadio] [int] NOT NULL,
	[estado_juego] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[fasegrupos_resultado]    Script Date: 24/09/2022 18:47:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[fasegrupos_resultado](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[userid] [int] NOT NULL,
	[grupo] [int] NOT NULL,
	[idjuego] [int] NOT NULL,
	[id_equipoa] [int] NOT NULL,
	[equipoa_gol] [int] NOT NULL,
	[id_equipob] [int] NOT NULL,
	[equipob_gol] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[grupo]    Script Date: 24/09/2022 18:47:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[grupo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[grupo] [char](1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[liga]    Script Date: 24/09/2022 18:47:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[liga](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[creator_userid] [int] NOT NULL,
	[fecha_creacion] [datetime] NOT NULL,
	[id_tipo_liga] [int] NOT NULL,
 CONSTRAINT [PK_liga] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuario]    Script Date: 24/09/2022 18:47:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuario](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[pass] [varchar](max) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[status] [int] NOT NULL,
	[tipo] [int] NOT NULL,
	[puntos] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuarioliga]    Script Date: 24/09/2022 18:47:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuarioliga](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idliga] [int] NOT NULL,
	[idusuario] [int] NOT NULL,
	[monto_apuesta] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_usuarioliga_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[equipo]  WITH CHECK ADD  CONSTRAINT [fk_EquipoGrupo] FOREIGN KEY([grupo])
REFERENCES [dbo].[grupo] ([id])
GO
ALTER TABLE [dbo].[equipo] CHECK CONSTRAINT [fk_EquipoGrupo]
GO
ALTER TABLE [dbo].[fasegrupos]  WITH CHECK ADD  CONSTRAINT [FK_fasegrupos_cat_status_juego1] FOREIGN KEY([estado_juego])
REFERENCES [dbo].[cat_status_juego] ([id])
GO
ALTER TABLE [dbo].[fasegrupos] CHECK CONSTRAINT [FK_fasegrupos_cat_status_juego1]
GO
ALTER TABLE [dbo].[fasegrupos]  WITH CHECK ADD  CONSTRAINT [FK_fasegrupos_equipo] FOREIGN KEY([equipoa])
REFERENCES [dbo].[equipo] ([id])
GO
ALTER TABLE [dbo].[fasegrupos] CHECK CONSTRAINT [FK_fasegrupos_equipo]
GO
ALTER TABLE [dbo].[fasegrupos]  WITH CHECK ADD  CONSTRAINT [FK_fasegrupos_equipo1] FOREIGN KEY([equipob])
REFERENCES [dbo].[equipo] ([id])
GO
ALTER TABLE [dbo].[fasegrupos] CHECK CONSTRAINT [FK_fasegrupos_equipo1]
GO
ALTER TABLE [dbo].[fasegrupos]  WITH CHECK ADD  CONSTRAINT [FK_fasegrupos_estadio] FOREIGN KEY([estadio])
REFERENCES [dbo].[estadio] ([id])
GO
ALTER TABLE [dbo].[fasegrupos] CHECK CONSTRAINT [FK_fasegrupos_estadio]
GO
ALTER TABLE [dbo].[fasegrupos_resultado]  WITH CHECK ADD  CONSTRAINT [FK_fasegrupos_resultado_fasegrupos] FOREIGN KEY([idjuego])
REFERENCES [dbo].[fasegrupos] ([id])
GO
ALTER TABLE [dbo].[fasegrupos_resultado] CHECK CONSTRAINT [FK_fasegrupos_resultado_fasegrupos]
GO
ALTER TABLE [dbo].[fasegrupos_resultado]  WITH CHECK ADD  CONSTRAINT [FK_fasegrupos_resultado_grupo] FOREIGN KEY([grupo])
REFERENCES [dbo].[grupo] ([id])
GO
ALTER TABLE [dbo].[fasegrupos_resultado] CHECK CONSTRAINT [FK_fasegrupos_resultado_grupo]
GO
ALTER TABLE [dbo].[fasegrupos_resultado]  WITH CHECK ADD  CONSTRAINT [FK_fasegrupos_resultado_usuario] FOREIGN KEY([userid])
REFERENCES [dbo].[usuario] ([id])
GO
ALTER TABLE [dbo].[fasegrupos_resultado] CHECK CONSTRAINT [FK_fasegrupos_resultado_usuario]
GO
ALTER TABLE [dbo].[liga]  WITH CHECK ADD  CONSTRAINT [FK_liga_cat_tipo_liga] FOREIGN KEY([id_tipo_liga])
REFERENCES [dbo].[cat_tipo_liga] ([id])
GO
ALTER TABLE [dbo].[liga] CHECK CONSTRAINT [FK_liga_cat_tipo_liga]
GO
ALTER TABLE [dbo].[usuario]  WITH CHECK ADD  CONSTRAINT [FK_usuario_cat_tipo_usuario] FOREIGN KEY([tipo])
REFERENCES [dbo].[cat_tipo_usuario] ([id])
GO
ALTER TABLE [dbo].[usuario] CHECK CONSTRAINT [FK_usuario_cat_tipo_usuario]
GO
ALTER TABLE [dbo].[usuarioliga]  WITH CHECK ADD  CONSTRAINT [FK_usuarioliga_liga] FOREIGN KEY([idliga])
REFERENCES [dbo].[liga] ([id])
GO
ALTER TABLE [dbo].[usuarioliga] CHECK CONSTRAINT [FK_usuarioliga_liga]
GO
ALTER TABLE [dbo].[usuarioliga]  WITH CHECK ADD  CONSTRAINT [FK_usuarioliga_usuario] FOREIGN KEY([idusuario])
REFERENCES [dbo].[usuario] ([id])
GO
ALTER TABLE [dbo].[usuarioliga] CHECK CONSTRAINT [FK_usuarioliga_usuario]
GO
USE [master]
GO
ALTER DATABASE [traderapp_qatar] SET  READ_WRITE 
GO
