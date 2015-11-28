-- INSERTS UBICACION --
INSERT INTO [dbo].[UBICACION] ([ubi_latitud], [ubi_longitud], [ubi_ciudad], [ubi_estado], [ubi_direccion]) VALUES ('10.499607', '-66.788419', 'Caracas', 'Miranda', null)
go

INSERT INTO [dbo].[UBICACION] ([ubi_latitud], [ubi_longitud], [ubi_ciudad], [ubi_estado], [ubi_direccion]) VALUES ('10.062028', '-69.4328889', 'Barquisimeto', 'Lara', null)
go

INSERT INTO [dbo].[UBICACION] ([ubi_latitud], [ubi_longitud], [ubi_ciudad], [ubi_estado], [ubi_direccion]) VALUES ('10.1727434', '-68.0642649', 'Valencia', 'Carabobo', null)
go

INSERT INTO [dbo].[UBICACION] ([ubi_latitud], [ubi_longitud], [ubi_ciudad], [ubi_estado], [ubi_direccion]) VALUES ('10.2673453', '-67.6754515', 'Maracay', 'Aragua', null)
go

INSERT INTO [dbo].[UBICACION] ([ubi_latitud], [ubi_longitud], [ubi_ciudad], [ubi_estado], [ubi_direccion]) VALUES ('10.6338776', '-71.8170448', 'Maracaibo', 'Zulia', null)
go

-- INSERTS TIPO_EVENTO --
INSERT INTO [dbo].[TIPO_EVENTO] ([tip_nombre]) VALUES ('Pase de Cinta')
go

INSERT INTO [dbo].[TIPO_EVENTO] ([tip_nombre]) VALUES ('Seminario')
go

INSERT INTO [dbo].[TIPO_EVENTO] ([tip_nombre]) VALUES ('Entrenamiento Especial')
go

INSERT INTO [dbo].[TIPO_EVENTO] ([tip_nombre]) VALUES ('Clases Regulares')
go

-- INSERTS HORARIO --
INSERT INTO [dbo].[HORARIO] ([hor_fecha_inicio],[hor_fecha_fin],[hor_hora_inicio],[hor_hora_fin]) VALUES ('2015-10-15','2016-10-15',2,4) -- Clases -- 
go
INSERT INTO [dbo].[HORARIO] ([hor_fecha_inicio],[hor_fecha_fin],[hor_hora_inicio],[hor_hora_fin]) VALUES ('2015-12-15','2016-02-02',5,1) -- Seminario --
go
INSERT INTO [dbo].[HORARIO] ([hor_fecha_inicio],[hor_fecha_fin],[hor_hora_inicio],[hor_hora_fin]) VALUES ('2015-11-15','2015-11-15',1,3) -- Pase de Cita --  
go
INSERT INTO [dbo].[HORARIO] ([hor_fecha_inicio],[hor_fecha_fin],[hor_hora_inicio],[hor_hora_fin]) VALUES ('2016-01-15','2016-01-15',2,4) -- Clase Especial -- 
go
INSERT INTO [dbo].[HORARIO] ([hor_fecha_inicio],[hor_fecha_fin],[hor_hora_inicio],[hor_hora_fin]) VALUES ('2015-10-15','2016-10-15',3,6) -- Clases -- 
go

-- INSERTS EVENTO -- 

INSERT INTO [dbo].[EVENTO] ([eve_nombre],[eve_costo],[eve_descripcion],[eve_estado],[DOJO_doj_id],[CATEGORIA_cat_id],[HORARIO_hor_id],[TIPO_EVENTO_tip_id],[UBICACION_ubi_id]) VALUES ('Clase Regular',0,'Clases regulares del atleta que va los dias asignados',1,null,null,1,4,1)
go
INSERT INTO [dbo].[EVENTO] ([eve_nombre],[eve_costo],[eve_descripcion],[eve_estado],[DOJO_doj_id],[CATEGORIA_cat_id],[HORARIO_hor_id],[TIPO_EVENTO_tip_id],[UBICACION_ubi_id]) VALUES ('Entrenamiento 2',2000,'Entrenammiento para Competencia',1,null,null,4,3,2)
go
INSERT INTO [dbo].[EVENTO] ([eve_nombre],[eve_costo],[eve_descripcion],[eve_estado],[DOJO_doj_id],[CATEGORIA_cat_id],[HORARIO_hor_id],[TIPO_EVENTO_tip_id],[UBICACION_ubi_id]) VALUES ('Pase a negra',1150,'Pase de cinta de los atletas',1,null,null,3,1,1)
go
INSERT INTO [dbo].[EVENTO] ([eve_nombre],[eve_costo],[eve_descripcion],[eve_estado],[DOJO_doj_id],[CATEGORIA_cat_id],[HORARIO_hor_id],[TIPO_EVENTO_tip_id],[UBICACION_ubi_id]) VALUES ('La vida en el Dojo',1150,'Charla sobre los atletas en la vida real',1,null,null,2,2,1)
go
