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

INSERT INTO DISEÑO (dis_contenido,PLANILLA_pla_id) values ('PHA+Jm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgPHN0cm9uZz4mbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwO1BsYW5pbGxhIGRlIEluc2NyaXBjaSZvYWN1dGU7bjwvc3Ryb25nPjwvcD4NCg0KPHA+Jm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICRwZXJfaW1hZ2VuPC9wPg0KDQo8cD4mbmJzcDs8L3A+DQoNCjx0YWJsZSBib3JkZXI9IjEiIGNlbGxwYWRkaW5nPSIxIiBjZWxsc3BhY2luZz0iMSIgc3R5bGU9IndpZHRoOjcwMHB4Ij4NCgk8Y2FwdGlvbj48c3Ryb25nPkRhdG9zIFBlcnNvbmFsZXM8L3N0cm9uZz48L2NhcHRpb24+DQoJPHRib2R5Pg0KCQk8dHI+DQoJCQk8dGQ+PHN0cm9uZz5Ob21icmU8L3N0cm9uZz48L3RkPg0KCQkJPHRkPiRwZXJfbm9tYnJlPC90ZD4NCgkJCTx0ZD48c3Ryb25nPkFwZWxsaWRvPC9zdHJvbmc+PC90ZD4NCgkJCTx0ZD4kcGVyX2FwZWxsaWRvPC90ZD4NCgkJPC90cj4NCgkJPHRyPg0KCQkJPHRkPjxzdHJvbmc+VGlwbyBkZSBEb2N1bWVudG88L3N0cm9uZz48L3RkPg0KCQkJPHRkPiRwZXJfdGlwb19kb2NfaWQ8L3RkPg0KCQkJPHRkPjxzdHJvbmc+RG9jdW1lbnRvIElkZW50aWRhZDwvc3Ryb25nPjwvdGQ+DQoJCQk8dGQ+JHBlcl9udW1fZG9jX2lkPC90ZD4NCgkJPC90cj4NCgkJPHRyPg0KCQkJPHRkPjxzdHJvbmc+TmFjaW9uYWxpZGFkPC9zdHJvbmc+PC90ZD4NCgkJCTx0ZD4kcGVyX25hY2lvbmFsaWRhZDwvdGQ+DQoJCQk8dGQ+PHN0cm9uZz5EaXJlY2NpJm9hY3V0ZTtuPC9zdHJvbmc+PC90ZD4NCgkJCTx0ZD4kcGVyX2RpcmVjY2lvbjwvdGQ+DQoJCTwvdHI+DQoJCTx0cj4NCgkJCTx0ZD48c3Ryb25nPlNleG88L3N0cm9uZz48L3RkPg0KCQkJPHRkPiRwZXJfc2V4bzwvdGQ+DQoJCQk8dGQ+PHN0cm9uZz5GZWNoYSBkZSBOYWNpbWllbnRvPC9zdHJvbmc+PC90ZD4NCgkJCTx0ZD4kcGVyX2ZlY2hhX25hY2ltaWVudG88L3RkPg0KCQk8L3RyPg0KCTwvdGJvZHk+DQo8L3RhYmxlPg0KDQo8dGFibGUgYm9yZGVyPSIxIiBjZWxscGFkZGluZz0iMSIgY2VsbHNwYWNpbmc9IjEiIHN0eWxlPSJ3aWR0aDo3MDBweCI+DQoJPGNhcHRpb24+DQoJPHA+Jm5ic3A7PC9wPg0KDQoJPHA+PHN0cm9uZz5EYXRvcyBkZWwgRG9qbzwvc3Ryb25nPjwvcD4NCgk8L2NhcHRpb24+DQoJPHRib2R5Pg0KCQk8dHI+DQoJCQk8dGQ+PHN0cm9uZz5Ob21icmU8L3N0cm9uZz48L3RkPg0KCQkJPHRkPiRkb2pfbm9tYnJlPC90ZD4NCgkJCTx0ZD48c3Ryb25nPlRlbCZlYWN1dGU7Zm9ubzwvc3Ryb25nPjwvdGQ+DQoJCQk8dGQ+JGRval90ZWxlZm9ubzwvdGQ+DQoJCTwvdHI+DQoJCTx0cj4NCgkJCTx0ZD48c3Ryb25nPlJpZjwvc3Ryb25nPjwvdGQ+DQoJCQk8dGQ+JGRval9yaWY8L3RkPg0KCQkJPHRkPjxzdHJvbmc+RW1haWw8L3N0cm9uZz48L3RkPg0KCQkJPHRkPiRkb2pfZW1haWw8L3RkPg0KCQk8L3RyPg0KCTwvdGJvZHk+DQo8L3RhYmxlPg0KDQo8cD4mbmJzcDs8L3A+DQo=',4);

INSERT INTO SOLICITUD_PLANILLA (sol_pla_fecha_Creacion,sol_pla_fecha_retiro,sol_pla_fecha_reincorporacion,sol_pla_motivo,PLANILLA_pla_id,INSCRIPCION_ins_id ,PERSONA_per_id) values ('01/02/2015','11/02/2015','12/02/2015','ENFERMEDAD',3,1,1);
INSERT INTO SOLICITUD_PLANILLA (sol_pla_fecha_Creacion,sol_pla_fecha_retiro,sol_pla_fecha_reincorporacion,sol_pla_motivo,PLANILLA_pla_id,INSCRIPCION_ins_id ,PERSONA_per_id) values ('23/08/2014','26/08/2014','27/09/2015','VACACIONES',4,2,1);
INSERT INTO SOLICITUD_PLANILLA (sol_pla_fecha_Creacion,sol_pla_fecha_retiro,sol_pla_fecha_reincorporacion,sol_pla_motivo,PLANILLA_pla_id,INSCRIPCION_ins_id ,PERSONA_per_id) values ('21/12/2013','08/01/2014','09/01/2014','FAMILIAR',5,2,2);





    