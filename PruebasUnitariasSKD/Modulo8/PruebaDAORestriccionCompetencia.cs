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
    class PruebaDAORestriccionCompetencia
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
        public void PruebaAgregarRestriccionEvento()
        {
            entidad = DominioSKD.Fabrica.FabricaEntidades.ObtenerRestriccionEvento("Negra", 10, 15, "M", 7, "PUevento",1);
            IDaoRestriccionEvento DAO = FabricaDAOSqlServer.ObtenerDAORestriccionEvento();
            a = DAO.AgregarRestriccionEvento(entidad);
            Assert.IsTrue(a);
        }

        
        #endregion


    }
 }