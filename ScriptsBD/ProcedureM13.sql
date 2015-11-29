--PROCEDURE LISTAR MOROSOS--------------------


	CREATE PROCEDURE M13_ListarMorosos
	AS
	BEGIN
	 select p.per_nombre,p.per_apellido,p.per_num_doc_id,d.doj_nombre, DATEDIFF(MONTH,m.mat_fecha_ultimo_pago,GETDATE()) as meseMoroso, ((DATEDIFF(MONTH,m.mat_fecha_ultimo_pago,GETDATE()))*(select MAX(h.his_mat_monto) from HISTORIAL_MATRICULA h)) as monto
FROM PERSONA p, MATRICULA m, DOJO d
where  d.doj_id=m.DOJO_doj_id and p.per_id= m.PERSONA_per_id 
GROUP BY  p.per_nombre,p.per_apellido,p.per_num_doc_id,m.mat_fecha_ultimo_pago,d.doj_nombre
HAVING DATEDIFF(MONTH,m.mat_fecha_ultimo_pago,GETDATE())>=2

END
GO




	


