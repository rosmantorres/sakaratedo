
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


--INSERTS CINTAS--

INSERT INTO [dbo].[CINTA] ([cin_color_nombre], [cin_rango], [cin_clasificacion], [cin_significado], [cin_orden]) VALUES ('Blanco', '1er Kyu', 'Nivel inferior', 'Principiante', 1);

INSERT INTO [dbo].[CINTA] ([cin_color_nombre], [cin_rango], [cin_clasificacion], [cin_significado], [cin_orden]) VALUES ('Amarillo', '2do Kyu', 'Nivel inferior', 'Iniciado', 2);

INSERT INTO [dbo].[CINTA] ([cin_color_nombre], [cin_rango], [cin_clasificacion], [cin_significado], [cin_orden]) VALUES ('Naranja', '3er Kyu', 'Nivel inferior', 'Aprendiz', 3);

INSERT INTO [dbo].[CINTA] ([cin_color_nombre], [cin_rango], [cin_clasificacion], [cin_significado], [cin_orden]) VALUES ('Marron', '8vo Kyu', 'Nivel inferior', 'Aprendiz avanzado', 4);

INSERT INTO [dbo].[CINTA] ([cin_color_nombre], [cin_rango], [cin_clasificacion], [cin_significado], [cin_orden]) VALUES ('Negro', '1er Dan', 'Nivel superior', 'Avanzado', 1);

INSERT INTO [dbo].[CINTA] ([cin_color_nombre], [cin_rango], [cin_clasificacion], [cin_significado], [cin_orden]) VALUES ('Negro', '2do Dan', 'Nivel superior', 'Maestro iniciado', 2);

INSERT INTO [dbo].[CINTA] ([cin_color_nombre], [cin_rango], [cin_clasificacion], [cin_significado], [cin_orden]) VALUES ('Negro', '3er Kyu', 'Nivel superior', 'Maestro medio', 3);

INSERT INTO [dbo].[CINTA] ([cin_color_nombre], [cin_rango], [cin_clasificacion], [cin_significado], [cin_orden]) VALUES ('Negro', '4to Kyu', 'Nivel superior', 'Maestro superior', 4);

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

INSERT INTO [dbo].[UBICACION] ([ubi_latitud], [ubi_longitud], [ubi_ciudad], [ubi_estado], [ubi_direccion]) VALUES ('10.499607', '-66.788419', 'Caracas', 'Miranda', 'Quinta transversal chacaito, casa Karate Do') 
go

INSERT INTO [dbo].[UBICACION] ([ubi_latitud], [ubi_longitud], [ubi_ciudad], [ubi_estado], [ubi_direccion]) VALUES ('10.499607', '-66.788419', 'Caracas', 'Miranda', 'Altamira, dojo OldSensei') 
go

-- INSERTS ESTILO --

INSERT INTO ESTILO(est_nombre,est_descripcion) VALUES('Cobra-do','Fusión entre Karate-Do y Kung Fu. Fundado por el Maestro Jesús López. Caracas-Venezuela.');

INSERT INTO ESTILO(est_nombre,est_descripcion) VALUES('Sistema libre de Karate','Combinación entre fusión entre Karate-Do, Taekwondo, y Kung Fu. Fundado por los Maestros Francisco Delgado y Roland Casanova en los años 80 en la Universidad Central de Venezuela - Caracas.');

INSERT INTO ESTILO(est_nombre,est_descripcion) VALUES('Shotokan','con numerosas variantes siendo la más conocida, la JKA');



-- INSERTS ORGANIZACION --

INSERT INTO ORGANIZACION(org_nombre,org_direccion,org_telefono,org_email,org_estado,ESTILO_est_id) VALUES('Seito Karate-do','Av 24, calle 8 edificio Morales, Altamira, Caracas',2123117754,'seitokaratedo@gmail.com','Distrito Federal',1);

INSERT INTO ORGANIZACION(org_nombre,org_direccion,org_telefono,org_email,org_estado,ESTILO_est_id) VALUES('Clash Cobra-do','Av principal,  edificio Torrealba, Edo Falcon',2123118854,'clashcobrado@gmail.com','Falcon',1);

INSERT INTO ORGANIZACION(org_nombre,org_direccion,org_telefono,org_email,org_estado,ESTILO_est_id) VALUES('Shotokan Org','Av 8, calle 8 local numero 12',2123457754,'seseikaratedo@gmail.com','Carabobo',2);

INSERT INTO ORGANIZACION(org_nombre,org_direccion,org_telefono,org_email,org_estado,ESTILO_est_id) VALUES('Seito Karate','Av 21, calle 3 edificio , Altamira, Caracas',2123116854,'seitokarate@gmail.com','Distrito Federal',2);

INSERT INTO ORGANIZACION(org_nombre,org_direccion,org_telefono,org_email,org_estado,ESTILO_est_id) VALUES('Sempai Karate','Av 20, calle 8 Local numero 35',2123156754,'seitokaratedo@gmail.com','Guarico',3);

-- INSERTS ORGANIZACION CINTA--

INSERT INTO ORGANIZACION_CINTA(ORGANIZACION_org_id,CINTA_cin_id) VALUES(1,1);

INSERT INTO ORGANIZACION_CINTA(ORGANIZACION_org_id,CINTA_cin_id) VALUES(1,2);

INSERT INTO ORGANIZACION_CINTA(ORGANIZACION_org_id,CINTA_cin_id) VALUES(2,2);

INSERT INTO ORGANIZACION_CINTA(ORGANIZACION_org_id,CINTA_cin_id) VALUES(3,3);



-- INSERTS COMPETENCIA--

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
VALUES (N'Shito Ryu', 1, 0, N'Por Iniciar', N'2015-06-20 00:00:00', N'2015-06-20 00:00:00', 2, 3, 2,900)
go

INSERT INTO [dbo].[COMPETENCIA] ( [comp_nombre], [comp_tipo], [comp_org_todas], [comp_status], [comp_fecha_ini], [comp_fecha_fin], [UBICACION_comp_id], [CATEGORIA_comp_id], [ORGANIZACION_comp_id], [comp_costo]) 
VALUES (N'Inoue Ha', 2, 0, N'Por Iniciar', N'2015-03-19 00:00:00', N'2015-03-19 00:00:00', 2, 3, 3,1200)
go
INSERT INTO [dbo].[COMPETENCIA] ( [comp_nombre], [comp_tipo], [comp_org_todas], [comp_status], [comp_fecha_ini], [comp_fecha_fin], [UBICACION_comp_id], [CATEGORIA_comp_id], [ORGANIZACION_comp_id], [comp_costo]) 
VALUES (N'Shoosei Kai', 3, 0, N'Por Iniciar', N'2015-10-11 00:00:00', N'2015-10-11 00:00:00', 2, 3, 2,1800)
go

INSERT INTO [dbo].[COMPETENCIA] ( [comp_nombre], [comp_tipo], [comp_org_todas], [comp_status], [comp_fecha_ini], [comp_fecha_fin], [UBICACION_comp_id], [CATEGORIA_comp_id], [ORGANIZACION_comp_id], [comp_costo]) 
VALUES (N'Shoosei Kai', 1, 0, N'Finalizada', N'2014-05-10 00:00:00', N'2014-05-14 00:00:00', 2, 3, 2,1800)
go 

INSERT INTO [dbo].[COMPETENCIA] ( [comp_nombre], [comp_tipo], [comp_org_todas], [comp_status], [comp_fecha_ini], [comp_fecha_fin], [UBICACION_comp_id], [CATEGORIA_comp_id], [ORGANIZACION_comp_id], [comp_costo]) 
VALUES (N'Gashumi Io', 1, 0, N'Inscrita', N'2015-05-10 00:00:00', N'2015-05-14 00:00:00', 2, 3, 2,3000)
go 


--INSERTS RESTRICCION COMPETENCIA--
INSERT INTO [dbo].[RESTRICCION_COMPETENCIA] ([res_com_desc], [res_com_edad_min], [res_com_edad_max], [res_com_rango_min], [res_com_rango_max], [res_com_sexo], [res_com_modalidad]) VALUES
('Rest. Competencia de 12 a 17 años todas las cintas unisex Kata',12,17,1,20,'B','Todas');

INSERT INTO [dbo].[RESTRICCION_COMPETENCIA] ([res_com_desc], [res_com_edad_min], [res_com_edad_max], [res_com_rango_min], [res_com_rango_max], [res_com_sexo], [res_com_modalidad]) VALUES
('Rest. Competencia de 6 a 11 años todas las cintas unisex Kata',6,11,1,20,'B','kata');

INSERT INTO [dbo].[RESTRICCION_COMPETENCIA] ([res_com_desc], [res_com_edad_min], [res_com_edad_max], [res_com_rango_min], [res_com_rango_max], [res_com_sexo], [res_com_modalidad]) VALUES
('Rest. Competencia de 18 a 25 años todas las cintas unisex Kata',18,25,1,20,'B','Todas');


-- INSERTS COMP_REST_COMP--

INSERT INTO [dbo].[COMP_REST_COMP] ([RESTRICCION_COMPETENCIA_res_com_id], [COMPETENCIA_comp_id]) VALUES
(1,1);

INSERT INTO [dbo].[COMP_REST_COMP] ([RESTRICCION_COMPETENCIA_res_com_id], [COMPETENCIA_comp_id]) VALUES
(1,2);

INSERT INTO [dbo].[COMP_REST_COMP] ([RESTRICCION_COMPETENCIA_res_com_id], [COMPETENCIA_comp_id]) VALUES
(1,3);

INSERT INTO [dbo].[COMP_REST_COMP] ([RESTRICCION_COMPETENCIA_res_com_id], [COMPETENCIA_comp_id]) VALUES
(1,4);

INSERT INTO [dbo].[COMP_REST_COMP] ([RESTRICCION_COMPETENCIA_res_com_id], [COMPETENCIA_comp_id]) VALUES
(2,1);

INSERT INTO [dbo].[COMP_REST_COMP] ([RESTRICCION_COMPETENCIA_res_com_id], [COMPETENCIA_comp_id]) VALUES
(2,2);

-- INSERTS DOJO--

INSERT INTO DOJO (doj_rif,doj_nombre,doj_telefono,doj_email,doj__logo,doj_fecha_registro,doj_status,ORGANIZACION_org_id,UBICACION_ubi_id) VALUES ('J-17280493-1','bushido',02126314625,'bushido@gmail.com','bushido.jpg','2014-11-13',1,2,2)
go

INSERT INTO DOJO (doj_rif,doj_nombre,doj_telefono,doj_email,doj__logo,doj_fecha_registro,doj_status,ORGANIZACION_org_id,UBICACION_ubi_id) VALUES ('J-13224369-3','bushido567',02123456789,'bushido34@gmail.com','bushido.jpg','2014-11-13',0,2,1)
go

INSERT INTO DOJO (doj_rif,doj_nombre,doj_telefono,doj_email,doj__logo,doj_fecha_registro,doj_status,ORGANIZACION_org_id,UBICACION_ubi_id) VALUES ('J-15403240-9','Dai-Fu',02124563322,'Dai-Fu@gmail.com','Dai-Fu.jpg','2014-10-18',1,3,4)
go

INSERT INTO DOJO (doj_rif,doj_nombre,doj_telefono,doj_email,doj__logo,doj_fecha_registro,doj_status,ORGANIZACION_org_id,UBICACION_ubi_id) VALUES ('J-18493618-8','hokuto',02126789876,'hokuto@gmail.com','hokuto.jpg','2011-11-11',1,4,3)
go

INSERT INTO DOJO (doj_rif,doj_nombre,doj_telefono,doj_email,doj__logo,doj_fecha_registro,doj_status,ORGANIZACION_org_id,UBICACION_ubi_id) VALUES ('J-11013997-1','Kaizen',02124756638,'Kaizen@gmail.com','Kaizen.jpg','2010-11-12',0,5,1)
go

INSERT INTO DOJO (doj_rif,doj_nombre,doj_telefono,doj_email,doj__logo,doj_fecha_registro,doj_status,ORGANIZACION_org_id,UBICACION_ubi_id) VALUES ('J-15374218-7','kate',02125698732,'kate@gmail.com','bushido.jpg','2014-11-13',1,2,2)
go

INSERT INTO DOJO (doj_rif,doj_nombre,doj_telefono,doj_email,doj__logo,doj_fecha_registro,doj_status,ORGANIZACION_org_id,UBICACION_ubi_id) VALUES ('J-14709720-1','karate Zen',02123456654,'karateZen@gmail.com','bushido.jpg','2014-11-13',1,2,3)
go

INSERT INTO DOJO (doj_rif,doj_nombre,doj_telefono,doj_email,doj__logo,doj_fecha_registro,doj_status,ORGANIZACION_org_id,UBICACION_ubi_id) VALUES ('J-13525491-7','Dai-Fu Manuela',02122245679,'daifu_manuela@gmail.com','Dai-Fu.jpg','2014-10-18',1,3,1)
go

INSERT INTO DOJO (doj_rif,doj_nombre,doj_telefono,doj_email,doj__logo,doj_fecha_registro,doj_status,ORGANIZACION_org_id,UBICACION_ubi_id) VALUES ('J-14795873-0','hokuto Zen',02125752632,'hokutozen@gmail.com','hokuto.jpg','2011-11-11',0,4,2)
go


-- INSERTS HISTORIAL MATRICULA--


INSERT INTO HISTORIAL_MATRICULA (his_mat_fecha_vigente,his_mat_modalidad,his_mat_monto,DOJO_doj_id)
VALUES ('2015-10-19','mensual',1554,1);
INSERT INTO HISTORIAL_MATRICULA (his_mat_fecha_vigente,his_mat_modalidad,his_mat_monto,DOJO_doj_id)
VALUES ('2014-2-23','mensual',1500,1);
INSERT INTO HISTORIAL_MATRICULA (his_mat_fecha_vigente,his_mat_modalidad,his_mat_monto,DOJO_doj_id)
VALUES ('2012-11-17','semestral',1300,1);
INSERT INTO HISTORIAL_MATRICULA (his_mat_fecha_vigente,his_mat_modalidad,his_mat_monto,DOJO_doj_id)
VALUES ('2011-1-21','mensual',1290,1);
INSERT INTO HISTORIAL_MATRICULA (his_mat_fecha_vigente,his_mat_modalidad,his_mat_monto,DOJO_doj_id)
VALUES ('2010-07-18','Trimestral',1100,1);
INSERT INTO HISTORIAL_MATRICULA (his_mat_fecha_vigente,his_mat_modalidad,his_mat_monto,DOJO_doj_id)
VALUES ('2015-10-19','mensual',1754,2);
INSERT INTO HISTORIAL_MATRICULA (his_mat_fecha_vigente,his_mat_modalidad,his_mat_monto,DOJO_doj_id)
VALUES ('2011-04-23','mensual',1500,2);
INSERT INTO HISTORIAL_MATRICULA (his_mat_fecha_vigente,his_mat_modalidad,his_mat_monto,DOJO_doj_id)
VALUES ('2010-11-17','semestral',1340,2);
INSERT INTO HISTORIAL_MATRICULA (his_mat_fecha_vigente,his_mat_modalidad,his_mat_monto,DOJO_doj_id)
VALUES ('2009-01-21','mensual',1290,2);
INSERT INTO HISTORIAL_MATRICULA (his_mat_fecha_vigente,his_mat_modalidad,his_mat_monto,DOJO_doj_id)
VALUES ('2006-08-18','Trimestral',500,2);
INSERT INTO HISTORIAL_MATRICULA (his_mat_fecha_vigente,his_mat_modalidad,his_mat_monto,DOJO_doj_id)
VALUES ('2015-10-19','mensual',1700,3);
INSERT INTO HISTORIAL_MATRICULA (his_mat_fecha_vigente,his_mat_modalidad,his_mat_monto,DOJO_doj_id)
VALUES ('2014-03-23','mensual',1500,3);
INSERT INTO HISTORIAL_MATRICULA (his_mat_fecha_vigente,his_mat_modalidad,his_mat_monto,DOJO_doj_id)
VALUES ('2013-11-17','semestral',1350,3);
INSERT INTO HISTORIAL_MATRICULA (his_mat_fecha_vigente,his_mat_modalidad,his_mat_monto,DOJO_doj_id)
VALUES ('2011-05-21','mensual',1200,3);
INSERT INTO HISTORIAL_MATRICULA (his_mat_fecha_vigente,his_mat_modalidad,his_mat_monto,DOJO_doj_id)
VALUES ('2010-04-18','Trimestral',1150,3);
INSERT INTO HISTORIAL_MATRICULA (his_mat_fecha_vigente,his_mat_modalidad,his_mat_monto,DOJO_doj_id)
VALUES ('2015-10-19','mensual',1554,4);
INSERT INTO HISTORIAL_MATRICULA (his_mat_fecha_vigente,his_mat_modalidad,his_mat_monto,DOJO_doj_id)
VALUES ('2014-09-23','mensual',1500,4);
INSERT INTO HISTORIAL_MATRICULA (his_mat_fecha_vigente,his_mat_modalidad,his_mat_monto,DOJO_doj_id)
VALUES ('2012-11-17','semestral',1300,4);
INSERT INTO HISTORIAL_MATRICULA (his_mat_fecha_vigente,his_mat_modalidad,his_mat_monto,DOJO_doj_id)
VALUES ('2010-04-18','Trimestral',1100,4);
INSERT INTO HISTORIAL_MATRICULA (his_mat_fecha_vigente,his_mat_modalidad,his_mat_monto,DOJO_doj_id)
VALUES ('2015-10-19','mensual',1754,5);
INSERT INTO HISTORIAL_MATRICULA (his_mat_fecha_vigente,his_mat_modalidad,his_mat_monto,DOJO_doj_id)
VALUES ('2011-12-23','mensual',1500,5);
INSERT INTO HISTORIAL_MATRICULA (his_mat_fecha_vigente,his_mat_modalidad,his_mat_monto,DOJO_doj_id)
VALUES ('2010-08-17','semestral',1340,5);
INSERT INTO HISTORIAL_MATRICULA (his_mat_fecha_vigente,his_mat_modalidad,his_mat_monto,DOJO_doj_id)
VALUES ('2009-12-21','mensual',1290,5);
INSERT INTO HISTORIAL_MATRICULA (his_mat_fecha_vigente,his_mat_modalidad,his_mat_monto,DOJO_doj_id)
VALUES ('2006-10-18','Trimestral',500,5);
INSERT INTO HISTORIAL_MATRICULA (his_mat_fecha_vigente,his_mat_modalidad,his_mat_monto,DOJO_doj_id)
VALUES ('2013-11-17','semestral',1350,6);
INSERT INTO HISTORIAL_MATRICULA (his_mat_fecha_vigente,his_mat_modalidad,his_mat_monto,DOJO_doj_id)
VALUES ('2011-06-21','mensual',1200,6);
INSERT INTO HISTORIAL_MATRICULA (his_mat_fecha_vigente,his_mat_modalidad,his_mat_monto,DOJO_doj_id)
VALUES ('2010-10-18','Trimestral',1150,6);


--INSERTS REGLAMENTO--







-- INSERTS DATO-- 

INSERT INTO DATO (dat_nombre,dat_abreviatura) values ('PERSONA','PER');
INSERT INTO DATO (dat_nombre,dat_abreviatura) values ('COMPETENCIA','COM');
INSERT INTO DATO (dat_nombre,dat_abreviatura) values ('DOJO','DOJ');
INSERT INTO DATO (dat_nombre,dat_abreviatura) values ('EVENTO','EVE');
INSERT INTO DATO (dat_nombre,dat_abreviatura) values ('ORGANIZACION','ORG');
INSERT INTO DATO (dat_nombre,dat_abreviatura) values ('MATRICULA','MAT');


