using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSKD.InterfazDAO.Modulo8;
using DominioSKD;
using DatosSKD.DAO.Modulo8;
using DatosSKD.Fabrica;

namespace PruebasUnitariasSKD.Modulo8
{
    [TestFixture]
    public class PruebaDAORestriccionEvento
    {

        #region Atributos
        List<Entidad> listaEntidad;
        public string idEvento;
        public string idCompetencia;
        public Entidad entidad;
        public Entidad entidad2;
        public Entidad entidad3;
        public bool a;
        DominioSKD.Entidades.Modulo8.RestriccionEvento laRest;
        #endregion

        #region SetUp y TearDown
        [SetUp]
        public void init()
        {
            listaEntidad = new List<Entidad>();
            laRest = new DominioSKD.Entidades.Modulo8.RestriccionEvento();
            laRest.IdRestEvento = 1;
            laRest.Descripcion = "Negra";
            laRest.EdadMinima = 10;
            laRest.EdadMaxima = 15;
            laRest.Sexo = "M";
            laRest.IdEvento = 9;
            laRest.Status = 0;
            entidad = DominioSKD.Fabrica.FabricaEntidades.ObtenerRestriccionEvento(1, "Negro", 10, 15, "M", 7, "PUevento", 1);
            entidad3 = DominioSKD.Fabrica.FabricaEntidades.ObtenerEventoSimple(1, "el Evento Prueba");
        }

        [TearDown]
        public void clean()
        {
            listaEntidad = null;
            idEvento = null;
            idCompetencia = null;
            entidad = null;
            entidad2 = null;
            entidad3 = null;
            a = false;
            laRest = null;
        }
        #endregion

        #region Pruebas Unitarias Datos

        [Test]
        public void PruebaConsultarEventosConRestriccion()
        {
            IDaoRestriccionEvento DAO = FabricaDAOSqlServer.ObtenerDAORestriccionEvento();
            listaEntidad = DAO.ConsultarEventosConRestriccion();
            Assert.NotNull(listaEntidad);
        }

        [Test]
        public void PruebaAgregarRestriccionEvento()
        {
            IDaoRestriccionEvento DAO = FabricaDAOSqlServer.ObtenerDAORestriccionEvento();
            a = DAO.AgregarRestriccionEvento(entidad);
            Assert.IsTrue(a);
        }

        [Test]
        public void PruebaEliminarRestriccionEvento()
        {
            IDaoRestriccionEvento DAO = FabricaDAOSqlServer.ObtenerDAORestriccionEvento();
            a = DAO.EliminarRestriccionEvento(entidad);
            Assert.IsTrue(a);
        }

        [Test]
        public void PruebaModificarRestriccionEvento()
        {
            IDaoRestriccionEvento DAO = FabricaDAOSqlServer.ObtenerDAORestriccionEvento();
            a = DAO.ModificarRestriccionEvento(entidad);
            Assert.IsTrue(a);
        }

        [Test]
        public void PruebaConsultarEventosSinRestriccion()
        {
            IDaoRestriccionEvento DAO = FabricaDAOSqlServer.ObtenerDAORestriccionEvento();
            listaEntidad = DAO.ConsultarEventosSinRestriccion();
            Assert.NotNull(listaEntidad);
        }

        [Test]
        public void PruebaEventosQuePuedeAsistirAtleta()
        {
            IDaoRestriccionEvento DAO = FabricaDAOSqlServer.ObtenerDAORestriccionEvento();
            listaEntidad = DAO.EventosQuePuedeAsistirAtleta(1);
            Assert.NotNull(listaEntidad);
        }
        
        [Test]
        public void PruebaConsultarRestriccionEvento()
        {
            IDaoRestriccionEvento DAO = FabricaDAOSqlServer.ObtenerDAORestriccionEvento();
            entidad2 = DAO.ConsultarRestriccionEvento(entidad3);
            Assert.NotNull(entidad2);
        }
        #endregion

