/*
INSERTS M6

Los inserts de personas dependen de que los de Dojo hayan sido realizados.

Para traer los IDs de personas INSCRITAS en DOJOS usar alguna de  las siguientes expresiones:
--ADMINISTRADORES--
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Alexander Abraham')
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Freddy Jose')
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Javier Porfirio')

--ATLETAS--
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Carlos Alberto'),
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
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Maria Antonieta')
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Victoria Isabella')
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Melissa Nathalie')
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Elizabeth Antonia')
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Marco Alejandro')
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Jose Gregorio')
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Luis Armando')
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Federico Ernesto')
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Liu Wa')
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Marta Carolina')
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Patricia Elena')
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Neolida Margarita')
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Nora Margarita')
(SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Sabrina')
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
    21424693,
    'Maria Antonieta',
    'Jaramillo Do Couto',
    'Venezolano',
    'Mariscos',
    '2da. Av. de Montalban. Res. Capricornio. Piso 5. Apto. 10',
    'F',
    'A+',
    '1993-05-21',
    1,
    77,
    1.72,
    'maritonieta',
    '12345',
    'http://pre14.deviantart.net/3404/th/pre/i/2013/181/8/a/portrait_of_beautiful_woman_by_vladimir_serov-d6b67i9.jpg',
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3')
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Maria Antonieta'),
    '02124423694'
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Maria Antonieta'),
    '04124456790'
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Maria Antonieta'),
    'ucab.genericoo@ucab.edu.ve',
    1
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Maria Antonieta'),
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
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Maria Antonieta'),
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
    'AA7-CAF-CAFE',
    GETDATE(),
    1,
    GETDATE(),
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Maria Antonieta'),
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
    21424694,
    'Victoria Isabella',
    'Jaramillo Do Couto',
    'Venezolano',
    'Mariscos',
    '2da. Av. de Montalban. Res. Capricornio. Piso 5. Apto. 10',
    'F',
    'A+',
    '1993-05-21',
    1,
    77,
    1.72,
    'vickybella',
    '12345',
    'http://pre14.deviantart.net/3404/th/pre/i/2013/181/8/a/portrait_of_beautiful_woman_by_vladimir_serov-d6b67i9.jpg',
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3')
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Victoria Isabella'),
    '02124423694'
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Victoria Isabella'),
    '04124456790'
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Victoria Isabella'),
    'ucab.genericoo@ucab.edu.ve',
    1
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Victoria Isabella'),
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
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Victoria Isabella'),
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
    'AA8-CAF-CAFE',
    GETDATE(),
    1,
    GETDATE(),
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Victoria Isabella'),
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
    21424632,
    'Melissa Nathalie',
    'Jaramillo Do Couto',
    'Venezolano',
    'Mariscos',
    '2da. Av. de Montalban. Res. Capricornio. Piso 5. Apto. 10',
    'F',
    'A+',
    '1993-05-21',
    1,
    77,
    1.72,
    'melilie',
    '12345',
    'http://www.noupe.com/wp-content/uploads/2010/01/26-portraits.jpg',
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3')
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Melissa Nathalie'),
    '02124423694'
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Melissa Nathalie'),
    '04124456790'
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Melissa Nathalie'),
    'ucab.genericoo@ucab.edu.ve',
    1
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Melissa Nathalie'),
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
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Melissa Nathalie'),
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
    'AA9-CAF-CAFE',
    GETDATE(),
    1,
    GETDATE(),
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Melissa Nathalie'),
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
    14020471,
    'Elizabeth Antonia',
    'Jaramillo Do Couto',
    'Venezolano',
    'Mariscos',
    '2da. Av. de Montalban. Res. Capricornio. Piso 5. Apto. 10',
    'F',
    'A+',
    '1993-05-21',
    1,
    77,
    1.72,
    'elidocouto',
    '12345',
    'http://www.wallcoo.net/photography/markus-j-grimm_portrait_photography_02/images/Color_portrait_photo_15971497.jpg',
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3')
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Elizabeth Antonia'),
    '02124423694'
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Elizabeth Antonia'),
    '04124456790'
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Elizabeth Antonia'),
    'ucab.genericoo@ucab.edu.ve',
    1
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Elizabeth Antonia'),
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
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Elizabeth Antonia'),
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
    'AAA-CAF-CAFE',
    GETDATE(),
    1,
    GETDATE(),
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Elizabeth Antonia'),
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
    14020472,
    'Marco Alejandro',
    'Sanz Arcila',
    'Venezolano',
    'Mariscos',
    '2da. Av. de Montalban. Res. Capricornio. Piso 5. Apto. 10',
    'M',
    'A+',
    '1993-05-21',
    1,
    77,
    1.72,
    'marcosanz',
    '12345',
    'https://pixabay.com/static/uploads/photo/2013/11/20/23/01/man-214200_960_720.jpg',
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3')
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Marco Alejandro'),
    '02124423694'
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Marco Alejandro'),
    '04124456790'
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Marco Alejandro'),
    'ucab.genericoo@ucab.edu.ve',
    1
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Marco Alejandro'),
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
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Marco Alejandro'),
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
    'EFC1-CAF-CAFE',
    GETDATE(),
    1,
    GETDATE(),
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Marco Alejandro'),
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
    'Jose Gregorio',
    'Sanz Arcila',
    'Venezolano',
    'Mariscos',
    '2da. Av. de Montalban. Res. Capricornio. Piso 5. Apto. 10',
    'M',
    'A+',
    '1993-05-21',
    1,
    77,
    1.72,
    'goyito',
    '12345',
    'https://c1.staticflickr.com/3/2835/9965420034_1b7450e257.jpg',
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3')
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Jose Gregorio'),
    '02124423694'
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Jose Gregorio'),
    '04124456790'
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Jose Gregorio'),
    'ucab.genericoo@ucab.edu.ve',
    1
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Jose Gregorio'),
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
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Jose Gregorio'),
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
    'EFC2-CAF-CAFE',
    GETDATE(),
    1,
    GETDATE(),
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Jose Gregorio'),
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
    14020475,
    'Luis Armando',
    'Pereira Alfonzo',
    'Venezolano',
    'Mariscos',
    '2da. Av. de Montalban. Res. Capricornio. Piso 5. Apto. 10',
    'M',
    'A+',
    '1993-05-21',
    1,
    77,
    1.72,
    'armandito',
    '12345',
    'https://pixabay.com/static/uploads/photo/2015/01/16/15/01/man-601560_960_720.jpg',
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3')
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Luis Armando'),
    '02124423694'
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Luis Armando'),
    '04124456790'
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Luis Armando'),
    'ucab.genericoo@ucab.edu.ve',
    1
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Luis Armando'),
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
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Luis Armando'),
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
    'EFC3-CAF-CAFE',
    GETDATE(),
    1,
    GETDATE(),
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Luis Armando'),
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
    14020476,
    'Federico Ernesto',
    'Pereira Alfonzo',
    'Venezolano',
    'Mariscos',
    '2da. Av. de Montalban. Res. Capricornio. Piso 5. Apto. 10',
    'M',
    'A+',
    '1993-05-21',
    1,
    77,
    1.72,
    'ernestof',
    '12345',
    'https://c1.staticflickr.com/3/2222/2088987724_f4f58e7aa7.jpg',
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3')
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Federico Ernesto'),
    '02124423694'
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Federico Ernesto'),
    '04124456790'
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Federico Ernesto'),
    'ucab.genericoo@ucab.edu.ve',
    1
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Federico Ernesto'),
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
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Federico Ernesto'),
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
    'EFC4-CAF-CAFE',
    GETDATE(),
    1,
    GETDATE(),
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Federico Ernesto'),
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
    'CEDULA-E',
    14086743,
    'Liu Wa',
    'Ping Hua',
    'Venezolano',
    'Mariscos',
    '2da. Av. de Montalban. Res. Capricornio. Piso 5. Apto. 10',
    'M',
    'A+',
    '1993-05-21',
    1,
    77,
    1.72,
    'chinitowa',
    '12345',
    'https://pixabay.com/static/uploads/photo/2014/11/19/10/52/man-537136_960_720.jpg',
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3')
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Liu Wa'),
    '02124423694'
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Liu Wa'),
    '04124456790'
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Liu Wa'),
    'ucab.genericoo@ucab.edu.ve',
    1
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Liu Wa'),
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
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Liu Wa'),
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
    'EFC5-CAF-CAFE',
    GETDATE(),
    1,
    GETDATE(),
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Liu Wa'),
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
    4818341,
    'Marta Carolina',
    'Huertas Moncada',
    'Venezolano',
    'Mariscos',
    '2da. Av. de Montalban. Res. Capricornio. Piso 5. Apto. 10',
    'F',
    'A+',
    '1993-05-21',
    1,
    77,
    1.72,
    'martica',
    '12345',
    'http://img.whitezine.com/Thomas-Lavelle-Portrait-Woman.jpg',
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3')
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Marta Carolina'),
    '02124423694'
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Marta Carolina'),
    '04124456790'
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Marta Carolina'),
    'ucab.genericoo@ucab.edu.ve',
    1
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Marta Carolina'),
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
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Marta Carolina'),
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
    'EFC6-CAF-CAFE',
    GETDATE(),
    1,
    GETDATE(),
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Marta Carolina'),
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
    4818342,
    'Patricia Elena',
    'Huertas Moncada',
    'Venezolano',
    'Mariscos',
    '2da. Av. de Montalban. Res. Capricornio. Piso 5. Apto. 10',
    'F',
    'A+',
    '1993-05-21',
    1,
    77,
    1.72,
    'elenita',
    '12345',
    'https://pixabay.com/static/uploads/photo/2015/03/04/19/41/woman-659348_960_720.jpg',
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3')
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Patricia Elena'),
    '02124423694'
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Patricia Elena'),
    '04124456790'
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Patricia Elena'),
    'ucab.genericoo@ucab.edu.ve',
    1
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Patricia Elena'),
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
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Patricia Elena'),
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
    'EFC7-CAF-CAFE',
    GETDATE(),
    1,
    GETDATE(),
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Patricia Elena'),
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
    4818343,
    'Neolida Margarita',
    'Huertas Moncada',
    'Venezolano',
    'Mariscos',
    '2da. Av. de Montalban. Res. Capricornio. Piso 5. Apto. 10',
    'F',
    'A+',
    '1993-05-21',
    1,
    77,
    1.72,
    'neomar',
    '12345',
    'http://digital-art-gallery.com/oid/21/632x833_5536_Alexz_Johnson_portrait_2d_realism_girl_portrait_realistic_beauty_woman_picture_image_digital_art.jpg',
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3')
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Neolida Margarita'),
    '02124423694'
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Neolida Margarita'),
    '04124456790'
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Neolida Margarita'),
    'ucab.genericoo@ucab.edu.ve',
    1
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Neolida Margarita'),
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
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Neolida Margarita'),
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
    'EFC8-CAF-CAFE',
    GETDATE(),
    1,
    GETDATE(),
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Neolida Margarita'),
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
    4818344,
    'Nora Margarita',
    'Lopez Villarroel',
    'Venezolano',
    'Mariscos',
    '2da. Av. de Montalban. Res. Capricornio. Piso 5. Apto. 10',
    'F',
    'A+',
    '1993-05-21',
    1,
    77,
    1.72,
    'norita',
    '12345',
    'http://hd.wallpaperswide.com/thumbs/beautiful_woman_portrait-t2.jpg',
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3')
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Nora Margarita'),
    '02124423694'
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Nora Margarita'),
    '04124456790'
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Nora Margarita'),
    'ucab.genericoo@ucab.edu.ve',
    1
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Nora Margarita'),
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
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Nora Margarita'),
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
    'EFC9-CAF-CAFE',
    GETDATE(),
    1,
    GETDATE(),
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Nora Margarita'),
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
    4818345,
    'Sabrina',
    'Flores Cisneros',
    'Venezolano',
    'Mariscos',
    '2da. Av. de Montalban. Res. Capricornio. Piso 5. Apto. 10',
    'F',
    'A+',
    '1993-05-21',
    1,
    77,
    1.72,
    'norita',
    '12345',
    'http://images.fineartamerica.com/images/artworkimages/mediumlarge/1/gorgeous-woman-portrait-anna-omelchenko.jpg',
    (SELECT doj_id FROM dbo.DOJO WHERE doj_rif = 'J-13224369-3')
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Sabrina'),
    '02124423694'
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Sabrina'),
    '04124456790'
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Sabrina'),
    'ucab.genericoo@ucab.edu.ve',
    1
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Sabrina'),
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
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Sabrina'),
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
    'BBA1-CAF-CAFE',
    GETDATE(),
    1,
    GETDATE(),
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Sabrina'),
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
    'Freddy Jose',
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
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Freddy Jose'),
    '02124423694'
);

INSERT INTO dbo.TELEFONO (
    PERSONA_per_id,
    tel_numero
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Freddy Jose'),
    '04124456790'
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Freddy Jose'),
    'administrador.generico@ucab.edu.ve',
    1
);

INSERT INTO dbo.EMAIL (
    PERSONA_per_id,
    ema_email,
    ema_principal
)
VALUES (
    (SELECT per_id FROM dbo.PERSONA WHERE per_nombre = 'Freddy Jose'),
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

-- INSERTS UBICACION --
INSERT INTO [dbo].[UBICACION] ([ubi_latitud], [ubi_longitud], [ubi_ciudad], [ubi_estado], [ubi_direccion]) VALUES ('10.499607', '-66.788419', 'Caracas', 'Miranda', null)
go

INSERT INTO [dbo].[UBICACION] ([ubi_latitud], [ubi_longitud], [ubi_ciudad], [ubi_estado], [ubi_direccion]) VALUES ('10.062028', '-69.4328889', 'Barquisimeto', 'Lara', null)
go

INSERT INTO [dbo].[UBICACION] ([ubi_latitud], [ubi_longitud], [ubi_ciudad], [ubi_estado], [ubi_direccion]) VALUES ('10.1727434', '-68.0642649', 'Valencia', 'Carabobo', null)
go

INSERT INTO [dbo].[UBICACION] ([ubi_latitud], [ubi_longitud], [ubi_ciudad], [ubi_estado], [ubi_direccion]) VALUES ('10.2673453', '-67.6754515', 'Maracay', 'Aragua', null)
go

INSERT INTO [dbo].[UBICACION] ([ubi_latitud], [ubi_longitud], [ubi_ciudad], [ubi_estado], [ubi_direccion]) VALUES ('10.6338776', '-71.8170448', 'Maracaibo', 'Zulia', null)
go

-- INSERTS TIPO_EVENTO --
INSERT INTO [dbo].[TIPO_EVENTO] ([tip_nombre]) VALUES ('Pase de Cinta')
go

INSERT INTO [dbo].[TIPO_EVENTO] ([tip_nombre]) VALUES ('Seminario')
go

INSERT INTO [dbo].[TIPO_EVENTO] ([tip_nombre]) VALUES ('Entrenamiento Especial')
go

INSERT INTO [dbo].[TIPO_EVENTO] ([tip_nombre]) VALUES ('Clases Regulares')
go

-- INSERTS HORARIO --
INSERT INTO [dbo].[HORARIO] ([hor_fecha_inicio],[hor_fecha_fin],[hor_hora_inicio],[hor_hora_fin]) VALUES ('2015-10-15','2016-10-15',2,4) -- Clases -- 
go
INSERT INTO [dbo].[HORARIO] ([hor_fecha_inicio],[hor_fecha_fin],[hor_hora_inicio],[hor_hora_fin]) VALUES ('2015-12-15','2016-02-02',5,1) -- Seminario --
go
INSERT INTO [dbo].[HORARIO] ([hor_fecha_inicio],[hor_fecha_fin],[hor_hora_inicio],[hor_hora_fin]) VALUES ('2015-11-15','2015-11-15',1,3) -- Pase de Cita --  
go
INSERT INTO [dbo].[HORARIO] ([hor_fecha_inicio],[hor_fecha_fin],[hor_hora_inicio],[hor_hora_fin]) VALUES ('2016-01-15','2016-01-15',2,4) -- Clase Especial -- 
go
INSERT INTO [dbo].[HORARIO] ([hor_fecha_inicio],[hor_fecha_fin],[hor_hora_inicio],[hor_hora_fin]) VALUES ('2015-10-15','2016-10-15',3,6) -- Clases -- 
go

-- INSERTS EVENTO -- 

INSERT INTO [dbo].[EVENTO] ([eve_nombre],[eve_costo],[eve_descripcion],[eve_estado],[DOJO_doj_id],[CATEGORIA_cat_id],[HORARIO_hor_id],[TIPO_EVENTO_tip_id],[UBICACION_ubi_id]) VALUES ('Clase Regular',0,'Clases regulares del atleta que va los dias asignados',1,null,null,1,4,1)
go
INSERT INTO [dbo].[EVENTO] ([eve_nombre],[eve_costo],[eve_descripcion],[eve_estado],[DOJO_doj_id],[CATEGORIA_cat_id],[HORARIO_hor_id],[TIPO_EVENTO_tip_id],[UBICACION_ubi_id]) VALUES ('Entrenamiento 2',2000,'Entrenammiento para Competencia',1,null,null,4,3,2)
go
INSERT INTO [dbo].[EVENTO] ([eve_nombre],[eve_costo],[eve_descripcion],[eve_estado],[DOJO_doj_id],[CATEGORIA_cat_id],[HORARIO_hor_id],[TIPO_EVENTO_tip_id],[UBICACION_ubi_id]) VALUES ('Pase a negra',1150,'Pase de cinta de los atletas',1,null,null,3,1,1)
go
INSERT INTO [dbo].[EVENTO] ([eve_nombre],[eve_costo],[eve_descripcion],[eve_estado],[DOJO_doj_id],[CATEGORIA_cat_id],[HORARIO_hor_id],[TIPO_EVENTO_tip_id],[UBICACION_ubi_id]) VALUES ('La vida en el Dojo',1150,'Charla sobre los atletas en la vida real',1,null,null,2,2,1)
go

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

-------------------------------------------------------INSERT_M14-------------------------------------------------------


INSERT INTO TIPO_PLANILLA (tip_nombre,tip_descripcion) values ('RETIRO','Este tipo de planilla se puede solicitar cuando se hacen retiros por compentencias');
INSERT INTO TIPO_PLANILLA (tip_nombre,tip_descripcion) values ('AUSENCIA','Este tipo de planilla se puede solicitar cuando se hacen ausencias temporales,prolongados, por campeonato y entrenamiento');
INSERT INTO TIPO_PLANILLA (tip_nombre,tip_descripcion) values ('ASISTENCIA','Este tipo de planilla se puede solicitar cuando se va a faltar a una competencia');
INSERT INTO TIPO_PLANILLA (tip_nombre,tip_descripcion) values ('PARTICIPACION','Este tipo de planilla se puede solicitar cuando se requiere de participacion en arbitraje');
INSERT INTO TIPO_PLANILLA (tip_nombre,tip_descripcion) values ('ESPECIAL','Este tipo de planilla se puede solicitar cuando requiere otros permisos especiales');


INSERT INTO PLANILLA (pla_nombre,pla_status,TIPO_PLANILLA_tip_id) values ('RETIRO COMPETENCIA',1,1);
INSERT INTO PLANILLA (pla_nombre,pla_status,TIPO_PLANILLA_tip_id) values ('AUSENCIA TEMPORAL',1,2);
INSERT INTO PLANILLA (pla_nombre,pla_status,TIPO_PLANILLA_tip_id) values ('RETIRO PROLONGADO',0,2);
INSERT INTO PLANILLA (pla_nombre,pla_status,TIPO_PLANILLA_tip_id) values ('RETIRO CAMPEONATO',0,2);
INSERT INTO PLANILLA (pla_nombre,pla_status,TIPO_PLANILLA_tip_id) values ('RETIRO ENTRENAMIENTO',1,2);
INSERT INTO PLANILLA (pla_nombre,pla_status,TIPO_PLANILLA_tip_id) values ('ASISTENCIA COMPETENCIA',1,3);
INSERT INTO PLANILLA (pla_nombre,pla_status,TIPO_PLANILLA_tip_id) values ('PAGO INSCRIPCION',1,4);
INSERT INTO PLANILLA (pla_nombre,pla_status,TIPO_PLANILLA_tip_id) values ('PARTICIPACION',0,4);



INSERT INTO DATO (dat_nombre,dat_abreviatura) values ('ATLETA','ATL');
INSERT INTO DATO (dat_nombre,dat_abreviatura) values ('COMPETENCIA','COM');
INSERT INTO DATO (dat_nombre,dat_abreviatura) values ('DOJO','DOJ');
INSERT INTO DATO (dat_nombre,dat_abreviatura) values ('EVENTO','EVE');



INSERT INTO PLA_DAT (DATO_dat_id,PLANILLA_pla_id) values (1,1);
INSERT INTO PLA_DAT (DATO_dat_id,PLANILLA_pla_id) values (1,2);
INSERT INTO PLA_DAT (DATO_dat_id,PLANILLA_pla_id) values (1,3);
INSERT INTO PLA_DAT (DATO_dat_id,PLANILLA_pla_id) values (2,1);
INSERT INTO PLA_DAT (DATO_dat_id,PLANILLA_pla_id) values (3,1);
INSERT INTO PLA_DAT (DATO_dat_id,PLANILLA_pla_id) values (4,3);
INSERT INTO PLA_DAT (DATO_dat_id,PLANILLA_pla_id) values (2,4);

INSERT INTO DISEÑO (dis_contenido,PLANILLA_pla_id) values ('PHA+Jm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgPHN0cm9uZz4mbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwO1BsYW5pbGxhIGRlIEluc2NyaXBjaSZvYWN1dGU7bjwvc3Ryb25nPjwvcD4NCg0KPHA+Jm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICZuYnNwOyAmbmJzcDsgJm5ic3A7ICRwZXJfaW1hZ2VuPC9wPg0KDQo8cD4mbmJzcDs8L3A+DQoNCjx0YWJsZSBib3JkZXI9IjEiIGNlbGxwYWRkaW5nPSIxIiBjZWxsc3BhY2luZz0iMSIgc3R5bGU9IndpZHRoOjcwMHB4Ij4NCgk8Y2FwdGlvbj48c3Ryb25nPkRhdG9zIFBlcnNvbmFsZXM8L3N0cm9uZz48L2NhcHRpb24+DQoJPHRib2R5Pg0KCQk8dHI+DQoJCQk8dGQ+PHN0cm9uZz5Ob21icmU8L3N0cm9uZz48L3RkPg0KCQkJPHRkPiRwZXJfbm9tYnJlPC90ZD4NCgkJCTx0ZD48c3Ryb25nPkFwZWxsaWRvPC9zdHJvbmc+PC90ZD4NCgkJCTx0ZD4kcGVyX2FwZWxsaWRvPC90ZD4NCgkJPC90cj4NCgkJPHRyPg0KCQkJPHRkPjxzdHJvbmc+VGlwbyBkZSBEb2N1bWVudG88L3N0cm9uZz48L3RkPg0KCQkJPHRkPiRwZXJfdGlwb19kb2NfaWQ8L3RkPg0KCQkJPHRkPjxzdHJvbmc+RG9jdW1lbnRvIElkZW50aWRhZDwvc3Ryb25nPjwvdGQ+DQoJCQk8dGQ+JHBlcl9udW1fZG9jX2lkPC90ZD4NCgkJPC90cj4NCgkJPHRyPg0KCQkJPHRkPjxzdHJvbmc+TmFjaW9uYWxpZGFkPC9zdHJvbmc+PC90ZD4NCgkJCTx0ZD4kcGVyX25hY2lvbmFsaWRhZDwvdGQ+DQoJCQk8dGQ+PHN0cm9uZz5EaXJlY2NpJm9hY3V0ZTtuPC9zdHJvbmc+PC90ZD4NCgkJCTx0ZD4kcGVyX2RpcmVjY2lvbjwvdGQ+DQoJCTwvdHI+DQoJCTx0cj4NCgkJCTx0ZD48c3Ryb25nPlNleG88L3N0cm9uZz48L3RkPg0KCQkJPHRkPiRwZXJfc2V4bzwvdGQ+DQoJCQk8dGQ+PHN0cm9uZz5GZWNoYSBkZSBOYWNpbWllbnRvPC9zdHJvbmc+PC90ZD4NCgkJCTx0ZD4kcGVyX2ZlY2hhX25hY2ltaWVudG88L3RkPg0KCQk8L3RyPg0KCTwvdGJvZHk+DQo8L3RhYmxlPg0KDQo8dGFibGUgYm9yZGVyPSIxIiBjZWxscGFkZGluZz0iMSIgY2VsbHNwYWNpbmc9IjEiIHN0eWxlPSJ3aWR0aDo3MDBweCI+DQoJPGNhcHRpb24+DQoJPHA+Jm5ic3A7PC9wPg0KDQoJPHA+PHN0cm9uZz5EYXRvcyBkZWwgRG9qbzwvc3Ryb25nPjwvcD4NCgk8L2NhcHRpb24+DQoJPHRib2R5Pg0KCQk8dHI+DQoJCQk8dGQ+PHN0cm9uZz5Ob21icmU8L3N0cm9uZz48L3RkPg0KCQkJPHRkPiRkb2pfbm9tYnJlPC90ZD4NCgkJCTx0ZD48c3Ryb25nPlRlbCZlYWN1dGU7Zm9ubzwvc3Ryb25nPjwvdGQ+DQoJCQk8dGQ+JGRval90ZWxlZm9ubzwvdGQ+DQoJCTwvdHI+DQoJCTx0cj4NCgkJCTx0ZD48c3Ryb25nPlJpZjwvc3Ryb25nPjwvdGQ+DQoJCQk8dGQ+JGRval9yaWY8L3RkPg0KCQkJPHRkPjxzdHJvbmc+RW1haWw8L3N0cm9uZz48L3RkPg0KCQkJPHRkPiRkb2pfZW1haWw8L3RkPg0KCQk8L3RyPg0KCTwvdGJvZHk+DQo8L3RhYmxlPg0KDQo8cD4mbmJzcDs8L3A+DQo=',4);

INSERT INTO SOLICITUD_PLANILLA (sol_pla_fecha_Creacion,sol_pla_fecha_retiro,sol_pla_fecha_reincorporacion,sol_pla_motivo,PLANILLA_pla_id,INSCRIPCION_ins_id ,PERSONA_per_id) values ('01/02/2015','11/02/2015','12/02/2015','ENFERMEDAD',3,1,1);
INSERT INTO SOLICITUD_PLANILLA (sol_pla_fecha_Creacion,sol_pla_fecha_retiro,sol_pla_fecha_reincorporacion,sol_pla_motivo,PLANILLA_pla_id,INSCRIPCION_ins_id ,PERSONA_per_id) values ('23/08/2014','26/08/2014','27/09/2015','VACACIONES',4,2,1);
INSERT INTO SOLICITUD_PLANILLA (sol_pla_fecha_Creacion,sol_pla_fecha_retiro,sol_pla_fecha_reincorporacion,sol_pla_motivo,PLANILLA_pla_id,INSCRIPCION_ins_id ,PERSONA_per_id) values ('21/12/2013','08/01/2014','09/01/2014','FAMILIAR',5,2,2);

INSERT INTO ORGANIZACION(org_nombre,org_direccion,org_telefono,org_email,org_estado,ESTILO_est_id) VALUES('Seito Karate-do','Av 24, calle 8 edificio Morales, Altamira, Caracas',2123117754,'seitokaratedo@gmail.com','Distrito Federal',1);

INSERT INTO ORGANIZACION(org_nombre,org_direccion,org_telefono,org_email,org_estado,ESTILO_est_id) VALUES('Clash Cobra-do','Av principal,  edificio Torrealba, Edo Falcon',2123118854,'clashcobrado@gmail.com','Falcon',1);

INSERT INTO ORGANIZACION(org_nombre,org_direccion,org_telefono,org_email,org_estado,ESTILO_est_id) VALUES('Shotokan Org','Av 8, calle 8 local numero 12',2123457754,'seseikaratedo@gmail.com','Carabobo',2);

INSERT INTO ORGANIZACION(org_nombre,org_direccion,org_telefono,org_email,org_estado,ESTILO_est_id) VALUES('Seito Karate','Av 21, calle 3 edificio , Altamira, Caracas',2123116854,'seitokarate@gmail.com','Distrito Federal',2);

INSERT INTO ORGANIZACION(org_nombre,org_direccion,org_telefono,org_email,org_estado,ESTILO_est_id) VALUES('Sempai Karate','Av 20, calle 8 Local numero 35',2123156754,'seitokaratedo@gmail.com','Guarico',3);



INSERT INTO ESTILO(est_nombre,est_descripcion) VALUES('Cobra-do','Fusión entre Karate-Do y Kung Fu. Fundado por el Maestro Jesús López. Caracas-Venezuela.');

INSERT INTO ESTILO(est_nombre,est_descripcion) VALUES('Sistema libre de Karate','Combinación entre fusión entre Karate-Do, Taekwondo, y Kung Fu. Fundado por los Maestros Francisco Delgado y Roland Casanova en los años 80 en la Universidad Central de Venezuela - Caracas.');

INSERT INTO ESTILO(est_nombre,est_descripcion) VALUES('Shotokan','con numerosas variantes siendo la más conocida, la JKA');

INSERT INTO DOJO (doj_rif,doj_nombre,doj_telefono,doj_email,doj__logo,doj_fecha_registro,doj_status,ORGANIZACION_org_id,UBICACION_ubi_id) VALUES ('J-17280493-1','bushido',02126314625,'bushido@gmail.com','bushido.jpg','2014-11-13',1,2,2)
go

INSERT INTO DOJO (doj_rif,doj_nombre,doj_telefono,doj_email,doj__logo,doj_fecha_registro,doj_status,ORGANIZACION_org_id,UBICACION_ubi_id) VALUES ('J-13224369-3','bushido567',02123456789,'bushido34@gmail.com','bushido.jpg','2014-11-13',0,2,1)
go

INSERT INTO DOJO (doj_rif,doj_nombre,doj_telefono,doj_email,doj__logo,doj_fecha_registro,doj_status,ORGANIZACION_org_id,UBICACION_ubi_id) VALUES ('J-15403240-9','Dai-Fu',02124563322,'Dai-Fu@gmail.com','Dai-Fu.jpg','2014-10-18',1,3,4)
go

INSERT INTO DOJO (doj_rif,doj_nombre,doj_telefono,doj_email,doj__logo,doj_fecha_registro,doj_status,ORGANIZACION_org_id,UBICACION_ubi_id) VALUES ('J-18493618-8','hokuto',02126789876,'hokuto@gmail.com','hokuto.jpg','2011-11-11',1,4,3)
go

INSERT INTO DOJO (doj_rif,doj_nombre,doj_telefono,doj_email,doj__logo,doj_fecha_registro,doj_status,ORGANIZACION_org_id,UBICACION_ubi_id) VALUES ('J-11013997-1','Kaizen',02124756638,'Kaizen@gmail.com','Kaizen.jpg','2010-11-12',0,5,1)
go

INSERT INTO DOJO (doj_rif,doj_nombre,doj_telefono,doj_email,doj__logo,doj_fecha_registro,doj_status,ORGANIZACION_org_id,UBICACION_ubi_id) VALUES ('J-15374218-7','kate',02125698732,'kate@gmail.com','bushido.jpg','2014-11-13',1,2,2)
go

INSERT INTO DOJO (doj_rif,doj_nombre,doj_telefono,doj_email,doj__logo,doj_fecha_registro,doj_status,ORGANIZACION_org_id,UBICACION_ubi_id) VALUES ('J-14709720-1','karate Zen',02123456654,'karateZen@gmail.com','bushido.jpg','2014-11-13',1,2,3)
go

INSERT INTO DOJO (doj_rif,doj_nombre,doj_telefono,doj_email,doj__logo,doj_fecha_registro,doj_status,ORGANIZACION_org_id,UBICACION_ubi_id) VALUES ('J-13525491-7','Dai-Fu Manuela',02122245679,'daifu_manuela@gmail.com','Dai-Fu.jpg','2014-10-18',1,3,1)
go

INSERT INTO DOJO (doj_rif,doj_nombre,doj_telefono,doj_email,doj__logo,doj_fecha_registro,doj_status,ORGANIZACION_org_id,UBICACION_ubi_id) VALUES ('J-14795873-0','hokuto Zen',02125752632,'hokutozen@gmail.com','hokuto.jpg','2011-11-11',0,4,2)
go

INSERT INTO HISTORIAL_MATRICULA (his_mat_fecha_vigente,his_mat_modalidad,his_mat_monto,DOJO_doj_id)
VALUES ('2015-10-19','mensual',1554,1);
INSERT INTO HISTORIAL_MATRICULA (his_mat_fecha_vigente,his_mat_modalidad,his_mat_monto,DOJO_doj_id)
VALUES ('2014-2-23','mensual',1500,1);
INSERT INTO HISTORIAL_MATRICULA (his_mat_fecha_vigente,his_mat_modalidad,his_mat_monto,DOJO_doj_id)
VALUES ('2012-11-17','semestral',1300,1);
INSERT INTO HISTORIAL_MATRICULA (his_mat_fecha_vigente,his_mat_modalidad,his_mat_monto,DOJO_doj_id)
VALUES ('2011-1-21','mensual',1290,1);
INSERT INTO HISTORIAL_MATRICULA (his_mat_fecha_vigente,his_mat_modalidad,his_mat_monto,DOJO_doj_id)
VALUES ('2010-07-18','Trimestral',1100,1);
INSERT INTO HISTORIAL_MATRICULA (his_mat_fecha_vigente,his_mat_modalidad,his_mat_monto,DOJO_doj_id)
VALUES ('2015-10-19','mensual',1754,2);
INSERT INTO HISTORIAL_MATRICULA (his_mat_fecha_vigente,his_mat_modalidad,his_mat_monto,DOJO_doj_id)
VALUES ('2011-04-23','mensual',1500,2);
INSERT INTO HISTORIAL_MATRICULA (his_mat_fecha_vigente,his_mat_modalidad,his_mat_monto,DOJO_doj_id)
VALUES ('2010-11-17','semestral',1340,2);
INSERT INTO HISTORIAL_MATRICULA (his_mat_fecha_vigente,his_mat_modalidad,his_mat_monto,DOJO_doj_id)
VALUES ('2009-01-21','mensual',1290,2);
INSERT INTO HISTORIAL_MATRICULA (his_mat_fecha_vigente,his_mat_modalidad,his_mat_monto,DOJO_doj_id)
VALUES ('2006-08-18','Trimestral',500,2);
INSERT INTO HISTORIAL_MATRICULA (his_mat_fecha_vigente,his_mat_modalidad,his_mat_monto,DOJO_doj_id)
VALUES ('2015-10-19','mensual',1700,3);
INSERT INTO HISTORIAL_MATRICULA (his_mat_fecha_vigente,his_mat_modalidad,his_mat_monto,DOJO_doj_id)
VALUES ('2014-03-23','mensual',1500,3);
INSERT INTO HISTORIAL_MATRICULA (his_mat_fecha_vigente,his_mat_modalidad,his_mat_monto,DOJO_doj_id)
VALUES ('2013-11-17','semestral',1350,3);
INSERT INTO HISTORIAL_MATRICULA (his_mat_fecha_vigente,his_mat_modalidad,his_mat_monto,DOJO_doj_id)
VALUES ('2011-05-21','mensual',1200,3);
INSERT INTO HISTORIAL_MATRICULA (his_mat_fecha_vigente,his_mat_modalidad,his_mat_monto,DOJO_doj_id)
VALUES ('2010-04-18','Trimestral',1150,3);
INSERT INTO HISTORIAL_MATRICULA (his_mat_fecha_vigente,his_mat_modalidad,his_mat_monto,DOJO_doj_id)
VALUES ('2015-10-19','mensual',1554,4);
INSERT INTO HISTORIAL_MATRICULA (his_mat_fecha_vigente,his_mat_modalidad,his_mat_monto,DOJO_doj_id)
VALUES ('2014-09-23','mensual',1500,4);
INSERT INTO HISTORIAL_MATRICULA (his_mat_fecha_vigente,his_mat_modalidad,his_mat_monto,DOJO_doj_id)
VALUES ('2012-11-17','semestral',1300,4);
INSERT INTO HISTORIAL_MATRICULA (his_mat_fecha_vigente,his_mat_modalidad,his_mat_monto,DOJO_doj_id)
VALUES ('2010-04-18','Trimestral',1100,4);
INSERT INTO HISTORIAL_MATRICULA (his_mat_fecha_vigente,his_mat_modalidad,his_mat_monto,DOJO_doj_id)
VALUES ('2015-10-19','mensual',1754,5);
INSERT INTO HISTORIAL_MATRICULA (his_mat_fecha_vigente,his_mat_modalidad,his_mat_monto,DOJO_doj_id)
VALUES ('2011-12-23','mensual',1500,5);
INSERT INTO HISTORIAL_MATRICULA (his_mat_fecha_vigente,his_mat_modalidad,his_mat_monto,DOJO_doj_id)
VALUES ('2010-08-17','semestral',1340,5);
INSERT INTO HISTORIAL_MATRICULA (his_mat_fecha_vigente,his_mat_modalidad,his_mat_monto,DOJO_doj_id)
VALUES ('2009-12-21','mensual',1290,5);
INSERT INTO HISTORIAL_MATRICULA (his_mat_fecha_vigente,his_mat_modalidad,his_mat_monto,DOJO_doj_id)
VALUES ('2006-10-18','Trimestral',500,5);
INSERT INTO HISTORIAL_MATRICULA (his_mat_fecha_vigente,his_mat_modalidad,his_mat_monto,DOJO_doj_id)
VALUES ('2013-11-17','semestral',1350,6);
INSERT INTO HISTORIAL_MATRICULA (his_mat_fecha_vigente,his_mat_modalidad,his_mat_monto,DOJO_doj_id)
VALUES ('2011-06-21','mensual',1200,6);
INSERT INTO HISTORIAL_MATRICULA (his_mat_fecha_vigente,his_mat_modalidad,his_mat_monto,DOJO_doj_id)
VALUES ('2010-10-18','Trimestral',1150,6);

INSERT INTO DOJO (doj_rif,doj_nombre,doj_telefono,doj_email,doj__logo,doj_fecha_registro,doj_status,ORGANIZACION_org_id,UBICACION_ubi_id) VALUES ('J-20022094-9','Kai',02123456799,'Kai@gmail.com','Kaizen.jpg','2010-11-12',1,5,1)

INSERT INTO ORGANIZACION_CINTA(ORGANIZACION_org_id,CINTA_cin_id) VALUES(1,1);

INSERT INTO ORGANIZACION_CINTA(ORGANIZACION_org_id,CINTA_cin_id) VALUES(1,2);

INSERT INTO ORGANIZACION_CINTA(ORGANIZACION_org_id,CINTA_cin_id) VALUES(2,2);

INSERT INTO ORGANIZACION_CINTA(ORGANIZACION_org_id,CINTA_cin_id) VALUES(3,3);


/* INSERTS DEL MODULO 8*/
/*--------------------------------Restricciones de cambio de cinta--------------------------------M8---------------------------*/
/*-----------------------------------------------------------------------------------------------------------------------------*/
    INSERT INTO dbo.RESTRICCION_CINTA (
    res_cin_id,
    res_cin_descripcion,
    res_cin_tiemp_min,
    res_cin_punt_min,
    res_cin_horas_docent,
    CINTA_cin_id
    ) 
    VALUES (1,"BLANCA A AMARILLA",3,0,0,2);
    
    INSERT INTO dbo.RESTRICCION_CINTA (
    res_cin_id,
    res_cin_descripcion,
    res_cin_tiemp_min,
    res_cin_punt_min,
    res_cin_horas_docent,
    CINTA_cin_id
    ) 
    VALUES (2,"AMARILLA A NARANJA",5,8,0,3);
    
    INSERT INTO dbo.RESTRICCION_CINTA (
    res_cin_id,
    res_cin_descripcion,
    res_cin_tiemp_min,
    res_cin_punt_min,
    res_cin_horas_docent,
    CINTA_cin_id
    ) 
    VALUES (3,"NARANJA A VERDE",7,20,0,4);
    
    INSERT INTO dbo.RESTRICCION_CINTA (
    res_cin_id,
    res_cin_descripcion,
    res_cin_tiemp_min,
    res_cin_punt_min,
    res_cin_horas_docent,
    CINTA_cin_id
    ) 
    VALUES (4,"VERDE A AZUL",10,25,2,5);
    
    INSERT INTO dbo.RESTRICCION_CINTA (
    res_cin_id,
    res_cin_descripcion,
    res_cin_tiemp_min,
    res_cin_punt_min,
    res_cin_horas_docent,
    CINTA_cin_id
    ) 
    VALUES (5,"AZUL A MARRON",10,30,4,6);
    
    INSERT INTO dbo.RESTRICCION_CINTA (
    res_cin_id,
    res_cin_descripcion,
    res_cin_tiemp_min,
    res_cin_punt_min,
    res_cin_horas_docent,
    CINTA_cin_id
    ) 
    VALUES (6,"MARRON A MARRON",12,40,7,7);
    
    INSERT INTO dbo.RESTRICCION_CINTA (
    res_cin_id,
    res_cin_descripcion,
    res_cin_tiemp_min,
    res_cin_punt_min,
    res_cin_horas_docent,
    CINTA_cin_id
    ) 
    VALUES (7,"MARRON A NEGRA",12,50,9,8);

    



