using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Interfaz_Presentadores.Modulo2;
using DominioSKD.Entidades.Modulo2;
using LogicaNegociosSKD.Fabrica;
using LogicaNegociosSKD.Comandos.Modulo2;
using DominioSKD.Fabrica;
using DominioSKD;
using DominioSKD.Entidades.Modulo1;

namespace PruebasUnitariasSKD.Modulo2
{
    class PruebaUnitariasPresentadoresM2
    {

        [TestFixture]
        class PruebaUnitariaPresentadores
        {
           private FabricaComandos laFabrica = new FabricaComandos();
           private FabricaEntidades laFabricaE = new FabricaEntidades();


            [Test]
            public void M2PruebaFiltrarRoles()
            {
                ValidacionesM2 lg = new ValidacionesM2();

                ComandoRolesDeSistema _respuesta = (ComandoRolesDeSistema)laFabrica.ObtenerRolesDeSistema();
                List<Rol> RolesSis = _respuesta.Ejecutar();
                Cuenta usuario = (Cuenta)laFabricaE.ObtenerCuenta_M1();
                usuario.Id = 1;
                ComandoRolesUsuario _respuesta2 = (ComandoRolesUsuario)laFabrica.ObtenerRolesUsuario();
                _respuesta2.LaEntidad = usuario;
                List<Rol> RolesUsu = _respuesta2.Ejecutar();
               List<Rol> filtrado = lg.filtrarRoles(RolesUsu, RolesSis);
               Assert.AreNotEqual(filtrado, RolesSis);
            }

            [Test]
            [ExpectedException(typeof(ExcepcionesSKD.Modulo2.RolesException))]
            public void M2PruebaFiltrarRolesEXC()
            {
                ValidacionesM2 lg = new ValidacionesM2();

                ComandoRolesDeSistema _respuesta = (ComandoRolesDeSistema)laFabrica.ObtenerRolesDeSistema();
                List<Rol> RolesSis = _respuesta.Ejecutar();
                Cuenta usuario = (Cuenta)laFabricaE.ObtenerCuenta_M1();
                usuario.Id = 1;
                ComandoRolesUsuario _respuesta2 = (ComandoRolesUsuario)laFabrica.ObtenerRolesUsuario();
                _respuesta2.LaEntidad = usuario;
                List<Rol> RolesUsu = _respuesta2.Ejecutar();
                List<Rol> filtrado = lg.filtrarRoles(null, null);
            }

            [Test]
            public void M2PruebaValidarRoles()
            {
                ValidacionesM2 lg = new ValidacionesM2();
                ComandoRolesDeSistema _respuesta = (ComandoRolesDeSistema)laFabrica.ObtenerRolesDeSistema();
                List<Rol> RolesSis = _respuesta.Ejecutar();
                List<Rol> Validacion = lg.validarPrioridad(RolesSis, RecursosPU_Mod2.Rol);                            
                Assert.AreEqual(RolesSis, Validacion);
            }

            [Test]
            [ExpectedException(typeof(ExcepcionesSKD.Modulo2.RolesException))]
            public void M2PruebaValidarRolesExc()
            {
                ValidacionesM2 lg = new ValidacionesM2();
                ComandoRolesDeSistema _respuesta = (ComandoRolesDeSistema)laFabrica.ObtenerRolesDeSistema();
                List<Rol> RolesSis = _respuesta.Ejecutar();
                List<Rol> Validacion = lg.validarPrioridad(RolesSis, RecursosPU_Mod2.Descripcion);                            
                Assert.AreEqual(RolesSis, Validacion);
            }

            [Test]
            public void M2PrioridadRol()
            {
                ValidacionesM2 lg = new ValidacionesM2();
                int _respuesta = lg.prioridadRol(RecursosPU_Mod2.Rol);
                int _respuesta1 = lg.prioridadRol(RecursosPU_Mod2.Rol2);
                int _respuesta2 = lg.prioridadRol(RecursosPU_Mod2.Rol3);
                int _respuesta3 = lg.prioridadRol(RecursosPU_Mod2.Rol4);
                int _respuesta4 = lg.prioridadRol(RecursosPU_Mod2.Rol5);
                int _respuesta5 = lg.prioridadRol(RecursosPU_Mod2.Rol6);
                int _respuesta6 = lg.prioridadRol(RecursosPU_Mod2.Rol7);
                int _respuesta7 = lg.prioridadRol(RecursosPU_Mod2.Rol8);
                int _respuesta8 = lg.prioridadRol(RecursosPU_Mod2.Rol9);
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

            [Test]
            [ExpectedException(typeof(ExcepcionesSKD.Modulo2.RolesException))]
            public void PruebaprioridadRolExc()
            {
                ValidacionesM2 lg = new ValidacionesM2();
                int _respuesta;
                _respuesta = lg.prioridadRol(RecursosPU_Mod2.RolInvalido);
            }

            [Test]
            public void PruebaValidarrolNoEditable()
            {
                ValidacionesM2 lg = new ValidacionesM2();
                ComandoRolesDeSistema _respuesta = (ComandoRolesDeSistema)laFabrica.ObtenerRolesDeSistema();
                List<Rol> RolesSis = _respuesta.Ejecutar();
                List<Rol>_respuesta2 = lg.rolNoEditable(RolesSis, RecursosPU_Mod2.Rol);
                Assert.IsNotNull(_respuesta2);
            }

            [Test]
            [ExpectedException(typeof(ExcepcionesSKD.Modulo2.RolesException))]
            public void PruebaValidarrolNoEditableEXC()
            {
                ValidacionesM2 lg = new ValidacionesM2();
                ComandoRolesDeSistema _respuesta = (ComandoRolesDeSistema)laFabrica.ObtenerRolesDeSistema();
                List<Rol> RolesSis = _respuesta.Ejecutar();
                List<Rol> _respuesta2 = lg.rolNoEditable(RolesSis, RecursosPU_Mod2.Descripcion);
            }

            [Test]
            public void PruebaHash()
            {
                Encriptacion lg = new Encriptacion();
                Assert.AreEqual(lg.hash(RecursosPU_Mod2.pruebaHash2), lg.hash(RecursosPU_Mod2.pruebaHash));
            }

            [Test]
            [ExpectedException(typeof(ExcepcionesSKD.Modulo1.HashException))]
            public void PruebaHashExc()
            {
                Encriptacion lg = new Encriptacion();
                string resp = lg.hash(null);
            }


        }
    }
}