-- INSERTS TIPO PLANILLA --

INSERT INTO TIPO_PLANILLA (tip_nombre,tip_descripcion) values ('RETIRO','Este tipo de planilla se puede solicitar cuando se hacen retiros por compentencias');
INSERT INTO TIPO_PLANILLA (tip_nombre,tip_descripcion) values ('AUSENCIA','Este tipo de planilla se puede solicitar cuando se hacen ausencias temporales,prolongados, por campeonato y entrenamiento');
INSERT INTO TIPO_PLANILLA (tip_nombre,tip_descripcion) values ('ASISTENCIA','Este tipo de planilla se puede solicitar cuando se va a faltar a una competencia');
INSERT INTO TIPO_PLANILLA (tip_nombre,tip_descripcion) values ('PARTICIPACION','Este tipo de planilla se puede solicitar cuando se requiere de participacion en arbitraje');
INSERT INTO TIPO_PLANILLA (tip_nombre,tip_descripcion) values ('ESPECIAL','Este tipo de planilla se puede solicitar cuando requiere otros permisos especiales');

-- INSERTS PLANILLA --

INSERT INTO PLANILLA (pla_nombre,pla_status,TIPO_PLANILLA_tip_id) values ('RETIRO COMPETENCIA',1,1);
INSERT INTO PLANILLA (pla_nombre,pla_status,TIPO_PLANILLA_tip_id) values ('AUSENCIA TEMPORAL',1,2);
INSERT INTO PLANILLA (pla_nombre,pla_status,TIPO_PLANILLA_tip_id) values ('RETIRO PROLONGADO',0,2);
INSERT INTO PLANILLA (pla_nombre,pla_status,TIPO_PLANILLA_tip_id) values ('RETIRO CAMPEONATO',0,2);
INSERT INTO PLANILLA (pla_nombre,pla_status,TIPO_PLANILLA_tip_id) values ('RETIRO ENTRENAMIENTO',1,2);
INSERT INTO PLANILLA (pla_nombre,pla_status,TIPO_PLANILLA_tip_id) values ('ASISTENCIA COMPETENCIA',1,3);
INSERT INTO PLANILLA (pla_nombre,pla_status,TIPO_PLANILLA_tip_id) values ('PAGO INSCRIPCION',1,4);
INSERT INTO PLANILLA (pla_nombre,pla_status,TIPO_PLANILLA_tip_id) values ('PARTICIPACION',0,4);




-- INSERTS DISEÑO --
INSERT INTO DISEÑO (dis_contenido,PLANILLA_pla_id) values ('PHA+Jm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgPHN0cm9uZz4mbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwO1BsYW5pbGxhIGRlIEluc2NyaXBjaSZvYWN1dGU7bjwvc3Ryb25nPjwvcD4NCg0KPHA+Jm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICRwZXJfaW1hZ2VuPC9wPg0KDQo8cD4mbmJzcDs8L3A+DQoNCjx0YWJsZSBib3JkZXI9IjEiIGNlbGxwYWRkaW5nPSIxIiBjZWxsc3BhY2luZz0iMSIgc3R5bGU9IndpZHRoOjcwMHB4Ij4NCgk8Y2FwdGlvbj48c3Ryb25nPkRhdG9zIFBlcnNvbmFsZXM8L3N0cm9uZz48L2NhcHRpb24+DQoJPHRib2R5Pg0KCQk8dHI+DQoJCQk8dGQ+PHN0cm9uZz5Ob21icmU8L3N0cm9uZz48L3RkPg0KCQkJPHRkPiRwZXJfbm9tYnJlPC90ZD4NCgkJCTx0ZD48c3Ryb25nPkFwZWxsaWRvPC9zdHJvbmc+PC90ZD4NCgkJCTx0ZD4kcGVyX2FwZWxsaWRvPC90ZD4NCgkJPC90cj4NCgkJPHRyPg0KCQkJPHRkPjxzdHJvbmc+VGlwbyBkZSBEb2N1bWVudG88L3N0cm9uZz48L3RkPg0KCQkJPHRkPiRwZXJfdGlwb19kb2NfaWQ8L3RkPg0KCQkJPHRkPjxzdHJvbmc+RG9jdW1lbnRvIElkZW50aWRhZDwvc3Ryb25nPjwvdGQ+DQoJCQk8dGQ+JHBlcl9udW1fZG9jX2lkPC90ZD4NCgkJPC90cj4NCgkJPHRyPg0KCQkJPHRkPjxzdHJvbmc+TmFjaW9uYWxpZGFkPC9zdHJvbmc+PC90ZD4NCgkJCTx0ZD4kcGVyX25hY2lvbmFsaWRhZDwvdGQ+DQoJCQk8dGQ+PHN0cm9uZz5EaXJlY2NpJm9hY3V0ZTtuPC9zdHJvbmc+PC90ZD4NCgkJCTx0ZD4kcGVyX2RpcmVjY2lvbjwvdGQ+DQoJCTwvdHI+DQoJCTx0cj4NCgkJCTx0ZD48c3Ryb25nPlNleG88L3N0cm9uZz48L3RkPg0KCQkJPHRkPiRwZXJfc2V4bzwvdGQ+DQoJCQk8dGQ+PHN0cm9uZz5GZWNoYSBkZSBOYWNpbWllbnRvPC9zdHJvbmc+PC90ZD4NCgkJCTx0ZD4kcGVyX2ZlY2hhX25hY2ltaWVudG88L3RkPg0KCQk8L3RyPg0KCTwvdGJvZHk+DQo8L3RhYmxlPg0KDQo8dGFibGUgYm9yZGVyPSIxIiBjZWxscGFkZGluZz0iMSIgY2VsbHNwYWNpbmc9IjEiIHN0eWxlPSJ3aWR0aDo3MDBweCI+DQoJPGNhcHRpb24+DQoJPHA+Jm5ic3A7PC9wPg0KDQoJPHA+PHN0cm9uZz5EYXRvcyBkZWwgRG9qbzwvc3Ryb25nPjwvcD4NCgk8L2NhcHRpb24+DQoJPHRib2R5Pg0KCQk8dHI+DQoJCQk8dGQ+PHN0cm9uZz5Ob21icmU8L3N0cm9uZz48L3RkPg0KCQkJPHRkPiRkb2pfbm9tYnJlPC90ZD4NCgkJCTx0ZD48c3Ryb25nPlRlbCZlYWN1dGU7Zm9ubzwvc3Ryb25nPjwvdGQ+DQoJCQk8dGQ+JGRval90ZWxlZm9ubzwvdGQ+DQoJCTwvdHI+DQoJCTx0cj4NCgkJCTx0ZD48c3Ryb25nPlJpZjwvc3Ryb25nPjwvdGQ+DQoJCQk8dGQ+JGRval9yaWY8L3RkPg0KCQkJPHRkPjxzdHJvbmc+RW1haWw8L3N0cm9uZz48L3RkPg0KCQkJPHRkPiRkb2pfZW1haWw8L3RkPg0KCQk8L3RyPg0KCTwvdGJvZHk+DQo8L3RhYmxlPg0KDQo8cD4mbmJzcDs8L3A+DQo=',4);


-- INSERTS HORARIO-- 

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
INSERT INTO [dbo].[HORARIO] ([hor_fecha_inicio],[hor_fecha_fin],[hor_hora_inicio],[hor_hora_fin]) VALUES ('2015-03-10','2015-03-10',15,18)
go
INSERT INTO [dbo].[HORARIO] ([hor_fecha_inicio],[hor_fecha_fin],[hor_hora_inicio],[hor_hora_fin]) VALUES ('2015-04-15','2016-04-15',1,3)  
go
INSERT INTO [dbo].[HORARIO] ([hor_fecha_inicio],[hor_fecha_fin],[hor_hora_inicio],[hor_hora_fin]) VALUES ('2015-07-22','2016-07-22',18,20)  
go
INSERT INTO [dbo].[HORARIO] ([hor_fecha_inicio],[hor_fecha_fin],[hor_hora_inicio],[hor_hora_fin]) VALUES ('2015-08-03','2016-08-03',13,18) 
go
INSERT INTO [dbo].[HORARIO] ([hor_fecha_inicio],[hor_fecha_fin],[hor_hora_inicio],[hor_hora_fin]) VALUES ('2015-10-15','2016-10-17',10,18) 
go
INSERT INTO [dbo].[HORARIO] ([hor_fecha_inicio],[hor_fecha_fin],[hor_hora_inicio],[hor_hora_fin]) VALUES ('2015-10-15','2016-10-15',2,4)  
go
INSERT INTO [dbo].[HORARIO] ([hor_fecha_inicio],[hor_fecha_fin],[hor_hora_inicio],[hor_hora_fin]) VALUES ('2015-10-16','2016-10-16',4,6) 
go
INSERT INTO [dbo].[HORARIO] ([hor_fecha_inicio],[hor_fecha_fin],[hor_hora_inicio],[hor_hora_fin]) VALUES ('2015-10-17','2016-10-17',3,5)  
go
INSERT INTO [dbo].[HORARIO] ([hor_fecha_inicio],[hor_fecha_fin],[hor_hora_inicio],[hor_hora_fin]) VALUES ('2016-01-15','2016-01-18',5,1) 
go
INSERT INTO [dbo].[HORARIO] ([hor_fecha_inicio],[hor_fecha_fin],[hor_hora_inicio],[hor_hora_fin]) VALUES ('2016-02-15','2016-02-15',1,3)  
go
INSERT INTO [dbo].[HORARIO] ([hor_fecha_inicio],[hor_fecha_fin],[hor_hora_inicio],[hor_hora_fin]) VALUES ('2016-01-11','2016-01-12',2,4) 




-- INSERTS TIPO EVENTO--

INSERT INTO [dbo].[TIPO_EVENTO] ([tip_nombre]) VALUES ('Pase de Cinta')
go

INSERT INTO [dbo].[TIPO_EVENTO] ([tip_nombre]) VALUES ('Seminario')
go

INSERT INTO [dbo].[TIPO_EVENTO] ([tip_nombre]) VALUES ('Entrenamiento Especial')
go

INSERT INTO [dbo].[TIPO_EVENTO] ([tip_nombre]) VALUES ('Clases Regulares')
go

-- INSERTS EVENTO--

INSERT INTO [dbo].[EVENTO] ([eve_nombre],[eve_costo],[eve_descripcion],[eve_estado],[DOJO_doj_id],[CATEGORIA_cat_id],[HORARIO_hor_id],[TIPO_EVENTO_tip_id],[UBICACION_ubi_id]) VALUES ('Clase Regular',0,'Clases regulares del atleta que va los dias asignados',1,null,2,1,4,1)
go
INSERT INTO [dbo].[EVENTO] ([eve_nombre],[eve_costo],[eve_descripcion],[eve_estado],[DOJO_doj_id],[CATEGORIA_cat_id],[HORARIO_hor_id],[TIPO_EVENTO_tip_id],[UBICACION_ubi_id]) VALUES ('Entrenamiento 2',2000,'Entrenammiento para Competencia',1,null,3,4,3,2)
go
INSERT INTO [dbo].[EVENTO] ([eve_nombre],[eve_costo],[eve_descripcion],[eve_estado],[DOJO_doj_id],[CATEGORIA_cat_id],[HORARIO_hor_id],[TIPO_EVENTO_tip_id],[UBICACION_ubi_id]) VALUES ('Pase a negra',1150,'Pase de cinta de los atletas',1,null,4,3,1,1)
go
INSERT INTO [dbo].[EVENTO] ([eve_nombre],[eve_costo],[eve_descripcion],[eve_estado],[DOJO_doj_id],[CATEGORIA_cat_id],[HORARIO_hor_id],[TIPO_EVENTO_tip_id],[UBICACION_ubi_id]) VALUES ('La vida en el Dojo',1150,'Charla sobre los atletas en la vida real',1,null,5,2,2,1)
go
INSERT INTO [dbo].[EVENTO] ([eve_nombre],[eve_costo],[eve_descripcion],[eve_estado],[DOJO_doj_id],[CATEGORIA_cat_id],[HORARIO_hor_id],[TIPO_EVENTO_tip_id],[UBICACION_ubi_id]) VALUES ('La vida en el Dojo',1150,'Charla sobre los atletas en la vida real',1,1,2,6,2,6)
go
INSERT INTO [dbo].[EVENTO] ([eve_nombre],[eve_costo],[eve_descripcion],[eve_estado],[DOJO_doj_id],[CATEGORIA_cat_id],[HORARIO_hor_id],[TIPO_EVENTO_tip_id],[UBICACION_ubi_id]) VALUES ('Clase Regular',520,'Clase para cualquier nivel de cinta',1,1,1,7,4,7) 
go
INSERT INTO [dbo].[EVENTO] ([eve_nombre],[eve_costo],[eve_descripcion],[eve_estado],[DOJO_doj_id],[CATEGORIA_cat_id],[HORARIO_hor_id],[TIPO_EVENTO_tip_id],[UBICACION_ubi_id]) VALUES ('Entrenamiento Especial',740,'Entrenamiento dedicado a perfeccionar las patadas',1,1,4,8,3,7) 
go
INSERT INTO [dbo].[EVENTO] ([eve_nombre],[eve_costo],[eve_descripcion],[eve_estado],[DOJO_doj_id],[CATEGORIA_cat_id],[HORARIO_hor_id],[TIPO_EVENTO_tip_id],[UBICACION_ubi_id]) VALUES ('El Bushido',450,'Charla explicativa sobre el codigo Bushido',1,1,5,9,2,6) 
go
INSERT INTO [dbo].[EVENTO] ([eve_nombre],[eve_costo],[eve_descripcion],[eve_estado],[DOJO_doj_id],[CATEGORIA_cat_id],[HORARIO_hor_id],[TIPO_EVENTO_tip_id],[UBICACION_ubi_id]) VALUES ('Congreso sobre el Karate Do',2500,'Tercer Congreso para hablar sobre el Karate Do',1,1,null,10,2,6) 
go
INSERT INTO [dbo].[EVENTO] ([eve_nombre],[eve_costo],[eve_descripcion],[eve_estado],[DOJO_doj_id],[CATEGORIA_cat_id],[HORARIO_hor_id],[TIPO_EVENTO_tip_id],[UBICACION_ubi_id]) VALUES ('Clase Regular',0,'Clases regulares del atleta que va los dias asignados',1,1,null,11,4,6) 
go
INSERT INTO [dbo].[EVENTO] ([eve_nombre],[eve_costo],[eve_descripcion],[eve_estado],[DOJO_doj_id],[CATEGORIA_cat_id],[HORARIO_hor_id],[TIPO_EVENTO_tip_id],[UBICACION_ubi_id]) VALUES ('Clase Regular',0,'Clases regulares del atleta que va los dias asignados',1,1,null,12,4,6) 
go
INSERT INTO [dbo].[EVENTO] ([eve_nombre],[eve_costo],[eve_descripcion],[eve_estado],[DOJO_doj_id],[CATEGORIA_cat_id],[HORARIO_hor_id],[TIPO_EVENTO_tip_id],[UBICACION_ubi_id]) VALUES ('Clase Regular',0,'Clases regulares del atleta que va los dias asignados',1,1,null,13,4,6) 
go
INSERT INTO [dbo].[EVENTO] ([eve_nombre],[eve_costo],[eve_descripcion],[eve_estado],[DOJO_doj_id],[CATEGORIA_cat_id],[HORARIO_hor_id],[TIPO_EVENTO_tip_id],[UBICACION_ubi_id]) VALUES ('Entrenamiento Especial',1000,'Entrenamiento para Competencia',1,1,null,16,3,7)
go
INSERT INTO [dbo].[EVENTO] ([eve_nombre],[eve_costo],[eve_descripcion],[eve_estado],[DOJO_doj_id],[CATEGORIA_cat_id],[HORARIO_hor_id],[TIPO_EVENTO_tip_id],[UBICACION_ubi_id]) VALUES ('Karate Deporte o Defensa Personal',3000,'Charla para los atletas, el karate como forma de defensa',1,1,null,14,2,7)
go
INSERT INTO [dbo].[EVENTO] ([eve_nombre],[eve_costo],[eve_descripcion],[eve_estado],[DOJO_doj_id],[CATEGORIA_cat_id],[HORARIO_hor_id],[TIPO_EVENTO_tip_id],[UBICACION_ubi_id]) VALUES ('Pse de Cinta',1300,'Pase de cinta de los atletas',1,1,null,15,1,6)
go



-- INSERTS PERSONA, TELEFONO, EMAIL, SOLICITUD INSCRIPCION, MATRICULA -- 
/*
INSERTS M6

Los inserts de personas dependen de que los de Dojo hayan sido realizados.

Para traer los IDs de personas INSCRITAS en DOJOS usar alguna de  las siguientes expresiones:
--ADMINISTRADORES--
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Alexander Abraham')
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Freddy Jose')
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Javier Porfirio')


--ATLETAS--
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Carlos Alberto'),
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Miguel Alejandro')
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Eduardo')
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Maria Isabel')
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Mario Alejandro')
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Romulo Jose')
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Silfredo Augusto')
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Saul Enrique')
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Guillermo Daniel')
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Pedro Leonardo')
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Jose Miguel')
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Maria Antonieta')
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Victoria Isabella')
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Melissa Nathalie')
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Elizabeth Antonia')
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Marco Alejandro')
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Jose Gregorio')
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Luis Armando')
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Federico Ernesto')
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Liu Wa')
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Marta Carolina')
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Patricia Elena')
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Neolida Margarita')
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Nora Margarita')
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Sabrina')
*/

INSERT INTO dbo.PERSONA (
    per_tipo_doc_id,
    per_num_doc_id,
    per_nombre,
    per_apellido ,
    per_nacionalidad,
    per_alergias,
    per_direccion,
    per_sexo,
    per_tipo_sangre,
    per_fecha_nacimiento,
    per_activo,
    per_peso,
    per_estatura,
    per_nombre_usuario,
    per_clave,
    per_imagen,
    DOJO_doj_id
) 
VALUES (
    'CEDULA-N',
    21424696,
    'Miguel Alejandro',
    'Ruiz Campos',
    'Venezolano',
    'Mariscos',
    '2da. Av. de Montalban. Res. Capricornio. Piso 5. Apto. 10',
    'M',
    'A+',
    '2002-05-21',
    1,
    77,
    1.72,
    'miguedro',
    '12345',
    'http://www.morganstanley.com/assets/images/people/tiles/michael-asmar.jpg',
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3')
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Miguel Alejandro'),
    '02124423694'
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Miguel Alejandro'),
    '04124456790'
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Miguel Alejandro'),
    'miguel.alejandro@ucab.edu.ve',
    1
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Miguel Alejandro'),
    'miguel.alejandro@gmail.com',
    0
);

INSERT INTO dbo.SOLICITUD_INSCRIPCION (
    PERSONA_per_id,
    DOJO_doj_id,
    sol_inc_fecha_creacion,
    sol_inc_fecha_actualizacion,
    sol_inc_estado
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Miguel Alejandro'),
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3'),
    GETDATE(),
    GETDATE(),
    'ACEPTADO'
);

INSERT INTO dbo.MATRICULA (
    mat_identificador,
    mat_fecha_creacion,
    mat_activa,
    mat_fecha_ultimo_pago,
    mat_precio,
    PERSONA_per_id,
    DOJO_doj_id
) 
VALUES (
    'CAF-CAF-CAFE',
    GETDATE(),
    1,
    GETDATE(),
    5000,
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Miguel Alejandro'),
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3')
);

