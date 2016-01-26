using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSKD.InterfazDAO.Modulo8;
using DominioSKD;
using DatosSKD.DAO.Modulo8;
using DatosSKD.Fabrica;

namespace PruebasUnitariasSKD.Modulo8
{
    [TestFixture]
    class PruebasRestCinta
    {

        #region Atributos
        List<Entidad> listaEntidad;
        public string idEvento;
        public string idCompetencia;
        public Entidad entidad;
        public Entidad entidad2;
        public bool a;
        #endregion

        [SetUp]
        public void init()
        {
            listaEntidad = new List<Entidad>();
            idEvento = "3";
            idCompetencia = "11";
        }

        [TearDown]
        public void clean()
        {
            listaEntidad = null;
            entidad = null;
        }

        #region Pruebas Unitarias

        [Test]
        public void PruebaConsultarCintaTodas()
        {
            IDaoRestriccionCinta DAO = FabricaDAOSqlServer.ObtenerDAORestriccionCinta();
            listaEntidad = DAO.ConsultarCintaTodas();
            Assert.NotNull(listaEntidad);
        }

        [Test]
        public void PruebaAgregarRestriccionCinta()
        {
            entidad = DominioSKD.Fabrica.FabricaEntidades.ObtenerRestriccionCinta("Descripcion pu", 1, 2, 3, 4);
            IDaoRestriccionCinta DAO = FabricaDAOSqlServer.ObtenerDAORestriccionCinta();
            entidad.Id = 5;
           a = DAO.AgregarRestriccionCinta(entidad);
            Assert.IsTrue(a);
        }

        [Test]
        public void PruebaModificarRestriccionEvento()
        {
            entidad = DominioSKD.Fabrica.FabricaEntidades.ObtenerRestriccionCinta(2, "Modificar pu2", 50, 50, 50, 50);
            IDaoRestriccionCinta DAO = FabricaDAOSqlServer.ObtenerDAORestriccionCinta();
            a = DAO.ModificarRestriccionCinta(entidad);
            Assert.IsTrue(a);
        }

        [Test]
        public void PruebaConsultarRestriccionCintaDT()
        {
            IDaoRestriccionCinta DAO = FabricaDAOSqlServer.ObtenerDAORestriccionCinta();
            listaEntidad = DAO.ConsultarRestriccionCintaDT();
            Assert.NotNull(listaEntidad);
        }


        #endregion


    }
}