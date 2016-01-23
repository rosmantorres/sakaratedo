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

namespace PruebasUnitariasSKD.Modulo14
{
    [TestFixture]
    public class PruebaDaoPlanilla
    {
        FabricaDAOSqlServer fabrica;
        DaoPlanilla daoplanilla;
        FabricaEntidades fentidades;
        [SetUp]
        public void Init()
        {
            fabrica = new FabricaDAOSqlServer();
            fentidades = new FabricaEntidades();
            daoplanilla = (DaoPlanilla)fabrica.ObtenerDAOPlanilla();
        }
        [Test]
        public void PruebaAgregar()
        {
            DominioSKD.Entidad laPlanilla = fentidades.ObtenerPlanilla("Retiro Prueba",true,1);

            Assert.IsTrue(daoplanilla.Agregar(laPlanilla));

        }
        [Test]
        public void PruebaModificar()
        {
            DominioSKD.Entidad laPlanilla = fentidades.ObtenerPlanilla("Retiro Pruebaa", true, 1);

            Assert.IsTrue(daoplanilla.Modificar(laPlanilla));

        }
        [Test]
        public void PruebaConsultar()
        {
            Planilla laPlanilla = (Planilla)fentidades.ObtenerPlanilla();
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
            Assert.IsTrue(daoplanilla.RegistrarDatosPlanillaBD("sinosi","DOJO"));
        }
        [Test]
        public void PruebaRegistrarTipoPlanilla()
        {
            Assert.IsTrue(daoplanilla.RegistrarTipoPlanilla("Planilla"));
        }
        [Test]
        public void PruebaObtenerIdTipoPlanilla()
        {
            Assert.AreEqual(daoplanilla.ObtenerIdTipoPlanilla("RETIRO"), 12);
        }
        [Test]
        public void PruebaObtenerDatosPlanillaID()
        {
            Assert.IsNotEmpty(daoplanilla.ObtenerDatosPlanillaID(16));
        }
         [Test]
          public void PruebaEliminarDatosPlanillaBD()
         {
            // DominioSKD.Entidad laPlanilla = fentidades.ObtenerPlanilla("Prueba", true, 1);
             Assert.IsTrue(daoplanilla.EliminarDatosPlanillaBD(55));

         }
        public void PruebaRegistrarDatosPlanillaIdBD()
        {
            Assert.IsTrue(daoplanilla.RegistrarDatosPlanillaIdBD(16,"DOJO"));
        }
        [Test]
        public void PruebaConsultarPlanillasCreadas()
        {
            Assert.IsNotEmpty(daoplanilla.ConsultarPlanillasCreadas());
        }
   }
}


