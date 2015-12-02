using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DominioSKD;
using ExcepcionesSKD.Modulo7;
using ExcepcionesSKD;
using LogicaNegociosSKD.Modulo7;

namespace PruebasUnitariasSKD.Modulo7
{
    [TestFixture]
    public class M7_PruebaLogicaCintas
    {
        #region Atributos
        /// <summary>
        /// Atributo que representa el id de la persona o atleta
        /// </summary>
        private int idPersona;
        /// <summary>
        /// Atributo que representa la clase LogicaCintas
        /// </summary>
        LogicaCintas logicaCinta;
        #endregion

        #region SetUp & TearDown
        [SetUp]
        public void Init()
        {
            logicaCinta = new LogicaCintas();
            idPersona = 6;
        }

        [TearDown]
        public void Clean()
        {
            logicaCinta = null;
            idPersona = 0;
        }
        #endregion

        #region Test

        /// <summary>
        /// Método para probar que la lista obtenida puede tener cero o mas cintas
        /// </summary>
        [Test]
        public void PruebaObtenerListaCintas()
        {         
            List<Cinta> listaCinta = logicaCinta.obtenerListaDeCintas(idPersona);
            Assert.GreaterOrEqual(listaCinta.Count, 0);
        }

        /// <summary>
        /// Método para probar que la lista puede no esta vacia
        /// </summary>
        [Test]
        public void PruebaObtenerListaCintasVacia()
        {
            List<Cinta> listaCinta = logicaCinta.obtenerListaDeCintas(idPersona);
            Assert.IsNotEmpty(listaCinta);
        }

        /// <summary>
        /// Método para probar la excepcion de número entero invalido de listar cintas obtenidas
        /// </summary>
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void ListarCintasNumeroEnteroException()
        {
            List<Cinta> listaCinta = logicaCinta.obtenerListaDeCintas(-1);
        }

        /// <summary>
        /// Método para probar que se obtiene una cinta
        /// </summary>
        [Test]
        public void PruebaObtenerCinta()
        {
            Cinta Cinta = logicaCinta.detalleCintaID(1);
            Assert.GreaterOrEqual(Cinta.Color_nombre, "Blanco");
        }

        /// <summary>
        /// Método para probar que puede no trae un objeto vacio
        /// </summary>
        [Test]
        public void PruebaObtenerCintaVacia()
        {
            Cinta cinta = logicaCinta.detalleCintaID(1);
            Assert.IsNotEmpty(cinta.Color_nombre);
        }

        /// <summary>
        /// Método para probar la excepcion de número entero invalido de detallar cinta
        /// </summary>
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void DetallarCintaNumeroEnteroException()
        {
            Cinta listaCinta = logicaCinta.detalleCintaID(-1);
        }


        /// <summary>
        /// Método para probar que se obtiene una cinta
        /// </summary>
        [Test]
        public void PruebaObtenerUltimaCinta()
        {
            Cinta Cinta = logicaCinta.obtenerUltimaCinta(idPersona);
            Assert.GreaterOrEqual(Cinta.Color_nombre, "Amarillo");
        }

        /// <summary>
        /// Método para probar que trae un objeto no nulo
        /// </summary>
        [Test]
        public void PruebaObtenerUltimaCintaNoNulo()
        {
            Cinta cinta = logicaCinta.obtenerUltimaCinta(idPersona);
            Assert.IsNotNull(cinta);
        }

        /// <summary>
        /// Método para probar la excepcion de número entero invalido de detallar cinta
        /// </summary>
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void UltimaCintaNumeroEnteroException()
        {
            Cinta listaCinta = logicaCinta.detalleCintaID(-1);
        }

        /// <summary>
        /// Método para probar que se obtiene una la fecha de obtencion de una cinta
        /// </summary>
        [Test]
        public void PruebaObtenerFechaCinta()
        {
            DateTime fechaCinta = logicaCinta.obtenerFechaCinta(idPersona, 2);
            Assert.AreEqual("08/21/2015",fechaCinta.ToString("MM/dd/yyyy"));
        }

        /// <summary>
        /// Método para probar que la fecha obtenida es no nula
        /// </summary>
        [Test]
        public void PruebaObtenerFechaCintaNoNula()
        {
            DateTime fechaCinta = logicaCinta.obtenerFechaCinta(idPersona, 1);
            Assert.IsNotNull(fechaCinta);
        }

        /// <summary>
        /// Método para probar la excepcion de número entero invalido de obtener fecha
        /// </summary>
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void FechaCintaNumeroEnteroException()
        {
            DateTime fechaCinta = logicaCinta.obtenerFechaCinta(idPersona, -1);
        }
        #endregion
    }
}
