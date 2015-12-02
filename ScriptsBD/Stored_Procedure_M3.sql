---------------------------------------------------STORED PROCEDURES M3-------------------------------------

--PROCEDURE CONSULTA LISTA DE ORGANIZACIONES--
CREATE procedure M3_ConsultarOrganizacion
as
	begin
		select org.org_id as idOrganizacion, org.org_nombre as nombreOrganizacion, 
		est.est_nombre as nombreEstilo,
		org.org_telefono as telefonoOrganiacion,org.org_email as emailOrganiacion,
		org.org_direccion as direccionOrganizacion,org.org_estado as estadoOrganizacion
		from ORGANIZACION org , ESTILO est
		where org.ESTILO_est_id = est.est_id
		
	end;
go
-- Le falta la descipcion del estilo y solo las org que tengan estilo van ha aparecer

--COMO PROBAR EL PROCEDIMIENTO
--execute M3_ConsultarOrganizacion;


--PROCEDURE CONSULTA LISTA DE ORGANIZACIONES POR ID, SERIA PARA LA LISTA DESPLEGABLE ESA DEL ICONO "i"
CREATE procedure M3_ConsultarOrganizacionXId
	@id_organizacion [int]
as
	begin
		select org.org_id as idOrganizacion, org.org_nombre as nombreOrganizacion, 
		est.est_nombre as nombreEstilo, est_descripcion as descripcionEstilo,
		org.org_telefono as telefonoOrganiacion,org.org_email as emailOrganiacion,
		org.org_direccion as direccionOrganizacion,org.org_estado as estadoOrganizacion
		from ORGANIZACION org , ESTILO est
		where org.ESTILO_est_id = est.est_id and @id_organizacion = org.org_id
	end;
go
-- Le falta la descipcion del estilo

--COMO PROBAR EL PROCEDIMIENTO
execute M3_ConsultarOrganizacionXId "1";


--PROCEDURE ELIMINAR ORGANIZACION --- SOLO BORRO ORG
CREATE procedure M3_EliminarOrganizacion
	@id_organizacion [int]
as
	begin
	    delete organizacion from organizacion org
		where @id_organizacion = org.org_id
	end;
go
--COMO PROBAR EL PROCEDIMIENTO execute M3_EliminarOrganizacion "1";


--PROCEDURE AGREGAR ORGANIZACION
CREATE PROCEDURE M3_AgregarOrganizacion
	@nombreOrganizacion  	[varchar](100),
	@nombreDireccion	 	[varchar](150),
	@telefOrganizacion		[int],
	@emailOrganizacion	    [varchar](100),
	@nombreEstado        	[varchar](100),	
	@nombreEstilo		   	[varchar](100)
 
as
 begin
	declare @numEstilo as int;

	select @numEstilo = est_id from ESTILO where est_nombre = @nombreEstilo;

	INSERT INTO ORGANIZACION(org_nombre, org_direccion, org_telefono, org_email, org_estado, ESTILO_est_id) 
				VALUES (@nombreOrganizacion, @nombreDireccion, @telefOrganizacion, @emailOrganizacion, @nombreEstado, @numEstilo);
		
 end;
go
--COMO PROBAR EL PROCEDIMIENTO
--execute M3_AgregarOrganizacion "Seito Karate-do","Av 24, calle 8 edificio Morales, Altamira, Caracas","2123117754","seitokaratedo@gmail.com","Distrito Federal","Cobra-do";


--PROCEDURE MODIFICAR ORGANIZACION--
CREATE PROCEDURE M3_ModificarOrganizacion
	@idOrganizacion			[int],
	@nombreOrganizacion  	[varchar](100),
	@nombreDireccion	 	[varchar](150),
	@telefOrganizacion		[int],
	@emailOrganizacion	    [varchar](100),
	@nombreEstado        	[varchar](100),	
	@nombreEstilo		   	[varchar](100)
 
as
 begin
	declare @numEstilo as int;

	select @numEstilo = est_id from ESTILO where est_nombre = @nombreEstilo;

	UPDATE ORGANIZACION
		SET 
			org_nombre        = @nombreOrganizacion,
			org_direccion     = @nombreDireccion,
			org_telefono	  = @telefOrganizacion,
			org_email         = @emailOrganizacion,
			org_estado        = @nombreEstado,
			ESTILO_est_id     = @numEstilo
			WHERE
			org_id = @idOrganizacion;	
	
 end;
go

--COMO PROBAR EL PROCEDIMIENTO
--execute M3_ModificarOrganizacion "6","Prueba Karate-do","Av 24, calle 8 edificio Morales, Altamira, Caracas","2123117754","seitokaratedo@gmail.com","Distrito Federal","Cobra-do";
