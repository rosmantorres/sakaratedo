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
using DominioSKD.Entidades.Modulo6;

namespace PruebasUnitariasSKD.Modulo7
{
    class M7_PruebasLogicaMatriculasPagas
    {
        #region Atributos
        /// <summary>
        /// Atributo que representa el id de la persona o atleta
        /// </summary>
        private int idPersona;
        /// <summary>
        /// Atributo que representa la clase LogicaEventosPagos
        /// </summary>
        LogicaMatriculasPagas logicaM;
        #endregion

        #region SetUp & TearDown
        [SetUp]
        public void Init()
        {
            logicaM = new LogicaMatriculasPagas();
            idPersona = 6;
        }

        [TearDown]
        public void Clean()
        {
            logicaM = null;
            idPersona = 0;
        }
        #endregion

        #region Test

        /// <summary>
        /// Método para probar que la lista obtenida puede tener cero o mas eventos
        /// </summary>
        [Test]
        public void PruebaObtenerListaMatriculas()
        {
            List<Matricula> listaM = logicaM.obtenerListaDeMatriculas(idPersona);
            Assert.GreaterOrEqual(listaM.Count, 0);
        }

        /// <summary>
        /// Método para probar la excepcion de número entero invalido de listar eventos pagos
        /// </summary>
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void ListarMatriculasNumeroEnteroException()
        {
            List<Matricula> listaM = logicaM.obtenerListaDeMatriculas(-1);
        }

        /// <summary>
        /// Método para probar que la lista obtenida puede tener cero o mas eventos
        /// </summary>
        [Test]
        public void PruebaObtenerIdMatriculas()
        {
            int idM = logicaM.obtenerIdMatricula(idPersona);
            Assert.GreaterOrEqual(idM, 3);
        }

        /// <summary>
        /// Método para probar la excepcion de número entero invalido de listar eventos pagos
        /// </summary>
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void ObtenerIdMatriculaEnteroException()
        {
            int listaM = logicaM.obtenerIdMatricula(-1);
        }

        /// <summary>
        /// Método para probar que se obtiene el monto del pago de un evento
        /// </summary>
        [Test]
        public void PruebaObtenerEstadoMatricula()
        {
            Boolean estado = logicaM.obtenerEstado(idPersona);
            Assert.AreEqual(true, estado);
        }

        /// <summary>
        /// Método para probar la excepcion de número entero invalido de obtener monto de pago de evento
        /// </summary>
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void EstadoMatriculaoNumeroEnteroException()
        {
            Boolean estado = logicaM.obtenerEstado(-1);
        }
        /// <summary>
        /// Método para probar que se obtiene el monto del pago de un evento
        /// </summary>
        [Test]
        public void PruebaObtenerMontoMatricula()
        {
            float monto = logicaM.obtenerMontoMatricula(idPersona, 3);
            Assert.AreEqual(1200, monto);
        }

        /// <summary>
        /// Método para probar la excepcion de número entero invalido de obtener monto de pago de evento
        /// </summary>
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void MontoMatriculaNumeroEnteroException()
        {
                float monto = logicaM.obtenerMontoMatricula(idPersona, -1);
        }

        /// <summary>
        /// Método para probar que se detalla una competencia
        /// </summary>
        [Test]
        public void PruebaObtenerDetalleMatriculaXId()
        {
            Matricula mat = logicaM.detalleMatriculaID(25);
            Assert.AreEqual("CCA1-CAF-CAFE", mat.Identificador);
        }

        /// <summary>
        /// Método para probar la excepcion de número entero invalido de detallar competencia
        /// </summary>
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void DetalleCompetenciaPagaNumeroEnteroException()
        {
            Matricula mat = logicaM.detalleMatriculaID(-1);
        }
        #endregion
    }
}
