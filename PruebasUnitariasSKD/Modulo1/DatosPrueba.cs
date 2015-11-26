using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DatosSKD.Modulo1;

namespace PruebasUnitariasSKD.Modulo1
{
    [TestFixture]
    public class DatosPrueba
    {
        [SetUp]
        protected void parametros()
        {

        }
        [TearDown]
        protected void limpiarParametros()
        {

        }

        [Test]
        public void PruebaObtenerUsuario()
        {
         DominioSKD.Cuenta resp=  BDLogin.ObtenerUsuario("usuario04");
         
        }
    }
}
