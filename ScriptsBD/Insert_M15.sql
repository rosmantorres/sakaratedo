-----------------SEQUENCES---------------------------
CREATE SEQUENCE IMPLEMENTO_SEQ 
    START WITH 1
    INCREMENT BY 1 ;
GO

CREATE SEQUENCE INVENTARIO_SEQ 
    START WITH 1
    INCREMENT BY 1 ;
GO

------------------------------------------------------------------------------------------INSERTS-------------------------------------------------------------------------------------------------------------------------------------------------------
insert into implemento (imp_id,imp_imagen,imp_nombre,imp_tipo,imp_marca,imp_color,imp_talla,imp_estatus,imp_precio,imp_stockmin,imp_descripcion) 
values(NEXT VALUE FOR IMPLEMENTO_SEQ,'~/GUI/Modulo15/Imagenes/guantes.jpg','Guantines Karate-DO','Guantines','Kombate','Azul','S','Activo',4500,5,'Guantines para Karate-DO');
insert into implemento (imp_id,imp_imagen,imp_nombre,imp_tipo,imp_marca,imp_color,imp_talla,imp_estatus,imp_precio,imp_stockmin,imp_descripcion) 
values(NEXT VALUE FOR IMPLEMENTO_SEQ,'~/GUI/Modulo15/Imagenes/karategi.jpg','Karate Gi Karate-DO','Karate Gi','Adidas','Blanco','S','Activo',3000,5,'Karate Gi para Karate-DO');
insert into implemento (imp_id,imp_imagen,imp_nombre,imp_tipo,imp_marca,imp_color,imp_talla,imp_estatus,imp_precio,imp_stockmin,imp_descripcion) 
values(NEXT VALUE FOR IMPLEMENTO_SEQ,'~/GUI/Modulo15/Imagenes/espinilleras.jpg', 'Espinilleras Karate-DO','Espinilleras','Adidas','Azul','S','Activo',4500,5,'Espinilleras para Karate-DO');
insert into implemento (imp_id,imp_imagen,imp_nombre,imp_tipo,imp_marca,imp_color,imp_talla,imp_estatus,imp_precio,imp_stockmin,imp_descripcion) 
values(NEXT VALUE FOR IMPLEMENTO_SEQ,'~/GUI/Modulo15/Imagenes/cinta.jpg', 'Cinta Karate-DO','Cinta','Adidas','Amarillo','M','Activo',1200,10,'Cinta para Karate-DO');
insert into implemento (imp_id,imp_imagen,imp_nombre,imp_tipo,imp_marca,imp_color,imp_talla,imp_estatus,imp_precio,imp_stockmin,imp_descripcion) 
values(NEXT VALUE FOR IMPLEMENTO_SEQ,'~/GUI/Modulo15/Imagenes/coderas.jpg', 'Coderas Karate-DO','Coderas','Kombate','Rojo','M','Activo',5000,5,'Coderas para Karate-DO');

insert into inventario (inv_id,inv_cantidad_total,IMPLEMENTO_imp_id,DOJO_doj_id) values (NEXT VALUE FOR INVENTARIO_SEQ,4,1,2);
insert into inventario (inv_id,inv_cantidad_total,IMPLEMENTO_imp_id,DOJO_doj_id) values (NEXT VALUE FOR INVENTARIO_SEQ,70,2,2);
insert into inventario (inv_id,inv_cantidad_total,IMPLEMENTO_imp_id,DOJO_doj_id) values (NEXT VALUE FOR INVENTARIO_SEQ,64,3,2);
insert into inventario (inv_id,inv_cantidad_total,IMPLEMENTO_imp_id,DOJO_doj_id) values (NEXT VALUE FOR INVENTARIO_SEQ,27,4,2);
insert into inventario (inv_id,inv_cantidad_total,IMPLEMENTO_imp_id,DOJO_doj_id) values (NEXT VALUE FOR INVENTARIO_SEQ,93,5,2);

insert into inventario (inv_id,inv_cantidad_total,IMPLEMENTO_imp_id,DOJO_doj_id) values (NEXT VALUE FOR INVENTARIO_SEQ,84,1,3);
insert into inventario (inv_id,inv_cantidad_total,IMPLEMENTO_imp_id,DOJO_doj_id) values (NEXT VALUE FOR INVENTARIO_SEQ,29,2,3);
insert into inventario (inv_id,inv_cantidad_total,IMPLEMENTO_imp_id,DOJO_doj_id) values (NEXT VALUE FOR INVENTARIO_SEQ,15,3,3);
insert into inventario (inv_id,inv_cantidad_total,IMPLEMENTO_imp_id,DOJO_doj_id) values (NEXT VALUE FOR INVENTARIO_SEQ,26,4,3);
insert into inventario (inv_id,inv_cantidad_total,IMPLEMENTO_imp_id,DOJO_doj_id) values (NEXT VALUE FOR INVENTARIO_SEQ,7,5,3);

insert into inventario (inv_id,inv_cantidad_total,IMPLEMENTO_imp_id,DOJO_doj_id) values (NEXT VALUE FOR INVENTARIO_SEQ,18,1,4);
insert into inventario (inv_id,inv_cantidad_total,IMPLEMENTO_imp_id,DOJO_doj_id) values (NEXT VALUE FOR INVENTARIO_SEQ,46,2,4);
insert into inventario (inv_id,inv_cantidad_total,IMPLEMENTO_imp_id,DOJO_doj_id) values (NEXT VALUE FOR INVENTARIO_SEQ,33,3,4);
insert into inventario (inv_id,inv_cantidad_total,IMPLEMENTO_imp_id,DOJO_doj_id) values (NEXT VALUE FOR INVENTARIO_SEQ,11,4,4);
insert into inventario (inv_id,inv_cantidad_total,IMPLEMENTO_imp_id,DOJO_doj_id) values (NEXT VALUE FOR INVENTARIO_SEQ,17,5,4);

insert into inventario (inv_id,inv_cantidad_total,IMPLEMENTO_imp_id,DOJO_doj_id) values (NEXT VALUE FOR INVENTARIO_SEQ,12,1,5);
insert into inventario (inv_id,inv_cantidad_total,IMPLEMENTO_imp_id,DOJO_doj_id) values (NEXT VALUE FOR INVENTARIO_SEQ,49,2,5);
insert into inventario (inv_id,inv_cantidad_total,IMPLEMENTO_imp_id,DOJO_doj_id) values (NEXT VALUE FOR INVENTARIO_SEQ,22,3,5);
insert into inventario (inv_id,inv_cantidad_total,IMPLEMENTO_imp_id,DOJO_doj_id) values (NEXT VALUE FOR INVENTARIO_SEQ,13,4,5);
insert into inventario (inv_id,inv_cantidad_total,IMPLEMENTO_imp_id,DOJO_doj_id) values (NEXT VALUE FOR INVENTARIO_SEQ,4,5,5);