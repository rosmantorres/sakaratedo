using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DominioSKD;
using DatosSKD;
using DatosSKD.Modulo7;

namespace PruebasUnitariasSKD.Modulo7
{ 
    /// <summary>
    /// Clase de pruebas para la clase BDTipoEvento
    /// </summary>
    [TestFixture]
    public class M7_PruebasBDTipoEvento
    {
        #region Atributos
        /// <summary>
        /// Atributo que representa el id del tipo de evento
        /// </summary>
        private int idTipoEvento;
        #endregion

        #region SetUp & TearDown
        [SetUp]
        public void Init()
        {
            idTipoEvento = 2;
        }

        [TearDown]
        public void Clean()
        {
            idTipoEvento = 0;
        }
        #endregion

        /// <summary>
        /// Método para probar que se detalla un tipo de evento
        /// </summary>
        [Test]
        public void PruebaDetallarTipoEventoXId()
        {
            BDTipoEvento baseDeDatosTipoEvento = new BDTipoEvento();
            TipoEvento tipoEvento = baseDeDatosTipoEvento.DetallarTipoEvento(idTipoEvento);
            Assert.AreEqual("Seminario", tipoEvento.Nombre);
        }

        /// <summary>
        /// Método para probar que el tipo de evento no es nulo
        /// </summary>
        [Test]
        public void PruebaDetallarTipoEventoXIdNoNulo()
        {
            BDTipoEvento baseDeDatosTipoEvento = new BDTipoEvento();
            TipoEvento tipoEvento = baseDeDatosTipoEvento.DetallarTipoEvento(idTipoEvento);
            Assert.IsNotNull(tipoEvento);
        }

        /// <summary>
        /// Método para probar la exception de número entero invalido de detallar persona
        /// </summary>
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void DetallarTipoEventoNumeroEnteroException()
        {
            BDTipoEvento baseDeDatosTipoEvento = new BDTipoEvento();
            TipoEvento tipoEvento = baseDeDatosTipoEvento.DetallarTipoEvento(-1);
        }
    }
}
