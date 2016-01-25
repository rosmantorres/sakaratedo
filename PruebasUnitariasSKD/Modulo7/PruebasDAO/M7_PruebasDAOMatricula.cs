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
using DominioSKD.Entidades.Modulo7;

namespace PruebasUnitariasSKD.Modulo7.PruebasDAO
{
    /// <summary>
    /// Clase que contiene las pruebas unitarias para DaoMatricula
    /// </summary>
    [TestFixture]
    public class M7_PruebasDAOMatricula
    {
        #region Atributos
        private PersonaM7 idPersona;
        private FabricaEntidades fabricaEntidades;
        private FabricaDAOSqlServer fabricaSql;
        private DaoMatricula baseDeDatosMatricula;

        #endregion

        #region SetUp & TearDown
        /// <summary>
        /// Método que se ejecuta antes de cada prueba
        /// </summary>
        [SetUp]
        public void Init()
        {
            fabricaSql = new FabricaDAOSqlServer();
            fabricaEntidades = new FabricaEntidades();
            baseDeDatosMatricula = fabricaSql.ObtenerDaoMatriculaM7();
            idPersona = (PersonaM7)FabricaEntidades.ObtenerPersonaM7();
            idPersona.Id = 6;
        }

        /// <summary>
        /// Método que se ejecuta luego de cada prueba
        /// </summary>
        [TearDown]
        public void Clean()
        {
            idPersona = null;
            fabricaEntidades = null;
            fabricaSql = null;
            baseDeDatosMatricula = null;
        }
        #endregion

        #region Test

        /// <summary>
        /// Método de prueba para Consultar el monto de las las matriculas en DAO
        /// </summary>
        [Test]
        public void PruebaMontoPagoMatricula()
        {

          
            MatriculaM7 idMatricula = (MatriculaM7)FabricaEntidades.ObtenerMatriculaM7();
            idMatricula.Id = 25;
            float matricula = (float)baseDeDatosMatricula.MontoPagoMatricula(idPersona, idMatricula);
            Assert.AreEqual(1200, matricula );
        }
        /// <summary>
        /// Método de prueba para ConSultarXId las matriculas en DAO
        /// </summary>
        [Test]
        public void PruebaDetallarMatriculaXId()
        {
            
            MatriculaM7 idMatricula = (MatriculaM7)FabricaEntidades.ObtenerMatriculaM7();
            idMatricula.Id =25;
            MatriculaM7 matricula = (MatriculaM7)baseDeDatosMatricula.ConsultarXId(idMatricula);
            Assert.AreEqual("CCA1-CAF-CAFE", matricula.Identificador);
        }


        /// <summary>
        /// Método para probar que una matricula detallada no sea nulo
        /// </summary>
        [Test]
        public void PruebaDetallarMatriculaXIdNoNulo()
        {
           
            MatriculaM7 idMatricula = (MatriculaM7)FabricaEntidades.ObtenerMatriculaM7();
            idMatricula.Id = 1;
             MatriculaM7 matricula = (MatriculaM7)baseDeDatosMatricula.ConsultarXId(idMatricula);
            Assert.NotNull(matricula);
        }

        /// <summary>
        /// Método para probar la exception de número entero invalido de detallar matricula pagada
        /// </summary>
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void DetallarMatriculaPagaNumeroEnteroException()
        {
            DaoMatricula baseDeDatosMatricula = new DaoMatricula();//esto se sustituye con la fabrica
            MatriculaM7 idMatricula = (MatriculaM7)FabricaEntidades.ObtenerMatriculaM7();
            idMatricula.Id = -1;
            MatriculaM7 matricula = (MatriculaM7)baseDeDatosMatricula.ConsultarXId(idMatricula);
        }
       
        
        /// Método de prueba para ListarMatriculasObtenidas en DAO
        /// </summary>
        [Test]
        public void PruebaListarMatriculasObtenidasDAO()
        {
           
           
            List<Entidad> listaMatricula = baseDeDatosMatricula.ListarMatriculasPagas(idPersona);
            Assert.GreaterOrEqual(listaMatricula.Count, 0);
        }

        /// <summary>
        /// Método para probar que la lista obtenida de matriculas sea distinto de  nulo nulo
        /// </summary>
        [Test]
        public void PruebaListarMatriculasPagasNulas()
        {
            
            List<Entidad> listaMatricula = baseDeDatosMatricula.ListarMatriculasPagas(idPersona);
            Assert.NotNull(listaMatricula);
        }


        /// <summary>
        /// Método para probar la exception de número entero invalido de listar matriculas pagas
        /// </summary>
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void ListarMatriculasPagasEnteroException()
        {
          
            idPersona.Id = -1;
            List<Entidad> listaMatricula = baseDeDatosMatricula.ListarMatriculasPagas(idPersona);
        }
        #endregion*/
    }
}
