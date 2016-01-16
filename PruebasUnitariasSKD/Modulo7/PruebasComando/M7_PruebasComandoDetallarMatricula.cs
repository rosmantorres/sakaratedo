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
    public class M7_PruebasComandoDetallarMatricula
    {
        #region Atributos
        private Matricula idMatricula;
        private FabricaComandos fabricaComandos;
        private ComandoConsultarDetallarMatricula detalleMatricula;
        private FabricaEntidades fabricaEntidades;
        #endregion

        #region SetUp & TearDown
        [SetUp]
        public void Init()
        {
            fabricaComandos = new FabricaComandos();
            detalleMatricula = (ComandoConsultarDetallarMatricula)fabricaComandos.ObtenerComandoConsultarDetallarMatricula();
            fabricaEntidades = new FabricaEntidades();
            idMatricula = new Matricula();//cambiar por fabrica
            idMatricula.Id = 2;
            detalleMatricula.LaEntidad = idMatricula;
        }

        [TearDown]
        public void Clean()
        {
            fabricaComandos = null;
            detalleMatricula = null;
            fabricaEntidades = null;
            idMatricula = null;
        }
        #endregion

        #region Test
        /// <summary>
        /// Método para probar que la matricula obtenida no esta vacia
        /// </summary>
        [Test]
        public void PruebaMatricula()
        {
            Matricula matricula = (Matricula)detalleMatricula.Ejecutar();
            Assert.GreaterOrEqual("CCA1-CAF-CAFE", matricula.Identificador);
        }

        /// <summary>
        /// Método para probar que la matricula obtenida no es nula
        /// </summary>
        [Test]
        public void PruebaMatriculaNoNula()
        {
            Matricula matricula = (Matricula)detalleMatricula.Ejecutar();
            Assert.IsNotNull(matricula);
        }

        /// <summary>
        /// Método para probar la excepcion de número entero invalido en detallar matricula
        /// </summary>
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void DetallarMatriculaNumeroEnteroException()
        {
            idMatricula.Id = -1;
            Matricula matricula = (Matricula)detalleMatricula.Ejecutar();
        }
        #endregion
    }
}
