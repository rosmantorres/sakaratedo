/*
INSERTS M6

Los inserts de personas dependen de que los de Dojo hayan sido realizados.

Para traer los IDs de personas INSCRITAS en DOJOS usar alguna de  las siguientes expresiones:
--ADMINISTRADORES--
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Alexander Abraham')
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Carlos Alberto')
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Javier Porfirio')

--ATLETAS--
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Miguel Alejandro')
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Eduardo')
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Maria Isabel')
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Mario Alejandro')
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Romulo Jose')
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Silfredo Augusto')
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Saul Enrique')
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Guillermo Daniel')
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Pedro Leonardo')
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Jose Miguel')
*/

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
	per_imagen,
	DOJO_doj_id
) 
VALUES (
    'CEDULA-N',
    21424696,
    'Miguel Alejandro',
    'Ruiz Campos',
    'Venezolano',
    'Mariscos',
    '2da. Av. de Montalban. Res. Capricornio. Piso 5. Apto. 10',
    'M',
    'A+',
    '1993-05-21',
    1,
    77,
    1.72,
    'miguedro',
    '12345',
    'http://www.morganstanley.com/assets/images/people/tiles/michael-asmar.jpg',
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3')
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Miguel Alejandro'),
    '02124423694'
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Miguel Alejandro'),
    '04124456790'
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Miguel Alejandro'),
    'miguel.alejandro@ucab.edu.ve',
    1
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Miguel Alejandro'),
    'miguel.alejandro@gmail.com',
    0
);

INSERT INTO dbo.SOLICITUD_INSCRIPCION (
    PERSONA_per_id,
    DOJO_doj_id,
    sol_inc_fecha_creacion,
    sol_inc_fecha_actualizacion,
    sol_inc_estado
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Miguel Alejandro'),
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3'),
    GETDATE(),
    GETDATE(),
    'ACEPTADO'
);

INSERT INTO dbo.MATRICULA (
    mat_identificador,
    mat_fecha_creacion,
    mat_activa,
    mat_fecha_ultimo_pago,
    PERSONA_per_id,
    DOJO_doj_id
) 
VALUES (
    'CAF-CAF-CAFE',
    GETDATE(),
    1,
    GETDATE(),
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Miguel Alejandro'),
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3')
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
	per_clave,
	per_imagen,
	DOJO_doj_id
) 
VALUES (
    'CEDULA-N',
    14020474,
    'Adriana Josefina',
    'Lopez Sojo',
    'Venezolana',
    'Lacteos',
    '3ra. Transversal de Los Palos Grandes. Res. Guarani. Piso 3. Apto. 3-A',
    'F',
    'O-',
    '1988-11-15',
    1,
    63,
    1.60,
    'adrijo',
    '12345',
    'http://tphsartjdoerrer.weebly.com/uploads/7/7/0/2/7702116/152821360.jpg',
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3')
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Adriana Josefina'),
    '02129876543'
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Adriana Josefina'),
    '04142357490'
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Adriana Josefina'),
    'adriana.josefina@ucab.edu.ve',
    1
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Adriana Josefina'),
    'petronila47@gmail.com',
    0
);

INSERT INTO dbo.SOLICITUD_INSCRIPCION (
    PERSONA_per_id,
    DOJO_doj_id,
    sol_inc_fecha_creacion,
    sol_inc_fecha_actualizacion,
    sol_inc_estado
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Adriana Josefina'), 
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3'),   
    GETDATE(),
    GETDATE(),
    'RECHAZADO'
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
	per_clave,
	per_imagen,
	DOJO_doj_id
) 
VALUES (
    'CEDULA-E',
    3253777,
    'Christian Jose',
    'Suarez Arraiz',
    'Colombiano',
    'Gluten',
    'Calle Montserrat de Carapita. Quinta Los Reales.',
    'M',
    'B+',
    '1956-08-31',
    0,
    83,
    1.84,
    'chrisjo',
    '12345',
    'http://www.morganstanley.com/assets/images/people/tiles/michael-asmar.jpg',
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3')
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Christian Jose'),
    '02129873278'
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Christian Jose'),
    '04148761209'
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Christian Jose'),
    'christian.jose@ucab.edu.ve',
    1
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Christian Jose'),
    'chiguire58@gmail.com',
    0
);

