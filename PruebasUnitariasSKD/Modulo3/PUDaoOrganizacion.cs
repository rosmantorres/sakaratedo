using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using LogicaNegociosSKD;
using LogicaNegociosSKD.Comandos.Modulo3;
using DominioSKD.Fabrica;
using DominioSKD.Entidades.Modulo3;
using DominioSKD;
using DatosSKD.Fabrica;
using DatosSKD.InterfazDAO.Modulo3;
using DatosSKD.DAO.Modulo3;

namespace PruebasUnitariasSKD.Modulo3
{
    [TestFixture]
    class PUDaoOrganizacion
    {

        private FabricaDAOSqlServer fabricaDAO;
        private Entidad miEntidad;
        private Entidad miEntidadModificar;
        private Entidad miEntidadAgregar;

        [SetUp]
        public void init()
        {
            FabricaEntidades miFabrica = new FabricaEntidades();
            miEntidad = miFabrica.ObtenerOrganizacion_M3(1, "Seito Karate-do", "Av 24, calle 8 edificio Morales, Altamira, Caracas", 2123117754, "seitokaratedo@gmail.com", "Distrito Federal", "Cobra-do");
            miEntidadModificar = miFabrica.ObtenerOrganizacion_M3(1, "Seito", "Av 24, calle 8 edificio Morales, Altamira, Caracas", 2123117754, "seitokaratedo@gmail.com", "Distrito Federal", "Cobra-do");
            miEntidadAgregar = miFabrica.ObtenerOrganizacion_M3(19, "Karate-do", "Av 24, calle 8 edificio Morales, Altamira, Falcon", 2123117754, "seitokaratedo@gmail.com", "Falcon", "Cobra-do");       
            
        }

        [Test]
        public void PruebaValidarNombreOrganizacion()
        {
            bool resultado;
            this.fabricaDAO = new FabricaDAOSqlServer();
            IDaoOrganizacion miDaoOrganizacion = this.fabricaDAO.ObtenerDaoOrganizacion();
            resultado = miDaoOrganizacion.ValidarNombreOrganizacion(miEntidad);
            Assert.IsTrue(resultado);

        }

        [Test]
        public void PruebaValidarEstilo()
        {
            bool resultado;
            this.fabricaDAO = new FabricaDAOSqlServer();
            IDaoOrganizacion miDaoOrganizacion = this.fabricaDAO.ObtenerDaoOrganizacion();
            resultado = miDaoOrganizacion.ValidarEstilo(miEntidad);
            Assert.IsTrue(resultado);

        }

        [Test]
        public void PruebaComboOrganizaciones()
        {
            List<Entidad> resultado;
            this.fabricaDAO = new FabricaDAOSqlServer();
            IDaoOrganizacion miDaoOrganizacion = this.fabricaDAO.ObtenerDaoOrganizacion();
            resultado = miDaoOrganizacion.ComboOrganizaciones();
            Assert.IsNotEmpty(resultado);

        }

        [Test]
        public void PruebaAgregarOrganizacion()
        {
            bool resultado;
            this.fabricaDAO = new FabricaDAOSqlServer();
            IDaoOrganizacion miDaoOrganizacion = this.fabricaDAO.ObtenerDaoOrganizacion();
            resultado = miDaoOrganizacion.Agregar(miEntidadAgregar);
            Assert.IsTrue(resultado);

        }

        [Test]
        public void PruebaModificarOrganizacion()
        {
            bool resultado;
            this.fabricaDAO = new FabricaDAOSqlServer();
            IDaoOrganizacion miDaoOrganizacion = this.fabricaDAO.ObtenerDaoOrganizacion();
            resultado = miDaoOrganizacion.Modificar(miEntidadModificar);
            Assert.IsTrue(resultado);

        }

        [Test]
        public void PruebaConsultarTodos()
        {
            List<Entidad> resultado;
            this.fabricaDAO = new FabricaDAOSqlServer();
            IDaoOrganizacion miDaoOrganizacion = this.fabricaDAO.ObtenerDaoOrganizacion();
            resultado = miDaoOrganizacion.ConsultarTodos();
            Assert.IsNotEmpty(resultado);

        }

        [Test]
        public void PruebaConsultarXId()
        {
            Entidad resultado;
            this.fabricaDAO = new FabricaDAOSqlServer();
            IDaoOrganizacion miDaoOrganizacion = this.fabricaDAO.ObtenerDaoOrganizacion();
            resultado = miDaoOrganizacion.ConsultarXId(miEntidad);
            Assert.IsNotNull(resultado);

        }

    }
}
