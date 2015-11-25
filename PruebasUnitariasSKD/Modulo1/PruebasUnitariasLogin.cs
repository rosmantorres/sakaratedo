using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using LogicaNegociosSKD.Modulo1;
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
            login lg = new login();
            string[] resp = lg.iniciarSesion(RecursosPU_Mod1.pruebaErrorCorreo, RecursosPU_Mod1.PruebaErrorClave);
            Assert.AreEqual(resp, null);

        }
        // Prueba unitaria del metodo IniciarSesion() de forma correcta
        [Test]
        public static void PruebaInicioSesionCorrecto()
        {
            login lg = new login();
            string[] resp = lg.iniciarSesion(RecursosPU_Mod1.pruebaCorrectoCorreo, RecursosPU_Mod1.PruebaCorrectoClave);
            Assert.AreEqual(resp[0], RecursosPU_Mod1.PruebaCorrectoResultado);

        }
        // Prueba unitaria de la excepcion del metodo EnviarCorreo()
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public static void PruebaEnviarCorreoFallidoEXC()
        {
            login lg = new login();
            bool resp = lg.EnviarCorreo(null);
            resp.ToString();

        }
        // Prueba unitaria de la excepcion del metodo IniciarSesion()
        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public static void PruebaIniciarSesionFallidoEXC()
        {
            login lg = new login();
            string[] resp = lg.iniciarSesion(null,null);
            resp.ToString();

        }
        // Prueba unitaria del metodo Enviarcorreo() de forma correcta

        [Test]
        public static void PruebaEnviarCorreoCorrecto()
        {
            login lg = new login();
            bool resp = lg.EnviarCorreo(RecursosPU_Mod1.PruebaCorrectoResultado);
            Assert.AreEqual(resp, true);

        }
        [Test]
        // Prueba unitaria del metodo hash() de forma correcta

        public void PruebaHashCorrecto()
        {
            login lg = new login();

            Assert.AreEqual(lg.hash(RecursosPU_Mod1.pruebaHash2), lg.hash(RecursosPU_Mod1.pruebaHash));
            
        }
        [Test]
        // Prueba unitaria de la excepcion del metodo hash()
        [ExpectedException(typeof(ArgumentNullException))]
        public void PruebaHashFallido()
        {
            login lg = new login();
            string resp = lg.hash(null);
        }
        // Prueba unitaria del metodo ValidarCorreo() de forma correcta
       /*[Test]
        public void PruebaValidarCorreoCorrecto()
        {
            login lg = new login();
            string _respuesta;


            _respuesta = lg.validarCorreo(RecursosPU_Mod1.pruebaCorrectoCorreo);

            Assert.AreEqual(true, _respuesta);
        } */
        // Prueba unitaria del metodo ValidarCorreo() de forma Erronea
        /* [Test]
         public void PruebaValidarCorreoFallido()
         {
             login lg = new login();
             string _respuesta;


             _respuesta = lg.validarCorreo(RecursosPU_Mod1.pruebaCorrectoCorreo);

             Assert.AreEqual(false, _respuesta);
         } */
    }
}