-- =========================================================================--
-- Inserts RESTRICCION_COMPETENCIA                           M8               --
-- =========================================================================--
INSERT INTO [dbo].[RESTRICCION_COMPETENCIA] ([res_com_desc], [res_com_edad_min], [res_com_edad_max], [res_com_sexo], [res_com_modalidad]) VALUES
('Rest. Competencia de 12 a 17 años todas las cintas unisex Kata',12,17,'B','Todas');

INSERT INTO [dbo].[RESTRICCION_COMPETENCIA] ([res_com_desc], [res_com_edad_min], [res_com_edad_max], [res_com_sexo], [res_com_modalidad]) VALUES
('Rest. Competencia de 6 a 11 años todas las cintas unisex Kata',6,11,'B','kata');

INSERT INTO [dbo].[RESTRICCION_COMPETENCIA] ([res_com_desc], [res_com_edad_min], [res_com_edad_max], [res_com_sexo], [res_com_modalidad]) VALUES
('Rest. Competencia de 18 a 25 años todas las cintas unisex Kata',18,25,'B','Todas');
-- =========================================================================--
-- Inserts COMP_REST_COMP                                    M8               --
-- =========================================================================--
INSERT INTO [dbo].[COMP_REST_COMP] (comp_rest_comp_id,RESTRICCION_COMPETENCIA_res_com_id,COMPETENCIA_comp_id) VALUES
(1,1);

