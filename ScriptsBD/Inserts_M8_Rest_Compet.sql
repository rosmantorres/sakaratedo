-- =========================================================================--
-- Inserts RESTRICCION_COMPETENCIA                                          --
-- =========================================================================--
INSERT INTO [dbo].[RESTRICCION_COMPETENCIA] ([res_com_desc], [res_com_edad_min], [res_com_edad_max], [res_com_sexo], [res_com_modalidad]) VALUES
('Rest. Competencia de 12 a 17 años todas las cintas unisex Kata',12,17,'B','Todas');

INSERT INTO [dbo].[RESTRICCION_COMPETENCIA] ([res_com_desc], [res_com_edad_min], [res_com_edad_max], [res_com_sexo], [res_com_modalidad]) VALUES
('Rest. Competencia de 6 a 11 años todas las cintas unisex Kata',6,11,'B','kata');

INSERT INTO [dbo].[RESTRICCION_COMPETENCIA] ([res_com_desc], [res_com_edad_min], [res_com_edad_max], [res_com_sexo], [res_com_modalidad]) VALUES
('Rest. Competencia de 18 a 25 años todas las cintas unisex Kata',18,25,'B','Todas');
-- =========================================================================--
-- Inserts COMP_REST_COMP                                                   --
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
-- Inserts RC_CINTA                                                  --
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
