CREATE PROCEDURE M14_AgregarDiseño
		 
		@dis_contenido   [varchar](8000),
		@PLANILLA_pla_id  int
AS 
BEGIN
		INSERT INTO DISEÑO(dis_contenido, PLANILLA_pla_id)
	    VALUES(@dis_contenido, @PLANILLA_pla_id)

END;
GO

CREATE PROCEDURE M14_CambioDeStatusPlanilla
	@pla_id int
AS
BEGIN
    IF((SELECT pla_status FROM PLANILLA WHERE pla_id= @pla_id)=1)
	BEGIN
	   UPDATE PLANILLA 
	      SET pla_status =0
		  WHERE pla_id=@pla_id
	END
	ELSE
	BEGIN
	   UPDATE PLANILLA 
	      SET pla_status =1
		  WHERE pla_id=@pla_id
	END
END;
GO

-----------------------------------------------------------
CREATE PROCEDURE M14_ConsultarDiseño
	
	@PLANILLA_pla_id [int]	
	   
AS
 BEGIN
	
	SELECT D.dis_id, D.dis_contenido
	FROM DISEÑO D
	WHERE D.PLANILLA_pla_id = @PLANILLA_pla_id
 END
 GO

 -------------------------------------------------------
 CREATE PROCEDURE M14_ConsultarPlanillasASolicitar
	
AS
 BEGIN
	
	SELECT P.pla_id, P.pla_nombre,(SELECT T.tip_nombre FROM TIPO_PLANILLA T WHERE P.TIPO_PLANILLA_tip_id= T.tip_id) AS tipo, D.dis_id
	FROM DISEÑO D, PLANILLA P
	WHERE D.PLANILLA_pla_id= p.pla_id AND P.pla_status=1
 END
 GO
 -----------------------------------------------------------
 CREATE PROCEDURE M14_ConsultarPlanillasCreadas
AS
BEGIN
	SELECT P.pla_id, P.pla_nombre, P.pla_status, T.tip_nombre, T.tip_id
	FROM PLANILLA p, TIPO_PLANILLA T
	WHERE P.TIPO_PLANILLA_tip_id=T.tip_id
END
GO
---------------------------------------------------
CREATE PROCEDURE M14_ConsultarSolicitudPlanilla
		@PERSONA_per_id      [varchar](50)
AS 
BEGIN
		SELECT S.sol_pla_id,S.INSCRIPCION_ins_id, S.sol_pla_fecha_creacion, S.sol_pla_fecha_retiro,
		S.sol_pla_fecha_reincorporacion,S.sol_pla_motivo,S.PLANILLA_pla_id,
		I.PERSONA_per_id, (SELECT E.eve_nombre FROM EVENTO E WHERE I.EVENTO_eve_id =E.eve_id and i.ins_id=s.INSCRIPCION_ins_id) as eve_nombre,(SELECT C.comp_nombre FROM COMPETENCIA C WHERE I.COMPETENCIA_comp_id = C.comp_id and i.ins_id=s.INSCRIPCION_ins_id) as comp_nombre,(SELECT p.pla_nombre FROM PLANILLA P WHERE P.pla_id= S.PLANILLA_pla_id) AS pla_nombre, (SELECT T.tip_nombre FROM TIPO_PLANILLA T WHERE P.TIPO_PLANILLA_tip_id =T.tip_id And P.pla_id= s.PLANILLA_pla_id) AS tipo
		FROM SOLICITUD_PLANILLA S, INSCRIPCION I, PLANILLA P
		WHERE @PERSONA_per_id= I.PERSONA_per_id and I.ins_id = s.INSCRIPCION_ins_id and (i.EVENTO_eve_id is not null or i.COMPETENCIA_comp_id is not null) and P.pla_id= s.PLANILLA_pla_id
	    

END;
GO
-------------------------------------------
CREATE PROCEDURE M14_ELIMINAR_SOLICITUD
   @pla_sol_id int
AS 
BEGIN
    DELETE FROM SOLICITUD_PLANILLA
	WHERE sol_pla_id= @pla_sol_id
