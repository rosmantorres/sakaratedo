/* INSERTS DEL MODULO 8*/
/*--------------------------------Restricciones de cambio de cinta--------------------------------M8---------------------------*/
/*-----------------------------------------------------------------------------------------------------------------------------*/
    INSERT INTO dbo.RESTRICCION_CINTA (
    res_cin_id,
    res_cin_descripcion,
    res_cin_tiemp_min,
    res_cin_punt_min,
    res_cin_horas_docent,
    CINTA_cin_id
    ) 
    VALUES (1,'BLANCA A AMARILLA',3,0,0,2);
    
    INSERT INTO dbo.RESTRICCION_CINTA (
    res_cin_id,
    res_cin_descripcion,
    res_cin_tiemp_min,
    res_cin_punt_min,
    res_cin_horas_docent,
    CINTA_cin_id
    ) 
    VALUES (2,'AMARILLA A NARANJA',5,8,0,3);
    
    INSERT INTO dbo.RESTRICCION_CINTA (
    res_cin_id,
    res_cin_descripcion,
    res_cin_tiemp_min,
    res_cin_punt_min,
    res_cin_horas_docent,
    CINTA_cin_id
    ) 
    VALUES (3,'NARANJA A VERDE',7,20,0,4);
    
    INSERT INTO dbo.RESTRICCION_CINTA (
    res_cin_id,
    res_cin_descripcion,
    res_cin_tiemp_min,
    res_cin_punt_min,
    res_cin_horas_docent,
    CINTA_cin_id
    ) 
    VALUES (4,'VERDE A AZUL',10,25,2,5);
    
    INSERT INTO dbo.RESTRICCION_CINTA (
    res_cin_id,
    res_cin_descripcion,
    res_cin_tiemp_min,
    res_cin_punt_min,
    res_cin_horas_docent,
    CINTA_cin_id
    ) 
    VALUES (5,'AZUL A MARRON',10,30,4,6);
    
    INSERT INTO dbo.RESTRICCION_CINTA (
    res_cin_id,
    res_cin_descripcion,
    res_cin_tiemp_min,
    res_cin_punt_min,
    res_cin_horas_docent,
    CINTA_cin_id
    ) 
    VALUES (6,'MARRON A MARRON',12,40,7,7);
    
    INSERT INTO dbo.RESTRICCION_CINTA (
    res_cin_id,
    res_cin_descripcion,
    res_cin_tiemp_min,
    res_cin_punt_min,
    res_cin_horas_docent,
    CINTA_cin_id
    ) 
    VALUES (7,'MARRON A NEGRA',12,50,9,8);

    



-- =========================================================================--
-- Inserts RESTRICCION_COMPETENCIA                           M8               --
-- =========================================================================--
INSERT INTO [dbo].[RESTRICCION_COMPETENCIA] ([res_com_desc], [res_com_edad_min], [res_com_edad_max], [res_com_sexo], [res_com_modalidad]) VALUES
('Rest. Competencia de 12 a 17 años todas las cintas unisex Kata',12,17,'B','Todas');

INSERT INTO [dbo].[RESTRICCION_COMPETENCIA] ([res_com_desc], [res_com_edad_min], [res_com_edad_max], [res_com_sexo], [res_com_modalidad]) VALUES
('Rest. Competencia de 6 a 11 años todas las cintas unisex Kata',6,11,'B','kata');

INSERT INTO [dbo].[RESTRICCION_COMPETENCIA] ([res_com_desc], [res_com_edad_min], [res_com_edad_max], [res_com_sexo], [res_com_modalidad]) VALUES
('Rest. Competencia de 18 a 25 años todas las cintas unisex Kata',18,25,'B','Todas');
-- =========================================================================--
-- Inserts COMP_REST_COMP                                    M8               --
-- =========================================================================--
INSERT INTO [dbo].[COMP_REST_COMP] (comp_rest_comp_id,RESTRICCION_COMPETENCIA_res_com_id,COMPETENCIA_comp_id) VALUES
(1,1);

INSERT INTO [dbo].[COMP_REST_COMP] (comp_rest_comp_id,RESTRICCION_COMPETENCIA_res_com_id,COMPETENCIA_comp_id) VALUES
(1,2);