INSERT INTO [dbo].[COMP_REST_COMP] (comp_rest_comp_id,RESTRICCION_COMPETENCIA_res_com_id,COMPETENCIA_comp_id) VALUES
(1,2);

INSERT INTO [dbo].[COMP_REST_COMP] (comp_rest_comp_id,RESTRICCION_COMPETENCIA_res_com_id,COMPETENCIA_comp_id) VALUES
(1,3);

INSERT INTO [dbo].[COMP_REST_COMP] (comp_rest_comp_id,RESTRICCION_COMPETENCIA_res_com_id,COMPETENCIA_comp_id) VALUES
(1,4);

INSERT INTO [dbo].[COMP_REST_COMP] (comp_rest_comp_id,RESTRICCION_COMPETENCIA_res_com_id,COMPETENCIA_comp_id) VALUES
(2,1);

INSERT INTO [dbo].[COMP_REST_COMP] (comp_rest_comp_id,RESTRICCION_COMPETENCIA_res_com_id,COMPETENCIA_comp_id) VALUES
(2,2);

-- =========================================================================--
-- Inserts RC_CINTA                                       M8           --
-- =========================================================================--
INSERT INTO [dbo].[RC_CINTA] (comp_rest_comp_id,RESTRICCION_COMPETENCIA_res_com_id,CINTA_cin_id) VALUES
(1,1);

