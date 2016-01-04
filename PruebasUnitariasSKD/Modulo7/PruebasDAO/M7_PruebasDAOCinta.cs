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
    public class M7_PruebasDAOCinta
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
            idPersona = new Persona();//esto se sustituye con fabrica de entidad
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
        public void PruebaDetallarCintaXIdDAO()
        {
            //DaoCinta basedeDatosCinta = fabricaSql.nuevoDAOCinta();
            DaoCinta baseDeDatosCinta = new DaoCinta();//esto se sustituye con la fabrica
            Cinta idCinta = (Cinta)fabricaEntidades.ObtenerCinta();
            idCinta.Id = 1;
            Cinta cinta = (Cinta)baseDeDatosCinta.ConsultarXId(idCinta);
            Assert.AreEqual("Blanco", cinta.Color_nombre);
        }

        /// <summary>
        /// Método de prueba para ListarCintasObtenidas en DAO
        /// </summary>
        [Test]
        public void PruebaListarCintasObtenidasDAO()
        {
            //DaoCinta basedeDatosCinta = fabricaSql.nuevoDAOCinta();
            DaoCinta baseDeDatosCinta = new DaoCinta();//esto se sustituye con la fabrica
            List<Entidad> listaCinta = baseDeDatosCinta.ListarCintasObtenidas(idPersona);
            Assert.GreaterOrEqual(listaCinta.Count, 1);
        }

        /// <summary>
        /// Método de prueba para UltimaCinta en DAO
        /// </summary>
        [Test]
        public void PruebaUltimaCinta()
        {
            //DaoCinta basedeDatosCinta = fabricaSql.nuevoDAOCinta();
            DaoCinta baseDeDatosCinta = new DaoCinta();//esto se sustituye con la fabrica
            Cinta cinta = (Cinta)baseDeDatosCinta.UltimaCinta(idPersona);
            Assert.AreEqual("Amarillo", cinta.Color_nombre);
        }

        /// <summary>
        /// Método de prueba para ObtenerCinta en DAO
        /// </summary>
        [Test]
        public void PruebaFechaObtencionCinta()
        {
            //DaoCinta basedeDatosCinta = fabricaSql.nuevoDAOCinta();
            DaoCinta baseDeDatosCinta = new DaoCinta();//esto se sustituye con la fabrica
            Cinta idCinta = (Cinta)fabricaEntidades.ObtenerCinta();
            idCinta.Id = 2;
            Assert.AreEqual("08/21/2015", baseDeDatosCinta.FechaCinta(idPersona, idCinta).ToString("MM/dd/yyyy"));
        }
        #endregion
    }
}
