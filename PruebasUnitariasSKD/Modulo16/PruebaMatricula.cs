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
    public class PruebaMatricula
    {
        //Los diferentes usuarios sobre los que probaremos.

        private Matricula miMatricula;


        /// <summary>
        /// Inicializa las clases que probaremos
        /// </summary>
        [SetUp]
        public void Init()
        {
            Matricula miMatricula = new Matricula();
            miMatricula.Identificador = "CAF - CAF - CAFE";
        
            miMatricula.FechaCreacion = Convert.ToDateTime(29 / 11 / 2015);
            miMatricula.UltimaFechaPago = Convert.ToDateTime(29 / 11 / 2015);
            Persona persona = new Persona();
            persona.ID = 1;
           
             
        }

        /// <summary>
        /// Se prueba que los diferentes Usuarios no apunten a vacio
        /// </summary>
        [Test]
        public void PruebaVacio()
        {
            Assert.IsNotNull(miMatricula);


        }

        /// <summary>
        /// Se prueba que los diferentes actores tengan los valores correspondientes
        /// </summary>
        [Test]
        public void PruebaValores()
        {
            //Verificamos todos los valores carrito con respecto a la matricula
            Assert.AreEqual("CAF - CAF - CAFE", miMatricula.Identificador);
            
            Assert.AreEqual(Convert.ToDateTime(29 / 11 / 2015), miMatricula.FechaCreacion);
            Assert.AreEqual(Convert.ToDateTime(29 / 11 / 2015), miMatricula.UltimaFechaPago);
           
            
        }



        /// <summary>
        /// Se deja en vacio los atributos creados para ser limpiados por el Garbage Collector
        /// </summary>
        [TearDown]
        public void Limpiar()
        {
            miMatricula = null;
        }
    }
}