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
using Interfaz_Presentadores.Modulo8;
using LogicaNegociosSKD.Fabrica;
using LogicaNegociosSKD.Comandos.Modulo8;

namespace PruebasUnitariasSKD.Modulo8
{
    [TestFixture]
    class PruebasRestCinta
    {

        #region Atributos
        List<Entidad> listaEntidad;
        public string idEvento;
        public string idCompetencia;
        public Entidad entidad;
        public Entidad entidad2;
        public bool a;
        #endregion

        [SetUp]
        public void init()
        {
            listaEntidad = new List<Entidad>();
            idEvento = "3";
            idCompetencia = "11";

        }

        [TearDown]
        public void clean()
        {
            listaEntidad = null;
            entidad = null;
        }

        #region Pruebas Unitarias

        [Test]
        public void PruebaConsultarCintaTodas()
        {
            IDaoRestriccionCinta DAO = FabricaDAOSqlServer.ObtenerDAORestriccionCinta();
            listaEntidad = DAO.ConsultarCintaTodas();
            Assert.NotNull(listaEntidad);
        }

        [Test]
        public void PruebaAgregarRestriccionCinta()
        {
            entidad = DominioSKD.Fabrica.FabricaEntidades.ObtenerRestriccionCinta("Descripcion pu", 1, 2, 3, 4,0);
            IDaoRestriccionCinta DAO = FabricaDAOSqlServer.ObtenerDAORestriccionCinta();
            entidad.Id = 5;
           a = DAO.AgregarRestriccionCinta(entidad);
            Assert.IsTrue(a);
        }

        [Test]
        public void PruebaModificarRestriccionCinta()
        {
            entidad = DominioSKD.Fabrica.FabricaEntidades.ObtenerRestriccionCinta(2, "Modificar pu2", 50, 50, 50, 50,0);
            IDaoRestriccionCinta DAO = FabricaDAOSqlServer.ObtenerDAORestriccionCinta();
            a = DAO.ModificarRestriccionCinta(entidad);
            Assert.IsTrue(a);
        }

        [Test]
        public void PruebaConsultarRestriccionCintaDT()
        {
            IDaoRestriccionCinta DAO = FabricaDAOSqlServer.ObtenerDAORestriccionCinta();
            listaEntidad = DAO.ConsultarRestriccionCintaDT();
            Assert.NotNull(listaEntidad);
        }

        [Test]
        public void PruebaStatusRestriccionCinta()
        {
            IDaoRestriccionCinta DAO = FabricaDAOSqlServer.ObtenerDAORestriccionCinta();
            entidad = DominioSKD.Fabrica.FabricaEntidades.ObtenerRestriccionCinta(37,1);
            a = DAO.StatusRestriccionCinta(entidad);
            Assert.IsTrue(a);
        }

        //Pruebas de Comando Restriccion Cinta

        [Test]
        public void PruebaComandoAgregarRestriccionCinta()
        {
            DominioSKD.Entidades.Modulo8.RestriccionCinta laRestCinta = new DominioSKD.Entidades.Modulo8.RestriccionCinta();
            laRestCinta.Id = 1;
            laRestCinta.Descripcion = "Descripcion Pu Comando Agregar";
            laRestCinta.PuntosMinimos = 1;
            laRestCinta.TiempoDocente = 1;
            laRestCinta.TiempoMinimo = 1;
            laRestCinta.TiempoMaximo = 1;
            laRestCinta.Status = 0;

            LogicaNegociosSKD.Comandos.Modulo8.ComandoAgregarRestriccionCinta _comando =
                        (LogicaNegociosSKD.Comandos.Modulo8.ComandoAgregarRestriccionCinta)LogicaNegociosSKD.Fabrica.FabricaComandos.CrearComandoAgregarRestriccionCinta(laRestCinta);
            bool resultado = _comando.Ejecutar();
            Assert.IsTrue(resultado,"Comando Agregado Correctamente");
            //Assert.IsFalse(resultado, "Comando no Agregado");
        }

        [Test]
        public void pruebaComandoConsultarRestriccionCinta()
        {
            List<Entidad> lista;
            LogicaNegociosSKD.Comando<List<Entidad>> command = FabricaComandos.CrearComandoConsultarRestriccionCinta();
            lista = command.Ejecutar();
            Assert.IsNotNull(lista," Objeto LLeno ");
            //Assert.IsEmpty(lista);
            //Assert.IsInstanceOfType(lista, List, "");

        }
        [Test]
        public void pruebaComandoConsultarCintaTodas()
        {
            LogicaNegociosSKD.Comandos.Modulo8.ComandoConsultarCintaTodas comboCinta =
                   (LogicaNegociosSKD.Comandos.Modulo8.ComandoConsultarCintaTodas)LogicaNegociosSKD.Fabrica.FabricaComandos.CrearComandoConsultarCintaTodas();
            List<Entidad> listCinta = new List<Entidad>();
            listCinta = comboCinta.Ejecutar();
            Assert.IsNotNull(listCinta, " Objeto LLeno ");
        }

        [Test]
        public void pruebaComandoModificarRCinta()
        {
            DominioSKD.Entidades.Modulo8.RestriccionCinta laRestCinta = new DominioSKD.Entidades.Modulo8.RestriccionCinta();
            
            laRestCinta.IdRestriccionCinta = 42;
            laRestCinta.PuntosMinimos = 2;
            laRestCinta.TiempoDocente = 1;
            laRestCinta.TiempoMinimo = 3;
            LogicaNegociosSKD.Comandos.Modulo8.ComandoModificarRestriccionCinta _comando =
                     (LogicaNegociosSKD.Comandos.Modulo8.ComandoModificarRestriccionCinta)LogicaNegociosSKD.Fabrica.FabricaComandos.CrearComandoModificarRestriccionCinta(laRestCinta);
            bool resultado = _comando.Ejecutar();
            Assert.IsTrue(resultado, " Consulta Correcta");
        }

        [Test]
        public void pruebaComandoModificarStatusCinta()
        {
            DominioSKD.Entidades.Modulo8.RestriccionCinta laRestCinta = new DominioSKD.Entidades.Modulo8.RestriccionCinta();
            int bitStatus = 1;
            laRestCinta.Status = bitStatus;
            laRestCinta.IdRestriccionCinta = 42;
            LogicaNegociosSKD.Comandos.Modulo8.ComandoModificarStatusCinta _comando =
                (LogicaNegociosSKD.Comandos.Modulo8.ComandoModificarStatusCinta)LogicaNegociosSKD.Fabrica.FabricaComandos.CrearComandoStatusRestriccionCinta(laRestCinta);
            bool resultado = _comando.Ejecutar();
            Assert.IsTrue(resultado, " Consulta Correcta");
        }
        #endregion


    }
}