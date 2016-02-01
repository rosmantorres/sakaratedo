using DominioSKD;
using DominioSKD.Entidades.Modulo7;
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

namespace PruebasUnitariasSKD.Modulo7.PruebasComando
{

    /// <summary>
    /// Clase que contiene las pruebas unitarias para el comando detallar el horario de practica del atleta
    /// </summary>
    [TestFixture]
    class M7_PruebasComandoDetallarHorarioPractica
    {
        #region Atributos
        private EventoM7 idEvento;
        private ComandoConsultarDetallarHorarioPractica detalleHorario;
        #endregion

        #region SetUp & TearDown
        /// <summary>
        /// Método que se ejecuta antes de cada prueba
        /// </summary>
        [SetUp]
        public void Init()
        {
            detalleHorario = (ComandoConsultarDetallarHorarioPractica)FabricaComandos.ObtenerComandoConsultarDetallarHorarioPractica();
            idEvento = (EventoM7)FabricaEntidades.ObtenerEventoM7();
            idEvento.Id = 1;
            detalleHorario.LaEntidad = idEvento;
        }

        /// <summary>
        /// Método que se ejecuta despues de cada prueba
        /// </summary>
        [TearDown]
        public void Clean()
        {
            detalleHorario = null;
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
            EventoM7 evento = (EventoM7)detalleHorario.Ejecutar();
            Assert.GreaterOrEqual("Clase Regular", evento.Nombre);
        }

        /// <summary>
        /// Método para probar que el evento obtenido no es nulo
        /// </summary>
        [Test]
        public void PruebaEventoNoNulo()
        {
            EventoM7 evento = (EventoM7)detalleHorario.Ejecutar();
            Assert.IsNotNull(evento);
        }

        /// <summary>
        /// Método para probar la excepcion de número entero invalido en detallar horario practica
        /// </summary>
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void DetallarHorarioPracticaNumeroEnteroException()
        {
            idEvento.Id = -1;
            EventoM7 evento = (EventoM7)detalleHorario.Ejecutar();
        }
        #endregion
    }
}
