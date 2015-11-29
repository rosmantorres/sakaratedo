using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DatosSKD.Modulo1;
using PruebasUnitariasSKD.Modulo1;
using DominioSKD;
using ExcepcionesSKD;


namespace PruebasUnitariasSKD.Modulo1.Datos
{
    [TestFixture]
    class PruebasUnitariasDatos
    {
        [SetUp]
        protected  void parametros()
        {
           
        }
        // Prueba unitaria del metodo  ReestablecerContrasena(string usuarioId,string contraseña)
        [Test]
        public void PruebaReestablecerContrasena()
        {

            bool True = BDRestablecer.RestablecerContrasena(RecursosPU_Mod1.Id, RecursosPU_Mod1.PruebaCorrectoClave);
            Assert.AreEqual(True,true);

        }
        // Prueba unitaria del metodo ValidarCorreoUsuario(string correo_usuario)

        [Test]
        public void PruebaValidarCorreoUsuario()
        {

            bool True = BDLogin.ValidarCorreoUsuario(RecursosPU_Mod1.PruebaCorrectoResultado);
            Assert.AreEqual(True, true);

        }
        // Prueba unitaria del metodo  ObtenerUsuario(string usuario)
        [Test]
        public void PruebaObtenerUsuario()
        {
            Cuenta user = BDLogin.ObtenerUsuario(RecursosPU_Mod1.usuario);
            Assert.AreEqual(user.Nombre_usuario, RecursosPU_Mod1.usuario);

        }

       
    }
}
