using DatosSKD.Fabrica;
using DatosSKD.InterfazDAO.Modulo14;
using DominioSKD.Fabrica;
using DominioSKD;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasUnitariasSKD.Modulo14
{
    [TestFixture]
    public class PruebaDaoDiseno
    {
        IDaoDiseno daoDiseno;
        [SetUp]
        public void Init()
        {
            daoDiseno = (IDaoDiseno)FabricaDAOSqlServer.ObtenerDAODiseno();
        }

        [Test]
        public void PruebaConsultar()
        {

            Entidad laPlanilla = FabricaEntidades.ObtenerPlanilla();
            ((DominioSKD.Entidades.Modulo14.Planilla)laPlanilla).ID = 19;
            DominioSKD.Entidades.Modulo14.Diseño result = (DominioSKD.Entidades.Modulo14.Diseño)daoDiseno.ConsultarXId(laPlanilla);
            Assert.IsTrue(result != null);
        }
        [Test]
        public void PruebaModificar()
        {

            Entidad elDiseno = FabricaEntidades.obtenerDiseño();
            ((DominioSKD.Entidades.Modulo14.Diseño)elDiseno).ID = 56;
            ((DominioSKD.Entidades.Modulo14.Diseño)elDiseno).Contenido = "Modificado en prueba";
            Assert.IsTrue(daoDiseno.Modificar(elDiseno));
        }
      
        [Test]
        public void PruebaGuardarDiseno()
        {

            Entidad laPlanilla = FabricaEntidades.ObtenerPlanilla();
            ((DominioSKD.Entidades.Modulo14.Planilla)laPlanilla).ID = 19;
            Entidad elDiseno = FabricaEntidades.obtenerDiseño();
            ((DominioSKD.Entidades.Modulo14.Diseño)elDiseno).Contenido = "Modificado en prueba";
            Assert.IsTrue(daoDiseno.GuardarDiseñoBD(elDiseno,laPlanilla));
        }
    }
}
