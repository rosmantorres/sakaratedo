using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DominioSKD;
using DatosSKD.Modulo3;

namespace PruebasUnitariasSKD.Modulo3
{
   [TestFixture]
    class PruebaBD
      {
       [SetUp]
       public void Ejecutar()
       {

       }

       [Test]
       public void PruebalistarOrganizacion()
       {
       
           //Asert
           List<Organizacion> listOrg = new List<Organizacion>();
           listOrg = BDOrganizacion.ListarOrganizaciones();

           Assert.IsTrue(listOrg.Count > 0);
       
       }
    }
}