        #region Pruebas Unitarias Logica
        [Test]
        public void PruebaComandoAgregarRestriccionEvento()
        {
            LogicaNegociosSKD.Comandos.Modulo8.ComandoAgregarRestriccionEvento _comando =
                        (LogicaNegociosSKD.Comandos.Modulo8.ComandoAgregarRestriccionEvento)LogicaNegociosSKD.Fabrica.FabricaComandos.CrearComandoAgregarRestriccionEvento(laRest);
            a = _comando.Ejecutar();
            Assert.IsTrue(a);
        }

        [Test]
        public void PruebaComandoConsultarEventosSinRestriccion()
        {
            LogicaNegociosSKD.Comandos.Modulo8.ComandoConsultarEventosSinRestriccion _comando =
                        (LogicaNegociosSKD.Comandos.Modulo8.ComandoConsultarEventosSinRestriccion)LogicaNegociosSKD.Fabrica.FabricaComandos.CrearComandoConsultarEventosSinRestriccion();
            listaEntidad = _comando.Ejecutar();
            Assert.IsNotNull(listaEntidad);
        }

        [Test]
        public void PruebaComandoConsultarRestriccionEvento()
        {
            LogicaNegociosSKD.Comandos.Modulo8.ComandoConsultarRestriccionEvento _comando =
                        (LogicaNegociosSKD.Comandos.Modulo8.ComandoConsultarRestriccionEvento)LogicaNegociosSKD.Fabrica.FabricaComandos.CrearComandoConsultarRestriccionEvento();
            listaEntidad = _comando.Ejecutar();
            Assert.IsNotNull(listaEntidad);
        }

        [Test]
        public void PruebaComandoModificarRestriccionEvento()
        {
            LogicaNegociosSKD.Comandos.Modulo8.ComandoModificarRestriccionEvento _comando = 
                        (LogicaNegociosSKD.Comandos.Modulo8.ComandoModificarRestriccionEvento)LogicaNegociosSKD.Fabrica.FabricaComandos.CrearComandoModificarRestriccionEvento(laRest);
            a = _comando.Ejecutar();
            Assert.IsTrue(a);
        }

        [Test]
        public void PruebaComandoEliminarRestriccionEvento()
        {
            LogicaNegociosSKD.Comandos.Modulo8.ComandoEliminarRestriccionEvento _comando = 
                        (LogicaNegociosSKD.Comandos.Modulo8.ComandoEliminarRestriccionEvento)LogicaNegociosSKD.Fabrica.FabricaComandos.CrearComandoEliminarRestriccionEvento(laRest);
            a = _comando.Ejecutar();
            Assert.IsTrue(a);
        }

        [Test]
        public void PruebaComandoConsultarUnaRestriccionEvento()
        {
            LogicaNegociosSKD.Comandos.Modulo8.ComandoConsultarUnaRestriccionEvento _comando =
                        (LogicaNegociosSKD.Comandos.Modulo8.ComandoConsultarUnaRestriccionEvento)LogicaNegociosSKD.Fabrica.FabricaComandos.CrearComandoConsultarUnaRestriccionEvento(entidad3);
            entidad2 = _comando.Ejecutar();
            Assert.IsNotNull(entidad2);
        }

        [Test]
        public void PruebaComandoEventosQuePuedeParticiparAtleta()
        {
            LogicaNegociosSKD.Comandos.Modulo8.ComandoEventosQuePuedeParticiparAtleta _comando =
                        (LogicaNegociosSKD.Comandos.Modulo8.ComandoEventosQuePuedeParticiparAtleta)LogicaNegociosSKD.Fabrica.FabricaComandos.CrearComandoEventosQuePuedeParticiparAtleta(entidad);
            listaEntidad = _comando.Ejecutar();
            Assert.IsNotNull(listaEntidad);
        }
        #endregion
    }
}