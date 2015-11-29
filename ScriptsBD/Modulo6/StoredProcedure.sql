------------------
-- Agregaciones --
------------------
/* Agrega un telefono de una Persona Y retorna el nuevo ID. */
CREATE PROCEDURE Agregar_Telefono
	@persona_id INTEGER,
	@telefono_numero VARCHAR (11),
	@telefono_id INTEGER OUTPUT
AS
BEGIN
	SELECT @telefono_id = tel_id
	FROM dbo.TELEFONO
	WHERE
			PERSONA_per_id = @persona_id
			AND tel_numero = @telefono_numero;
	IF @telefono_id IS NULL
	BEGIN
		INSERT INTO dbo.TELEFONO (
			tel_numero,
			PERSONA_per_id
		)
		VALUES (
			@telefono_numero,
			@persona_id
		);
		SELECT @telefono_id = SCOPE_IDENTITY();
	END
END

/* Agrega un telefono de una Persona. */
CREATE PROCEDURE Agregar_Email
	@persona_id INTEGER,
	@correo_direccion VARCHAR (100),
	@correo_id INTEGER OUTPUT
AS
BEGIN
	SELECT @correo_id = ema_id
	FROM dbo.EMAIL
	WHERE
		PERSONA_per_id = @persona_id
		AND ema_email = @correo_direccion;
	
	IF @correo_id IS NULL
	BEGIN

		INSERT INTO dbo.EMAIL (
			ema_email,
			ema_principal,
			PERSONA_per_id
		) VALUES (
			@correo_direccion,
			0,
			@persona_id
		);
		SELECT @correo_id = SCOPE_IDENTITY();
	END
END

/* Agrega una nueva persona. */
CREATE PROCEDURE Agregar_Persona
	@persona_tipo_doc_id VARCHAR (9),
    @persona_num_doc_id NUMERIC (28),
    @persona_nombre VARCHAR (256),
    @persona_apellido VARCHAR (256),
    @persona_nacionalidad VARCHAR (10),
    @persona_alergias TEXT,
    @persona_direccion TEXT,
    @persona_sexo CHAR (1),
    @persona_tipo_sangre VARCHAR (3),
    @persona_fecha_nacimiento DATETIME,
    @persona_peso FLOAT,
    @persona_estatura FLOAT,
	@persona_id INTEGER OUTPUT
AS
BEGIN
	INSERT INTO dbo.PERSONA (
		per_tipo_doc_id,
		per_num_doc_id,
		per_nombre,
		per_apellido ,
		per_nacionalidad,
		per_alergias,
		per_direccion,
		per_sexo,
		per_tipo_sangre,
		per_fecha_nacimiento,
		per_activo,
		per_peso,
		per_estatura
	) 
	VALUES (
		@persona_tipo_doc_id,
		@persona_num_doc_id,
		@persona_nombre,
		@persona_apellido,
		@persona_nacionalidad,
		@persona_alergias,
		@persona_direccion,
		@persona_sexo,
		@persona_tipo_sangre,
		@persona_fecha_nacimiento,
		0,
		@persona_peso,
		@persona_estatura
	);
	SELECT @persona_id = SCOPE_IDENTITY();
END

/* Agrega una nueva persona COntacto . */
CREATE PROCEDURE Agregar_Contacto
    @persona_nombre VARCHAR (256),
    @persona_apellido VARCHAR (256),
    @persona_sexo CHAR (1),
	@persona_id INTEGER OUTPUT
AS
BEGIN
	INSERT INTO dbo.PERSONA (
		per_nombre,
		per_apellido ,
		per_sexo,
		per_activo
	) 
	VALUES (
		@persona_nombre,
		@persona_apellido,
		@persona_sexo,
		0
	);
	SELECT @persona_id = SCOPE_IDENTITY();
END

/* Agrega una nueva persona Representante. */
CREATE PROCEDURE Agregar_Representante
	@persona_tipo_doc_id VARCHAR (9),
    @persona_num_doc_id NUMERIC (28),
    @persona_nombre VARCHAR (256),
    @persona_apellido VARCHAR (256),
    @persona_nacionalidad VARCHAR (10),
    @persona_sexo CHAR (1),
    @persona_fecha_nacimiento DATETIME,
	@persona_id INTEGER OUTPUT
AS
BEGIN
	INSERT INTO dbo.PERSONA (
		per_tipo_doc_id,
		per_num_doc_id,
		per_nombre,
		per_apellido ,
		per_nacionalidad,
		per_sexo,
		per_fecha_nacimiento,
		per_activo
	) 
	VALUES (
		@persona_tipo_doc_id,
		@persona_num_doc_id,
		@persona_nombre,
		@persona_apellido,
		@persona_nacionalidad,
		@persona_sexo,
		@persona_fecha_nacimiento,
		0
	);
	SELECT @persona_id = SCOPE_IDENTITY();
