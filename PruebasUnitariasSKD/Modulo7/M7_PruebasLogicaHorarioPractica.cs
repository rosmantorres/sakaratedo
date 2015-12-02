using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DominioSKD;
using ExcepcionesSKD.Modulo7;
using ExcepcionesSKD;
using LogicaNegociosSKD.Modulo7;
using DatosSKD.Modulo7;

namespace PruebasUnitariasSKD.Modulo7
{
    class M7_PruebasLogicaHorarioPractica
    {
        #region Atributos
        /// <summary>
        /// Atributo que representa el id de la persona o atleta
        /// </summary>
        private int idPersona;
        LogicaHorarioPractica logicahorarioPractica;
        #endregion

        #region SetUp & TearDown
        [SetUp]
        public void Init()
        {
            logicahorarioPractica = new LogicaHorarioPractica();
            idPersona = 6;
        }

        [TearDown]
        public void Clean()
        {
            logicahorarioPractica = null;
            idPersona = 0;
        }
        #endregion

        #region Test
        /// <summary>
        /// Método para probar que la lista obtenida puede tener cero o mas eventos
        /// </summary>
        [Test]
        public void PruebaObtenerListaHorarioPractica()
        {
            List<Evento> listaEvento = logicahorarioPractica.obtenerListaDePractica(idPersona);
            Assert.GreaterOrEqual(listaEvento.Count, 0);
        }
        /// <summary>
        /// Método para probar la excepcion de número entero invalido de listar practicas
        /// </summary>
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void ListarHorarioPracticaNumeroEnteroException()
        {
            List<Evento> listaEvento = logicahorarioPractica.obtenerListaDePractica(-1);
        }

        /// <summary>
        /// Método para probar que se detalla un evento
        /// </summary>
        [Test]
        public void PruebaDetallarEvento()
        {
            Evento evento = logicahorarioPractica.detalleEventoID(10);
            Assert.AreEqual("Clase Regular", evento.Nombre);
        }

        /// <summary>
        /// Método para probar la excepcion de número entero invalido de detallar evento
        /// </summary>
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void DetallarEventoNumeroEnteroException()
        {
            Evento listaHorario = logicahorarioPractica.detalleEventoID(-1);
        }

        #endregion
    }
}
