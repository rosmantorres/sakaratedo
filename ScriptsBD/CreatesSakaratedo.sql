CREATE
  TABLE ASISTENCIA
  (
    asi_asistio CHAR(1) NOT NULL ,
    INSCRIPCION_ins_id INTEGER NOT NULL ,
	EVENTO_eve_id      INTEGER,
	COMPETENCIA_comp_id INTEGER
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
	det_cantidad		  INTEGER NOT NULL,
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
    dis_id          INTEGER IDENTITY(1,1) NOT NULL ,
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
    est_descripcion VARCHAR (250) NOT NULL ,
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
  TABLE HISTORIAL_CINTAS
  (
    PERSONA_per_id INTEGER NOT NULL ,
    EVENTO_eve_id  INTEGER ,
    his_cin_fecha  DATE NOT NULL ,
    CINTA_cin_id   INTEGER NOT NULL 
  )
  ON "default"
GO

CREATE
  TABLE HISTORIAL_MATRICULA
  (
    his_mat_fecha_vigente DATE NOT NULL ,
    his_mat_modalidad     VARCHAR (50) NOT NULL ,
    his_mat_monto FLOAT NOT NULL ,
    DOJO_doj_id INTEGER NOT NULL 
	
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
    imp_id      INTEGER IDENTITY(1,1) NOT NULL ,
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
    inv_id             INTEGER IDENTITY(1,1) NOT NULL ,
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
    mat_precio            INTEGER NOT NULL,
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
    res_cin_id               INTEGER IDENTITY(1,1) NOT NULL ,
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


CREATE
  TABLE RESTRICCION_COMPETENCIA
  (
    res_com_id        INTEGER IDENTITY(1,1) NOT NULL ,
    res_com_desc      VARCHAR (255) NOT NULL ,
    res_com_edad_min  INTEGER NOT NULL ,
    res_com_edad_max  INTEGER NOT NULL ,
    res_com_rango_min INTEGER NOT NULL ,
    res_com_rango_max INTEGER NOT NULL ,
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
 CONSTRAINT COMP_REST_COMP_PK PRIMARY KEY CLUSTERED (comp_rest_comp_id)
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
  TABLE RESTRICCION_EVENTO
  (
    res_eve_id       INTEGER  IDENTITY(1,1) NOT NULL ,
    res_eve_desc     VARCHAR (255) ,
    res_eve_edad_min INTEGER ,
    res_eve_edad_max INTEGER ,
    res_eve_sexo     VARCHAR (1) ,
    EVENTO_eve_id    INTEGER,
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
	INSCRIPCION_ins_id            INTEGER NOT NULL ,
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
ADD CONSTRAINT ASISTENCIA_COMPETENCIA_FK FOREIGN KEY
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

ALTER TABLE ASISTENCIA
ADD CONSTRAINT ASISTENCIA_INSCRIPCION_FK FOREIGN KEY
(
INSCRIPCION_ins_id
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

ALTER TABLE ASISTENCIA
ADD CONSTRAINT ASISTENCIA_EVENTO_FK FOREIGN KEY
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

ALTER TABLE RESULTADO_ASCENSO
ADD CONSTRAINT RESULTADO_ASCENSO_INSCRIPCION_FK FOREIGN KEY
(
INSCRIPCION_ins_id
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

ALTER TABLE RESULTADO_KATA
ADD CONSTRAINT RESULTADO_KATA_INSCRIPCION_FK FOREIGN KEY
(
INSCRIPCION_ins_id
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

ALTER TABLE RESULTADO_KUMITE
ADD CONSTRAINT RESULTADO_KUMITE_INSCRIPCION1_FK FOREIGN KEY
(
INSCRIPCION_ins_id1
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

ALTER TABLE RESULTADO_KUMITE
ADD CONSTRAINT RESULTADO_KUMITE_INSCRIPCION2_FK FOREIGN KEY
(
INSCRIPCION_ins_id2
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
  CASCADE ON
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
  CASCADE ON
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

ALTER TABLE RESTRICCION_EVENTO
ADD CONSTRAINT RESTRICCION_EVENTO_EVENTO_FK FOREIGN KEY
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

ALTER TABLE SOLICITUD_PLANILLA
ADD CONSTRAINT SOLICITUD_PLANILLA_INSCRIPCION_FK FOREIGN KEY
(
INSCRIPCION_ins_id
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
	@idCompetencia       [int],
	@numCompetencia      [int] OUTPUT
as
 begin
	declare @aux as int;
	set @aux = 0;

	select @aux = comp_id 
	from COMPETENCIA 
	where comp_nombre = @nombreCompetencia
	group by comp_id;

	if (@aux = @idCompetencia or @aux = 0)
		set @numCompetencia = 0;
	else
		select @numCompetencia = count(*)
		from COMPETENCIA 
		where comp_nombre = @nombreCompetencia
 end;
 go

 --PROCEDURE CONSULTAR NOMBRE COMPETENCIA PARA AGREGAR--
CREATE PROCEDURE M12_BuscarNombreCompetenciaAgregar
	@nombreCompetencia   [varchar](100),
	@numCompetencia      [int] OUTPUT
as
 begin

	select @numCompetencia = count(*)
	from COMPETENCIA 
	where comp_nombre = @nombreCompetencia

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

	

--PROCEDURE CONSULTA LISTA DE ORGANIZACIONES--
CREATE procedure M12_ConsultarOrganizaciones
as
	begin
		select org.org_id as idOrganizacion, org.org_nombre as nombreOrganizacion
		from ORGANIZACION as org		
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
			UBICACION_comp_id = (select ubi_id from UBICACION where @latitudDireccion = ubi_latitud and @longitudDireccion = ubi_longitud and @nombreCiudad = ubi_ciudad and @nombreEstado = ubi_estado and @nombreDireccion = ubi_direccion),
			ORGANIZACION_comp_id = null
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
  ----------------------------------STORED PROCEDURES M1-------------------------------------

--------------------PROCEDURE CONSULTA PERSONA POR ID ----------------------

CREATE procedure M1_ConsultarPersona_ID
	@id_usuario [int]
as
	begin
		select pers.per_nombre as nombre_usuario, pers.per_apellido as apellido_usuario, pers.per_id as id_usuario,
		pers.per_num_doc_id as documento_usuario
		from PERSONA pers
		where pers.per_id = @id_usuario
	end;
	go

-----------------------PROCEDURE LISTAR PERSONAS--------------------

CREATE procedure M1_ConsultarNombreUsuarioContrasena_listar
as
	begin
		select pers.per_id as id_usuario, pers.per_nombre_usuario as nombre_usuario, pers.per_clave as contrasena,pers.per_imagen as imagen,
		(pers.per_nombre+' '+pers.per_apellido) as nombreDePila
		from PERSONA pers
	end;
	go



------------------PROCEDURE CONSULTA NOMBRE DE USUARIO Y CONTRASEÑA POR USERNAME--------*Nuevo*----
CREATE procedure M1_ConsultarNombreUsuarioContrasena
	@nombre_usuario [varchar](25)
as
	begin
		select pers.per_id as id_usuario, pers.per_nombre_usuario as nombre_usuario, pers.per_clave as contrasena,pers.per_imagen as imagen,
		(pers.per_nombre+' '+pers.per_apellido) as nombreDePila
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


------------------PROCEDURE CONSULTA NOMBRE DE USUARIO Y CONTRASEÑA POR ID--------*NUEVO*----


CREATE procedure M2_ConsultarNombreUsuarioContrasena_ID
	@id_usuario [int]
as
	begin
		select pers.per_id as id_usuario, pers.per_nombre_usuario as nombre_usuario,pers.per_imagen as imagen,
		(pers.per_nombre+' '+pers.per_apellido) as nombreDePila
		from PERSONA pers
		where pers.per_id = @id_usuario
	end;
	go

-------------------------------------------M14---------------------------------------------------
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

CREATE PROCEDURE M14_ConsultarDatosPlanilla
		@PLANILLA_pla_id         int
AS 
BEGIN
        
		SELECT D.dat_nombre FROM DATO D, PLA_DAT P
		WHERE P.PLANILLA_pla_id = @PLANILLA_pla_id AND P.DATO_dat_id = D.dat_id

END;
GO

CREATE PROCEDURE M14_ConsultarDiseño
	
	@PLANILLA_pla_id [int]	
	   
AS
 BEGIN
	
	SELECT D.dis_id, D.dis_contenido
	FROM DISEÑO D
	WHERE D.PLANILLA_pla_id = @PLANILLA_pla_id
 END
 GO

 CREATE PROCEDURE M14_ConsultarDojoPersonas
	
	@doj_id [int]	
	   
AS
 BEGIN
	
	SELECT D.doj_rif, D.doj_nombre, D.doj_telefono, D.doj_email, D.doj__logo, D.ORGANIZACION_org_id
	FROM DOJO D
	WHERE D.doj_id = @doj_id
 END
 GO

 CREATE PROCEDURE M14_ConsultarMatriculaPersona
	
	@per_id [int],	
	@DOJO_doj_id [int]
	   
AS
 BEGIN
	
	SELECT M.mat_identificador, M.mat_fecha_creacion, M.mat_fecha_ultimo_pago, M.mat_activa, M.mat_precio
	FROM MATRICULA M, PERSONA P
	WHERE M.PERSONA_per_id = @per_id AND M.DOJO_doj_id = @DOJO_doj_id
 END
 GO

 CREATE PROCEDURE M14_ConsultarOrganizacionDojo
	
	@org_id [int]
	   
AS
 BEGIN
	
	SELECT O.org_nombre, O.org_direccion, O.org_telefono, O.org_email
	FROM ORGANIZACION O
	WHERE O.org_id = @org_id
 END
 GO

 CREATE PROCEDURE M14_ConsultarPersonaCompetencia
	@ins_id [int]	   
AS
 BEGIN
	
	 SELECT C.comp_nombre,C.comp_fecha_ini,C.comp_fecha_fin,C.comp_costo, C.comp_tipo,
 (SELECT Ca.cat_sexo FROM CATEGORIA Ca WHERE Ca.cat_id = C.CATEGORIA_comp_id) AS cat_sexo,
 (SELECT Ca.cat_cinta_fin FROM CATEGORIA Ca WHERE Ca.cat_id = C.CATEGORIA_comp_id) AS cintafin, 
 (SELECT Ca.cat_cinta_ini FROM CATEGORIA Ca WHERE Ca.cat_id = C.CATEGORIA_comp_id) AS cintaini,
 (SELECT Ca.cat_edad_fin FROM CATEGORIA Ca WHERE Ca.cat_id = C.CATEGORIA_comp_id) AS cat_edad_fin, 
 (SELECT Ca.cat_edad_ini FROM CATEGORIA Ca WHERE Ca.cat_id = C.CATEGORIA_comp_id) AS cat_edad_ini
	FROM COMPETENCIA C, INSCRIPCION I
	WHERE i.ins_id = @ins_id AND I.COMPETENCIA_comp_id = c.comp_id
 END
 GO

 CREATE PROCEDURE M14_ConsultarPersonaEvento
	@ins_id [int]	   
AS
 BEGIN
	
	SELECT E.eve_id,E.eve_nombre, E.eve_descripcion, E.eve_costo, 
 (SELECT C.cat_sexo FROM CATEGORIA C WHERE C.cat_id = E.CATEGORIA_cat_id) AS cat_sexo,
 (SELECT C.cat_cinta_fin FROM CATEGORIA C WHERE C.cat_id = E.CATEGORIA_cat_id) AS cintafin, 
 (SELECT C.cat_cinta_ini FROM CATEGORIA C WHERE C.cat_id = E.CATEGORIA_cat_id) AS cintaini,
 (SELECT C.cat_edad_fin FROM CATEGORIA C WHERE C.cat_id = E.CATEGORIA_cat_id) AS cat_edad_fin, 
 (SELECT cat_edad_ini FROM CATEGORIA C WHERE C.cat_id = E.CATEGORIA_cat_id) AS cat_edad_ini,
	(SELECT T.tip_nombre FROM TIPO_EVENTO T WHERE T.tip_id = E.TIPO_EVENTO_tip_id) AS tipo,
	(SELECT H.hor_fecha_inicio FROM HORARIO H WHERE H.hor_id= E.HORARIO_hor_id) AS hor_fecha_inicio, 
	(SELECT H.hor_fecha_fin FROM HORARIO H WHERE H.hor_id= E.HORARIO_hor_id) AS hor_fecha_fin, 
	(SELECT H.hor_hora_inicio FROM HORARIO H WHERE H.hor_id= E.HORARIO_hor_id) AS hor_hora_inicio, 
	(SELECT H.hor_hora_fin FROM HORARIO H WHERE H.hor_id=  E.HORARIO_hor_id) AS hor_hora_fin
	FROM EVENTO E, INSCRIPCION I
	WHERE i.ins_id = @ins_id AND I.EVENTO_eve_id = E.eve_id 
 END
 GO

 CREATE PROCEDURE M14_ConsultarPersonas
	
	@per_id [int]	
	   
AS
 BEGIN
	
	SELECT P.per_num_doc_id,P.per_nombre, P.per_apellido, P.per_sexo , P.per_direccion,
	P.per_fecha_nacimiento, P.per_peso, P.per_estatura, P.per_imagen, P.DOJO_doj_id, P.per_nacionalidad
	FROM Persona P
	WHERE P.per_id = @per_id
 END
 GO

 CREATE PROCEDURE M14_ConsultarPlanillasASolicitar
	
AS
 BEGIN
	
	SELECT P.pla_id, P.pla_nombre,(SELECT T.tip_nombre FROM TIPO_PLANILLA T WHERE P.TIPO_PLANILLA_tip_id= T.tip_id) AS tipo, D.dis_id
	FROM DISEÑO D, PLANILLA P
	WHERE D.PLANILLA_pla_id= p.pla_id AND P.pla_status=1
 END
 GO

 CREATE PROCEDURE M14_ConsultarPlanillasCreadas
AS
BEGIN
	SELECT P.pla_id, P.pla_nombre, P.pla_status, T.tip_nombre, T.tip_id
	FROM PLANILLA p, TIPO_PLANILLA T
	WHERE P.TIPO_PLANILLA_tip_id=T.tip_id
END
GO

CREATE PROCEDURE M14_ConsultarSolicitudId
	
	@sol_pla_id [int]	
	   
AS
 BEGIN
	
	SELECT S.sol_pla_fecha_creacion, S.sol_pla_fecha_reincorporacion, S.sol_pla_fecha_retiro,
	S.sol_pla_motivo
	FROM SOLICITUD_PLANILLA S
	WHERE S.sol_pla_id = @sol_pla_id
 END
 GO

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

CREATE PROCEDURE M14_ELIMINAR_SOLICITUD
   @pla_sol_id int
AS 
BEGIN
    DELETE FROM SOLICITUD_PLANILLA
	WHERE sol_pla_id= @pla_sol_id
END
GO

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

 ------Eliminar los datos de planilla----------------

--PROCEDURE ELIMINA DATOS DE LA PLAILLA--
CREATE PROCEDURE M14_ProcedureEliminarDatosPlanilla
	@pla_id [int]

as
 begin
		delete from PLA_DAT
	where
		PLANILLA_pla_id = @pla_id;
 end;
GO



------------agregar datos y planillas------------------------------------

---****------PROCEDURE AGREGAR DATOS Y PLANILLA ID--
CREATE PROCEDURE M14_ProcedureAgregarDatoPlanillaID
	@pla_id [int],
	@dat_nombre [varchar](100)

as
 begin
     
    INSERT INTO PLA_DAT(DATO_dat_id,PLANILLA_pla_id) 
	VALUES((select dat_id from DATO where dat_nombre=@dat_nombre),@pla_id);  

 end;
GO

----****--------Cosultar datos de planilla por id--------------------------

CREATE PROCEDURE M14_ProcedureConsultarDatosPlanillaID
	@pla_id[int]
AS
 BEGIN
	SELECT dat_nombre
    FROM PLANILLA, DATO, PLA_DAT
	WHERE pla_id=@pla_id and DATO_dat_id=dat_id and PLANILLA_pla_id=pla_id;
 END;
GO

-----***-------------Consultar una planilla por ID----------------------

CREATE PROCEDURE M14_ProcedureConsultarPlanillaID
	@pla_id[int]
AS
 BEGIN
	SELECT pla_nombre,pla_status,tip_nombre
    FROM PLANILLA, TIPO_PLANILLA
	WHERE pla_id=@pla_id and tip_id=TIPO_PLANILLA_tip_id;
 END;
GO
----*******--------PROCEDURE MODIFICAR UNA PLANILLA --
CREATE PROCEDURE M14_ProcedureModificarPlanilla
	@pla_id [int],
	@pla_nombre [varchar](100),
	@TIPO_PLANILLA_tip_id [int]

as
 begin
		UPDATE PLANILLA
	SET 
		pla_nombre = @pla_nombre,
		TIPO_PLANILLA_tip_id   = @TIPO_PLANILLA_tip_id
	WHERE
		pla_id = @pla_id;
 end;
GO


-----***----------AGREGAR SOLICITUD PLANILLA------------------------------
CREATE PROCEDURE M14_ProcedureAgregarSolicitud
	
	@sol_pla_fecha_retiro [date],
	@sol_pla_fecha_reincorporacion [date],
	@sol_pla_motivo [varchar] (2000),
	@PLANILLA_pla_id [int],
	@INSCRIPCION_ins_id [int]

as
 begin
  
    INSERT INTO SOLICITUD_PLANILLA(sol_pla_fecha_creacion,sol_pla_fecha_retiro,sol_pla_fecha_reincorporacion,sol_pla_motivo,PLANILLA_pla_id,INSCRIPCION_ins_id) 
	VALUES((SELECT CONVERT (date, SYSDATETIME())),@sol_pla_fecha_retiro,@sol_pla_fecha_reincorporacion,@sol_pla_motivo,@PLANILLA_pla_id,@INSCRIPCION_ins_id);  

 end;
GO




----***------------Listar los tipo de planillas-----------------

CREATE PROCEDURE M14_Procedure_ListarTipoPlanilla
	
AS
 BEGIN
	SELECT tip_id , tip_nombre
    FROM TIPO_PLANILLA;
 END;
GO

---***-----------AGREGAR DATOS Y PLANILLA---------------------
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

------***---------AGREGAR PLANILLA------------------------------
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

---------***---------AGREGAR TIPO PLANILLA------------------------
CREATE PROCEDURE M14_ProcedureAgregarTipoPlanilla
	@tip_nombre [varchar] (100)

as
 begin
  
    INSERT INTO TIPO_PLANILLA(tip_nombre) 
	VALUES(@tip_nombre); 

 end;
GO

------***----------Obtener Datos----------------------------------
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
-----***--------------Listar Datos-------------
CREATE PROCEDURE M14_Procedure_ListarDatos
	
AS
 BEGIN
	SELECT dat_nombre
    FROM Dato;
 END;
GO

--------****---------------------------------------------------------------
CREATE PROCEDURE M14_ConsultaEventoSolicitud
	@PERSONA_per_id [int]
AS
 BEGIN


	SELECT i.ins_id, e.eve_nombre
    FROM  INSCRIPCION as i, EVENTO as e
	WHERE i.PERSONA_per_id=@PERSONA_per_id and i.EVENTO_eve_id=e.eve_id and i.COMPETENCIA_comp_id is null;
	
 END;
GO

------*****-------------------------------------------------------------------
CREATE PROCEDURE M14_ConsultaCompetenciaSolicitud
	@PERSONA_per_id [int]
AS
 BEGIN


	SELECT i.ins_id, c.comp_nombre
    FROM  INSCRIPCION as i, COMPETENCIA as c
	WHERE i.PERSONA_per_id=@PERSONA_per_id and i.COMPETENCIA_comp_id=c.comp_id;
	
 END;
GO

--------****-----------------------------------------------------------------
CREATE PROCEDURE M14_AgregarSolicitudIDPersona
	
	@sol_pla_fecha_retiro [date],
	@sol_pla_fecha_reincorporacion [date],
	@sol_pla_motivo [varchar] (2000),
	@PLANILLA_pla_id [int],
	@per_id [int]

as
 begin
  
  
    INSERT INTO SOLICITUD_PLANILLA(sol_pla_fecha_creacion,sol_pla_fecha_retiro,sol_pla_fecha_reincorporacion,sol_pla_motivo,PLANILLA_pla_id,INSCRIPCION_ins_id) 
	VALUES((SELECT CONVERT (date, SYSDATETIME())),@sol_pla_fecha_retiro,@sol_pla_fecha_reincorporacion,@sol_pla_motivo,@PLANILLA_pla_id,(SELECT ins_id FROM INSCRIPCION WHERE PERSONA_per_id=@per_id and COMPETENCIA_comp_id is null and EVENTO_eve_id is null));  

 end;
GO

-----------*******-------------------------------------------------------------
CREATE PROCEDURE M14_ProcedureConsultarSolicitudID
	@sol_pla_id [int]
AS
 BEGIN
	SELECT sol_pla_fecha_creacion, sol_pla_fecha_reincorporacion,sol_pla_fecha_retiro,sol_pla_motivo,PLANILLA_pla_id, INSCRIPCION_ins_id
    FROM SOLICITUD_PLANILLA
	WHERE  sol_pla_id=@sol_pla_id;
 END;
GO

----------****------------------------------------------------------------
--PROCEDURE MODIFICAR UNA SOLICITUD --
CREATE PROCEDURE M14_ProcedureModificarSolicitud
	@sol_pla_id [int],
	@sol_pla_fecha_retiro [date],
	@sol_pla_fecha_reincorporacion [date],
	@sol_pla_motivo [varchar](2000),
	@INSCRIPCION_ins_id [int]
	

as
 begin
		UPDATE SOLICITUD_PLANILLA
	SET 
		sol_pla_fecha_retiro = @sol_pla_fecha_retiro,
		sol_pla_fecha_reincorporacion = @sol_pla_fecha_reincorporacion,
		sol_pla_motivo = @sol_pla_motivo ,INSCRIPCION_ins_id=@INSCRIPCION_ins_id
	WHERE
		sol_pla_id = @sol_pla_id;
 end;
GO
---------------FIN PROCEDURE MODULO 14----------------------


 --------------------------------------Stored Procedures M9-------------------------------------------------------
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
--------------------------------------------------------------Inicio Procedure M15 Inventario-------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------------------------------------

--------------------M15_ConsultarImplementoUltimo--------------------
CREATE PROCEDURE [dbo].[M15_ConsultarImplementoUltimo]
AS
  BEGIN
    SELECT  TOP(1) imp_id,
            imp_nombre,
        imp_imagen,
        imp_tipo ,
        imp_color,
        imp_marca,
        imp_talla ,
        imp_precio,
        imp_stockmin,
        inv_cantidad_total,
          imp_estatus,
        imp_descripcion,
        DOJO_doj_id
    FROM  IMPLEMENTO, INVENTARIO, DOJO
    WHERE imp_id = IMPLEMENTO_imp_id
    AND   DOJO_doj_id = doj_id
    ORDER BY imp_id DESC;
  END


GO
  ----------------------------------------------------

-----------M15_ConsultarUsuarioDojo------------------------------
CREATE PROCEDURE [dbo].[M15_ConsultarUsuarioDojo]
  @_perUsuario [varchar] (255)
AS
  BEGIN
    SELECT DOJO_doj_id
    FROM PERSONA, DOJO
    WHERE per_nombre_usuario = @_perUsuario
    AND   doj_id=DOJO_doj_id
  END

-------------------------------------------------------------------

GO
/*-------------M15_AgregarImplemento----------------------*/
CREATE PROCEDURE [dbo].[M15_AgregarImplemento]
@_impNombre [varchar] (255),
@_impTipo [varchar] (255),
@_impMarca [varchar] (255),
@_impColor [varchar] (255),
@_impTalla [varchar] (255), 
@_impPrecio [float], 
@_impStockmin [int],
@_invCantidad [int],
@_impDescripcion [varchar] (255),
@_dojId [int],
@_impImagen [varchar] (255)

AS

DECLARE @_impId int = 0

BEGIN
  set @_impId = (Select (max(imp_id)+1) from IMPLEMENTO);
    BEGIN
      INSERT INTO IMPLEMENTO (imp_nombre,imp_imagen,imp_estatus,imp_tipo,imp_marca,imp_color,imp_talla,imp_precio,imp_stockmin,imp_descripcion) VALUES
      (@_impNombre ,@_impImagen,'Activo',@_impTipo,@_impMarca,@_impColor,@_impTalla,@_impPrecio,@_impStockmin,@_impDescripcion);
        END   

    BEGIN
      INSERT INTO INVENTARIO(inv_cantidad_total,IMPLEMENTO_imp_id,DOJO_doj_id) VALUES
      (@_invCantidad,@_impId,@_dojId);
      
    END
END
--------------------------------------------------------------------------
GO
---------------------M15_ConsultarImplemento--------------------
CREATE PROCEDURE [dbo].[M15_ConsultarImplemento]
  @_impId [int]
AS
  BEGIN
    SELECT  imp_id,
            imp_nombre,
        imp_imagen,
        imp_tipo ,
        imp_color,
        imp_marca,
        imp_talla ,
        imp_precio,
        imp_stockmin,
        inv_cantidad_total,
          imp_estatus,
        DOJO_doj_id,
        imp_descripcion
    FROM  IMPLEMENTO, INVENTARIO, DOJO
    WHERE imp_id = ISNULL(@_impId,imp_id)
    AND   imp_id = IMPLEMENTO_imp_id
    AND   DOJO_doj_id = doj_id
  END

  ----------------------------------------------------
GO
  ---------------------M15_ConsultarImplementoTotal--------------------
CREATE PROCEDURE [dbo].[M15_ConsultarImplementoTotal]
@_dojId [int]
AS
  BEGIN
    SELECT  imp_id,
            imp_nombre,
            imp_imagen,
        imp_tipo,
        imp_color,
        imp_marca ,
        imp_talla ,
        imp_precio ,
        imp_stockmin,
        inv_cantidad_total,
        imp_estatus,
        DOJO_doj_id 
          FROM  IMPLEMENTO IMP, INVENTARIO INV, DOJO DOJ
    WHERE imp.imp_estatus != 'Inactivo'
    AND   imp.imp_id = INV.IMPLEMENTO_imp_id
    AND      INV.DOJO_doj_id= DOJ.doj_id
    AND      INV.DOJO_doj_id=@_dojId
  END


  ------------------------------------------------------------------------
GO

  ---------------------M15_ConsultarImplementoTotal2--------------------
CREATE PROCEDURE [dbo].[M15_ConsultarImplementoTotal2]
@_dojId [int]
AS
  BEGIN
    SELECT  imp_id,
            imp_nombre,
            imp_imagen,
        imp_tipo,
        imp_color,
        imp_marca ,
        imp_talla ,
        imp_precio ,
        imp_stockmin,
        inv_cantidad_total ,
        imp_estatus,
        DOJO_doj_id
    FROM  IMPLEMENTO IMP, INVENTARIO INV, DOJO DOJ
    WHERE imp_estatus != 'Activo'
    AND   imp_id = IMPLEMENTO_imp_id
    AND   DOJO_doj_id = doj_id
    AND     doj_id = @_dojId
  END

  ------------------------------------------------------------------------
GO

  /*----------------M15_EliminarImplemento---------------------------------*/
CREATE PROCEDURE [dbo].[M15_EliminarImplemento]
@_impId [int],
@_dojId [int]
AS
  BEGIN
    UPDATE  IMPLEMENTO 
    SET imp_estatus = 'Inactivo'
    WHERE @_impId = imp_id
    AND @_dojId=(select DOJO_doj_id from INVENTARIO where @_impId=IMPLEMENTO_imp_id )
  END
  --------------------------------------------------------------------------
GO
  -------------------------- M15_ModificarImplemento---------------------------------
CREATE PROCEDURE [dbo].[M15_ModificarImplemento]
@_impId [int],
@_impNombre [varchar] (255),
@_impTipo [varchar] (255),
@_impMarca [varchar] (255),
@_impColor [varchar] (255),
@_impTalla [varchar] (255), 
@_impPrecio [varchar] (255), 
@_impStockmin [varchar] (255),
@_invCantidad [int],
@_impDescripcion [varchar] (255),
@_dojId [int],
@_impEstatus [varchar] (255),
@_impImagen [varchar] (255)
AS
BEGIN

     UPDATE IMPLEMENTO 
     SET imp_nombre = @_impNombre,
     imp_estatus = @_impEstatus,
         imp_tipo = @_impTipo,
         imp_marca = @_impMarca,
         imp_color = @_impColor,
         imp_talla = @_impTalla,
         imp_precio = @_impPrecio,
      imp_descripcion = @_impDescripcion,
      imp_imagen = @_impImagen,
         imp_stockmin = @_impStockmin  
   WHERE imp_id = @_impId           
     UPDATE INVENTARIO 
     SET inv_cantidad_total= @_invCantidad
     WHERE IMPLEMENTO_imp_id = @_impId
   AND   DOJO_doj_id = @_dojId 

END


  ---------------------M15_ConsultarImplementoTotal--------------------

GO

CREATE PROCEDURE [dbo].[M15_ConsultarCarrito]
AS
  BEGIN
    SELECT  imp_id,
            imp_nombre,
            imp_imagen,
            imp_tipo,
            imp_color,
            imp_marca ,
            imp_talla ,
            imp_precio ,
            imp_stockmin,
            imp_estatus,
            imp_descripcion
          FROM  IMPLEMENTO 
  END

GO
----------------------------------------------------------------------------------------------------------------------------------------------------------

CREATE procedure M4_ConsultarDojosXId
@idDojo [int]
as
  begin
    select doj.doj_id as idDojo, doj.doj_rif as rifDojo, doj.doj_nombre as nombreDojo, doj.doj_telefono as telefonoDojo, doj.doj_email as emailDojo,
     doj.doj__logo  as LogoDojo, doj.doj_fecha_registro as fechaRegistroDojo, doj.doj_status as statusDojo, ubi.ubi_id as idUbicacion, ubi.ubi_ciudad as nombreCiudad, ubi.ubi_estado as nombreEstado, ubi.ubi_direccion as nombreDireccion, ubi.ubi_latitud as latitudDireccion,
                   ubi.ubi_longitud as longitudDireccion, org.org_id as organizacionDojo , org.org_nombre as orgNombreDojo
         From DOJO doj, ORGANIZACION org, UBICACION ubi
    where doj.doj_id = @idDojo and doj.UBICACION_ubi_id = ubi.ubi_id and doj.ORGANIZACION_org_id = org.org_id 
    
  end;
--------------------------------------------------------------------------------Fin Procedure Inventario----------------------------------------------------


--------------------------------------------------------------P R O C E D U R E S   M 7--------------------------------------------------------------------- 

---------------- Procedimiento para Consultar un Horario ----------------
CREATE PROCEDURE M7_ConsultarHorario	
	@hor_id [int]		   
AS
 BEGIN
	SELECT	hor_id as id, hor_fecha_inicio as fechaInicio, hor_fecha_fin as fechaFin,hor_hora_inicio as horaInicio, hor_hora_fin as horaFin
	FROM	HORARIO H
	WHERE	(H.hor_id=@hor_id) 
	RETURN
END
GO

---------------- Procedimiento para Consultar una Ubicacion ----------------
CREATE PROCEDURE M7_ConsultaUbicacion
			@idUbicacion int
AS
BEGIN
	SELECT	U.ubi_id as id, U.ubi_ciudad as ciudad, U.ubi_estado as estado, U.ubi_direccion as direccion
	FROM	UBICACION U
	WHERE	U.ubi_id = @idUbicacion
END
GO


---------------- Procedimiento para Consultar un Tipo de Evento ----------------
CREATE PROCEDURE M7_ConsultaTipoEvento
			@idTipoEvento int
AS
BEGIN
	SELECT	TE.tip_id as id, TE.tip_nombre as nombre
	FROM	TIPO_EVENTO TE
	WHERE	TE.tip_id = @idTipoEvento
END
GO


---------------- Procedimiento para Consultar los Eventos Asistidos de un Atleta ----------------
CREATE PROCEDURE M7_ConsultarEventosAsistidos
			@per_id int
AS
BEGIN
	SELECT	E.eve_id as id, E.eve_nombre as nombre, E.eve_descripcion as descripcion, E.eve_costo as costo,E.eve_estado as estado, 
			E.HORARIO_hor_id as idHorario, E.UBICACION_ubi_id as idUbicacion,E.TIPO_EVENTO_tip_id as idTipoEvento, I.ins_fecha as fechaInscripcion
	FROM	EVENTO E, INSCRIPCION I, PERSONA P
	WHERE	I.PERSONA_per_id = @per_id  AND I.PERSONA_per_id = P.per_id AND I.EVENTO_eve_id = E.eve_id
END
GO


---------------- Procedimiento para Consultar las Competencias Asistidas de un Atleta ----------------
CREATE PROCEDURE M7_ConsultarCompetenciasAsistidas
			@per_id int
AS
BEGIN
	SELECT	C.comp_id as id, C.comp_nombre as nombre, C.comp_tipo as tipo, C.comp_fecha_ini as fechaInicio,
			C.comp_fecha_fin as fechaFin, C.UBICACION_comp_id as idUbicacion, C.comp_costo as costo
	FROM	COMPETENCIA C, INSCRIPCION I, PERSONA P
	WHERE	I.PERSONA_per_id = @per_id  AND I.PERSONA_per_id = P.per_id AND I.COMPETENCIA_comp_id = C.comp_id
END
GO


---------------- Procedimiento para Consultar un Evento ----------------
CREATE PROCEDURE M7_ConsultaEvento
			@eve_id int
AS
BEGIN
	SELECT	E.eve_id as id, E.eve_nombre as nombre, E.eve_descripcion as descripcion, E.eve_costo as costo,E.eve_estado as estado, 
			E.HORARIO_hor_id as idHorario, E.UBICACION_ubi_id as idUbicacion,E.TIPO_EVENTO_tip_id as idTipoEvento
	FROM	EVENTO E
	WHERE	E.eve_id = @eve_id
END
GO


---------------- Procedimiento para Consultas las Cintas de un Atleta ----------------
CREATE PROCEDURE M7_ConsultarCintas
			@per_id int
AS
BEGIN
	SELECT	C.cin_id as id, C.cin_color_nombre as nombre, C.cin_rango as rango, C.cin_clasificacion as clasificacion,
			C.cin_significado as significado, C.cin_orden as orden
	FROM	CINTA C, HISTORIAL_CINTAS H, PERSONA P
	WHERE	H.PERSONA_per_id = @per_id  AND H.CINTA_cin_id = C.cin_id AND H.PERSONA_per_id = P.per_id
END
GO


---------------- Procedimiento para Consultasr la Fecha de Inscripcion de un Evento ----------------
CREATE PROCEDURE M7_ConsultarFechaInscripcion
			@per_id int,
			@eve_id int
AS
BEGIN
	SELECT	I.ins_fecha as fecha
	FROM	INSCRIPCION I
	WHERE	I.PERSONA_per_id = @per_id  AND I.EVENTO_eve_id = @eve_id AND I.ins_fecha < cast(cast(getdate() as date) as datetime)
END
GO



---------------- Procedimiento para consultar la Fecha de la Cinta ----------------
CREATE PROCEDURE M7_ConsultarFechaCinta
			@per_id int,
			@cin_id int
AS
BEGIN
	SELECT	H.his_cin_fecha as fecha
	FROM	HISTORIAL_CINTAS H
	WHERE	H.PERSONA_per_id = @per_id  AND H.CINTA_cin_id = @cin_id AND H.his_cin_fecha < cast(cast(getdate() as date) as datetime)
END
GO



---------------- Procedimiento para Consultar una Cinta ----------------
CREATE PROCEDURE M7_ConsultaCinta
			@cin_id int
AS
BEGIN
	SELECT	C.cin_id as id, C.cin_color_nombre as nombre, C.cin_rango as rango, C.cin_clasificacion as clasificacion,
			C.cin_significado as significado, C.cin_orden as orden
	FROM	CINTA C
	WHERE	C.cin_id = @cin_id
END
GO


---------------- Procedimiento para Consultar la Última Cinta de una Persona ----------------
CREATE PROCEDURE M7_ConsultarUltimaCinta
			@per_id int
AS
BEGIN
	SELECT	H.his_cin_fecha as fecha, C.cin_id as id, C.cin_color_nombre as nombre, C.cin_rango as rango, C.cin_clasificacion as clasificacion,
			C.cin_significado as significado, C.cin_orden as orden
	FROM	CINTA C, HISTORIAL_CINTAS H, PERSONA P
	WHERE	H.PERSONA_per_id = @per_id  AND H.CINTA_cin_id = C.cin_id AND H.PERSONA_per_id = P.per_id
			AND H.his_cin_fecha = (	SELECT	MAX(H.his_cin_fecha)
									FROM	CINTA C, HISTORIAL_CINTAS H, PERSONA P
									WHERE	H.PERSONA_per_id = @per_id  AND H.CINTA_cin_id = C.cin_id AND H.PERSONA_per_id = P.per_id)
END
GO


---------------- Procedimiento para Consultar un Dojo ----------------
CREATE PROCEDURE M7_ConsultaDojo
			@doj_id int
AS
BEGIN
	SELECT	D.doj_id as id, D.doj_nombre as nombre, D.doj_telefono as telefono,
			D.doj_email as email, D.UBICACION_ubi_id as ubicacion, D.ORGANIZACION_org_id as organizacion
	FROM	DOJO D
	WHERE	D.doj_id = @doj_id
END
GO


---------------- Procedimiento para Consultar una Organización ----------------
CREATE PROCEDURE M7_ConsultaOrganizacion
			@org_id int
AS
BEGIN
	SELECT	O.org_id as id, O.org_nombre as nombre, O.org_direccion as direccion,
			O.org_telefono as telefono, O.org_email as email
	FROM	ORGANIZACION O
	WHERE	O.org_id = @org_id
END
GO


---------------- Procedimiento para Consultar Eventos Inscritos ----------------
CREATE PROCEDURE M7_ConsultaEventoInscrito
			@idAtleta int
AS
BEGIN
	SELECT	E.eve_id as id, E.eve_nombre as nombre, E.eve_descripcion as descripcion, E.eve_costo as costo,E.eve_estado as estado,
			E.HORARIO_hor_id as idHorario, E.UBICACION_ubi_id as idUbicacion,E.TIPO_EVENTO_tip_id as idTipoEvento, H.hor_fecha_inicio as Fecha_Inicio
	FROM	EVENTO E, DETALLE_COMPRA DC, COMPRA_CARRITO CC, TIPO_EVENTO TE, HORARIO H
	WHERE	E.eve_id = DC.EVENTO_eve_id and DC.COMPRA_CARRITO_com_id = CC.com_id and CC.PERSONA_per_id = @idAtleta and TE.tip_id = E.TIPO_EVENTO_tip_id and 
			TE.tip_id != 4 and H.hor_id = E.HORARIO_hor_id and H.hor_fecha_inicio > cast(cast(getdate() as date) as datetime)

END
GO


---------------- Procedimiento para Consultar las Competencias Inscritas ----------------
CREATE PROCEDURE M7_ConsultaCompetenciaInscrita
			@idAtleta int
AS
BEGIN
	SELECT	C.comp_id as id, C.comp_nombre as nombre, C.comp_tipo as tipo, C.comp_fecha_ini as fechaInicio, C.comp_fecha_fin as fechaFin, 
			C.comp_costo as costo, C.CATEGORIA_comp_id as idCategoria, C.UBICACION_comp_id as idUbicacion
	FROM	COMPETENCIA C, INSCRIPCION I 
	WHERE	C.comp_id = I.COMPETENCIA_comp_id and I.PERSONA_per_id = @idAtleta 
END
GO


---------------- Procedimiento para Cconsultar Horario de Práctica ----------------
CREATE PROCEDURE M7_ConsultaHorarioPractica
			@idAtleta int
AS
BEGIN
	SELECT	E.eve_id as id, E.eve_nombre as nombre, E.eve_descripcion as descripcion, E.eve_costo as costo,E.eve_estado as estado, 
			E.HORARIO_hor_id as idHorario, E.UBICACION_ubi_id as idUbicacion,E.TIPO_EVENTO_tip_id as idTipoEvento
	FROM	EVENTO E, DETALLE_COMPRA DC, COMPRA_CARRITO CC, TIPO_EVENTO TE
	WHERE	E.eve_id = DC.EVENTO_eve_id and DC.COMPRA_CARRITO_com_id = CC.com_id and CC.PERSONA_per_id = @idAtleta and E.TIPO_EVENTO_tip_id = TE.tip_id 
			and TE.tip_id = 4
END
GO



---------------- Procedimiento que Consulta una Persona por Id ---------------- 
CREATE PROCEDURE M7_ConsultaPersona
			@idAtleta int
AS
BEGIN
	SELECT	p.per_id as id, p.per_nombre as nombre, p.per_apellido as apellido, p.per_fecha_nacimiento as fechaNacimiento, 
			p.per_direccion as direccion, p.DOJO_doj_id as idDojo
	FROM	PERSONA p
	WHERE	p.per_id = @idAtleta 
END
GO


---------------- Procedimiento para consultar una Matricula----------------------
CREATE PROCEDURE M7_ConsultarMatricula	
			@mat_id [int]		   
AS
 BEGIN
	
	SELECT	mat_identificador as identificador, mat_id as id, mat_fecha_creacion as fechaPag, mat_fecha_ultimo_pago as fechaUltimoPago
	FROM	MATRICULA m 
	WHERE	(M.mat_id=@mat_id)  AND M.mat_fecha_ultimo_pago < cast(cast(getdate() as date) as datetime) 
			AND M.mat_fecha_creacion < cast(cast(getdate() as date) as datetime)
	RETURN
END
GO

---------------- Procedimiento para Consultar el Id de una Matrícula Pagada por un Atleta----------------------
CREATE PROCEDURE M7_ConsultarIdMatricula	
			@per_id [int]		   
AS
 BEGIN
	
	SELECT	mat_id as id
	FROM	MATRICULA m 
	WHERE	(M.PERSONA_per_id=@per_id) 
	RETURN
END
GO

---------------- Procedimiento para Consultasr la Fecha de Pago de un Evento ----------------

CREATE PROCEDURE M7_ConsultarFechaPagoEvento
			@per_id int,
			@eve_id int
AS
BEGIN
	SELECT	C.com_fecha_compra as fecha
	FROM	COMPRA_CARRITO C, DETALLE_COMPRA D
	WHERE	C.PERSONA_per_id = @per_id  AND D.EVENTO_eve_id = @eve_id
	AND     C.com_fecha_compra < cast(cast(getdate() as date) as datetime)
END
GO

---------------- Procedimiento para Consultar el Estado de una Matricula Pagada por un Atleta ---------------- 
CREATE PROCEDURE M7_ConsultarEstadoMatricula
			@per_id [int]		   
AS
 BEGIN
	
	SELECT  mat_activa as status
	FROM	MATRICULA m 
	WHERE	(M.PERSONA_per_id=@per_id) 
	RETURN
END
GO


---------------- Procedimiento para Consultar Monto de Pago Detalle Compra Matrícula ----------------
CREATE PROCEDURE M7_ConsultarMontoMatricula
			@per_id int,
			@mat_id int
AS
BEGIN
	SELECT	d.det_precio as pago
	FROM	DETALLE_COMPRA D 
	WHERE	D.MATRICULA_mat_id = @mat_id  AND D.MATRICULA_per_id = @per_id
	
END
GO


---------------- Procedimiento para Consultar Monto de Pago Detalle Compra Evento ---------------
CREATE PROCEDURE M7_ConsultarMontoEvento
			@per_id int,
			@eve_id int
AS
BEGIN
	SELECT	d.det_precio as monto
	FROM	DETALLE_COMPRA D , COMPRA_CARRITO C
	WHERE   D.EVENTO_eve_id = @eve_id  AND C.PERSONA_per_id = @per_id
	
END
GO


---------------- Procedimiento para Consultas las Matrículas Pagas de los Atletas------
CREATE PROCEDURE M7_ConsultarMatriculasPagas
			@idAtleta int
AS
BEGIN
	
	SELECT	M.mat_id as id, M.mat_identificador as identificador, M.mat_fecha_creacion as fechaPag,
			M.mat_fecha_ultimo_pago as fechaUltimoPago, D.det_precio as pago
	FROM	MATRICULA M, PERSONA P, DETALLE_COMPRA D
	WHERE	M.PERSONA_per_id = @idAtleta  AND M.PERSONA_per_id = P.per_id AND D.MATRICULA_mat_id  = M.mat_id
			AND M.mat_fecha_ultimo_pago < cast(cast(getdate() as date) as datetime) AND M.mat_fecha_creacion < cast(cast(getdate() as date) as datetime)
END
GO



---------------- Procedimiento para Consultas Eventos Pagos de los Atletas ----------------
CREATE PROCEDURE M7_ConsultarEventosPagos
			@idAtleta int
AS
BEGIN
	SELECT	E.eve_id as id, E.eve_nombre as nombre, E.TIPO_EVENTO_tip_id as idTipoEvento, 
	        D.det_precio as pago, D.COMPRA_CARRITO_com_id as idCarrito, C.com_tipo_pago as tipoPago, C.com_fecha_compra as fechaPago
	FROM	EVENTO E, DETALLE_COMPRA D, PERSONA P, COMPRA_CARRITO C
	WHERE	C.PERSONA_per_id = @idAtleta AND C.PERSONA_per_id = P.per_id AND D.COMPRA_CARRITO_com_id = C.com_id  AND  D.EVENTO_eve_id = E.eve_id  
	        AND C.com_fecha_compra < cast(cast(getdate() as date) as datetime)
END
GO


---------------- Procedimiento para Consultas las Competencias Pagas de los Atletas ----------------
CREATE PROCEDURE M7_ConsultarCompetenciasPagas
			@idAtleta int
AS
BEGIN
	SELECT	C.comp_id as id, C.comp_nombre as nombre, C.comp_tipo as tipo, C.comp_costo as costo, I.ins_fecha as fechaInscripcion
	       		
	FROM	COMPETENCIA C, INSCRIPCION I, PERSONA P
	WHERE	 (I.PERSONA_per_id = @idAtleta AND I.PERSONA_per_id = P.per_id AND I.COMPETENCIA_comp_id  = C.comp_id AND 
	         I.ins_fecha < cast(cast(getdate() as date) as datetime))	
END
GO


-------------------------------- Procedimiento para consultar una Competencia----------------------
CREATE PROCEDURE M7_ConsultaCompetencia
			@comp_id int
AS
BEGIN
	SELECT	C.comp_id as id, C.comp_nombre as nombre, C.comp_tipo as tipo, C.comp_fecha_ini as fechaInicio, C.comp_fecha_fin as fechaFin,
	C.comp_costo as costo, C.CATEGORIA_comp_id as idCategoria, C.UBICACION_comp_id as idUbicacion
	FROM	COMPETENCIA C
	WHERE	C.comp_id = @comp_id
END
GO

---------------- Procedimiento para Consultas las Fecha de Inscripcion de una Competencia ----------------
CREATE PROCEDURE M7_ConsultarFechaInscripcionCompetencia
			@per_id int,
			@com_id int
AS
BEGIN
	SELECT	I.ins_fecha as fechaInscripcion	
	FROM	INSCRIPCION I
	WHERE	 (I.PERSONA_per_id = @per_id AND  I.COMPETENCIA_comp_id  = @com_id AND I.ins_fecha < cast(cast(getdate() as date) as datetime))	
END
GO
---------------------------------------------------------------FIN M7--------------------------------------------------------------------------

/*===============================================Stored Procedures Modulo 16 =======================*/

----------------------- STORE PROCEDURE INVENTARIO / EVENTO / FACTURAS (M14) / MATRICULA ---------------------------------
CREATE PROCEDURE M16_CONSULTARINVENTARIO

AS
 BEGIN
	select imp_id as idImplemento,
	    imp_imagen as impImagen,
		imp_nombre as impNombre,
		imp_tipo as impTipo, 
		imp_marca as impMarca, 
		imp_precio as impPrecio 
	from IMPLEMENTO
 END
 GO
 
 
 CREATE PROCEDURE M16_DETALLARIMPLEMENTO
	@iditem [int]
AS
 BEGIN
	select	imp_imagen as impImagen,
		imp_nombre as impNombre,
		imp_tipo as impTipo, 
		imp_marca as impMarca, 
		imp_color as impColor,
		imp_talla as impTalla,
		imp_estatus as impEstatus,
		imp_precio as impPrecio,
		imp_descripcion as impDescripcion 
from IMPLEMENTO
where imp_id =@iditem
END
GO

CREATE PROCEDURE M16_CONSULTAREVENTOS

AS
 BEGIN
	select  eve_id as idEvento,
			eve_nombre as impNombre,
			eve_descripcion as impDescripcion,
			eve_costo as impPrecio 
	from EVENTO
END
GO

CREATE PROCEDURE M16_DETALLAREVENTO
	@iditem [int]
AS
 BEGIN
	select 	eve_id as idEvento,
			eve_nombre as impNombre,
			eve_costo as impPrecio, 
			eve_descripcion as impDescripcion
	from	EVENTO
	where	eve_id =@iditem
END
GO

CREATE PROCEDURE M16_consultarMatriculas

AS
 BEGIN
    SELECT	M.mat_id AS idMatricula ,
			M.mat_identificador AS idIdentificadorMatricla, 
	        M.mat_fecha_creacion AS fechaInicio,
		    M.mat_fecha_ultimo_pago AS fechaTope
	 		
	FROM  MATRICULA M
 END
 GO
 
 CREATE PROCEDURE M16_CONSULTARCOMPRA
@per_id [int]
AS
 BEGIN
    SELECT	com_id as idCompra,
		com_tipo_pago as tipoPago,
		com_fecha_compra as fecha,
		com_estado as estado
	 		
	FROM  COMPRA_CARRITO
	WHERE PERSONA_per_id = @per_id and
		  com_estado ='PAGADO';
 END
 GO
 
--------------------- STORE PROCEDURE CARRITO DE COMPRA /MODIFICAR / ELIMINAR / REGISTRAR PAGO

/* Selecciono ID de los Inventarios agregados al carrito */
CREATE PROCEDURE M16_SELECCIONAR_ID_MATRICULA
		@idusuario INTEGER
AS
BEGIN
	--Busco el carrito actual del Usuario
	DECLARE @idcompra INTEGER;
	SET @idcompra = (SELECT com_id FROM COMPRA_CARRITO WHERE PERSONA_per_id = @idusuario AND com_estado = 'CARRITO');

	--Selecciono los ID sin repetirse
	SELECT DISTINCT MATRICULA_mat_id as idMatricula FROM DETALLE_COMPRA WHERE COMPRA_CARRITO_com_id = @idcompra and MATRICULA_mat_id IS NOT NULL;
END
GO

/* Selecciono ID de los Inventarios agregados al carrito */
CREATE PROCEDURE M16_SELECCIONAR_ID_INVENTARIO
		@idusuario INTEGER
AS
BEGIN
	--Busco el carrito actual del Usuario
	DECLARE @idcompra INTEGER;
	SET @idcompra = (SELECT com_id FROM COMPRA_CARRITO WHERE PERSONA_per_id = @idusuario AND com_estado = 'CARRITO');

	--Selecciono los ID sin repetirse
	SELECT DISTINCT IMPLEMENTO_inv_id AS idImplemento FROM DETALLE_COMPRA WHERE COMPRA_CARRITO_com_id = @idcompra and IMPLEMENTO_inv_id IS NOT NULL;
END
GO

/* Selecciono ID de los eventos agregados al carrito */
CREATE PROCEDURE M16_SELECCIONAR_ID_EVENTO
		@idusuario INTEGER
AS
BEGIN
	--Busco el carrito actual del Usuario
	DECLARE @idcompra INTEGER;
	SET @idcompra = (SELECT com_id FROM COMPRA_CARRITO WHERE PERSONA_per_id = @idusuario AND com_estado = 'CARRITO');

	--Selecciono los ID sin repetirse
	SELECT DISTINCT EVENTO_eve_id AS idEvento FROM DETALLE_COMPRA WHERE COMPRA_CARRITO_com_id = @idcompra AND EVENTO_eve_id IS NOT NULL;
END
GO


CREATE PROCEDURE M16_MODIFICAR_CANTIDAD_IMPLEMENTO
				@idPersona int,
				@idImplemento int,
				@cantidad int,
				@exito int OUTPUT
AS
BEGIN

	DECLARE @Dojo INT;
	SET @Dojo = (SELECT D.doj_id FROM DOJO D, PERSONA P WHERE P.per_id = @idPersona AND D.doj_id = P.DOJO_doj_id);
		
	DECLARE @cantidadEnstock INT;
	SET @cantidadEnstock = (SELECT V.inv_cantidad_total AS cantidadInventario 
	FROM IMPLEMENTO I, INVENTARIO V 
	WHERE I.imp_id = V.IMPLEMENTO_imp_id AND I.imp_id = @idImplemento AND V.DOJO_doj_id = @Dojo);
		
	IF @cantidadEnstock > = @cantidad
		BEGIN
			--Busco el ID del carrito
			DECLARE @idCarrito INT;
			SET @idCarrito = (SELECT C.com_id FROM COMPRA_CARRITO C WHERE C.PERSONA_per_id = @idPersona AND C.com_estado = 'CARRITO');

			--Actualizo la cantidad que hay actualmente
			UPDATE DETALLE_COMPRA SET det_cantidad = @cantidad WHERE COMPRA_CARRITO_com_id = @idCarrito AND IMPLEMENTO_inv_id =@idImplemento;

			SET @exito= 1;

			COMMIT;
		END
	ELSE
		BEGIN
			SET @exito = 0;
		END
END
GO

CREATE PROCEDURE M16_MODIFICAR_CANTIDAD_EVENTO
				@idPersona int,
				@idEvento int,
				@cantidad int,
				@exito int OUTPUT
AS
BEGIN
	
			--Busco el ID del carrito
			DECLARE @idCarrito INT;
			SET @idCarrito = (SELECT C.com_id FROM COMPRA_CARRITO C WHERE C.PERSONA_per_id = @idPersona AND C.com_estado = 'CARRITO');

			--Actualizo la cantidad que hay actualmente
			UPDATE DETALLE_COMPRA SET det_cantidad = @cantidad WHERE COMPRA_CARRITO_com_id = @idCarrito AND EVENTO_eve_id = @idEvento;

			SET @exito= 1;

			COMMIT;
	
END
GO

/* Listar todas las matriculas pagadas por el usuario recientemente */
CREATE PROCEDURE M16_MATRICULAS_PAGADAS
				@idusuario INT
AS
BEGIN

	--Realizo la consulta
	/*SELECT D.MATRICULA_per_id AS idMatricula FROM COMPRA_CARRITO C, DETALLE_COMPRA D 
	WHERE C.PERSONA_per_id = @idusuario AND C.com_id = D.COMPRA_CARRITO_com_id AND C.com_estado = 'PAGADO'
	AND C.com_fecha_compra = (SELECT MAX(com_fecha_compra) FROM COMPRA_CARRITO);*/

	SELECT D.MATRICULA_per_id AS idMatricula FROM COMPRA_CARRITO C, DETALLE_COMPRA D 
	WHERE C.PERSONA_per_id = @idusuario AND C.com_id = D.COMPRA_CARRITO_com_id AND C.com_estado = 'PAGADO'
	GROUP BY D.MATRICULA_per_id
	HAVING MAX (C.com_fecha_compra) <= GETDATE();

END
GO

/* Eliminar Item */
CREATE PROCEDURE M16_ELIMINAR_ITEM
		@idusuario int,
		@iditem int,
		@tipoitem int
AS
BEGIN

	--Buscamos el ID del carrito de la persona correspondiente
	DECLARE @idcarrito INTEGER;
	SET @idcarrito = (SELECT com_id FROM COMPRA_CARRITO WHERE PERSONA_per_id = @idusuario AND com_estado = 'CARRITO');

	--Evaluamos a que tipo de item nos estamos refiriendo y lo eliminamos
	IF (@tipoitem = 1)
		DELETE FROM DETALLE_COMPRA WHERE COMPRA_CARRITO_com_id = @idcarrito AND IMPLEMENTO_inv_id = @iditem;
	ELSE IF (@tipoitem = 2)
		DELETE FROM DETALLE_COMPRA WHERE COMPRA_CARRITO_com_id = @idcarrito AND MATRICULA_mat_id = @iditem;
	ELSE IF (@tipoitem = 3)
		DELETE FROM DETALLE_COMPRA WHERE COMPRA_CARRITO_com_id = @idcarrito AND EVENTO_eve_id = @iditem;

	--Si el carrito se quedo sin detalles lo eliminamos
	IF NOT EXISTS (SELECT det_id FROM DETALLE_COMPRA WHERE COMPRA_CARRITO_com_id = @idcarrito)
		DELETE FROM COMPRA_CARRITO WHERE com_id = @idcarrito;
	

END
GO

/* Consulta toda la informacion de un inventario dado el ID */
CREATE PROCEDURE M16_CONSULTAR_INVENTARIO_ID
		@iditem INTEGER
AS
BEGIN
	--Selecciono la informacion del implemento
	SELECT imp_imagen as impImagen, imp_nombre as impNombre,
	imp_tipo as impTipo, imp_marca as impMarca, imp_precio as impPrecio
	FROM implemento WHERE imp_id = @iditem;
END
GO

/* Consulta la informacion del evento dado el ID del evento en especifico */
CREATE PROCEDURE M16_CONSULTAR_EVENTO_ID
		@iditem INTEGER
AS
BEGIN
	--Selecciono la informacion del evento
	SELECT eve_nombre as impNombre, eve_costo as impPrecio
	FROM EVENTO WHERE eve_id = @iditem;
END
GO



/* Registrar Pago Actualizado para las 4 pm del 01/12/15 */
CREATE PROCEDURE M16_REGISTRAR_PAGO
		@idusuario int,
		@pago [varchar] (100)
		
AS
BEGIN
	
	-------------------------------------------------INSERTO EN INSCRIPCION--------------------------------------------

	--Obtengo todos los eventos de la persona que estan en el carrito
	DECLARE @eventos CURSOR;
	SET @eventos = CURSOR FOR SELECT EVENTO_eve_id, det_cantidad FROM COMPRA_CARRITO, DETALLE_COMPRA
	WHERE COMPRA_CARRITO.PERSONA_per_id = @idUsuario AND COMPRA_CARRITO.com_id = DETALLE_COMPRA.COMPRA_CARRITO_com_id
	AND EVENTO_eve_id IS NOT NULL AND COMPRA_CARRITO.com_estado= 'CARRITO';
	
	--Variable que contendra el id del evento al recorrer la lista
	DECLARE @evento int;
	DECLARE @cantidadEvento int;
	--Recorro cada uno de los eventos que haya en el carrito para insertar en inscripcion tantas veces como hayan
	OPEN @eventos
	FETCH NEXT FROM @eventos INTO @evento, @cantidadEvento;
	WHILE @@FETCH_STATUS = 0
	BEGIN
		DECLARE @aux INT;
		SET @aux = 1;
		WHILE @aux < = @cantidadEvento
		BEGIN
			--Inserto en la tabla inscripcion
			INSERT INTO INSCRIPCION VALUES (@idusuario,GETDATE(),NULL,@evento);
			SET @aux = @aux +1;
		END
		FETCH NEXT FROM @eventos INTO @evento, @cantidadEvento;
	END;

	--Cierro el cursor
	CLOSE @eventos;
	DEALLOCATE @eventos;
	-------------------------------------------------------------------------------------------------------------------

	-----------------------------------------------------ACTUALIZAR INVENTARIO-----------------------------------------
	
	--Si se compraron implementos los obtengo de la compra para actualizar la cantidad de cada uno
	DECLARE @implementos CURSOR;
	SET @implementos = CURSOR FOR SELECT D.IMPLEMENTO_inv_id, D.det_cantidad AS CANTIDAD 
	FROM COMPRA_CARRITO C, DETALLE_COMPRA D
	WHERE C.PERSONA_per_id = @idUsuario AND D.IMPLEMENTO_inv_id IS NOT NULL AND C.com_id = D.COMPRA_CARRITO_com_id AND 
	C.com_estado = 'CARRITO';

	/*--Obtengo el Dojo al cual la Persona esta asociada para saber a cual dojo se vera afectado su inventario
	DECLARE @idDojo INT;
	SET @idDojo = (SELECT P.DOJO_doj_id FROM PERSONA P WHERE P.per_id = @idUsuario);
	*/

	--Variables que contendran los id de los implementos y la cantidad comprada
	DECLARE @idimplemento INT, @cantidad INT;

	--Recorro cada uno de los implementos y cantidad que haya en el carrito para actualizar en el inventario
	 OPEN @implementos
	 FETCH NEXT FROM @implementos INTO @idimplemento, @cantidad;
	 WHILE @@FETCH_STATUS = 0
	 BEGIN
		
		DECLARE @inventarios CURSOR;
		DECLARE @cantidad2 INT;
		DECLARE @inventarioid2 INT;
		SET @inventarios = CURSOR FOR SELECT I.inv_cantidad_total AS cantidad, I.inv_id as inventarioid FROM INVENTARIO I WHERE I.IMPLEMENTO_imp_id = @idimplemento;
		OPEN @inventarios
		FETCH NEXT FROM @inventarios INTO @cantidad2, @inventarioid2;
		WHILE @@FETCH_STATUS = 0
		BEGIN
			IF (@cantidad2 >= @cantidad)
			BEGIN
			--Actualizo la tabla INVENTARIO de modulo 15
				UPDATE INVENTARIO SET inv_cantidad_total = inv_cantidad_total-@cantidad 
				WHERE IMPLEMENTO_imp_id = @idimplemento AND inv_id = @inventarioid2;
				BREAK; 
			END
		FETCH NEXT FROM @inventarios INTO @cantidad2, @inventarioid2;
		END
		CLOSE @inventarios;
		DEALLOCATE @inventarios;
		
	--(SELECT V.inv_id FROM INVENTARIO V, IMPLEMENTO M WHERE M.imp_id = @idimplemento AND V.IMPLEMENTO_imp_id = M.imp_id)
		FETCH NEXT FROM @implementos INTO @idimplemento, @cantidad;
	 END;

	 --Cierro el cursor
	 CLOSE @implementos;
	 DEALLOCATE @implementos;

	 ------------------------------------------------------------------------------------------------------------------

	 ---------------------------------------------------REGISTRAR PAGO CARRITO-----------------------------------------

	--Actualizo el estado de la compra para indicar que ya se pago
	UPDATE COMPRA_CARRITO SET com_estado = 'PAGADO', com_tipo_pago=@pago, com_fecha_compra=GETDATE() 
	WHERE PERSONA_per_id = @idUsuario AND com_estado = 'CARRITO';

	-------------------------------------------------------------------------------------------------------------------

END
GO

CREATE PROCEDURE M16_AGREGAR_IMPLEMENTO_CARRITO 
	@idPersona [int],
	@idImplemento [int],
	@cantidad [int],
	@precio [int],
	@exito [int] OUTPUT
AS
	BEGIN
			
		--Obtengo todos los inventarios de ese implemento
		DECLARE @Stocks CURSOR;
		SET @Stocks = CURSOR FOR SELECT V.inv_id, V.inv_cantidad_total FROM IMPLEMENTO I, INVENTARIO V
		WHERE I.imp_id = V.IMPLEMENTO_imp_id AND I.imp_id = @idImplemento;
		
		--Variables que obtendran los datos del cursor
		DECLARE @cantidadEnstock INT;
		DECLARE @idInventario INT;

		--Abro el cursor y recorro
		OPEN @Stocks
		FETCH NEXT FROM @Stocks INTO @idInventario, @cantidadEnstock;
		WHILE @@FETCH_STATUS = 0
		BEGIN
			IF @cantidadEnstock > = @cantidad
			BEGIN
				DECLARE @idCarrito INT;
				--Si ya tiene un carrito (compra en proceso) agregamos la cantidad que desea el usuario
				IF EXISTS (SELECT C.com_id FROM COMPRA_CARRITO C WHERE C.PERSONA_per_id = @idPersona AND C.com_estado = 'CARRITO')
					BEGIN

						--Buscamos el ID del carrito
						SET @idCarrito = (SELECT C.com_id FROM COMPRA_CARRITO C WHERE C.PERSONA_per_id = @idPersona AND C.com_estado = 'CARRITO');
						
						--Verificamos si ese Item ya esta en el carrito o no
						IF EXISTS (SELECT D.IMPLEMENTO_inv_id FROM DETALLE_COMPRA D WHERE D.IMPLEMENTO_inv_id IS NOT NULL AND D.COMPRA_CARRITO_com_id = @idCarrito AND D.IMPLEMENTO_inv_id = @idImplemento)
							--Actualizamos si existe
							UPDATE DETALLE_COMPRA 
							SET det_cantidad = det_cantidad + @cantidad 
							WHERE COMPRA_CARRITO_com_id = @idCarrito AND IMPLEMENTO_inv_id = @idImplemento;

						--Sino existe lo insertamos
						ELSE
							BEGIN
								--Selecciono el ID del ultimo compra_carrito creado
								DECLARE @ultimoId2 INT;
								SET @ultimoId2 = (SELECT MAX(com_id) FROM COMPRA_CARRITO WHERE PERSONA_per_id = @idPersona);
								INSERT INTO DETALLE_COMPRA VALUES (@ultimoId2,@precio,@cantidad,NULL,NULL,@idImplemento,NULL,NULL);
							END
					END

				--Si aun no tiene un compra en proceso
				ELSE
					BEGIN
						--Creamos un carrito nuevo y le añadimos un detalle
						INSERT INTO COMPRA_CARRITO VALUES (NULL,NULL,'CARRITO',@idPersona);

						--Selecciono el ID del ultimo compra_carrito creado
						DECLARE @ultimoId INT;
						SET @ultimoId = (SELECT MAX(com_id) FROM COMPRA_CARRITO WHERE PERSONA_per_id = @idPersona);

						--Creo mi primer detalle de la compra
						INSERT INTO DETALLE_COMPRA VALUES (@ultimoId,@precio,@cantidad,NULL,NULL,@idImplemento,NULL,NULL);

					END
				SET @exito = 1;
				BREAK;
			END
			FETCH NEXT FROM @Stocks INTO @idInventario, @cantidadEnstock;
		END

		--Cierro el cursor
		CLOSE @stocks;
		DEALLOCATE @stocks;				
END
GO

CREATE PROCEDURE M16_AGREGAR_EVENTO_CARRITO 
	@idPersona int,
	@idEvento int,
	@cantidad int,
	@precio int,
	@exito int OUTPUT
AS
BEGIN

	DECLARE @idCarrito INT;
	--Si ya tiene un carrito (compra en proceso) agregamos la cantidad que desea el usuario
	IF EXISTS (SELECT C.com_id FROM COMPRA_CARRITO C WHERE C.PERSONA_per_id = @idPersona AND C.com_estado = 'CARRITO')
		BEGIN

			--Buscamos el ID del carrito
			SET @idCarrito = (SELECT C.com_id FROM COMPRA_CARRITO C WHERE C.PERSONA_per_id = @idPersona AND C.com_estado = 'CARRITO');
						
			--Verificamos si ese Item ya esta en el carrito o no
			IF EXISTS (SELECT D.EVENTO_eve_id FROM DETALLE_COMPRA D WHERE D.EVENTO_eve_id IS NOT NULL AND D.COMPRA_CARRITO_com_id = @idCarrito AND D.EVENTO_eve_id = @idEvento)
				--Actualizamos si existe
				UPDATE DETALLE_COMPRA 
				SET det_cantidad = det_cantidad + @cantidad 
				WHERE COMPRA_CARRITO_com_id = @idCarrito AND EVENTO_eve_id = @idEvento;

			--Sino existe lo insertamos
			ELSE
				BEGIN
					--Selecciono el ID del ultimo compra_carrito creado
					DECLARE @ultimoId2 INT;
					SET @ultimoId2 = (SELECT MAX(com_id) FROM COMPRA_CARRITO WHERE PERSONA_per_id = @idPersona);
					INSERT INTO DETALLE_COMPRA VALUES (@ultimoId2,@precio,@cantidad,NULL,NULL,NULL,@idEvento,NULL);
				END
		END

	--Si aun no tiene un compra en proceso
	ELSE
		BEGIN
			--Creamos un carrito nuevo y le añadimos un detalle
			INSERT INTO COMPRA_CARRITO VALUES (NULL,NULL,'CARRITO',@idPersona);

			--Selecciono el ID del ultimo compra_carrito creado
			DECLARE @ultimoId INT;
			SET @ultimoId = (SELECT MAX(com_id) FROM COMPRA_CARRITO WHERE PERSONA_per_id = @idPersona);

			--Creo mi primer detalle de la compra
			INSERT INTO DETALLE_COMPRA VALUES (@ultimoId,@precio,@cantidad,NULL,NULL,NULL,@idEvento,NULL);

		END
	SET @exito = 1;
END
GO

CREATE PROCEDURE M16_AGREGAR_MATRICULA_CARRITO 
	@idPersona int,
	@idMatricula int,
	@cantidad int,
	@precio int,
	@exito int OUTPUT
AS
BEGIN

	DECLARE @idCarrito INT;

	--Si ya tiene un carrito (compra en proceso) agregamos la cantidad que desea el usuario
	IF EXISTS (SELECT C.com_id FROM COMPRA_CARRITO C WHERE C.PERSONA_per_id = @idPersona AND C.com_estado = 'CARRITO')
		BEGIN

			--Buscamos el ID del carrito
			SET @idCarrito = (SELECT C.com_id FROM COMPRA_CARRITO C WHERE C.PERSONA_per_id = @idPersona AND C.com_estado = 'CARRITO');
						
			--Verificamos si ese Item ya esta en el carrito o no
			IF EXISTS (SELECT D.MATRICULA_mat_id FROM DETALLE_COMPRA D WHERE D.MATRICULA_mat_id IS NOT NULL AND D.COMPRA_CARRITO_com_id = @idCarrito AND D.MATRICULA_mat_id = @idMatricula)
				--Actualizamos si existe
				UPDATE DETALLE_COMPRA 
				SET det_cantidad = det_cantidad + @cantidad 
				WHERE COMPRA_CARRITO_com_id = @idCarrito AND MATRICULA_mat_id = @idMatricula;

			--Sino existe lo insertamos
			ELSE
				BEGIN
					--Selecciono el ID del ultimo compra_carrito creado
					DECLARE @ultimoId2 INT;
					SET @ultimoId2 = (SELECT MAX(com_id) FROM COMPRA_CARRITO WHERE PERSONA_per_id = @idPersona);
					INSERT INTO DETALLE_COMPRA VALUES (@ultimoId2,@precio,@cantidad,@idMatricula,NULL,NULL,NULL,NULL);
				END
		END

	--Si aun no tiene un compra en proceso
	ELSE
		BEGIN
			--Creamos un carrito nuevo y le añadimos un detalle
			INSERT INTO COMPRA_CARRITO VALUES (NULL,NULL,'CARRITO',@idPersona);

			--Selecciono el ID del ultimo compra_carrito creado
			DECLARE @ultimoId INT;
			SET @ultimoId = (SELECT MAX(com_id) FROM COMPRA_CARRITO WHERE PERSONA_per_id = @idPersona);

			--Creo mi primer detalle de la compra
			INSERT INTO DETALLE_COMPRA VALUES (@ultimoId,@precio,@cantidad,@idMatricula,NULL,NULL,NULL,NULL);

		END
	SET @exito = 1;
END

/*===============================================Stored Procedures Modulo 16 =======================*/