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
    [TestFixture]
    public class M7_PruebasBDCinta
    {
        #region Atributos
        private Cinta cinta;
        private int id;
        #endregion

        #region SetUp & TearDown
        [SetUp]
        public void Init()
        {
            id = 1;
            cinta = new Cinta();
            cinta.Id_cinta = id;
            cinta.Color_nombre = "Blanco";
            cinta.Rango = "1er Kyu";
            cinta.Clasificacion = "Nivel inferior";
            cinta.Significado = "Principiante";
            cinta.Orden = 1;
        }

        [TearDown]
        public void Clean()
        {
            id = 0;
            cinta = null;
        }
        #endregion

        #region Test`s

        [Test]
        public void PruebaListarCintasObtenidas()
        {
            List<Cinta> listaCinta = BDCinta.ListarCintasObtenidas(1);
            Assert.Greater(listaCinta.Count, 0);

        }

        #endregion

    }
}
