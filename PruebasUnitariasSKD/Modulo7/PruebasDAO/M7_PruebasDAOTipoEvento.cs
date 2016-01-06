using DatosSKD.DAO.Modulo7;
using DatosSKD.Fabrica;
using DominioSKD;
using DominioSKD.Fabrica;
using ExcepcionesSKD.Modulo7;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasUnitariasSKD.Modulo7.PruebasDAO
{
    /// <summary>
    /// Clase que contiene las pruebas unitarias para DaoTipoEvento
    /// </summary>
    [TestFixture]
    public class M7_PruebasDAOTipoEvento
    {
        #region Atributos
        private TipoEvento idTipoEvento;
        FabricaEntidades fabricaEntidades;
        FabricaDAOSqlServer fabricaSql;
        DaoTipoEvento baseDeDatosTipoEvento;
        #endregion

        #region SetUp & TearDown
        [SetUp]
        public void Init()
        {
            fabricaSql = new FabricaDAOSqlServer();
            baseDeDatosTipoEvento = fabricaSql.ObtenerDaoTipoEventoM7();
            fabricaEntidades = new FabricaEntidades();
            idTipoEvento = new TipoEvento(); //se sustituye con fabrica
            idTipoEvento.Id = 2;
        }

        [TearDown]
        public void Clean()
        {
            idTipoEvento = null;
            fabricaEntidades = null;
            fabricaSql = null;
            baseDeDatosTipoEvento = null;
        }
        #endregion

        /// <summary>
        /// Método para probar que se detalla un tipo de evento en DAO
        /// </summary>
        [Test]
        public void PruebaDetallarTipoEventoXId()
        {
            TipoEvento tipoEvento = (TipoEvento)baseDeDatosTipoEvento.ConsultarXId(idTipoEvento);
            Assert.AreEqual("Seminario", tipoEvento.Nombre);
        }

        /// <summary>
        /// Método para probar que el tipo de evento no es nulo en DAO
        /// </summary>
        [Test]
        public void PruebaDetallarTipoEventoXIdNoNulo()
        {
            TipoEvento tipoEvento = (TipoEvento)baseDeDatosTipoEvento.ConsultarXId(idTipoEvento);
            Assert.IsNotNull(tipoEvento);
        }

        /// <summary>
        /// Método para probar la exception de número entero invalido de detallar persona en DAO
        /// </summary>
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void DetallarTipoEventoNumeroEnteroException()
        {
            idTipoEvento.Id = -1;
            TipoEvento tipoEvento = (TipoEvento)baseDeDatosTipoEvento.ConsultarXId(idTipoEvento);
        }
    }
}
