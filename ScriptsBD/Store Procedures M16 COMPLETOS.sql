
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
@per_id [int]
AS
 BEGIN
    SELECT	M.mat_identificador AS idIdentificadorMatricla, 
	        M.mat_fecha_creacion AS fechaInicio,
		    M.mat_fecha_ultimo_pago AS fechaTope
	 		
	FROM  	MATRICULA M, PERSONA P
	WHERE  M.PERSONA_per_id= @per_id;
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