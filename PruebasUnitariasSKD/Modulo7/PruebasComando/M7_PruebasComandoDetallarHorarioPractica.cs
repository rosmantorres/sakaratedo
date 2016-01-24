using DominioSKD;
using DominioSKD.Fabrica;
using LogicaNegociosSKD.Comandos.Modulo7;
using LogicaNegociosSKD.Fabrica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasUnitariasSKD.Modulo7.PruebasComando
{
    class M7_PruebasComandoDetallarHorarioPractica
    {/*
        #region Atributos
        private Evento idEvento;
        private FabricaComandos fabricaComandos;
        private ComandoConsultarDetallarHorarioPractica detalleHorario;
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
            detalleHorario = (ComandoConsultarDetallarHorarioPractica)fabricaComandos.ObtenerComandoConsultarDetallarHorarioPractica();
            fabricaEntidades = new FabricaEntidades();
            idEvento = new Evento();//cambiar por fabrica
            idEvento.Id = 1;
            detalleHorario.LaEntidad = idEvento;
        }

        /// <summary>
        /// Método que se ejecuta despues de cada prueba
        /// </summary>
        [TearDown]
        public void Clean()
        {
            fabricaComandos = null;
            detalleHorario = null;
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
            Evento evento = (Evento)detalleHorario.Ejecutar();
            Assert.GreaterOrEqual("Clase Regular", evento.Nombre);
        }

        /// <summary>
        /// Método para probar que el evento obtenido no es nulo
        /// </summary>
        [Test]
        public void PruebaEventoNoNulo()
        {
            Evento evento = (Evento)detalleHorario.Ejecutar();
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
            Evento evento = (Evento)detalleHorario.Ejecutar();
        }
        #endregion*/
    }
}
