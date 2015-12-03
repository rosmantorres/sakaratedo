 select p.per_nombre, p.per_apellido, DATEDIFF(yy,p.per_fecha_nacimiento,GETDATE()) AS edad, p.per_peso, p.per_estatura
          from PERSONA p, HISTORIAL_CINTAS hc, CINTA c 
          where p.per_id=hc.PERSONA_per_id and c.cin_id=hc.CINTA_cin_id; 