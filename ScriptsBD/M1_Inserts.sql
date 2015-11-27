--------------------------------Para Obtener los ID de los roles-------

/*
SELECT rol_id from ROL where rol_nombre='Admin Sistema';
SELECT rol_id from ROL where rol_nombre='Admin Organización';
SELECT rol_id from ROL where rol_nombre='Admin Dojo';
SELECT rol_id from ROL where rol_nombre='Entrenador';
SELECT rol_id from ROL where rol_nombre='Atleta';
SELECT rol_id from ROL where rol_nombre='Representante';
*/

--------------------------Inserts de Roles-----------------------------------

INSERT INTO  ROL VALUES ('Admin Sistema','El administrador tiene acceso a todo el sistema sin restricción,con la capacidad de dar seguimiento a todo los procesos.' );
INSERT INTO  ROL VALUES ('Admin Organización','El administrador de la organizacion se encarga de gestionar la organización a la cual esta asociado, actualizando agregando y descartando información correspondiente.');
INSERT INTO  ROL VALUES ('Admin Dojo','El administrador del dojo es el encargado de llevar un seguimiento y tener al día la información relevante con respecto al dojo asociado.');
INSERT INTO  ROL VALUES ('Entrenador','El entrenador lleva un seguimiento de los atletas y los eventos realizados en el dojo.');
INSERT INTO  ROL VALUES ('Atleta','El atleta es la persona en formación que recibe clases en un dojo particular.');
INSERT INTO  ROL VALUES ('Representante','El representante como su nombre lo indica es el encargado del atleta menor, con lo cual puede dar seguimiento a las actividades realizadas por el menor.');

--------------------------Inserts Personas tipo AdminSistema (Magurno, Rosman)------------------------------

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
    per_estatura,
	per_nombre_usuario,
	per_clave,
	per_imagen
) 
VALUES (
    'CEDULA-N',
    12813521,
    'Carlo',
    'Magurno',
    'Venezolano',
    'Mariscos',
    '3da. Av. de Montalban. Res. Maracaibo. Piso 4. Apto. 4b',
    'M',
    'A+',
    '1983-05-21',
    1,
    77,
    1.72,
    'carloadmin',
    '12345',
	'https://media.licdn.com/media/p/1/005/040/3e7/00ea99f.jpg'
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Carlo'),
    '02126627843'
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Carlo'),
    '04125536420'
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Carlo'),
    'sistemaadministrador.generico@ucab.edu.ve',
    1
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Carlo'),
    'sistemaplain_administrador@gmail.com',
    0
);


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
    per_estatura,
	per_nombre_usuario,
	per_clave
) 
VALUES (
    'CEDULA-N',
    15673280,
    'Rosman',
    'Torres',
    'Venezolano',
    'Mariscos',
    '3da. Av. de los Palos Grandes. Res. Juanas. Piso 2. Apto. 2c',
    'M',
    'A+',
    '1990-05-21',
    1,
    77,
    1.72,
    'rosmanadmin',
    '12345'
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Rosman'),
    '02126626345'
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Rosman'),
    '04142156345'
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Rosman'),
    'sistemaadministrador2.generico@ucab.edu.ve',
    1
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Rosman'),
    'sistemaplain_administrador2@gmail.com',
    0
);


----------------------------------Inserts Tabla Persona_Rol----------------------



INSERT INTO dbo.PERSONA_ROL  (
per_rol_fecha,
PERSONA_per_id,
ROL_rol_id
)
VALUES (
GETDATE(),
SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Carlo',
SELECT rol_id from ROL where rol_nombre='Admin Sistema'
);

