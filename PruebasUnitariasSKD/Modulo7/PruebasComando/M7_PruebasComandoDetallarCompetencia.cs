using DominioSKD;
using DominioSKD.Fabrica;
using ExcepcionesSKD.Modulo7;
using LogicaNegociosSKD.Comandos.Modulo7;
using LogicaNegociosSKD.Fabrica;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasUnitariasSKD.Modulo7.PruebasComando
{
    [TestFixture]
    public class M7_PruebasComandoDetallarCompetencia
    {
        #region Atributos
        private Competencia idCompetencia;
        private FabricaComandos fabricaComandos;
        private ComandoConsultarDetallarCompetencia detalleCompetencia;
        private FabricaEntidades fabricaEntidades;
        #endregion

        #region SetUp & TearDown
        [SetUp]
        public void Init()
        {
            fabricaComandos = new FabricaComandos();
            detalleCompetencia = (ComandoConsultarDetallarCompetencia)fabricaComandos.ObtenerComandoConsultarDetallarCompetencia();
            fabricaEntidades = new FabricaEntidades();
            idCompetencia = new Competencia();//cambiar por fabrica
            idCompetencia.Id = 2;
            detalleCompetencia.LaEntidad = idCompetencia;
        }

        [TearDown]
        public void Clean()
        {
            fabricaComandos = null;
            detalleCompetencia = null;
            fabricaEntidades = null;
            idCompetencia = null;
        }
        #endregion

        #region Test
        /// <summary>
        /// Método para probar que la competencia obtenida no esta vacia
        /// </summary>
        [Test]
        public void PruebaCompetencia()
        {
            Competencia competencia = (Competencia)detalleCompetencia.Ejecutar();
            Assert.GreaterOrEqual("Kobudo", competencia.Nombre);
        }

        /// <summary>
        /// Método para probar que la competencia obtenida no es nula
        /// </summary>
        [Test]
        public void PruebaCintaNoNula()
        {
            Competencia competencia = (Competencia)detalleCompetencia.Ejecutar();
            Assert.IsNotNull(competencia);
        }

        /// <summary>
        /// Método para probar la excepcion de número entero invalido en detallar competencia
        /// </summary>
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void DetallarCintaNumeroEnteroException()
        {
            idCompetencia.Id = -1;
            Competencia competencia = (Competencia)detalleCompetencia.Ejecutar();
        }
        #endregion
    }
}
