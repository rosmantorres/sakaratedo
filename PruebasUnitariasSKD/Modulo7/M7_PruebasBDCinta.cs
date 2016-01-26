using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DominioSKD;
using DatosSKD;
using DatosSKD.Modulo7;
using ExcepcionesSKD.Modulo7;
using ExcepcionesSKD;

namespace PruebasUnitariasSKD.Modulo7
{
    /// <summary>
    /// Clase de pruebas para la clase BDCinta
    /// </summary>
    [TestFixture]
    public class M7_PruebasBDCinta
    {
        #region Atributos
        /// <summary>
        /// Atributo que representa el id de la persona o atleta
        /// </summary>
        private int idPersona;
        #endregion

        #region SetUp & TearDown
        [SetUp]
        public void Init()
        {
            idPersona = 6;        
        }

        [TearDown]
        public void Clean()
        {
            idPersona = 0;
        }
        #endregion

        #region Test

        /// <summary>
        /// Método para probar que la lista de cintas obtenidas puede tener cero o mas cintas
        /// </summary>
        [Test]
        public void PruebaListarCintasObtenidas()
        {
            BDCinta baseDeDatosCinta = new BDCinta();
            List<Cinta> listaCinta = baseDeDatosCinta.ListarCintasObtenidas(idPersona);
            Assert.GreaterOrEqual(listaCinta.Count, 0);

        }

        /// <summary>
        /// Método para probar la exception de número entero invalido de listar cintas obtenidas
        /// </summary>
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void ListarCintasNumeroEnteroException()
        {
            BDCinta baseDeDatosCinta = new BDCinta();
            List<Cinta> listaCinta = baseDeDatosCinta.ListarCintasObtenidas(-1);
        }


        /// <summary>
        /// Método para probar que la lista de cintas obtenidas no es nula
        /// </summary>
        [Test]
        public void PruebaListarCintasObtenidasNoNula()
        {
            BDCinta baseDeDatosCinta = new BDCinta();
            List<Cinta> listaCinta = baseDeDatosCinta.ListarCintasObtenidas(idPersona);
            Assert.NotNull(listaCinta);
        }

        /// <summary>
        /// Método para probar que se detalla una cinta
        /// </summary>
        [Test]
        public void PruebaDetallarCintaXId()
        {
            BDCinta baseDeDatosCinta = new BDCinta();
            Cinta cinta= baseDeDatosCinta.DetallarCinta(1);
            Assert.AreEqual("Blanco", cinta.Color_nombre);
        }

        /// <summary>
        /// Método para probar la exception de número entero invalido de detallar cinta
        /// </summary>
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void DetallarCintaNumeroEnteroException()
        {
            BDCinta baseDeDatosCinta = new BDCinta();
            Cinta cinta = baseDeDatosCinta.DetallarCinta(-1);
        }

        /// <summary>
        /// Método para probar que la cinta obtenida no sea nula
        /// </summary>
        [Test]
        public void PruebaDetallarCintaxIDNoNula()
        {
            BDCinta baseDeDatosCinta = new BDCinta();
            Cinta cinta = baseDeDatosCinta.DetallarCinta(1);
            Assert.NotNull(cinta);
        }

        /// <summary>
        /// Método para probar que la cinta obtenida sea la última de la persona
        /// </summary>
        [Test]
        public void PruebaUltimaCinta()
        {
            BDCinta baseDeDatosCinta = new BDCinta();
            Cinta cinta = baseDeDatosCinta.UltimaCinta(idPersona);
            Assert.AreEqual("Amarillo", cinta.Color_nombre);
        }

        /// <summary>
        /// Método para probar la exception de número entero invalido de prueba ultima cinta
        /// </summary>
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void UltimaCintaNumeroEnteroException()
        {
            BDCinta baseDeDatosCinta = new BDCinta();
            Cinta cinta = baseDeDatosCinta.UltimaCinta(-1);
        }

        /// <summary>
        /// Método para probar que la ultima cinta obtenida no sea nula
        /// </summary>
        [Test]
        public void PruebaUltimaCintaNoNula()
        {
            BDCinta baseDeDatosCinta = new BDCinta();
            Cinta cinta = baseDeDatosCinta.UltimaCinta(1);
            Assert.NotNull(cinta);
        }

        /// <summary>
        /// Método para probar que la fecha obtenida de una cinta sea correcta
        /// </summary>
        [Test]
        public void PruebaFechaObtencionCinta()
        {
            BDCinta baseDeDatosCinta = new BDCinta();
            Assert.AreEqual("08/21/2015", baseDeDatosCinta.fechaCinta(idPersona,2).ToString("MM/dd/yyyy"));
        }

        /// <summary>
        /// Método para probar la exception de número entero invalido de prueba ultima cinta
        /// </summary>
        
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void FechaObtecionCintaNumeroEnteroException()
        {
            BDCinta baseDeDatosCinta = new BDCinta();
            baseDeDatosCinta.fechaCinta(idPersona, -2);
        }

        /// <summary>
        /// Método para probar que la fecha obtenida de una cinta no sea nula
        /// </summary>
        [Test]
        public void PruebaFechaObtencionCintaNoNula()
        {
            BDCinta baseDeDatosCinta = new BDCinta();
            Assert.NotNull(baseDeDatosCinta.fechaCinta(idPersona, 3).ToString("MM/dd/yyyy"));
        }

        #endregion
    }
}
