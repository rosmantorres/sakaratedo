CREATE PROCEDURE M9_AgregarHorario
	
    @hor_fecha_inicio [DATE], 
    @hor_fecha_fin    [DATE] ,
    @hor_hora_inicio  [INTEGER],
    @hor_hora_fin     [INTEGER] 
as
	begin
		INSERT INTO HORARIO (hor_fecha_inicio,hor_fecha_fin,hor_hora_inicio,hor_hora_fin) VALUES (@hor_fecha_inicio,@hor_fecha_fin,@hor_hora_inicio, @hor_hora_fin) ;

	end;

GO


CREATE PROCEDURE M9_AgregarEventoCompleto
	@nombre       [VARCHAR](120),
    @descripcion  [VARCHAR](120),
    @costo [FLOAT]  ,
	@estado [BIT],
	@idPersona [INTEGER],
    @idUbicacion [INTEGER],
    @idTipoEvento [INTEGER],
	@idCategoria [INTEGER],
	@fechaInicio [DATE], 
    @fechaFin    [DATE] ,
    @horaInicio  [INTEGER],
    @horaFin     [INTEGER] 	
	

AS
	
	BEGIN
		DECLARE @idHorario as integer ;
		DECLARE @idDojo as integer;
		exec "M9_AgregarHorario" @hor_fecha_inicio=@fechaInicio, @hor_fecha_fin = @fechaFin, @hor_hora_inicio = @horaInicio , @hor_hora_fin = @horaFin
		Select @idHorario =  Count(*) From HORARIO;
		Select @idDojo = persona.DOJO_doj_id from PERSONA persona WHERE persona.per_id = @idPersona;
		if (@idCategoria = null) and (@idDojo = null)
			INSERT INTO EVENTO (eve_nombre,eve_costo,eve_descripcion,eve_estado,DOJO_doj_id,CATEGORIA_cat_id,HORARIO_hor_id,TIPO_EVENTO_tip_id,UBICACION_ubi_id) 
			VALUES (@nombre,@costo,@descripcion,1,null,null,@idHorario,@idTipoEvento,@idUbicacion);
		else
			INSERT INTO EVENTO (eve_nombre,eve_costo,eve_descripcion,eve_estado,DOJO_doj_id,CATEGORIA_cat_id,HORARIO_hor_id,TIPO_EVENTO_tip_id,UBICACION_ubi_id) 
			VALUES (@nombre,@costo,@descripcion,1,@idDojo,@idCategoria,@idHorario,@idTipoEvento,@idUbicacion);
			
	
	
	END
	
GO




CREATE PROCEDURE M9_AgregarTipoEvento
	@nombre   [varchar](100)
as
	begin
		INSERT INTO TIPO_EVENTO (tip_nombre) VALUES (@nombre);
	end;
	
GO


CREATE procedure M9_ConsultarAscensosRangoFecha
@fechaInicio date,
@fechaFin date
as
	begin
		select evento.eve_id as idEvento, evento.eve_nombre as nombreEvento, evento.eve_costo as costoEvento, evento.eve_descripcion as descripcionEvento, evento.eve_estado as estadoEvento, tipo.tip_nombre as tipoEvento,
		horario.hor_fecha_inicio as fechaInicio, horario.hor_fecha_fin as fechaFin, horario.hor_hora_inicio as horaInicio, horario.hor_hora_fin as horaFin
		
		from EVENTO evento, HORARIO horario, TIPO_EVENTO tipo
		where (tipo.tip_id = evento.TIPO_EVENTO_tip_id)and (tipo.tip_nombre='Pase de Cinta')and(evento.HORARIO_hor_id = horario.hor_id) and (evento.TIPO_EVENTO_tip_id = tipo.tip_id) and (horario.hor_fecha_inicio>=@fechaInicio) and (horario.hor_fecha_fin <=@fechaFin) and (evento.eve_estado = 'True')

		
	end;
	
GO

