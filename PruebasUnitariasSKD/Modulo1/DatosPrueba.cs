using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

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
         DominioSKD.Cuenta resp=  DatosSKD.Modulo1.BDLogin.ObtenerUsuario("usuario01");
         Console.WriteLine(resp.Nombre_usuario);
         Console.WriteLine(resp.Roles);
         Console.WriteLine(resp.Id_usuario.ToString());
        }
    }
}
