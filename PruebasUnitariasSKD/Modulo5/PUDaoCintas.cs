using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using LogicaNegociosSKD;
using LogicaNegociosSKD.Comandos.Modulo5;
using DominioSKD.Fabrica;
using DominioSKD.Entidades.Modulo5;
using DominioSKD.Entidades.Modulo3;
using DominioSKD;
using DatosSKD.Fabrica;
using DatosSKD.InterfazDAO.Modulo5;
using DatosSKD.DAO.Modulo5;

namespace PruebasUnitariasSKD.Modulo5
{
    [TestFixture]
    class PUDaoCintas
    {
        
      //  private Comando<bool> miComando;
        private FabricaDAOSqlServer fabricaDAO;
        private Entidad miEntidad;
        private Entidad miEntidadCinta;
        private Entidad miEntidadCintaModificar;
       
        [SetUp]
        public void init()
        {
           
            FabricaEntidades miFabrica = new FabricaEntidades();
            miEntidad = miFabrica.ObtenerOrganizacion_M3(1, "Seito Karate-do");
            DominioSKD.Entidades.Modulo3.Organizacion org = (DominioSKD.Entidades.Modulo3.Organizacion)miEntidad; ;
            miEntidadCinta = miFabrica.ObtenerCinta_M5(1, "Blanco","1er Kyu","Nivel inferior",	1, "Principiante"	, org, true);
            miEntidadCintaModificar = miFabrica.ObtenerCinta_M5(1, "Amarillo", "1er Kyu", "Nivel inferior", 3, "Principiante", org, true);
           // this.miComando = new EjecutarAgregarCinta(miEntidad);
       
        }

     /*   [Test]
        public void ejecutarElComandoAgregar()
        {

            bool resultado = this.miComando.Ejecutar();
            Assert.IsFalse(resultado);
        
        }*/

        [Test]
        public void PruebaValidarOrganizacion()
        {
            bool resultado;
            this.fabricaDAO = new FabricaDAOSqlServer(); 
            IDaoCinta miDaoCinta = this.fabricaDAO.ObtenerDaoCinta();
            resultado = miDaoCinta.ValidarOrganizacion(miEntidad);
            Assert.IsTrue(resultado);
           
        }

        [Test]
        public void PruebaValidarOrdenCinta()
        {
            bool resultado;
            this.fabricaDAO = new FabricaDAOSqlServer();
            IDaoCinta miDaoCinta = this.fabricaDAO.ObtenerDaoCinta();
            resultado = miDaoCinta.ValidarOrdenCinta(miEntidadCinta);
            Assert.IsTrue(resultado);

        }

        [Test]
        public void PruebaValidarNombreCinta()
        {
            bool resultado;
            this.fabricaDAO = new FabricaDAOSqlServer();
            IDaoCinta miDaoCinta = this.fabricaDAO.ObtenerDaoCinta();
            resultado = miDaoCinta.ValidarNombreCinta(miEntidadCinta);
            Assert.IsTrue(resultado);

        }

        [Test]
        public void PruebaListarCintasXOrganizacion()
        {
            List<Entidad> resultado;
            this.fabricaDAO = new FabricaDAOSqlServer();
            IDaoCinta miDaoCinta = this.fabricaDAO.ObtenerDaoCinta();
            resultado = miDaoCinta.ListarCintasXOrganizacion(miEntidad);
            Assert.IsEmpty(resultado);

        }

        [Test]
        public void PruebaAgregarCinta()
        {
            bool resultado;
            this.fabricaDAO = new FabricaDAOSqlServer();
            IDaoCinta miDaoCinta = this.fabricaDAO.ObtenerDaoCinta();
            resultado = miDaoCinta.Agregar(miEntidadCinta);
            Assert.IsTrue(resultado);

        }

        [Test]
        public void PruebaModificarCinta()
        {
            bool resultado;
            this.fabricaDAO = new FabricaDAOSqlServer();
            IDaoCinta miDaoCinta = this.fabricaDAO.ObtenerDaoCinta();
            resultado = miDaoCinta.Modificar(miEntidadCintaModificar);
            Assert.IsTrue(resultado);

        }

        [Test]
        public void PruebaConsultarTodos()
        {
            List<Entidad> resultado;
            this.fabricaDAO = new FabricaDAOSqlServer();
            IDaoCinta miDaoCinta = this.fabricaDAO.ObtenerDaoCinta();
            resultado = miDaoCinta.ConsultarTodos();
            Assert.IsEmpty(resultado);

        }

        [Test]
        public void PruebaConsultarXId()
        {
            Entidad resultado;
            this.fabricaDAO = new FabricaDAOSqlServer();
            IDaoCinta miDaoCinta = this.fabricaDAO.ObtenerDaoCinta();
            resultado = miDaoCinta.ConsultarXId(miEntidadCinta);
            Assert.IsNull(resultado);

        }


    }

}
