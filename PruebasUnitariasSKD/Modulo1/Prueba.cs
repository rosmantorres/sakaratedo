using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using LogicaNegociosSKD.Modulo1;

namespace PruebasUnitariasSKD.Modulo1
{
    [TestFixture]
    class Prueba
    {
        [Test]
        public void Prueba1()
        {
            login lg = new login();
            string[] resp = lg.iniciarSesion("man", "12345");
            Assert.AreEqual(resp, null);

        }
    }
}
