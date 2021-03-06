USE [test]
GO
/****** Object:  Table [dbo].[Tareas]    Script Date: 13/06/2021 23:02:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tareas](
	[IdTarea] [int] NOT NULL,
	[FechaCreacion] [datetime] NULL,
	[Descripcion] [varchar](50) NULL,
	[EstTarea] [char](2) NULL,
	[FechaVence] [datetime] NULL,
	[AutorTarea] [varchar](20) NULL,
 CONSTRAINT [PK_Tareas] PRIMARY KEY CLUSTERED 
(
	[IdTarea] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Tareas] ([IdTarea], [FechaCreacion], [Descripcion], [EstTarea], [FechaVence], [AutorTarea]) VALUES (1, CAST(N'2021-05-01 00:00:00.000' AS DateTime), N'tareas1', N'SI', CAST(N'2021-05-02 00:00:00.000' AS DateTime), N'SDCHILAN')
INSERT [dbo].[Tareas] ([IdTarea], [FechaCreacion], [Descripcion], [EstTarea], [FechaVence], [AutorTarea]) VALUES (2, CAST(N'2021-04-15 00:00:00.000' AS DateTime), N'TAREAS DE INFORMATICA', N'NO', CAST(N'2021-05-21 00:00:00.000' AS DateTime), N'SDCHILAN')
INSERT [dbo].[Tareas] ([IdTarea], [FechaCreacion], [Descripcion], [EstTarea], [FechaVence], [AutorTarea]) VALUES (3, CAST(N'2021-02-05 00:00:00.000' AS DateTime), N'MATEMATICAS', N'SI', CAST(N'2021-02-06 00:00:00.000' AS DateTime), N'CPONCE')
INSERT [dbo].[Tareas] ([IdTarea], [FechaCreacion], [Descripcion], [EstTarea], [FechaVence], [AutorTarea]) VALUES (4, CAST(N'2021-03-02 00:00:00.000' AS DateTime), N'CULTURA GENERAL', N'SI', CAST(N'2021-03-03 00:00:00.000' AS DateTime), N'CPONCE')
INSERT [dbo].[Tareas] ([IdTarea], [FechaCreacion], [Descripcion], [EstTarea], [FechaVence], [AutorTarea]) VALUES (5, CAST(N'2021-05-01 10:30:00.000' AS DateTime), N'MANTENIMIENTO WEB', N'SI', CAST(N'2021-05-01 15:30:00.000' AS DateTime), N'JCEDEÑO')
INSERT [dbo].[Tareas] ([IdTarea], [FechaCreacion], [Descripcion], [EstTarea], [FechaVence], [AutorTarea]) VALUES (6, CAST(N'2021-05-27 00:00:00.000' AS DateTime), N'Modificacion desde el post6', N'SI', CAST(N'2021-05-28 00:00:00.000' AS DateTime), N'SDCHILAN')
INSERT [dbo].[Tareas] ([IdTarea], [FechaCreacion], [Descripcion], [EstTarea], [FechaVence], [AutorTarea]) VALUES (7, CAST(N'2021-06-10 21:30:41.677' AS DateTime), N'HAY TAREAS PENDIENTES', N'NO', CAST(N'2021-06-10 21:30:41.677' AS DateTime), N'SDCHILAN')
INSERT [dbo].[Tareas] ([IdTarea], [FechaCreacion], [Descripcion], [EstTarea], [FechaVence], [AutorTarea]) VALUES (8, CAST(N'2021-06-14 03:16:59.167' AS DateTime), N'pruebas dos', N'SI', CAST(N'2021-06-14 03:16:59.167' AS DateTime), N'JCEDEÑO')
/****** Object:  StoredProcedure [dbo].[tsp_eliminar]    Script Date: 13/06/2021 23:02:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[tsp_eliminar](@idTarea int, @autor varchar(20))
as
begin

delete from Tareas where IdTarea = @idTarea and AutorTarea = @autor

end;
GO
/****** Object:  StoredProcedure [dbo].[tsp_listar]    Script Date: 13/06/2021 23:02:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[tsp_listar]
as
begin
select * from Tareas
end;
GO
/****** Object:  StoredProcedure [dbo].[tsp_modificar]    Script Date: 13/06/2021 23:02:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[tsp_modificar](@idtarea int,
								 @Descripcion varchar(50),
								 @EstTarea char(2),
								 @Autor varchar(20),
								 @FechaVence datetime,
								 @fechCreacion datetime)
as
begin

update Tareas 
set Descripcion = @Descripcion, EstTarea = @EstTarea, FechaCreacion = @fechCreacion, FechaVence = @FechaVence
where IdTarea = @idtarea and AutorTarea = @Autor
end;
GO
/****** Object:  StoredProcedure [dbo].[tsp_obtenerByFchVence]    Script Date: 13/06/2021 23:02:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[tsp_obtenerByFchVence]
as
begin
select * from Tareas order by FechaVence Desc
end
GO
/****** Object:  StoredProcedure [dbo].[tsp_obtenerByID]    Script Date: 13/06/2021 23:02:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[tsp_obtenerByID](@idTarea int)
as
begin

select * from Tareas where IdTarea = @idTarea
end
GO
/****** Object:  StoredProcedure [dbo].[tsp_registrar]    Script Date: 13/06/2021 23:02:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[tsp_registrar](@IdTarea int,
									   @Descripcion varchar(50),
									   @EstTarea char(2),
									   @Autor varchar(20),
									   @FechaVence datetime,
									   @fechCreacion datetime)
as
begin

insert into Tareas(idTarea, Descripcion, EstTarea, AutorTarea, FechaCreacion, FechaVence)
values(@IdTarea, @Descripcion, @EstTarea, @Autor, @fechCreacion,@FechaVence)

end
GO
