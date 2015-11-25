using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DatosSKD.Modulo1;
using PruebasUnitariasSKD.Modulo1;

namespace PruebasUnitariasSKD.Modulo1
{
    [TestFixture]
    class PruebasUnitariasLogin
    {
        [SetUp]
        protected  void parametros()
        {
           
        }
         // Prueba unitaria del metodo IniciarSesion() de forma erronea
        [Test]
        public static void PruebaInicioSesionFallida()
        {
            Cuenta lg = new Cuenta();
            string[] resp = lg.iniciarSesion(RecursosPU_Mod1.pruebaErrorCorreo, RecursosPU_Mod1.PruebaErrorClave);
            Assert.AreEqual(resp, null);

        }

       
    }
}
