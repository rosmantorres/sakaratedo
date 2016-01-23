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

        public void ListarCategoriaCompetencia() 
        {

            DominioSKD.Fabrica.FabricaEntidades fabrica = new DominioSKD.Fabrica.FabricaEntidades();
            IDaoResultadoKata DAO = FabricaDAOSqlServer.ObtenerDAOResultadoKata();
           
            Entidad competencia = fabrica.ObtenerCompetencia();
            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Id = 11;
            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).TipoCompetencia = "1";

            listaEntidad = DAO.ListaCategoriaCompetencia(competencia);
            Assert.NotNull(listaEntidad);
        }


        [Test]

        public void ListaAtletasParticipanComKata()
        {
            DominioSKD.Fabrica.FabricaEntidades fabrica = new DominioSKD.Fabrica.FabricaEntidades();
            
            IDaoResultadoKata DAO = FabricaDAOSqlServer.ObtenerDAOResultadoKata();
            Entidad competencia = fabrica.ObtenerCompetencia();
            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).TipoCompetencia = "1";
            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Id = 10;
            Entidad categoria = fabrica.ObtenerCategoria();
            ((DominioSKD.Entidades.Modulo12.Categoria)categoria).Id = 1;
            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Categoria = categoria as DominioSKD.Entidades.Modulo12.Categoria;
          
            listaEntidad = DAO.ListaAtletasParticipanCompetenciaKata(competencia);
            Assert.NotNull(listaEntidad);
        }


        [Test]

        public void ListaAtletasParticipanComKataAmbos() 
        {
            DominioSKD.Fabrica.FabricaEntidades fabrica = new DominioSKD.Fabrica.FabricaEntidades();

            IDaoResultadoKata DAO = FabricaDAOSqlServer.ObtenerDAOResultadoKata();
            Entidad competencia = fabrica.ObtenerCompetencia();
            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).TipoCompetencia = "1";
            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Id = 10;
            Entidad categoria = fabrica.ObtenerCategoria();
            ((DominioSKD.Entidades.Modulo12.Categoria)categoria).Id = 1;
            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Categoria = categoria as DominioSKD.Entidades.Modulo12.Categoria;
            listaEntidad = DAO.ListaAtletasParticipanCompetenciaKataAmbos(competencia);
            Assert.NotNull(listaEntidad);
        }

        [Test]

        public void AgregarResultadoKata()
        {
            DominioSKD.Fabrica.FabricaEntidades fabrica = new DominioSKD.Fabrica.FabricaEntidades();

            IDaoResultadoKata DAO = FabricaDAOSqlServer.ObtenerDAOResultadoKata();
            
            bool e;
            listaEntidad = new List<Entidad>();
            entidad = DominioSKD.Fabrica.FabricaEntidades.ObtenerResultadoKata();
            ((DominioSKD.Entidades.Modulo11.ResultadoKata)entidad).Inscripcion.Id = 4;
            ((DominioSKD.Entidades.Modulo11.ResultadoKata)entidad).Jurado1 = 1;
            ((DominioSKD.Entidades.Modulo11.ResultadoKata)entidad).Jurado2 = 1;
            ((DominioSKD.Entidades.Modulo11.ResultadoKata)entidad).Jurado3 = 1; 
            listaEntidad.Add(entidad);
            e = DAO.Agregar(listaEntidad);
            Assert.IsTrue(e);
        }

        [Test]

        public void ModificarResultadoKata()
        {
            DominioSKD.Fabrica.FabricaEntidades fabrica = new DominioSKD.Fabrica.FabricaEntidades();

            IDaoResultadoKata DAO = FabricaDAOSqlServer.ObtenerDAOResultadoKata();

            bool e;
            listaEntidad = new List<Entidad>();
            entidad = DominioSKD.Fabrica.FabricaEntidades.ObtenerResultadoKata();
            ((DominioSKD.Entidades.Modulo11.ResultadoKata)entidad).Inscripcion.Id = 1;
            ((DominioSKD.Entidades.Modulo11.ResultadoKata)entidad).Inscripcion.Competencia.Id = 5;
            ((DominioSKD.Entidades.Modulo11.ResultadoKata)entidad).Jurado1 = 2;
            ((DominioSKD.Entidades.Modulo11.ResultadoKata)entidad).Jurado2 = 3;
            ((DominioSKD.Entidades.Modulo11.ResultadoKata)entidad).Jurado3 = 1;

            listaEntidad.Add(entidad);
            e = DAO.Modificar(listaEntidad);
            Assert.IsTrue(e);
        }
        #endregion
    }
}
