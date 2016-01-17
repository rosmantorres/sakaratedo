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
    /// <summary>
    /// Clase que contiene las pruebas unitarias para el comando consultar cinta de atleta
    /// </summary>
    [TestFixture]
    public class M7_PruebasComandoDetallarCinta
    {
        #region Atributos
        private Cinta idCinta;
        private FabricaComandos fabricaComandos;
        private ComandoConsultarDetallarCinta detalleCinta;
        private FabricaEntidades fabricaEntidades;
        #endregion

        #region SetUp & TearDown
        /// <summary>
        /// Método que se ejecuta antes de cada prueba
        /// </summary>
        [SetUp]
        public void Init()
        {
            fabricaComandos = new FabricaComandos();
            detalleCinta  = (ComandoConsultarDetallarCinta)fabricaComandos.ObtenerComandoConsultarDetallarCinta();
            detalleCinta.IdPersona.Id = 6;
            fabricaEntidades = new FabricaEntidades();
            idCinta = new Cinta();//cambiar por fabrica
            idCinta.Id = 2;
            detalleCinta.LaEntidad = idCinta;
        }

        /// <summary>
        /// Método que se ejecuta luego de cada prueba
        /// </summary>
        [TearDown]
        public void Clean()
        {
            fabricaComandos = null;
            detalleCinta = null;
            fabricaEntidades = null;
            idCinta = null;
        }
        #endregion

        #region Test
        /// <summary>
        /// Método para probar que la cinta obtenida no esta vacia
        /// </summary>
        [Test]
        public void PruebaCinta()
        {
            Tuple<Entidad, DateTime> tupla = detalleCinta.Ejecutar();
            Cinta cinta = (Cinta)tupla.Item1;
            Assert.GreaterOrEqual("Amarillo", cinta.Color_nombre);
        }

        /// <summary>
        /// Método para probar que la cinta obtenida no es nula
        /// </summary>
        [Test]
        public void PruebaCintaNoNula()
        {
            Tuple<Entidad, DateTime> tupla = detalleCinta.Ejecutar();
            Cinta cinta = (Cinta)tupla.Item1;
            Assert.IsNotNull(cinta);
        }

        /// <summary>
        /// Método para probar la excepcion de número entero invalido en detallar cinta
        /// </summary>
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void DetallarCintaNumeroEnteroException()
        {
            idCinta.Id = -1;
            Tuple<Entidad, DateTime> tupla = detalleCinta.Ejecutar();            
        }
        #endregion
    }
}
