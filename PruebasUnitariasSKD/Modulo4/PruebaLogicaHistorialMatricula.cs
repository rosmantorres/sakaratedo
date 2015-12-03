using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DominioSKD;
using ExcepcionesSKD.Modulo4;
using LogicaNegociosSKD.Modulo4;

namespace PruebasUnitariasSKD.Modulo4
{
     [TestFixture]
    class PruebaLogicaHistorialMatricula
    {

        #region Atributos
        /// <summary>
        /// Atributo que representa el id del Historial Matricula
        /// </summary>
        private int idHis;
        /// <summary>
        /// Atributo que representa la clase LogicaEventosPagos
        /// </summary>
        LogicaHistorial_Matricula logicaHistorial;
        #endregion

        #region SetUp & TearDown
        [SetUp]
        public void Init()
        {
            logicaHistorial = new LogicaHistorial_Matricula();
            idHis = 8;
        }

        [TearDown]
        public void Clean()
        {
            logicaHistorial = null;
            idHis = 0;
        }
        #endregion

        #region Test

        /// <summary>
        /// Método para probar que la lista obtenida puede tener cero o mas Historiales
        /// </summary>
        [Test]
        public void PruebaObtenerListaHMatriculas()
        {
            List<Historial_Matricula> listaHist = logicaHistorial.obtenerListaDeMatriculas();
            Assert.GreaterOrEqual(listaHist.Count, 0);
        }

        /// <summary>
        /// Método para probar que la lista obtenida puede tener cero o mas Historiales filtrada por dojos
        /// </summary>
        [Test]
        public void PruebaObtenerListaHMatriculas()
        {
            List<Historial_Matricula> listaHist = logicaHistorial.obtenerListaDeMatriculas(4);
            Assert.GreaterOrEqual(listaHist.Count, 0);
        }


        /// <summary>
        /// Método para probar que se detalla una competencia
        /// </summary>
        [Test]
        public void PruebaAgregarHistorial()
        {
            bool prueba = true;
            Dojo elDojo = new Dojo();
            elDojo.Id_dojo = 4;
            DateTime fecha = new DateTime(01 / 01 / 2011);
            Historial_Matricula his = new Historial_Matricula(fecha, "Anual", 2340);
             bool agrego = logicaHistorial.agregarHistorialMatricula(his,elDojo);
            Assert.AreEqual(agrego, prueba);
        }



        #endregion
    }
}
