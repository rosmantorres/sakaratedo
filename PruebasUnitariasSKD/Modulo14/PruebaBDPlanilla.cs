using DominioSKD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSKD.Modulo14;
using LogicaNegociosSKD.Modulo14;
using NUnit.Framework;
using DatosSKD;


namespace PruebasUnitariasSKD.Modulo14
{
    [TestFixture]
    public class PruebaBDPlanilla
    {
        private BDPlanilla BaseDeDatosPlanilla;
      
        [SetUp]
        public void Init()
        {
            BaseDeDatosPlanilla = new BDPlanilla();
        }
        
    
        /// <summary>
        /// Prueba para el metodo listar Planilla Creadas
        /// </summary>
        [Test]
        public void PruebaConsultarPlanillasCreadas()
        {
             List<DominioSKD.Planilla> lista = new List<DominioSKD.Planilla>();
             Planilla planilla = new Planilla("RETIRO COMPETENCIA", true, 1);
             lista=BaseDeDatosPlanilla.ConsultarPlanillasCreadas();
             Assert.AreEqual(lista[0].Nombre,planilla.Nombre);
             
        }
        /// <summary>
        /// Prueba para el metodo obtener tipo planilla
        /// </summary>
        [Test]
        public void PruebaObtenerTipoPlanilla()
        {
            List<Planilla> lista2 = new List<Planilla>();
            Planilla planilla = new Planilla(1, "RETIRO COMPETENCIA", true, "RETIRO");
            lista2 = BaseDeDatosPlanilla.ObtenerTipoPlanilla();
            Assert.AreEqual(lista2[0].TipoPlanilla, planilla.TipoPlanilla);
            

        }
        /// <summary>
        /// Prueba para el metodo obtener Datos de la Base de datos
        /// </summary>
        [Test]

        public void PruebaObtenerDatosBD()
        {
            var datos = new List<string> { "PERSONA", "COMPETENCIA","DOJO"};
            Planilla planilla = new Planilla("RETIRO COMPETENCIA",true,"RETIRO",datos);
            datos = BaseDeDatosPlanilla.ObtenerDatosBD();
            Assert.AreEqual(6, datos.Count());
           
        }

        /// <summary>
        /// Prueba para el metodo registrar PlanillaBD
        /// </summary>
         [Test]
        public void PruebaRegistrarPlanillaBD()
        {
            Planilla planilla = new Planilla("RETIRO VACACIONES", true, 1);
            Assert.IsTrue(BaseDeDatosPlanilla.RegistrarPlanillaBD(planilla));
                
        }
         /// <summary>
         /// Prueba para el metodo registrar PlanillaBD
         /// </summary>
         [Test]
         public void PruebaRegistrarDatosPlanillaBD()
         {
             var datos = new List<string> { "PERSONA", "COMPETENCIA", "DOJO" };
             Planilla planilla = new Planilla("RETIRO COMPETENCIA",true,1,datos);
             Assert.IsTrue(BaseDeDatosPlanilla.RegistrarDatosPlanillaBD("RETIRO COMPETENCIA","PERSONA"));
            
         }
         /// <summary>
         /// Prueba para el metodo registrar id planilla y datos planilla
         /// </summary>
         [Test]
         public void PruebaRegistrarDatosPlanillaIdBD()
         {
             var datos = new List<string> { "PERSONA"};
             Planilla planilla = new Planilla("RETIRO COMPETENCIA", true, 1, datos);
             Assert.IsTrue(BaseDeDatosPlanilla.RegistrarDatosPlanillaIdBD(1,"PERSONA"));
                 
               
         }
         [Test]
        public void PruebaEliminarDatosPlanillaBD()
         {

             var datos = new List<string> { "PERSONA","DOJO" };
             Planilla planilla = new Planilla(1,"RETIRO COMPETENCIA", true, 1, datos);
             Boolean seRealizo = BaseDeDatosPlanilla.RegistrarPlanillaBD(planilla);
             BaseDeDatosPlanilla.EliminarDatosPlanillaBD(1);
             Assert.IsTrue(BaseDeDatosPlanilla.EliminarDatosPlanillaBD(1));
                 
         }
         [Test]
         public void PruebaModificarPlanillaBD()
         {
             var datos = new List<string> { "PERSONA", "DOJO" };
             Planilla planilla = new Planilla(1, "RETIRO COMPETENCIA", true, 1, datos);
             Assert.IsTrue(BaseDeDatosPlanilla.ModificarPlanillaBD(planilla));
                 

         }

        [Test]
        public void PruebaObtenerDatosPlanillaID()
         {
             var datos = new List<string> { "PERSONA", "COMPETENCIA", "DOJO" };
             List<String> listDatos = new List<String>();
             Planilla planilla = new Planilla(1, "RETIRO COMPETENCIA", true, 1, datos);
             listDatos = BaseDeDatosPlanilla.ObtenerDatosPlanillaID(1);
             Assert.AreEqual(3, datos.Count());
         }
          

        [TearDown]
        public void Limpiar()
        {
            BaseDeDatosPlanilla = null;
            
        }
    }
 }
    
   
    