INSERT INTO dbo.PERSONA (
    per_tipo_doc_id,
    per_num_doc_id,
    per_nombre,
    per_apellido ,
    per_nacionalidad,
    per_alergias,
    per_direccion,
    per_sexo,
    per_tipo_sangre,
    per_fecha_nacimiento,
    per_activo,
    per_peso,
    per_estatura,
    per_nombre_usuario,
    per_clave,
    per_imagen,
    DOJO_doj_id
) 
VALUES (
    'CEDULA-N',
    14020474,
    'Adriana Josefina',
    'Lopez Sojo',
    'Venezolana',
    'Lacteos',
    '3ra. Transversal de Los Palos Grandes. Res. Guarani. Piso 3. Apto. 3-A',
    'F',
    'O-',
    '2001-11-15',
    1,
    63,
    1.60,
    'adrijo',
    '12345',
    'http://tphsartjdoerrer.weebly.com/uploads/7/7/0/2/7702116/152821360.jpg',
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-15403240-9')
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Adriana Josefina'),
    '02129876543'
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Adriana Josefina'),
    '04142357490'
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Adriana Josefina'),
    'adriana.josefina@ucab.edu.ve',
    1
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Adriana Josefina'),
    'petronila47@gmail.com',
    0
);

INSERT INTO dbo.SOLICITUD_INSCRIPCION (
    PERSONA_per_id,
    DOJO_doj_id,
    sol_inc_fecha_creacion,
    sol_inc_fecha_actualizacion,
    sol_inc_estado
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Adriana Josefina'), 
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-15403240-9'),   
    GETDATE(),
    GETDATE(),
    'RECHAZADO'
);

INSERT INTO dbo.PERSONA (
    per_tipo_doc_id,
    per_num_doc_id,
    per_nombre,
    per_apellido ,
    per_nacionalidad,
    per_alergias,
    per_direccion,
    per_sexo,
    per_tipo_sangre,
    per_fecha_nacimiento,
    per_activo,
    per_peso,
    per_estatura,
    per_nombre_usuario,
    per_clave,
    per_imagen,
    DOJO_doj_id
) 
VALUES (
    'CEDULA-E',
    3253777,
    'Christian Jose',
    'Suarez Arraiz',
    'Colombiano',
    'Gluten',
    'Calle Montserrat de Carapita. Quinta Los Reales.',
    'M',
    'B+',
    '2001-08-31',
    0,
    83,
    1.84,
    'chrisjo',
    '12345',
    'http://www.morganstanley.com/assets/images/people/tiles/michael-asmar.jpg',
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3')
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Christian Jose'),
    '02129873278'
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Christian Jose'),
    '04148761209'
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Christian Jose'),
    'christian.jose@ucab.edu.ve',
    1
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Christian Jose'),
    'chiguire58@gmail.com',
    0
);

INSERT INTO dbo.SOLICITUD_INSCRIPCION (
    PERSONA_per_id,
    DOJO_doj_id,
    sol_inc_fecha_creacion,
    sol_inc_fecha_actualizacion,
    sol_inc_estado
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Christian Jose'),    
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3'),
    GETDATE(),
    GETDATE(),
    'PENDIENTE'
);

INSERT INTO dbo.PERSONA (
    per_tipo_doc_id,
    per_num_doc_id,
    per_nombre,
    per_apellido ,
    per_nacionalidad,
    per_alergias,
    per_direccion,
    per_sexo,
    per_tipo_sangre,
    per_fecha_nacimiento,
    per_activo,
    per_peso,
    per_estatura,
    per_nombre_usuario,
    per_clave,
    per_imagen,
    DOJO_doj_id
) 
VALUES (
    'CEDULA-N',
    20532517,
    'Cesar Augusto',
    'Rodriguez Torres',
    'Venezolano',
    'Penicilina',
    'Calle principal de Santa Paula. Res. Caroni. Piso 12. PH-B',
    'M',
    'AB-',
    '2000-02-27',
    1,
    74,
    1.75,
    'cesarau',
    '12345',
    'http://www.one2onephotography.ca/image/portrait/men/men-images-1.jpg',
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3')
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Cesar Augusto'),
    '02123764504'
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Cesar Augusto'),
    '04143389564'
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Cesar Augusto'),
    'cesar.augusto@ucab.edu.ve',
    1
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Cesar Augusto'),
    'cesarag93@gmail.com',
    0
);

INSERT INTO dbo.SOLICITUD_INSCRIPCION (
    PERSONA_per_id,
    DOJO_doj_id,
    sol_inc_fecha_creacion,
    sol_inc_fecha_actualizacion,
    sol_inc_estado
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Cesar Augusto'),  
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3'),  
    GETDATE(),
    GETDATE(),
    'PENDIENTE'
);

INSERT INTO dbo.PERSONA (
    per_tipo_doc_id,
    per_num_doc_id,
    per_nombre,
    per_apellido ,
    per_nacionalidad,
    per_alergias,
    per_direccion,
    per_sexo,
    per_tipo_sangre,
    per_fecha_nacimiento,
    per_activo,
    per_peso,
    per_estatura,
    per_nombre_usuario,
    per_clave,
    per_imagen,
    DOJO_doj_id
) 
VALUES (
    'CEDULA-N',
    4818349,
    'Eduardo',
    'Sanchez Quintero',
    'Venezolano',
    'Coco',
    '2da. Avenida de La Lagunita. Quinta Los Querubines.',
    'M',
    'O-',
    '2002-03-05',
    1,
    88,
    1.78,
    'eduardo',
    '12345',
    'https://upload.wikimedia.org/wikipedia/en/2/28/Deep_Fried_Man_portrait_-_real_name_Daniel_Friedman_-_South_African_Comedian.jpg',
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3')
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Eduardo'),
    '02128740976'
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Eduardo'),
    '04142341765'
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Eduardo'),
    'eduardo@ucab.edu.ve',
    1
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Eduardo'),
    'edusanquin@gmail.com',
    0
);

INSERT INTO dbo.SOLICITUD_INSCRIPCION (
    PERSONA_per_id,
    DOJO_doj_id,
    sol_inc_fecha_creacion,
    sol_inc_fecha_actualizacion,
    sol_inc_estado
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Eduardo'),    
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3'),
    GETDATE(),
    GETDATE(),
    'ACEPTADO'
);

INSERT INTO dbo.MATRICULA (
    mat_identificador,
    mat_fecha_creacion,
    mat_activa,
    mat_fecha_ultimo_pago,
    mat_precio,
    PERSONA_per_id,
    DOJO_doj_id
) 
VALUES (
    '32-FE-A1',
    GETDATE(),
    1,
    GETDATE(),
     4500,
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Eduardo'),
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3')
);
INSERT INTO dbo.PERSONA (
    per_tipo_doc_id,
    per_num_doc_id,
    per_nombre,
    per_apellido ,
    per_nacionalidad,
    per_alergias,
    per_direccion,
    per_sexo,
    per_tipo_sangre,
    per_fecha_nacimiento,
    per_activo,
    per_peso,
    per_estatura,
    per_nombre_usuario,
    per_clave,
    per_imagen,
    DOJO_doj_id
) 
VALUES (
    'CEDULA-N',
    23456834,
    'Maria Isabel',
    'Sanchez Quintero',
    'Venezolano',
    'Coco',
    '2da. Avenida de La Lagunita. Quinta Los Querubines.',
    'M',
    'O-',
    '2000-03-05',
    1,
    88,
    1.78,
    'mariaisa',
    '12345',
    'http://guildfordphotographer.co.uk/wp-content/uploads/2011/01/lucy.jpg',
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-15403240-9')
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Maria Isabel'),
    '02128740976'
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Maria Isabel'),
    '04142341765'
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Maria Isabel'),
    'maria.isabel@ucab.edu.ve',
    1
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Maria Isabel'),
    'mariitabel@gmail.com',
    0
);

INSERT INTO dbo.SOLICITUD_INSCRIPCION (
    PERSONA_per_id,
    DOJO_doj_id,
    sol_inc_fecha_creacion,
    sol_inc_fecha_actualizacion,
    sol_inc_estado
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Maria Isabel'),    
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-15403240-9'),
    GETDATE(),
    GETDATE(),
    'ACEPTADO'
);

INSERT INTO dbo.MATRICULA (
    mat_identificador,
    mat_fecha_creacion,
    mat_activa,
    mat_fecha_ultimo_pago,
    mat_precio,
    PERSONA_per_id,
    DOJO_doj_id
) 
VALUES (
    'CEFA-FE-A65',
    GETDATE(),
    1,
    GETDATE(),
    2000,
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Maria Isabel'),
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-17280493-1')
);

INSERT INTO dbo.PERSONA (
    per_tipo_doc_id,
    per_num_doc_id,
    per_nombre,
    per_apellido ,
    per_nacionalidad,
    per_alergias,
    per_direccion,
    per_sexo,
    per_tipo_sangre,
    per_fecha_nacimiento,
    per_activo,
    per_peso,
    per_estatura,
    per_nombre_usuario,
    per_clave,
    per_imagen,
    DOJO_doj_id
) 
VALUES (
    'CEDULA-N',
    23456834,
    'Carlos Alberto',
    'Perez Pirela',
    'Venezolano',
    'Coco',
    '2da. Avenida de La Lagunita. Quinta Los Querubines.',
    'F',
    'O-',
    '2001-03-05',
    1,
    88,
    1.78,
    'carlosal',
    '12345',
    'https://c.stocksy.com/a/3iJ000/z0/75767.jpg',
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-17280493-1')
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Carlos Alberto'),
    '02128740976'
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Carlos Alberto'),
    '04142341765'
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Carlos Alberto'),
    'carlos.alberto@ucab.edu.ve',
    1
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Carlos Alberto'),
    'albertico1115@gmail.com',
    0
);

INSERT INTO dbo.SOLICITUD_INSCRIPCION (
    PERSONA_per_id,
    DOJO_doj_id,
    sol_inc_fecha_creacion,
    sol_inc_fecha_actualizacion,
    sol_inc_estado
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Carlos Alberto'),    
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-17280493-1'),
    GETDATE(),
    GETDATE(),
    'RECHAZADO'
);

INSERT INTO dbo.PERSONA (
    per_tipo_doc_id,
    per_num_doc_id,
    per_nombre,
    per_apellido ,
    per_nacionalidad,
    per_alergias,
    per_direccion,
    per_sexo,
    per_tipo_sangre,
    per_fecha_nacimiento,
    per_activo,
    per_peso,
    per_estatura,
    per_nombre_usuario,
    per_clave,
    per_imagen,
    DOJO_doj_id
) 
VALUES (
    'CEDULA-N',
    23456834,
    'Jesus Enrique',
    'Gutierrez Escobar',
    'Venezolano',
    'Coco',
    '2da. Avenida de La Lagunita. Quinta Los Querubines.',
    'M',
    'O-',
    '2001-03-05',
    1,
    88,
    1.78,
    'jesusen',
    '12345',
    'http://www.offshoresailing.com/wp-content/uploads/2013/05/photodune-658305-portrait-of-a-good-looking-african-american-business-man-s7-300x247.png',
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-17280493-1')
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Jesus Enrique'),
    '02128740976'
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Jesus Enrique'),
    '04142341765'
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Jesus Enrique'),
    'jesus.enrique@ucab.edu.ve',
    1
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Jesus Enrique'),
    'chuoito3334@gmail.com',
    0
);

INSERT INTO dbo.SOLICITUD_INSCRIPCION (
    PERSONA_per_id,
    DOJO_doj_id,
    sol_inc_fecha_creacion,
    sol_inc_fecha_actualizacion,
    sol_inc_estado
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Jesus Enrique'),    
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-17280493-1'),
    GETDATE(),
    GETDATE(),
    'PENDIENTE'
);

INSERT INTO dbo.PERSONA (
    per_tipo_doc_id,
    per_num_doc_id,
    per_nombre,
    per_apellido ,
    per_nacionalidad,
    per_alergias,
    per_direccion,
    per_sexo,
    per_tipo_sangre,
    per_fecha_nacimiento,
    per_activo,
    per_peso,
    per_estatura,
    per_nombre_usuario,
    per_clave,
    per_imagen,
    DOJO_doj_id
) 
VALUES (
    'CEDULA-N',
    23456834,
    'Gustavo Antonio',
    'Colmenares Alvarado',
    'Venezolano',
    'Mariscos',
    'Boulevard del Cafetal. Res. Adriatica. Piso 8. Apto. 8A',
    'M',
    'O-',
    '2000-03-05',
    1,
    88,
    1.78,
    'gustavoto',
    '12345',
    'http://thumbs.dreamstime.com/x/smiley-man-portrait-11016049.jpg',
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-17280493-1')
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Gustavo Antonio'),
    '02128740976'
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Gustavo Antonio'),
    '04142341765'
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Gustavo Antonio'),
    'gustavo.antonio@ucab.edu.ve',
    1
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Gustavo Antonio'),
    'antonio_77@gmail.com',
    0
);

INSERT INTO dbo.SOLICITUD_INSCRIPCION (
    PERSONA_per_id,
    DOJO_doj_id,
    sol_inc_fecha_creacion,
    sol_inc_fecha_actualizacion,
    sol_inc_estado
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Gustavo Antonio'),    
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-17280493-1'),
    GETDATE(),
    GETDATE(),
    'PENDIENTE'
);

INSERT INTO dbo.PERSONA (
    per_tipo_doc_id,
    per_num_doc_id,
    per_nombre,
    per_apellido ,
    per_nacionalidad,
    per_alergias,
    per_direccion,
    per_sexo,
    per_tipo_sangre,
    per_fecha_nacimiento,
    per_activo,
    per_peso,
    per_estatura,
    per_nombre_usuario,
    per_clave,
    per_imagen,
    DOJO_doj_id
) 
VALUES (
    'CEDULA-N',
    23456834,
    'Jessica Alejandra',
    'Garcia Sojo',
    'Venezolano',
    'Mariscos',
    'Boulevard del Cafetal. Res. Adriatica. Piso 8. Apto. 8A',
    'F',
    'O-',
    '2002-03-05',
    1,
    88,
    1.78,
    'jessiale',
    '12345',
    'http://thumbs.dreamstime.com/x/beautiful-woman-portrait-11713329.jpg',
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-15403240-9')
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Jessica Alejandra'),
    '02128740976'
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Jessica Alejandra'),
    '04142341765'
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Jessica Alejandra'),
    'jessica.alejandra@ucab.edu.ve',
    1
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Jessica Alejandra'),
    'jessgarcia94@gmail.com',
    0
);

INSERT INTO dbo.SOLICITUD_INSCRIPCION (
    PERSONA_per_id,
    DOJO_doj_id,
    sol_inc_fecha_creacion,
    sol_inc_fecha_actualizacion,
    sol_inc_estado
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Jessica Alejandra'),    
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-15403240-9'),
    GETDATE(),
    GETDATE(),
    'RECHAZADO'
);

INSERT INTO dbo.PERSONA (
    per_tipo_doc_id,
    per_num_doc_id,
    per_nombre,
    per_apellido ,
    per_nacionalidad,
    per_alergias,
    per_direccion,
    per_sexo,
    per_tipo_sangre,
    per_fecha_nacimiento,
    per_activo,
    per_peso,
    per_estatura,
    per_nombre_usuario,
    per_clave,
    per_imagen,
    DOJO_doj_id
) 
VALUES (
    'CEDULA-N',
    23456834,
    'Mario Alejandro',
    'De Castro Henriquez',
    'Venezolano',
    'Mariscos',
    'Boulevard del Cafetal. Res. Adriatica. Piso 8. Apto. 8A',
    'M',
    'O-',
    '2000-03-05',
    1,
    88,
    1.78,
    'marioale',
    '12345',
    'http://tedslater.com/wp-content/uploads/2010/07/shutterstock_202093444.jpg',
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3')
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Mario Alejandro'),
    '02128740976'
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Mario Alejandro'),
    '04142341765'
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Mario Alejandro'),
    'mario.alejandro@ucab.edu.ve',
    1
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Mario Alejandro'),
    'alejandro.m.dcastro@gmail.com',
    0
);

INSERT INTO dbo.SOLICITUD_INSCRIPCION (
    PERSONA_per_id,
    DOJO_doj_id,
    sol_inc_fecha_creacion,
    sol_inc_fecha_actualizacion,
    sol_inc_estado
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Mario Alejandro'),    
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3'),
    GETDATE(),
    GETDATE(),
    'ACEPTADO'
);

INSERT INTO dbo.MATRICULA (
    mat_identificador,
    mat_fecha_creacion,
    mat_activa,
    mat_fecha_ultimo_pago,
    mat_precio,
    PERSONA_per_id,
    DOJO_doj_id
) 
VALUES (
    '67F-31A-F2',
    GETDATE(),
    1,
    GETDATE(),
    3000,
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Mario Alejandro'),
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-15403240-9')
);

INSERT INTO dbo.PERSONA (
    per_tipo_doc_id,
    per_num_doc_id,
    per_nombre,
    per_apellido ,
    per_nacionalidad,
    per_alergias,
    per_direccion,
    per_sexo,
    per_tipo_sangre,
    per_fecha_nacimiento,
    per_activo,
    per_peso,
    per_estatura,
    per_nombre_usuario,
    per_clave,
    per_imagen,
    DOJO_doj_id
) 
VALUES (
    'CEDULA-N',
    21424696,
    'Romulo Jose',
    'Ruiz Campos',
    'Venezolano',
    'Mariscos',
    '2da. Av. de Montalban. Res. Capricornio. Piso 5. Apto. 10',
    'M',
    'A+',
    '2001-05-21',
    1,
    77,
    1.72,
    'eltercera',
    '12345',
    'https://upload.wikimedia.org/wikipedia/commons/thumb/0/01/Bill_Gates_July_2014.jpg/220px-Bill_Gates_July_2014.jpg',
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-17280493-1')
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Romulo Jose'),
    '02124423694'
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Romulo Jose'),
    '04124456790'
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Romulo Jose'),
    'ucab.genericoo@ucab.edu.ve',
    1
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Romulo Jose'),
    'generico.prueba@gmail.com',
    0
);

INSERT INTO dbo.SOLICITUD_INSCRIPCION (
    PERSONA_per_id,
    DOJO_doj_id,
    sol_inc_fecha_creacion,
    sol_inc_fecha_actualizacion,
    sol_inc_estado
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Romulo Jose'),
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-17280493-1'),
    GETDATE(),
    GETDATE(),
    'ACEPTADO'
);

INSERT INTO dbo.MATRICULA (
    mat_identificador,
    mat_fecha_creacion,
    mat_activa,
    mat_fecha_ultimo_pago,
    mat_precio,
    PERSONA_per_id,
    DOJO_doj_id
) 
VALUES (
    'AA1-CAF-CAFE',
    GETDATE(),
    1,
    GETDATE(),
    3600,
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Romulo Jose'),
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3')
);


INSERT INTO dbo.PERSONA (
    per_tipo_doc_id,
    per_num_doc_id,
    per_nombre,
    per_apellido ,
    per_nacionalidad,
    per_alergias,
    per_direccion,
    per_sexo,
    per_tipo_sangre,
    per_fecha_nacimiento,
    per_activo,
    per_peso,
    per_estatura,
    per_nombre_usuario,
    per_clave,
    per_imagen,
    DOJO_doj_id
) 
VALUES (
    'CEDULA-N',
    21424696,
    'Silfredo Augusto',
    'Rugeles Arraiz',
    'Venezolano',
    'Mariscos',
    '2da. Av. de Montalban. Res. Capricornio. Piso 5. Apto. 10',
    'M',
    'A+',
    '2000-05-21',
    1,
    77,
    1.72,
    'silfreau',
    '12345',
    'http://marshallmatlock.com/wp-content/gallery/mans-man-jon-hamm/thumbs/thumbs_jon%20hamm%20portrait%20suit.png',
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3')
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Silfredo Augusto'),
    '02124423694'
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Silfredo Augusto'),
    '04124456790'
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Silfredo Augusto'),
    'ucab.genericoo@ucab.edu.ve',
    1
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Silfredo Augusto'),
    'generico.prueba@gmail.com',
    0
);

