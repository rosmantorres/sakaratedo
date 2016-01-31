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
using DominioSKD.Entidades.Modulo7;

namespace PruebasUnitariasSKD.Modulo7.PruebasDAO
{
    /// <summary>
    /// Clase que contiene las pruebas unitarias para DaoTipoEvento
    /// </summary>
    [TestFixture]
    public class M7_PruebasDAOTipoEvento
    {
        #region Atributos
        private TipoEventoM7 idTipoEvento;
        private DaoTipoEvento baseDeDatosTipoEvento;
        #endregion

        #region SetUp & TearDown
        /// <summary>
        /// Método que se ejecuta antes de cada prueba
        /// </summary>
        [SetUp]
        public void Init()
        {
            baseDeDatosTipoEvento = FabricaDAOSqlServer.ObtenerDaoTipoEventoM7();
            idTipoEvento = (TipoEventoM7)FabricaEntidades.ObtenerTipoEventoM7();
            idTipoEvento.Id = 2;
        }

        /// <summary>
        /// Método que se ejecuta luego de cada prueba
        /// </summary>
        [TearDown]
        public void Clean()
        {
            idTipoEvento = null;
            baseDeDatosTipoEvento = null;
        }
        #endregion

        /// <summary>
        /// Método para probar que se detalla un tipo de evento en DAO
        /// </summary>
        [Test]
        public void PruebaDetallarTipoEventoXId()
        {
            TipoEventoM7 tipoEvento = (TipoEventoM7)baseDeDatosTipoEvento.ConsultarXId(idTipoEvento);
            Assert.AreEqual("Seminario", tipoEvento.Nombre);
        }

        /// <summary>
        /// Método para probar que el tipo de evento no es nulo en DAO
        /// </summary>
        [Test]
        public void PruebaDetallarTipoEventoXIdNoNulo()
        {
            TipoEventoM7 tipoEvento = (TipoEventoM7)baseDeDatosTipoEvento.ConsultarXId(idTipoEvento);
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
            TipoEventoM7 tipoEvento = (TipoEventoM7)baseDeDatosTipoEvento.ConsultarXId(idTipoEvento);
        }
    }
}
