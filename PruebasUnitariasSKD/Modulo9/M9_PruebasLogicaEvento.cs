using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DominioSKD;
using DatosSKD;
using LogicaNegociosSKD.Modulo9;

namespace PruebasUnitariasSKD.Modulo9
{

    [TestFixture]
    class M9_PruebasLogicaEvento
    {
        [Test]
        public void PruebaValidarCaracteres()
        {
            String cadenaPrueba = "Caracas es La mejor Ciudad del Mundo";
            LogicaEvento logicaEvento = new LogicaEvento();
            Boolean auxiliar = logicaEvento.ValidarCaracteres(cadenaPrueba);
            Assert.IsTrue(auxiliar);
        }

        [Test]
        public void PruebaValidarCosto()
        {
            double numeroPrueba = 85269.56;
            LogicaEvento logicaEvento = new LogicaEvento();
            Boolean auxiliar = logicaEvento.ValidarCosto(numeroPrueba);
            Assert.IsTrue(auxiliar);
        }

        [Test]
        public void PruebaConvertirFecha()
        {
            LogicaEvento logicaEvento = new LogicaEvento();
            String prueba = "05/06/2015";
            DateTime resultado = logicaEvento.ConvertirFecha(prueba);
            Console.Out.WriteLine(resultado.Day);
            Console.Out.WriteLine(resultado.Month);
            Console.Out.WriteLine(resultado.Year);
            Assert.AreEqual(resultado.Year, 2015);
        }

        [Test]

        public void PruebaValidarFormatoFecha()
        {
            LogicaEvento logicaEvento = new LogicaEvento();
            String prueba = "05-06-2015";
            Boolean resultado = logicaEvento.ValidarFormatoFecha(prueba);
            Assert.IsTrue(resultado);
        }

        [Test]

        public void PruebaValidarFechaFinMayor()
        {
            LogicaEvento logicaEvento = new LogicaEvento();
            String fecha1 = "05/06/2015";
            String fecha2 = "07/06/2015";
            Boolean resultado = logicaEvento.ValidarFechaFinMayor(fecha1, fecha2);
            Assert.IsTrue(resultado);
        }

    }
}
