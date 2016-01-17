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
    public class M7_PruebasDAOCinta
    {
        #region Atributos
        private Persona idPersona;
        private FabricaEntidades fabricaEntidades;
        private FabricaDAOSqlServer fabricaSql;
        private DaoCinta baseDeDatosCinta;
        #endregion

        #region SetUp & TearDown
        /// <summary>
        /// Método que se ejecuta antes de cada prueba
        /// </summary>
        [SetUp]
        public void Init()
        {
            fabricaSql = new FabricaDAOSqlServer();
            baseDeDatosCinta = fabricaSql.ObtenerDaoCintaM7();
            fabricaEntidades = new FabricaEntidades();
            idPersona = new Persona();//esto se sustituye con fabrica de entidad
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
            baseDeDatosCinta = null;
        }
        #endregion

        #region Test
        
        /// <summary>
        /// Método de prueba para ListarCintasObtenidas en DAO
        /// </summary>
        [Test]
        public void PruebaListarCintasObtenidasDAO()
        {
            List<Entidad> listaCinta = baseDeDatosCinta.ListarCintasObtenidas(idPersona);
            Assert.GreaterOrEqual(listaCinta.Count, 1);
        }

        /// <summary>
        /// Método para probar la exception de número entero invalido para ListarCintasObtenidas en DAO
        /// </summary>
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void ListarCintasNumeroEnteroException()
        {
            idPersona.Id = -1;
            List<Entidad> listaCinta = baseDeDatosCinta.ListarCintasObtenidas(idPersona);
        }


        /// <summary>
        /// Método para probar que la lista de cintas obtenidas no es nula en DAO
        /// </summary>
        [Test]
        public void PruebaListarCintasObtenidasNoNula()
        {
            List<Entidad> listaCinta = baseDeDatosCinta.ListarCintasObtenidas(idPersona);
            Assert.NotNull(listaCinta);
        }

        /// <summary>
        /// Método de prueba para ConSultarXId en DAO
        /// </summary>
        [Test]
        public void PruebaDetallarCintaXIdDAO()
        {
            Cinta idCinta = (Cinta)fabricaEntidades.ObtenerCinta();
            idCinta.Id = 1;
            Cinta cinta = (Cinta)baseDeDatosCinta.ConsultarXId(idCinta);
            Assert.AreEqual("Blanco", cinta.Color_nombre);
        }

        /// <summary>
        /// Método para probar la exception de número entero invalido de detallar cinta por id en DAO
        /// </summary>
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void DetallarCintaNumeroEnteroException()
        {
            Cinta idCinta = (Cinta)fabricaEntidades.ObtenerCinta();
            idCinta.Id = -1;
            Cinta cinta = (Cinta)baseDeDatosCinta.ConsultarXId(idCinta);
        }

        /// <summary>
        /// Método para probar que la cinta obtenida no sea nula para detallar cinta por id en DAO
        /// </summary>
        [Test]
        public void PruebaDetallarCintaxIDNoNula()
        {
            Cinta idCinta = (Cinta)fabricaEntidades.ObtenerCinta();
            idCinta.Id = 1;
            Cinta cinta = (Cinta)baseDeDatosCinta.ConsultarXId(idCinta);
            Assert.NotNull(cinta);
        }

        /// <summary>
        /// Método de prueba para UltimaCinta en DAO
        /// </summary>
        [Test]
        public void PruebaUltimaCinta()
        {
            Cinta cinta = (Cinta)baseDeDatosCinta.UltimaCinta(idPersona);
            Assert.AreEqual("Amarillo", cinta.Color_nombre);
        }

        /// <summary>
        /// Método para probar la exception de número entero invalido de prueba ultima cinta en DAO
        /// </summary>
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void UltimaCintaNumeroEnteroException()
        {
            idPersona.Id = -1;
            Cinta cinta = (Cinta)baseDeDatosCinta.UltimaCinta(idPersona);
        }

        /// <summary>
        /// Método para probar que la ultima cinta obtenida no sea nula en DAO
        /// </summary>
        [Test]
        public void PruebaUltimaCintaNoNula()
        {
            Cinta cinta = (Cinta)baseDeDatosCinta.UltimaCinta(idPersona);
            Assert.NotNull(cinta);
        }

        /// <summary>
        /// Método de prueba para ObtenerCinta en DAO
        /// </summary>
        [Test]
        public void PruebaFechaObtencionCinta()
        {
            Cinta idCinta = (Cinta)fabricaEntidades.ObtenerCinta();
            idCinta.Id = 2;
            Assert.AreEqual("08/21/2015", baseDeDatosCinta.FechaCinta(idPersona, idCinta).ToString("MM/dd/yyyy"));
        }

        /// <summary>
        /// Método para probar la exception de número entero invalido de prueba ultima cinta en DAO
        /// </summary>

        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void FechaObtecionCintaNumeroEnteroException()
        {
            Cinta idCinta = (Cinta)fabricaEntidades.ObtenerCinta();
            idCinta.Id = -2;
            baseDeDatosCinta.FechaCinta(idPersona, idCinta);
        }

        /// <summary>
        /// Método para probar que la fecha obtenida de una cinta no sea nula en DAO
        /// </summary>
        [Test]
        public void PruebaFechaObtencionCintaNoNula()
        {
            Cinta idCinta = (Cinta)fabricaEntidades.ObtenerCinta();
            idCinta.Id = 3;
            Assert.NotNull(baseDeDatosCinta.FechaCinta(idPersona, idCinta).ToString("MM/dd/yyyy"));
        }

        #endregion
    }
}