END


/* Agrega una nueava matricula */
CREATE PROCEDURE Agregar_Matricula
	@matricula_identificador VARCHAR (50),
	@dojo_id INTEGER,
	@persona_id INTEGER,
	@matricula_id INTEGER OUTPUT
AS
BEGIN
	INSERT INTO dbo.PERSONA (
		mat_identificador,
		mat_fecha_creacion,
		mat_activa,
		mat_fecha_ultimo_pago,
		PERSONA_per_id,
		DOJO_doj_id
	) VALUES (
		@matricula_identificador,
		GETDATE(),
		1,
		GETDATE(),
		@persona_id,
		@dojo_id
	);
	SELECT @matricula_id = SCOPE_IDENTITY()
END

/* Agrega un usuario a persona. */
CREATE PROCEDURE Agregar_Usuario
	@persona_nombre_usuario VARCHAR (25),
	@persona_clave VARCHAR (64),
	@persona_id INTEGER
AS
BEGIN
	UPDATE dbo.PERSONA
	SET
		per_nombre_usuario = @persona_nombre_usuario,
		per_clave = @persona_clave,
		per_activo = 1
	WHERE
		per_id = @persona_id
	;
END

/*Agrega una nueva solicitud*/
CREATE PROCEDURE Agregar_Solicitud
	@id_persona INTEGER,
	@id_dojo INTEGER
AS
BEGIN
	INSERT INTO dbo.SOLICITUD_INSCRIPCION(
		sol_inc_fecha_creacion,
		sol_inc_fecha_actualizacion, 
		sol_inc_estado, 
		PERSONA_per_id, 
		DOJO_doj_id) 
	VALUES (
		GETDATE(), 
		GETDATE(),
		'PENDIENTE', 
		@id_persona, 
		@id_dojo);	
END


/*Setea el contacto de emergencia de una persona*/
ALTER PROCEDURE Agregar_Relacion
	@relacion_tipo varchar(15),
	@persona_id INTEGER,
	@id_persona_relacion INTEGER
AS
BEGIN
	IF NOT EXISTS (SELECT rel_tipo FROM dbo.RELACION WHERE PERSONA_per_id = @persona_id AND  PERSONA_per_id1 = @id_persona_Relacion)
	BEGIN
		INSERT INTO dbo.RELACION(
			rel_tipo,
			PERSONA_per_id, 
			PERSONA_per_id1
		) VALUES (
			@relacion_tipo, 
			@persona_id,
			@id_persona_Relacion
		)
	END
END

------------
-- Listar --
------------

/* Lista los Telefonos de una Persona */
CREATE PROCEDURE Listar_Telefonos
	@persona_id INTEGER
AS
BEGIN
	SELECT
		tel_id AS telefono_id,
		tel_numero AS telefono_numero
	FROM
		dbo.TELEFONO
	WHERE
		PERSONA_per_id = @persona_id
	;
END

/* Lista los correos de una persona */
CREATE PROCEDURE Listar_Correos
	@persona_id INTEGER
AS
BEGIN
	SELECT
		ema_id AS correo_id,
		ema_email AS correo_direccion,
		ema_principal AS correo_principal
	FROM
		dbo.EMAIL
	WHERE
		PERSONA_per_id = @persona_id
	;
END

/* Lista los ID de los Representados de una Persona */
CREATE PROCEDURE Listar_Representados
	@persona_id INTEGER
AS
BEGIN
	SELECT
		PERSONA_per_id1 AS persona_id
	FROM
		dbo.RELACION
	WHERE
		PERSONA_per_id = @persona_id
	;
END

---------------
-- Modificar --
---------------
/* Cambiar la imagen del usuario */
CREATE PROCEDURE Cambiar_Image_Usuario
	@persona_imagen TEXT,
	@persona_id INTEGER
AS
BEGIN
	UPDATE dbo.PERSONA
	SET
		per_imagen = @persona_imagen
	WHERE
		per_id = @persona_id
	;
END

/* Cambiar el status de la solicitud */
CREATE PROCEDURE Modificar_Solicitud
	@id_solicitud INTEGER,
	@estado_solicitud varchar(30)
AS
BEGIN
	UPDATE dbo.SOLICITUD_INSCRIPCION
	SET sol_inc_estado = @estado_solicitud, sol_inc_fecha_actualizacion = GETDATE()
	WHERE sol_inc_id = @id_solicitud
	;
END

/* Cambiar los datos de una persona*/
CREATE PROCEDURE Modificar_Persona
    @persona_id INTEGER,
	@persona_tipo_doc_id VARCHAR (9),
    @persona_num_doc_id NUMERIC (28),
    @persona_nombre VARCHAR (256),
    @persona_apellido VARCHAR (256),
    @persona_nacionalidad VARCHAR (10),
    @persona_alergias TEXT,
    @persona_direccion TEXT,
    @persona_sexo CHAR (1),
    @persona_tipo_sangre VARCHAR (3),
    @persona_fecha_nacimiento DATETIME,
    @persona_peso FLOAT,
    @persona_estatura FLOAT,
	@id_usuario INTEGER