INSERT INTO [dbo].[COMP_REST_COMP] (comp_rest_comp_id,RESTRICCION_COMPETENCIA_res_com_id,COMPETENCIA_comp_id) VALUES
(1,3);

INSERT INTO [dbo].[COMP_REST_COMP] (comp_rest_comp_id,RESTRICCION_COMPETENCIA_res_com_id,COMPETENCIA_comp_id) VALUES
(1,4);

INSERT INTO [dbo].[COMP_REST_COMP] (comp_rest_comp_id,RESTRICCION_COMPETENCIA_res_com_id,COMPETENCIA_comp_id) VALUES
(2,1);

INSERT INTO [dbo].[COMP_REST_COMP] (comp_rest_comp_id,RESTRICCION_COMPETENCIA_res_com_id,COMPETENCIA_comp_id) VALUES
(2,2);

-- =========================================================================--
-- Inserts RC_CINTA                                       M8           --
-- =========================================================================--
INSERT INTO [dbo].[RC_CINTA] (comp_rest_comp_id,RESTRICCION_COMPETENCIA_res_com_id,CINTA_cin_id) VALUES
(1,1);

INSERT INTO [dbo].[RC_CINTA] (comp_rest_comp_id,RESTRICCION_COMPETENCIA_res_com_id,CINTA_cin_id) VALUES
(1,2);

INSERT INTO [dbo].[RC_CINTA] (comp_rest_comp_id,RESTRICCION_COMPETENCIA_res_com_id,CINTA_cin_id) VALUES
(1,3);

INSERT INTO [dbo].[RC_CINTA] (comp_rest_comp_id,RESTRICCION_COMPETENCIA_res_com_id,CINTA_cin_id) VALUES
(1,4);

INSERT INTO [dbo].[RC_CINTA] (comp_rest_comp_id,RESTRICCION_COMPETENCIA_res_com_id,CINTA_cin_id) VALUES
(2,5);

INSERT INTO [dbo].[RC_CINTA] (comp_rest_comp_id,RESTRICCION_COMPETENCIA_res_com_id,CINTA_cin_id) VALUES
(2,6);

INSERT INTO [dbo].[RC_CINTA] (comp_rest_comp_id,RESTRICCION_COMPETENCIA_res_com_id,CINTA_cin_id) VALUES
(2,1);

INSERT INTO [dbo].[RC_CINTA] (comp_rest_comp_id,RESTRICCION_COMPETENCIA_res_com_id,CINTA_cin_id) VALUES
(2,2);


-- =========================================================================--
-- Inserts RESTRICCION_EVENTO  (descripcion,edadMIN,edadMAX,sexo)    M8     --
-- =========================================================================--
insert into RESTRICCION_EVENTO values ('Rest. evento evento1 de 18 a 25 años solo masculino',18,25,'m');
insert into RESTRICCION_EVENTO values ('Rest. evento evento2 de 18 a 20 años solo femenino',18,20,'f');
insert into RESTRICCION_EVENTO values ('Rest. evento evento3 de 20 a 25 años sexo combinado',20,25,'c');
insert into RESTRICCION_EVENTO values ('Rest. evento evento4 de 20 a 25 años sexo combinado',20,25,'c');

-- =========================================================================--
-- Inserts EVENTO_RESTRICCION  (evento id, restriccionEve id)        M8     --
-- =========================================================================--
insert into EVENTO_RESTRICCION values (1,1);
insert into EVENTO_RESTRICCION values (2,3);
insert into EVENTO_RESTRICCION values (3,2);
insert into EVENTO_RESTRICCION values (4,4);

-- =========================================================================--
-- Inserts RH_CINTA   (restriccionEve id, cinta id)                  M8     --
-- =========================================================================--
-- FALTA INSERT DE CINTA PARA COMPLETAR --
insert into RH_CINTA values (1,1);
insert into RH_CINTA values (1,2);
insert into RH_CINTA values (2,2);
insert into RH_CINTA values (2,3);
insert into RH_CINTA values (3,4);
insert into RH_CINTA values (4,5);
insert into RH_CINTA values (4,7);