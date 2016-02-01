using DatosSKD.DAO.Modulo4;
using DatosSKD.Fabrica;
using DominioSKD;
using DominioSKD.Fabrica;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD.Entidades.Modulo4;
using DatosSKD.InterfazDAO.Modulo4;

namespace PruebasUnitariasSKD.Modulo4.PruebasDAO
{
    /// <summary>
    /// Clase que contiene las pruebas unitarias para DaoHistorialM
    /// </summary>
    [TestFixture]
    public class M4_PruebasDAOHistorialM
    {
        #region Atributos
        private HistorialM idHist;
        private IDaoHistorialM baseDeDatosHist;
        #endregion

        #region SetUp & TearDown
        /// <summary>
        /// Método que se ejecuta antes de cada prueba
        /// </summary>
        [SetUp]
        public void Init()
        {
            baseDeDatosHist = FabricaDAOSqlServer.ObtenerDAOHistorialM();
            idHist = (HistorialM)FabricaEntidades.ObtenerHistorialMatricula();
            idHist.Id = 1;
        }

        /// <summary>
        /// Método que se ejecuta luego de cada prueba
        /// </summary>
        [TearDown]
        public void Clean()
        {
            idHist = null;
            baseDeDatosHist = null;
        }
        #endregion

        /// <summary>
        /// Método para probar que se detalla un Historial Matricula en DAO
        /// </summary>
        [Test]
        public void PruebaDetallarHistorialXId()
        {
            HistorialM hist = (HistorialM)baseDeDatosHist.ConsultarXId(idHist);
            Assert.AreEqual("Mensual", hist.Modalidad_historial_matricula);
        }

        /// <summary>
        /// Método para probar que el Historial Matricula no es nulo en DAO
        /// </summary>
        [Test]
        public void PruebaDetallarHistorialXIdNoNulo()
        {
            HistorialM hist = (HistorialM)baseDeDatosHist.ConsultarXId(idHist);
            Assert.IsNotNull(hist);
        }

        /// Método de prueba para consultar todos los Historial Matricula  en DAO
        /// </summary>
        [Test]
        public void PruebaConsultarTodoslosHistorialMDAO()
        {
            List<Entidad> listaHist = baseDeDatosHist.ConsultarTodos();
            Assert.GreaterOrEqual(listaHist.Count, 0);
        }

        /// <summary>
        /// Método para probar que la lista obtenida de Historial Matricula sea distinto de  nulo 
        /// </summary>
        [Test]
        public void PruebaConsultarTodosLosHistorialM()
        {

            List<Entidad> listaHist = baseDeDatosHist.ConsultarTodos();
            Assert.NotNull(listaHist);
        }

        /// Método de prueba para consultar todos los Historial Matricula de un Dojo  en DAO
        /// </summary>
        [Test]
        public void PruebaConsultarTodosXDojoDAO()
        {
            DojoM4 idDojo = (DojoM4)FabricaEntidades.ObtenerDojo_M4();
            idDojo.Id = 35;
            idHist.Dojo_historial_matricula = idDojo;
            List<Entidad> listaHist = baseDeDatosHist.ConsultarTodosDojo(idHist);
            Assert.GreaterOrEqual(listaHist.Count, 0);
        }

        /// <summary>
        /// Método para probar que la lista obtenida de Historial Matricula sea distinto de  nulo 
        /// </summary>
        [Test]
        public void PruebaConsultarTodosXDojoDAONoNull()
        {
            DojoM4 idDojo = (DojoM4)FabricaEntidades.ObtenerDojo_M4();
            idDojo.Id = 7;
            idHist.Dojo_historial_matricula = idDojo;
            List<Entidad> listaHist = baseDeDatosHist.ConsultarTodosDojo(idHist);
            Assert.NotNull(listaHist);
        }
        
        [Test]
        public void PruebaAgregarHistorialMatricula()
        {
            HistorialM elHistM = (HistorialM)FabricaEntidades.ObtenerHistorialMatricula();
            elHistM.Id_historial_matricula = 7;
            elHistM.Modalidad_historial_matricula = "Mensual";
            elHistM.Fecha_historial_matricula = DateTime.Parse("19/2/2016");
            elHistM.Monto_historial_matricula = float.Parse("12300");
            Assert.IsTrue(baseDeDatosHist.Agregar(elHistM));

        }
        [Test]
        public void PruebaModificararHistorialMatricula()
        {
            HistorialM elHistM = (HistorialM)FabricaEntidades.ObtenerHistorialMatricula();
            elHistM.Id_historial_matricula = 20;
            elHistM.Modalidad_historial_matricula = "Semanal";
            elHistM.Fecha_historial_matricula = DateTime.Parse("19/2/2016");
            elHistM.Monto_historial_matricula = float.Parse("300");
            Assert.IsTrue(baseDeDatosHist.Agregar(elHistM));

        }
        [Test]
        public void PruebaEliminarHistorialMatricula()
        {
            HistorialM elHistM = (HistorialM)FabricaEntidades.ObtenerHistorialMatricula();
            elHistM.Id_historial_matricula = 20;
            Assert.IsTrue(baseDeDatosHist.Eliminar(elHistM));
        }


    }
}
