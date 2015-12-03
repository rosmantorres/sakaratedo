-- STORE PROCEDURES FINALES M8
--=========================================================================--
--Agregar RESTRICCION_COMPETENCIA                                          --
--=========================================================================--

CREATE PROCEDURE M8_AgregarRestriccionCompetencia

	@rest_comp_desc		  [varchar] (255),
	@rest_comp_edadmin	  [int],
	@rest_comp_edadmax	  [int],
	@rest_comp_rangomin	  [int],
	@rest_comp_rangomax	  [int],
	@rest_comp_sexo		  [varchar] (1),
	@rest_comp_modalidad  [varchar] (10)

AS
	BEGIN
		INSERT INTO RESTRICCION_COMPETENCIA(
			res_com_desc,
			res_com_edad_min,
			res_com_edad_max,
			res_com_rango_min,
			res_com_rango_max,
			res_com_sexo,
			res_com_modalidad
		)
		VALUES(
			@rest_comp_desc,
			@rest_comp_edadmin,
			@rest_comp_edadmax,
			@rest_comp_rangomin,
			@rest_comp_rangomax,
			@rest_comp_sexo,
			@rest_comp_modalidad
		)
	END;
GO

-- ========================================================================= --
-- Modificar RESTRICCION_COMPETENCIA
-- ========================================================================= --

CREATE PROCEDURE M8_ModificarRestriccionCompetencia

	@rest_comp_id         [int],
	@rest_comp_desc		  [varchar] (255),
	@rest_comp_edadmin	  [int],
	@rest_comp_edadmax	  [int],
	@rest_comp_rangomin	  [int],
	@rest_comp_rangomax	  [int],
	@rest_comp_sexo		  [varchar] (1),
	@rest_comp_modalidad  [varchar] (10)


AS 
	BEGIN
		UPDATE RESTRICCION_COMPETENCIA
		SET
			res_com_desc		=	@rest_comp_desc,
			res_com_edad_min	=	@rest_comp_edadmin,
			res_com_edad_max	=	@rest_comp_edadmax,
			res_com_rango_min	=	@rest_comp_rangomin,
			res_com_rango_max	=	@rest_comp_rangomax,
			res_com_sexo		=	@rest_comp_sexo,
			res_com_modalidad	=	@rest_comp_modalidad
		WHERE
			res_com_id = @rest_comp_id;
	END;
GO

-- ========================================================================= --
-- Eliminar RESTRICCION_COMPETENCIA 										--
-- ========================================================================= --

CREATE PROCEDURE M8_EliminarRestriccionCompetencia

  @rest_comp_id       [int]

AS
  BEGIN
    DELETE FROM RESTRICCION_COMPETENCIA
    WHERE res_com_id = @rest_comp_id;
  END;
GO

-- ========================================================================= --
-- CONSULTAR RESTRICCIONES											         --
-- ========================================================================= --
CREATE PROCEDURE M8_ConsultarRestriccionCompetencia

AS
	BEGIN
		SELECT rc.res_com_id as id, rc.res_com_desc as descripcion, rc.res_com_edad_min as edadMin, rc.res_com_edad_max as edadMax, rc.res_com_rango_min as rangoMin, rc.res_com_rango_max as rangoMax, 
			   rc.res_com_sexo as sexo, rc.res_com_modalidad as modalidad
		FROM RESTRICCION_COMPETENCIA rc 
	END;
GO



-- ========================================================================= --
-- RESTORNAR SI EXISTE UNA RESTRICCION DE COMPETENCIA SIMILAR                --
-- ========================================================================= --
CREATE PROCEDURE M8_ExisteRestriccionCompetencia
	
	@rest_comp_desc		  	[varchar] (255),
	@rest_comp_edadmin	 	[int],
	@rest_comp_edadmax	 	[int],
	@rest_comp_rangomin	    [int],
	@rest_comp_rangomax	    [int],	
	@rest_comp_sexo		  	[varchar] (1),
	@rest_comp_modalidad  	[varchar] (10),
	@numRestriccion     	[int] OUTPUT
AS
	BEGIN
		SELECT @numRestriccion = COUNT(*)
		FROM RESTRICCION_COMPETENCIA
		WHERE res_com_edad_min = @rest_comp_edadmin
		AND	  res_com_edad_max = @rest_comp_edadmax
		AND	   res_com_rango_min = @rest_comp_rangomin
		AND	  res_com_rango_max = @rest_comp_rangomax
		AND	  res_com_sexo		=	@rest_comp_sexo
		AND   res_com_modalidad	=	@rest_comp_modalidad
	END;