INSERT INTO dbo.SOLICITUD_INSCRIPCION (
    PERSONA_per_id,
    DOJO_doj_id,
    sol_inc_fecha_creacion,
    sol_inc_fecha_actualizacion,
    sol_inc_estado
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Silfredo Augusto'),
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3'),
    GETDATE(),
    GETDATE(),
    'ACEPTADO'
);

INSERT INTO dbo.MATRICULA (
    mat_identificador,
    mat_fecha_creacion,
    mat_activa,
    mat_fecha_ultimo_pago,
    mat_precio,
    PERSONA_per_id,
    DOJO_doj_id
) 
VALUES (
    'AA2-CAF-CAFE',
    GETDATE(),
    1,
    GETDATE(),
    5500,
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Silfredo Augusto'),
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3')
);

INSERT INTO dbo.PERSONA (
    per_tipo_doc_id,
    per_num_doc_id,
    per_nombre,
    per_apellido ,
    per_nacionalidad,
    per_alergias,
    per_direccion,
    per_sexo,
    per_tipo_sangre,
    per_fecha_nacimiento,
    per_activo,
    per_peso,
    per_estatura,
    per_nombre_usuario,
    per_clave,
    per_imagen,
    DOJO_doj_id
) 
VALUES (
    'CEDULA-N',
    21424696,
    'Saul Enrique',
    'Hernandez Arraiz',
    'Venezolano',
    'Mariscos',
    '2da. Av. de Montalban. Res. Capricornio. Piso 5. Apto. 10',
    'M',
    'A+',
    '2000-05-21',
    1,
    77,
    1.72,
    'saulen',
    '12345',
    'http://www4.pictures.zimbio.com/gi/Solitary+Man+Portraits+2009+Toronto+International+kBVOjNQV9rzl.jpg',
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3')
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Saul Enrique'),
    '02124423694'
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Saul Enrique'),
    '04124456790'
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Saul Enrique'),
    'ucab.genericoo@ucab.edu.ve',
    1
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Saul Enrique'),
    'generico.prueba@gmail.com',
    0
);

INSERT INTO dbo.SOLICITUD_INSCRIPCION (
    PERSONA_per_id,
    DOJO_doj_id,
    sol_inc_fecha_creacion,
    sol_inc_fecha_actualizacion,
    sol_inc_estado
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Saul Enrique'),
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3'),
    GETDATE(),
    GETDATE(),
    'ACEPTADO'
);

INSERT INTO dbo.MATRICULA (
    mat_identificador,
    mat_fecha_creacion,
    mat_activa,
    mat_fecha_ultimo_pago,
    mat_precio,
    PERSONA_per_id,
    DOJO_doj_id
) 
VALUES (
    'AA3-CAF-CAFE',
    GETDATE(),
    1,
    GETDATE(),
    2780,
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Saul Enrique'),
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3')
);

INSERT INTO dbo.PERSONA (
    per_tipo_doc_id,
    per_num_doc_id,
    per_nombre,
    per_apellido ,
    per_nacionalidad,
    per_alergias,
    per_direccion,
    per_sexo,
    per_tipo_sangre,
    per_fecha_nacimiento,
    per_activo,
    per_peso,
    per_estatura,
    per_nombre_usuario,
    per_clave,
    per_imagen,
    DOJO_doj_id
) 
VALUES (
    'CEDULA-N',
    21424696,
    'Guillermo Daniel',
    'Jaramillo Do Couto',
    'Venezolano',
    'Mariscos',
    '2da. Av. de Montalban. Res. Capricornio. Piso 5. Apto. 10',
    'M',
    'A+',
    '2001-05-21',
    1,
    77,
    1.,
    'guilleja',
    '12345',
    'http://previews.123rf.com/images/rido/rido1212/rido121200073/16732489-Closeup-portrait-of-smiling-young-man-isolated-on-white-background-Stock-Photo.jpg',
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3')
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Guillermo Daniel'),
    '02124423694'
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Guillermo Daniel'),
    '04124456790'
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Guillermo Daniel'),
    'ucab.genericoo@ucab.edu.ve',
    1
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Guillermo Daniel'),
    'generico.prueba@gmail.com',
    0
);

INSERT INTO dbo.SOLICITUD_INSCRIPCION (
    PERSONA_per_id,
    DOJO_doj_id,
    sol_inc_fecha_creacion,
    sol_inc_fecha_actualizacion,
    sol_inc_estado
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Guillermo Daniel'),
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3'),
    GETDATE(),
    GETDATE(),
    'ACEPTADO'
);

INSERT INTO dbo.MATRICULA (
    mat_identificador,
    mat_fecha_creacion,
    mat_activa,
    mat_fecha_ultimo_pago,
    mat_precio,
    PERSONA_per_id,
    DOJO_doj_id
) 
VALUES (
    'AA4-CAF-CAFE',
    GETDATE(),
    1,
    GETDATE(),
    2678,
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Guillermo Daniel'),
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3')
);

INSERT INTO dbo.PERSONA (
    per_tipo_doc_id,
    per_num_doc_id,
    per_nombre,
    per_apellido ,
    per_nacionalidad,
    per_alergias,
    per_direccion,
    per_sexo,
    per_tipo_sangre,
    per_fecha_nacimiento,
    per_activo,
    per_peso,
    per_estatura,
    per_nombre_usuario,
    per_clave,
    per_imagen,
    DOJO_doj_id
) 
VALUES (
    'CEDULA-N',
    21424696,
    'Pedro Leonardo',
    'Jaramillo Do Couto',
    'Venezolano',
    'Mariscos',
    '2da. Av. de Montalban. Res. Capricornio. Piso 5. Apto. 10',
    'M',
    'A+',
    '2000-05-21',
    1,
    77,
    1.72,
    'pedroleo',
    '12345',
    'https://c2.staticflickr.com/4/3147/3030821516_793151ecc1_z.jpg',
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3')
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Pedro Leonardo'),
    '02124423694'
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Pedro Leonardo'),
    '04124456790'
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Pedro Leonardo'),
    'ucab.genericoo@ucab.edu.ve',
    1
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Pedro Leonardo'),
    'generico.prueba@gmail.com',
    0
);

INSERT INTO dbo.SOLICITUD_INSCRIPCION (
    PERSONA_per_id,
    DOJO_doj_id,
    sol_inc_fecha_creacion,
    sol_inc_fecha_actualizacion,
    sol_inc_estado
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Pedro Leonardo'),
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3'),
    GETDATE(),
    GETDATE(),
    'ACEPTADO'
);

INSERT INTO dbo.MATRICULA (
    mat_identificador,
    mat_fecha_creacion,
    mat_activa,
    mat_fecha_ultimo_pago,
    mat_precio,
    PERSONA_per_id,
    DOJO_doj_id
) 
VALUES (
    'AA5-CAF-CAFE',
    GETDATE(),
    1,
    GETDATE(),
    4200,
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Pedro Leonardo'),
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3')
);

INSERT INTO dbo.PERSONA (
    per_tipo_doc_id,
    per_num_doc_id,
    per_nombre,
    per_apellido ,
    per_nacionalidad,
    per_alergias,
    per_direccion,
    per_sexo,
    per_tipo_sangre,
    per_fecha_nacimiento,
    per_activo,
    per_peso,
    per_estatura,
    per_nombre_usuario,
    per_clave,
    per_imagen,
    DOJO_doj_id
) 
VALUES (
    'CEDULA-N',
    21424696,
    'Jose Miguel',
    'Jaramillo Do Couto',
    'Venezolano',
    'Mariscos',
    '2da. Av. de Montalban. Res. Capricornio. Piso 5. Apto. 10',
    'M',
    'A+',
    '2001-05-21',
    1,
    77,
    1.72,
    'josemiguel',
    '12345',
    'http://www.photographyblogger.net/wp-content/uploads/2013/05/1-jaco-van-den-hoven.jpg',
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3')
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Jose Miguel'),
    '02124423694'
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Jose Miguel'),
    '04124456790'
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Jose Miguel'),
    'ucab.genericoo@ucab.edu.ve',
    1
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Jose Miguel'),
    'generico.prueba@gmail.com',
    0
);

INSERT INTO dbo.SOLICITUD_INSCRIPCION (
    PERSONA_per_id,
    DOJO_doj_id,
    sol_inc_fecha_creacion,
    sol_inc_fecha_actualizacion,
    sol_inc_estado
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Jose Miguel'),
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3'),
    GETDATE(),
    GETDATE(),
    'ACEPTADO'
);

INSERT INTO dbo.MATRICULA (
    mat_identificador,
    mat_fecha_creacion,
    mat_activa,
    mat_fecha_ultimo_pago,
    mat_precio,
    PERSONA_per_id,
    DOJO_doj_id
) 
VALUES (
    'AA6-CAF-CAFE',
    GETDATE(),
    1,
    GETDATE(),
    5600,
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Jose Miguel'),
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3')
);

INSERT INTO dbo.PERSONA (
    per_tipo_doc_id,
    per_num_doc_id,
    per_nombre,
    per_apellido ,
    per_nacionalidad,
    per_alergias,
    per_direccion,
    per_sexo,
    per_tipo_sangre,
    per_fecha_nacimiento,
    per_activo,
    per_peso,
    per_estatura,
    per_nombre_usuario,
    per_clave,
    per_imagen,
    DOJO_doj_id
) 
VALUES (
    'CEDULA-N',
    21424693,
    'Maria Antonieta',
    'Jaramillo Do Couto',
    'Venezolano',
    'Mariscos',
    '2da. Av. de Montalban. Res. Capricornio. Piso 5. Apto. 10',
    'F',
    'A+',
    '2001-05-21',
    1,
    77,
    1.72,
    'maritonieta',
    '12345',
    'http://pre14.deviantart.net/3404/th/pre/i/2013/181/8/a/portrait_of_beautiful_woman_by_vladimir_serov-d6b67i9.jpg',
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-15403240-9')
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Maria Antonieta'),
    '02124423694'
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Maria Antonieta'),
    '04124456790'
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Maria Antonieta'),
    'ucab.genericoo@ucab.edu.ve',
    1
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Maria Antonieta'),
    'generico.prueba@gmail.com',
    0
);

INSERT INTO dbo.SOLICITUD_INSCRIPCION (
    PERSONA_per_id,
    DOJO_doj_id,
    sol_inc_fecha_creacion,
    sol_inc_fecha_actualizacion,
    sol_inc_estado
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Maria Antonieta'),
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-15403240-9'),
    GETDATE(),
    GETDATE(),
    'ACEPTADO'
);

INSERT INTO dbo.MATRICULA (
    mat_identificador,
    mat_fecha_creacion,
    mat_activa,
    mat_fecha_ultimo_pago,
    mat_precio,
    PERSONA_per_id,
    DOJO_doj_id
) 
VALUES (
    'AA7-CAF-CAFE',
    GETDATE(),
    1,
    GETDATE(),
    2100,
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Maria Antonieta'),
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3')
);


INSERT INTO dbo.PERSONA (
    per_tipo_doc_id,
    per_num_doc_id,
    per_nombre,
    per_apellido ,
    per_nacionalidad,
    per_alergias,
    per_direccion,
    per_sexo,
    per_tipo_sangre,
    per_fecha_nacimiento,
    per_activo,
    per_peso,
    per_estatura,
    per_nombre_usuario,
    per_clave,
    per_imagen,
    DOJO_doj_id
) 
VALUES (
    'CEDULA-N',
    21424694,
    'Victoria Isabella',
    'Jaramillo Do Couto',
    'Venezolano',
    'Mariscos',
    '2da. Av. de Montalban. Res. Capricornio. Piso 5. Apto. 10',
    'F',
    'A+',
    '2000-05-21',
    1,
    77,
    1.72,
    'vickybella',
    '12345',
    'http://pre14.deviantart.net/3404/th/pre/i/2013/181/8/a/portrait_of_beautiful_woman_by_vladimir_serov-d6b67i9.jpg',
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-15403240-9')
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Victoria Isabella'),
    '02124423694'
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Victoria Isabella'),
    '04124456790'
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Victoria Isabella'),
    'ucab.genericoo@ucab.edu.ve',
    1
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Victoria Isabella'),
    'generico.prueba@gmail.com',
    0
);

INSERT INTO dbo.SOLICITUD_INSCRIPCION (
    PERSONA_per_id,
    DOJO_doj_id,
    sol_inc_fecha_creacion,
    sol_inc_fecha_actualizacion,
    sol_inc_estado
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Victoria Isabella'),
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-15403240-9'),
    GETDATE(),
    GETDATE(),
    'ACEPTADO'
);

INSERT INTO dbo.MATRICULA (
    mat_identificador,
    mat_fecha_creacion,
    mat_activa,
    mat_fecha_ultimo_pago,
    mat_precio,
    PERSONA_per_id,
    DOJO_doj_id
) 
VALUES (
    'AA8-CAF-CAFE',
    GETDATE(),
    1,
    GETDATE(),
    3900,
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Victoria Isabella'),
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3')
);


INSERT INTO dbo.PERSONA (
    per_tipo_doc_id,
    per_num_doc_id,
    per_nombre,
    per_apellido ,
    per_nacionalidad,
    per_alergias,
    per_direccion,
    per_sexo,
    per_tipo_sangre,
    per_fecha_nacimiento,
    per_activo,
    per_peso,
    per_estatura,
    per_nombre_usuario,
    per_clave,
    per_imagen,
    DOJO_doj_id
) 
VALUES (
    'CEDULA-N',
    21424632,
    'Melissa Nathalie',
    'Jaramillo Do Couto',
    'Venezolano',
    'Mariscos',
    '2da. Av. de Montalban. Res. Capricornio. Piso 5. Apto. 10',
    'F',
    'A+',
    '2001-05-21',
    1,
    77,
    1.72,
    'melilie',
    '12345',
    'http://www.noupe.com/wp-content/uploads/2010/01/26-portraits.jpg',
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-15403240-9')
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Melissa Nathalie'),
    '02124423694'
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Melissa Nathalie'),
    '04124456790'
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Melissa Nathalie'),
    'ucab.genericoo@ucab.edu.ve',
    1
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Melissa Nathalie'),
    'generico.prueba@gmail.com',
    0
);

INSERT INTO dbo.SOLICITUD_INSCRIPCION (
    PERSONA_per_id,
    DOJO_doj_id,
    sol_inc_fecha_creacion,
    sol_inc_fecha_actualizacion,
    sol_inc_estado
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Melissa Nathalie'),
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-15403240-9'),
    GETDATE(),
    GETDATE(),
    'ACEPTADO'
);

INSERT INTO dbo.MATRICULA (
    mat_identificador,
    mat_fecha_creacion,
    mat_activa,
    mat_fecha_ultimo_pago,
    mat_precio,
    PERSONA_per_id,
    DOJO_doj_id
) 
VALUES (
    'AA9-CAF-CAFE',
    GETDATE(),
    1,
    GETDATE(),
    5000,
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Melissa Nathalie'),
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3')
);


INSERT INTO dbo.PERSONA (
    per_tipo_doc_id,
    per_num_doc_id,
    per_nombre,
    per_apellido ,
    per_nacionalidad,
    per_alergias,
    per_direccion,
    per_sexo,
    per_tipo_sangre,
    per_fecha_nacimiento,
    per_activo,
    per_peso,
    per_estatura,
    per_nombre_usuario,
    per_clave,
    per_imagen,
    DOJO_doj_id
) 
VALUES (
    'CEDULA-N',
    14020471,
    'Elizabeth Antonia',
    'Jaramillo Do Couto',
    'Venezolano',
    'Mariscos',
    '2da. Av. de Montalban. Res. Capricornio. Piso 5. Apto. 10',
    'F',
    'A+',
    '2001-05-21',
    1,
    77,
    1.72,
    'elidocouto',
    '12345',
    'http://www.wallcoo.net/photography/markus-j-grimm_portrait_photography_02/images/Color_portrait_photo_15971497.jpg',
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-15403240-9')
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Elizabeth Antonia'),
    '02124423694'
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Elizabeth Antonia'),
    '04124456790'
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Elizabeth Antonia'),
    'ucab.genericoo@ucab.edu.ve',
    1
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Elizabeth Antonia'),
    'generico.prueba@gmail.com',
    0
);

INSERT INTO dbo.SOLICITUD_INSCRIPCION (
    PERSONA_per_id,
    DOJO_doj_id,
    sol_inc_fecha_creacion,
    sol_inc_fecha_actualizacion,
    sol_inc_estado
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Elizabeth Antonia'),
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-15403240-9'),
    GETDATE(),
    GETDATE(),
    'ACEPTADO'
);

INSERT INTO dbo.MATRICULA (
    mat_identificador,
    mat_fecha_creacion,
    mat_activa,
    mat_fecha_ultimo_pago,
    mat_precio,
    PERSONA_per_id,
    DOJO_doj_id
) 
VALUES (
    'AAA-CAF-CAFE',
    GETDATE(),
    1,
    GETDATE(),
    4200,
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Elizabeth Antonia'),
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3')
);

INSERT INTO dbo.PERSONA (
    per_tipo_doc_id,
    per_num_doc_id,
    per_nombre,
    per_apellido ,
    per_nacionalidad,
    per_alergias,
    per_direccion,
    per_sexo,
    per_tipo_sangre,
    per_fecha_nacimiento,
    per_activo,
    per_peso,
    per_estatura,
    per_nombre_usuario,
    per_clave,
    per_imagen,
    DOJO_doj_id
) 
VALUES (
    'CEDULA-N',
    14020472,
    'Marco Alejandro',
    'Sanz Arcila',
    'Venezolano',
    'Mariscos',
    '2da. Av. de Montalban. Res. Capricornio. Piso 5. Apto. 10',
    'M',
    'A+',
    '2001-05-21',
    1,
    77,
    1.72,
    'marcosanz',
    '12345',
    'https://pixabay.com/static/uploads/photo/2013/11/20/23/01/man-214200_960_720.jpg',
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3')
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Marco Alejandro'),
    '02124423694'
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Marco Alejandro'),
    '04124456790'
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Marco Alejandro'),
    'ucab.genericoo@ucab.edu.ve',
    1
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Marco Alejandro'),
    'generico.prueba@gmail.com',
    0
);

INSERT INTO dbo.SOLICITUD_INSCRIPCION (
    PERSONA_per_id,
    DOJO_doj_id,
    sol_inc_fecha_creacion,
    sol_inc_fecha_actualizacion,
    sol_inc_estado
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Marco Alejandro'),
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3'),
    GETDATE(),
    GETDATE(),
    'ACEPTADO'
);

INSERT INTO dbo.MATRICULA (
    mat_identificador,
    mat_fecha_creacion,
    mat_activa,
    mat_fecha_ultimo_pago,
    mat_precio,
    PERSONA_per_id,
    DOJO_doj_id
) 
VALUES (
    'EFC1-CAF-CAFE',
    GETDATE(),
    1,
    GETDATE(),
    2780,
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Marco Alejandro'),
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3')
);
INSERT INTO dbo.PERSONA (
    per_tipo_doc_id,
    per_num_doc_id,
    per_nombre,
    per_apellido ,
    per_nacionalidad,
    per_alergias,
    per_direccion,
    per_sexo,
    per_tipo_sangre,
    per_fecha_nacimiento,
    per_activo,
    per_peso,
    per_estatura,
    per_nombre_usuario,
    per_clave,
    per_imagen,
    DOJO_doj_id
) 
VALUES (
    'CEDULA-N',
    14020474,
    'Jose Gregorio',
    'Sanz Arcila',
    'Venezolano',
    'Mariscos',
    '2da. Av. de Montalban. Res. Capricornio. Piso 5. Apto. 10',
    'M',
    'A+',
    '2002-05-21',
    1,
    77,
    1.72,
    'goyito',
    '12345',
    'https://c1.staticflickr.com/3/2835/9965420034_1b7450e257.jpg',
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3')
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Jose Gregorio'),
    '02124423694'
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Jose Gregorio'),
    '04124456790'
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Jose Gregorio'),
    'ucab.genericoo@ucab.edu.ve',
    1
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Jose Gregorio'),
    'generico.prueba@gmail.com',
    0
);