INSERT INTO [dbo].[RC_CINTA] (comp_rest_comp_id,RESTRICCION_COMPETENCIA_res_com_id,CINTA_cin_id) VALUES
(1,2);

INSERT INTO [dbo].[RC_CINTA] (comp_rest_comp_id,RESTRICCION_COMPETENCIA_res_com_id,CINTA_cin_id) VALUES
(1,3);

INSERT INTO [dbo].[RC_CINTA] (comp_rest_comp_id,RESTRICCION_COMPETENCIA_res_com_id,CINTA_cin_id) VALUES
(1,4);

INSERT INTO [dbo].[RC_CINTA] (comp_rest_comp_id,RESTRICCION_COMPETENCIA_res_com_id,CINTA_cin_id) VALUES
(2,5);

INSERT INTO [dbo].[RC_CINTA] (comp_rest_comp_id,RESTRICCION_COMPETENCIA_res_com_id,CINTA_cin_id) VALUES
(2,6);

INSERT INTO [dbo].[RC_CINTA] (comp_rest_comp_id,RESTRICCION_COMPETENCIA_res_com_id,CINTA_cin_id) VALUES
(2,1);

INSERT INTO [dbo].[RC_CINTA] (comp_rest_comp_id,RESTRICCION_COMPETENCIA_res_com_id,CINTA_cin_id) VALUES
(2,2);


