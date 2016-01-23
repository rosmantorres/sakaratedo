using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
//using DatosSKD.Modulo1;
using DatosSKD.Modulo2;
using PruebasUnitariasSKD.Modulo1;
using DominioSKD.Entidades.Modulo1;
using ExcepcionesSKD;
using DatosSKD.DAO.Modulo1;
using DatosSKD.Fabrica;



namespace PruebasUnitariasSKD.Modulo1
{
    [TestFixture]
    class PruebasUnitariasDatos
    {
        FabricaDAOSqlServer laFabrica = new FabricaDAOSqlServer();
        [SetUp]
        protected void parametros()
        {

        }
        // Prueba unitaria del metodo  ReestablecerContrasena(string usuarioId,string contraseña)
        [Test]
        public void PruebaReestablecerContrasena()
        {
            
            DaoRestablecer conexionBD = (DaoRestablecer) laFabrica.ObtenerDaoRestablecer();
            bool True = conexionBD.RestablecerContrasena(RecursosPU_Mod1.Id, RecursosPU_Mod1.PruebaCorrectoClave);
            Assert.AreEqual(True, true);

        }
        // Prueba unitaria del metodo ValidarCorreoUsuario(string correo_usuario)

        [Test]
        public void PruebaValidarCorreoUsuario()
        {

            BDLogin conexionBD = new BDLogin();
            String True = conexionBD.ValidarCorreoUsuario(RecursosPU_Mod1.PruebaCorrectoResultado);
            Assert.AreNotEqual(True, null);

        }
        // Prueba unitaria del metodo ValidarCorreoUsuario(string correo_usuario) EXC mas de un correo Principal

        [Test]
        [ExpectedException(typeof(ExcepcionesSKD.ExceptionSKD))]
        public void PruebaValidarCorreoUsuarioExc()
        {

            BDLogin conexionBD = new BDLogin();
            String True = conexionBD.ValidarCorreoUsuario(RecursosPU_Mod1.emailerrordoble);

        }
        // Prueba unitaria del metodo  ObtenerUsuario(string usuario)
        [Test]
        public void PruebaObtenerUsuario()
        {

            BDLogin conexionBD = new BDLogin();
            Cuenta user = conexionBD.ObtenerUsuario(RecursosPU_Mod1.usuario);
            Assert.AreEqual(user.Nombre_usuario, RecursosPU_Mod1.usuario);

        }
        // Prueba unitaria del metodo  ObtenerUsuario(string usuario) con EXC

        [Test]
        [ExpectedException(typeof(ExcepcionesSKD.ExceptionSKD))]
        public void PruebaObtenerUsuarioEXC()
        {

            BDLogin conexionBD = new BDLogin();
            Cuenta user = conexionBD.ObtenerUsuario(null);

        }
        [Test]
        public void PruebaValidarRestablecerContrasena()
        {
            bool _respuesta;

            BDRestablecer conexionBD = new BDRestablecer();
            _respuesta = conexionBD.RestablecerContrasena(RecursosPU_Mod1.Id, RecursosPU_Mod1.PruebaRestablecerClave);
            Assert.AreEqual(true, _respuesta);
        }
        // Prueba unitaria de la excepcion del metodo restablecerContrasena()
        [Test]
        [ExpectedException(typeof(ExcepcionesSKD.ExceptionSKD))]
        public void PruebaValidarRestablecerContrasenaexc()
        {
            bool _respuesta;
            BDRestablecer conexionBD = new BDRestablecer();
            _respuesta = conexionBD.RestablecerContrasena(null, RecursosPU_Mod1.PruebaRestablecerClave);
        }



    }
}
