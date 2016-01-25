using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using LogicaNegociosSKD.Modulo2;
using DominioSKD.Entidades.Modulo2;
using DominioSKD.Entidades.Modulo1;
using LogicaNegociosSKD.Comandos.Modulo2;
using LogicaNegociosSKD.Fabrica;
using DominioSKD;
using DominioSKD.Fabrica;

namespace PruebasUnitariasSKD.Modulo2
{
    [TestFixture]

    class PruebasUnitariasLogicaN
    {
        AlgoritmoDeEncriptacion cripto = new AlgoritmoDeEncriptacion();
        private FabricaComandos laFabrica = new FabricaComandos();
        private FabricaEntidades laFabricaE = new FabricaEntidades();

        // Prueba unitaria de la excepcion del metodo consultarRolesUsuario()
        [Test]
        public void PruebaValidarconsultarRolesUsuario()
        {
            Cuenta Login = (Cuenta)laFabricaE.ObtenerCuenta_M1();
            Login.Id = 1;
          ComandoRolesUsuario  lg = (ComandoRolesUsuario)laFabrica.ObtenerRolesUsuario();
          lg.LaEntidad = Login;
          List<Entidad> _respuesta = lg.Ejecutar();
            Assert.AreNotEqual(null, _respuesta);

        }
        // Prueba unitaria de la excepcion del metodo consultarRolesUsuario() excepcion
        [Test]
        [ExpectedException(typeof(ExcepcionesSKD.Modulo2.RolesException))]
        public void PruebaValidarconsultarRolesUsuarioEXC()
        {
            Cuenta Login = (Cuenta)laFabricaE.ObtenerCuenta_M1();
            Login = null;
            ComandoRolesUsuario lg = (ComandoRolesUsuario)laFabrica.ObtenerRolesUsuario();
            lg.LaEntidad = Login;
            List<Entidad> _respuesta = lg.Ejecutar();
        }
        // Prueba unitaria  del metodo prioridadRol()
   
        // Prueba unitaria de la excepcion del metodo prioridadRol() Exc
     
        // Prueba unitaria  del metodo agregarRol(),consultarRolesUsuario() y eliminarRol();
        [Test]
        public void PruebaagregarEliminarConsultarRol()
        {
            List<Rol> listaRol = new List<Rol>();
            Rol elRol = (Rol)laFabricaE.ObtenerRol_M2();
            elRol.Id = 3;
            listaRol.Add(elRol);
            Cuenta Login = (Cuenta)laFabricaE.ObtenerCuenta_M1();
            Login.Roles = listaRol;
            Login.Id = 1;

            ComandoAgregarRol lg = (ComandoAgregarRol)laFabrica.ObtenerAgregarRol();
            lg.LaEntidad = Login;
            bool _respuesta = _respuesta = lg.Ejecutar();

            Assert.AreEqual(true, _respuesta);

            ComandoEliminarRol lg2 = (ComandoEliminarRol)laFabrica.ObtenerEliminarRol();
            lg2.LaEntidad = Login;
            bool _respuesta2  = lg2.Ejecutar();
            Assert.AreEqual(true, _respuesta2);

        }
        // Prueba unitaria  del metodo eliminarRol();Exc
        [Test]
        [ExpectedException(typeof(ExcepcionesSKD.Modulo2.RolesException))]
        public void PruebaEliminarRolEXC()
        {
            List<Rol> listaRol = new List<Rol>();
            
            Cuenta Login = (Cuenta)laFabricaE.ObtenerCuenta_M1();
            Login.Roles = listaRol;
            Login.Id = 1;

            ComandoEliminarRol lg2 = (ComandoEliminarRol)laFabrica.ObtenerEliminarRol();
            lg2.LaEntidad = Login;
            bool _respuesta2 = lg2.Ejecutar();
        }
    
        [Test]
        [ExpectedException(typeof(ExcepcionesSKD.Modulo2.RolesException))]
        public void PruebaAgregaryelimanarRolEXC()
        {
            List<Rol> listaRol = new List<Rol>();
            
            Cuenta Login = (Cuenta)laFabricaE.ObtenerCuenta_M1();
            Login.Id = 1;
            ComandoAgregarRol lg = (ComandoAgregarRol)laFabrica.ObtenerAgregarRol();
            lg.LaEntidad = Login;
            bool _respuesta1 = lg.Ejecutar();
            ComandoEliminarRol lg2 = (ComandoEliminarRol)laFabrica.ObtenerEliminarRol();
            lg2.LaEntidad = Login;
            bool _respuesta2 = lg2.Ejecutar();
        }
        [Test]
        public void PruebaValidarcuentaAConsultar()
        {
            Cuenta Login = (Cuenta)laFabricaE.ObtenerCuenta_M1();
            Login.Id = 35;
            ComandoCuentaUsuario lg = (ComandoCuentaUsuario)laFabrica.ObtenerCuentaUsuario();
            lg.LaEntidad = Login;
            Cuenta _respuesta = (Cuenta)lg.Ejecutar();
            Assert.AreEqual(_respuesta.Nombre_usuario, RecursosPU_Mod2.usuario);
        }
      


    }
}
