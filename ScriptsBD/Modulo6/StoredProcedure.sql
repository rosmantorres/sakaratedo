------------------
-- Agregaciones --
------------------
/* Agrega un telefono de una Persona Y retorna el nuevo ID. */
CREATE PROCEDURE Agregar_Telefono
	@persona_id INTEGER,
	@telefono_numero VARCHAR (10),
	@telefono_id INTEGER OUTPUT
AS
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

/* Agrega un telefono de una Persona. */
CREATE PROCEDURE Agregar_Email
	@persona_id INTEGER,
	@correo_direccion VARCHAR (100),
	@correo_principal BIT,
	@correo_id INTEGER OUTPUT
AS
BEGIN
	INSERT INTO dbo.EMAIL (
		ema_email,
		ema_principal,
		PERSONA_per_id
	) VALUES (
		@correo_direccion,
		@correo_principal,
		@persona_id
	);
	SELECT @correo_id = SCOPE_IDENTITY();
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

---------------
-- Modificar --
---------------
/* Cambiar el estado de una persona */
CREATE PROCEDURE Cambiar_Estado_Usuario
	@persona_activo BIT,
	@persona_id INTEGER
AS
BEGIN
	UPDATE dbo.PERSONA
	SET
		per_activo = @persona_activo
	WHERE
		per_id = @persona_id
	;
END

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

---------------
-- Consultas --
---------------
/* Consultar todos los datos de una persona. */
CREATE PROCEDURE [dbo].[Consulta_Persona]
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
		per_imagen AS persona_imagen,
		per_id AS persona_id 
	FROM dbo.PERSONA
	WHERE
		per_id = @persona_id
	;
END