INSERT INTO dbo.SOLICITUD_INSCRIPCION (
    PERSONA_per_id,
    DOJO_doj_id,
    sol_inc_fecha_creacion,
    sol_inc_fecha_actualizacion,
    sol_inc_estado
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Christian Jose'),    
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3'),
    GETDATE(),
    GETDATE(),
    'PENDIENTE'
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
	per_clave,
	per_imagen,
	DOJO_doj_id
) 
VALUES (
    'CEDULA-N',
    20532517,
    'Cesar Augusto',
    'Rodriguez Torres',
    'Venezolano',
    'Penicilina',
    'Calle principal de Santa Paula. Res. Caroni. Piso 12. PH-B',
    'M',
    'AB-',
    '1979-02-27',
    1,
    74,
    1.75,
    'cesarau',
    '12345',
    'http://www.one2onephotography.ca/image/portrait/men/men-images-1.jpg',
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3')
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Cesar Augusto'),
    '02123764504'
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Cesar Augusto'),
    '04143389564'
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Cesar Augusto'),
    'cesar.augusto@ucab.edu.ve',
    1
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Cesar Augusto'),
    'cesarag93@gmail.com',
    0
);

INSERT INTO dbo.SOLICITUD_INSCRIPCION (
    PERSONA_per_id,
    DOJO_doj_id,
    sol_inc_fecha_creacion,
    sol_inc_fecha_actualizacion,
    sol_inc_estado
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Cesar Augusto'),  
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3'),  
    GETDATE(),
    GETDATE(),
    'PENDIENTE'
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
	per_clave,
	per_imagen,
	DOJO_doj_id
) 
VALUES (
    'CEDULA-N',
    4818349,
    'Eduardo',
    'Sanchez Quintero',
    'Venezolano',
    'Coco',
    '2da. Avenida de La Lagunita. Quinta Los Querubines.',
    'M',
    'O-',
    '1968-03-05',
    1,
    88,
    1.78,
    'eduardo',
    '12345',
    'https://upload.wikimedia.org/wikipedia/en/2/28/Deep_Fried_Man_portrait_-_real_name_Daniel_Friedman_-_South_African_Comedian.jpg',
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3')
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Eduardo'),
    '02128740976'
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Eduardo'),
    '04142341765'
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Eduardo'),
    'eduardo@ucab.edu.ve',
    1
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Eduardo'),
    'edusanquin@gmail.com',
    0
);

INSERT INTO dbo.SOLICITUD_INSCRIPCION (
    PERSONA_per_id,
    DOJO_doj_id,
    sol_inc_fecha_creacion,
    sol_inc_fecha_actualizacion,
    sol_inc_estado
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Eduardo'),    
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3'),
    GETDATE(),
    GETDATE(),
    'ACEPTADO'
);

INSERT INTO dbo.MATRICULA (
    mat_identificador,
    mat_fecha_creacion,
    mat_activa,
    mat_fecha_ultimo_pago,
    PERSONA_per_id,
    DOJO_doj_id
) 
VALUES (
    '32-FE-A1',
    GETDATE(),
    1,
    GETDATE(),
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Eduardo'),
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3')
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
	per_clave,
	per_imagen,
	DOJO_doj_id
) 
VALUES (
    'CEDULA-N',
    23456834,
    'Maria Isabel',
    'Sanchez Quintero',
    'Venezolano',
    'Coco',
    '2da. Avenida de La Lagunita. Quinta Los Querubines.',
    'M',
    'O-',
    '1968-03-05',
    1,
    88,
    1.78,
    'mariaisa',
    '12345',
    'http://guildfordphotographer.co.uk/wp-content/uploads/2011/01/lucy.jpg',
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-17280493-1')
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Maria Isabel'),
    '02128740976'
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Maria Isabel'),
    '04142341765'
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Maria Isabel'),
    'maria.isabel@ucab.edu.ve',
    1
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Maria Isabel'),
    'mariitabel@gmail.com',
    0
);

