----------------------------------STORED PROCEDURES M1-------------------------------------

------------------PROCEDURE CONSULTA NOMBRE DE USUARIO Y CONTRASEÑA ------------
CREATE procedure M1_ConsultarNombreUsuarioContrasena
	@nombre_usuario [varchar](25)
as
	begin
		select pers.per_id as id_usuario, pers.per_nombre_usuario as nombre_usuario, pers.per_clave as contrasena
		from PERSONA pers
		where pers.per_nombre_usuario = @nombre_usuario
	end;
	go

------------------PROCEDURE CONSULTA ROLES DEL SISTEMA --------------------
CREATE procedure M1_ConsultarRolesSistema
as
	begin
		select rol_id as id_rol, rol_nombre as nombre, rol_descripcion as descripcion
		from Rol 
	end;
	go

------------------PROCEDURE CONSULTA ROLES DE USUARIO ------------------
CREATE procedure M1_ConsultarRolesUsuario
	@nombre_usuario [varchar](25)
as
	begin
		select roles.rol_id as id_rol, roles.rol_nombre as nombre,perol.per_rol_fecha as fecha_creacion
		from ROL roles , PERSONA pers, PERSONA_ROL perol
		where pers.per_id = perol.PERSONA_per_id AND perol.ROL_rol_id = roles.rol_id AND pers.per_nombre_usuario = @nombre_usuario
	end;
	go
	

------------------PROCEDURE RESTABLECER CONTRASENA ------------------
CREATE procedure M1_RestablecerContrasena
	@id_usuario [int],
	@contrasena [varchar](64)
as
	begin
		UPDATE PERSONA 
		SET per_clave = @contrasena
		WHERE per_id = @id_usuario
	end;
	go

-----------------PROCEDURE VALIDAR CORREO--------------------------
CREATE procedure M1_ValidarCorreo
@correo_usuario [varchar](25)
as
	begin
		select  PERSONA_per_id  as correo_usuario
		from EMAIL
		where ema_email= @correo_usuario and ema_principal=1
	end;
	go
