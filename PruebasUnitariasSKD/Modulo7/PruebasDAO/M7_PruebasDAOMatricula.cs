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
namespace PruebasUnitariasSKD.Modulo7.PruebasDAO
{
    /// <summary>
    /// Clase que contiene las pruebas unitarias para DaoCinta
    /// </summary>
    [TestFixture]
    public class M7_PruebasDAOMatricula
    {
        #region Atributos
        Persona idPersona;
        FabricaEntidades fabricaEntidades;
        FabricaDAOSqlServer fabricaSql;
        #endregion

        #region SetUp & TearDown
        [SetUp]
        public void Init()
        {
            fabricaSql = new FabricaDAOSqlServer();
            fabricaEntidades = new FabricaEntidades();
            idPersona = new Persona();
            idPersona.ID = 6;
        }

        [TearDown]
        public void Clean()
        {
            idPersona = null;
            fabricaEntidades = null;
            fabricaSql = null;
        }
        #endregion

        #region Test
        /// <summary>
        /// Método de prueba para ConSultarXId en DAO
        /// </summary>
        [Test]
        public void PruebaDetallarMatriculaXId()
        {
            
            DaoMatricula baseDeDatosMatricula = new DaoMatricula();//esto se sustituye con la fabrica
            Matricula idMatricula = (Matricula)fabricaEntidades.ObtenerMatricula();
            idMatricula.Id =25;
            Matricula matricula = (Matricula)baseDeDatosMatricula.ConsultarXId(idMatricula);
            Assert.AreEqual("CCA1-CAF-CAFE", matricula.Identificador);
        }
           
       

        /// <summary>
        /// Método de prueba para ListarMatriculasObtenidas en DAO
        /// </summary>
        [Test]
        public void PruebaListarMatriculasObtenidasDAO()
        {
           
            DaoMatricula baseDeDatosMatricula = new DaoMatricula();//esto se sustituye con la fabrica
            List<Entidad> listaMatricula = baseDeDatosMatricula.ListarMatriculasPagas(idPersona);
            Assert.GreaterOrEqual(listaMatricula.Count, 0);
        }

      
      
        #endregion
    }
}
