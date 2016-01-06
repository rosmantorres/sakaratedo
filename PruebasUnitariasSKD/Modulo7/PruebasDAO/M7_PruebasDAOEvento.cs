using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DatosSKD.Fabrica;
using DatosSKD.DAO.Modulo7;
using DominioSKD.Fabrica;
using DominioSKD;
using ExcepcionesSKD.Modulo7;

namespace PruebasUnitariasSKD.Modulo7.PruebasDAO
{

    /// <summary>
    /// Clase que contiene las pruebas unitarias para DaoCinta
    /// </summary>
    [TestFixture]
    public class M7_PruebasDAOEvento
    {
        #region Atributos
        Persona idPersona;
        FabricaEntidades fabricaEntidades;
        FabricaDAOSqlServer fabricaSql;
        DaoEvento baseDeDatosEvento;
        #endregion

        #region SetUp & TearDown
        [SetUp]
        public void Init()
        {
            fabricaSql = new FabricaDAOSqlServer();
            fabricaEntidades = new FabricaEntidades();
            baseDeDatosEvento = fabricaSql.ObtenerDaoEventoM7();
            idPersona = new Persona();
            idPersona.ID = 6;
        }

        [TearDown]
        public void Clean()
        {
            idPersona = null;
            fabricaEntidades = null;
            fabricaSql = null;
            baseDeDatosEvento = null;
        }
        #endregion
        /// <summary>
        /// Método de prueba para ConSultarXId en DAO
        /// </summary>
        [Test]
        public void PruebaDetallarEventoXId()
        {
            Evento idEvento = (Evento)fabricaEntidades.ObtenerEvento();
            idEvento.Id = 5;
            Evento evento = (Evento)baseDeDatosEvento.ConsultarXId(idEvento);
            Assert.AreEqual("La vida en el Dojo", evento.Nombre);
        }
        /// <summary>
        /// Método para probar que una matriculada detallado no sea nulo en DAO
        /// </summary>
        [Test]
        public void PruebaDetallarEventoXIdNoNulo()
        {
            Evento idEvento = (Evento)fabricaEntidades.ObtenerEvento();
            idEvento.Id = 5;
            Evento evento = (Evento)baseDeDatosEvento.ConsultarXId(idEvento);
            Assert.NotNull(evento);
        }

        /// <summary>
        /// Método para probar la exception de número entero invalido de prueba detalle evento en DAO
        /// </summary>

        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void DetalleEventoNumeroEnteroException()
        {
            Evento idEvento = (Evento)fabricaEntidades.ObtenerEvento();;
            idEvento.Id = -1;
            Evento evento = (Evento)baseDeDatosEvento.ConsultarXId(idEvento);
        }

        /// <summary>
        /// Método para probar que la lista obtenida tiene cero o mas eventos pagos en DAO
        /// </summary>
        [Test]
        public void PruebaListarEventosPagos()
        {
            List<Entidad> listaEvento = baseDeDatosEvento.ListarEventosPagos(idPersona);
            Assert.GreaterOrEqual(listaEvento.Count, 0);
        }
        /// <summary>
        /// Método para probar que la lista obtenida no sea nula en DAO
        /// </summary>
        [Test]
        public void PruebaListarEventosPagosNoNulo()
        {
            List<Entidad> listaEvento = baseDeDatosEvento.ListarEventosPagos(idPersona);
            Assert.NotNull(listaEvento);
        }

        /// <summary>
        /// Método para probar la exception de número entero invalido de listar eventos pagos en DAO
        /// </summary>
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void ListarEventoPagoNumeroEnteroException()
        {
            idPersona.ID = -1;
            List<Entidad> listaEvento = baseDeDatosEvento.ListarEventosPagos(idPersona);
           
        }
        /// <summary>
        /// Método para probar que la lista obtenida tiene cero o mas competencias pagadas por atleta en DAO
        /// </summary>
        [Test]
        public void PruebaListarCompetenciasPagas()
        {
            List<Entidad> listaCompetencia = baseDeDatosEvento.ListarCompetenciasPaga(idPersona);
            Assert.GreaterOrEqual(listaCompetencia.Count, 0);
        }

        /// <summary>
        /// Método para probar que la lista obtenida no sea nula en DAO
        /// </summary>
        [Test]
        public void PruebaListarCompetenciasPagasNoNula()
        {
            List<Entidad> listaCompetencia = baseDeDatosEvento.ListarCompetenciasPaga(idPersona);
            Assert.NotNull(listaCompetencia);
        }

        /// <summary>
        /// Método para probar la exception de número entero invalido de listar competencias pagadas en DAO
        /// </summary>
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void ListarCompetenciaPagaNumeroEnteroException()
        {
            idPersona.ID = -1;
            List<Entidad> listaCompetencia = baseDeDatosEvento.ListarCompetenciasPaga(idPersona);
        }

        /// <summary>
        /// Método para probar que la lista obtenida tiene cero o mas eventos en DAO
        /// </summary>
        [Test]
        public void PruebaListarEventosAsistidos()
        {
            List<Entidad> listaEvento = baseDeDatosEvento.ListarEventosAsistidos(idPersona);
            Assert.GreaterOrEqual(listaEvento.Count, 0);
        }

        /// <summary>
        /// Método para probar que la lista obtenida no sea nula en DAO
        /// </summary>
        [Test]
        public void PruebaListarEventosAsistidosNoNulo()
        {
            List<Entidad> listaEvento = baseDeDatosEvento.ListarEventosAsistidos(idPersona);
            Assert.NotNull(listaEvento);
        }

        /// <summary>
        /// Método para probar la exception de número entero invalido de listar eventos asistidos en DAO
        /// </summary>
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void ListarEventoAsistidoNumeroEnteroException()
        {
            idPersona.ID = -1;
            List<Entidad> listaEvento = baseDeDatosEvento.ListarEventosAsistidos(idPersona);
        }

        /// <summary>
        /// Método para probar que la lista obtenida tiene cero o mas competencias en DAO
        /// </summary>
        [Test]
        public void PruebaListarCompetenciasAsistidas()
        {
            List<Entidad> listaCompetencia = baseDeDatosEvento.ListarCompetenciasAsistidas(idPersona);
            Assert.GreaterOrEqual(listaCompetencia.Count, 0);
        }

        /// <summary>
        /// Método para probar que la lista obtenida no sea nula en DAO
        /// </summary>
        [Test]
        public void PruebaListarCompetenciasAsistidasNoNula()
        {
            List<Entidad> listaCompetencia = baseDeDatosEvento.ListarCompetenciasAsistidas(idPersona);
            Assert.NotNull(listaCompetencia);
        }

        /// <summary>
        /// Método para probar la exception de número entero invalido de listar eventos asistidos en DAO
        /// </summary>
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void ListarCompetenciaAsistidaNumeroEnteroException()
        {
            idPersona.ID = -1;
            List<Entidad> listaCompetencia = baseDeDatosEvento.ListarCompetenciasAsistidas(idPersona);
        }

    }
}
