CREATE
  TABLE ASISTENCIA
  (
    asi_asistio CHAR(1) NOT NULL ,
    INSCRIPCION_ins_id INTEGER NOT NULL ,
    CONSTRAINT ASISTENCIA_PK PRIMARY KEY CLUSTERED (INSCRIPCION_ins_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

ALTER TABLE ASISTENCIA
ADD
CHECK ( asi_asistio IN ('S', 'N') )
GO

CREATE
  TABLE CATEGORIA
  (
    cat_id        INTEGER IDENTITY(1,1) NOT NULL ,
    cat_edad_ini  INTEGER NOT NULL ,
    cat_edad_fin  INTEGER ,
    cat_cinta_ini VARCHAR (100) NOT NULL ,
    cat_cinta_fin VARCHAR (100) ,
    cat_sexo      CHAR NOT NULL ,
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

CREATE
  TABLE CINTA
  (
    cin_id                       INTEGER IDENTITY(1,1) NOT NULL ,
    cin_color_nombre             VARCHAR (100) NOT NULL ,
    cin_rango                    VARCHAR (100) NOT NULL ,
    cin_clasificacion            VARCHAR (100) NOT NULL ,
    cin_significado              VARCHAR (150) NOT NULL ,
    cin_orden                    INTEGER NOT NULL ,
    RESTRICCION_CINTA_res_cin_id INTEGER NOT NULL ,
    CONSTRAINT CINTA_PK PRIMARY KEY CLUSTERED (cin_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO
CREATE UNIQUE NONCLUSTERED INDEX
CINTA__IDX ON CINTA
(
  RESTRICCION_CINTA_res_cin_id
)
ON "default"
GO

CREATE
  TABLE COMPETENCIA
  (
    comp_id                            INTEGER IDENTITY(1,1) NOT NULL ,
    comp_nombre                        VARCHAR (100) NOT NULL ,
    comp_tipo                          INTEGER NOT NULL ,
    CATEGORIA_comp_id                   INTEGER NOT NULL ,
    UBICACION_comp_id                   INTEGER NOT NULL ,
    ORGANIZACION_comp_id                INTEGER ,
    comp_org_todas BIT NOT NULL ,
    comp_status    VARCHAR (100) NOT NULL ,
    comp_fecha_ini DATETIME NOT NULL ,
    comp_fecha_fin DATETIME NOT NULL ,
    comp_costo FLOAT NOT NULL ,
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

CREATE
  TABLE COMPRA_CARRITO
  (
    com_id           INTEGER IDENTITY(1,1) NOT NULL ,
    com_tipo_pago    VARCHAR (100) ,
    com_fecha_compra DATE ,
    com_estado       VARCHAR (20) NOT NULL ,
    PERSONA_per_id   INTEGER NOT NULL ,
	 CONSTRAINT COMPRA_CARRITO_PK PRIMARY KEY CLUSTERED (com_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE
  TABLE DATO
  (
    dat_id          INTEGER IDENTITY(1,1) NOT NULL ,
    dat_nombre      VARCHAR (100) NOT NULL ,
    dat_abreviatura VARCHAR (20) NOT NULL ,
    CONSTRAINT DATO_PK PRIMARY KEY CLUSTERED (dat_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE
  TABLE DETALLE_COMPRA
  (
    det_id                INTEGER IDENTITY(1,1) NOT NULL ,
	COMPRA_CARRITO_com_id INTEGER NOT NULL,
    det_precio 	          FLOAT NOT NULL ,
    MATRICULA_mat_id      INTEGER ,
    MATRICULA_per_id      INTEGER ,
    IMPLEMENTO_inv_id     INTEGER ,
    EVENTO_eve_id         INTEGER ,
    MATRICULA_doj_id      INTEGER ,
    CONSTRAINT DETALLE_COMPRA_PK PRIMARY KEY CLUSTERED (det_id,COMPRA_CARRITO_com_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE
  TABLE DISEÑO
  (
    dis_id          INTEGER NOT NULL ,
    dis_contenido   TEXT NOT NULL ,
    PLANILLA_pla_id INTEGER NOT NULL ,
    CONSTRAINT DISEÑO_PK PRIMARY KEY CLUSTERED (dis_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO
CREATE UNIQUE NONCLUSTERED INDEX
DISEÑO__IDX ON DISEÑO
(
  PLANILLA_pla_id
)
ON "default"
GO

CREATE
  TABLE DOJO
  (
    doj_id             INTEGER NOT NULL ,
    doj_rif            VARCHAR (150) NOT NULL ,
    doj_nombre         VARCHAR (150) NOT NULL ,
    doj_telefono       INTEGER NOT NULL ,
    doj_email          VARCHAR (120) NOT NULL ,
    doj__logo          VARCHAR (150) ,
    doj_fecha_registro DATE NOT NULL ,
    doj_status BIT NOT NULL ,
    ORGANIZACION_org_id INTEGER NOT NULL ,
    UBICACION_ubi_id    INTEGER NOT NULL ,
    CONSTRAINT DOJO_PK PRIMARY KEY CLUSTERED (doj_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE
  TABLE EMAIL
  (
    ema_id    INTEGER IDENTITY(1,1) NOT NULL ,
    ema_email VARCHAR (100) NOT NULL ,
    ema_principal BIT NOT NULL ,
    PERSONA_per_id INTEGER NOT NULL ,
    CONSTRAINT EMAIL_PK PRIMARY KEY CLUSTERED (ema_id, PERSONA_per_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE
  TABLE ESTILO
  (
    est_id          INTEGER IDENTITY(1,1) NOT NULL ,
    est_nombre      VARCHAR (150) NOT NULL ,
    est_descripcion VARCHAR (150) NOT NULL ,
    CONSTRAINT ESTILO_PK PRIMARY KEY CLUSTERED (est_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE
  TABLE EVENTO
  (
    eve_id           INTEGER IDENTITY(1,1) NOT NULL ,
	eve_nombre       VARCHAR (120) NOT NULL ,
    eve_descripcion  VARCHAR (120) NOT NULL ,
    eve_costo FLOAT NOT NULL ,
	eve_estado BIT Not Null,
    HORARIO_hor_id   INTEGER NOT NULL ,
    UBICACION_ubi_id INTEGER NOT NULL ,
    DOJO_doj_id      INTEGER ,
    CATEGORIA_cat_id INTEGER,
    TIPO_EVENTO_tip_id INTEGER NOT NULL ,
    CONSTRAINT EVENTO_PK PRIMARY KEY CLUSTERED (eve_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO
CREATE
  TABLE EVENTO_RESTRICCION
  (
    EVENTO_eve_id                 INTEGER NOT NULL ,
    RESTRICCION_EVENTO_res_eve_id INTEGER NOT NULL ,
    eve_res_id                    INTEGER IDENTITY(1,1) NOT NULL ,
    CONSTRAINT EVENTO_RESTRICCION_PK PRIMARY KEY CLUSTERED (eve_res_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE
  TABLE HISTORIAL_CINTAS
  (
    PERSONA_per_id INTEGER NOT NULL ,
    EVENTO_eve_id  INTEGER NOT NULL ,
    his_cin_fecha  DATE NOT NULL ,
    CINTA_cin_id   INTEGER NOT NULL ,
    CONSTRAINT HISTORIAL_CINTAS_PK PRIMARY KEY CLUSTERED (PERSONA_per_id,
    CINTA_cin_id, EVENTO_eve_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE
  TABLE HISTORIAL_MATRICULA
  (
    his_mat_fecha_vigente DATE NOT NULL ,
    his_mat_modalidad     VARCHAR (50) NOT NULL ,
    his_mat_monto FLOAT NOT NULL ,
    DOJO_doj_id INTEGER NOT NULL ,
    CONSTRAINT HISTORIAL_MATRICULA_PK PRIMARY KEY CLUSTERED (DOJO_doj_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE
  TABLE HORARIO
  (
    hor_id           INTEGER IDENTITY(1,1) NOT NULL ,
    hor_fecha_inicio DATE NOT NULL ,
    hor_fecha_fin    DATE NOT NULL ,
    hor_hora_inicio  INTEGER NOT NULL ,
    hor_hora_fin     INTEGER NOT NULL ,
    CONSTRAINT HORARIO_PK PRIMARY KEY CLUSTERED (hor_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE
  TABLE IMPLEMENTO
  (
    imp_id      INTEGER NOT NULL ,
    imp_imagen  VARCHAR (100) NOT NULL ,
    imp_nombre  VARCHAR (100) NOT NULL ,
    imp_tipo    VARCHAR (100) NOT NULL ,
    imp_marca   VARCHAR (100) NOT NULL ,
    imp_color   VARCHAR (100) NOT NULL ,
    imp_talla   VARCHAR (3) ,
    imp_estatus VARCHAR (50) NOT NULL ,
    imp_precio FLOAT NOT NULL ,
    imp_stockmin    INTEGER NOT NULL ,
    imp_descripcion VARCHAR (255) NOT NULL ,
    CONSTRAINT IMPLEMENTO_PK PRIMARY KEY CLUSTERED (imp_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE
  TABLE INSCRIPCION
  (
    ins_id                    		   INTEGER IDENTITY(1,1) NOT NULL ,
    PERSONA_per_id                     INTEGER NOT NULL ,
    ins_fecha                          DATE NOT NULL ,
    SOLICITUD_PLANILLA_sol_pla_id      INTEGER ,
    SOLICITUD_PLANILLA_PLANILLA_pla_id INTEGER ,
    COMPETENCIA_comp_id                INTEGER ,
    EVENTO_eve_id                      INTEGER ,
    CONSTRAINT INSCRIPCION_PK PRIMARY KEY CLUSTERED (ins_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE
  TABLE INVENTARIO
  (
    inv_id             INTEGER NOT NULL ,
    inv_cantidad_total INTEGER NOT NULL ,
    IMPLEMENTO_imp_id  INTEGER NOT NULL ,
    DOJO_doj_id        INTEGER NOT NULL ,
    CONSTRAINT INVENTARIO_PK PRIMARY KEY CLUSTERED (inv_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE
  TABLE MATRICULA
  (
    mat_id             INTEGER IDENTITY(1,1) NOT NULL ,
    mat_identificador  VARCHAR (50) NOT NULL ,
    mat_fecha_creacion DATETIME NOT NULL ,
    mat_activa BIT NOT NULL ,
    mat_fecha_ultimo_pago DATETIME NOT NULL ,
    PERSONA_per_id        INTEGER NOT NULL ,
    DOJO_doj_id           INTEGER NOT NULL ,
    CONSTRAINT MATRICULA_PK PRIMARY KEY CLUSTERED (mat_id, PERSONA_per_id,
    DOJO_doj_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE
  TABLE ORGANIZACION
  (
    org_id        INTEGER IDENTITY(1,1) NOT NULL ,
    org_nombre    VARCHAR (100) NOT NULL ,
    org_direccion VARCHAR (150) NOT NULL ,
    org_telefono  INTEGER NOT NULL ,
    org_email     VARCHAR (100) NOT NULL ,
    org_estado    VARCHAR (100) NOT NULL ,
    ESTILO_est_id INTEGER NOT NULL ,
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

CREATE
  TABLE ORGANIZACION_CINTA
  (
    ORGANIZACION_org_id INTEGER NOT NULL ,
    CINTA_cin_id        INTEGER NOT NULL
  )
  ON "default"
GO

CREATE
  TABLE PERSONA
  (
    per_id           INTEGER IDENTITY(1,1) NOT NULL ,
    per_tipo_doc_id  VARCHAR (9) ,
    per_num_doc_id   NUMERIC (28) ,
    per_nombre       VARCHAR (256) NOT NULL ,
    per_apellido     VARCHAR (256) NOT NULL ,
    per_nacionalidad VARCHAR (10) ,
    per_alergias TEXT ,
    per_direccion TEXT ,
    per_sexo             CHAR (1) NOT NULL ,
    per_tipo_sangre      VARCHAR (3) ,
    per_fecha_nacimiento DATETIME ,
    per_nombre_usuario   VARCHAR (25) ,
    per_clave            VARCHAR (64) ,
    per_activo BIT ,
    per_peso FLOAT ,
    per_estatura FLOAT ,
    per_imagen TEXT ,
    DOJO_doj_id INTEGER ,
    CONSTRAINT PERSONA_PK PRIMARY KEY CLUSTERED (per_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO
ALTER TABLE PERSONA
ADD
CHECK ( per_tipo_doc_id IN ('CEDULA-N', 'CEDULA-E', 'PASAPORTE') )
GO
ALTER TABLE PERSONA
ADD
CHECK ( per_sexo IN ('F', 'M') )
GO
ALTER TABLE PERSONA
ADD
CHECK ( per_tipo_sangre IN ('A+', 'A-', 'AB+', 'AB-', 'B+', 'B-', 'O+', 'O-') )
GO

CREATE
  TABLE PERSONA_ROL
  (
    per_rol_fecha  DATE NOT NULL ,
    PERSONA_per_id INTEGER NOT NULL ,
    ROL_rol_id     INTEGER NOT NULL ,
    CONSTRAINT PERSONA_ROL_PK PRIMARY KEY CLUSTERED (PERSONA_per_id, ROL_rol_id
    )
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE
  TABLE PLANILLA
  (
    pla_id     INTEGER IDENTITY(1,1) NOT NULL ,
    pla_nombre VARCHAR (100) NOT NULL ,
    pla_status BIT NOT NULL ,
    DOJO_doj_id          INTEGER ,
    TIPO_PLANILLA_tip_id INTEGER NOT NULL ,
    CONSTRAINT PLANILLA_PK PRIMARY KEY CLUSTERED (pla_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE
  TABLE PLA_DAT
  (
    pd_id           INTEGER IDENTITY(1,1) NOT NULL ,
    DATO_dat_id     INTEGER NOT NULL ,
    PLANILLA_pla_id INTEGER NOT NULL ,
    CONSTRAINT PLA_DAT_PK PRIMARY KEY CLUSTERED (pd_id, DATO_dat_id,
    PLANILLA_pla_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE
  TABLE RC_CINTA
  (
    rc_cinta_id                        INTEGER IDENTITY(1,1) NOT NULL ,
    RESTRICCION_COMPETENCIA_res_com_id INTEGER NOT NULL ,
    CINTA_cin_id                       INTEGER NOT NULL ,
    CONSTRAINT RC_CINTA_PK PRIMARY KEY CLUSTERED (rc_cinta_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE
  TABLE REGLAMENTO
  (
    reg_id               INTEGER NOT NULL ,
    reg_nombre           VARCHAR (150) NOT NULL ,
    reg_descripcion      VARCHAR (150) NOT NULL ,
    reg_fecha_registrada DATE NOT NULL ,
    reg_status BIT NOT NULL ,
    DOJO_doj_id INTEGER NOT NULL ,
    CONSTRAINT REGLAMENTO_PK PRIMARY KEY CLUSTERED (reg_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE
  TABLE RELACION
  (
    rel_tipo        VARCHAR (15) NOT NULL ,
    PERSONA_per_id1 INTEGER NOT NULL ,
    PERSONA_per_id  INTEGER NOT NULL ,
    CONSTRAINT RELACION_PK PRIMARY KEY CLUSTERED (PERSONA_per_id1,
    PERSONA_per_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO
ALTER TABLE RELACION
ADD
CHECK ( rel_tipo IN ('CONTACTO', 'REPRESENTANTE') )
GO

CREATE
  TABLE RESTRICCION_CINTA
  (
    res_cin_id               INTEGER NOT NULL ,
    res_cin_descripcion      VARCHAR (255) NOT NULL ,
    res_cin_tiemp_min        INTEGER NOT NULL , /*# de meses*/
    res_cin_punt_min         INTEGER NOT NULL ,
    res_cin_horas_docent     INTEGER NOT NULL ,/*tiempo mensual en horas*/
    CINTA_cin_id             INTEGER NOT NULL ,
    CONSTRAINT RESTRICCION_CINTA_PK PRIMARY KEY CLUSTERED (res_cin_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO
CREATE UNIQUE NONCLUSTERED INDEX
RESTRICCION_CINTA__IDX ON RESTRICCION_CINTA
(
  TIPO_PERIODO_tipo_per_id
)
ON "default"
GO
CREATE UNIQUE NONCLUSTERED INDEX
RESTRICCION_CINTA__IDXv1 ON RESTRICCION_CINTA
(
  CINTA_cin_id
)
ON "default"
GO

CREATE
  TABLE RESTRICCION_COMPETENCIA
  (
    res_com_id        INTEGER IDENTITY(1,1) NOT NULL ,
    res_com_desc      VARCHAR (255) NOT NULL ,
    res_com_edad_min  INTEGER NOT NULL ,
    res_com_edad_max  INTEGER NOT NULL ,
    res_com_sexo      VARCHAR (1) NOT NULL ,
    res_com_modalidad VARCHAR (10) NOT NULL ,
    CONSTRAINT RESTRICCION_COMPETENCIA_PK PRIMARY KEY CLUSTERED (res_com_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE
  TABLE COMP_REST_COMP
  (
    comp_rest_comp_id                  INTEGER IDENTITY(1,1) NOT NULL ,
    RESTRICCION_COMPETENCIA_res_com_id INTEGER NOT NULL ,
    COMPETENCIA_comp_id                INTEGER NOT NULL ,
  )
  ON "default"
GO
ALTER TABLE COMP_REST_COMP ADD CONSTRAINT COMP_REST_COMP_PK PRIMARY KEY
CLUSTERED (comp_rest_comp_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
GO

CREATE
  TABLE RESTRICCION_EVENTO
  (
    res_eve_id       INTEGER  IDENTITY(1,1) NOT NULL ,
    res_eve_desc     VARCHAR (255) ,
    res_eve_edad_min INTEGER ,
    res_eve_edad_max INTEGER ,
    res_eve_sexo     VARCHAR (1) ,
    CONSTRAINT RESTRICCION_EVENTO_PK PRIMARY KEY CLUSTERED (res_eve_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE
  TABLE RESULTADO_ASCENSO
  (
    res_asc_id INTEGER NOT NULL ,
    res_asc_aprobado CHAR(1) NOT NULL ,
	INSCRIPCION_ins_id INTEGER NOT NULL,
    CONSTRAINT RESULTADO_ASCENSO_PK PRIMARY KEY CLUSTERED (res_asc_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

ALTER TABLE RESULTADO_ASCENSO
ADD
CHECK ( res_asc_aprobado IN ('S', 'N') )
GO

CREATE
  TABLE RESULTADO_KATA
  (
    res_kat_id      INTEGER NOT NULL ,
    res_kat_jurado1 INTEGER NOT NULL ,
    res_kat_jurado2 INTEGER NOT NULL ,
    res_kat_jurado3 INTEGER NOT NULL ,
	INSCRIPCION_ins_id INTEGER NOT NULL ,
    CONSTRAINT RESULTADO_KATA_PK PRIMARY KEY CLUSTERED (res_kat_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE
  TABLE RESULTADO_KUMITE
  (
    res_kum_id      INTEGER NOT NULL ,
    res_kum_atleta1 INTEGER NOT NULL ,
    res_kum_atleta2 INTEGER NOT NULL ,
	INSCRIPCION_ins_id1 INTEGER NOT NULL ,
	INSCRIPCION_ins_id2 INTEGER NOT NULL ,
    CONSTRAINT RESULTADO_KUMITE_PK PRIMARY KEY CLUSTERED (res_kum_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE
  TABLE RH_CINTA
  (
    rh_cinta_id                   INTEGER IDENTITY(1,1) NOT NULL ,
    RESTRICCION_EVENTO_res_eve_id INTEGER NOT NULL ,
    CINTA_cin_id                  INTEGER NOT NULL,
    CONSTRAINT RH_CINTA_PK PRIMARY KEY CLUSTERED (rh_cinta_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE
  TABLE ROL
  (
    rol_id     INTEGER IDENTITY(1,1) NOT NULL,
    rol_nombre VARCHAR (150) NOT NULL ,
	rol_descripcion VARCHAR(200) NOT NULL,
    CONSTRAINT ROL_PK PRIMARY KEY CLUSTERED (rol_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE
  TABLE SOLICITUD_INSCRIPCION
  (
    sol_inc_id                  INTEGER IDENTITY(1,1) NOT NULL ,
    sol_inc_fecha_creacion      DATETIME NOT NULL ,
    sol_inc_fecha_actualizacion DATETIME NOT NULL ,
    sol_inc_estado              VARCHAR (30) NOT NULL ,
    PERSONA_per_id              INTEGER NOT NULL ,
    DOJO_doj_id                 INTEGER NOT NULL ,
    CONSTRAINT SOLICITUD_INSCRIPCION_PK PRIMARY KEY CLUSTERED (sol_inc_id,
    PERSONA_per_id, DOJO_doj_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO
ALTER TABLE SOLICITUD_INSCRIPCION
ADD
CHECK ( sol_inc_estado IN ('ACEPTADO', 'PENDIENTE', 'RECHAZADO') )
GO

CREATE
  TABLE SOLICITUD_PLANILLA
  (
    sol_pla_id                    INTEGER IDENTITY(1,1) NOT NULL ,
    sol_pla_fecha_creacion        DATE NOT NULL ,
    sol_pla_fecha_retiro          DATE ,
    sol_pla_fecha_reincorporacion DATE ,
    sol_pla_motivo                VARCHAR (2000) ,
    PLANILLA_pla_id               INTEGER NOT NULL ,
    CONSTRAINT SOLICITUD_PLANILLA_PK PRIMARY KEY CLUSTERED (sol_pla_id,
    PLANILLA_pla_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE
  TABLE TELEFONO
  (
    tel_id         INTEGER IDENTITY(1,1) NOT NULL ,
    tel_numero     VARCHAR (11) NOT NULL ,
    PERSONA_per_id INTEGER NOT NULL ,
    CONSTRAINT TELEFONO_PK PRIMARY KEY CLUSTERED (tel_id,PERSONA_per_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE
  TABLE TIPO_EVENTO
  (
    tip_id        INTEGER IDENTITY(1,1) NOT NULL ,
    tip_nombre    VARCHAR (120) NOT NULL ,
    CONSTRAINT TIPO_EVENTO_PK PRIMARY KEY CLUSTERED (tip_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE
  TABLE TIPO_PERIODO
  (
    tipo_per_id                  INTEGER NOT NULL ,
    tipo_per_desc                VARCHAR (25) ,
    rest_cinta_id                INTEGER NOT NULL ,
    RESTRICCION_CINTA_res_cin_id INTEGER NOT NULL ,
    CONSTRAINT TIPO_PERIODO_PK PRIMARY KEY CLUSTERED (tipo_per_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO
CREATE UNIQUE NONCLUSTERED INDEX
TIPO_PERIODO__IDX ON TIPO_PERIODO
(
  RESTRICCION_CINTA_res_cin_id
)
ON "default"
GO

CREATE
  TABLE TIPO_PLANILLA
  (
    tip_id          INTEGER IDENTITY(1,1) NOT NULL UNIQUE ,
    tip_nombre      VARCHAR (100) NOT NULL ,
    tip_descripcion VARCHAR (150) ,
    CONSTRAINT TIPO_PLANILLA_PK PRIMARY KEY CLUSTERED (tip_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE
  TABLE UBICACION
  (
    ubi_id        INTEGER IDENTITY(1,1) NOT NULL ,
    ubi_latitud   VARCHAR (100) NOT NULL ,
    ubi_longitud  VARCHAR (100) NOT NULL ,
    ubi_ciudad    VARCHAR (100) NOT NULL ,
    ubi_estado    VARCHAR (100) NOT NULL ,
    ubi_direccion VARCHAR (100) ,
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





-----------------------------------PROCEDURE----------------------
---------------------------------------------------------STORED PROCEDURES M12--------------------------------------------------------------------

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
	declare @numUbicacion as int;

	select @numCategoria = count(*) from CATEGORIA where cat_cinta_fin = @cintaFin and cat_cinta_ini = @cintaIni
													     and cat_edad_fin = @edadFin and cat_edad_ini = @edadIni
														 and cat_sexo = @sexo;
	select @numUbicacion = count(*) from UBICACION where ubi_latitud = @latitudDireccion and ubi_longitud = @longitudDireccion
														 and ubi_ciudad = @nombreCiudad and ubi_estado = @nombreEstado
														 and ubi_direccion = @nombreDireccion
		if(@numCategoria = 0)
				INSERT INTO CATEGORIA (cat_edad_ini, cat_edad_fin, cat_cinta_ini, cat_cinta_fin, cat_sexo) 
				VALUES (@edadIni, @edadFin, @cintaIni, @cintaFin, @sexo);

		if(@numUbicacion = 0)
				INSERT INTO UBICACION(ubi_latitud, ubi_longitud, ubi_ciudad, ubi_estado, ubi_direccion) 
				VALUES (@latitudDireccion, @longitudDireccion, @nombreCiudad, @nombreEstado, @nombreDireccion);


		if(@organizacionesTodas = 1)
						
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
					   (select org_id from ORGANIZACION where @nombreOrganizacion = org_nombre),@costoCompetencia);

 end;
 go

 
--PROCEDURE CONSULTAR ID COMPETENCIA--
CREATE PROCEDURE M12_BuscarIDCompetencia
	@idCompetencia   [int],
	@numCompetencia  [int] OUTPUT
as
 begin

	select @numCompetencia = count(*) 
	from COMPETENCIA 
	where comp_id = @idCompetencia

 end;
 go

 
--PROCEDURE CONSULTAR NOMBRE COMPETENCIA--
CREATE PROCEDURE M12_BuscarNombreCompetencia
	@nombreCompetencia   [varchar](100),
	@numCompetencia      [int] OUTPUT
as
 begin

	select @numCompetencia = count(*) 
	from COMPETENCIA 
	where comp_nombre = @nombreCompetencia

 end;
 go

 

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

	--PROCEDURE MODIFICAR COMPETENCIA--
CREATE PROCEDURE M12_ModificarCompetencia
	@idCompetencia       [int],
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
	declare @numUbicacion as int;

	select @numCategoria = count(*) from CATEGORIA where cat_cinta_fin = @cintaFin and cat_cinta_ini = @cintaIni
													     and cat_edad_fin = @edadFin and cat_edad_ini = @edadIni
														 and cat_sexo = @sexo;
	select @numUbicacion = count(*) from UBICACION where ubi_latitud = @latitudDireccion and ubi_longitud = @longitudDireccion
														 and ubi_ciudad = @nombreCiudad and ubi_estado = @nombreEstado
														 and ubi_direccion = @nombreDireccion
	if(@numCategoria = 0)
			INSERT INTO CATEGORIA (cat_edad_ini, cat_edad_fin, cat_cinta_ini, cat_cinta_fin, cat_sexo) 
			VALUES (@edadIni, @edadFin, @cintaIni, @cintaFin, @sexo);

	if(@numUbicacion = 0)
			INSERT INTO UBICACION(ubi_latitud, ubi_longitud, ubi_ciudad, ubi_estado, ubi_direccion) 
			VALUES (@latitudDireccion, @longitudDireccion, @nombreCiudad, @nombreEstado, @nombreDireccion);

	if(@organizacionesTodas = 1)
		UPDATE COMPETENCIA
		SET 
			comp_nombre       = @nombreCompetencia,
			comp_tipo         = @tipoCompetencia,
			comp_org_todas    = @organizacionesTodas,
			comp_status       = @statusCompetencia,
			comp_fecha_ini    = @fecha_ini,
			comp_fecha_fin    = @fecha_fin,
			comp_costo        = @costoCompetencia,
			CATEGORIA_comp_id = (select cat_id from CATEGORIA where @edadIni = cat_edad_ini and @edadFin = cat_edad_fin and @cintaIni = cat_cinta_ini and @cintaFin = cat_cinta_fin and @sexo = cat_sexo), 
			UBICACION_comp_id = (select ubi_id from UBICACION where @latitudDireccion = ubi_latitud and @longitudDireccion = ubi_longitud and @nombreCiudad = ubi_ciudad and @nombreEstado = ubi_estado and @nombreDireccion = ubi_direccion)
		WHERE
			comp_id = @idCompetencia;
	else
		UPDATE COMPETENCIA
		SET 
			comp_nombre          = @nombreCompetencia,
			comp_tipo            = @tipoCompetencia,
			comp_org_todas       = @organizacionesTodas,
			comp_status          = @statusCompetencia,
			comp_fecha_ini       = @fecha_ini,
			comp_fecha_fin       = @fecha_fin,
			comp_costo           = @costoCompetencia,
			CATEGORIA_comp_id    = (select cat_id from CATEGORIA where @edadIni = cat_edad_ini and @edadFin = cat_edad_fin and @cintaIni = cat_cinta_ini and @cintaFin = cat_cinta_fin and @sexo = cat_sexo), 
			UBICACION_comp_id    = (select ubi_id from UBICACION where @latitudDireccion = ubi_latitud and @longitudDireccion = ubi_longitud and @nombreCiudad = ubi_ciudad and @nombreEstado = ubi_estado and @nombreDireccion = ubi_direccion),
			ORGANIZACION_comp_id = (select org_id from ORGANIZACION where org_nombre = @nombreOrganizacion)
		WHERE
			comp_id = @idCompetencia;
 end;

 go


--PROCEDURE CONSULTA LISTA DE ORGANIZACIONES--
CREATE procedure M12_ConsultarOrganizaciones
as
	begin
		select org.org_id as idOrganizacion, org.org_nombre as nombreOrganizacion
		from ORGANIZACION as org		
	end;
go


--PROCEDURE CONSULTA LISTA DE CINTAS--
CREATE procedure M12_ConsultarCintas
as
	begin
		select cin.cin_id as idCinta, cin.cin_color_nombre nombreCinta, cin_orden as ordenCinta
		from CINTA as cin		
	end;
go



 ----------------------------------STORED PROCEDURES M1-------------------------------------

------------------PROCEDURE CONSULTA NOMBRE DE USUARIO Y CONTRASEÑA ------------
CREATE procedure M1_ConsultarNombreUsuarioContrasena
	@nombre_usuario [varchar](25)
as
	begin
		select pers.per_id as id_usuario, pers.per_nombre_usuario as nombre_usuario, pers.per_clave as contrasena
		from PERSONA pers
		where pers.per_nombre_usuario = @nombre_usuario
	end;
	go


------------------PROCEDURE CONSULTA ROLES DE USUARIO POR NOMBRE------------------
CREATE procedure M1_ConsultarRolesUsuario
	@nombre_usuario [varchar](25)
as
	begin
		select roles.rol_id as id_rol, roles.rol_nombre as nombre,perol.per_rol_fecha as fecha_creacion,roles.rol_descripcion as descripcion
		from ROL roles , PERSONA pers, PERSONA_ROL perol
		where pers.per_id = perol.PERSONA_per_id AND perol.ROL_rol_id = roles.rol_id AND pers.per_nombre_usuario = @nombre_usuario
	end;
	go


------------------PROCEDURE RESTABLECER CONTRASENA ------------------
CREATE procedure M1_RestablecerContrasena
	@id_usuario [int],
	@contrasena [varchar](64)
as
	begin
		UPDATE PERSONA 
		SET per_clave = @contrasena
		WHERE per_id = @id_usuario
	end;
	go

-----------------PROCEDURE VALIDAR CORREO--------------------------
CREATE procedure M1_ValidarCorreo
@correo_usuario [varchar](25)
as
	begin
		select  PERSONA_per_id  as correo_usuario
		from EMAIL
		where ema_email= @correo_usuario and ema_principal=1
	end;
	go


-----------------------------------STORED PROCEDURES M2--------------------------------------------------------

--------------PROCEDURE CONSULTA ROLES DE USUARIO POR ID----------------------
CREATE procedure M2_ConsultarRolesUsuario
	@id_usuario [varchar](25)
as
	begin
		select roles.rol_id as id_rol, roles.rol_nombre as nombre,perol.per_rol_fecha as fecha_creacion,roles.rol_descripcion as descripcion
		from ROL roles , PERSONA_ROL perol
		where  perol.ROL_rol_id = roles.rol_id AND perol.PERSONA_per_id = CONVERT(INT,@id_usuario)
	end;
GO
	
------------------PROCEDURE CONSULTA ROLES DEL SISTEMA --------------------
CREATE procedure M2_ConsultarRolesSistema
as
	begin
		select rol_id as id_rol, rol_nombre as nombre, rol_descripcion as descripcion
		from Rol 
	end;
	go
---------------PROCEDURE AGREGAR ROL--------------------------

	CREATE procedure M2_AgregarRole
	@id_usuario [varchar](25),
	@id_rol [varchar](25)
as
	begin
		insert into PERSONA_ROL values(CONVERT (date, GETDATE()),@id_usuario,@id_rol);
	end;
	go
------------------PROCEDURA ELIMINAR ROL-------------------------------
CREATE procedure M2_EliminarRole
	@id_usuario [varchar](25),
	@id_rol [varchar](25)
as
	begin
		delete  from PERSONA_ROL  where PERSONA_per_id=@id_usuario AND ROL_rol_id=@id_rol;
	end;
	go



	INSERT INTO dbo.PERSONA (
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
	per_clave
) 
VALUES (
    'Eduardo',
    'Sanchez Quintero',
    'Venezolano',
    'Coco',
    '2da. Avenida de La Lagunita. Quinta Los Querubines.',
    'M',
    'O-',
    '1968-03-05',
    1,
    88,
    1.78,
    'usuario01',
	'12345'
);


INSERT INTO dbo.PERSONA (
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
	per_clave
) 
VALUES (
    'Alejandro',
    'Perez',
    'Venezolano',
    'Coco',
    '2da. Avenida de La Lagunita. Quinta Los Querubines.',
    'M',
    'O-',
    '1968-03-05',
    1,
    88,
    1.78,
    'usuario02',
	'12345'
);

INSERT INTO  ROL VALUES ('Admin Sistema','El administrador tiene acceso a todo el sistema sin restricción,con la capacidad de dar seguimiento a todo los procesos.' );
INSERT INTO  ROL VALUES ('Admin Organización','El administrador de la organizacion se encarga de gestionar la organización a la cual esta asociado, actualizando agregando y descartando información correspondiente.');
INSERT INTO  ROL VALUES ('Admin Dojo','El administrador del dojo es el encargado de llevar un seguimiento y tener al día la información relevante con respecto al dojo asociado.');
INSERT INTO  ROL VALUES ('Entrenador','El entrenador lleva un seguimiento de los atletas y los eventos realizados en el dojo.');
INSERT INTO  ROL VALUES ('Atleta','El atleta es la persona en formación que recibe clases en un dojo particular.');
INSERT INTO  ROL VALUES ('Representante','El representante como su nombre lo indica es el encargado del atleta menor, con lo cual puede dar seguimiento a las actividades realizadas por el menor.');

-----------ID DE PERSONA------------------
SELECT per_id from PERSONA where per_nombre_usuario='usuario01';

SELECT per_id from PERSONA where per_nombre_usuario='usuario02';
----------ID DE ROL -------------
SELECT rol_id  from ROL where rol_nombre='Admin Sistema';
SELECT rol_id  from ROL where rol_nombre='Admin Organización';
SELECT rol_id  from ROL where rol_nombre='Admin Dojo';
SELECT rol_id  from ROL where rol_nombre='Entrenador';
SELECT rol_id  from ROL where rol_nombre='Atleta';
SELECT rol_id  from ROL where rol_nombre='Representante';

INSERT INTO PERSONA_ROL 
VALUES(CONVERT (date, GETDATE()),
(SELECT per_id from PERSONA where per_nombre_usuario='usuario01'),
(SELECT rol_id  from ROL where rol_nombre='Atleta'));


INSERT INTO PERSONA_ROL 
VALUES(CONVERT (date, GETDATE()),
(SELECT per_id from PERSONA where per_nombre_usuario='usuario02'),
(SELECT rol_id  from ROL where rol_nombre='Entrenador'));

INSERT INTO PERSONA_ROL 
VALUES(CONVERT (date, GETDATE()),
(SELECT per_id from PERSONA where per_nombre_usuario='usuario02'),
(SELECT rol_id  from ROL where rol_nombre='Admin Dojo'));

INSERT INTO PERSONA_ROL 
VALUES(CONVERT (date, GETDATE()),
(SELECT per_id from PERSONA where per_nombre_usuario='usuario02'),
(SELECT rol_id  from ROL where rol_nombre='Admin Organización'));