-- ========================================================================= --
-- RETORNAR TODOS LOS ID DE ATLETAS QUE CUMPLEN CON UNA RESTRICCION          --
-- ========================================================================= --

CREATE PROCEDURE M8_AtletasCumplenRestriccion

	@rest_comp_id         	[int]
AS
BEGIN
	SELECT P1.per_id as idAtleta
	FROM	PERSONA P1, RESTRICCION_COMPETENCIA RC
	WHERE RC.res_com_id = @rest_comp_id
	AND   RC.res_com_edad_min <= (SELECT datediff(dd,P1.per_fecha_nacimiento,cast(GETDATE() as date))/365)
	AND	  RC.res_com_edad_max >= (SELECT datediff(dd,P1.per_fecha_nacimiento,cast(GETDATE() as date))/365)
	OR	  RC.res_com_sexo = P1.per_sexo  
	OR    RC.res_com_sexo = 'B'
	AND   RC.res_com_rango_min <= (SELECT  C.cin_rango 
								FROM	CINTA C, HISTORIAL_CINTAS H, PERSONA P
								WHERE H.PERSONA_per_id = P1.per_id  AND H.CINTA_cin_id = C.cin_id AND H.PERSONA_per_id = P.per_id
							    AND H.his_cin_fecha = (SELECT MAX(H.his_cin_fecha)
	                        	FROM CINTA C, HISTORIAL_CINTAS H, PERSONA P
						   		WHERE H.PERSONA_per_id = P1.per_id  AND H.CINTA_cin_id = C.cin_id AND H.PERSONA_per_id = P.per_id))
	AND	  RC.res_com_rango_max >= (SELECT  C.cin_rango
								FROM	CINTA C, HISTORIAL_CINTAS H, PERSONA P
								WHERE H.PERSONA_per_id = P1.per_id  AND H.CINTA_cin_id = C.cin_id AND H.PERSONA_per_id = P.per_id
							    AND H.his_cin_fecha = (SELECT MAX(H.his_cin_fecha)
	                        	FROM CINTA C, HISTORIAL_CINTAS H, PERSONA P
						   		WHERE H.PERSONA_per_id = P1.per_id  AND H.CINTA_cin_id = C.cin_id AND H.PERSONA_per_id = P.per_id))
END;
GO

-- ========================================================================= --
-- RETORNAR lista de evento dado el id de un ATLETA                          --
-- ========================================================================= --

CREATE PROCEDURE M8_EventosQuePuedeAsistirAtleta

	@per_id         	[int]
AS
BEGIN
	SELECT DISTINCT CRC.COMPETENCIA_comp_id   as idCompetencia
	FROM	PERSONA P1, RESTRICCION_COMPETENCIA RC, COMPETENCIA C, COMP_REST_COMP CRC
	WHERE P1.per_id = @per_id
	AND	  CRC.RESTRICCION_COMPETENCIA_res_com_id = RC.res_com_id
	AND   RC.res_com_edad_min <= (SELECT datediff(dd,P1.per_fecha_nacimiento,cast(GETDATE() as date))/365)
	AND	  RC.res_com_edad_max >= (SELECT datediff(dd,P1.per_fecha_nacimiento,cast(GETDATE() as date))/365)
	OR	  RC.res_com_sexo = P1.per_sexo  
	OR    RC.res_com_sexo = 'B'
	AND   RC.res_com_rango_min <= (SELECT  C.cin_rango 
								FROM	CINTA C, HISTORIAL_CINTAS H, PERSONA P
								WHERE H.PERSONA_per_id = P1.per_id  AND H.CINTA_cin_id = C.cin_id AND H.PERSONA_per_id = P.per_id
							    AND H.his_cin_fecha = (SELECT MAX(H.his_cin_fecha)
	                        	FROM CINTA C, HISTORIAL_CINTAS H, PERSONA P
						   		WHERE H.PERSONA_per_id = P1.per_id  AND H.CINTA_cin_id = C.cin_id AND H.PERSONA_per_id = P.per_id))
	AND	  RC.res_com_rango_max >= (SELECT  C.cin_rango
								FROM	CINTA C, HISTORIAL_CINTAS H, PERSONA P
								WHERE H.PERSONA_per_id = P1.per_id  AND H.CINTA_cin_id = C.cin_id AND H.PERSONA_per_id = P.per_id
							    AND H.his_cin_fecha = (SELECT MAX(H.his_cin_fecha)
	                        	FROM CINTA C, HISTORIAL_CINTAS H, PERSONA P
						   		WHERE H.PERSONA_per_id = P1.per_id  AND H.CINTA_cin_id = C.cin_id AND H.PERSONA_per_id = P.per_id))