INSERT INTO dbo.SOLICITUD_INSCRIPCION (
    PERSONA_per_id,
    DOJO_doj_id,
    sol_inc_fecha_creacion,
    sol_inc_fecha_actualizacion,
    sol_inc_estado
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Jose Gregorio'),
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3'),
    GETDATE(),
    GETDATE(),
    'ACEPTADO'
);

INSERT INTO dbo.MATRICULA (
    mat_identificador,
    mat_fecha_creacion,
    mat_activa,
    mat_fecha_ultimo_pago,
    mat_precio,
    PERSONA_per_id,
    DOJO_doj_id
) 
VALUES (
    'EFC2-CAF-CAFE',
    GETDATE(),
    1,
    GETDATE(),
    3700,
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Jose Gregorio'),
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3')
);


INSERT INTO dbo.PERSONA (
    per_tipo_doc_id,
    per_num_doc_id,
    per_nombre,
    per_apellido ,
    per_nacionalidad,
    per_alergias,
    per_direccion,
    per_sexo,
    per_tipo_sangre,
    per_fecha_nacimiento,
    per_activo,
    per_peso,
    per_estatura,
    per_nombre_usuario,
    per_clave,
    per_imagen,
    DOJO_doj_id
) 
VALUES (
    'CEDULA-N',
    14020475,
    'Luis Armando',
    'Pereira Alfonzo',
    'Venezolano',
    'Mariscos',
    '2da. Av. de Montalban. Res. Capricornio. Piso 5. Apto. 10',
    'M',
    'A+',
    '2001-05-21',
    1,
    77,
    1.72,
    'armandito',
    '12345',
    'https://pixabay.com/static/uploads/photo/2015/01/16/15/01/man-601560_960_720.jpg',
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3')
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Luis Armando'),
    '02124423694'
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Luis Armando'),
    '04124456790'
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Luis Armando'),
    'ucab.genericoo@ucab.edu.ve',
    1
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Luis Armando'),
    'generico.prueba@gmail.com',
    0
);

INSERT INTO dbo.SOLICITUD_INSCRIPCION (
    PERSONA_per_id,
    DOJO_doj_id,
    sol_inc_fecha_creacion,
    sol_inc_fecha_actualizacion,
    sol_inc_estado
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Luis Armando'),
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3'),
    GETDATE(),
    GETDATE(),
    'ACEPTADO'
);

INSERT INTO dbo.MATRICULA (
    mat_identificador,
    mat_fecha_creacion,
    mat_activa,
    mat_fecha_ultimo_pago,
    mat_precio,
    PERSONA_per_id,
    DOJO_doj_id
) 
VALUES (
    'EFC3-CAF-CAFE',
    GETDATE(),
    1,
    GETDATE(),
    2900,
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Luis Armando'),
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3')
);

INSERT INTO dbo.PERSONA (
    per_tipo_doc_id,
    per_num_doc_id,
    per_nombre,
    per_apellido ,
    per_nacionalidad,
    per_alergias,
    per_direccion,
    per_sexo,
    per_tipo_sangre,
    per_fecha_nacimiento,
    per_activo,
    per_peso,
    per_estatura,
    per_nombre_usuario,
    per_clave,
    per_imagen,
    DOJO_doj_id
) 
VALUES (
    'CEDULA-N',
    14020476,
    'Federico Ernesto',
    'Pereira Alfonzo',
    'Venezolano',
    'Mariscos',
    '2da. Av. de Montalban. Res. Capricornio. Piso 5. Apto. 10',
    'M',
    'A+',
    '2000-05-21',
    1,
    77,
    1.72,
    'ernestof',
    '12345',
    'https://c1.staticflickr.com/3/2222/2088987724_f4f58e7aa7.jpg',
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3')
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Federico Ernesto'),
    '02124423694'
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Federico Ernesto'),
    '04124456790'
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Federico Ernesto'),
    'ucab.genericoo@ucab.edu.ve',
    1
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Federico Ernesto'),
    'generico.prueba@gmail.com',
    0
);

INSERT INTO dbo.SOLICITUD_INSCRIPCION (
    PERSONA_per_id,
    DOJO_doj_id,
    sol_inc_fecha_creacion,
    sol_inc_fecha_actualizacion,
    sol_inc_estado
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Federico Ernesto'),
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3'),
    GETDATE(),
    GETDATE(),
    'ACEPTADO'
);

INSERT INTO dbo.MATRICULA (
    mat_identificador,
    mat_fecha_creacion,
    mat_activa,
    mat_fecha_ultimo_pago,
    mat_precio,
    PERSONA_per_id,
    DOJO_doj_id
) 
VALUES (
    'EFC4-CAF-CAFE',
    GETDATE(),
    1,
    GETDATE(),
    2100,
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Federico Ernesto'),
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3')
);


INSERT INTO dbo.PERSONA (
    per_tipo_doc_id,
    per_num_doc_id,
    per_nombre,
    per_apellido ,
    per_nacionalidad,
    per_alergias,
    per_direccion,
    per_sexo,
    per_tipo_sangre,
    per_fecha_nacimiento,
    per_activo,
    per_peso,
    per_estatura,
    per_nombre_usuario,
    per_clave,
    per_imagen,
    DOJO_doj_id
) 
VALUES (
    'CEDULA-E',
    14086743,
    'Liu Wa',
    'Ping Hua',
    'Venezolano',
    'Mariscos',
    '2da. Av. de Montalban. Res. Capricornio. Piso 5. Apto. 10',
    'M',
    'A+',
    '2001-05-21',
    1,
    77,
    1.72,
    'chinitowa',
    '12345',
    'https://pixabay.com/static/uploads/photo/2014/11/19/10/52/man-537136_960_720.jpg',
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3')
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Liu Wa'),
    '02124423694'
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Liu Wa'),
    '04124456790'
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Liu Wa'),
    'ucab.genericoo@ucab.edu.ve',
    1
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Liu Wa'),
    'generico.prueba@gmail.com',
    0
);

INSERT INTO dbo.SOLICITUD_INSCRIPCION (
    PERSONA_per_id,
    DOJO_doj_id,
    sol_inc_fecha_creacion,
    sol_inc_fecha_actualizacion,
    sol_inc_estado
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Liu Wa'),
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3'),
    GETDATE(),
    GETDATE(),
    'ACEPTADO'
);

INSERT INTO dbo.MATRICULA (
    mat_identificador,
    mat_fecha_creacion,
    mat_activa,
    mat_fecha_ultimo_pago,
    mat_precio,
    PERSONA_per_id,
    DOJO_doj_id
) 
VALUES (
    'EFC5-CAF-CAFE',
    GETDATE(),
    1,
    GETDATE(),
    4600,
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Liu Wa'),
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3')
);

INSERT INTO dbo.PERSONA (
    per_tipo_doc_id,
    per_num_doc_id,
    per_nombre,
    per_apellido ,
    per_nacionalidad,
    per_alergias,
    per_direccion,
    per_sexo,
    per_tipo_sangre,
    per_fecha_nacimiento,
    per_activo,
    per_peso,
    per_estatura,
    per_nombre_usuario,
    per_clave,
    per_imagen,
    DOJO_doj_id
) 
VALUES (
    'CEDULA-N',
    4818341,
    'Marta Carolina',
    'Huertas Moncada',
    'Venezolano',
    'Mariscos',
    '2da. Av. de Montalban. Res. Capricornio. Piso 5. Apto. 10',
    'F',
    'A+',
    '2000-05-21',
    1,
    77,
    1.72,
    'martica',
    '12345',
    'http://img.whitezine.com/Thomas-Lavelle-Portrait-Woman.jpg',
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-15403240-9')
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Marta Carolina'),
    '02124423694'
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Marta Carolina'),
    '04124456790'
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Marta Carolina'),
    'ucab.genericoo@ucab.edu.ve',
    1
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Marta Carolina'),
    'generico.prueba@gmail.com',
    0
);

INSERT INTO dbo.SOLICITUD_INSCRIPCION (
    PERSONA_per_id,
    DOJO_doj_id,
    sol_inc_fecha_creacion,
    sol_inc_fecha_actualizacion,
    sol_inc_estado
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Marta Carolina'),
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-15403240-9'),
    GETDATE(),
    GETDATE(),
    'ACEPTADO'
);

INSERT INTO dbo.MATRICULA (
    mat_identificador,
    mat_fecha_creacion,
    mat_activa,
    mat_fecha_ultimo_pago,
    mat_precio,
    PERSONA_per_id,
    DOJO_doj_id
) 
VALUES (
    'EFC6-CAF-CAFE',
    GETDATE(),
    1,
    GETDATE(),
    7000,
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Marta Carolina'),
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3')
);

INSERT INTO dbo.PERSONA (
    per_tipo_doc_id,
    per_num_doc_id,
    per_nombre,
    per_apellido ,
    per_nacionalidad,
    per_alergias,
    per_direccion,
    per_sexo,
    per_tipo_sangre,
    per_fecha_nacimiento,
    per_activo,
    per_peso,
    per_estatura,
    per_nombre_usuario,
    per_clave,
    per_imagen,
    DOJO_doj_id
) 
VALUES (
    'CEDULA-N',
    4818342,
    'Patricia Elena',
    'Huertas Moncada',
    'Venezolano',
    'Mariscos',
    '2da. Av. de Montalban. Res. Capricornio. Piso 5. Apto. 10',
    'F',
    'A+',
    '2000-05-21',
    1,
    77,
    1.72,
    'elenita',
    '12345',
    'https://pixabay.com/static/uploads/photo/2015/03/04/19/41/woman-659348_960_720.jpg',
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-15403240-9')
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Patricia Elena'),
    '02124423694'
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Patricia Elena'),
    '04124456790'
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Patricia Elena'),
    'ucab.genericoo@ucab.edu.ve',
    1
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Patricia Elena'),
    'generico.prueba@gmail.com',
    0
);

INSERT INTO dbo.SOLICITUD_INSCRIPCION (
    PERSONA_per_id,
    DOJO_doj_id,
    sol_inc_fecha_creacion,
    sol_inc_fecha_actualizacion,
    sol_inc_estado
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Patricia Elena'),
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-15403240-9'),
    GETDATE(),
    GETDATE(),
    'ACEPTADO'
);

INSERT INTO dbo.MATRICULA (
    mat_identificador,
    mat_fecha_creacion,
    mat_activa,
    mat_fecha_ultimo_pago,
    mat_precio,
    PERSONA_per_id,
    DOJO_doj_id
) 
VALUES (
    'EFC7-CAF-CAFE',
    GETDATE(),
    1,
    GETDATE(),
    6000,
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Patricia Elena'),
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3')
);


INSERT INTO dbo.PERSONA (
    per_tipo_doc_id,
    per_num_doc_id,
    per_nombre,
    per_apellido ,
    per_nacionalidad,
    per_alergias,
    per_direccion,
    per_sexo,
    per_tipo_sangre,
    per_fecha_nacimiento,
    per_activo,
    per_peso,
    per_estatura,
    per_nombre_usuario,
    per_clave,
    per_imagen,
    DOJO_doj_id
) 
VALUES (
    'CEDULA-N',
    4818343,
    'Neolida Margarita',
    'Huertas Moncada',
    'Venezolano',
    'Mariscos',
    '2da. Av. de Montalban. Res. Capricornio. Piso 5. Apto. 10',
    'F',
    'A+',
    '2000-05-21',
    1,
    77,
    1.72,
    'neomar',
    '12345',
    'http://digital-art-gallery.com/oid/21/632x833_5536_Alexz_Johnson_portrait_2d_realism_girl_portrait_realistic_beauty_woman_picture_image_digital_art.jpg',
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-15403240-9')
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Neolida Margarita'),
    '02124423694'
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Neolida Margarita'),
    '04124456790'
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Neolida Margarita'),
    'ucab.genericoo@ucab.edu.ve',
    1
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Neolida Margarita'),
    'generico.prueba@gmail.com',
    0
);

INSERT INTO dbo.SOLICITUD_INSCRIPCION (
    PERSONA_per_id,
    DOJO_doj_id,
    sol_inc_fecha_creacion,
    sol_inc_fecha_actualizacion,
    sol_inc_estado
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Neolida Margarita'),
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-15403240-9'),
    GETDATE(),
    GETDATE(),
    'ACEPTADO'
);

INSERT INTO dbo.MATRICULA (
    mat_identificador,
    mat_fecha_creacion,
    mat_activa,
    mat_fecha_ultimo_pago,
    mat_precio,
    PERSONA_per_id,
    DOJO_doj_id
) 
VALUES (
    'EFC8-CAF-CAFE',
    GETDATE(),
    1,
    GETDATE(),
    3400,
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Neolida Margarita'),
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3')
);

INSERT INTO dbo.PERSONA (
    per_tipo_doc_id,
    per_num_doc_id,
    per_nombre,
    per_apellido ,
    per_nacionalidad,
    per_alergias,
    per_direccion,
    per_sexo,
    per_tipo_sangre,
    per_fecha_nacimiento,
    per_activo,
    per_peso,
    per_estatura,
    per_nombre_usuario,
    per_clave,
    per_imagen,
    DOJO_doj_id
) 
VALUES (
    'CEDULA-N',
    4818344,
    'Nora Margarita',
    'Lopez Villarroel',
    'Venezolano',
    'Mariscos',
    '2da. Av. de Montalban. Res. Capricornio. Piso 5. Apto. 10',
    'F',
    'A+',
    '2001-05-21',
    1,
    77,
    1.72,
    'norita',
    '12345',
    'http://hd.wallpaperswide.com/thumbs/beautiful_woman_portrait-t2.jpg',
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-15403240-9')
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Nora Margarita'),
    '02124423694'
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Nora Margarita'),
    '04124456790'
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Nora Margarita'),
    'ucab.genericoo@ucab.edu.ve',
    1
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Nora Margarita'),
    'generico.prueba@gmail.com',
    0
);

INSERT INTO dbo.SOLICITUD_INSCRIPCION (
    PERSONA_per_id,
    DOJO_doj_id,
    sol_inc_fecha_creacion,
    sol_inc_fecha_actualizacion,
    sol_inc_estado
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Nora Margarita'),
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-15403240-9'),
    GETDATE(),
    GETDATE(),
    'ACEPTADO'
);

INSERT INTO dbo.MATRICULA (
    mat_identificador,
    mat_fecha_creacion,
    mat_activa,
    mat_fecha_ultimo_pago,
    mat_precio,
    PERSONA_per_id,
    DOJO_doj_id
) 
VALUES (
    'EFC9-CAF-CAFE',
    GETDATE(),
    1,
    GETDATE(),
    5900,
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Nora Margarita'),
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3')
);


INSERT INTO dbo.PERSONA (
    per_tipo_doc_id,
    per_num_doc_id,
    per_nombre,
    per_apellido ,
    per_nacionalidad,
    per_alergias,
    per_direccion,
    per_sexo,
    per_tipo_sangre,
    per_fecha_nacimiento,
    per_activo,
    per_peso,
    per_estatura,
    per_nombre_usuario,
    per_clave,
    per_imagen,
    DOJO_doj_id
) 
VALUES (
    'CEDULA-N',
    4818345,
    'Sabrina',
    'Flores Cisneros',
    'Venezolano',
    'Mariscos',
    '2da. Av. de Montalban. Res. Capricornio. Piso 5. Apto. 10',
    'F',
    'A+',
    '2001-05-21',
    1,
    77,
    1.72,
    'norita',
    '12345',
    'http://images.fineartamerica.com/images/artworkimages/mediumlarge/1/gorgeous-woman-portrait-anna-omelchenko.jpg',
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-15403240-9')
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Sabrina'),
    '02124423694'
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Sabrina'),
    '04124456790'
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Sabrina'),
    'ucab.genericoo@ucab.edu.ve',
    1
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Sabrina'),
    'generico.prueba@gmail.com',
    0
);

INSERT INTO dbo.SOLICITUD_INSCRIPCION (
    PERSONA_per_id,
    DOJO_doj_id,
    sol_inc_fecha_creacion,
    sol_inc_fecha_actualizacion,
    sol_inc_estado
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Sabrina'),
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-15403240-9'),
    GETDATE(),
    GETDATE(),
    'ACEPTADO'
);

INSERT INTO dbo.MATRICULA (
    mat_identificador,
    mat_fecha_creacion,
    mat_activa,
    mat_fecha_ultimo_pago,
    mat_precio,
    PERSONA_per_id,
    DOJO_doj_id
) 
VALUES (
    'BBA1-CAF-CAFE',
    GETDATE(),
    1,
    GETDATE(),
    4250,
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Sabrina'),
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3')
);



/* ADMINISTRADORES */

INSERT INTO dbo.PERSONA (
    per_tipo_doc_id,
    per_num_doc_id,
    per_nombre,
    per_apellido ,
    per_nacionalidad,
    per_alergias,
    per_direccion,
    per_sexo,
    per_tipo_sangre,
    per_fecha_nacimiento,
    per_activo,
    per_peso,
    per_estatura,
    per_nombre_usuario,
    per_clave,
    per_imagen,
    DOJO_doj_id
) 
VALUES (
    'CEDULA-N',
    21424696,
    'Alexander Abraham',
    'Ramirez Cabrera',
    'Venezolano',
    'Mariscos',
    '2da. Av. de Montalban. Res. Capricornio. Piso 5. Apto. 10',
    'M',
    'A+',
    '1993-05-21',
    1,
    77,
    1.72,
    'ramirezadmin',
    '12345',
    'http://st.depositphotos.com/1009647/1293/i/950/depositphotos_12933724-Bearded-man.jpg',
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3')
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Alexander Abraham'),
    '02124423694'
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Alexander Abraham'),
    '04124456790'
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Alexander Abraham'),
    'administrador.generico@ucab.edu.ve',
    1
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Alexander Abraham'),
    'plain_administrador@gmail.com',
    0
);

INSERT INTO dbo.PERSONA (
    per_tipo_doc_id,
    per_num_doc_id,
    per_nombre,
    per_apellido ,
    per_nacionalidad,
    per_alergias,
    per_direccion,
    per_sexo,
    per_tipo_sangre,
    per_fecha_nacimiento,
    per_activo,
    per_peso,
    per_estatura,
    per_nombre_usuario,
    per_clave,
    per_imagen,
    DOJO_doj_id
) 
VALUES (
    'CEDULA-N',
    21424696,
    'Freddy Jose',
    'Suarez Romero',
    'Venezolano',
    'Mariscos',
    '2da. Av. de Montalban. Res. Capricornio. Piso 5. Apto. 10',
    'M',
    'A+',
    '2000-05-21',
    1,
    77,
    1.72,
    'suarezadmin',
    '12345',
    'http://www.photographyblogger.net/wp-content/uploads/2013/05/1-jaco-van-den-hoven.jpg',
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-17280493-1')
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Freddy Jose'),
    '02124423694'
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Freddy Jose'),
    '04124456790'
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Freddy Jose'),
    'administrador.generico@ucab.edu.ve',
    1
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Freddy Jose'),
    'plain_administrador@gmail.com',
    0
);

