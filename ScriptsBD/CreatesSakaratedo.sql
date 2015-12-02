﻿CREATE
  TABLE ASISTENCIA
  (
    asi_asistio CHAR(1) NOT NULL ,
    INSCRIPCION_ins_id INTEGER NOT NULL ,

  EVENTO_eve_id      INTEGER NOT NULL,
   

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
    det_precio            FLOAT NOT NULL ,
  det_cantidad      INTEGER NOT NULL,
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
    ins_id                           INTEGER IDENTITY(1,1) NOT NULL ,
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


---------------------------------------------------------STORED PROCEDURES M12--------------------------------------------------------------------

--PROCEDURE AGREGAR COMPETENCIA--
CREATE PROCEDURE M12_AgregarCompetencia
  @nombreCompetencia   [varchar](100),
  @tipoCompetencia     [int],
  @organizacionesTodas [bit],
  @statusCompetencia   [varchar](100),
  @fecha_ini         [datetime],
  @fecha_fin           [datetime],
  @nombreOrganizacion  [varchar](100),
  @nombreCiudad    [varchar](100),
  @nombreEstado        [varchar](100),
  @nombreDireccion   [varchar](100),
  @latitudDireccion    [varchar](100),
  @longitudDireccion   [varchar](100),
  @edadIni       [int],
  @edadFin       [int],
  @cintaIni      [varchar](100),
  @cintaFin            [varchar](100),
  @sexo        [char](1),
  @costoCompetencia  [float]
 
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
  @fecha_ini         [datetime],
  @fecha_fin           [datetime],
  @nombreOrganizacion  [varchar](100),
  @nombreCiudad    [varchar](100),
  @nombreEstado        [varchar](100),
  @nombreDireccion   [varchar](100),
  @latitudDireccion    [varchar](100),
  @longitudDireccion   [varchar](100),
  @edadIni       [int],
  @edadFin       [int],
  @cintaIni      [varchar](100),
  @cintaFin            [varchar](100),
  @sexo        [char](1),
  @costoCompetencia  [float]
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
<<<<<<< HEAD
  begin
    select cin.cin_id as idCinta, cin.cin_color_nombre nombreCinta, cin_orden as ordenCinta
    from CINTA as cin   
  end;
=======
	begin
		select cin.cin_id as idCinta, cin.cin_color_nombre nombreCinta, cin_orden as ordenCinta
		from CINTA as cin		
	end;
>>>>>>> 5bd2abb0082af1b93601fe7a3a8459dfc9fc10c9
go


  ----------------------------------STORED PROCEDURES M1-------------------------------------

-------*NUEVO*-------PROCEDURE CONSULTA PERSONA POR ID ----------------------

CREATE procedure M1_ConsultarPersona_ID
	@id_usuario [int]
as
	begin
		select pers.per_nombre as nombre_usuario, pers.per_apellido as apellido_usuario, pers.per_id as id_usuario
		from PERSONA pers
		where pers.per_id = @id_usuario
	end;
	go





------------------PROCEDURE CONSULTA NOMBRE DE USUARIO Y CONTRASEÑA POR USERNAME--------*Nuevo*----
CREATE procedure M1_ConsultarNombreUsuarioContrasena
  @nombre_usuario [varchar](25)
as
<<<<<<< HEAD
  begin
    select pers.per_id as id_usuario, pers.per_nombre_usuario as nombre_usuario, pers.per_clave as contrasena
    from PERSONA pers
    where pers.per_nombre_usuario = @nombre_usuario
  end;
  go
=======
	begin
		select pers.per_id as id_usuario, pers.per_nombre_usuario as nombre_usuario, pers.per_clave as contrasena,pers.per_imagen as imagen,
		(pers.per_nombre+' '+pers.per_apellido) as nombreDePila
		from PERSONA pers
		where pers.per_nombre_usuario = @nombre_usuario
	end;
	go
>>>>>>> 51d6c0785d0a3e8403ffbc0ea13cf2575a1d2c15



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
<<<<<<< HEAD
  begin
    select  PERSONA_per_id  as correo_usuario
    from EMAIL
    where ema_email= @correo_usuario and ema_principal=1
  end;
  go

=======
	begin
		select  PERSONA_per_id  as correo_usuario
		from EMAIL
		where ema_email= @correo_usuario and ema_principal=1
	end;
go
>>>>>>> 51d6c0785d0a3e8403ffbc0ea13cf2575a1d2c15

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

-------------------------------------------------Stored Procedure M14--------------------------
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

<<<<<<< HEAD
=======
-------------------------------------------------Stored Procedure M14--------------------------
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

>>>>>>> 5bd2abb0082af1b93601fe7a3a8459dfc9fc10c9
 end;
 GO
 ----------------Obtener Datos----------------------------------
CREATE PROCEDURE M14_ProcedureDatosPlanilla
<<<<<<< HEAD
  @pla_nombre [varchar] (100),
  @pla_status [bit],
  @TIPO_PLANILLA_tip_id [int]
=======
	@pla_nombre [varchar] (100),
	@pla_status [bit],
	@TIPO_PLANILLA_tip_id [int]
>>>>>>> 5bd2abb0082af1b93601fe7a3a8459dfc9fc10c9

as
 begin

    INSERT INTO PLANILLA(pla_nombre,pla_status,TIPO_PLANILLA_tip_id) 
<<<<<<< HEAD
  VALUES(@pla_nombre,@pla_status,@TIPO_PLANILLA_tip_id);  

 end;
 GO
=======
	VALUES(@pla_nombre,@pla_status,@TIPO_PLANILLA_tip_id);  

 end;
 GO
 
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
<<<<<<< HEAD
>>>>>>> 5bd2abb0082af1b93601fe7a3a8459dfc9fc10c9
=======


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
        inv_cantidad_total,
        imp_estatus,
        DOJO_doj_id 
          FROM  IMPLEMENTO IMP, INVENTARIO INV, DOJO DOJ
    WHERE imp.imp_estatus != 'Inactivo'
    AND   imp.imp_id = INV.IMPLEMENTO_imp_id
    AND      INV.DOJO_doj_id= DOJ.doj_id
  END

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
>>>>>>> 51d6c0785d0a3e8403ffbc0ea13cf2575a1d2c15
