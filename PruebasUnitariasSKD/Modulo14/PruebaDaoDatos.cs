using DatosSKD.Fabrica;
using DatosSKD.InterfazDAO.Modulo14;
using DominioSKD;
using DominioSKD.Fabrica;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasUnitariasSKD.Modulo14
{
    [TestFixture]
    public class PruebaDaoDatos
    {
        IDaoDatos daoDatos;
        [SetUp]
        public void Init()
        {
            daoDatos = (IDaoDatos)FabricaDAOSqlServer.ObtenerDAODatos();
        }
        [Test]
        public void PruebaConsultarPersona()
        {
            Persona result = daoDatos.ConsultarPersona(1);
            Assert.IsTrue(result !=null);
        }
        [Test]
        public void PruebaConsultarDojo()
        {
            Dojo result = daoDatos.ConsultarDojo(1);
            Assert.IsTrue(result != null);
        }
        [Test]
        public void PruebaConsultarMatricula()
        {
            List<string> result = daoDatos.ConsultarMatricula(1,1);
            Assert.IsTrue(result != null);
        }
        [Test]
        public void PruebaConsultarOrganizacion()
        {
            Entidad result = daoDatos.ConsultarOrganizacion(1);
            Assert.IsTrue(result != null);
        }
        //arreglar el parametro
        [Test]
        public void PruebaConsultarEvento()
        {
            Entidad result = daoDatos.ConsultarEvento(2);
            Assert.IsTrue(result != null);
        }
        [Test]
        public void PruebaConsultarCompetencia()
        {
            Entidad result = daoDatos.ConsultarCompetencia(1);
            Assert.IsTrue(result != null);
        }
      
    }
}