CREATE procedure M9_ConsultarEventos
as
	begin
		select evento.eve_id as idEvento, evento.eve_nombre as nombreEvento, evento.eve_costo as costoEvento, evento.eve_descripcion as descripcionEvento, evento.eve_estado as estadoEvento, tipo.tip_nombre as tipoEvento,
		horario.hor_fecha_inicio as fechaInicio, horario.hor_fecha_fin as fechaFin, horario.hor_hora_inicio as horaInicio, horario.hor_hora_fin as horaFin
		
		from EVENTO evento, HORARIO horario, TIPO_EVENTO tipo
		where evento.HORARIO_hor_id = horario.hor_id and evento.TIPO_EVENTO_tip_id = tipo.tip_id

		
	end;
	
GO

CREATE procedure M9_ConsultarEventosRangoFecha
@fechaInicio date,
@fechaFin date
as
	begin
		select evento.eve_id as idEvento, evento.eve_nombre as nombreEvento, evento.eve_costo as costoEvento, evento.eve_descripcion as descripcionEvento, evento.eve_estado as estadoEvento, tipo.tip_nombre as tipoEvento,
		horario.hor_fecha_inicio as fechaInicio, horario.hor_fecha_fin as fechaFin, horario.hor_hora_inicio as horaInicio, horario.hor_hora_fin as horaFin
		
		from EVENTO evento, HORARIO horario, TIPO_EVENTO tipo
		where (evento.HORARIO_hor_id = horario.hor_id) and (evento.TIPO_EVENTO_tip_id = tipo.tip_id) and (horario.hor_fecha_inicio>=@fechaInicio) and (horario.hor_fecha_fin <=@fechaFin) and (evento.eve_estado = 'True')

		
	end;

GO

CREATE PROCEDURE M9_ConsultarEventoXID
	@idEvento integer
	

AS
	
	BEGIN
		select evento.eve_nombre as nombreEvento, evento.eve_costo as costoEvento, evento.eve_descripcion as descripcionEvento, evento.eve_estado as estadoEvento, tipo.tip_nombre as tipoEvento,
		horario.hor_fecha_inicio as fechaInicio, horario.hor_fecha_fin as fechaFin, horario.hor_hora_inicio as horaInicio, horario.hor_hora_fin as horaFin
		
		from EVENTO evento, HORARIO horario, TIPO_EVENTO tipo
		where (evento.HORARIO_hor_id = horario.hor_id) and (evento.TIPO_EVENTO_tip_id = tipo.tip_id) and (evento.eve_id = @idEvento)
	
	
	END

GO

CREATE PROCEDURE M9_ConsultarHorario
	
	@id [integer],
	@id2 [integer] output,
	@fechaInicio [DATE] output, 
    @fechaFin    [DATE] output,
    @horaInicio  [INTEGER] output,
    @horaFin     [INTEGER] output	   
AS
 BEGIN
	
	SELECT @id2=hor_id, @fechaInicio= hor_fecha_inicio , @fechaFin = hor_fecha_fin , @horaInicio = hor_hora_inicio , @horaFin = hor_hora_fin 
	FROM HORARIO H
	WHERE (H.hor_id=@id) 
	RETURN
 END
 
GO

 CREATE PROCEDURE M9_ConsultarUbicacion
	
	@id [integer],
	@id2       [INTEGER] output,
    @latitud   [VARCHAR] (100) output ,
    @longitud  [VARCHAR] (100) output,
    @ciudad    [VARCHAR] (100) output,
    @estado    [VARCHAR](100) output,
    @direccion [VARCHAR] (100)    
	
AS
 BEGIN
	
	SELECT @id2=ubi_id, @latitud= ubi_latitud , @longitud = ubi_longitud , @ciudad = ubi_ciudad , @estado = ubi_estado, @direccion = ubi_direccion
	FROM UBICACION U
	WHERE (U.ubi_id=@id) 
	RETURN
 END
 
GO

CREATE PROCEDURE M9_TodasLasFechas
AS
 BEGIN
		Select horario.hor_fecha_inicio as fechaInicio, horario.hor_fecha_fin as fechaFin, horario.hor_hora_inicio as horaInicio, horario.hor_hora_fin as horaFin
		from EVENTO evento, HORARIO horario
		where evento.eve_estado = 'True' and evento.HORARIO_hor_id = horario.hor_id
 END
 
