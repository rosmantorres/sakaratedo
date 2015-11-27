using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DatosSKD.Modulo1;
using DominioSKD;

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
            Cuenta user = BDLogin.ObtenerUsuario(RecursosPU_Mod1.usuario);
            Assert.AreEqual(user.Nombre_usuario, RecursosPU_Mod1.usuario);
         
        }
    }
}
