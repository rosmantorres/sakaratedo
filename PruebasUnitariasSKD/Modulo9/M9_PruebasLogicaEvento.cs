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
            Persona persona = new Persona();
            categoria.Id_categoria = 1;
            persona.ID = 33;
            ubicacion.Id_ubicacion = 1;
            elEvento = new Evento();
            elEvento.Nombre = "Prueba Unitaria Desde Logica de Negocios";
            elEvento.Descripcion = "Pruebas Unitarias Logica de Negocios";
            elEvento.Costo = 55;
            elEvento.Estado = true;
            elEvento.Categoria = categoria;
            elEvento.Horario = horario;
            elEvento.Ubicacion = ubicacion;
            elEvento.TipoEvento = tipoEvento;
            elEvento.Persona = persona;
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
            float numeroPrueba = 85269;
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

        [Test]

        public void PruebaCrearEventoConTipo()
        {
            LogicaEvento logicaEvento = new LogicaEvento();
            elEvento.TipoEvento.Nombre = "PRuebas Unitarias desde Logica";
            Boolean resultado = logicaEvento.CrearEventoConTipo(elEvento);
            Assert.IsTrue(resultado);

        }

        [Test]

        public void PruebaListarEventos()
        {
            LogicaEvento logicaEvento = new LogicaEvento();
            List<Evento> listaEventos = logicaEvento.ListarEventos(elEvento.Persona.ID);
            Console.Out.WriteLine("El tamaño de la lista es"+" "+listaEventos.Count);
            Console.Out.WriteLine(" ");

            foreach (Evento evento in listaEventos)
            {
                Console.Out.WriteLine("Nombre de Evento:"+" "+evento.Nombre);
                Console.Out.WriteLine("Descripcion de Evento:" + " " + evento.Descripcion);
                Console.Out.WriteLine("Costo de Evento:" + " " + evento.Costo);
                Console.Out.WriteLine("Estado de Evento:" + " " + evento.Estado);
                Console.Out.WriteLine("Fecha Inicio de Evento:" + " " + evento.Horario.FechaInicio);
                Console.Out.WriteLine("Fecha Fin de Evento:" + " " + evento.Horario.FechaFin);
                Console.Out.WriteLine("Tipo de Evento:" + " " + evento.TipoEvento.Nombre);
                Console.Out.WriteLine("Hora inicio de Evento:" + " " + evento.Horario.HoraInicio);
                Console.Out.WriteLine("Hora fin de Evento:" + " " + evento.Horario.HoraFin);
                Console.Out.WriteLine(" ");

            }
            Assert.Greater(listaEventos.Count, 0);
        }

        [Test]

        public void PruebaConsultarEvento()
        {
            LogicaEvento logicaEvento = new LogicaEvento();
            Evento evento = logicaEvento.ConsultarEvento("1");
            Console.Out.WriteLine("Nombre de Evento:" + " " + evento.Nombre);
            Console.Out.WriteLine("Descripcion de Evento:" + " " + evento.Descripcion);
            Console.Out.WriteLine("Costo de Evento:" + " " + evento.Costo);
            Console.Out.WriteLine("Estado de Evento:" + " " + evento.Estado);
            Console.Out.WriteLine("Fecha Inicio de Evento:" + " " + evento.Horario.FechaInicio);
            Console.Out.WriteLine("Fecha Fin de Evento:" + " " + evento.Horario.FechaFin);
            Console.Out.WriteLine("Tipo de Evento:" + " " + evento.TipoEvento.Nombre);
            Console.Out.WriteLine("Hora inicio de Evento:" + " " + evento.Horario.HoraInicio);
            Console.Out.WriteLine("Hora fin de Evento:" + " " + evento.Horario.HoraFin);
            Console.Out.WriteLine(" ");
            Assert.AreEqual(evento.Nombre, "Clase Regular");
        }

        [Test]
        public void PruebaConsultarTipoEventos()
        {
            LogicaEvento logicaEvento = new LogicaEvento();
            List<TipoEvento> tipos = logicaEvento.ConsultarTiposEventos();
            foreach (TipoEvento tipo in tipos)
            {
                Console.Out.WriteLine("Id Tipo de Evento:" + " " + tipo.Id);
                Console.Out.WriteLine("Nombre:" + " " + tipo.Nombre);

                Console.Out.WriteLine(" ");

            }
            Assert.Greater(tipos.Count, 0);

        }

        [Test]
        public void PruebaModificarEvento()
        {
            LogicaEvento logicaEvento = new LogicaEvento();
            elEvento.Id_evento = 4;
            elEvento.Nombre = "PRobando el Modificar desde Logica";
            elEvento.Descripcion = "PRobando el Modificar desde Logica";
            elEvento.Estado = false;
            Boolean auxiliar = logicaEvento.ModificarEvento(elEvento);
            Assert.True(auxiliar);


        }

        [Test]
        public void PruebaModificarEventoConTipo()
        {
            LogicaEvento logicaEvento = new LogicaEvento();
            elEvento.Id_evento = 4;
            elEvento.Nombre = "PRobando el Modificar desde Logica";
            elEvento.Descripcion = "PRobando el Modificar desde Logica";
            elEvento.Estado = false;
            elEvento.TipoEvento.Nombre = "PRuebas Unitarias desde Logica";
            Boolean auxiliar = logicaEvento.ModificarEvento(elEvento);
            Assert.True(auxiliar);


        }
    }
}