-- =========================================================================--
-- Inserts RESTRICCION_EVENTO  (descripcion,edadMIN,edadMAX,sexo)    M8     --
-- =========================================================================--
insert into RESTRICCION_EVENTO values ('Rest. evento evento1 de 18 a 25 años solo masculino',18,25,'m');
insert into RESTRICCION_EVENTO values ('Rest. evento evento2 de 18 a 20 años solo femenino',18,20,'f');
insert into RESTRICCION_EVENTO values ('Rest. evento evento3 de 20 a 25 años sexo combinado',20,25,'c');
insert into RESTRICCION_EVENTO values ('Rest. evento evento4 de 20 a 25 años sexo combinado',20,25,'c');

-- =========================================================================--
-- Inserts EVENTO_RESTRICCION  (evento id, restriccionEve id)        M8     --
-- =========================================================================--
insert into EVENTO_RESTRICCION values (1,1);
insert into EVENTO_RESTRICCION values (2,3);
insert into EVENTO_RESTRICCION values (3,2);
insert into EVENTO_RESTRICCION values (4,4);

-- =========================================================================--
-- Inserts RH_CINTA   (restriccionEve id, cinta id)                  M8     --
-- =========================================================================--
-- FALTA INSERT DE CINTA PARA COMPLETAR --
insert into RH_CINTA values (1,1);
insert into RH_CINTA values (1,2);
insert into RH_CINTA values (2,2);
insert into RH_CINTA values (2,3);
insert into RH_CINTA values (3,4);
insert into RH_CINTA values (4,5);
insert into RH_CINTA values (4,7);


