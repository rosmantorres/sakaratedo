using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;
using NUnit.Framework;
using log4net;
using log4net.Config;
using LogicaNegociosSKD.Comandos;
using LogicaNegociosSKD.Fabrica;
using DominioSKD.Fabrica;


namespace PruebasUnitariasSKD.Modulo9
{
    class PruebasComandosM9
    {
        /// <summary>
        /// Prueba que permite saber si esta retornando los datos de BD
        /// </summary>
        [Test]
        public void PruebaListarTiposEventos()
        {
            LogicaNegociosSKD.Comandos.Modulo9.ComandoConsultarListaTipoEventos comando = (LogicaNegociosSKD.Comandos.Modulo9.ComandoConsultarListaTipoEventos)FabricaComandos.ObtenerComandoConsultarTipoEventos();  
            List<Entidad> listaEvento = comando.Ejecutar();
            foreach (Entidad a in listaEvento)
            {
                DominioSKD.Entidades.Modulo9.TipoEvento tipo = (DominioSKD.Entidades.Modulo9.TipoEvento)a;
                Console.Out.WriteLine(tipo.Id);
                Console.Out.WriteLine(tipo.Nombre);
            }
            Assert.Greater(listaEvento.Count, 0);
        }

        /// <summary>
        /// Prueba que permite listar los eventos que estan en BD
        /// </summary>

        [Test]

        public void PruebaListarEventos()
        {
            FabricaEntidades fabricaEntidades = new FabricaEntidades();
            DominioSKD.Entidades.Modulo9.Evento parametro = (DominioSKD.Entidades.Modulo9.Evento)fabricaEntidades.ObtenerEvento();
            parametro.Id = 36;
            LogicaNegociosSKD.Comandos.Modulo9.ComandoConsultarListaEventos comando = (LogicaNegociosSKD.Comandos.Modulo9.ComandoConsultarListaEventos)FabricaComandos.ObtenerComandoConsultarListaEventos(parametro);
            List<Entidad> listaEvento = comando.Ejecutar();
            Console.Out.WriteLine("El tamaño de la lista es" + " " + listaEvento.Count);
            Console.Out.WriteLine(" ");

            foreach (Entidad entidad in listaEvento)
            {
                DominioSKD.Entidades.Modulo9.Evento evento = (DominioSKD.Entidades.Modulo9.Evento)entidad;
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

            }
            Assert.Greater(listaEvento.Count, 0);
        }

        /// <summary>
        /// Prueba que permite verificar la creacion de un evento
        /// </summary>

        [Test]
        public void PruebaCrearEvento()
        {
            FabricaEntidades fabricaEntidad = new FabricaEntidades();
            DateTime fechaInicio = new DateTime(2008, 5, 1, 8, 30, 52);
            DateTime fechaFin = new DateTime(2009, 5, 1, 1, 1, 1);
            DominioSKD.Entidades.Modulo9.Horario horario = (DominioSKD.Entidades.Modulo9.Horario)fabricaEntidad.ObtenerHorario();
            horario.FechaInicio = fechaInicio;
            horario.FechaFin = fechaFin;
            horario.HoraInicioS = "10:30";
            horario.HoraFinS = "11:00";
            horario.Id = 1;
            DominioSKD.Entidades.Modulo9.TipoEvento tipoEvento = (DominioSKD.Entidades.Modulo9.TipoEvento)fabricaEntidad.ObtenerTipoEvento();
            tipoEvento.Id = 1;
            tipoEvento.Nombre = "Prueba Unitaria en Dao";
            Persona persona = new Persona();
            persona.ID = 36;
            DominioSKD.Entidades.Modulo9.Evento elEvento = (DominioSKD.Entidades.Modulo9.Evento)fabricaEntidad.ObtenerEvento();
            elEvento.Nombre = "Prueba Unitaria Dao Crear";
            elEvento.Descripcion = "Pruebas Unitarias de DAO Crear";
            elEvento.Costo = 55;
            elEvento.Estado = true;
            elEvento.Horario = horario;
            elEvento.TipoEvento = tipoEvento;
            elEvento.Persona = persona;
            LogicaNegociosSKD.Comandos.Modulo9.ComandoAgregarEvento comando = (LogicaNegociosSKD.Comandos.Modulo9.ComandoAgregarEvento)FabricaComandos.ObtenerComandoAgregarEvento(elEvento);
            Boolean auxiliar = comando.Ejecutar();
            Console.Out.WriteLine(auxiliar);
            Assert.True(auxiliar);
        }

        /// <summary>
        /// Prueba que permite verificar si esta retornando los datos correctos de BD
        /// </summary>
        [Test]
        public void PruebaConsultarEvento()
        {
            FabricaEntidades fabricaEntidad = new FabricaEntidades();
            DominioSKD.Entidades.Modulo9.Evento evento = (DominioSKD.Entidades.Modulo9.Evento)fabricaEntidad.ObtenerEvento();
            evento.Id = 1;
            LogicaNegociosSKD.Comandos.Modulo9.ComandoConsultarEvento comando = (LogicaNegociosSKD.Comandos.Modulo9.ComandoConsultarEvento)FabricaComandos.ObtenerComandoConsultarEvento(evento);
            Entidad axuiliar = comando.Ejecutar();
            Console.Out.WriteLine(axuiliar.Id);
            Assert.AreEqual(axuiliar.Id, 1);
        }

        /// <summary>
        /// Prueba que permite verificar si esta modificando eventos en BD
        /// </summary>
        [Test]
        public void PruebaModificarEvento()
        {
            FabricaEntidades fabricaEntidad = new FabricaEntidades();
            DateTime fechaInicio = new DateTime(2008, 5, 1, 8, 30, 52);
            DateTime fechaFin = new DateTime(2009, 5, 1, 1, 1, 1);
            DominioSKD.Entidades.Modulo9.Horario horario = (DominioSKD.Entidades.Modulo9.Horario)fabricaEntidad.ObtenerHorario();
            horario.FechaInicio = fechaInicio;
            horario.FechaFin = fechaFin;
            horario.HoraInicioS = "10:30";
            horario.HoraFinS = "11:00";
            horario.Id = 1;
            DominioSKD.Entidades.Modulo9.TipoEvento tipoEvento = (DominioSKD.Entidades.Modulo9.TipoEvento)fabricaEntidad.ObtenerTipoEvento();
            tipoEvento.Id = 1;
            tipoEvento.Nombre = "Prueba Unitaria en Comandos";
            Persona persona = new Persona();
            persona.ID = 36;
            DominioSKD.Entidades.Modulo9.Evento elEvento = (DominioSKD.Entidades.Modulo9.Evento)fabricaEntidad.ObtenerEvento();
            elEvento.Id = 4;
            elEvento.Nombre = "Prueba Unitaria Comando Modificar";
            elEvento.Descripcion = "Pruebas Unitarias de Comando Modificar";
            elEvento.Costo = 55;
            elEvento.Estado = true;
            elEvento.Horario = horario;
            elEvento.TipoEvento = tipoEvento;
            elEvento.Persona = persona;
            LogicaNegociosSKD.Comandos.Modulo9.ComandoModificarEvento comando = (LogicaNegociosSKD.Comandos.Modulo9.ComandoModificarEvento)FabricaComandos.ObtenerComandoModificarEvento(elEvento);
            Boolean auxiliar = comando.Ejecutar();
            Console.Out.WriteLine(auxiliar);
            Assert.True(auxiliar);
        }

       
    }
}
