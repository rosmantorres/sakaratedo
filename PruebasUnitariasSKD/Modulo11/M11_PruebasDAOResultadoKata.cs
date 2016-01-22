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
    public class M11_PruebasDAOResultadoKata
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

        public void ListarCompetenciasAsistidasContar()
        {
            IDaoResultadoKata DAO = FabricaDAOSqlServer.ObtenerDAOResultadoKata();

            listaEntidad = DAO.ListarCompetenciasAsistidas();
            Assert.AreEqual(5, listaEntidad.ToArray().Length);
        }


        [Test]

        public void ListarCompetenciasAsistidasVacio()
        {
            IDaoResultadoKata DAO = FabricaDAOSqlServer.ObtenerDAOResultadoKata();

            listaEntidad = DAO.ListarCompetenciasAsistidas();
            Assert.NotNull(listaEntidad);
        }


        [Test]

        public void ListarEspecialidadesComp()
        {
            IDaoResultadoKata DAO = FabricaDAOSqlServer.ObtenerDAOResultadoKata();

            listaString = DAO.ListaEspecialidadesCompetencia(idCompetencia);
            Assert.NotNull(listaString);
        }

        [Test]

        public void ListarEspecialidadesCompContar()
        {
            IDaoResultadoKata DAO = FabricaDAOSqlServer.ObtenerDAOResultadoKata();

            listaString = DAO.ListaEspecialidadesCompetencia(idCompetencia);
            Assert.AreEqual(2, listaString.ToArray().Length);
        }



        [Test]

        public void ListarCategoriaCompetencia()  // FALTA
        {

            DominioSKD.Fabrica.FabricaEntidades fabrica = new DominioSKD.Fabrica.FabricaEntidades();
            IDaoResultadoKata DAO = FabricaDAOSqlServer.ObtenerDAOResultadoKata();
            Entidad categoria = fabrica.ObtenerCategoria();
            Entidad competencia = fabrica.ObtenerCompetencia();
            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Id = 11;
            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).TipoCompetencia = "1";
          //  ((DominioSKD.Entidades.Modulo10.Evento)categoria).Categoria = categoria as DominioSKD.Entidades.Modulo12.Categoria;

            listaEntidad = DAO.ListaCategoriaCompetencia(competencia);
            Assert.NotNull(listaEntidad);
        }


        [Test]

        public void ListaAtletasParticipanComKata() //FALTA
        {
            DominioSKD.Fabrica.FabricaEntidades fabrica = new DominioSKD.Fabrica.FabricaEntidades();
            
            IDaoResultadoKata DAO = FabricaDAOSqlServer.ObtenerDAOResultadoKata();
            entidad = DominioSKD.Fabrica.FabricaEntidades.ObtenerInscripcion();
            Entidad competencia = fabrica.ObtenerCompetencia();
            Entidad categoria = fabrica.ObtenerCategoria();
           
            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).TipoCompetencia = "2";
            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Id = 6;
            ((DominioSKD.Entidades.Modulo12.Categoria)categoria).Id = 6;

       
   
            Assert.NotNull(listaEntidad);
        }


        [Test]

        public void ListaAtletasParticipanComKataAmbos() //FALTA
        {
            DominioSKD.Fabrica.FabricaEntidades fabrica = new DominioSKD.Fabrica.FabricaEntidades();

            IDaoResultadoKata DAO = FabricaDAOSqlServer.ObtenerDAOResultadoKata();
            
            Entidad entidad = fabrica.ObtenerCompetencia();
            ((DominioSKD.Entidades.Modulo12.Competencia)entidad).Id = 1;
            listaEntidad = DAO.ListaAtletasParticipanCompetenciaKataAmbos(entidad);
            Assert.NotNull(listaEntidad);
        }
        #endregion
    }
}
