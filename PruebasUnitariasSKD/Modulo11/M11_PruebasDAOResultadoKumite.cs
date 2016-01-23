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
            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).TipoCompetencia = "2";
            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Id = 6;
            Entidad categoria = fabrica.ObtenerCategoria();
            ((DominioSKD.Entidades.Modulo12.Categoria)categoria).Id = 2;

            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Categoria = categoria as DominioSKD.Entidades.Modulo12.Categoria;

            listaEntidad = DAO.ListaAtletasParticipanCompetenciaKumite(entidad);
            Assert.NotNull(listaEntidad);

        }


        [Test]


        public void ListaAtletasParticipanCompetenciaKumiteAmbos()
        {

            DominioSKD.Fabrica.FabricaEntidades fabrica = new DominioSKD.Fabrica.FabricaEntidades();

            IDaoResultadoKumite DAO = FabricaDAOSqlServer.ObtenerDAOResultadoKumite();
            entidad = DominioSKD.Fabrica.FabricaEntidades.ObtenerResultadoKumite();
            Entidad competencia = fabrica.ObtenerCompetencia();
            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).TipoCompetencia = "3";
            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Id = 7;
            Entidad categoria = fabrica.ObtenerCategoria();
            ((DominioSKD.Entidades.Modulo12.Categoria)categoria).Id = 1;
            

            listaEntidad = DAO.ListaAtletasParticipanCompetenciaKumiteAmbos(entidad);
            Assert.NotNull(listaEntidad);

        }


        [Test]


        public void ListInscritosCompetencia()
        {

            DominioSKD.Fabrica.FabricaEntidades fabrica = new DominioSKD.Fabrica.FabricaEntidades();

            IDaoResultadoKumite DAO = FabricaDAOSqlServer.ObtenerDAOResultadoKumite();
            entidad = DominioSKD.Fabrica.FabricaEntidades.ObtenerInscripcion();
            Entidad competencia = fabrica.ObtenerCompetencia();
            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).TipoCompetencia = "1";
            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Id = 6;
            Entidad categoria = fabrica.ObtenerCategoria();
            ((DominioSKD.Entidades.Modulo12.Categoria)categoria).Id = 1;

            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Categoria = categoria as DominioSKD.Entidades.Modulo12.Categoria;

            listaEntidad = DAO.ListaInscritosCompetencia(entidad);
            Assert.NotNull(listaEntidad);

        }

        [Test]
        public void AgregarResultadoKumite()

    {
            DominioSKD.Fabrica.FabricaEntidades fabrica = new DominioSKD.Fabrica.FabricaEntidades();

            IDaoResultadoKumite DAO = FabricaDAOSqlServer.ObtenerDAOResultadoKumite();
            
            bool e;
            listaEntidad = new List<Entidad>();
            entidad = DominioSKD.Fabrica.FabricaEntidades.ObtenerResultadoKumite();
            ((DominioSKD.Entidades.Modulo11.ResultadoKumite)entidad).Inscripcion1.Id = 4;
            ((DominioSKD.Entidades.Modulo11.ResultadoKumite)entidad).Inscripcion2.Id = 1;
            ((DominioSKD.Entidades.Modulo11.ResultadoKumite)entidad).Puntaje1 = 1;
            ((DominioSKD.Entidades.Modulo11.ResultadoKumite)entidad).Puntaje2 = 1; 
            listaEntidad.Add(entidad);
            e = DAO.Agregar(listaEntidad);
            Assert.IsTrue(e);

        }


        [Test]
        public void ModificarResultadoKumite()
        {
            DominioSKD.Fabrica.FabricaEntidades fabrica = new DominioSKD.Fabrica.FabricaEntidades();

            IDaoResultadoKumite DAO = FabricaDAOSqlServer.ObtenerDAOResultadoKumite();

            bool e;
            listaEntidad = new List<Entidad>();
            entidad = DominioSKD.Fabrica.FabricaEntidades.ObtenerResultadoKumite();
            ((DominioSKD.Entidades.Modulo11.ResultadoKumite)entidad).Inscripcion1.Id = 9;
            ((DominioSKD.Entidades.Modulo11.ResultadoKumite)entidad).Inscripcion2.Id = 11;
            ((DominioSKD.Entidades.Modulo11.ResultadoKumite)entidad).Puntaje1 = 2;
            ((DominioSKD.Entidades.Modulo11.ResultadoKumite)entidad).Puntaje2 = 5;
            ((DominioSKD.Entidades.Modulo11.ResultadoKumite)entidad).Inscripcion1.Competencia.Id = 6;
            listaEntidad.Add(entidad);
            e = DAO.Modificar(listaEntidad);
            Assert.IsTrue(e);

        }
        #endregion
    }
}
