-----------------------PROCEDURE RESTRICCION_EVENTO----------------------------------------------------------------------
-----------------------PROCEDURE RESTRICCION_EVENTO----------------------------------------------------------------------
-----------------------PROCEDURE RESTRICCION_EVENTO----------------------------------------------------------------------
-----------------------PROCEDURE AGREGAR NUEVA RESTRICCION_EVENTO---------------------------
CREATE PROCEDURE M8_Agregar_Restriccion_Evento
	@descripcion        [varchar](255),
	@edad_minima		int,
	@edad_maxima	    int,
	@sexo      			[varchar](1),
	@eventoid			int

as
 begin

	INSERT INTO dbo.RESTRICCION_EVENTO
    VALUES (@descripcion,@edad_minima,@edad_maxima,@sexo,@eventoid);

 end;
GO
-----------------------PROCEDURE MODIFICAR RESTRICCION_EVENTO---------------------------
CREATE PROCEDURE M8_Modificar_Restriccion_Evento
	@res_eve_id         int,
	@descripcion        [varchar](255),
	@edad_minima		int,
	@edad_maxima	    int,
	@sexo      			[varchar](1),
	@eventoid			int

as
 begin

	UPDATE dbo.RESTRICCION_EVENTO
	SET res_eve_desc = @descripcion, res_eve_edad_min = @edad_minima, res_eve_edad_max = @edad_maxima, res_eve_sexo = @sexo
	WHERE res_eve_id = @res_eve_id
 end;
GO
-----------------------PROCEDURE ELIMINAR RESTRICCION_EVENTO---------------------------
CREATE PROCEDURE M8_Eliminar_Restriccion_Evento
	@res_eve_id         int

as
 begin

	DELETE FROM dbo.RESTRICCION_EVENTO
	WHERE res_eve_id = @res_eve_id
 end;
GO
-----------------------PROCEDURE CONSULTAR EVENTOS SIN RESTRICCION---------------------------
CREATE PROCEDURE M8_CONSULTAR_EVENTOS_SINRESTRICCION
as
 begin
 	select e2.eve_id as idEvento, e2.eve_nombre as nombreEvento from
    EVENTO e2
    where e2.eve_id not in 
    (select e1.eve_id as eve_id 
    from RESTRICCION_EVENTO r1, EVENTO e1
    where r1.res_eve_id = e1.eve_id)
 end;
GO
 -----------------------PROCEDURE CONSULTAR EVENTOS CON RESTRICCION---------------------------
CREATE PROCEDURE M8_CONSULTAR_EVENTOS_CONRESTRICCION
as
 begin
 	select res.res_eve_id as res_eve_id, res.res_eve_desc as res_eve_desc,
 	res.res_eve_edad_min as edad_min, res.res_eve_edad_max as edad_max,
 	res.res_eve_sexo as sexo, res.EVENTO_eve_id as idEvento, ev.eve_nombre as eve_nombre
	from RESTRICCION_EVENTO as res, Evento as ev
	where res.EVENTO_eve_id = ev.eve_id
 end;
GO
 -----------------------PROCEDURE CONSULTAR CINTAS DE RESTRICCION_EVENTO---------------------------
CREATE PROCEDURE M8_CONSULTAR_CINTAS_RESTRICCION_EVENTO
	@res_eve_id         int

as
 begin
	SELECT rh.CINTA_cin_id as cinta_id, cin.cin_color_nombre as cin_color_nombre  FROM RH_CINTA as rh, CINTA as cin
	WHERE rh.RESTRICCION_EVENTO_res_eve_id = @res_eve_id and rh.CINTA_cin_id = cin.cin_id	
 end;
GO
-----------------------PROCEDURE RH_CINTA----------------------------------------------------------------------
-----------------------PROCEDURE RH_CINTA----------------------------------------------------------------------
-----------------------PROCEDURE RH_CINTA----------------------------------------------------------------------
-----------------------PROCEDURE AGREGAR NUEVA RH_CINTA---------------------------
CREATE PROCEDURE M8_Agregar_RH_Cinta
	@cintaid			int,
	@res_eve_id 	    int

as
 begin

	INSERT INTO dbo.RH_Cinta
    VALUES (@res_eve_id ,@cintaid);

 end;
GO
-----------------------PROCEDURE ELIMINAR RH_CINTA TODO---------------------------
CREATE PROCEDURE M8_Eliminar_RH_Cinta
	@res_eve_id         int

