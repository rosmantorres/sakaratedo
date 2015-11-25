-------------------------------------------------------INSERT_M14-------------------------------------------------------


INSERT INTO TIPO_PLANILLA (tip_nombre,tip_descripcion) values ('RETIRO','Este tipo de planilla se puede solicitar cuando se hacen retiros por compentencias');
INSERT INTO TIPO_PLANILLA (tip_nombre,tip_descripcion) values ('AUSENCIA','Este tipo de planilla se puede solicitar cuando se hacen ausencias temporales,prolongados, por campeonato y entrenamiento');
INSERT INTO TIPO_PLANILLA (tip_nombre,tip_descripcion) values ('ASISTENCIA','Este tipo de planilla se puede solicitar cuando se va a faltar a una competencia');
INSERT INTO TIPO_PLANILLA (tip_nombre,tip_descripcion) values ('PARTICIPACION','Este tipo de planilla se puede solicitar cuando se requiere de participacion en arbitraje');
INSERT INTO TIPO_PLANILLA (tip_nombre,tip_descripcion) values ('ESPECIAL','Este tipo de planilla se puede solicitar cuando requiere otros permisos especiales');


INSERT INTO PLANILLA (pla_nombre,pla_status,TIPO_PLANILLA_tip_id) values ('RETIRO COMPETENCIA',1,1);
INSERT INTO PLANILLA (pla_nombre,pla_status,TIPO_PLANILLA_tip_id) values ('AUSENCIA TEMPORAL',1,2);
INSERT INTO PLANILLA (pla_nombre,pla_status,TIPO_PLANILLA_tip_id) values ('RETIRO PROLONGADO',0,2);
INSERT INTO PLANILLA (pla_nombre,pla_status,TIPO_PLANILLA_tip_id) values ('RETIRO CAMPEONATO',0,2);
INSERT INTO PLANILLA (pla_nombre,pla_status,TIPO_PLANILLA_tip_id) values ('RETIRO ENTRENAMIENTO',1,2);
INSERT INTO PLANILLA (pla_nombre,pla_status,TIPO_PLANILLA_tip_id) values ('ASISTENCIA COMPETENCIA',1,3);
INSERT INTO PLANILLA (pla_nombre,pla_status,TIPO_PLANILLA_tip_id) values ('PAGO INSCRIPCION',1,4);
INSERT INTO PLANILLA (pla_nombre,pla_status,TIPO_PLANILLA_tip_id) values ('PARTICIPACION',0,4);



INSERT INTO DATO (dat_nombre,dat_abreviatura) values ('ATLETA','ATL');
INSERT INTO DATO (dat_nombre,dat_abreviatura) values ('COMPETENCIA','COM');
INSERT INTO DATO (dat_nombre,dat_abreviatura) values ('DOJO','DOJ');
INSERT INTO DATO (dat_nombre,dat_abreviatura) values ('EVENTO','EVE');



INSERT INTO PLA_DAT (DATO_dat_id,PLANILLA_pla_id) values (1,1);
INSERT INTO PLA_DAT (DATO_dat_id,PLANILLA_pla_id) values (1,2);
INSERT INTO PLA_DAT (DATO_dat_id,PLANILLA_pla_id) values (1,3);
INSERT INTO PLA_DAT (DATO_dat_id,PLANILLA_pla_id) values (2,1);
INSERT INTO PLA_DAT (DATO_dat_id,PLANILLA_pla_id) values (3,1);
INSERT INTO PLA_DAT (DATO_dat_id,PLANILLA_pla_id) values (4,3);
INSERT INTO PLA_DAT (DATO_dat_id,PLANILLA_pla_id) values (2,4);







    