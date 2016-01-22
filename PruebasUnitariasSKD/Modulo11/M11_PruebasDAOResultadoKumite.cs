using DatosSKD.Fabrica;
using DatosSKD.InterfazDAO.Modulo11;
using DominioSKD;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasUnitariasSKD.Modulo11
{
    /// <summary>
    /// Clase que se encarga de Realizar las pruebas unitarias de los metodos de la Clase DAO
    /// </summary>
    /// 

    [TestFixture]
    public class M11_PruebasDAOResultadoKumite
    {


        #region Atributos
        List<Entidad> listaEntidad;
        string idEvento;
        public string idCompetencia;
        public Entidad entidad;
        List<string> listaString;

        #endregion

        #region setUp
        [SetUp]
        public void init()
        {
            listaEntidad = new List<Entidad>();
            idEvento = "3";
            idCompetencia = "11";

        }


        #endregion

        #region Pruebas Unitarias

        [Test]


        public void ListaAtletasParticipanCompetenciaKumite()
        {

            DominioSKD.Fabrica.FabricaEntidades fabrica = new DominioSKD.Fabrica.FabricaEntidades();

            IDaoResultadoKumite DAO = FabricaDAOSqlServer.ObtenerDAOResultadoKumite();
            entidad = DominioSKD.Fabrica.FabricaEntidades.ObtenerResultadoKumite();
            Entidad competencia = fabrica.ObtenerCompetencia();
            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).TipoCompetencia = "1";
            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Id = 6;
            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Categoria.Id = 1;

            listaEntidad = DAO.ListaAtletasParticipanCompetenciaKumite(entidad);
            Assert.AreEqual(1, listaEntidad.ToArray().Length);

        }


        [Test]


        public void ListaAtletasParticipanCompetenciaKumiteAmbos()
        {

            DominioSKD.Fabrica.FabricaEntidades fabrica = new DominioSKD.Fabrica.FabricaEntidades();

            IDaoResultadoKumite DAO = FabricaDAOSqlServer.ObtenerDAOResultadoKumite();
            entidad = DominioSKD.Fabrica.FabricaEntidades.ObtenerResultadoKumite();
            Entidad competencia = fabrica.ObtenerCompetencia();
            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).TipoCompetencia = "1";
            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Id = 6;
            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Categoria.Id = 1;

            listaEntidad = DAO.ListaAtletasParticipanCompetenciaKumiteAmbos(entidad);
            Assert.AreEqual(1, listaEntidad.ToArray().Length);

        }


        [Test]


        public void ListInscritosCompetencia()
        {

            DominioSKD.Fabrica.FabricaEntidades fabrica = new DominioSKD.Fabrica.FabricaEntidades();

            IDaoResultadoKumite DAO = FabricaDAOSqlServer.ObtenerDAOResultadoKumite();
            entidad = DominioSKD.Fabrica.FabricaEntidades.ObtenerResultadoKumite();
            Entidad competencia = fabrica.ObtenerCompetencia();
            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).TipoCompetencia = "1";
            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Id = 6;
            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Categoria.Id = 1;

            listaEntidad = DAO.ListaInscritosCompetencia(entidad);
            Assert.AreEqual(1, listaEntidad.ToArray().Length);

        }
        #endregion
    }
}