INSERT INTO dbo.SOLICITUD_INSCRIPCION (
    PERSONA_per_id,
    DOJO_doj_id,
    sol_inc_fecha_creacion,
    sol_inc_fecha_actualizacion,
    sol_inc_estado
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Maria Isabel'),    
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-17280493-1'),
    GETDATE(),
    GETDATE(),
    'ACEPTADO'
);

INSERT INTO dbo.MATRICULA (
    mat_identificador,
    mat_fecha_creacion,
    mat_activa,
    mat_fecha_ultimo_pago,
    PERSONA_per_id,
    DOJO_doj_id
) 
VALUES (
    'CEFA-FE-A65',
    GETDATE(),
    1,
    GETDATE(),
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Maria Isabel'),
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-17280493-1')
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
	per_clave,
	per_imagen,
	DOJO_doj_id
) 
VALUES (
    'CEDULA-N',
    23456834,
    'Carlos Alberto',
    'Perez Pirela',
    'Venezolano',
    'Coco',
    '2da. Avenida de La Lagunita. Quinta Los Querubines.',
    'M',
    'O-',
    '1968-03-05',
    1,
    88,
    1.78,
    'carlosal',
    '12345',
    'https://c.stocksy.com/a/3iJ000/z0/75767.jpg',
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-17280493-1')
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Carlos Alberto'),
    '02128740976'
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Carlos Alberto'),
    '04142341765'
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Carlos Alberto'),
    'carlos.alberto@ucab.edu.ve',
    1
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Carlos Alberto'),
    'albertico1115@gmail.com',
    0
);

INSERT INTO dbo.SOLICITUD_INSCRIPCION (
    PERSONA_per_id,
    DOJO_doj_id,
    sol_inc_fecha_creacion,
    sol_inc_fecha_actualizacion,
    sol_inc_estado
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Carlos Alberto'),    
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-17280493-1'),
    GETDATE(),
    GETDATE(),
    'RECHAZADO'
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
	per_clave,
	per_imagen,
	DOJO_doj_id
) 
VALUES (
    'CEDULA-N',
    23456834,
    'Jesus Enrique',
    'Gutierrez Escobar',
    'Venezolano',
    'Coco',
    '2da. Avenida de La Lagunita. Quinta Los Querubines.',
    'M',
    'O-',
    '1968-03-05',
    1,
    88,
    1.78,
    'jesusen',
    '12345',
    'http://www.offshoresailing.com/wp-content/uploads/2013/05/photodune-658305-portrait-of-a-good-looking-african-american-business-man-s7-300x247.png',
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-17280493-1')
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Jesus Enrique'),
    '02128740976'
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Jesus Enrique'),
    '04142341765'
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Jesus Enrique'),
    'jesus.enrique@ucab.edu.ve',
    1
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Jesus Enrique'),
    'chuoito3334@gmail.com',
    0
);

INSERT INTO dbo.SOLICITUD_INSCRIPCION (
    PERSONA_per_id,
    DOJO_doj_id,
    sol_inc_fecha_creacion,
    sol_inc_fecha_actualizacion,
    sol_inc_estado
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Jesus Enrique'),    
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-17280493-1'),
    GETDATE(),
    GETDATE(),
    'PENDIENTE'
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
	per_clave,
	per_imagen,
	DOJO_doj_id
) 
VALUES (
    'CEDULA-N',
    23456834,
    'Gustavo Antonio',
    'Colmenares Alvarado',
    'Venezolano',
    'Mariscos',
    'Boulevard del Cafetal. Res. Adriatica. Piso 8. Apto. 8A',
    'M',
    'O-',
    '1968-03-05',
    1,
    88,
    1.78,
    'gustavoto',
    '12345',
    'http://thumbs.dreamstime.com/x/smiley-man-portrait-11016049.jpg',
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-17280493-1')
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Gustavo Antonio'),
    '02128740976'
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Gustavo Antonio'),
    '04142341765'
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Gustavo Antonio'),
    'gustavo.antonio@ucab.edu.ve',
    1
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Gustavo Antonio'),
    'antonio_77@gmail.com',
    0
);