-- =========================================================================--
-- Inserts RESTRICCION_COMPETENCIA                                          --
-- =========================================================================--
INSERT INTO [dbo].[RESTRICCION_COMPETENCIA] ([res_com_desc], [res_com_edad_min], [res_com_edad_max], [res_com_sexo], [res_com_modalidad]) VALUES
('Rest. Competencia de 12 a 17 años todas las cintas unisex Kata',12,17,'B','Todas');

INSERT INTO [dbo].[RESTRICCION_COMPETENCIA] ([res_com_desc], [res_com_edad_min], [res_com_edad_max], [res_com_sexo], [res_com_modalidad]) VALUES
('Rest. Competencia de 6 a 11 años todas las cintas unisex Kata',6,11,'B','kata');

INSERT INTO [dbo].[RESTRICCION_COMPETENCIA] ([res_com_desc], [res_com_edad_min], [res_com_edad_max], [res_com_sexo], [res_com_modalidad]) VALUES
('Rest. Competencia de 18 a 25 años todas las cintas unisex Kata',18,25,'B','Todas');
-- =========================================================================--
-- Inserts COMP_REST_COMP                                                   --
-- =========================================================================--
INSERT INTO [dbo].[COMP_REST_COMP] (comp_rest_comp_id,RESTRICCION_COMPETENCIA_res_com_id,COMPETENCIA_comp_id) VALUES
(1,1);

INSERT INTO [dbo].[COMP_REST_COMP] (comp_rest_comp_id,RESTRICCION_COMPETENCIA_res_com_id,COMPETENCIA_comp_id) VALUES
(1,2);

INSERT INTO [dbo].[COMP_REST_COMP] (comp_rest_comp_id,RESTRICCION_COMPETENCIA_res_com_id,COMPETENCIA_comp_id) VALUES
(1,3);

INSERT INTO [dbo].[COMP_REST_COMP] (comp_rest_comp_id,RESTRICCION_COMPETENCIA_res_com_id,COMPETENCIA_comp_id) VALUES
(1,4);

INSERT INTO [dbo].[COMP_REST_COMP] (comp_rest_comp_id,RESTRICCION_COMPETENCIA_res_com_id,COMPETENCIA_comp_id) VALUES
(2,1);

INSERT INTO [dbo].[COMP_REST_COMP] (comp_rest_comp_id,RESTRICCION_COMPETENCIA_res_com_id,COMPETENCIA_comp_id) VALUES
(2,2);

-- =========================================================================--
-- Inserts RC_CINTA                                                  --
-- =========================================================================--
INSERT INTO [dbo].[RC_CINTA] (comp_rest_comp_id,RESTRICCION_COMPETENCIA_res_com_id,CINTA_cin_id) VALUES
(1,1);

