using DominioSKD;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSKD.DAO.Modulo11;
using DatosSKD.InterfazDAO.Modulo11;
using DatosSKD.Fabrica;


namespace PruebasUnitariasSKD.Modulo11
{
        /// <summary>
    /// Clase que se encarga de Realizar las pruebas unitarias de los metodos de la Clase DAO
    /// </summary>
    /// 

    [TestFixture]

    public class M11_PruebasDAOResultadoAscenso
    {
   
        #region Atributos
        List<Entidad> listaEntidad;
        public string idEvento;
        public string idCompetencia;
        public Entidad entidad;

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

        public void PruebaListarResultadoEventoPvacio()
        {

            IDaoResultadoAscenso DAO = FabricaDAOSqlServer.ObtenerDAOResultadoAscenso();
            listaEntidad = DAO.ListarResultadosEventosPasados();
            Assert.IsNotNull(listaEntidad);

        }



        [Test]

        public void PruebaListarResultadoEventoPcontar()
        {

            IDaoResultadoAscenso DAO = FabricaDAOSqlServer.ObtenerDAOResultadoAscenso();
            listaEntidad = DAO.ListarResultadosEventosPasados();
            Assert.AreEqual(1, listaEntidad.ToArray().Length);

        }



        [Test]

        public void PruebalistaCategoriasEventoContar()
        {
            IDaoResultadoAscenso DAO = FabricaDAOSqlServer.ObtenerDAOResultadoAscenso();
            listaEntidad = DAO.ListaCategoriaEvento(idEvento);
            Assert.AreEqual(1, listaEntidad.ToArray().Length);
        }

        [Test]

        public void PruebalistaCategoriasEventoVacio()
        {
            IDaoResultadoAscenso DAO = FabricaDAOSqlServer.ObtenerDAOResultadoAscenso();
            listaEntidad = DAO.ListaCategoriaEvento(idEvento);
            Assert.NotNull(listaEntidad);


        }

        [Test]

        public void PruebaListarAtletaEnCatyAsc()
        {
            IDaoResultadoAscenso DAO = FabricaDAOSqlServer.ObtenerDAOResultadoAscenso();
            entidad = DominioSKD.Fabrica.FabricaEntidades.ObtenerEventoM10();
            ((DominioSKD.Entidades.Modulo10.Evento)entidad).Id = 3;
            ((DominioSKD.Entidades.Modulo10.Evento)entidad).Categoria.Id = 1;
            listaEntidad = DAO.ListaAtletasEnCategoriaYAscenso(entidad);
            Assert.AreEqual(1,listaEntidad.ToArray().Length);


        }

        [Test]

        public void PruebaListarInscritosExamenAsc()
        {
            IDaoResultadoAscenso DAO = FabricaDAOSqlServer.ObtenerDAOResultadoAscenso();
            listaEntidad = DAO.ListaInscritosExamenAscenso(entidad);
            Assert.NotNull(listaEntidad);

        }


        [Test]

        public void PruebaConsultarEventoDetalle()
        {
            IDaoResultadoAscenso DAO = FabricaDAOSqlServer.ObtenerDAOResultadoAscenso();
            

        }
        #endregion
    }
}