AS
BEGIN
    UPDATE dbo.PERSONA
    SET per_tipo_doc_id = @persona_tipo_doc_id,
        per_num_doc_id = @persona_num_doc_id,
        per_nombre = @persona_nombre,
        per_apellido = @persona_apellido,
        per_nacionalidad = @persona_nacionalidad,
        per_alergias = @persona_alergias,
        per_direccion = @persona_direccion,
        per_sexo = @persona_sexo,
        per_tipo_sangre = @persona_tipo_sangre,
        per_fecha_nacimiento = @persona_fecha_nacimiento,
        per_peso = @persona_peso,
        per_estatura = @persona_estatura
    WHERE per_id = @persona_id
    ;
END


/* Cambiar los datos de una persona*/
CREATE PROCEDURE Modificar_Persona_Contacto
    @persona_nombre VARCHAR (256),
    @persona_apellido VARCHAR (256),
    @persona_sexo CHAR (1),
	@persona_id INTEGER
AS
BEGIN
    UPDATE dbo.PERSONA
    SET per_nombre = @persona_nombre,
        per_apellido = @persona_apellido,
        per_sexo = @persona_sexo
    WHERE per_id = @persona_id
    ;
END

/* Modifica la informacion de un telefono */
CREATE PROCEDURE Modificar_Telefono
	@telefono_numero VARCHAR (11),
	@telefono_id INTEGER
AS
BEGIN
	IF @telefono_numero <> (SELECT tel_numero FROM dbo.TELEFONO WHERE tel_id = @telefono_id)
	BEGIN
		UPDATE dbo.TELEFONO
		SET tel_numero = @telefono_numero
		WHERE tel_id = @telefono_id;
	END
END

/* Modifica la informacion de un correo */
CREATE PROCEDURE Modificar_Correo
	@correo_direccion VARCHAR (100),
	@correo_id INTEGER
AS
BEGIN
	IF @correo_direccion <> (SELECT ema_email FROM dbo.EMAIL WHERE ema_id = @correo_id )
	BEGIN
		UPDATE dbo.EMAIL
		SET
			ema_email = @correo_direccion
			WHERE ema_id = @correo_id;
	END
END

---------------
-- Consultas --
---------------
/* Consultar todos los datos de una persona. */
CREATE PROCEDURE dbo.Consulta_Persona
	@persona_id INTEGER OUTPUT
AS
BEGIN
	SELECT
		per_tipo_doc_id AS persona_tipo_doc_id,
		per_num_doc_id AS persona_num_doc_id,
		per_nombre AS persona_nombre,
		per_apellido AS persona_apellido,
		per_nacionalidad AS persona_nacionalidad,
		per_alergias AS persona_alergias,
		per_direccion AS persona_direccion,
		per_sexo AS persona_sexo,
		per_tipo_sangre AS persona_tipo_sangre,
		per_fecha_nacimiento AS persona_fecha_nacimiento,
		per_peso AS persona_peso,
		per_estatura AS persona_estatura,
		per_id AS persona_id 
	FROM dbo.PERSONA
	WHERE
		per_id = @persona_id
	;
END

/* Consultar el id de la persona de contacto. */
CREATE PROCEDURE dbo.Contacto_de_Persona
	@id_persona_relacion INTEGER OUTPUT,
	@persona_id INTEGER
AS
BEGIN
	SELECT @id_persona_relacion = PERSONA_per_id1
	FROM dbo.RELACION
	WHERE PERSONA_per_id = @persona_id AND rel_tipo = 'CONTACTO';
END


-------------
-- ENL/DIS --
-------------
/* Colocal un correo como el principal. */
CREATE PROCEDURE dbo.correo_principal
	@persona_id INTEGER,
	@correo_id INTEGER
AS
BEGIN
	UPDATE dbo.EMAIL
	SET ema_principal = 0
	WHERE PERSONA_per_id = @persona_id;
	UPDATE dbo.EMAIL
	SET ema_principal = 1
	WHERE ema_id = @correo_id;
END


/* Activar a ua persna */
CREATE PROCEDURE dbo.activar_persona
	@persona_id INTEGER
AS
BEGIN
	UPDATE dbo.PERSONA
	SET per_activo = 1
	WHERE per_id = @persona_id;
END

/* Activar a ua persna */
CREATE PROCEDURE dbo.desactivar_persona
	@persona_id INTEGER
AS
BEGIN
	UPDATE dbo.PERSONA
	SET per_activo = 0
	WHERE per_id = @persona_id;
END