
------------------------------------------------------------------------------------------INSERTS-------------------------------------------------------------------------------------------------------------------------------------------------------
insert into implemento (imp_imagen,imp_nombre,imp_tipo,imp_marca,imp_color,imp_talla,imp_estatus,imp_precio,imp_stockmin,imp_descripcion) 
values('~/GUI/Modulo15/Imagenes/guantes.jpg','Guantines Karate-DO','Guantines','Kombate','Azul','S','Activo',4500,5,'Guantines para Karate-DO');
insert into implemento (imp_imagen,imp_nombre,imp_tipo,imp_marca,imp_color,imp_talla,imp_estatus,imp_precio,imp_stockmin,imp_descripcion) 
values('~/GUI/Modulo15/Imagenes/karategi.jpg','Karate Gi Karate-DO','Karate Gi','Adidas','Blanco','S','Activo',3000,5,'Karate Gi para Karate-DO');
insert into implemento (imp_imagen,imp_nombre,imp_tipo,imp_marca,imp_color,imp_talla,imp_estatus,imp_precio,imp_stockmin,imp_descripcion) 
values('~/GUI/Modulo15/Imagenes/espinilleras.jpg', 'Espinilleras Karate-DO','Espinilleras','Adidas','Azul','S','Activo',4500,5,'Espinilleras para Karate-DO');
insert into implemento (imp_imagen,imp_nombre,imp_tipo,imp_marca,imp_color,imp_talla,imp_estatus,imp_precio,imp_stockmin,imp_descripcion) 
values('~/GUI/Modulo15/Imagenes/cinta.jpg', 'Cinta Karate-DO','Cinta','Adidas','Amarillo','M','Activo',1200,10,'Cinta para Karate-DO');
insert into implemento (imp_imagen,imp_nombre,imp_tipo,imp_marca,imp_color,imp_talla,imp_estatus,imp_precio,imp_stockmin,imp_descripcion) 
values('~/GUI/Modulo15/Imagenes/coderas.jpg', 'Coderas Karate-DO','Coderas','Kombate','Rojo','M','Activo',5000,5,'Coderas para Karate-DO');

insert into inventario (inv_cantidad_total,IMPLEMENTO_imp_id,DOJO_doj_id) values (4,1,2);
insert into inventario (inv_cantidad_total,IMPLEMENTO_imp_id,DOJO_doj_id) values (70,2,2);
insert into inventario (inv_cantidad_total,IMPLEMENTO_imp_id,DOJO_doj_id) values (64,3,2);
insert into inventario (inv_cantidad_total,IMPLEMENTO_imp_id,DOJO_doj_id) values (27,4,2);
insert into inventario (inv_cantidad_total,IMPLEMENTO_imp_id,DOJO_doj_id) values (93,5,2);

insert into inventario (inv_cantidad_total,IMPLEMENTO_imp_id,DOJO_doj_id) values (84,1,3);
insert into inventario (inv_cantidad_total,IMPLEMENTO_imp_id,DOJO_doj_id) values (29,2,3);
insert into inventario (inv_cantidad_total,IMPLEMENTO_imp_id,DOJO_doj_id) values (15,3,3);
insert into inventario (inv_cantidad_total,IMPLEMENTO_imp_id,DOJO_doj_id) values (26,4,3);
insert into inventario (inv_cantidad_total,IMPLEMENTO_imp_id,DOJO_doj_id) values (7,5,3);

insert into inventario (inv_cantidad_total,IMPLEMENTO_imp_id,DOJO_doj_id) values (18,1,4);
insert into inventario (inv_cantidad_total,IMPLEMENTO_imp_id,DOJO_doj_id) values (46,2,4);
insert into inventario (inv_cantidad_total,IMPLEMENTO_imp_id,DOJO_doj_id) values (33,3,4);
insert into inventario (inv_cantidad_total,IMPLEMENTO_imp_id,DOJO_doj_id) values (11,4,4);
insert into inventario (inv_cantidad_total,IMPLEMENTO_imp_id,DOJO_doj_id) values (17,5,4);

insert into inventario (inv_cantidad_total,IMPLEMENTO_imp_id,DOJO_doj_id) values (12,1,5);
insert into inventario (inv_cantidad_total,IMPLEMENTO_imp_id,DOJO_doj_id) values (49,2,5);
insert into inventario (inv_cantidad_total,IMPLEMENTO_imp_id,DOJO_doj_id) values (22,3,5);
insert into inventario (inv_cantidad_total,IMPLEMENTO_imp_id,DOJO_doj_id) values (13,4,5);
insert into inventario (inv_cantidad_total,IMPLEMENTO_imp_id,DOJO_doj_id) values (4,5,5);