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
        string idEvento;
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
            Entidad categoria = DominioSKD.Fabrica.FabricaEntidades.ObtenerCategoria();
            ((DominioSKD.Entidades.Modulo10.Evento)entidad).Id = 3;
            ((DominioSKD.Entidades.Modulo12.Categoria)categoria).Id = 1;
            ((DominioSKD.Entidades.Modulo10.Evento)entidad).Categoria = categoria as DominioSKD.Entidades.Modulo12.Categoria;
            listaEntidad = DAO.ListaAtletasEnCategoriaYAscenso(entidad);
            Assert.NotNull(listaEntidad);


        }

        [Test]

        public void PruebaListarInscritosExamenAsc()
        {

          
            IDaoResultadoAscenso DAO = FabricaDAOSqlServer.ObtenerDAOResultadoAscenso();
            entidad = DominioSKD.Fabrica.FabricaEntidades.ObtenerEventoM10();
            Entidad categoria = DominioSKD.Fabrica.FabricaEntidades.ObtenerCategoria();
            ((DominioSKD.Entidades.Modulo12.Categoria)categoria).Id = 1;
            ((DominioSKD.Entidades.Modulo10.Evento)entidad).Categoria = categoria as DominioSKD.Entidades.Modulo12.Categoria;
            ((DominioSKD.Entidades.Modulo10.Evento)entidad).Id = 3;
           

            listaEntidad = DAO.ListaInscritosExamenAscenso(entidad);
            Assert.NotNull(listaEntidad);

        }

        [Test]

        public void PruebaAgregarResultadoAscenso()
        {
            DominioSKD.Fabrica.FabricaEntidades fabrica = new DominioSKD.Fabrica.FabricaEntidades();

            IDaoResultadoAscenso DAO = FabricaDAOSqlServer.ObtenerDAOResultadoAscenso();

            bool e;
            listaEntidad = new List<Entidad>();
            entidad = DominioSKD.Fabrica.FabricaEntidades.ObtenerResultadoAscenso();
            ((DominioSKD.Entidades.Modulo11.ResultadoAscenso)entidad).Aprobado = "S";
            ((DominioSKD.Entidades.Modulo11.ResultadoAscenso)entidad).Inscripcion.Id = 1;
            listaEntidad.Add(entidad);
            e = DAO.Agregar(listaEntidad);
            Assert.IsTrue(e);

        }

        [Test]

        public void PruebaModificarResultadoAscenso()
        {
            DominioSKD.Fabrica.FabricaEntidades fabrica = new DominioSKD.Fabrica.FabricaEntidades();

            IDaoResultadoAscenso DAO = FabricaDAOSqlServer.ObtenerDAOResultadoAscenso();

            bool e;
            listaEntidad = new List<Entidad>();
            entidad = DominioSKD.Fabrica.FabricaEntidades.ObtenerResultadoAscenso();
            ((DominioSKD.Entidades.Modulo11.ResultadoAscenso)entidad).Aprobado = "N";
            ((DominioSKD.Entidades.Modulo11.ResultadoAscenso)entidad).Inscripcion.Id = 32;
            ((DominioSKD.Entidades.Modulo11.ResultadoAscenso)entidad).Inscripcion.Evento.Id = 3;
            listaEntidad.Add(entidad);
            e = DAO.Modificar(listaEntidad);
            Assert.IsTrue(e);

        }

        [Test]

        public void PruebaConsultarEventoDetalle()
        {
            IDaoResultadoAscenso DAO = FabricaDAOSqlServer.ObtenerDAOResultadoAscenso();
            DominioSKD.Fabrica.FabricaEntidades fabrica = new DominioSKD.Fabrica.FabricaEntidades();
            entidad = DominioSKD.Fabrica.FabricaEntidades.ObtenerEventoM10();

            ((DominioSKD.Entidades.Modulo10.Evento)entidad).Id = 3;
            Assert.NotNull(entidad);
        }

        
        #endregion
    }
}
