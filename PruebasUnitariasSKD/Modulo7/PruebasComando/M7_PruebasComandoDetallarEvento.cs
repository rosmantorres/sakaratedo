using DominioSKD;
using DominioSKD.Fabrica;
using ExcepcionesSKD.Modulo7;
using LogicaNegociosSKD.Comandos.Modulo7;
using LogicaNegociosSKD.Fabrica;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD.Entidades.Modulo7;

namespace PruebasUnitariasSKD.Modulo7.PruebasComando
{
    /// <summary>
    /// Clase que contiene las pruebas unitarias para el comando detallar evento de atleta
    /// </summary>
    [TestFixture]
    public class M7_PruebasComandoDetallarEvento
    {
        #region Atributos
        private EventoM7 idEvento;
        private FabricaComandos fabricaComandos;
        private ComandoConsultarDetallarEvento detalleEvento;
        #endregion

        #region SetUp & TearDown
        /// <summary>
        /// Método que se ejecuta antes de cada prueba
        /// </summary>
        [SetUp]
        public void Init()
        {
            fabricaComandos = new FabricaComandos();
            detalleEvento = (ComandoConsultarDetallarEvento)fabricaComandos.ObtenerComandoConsultarDetallarEvento();
            idEvento = (EventoM7)FabricaEntidades.ObtenerEventoM7();
            idEvento.Id = 2;
            detalleEvento.LaEntidad = idEvento;
        }

        /// <summary>
        /// Método que se ejecuta despues de cada prueba
        /// </summary>
        [TearDown]
        public void Clean()
        {
            fabricaComandos = null;
            detalleEvento = null;
            idEvento = null;
        }
        #endregion

        #region Test
        /// <summary>
        /// Método para probar que el evento obtenido no esta vacio
        /// </summary>
        [Test]
        public void PruebaEvento()
        {
            EventoM7 evento = (EventoM7)detalleEvento.Ejecutar();
            Assert.GreaterOrEqual("Entrenamiento 2", evento.Nombre);
        }

        /// <summary>
        /// Método para probar que el evento obtenido no es nulo
        /// </summary>
        [Test]
        public void PruebaEventoNoNulo()
        {
            EventoM7 evento = (EventoM7)detalleEvento.Ejecutar();
            Assert.IsNotNull(evento);
        }

        /// <summary>
        /// Método para probar la excepcion de número entero invalido en detallar evento
        /// </summary>
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void DetallarEventoNumeroEnteroException()
        {
            idEvento.Id = -1;
            EventoM7 evento = (EventoM7)detalleEvento.Ejecutar();
        }
        #endregion
    }
}
