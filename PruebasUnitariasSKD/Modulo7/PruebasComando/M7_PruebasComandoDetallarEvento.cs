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

namespace PruebasUnitariasSKD.Modulo7.PruebasComando
{
    /// <summary>
    /// Clase que contiene las pruebas unitarias para el comando detallar evento de atleta
    /// </summary>
    [TestFixture]
    public class M7_PruebasComandoDetallarEvento
    {
        #region Atributos
        private Evento idEvento;
        private FabricaComandos fabricaComandos;
        private ComandoConsultarDetallarEvento detalleEvento;
        private FabricaEntidades fabricaEntidades;
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
            fabricaEntidades = new FabricaEntidades();
            idEvento = new Evento();//cambiar por fabrica
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
            fabricaEntidades = null;
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
            Evento evento = (Evento)detalleEvento.Ejecutar();
            Assert.GreaterOrEqual("Entrenamiento 2", evento.Nombre);
        }

        /// <summary>
        /// Método para probar que el evento obtenido no es nulo
        /// </summary>
        [Test]
        public void PruebaEventoNoNulo()
        {
            Evento evento = (Evento)detalleEvento.Ejecutar();
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
            Evento evento = (Evento)detalleEvento.Ejecutar();
        }
        #endregion
    }
}