END
GO
-----------------------------------------------
CREATE PROCEDURE M14_InsertarSolicitudPlanilla
		@sol_pla_fecha_creacion          [date],
		@sol_pla_fecha_retiro            [date],
		@sol_pla_fecha_reincorporacion   [date],
		@sol_pla_motivo                  [varchar](1000),
		@PLANILLA_pla_id                 int,
		@INSCRIPCION_ins_id              int
AS 
BEGIN
		INSERT INTO SOLICITUD_PLANILLA(sol_pla_fecha_creacion, sol_pla_fecha_retiro,
		sol_pla_fecha_reincorporacion,sol_pla_motivo,PLANILLA_pla_id,INSCRIPCION_ins_id)
	    VALUES(@sol_pla_fecha_creacion, @sol_pla_fecha_retiro,
		@sol_pla_fecha_reincorporacion,@sol_pla_motivo,@PLANILLA_pla_id,@INSCRIPCION_ins_id)

END;
GO
---------------------------------------------------------
CREATE PROCEDURE M14_ModificarDiseño
	@dis_id int,
	@dis_contenido [varchar](8000)
AS
BEGIN
	UPDATE DISEÑO 
	    SET dis_contenido = @dis_contenido
		where dis_id=@dis_id
END;
GO
---------------------------------------------------
CREATE PROCEDURE M14_Procedure_IdTipoPlanilla
	
	@tip_nombre [varchar] (100),
	@tip_id [int] OUTPUT
AS
 BEGIN
	SELECT @tip_id= tip_id
    FROM TIPO_PLANILLA
	where tip_nombre=@tip_nombre;
	RETURN
 END
 GO
 ------------------------------------------
 CREATE PROCEDURE M14_Procedure_ListarDatos
	
AS
 BEGIN
	SELECT dat_nombre
    FROM Dato;
 END;
 GO
 -----------------------------------
 CREATE PROCEDURE M14_Procedure_ListarTipoPlanilla
	
AS
 BEGIN
	SELECT tip_id , tip_nombre
    FROM TIPO_PLANILLA;
 END;
 GO

 ---------------------------
 ----------------AGREGAR DATOS Y PLANILLA---------------------
CREATE PROCEDURE M14_ProcedureAgregarDatoPlanilla
	@pla_nombre [varchar](100),
	@dat_nombre [varchar](100)
	


as
 begin
     
   --insertar datos y planilla--
    INSERT INTO PLA_DAT(DATO_dat_id,PLANILLA_pla_id) 
	VALUES((select dat_id from DATO where dat_nombre=@dat_nombre),(select MAX(pla_id) from PLANILLA where pla_nombre=@pla_nombre));  

 end;
 GO

 -------------------------------
 ---------------AGREGAR PLANILLA------------------------------
CREATE PROCEDURE M14_ProcedureAgregarPlanilla
	@pla_nombre [varchar] (100),
	@pla_status [bit],
	@TIPO_PLANILLA_tip_id [int]

as
 begin
  
    INSERT INTO PLANILLA(pla_nombre,pla_status,TIPO_PLANILLA_tip_id) 
	VALUES(@pla_nombre,@pla_status,@TIPO_PLANILLA_tip_id);  

 end;
 GO
 -----------------------
 ------------------AGREGAR TIPO PLANILLA------------------------
CREATE PROCEDURE M14_ProcedureAgregarTipoPlanilla
	@tip_nombre [varchar] (100)

as
 begin
  
    INSERT INTO TIPO_PLANILLA(tip_nombre) 
	VALUES(@tip_nombre); 

 end;
 GO
 ----------------Obtener Datos----------------------------------
CREATE PROCEDURE M14_ProcedureDatosPlanilla
	@pla_nombre [varchar] (100),
	@pla_status [bit],
	@TIPO_PLANILLA_tip_id [int]

as
 begin

    INSERT INTO PLANILLA(pla_nombre,pla_status,TIPO_PLANILLA_tip_id) 
	VALUES(@pla_nombre,@pla_status,@TIPO_PLANILLA_tip_id);  

 end;
 GO