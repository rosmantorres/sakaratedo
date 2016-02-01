using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PruebasUnitariasSKD.Modulo1;
using DominioSKD.Entidades.Modulo1;
using DominioSKD.Entidades.Modulo2;
using DatosSKD.DAO.Modulo2;
using DatosSKD.Fabrica;
using DominioSKD;
using DominioSKD.Fabrica;


namespace PruebasUnitariasSKD.Modulo2
{
    [TestFixture]
    class PruebasUnitariasDatos
    {
        FabricaDAOSqlServer laFabrica = new FabricaDAOSqlServer();
        private FabricaEntidades laFabricaE = new FabricaEntidades();
      [Test]
        public void PruebaValidarconsultarRolesUsuario()
        {
            List<Rol> _respuesta;
            DaoRoles conexionBD = (DaoRoles)laFabrica.ObtenerDaoRoles();
            _respuesta = conexionBD.consultarRolesUsuario(RecursosPU_Mod1.Id);
            Assert.AreNotEqual(null, _respuesta);

        }
        [Test]
        public void PruebaValidarObtenerRolesDeSistema()
        {
            DaoRoles conexionBD = (DaoRoles)laFabrica.ObtenerDaoRoles();
            List<Rol> _respuesta = conexionBD.ConsultarTodos().Cast<Rol>().ToList();
            Assert.AreNotEqual(null, _respuesta);

        }

        [Test]
        [ExpectedException(typeof(ExcepcionesSKD.ExceptionSKD))]
        public void PruebaValidarconsultarRolesUsuarioEXC()
        {
            List<Rol> _respuesta;
            DaoRoles conexionBD = (DaoRoles)laFabrica.ObtenerDaoRoles();
            _respuesta = conexionBD.consultarRolesUsuario(null);

        }
        [Test]
        public void PruebaValidarObtenerUsuario()
        {
            DaoRoles conexionBD = (DaoRoles)laFabrica.ObtenerDaoRoles();
            Rol elRol = (Rol)laFabricaE.ObtenerRol_M2();
            elRol.Id_rol = Int32.Parse(RecursosPU_Mod1.Id);
            elRol.Nombre = RecursosPU_Mod1.usuario.ToString();
            Cuenta _respuesta = (Cuenta)conexionBD.ConsultarXId(elRol);
            Assert.AreNotEqual(null, _respuesta);

        }



    }
}
