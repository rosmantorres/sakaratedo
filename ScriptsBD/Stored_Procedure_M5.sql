---------------------------------------------------STORED PROCEDURES M5-------------------------------------

--PROCEDURE AGREGAR CINTA
CREATE PROCEDURE M5_AgregarCinta
	@colorCinta			 	[varchar](100),
	@rangoCinta			 	[varchar](100),
	@clasificacionCinta		[varchar](100),
	@significadoCinta	    [varchar](100),
	@ordenCinta	        	[int],	
	@idOrganizacion			[int],
	@nombreOrganizacion  	[varchar](100)
 
as
 begin
	declare @idCinta as int;

	INSERT INTO CINTA(cin_color_nombre, cin_rango, cin_clasificacion, cin_significado, cin_orden) 
				VALUES (@colorCinta, @rangoCinta, @clasificacionCinta, @significadoCinta, @ordenCinta);
	
	select @idCinta = max(cin_id) from cinta;
	
	INSERT INTO ORGANIZACION_CINTA (ORGANIZACION_org_id, CINTA_cin_id) 
				VALUES (@idOrganizacion, @idCinta);
		
 end;
 
 
--PROCEDURE BUSCAR ID DE CINTA
CREATE procedure M5_BuscarIdCinta
	@color_cinta [varchar](100)
	
as
declare @id_cinta     [int]
	begin
		select @id_cinta = cin_id from cinta
		where cin_color_nombre = @color_cinta
	end;
	
--Para Cesar
CREATE procedure M5_BuscarNombreCinta
	@color_cinta [varchar](100)
	
as
declare @nombre_cinta  [varchar](100)
	begin
		select @nombre_cinta  = cin_color_nombre from cinta
		where cin_color_nombre = @color_cinta
	end;


--PROCEDURE CONSULTA LISTA DE CINTAS 
CREATE procedure M5_ConsultarCintas
as
	begin
		select cin.cin_id as idCinta, cin.cin_color_nombre as colorCinta, cin.cin_rango as rangoCinta, 
		cin.cin_clasificacion as ClasificacionCinta,
		cin.cin_significado as significadoCinta, cin.cin_orden as ordenCinta,
		org.org_id as idOrganizacion,org.org_nombre as nombreOrganizacion
		from  CINTA cin, ORGANIZACION_CINTA orgcin, ORGANIZACION org
		where orgcin.CINTA_cin_id = cin.cin_id  and orgcin.ORGANIZACION_org_id = org.org_id	
	end;


--PROCEDURE CONSULTA LISTA DE CINTAS POR ID, para el de "i"
CREATE procedure M5_ConsultarCintasXId
	@id_cinta [int]
as
	begin
		select cin.cin_id as idCinta,cin.cin_color_nombre as colorCinta, cin.cin_rango as rangoCinta, 
		cin.cin_clasificacion as ClasificacionCinta,
		cin.cin_significado as significadoCinta, cin.cin_orden as ordenCinta,
		org.org_id as idOrganizacion, org.org_nombre as nombreOrganizacion		
		from ORGANIZACION org , CINTA cin, ORGANIZACION_CINTA orgcin
		where orgcin.CINTA_cin_id = cin.cin_id  and orgcin.ORGANIZACION_org_id = org.org_id	
		and @id_cinta = cin.cin_id  
	end;
	
--PROCEDURE CONSULTA LISTA DE CINTAS POR IDORGANIZACION
CREATE procedure M5_ConsultarCintasXOrganizacionId
	@id_organizacion [int]
as
	begin
		select cin.cin_id as idCinta, cin.cin_color_nombre as colorCinta, cin.cin_rango as rangoCinta, 
		cin.cin_clasificacion as ClasificacionCinta,
		cin.cin_significado as significadoCinta, cin.cin_orden as ordenCinta,
		org.org_id as idOrganizacion,org.org_nombre as nombreOrganizacion
		from  CINTA cin, ORGANIZACION_CINTA orgcin, ORGANIZACION org
		where orgcin.CINTA_cin_id = cin.cin_id  and orgcin.ORGANIZACION_org_id = org.org_id	and
		org.org_id = @id_organizacion	
	end;
	

--PROCEDURE ELIMINAR CINTA --- SOLO BORRO CINTA
CREATE procedure M5_EliminarCinta
	@id_cinta [int]
as
	begin
	    delete cinta from cinta cin
		where @id_cinta = cin.cin_id
	end;
	


--PROCEDURE MODIFICAR CINTA--
CREATE PROCEDURE M5_ModificarCinta
	@idcinta				[int],
	@colorCinta			 	[varchar](100),
	@rangoCinta			 	[varchar](100),
	@clasificacionCinta		[varchar](100),
	@significadoCinta	    [varchar](100),
	@ordenCinta	        	[int],
	@idOrganizacion			[int],
	@nombreOrganizacion		[varchar](100)
 
as
 begin
	declare @idOrg as int


--	@idOrganizacionNueva = @idOrganizacion
	
	select @idOrg = orgcin.ORGANIZACION_org_id from  CINTA cin, ORGANIZACION_CINTA orgcin
		where orgcin.CINTA_cin_id = cin.cin_id  and cin.cin_id = @idcinta
	

	if(@idOrganizacion = @idOrg) --Es decir si no se cambia la org
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
		
		
		INSERT INTO ORGANIZACION_CINTA(ORGANIZACION_org_id,CINTA_cin_id) VALUES(@idOrganizacion,@idcinta);
	
	
 end;