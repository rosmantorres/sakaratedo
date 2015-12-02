using System;
using System.Collections.Generic;                   
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegociosSKD.Modulo14;
using NUnit.Framework;
using DatosSKD.Modulo14;
using DominioSKD;
using DatosSKD;
using LogicaNegociosSKD;

namespace PruebasUnitariasSKD.Modulo14
{
    [TestFixture]
    public class PruebaLogicaPlanilla
    {
        private LogicaPlanilla logica;

        [SetUp]
        public void Init()
        {
            LogicaPlanilla logica = new LogicaPlanilla();
           
        }
        /// <summary>
        /// Prueba para el metodo listar Planilla Creadas
        /// </summary>
        [Test]
        public void PruebaConsultarPlanillasCreadas()
        {
            List<DominioSKD.Planilla> lista = new List<DominioSKD.Planilla>();
            LogicaPlanilla logica = new LogicaPlanilla();   
            lista = logica.ConsultarPlanillas();
            Assert.IsTrue(lista.Count > 0);
        }
        /// <summary>
        /// Prueba para el metodo para obtener tipo de planilla
        /// </summary>
        [Test]
        public void PruebaObtenerTipoPlanilla()
        {
            var datos = new List<string> { "PERSONA"};
            Planilla planilla = new Planilla("RETIRO COMPETENCIA", true, "RETIRO", datos);
            LogicaPlanilla logica = new LogicaPlanilla();
            datos = logica.ObtenerDatosPlanilla(1);
            Assert.AreEqual(1,datos.Count());
        }
          /// <summary>
        /// Prueba para el metodo registrar planilla
        /// </summary>
        [Test]
        public void PruebaRegistrarPlanilla()
        {

            Planilla planilla = new Planilla("RETIRO VACACIONES", true, 1);
            LogicaPlanilla logica = new LogicaPlanilla();
            BDPlanilla BaseDeDatosPlanilla = new BDPlanilla();
            Assert.IsTrue(BaseDeDatosPlanilla.RegistrarPlanillaBD(planilla));
            //Assert.IsTrue(logica.RegistrarPlanilla(planilla));
               
        }
        /// <summary>
        /// Prueba para el metodo para Cambiar Status Planilla
        /// </summary>
        [Test]
        public void PruebaCambiarStatusPlanilla()
        {
            Planilla planilla = new Planilla(1,"RETIRO COMPETENCIA",true,"RETIRO");
            LogicaPlanilla logica = new LogicaPlanilla();
            Assert.IsTrue(logica.CambiarStatusPlanilla(1));
        }

        /// <summary>
        /// Prueba para el metodo nuevo tipo de planilla
        /// </summary>
        [Test]
        public void PruebaNuevoTipoPlanilla()
        {
            Planilla planilla = new Planilla(1,"RETIRO");
            LogicaPlanilla logica = new LogicaPlanilla();
            BDPlanilla BaseDeDatosPlanilla = new BDPlanilla();
            Assert.IsTrue(BaseDeDatosPlanilla.RegistrarTipoPlanilla("RETIRO"));
        
        }

        [TearDown]
        public void Limpiar()
        {
            logica = null;
        }
        
    }
}
