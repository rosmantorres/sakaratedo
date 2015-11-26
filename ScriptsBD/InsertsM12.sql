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

-- INSERTS CATEGORIA --
INSERT INTO [dbo].[CATEGORIA] ([cat_edad_ini], [cat_edad_fin], [cat_cinta_ini], [cat_cinta_fin], [cat_sexo]) VALUES (10,15,'Blanca','Naranja','M')
go

INSERT INTO [dbo].[CATEGORIA] ([cat_edad_ini], [cat_edad_fin], [cat_cinta_ini], [cat_cinta_fin], [cat_sexo]) VALUES (10,15,'Blanca','Naranja','F')
go

INSERT INTO [dbo].[CATEGORIA] ([cat_edad_ini], [cat_edad_fin], [cat_cinta_ini], [cat_cinta_fin], [cat_sexo]) VALUES (10,15,'Azul Celeste','Purpura','M')
go

INSERT INTO [dbo].[CATEGORIA] ([cat_edad_ini], [cat_edad_fin], [cat_cinta_ini], [cat_cinta_fin], [cat_sexo]) VALUES (10,15,'Azul Celeste','Purpura','F')
go

INSERT INTO [dbo].[CATEGORIA] ([cat_edad_ini], [cat_edad_fin], [cat_cinta_ini], [cat_cinta_fin], [cat_sexo]) VALUES (10,15,'Naranja','Verde','M')
go

INSERT INTO [dbo].[CATEGORIA] ([cat_edad_ini], [cat_edad_fin], [cat_cinta_ini], [cat_cinta_fin], [cat_sexo]) VALUES (10,15,'Naranja','Verde','F')
go

INSERT INTO [dbo].[CATEGORIA] ([cat_edad_ini], [cat_edad_fin], [cat_cinta_ini], [cat_cinta_fin], [cat_sexo]) VALUES (10,15,'Amarilla','Purpura','M')
go

INSERT INTO [dbo].[CATEGORIA] ([cat_edad_ini], [cat_edad_fin], [cat_cinta_ini], [cat_cinta_fin], [cat_sexo]) VALUES (10,15,'Amarilla','Purpura','F')
go

INSERT INTO [dbo].[CATEGORIA] ([cat_edad_ini], [cat_edad_fin], [cat_cinta_ini], [cat_cinta_fin], [cat_sexo]) VALUES (10,15,'Azul Oscuro','Marron','M')
go

INSERT INTO [dbo].[CATEGORIA] ([cat_edad_ini], [cat_edad_fin], [cat_cinta_ini], [cat_cinta_fin], [cat_sexo]) VALUES (10,15,'Azul Oscuro','Marron','F')
go

--COMPETENCIA--

INSERT INTO [dbo].[COMPETENCIA] ( [comp_nombre], [comp_tipo], [comp_org_todas], [comp_status], [comp_fecha_ini], [comp_fecha_fin], [UBICACION_comp_id], [CATEGORIA_comp_id], [ORGANIZACION_comp_id], [comp_costo]) 
VALUES (N'Ryu Kobudo', 1, 1, N'Por Iniciar', N'2016-10-25 00:00:00', N'2016-10-27 00:00:00', 3, 4, NULL,1500)
go

INSERT INTO [dbo].[COMPETENCIA] ( [comp_nombre], [comp_tipo], [comp_org_todas], [comp_status], [comp_fecha_ini], [comp_fecha_fin], [UBICACION_comp_id], [CATEGORIA_comp_id], [ORGANIZACION_comp_id], [comp_costo]) 
VALUES (N'Kobudo', 2, 1, N'Por Iniciar', N'2016-09-01 00:00:00', N'2016-09-03 00:00:00', 1, 1, NULL,1100)
go
INSERT INTO [dbo].[COMPETENCIA] ( [comp_nombre], [comp_tipo], [comp_org_todas], [comp_status], [comp_fecha_ini], [comp_fecha_fin], [UBICACION_comp_id], [CATEGORIA_comp_id], [ORGANIZACION_comp_id], [comp_costo]) 
VALUES (N'Doo Kan', 2, 0, N'Por Iniciar', N'2016-10-15 00:00:00', N'2016-10-18 00:00:00', 1, 2, 1,900)
go
INSERT INTO [dbo].[COMPETENCIA] ( [comp_nombre], [comp_tipo], [comp_org_todas], [comp_status], [comp_fecha_ini], [comp_fecha_fin], [UBICACION_comp_id], [CATEGORIA_comp_id], [ORGANIZACION_comp_id], [comp_costo]) 
VALUES (N'Yodan Ryu', 1, 0, N'Por Iniciar', N'2016-05-20 00:00:00', N'2016-05-23 00:00:00', 2, 3, 1,1000)
go
INSERT INTO [dbo].[COMPETENCIA] ( [comp_nombre], [comp_tipo], [comp_org_todas], [comp_status], [comp_fecha_ini], [comp_fecha_fin], [UBICACION_comp_id], [CATEGORIA_comp_id], [ORGANIZACION_comp_id], [comp_costo]) 
VALUES (N'Shito Ryu', 1, 0, N'Por Iniciar', N'2016-06-20 00:00:00', N'2016-06-23 00:00:00', 2, 3, 2,900)
go
INSERT INTO [dbo].[COMPETENCIA] ( [comp_nombre], [comp_tipo], [comp_org_todas], [comp_status], [comp_fecha_ini], [comp_fecha_fin], [UBICACION_comp_id], [CATEGORIA_comp_id], [ORGANIZACION_comp_id], [comp_costo]) 
VALUES (N'Inoue Ha', 1, 0, N'Por Iniciar', N'2016-03-19 00:00:00', N'2016-05-21 00:00:00', 2, 3, 3,1200)
go
INSERT INTO [dbo].[COMPETENCIA] ( [comp_nombre], [comp_tipo], [comp_org_todas], [comp_status], [comp_fecha_ini], [comp_fecha_fin], [UBICACION_comp_id], [CATEGORIA_comp_id], [ORGANIZACION_comp_id], [comp_costo]) 
VALUES (N'Shoosei Kai', 1, 0, N'Por Iniciar', N'2016-01-10 00:00:00', N'2016-05-11 00:00:00', 2, 3, 4,1800)
go

