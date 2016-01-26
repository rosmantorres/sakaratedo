using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DatosSKD;
using DatosSKD.Fabrica;
using DatosSKD.DAO.Modulo14;
using DominioSKD.Fabrica;
using DominioSKD.Entidades.Modulo14;
using DatosSKD.InterfazDAO.Modulo14;

namespace PruebasUnitariasSKD.Modulo14
{
    [TestFixture]
    public class PruebaDaoPlanilla
    {
       // FabricaDAOSqlServer fabrica;
        IDaoPlanilla daoplanilla;
       // FabricaEntidades fentidades;
        [SetUp]
        public void Init()
        {
            daoplanilla = (IDaoPlanilla)FabricaDAOSqlServer.ObtenerDAOPlanilla();
        }
        [Test]
        public void PruebaAgregar()
        {
            DominioSKD.Entidad laPlanilla = FabricaEntidades.ObtenerPlanilla("Retiro Prueba", true, 1);

            Assert.IsTrue(daoplanilla.Agregar(laPlanilla));

        }
        [Test]
        public void PruebaModificar()
        {
            DominioSKD.Entidad laPlanilla = FabricaEntidades.ObtenerPlanilla("Retiro Pruebaa", true, 1);

            Assert.IsTrue(daoplanilla.Modificar(laPlanilla));

        }
        [Test]
        public void PruebaConsultar()
        {
            Planilla laPlanilla = (Planilla)FabricaEntidades.ObtenerPlanilla();
            ((Planilla)laPlanilla).ID = 16;
            Assert.IsTrue(((Planilla)daoplanilla.ConsultarXId(laPlanilla)).Nombre == "Carnet");
         }
        [Test]
        public void PruebaObtenerTipoPlanilla()
        {
            Assert.IsNotEmpty(daoplanilla.ObtenerTipoPlanilla());
        }

        [Test]
        public void PruebaObtenerDatosBD()
        {
            Assert.IsNotEmpty(daoplanilla.ObtenerDatosBD());
        }

        [Test]
        public void PruebaRegistrarDatosPlanillaBD()
        {
            Assert.IsTrue(daoplanilla.RegistrarDatosPlanillaBD("Retiro Prueba","DOJO"));
        }
        [Test]
        public void PruebaRegistrarTipoPlanilla()
        {
            Assert.IsTrue(daoplanilla.RegistrarTipoPlanilla("Planilla"));
        }
        [Test]
        public void PruebaObtenerIdTipoPlanilla()
        {
            Assert.AreEqual(daoplanilla.ObtenerIdTipoPlanilla("RETIRO"), 1);
        }
        [Test]
        public void PruebaObtenerDatosPlanillaID()
        {
            Assert.IsNotEmpty(daoplanilla.ObtenerDatosPlanillaID(16));
        }
         [Test]
          public void PruebaEliminarDatosPlanillaBD()
         {
             Assert.IsTrue(daoplanilla.EliminarDatosPlanillaBD(91));

         }
        public void PruebaRegistrarDatosPlanillaIdBD()
        {
            Assert.IsTrue(daoplanilla.RegistrarDatosPlanillaIdBD(90,"Matricula"));
        }
        
   }
}