INSERT INTO dbo.SOLICITUD_INSCRIPCION (
    PERSONA_per_id,
    DOJO_doj_id,
    sol_inc_fecha_creacion,
    sol_inc_fecha_actualizacion,
    sol_inc_estado
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Gustavo Antonio'),    
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-17280493-1'),
    GETDATE(),
    GETDATE(),
    'PENDIENTE'
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
	per_clave,
	per_imagen,
	DOJO_doj_id
) 
VALUES (
    'CEDULA-N',
    23456834,
    'Jessica Alejandra',
    'Garcia Sojo',
    'Venezolano',
    'Mariscos',
    'Boulevard del Cafetal. Res. Adriatica. Piso 8. Apto. 8A',
    'M',
    'O-',
    '1968-03-05',
    1,
    88,
    1.78,
    'jessiale',
    '12345',
    'http://thumbs.dreamstime.com/x/beautiful-woman-portrait-11713329.jpg',
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-15403240-9')
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Jessica Alejandra'),
    '02128740976'
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Jessica Alejandra'),
    '04142341765'
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Jessica Alejandra'),
    'jessica.alejandra@ucab.edu.ve',
    1
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Jessica Alejandra'),
    'jessgarcia94@gmail.com',
    0
);

INSERT INTO dbo.SOLICITUD_INSCRIPCION (
    PERSONA_per_id,
    DOJO_doj_id,
    sol_inc_fecha_creacion,
    sol_inc_fecha_actualizacion,
    sol_inc_estado
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Jessica Alejandra'),    
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-15403240-9'),
    GETDATE(),
    GETDATE(),
    'RECHAZADO'
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
	per_clave,
	per_imagen,
	DOJO_doj_id
) 
VALUES (
    'CEDULA-N',
    23456834,
    'Mario Alejandro',
    'De Castro Henriquez',
    'Venezolano',
    'Mariscos',
    'Boulevard del Cafetal. Res. Adriatica. Piso 8. Apto. 8A',
    'M',
    'O-',
    '1968-03-05',
    1,
    88,
    1.78,
    'marioale',
    '12345',
    'http://tedslater.com/wp-content/uploads/2010/07/shutterstock_202093444.jpg',
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-15403240-9')
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Mario Alejandro'),
    '02128740976'
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Mario Alejandro'),
    '04142341765'
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Mario Alejandro'),
    'mario.alejandro@ucab.edu.ve',
    1
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Mario Alejandro'),
    'alejandro.m.dcastro@gmail.com',
    0
);

INSERT INTO dbo.SOLICITUD_INSCRIPCION (
    PERSONA_per_id,
    DOJO_doj_id,
    sol_inc_fecha_creacion,
    sol_inc_fecha_actualizacion,
    sol_inc_estado
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Mario Alejandro'),    
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-15403240-9'),
    GETDATE(),
    GETDATE(),
    'ACEPTADO'
);

INSERT INTO dbo.MATRICULA (
    mat_identificador,
    mat_fecha_creacion,
    mat_activa,
    mat_fecha_ultimo_pago,
    PERSONA_per_id,
    DOJO_doj_id
) 
VALUES (
    '67F-31A-F2',
    GETDATE(),
    1,
    GETDATE(),
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Mario Alejandro'),
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-15403240-9')
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
	per_clave,
	per_imagen,
	DOJO_doj_id
) 
VALUES (
    'CEDULA-N',
    21424696,
    'Romulo Jose',
    'Ruiz Campos',
    'Venezolano',
    'Mariscos',
    '2da. Av. de Montalban. Res. Capricornio. Piso 5. Apto. 10',
    'M',
    'A+',
    '1993-05-21',
    1,
    77,
    1.72,
    'eltercera',
    '12345',
    'https://upload.wikimedia.org/wikipedia/commons/thumb/0/01/Bill_Gates_July_2014.jpg/220px-Bill_Gates_July_2014.jpg',
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3')
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Romulo Jose'),
    '02124423694'
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Romulo Jose'),
    '04124456790'
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Romulo Jose'),
    'ucab.genericoo@ucab.edu.ve',
    1
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Romulo Jose'),
    'generico.prueba@gmail.com',
    0
);