INSERT INTO dbo.PERSONA (
    per_tipo_doc_id,
    per_num_doc_id,
    per_nombre,
    per_apellido ,
    per_nacionalidad,
    per_alergias,
    per_direccion,
    per_sexo,
    per_tipo_sangre,
    per_fecha_nacimiento,
    per_activo,
    per_peso,
    per_estatura,
    per_nombre_usuario,
    per_clave,
    per_imagen,
    DOJO_doj_id
) 
VALUES (
    'CEDULA-N',
    21424696,
    'Javier Porfirio',
    'Torres Contreras',
    'Venezolano',
    'Mariscos',
    '2da. Av. de Montalban. Res. Capricornio. Piso 5. Apto. 10',
    'M',
    'A+',
    '1993-05-21',
    1,
    77,
    1.72,
    'torresadmin',
    '12345',
    'http://st.depositphotos.com/1009647/1293/i/950/depositphotos_12933724-Bearded-man.jpg',
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3')
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Javier Porfirio'),
    '02124423694'
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Javier Porfirio'),
    '04124456790'
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Javier Porfirio'),
    'administrador.generico@ucab.edu.ve',
    1
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Javier Porfirio'),
    'plain_administrador@gmail.com',
    0
);
--FIN--


--------------------------Inserts Personas tipo AdminSistema (Magurno, Rosman)------------------------------

INSERT INTO dbo.PERSONA (
    per_tipo_doc_id,
    per_num_doc_id,
    per_nombre,
    per_apellido ,
    per_nacionalidad,
    per_alergias,
    per_direccion,
    per_sexo,
    per_tipo_sangre,
    per_fecha_nacimiento,
    per_activo,
    per_peso,
    per_estatura,
	per_nombre_usuario,
	per_clave,
	per_imagen,
	DOJO_doj_id

) 
VALUES (
    'CEDULA-N',
    12813521,
    'Carlo',
    'Magurno',
    'Venezolano',
    'Mariscos',
    '3da. Av. de Montalban. Res. Maracaibo. Piso 4. Apto. 4b',
    'M',
    'A+',
    '1983-05-21',
    1,
    77,
    1.72,
    'carloadmin',
    '12345',
	'https://media.licdn.com/media/p/1/005/040/3e7/00ea99f.jpg',
	    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3')

);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Carlo'),
    '02126627843'
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Carlo'),
    '04125536420'
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Carlo'),
    'sistemaadministrador.generico@ucab.edu.ve',
    1
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Carlo'),
    'sistemaplain_administrador@gmail.com',
    0
);


INSERT INTO dbo.PERSONA (
    per_tipo_doc_id,
    per_num_doc_id,
    per_nombre,
    per_apellido ,
    per_nacionalidad,
    per_alergias,
    per_direccion,
    per_sexo,
    per_tipo_sangre,
    per_fecha_nacimiento,
    per_activo,
    per_peso,
    per_estatura,
	per_nombre_usuario,
	per_clave,
    DOJO_doj_id

) 
VALUES (
    'CEDULA-N',
    15673280,
    'Rosman',
    'Torres',
    'Venezolano',
    'Mariscos',
    '3da. Av. de los Palos Grandes. Res. Juanas. Piso 2. Apto. 2c',
    'M',
    'A+',
    '1990-05-21',
    1,
    77,
    1.72,
    'rosmanadmin',
    '12345',
        (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3')

);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Rosman'),
    '02126626345'
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Rosman'),
    '04142156345'
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Rosman'),
    'sistemaadministrador2.generico@ucab.edu.ve',
    1
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Rosman'),
    'sistemaplain_administrador2@gmail.com',
    0
);

INSERT INTO [dbo].[MATRICULA] ([mat_identificador],[mat_fecha_creacion],[mat_activa], [mat_fecha_ultimo_pago], [mat_precio],[PERSONA_per_id], [DOJO_doj_id]) VALUES ('CCA1-CAF-CAFE','2014-12-10',1,'2015-03-08',4200,6,1)
go
-- FIN DEL INSERT PERSONA--


--INSERTS SOLICITUD INSCRIPCION--



--INSERTS DE ROLES--

INSERT INTO  ROL VALUES ('Admin Sistema','El administrador tiene acceso a todo el sistema sin restricción,con la capacidad de dar seguimiento a todo los procesos.' );
INSERT INTO  ROL VALUES ('Admin Organización','El administrador de la organizacion se encarga de gestionar la organización a la cual esta asociado, actualizando agregando y descartando información correspondiente.');
INSERT INTO  ROL VALUES ('Admin Dojo','El administrador del dojo es el encargado de llevar un seguimiento y tener al día la información relevante con respecto al dojo asociado.');
INSERT INTO  ROL VALUES ('Entrenador','El entrenador lleva un seguimiento de los atletas y los eventos realizados en el dojo.');
INSERT INTO  ROL VALUES ('Atleta','El atleta es la persona en formación que recibe clases en un dojo particular.');
INSERT INTO  ROL VALUES ('Representante','El representante como su nombre lo indica es el encargado del atleta menor, con lo cual puede dar seguimiento a las actividades realizadas por el menor.');



--INSERTS PERSONA ROL--

INSERT INTO dbo.PERSONA_ROL  (
per_rol_fecha,
PERSONA_per_id,
ROL_rol_id
)
VALUES (
GETDATE(),
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Carlo'),
(SELECT rol_id from ROL where rol_nombre='Admin Sistema')
);

INSERT INTO dbo.PERSONA_ROL  (
per_rol_fecha,
PERSONA_per_id,
ROL_rol_id
)
VALUES (
GETDATE(),
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Rosman'),
(SELECT rol_id from ROL where rol_nombre='Admin Sistema')
);

INSERT INTO dbo.PERSONA_ROL  (
per_rol_fecha,
PERSONA_per_id,
ROL_rol_id
)
VALUES (
GETDATE(),
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Miguel Alejandro'),
(SELECT rol_id from ROL where rol_nombre='Atleta')
);


INSERT INTO dbo.PERSONA_ROL  (
per_rol_fecha,
PERSONA_per_id,
ROL_rol_id
)
VALUES (
GETDATE(),
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Eduardo'),
(SELECT rol_id from ROL where rol_nombre='Atleta')
);

INSERT INTO dbo.PERSONA_ROL  (
per_rol_fecha,
PERSONA_per_id,
ROL_rol_id
)
VALUES (
GETDATE(),
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Maria Isabel'),
(SELECT rol_id from ROL where rol_nombre='Atleta')
);


INSERT INTO dbo.PERSONA_ROL  (
per_rol_fecha,
PERSONA_per_id,
ROL_rol_id
)
VALUES (
GETDATE(),
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Mario Alejandro'),
(SELECT rol_id from ROL where rol_nombre='Atleta')
);

INSERT INTO dbo.PERSONA_ROL  (
per_rol_fecha,
PERSONA_per_id,
ROL_rol_id
)
VALUES (
GETDATE(),
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Romulo Jose'),
(SELECT rol_id from ROL where rol_nombre='Atleta')
);

INSERT INTO dbo.PERSONA_ROL  (
per_rol_fecha,
PERSONA_per_id,
ROL_rol_id
)
VALUES (
GETDATE(),
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Silfredo Augusto'),
(SELECT rol_id from ROL where rol_nombre='Atleta')
);

INSERT INTO dbo.PERSONA_ROL  (
per_rol_fecha,
PERSONA_per_id,
ROL_rol_id
)
VALUES (
GETDATE(),
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Saul Enrique'),
(SELECT rol_id from ROL where rol_nombre='Atleta')
);

INSERT INTO dbo.PERSONA_ROL  (
per_rol_fecha,
PERSONA_per_id,
ROL_rol_id
)
VALUES (
GETDATE(),
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Guillermo Daniel'),
(SELECT rol_id from ROL where rol_nombre='Atleta')
);

INSERT INTO dbo.PERSONA_ROL  (
per_rol_fecha,
PERSONA_per_id,
ROL_rol_id
)
VALUES (
GETDATE(),
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Pedro Leonardo'),
(SELECT rol_id from ROL where rol_nombre='Atleta')
);

INSERT INTO dbo.PERSONA_ROL  (
per_rol_fecha,
PERSONA_per_id,
ROL_rol_id
)
VALUES (
GETDATE(),
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Jose Miguel'),
(SELECT rol_id from ROL where rol_nombre='Atleta')
);

INSERT INTO dbo.PERSONA_ROL  (
per_rol_fecha,
PERSONA_per_id,
ROL_rol_id
)
VALUES (
GETDATE(),
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Pedro Leonardo'),
(SELECT rol_id from ROL where rol_nombre='Entrenador')
);

INSERT INTO dbo.PERSONA_ROL  (
per_rol_fecha,
PERSONA_per_id,
ROL_rol_id
)
VALUES (
GETDATE(),
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Jose Miguel'),
(SELECT rol_id from ROL where rol_nombre='Entrenador')
);

INSERT INTO dbo.PERSONA_ROL  (
per_rol_fecha,
PERSONA_per_id,
ROL_rol_id
)
VALUES (
GETDATE(),
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Alexander Abraham'),
(SELECT rol_id from ROL where rol_nombre='Admin Dojo')
);

INSERT INTO dbo.PERSONA_ROL  (
per_rol_fecha,
PERSONA_per_id,
ROL_rol_id
)
VALUES (
GETDATE(),
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Carlos Alberto'),
(SELECT rol_id from ROL where rol_nombre='Admin Dojo')
);

INSERT INTO dbo.PERSONA_ROL  (
per_rol_fecha,
PERSONA_per_id,
ROL_rol_id
)
VALUES (
GETDATE(),
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Javier Porfirio'),
(SELECT rol_id from ROL where rol_nombre='Admin Dojo')
);


INSERT INTO dbo.PERSONA_ROL  (
per_rol_fecha,
PERSONA_per_id,
ROL_rol_id
)
VALUES (
GETDATE(),
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Adriana Josefina'),
(SELECT rol_id from ROL where rol_nombre='Atleta')
);

INSERT INTO dbo.PERSONA_ROL  (
per_rol_fecha,
PERSONA_per_id,
ROL_rol_id
)
VALUES (
GETDATE(),
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Christian Jose'),
(SELECT rol_id from ROL where rol_nombre='Atleta')
);

INSERT INTO dbo.PERSONA_ROL  (
per_rol_fecha,
PERSONA_per_id,
ROL_rol_id
)
VALUES (
GETDATE(),
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Cesar Augusto'),
(SELECT rol_id from ROL where rol_nombre='Atleta')
);

INSERT INTO dbo.PERSONA_ROL  (
per_rol_fecha,
PERSONA_per_id,
ROL_rol_id
)
VALUES (
GETDATE(),
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Jesus Enrique'),
(SELECT rol_id from ROL where rol_nombre='Atleta')
);

INSERT INTO dbo.PERSONA_ROL  (
per_rol_fecha,
PERSONA_per_id,
ROL_rol_id
)
VALUES (
GETDATE(),
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Gustavo Antonio'),
(SELECT rol_id from ROL where rol_nombre='Atleta')
);

INSERT INTO dbo.PERSONA_ROL  (
per_rol_fecha,
PERSONA_per_id,
ROL_rol_id
)
VALUES (
GETDATE(),
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Jessica Alejandra'),
(SELECT rol_id from ROL where rol_nombre='Atleta')
);

INSERT INTO dbo.PERSONA_ROL  (
per_rol_fecha,
PERSONA_per_id,
ROL_rol_id
)
VALUES (
GETDATE(),
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Maria Antonieta'),
(SELECT rol_id from ROL where rol_nombre='Atleta')
);

INSERT INTO dbo.PERSONA_ROL  (
per_rol_fecha,
PERSONA_per_id,
ROL_rol_id
)
VALUES (
GETDATE(),
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Victoria Isabella'),
(SELECT rol_id from ROL where rol_nombre='Atleta')
);

INSERT INTO dbo.PERSONA_ROL  (
per_rol_fecha,
PERSONA_per_id,
ROL_rol_id
)
VALUES (
GETDATE(),
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Melissa Nathalie'),
(SELECT rol_id from ROL where rol_nombre='Atleta')
);

INSERT INTO dbo.PERSONA_ROL  (
per_rol_fecha,
PERSONA_per_id,
ROL_rol_id
)
VALUES (
GETDATE(),
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Elizabeth Antonia'),
(SELECT rol_id from ROL where rol_nombre='Atleta')
);

INSERT INTO dbo.PERSONA_ROL  (
per_rol_fecha,
PERSONA_per_id,
ROL_rol_id
)
VALUES (
GETDATE(),
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Marco Alejandro'),
(SELECT rol_id from ROL where rol_nombre='Atleta')
);

INSERT INTO dbo.PERSONA_ROL  (
per_rol_fecha,
PERSONA_per_id,
ROL_rol_id
)
VALUES (
GETDATE(),
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Jose Gregorio'),
(SELECT rol_id from ROL where rol_nombre='Atleta')
);

INSERT INTO dbo.PERSONA_ROL  (
per_rol_fecha,
PERSONA_per_id,
ROL_rol_id
)
VALUES (
GETDATE(),
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Luis Armando'),
(SELECT rol_id from ROL where rol_nombre='Atleta')
);

INSERT INTO dbo.PERSONA_ROL  (
per_rol_fecha,
PERSONA_per_id,
ROL_rol_id
)
VALUES (
GETDATE(),
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Federico Ernesto'),
(SELECT rol_id from ROL where rol_nombre='Atleta')
);

INSERT INTO dbo.PERSONA_ROL  (
per_rol_fecha,
PERSONA_per_id,
ROL_rol_id
)
VALUES (
GETDATE(),
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Liu Wa'),
(SELECT rol_id from ROL where rol_nombre='Atleta')
);

INSERT INTO dbo.PERSONA_ROL  (
per_rol_fecha,
PERSONA_per_id,
ROL_rol_id
)
VALUES (
GETDATE(),
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Marta Carolina'),
(SELECT rol_id from ROL where rol_nombre='Atleta')
);

INSERT INTO dbo.PERSONA_ROL  (
per_rol_fecha,
PERSONA_per_id,
ROL_rol_id
)
VALUES (
GETDATE(),
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Patricia Elena'),
(SELECT rol_id from ROL where rol_nombre='Atleta')
);

INSERT INTO dbo.PERSONA_ROL  (
per_rol_fecha,
PERSONA_per_id,
ROL_rol_id
)
VALUES (
GETDATE(),
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Neolida Margarita'),
(SELECT rol_id from ROL where rol_nombre='Atleta')
);

INSERT INTO dbo.PERSONA_ROL  (
per_rol_fecha,
PERSONA_per_id,
ROL_rol_id
)
VALUES (
GETDATE(),
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Nora Margarita'),
(SELECT rol_id from ROL where rol_nombre='Atleta')
);

INSERT INTO dbo.PERSONA_ROL  (
per_rol_fecha,
PERSONA_per_id,
ROL_rol_id
)
VALUES (
GETDATE(),
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Sabrina'),
(SELECT rol_id from ROL where rol_nombre='Atleta')
);


INSERT INTO dbo.PERSONA_ROL  (
per_rol_fecha,
PERSONA_per_id,
ROL_rol_id
)
VALUES (
GETDATE(),
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Freddy Jose'),
(SELECT rol_id from ROL where rol_nombre='Atleta')
);

-- INSERTS IMPLEMENTO--

insert into implemento (imp_imagen,imp_nombre,imp_tipo,imp_marca,imp_color,imp_talla,imp_estatus,imp_precio,imp_stockmin,imp_descripcion) 
values('~/GUI/Modulo15/Imagenes/guantes.jpg','Guantines Karate-DO','Guantines','Kombate','Azul','S','Activo',4500,5,'Guantines para Karate-DO');
insert into implemento (imp_imagen,imp_nombre,imp_tipo,imp_marca,imp_color,imp_talla,imp_estatus,imp_precio,imp_stockmin,imp_descripcion) 
values('~/GUI/Modulo15/Imagenes/karategi.jpg','Karate Gi Karate-DO','Karate Gi','Adidas','Blanco','S','Activo',3000,5,'Karate Gi para Karate-DO');
insert into implemento (imp_imagen,imp_nombre,imp_tipo,imp_marca,imp_color,imp_talla,imp_estatus,imp_precio,imp_stockmin,imp_descripcion) 
values('~/GUI/Modulo15/Imagenes/espinilleras.jpg', 'Espinilleras Karate-DO','Espinilleras','Adidas','Azul','S','Activo',4500,5,'Espinilleras para Karate-DO');
insert into implemento (imp_imagen,imp_nombre,imp_tipo,imp_marca,imp_color,imp_talla,imp_estatus,imp_precio,imp_stockmin,imp_descripcion) 
values('~/GUI/Modulo15/Imagenes/cinta.jpg', 'Cinta Karate-DO','Cinta','Adidas','Amarillo','M','Activo',1200,10,'Cinta para Karate-DO');
insert into implemento (imp_imagen,imp_nombre,imp_tipo,imp_marca,imp_color,imp_talla,imp_estatus,imp_precio,imp_stockmin,imp_descripcion) 
values('~/GUI/Modulo15/Imagenes/coderas.jpg', 'Coderas Karate-DO','Coderas','Kombate','Rojo','M','Activo',5000,5,'Coderas para Karate-DO');



-- INSERTS INVENTARIO--

insert into inventario (inv_cantidad_total,IMPLEMENTO_imp_id,DOJO_doj_id) values (45,1,1);
insert into inventario (inv_cantidad_total,IMPLEMENTO_imp_id,DOJO_doj_id) values (19,2,1);
insert into inventario (inv_cantidad_total,IMPLEMENTO_imp_id,DOJO_doj_id) values (75,3,1);
insert into inventario (inv_cantidad_total,IMPLEMENTO_imp_id,DOJO_doj_id) values (95,4,1);
insert into inventario (inv_cantidad_total,IMPLEMENTO_imp_id,DOJO_doj_id) values (6,5,1);

insert into inventario (inv_cantidad_total,IMPLEMENTO_imp_id,DOJO_doj_id) values (4,1,2);
insert into inventario (inv_cantidad_total,IMPLEMENTO_imp_id,DOJO_doj_id) values (70,2,2);
insert into inventario (inv_cantidad_total,IMPLEMENTO_imp_id,DOJO_doj_id) values (64,3,2);
insert into inventario (inv_cantidad_total,IMPLEMENTO_imp_id,DOJO_doj_id) values (27,4,2);
insert into inventario (inv_cantidad_total,IMPLEMENTO_imp_id,DOJO_doj_id) values (93,5,2);

insert into inventario (inv_cantidad_total,IMPLEMENTO_imp_id,DOJO_doj_id) values (84,1,3);
insert into inventario (inv_cantidad_total,IMPLEMENTO_imp_id,DOJO_doj_id) values (29,2,3);
insert into inventario (inv_cantidad_total,IMPLEMENTO_imp_id,DOJO_doj_id) values (15,3,3);
insert into inventario (inv_cantidad_total,IMPLEMENTO_imp_id,DOJO_doj_id) values (26,4,3);
insert into inventario (inv_cantidad_total,IMPLEMENTO_imp_id,DOJO_doj_id) values (7,5,3);

insert into inventario (inv_cantidad_total,IMPLEMENTO_imp_id,DOJO_doj_id) values (18,1,4);
insert into inventario (inv_cantidad_total,IMPLEMENTO_imp_id,DOJO_doj_id) values (46,2,4);
insert into inventario (inv_cantidad_total,IMPLEMENTO_imp_id,DOJO_doj_id) values (33,3,4);
insert into inventario (inv_cantidad_total,IMPLEMENTO_imp_id,DOJO_doj_id) values (11,4,4);
insert into inventario (inv_cantidad_total,IMPLEMENTO_imp_id,DOJO_doj_id) values (17,5,4);