as
 begin

	DELETE FROM dbo.RH_Cinta
	WHERE  RESTRICCION_EVENTO_res_eve_id = @res_eve_id  
 end;
GO
-- ========================================================================= --
-- RETORNAR TODOS LOS ID DE ATLETAS QUE CUMPLEN CON UNA RESTRICCION          --
-- ========================================================================= --

CREATE PROCEDURE M8_AtletasCumplenRestriccionEvento

	@eventoid        	[int]
AS
BEGIN
	SELECT P1.per_id as idAtleta
	FROM	PERSONA P1, RESTRICCION_EVENTO RC 
	WHERE RC.EVENTO_eve_id = @eventoid
	AND   RC.res_eve_edad_min <= (SELECT datediff(dd,P1.per_fecha_nacimiento,cast(GETDATE() as date))/365)
	AND	  RC.res_eve_edad_max >= (SELECT datediff(dd,P1.per_fecha_nacimiento,cast(GETDATE() as date))/365)
	AND	  (RC.res_eve_sexo = P1.per_sexo  
	OR    RC.res_eve_sexo = 'B')

	END;
GO

-- ========================================================================= --
-- RETORNAR lista de evento dado el id de un ATLETA                          --
-- ========================================================================= --

CREATE PROCEDURE M8_EventosQuePuedeAsistirAtleta

	@per_id         	[int]
AS
BEGIN
SELECT DISTINCT RC.EVENTO_eve_id   as idEvento, c.eve_nombre as nombreEvento
	FROM	PERSONA P1, RESTRICCION_EVENTO RC, EVENTO C
	WHERE P1.per_id = @per_id
	AND RC.EVENTO_eve_id = c.eve_id
	AND   RC.res_eve_edad_min <= (SELECT datediff(dd,P1.per_fecha_nacimiento,cast(GETDATE() as date))/365)
	AND	  RC.res_eve_edad_max >= (SELECT datediff(dd,P1.per_fecha_nacimiento,cast(GETDATE() as date))/365)
	AND	  (RC.res_eve_sexo = P1.per_sexo  
	OR    RC.res_eve_sexo = 'B')

END;
GO

 ----------------------------------STORED PROCEDURES M8-------------------------------------

------------------PROCEDURE CONSULTA DE RESTRICCIONES POR CINTA------------

CREATE PROCEDURE M8_Consultar_Restriccion_Cinta
	@id_cinta int
AS
	begin
		SELECT res_cin_descripcion as DESCRIPCION from RESTRICCION_CINTA 
			where 
				@id_cinta = CINTA_cin_id
	end;
GO

------------------PROCEDURE AGREGAR NUEVA RESTRICCION DE CINTA------------


CREATE PROCEDURE M8_Agregar_Restriccion_Cinta
	@id_cinta            int,
	@tiempo_minimo       int,
	@puntaje_minimo      int,
	@horas_docentes      int,
	@descripcion   [varchar](255)

as
 begin
	

	INSERT INTO dbo.RESTRICCION_CINTA (
    
    res_cin_descripcion,
    res_cin_tiemp_min,
    res_cin_punt_min,
    res_cin_horas_docent,
    CINTA_cin_id
    ) 
    VALUES (@descripcion,@tiempo_minimo,@puntaje_minimo,@horas_docentes,@id_cinta);

 end;
GO

----Execute M8_Agregar_Restriccion_Cinta "INSERT DE PRUEBA",10,2,3,9;--

CREATE PROCEDURE M8_Modificar_Restriccion_Cinta
	@id_restriccion      int,
	@tiempo_minimo       int,
	@puntaje_minimo      int,
	@horas_docentes      int
AS
	begin
		
		UPDATE RESTRICCION_CINTA
		SET
			res_cin_tiemp_min = @tiempo_minimo,
			res_cin_punt_min = @puntaje_minimo,
			res_cin_horas_docent = @horas_docentes
		WHERE
			res_cin_id = @id_restriccion;
	end;
GO

CREATE procedure M8_Consultar_Restricciones_Cinta
as
	begin
		select res_cin_id as id_restricion, res_cin_descripcion as descripcion 
		from RESTRICCION_CINTA
		
	end;
GO

CREATE procedure M8_Consultar_Cintas
as
	begin
		select cin_id as id_cinta, cin_color_nombre  as color 
		from CINTA
		
	end;	
GO