END;
GO

-- ========================================================================= --
-- ELIMINAR COMPETENCIA_RESTRICCION_COMPETENCIA			                     --
-- ========================================================================= --


CREATE PROCEDURE M8_EliminarCompetenciaRestriccionCompetencia
  
  @rest_comp_id      [int],
  @com_id           [int]

AS
  BEGIN
    DELETE FROM COMP_REST_COMP
    WHERE RESTRICCION_COMPETENCIA_res_com_id = @rest_comp_id
    AND   COMPETENCIA_comp_id = @com_id
  END;
GO

-- ========================================================================= --
-- CONSULTAR ID NOMBRE COMPETENCIA--		                     --
-- ========================================================================= --

--PROCEDURE CONSULTAR NOMBRE COMPETENCIA--
CREATE PROCEDURE M8_BuscarPorNombreCompetencia
	@nombreCompetencia   [varchar](100),
	@numCompetencia      [int] OUTPUT
as
 begin

	select @numCompetencia = count(*) 
	from COMPETENCIA 
	where comp_nombre = @nombreCompetencia

 end;
 go
-- ========================================================================= --
-- CONSULTA LISTA DE COMPETENCIAS NO ASOCIADAS A UN EVENTO                     --
-- ========================================================================= --
 

--PROCEDURE CONSULTA LISTA DE COMPETENCIAS--
CREATE procedure M8_ConsultarTodasLasCompetenciasNoAsociadas
 @rest_comp_id      [int]
as
	begin
		select comp.comp_id as idCompetencia, comp.comp_nombre as nombreCompetencia,
		 comp.comp_tipo as tipoCompetencia, comp.comp_status as statusCompetencia
		from COMPETENCIA comp, COMP_REST_COMP CRC, RESTRICCION_COMPETENCIA RC, ORGANIZACION org
		where RC.res_com_id = @rest_comp_id
		AND   CRC.RESTRICCION_COMPETENCIA_res_com_id <> RC.res_com_id
		AND   CRC.COMPETENCIA_comp_id = comp.comp_id
		
	end;
go

-- ========================================================================= --
-- CONSULTA LISTA DE COMPETENCIAS ASOCIADAS A UN EVENTO                     --
-- ========================================================================= --

CREATE procedure M8_ConsultarTodasLasCompetenciasAsociadas
 @rest_comp_id      [int]
as
	begin
		select comp.comp_id as idCompetencia, comp.comp_nombre as nombreCompetencia, comp.comp_tipo as tipoCompetencia, 
		comp.comp_status as statusCompetencia, comp.comp_org_todas as todasOrganizaciones

		from COMPETENCIA comp, COMP_REST_COMP CRC, RESTRICCION_COMPETENCIA RC
		where RC.res_com_id = @rest_comp_id
		AND   CRC.RESTRICCION_COMPETENCIA_res_com_id = RC.res_com_id
		AND   CRC.COMPETENCIA_comp_id = comp.comp_id
		
	end;
go


--=========================================================================--
--Agregar COMPETENCIA_RESTRICCION_COMPETENCIA                                          --
--=========================================================================--

CREATE PROCEDURE M8_AgregarCompetenciaRestriccionCompetencia
	
	@rest_comp_id      [int],
	@com_id           [int]
  
AS
	BEGIN
		INSERT INTO COMP_REST_COMP(
			RESTRICCION_COMPETENCIA_res_com_id,
    		COMPETENCIA_comp_id
		)
		VALUES(
			@rest_comp_id,
			@com_id
		)
	END;
GO



CREATE procedure M8_ConsultarRestriccionCompetenciasXId
  @rest_comp_id [int]
as
  begin
      select RC.res_com_id as id, RC.res_com_desc as descripcion, RC.res_com_edad_min as edadMin,
      		 RC.res_com_edad_max as edadMax, RC.res_com_rango_min as rangoMin, RC.res_com_rango_max as rangoMax, 
      		 RC.res_com_sexo as sexo, RC.res_com_modalidad as modalidad
            from RESTRICCION_COMPETENCIA RC
      where RC.res_com_id = @rest_comp_id

  END;
GO