insert into inventario (inv_cantidad_total,IMPLEMENTO_imp_id,DOJO_doj_id) values (12,1,5);
insert into inventario (inv_cantidad_total,IMPLEMENTO_imp_id,DOJO_doj_id) values (49,2,5);
insert into inventario (inv_cantidad_total,IMPLEMENTO_imp_id,DOJO_doj_id) values (22,3,5);
insert into inventario (inv_cantidad_total,IMPLEMENTO_imp_id,DOJO_doj_id) values (13,4,5);
insert into inventario (inv_cantidad_total,IMPLEMENTO_imp_id,DOJO_doj_id) values (4,5,5);


-- INSERTS PLA_DAT--


INSERT INTO PLA_DAT (DATO_dat_id,PLANILLA_pla_id) values (1,1);
INSERT INTO PLA_DAT (DATO_dat_id,PLANILLA_pla_id) values (1,2);
INSERT INTO PLA_DAT (DATO_dat_id,PLANILLA_pla_id) values (1,3);
INSERT INTO PLA_DAT (DATO_dat_id,PLANILLA_pla_id) values (2,1);
INSERT INTO PLA_DAT (DATO_dat_id,PLANILLA_pla_id) values (3,1);
INSERT INTO PLA_DAT (DATO_dat_id,PLANILLA_pla_id) values (4,3);
INSERT INTO PLA_DAT (DATO_dat_id,PLANILLA_pla_id) values (2,4);


-- INSERTS RELACION--







-- INSERTS RESTRICCION CINTA--

  INSERT INTO dbo.RESTRICCION_CINTA (
    res_cin_descripcion,
    res_cin_tiemp_min,
    res_cin_punt_min,
    res_cin_horas_docent,
    CINTA_cin_id
    ) 
    VALUES ('BLANCA A AMARILLA',3,20,0,2);
    
    INSERT INTO dbo.RESTRICCION_CINTA (

    res_cin_descripcion,
    res_cin_tiemp_min,
    res_cin_punt_min,
    res_cin_horas_docent,
    CINTA_cin_id
    ) 
    VALUES ('AMARILLA A NARANJA',5,40,0,3);
    
    INSERT INTO dbo.RESTRICCION_CINTA (

    res_cin_descripcion,
    res_cin_tiemp_min,
    res_cin_punt_min,
    res_cin_horas_docent,
    CINTA_cin_id
    ) 
    VALUES ('NARANJA A VERDE',7,80,0,4);
    
    INSERT INTO dbo.RESTRICCION_CINTA (

    res_cin_descripcion,
    res_cin_tiemp_min,
    res_cin_punt_min,
    res_cin_horas_docent,
    CINTA_cin_id
    ) 
    VALUES ('VERDE A AZUL',10,160,2,5);
    
    INSERT INTO dbo.RESTRICCION_CINTA (

    res_cin_descripcion,
    res_cin_tiemp_min,
    res_cin_punt_min,
    res_cin_horas_docent,
    CINTA_cin_id
    ) 
    VALUES ('AZUL A MARRON',10,320,4,6);
    
    INSERT INTO dbo.RESTRICCION_CINTA (

    res_cin_descripcion,
    res_cin_tiemp_min,
    res_cin_punt_min,
    res_cin_horas_docent,
    CINTA_cin_id
    ) 
    VALUES ('MARRON A MARRON',12,640,6,7);
    
    INSERT INTO dbo.RESTRICCION_CINTA (

    res_cin_descripcion,
    res_cin_tiemp_min,
    res_cin_punt_min,
    res_cin_horas_docent,
    CINTA_cin_id
    ) 
    VALUES ('MARRON A NEGRA',12,1280,9,8);



--INSERTS TIPO PERIODO--







-- INSERTS RESTRICCION COMPETENCIA--

INSERT INTO [dbo].[RESTRICCION_COMPETENCIA] ([res_com_desc], [res_com_edad_min], [res_com_edad_max], [res_com_rango_min], [res_com_rango_max], [res_com_sexo], [res_com_modalidad]) VALUES
('Rest. Competencia de 12 a 17 años todas las cintas unisex Kata',12,17,1,20,'B','Todas');

INSERT INTO [dbo].[RESTRICCION_COMPETENCIA] ([res_com_desc], [res_com_edad_min], [res_com_edad_max], [res_com_rango_min], [res_com_rango_max], [res_com_sexo], [res_com_modalidad]) VALUES
('Rest. Competencia de 6 a 11 años todas las cintas unisex Kata',6,11,1,20,'B','kata');

INSERT INTO [dbo].[RESTRICCION_COMPETENCIA] ([res_com_desc], [res_com_edad_min], [res_com_edad_max], [res_com_rango_min], [res_com_rango_max], [res_com_sexo], [res_com_modalidad]) VALUES
('Rest. Competencia de 18 a 25 años todas las cintas unisex Kata',18,25,1,20,'B','Todas');

-- INSERTS RESTRICCION EVENTO--

insert into RESTRICCION_EVENTO values ('Rest. evento evento1 de 18 a 25 años solo masculino',18,25,'m',1);
insert into RESTRICCION_EVENTO values ('Rest. evento evento2 de 18 a 20 años solo femenino',18,20,'f',2);
insert into RESTRICCION_EVENTO values ('Rest. evento evento3 de 20 a 25 años sexo combinado',20,25,'c',3);
insert into RESTRICCION_EVENTO values ('Rest. evento evento4 de 20 a 25 años sexo combinado',20,25,'c',4);

-- INSERTS RC_CINTA --

INSERT INTO [dbo].[RC_CINTA] ([RESTRICCION_COMPETENCIA_res_com_id], [CINTA_cin_id]) VALUES
(1,1);

INSERT INTO [dbo].[RC_CINTA] ([RESTRICCION_COMPETENCIA_res_com_id], [CINTA_cin_id]) VALUES
(1,2);

INSERT INTO [dbo].[RC_CINTA] ([RESTRICCION_COMPETENCIA_res_com_id], [CINTA_cin_id]) VALUES
(1,3);

INSERT INTO [dbo].[RC_CINTA] ([RESTRICCION_COMPETENCIA_res_com_id], [CINTA_cin_id]) VALUES
(1,4);

INSERT INTO [dbo].[RC_CINTA] ([RESTRICCION_COMPETENCIA_res_com_id], [CINTA_cin_id]) VALUES
(2,5);

INSERT INTO [dbo].[RC_CINTA] ([RESTRICCION_COMPETENCIA_res_com_id], [CINTA_cin_id]) VALUES
(2,6);

INSERT INTO [dbo].[RC_CINTA] ([RESTRICCION_COMPETENCIA_res_com_id], [CINTA_cin_id]) VALUES
(2,1);

INSERT INTO [dbo].[RC_CINTA] ([RESTRICCION_COMPETENCIA_res_com_id], [CINTA_cin_id]) VALUES
(2,2);


-- INSERTS RH_CINTA --

insert into RH_CINTA values (1,1);
insert into RH_CINTA values (1,2);
insert into RH_CINTA values (2,2);
insert into RH_CINTA values (2,3);
insert into RH_CINTA values (3,4);
insert into RH_CINTA values (4,5);
insert into RH_CINTA values (4,7);

-- INSERTS HISTORIAL CINTAS--

INSERT INTO	HISTORIAL_CINTAS	VALUES	(	1	,	NULL	,	'2015-05-20'	,	1	);
INSERT INTO	HISTORIAL_CINTAS	VALUES	(	3	,	NULL	,	'2015-04-10'	,	1	);
INSERT INTO	HISTORIAL_CINTAS	VALUES	(	4	,	NULL	,	'2015-03-15'	,	1	);
INSERT INTO	HISTORIAL_CINTAS	VALUES	(	5	,	NULL	,	'2015-01-27'	,	1	);
INSERT INTO	HISTORIAL_CINTAS	VALUES	(	8	,	NULL	,	'2015-03-04'	,	1	);
INSERT INTO	HISTORIAL_CINTAS	VALUES	(	9	,	NULL	,	'2015-05-11'	,	1	);
INSERT INTO	HISTORIAL_CINTAS	VALUES	(	12	,	NULL	,	'2015-05-14'	,	1	);
INSERT INTO	HISTORIAL_CINTAS	VALUES	(	33	,	NULL	,	'2015-05-13'	,	1	);
INSERT INTO	HISTORIAL_CINTAS	VALUES	(	2	,	NULL	,	'2015-02-19'	,	1	);
INSERT INTO	HISTORIAL_CINTAS	VALUES	(	6	,	NULL	,	'2015-02-10'	,	1	);
INSERT INTO	HISTORIAL_CINTAS	VALUES	(	10	,	NULL	,	'2015-01-01'	,	1	);
INSERT INTO	HISTORIAL_CINTAS	VALUES	(	18	,	3	,	'2015-11-15'	,	2	);
INSERT INTO	HISTORIAL_CINTAS	VALUES	(	19	,	3	,	'2015-11-15'	,	2	);
INSERT INTO	HISTORIAL_CINTAS	VALUES	(	20	,	3	,	'2015-11-15'	,	2	);
INSERT INTO	HISTORIAL_CINTAS	VALUES	(	21	,	3	,	'2015-11-15'	,	2	);
INSERT INTO	HISTORIAL_CINTAS	VALUES	(	27	,	3	,	'2015-11-15'	,	2	);
INSERT INTO	HISTORIAL_CINTAS	VALUES	(	11	,	3	,	'2015-11-15'	,	2	);
INSERT INTO	HISTORIAL_CINTAS	VALUES	(	13	,	3	,	'2015-11-15'	,	2	);
INSERT INTO	HISTORIAL_CINTAS	VALUES	(	14	,	3	,	'2015-11-15'	,	2	);
INSERT INTO	HISTORIAL_CINTAS	VALUES	(	15	,	3	,	'2015-11-15'	,	2	);
INSERT INTO	HISTORIAL_CINTAS	VALUES	(	16	,	3	,	'2015-11-15'	,	2	);
INSERT INTO	HISTORIAL_CINTAS	VALUES	(	17	,	3	,	'2015-11-15'	,	2	);
INSERT INTO	HISTORIAL_CINTAS	VALUES	(	22	,	3	,	'2015-11-15'	,	2	);
INSERT INTO	HISTORIAL_CINTAS	VALUES	(	23	,	3	,	'2015-11-15'	,	2	);
INSERT INTO	HISTORIAL_CINTAS	VALUES	(	24	,	3	,	'2015-11-15'	,	2	);
INSERT INTO	HISTORIAL_CINTAS	VALUES	(	25	,	3	,	'2015-11-15'	,	2	);
INSERT INTO	HISTORIAL_CINTAS	VALUES	(	26	,	3	,	'2015-11-15'	,	2	);
INSERT INTO	HISTORIAL_CINTAS	VALUES	(	28	,	NULL	,	'2015-05-20'	,	1	);
INSERT INTO	HISTORIAL_CINTAS	VALUES	(	29	,	NULL	,	'2015-04-10'	,	1	);
INSERT INTO	HISTORIAL_CINTAS	VALUES	(	30	,	NULL	,	'2015-03-15'	,	1	);
INSERT INTO	HISTORIAL_CINTAS	VALUES	(	31	,	NULL	,	'2015-01-27'	,	1	);
INSERT INTO	HISTORIAL_CINTAS	VALUES	(	6	,	NULL	,	'2015-08-21'	,	2	);



-- INSERTS INSCRIPCION--
INSERT INTO	INSCRIPCION	VALUES	(	1	,	'2015-05-20'	,	5	,	NULL	);
INSERT INTO	INSCRIPCION	VALUES	(	1	,	'2015-04-10'	,	NULL	,	2	);
INSERT INTO	INSCRIPCION	VALUES	(	1	,	'2015-05-10'	,	1	,	NULL);
INSERT INTO	INSCRIPCION	VALUES	(	2	,	'2015-03-15'	,	4	,	NULL	);
INSERT INTO	INSCRIPCION	VALUES	(	2	,	'2015-01-27'	,	NULL	,	1	);
INSERT INTO	INSCRIPCION	VALUES	(	2	,	'2015-03-04'	,	NULL	,	3	);

INSERT INTO	INSCRIPCION	VALUES	(	1	,	'2015-05-20'	,	5	,	NULL	);
INSERT INTO	INSCRIPCION	VALUES	(	3	,	'2015-04-10'	,	5	,	NULL	);
INSERT INTO	INSCRIPCION	VALUES	(	4	,	'2015-03-15'	,	5	,	NULL	);
INSERT INTO	INSCRIPCION	VALUES	(	5	,	'2015-01-27'	,	5	,	NULL	);
INSERT INTO	INSCRIPCION	VALUES	(	8	,	'2015-03-04'	,	5	,	NULL	);
INSERT INTO	INSCRIPCION	VALUES	(	9	,	'2015-05-11'	,	5	,	NULL	);
INSERT INTO	INSCRIPCION	VALUES	(	12	,	'2015-05-14'	,	5	,	NULL	);
INSERT INTO	INSCRIPCION	VALUES	(	33	,	'2015-05-13'	,	5	,	NULL	);
INSERT INTO	INSCRIPCION	VALUES	(	2	,	'2015-02-19'	,	6	,	NULL	);
INSERT INTO	INSCRIPCION	VALUES	(	6	,	'2015-02-10'	,	6	,	NULL	);
INSERT INTO	INSCRIPCION	VALUES	(	10	,	'2015-01-01'	,	6	,	NULL	);
INSERT INTO	INSCRIPCION	VALUES	(	18	,	'2014-11-27'	,	6	,	NULL	);
INSERT INTO	INSCRIPCION	VALUES	(	19	,	'2014-12-11'	,	6	,	NULL	);
INSERT INTO	INSCRIPCION	VALUES	(	20	,	'2015-02-20'	,	6	,	NULL	);
INSERT INTO	INSCRIPCION	VALUES	(	21	,	'2015-02-03'	,	6	,	NULL	);
INSERT INTO	INSCRIPCION	VALUES	(	27	,	'2015-02-16'	,	6	,	NULL	);
INSERT INTO	INSCRIPCION	VALUES	(	28	,	'2015-05-13'	,	6	,	NULL	);
INSERT INTO	INSCRIPCION	VALUES	(	29	,	'2015-02-19'	,	6	,	NULL	);
INSERT INTO	INSCRIPCION	VALUES	(	30	,	'2015-02-10'	,	6	,	NULL	);
INSERT INTO	INSCRIPCION	VALUES	(	31	,	'2015-01-01'	,	6	,	NULL	);
INSERT INTO	INSCRIPCION	VALUES	(	11	,	'2015-09-21'	,	7	,	NULL	);
INSERT INTO	INSCRIPCION	VALUES	(	13	,	'2015-04-30'	,	7	,	NULL	);
INSERT INTO	INSCRIPCION	VALUES	(	14	,	'2015-02-21'	,	7	,	NULL	);
INSERT INTO	INSCRIPCION	VALUES	(	15	,	'2015-01-15'	,	7	,	NULL	);
INSERT INTO	INSCRIPCION	VALUES	(	16	,	'2015-05-01'	,	7	,	NULL	);
INSERT INTO	INSCRIPCION	VALUES	(	17	,	'2015-06-23'	,	7	,	NULL	);
INSERT INTO	INSCRIPCION	VALUES	(	22	,	'2015-09-21'	,	7	,	NULL	);
INSERT INTO	INSCRIPCION	VALUES	(	23	,	'2015-07-16'	,	7	,	NULL	);
INSERT INTO	INSCRIPCION	VALUES	(	24	,	'2015-02-18'	,	7	,	NULL	);
INSERT INTO	INSCRIPCION	VALUES	(	25	,	'2015-08-22'	,	7	,	NULL	);
INSERT INTO	INSCRIPCION	VALUES	(	26	,	'2015-09-11'	,	7	,	NULL	);
INSERT INTO	INSCRIPCION	VALUES	(	18	,	'2015-05-20'	,	NULL	,	3	);
INSERT INTO	INSCRIPCION	VALUES	(	19	,	'2015-04-10'	,	NULL	,	3	);
INSERT INTO	INSCRIPCION	VALUES	(	20	,	'2015-03-15'	,	NULL	,	3	);
INSERT INTO	INSCRIPCION	VALUES	(	21	,	'2015-01-27'	,	NULL	,	3	);
INSERT INTO	INSCRIPCION	VALUES	(	27	,	'2015-03-04'	,	NULL	,	3	);
INSERT INTO	INSCRIPCION	VALUES	(	11	,	'2015-05-11'	,	NULL	,	3	);
INSERT INTO	INSCRIPCION	VALUES	(	13	,	'2015-05-14'	,	NULL	,	3	);
INSERT INTO	INSCRIPCION	VALUES	(	14	,	'2015-05-13'	,	NULL	,	3	);
INSERT INTO	INSCRIPCION	VALUES	(	15	,	'2015-02-19'	,	NULL	,	3	);
INSERT INTO	INSCRIPCION	VALUES	(	16	,	'2015-02-10'	,	NULL	,	3	);
INSERT INTO	INSCRIPCION	VALUES	(	17	,	'2015-01-01'	,	NULL	,	3	);
INSERT INTO	INSCRIPCION	VALUES	(	22	,	'2014-11-27'	,	NULL	,	3	);
INSERT INTO	INSCRIPCION	VALUES	(	23	,	'2014-12-11'	,	NULL	,	3	);
INSERT INTO	INSCRIPCION	VALUES	(	24	,	'2015-02-20'	,	NULL	,	3	);
INSERT INTO	INSCRIPCION	VALUES	(	25	,	'2015-02-03'	,	NULL	,	3	);
INSERT INTO	INSCRIPCION	VALUES	(	26	,	'2015-02-16'	,	NULL	,	3	);
INSERT INTO	INSCRIPCION	VALUES	(	14	,	'2015-09-21'	,	NULL	,	1	);
INSERT INTO	INSCRIPCION	VALUES	(	16	,	'2015-04-30'	,	NULL	,	1	);
INSERT INTO	INSCRIPCION	VALUES	(	3	,	'2015-02-21'	,	NULL	,	1	);
INSERT INTO	INSCRIPCION	VALUES	(	5	,	'2015-01-15'	,	NULL	,	1	);
INSERT INTO	INSCRIPCION	VALUES	(	25	,	'2015-05-01'	,	NULL	,	1	);
INSERT INTO	INSCRIPCION	VALUES	(	13	,	'2015-06-23'	,	NULL	,	1	);
INSERT INTO	INSCRIPCION	VALUES	(	1	,	'2015-09-21'	,	NULL	,	1	);
INSERT INTO	INSCRIPCION	VALUES	(	23	,	'2015-07-16'	,	NULL	,	1	);
INSERT INTO	INSCRIPCION	VALUES	(	26	,	'2015-02-18'	,	NULL	,	1	);
INSERT INTO	INSCRIPCION	VALUES	(	24	,	'2015-08-22'	,	NULL	,	1	);
INSERT INTO	INSCRIPCION	VALUES	(	22	,	'2015-09-11'	,	NULL	,	1	);
INSERT INTO	INSCRIPCION	VALUES	(	17	,	'2015-05-20'	,	NULL	,	1	);
INSERT INTO INSCRIPCION VALUES (6,'2015-02-10',NULL,5); 
INSERT INTO INSCRIPCION VALUES (6,'2015-04-05',NULL,6); 
INSERT INTO INSCRIPCION VALUES (6,'2015-05-01',NULL,7); 
INSERT INTO INSCRIPCION VALUES (6,'2015-07-15',NULL,8); 
INSERT INTO INSCRIPCION VALUES (6,'2015-07-22',NULL,9); 
INSERT INTO INSCRIPCION VALUES (6,'2014-02-13',8,NULL); 
INSERT INTO INSCRIPCION VALUES (6,'2015-09-17',NULL,10); 
INSERT INTO INSCRIPCION VALUES (6,'2015-09-17',NULL,11);
INSERT INTO INSCRIPCION VALUES (6,'2015-09-17',NULL,12);
INSERT INTO INSCRIPCION VALUES (6,'2015-07-10',NULL,13);
INSERT INTO INSCRIPCION VALUES (6,'2015-10-09',NULL,14);
INSERT INTO INSCRIPCION VALUES (6,'2015-05-07',NULL,15);
INSERT INTO INSCRIPCION VALUES (6,'2015-06-17',9,NULL);
INSERT INTO INSCRIPCION VALUES (6,'2015-07-10',4,4);
INSERT INTO INSCRIPCION VALUES (6,'2015-07-10',2,10);
INSERT INTO INSCRIPCION VALUES (6,'2015-07-10',6,7);


