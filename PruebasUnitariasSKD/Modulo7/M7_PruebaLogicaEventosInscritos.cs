using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DominioSKD;
using ExcepcionesSKD.Modulo7;
using LogicaNegociosSKD.Modulo7;
 

namespace PruebasUnitariasSKD.Modulo7
{
    [TestFixture]
    public class M7_PruebaLogicaEventosInscritos
    {
        #region Atributos
        /// <summary>
        /// Atributo que representa el id de la persona o atleta
        /// </summary>
        private int idPersona;
        /// <summary>
        /// Atributo que representa la clase LogicaEventosInscritos
        /// </summary>
        LogicaEventosInscritos logicaEventosInscritos;
        #endregion

        #region SetUp & TearDown
        [SetUp]
        public void Init()
        {
            logicaEventosInscritos = new LogicaEventosInscritos();
            idPersona = 6;
        }

        [TearDown]
        public void Clean()
        {
            logicaEventosInscritos = null;
            idPersona = 0;
        }
        #endregion

        #region Test

        /// <summary>
        /// Método para probar que la lista obtenida puede tener cero o mas eventos
        /// </summary>
        [Test]
        public void PruebaObtenerListaEventosInscritos()
        {
            List<Evento> listaEvento = logicaEventosInscritos.obtenerListaDeEventos(idPersona);
            Assert.GreaterOrEqual(listaEvento.Count, 0);
        }

        /// <summary>
        /// Método para probar la excepcion de número entero invalido de listar eventos inscritos
        /// </summary>
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void ListarEventosInscritosNumeroEnteroException()
        {
            List<Evento> listaEvento = logicaEventosInscritos.obtenerListaDeEventos(-1);
        }

        /// <summary>
        /// Método para probar que la lista obtenida puede tener cero o mas competencia
        /// </summary>
        [Test]
        public void PruebaObtenerListaCompetenciasInscritas()
        {
            List<Competencia> listaCompetencia = logicaEventosInscritos.obtenerListaDeCompetencias(idPersona);
            Assert.GreaterOrEqual(listaCompetencia.Count, 0);
        }

        /// <summary>
        /// Método para probar la excepcion de número entero invalido de listar competencias Inscritas
        /// </summary>
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void ListarCompetenciasInscritasNumeroEnteroException()
        {
            List<Competencia> listaCompetencia = logicaEventosInscritos.obtenerListaDeCompetencias(-1);
        }


        /// <summary>
        /// Método para probar que se detalla un evento
        /// </summary>
        [Test]
        public void PruebaDetallarEvento()
        {
            Evento evento = logicaEventosInscritos.detalleEventoID(8);
            Assert.AreEqual("El Bushido", evento.Nombre);
        }

        /// <summary>
        /// Método para probar la excepcion de número entero invalido de detallar evento
        /// </summary>
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void DetallarEventoNumeroEnteroException()
        {
            Evento listaCinta = logicaEventosInscritos.detalleEventoID(-1);
        }

        /// <summary>
        /// Método para probar que se detalla una competencia
        /// </summary>
        [Test]
        public void PruebaObtenrDetalleCompetencia()
        {
            Competencia competencia = logicaEventosInscritos.detalleCompetenciaID(1);
            Assert.AreEqual("Ryu Kobudo", competencia.Nombre);
        }

        /// <summary>
        /// Método para probar la excepcion de número entero invalido de detallar competencia
        /// </summary>
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void DetalleCompetenciaNumeroEnteroException()
        {
            Competencia competencia = logicaEventosInscritos.detalleCompetenciaID(-1);
        }

        #endregion

    }
}
