using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using LogicaNegociosSKD.Modulo1;
using LogicaNegociosSKD.Modulo2;
using DominioSKD;
namespace PruebasUnitariasSKD.Modulo1
{
    [TestFixture]
    class PruebasUnitariasLogicaN
    {
        [SetUp]
        protected  void parametros()
        {
           
        }

        // Prueba unitaria del metodo IniciarSesion() de forma erronea
        [Test]
        public  void PruebaInicioSesionFallida()
        {
            logicaLogin lg = new logicaLogin();
            string[] resp = lg.iniciarSesion(RecursosPU_Mod1.pruebaErrorCorreo, RecursosPU_Mod1.PruebaErrorClave);
            Assert.AreEqual(resp, null);

        }
        // Prueba unitaria del metodo IniciarSesion() de forma correcta
        [Test]
        public  void PruebaInicioSesionCorrecto()
        {
            logicaLogin lg = new logicaLogin();
            string[] resp = lg.iniciarSesion(RecursosPU_Mod1.pruebainicioCorreo, RecursosPU_Mod1.PruebaCorrectoClave);
            Assert.AreEqual(resp[1], RecursosPU_Mod1.pruebainicioCorreo);

        }
        // Prueba unitaria de la excepcion del metodo EnviarCorreo()
        [Test]
        [ExpectedException(typeof(ExcepcionesSKD.ExceptionSKD))]
        public  void PruebaEnviarCorreoFallidoEXC()
        {
            logicaLogin lg = new logicaLogin();
            bool resp = lg.EnviarCorreo(null);
            resp.ToString();

        }
        // Prueba unitaria de la excepcion del metodo IniciarSesion()
        [Test]
        [ExpectedException(typeof(ExcepcionesSKD.Modulo1.InicioSesionException))]
        public  void PruebaIniciarSesionFallidoEXC()
        {
            logicaLogin lg = new logicaLogin();
            string[] resp = lg.iniciarSesion(null,null);
            resp.ToString();

        }
        // Prueba unitaria del metodo Enviarcorreo() de forma correcta

        [Test]
        public  void PruebaEnviarCorreoCorrecto()
        {
            logicaLogin lg = new logicaLogin();
            bool resp = lg.EnviarCorreo(RecursosPU_Mod1.PruebaCorrectoResultado);
            Assert.AreEqual(resp, true);

        }
        [Test]
        // Prueba unitaria del metodo hash() de forma correcta

        public void PruebaHashCorrecto()
        {


            Assert.AreEqual(logicaLogin.hash(RecursosPU_Mod1.pruebaHash2), logicaLogin.hash(RecursosPU_Mod1.pruebaHash));
            
        }
        [Test]
        // Prueba unitaria de la excepcion del metodo hash()
        [ExpectedException(typeof(ExcepcionesSKD.Modulo1.HashException))]
        public void PruebaHashFallido()
        {
            string resp = logicaLogin.hash(null);
        }
        // Prueba unitaria del metodo ValidarCorreo() de forma correcta
       [Test]
        public void PruebaValidarCorreoCorrecto()
        {
            logicaLogin lg = new logicaLogin();
            string _respuesta;


            _respuesta = lg.validarCorreo(RecursosPU_Mod1.PruebaCorrectoResultado);

            Assert.AreNotEqual(null, _respuesta);
        } 
        // Prueba unitaria del metodo ValidarCorreo() de forma Erronea
         [Test]
         public void PruebaValidarCorreoFallido()
         {
             logicaLogin lg = new logicaLogin();
             string _respuesta;


             _respuesta = lg.validarCorreo(RecursosPU_Mod1.pruebaErrorCorreo);
             Assert.AreEqual(null, _respuesta);
         }
         [Test]
         // Prueba unitaria de la excepcion del metodo hash()
         [ExpectedException(typeof(ExcepcionesSKD.ExceptionSKD))]
         public void PruebaValidarCorreoFallidoexc()
         {
             logicaLogin lg = new logicaLogin();
             string _respuesta;
             _respuesta = lg.validarCorreo(null);
         }
         // Prueba unitaria del metodo restablecerContrasena(string usuarioID, string contraseña) de forma Erronea
         [Test]
         public void PruebaValidarRestablecerContrasena()
         {
             logicaRestablecer lgr = new logicaRestablecer();
             bool _respuesta;


             _respuesta = lgr.restablecerContrasena(RecursosPU_Mod1.id2, RecursosPU_Mod1.PruebaRestablecerClave);
             Assert.AreEqual(true, _respuesta);
         }
         // Prueba unitaria de la excepcion del metodo restablecerContrasena()
          [Test]
         [ExpectedException(typeof(ExcepcionesSKD.ExceptionSKD))]
         public void PruebaValidarRestablecerContrasenaexc()
         {
             logicaRestablecer lgr = new logicaRestablecer();
             bool _respuesta;
             _respuesta = lgr.restablecerContrasena(null, RecursosPU_Mod1.PruebaRestablecerClave);
              
         }
          
    }
}
