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
        #region Pruebas Unitarias
        /// <summary>
        /// Prueba que verifica si se inserta en BD
        /// </summary>
        [Test]
        public void PruebaCrearEvento()
        {
            //FabricaEntidades fabricaEntidad = new FabricaEntidades();
            DateTime fechaInicio = new DateTime(2008, 5, 1, 8, 30, 52);
            DateTime fechaFin = new DateTime(2009, 5, 1, 1, 1, 1);
            DominioSKD.Entidades.Modulo9.Horario horario = (DominioSKD.Entidades.Modulo9.Horario)FabricaEntidades.ObtenerHorario();
            horario.FechaInicio = fechaInicio;
            horario.FechaFin = fechaFin;
            horario.HoraInicioS = "10:30";
            horario.HoraFinS = "11:00";
            horario.Id = 1;
            DominioSKD.Entidades.Modulo9.TipoEvento tipoEvento = (DominioSKD.Entidades.Modulo9.TipoEvento)FabricaEntidades.ObtenerTipoEvento();
            tipoEvento.Id = 1;
            tipoEvento.Nombre = "Prueba Unitaria en Dao";
            Persona persona = new Persona();
            persona.ID = 36;
            DominioSKD.Entidades.Modulo9.Evento elEvento = (DominioSKD.Entidades.Modulo9.Evento)FabricaEntidades.ObtenerEvento();
            elEvento.Nombre = "Prueba Unitaria Dao Crear";
            elEvento.Descripcion = "Pruebas Unitarias de DAO Crear";
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
            List<Entidad> listaEvento = daoEvento.ListarEventos(36);
            foreach (Entidad a in listaEvento)
            {
                DominioSKD.Entidades.Modulo9.Evento evento = (DominioSKD.Entidades.Modulo9.Evento)a;
                Console.Out.WriteLine(evento.Id);
                Console.Out.WriteLine(evento.Nombre);
                Console.Out.WriteLine(evento.Descripcion);
                Console.Out.WriteLine(evento.Costo);
                Console.Out.WriteLine(evento.Horario.FechaInicio);
                Console.Out.WriteLine(evento.Horario.FechaFin);
                Console.Out.WriteLine(evento.Horario.HoraInicioS);
                Console.Out.WriteLine(evento.Horario.HoraFinS);
                Console.Out.WriteLine(evento.TipoEvento.Nombre);


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
        /// Prueba que permite saber si esta modificando un evento
        /// </summary>
        [Test]
        public void PruebaModificarEvento()
        {
            //FabricaEntidades fabricaEntidad = new FabricaEntidades();
            DateTime fechaInicio = new DateTime(2008, 5, 1, 8, 30, 52);
            DateTime fechaFin = new DateTime(2009, 5, 1, 1, 1, 1);
            DominioSKD.Entidades.Modulo9.Horario horario = (DominioSKD.Entidades.Modulo9.Horario)FabricaEntidades.ObtenerHorario();
            horario.FechaInicio = fechaInicio;
            horario.FechaFin = fechaFin;
            horario.HoraInicioS = "10:30";
            horario.HoraFinS = "11:00";
            horario.Id = 1;
            DominioSKD.Entidades.Modulo9.TipoEvento tipoEvento = (DominioSKD.Entidades.Modulo9.TipoEvento)FabricaEntidades.ObtenerTipoEvento();
            tipoEvento.Id = 1;
            tipoEvento.Nombre = "Prueba Unitaria en Dao";
            Persona persona = new Persona();
            persona.ID = 36;
            DominioSKD.Entidades.Modulo9.Evento elEvento = (DominioSKD.Entidades.Modulo9.Evento)FabricaEntidades.ObtenerEvento();
            elEvento.Id = 4;
            elEvento.Nombre = "Prueba Unitaria Dao Modificar";
            elEvento.Descripcion = "Pruebas Unitarias de DAO Modificar";
            elEvento.Costo = 55;
            elEvento.Estado = true;
            elEvento.Horario = horario;
            elEvento.TipoEvento = tipoEvento;
            elEvento.Persona = persona;
            DatosSKD.DAO.Modulo9.DaoEvento daoEvento = (DatosSKD.DAO.Modulo9.DaoEvento)FabricaDAOSqlServer.ObtenerDaoEvento();
            Boolean auxiliar = daoEvento.Modificar(elEvento);
            Console.Out.WriteLine(auxiliar);
            Assert.True(auxiliar);


        }

        /// <summary>
        /// Prueba que verifica si se el evento consultado existe
        /// </summary>
        [Test]
        public void PruebaConsultarEvento()
        {
            FabricaEntidades fabricaEntidad = new FabricaEntidades();
            DatosSKD.DAO.Modulo9.DaoEvento daoEvento = (DatosSKD.DAO.Modulo9.DaoEvento)FabricaDAOSqlServer.ObtenerDaoEvento();
            DominioSKD.Entidades.Modulo9.Evento evento = (DominioSKD.Entidades.Modulo9.Evento)FabricaEntidades.ObtenerEvento();
            evento.Id = 1;
            Entidad axuiliar = daoEvento.ConsultarXId(evento);
            Console.Out.WriteLine(axuiliar.Id);
            Assert.AreEqual(axuiliar.Id,1);
        }

        #endregion

    }
}



