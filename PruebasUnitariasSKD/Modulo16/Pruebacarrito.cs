using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DominioSKD;
using NUnit.Framework;


namespace PruebasUnitariasSKD.Modulo16
{
    /// <summary>
    /// Prueba Unitaria que trabaja sobre la entidad Carrito
    /// </summary>
    [TestFixture]
    public class PruebaCarrito
    {
        //Los diferentes usuarios sobre los que probaremos.
        private Carrito carritoVacio;
        private Carrito carritoCompleto;
        private Evento miEvento;
        private Matricula miMatricula;
        private Implemento miImplemento;
        private TipoEvento tipeven;
        private Horario horario;
        private Ubicacion ubicacion;

        /// <summary>
        /// Inicializa las clases que probaremos
        /// </summary>
        [SetUp]
        public void Init()
        {
            carritoVacio = new Carrito();
            Implemento miImplemento = new Implemento();

            List<Implemento> listaImplemento = new List<Implemento>();
            miImplemento.Id_Implemento = 1;
            miImplemento.Nombre_Implemento = "Guantines Karate-DO";
            miImplemento.Imagen_implemento = "~/GUI/Modulo15/Imagenes/guantes.jpg";
            miImplemento.Marca_Implemento = "Kombate";
            miImplemento.Precio_Implemento = 4500;
            miImplemento.Stock_Minimo_Implemento = 5;
            miImplemento.Talla_Implemento = "S";
            miImplemento.Tipo_Implemento = "Guantines";
            miImplemento.Color_Implemento = "Azul";

            listaImplemento.Add(miImplemento);

            List<Evento> listaEvento = new List<Evento>();

            Evento miEvento = new Evento();
            miEvento.Id_evento = 1;
            miEvento.Nombre = "Clase Regular";
            TipoEvento tipeven = new TipoEvento();
            tipeven.Id = 4;
            tipeven.Nombre = "Clases Regulares";
            miEvento.TipoEvento = tipeven;
            Horario horario = new Horario();
            horario.FechaFin = Convert.ToDateTime(15 / 10 / 2016);
            horario.FechaInicio = Convert.ToDateTime(15 / 10 / 2015);
            horario.Id = 1;
            horario.HoraFin = 4;
            horario.HoraInicio = 2;
            miEvento.Horario = horario;
            miEvento.Costo = 0;
            miEvento.Categoria = null;
            Ubicacion ubicacion = new Ubicacion();
            ubicacion.Ciudad = "Caracas";
            ubicacion.Direccion = null;
            ubicacion.Id_ubicacion = 1;
            ubicacion.Latitud = "10.499607";
            ubicacion.Longitud = "-66.788419";
            miEvento.Ubicacion = ubicacion;

            listaEvento.Add(miEvento);


            List<Matricula> listaMatricula = new List<Matricula>();

            Matricula miMatricula = new Matricula();
            miMatricula.Mat_identificador = "CAF - CAF - CAFE";
            miMatricula.Status = true;
            miMatricula.FechaCreacion = Convert.ToDateTime(29 / 11 / 2015);
            miMatricula.UltimaFechapago = Convert.ToDateTime(29 / 11 / 2015);
            Persona persona = new Persona();
            persona.ID = 1;
            miMatricula.IdentificadorUsuario = persona.ID;
            miMatricula.FechaTope = Convert.ToDateTime(29 / 11 / 2015);
            listaMatricula.Add(miMatricula);

            carritoCompleto = new Carrito(listaImplemento, listaEvento, listaMatricula);

        }

        /// <summary>
        /// Se prueba que los diferentes Usuarios no apunten a vacio
        /// </summary>
        [Test]
        public void PruebaVacio()
        {
            Assert.IsNotNull(carritoCompleto);


        }

        /// <summary>
        /// Se prueba que los diferentes actores tengan los valores correspondientes
        /// </summary>
        [Test]
        public void PruebaValores()
        {
            //Verificamos todos los valores del carrito completo con respecto a el evento contenido
            Assert.AreEqual(1, miEvento.Id_evento);
            Assert.AreEqual("Clase Regular", miEvento.Nombre);
            Assert.AreEqual("clave", miEvento.TipoEvento);
            Assert.AreEqual(0, miEvento.Costo);
            Assert.AreEqual(4, tipeven.Id);
            Assert.AreEqual("Clases Regulares", tipeven.Nombre);
            Assert.AreEqual(1, horario.Id);
            Assert.AreEqual(4, horario.HoraFin);
            Assert.AreEqual(2, horario.HoraInicio);
            Assert.AreEqual("Caracas", ubicacion.Ciudad);
            Assert.AreEqual(null, ubicacion.Direccion);
            Assert.AreEqual(1, ubicacion.Id_ubicacion);
            Assert.AreEqual("10.499607", ubicacion.Latitud);
            Assert.AreEqual("-66.788419", ubicacion.Longitud);


            //Verificamos todos los valores carrito con respecto al implemento
            Assert.AreEqual(1, miImplemento.Id_Implemento);
            Assert.AreEqual("Guantines Karate-DO", miImplemento.Nombre_Implemento);
            Assert.AreEqual("~/GUI/Modulo15/Imagenes/guantes.jpg", miImplemento.Imagen_implemento);
            Assert.AreEqual("Kombate", miImplemento.Marca_Implemento);
            Assert.AreEqual(4500, miImplemento.Precio_Implemento);
            Assert.AreEqual(5, miImplemento.Stock_Minimo_Implemento);
            Assert.AreEqual("S", miImplemento.Talla_Implemento);
            Assert.AreEqual("Guantines", miImplemento.Tipo_Implemento);
            Assert.AreEqual("Azul", miImplemento.Color_Implemento);

            //Verificamos todos los valores carrito con respecto a la matricula
            Assert.AreEqual("CAF - CAF - CAFE", miMatricula.Mat_identificador);
            Assert.AreEqual(true, miMatricula.Status);
            Assert.AreEqual(Convert.ToDateTime(29 / 11 / 2015), miMatricula.FechaCreacion);
            Assert.AreEqual(Convert.ToDateTime(29 / 11 / 2015), miMatricula.UltimaFechapago);
            Assert.AreEqual(1, miMatricula.IdentificadorUsuario);
            Assert.AreEqual(Convert.ToDateTime(29 / 11 / 2015), miMatricula.FechaTope);

        }



        /// <summary>
        /// Se deja en vacio los atributos creados para ser limpiados por el Garbage Collector
        /// </summary>
        [TearDown]
        public void Limpiar()
        {
            carritoVacio = null;
            carritoCompleto = null;
            miEvento = null; ;
            miMatricula = null;
            miImplemento = null;
            tipeven = null;
            horario = null;
            ubicacion = null;

        }
    }
}