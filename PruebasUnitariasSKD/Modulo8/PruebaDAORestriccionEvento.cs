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
    public class PruebaDAORestriccionEvento
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
        public void PruebaConsultarEventosConRestriccion()
        {
            IDaoRestriccionEvento DAO = FabricaDAOSqlServer.ObtenerDAORestriccionEvento();
            listaEntidad = DAO.ConsultarEventosConRestriccion();
            Assert.NotNull(listaEntidad);
        }

        [Test]
        public void PruebaAgregarRestriccionEvento()
        {
            entidad = DominioSKD.Fabrica.FabricaEntidades.ObtenerRestriccionEvento("Negra",10, 15, "M", 7, "PUevento");
            IDaoRestriccionEvento DAO = FabricaDAOSqlServer.ObtenerDAORestriccionEvento();
            a = DAO.AgregarRestriccionEvento(entidad);
            Assert.IsTrue(a);
        }

        [Test]
        public void PruebaEliminarRestriccionEvento()
        {
            entidad = DominioSKD.Fabrica.FabricaEntidades.ObtenerRestriccionEvento(18,"Negra", 10, 15, "M", 7, "PUevento");
            IDaoRestriccionEvento DAO = FabricaDAOSqlServer.ObtenerDAORestriccionEvento();
            a = DAO.EliminarRestriccionEvento(entidad);
            Assert.IsTrue(a);
        }

        [Test]
        public void PruebaModificarRestriccionEvento()
        {
            entidad = DominioSKD.Fabrica.FabricaEntidades.ObtenerRestriccionEvento(1,"Negro", 10, 15, "M", 7, "PUevento");
            IDaoRestriccionEvento DAO = FabricaDAOSqlServer.ObtenerDAORestriccionEvento();
            a = DAO.ModificarRestriccionEvento(entidad);
            Assert.IsTrue(a);
        }

        [Test]
        public void PruebaConsultarEventosSinRestriccion()
        {
            IDaoRestriccionEvento DAO = FabricaDAOSqlServer.ObtenerDAORestriccionEvento();
            listaEntidad = DAO.ConsultarEventosSinRestriccion();
            Assert.NotNull(listaEntidad);
        }

        [Test]
        public void PruebaEventosQuePuedeAsistirAtleta()
        {
            IDaoRestriccionEvento DAO = FabricaDAOSqlServer.ObtenerDAORestriccionEvento();
            listaEntidad = DAO.EventosQuePuedeAsistirAtleta(1);
            Assert.NotNull(listaEntidad);
        }
        #endregion


    }
}