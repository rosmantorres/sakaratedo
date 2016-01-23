using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSKD.Fabrica;
using DominioSKD.Fabrica;
using DominioSKD;
using NUnit.Framework;


namespace PruebasUnitariasSKD.Modulo9
{
   
        /// <summary>
        /// Clase Encargada de Realizar las pruebas unitarias de los metodos de la Clase BDEvento
        /// </summary>
        [TestFixture]
        class PruebasDaoEvento
        {



            #region SetUp&TearDown

            [SetUp]
            public void Init()
            {
                FabricaEntidades fabricaEntidad = new FabricaEntidades();
                DateTime fechaInicio = new DateTime(2008, 5, 1, 8, 30, 52);
                DateTime fechaFin = new DateTime(2009, 5, 1, 1, 1, 1);
                DominioSKD.Entidades.Modulo9.Horario horario = (DominioSKD.Entidades.Modulo9.Horario)fabricaEntidad.ObtenerHorario();
                horario.FechaInicio = fechaInicio;
                horario.FechaFin = fechaFin;
                horario.HoraInicio = 10;
                horario.HoraFin = 10;
                horario.Id = 1;
                DominioSKD.Entidades.Modulo9.TipoEvento tipoEvento = (DominioSKD.Entidades.Modulo9.TipoEvento)fabricaEntidad.ObtenerTipoEvento();
                tipoEvento.Id = 1;
                tipoEvento.Nombre = "Prueba Unitaria en Dao";               
                Persona persona = new Persona();
                persona.ID = 33;
                DominioSKD.Entidades.Modulo9.Evento elEvento = (DominioSKD.Entidades.Modulo9.Evento)fabricaEntidad.ObtenerEvento();
                elEvento.Nombre = "Prueba Unitaria Dao";
                elEvento.Descripcion = "Pruebas Unitarias de DAO";
                elEvento.Costo = 55;
                elEvento.Estado = true;           
                elEvento.Horario = horario;
                elEvento.TipoEvento = tipoEvento;
                elEvento.Persona = persona;
            }

            [TearDown]

            public void clean()
            {
                
            }
            #endregion

            #region Pruebas Unitarias

            /// <summary>
            /// Prueba que verifica si se inserta en BD
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
                horario.HoraInicio = 10;
                horario.HoraFin = 10;
                horario.Id = 1;
                DominioSKD.Entidades.Modulo9.TipoEvento tipoEvento = (DominioSKD.Entidades.Modulo9.TipoEvento)fabricaEntidad.ObtenerTipoEvento();
                tipoEvento.Id = 1;
                tipoEvento.Nombre = "Prueba Unitaria en Dao";
                Persona persona = new Persona();
                persona.ID = 33;
                DominioSKD.Entidades.Modulo9.Evento elEvento = (DominioSKD.Entidades.Modulo9.Evento)fabricaEntidad.ObtenerEvento();
                elEvento.Nombre = "Prueba Unitaria Dao";
                elEvento.Descripcion = "Pruebas Unitarias de DAO";
                elEvento.Costo = 55;
                elEvento.Estado = true;
                elEvento.Horario = horario;
                elEvento.TipoEvento = tipoEvento;
                elEvento.Persona = persona;
                DatosSKD.DAO.Modulo9.DaoEvento daoEvento = (DatosSKD.DAO.Modulo9.DaoEvento)FabricaDAOSqlServer.ObtenerDaoEvento();
                Boolean auxiliar = daoEvento.Agregar(elEvento);
                Console.Out.WriteLine(auxiliar);
                Assert.True(auxiliar);
            }

            /// <summary>
            /// Prueba que permite saber si esta retornando los datos de BD
            /// </summary>
            [Test]
            public void PruebaListarEventos()
            {
                DatosSKD.DAO.Modulo9.DaoEvento daoEvento = (DatosSKD.DAO.Modulo9.DaoEvento)FabricaDAOSqlServer.ObtenerDaoEvento();
                List<Entidad> listaEvento = daoEvento.ListarEventos(70);
                foreach (Entidad a in listaEvento)
                {
                    DominioSKD.Entidades.Modulo9.Evento evento = (DominioSKD.Entidades.Modulo9.Evento)a;
                    Console.Out.WriteLine(evento.Id);
                    Console.Out.WriteLine(evento.Nombre);
                    Console.Out.WriteLine(evento.Descripcion);

                }
                Assert.Greater(listaEvento.Count, 0);
            }

            /// <summary>
            /// Prueba que permite saber si esta retornando los datos de BD
            /// </summary>
            [Test]
            public void PruebaListarTiposEventos()
            {
                DatosSKD.DAO.Modulo9.DaoEvento daoEvento = (DatosSKD.DAO.Modulo9.DaoEvento)FabricaDAOSqlServer.ObtenerDaoEvento();
                List<Entidad> listaEvento = daoEvento.ListarTiposEventos();
                foreach (Entidad a in listaEvento)
                {
                    DominioSKD.Entidades.Modulo9.TipoEvento tipo = (DominioSKD.Entidades.Modulo9.TipoEvento)a;
                    Console.Out.WriteLine(tipo.Id);
                    Console.Out.WriteLine(tipo.Nombre);
                    

                }
                Assert.Greater(listaEvento.Count, 0);
            }

        /// <summary>
        /// Prueba que verifica si se el evento consultado existe
        /// </summary>

        [Test]
            public void PruebaConsultarEvento()
            {
                FabricaEntidades fabricaEntidad = new FabricaEntidades();
                DatosSKD.DAO.Modulo9.DaoEvento daoEvento = (DatosSKD.DAO.Modulo9.DaoEvento)FabricaDAOSqlServer.ObtenerDaoEvento();
                DominioSKD.Entidades.Modulo9.Evento evento = (DominioSKD.Entidades.Modulo9.Evento)fabricaEntidad.ObtenerEvento();
                evento.Id = 1;
                Entidad axuiliar = daoEvento.ConsultarXId(evento);
                Console.Out.WriteLine(axuiliar.Id);
                Assert.AreEqual(axuiliar.Id,1);
            }

            /*[Test]
            public void PruebaListarHorarios()
            {
                DatosSKD.Modulo9.BDEvento baseDeDatosEvento = new DatosSKD.Modulo9.BDEvento();
                List<Horario> horarios = baseDeDatosEvento.ListarHorarios();
                Assert.Greater(horarios.Count, 0);
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


            }*/
            #endregion
        }
    }