INSERT INTO [dbo].[RC_CINTA] (comp_rest_comp_id,RESTRICCION_COMPETENCIA_res_com_id,CINTA_cin_id) VALUES
(1,2);

INSERT INTO [dbo].[RC_CINTA] (comp_rest_comp_id,RESTRICCION_COMPETENCIA_res_com_id,CINTA_cin_id) VALUES
(1,3);

INSERT INTO [dbo].[RC_CINTA] (comp_rest_comp_id,RESTRICCION_COMPETENCIA_res_com_id,CINTA_cin_id) VALUES
(1,4);

INSERT INTO [dbo].[RC_CINTA] (comp_rest_comp_id,RESTRICCION_COMPETENCIA_res_com_id,CINTA_cin_id) VALUES
(2,5);

INSERT INTO [dbo].[RC_CINTA] (comp_rest_comp_id,RESTRICCION_COMPETENCIA_res_com_id,CINTA_cin_id) VALUES
(2,6);

INSERT INTO [dbo].[RC_CINTA] (comp_rest_comp_id,RESTRICCION_COMPETENCIA_res_com_id,CINTA_cin_id) VALUES
(2,1);

INSERT INTO [dbo].[RC_CINTA] (comp_rest_comp_id,RESTRICCION_COMPETENCIA_res_com_id,CINTA_cin_id) VALUES
(2,2);

INSERT INTO INSCRIPCION VALUES (1,,'17/12/1992',NULL,NULL);

INSERT INTO INSCRIPCION VALUES (2,,'11/07/2000',NULL,NULL);

INSERT INTO INSCRIPCION VALUES (3,,'02/01/1990',NULL,NULL);

INSERT INTO INSCRIPCION VALUES (4,,'21/06/1989',NULL,NULL);

INSERT INTO INSCRIPCION VALUES (5,,'04/04/1982',NULL,NULL);

INSERT INTO INSCRIPCION VALUES (6,,'19/05/2000',NULL,NULL);

INSERT INTO INSCRIPCION VALUES (7,,'21/11/1991',NULL,NULL);

INSERT INTO INSCRIPCION VALUES (8,,'12/08/1988',NULL,NULL);

/*Se deben agregar los ID de las personas, ya que para este momento
no se contaba con esa informacion */

-- INSERTS UBICACION --
INSERT INTO [dbo].[UBICACION] ([ubi_latitud], [ubi_longitud], [ubi_ciudad], [ubi_estado], [ubi_direccion]) VALUES ('10.499607', '-66.788419', 'Caracas', 'Miranda', null)
go

INSERT INTO [dbo].[UBICACION] ([ubi_latitud], [ubi_longitud], [ubi_ciudad], [ubi_estado], [ubi_direccion]) VALUES ('10.062028', '-69.4328889', 'Barquisimeto', 'Lara', null)
go

INSERT INTO [dbo].[UBICACION] ([ubi_latitud], [ubi_longitud], [ubi_ciudad], [ubi_estado], [ubi_direccion]) VALUES ('10.1727434', '-68.0642649', 'Valencia', 'Carabobo', null)
go

INSERT INTO [dbo].[UBICACION] ([ubi_latitud], [ubi_longitud], [ubi_ciudad], [ubi_estado], [ubi_direccion]) VALUES ('10.2673453', '-67.6754515', 'Maracay', 'Aragua', null)
go

INSERT INTO [dbo].[UBICACION] ([ubi_latitud], [ubi_longitud], [ubi_ciudad], [ubi_estado], [ubi_direccion]) VALUES ('10.6338776', '-71.8170448', 'Maracaibo', 'Zulia', null)
go

-- INSERTS CATEGORIA --
INSERT INTO [dbo].[CATEGORIA] ([cat_edad_ini], [cat_edad_fin], [cat_cinta_ini], [cat_cinta_fin], [cat_sexo]) VALUES (10,15,'Blanca','Naranja','M')
go

INSERT INTO [dbo].[CATEGORIA] ([cat_edad_ini], [cat_edad_fin], [cat_cinta_ini], [cat_cinta_fin], [cat_sexo]) VALUES (10,15,'Blanca','Naranja','F')
go

INSERT INTO [dbo].[CATEGORIA] ([cat_edad_ini], [cat_edad_fin], [cat_cinta_ini], [cat_cinta_fin], [cat_sexo]) VALUES (10,15,'Azul Celeste','Purpura','M')
go

INSERT INTO [dbo].[CATEGORIA] ([cat_edad_ini], [cat_edad_fin], [cat_cinta_ini], [cat_cinta_fin], [cat_sexo]) VALUES (10,15,'Azul Celeste','Purpura','F')
go

INSERT INTO [dbo].[CATEGORIA] ([cat_edad_ini], [cat_edad_fin], [cat_cinta_ini], [cat_cinta_fin], [cat_sexo]) VALUES (10,15,'Naranja','Verde','M')
go

INSERT INTO [dbo].[CATEGORIA] ([cat_edad_ini], [cat_edad_fin], [cat_cinta_ini], [cat_cinta_fin], [cat_sexo]) VALUES (10,15,'Naranja','Verde','F')
go

INSERT INTO [dbo].[CATEGORIA] ([cat_edad_ini], [cat_edad_fin], [cat_cinta_ini], [cat_cinta_fin], [cat_sexo]) VALUES (10,15,'Amarilla','Purpura','M')
go

INSERT INTO [dbo].[CATEGORIA] ([cat_edad_ini], [cat_edad_fin], [cat_cinta_ini], [cat_cinta_fin], [cat_sexo]) VALUES (10,15,'Amarilla','Purpura','F')
go

INSERT INTO [dbo].[CATEGORIA] ([cat_edad_ini], [cat_edad_fin], [cat_cinta_ini], [cat_cinta_fin], [cat_sexo]) VALUES (10,15,'Azul Oscuro','Marron','M')
go

INSERT INTO [dbo].[CATEGORIA] ([cat_edad_ini], [cat_edad_fin], [cat_cinta_ini], [cat_cinta_fin], [cat_sexo]) VALUES (10,15,'Azul Oscuro','Marron','F')
go

--COMPETENCIA--

INSERT INTO [dbo].[COMPETENCIA] ( [comp_nombre], [comp_tipo], [comp_org_todas], [comp_status], [comp_fecha_ini], [comp_fecha_fin], [UBICACION_comp_id], [CATEGORIA_comp_id], [ORGANIZACION_comp_id], [comp_costo]) 
VALUES (N'Ryu Kobudo', 1, 1, N'Por Iniciar', N'2016-10-25 00:00:00', N'2016-10-27 00:00:00', 3, 4, NULL,1500)
go

INSERT INTO [dbo].[COMPETENCIA] ( [comp_nombre], [comp_tipo], [comp_org_todas], [comp_status], [comp_fecha_ini], [comp_fecha_fin], [UBICACION_comp_id], [CATEGORIA_comp_id], [ORGANIZACION_comp_id], [comp_costo]) 
VALUES (N'Kobudo', 2, 1, N'Por Iniciar', N'2016-09-01 00:00:00', N'2016-09-03 00:00:00', 1, 1, NULL,1100)
go
INSERT INTO [dbo].[COMPETENCIA] ( [comp_nombre], [comp_tipo], [comp_org_todas], [comp_status], [comp_fecha_ini], [comp_fecha_fin], [UBICACION_comp_id], [CATEGORIA_comp_id], [ORGANIZACION_comp_id], [comp_costo]) 
VALUES (N'Doo Kan', 2, 0, N'Por Iniciar', N'2016-10-15 00:00:00', N'2016-10-18 00:00:00', 1, 2, 1,900)
go
INSERT INTO [dbo].[COMPETENCIA] ( [comp_nombre], [comp_tipo], [comp_org_todas], [comp_status], [comp_fecha_ini], [comp_fecha_fin], [UBICACION_comp_id], [CATEGORIA_comp_id], [ORGANIZACION_comp_id], [comp_costo]) 
VALUES (N'Yodan Ryu', 1, 0, N'Por Iniciar', N'2016-05-20 00:00:00', N'2016-05-23 00:00:00', 2, 3, 1,1000)
go
INSERT INTO [dbo].[COMPETENCIA] ( [comp_nombre], [comp_tipo], [comp_org_todas], [comp_status], [comp_fecha_ini], [comp_fecha_fin], [UBICACION_comp_id], [CATEGORIA_comp_id], [ORGANIZACION_comp_id], [comp_costo]) 
VALUES (N'Shito Ryu', 1, 0, N'Por Iniciar', N'2016-06-20 00:00:00', N'2016-06-23 00:00:00', 2, 3, 2,900)
go
INSERT INTO [dbo].[COMPETENCIA] ( [comp_nombre], [comp_tipo], [comp_org_todas], [comp_status], [comp_fecha_ini], [comp_fecha_fin], [UBICACION_comp_id], [CATEGORIA_comp_id], [ORGANIZACION_comp_id], [comp_costo]) 
VALUES (N'Inoue Ha', 1, 0, N'Por Iniciar', N'2016-03-19 00:00:00', N'2016-05-21 00:00:00', 2, 3, 3,1200)
go
INSERT INTO [dbo].[COMPETENCIA] ( [comp_nombre], [comp_tipo], [comp_org_todas], [comp_status], [comp_fecha_ini], [comp_fecha_fin], [UBICACION_comp_id], [CATEGORIA_comp_id], [ORGANIZACION_comp_id], [comp_costo]) 
VALUES (N'Shoosei Kai', 1, 0, N'Por Iniciar', N'2016-01-10 00:00:00', N'2016-05-11 00:00:00', 2, 3, 4,1800)
go