GO

 CREATE PROCEDURE M9_TodasLasFechasAscensos
AS
 BEGIN
		Select horario.hor_fecha_inicio as fechaInicio, horario.hor_fecha_fin as fechaFin, horario.hor_hora_inicio as horaInicio, horario.hor_hora_fin as horaFin
		from EVENTO evento, HORARIO horario , TIPO_EVENTO tipo
		where evento.eve_estado = 'True' and evento.HORARIO_hor_id = horario.hor_id and tipo.tip_nombre = 'Pase de Cinta' and tipo.tip_id = evento.TIPO_EVENTO_tip_id
 END
 GO

 Create Procedure M9_ModificarEvento
	@idEvento   [INTEGER], 
	@nombre       [VARCHAR](120),
    @descripcion  [VARCHAR](120),
    @costo [FLOAT]  ,
	@estado [BIT],
    @idUbicacion [INTEGER],
    @idTipoEvento [INTEGER],
	@fechaInicio [DATE], 
    @fechaFin    [DATE] ,
    @horaInicio  [INTEGER],
    @horaFin     [INTEGER] 
	
	AS

	BEGIN
		DECLARE @idHorario as integer ;
		Declare @nuevoIdHorario as Integer;
		Select @idHorario =  evento.HORARIO_hor_id From EVENTO evento WHERE evento.eve_id = @idEvento;
		
		exec "M9_AgregarHorario" @hor_fecha_inicio=@fechaInicio, @hor_fecha_fin = @fechaFin, @hor_hora_inicio = @horaInicio , @hor_hora_fin = @horaFin;
		Select @nuevoIdHorario =  Count(*) From HORARIO;

		Update EVENTO set eve_nombre = @nombre , eve_descripcion = @descripcion, eve_estado = @estado , eve_costo = @costo, TIPO_EVENTO_tip_id = @idTipoEvento, HORARIO_hor_id = @nuevoIdHorario, UBICACION_ubi_id = @idUbicacion WHERE eve_id = @idEvento;

		Delete From HORARIO WHERE hor_id = @idHorario;
		
	END

GO

CREATE PROCEDURE M9_TodosLosTiposEvento
AS
 BEGIN
		Select  tipo.tip_id as idTipo, tipo.tip_nombre as tipoEvento
		from TIPO_EVENTO tipo
		
 END
 
GO

CREATE PROCEDURE M9_AgregarEventoConTipo
	@nombre       [VARCHAR](120),
    @descripcion  [VARCHAR](120),
    @costo [FLOAT]  ,
	@estado [BIT],
	@idPersona [INTEGER],
    @idUbicacion [INTEGER],
    @nombreTipoEvento [VARCHAR](120),
	@fechaInicio [DATE], 
    @fechaFin    [DATE] ,
    @horaInicio  [INTEGER],
    @horaFin     [INTEGER] 	
	

AS
	
	BEGIN
		DECLARE @idHorario as integer ;
		DECLARE @idDojo as integer;
		DECLARE @idTipoEvento as integer;
		exec "M9_AgregarHorario" @hor_fecha_inicio=@fechaInicio, @hor_fecha_fin = @fechaFin, @hor_hora_inicio = @horaInicio , @hor_hora_fin = @horaFin;
		exec "M9_AgregarTipoEvento" @nombre = @nombreTipoEvento;
		Select @idHorario =  Count(*) From HORARIO;
		Select @idDojo = persona.DOJO_doj_id from PERSONA persona WHERE persona.per_id = @idPersona;
		Select @idTipoEvento = Count(*) FROM TIPO_EVENTO;
		INSERT INTO EVENTO (eve_nombre,eve_costo,eve_descripcion,eve_estado,DOJO_doj_id,CATEGORIA_cat_id,HORARIO_hor_id,TIPO_EVENTO_tip_id,UBICACION_ubi_id) 
		VALUES (@nombre,@costo,@descripcion,1,@idDojo,null,@idHorario,@idTipoEvento,@idUbicacion);
			
	
	
	END
	
GO