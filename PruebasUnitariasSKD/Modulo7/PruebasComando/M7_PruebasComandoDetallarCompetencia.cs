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
using DominioSKD.Entidades.Modulo7;

namespace PruebasUnitariasSKD.Modulo7.PruebasComando
{
    /// <summary>
    /// Clase que contiene las pruebas unitarias para el comando detallar competencia de atleta
    /// </summary>
    [TestFixture]
    public class M7_PruebasComandoDetallarCompetencia
    {
        #region Atributos
        private CompetenciaM7 idCompetencia;
        private FabricaComandos fabricaComandos;
        private ComandoConsultarDetallarCompetencia detalleCompetencia;
        #endregion

        #region SetUp & TearDown
        /// <summary>
        /// Método que se ejecuta antes de cada prueba
        /// </summary>
        [SetUp]
        public void Init()
        {
            fabricaComandos = new FabricaComandos();
            detalleCompetencia = (ComandoConsultarDetallarCompetencia)fabricaComandos.ObtenerComandoConsultarDetallarCompetencia();
            idCompetencia = (CompetenciaM7)FabricaEntidades.ObtenerCompetenciaM7();
            idCompetencia.Id = 2;
            detalleCompetencia.LaEntidad = idCompetencia;
        }

        /// <summary>
        /// Método que se ejecuta luego de cada prueba
        /// </summary>
        [TearDown]
        public void Clean()
        {
            fabricaComandos = null;
            detalleCompetencia = null;
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
            CompetenciaM7 competencia = (CompetenciaM7)detalleCompetencia.Ejecutar();
            Assert.GreaterOrEqual("Kobudo", competencia.Nombre);
        }

        /// <summary>
        /// Método para probar que la competencia obtenida no es nula
        /// </summary>
        [Test]
        public void PruebaCintaNoNula()
        {
            CompetenciaM7 competencia = (CompetenciaM7)detalleCompetencia.Ejecutar();
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
            CompetenciaM7 competencia = (CompetenciaM7)detalleCompetencia.Ejecutar();
        }
        #endregion
    }
}