INSERT INTO dbo.SOLICITUD_INSCRIPCION (
    PERSONA_per_id,
    DOJO_doj_id,
    sol_inc_fecha_creacion,
    sol_inc_fecha_actualizacion,
    sol_inc_estado
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Romulo Jose'),
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3'),
    GETDATE(),
    GETDATE(),
    'ACEPTADO'
);

INSERT INTO dbo.MATRICULA (
    mat_identificador,
    mat_fecha_creacion,
    mat_activa,
    mat_fecha_ultimo_pago,
    PERSONA_per_id,
    DOJO_doj_id
) 
VALUES (
    'AA1-CAF-CAFE',
    GETDATE(),
    1,
    GETDATE(),
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Romulo Jose'),
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3')
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
	per_clave,
	per_imagen,
	DOJO_doj_id
) 
VALUES (
    'CEDULA-N',
    21424696,
    'Silfredo Augusto',
    'Rugeles Arraiz',
    'Venezolano',
    'Mariscos',
    '2da. Av. de Montalban. Res. Capricornio. Piso 5. Apto. 10',
    'M',
    'A+',
    '1993-05-21',
    1,
    77,
    1.72,
    'silfreau',
    '12345',
    'http://marshallmatlock.com/wp-content/gallery/mans-man-jon-hamm/thumbs/thumbs_jon%20hamm%20portrait%20suit.png',
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3')
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Silfredo Augusto'),
    '02124423694'
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Silfredo Augusto'),
    '04124456790'
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Silfredo Augusto'),
    'ucab.genericoo@ucab.edu.ve',
    1
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Silfredo Augusto'),
    'generico.prueba@gmail.com',
    0
);

INSERT INTO dbo.SOLICITUD_INSCRIPCION (
    PERSONA_per_id,
    DOJO_doj_id,
    sol_inc_fecha_creacion,
    sol_inc_fecha_actualizacion,
    sol_inc_estado
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Silfredo Augusto'),
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3'),
    GETDATE(),
    GETDATE(),
    'ACEPTADO'
);

INSERT INTO dbo.MATRICULA (
    mat_identificador,
    mat_fecha_creacion,
    mat_activa,
    mat_fecha_ultimo_pago,
    PERSONA_per_id,
    DOJO_doj_id
) 
VALUES (
    'AA2-CAF-CAFE',
    GETDATE(),
    1,
    GETDATE(),
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Silfredo Augusto'),
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3')
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
	per_clave,
	per_imagen,
	DOJO_doj_id
) 
VALUES (
    'CEDULA-N',
    21424696,
    'Saul Enrique',
    'Hernandez Arraiz',
    'Venezolano',
    'Mariscos',
    '2da. Av. de Montalban. Res. Capricornio. Piso 5. Apto. 10',
    'M',
    'A+',
    '1993-05-21',
    1,
    77,
    1.72,
    'saulen',
    '12345',
    'http://www4.pictures.zimbio.com/gi/Solitary+Man+Portraits+2009+Toronto+International+kBVOjNQV9rzl.jpg',
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3')
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Saul Enrique'),
    '02124423694'
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Saul Enrique'),
    '04124456790'
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Saul Enrique'),
    'ucab.genericoo@ucab.edu.ve',
    1
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Saul Enrique'),
    'generico.prueba@gmail.com',
    0
);

INSERT INTO dbo.SOLICITUD_INSCRIPCION (
    PERSONA_per_id,
    DOJO_doj_id,
    sol_inc_fecha_creacion,
    sol_inc_fecha_actualizacion,
    sol_inc_estado
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Saul Enrique'),
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3'),
    GETDATE(),
    GETDATE(),
    'ACEPTADO'
);

