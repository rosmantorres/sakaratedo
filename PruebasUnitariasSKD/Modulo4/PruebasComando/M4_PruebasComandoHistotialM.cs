using DominioSKD;
using DominioSKD.Entidades.Modulo4;
using DominioSKD.Fabrica;
using LogicaNegociosSKD;
using LogicaNegociosSKD.Fabrica;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasUnitariasSKD.Modulo4.PruebasComando
{
    /// <summary>
    /// Clase que contiene las pruebas unitarias para ComandoHistorialM
    /// </summary>
    [TestFixture]
    public class M4_PruebasComandoHistotialM
    {
        #region Atributos
        private HistorialM idHist;
        #endregion

        #region SetUp & TearDown
        /// <summary>
        /// Método que se ejecuta antes de cada prueba
        /// </summary>
        [SetUp]
        public void Init()
        {
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
        }
        #endregion

        /// <summary>
        /// Método para probar que se detalla un Historial Matricula en Comando
        /// </summary>
        [Test]
        public void PruebaDetallarHistorialXId()
        {
            Comando<Entidad> detallarHistM = FabricaComandos.CrearComandoDetallarHistorialM();
            detallarHistM.LaEntidad = idHist;
            HistorialM elHistM = (HistorialM)FabricaEntidades.ObtenerHistorialMatricula();
            elHistM = (HistorialM)detallarHistM.Ejecutar();
            Assert.AreEqual("Mensual", elHistM.Modalidad_historial_matricula);
        }

        /// <summary>
        /// Método para probar que el Historial Matricula no es nulo en Comando
        /// </summary>
        [Test]
        public void PruebaDetallarHistorialXIdNoNulo()
        {
            Comando<Entidad> detallarHistM = FabricaComandos.CrearComandoDetallarHistorialM();
            detallarHistM.LaEntidad = idHist;
            HistorialM elHistM = (HistorialM)FabricaEntidades.ObtenerHistorialMatricula();
            elHistM = (HistorialM)detallarHistM.Ejecutar();
            Assert.IsNotNull(elHistM);
        }

        /// Método de prueba para consultar todos los Historial Matricula  en Comando
        /// </summary>
        [Test]
        public void PruebaConsultarTodoslosHistorialMCom()
        {
            Comando<List<Entidad>> laListaHistM = FabricaComandos.CrearComandoListarHistorialM();
            List<Entidad> laLista = laListaHistM.Ejecutar();
            Assert.GreaterOrEqual(laLista.Count, 0);
        }

        /// <summary>
        /// Método para probar que la lista obtenida de Historial Matricula sea distinto de  nulo 
        /// </summary>
        [Test]
        public void PruebaConsultarTodosLosHistorialM()
        {
            Comando<List<Entidad>> laListaHistM = FabricaComandos.CrearComandoListarHistorialM();
            List<Entidad> laLista = laListaHistM.Ejecutar();
            Assert.NotNull(laLista);
        }

        /// Método de prueba para consultar todos los Historial Matricula de un Dojo  en Comando
        /// </summary>
        [Test]
        public void PruebaConsultarTodosXDojoCom()
        {
            DojoM4 idDojo = (DojoM4)FabricaEntidades.ObtenerDojo_M4();
            idDojo.Id = 35;
            idHist.Dojo_historial_matricula = idDojo;
            Comando<List<Entidad>> laListaHistM = FabricaComandos.CrearComandoListarHistorialM();
            laListaHistM.LaEntidad = idHist;
            List<Entidad> laLista = laListaHistM.Ejecutar();
            Assert.GreaterOrEqual(laLista.Count, 0);
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
            Comando<List<Entidad>> laListaHistM = FabricaComandos.CrearComandoListarHistorialM();
            laListaHistM.LaEntidad = idHist;
            List<Entidad> laLista = laListaHistM.Ejecutar();
            Assert.NotNull(laLista);
        }

        [Test]
        public void PruebaAgregarHistorialMatricula()
        {
            HistorialM elHistM = (HistorialM)FabricaEntidades.ObtenerHistorialMatricula();
            elHistM.Id_historial_matricula = 7;
            elHistM.Modalidad_historial_matricula = "Mensual";
            elHistM.Fecha_historial_matricula = DateTime.Parse("19/2/2016");
            elHistM.Monto_historial_matricula = float.Parse("12300");
            Comando<bool> laListaHistM = FabricaComandos.CrearComandoAgregaHistorialM();
            laListaHistM.LaEntidad = elHistM;
            Assert.IsTrue(laListaHistM.Ejecutar());

        }
        [Test]
        public void PruebaModificararHistorialMatricula()
        {
            HistorialM elHistM = (HistorialM)FabricaEntidades.ObtenerHistorialMatricula();
            elHistM.Id_historial_matricula = 20;
            elHistM.Modalidad_historial_matricula = "Semanal";
            elHistM.Fecha_historial_matricula = DateTime.Parse("19/2/2016");
            elHistM.Monto_historial_matricula = float.Parse("300");
            Comando<bool> laListaHistM = FabricaComandos.CrearComandoModificarHistorialM();
            laListaHistM.LaEntidad = elHistM;
            Assert.IsTrue(laListaHistM.Ejecutar());

        }
        [Test]
        public void PruebaEliminarHistorialMatricula()
        {
            HistorialM elHistM = (HistorialM)FabricaEntidades.ObtenerHistorialMatricula();
            elHistM.Id_historial_matricula = 21;
            Comando<bool> laListaHistM = FabricaComandos.CrearComandoEliminarHistorialM();
            laListaHistM.LaEntidad = elHistM;
            Assert.IsTrue(laListaHistM.Ejecutar());
        }

    }
}
