﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DominioSKD;
using DatosSKD;

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
            ubicacion.Id_ubicacion = 1;
            elEvento = new Evento();
            elEvento.Nombre = "Prueba Unitaria";
            elEvento.Descripcion = "Pruebas Unitarias";
            elEvento.Costo = 50;
            elEvento.Estado = true;
            elEvento.Categoria = categoria;
            elEvento.Horario = horario;
            elEvento.Ubicacion = ubicacion;
            elEvento.TipoEvento = tipoEvento;
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
            List<Evento> listaEvento = baseDeDatosEvento.ListarEventos(); 
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

        #endregion
    }
}
