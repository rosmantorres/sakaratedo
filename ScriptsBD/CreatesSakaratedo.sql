CREATE
  TABLE ASISTENCIA
  (
    asi_asistio BIT NOT NULL ,
    INSCRIPCION_PERSONA_per_id INTEGER NOT NULL ,
    CONSTRAINT ASISTENCIA_PK PRIMARY KEY CLUSTERED (INSCRIPCION_PERSONA_per_id)
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
    doj_id             INTEGER IDENTITY(1,1) NOT NULL ,
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
	his_mat_id INTEGER IDENTITY(1,1) NOT NULL,
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
  TABLE HIST_ASCENSO
  (
    RESULTADO_ASCENSO_res_asc_id INTEGER NOT NULL ,
    INSCRIPCION_PERSONA_per_id   INTEGER NOT NULL ,
    CONSTRAINT HIST_ASCENSO_PK PRIMARY KEY CLUSTERED (
    RESULTADO_ASCENSO_res_asc_id, INSCRIPCION_PERSONA_per_id)
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
  TABLE HIST_KATA
  (
    RESULTADO_KATA_res_kat_id  INTEGER NOT NULL ,
    INSCRIPCION_PERSONA_per_id INTEGER NOT NULL ,
    CONSTRAINT HIST_KATA_PK PRIMARY KEY CLUSTERED (RESULTADO_KATA_res_kat_id,
    INSCRIPCION_PERSONA_per_id)
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
  TABLE HIST_KUMITE
  (
    RESULTADO_KUMITE_res_kum_id INTEGER NOT NULL ,
    INSCRIPCION_PERSONA_per_id  INTEGER NOT NULL ,
    INSCRIPCION_PERSONA_per_id1 INTEGER NOT NULL ,
    CONSTRAINT HIST_KUMITE_PK PRIMARY KEY CLUSTERED (
    RESULTADO_KUMITE_res_kum_id, INSCRIPCION_PERSONA_per_id,
    INSCRIPCION_PERSONA_per_id1)
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
CHECK ( per_tipo_doc_id IN ('CEDULA NACIONAL', 'CEDULA EXTRAJERA', 'PASAPORTE') )
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
    reg_id               INTEGER IDENTITY(1,1) NOT NULL ,
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
    res_asc_aprobado BIT NOT NULL ,
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

CREATE
  TABLE RESULTADO_KATA
  (
    res_kat_id      INTEGER NOT NULL ,
    res_kat_jurado1 INTEGER NOT NULL ,
    res_kat_jurado2 INTEGER NOT NULL ,
    res_kat_jurado3 INTEGER NOT NULL ,
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

ALTER TABLE ASISTENCIA
ADD CONSTRAINT ASISTENCIA_INSCRIPCION_FK FOREIGN KEY
(
INSCRIPCION_PERSONA_per_id
)
REFERENCES INSCRIPCION
(
ins_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE CINTA
ADD CONSTRAINT CINTA_RESTRICCION_CINTA_FK FOREIGN KEY
(
RESTRICCION_CINTA_res_cin_id
)
REFERENCES RESTRICCION_CINTA
(
res_cin_id
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

ALTER TABLE COMPRA_CARRITO
ADD CONSTRAINT COMPRA_CARRITO_PERSONA_FK FOREIGN KEY
(
PERSONA_per_id
)
REFERENCES PERSONA
(
per_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE COMPRA_CARRITO
ADD
CHECK ( com_estado IN ('CARRITO','PAGADO') )
GO

ALTER TABLE COMPRA_CARRITO
ADD
CHECK ( com_tipo_pago IN ('Tarjeta','Deposito','Transferencia') )
GO

ALTER TABLE DETALLE_COMPRA
ADD CONSTRAINT DETALLE_COMPRA_COMPRA_CARRITO_FK FOREIGN KEY
(
COMPRA_CARRITO_com_id
)
REFERENCES COMPRA_CARRITO
(
com_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE DETALLE_COMPRA
ADD CONSTRAINT DETALLE_COMPRA_EVENTO_FK FOREIGN KEY
(
EVENTO_eve_id
)
REFERENCES EVENTO
(
eve_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE DETALLE_COMPRA
ADD CONSTRAINT DETALLE_COMPRA_IMPLEMENTO_FK FOREIGN KEY
(
IMPLEMENTO_inv_id
)
REFERENCES IMPLEMENTO
(
imp_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE DETALLE_COMPRA
ADD CONSTRAINT DETALLE_COMPRA_MATRICULA_FK FOREIGN KEY
(
MATRICULA_mat_id,
MATRICULA_per_id,
MATRICULA_doj_id
)
REFERENCES MATRICULA
(
mat_id ,
PERSONA_per_id ,
DOJO_doj_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE DISEÑO
ADD CONSTRAINT DISEÑO_PLANILLA_FK FOREIGN KEY
(
PLANILLA_pla_id
)
REFERENCES PLANILLA
(
pla_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE DOJO
ADD CONSTRAINT DOJO_ORGANIZACION_FK FOREIGN KEY
(
ORGANIZACION_org_id
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

ALTER TABLE DOJO
ADD CONSTRAINT DOJO_UBICACION_FK FOREIGN KEY
(
UBICACION_ubi_id
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

ALTER TABLE EMAIL
ADD CONSTRAINT EMAIL_PERSONA_FK FOREIGN KEY
(
PERSONA_per_id
)
REFERENCES PERSONA
(
per_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE EVENTO
ADD CONSTRAINT EVENTO_CATEGORIA_FK FOREIGN KEY
(
CATEGORIA_cat_id
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

ALTER TABLE EVENTO
ADD CONSTRAINT EVENTO_DOJO_FK FOREIGN KEY
(
DOJO_doj_id
)
REFERENCES DOJO
(
doj_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE EVENTO
ADD CONSTRAINT EVENTO_HORARIO_FK FOREIGN KEY
(
HORARIO_hor_id
)
REFERENCES HORARIO
(
hor_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE EVENTO_RESTRICCION
ADD CONSTRAINT EVENTO_RESTRICCION_EVENTO_FK FOREIGN KEY
(
EVENTO_eve_id
)
REFERENCES EVENTO
(
eve_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE EVENTO_RESTRICCION
ADD CONSTRAINT EVENTO_RESTRICCION_RESTRICCION_EVENTO_FK FOREIGN KEY
(
RESTRICCION_EVENTO_res_eve_id
)
REFERENCES RESTRICCION_EVENTO
(
res_eve_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE EVENTO
ADD CONSTRAINT EVENTO_TIPO_EVENTO_FK FOREIGN KEY
(
TIPO_EVENTO_tip_id
)
REFERENCES TIPO_EVENTO
(
tip_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE EVENTO
ADD CONSTRAINT EVENTO_UBICACION_FK FOREIGN KEY
(
UBICACION_ubi_id
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

ALTER TABLE HISTORIAL_CINTAS
ADD CONSTRAINT HISTORIAL_CINTAS_CINTA_FK FOREIGN KEY
(
CINTA_cin_id
)
REFERENCES CINTA
(
cin_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE HISTORIAL_CINTAS
ADD CONSTRAINT HISTORIAL_CINTAS_EVENTO_FK FOREIGN KEY
(
EVENTO_eve_id
)
REFERENCES EVENTO
(
eve_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE HISTORIAL_CINTAS
ADD CONSTRAINT HISTORIAL_CINTAS_PERSONA_FK FOREIGN KEY
(
PERSONA_per_id
)
REFERENCES PERSONA
(
per_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE HISTORIAL_MATRICULA
ADD CONSTRAINT HISTORIAL_MATRICULA_DOJO_FK FOREIGN KEY
(
DOJO_doj_id
)
REFERENCES DOJO
(
doj_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE HIST_ASCENSO
ADD CONSTRAINT HIST_ASCENSO_INSCRIPCION_FK FOREIGN KEY
(
INSCRIPCION_PERSONA_per_id
)
REFERENCES INSCRIPCION
(
ins_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE HIST_ASCENSO
ADD CONSTRAINT HIST_ASCENSO_RESULTADO_ASCENSO_FK FOREIGN KEY
(
RESULTADO_ASCENSO_res_asc_id
)
REFERENCES RESULTADO_ASCENSO
(
res_asc_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE HIST_KATA
ADD CONSTRAINT HIST_KATA_INSCRIPCION_FK FOREIGN KEY
(
INSCRIPCION_PERSONA_per_id
)
REFERENCES INSCRIPCION
(
ins_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE HIST_KATA
ADD CONSTRAINT HIST_KATA_RESULTADO_KATA_FK FOREIGN KEY
(
RESULTADO_KATA_res_kat_id
)
REFERENCES RESULTADO_KATA
(
res_kat_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE HIST_KUMITE
ADD CONSTRAINT HIST_KUMITE_INSCRIPCION_FK FOREIGN KEY
(
INSCRIPCION_PERSONA_per_id
)
REFERENCES INSCRIPCION
(
ins_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE HIST_KUMITE
ADD CONSTRAINT HIST_KUMITE_INSCRIPCION_FKv1 FOREIGN KEY
(
INSCRIPCION_PERSONA_per_id1
)
REFERENCES INSCRIPCION
(
ins_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE HIST_KUMITE
ADD CONSTRAINT HIST_KUMITE_RESULTADO_KUMITE_FK FOREIGN KEY
(
RESULTADO_KUMITE_res_kum_id
)
REFERENCES RESULTADO_KUMITE
(
res_kum_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE INSCRIPCION
ADD CONSTRAINT INSCRIPCION_COMPETENCIA_FK FOREIGN KEY
(
COMPETENCIA_comp_id
)
REFERENCES COMPETENCIA
(
comp_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE INSCRIPCION
ADD CONSTRAINT INSCRIPCION_EVENTO_FK FOREIGN KEY
(
EVENTO_eve_id
)
REFERENCES EVENTO
(
eve_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE INSCRIPCION
ADD CONSTRAINT INSCRIPCION_PERSONA_FK FOREIGN KEY
(
PERSONA_per_id
)
REFERENCES PERSONA
(
per_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE INSCRIPCION
ADD CONSTRAINT INSCRIPCION_SOLICITUD_PLANILLA_FK FOREIGN KEY
(
SOLICITUD_PLANILLA_sol_pla_id,
SOLICITUD_PLANILLA_PLANILLA_pla_id
)
REFERENCES SOLICITUD_PLANILLA
(
sol_pla_id ,
PLANILLA_pla_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE INVENTARIO
ADD CONSTRAINT INVENTARIO_DOJO_FK FOREIGN KEY
(
DOJO_doj_id
)
REFERENCES DOJO
(
doj_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE INVENTARIO
ADD CONSTRAINT INVENTARIO_IMPLEMENTO_FK FOREIGN KEY
(
IMPLEMENTO_imp_id
)
REFERENCES IMPLEMENTO
(
imp_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE MATRICULA
ADD CONSTRAINT MATRICULA_DOJO_FK FOREIGN KEY
(
DOJO_doj_id
)
REFERENCES DOJO
(
doj_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE MATRICULA
ADD CONSTRAINT MATRICULA_PERSONA_FK FOREIGN KEY
(
PERSONA_per_id
)
REFERENCES PERSONA
(
per_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE ORGANIZACION_CINTA
ADD CONSTRAINT ORGANIZACION_CINTA_CINTA_FK FOREIGN KEY
(
CINTA_cin_id
)
REFERENCES CINTA
(
cin_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE ORGANIZACION_CINTA
ADD CONSTRAINT ORGANIZACION_CINTA_ORGANIZACION_FK FOREIGN KEY
(
ORGANIZACION_org_id
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

ALTER TABLE ORGANIZACION
ADD CONSTRAINT ORGANIZACION_ESTILO_FK FOREIGN KEY
(
ESTILO_est_id
)
REFERENCES ESTILO
(
est_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE PERSONA
ADD CONSTRAINT PERSONA_DOJO_FK FOREIGN KEY
(
DOJO_doj_id
)
REFERENCES DOJO
(
doj_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE PERSONA_ROL
ADD CONSTRAINT PERSONA_ROL_PERSONA_FK FOREIGN KEY
(
PERSONA_per_id
)
REFERENCES PERSONA
(
per_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE PERSONA_ROL
ADD CONSTRAINT PERSONA_ROL_ROL_FK FOREIGN KEY
(
ROL_rol_id
)
REFERENCES ROL
(
rol_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE PLANILLA
ADD CONSTRAINT PLANILLA_DOJO_FK FOREIGN KEY
(
DOJO_doj_id
)
REFERENCES DOJO
(
doj_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE PLANILLA
ADD CONSTRAINT PLANILLA_TIPO_PLANILLA_FK FOREIGN KEY
(
TIPO_PLANILLA_tip_id
)
REFERENCES TIPO_PLANILLA
(
tip_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE PLA_DAT
ADD CONSTRAINT PLA_DAT_DATO_FK FOREIGN KEY
(
DATO_dat_id
)
REFERENCES DATO
(
dat_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE PLA_DAT
ADD CONSTRAINT PLA_DAT_PLANILLA_FK FOREIGN KEY
(
PLANILLA_pla_id
)
REFERENCES PLANILLA
(
pla_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE RC_CINTA
ADD CONSTRAINT RC_CINTA_CINTA_FK FOREIGN KEY
(
CINTA_cin_id
)
REFERENCES CINTA
(
cin_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE RC_CINTA
ADD CONSTRAINT RC_CINTA_RESTRICCION_COMPETENCIA_FK FOREIGN KEY
(
RESTRICCION_COMPETENCIA_res_com_id
)
REFERENCES RESTRICCION_COMPETENCIA
(
res_com_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE REGLAMENTO
ADD CONSTRAINT REGLAMENTO_DOJO_FK FOREIGN KEY
(
DOJO_doj_id
)
REFERENCES DOJO
(
doj_id
)
ON
DELETE CASCADE ON
UPDATE NO ACTION
GO

ALTER TABLE RELACION
ADD CONSTRAINT RELACION_PERSONA_FK FOREIGN KEY
(
PERSONA_per_id
)
REFERENCES PERSONA
(
per_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE RELACION
ADD CONSTRAINT RELACION_PERSONA_FKv1 FOREIGN KEY
(
PERSONA_per_id1
)
REFERENCES PERSONA
(
per_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE RESTRICCION_CINTA
ADD CONSTRAINT RESTRICCION_CINTA_CINTA_FK FOREIGN KEY
(
CINTA_cin_id
)
REFERENCES CINTA
(
cin_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE RESTRICCION_CINTA
ADD CONSTRAINT RESTRICCION_CINTA_TIPO_PERIODO_FK FOREIGN KEY
(
TIPO_PERIODO_tipo_per_id
)
REFERENCES TIPO_PERIODO
(
tipo_per_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE RH_CINTA
ADD CONSTRAINT RH_CINTA_CINTA_FK FOREIGN KEY
(
CINTA_cin_id
)
REFERENCES CINTA
(
cin_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE RH_CINTA
ADD CONSTRAINT RH_CINTA_RESTRICCION_EVENTO_FK FOREIGN KEY
(
RESTRICCION_EVENTO_res_eve_id
)
REFERENCES RESTRICCION_EVENTO
(
res_eve_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE SOLICITUD_INSCRIPCION
ADD CONSTRAINT SOLICITUD_INSCRIPCION_DOJO_FK FOREIGN KEY
(
DOJO_doj_id
)
REFERENCES DOJO
(
doj_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE SOLICITUD_INSCRIPCION
ADD CONSTRAINT SOLICITUD_INSCRIPCION_PERSONA_FK FOREIGN KEY
(
PERSONA_per_id
)
REFERENCES PERSONA
(
per_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE SOLICITUD_PLANILLA
ADD CONSTRAINT SOLICITUD_PLANILLA_PLANILLA_FK FOREIGN KEY
(
PLANILLA_pla_id
)
REFERENCES PLANILLA
(
pla_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE TELEFONO
ADD CONSTRAINT TELEFONO_PERSONA_FK FOREIGN KEY
(
PERSONA_per_id
)
REFERENCES PERSONA
(
per_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE TIPO_PERIODO
ADD CONSTRAINT TIPO_PERIODO_RESTRICCION_CINTA_FK FOREIGN KEY
(
RESTRICCION_CINTA_res_cin_id
)
REFERENCES RESTRICCION_CINTA
(
res_cin_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE COMP_REST_COMP
ADD CONSTRAINT COMPETENCIA_FK FOREIGN KEY
(
COMPETENCIA_comp_id
)
REFERENCES COMPETENCIA
(
comp_id
)
ON
DELETE
  CASCADE ON
UPDATE NO ACTION
GO

ALTER TABLE COMP_REST_COMP
ADD CONSTRAINT REST_COMPET_FK FOREIGN KEY
(
RESTRICCION_COMPETENCIA_res_com_id
)
REFERENCES RESTRICCION_COMPETENCIA
(
res_com_id
)
ON
DELETE
  CASCADE ON
UPDATE NO ACTION
GO


---------------------------------------------------STORED PROCEDURES M12 -------------------------------------

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