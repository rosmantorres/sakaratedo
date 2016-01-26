using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Interfaz_Presentadores.Modulo2;
using LogicaNegociosSKD.Comandos.Modulo1;
using LogicaNegociosSKD.Fabrica;
using DominioSKD.Fabrica;
using DominioSKD.Entidades.Modulo1;


namespace PruebasUnitariasSKD.Modulo1
{
    [TestFixture]

    class PruebasUnitariasLogicaN
    {
        Encriptacion cripto = new Encriptacion();
        private FabricaComandos laFabrica = new FabricaComandos();
        private FabricaEntidades laFabricaE = new FabricaEntidades();

        // Prueba unitaria del metodo IniciarSesion() de forma erronea
        [Test]
        public void PruebaInicioSesionFallida()
        {
            Cuenta Login = (Cuenta)laFabricaE.ObtenerCuenta_M1();
            Login.Nombre_usuario=RecursosPU_Mod1.pruebaErrorCorreo;
            Login.Contrasena = RecursosPU_Mod1.PruebaErrorClave;
            ComandoIniciarSesion lg = (ComandoIniciarSesion)laFabrica.ObtenerIniciarSesion();
            lg.LaEntidad = Login;
            string[] resp = lg.Ejecutar();
            Assert.AreEqual(resp, null);

        }
        // Prueba unitaria del metodo IniciarSesion() de forma correcta
        [Test]
        public void PruebaInicioSesionCorrecto()
        {
            Cuenta Login = (Cuenta)laFabricaE.ObtenerCuenta_M1();
            Login.Nombre_usuario = RecursosPU_Mod1.pruebainicioCorreo;
            Login.Contrasena = RecursosPU_Mod1.PruebaRestablecerClave;
            ComandoIniciarSesion lg = (ComandoIniciarSesion)laFabrica.ObtenerIniciarSesion();
            lg.LaEntidad = Login;
            string[] resp = lg.Ejecutar();
            Assert.AreEqual(resp[1], RecursosPU_Mod1.pruebainicioCorreo);

        }
        // Prueba unitaria de la excepcion del metodo EnviarCorreo()
        [Test]
        [ExpectedException(typeof(FormatException))]
        public void PruebaEnviarCorreoFallidoEXC()
        {
            
             Cuenta Login = (Cuenta)laFabricaE.ObtenerCuenta_M1();
            Login.PersonaUsuario._CorreoElectronico=RecursosPU_Mod1.usuario;
            ComandoEnviarCorreo lg = (ComandoEnviarCorreo)laFabrica.ObtenerEnviarCorreo();
            lg.LaEntidad = Login;
            bool resp = lg.Ejecutar();
            resp.ToString();

        }
        // Prueba unitaria de la excepcion del metodo IniciarSesion()
        [Test]
        [ExpectedException(typeof(ExcepcionesSKD.ExceptionSKD))]
        public void PruebaIniciarSesionFallidoEXC()
        {
            Cuenta Login = (Cuenta)laFabricaE.ObtenerCuenta_M1();
            Login.Nombre_usuario = null;
            Login.Contrasena = null;
            ComandoIniciarSesion lg = (ComandoIniciarSesion)laFabrica.ObtenerIniciarSesion();
            lg.LaEntidad = Login;
            string[] resp = lg.Ejecutar();
            resp.ToString();

        }
        // Prueba unitaria del metodo Enviarcorreo() de forma correcta

        [Test]
        public void PruebaEnviarCorreoCorrecto()
        {
            Cuenta Login = (Cuenta)laFabricaE.ObtenerCuenta_M1();
            Login.PersonaUsuario._CorreoElectronico = RecursosPU_Mod1.PruebaCorrectoResultado;
            ComandoEnviarCorreo lg = (ComandoEnviarCorreo)laFabrica.ObtenerEnviarCorreo();
            lg.LaEntidad = Login;
            bool resp = lg.Ejecutar();
            Assert.AreEqual(resp, true);

        }
        [Test]
        // Prueba unitaria del metodo hash() de forma correcta

        public void PruebaHashCorrecto()
        {
            Assert.AreEqual(cripto.hash(RecursosPU_Mod1.pruebaHash2), cripto.hash(RecursosPU_Mod1.pruebaHash));

        }
        [Test]
        // Prueba unitaria de la excepcion del metodo hash()
        [ExpectedException(typeof(ExcepcionesSKD.Modulo1.HashException))]
        public void PruebaHashFallido()
        {
            string resp = cripto.hash(null);
        }
        // Prueba unitaria del metodo ValidarCorreo() de forma correcta
        [Test]
        public void PruebaValidarCorreoCorrecto()
        {
            Cuenta Login = (Cuenta)laFabricaE.ObtenerCuenta_M1();
            Login.PersonaUsuario._CorreoElectronico = RecursosPU_Mod1.PruebaCorrectoResultado;
            ComandoConsultarCorreo lg = (ComandoConsultarCorreo)laFabrica.ObtenerConsultarCorreo();
            lg.LaEntidad = Login;
            string _respuesta = lg.Ejecutar();

            Assert.AreNotEqual(null, _respuesta);
        }
        // Prueba unitaria del metodo ValidarCorreo() de forma Erronea
        [Test]
        public void PruebaValidarCorreoFallido()
        {
            Cuenta Login = (Cuenta)laFabricaE.ObtenerCuenta_M1();
            Login.PersonaUsuario._CorreoElectronico = RecursosPU_Mod1.pruebaErrorCorreo;
            ComandoConsultarCorreo lg = (ComandoConsultarCorreo)laFabrica.ObtenerConsultarCorreo();
            lg.LaEntidad = Login;
            string _respuesta = lg.Ejecutar();

            Assert.AreEqual(null, _respuesta);
        }
        [Test]
        // Prueba unitaria de la excepcion del metodo hash()
        [ExpectedException(typeof(ExcepcionesSKD.ExceptionSKD))]
        public void PruebaValidarCorreoFallidoexc()
        {
            Cuenta Login = (Cuenta)laFabricaE.ObtenerCuenta_M1();
            Login.PersonaUsuario._CorreoElectronico = null;
            ComandoConsultarCorreo lg = (ComandoConsultarCorreo)laFabrica.ObtenerConsultarCorreo();
            lg.LaEntidad = Login;
            string _respuesta = lg.Ejecutar();
        }
        // Prueba unitaria del metodo restablecerContrasena(string usuarioID, string contraseña) de forma Erronea
        [Test]
        public void PruebaValidarRestablecerContrasena()
        {
            Cuenta Login = (Cuenta)laFabricaE.ObtenerCuenta_M1();
            Login.Id =2;
            Login.Contrasena = RecursosPU_Mod1.PruebaRestablecerClave;
            ComandoRestablecerContraseña lg = (ComandoRestablecerContraseña)laFabrica.ObtenerRestablecerContraseña();
            lg.LaEntidad = Login;
            bool _respuesta = lg.Ejecutar();
            Assert.AreEqual(true, _respuesta);
        }
        // Prueba unitaria de la excepcion del metodo restablecerContrasena()
        [Test]
        [ExpectedException(typeof(ExcepcionesSKD.ExceptionSKD))]
        public void PruebaValidarRestablecerContrasenaexc()
        {
            Cuenta Login = (Cuenta)laFabricaE.ObtenerCuenta_M1();
            Login.Id = 1;
            Login.Contrasena = null;
            ComandoRestablecerContraseña lg = (ComandoRestablecerContraseña)laFabrica.ObtenerRestablecerContraseña();
            lg.LaEntidad = Login;
            bool _respuesta = lg.Ejecutar();

        }

    }
}
