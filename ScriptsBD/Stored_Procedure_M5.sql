---------------------------------------------------STORED PROCEDURES M5-------------------------------------

--PROCEDURE CONSULTA LISTA DE CINTAS 
CREATE procedure M5_ConsultarCintas
as
	begin
		select cin.cin_id as idCinta, cin.cin_color_nombre as colorCinta, cin.cin_rango as rangoCinta, 
		cin.cin_clasificacion as ClasificacionCinta,
		cin.cin_significado as significadoCinta, cin.cin_orden as ordenCinta,
		org.org_nombre as nombreOrganizacion
		from  CINTA cin, ORGANIZACION_CINTA orgcin, ORGANIZACION org
		where orgcin.CINTA_cin_id = cin.cin_id  and orgcin.ORGANIZACION_org_id = org.org_id	
	end;
go
--COMO PROBAR EL PROCEDIMIENTO
--execute M5_ConsultarCintas;


--PROCEDURE CONSULTA LISTA DE CINTAS POR IDORGANIZACION
CREATE procedure M5_ConsultarCintasXOrganizacionId
	@id_organizacion [int]
as
	begin
		select cin.cin_id as idCinta, cin.cin_color_nombre as colorCinta, cin.cin_rango as rangoCinta, 
		cin.cin_clasificacion as ClasificacionCinta,
		cin.cin_significado as significadoCinta, cin.cin_orden as ordenCinta,
		org.org_nombre as nombreOrganizacion
		from  CINTA cin, ORGANIZACION_CINTA orgcin, ORGANIZACION org
		where orgcin.CINTA_cin_id = cin.cin_id  and orgcin.ORGANIZACION_org_id = org.org_id	and
		org.org_id = @id_organizacion	
	end;
go
--COMO PROBAR EL PROCEDIMIENTO
--execute M5_ConsultarCintasXOrganizacionId "2";

--PROCEDURE CONSULTA LISTA DE CINTAS POR ID, para el de "i"
CREATE procedure M5_ConsultarCintasXId
	@id_cinta [int]
as
	begin
		select cin.cin_id as idCinta,cin.cin_color_nombre as colorCinta, cin.cin_rango as rangoCinta, 
		cin.cin_clasificacion as ClasificacionCinta,
		cin.cin_significado as significadoCinta, cin.cin_orden as ordenCinta,org.org_nombre as nombreOrganizacion		
		from ORGANIZACION org , CINTA cin, ORGANIZACION_CINTA orgcin
		where orgcin.CINTA_cin_id = cin.cin_id  and orgcin.ORGANIZACION_org_id = org.org_id	
		and @id_cinta = cin.cin_id  
	end;
go
--COMO PROBAR EL PROCEDIMIENTO
--execute M5_ConsultarCintasXId "2";


--PROCEDURE ELIMINAR CINTA --- SOLO BORRO CINTA
CREATE procedure M5_EliminarCinta
	@id_cinta [int]
as
	begin
	    delete cinta from cinta cin
		where @id_cinta = cin.cin_id
	end;
go

--COMO PROBAR EL PROCEDIMIENTO execute M5_EliminarCinta "4";

--PROCEDURE BUSCAR ID DE CINTA
CREATE procedure M5_BuscarIdCinta
	@color_cinta [varchar](100)
	
as
declare @id_cinta     [int]
	begin
		select @id_cinta = cin_id from cinta
		where cin_color_nombre = @color_cinta
	end;
go

-- execute M5_BuscarIdCinta "Amarillo"


--Para Cesar
CREATE procedure M5_BuscarNombreCinta
	@color_cinta [varchar](100)
	
as
declare @nombre_cinta  [varchar](100)
	begin
		select @nombre_cinta  = cin_color_nombre from cinta
		where cin_color_nombre = @color_cinta
	end;
go


--PROCEDURE AGREGAR CINTA
CREATE PROCEDURE M5_AgregarCinta
	@colorCinta			 	[varchar](100),
	@rangoCinta			 	[varchar](100),
	@clasificacionCinta		[varchar](100),
	@significadoCinta	    [varchar](100),
	@ordenCinta	        	[int],	
	@nombreOrganizacion  	[varchar](100)
 
as
 begin
	declare @idOrganizacion as int;
	declare @idCinta as int;

	select @idOrganizacion = org_id from ORGANIZACION where org_nombre = @nombreOrganizacion;

	INSERT INTO CINTA(cin_color_nombre, cin_rango, cin_clasificacion, cin_significado, cin_orden) 
				VALUES (@colorCinta, @rangoCinta, @clasificacionCinta, @significadoCinta, @ordenCinta);
	
	select @idCinta = max(cin_id) from cinta;
	
	INSERT INTO ORGANIZACION_CINTA (ORGANIZACION_org_id, CINTA_cin_id) 
				VALUES (@idOrganizacion, @idCinta);
		
 end;

--COMO PROBAR EL PROCEDIMIENTO execute M5_AgregarCinta 'Blanco', '1er Kyu', 'Nivel inferior', 'Principiante', '1', 'Clash Cobra-do';



--PROCEDURE MODIFICAR CINTA--
CREATE PROCEDURE M5_ModificarCinta
	@idcinta				[int],
	@colorCinta			 	[varchar](100),
	@rangoCinta			 	[varchar](100),
	@clasificacionCinta		[varchar](100),
	@significadoCinta	    [varchar](100),
	@ordenCinta	        	[int],
	@nombreOrganizacion		[varchar](100)
 
as
 begin
	declare @idOrganizacionNueva as int;
	declare @idOrg as int;

	select @idOrganizacionNueva = org_id from ORGANIZACION where org_nombre = @nombreOrganizacion;
	
	select @idOrg = orgcin.ORGANIZACION_org_id from  CINTA cin, ORGANIZACION_CINTA orgcin
		where orgcin.CINTA_cin_id = cin.cin_id  and cin.cin_id = @idcinta
	

	if(@idOrganizacionNueva = @idOrg) --Es decir si no se cambia la org
	UPDATE CINTA
		SET 
			cin_color_nombre  = @colorCinta,
			cin_rango         = @rangoCinta, 
			cin_clasificacion = @clasificacionCinta, 
			cin_significado   = @significadoCinta,
			cin_orden		  = @ordenCinta	
			WHERE
			cin_id = @idCinta;	
	else
		delete ORGANIZACION_CINTA from ORGANIZACION_CINTA orgcin 
					where orgcin.ORGANIZACION_org_id = @idOrg and orgcin.CINTA_cin_id = @idcinta;
		
		UPDATE CINTA
		SET 
			cin_color_nombre  = @colorCinta,
			cin_rango         = @rangoCinta, 
			cin_clasificacion = @clasificacionCinta, 
			cin_significado   = @significadoCinta,
			cin_orden		  = @ordenCinta	
			WHERE
			cin_id = @idcinta;	
		
		
		INSERT INTO ORGANIZACION_CINTA(ORGANIZACION_org_id,CINTA_cin_id) VALUES(@idOrganizacionNueva,@idcinta);
	
	
 end;
go

--COMO PROBAR EL PROCEDIMIENTO execute M5_ModificarCinta 'Clash Cobra-do','3','Blanco', '1er Kyu', 'Nivel inferior', 'Principiante', '1';