INSERT INTO dbo.MATRICULA (
    mat_identificador,
    mat_fecha_creacion,
    mat_activa,
    mat_fecha_ultimo_pago,
    PERSONA_per_id,
    DOJO_doj_id
) 
VALUES (
    'AA3-CAF-CAFE',
    GETDATE(),
    1,
    GETDATE(),
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Saul Enrique'),
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3')
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
	per_clave,
	per_imagen,
	DOJO_doj_id
) 
VALUES (
    'CEDULA-N',
    21424696,
    'Guillermo Daniel',
    'Jaramillo Do Couto',
    'Venezolano',
    'Mariscos',
    '2da. Av. de Montalban. Res. Capricornio. Piso 5. Apto. 10',
    'M',
    'A+',
    '1993-05-21',
    1,
    77,
    1.,
    'guilleja',
    '12345',
    'http://previews.123rf.com/images/rido/rido1212/rido121200073/16732489-Closeup-portrait-of-smiling-young-man-isolated-on-white-background-Stock-Photo.jpg',
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3')
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Guillermo Daniel'),
    '02124423694'
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Guillermo Daniel'),
    '04124456790'
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Guillermo Daniel'),
    'ucab.genericoo@ucab.edu.ve',
    1
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Guillermo Daniel'),
    'generico.prueba@gmail.com',
    0
);

INSERT INTO dbo.SOLICITUD_INSCRIPCION (
    PERSONA_per_id,
    DOJO_doj_id,
    sol_inc_fecha_creacion,
    sol_inc_fecha_actualizacion,
    sol_inc_estado
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Guillermo Daniel'),
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3'),
    GETDATE(),
    GETDATE(),
    'ACEPTADO'
);

INSERT INTO dbo.MATRICULA (
    mat_identificador,
    mat_fecha_creacion,
    mat_activa,
    mat_fecha_ultimo_pago,
    PERSONA_per_id,
    DOJO_doj_id
) 
VALUES (
    'AA4-CAF-CAFE',
    GETDATE(),
    1,
    GETDATE(),
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Guillermo Daniel'),
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3')
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
	per_clave,
	per_imagen,
	DOJO_doj_id
) 
VALUES (
    'CEDULA-N',
    21424696,
    'Pedro Leonardo',
    'Jaramillo Do Couto',
    'Venezolano',
    'Mariscos',
    '2da. Av. de Montalban. Res. Capricornio. Piso 5. Apto. 10',
    'M',
    'A+',
    '1993-05-21',
    1,
    77,
    1.72,
    'pedroleo',
    '12345',
    'https://c2.staticflickr.com/4/3147/3030821516_793151ecc1_z.jpg',
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3')
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Pedro Leonardo'),
    '02124423694'
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Pedro Leonardo'),
    '04124456790'
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Pedro Leonardo'),
    'ucab.genericoo@ucab.edu.ve',
    1
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Pedro Leonardo'),
    'generico.prueba@gmail.com',
    0
);

INSERT INTO dbo.SOLICITUD_INSCRIPCION (
    PERSONA_per_id,
    DOJO_doj_id,
    sol_inc_fecha_creacion,
    sol_inc_fecha_actualizacion,
    sol_inc_estado
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Pedro Leonardo'),
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3'),
    GETDATE(),
    GETDATE(),
    'ACEPTADO'
);

