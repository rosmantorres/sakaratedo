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
    public class PruebaEvento
    {
        //Los diferentes usuarios sobre los que probaremos.

        private Evento miEvento;
        private TipoEvento tipeven;
        private Horario horario;
        private Ubicacion ubicacion;

        /// <summary>
        /// Inicializa las clases que probaremos
        /// </summary>
        [SetUp]
        public void Init()
        {
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


        }

        /// <summary>
        /// Se prueba que los diferentes Usuarios no apunten a vacio
        /// </summary>
        [Test]
        public void PruebaVacio()
        {
            Assert.IsNotNull(miEvento);


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



        }



        /// <summary>
        /// Se deja en vacio los atributos creados para ser limpiados por el Garbage Collector
        /// </summary>
        [TearDown]
        public void Limpiar()
        {

            miEvento = null; ;

        }
    }
}