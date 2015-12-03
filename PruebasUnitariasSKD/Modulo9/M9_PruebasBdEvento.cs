using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DominioSKD;
using DatosSKD;
using log4net;
using log4net.Config;

namespace PruebasUnitariasSKD.Modulo9
{
    /// <summary>
    /// Clase Encargada de Realizar las pruebas unitarias de los metodos de la Clase BDEvento
    /// </summary>
    [TestFixture]
    class M9_PruebasBdEvento
    {
        #region Atributos
        private int elId;
        private Evento elEvento;

        #endregion

        #region SetUp&TearDown

        [SetUp]
        public void Init()
        {
            elId = 9;
            DateTime fechaInicio = new DateTime(2008, 5, 1, 8, 30, 52);
            DateTime fechaFin = new DateTime(2009, 5, 1, 1, 1, 1);
            Horario horario = new Horario(1,fechaInicio,fechaFin,10,11);
            Categoria categoria = new Categoria(15,16,"verde","amarillo","masculino");
            TipoEvento tipoEvento = new TipoEvento(1,"Pase de Cinta");
            Ubicacion ubicacion = new Ubicacion("10.499607", "66.788419", "Caracas", "Miranda","NULL");
            Persona persona = new Persona();
            categoria.Id_categoria = 1;
            persona.ID = 33;
            ubicacion.Id_ubicacion = 1;
            elEvento = new Evento();
            elEvento.Nombre = "Prueba Unitaria";
            elEvento.Descripcion = "Pruebas Unitarias";
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
            elId = 0;
            elEvento = null;
        }
        #endregion

        #region Pruebas Unitarias

        [Test]
        public void PruebaCrearEvento()
        {
            DatosSKD.Modulo9.BDEvento baseDeDatosEvento = new DatosSKD.Modulo9.BDEvento();
            Boolean auxiliar = baseDeDatosEvento.CrearEvento(elEvento);
            Console.Out.WriteLine(auxiliar);
            Assert.True(auxiliar);
        }

        [Test]
        public void PruebaListarEventos()
        {
            DatosSKD.Modulo9.BDEvento baseDeDatosEvento = new DatosSKD.Modulo9.BDEvento();
            List<Evento> listaEvento = baseDeDatosEvento.ListarEventos(elEvento.Persona.ID); 
            Assert.Greater(listaEvento.Count,0);
        }

        [Test]
        public void PruebaConsultarEvento()
        {
            DatosSKD.Modulo9.BDEvento baseDeDatosEvento = new DatosSKD.Modulo9.BDEvento();
            Evento evento = baseDeDatosEvento.ConsultarEvento("1");
            Console.Out.WriteLine(evento.Nombre);
            Assert.AreEqual(evento.Nombre, "Clase Regular");
        }

        [Test]
        public void PruebaListarHorarios()
        {
            DatosSKD.Modulo9.BDEvento baseDeDatosEvento = new DatosSKD.Modulo9.BDEvento();
            List<Horario> horarios = baseDeDatosEvento.ListarHorarios();
            Assert.Greater(horarios.Count,0);
        }

        [Test]
        public void PruebaEventosPorFecha()
        {
            DatosSKD.Modulo9.BDEvento baseDeDatosEvento = new DatosSKD.Modulo9.BDEvento();
            String fechaI = "2008-05-15";
            String fechaF = "2016-06-05";
            List<Evento> eventos = baseDeDatosEvento.EventosPorFecha(fechaI, fechaF);
            Assert.Greater(eventos.Count, 0);

        }

        [Test]
        public void PruebaListarHorariosAscensos()
        {
            DatosSKD.Modulo9.BDEvento baseDeDatosEvento = new DatosSKD.Modulo9.BDEvento();
            List<Horario> horarios = baseDeDatosEvento.ListarHorariosAscensos();
            Assert.Greater(horarios.Count, 0);
        }

        [Test]
        public void PruebaAcsensosPorFecha()
        {
            DatosSKD.Modulo9.BDEvento baseDeDatosEvento = new DatosSKD.Modulo9.BDEvento();
            String fechaI = "2008-05-15";
            String fechaF = "2016-06-05";
            List<Evento> eventos = baseDeDatosEvento.AcsensosPorFecha(fechaI, fechaF);
            Assert.Greater(eventos.Count, 0);
        }

        [Test]
        public void PruebaConsultarTipoEventos()
        {
            DatosSKD.Modulo9.BDEvento baseDeDatosEvento = new DatosSKD.Modulo9.BDEvento();
            List<TipoEvento> tipos = baseDeDatosEvento.ListarTiposEventos();
            foreach (TipoEvento tipo in tipos)
            {
                Console.Out.WriteLine("Id Tipo de Evento:" + " " + tipo.Id);
                Console.Out.WriteLine("Nombre:" + " " + tipo.Nombre);
                
                Console.Out.WriteLine(" ");

            }
            Assert.Greater(tipos.Count, 0);

        }

        [Test]
        public void PruebaCrearEventoTipo()
        {
            DatosSKD.Modulo9.BDEvento baseDeDatosEvento = new DatosSKD.Modulo9.BDEvento();
            elEvento.TipoEvento.Nombre = "Prueba Unitaria";
            Boolean auxiliar = baseDeDatosEvento.CrearEventoConTipo(elEvento);
            Console.Out.WriteLine(auxiliar);
            Assert.True(auxiliar);
        }

        [Test]
        public void PruebaModificarEvento()
        {
            DatosSKD.Modulo9.BDEvento baseDeDatosEvento = new DatosSKD.Modulo9.BDEvento();
            elEvento.Id_evento = 3;
            elEvento.Nombre = "PRobando el Modificar desde BD";
            elEvento.Descripcion = "PRobando el Modificar desde BD";
            elEvento.Estado = false;
            Boolean auxiliar = baseDeDatosEvento.ModificarEvento(elEvento);
            Assert.True(auxiliar);


        }

        [Test]
        public void PruebaModificarEventoConTipo()
        {
            DatosSKD.Modulo9.BDEvento baseDeDatosEvento = new DatosSKD.Modulo9.BDEvento();
            elEvento.Id_evento = 3;
            elEvento.Nombre = "PRobando el Modificar desde BD";
            elEvento.Descripcion = "PRobando el Modificar desde BD";
            elEvento.TipoEvento.Nombre = "Probando el Modificar desde BD";
            elEvento.Estado = false;
            Boolean auxiliar = baseDeDatosEvento.ModificarEventoConTipo(elEvento);
            Assert.True(auxiliar);


        }
        #endregion
    }
}
