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
        [Test]
        public void PruebaprioridadRol()
        {

            int _respuesta = logicaRol.prioridadRol(RecursosPU_Mod2.Rol);
            int _respuesta1 = logicaRol.prioridadRol(RecursosPU_Mod2.Rol2);
            int _respuesta2 = logicaRol.prioridadRol(RecursosPU_Mod2.Rol3);
            int _respuesta3 = logicaRol.prioridadRol(RecursosPU_Mod2.Rol4);
            int _respuesta4 = logicaRol.prioridadRol(RecursosPU_Mod2.Rol5);
            int _respuesta5 = logicaRol.prioridadRol(RecursosPU_Mod2.Rol6);
            int _respuesta6 = logicaRol.prioridadRol(RecursosPU_Mod2.Rol7);
            int _respuesta7 = logicaRol.prioridadRol(RecursosPU_Mod2.Rol8);
            int _respuesta8 = logicaRol.prioridadRol(RecursosPU_Mod2.Rol9);
            Assert.AreEqual(1, _respuesta);
            Assert.AreEqual(1, _respuesta1);
            Assert.AreEqual(2, _respuesta2);
            Assert.AreEqual(2, _respuesta3);
            Assert.AreEqual(3, _respuesta4);
            Assert.AreEqual(3, _respuesta5);
            Assert.AreEqual(4, _respuesta6);
            Assert.AreEqual(5, _respuesta7);
            Assert.AreEqual(6, _respuesta8);

        }
        // Prueba unitaria de la excepcion del metodo prioridadRol() Exc
        [Test]
        [ExpectedException(typeof(ExcepcionesSKD.Modulo2.RolesException))]
        public void PruebaprioridadRolExc()
        {

            int _respuesta = logicaRol.prioridadRol(RecursosPU_Mod2.RolInvalido);

        }
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
    /*    [Test]
        public void PreubaEncriptadoYdesencriptado()
        {
            string Archivo = cripto.EncriptarCadenaDeCaracteres(RecursosPU_Mod2.Id, RecursosLogicaModulo2.claveDES);
            Console.WriteLine(cripto.hash("12345"));
            Archivo = cripto.DesencriptarCadenaDeCaracteres(Archivo, RecursosLogicaModulo2.claveDES);
        }*/

        // Prueba unitaria  del metodo cargarRoles()
   /*     [Test]
        public void PruebaValidarcargarRoles()
        {
            List<Rol> _respuesta = logicaRol.cargarRoles();
            Assert.AreNotEqual(null, _respuesta);

        }*/
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
        // Prueba unitaria  del metodo validarPrioridad()
        [Test]
        public void PruebaValidarRoles()
        {
            List<Rol> _respuesta = logicaRol.cargarRoles();
            List<Rol> _respuesta2 = logicaRol.validarPrioridad(_respuesta, RecursosPU_Mod2.Rol);
            Assert.AreEqual(_respuesta, _respuesta2);
        }
        // Prueba unitaria  del metodo validarPrioridad() EXC
        [Test]
        [ExpectedException(typeof(ExcepcionesSKD.Modulo2.RolesException))]
        public void PruebaValidarRolesEXC()
        {
            List<Rol> _respuesta = logicaRol.cargarRoles();
            List<Rol> _respuesta2 = logicaRol.validarPrioridad(_respuesta, RecursosPU_Mod2.Descripcion);
            Assert.AreEqual(_respuesta, _respuesta2);
        }
        // Prueba unitaria  del metodo rolNoEditable()
        [Test]
        public void PruebaValidarrolNoEditable()
        {
            List<Rol> _respuesta = logicaRol.cargarRoles();
            List<Rol> _respuesta2 = logicaRol.rolNoEditable(_respuesta, RecursosPU_Mod2.Rol);
            Assert.IsNotNull(_respuesta2);
        }
        // Prueba unitaria  del metodo rolNoEditable() EXC
        [Test]
        [ExpectedException(typeof(ExcepcionesSKD.Modulo2.RolesException))]
        public void PruebaValidarrolNoEditableEXC()
        {
            List<Rol> _respuesta = logicaRol.cargarRoles();
            List<Rol> _respuesta2 = logicaRol.rolNoEditable(_respuesta, RecursosPU_Mod2.Descripcion);
        }
        // Prueba unitaria  del metodo cuentaAConsultar()
        [Test]
        public void PruebaValidarcuentaAConsultar()

        {
            Cuenta Login = (Cuenta)laFabricaE.ObtenerCuenta_M1();
            Login.Id = 35;
            ComandoCuentaUsuario lg = (ComandoCuentaUsuario)laFabrica.ObtenerCuentaUsuario();
            lg.LaEntidad = Login;
            Cuenta _respuesta = (Cuenta)lg.Ejecutar();
            Assert.AreEqual(_respuesta.Nombre_usuario , RecursosPU_Mod2.usuario);
        }
        // Prueba unitaria  del metodo filtrarRoles()
   /*     [Test]
        public void PruebaValidafiltrarRoles()
        {
            List<Rol> _respuesta = logicaRol.cargarRoles();
            List<Rol> _respuesta2 = logicaRol.consultarRolesUsuario("1");
            List<Rol> _respuesta3 = logicaRol.filtrarRoles(_respuesta2, _respuesta);
          List<Rol> respuesta = new List<Rol>();
            Assert.AreNotEqual(_respuesta3,respuesta);
        }
        // Prueba unitaria  del metodo filtrarRoles() EXCEPCION
        [Test]
        [ExpectedException(typeof(ExcepcionesSKD.Modulo2.RolesException))]
        public void PruebaValidafiltrarRolesEXC()
        {
            List<Rol> _respuesta = logicaRol.cargarRoles();
            List<Rol> _respuesta2 = logicaRol.consultarRolesUsuario("1");
            List<Rol> _respuesta3 = logicaRol.filtrarRoles(null, _respuesta);
            List<Rol> respuesta = new List<Rol>();
        }*/


    }
}
