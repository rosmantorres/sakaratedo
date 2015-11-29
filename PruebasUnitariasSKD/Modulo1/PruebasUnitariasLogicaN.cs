﻿using System;
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
            string[] resp = lg.iniciarSesion(RecursosPU_Mod1.pruebaCorrectoCorreo, RecursosPU_Mod1.PruebaCorrectoClave);
            Assert.AreEqual(resp[0], RecursosPU_Mod1.PruebaCorrectoResultado);

        }
        // Prueba unitaria de la excepcion del metodo EnviarCorreo()
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public  void PruebaEnviarCorreoFallidoEXC()
        {
            logicaLogin lg = new logicaLogin();
            bool resp = lg.EnviarCorreo(null);
            resp.ToString();

        }
        // Prueba unitaria de la excepcion del metodo IniciarSesion()
        [Test]
        [ExpectedException(typeof(NullReferenceException))]
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
        [ExpectedException(typeof(ArgumentNullException))]
        public void PruebaHashFallido()
        {
            string resp = logicaLogin.hash(null);
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