/* Pendiente con el nombre de la tabla detalle y las foraneas */

/* Eliminar Item */
CREATE PROCEDURE ELIMINAR_ITEM
		@idusuario int,
		@iditem int,
		@tipoitem int
AS
BEGIN
	DECLARE @idcarrito INTEGER;
	SET @idcarrito = (SELECT com_id FROM COMPRA_CARRITO WHERE fk_usu_com = @idusuario AND com_estado = 'CARRITO');

	IF (@tipoitem = 1)
		DELETE FROM DETALLE_COMPRA WHERE fk_carr_det = @idcarrito AND fk_inv_det = @iditem;
	ELSE IF (@tipoitem = 2)
		DELETE FROM DETALLE_COMPRA WHERE fk_carr_det = @idcarrito AND fk_mat_det = @iditem;
	ELSE IF (@tipoitem = 3)
		DELETE FROM DETALLE_COMPRA WHERE fk_carr_det = @idcarrito AND fk_eve_det = @iditem;
	
END
GO;