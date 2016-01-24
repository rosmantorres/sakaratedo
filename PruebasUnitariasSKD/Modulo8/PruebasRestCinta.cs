using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using LogicaNegociosSKD;
using LogicaNegociosSKD.Comandos.Modulo5;
using DominioSKD.Fabrica;
using DominioSKD.Entidades.Modulo8;
using DominioSKD;
using DatosSKD.Fabrica;
using DatosSKD.InterfazDAO.Modulo8;
using DatosSKD.DAO.Modulo8;
using LogicaNegociosSKD.Fabrica;

namespace PruebasUnitariasSKD.Modulo8
{

    [TestFixture]
    class PruebasRestCinta
    {
        #region Atributos
        private Comando<bool> miComando;
        private Entidad miEntidad;
        private Entidad RestriccionCintaAgregar;
        private Comando<List<Entidad>> miComandoLista;
        private Comando<Entidad> miComandoEntidad;
        FabricaComandos _fabrica = new FabricaComandos();
        #endregion

        #region SetUp & TearDown
        /// <summary>
        /// Método que se ejecuta antes de cada prueba
        /// </summary>
        [SetUp]
        public void init()
        {
            miEntidad = FabricaEntidades.ObtenerRestriccionCinta();
            DominioSKD.Entidades.Modulo8.RestriccionCinta restCinta = (DominioSKD.Entidades.Modulo8.RestriccionCinta)miEntidad; ;
            
            RestriccionCintaAgregar = FabricaEntidades.ObtenerRestriccionCinta(1,"pUDescripcion", 1, 1, 1, 1);
        }

        /// <summary>
        /// Método que se ejecuta luego de cada prueba
        /// </summary>
        [TearDown]
        public void Clean()
        {
            miComando = null;
            miEntidad = null;
            RestriccionCintaAgregar = null;
            miComandoLista = null;
            miComandoEntidad = null;

        }
        #endregion


        [Test]
        public void ejecutarElComandoAgregar()
        {
            this.miComando = _fabrica.CrearComandoAgregarRestriccionCinta(RestriccionCintaAgregar);
            bool resultado = this.miComando.Ejecutar();
            Assert.IsFalse(resultado);

        }
    }
}