INSERT INTO dbo.PERSONA_ROL  (
per_rol_fecha,
PERSONA_per_id,
ROL_rol_id
)
VALUES (
GETDATE(),
SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Rosman'
SELECT rol_id from ROL where rol_nombre='Admin Sistema'

INSERT INTO dbo.PERSONA_ROL  (
per_rol_fecha,
PERSONA_per_id,
ROL_rol_id
)
VALUES (
GETDATE(),
SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Miguel Alejandro',
SELECT rol_id from ROL where rol_nombre='Atleta'
);


INSERT INTO dbo.PERSONA_ROL  (
per_rol_fecha,
PERSONA_per_id,
ROL_rol_id
)
VALUES (
GETDATE(),
SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Eduardo',
SELECT rol_id from ROL where rol_nombre='Atleta'
);

INSERT INTO dbo.PERSONA_ROL  (
per_rol_fecha,
PERSONA_per_id,
ROL_rol_id
)
VALUES (
GETDATE(),
SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Maria Isabel',
SELECT rol_id from ROL where rol_nombre='Atleta'
);


INSERT INTO dbo.PERSONA_ROL  (
per_rol_fecha,
PERSONA_per_id,
ROL_rol_id
)
VALUES (
GETDATE(),
SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Mario Alejandro',
SELECT rol_id from ROL where rol_nombre='Atleta'
);

INSERT INTO dbo.PERSONA_ROL  (
per_rol_fecha,
PERSONA_per_id,
ROL_rol_id
)
VALUES (
GETDATE(),
SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Romulo Jose',
SELECT rol_id from ROL where rol_nombre='Atleta'
);

INSERT INTO dbo.PERSONA_ROL  (
per_rol_fecha,
PERSONA_per_id,
ROL_rol_id
)
VALUES (
GETDATE(),
SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Silfredo Augusto',
SELECT rol_id from ROL where rol_nombre='Atleta'
);

INSERT INTO dbo.PERSONA_ROL  (
per_rol_fecha,
PERSONA_per_id,
ROL_rol_id
)
VALUES (
GETDATE(),
SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Saul Enrique'
SELECT rol_id from ROL where rol_nombre='Atleta'
);

INSERT INTO dbo.PERSONA_ROL  (
per_rol_fecha,
PERSONA_per_id,
ROL_rol_id
)
VALUES (
GETDATE(),
SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Guillermo Daniel',
SELECT rol_id from ROL where rol_nombre='Atleta'
);

INSERT INTO dbo.PERSONA_ROL  (
per_rol_fecha,
PERSONA_per_id,
ROL_rol_id
)
VALUES (
GETDATE(),
SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Pedro Leonardo',
SELECT rol_id from ROL where rol_nombre='Atleta'
);

INSERT INTO dbo.PERSONA_ROL  (
per_rol_fecha,
PERSONA_per_id,
ROL_rol_id
)
VALUES (
GETDATE(),
SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Jose Miguel',
SELECT rol_id from ROL where rol_nombre='Atleta'
);

INSERT INTO dbo.PERSONA_ROL  (
per_rol_fecha,
PERSONA_per_id,
ROL_rol_id
)
VALUES (
GETDATE(),
SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Pedro Leonardo',
SELECT rol_id from ROL where rol_nombre='Entrenador'
);

INSERT INTO dbo.PERSONA_ROL  (
per_rol_fecha,
PERSONA_per_id,
ROL_rol_id
)
VALUES (
GETDATE(),
SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Jose Miguel',
SELECT rol_id from ROL where rol_nombre='Entrenador'
);

INSERT INTO dbo.PERSONA_ROL  (
per_rol_fecha,
PERSONA_per_id,
ROL_rol_id
)
VALUES (
GETDATE(),
SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Alexander Abraham',
SELECT rol_id from ROL where rol_nombre='Admin Dojo'
);

INSERT INTO dbo.PERSONA_ROL  (
per_rol_fecha,
PERSONA_per_id,
ROL_rol_id
)
VALUES (
GETDATE(),
SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Carlos Alberto',
SELECT rol_id from ROL where rol_nombre='Admin Dojo'
);

INSERT INTO dbo.PERSONA_ROL  (
per_rol_fecha,
PERSONA_per_id,
ROL_rol_id
)
VALUES (
GETDATE(),
SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Javier Porfirio',
SELECT rol_id from ROL where rol_nombre='Admin Dojo'
);