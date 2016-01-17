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
using LogicaNegociosSKD.Fabrica;

namespace PruebasUnitariasSKD.Modulo5
{
    /// <summary>
    /// Clase que contiene las pruebas unitarias para Comandos Cinta
    /// </summary>
    [TestFixture]
    class PUComandoCinta
    {
        #region Atributos
        private Comando<bool> miComando;
        private Entidad miEntidad;
        private Entidad miEntidadCinta;
        private Entidad miEntidadCintaModificar;
        FabricaComandos fabricaComandos;
        private Entidad miEntidadCintaAgregar;
        private Comando<List<Entidad>> miComandoLista;
        private Comando<Entidad> miComandoEntidad;
        private FabricaEntidades miFabrica;
        #endregion

        #region SetUp & TearDown
        /// <summary>
        /// Método que se ejecuta antes de cada prueba
        /// </summary>
        [SetUp]
        public void init()
        {
            miFabrica = new FabricaEntidades();
            fabricaComandos = new FabricaComandos();
            miEntidad = miFabrica.ObtenerOrganizacion_M3(3, "Shotokan Org");
            DominioSKD.Entidades.Modulo3.Organizacion org = (DominioSKD.Entidades.Modulo3.Organizacion)miEntidad; ;
            miEntidadCinta = miFabrica.ObtenerCinta_M5(1, "Blanco", "1er Kyu", "Nivel inferior", 1, "Principiante", org, true);
            miEntidadCintaModificar = miFabrica.ObtenerCinta_M5(1, "Verde", "1er Kyu", "Nivel inferior", 2, "Principiante", org, true);
            miEntidadCintaAgregar = miFabrica.ObtenerCinta_M5(16, "Rojo", "1er Kyu", "Nivel inferior", 4, "Principiante", org, true);
            
        }

        /// <summary>
        /// Método que se ejecuta luego de cada prueba
        /// </summary>
        [TearDown]
        public void Clean()
        {
            miComando = null;
            fabricaComandos = null;
            miEntidad = null;
            miEntidadCinta = null;
            miEntidadCintaModificar = null;
            miEntidadCintaAgregar = null;
            miFabrica = null;
            miComandoLista = null;
            miComandoEntidad = null;

        }
        #endregion

        
        #region Test
        /// <summary>
        /// Método de prueba para Ejecutar el comando Agregar una Cinta
        /// </summary>
        [Test]
        public void ejecutarElComandoAgregar()
        {
            this.miComando = this.fabricaComandos.ObtenerEjecutarAgregarCinta(miEntidadCintaAgregar);
            bool resultado = this.miComando.Ejecutar();
            Assert.IsFalse(resultado);
        
        }

        /// <summary>
        /// Método de prueba para Ejecutar el comando Modificar una Cinta
        /// </summary>
        [Test]
        public void ejecutarElComandoModificar()
        {
            this.miComando = this.fabricaComandos.ObtenerEjecutarModificarCinta(miEntidadCintaModificar);
            bool resultado = this.miComando.Ejecutar();
            Assert.IsFalse(resultado);

        }
        /// <summary>
        /// Método de prueba para Ejecutar el comando Consultar todas las Cintas
        /// </summary>
        [Test]
        public void ejecutarElComandoConsultarTodosCinta()
        {
            this.miComandoLista = this.fabricaComandos.ObtenerEjecutarConsultarTodosCinta();
            List<Entidad> resultado = this.miComandoLista.Ejecutar();
            Assert.IsNotEmpty(resultado);

        }

        /// <summary>
        /// Método de prueba para Ejecutar el comando Consultar cinta por ID
        /// </summary>
        [Test]
        public void ejecutarElComandoConsultarXIdCinta()
        {
            this.miComandoEntidad = this.fabricaComandos.ObtenerEjecutarConsultarXIdCinta(miEntidadCinta);
            Entidad resultado = this.miComandoEntidad.Ejecutar();
            Assert.IsNotNull(resultado);

        }

        #endregion
    }
}
