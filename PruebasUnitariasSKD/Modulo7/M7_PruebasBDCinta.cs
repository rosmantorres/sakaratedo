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
            idPersona = 1;
            
        }

        [TearDown]
        public void Clean()
        {
            idPersona = 0;
        }
        #endregion

        #region Test`s

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
        /// Método para probar que la cinta obtenida es correcta
        /// </summary>
        [Test]
        public void PruebaDetallarCintaxID()
        {
            BDCinta baseDeDatosCinta = new BDCinta();
            Cinta cinta= baseDeDatosCinta.DetallarCinta(1);
            Assert.AreEqual("Blanco", cinta.Color_nombre);
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
            Cinta cinta = baseDeDatosCinta.UltimaCinta(1);
            Assert.AreEqual("Verde", cinta.Color_nombre);
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
            Assert.AreEqual("08/08/2016", baseDeDatosCinta.fechaCinta(idPersona,3).ToString("MM/dd/yyyy"));
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
