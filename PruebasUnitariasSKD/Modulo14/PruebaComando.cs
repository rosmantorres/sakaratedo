using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using LogicaNegociosSKD.Fabrica;
using LogicaNegociosSKD.Comandos.Modulo14;
using DominioSKD;
using LogicaNegociosSKD;

namespace PruebasUnitariasSKD.Modulo14
{
    [TestFixture]
    public class PruebaComando
    {
        FabricaComandos fabricaC;
        DominioSKD.Fabrica.FabricaEntidades fabricaE;
       
        [SetUp]
        public void Init()
        {
           // fabricaC = new FabricaComandos();
        }

        [Test]
        public void PruebaComandoConsultarPlanillas()
        {
            Assert.IsNotEmpty(((ComandoConsultarPlanillas)FabricaComandos.ObtenerComandConsultarPlanillas()).Ejecutar());
        }

        [Test]
        public void PruebaComandoConsultarPlanillasASolicitar()
        {
            Assert.IsNotEmpty(((ComandoConsultarPlanillasASolicitar)FabricaComandos.ObtenerComandoConsultarPlanillasASolicitar()).Ejecutar());
        }

        [Test]
        public void PruebaComandoDatosRequeridosSolicitud()
        {
            Comando<List<Boolean>> comando = FabricaComandos.ObtenerComandoDatosRequeridosSolicitud();
            comando.LaEntidad = DominioSKD.Fabrica.FabricaEntidades.ObtenerPlanilla();
            comando.LaEntidad.Id = 16;
            Assert.IsNotEmpty(((ComandoDatosRequeridosSolicitud)comando).Ejecutar());
        }
    
    
    }

}
