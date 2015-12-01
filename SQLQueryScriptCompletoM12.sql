--CREATE MODULO 5--
--CREATE TABLE ORGANIZACION--
CREATE
  TABLE ORGANIZACION
  (
    org_id          INTEGER IDENTITY(1,1) NOT NULL ,
    org_nombre      VARCHAR (100) NOT NULL ,
    CONSTRAINT ORGANIZACION_PK PRIMARY KEY CLUSTERED (org_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

--CREATES MODULO 12--
--CREATE TABLE UBICACION--
CREATE
  TABLE UBICACION
  (
    ubi_id          INTEGER IDENTITY(1,1) NOT NULL ,
    ubi_latitud     VARCHAR (100) NOT NULL ,
    ubi_longitud    VARCHAR (100) NOT NULL ,
    ubi_ciudad      VARCHAR (100) NOT NULL ,
    ubi_estado      VARCHAR (100) NOT NULL ,
    ubi_direccion   VARCHAR (100) ,
    CONSTRAINT UBICACION_PK PRIMARY KEY CLUSTERED (ubi_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO


--CREATE TABLE CATEGORIA--
CREATE
  TABLE CATEGORIA
  (
    cat_id          INTEGER IDENTITY(1,1) NOT NULL ,
    cat_edad_ini    INTEGER NOT NULL ,
    cat_edad_fin    INTEGER ,
    cat_cinta_ini   VARCHAR (100) NOT NULL ,
    cat_cinta_fin   VARCHAR (100) ,
    cat_sexo        CHAR NOT NULL,
    CONSTRAINT CATEGORIA_PK PRIMARY KEY CLUSTERED (cat_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO


--CREATE TABLE COMPETENCIA--
CREATE
  TABLE COMPETENCIA
  (
    comp_id              INTEGER IDENTITY(1,1) NOT NULL ,
    comp_nombre          VARCHAR (100) NOT NULL ,
    comp_tipo            INTEGER NOT NULL ,
	comp_org_todas       BIT NOT NULL,
    comp_status	         VARCHAR(100) NOT NULL,
	comp_fecha_ini		 DATETIME NOT NULL,
	comp_fecha_fin		 DATETIME NOT NULL,
	UBICACION_comp_id    INTEGER NOT NULL,
	CATEGORIA_comp_id    INTEGER NOT NULL,
	ORGANIZACION_comp_id INTEGER,
	comp_costo			 FLOAT NOT NULL,
    CONSTRAINT COMPETENCIA_PK PRIMARY KEY CLUSTERED (comp_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

--CREATE MODULO 9--
--CREATE TABLE EVENTO--
CREATE
  TABLE EVENTO
  (
    even_id           INTEGER IDENTITY(1,1) NOT NULL ,
    even_nombre       VARCHAR (100) NOT NULL ,
	UBICACION_even_id INTEGER NOT NULL,
    CONSTRAINT EVENTO_PK PRIMARY KEY CLUSTERED (even_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

-- INSERTS ORGANIZACION --
INSERT INTO [dbo].ORGANIZACION ([org_nombre]) VALUES ('Kenshin Ryu');
go

INSERT INTO [dbo].ORGANIZACION ([org_nombre]) VALUES ('Kihin');
go

INSERT INTO [dbo].ORGANIZACION ([org_nombre]) VALUES ('Seito');
go
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

-- INSERTS EVENTO --
INSERT INTO [dbo].EVENTO ([even_nombre], [UBICACION_even_id]) VALUES ('Do Hombu',1)
go

INSERT INTO [dbo].EVENTO ([even_nombre], [UBICACION_even_id]) VALUES ('Hayashi Ha',2)
go

INSERT INTO [dbo].EVENTO ([even_nombre], [UBICACION_even_id]) VALUES ('Nacional Juvenil F.V.K.D.',3)
go

INSERT INTO [dbo].EVENTO ([even_nombre], [UBICACION_even_id]) VALUES ('Ozawa Cup',4)
go

INSERT INTO [dbo].EVENTO ([even_nombre], [UBICACION_even_id]) VALUES ('Shi Kyoshi',5)
go

-- INSERTS COMPETENCIA --
--INSERT INTO [dbo].COMPETENCIA ([comp_nombre], [comp_tipo], [UBICACION_comp_id], [CATEGORIA_comp_id], [EVENTO_comp_id], [ORGANIZACION_comp_id], [com_org_todas]) VALUES ('nombre','tipo'(KATA:1 KUMITE:",ubicacion,categoria,evento,organizacion,todas)
--go--

INSERT INTO [dbo].[COMPETENCIA] ([comp_id], [comp_nombre], [comp_tipo], [comp_org_todas], [comp_status], [comp_fecha_ini], [comp_fecha_fin], [UBICACION_comp_id], [CATEGORIA_comp_id], [ORGANIZACION_comp_id], [comp_costo]) VALUES (4, N'Ryu Kobudo', 1, 1, N'Por Iniciar', N'2016-10-25 00:00:00', N'2016-10-27 00:00:00', 3, 4, NULL,1500)
INSERT INTO [dbo].[COMPETENCIA] ([comp_id], [comp_nombre], [comp_tipo], [comp_org_todas], [comp_status], [comp_fecha_ini], [comp_fecha_fin], [UBICACION_comp_id], [CATEGORIA_comp_id], [ORGANIZACION_comp_id], [comp_costo]) VALUES (5, N'Kobudo', 2, 1, N'Por Iniciar', N'2016-09-01 00:00:00', N'2016-09-03 00:00:00', 1, 1, NULL,1100)
INSERT INTO [dbo].[COMPETENCIA] ([comp_id], [comp_nombre], [comp_tipo], [comp_org_todas], [comp_status], [comp_fecha_ini], [comp_fecha_fin], [UBICACION_comp_id], [CATEGORIA_comp_id], [ORGANIZACION_comp_id], [comp_costo]) VALUES (6, N'Doo Kan', 2, 0, N'Por Iniciar', N'2016-10-15 00:00:00', N'2016-10-18 00:00:00', 1, 2, 1,900)
INSERT INTO [dbo].[COMPETENCIA] ([comp_id], [comp_nombre], [comp_tipo], [comp_org_todas], [comp_status], [comp_fecha_ini], [comp_fecha_fin], [UBICACION_comp_id], [CATEGORIA_comp_id], [ORGANIZACION_comp_id], [comp_costo]) VALUES (7, N'Yodan Ryu', 1, 0, N'Por Iniciar', N'2016-05-20 00:00:00', N'2016-05-23 00:00:00', 2, 3, 2,1000)

--ALTER--

ALTER TABLE EVENTO
ADD CONSTRAINT EVENTO_UBICACION_FK FOREIGN KEY
(
UBICACION_even_id
)
REFERENCES UBICACION
(
ubi_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE COMPETENCIA
ADD CONSTRAINT COMPETENCIA_UBICACION_FK FOREIGN KEY
(
UBICACION_comp_id
)
REFERENCES UBICACION
(
ubi_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE COMPETENCIA
ADD CONSTRAINT COMPETENCIA_CATEGORIA_FK FOREIGN KEY
(
CATEGORIA_comp_id
)
REFERENCES CATEGORIA
(
cat_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE COMPETENCIA
ADD CONSTRAINT COMPETENCIA_ORGANIZACION_FK FOREIGN KEY
(
ORGANIZACION_comp_id
)
REFERENCES ORGANIZACION
(
org_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

--PROCEDURE CONSULTA LISTA DE COMPETENCIAS--
CREATE procedure M12_ConsultarCompetencias
as
	begin
		select comp.comp_id as idCompetencia, comp.comp_nombre as nombreCompetencia, comp.comp_tipo as tipoCompetencia, comp.comp_status as statusCompetencia, comp.comp_org_todas as todasOrganizaciones,
			   org.org_id as idOrganizacion, org.org_nombre as nombreOrganizacion, ubi.ubi_id as idUbicacion, ubi.ubi_ciudad as nombreCiudad, ubi.ubi_estado as nombreEstado
		from COMPETENCIA comp LEFT OUTER JOIN ORGANIZACION org ON comp.ORGANIZACION_comp_id = org.org_id, UBICACION ubi
		where comp.UBICACION_comp_id = ubi.ubi_id
		
	end;
go

	--PROCEDURE CONSULTA COMPETENCIA POR ID --
CREATE procedure M12_ConsultarCompetenciasXId
	@idCompetencia [int]
as
DECLARE 
	@organizacionesTodas [bit]
	begin
	
		select @organizacionesTodas = comp.comp_org_todas
		from COMPETENCIA comp
		where comp.comp_id = @idCompetencia

		if(@organizacionesTodas = 0)
			select comp.comp_id as idCompetencia, comp.comp_nombre as nombreCompetencia, comp.comp_tipo as tipoCompetencia, comp.comp_status as statusCompetencia, comp.comp_org_todas as todasOrganizaciones, comp.comp_fecha_ini as fechaInicio, comp.comp_fecha_fin as fechaFin, comp.comp_costo as costoCompetencia,
				   org.org_id as idOrganizacion, org.org_nombre as nombreOrganizacion, ubi.ubi_id as idUbicacion, ubi.ubi_ciudad as nombreCiudad, ubi.ubi_estado as nombreEstado, ubi.ubi_direccion as nombreDireccion, ubi.ubi_latitud as latitudDireccion,
				   ubi.ubi_longitud as longitudDireccion, cat.cat_id as idCategoria, cat.cat_edad_ini as edadInicio, cat.cat_edad_fin as edadFin, cat.cat_cinta_ini as cintaInicio, cat_cinta_fin as cintaFin, cat_sexo as sexoCategoria
			from COMPETENCIA comp, ORGANIZACION org, UBICACION ubi, CATEGORIA cat
			where comp.ORGANIZACION_comp_id = org.org_id and comp.UBICACION_comp_id = ubi.ubi_id and cat.cat_id = comp.CATEGORIA_comp_id and comp.comp_id = @idCompetencia
		else
			select comp.comp_id as idCompetencia, comp.comp_nombre as nombreCompetencia, comp.comp_tipo as tipoCompetencia, comp.comp_status as statusCompetencia, comp.comp_org_todas as todasOrganizaciones, comp.comp_fecha_ini as fechaInicio, comp.comp_fecha_fin as fechaFin, comp.comp_costo as costoCompetencia,
				   ubi.ubi_id as idUbicacion, ubi.ubi_ciudad as nombreCiudad, ubi.ubi_estado as nombreEstado, ubi.ubi_direccion as nombreDireccion, ubi.ubi_latitud as latitudDireccion,
				   ubi.ubi_longitud as longitudDireccion, cat.cat_id as idCategoria, cat.cat_edad_ini as edadInicio, cat.cat_edad_fin as edadFin, cat.cat_cinta_ini as cintaInicio, cat_cinta_fin as cintaFin, cat_sexo as sexoCategoria
			from COMPETENCIA comp, UBICACION ubi, CATEGORIA cat
			where comp.UBICACION_comp_id = ubi.ubi_id and cat.cat_id = comp.CATEGORIA_comp_id and comp.comp_id = @idCompetencia
	end;
	go

--PROCEDURE AGREGAR COMPETENCIA--
CREATE PROCEDURE M12_AgregarCompetencia
	@nombreCompetencia   [varchar](100),
	@tipoCompetencia     [int],
	@organizacionesTodas [bit],
	@statusCompetencia   [varchar](100),
	@fecha_ini		     [datetime],
	@fecha_fin           [datetime],
	@nombreOrganizacion  [varchar](100),
	@nombreCiudad		 [varchar](100),
	@nombreEstado        [varchar](100),
	@nombreDireccion	 [varchar](100),
	@latitudDireccion    [varchar](100),
	@longitudDireccion   [varchar](100),
	@edadIni			 [int],
	@edadFin			 [int],
	@cintaIni			 [varchar](100),
	@cintaFin            [varchar](100),
	@sexo				 [char](1),
	@costoCompetencia	 [float]
 
as
 begin
	declare @numCategoria as int;
	declare @numCompetencia as int;

	select @numCategoria = count(*) from CATEGORIA where cat_cinta_fin = @cintaFin and cat_cinta_ini = @cintaIni
													     and cat_edad_fin = @edadFin and cat_edad_ini = @edadIni
														 and cat_sexo = @sexo;

	select @numCompetencia = count(*) from COMPETENCIA where comp_nombre = @nombreCompetencia;

		if(@numCompetencia = 0 and @numCategoria = 0)
				INSERT INTO CATEGORIA (cat_edad_ini, cat_edad_fin, cat_cinta_ini, cat_cinta_fin, cat_sexo) 
				VALUES (@edadIni, @edadFin, @cintaIni, @cintaFin, @sexo);

		if(@numCompetencia = 0 or @numCategoria = 0)
				INSERT INTO UBICACION(ubi_latitud, ubi_longitud, ubi_ciudad, ubi_estado, ubi_direccion) 
				VALUES (@latitudDireccion, @longitudDireccion, @nombreCiudad, @nombreEstado, @nombreDireccion);


		if(@organizacionesTodas = 1)
			if(@numCompetencia = 0 and @costoCompetencia >= 0)
						
					INSERT INTO COMPETENCIA (comp_nombre, comp_tipo, comp_org_todas, comp_status, comp_fecha_ini, comp_fecha_fin, UBICACION_comp_id, CATEGORIA_comp_id, ORGANIZACION_comp_id, comp_costo)
					VALUES (@nombreCompetencia, @tipoCompetencia, @organizacionesTodas, @statusCompetencia, @fecha_ini, @fecha_fin, 
						   (select ubi_id from UBICACION where @latitudDireccion = ubi_latitud and @longitudDireccion = ubi_longitud and @nombreCiudad = ubi_ciudad and @nombreEstado = ubi_estado and @nombreDireccion = ubi_direccion), 
						   (select cat_id from CATEGORIA where @edadIni = cat_edad_ini and @edadFin = cat_edad_fin and @cintaIni = cat_cinta_ini and @cintaFin = cat_cinta_fin and @sexo = cat_sexo), 
						   null,@costoCompetencia);
				
				else
					INSERT INTO COMPETENCIA (comp_nombre, comp_tipo, comp_org_todas, comp_status, comp_fecha_ini, comp_fecha_fin, UBICACION_comp_id, CATEGORIA_comp_id, ORGANIZACION_comp_id, comp_costo)
					VALUES (@nombreCompetencia, @tipoCompetencia, @organizacionesTodas, @statusCompetencia, @fecha_ini, @fecha_fin, 
						   (select ubi_id from UBICACION where @latitudDireccion = ubi_latitud and @longitudDireccion = ubi_longitud and @nombreCiudad = ubi_ciudad and @nombreEstado = ubi_estado and @nombreDireccion = ubi_direccion), 
						   (select cat_id from CATEGORIA where @edadIni = cat_edad_ini and @edadFin = cat_edad_fin and @cintaIni = cat_cinta_ini and @cintaFin = cat_cinta_fin and @sexo = cat_sexo), 
						   null,@costoCompetencia);
			
		else
			if(@numCompetencia = 0 and @costoCompetencia >= 0)		
				INSERT INTO COMPETENCIA (comp_nombre, comp_tipo, comp_org_todas, comp_status, comp_fecha_ini, comp_fecha_fin, UBICACION_comp_id, CATEGORIA_comp_id, ORGANIZACION_comp_id, comp_costo)
				VALUES (@nombreCompetencia, @tipoCompetencia, @organizacionesTodas, @statusCompetencia, @fecha_ini, @fecha_fin, 
					   (select ubi_id from UBICACION where @latitudDireccion = ubi_latitud and @longitudDireccion = ubi_longitud and @nombreCiudad = ubi_ciudad and @nombreEstado = ubi_estado and @nombreDireccion = ubi_direccion), 
					   (select cat_id from CATEGORIA where @edadIni = cat_edad_ini and @edadFin = cat_edad_fin and @cintaIni = cat_cinta_ini and @cintaFin = cat_cinta_fin and @sexo = cat_sexo), 
					   (select org_id from ORGANIZACION where @nombreOrganizacion = org_nombre),@costoCompetencia);

 end;
go