INSERT INTO dbo.MATRICULA (
    mat_identificador,
    mat_fecha_creacion,
    mat_activa,
    mat_fecha_ultimo_pago,
    PERSONA_per_id,
    DOJO_doj_id
) 
VALUES (
    'AA5-CAF-CAFE',
    GETDATE(),
    1,
    GETDATE(),
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Pedro Leonardo'),
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3')
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
	per_clave,
	per_imagen,
	DOJO_doj_id
) 
VALUES (
    'CEDULA-N',
    21424696,
    'Jose Miguel',
    'Jaramillo Do Couto',
    'Venezolano',
    'Mariscos',
    '2da. Av. de Montalban. Res. Capricornio. Piso 5. Apto. 10',
    'M',
    'A+',
    '1993-05-21',
    1,
    77,
    1.72,
    'josemiguel',
    '12345',
    'http://www.photographyblogger.net/wp-content/uploads/2013/05/1-jaco-van-den-hoven.jpg',
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3')
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Jose Miguel'),
    '02124423694'
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Jose Miguel'),
    '04124456790'
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Jose Miguel'),
    'ucab.genericoo@ucab.edu.ve',
    1
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Jose Miguel'),
    'generico.prueba@gmail.com',
    0
);

INSERT INTO dbo.SOLICITUD_INSCRIPCION (
    PERSONA_per_id,
    DOJO_doj_id,
    sol_inc_fecha_creacion,
    sol_inc_fecha_actualizacion,
    sol_inc_estado
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Jose Miguel'),
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3'),
    GETDATE(),
    GETDATE(),
    'ACEPTADO'
);

INSERT INTO dbo.MATRICULA (
    mat_identificador,
    mat_fecha_creacion,
    mat_activa,
    mat_fecha_ultimo_pago,
    PERSONA_per_id,
    DOJO_doj_id
) 
VALUES (
    'AA6-CAF-CAFE',
    GETDATE(),
    1,
    GETDATE(),
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Jose Miguel'),
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3')
);

/* ADMINISTRADORES */

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
	per_imagen,
	DOJO_doj_id
) 
VALUES (
    'CEDULA-N',
    21424696,
    'Alexander Abraham',
    'Ramirez Cabrera',
    'Venezolano',
    'Mariscos',
    '2da. Av. de Montalban. Res. Capricornio. Piso 5. Apto. 10',
    'M',
    'A+',
    '1993-05-21',
    1,
    77,
    1.72,
    'ramirezadmin',
    '12345',
    'http://st.depositphotos.com/1009647/1293/i/950/depositphotos_12933724-Bearded-man.jpg',
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3')
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Alexander Abraham'),
    '02124423694'
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Alexander Abraham'),
    '04124456790'
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Alexander Abraham'),
    'administrador.generico@ucab.edu.ve',
    1
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Alexander Abraham'),
    'plain_administrador@gmail.com',
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
	per_clave,
	per_imagen,
	DOJO_doj_id
) 
VALUES (
    'CEDULA-N',
    21424696,
    'Carlos Alberto',
    'Suarez Romero',
    'Venezolano',
    'Mariscos',
    '2da. Av. de Montalban. Res. Capricornio. Piso 5. Apto. 10',
    'M',
    'A+',
    '1993-05-21',
    1,
    77,
    1.72,
    'suarezadmin',
    '12345',
    'http://www.photographyblogger.net/wp-content/uploads/2013/05/1-jaco-van-den-hoven.jpg',
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-17280493-1')
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Carlos Alberto'),
    '02124423694'
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Carlos Alberto'),
    '04124456790'
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Carlos Alberto'),
    'administrador.generico@ucab.edu.ve',
    1
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Carlos Alberto'),
    'plain_administrador@gmail.com',
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
	per_clave,
	per_imagen,
	DOJO_doj_id
) 
VALUES (
    'CEDULA-N',
    21424696,
    'Javier Porfirio',
    'Torres Contreras',
    'Venezolano',
    'Mariscos',
    '2da. Av. de Montalban. Res. Capricornio. Piso 5. Apto. 10',
    'M',
    'A+',
    '1993-05-21',
    1,
    77,
    1.72,
    'torresadmin',
    '12345',
    'http://st.depositphotos.com/1009647/1293/i/950/depositphotos_12933724-Bearded-man.jpg',
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3')
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Javier Porfirio'),
    '02124423694'
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Javier Porfirio'),
    '04124456790'
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Javier Porfirio'),
    'administrador.generico@ucab.edu.ve',
    1
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Javier Porfirio'),
    'plain_administrador@gmail.com',
    0
);