-- INSERTS SOLICITUD PLANILLA--

INSERT INTO SOLICITUD_PLANILLA (sol_pla_fecha_Creacion,sol_pla_fecha_retiro,sol_pla_fecha_reincorporacion,sol_pla_motivo,PLANILLA_pla_id,INSCRIPCION_ins_id) values ('2015-01-02','2015-02-11','2015-02-12','ENFERMEDAD',3,1);
INSERT INTO SOLICITUD_PLANILLA (sol_pla_fecha_Creacion,sol_pla_fecha_retiro,sol_pla_fecha_reincorporacion,sol_pla_motivo,PLANILLA_pla_id,INSCRIPCION_ins_id) values ('2014-08-23','2014-08-26','2015-09-27','VACACIONES',4,2);
INSERT INTO SOLICITUD_PLANILLA (sol_pla_fecha_Creacion,sol_pla_fecha_retiro,sol_pla_fecha_reincorporacion,sol_pla_motivo,PLANILLA_pla_id,INSCRIPCION_ins_id) values ('2013-12-21','2014-01-08','2014-09-01','FAMILIAR',5,2);
INSERT INTO SOLICITUD_PLANILLA (sol_pla_fecha_Creacion,sol_pla_fecha_retiro,sol_pla_fecha_reincorporacion,sol_pla_motivo,PLANILLA_pla_id,INSCRIPCION_ins_id) values ('2015-03-13','2015-03-03','2015-09-01','FAMILIAR',1,17);
INSERT INTO SOLICITUD_PLANILLA (sol_pla_fecha_Creacion,sol_pla_fecha_retiro,sol_pla_fecha_reincorporacion,sol_pla_motivo,PLANILLA_pla_id,INSCRIPCION_ins_id) values ('2015-01-11','2015-01-09','2015-10-19','ENFERMEDAD',1,18);
INSERT INTO SOLICITUD_PLANILLA (sol_pla_fecha_Creacion,sol_pla_fecha_retiro,sol_pla_fecha_reincorporacion,sol_pla_motivo,PLANILLA_pla_id,INSCRIPCION_ins_id) values ('2015-01-02','2014-12-18','2015-09-01','FAMILIAR',1,19);
INSERT INTO SOLICITUD_PLANILLA (sol_pla_fecha_Creacion,sol_pla_fecha_retiro,sol_pla_fecha_reincorporacion,sol_pla_motivo,PLANILLA_pla_id,INSCRIPCION_ins_id) values ('2014-12-01','2014-11-08','2015-08-01','VACACIONES',1,20);


-- INSERTS RESULTADO ASCENSO--

INSERT INTO	RESULTADO_ASCENSO	VALUES	(	1	,	'S'	,	32	);
INSERT INTO	RESULTADO_ASCENSO	VALUES	(	2	,	'S'	,	33	);
INSERT INTO	RESULTADO_ASCENSO	VALUES	(	3	,	'S'	,	34	);
INSERT INTO	RESULTADO_ASCENSO	VALUES	(	4	,	'S'	,	35	);
INSERT INTO	RESULTADO_ASCENSO	VALUES	(	5	,	'S'	,	36	);
INSERT INTO	RESULTADO_ASCENSO	VALUES	(	6	,	'S'	,	37	);
INSERT INTO	RESULTADO_ASCENSO	VALUES	(	7	,	'S'	,	38	);
INSERT INTO	RESULTADO_ASCENSO	VALUES	(	8	,	'S'	,	39	);
INSERT INTO	RESULTADO_ASCENSO	VALUES	(	9	,	'S'	,	40	);
INSERT INTO	RESULTADO_ASCENSO	VALUES	(	10	,	'S'	,	41	);
INSERT INTO	RESULTADO_ASCENSO	VALUES	(	11	,	'S'	,	42	);
INSERT INTO	RESULTADO_ASCENSO	VALUES	(	12	,	'S'	,	43	);
INSERT INTO	RESULTADO_ASCENSO	VALUES	(	13	,	'S'	,	44	);
INSERT INTO	RESULTADO_ASCENSO	VALUES	(	14	,	'S'	,	45	);
INSERT INTO	RESULTADO_ASCENSO	VALUES	(	15	,	'S'	,	46	);
INSERT INTO	RESULTADO_ASCENSO	VALUES	(	16	,	'S'	,	47	);








-- INSERTS RESULTADO KATA--

INSERT INTO	RESULTADO_KATA	VALUES	(	1	,	7	,	10	,	3	,	1	);
INSERT INTO	RESULTADO_KATA	VALUES	(	2	,	6	,	9	,	5	,	2	);
INSERT INTO	RESULTADO_KATA	VALUES	(	3	,	3	,	5	,	2	,	3	);
INSERT INTO	RESULTADO_KATA	VALUES	(	4	,	5	,	8	,	7	,	4	);
INSERT INTO	RESULTADO_KATA	VALUES	(	5	,	10	,	5	,	10	,	5	);
INSERT INTO	RESULTADO_KATA	VALUES	(	6	,	2	,	4	,	5	,	6	);
INSERT INTO	RESULTADO_KATA	VALUES	(	7	,	7	,	10	,	8	,	7	);
INSERT INTO	RESULTADO_KATA	VALUES	(	8	,	9	,	7	,	5	,	8	);
INSERT INTO	RESULTADO_KATA	VALUES	(	9	,	8	,	3	,	6	,	17	);
INSERT INTO	RESULTADO_KATA	VALUES	(	10	,	10	,	3	,	9	,	18	);
INSERT INTO	RESULTADO_KATA	VALUES	(	11	,	2	,	8	,	7	,	19	);
INSERT INTO	RESULTADO_KATA	VALUES	(	12	,	3	,	6	,	4	,	20	);
INSERT INTO	RESULTADO_KATA	VALUES	(	13	,	10	,	1	,	4	,	21	);
INSERT INTO	RESULTADO_KATA	VALUES	(	14	,	1	,	9	,	9	,	22	);
INSERT INTO	RESULTADO_KATA	VALUES	(	15	,	9	,	1	,	4	,	23	);
INSERT INTO	RESULTADO_KATA	VALUES	(	16	,	9	,	7	,	9	,	24	);





-- INSERTS RESULTADO KUMITE--

INSERT INTO	RESULTADO_KUMITE	VALUES	(	1	,	5	,	9	,	9	,	11	);
INSERT INTO	RESULTADO_KUMITE	VALUES	(	2	,	6	,	3	,	10	,	15	);
INSERT INTO	RESULTADO_KUMITE	VALUES	(	3	,	7	,	8	,	12	,	13	);
INSERT INTO	RESULTADO_KUMITE	VALUES	(	4	,	5	,	3	,	14	,	16	);
INSERT INTO	RESULTADO_KUMITE	VALUES	(	5	,	4	,	3	,	11	,	14	);
INSERT INTO	RESULTADO_KUMITE	VALUES	(	6	,	1	,	3	,	10	,	13	);
INSERT INTO	RESULTADO_KUMITE	VALUES	(	7	,	7	,	4	,	11	,	13	);
INSERT INTO	RESULTADO_KUMITE	VALUES	(	8	,	1	,	5	,	28	,	26	);
INSERT INTO	RESULTADO_KUMITE	VALUES	(	9	,	8	,	9	,	25	,	24	);
INSERT INTO	RESULTADO_KUMITE	VALUES	(	10	,	10	,	3	,	21	,	23	);
INSERT INTO	RESULTADO_KUMITE	VALUES	(	11	,	9	,	6	,	27	,	22	);
INSERT INTO	RESULTADO_KUMITE	VALUES	(	12	,	2	,	5	,	26	,	27	);
INSERT INTO	RESULTADO_KUMITE	VALUES	(	13	,	7	,	6	,	21	,	24	);
INSERT INTO	RESULTADO_KUMITE	VALUES	(	14	,	10	,	5	,	27	,	21	);

-- INSERTS ASISTENCIA--

INSERT INTO	ASISTENCIA	VALUES	(	'S'	,	1	,	NULL	,	5	);
INSERT INTO	ASISTENCIA	VALUES	(	'S'	,	2	,	NULL	,	5	);
INSERT INTO	ASISTENCIA	VALUES	(	'S'	,	3	,	NULL	,	5	);
INSERT INTO	ASISTENCIA	VALUES	(	'S'	,	4	,	NULL	,	5	);
INSERT INTO	ASISTENCIA	VALUES	(	'S'	,	5	,	NULL	,	5	);
INSERT INTO	ASISTENCIA	VALUES	(	'S'	,	6	,	NULL	,	5	);
INSERT INTO	ASISTENCIA	VALUES	(	'S'	,	7	,	NULL	,	5	);
INSERT INTO	ASISTENCIA	VALUES	(	'S'	,	8	,	NULL	,	5	);
INSERT INTO	ASISTENCIA	VALUES	(	'S'	,	9	,	NULL	,	6	);
INSERT INTO	ASISTENCIA	VALUES	(	'S'	,	10	,	NULL	,	6	);
INSERT INTO	ASISTENCIA	VALUES	(	'S'	,	11	,	NULL	,	6	);
INSERT INTO	ASISTENCIA	VALUES	(	'S'	,	12	,	NULL	,	6	);
INSERT INTO	ASISTENCIA	VALUES	(	'S'	,	13	,	NULL	,	6	);
INSERT INTO	ASISTENCIA	VALUES	(	'S'	,	14	,	NULL	,	6	);
INSERT INTO	ASISTENCIA	VALUES	(	'S'	,	15	,	NULL	,	6	);
INSERT INTO	ASISTENCIA	VALUES	(	'S'	,	16	,	NULL	,	6	);
INSERT INTO	ASISTENCIA	VALUES	(	'N'	,	17	,	NULL	,	6	);
INSERT INTO	ASISTENCIA	VALUES	(	'N'	,	18	,	NULL	,	6	);
INSERT INTO	ASISTENCIA	VALUES	(	'N'	,	19	,	NULL	,	6	);
INSERT INTO	ASISTENCIA	VALUES	(	'N'	,	20	,	NULL	,	6	);
INSERT INTO	ASISTENCIA	VALUES	(	'S'	,	21	,	NULL	,	7	);
INSERT INTO	ASISTENCIA	VALUES	(	'S'	,	22	,	NULL	,	7	);
INSERT INTO	ASISTENCIA	VALUES	(	'S'	,	23	,	NULL	,	7	);
INSERT INTO	ASISTENCIA	VALUES	(	'S'	,	24	,	NULL	,	7	);
INSERT INTO	ASISTENCIA	VALUES	(	'S'	,	25	,	NULL	,	7	);
INSERT INTO	ASISTENCIA	VALUES	(	'S'	,	26	,	NULL	,	7	);
INSERT INTO	ASISTENCIA	VALUES	(	'S'	,	27	,	NULL	,	7	);
INSERT INTO	ASISTENCIA	VALUES	(	'S'	,	28	,	NULL	,	7	);
INSERT INTO	ASISTENCIA	VALUES	(	'N'	,	29	,	NULL	,	7	);
INSERT INTO	ASISTENCIA	VALUES	(	'N'	,	30	,	NULL	,	7	);
INSERT INTO	ASISTENCIA	VALUES	(	'N'	,	31	,	NULL	,	7	);
INSERT INTO	ASISTENCIA	VALUES	(	'S'	,	32	,	3	,	NULL	);
INSERT INTO	ASISTENCIA	VALUES	(	'S'	,	33	,	3	,	NULL	);
INSERT INTO	ASISTENCIA	VALUES	(	'S'	,	34	,	3	,	NULL	);
INSERT INTO	ASISTENCIA	VALUES	(	'S'	,	35	,	3	,	NULL	);
INSERT INTO	ASISTENCIA	VALUES	(	'S'	,	36	,	3	,	NULL	);
INSERT INTO	ASISTENCIA	VALUES	(	'S'	,	37	,	3	,	NULL	);
INSERT INTO	ASISTENCIA	VALUES	(	'S'	,	38	,	3	,	NULL	);
INSERT INTO	ASISTENCIA	VALUES	(	'S'	,	39	,	3	,	NULL	);
INSERT INTO	ASISTENCIA	VALUES	(	'S'	,	40	,	3	,	NULL	);
INSERT INTO	ASISTENCIA	VALUES	(	'S'	,	41	,	3	,	NULL	);
INSERT INTO	ASISTENCIA	VALUES	(	'S'	,	42	,	3	,	NULL	);
INSERT INTO	ASISTENCIA	VALUES	(	'S'	,	43	,	3	,	NULL	);
INSERT INTO	ASISTENCIA	VALUES	(	'S'	,	44	,	3	,	NULL	);
INSERT INTO	ASISTENCIA	VALUES	(	'S'	,	45	,	3	,	NULL	);
INSERT INTO	ASISTENCIA	VALUES	(	'S'	,	46	,	3	,	NULL	);
INSERT INTO	ASISTENCIA	VALUES	(	'S'	,	47	,	3	,	NULL	);
INSERT INTO	ASISTENCIA	VALUES	(	'S'	,	48	,	1	,	NULL	);
INSERT INTO	ASISTENCIA	VALUES	(	'S'	,	49	,	1	,	NULL	);
INSERT INTO	ASISTENCIA	VALUES	(	'S'	,	50	,	1	,	NULL	);
INSERT INTO	ASISTENCIA	VALUES	(	'S'	,	51	,	1	,	NULL	);
INSERT INTO	ASISTENCIA	VALUES	(	'S'	,	52	,	1	,	NULL	);
INSERT INTO	ASISTENCIA	VALUES	(	'S'	,	53	,	1	,	NULL	);
INSERT INTO	ASISTENCIA	VALUES	(	'N'	,	54	,	1	,	NULL	);
INSERT INTO	ASISTENCIA	VALUES	(	'N'	,	55	,	1	,	NULL	);
INSERT INTO	ASISTENCIA	VALUES	(	'N'	,	56	,	1	,	NULL	);
INSERT INTO	ASISTENCIA	VALUES	(	'S'	,	57	,	1	,	NULL	);
INSERT INTO	ASISTENCIA	VALUES	(	'S'	,	58	,	1	,	NULL	);
INSERT INTO	ASISTENCIA	VALUES	(	'S'	,	59	,	1	,	NULL	);





-- INSERTS COMPRA CARRITO Y DETALLE COMPRA --

/*===================================INSERTS MODULO 16====================================*/


/*-------------------------------COMPRA_CARRITO----------------------------*/

INSERT INTO COMPRA_CARRITO VALUES ('Tarjeta','2015-11-28','PAGADO',1);

INSERT INTO COMPRA_CARRITO VALUES ('Deposito','2016-11-28','PAGADO',2);

INSERT INTO COMPRA_CARRITO VALUES ('Transferencia','2015-11-28','PAGADO',3);

INSERT INTO COMPRA_CARRITO VALUES ('Tarjeta','2016-11-28','PAGADO',4);

INSERT INTO COMPRA_CARRITO VALUES ('Deposito','2015-11-28','PAGADO',5);

INSERT INTO COMPRA_CARRITO VALUES ('Transferencia','2016-11-28','PAGADO',6);

INSERT INTO COMPRA_CARRITO VALUES (NULL,NULL,'CARRITO',7);

INSERT INTO COMPRA_CARRITO VALUES (NULL,NULL,'CARRITO',8);

INSERT INTO COMPRA_CARRITO VALUES ('Tarjeta','2015-09-17','PAGADO',6);

INSERT INTO COMPRA_CARRITO VALUES ('Deposito','2015-07-10','PAGADO',6); 

INSERT INTO COMPRA_CARRITO VALUES ('Transferencia','2015-10-09','PAGADO',6); 

INSERT INTO COMPRA_CARRITO VALUES ('Tarjeta','2016-05-07','PAGADO',6);

INSERT INTO COMPRA_CARRITO VALUES ('Tarjeta','2015-04-10','PAGADO',6);

INSERT INTO COMPRA_CARRITO VALUES ('Tarjeta','2015-03-11','CARRITO',6);

INSERT INTO COMPRA_CARRITO VALUES ('Tarjeta','2015-03-18','PAGADO',6);
 
INSERT INTO COMPRA_CARRITO VALUES ('Tarjeta','2015-03-10','CARRITO',6);

/*-------------------------------------------------------------------------*/

/*------------------------------DETALLE_COMPRA-----------------------------*/

INSERT INTO DETALLE_COMPRA VALUES (1,4500,4,NULL,NULL,1,NULL,NULL);

INSERT INTO DETALLE_COMPRA VALUES (1,3000,3,NULL,NULL,2,NULL,NULL);

INSERT INTO DETALLE_COMPRA VALUES (1,1200,2,NULL,NULL,4,NULL,NULL);

INSERT INTO DETALLE_COMPRA VALUES (1,5000,4,NULL,NULL,5,NULL,NULL);

INSERT INTO DETALLE_COMPRA VALUES (1,0,1,NULL,NULL,NULL,1,NULL);

INSERT INTO DETALLE_COMPRA VALUES (1,2000,1,NULL,NULL,NULL,2,NULL);

INSERT INTO DETALLE_COMPRA VALUES (7,1150,1,NULL,NULL,NULL,3,NULL);

INSERT INTO DETALLE_COMPRA VALUES (8,4500,5,NULL,NULL,3,NULL,NULL);

INSERT INTO DETALLE_COMPRA VALUES (9,0,1,NULL,NULL,NULL,10,NULL); 

INSERT INTO DETALLE_COMPRA VALUES (9,0,1,NULL,NULL,NULL,11,NULL);

INSERT INTO DETALLE_COMPRA VALUES (9,0,1,NULL,NULL,NULL,12,NULL);

INSERT INTO DETALLE_COMPRA VALUES (10,1000,1,NULL,NULL,NULL,13,NULL);

INSERT INTO DETALLE_COMPRA VALUES (11,3000,1,NULL,NULL,NULL,14,NULL);

INSERT INTO DETALLE_COMPRA VALUES (12,1200,1,NULL,NULL,NULL,15,NULL);

INSERT INTO DETALLE_COMPRA VALUES (8,1200,6,3,6,NULL,2,NULL);

INSERT INTO DETALLE_COMPRA VALUES (7,1200,1,3,6,NULL,13,NULL);

INSERT INTO DETALLE_COMPRA VALUES (6,1200,1,3,6,NULL,14,NULL);

INSERT INTO DETALLE_COMPRA VALUES (8,1200,6,25,6,NULL,2,NULL);


update PERSONA set per_clave='5ae2bacffebdf3e8e37decdd343ac728';
update EMAIL set ema_email='perdomo21346@gmail.com' where PERSONA_per_id=28 and ema_principal=1;
update EMAIL set ema_email='rafa91_1@hotmail.com' where (PERSONA_per_id=31 or PERSONA_per_id=30 ) and ema_principal=1;




/*-------------------------------------------------------------------------*/


/*=======================================================================================*/



    