--DOJO--
INSERT INTO DOJO VALUES (1,'J30767662-0','Dojo San Antonio',2128313743,'sanantonio@gmail.com','verde',CONVERT(datetime, '2015-10-09', 101),1,1,1);
INSERT INTO DOJO VALUES (2,'J30767643-0','Dojo Budokan Venezuela',2129760890,'budokan@gmail.com','rojo',CONVERT(datetime, '2014-10-12', 101),1,2,2);
INSERT INTO DOJO VALUES (3,'J30907662-0','Dojo USB',143202838,'usb@gmail.com','azul',CONVERT(datetime, '2010-05-14', 101),1,3,3);


--MATRICULA--
INSERT INTO MATRICULA VALUES ('121',CONVERT(datetime,'2010-08-26',101),1,CONVERT(datetime,'2015-10-26',101),1,1);
INSERT INTO MATRICULA VALUES ('122',CONVERT(datetime,'2011-07-12',101),1,CONVERT(datetime,'2015-09-26',101),2,1);
INSERT INTO MATRICULA VALUES ('123',CONVERT(datetime,'2012-06-13',101),1,CONVERT(datetime,'2015-05-26',101),3,1);
INSERT INTO MATRICULA VALUES ('124',CONVERT(datetime,'2013-05-26',101),1,CONVERT(datetime,'2015-11-26',101),3,2);
INSERT INTO MATRICULA VALUES ('125',CONVERT(datetime,'2014-02-12',101),1,CONVERT(datetime,'2015-09-26',101),4,2);
INSERT INTO MATRICULA VALUES ('126',CONVERT(datetime,'2015-01-13',101),1,CONVERT(datetime,'2015-06-26',101),5,2);
INSERT INTO MATRICULA VALUES ('127',CONVERT(datetime,'2010-08-26',101),1,CONVERT(datetime,'2015-04-12',101),6,3);
INSERT INTO MATRICULA VALUES ('128',CONVERT(datetime,'2013-05-12',101),1,CONVERT(datetime,'2015-08-28',101),7,3);
INSERT INTO MATRICULA VALUES ('129',CONVERT(datetime,'2012-04-13',101),1,CONVERT(datetime,'2015-10-15',101),8,3);


--HIST_MATRICULA--

INSERT INTO HISTORIAL_MATRICULA VALUES (CONVERT(datetime, '2015-11-10', 101),'mensualidad','3250',1);
INSERT INTO HISTORIAL_MATRICULA VALUES (CONVERT(datetime, '2013-09-10', 101),'mensualidad','2200',2);
INSERT INTO HISTORIAL_MATRICULA VALUES (CONVERT(datetime, '2012-02-10', 101),'mensualidad','2000',3);


--RESULTADO_KUMITE--

INSERT INTO RESULTADO_KUMITE VALUES (1,20,30,1,2);
INSERT INTO RESULTADO_KUMITE VALUES (2,40,55,1,2);
INSERT INTO RESULTADO_KUMITE VALUES (3,15,20,2,3);
INSERT INTO RESULTADO_KUMITE VALUES (4,20,10,2,3);
INSERT INTO RESULTADO_KUMITE VALUES (5,10,15,3,4);
INSERT INTO RESULTADO_KUMITE VALUES (6,40,50,3,4);
INSERT INTO RESULTADO_KUMITE VALUES (7,35,30,4,5);
INSERT INTO RESULTADO_KUMITE VALUES (8,40,30,4,5);
INSERT INTO RESULTADO_KUMITE VALUES (9,10,20,5,6);
INSERT INTO RESULTADO_KUMITE VALUES (10,25,35,5,6);
INSERT INTO RESULTADO_KUMITE VALUES (11,20,15,6,7);
INSERT INTO RESULTADO_KUMITE VALUES (12,30,40,6,7);
INSERT INTO RESULTADO_KUMITE VALUES (13,35,45,7,8);
INSERT INTO RESULTADO_KUMITE VALUES (14,20,40,7,8);
INSERT INTO RESULTADO_KUMITE VALUES (15,30,35,8,9);
INSERT INTO RESULTADO_KUMITE VALUES (16,40,35,8,9);



-----HISTORIAL_CINTAS----------

INSERT INTO HISTORIAL_CINTAS VALUES (1,1,CONVERT(datetime,'2015-10-22',101),1);
INSERT INTO HISTORIAL_CINTAS VALUES (2,2,CONVERT(datetime,'2015-06-12',101),2);
INSERT INTO HISTORIAL_CINTAS VALUES (3,3,CONVERT(datetime,'2015-08-21',101),3);
INSERT INTO HISTORIAL_CINTAS VALUES (4,4,CONVERT(datetime,'2015-11-22',101),4);
INSERT INTO HISTORIAL_CINTAS VALUES (5,5,CONVERT(datetime,'2015-05-12',101),5);




INSERT INTO [dbo].[CINTA] ([cin_color_nombre], [cin_rango], [cin_clasificacion], [cin_significado], [cin_orden], [RESTRICCION_CINTA_res_cin_id]) VALUES ('Blanco', '1er Kyu', 'Nivel inferior', 'Principiante', 1,1);

INSERT INTO [dbo].[CINTA] ([cin_color_nombre], [cin_rango], [cin_clasificacion], [cin_significado], [cin_orden], [RESTRICCION_CINTA_res_cin_id]) VALUES ('Amarillo', '2do Kyu', 'Nivel inferior', 'Iniciado', 2,2);

INSERT INTO [dbo].[CINTA] ([cin_color_nombre], [cin_rango], [cin_clasificacion], [cin_significado], [cin_orden], [RESTRICCION_CINTA_res_cin_id]) VALUES ('Verde', '3er Kyu', 'Nivel inferior', 'Aprendiz', 3,3);

INSERT INTO [dbo].[CINTA] ([cin_color_nombre], [cin_rango], [cin_clasificacion], [cin_significado], [cin_orden], [RESTRICCION_CINTA_res_cin_id]) VALUES ('Marron', '8vo Kyu', 'Nivel inferior', 'Aprendiz avanzado', 4,4);

INSERT INTO [dbo].[CINTA] ([cin_color_nombre], [cin_rango], [cin_clasificacion], [cin_significado], [cin_orden], [RESTRICCION_CINTA_res_cin_id]) VALUES ('Negro', '1er Dan', 'Nivel superior', 'Avanzado', 1,5);

INSERT INTO [dbo].[CINTA] ([cin_color_nombre], [cin_rango], [cin_clasificacion], [cin_significado], [cin_orden], [RESTRICCION_CINTA_res_cin_id]) VALUES ('Negro', '2do Dan', 'Nivel superior', 'Maestro iniciado', 2,6);

INSERT INTO [dbo].[CINTA] ([cin_color_nombre], [cin_rango], [cin_clasificacion], [cin_significado], [cin_orden], [RESTRICCION_CINTA_res_cin_id]) VALUES ('Negro', '3er Kyu', 'Nivel superior', 'Maestro medio', 3,7);

INSERT INTO [dbo].[CINTA] ([cin_color_nombre], [cin_rango], [cin_clasificacion], [cin_significado], [cin_orden], [RESTRICCION_CINTA_res_cin_id]) VALUES ('Negro', '4to Kyu', 'Nivel superior', 'Maestro superior', 4,8);

































update PERSONA set per_clave='5ae2bacffebdf3e8e37decdd343ac728';

    