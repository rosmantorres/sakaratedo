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
        private Evento elEvento;

        [SetUp]
        public void Init()
        {
            DateTime fechaInicio = new DateTime(2008, 5, 1, 8, 30, 52);
            DateTime fechaFin = new DateTime(2009, 5, 1, 1, 1, 1);
            Horario horario = new Horario(1, fechaInicio, fechaFin, 10, 11);
            Categoria categoria = new Categoria(15, 16, "verde", "amarillo", "masculino");
            TipoEvento tipoEvento = new TipoEvento(1, "Pase de Cinta");
            Ubicacion ubicacion = new Ubicacion("10.499607", "66.788419", "Caracas", "Miranda", "NULL");
            ubicacion.Id_ubicacion = 1;
            elEvento = new Evento();
            elEvento.Nombre = "Prueba Unitaria Logica Evento";
            elEvento.Descripcion = "Pruebas Unitarias Logica Evento";
            elEvento.Costo = 55;
            elEvento.Estado = true;
            elEvento.Categoria = categoria;
            elEvento.Horario = horario;
            elEvento.Ubicacion = ubicacion;
            elEvento.TipoEvento = tipoEvento;
        }

        [TearDown]

        public void clean()
        {
            elEvento = null;
        }
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

        [Test]

        public void PruebaCrearEvento()
        {
            LogicaEvento logicaEvento = new LogicaEvento();
            Boolean resultado = logicaEvento.CrearEvento(elEvento);
            Assert.IsTrue(resultado);

        }
    }
}
