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
    /// Clase que contiene las pruebas unitarias para el comando detallar matricula de atleta
    /// </summary>
    [TestFixture]
    public class M7_PruebasComandoDetallarMatricula
    {
        #region Atributos
        private MatriculaM7 idMatricula;
        private FabricaComandos fabricaComandos;
        private ComandoConsultarDetallarMatricula detalleMatricula;
       
        #endregion

        #region SetUp & TearDown
        /// <summary>
        /// Método que se ejecuta antes de cada prueba
        /// </summary>
        [SetUp]
        public void Init()
        {
            fabricaComandos = new FabricaComandos();
            detalleMatricula = (ComandoConsultarDetallarMatricula)fabricaComandos.ObtenerComandoConsultarDetallarMatricula();
            //  fabricaEntidades = new FabricaEntidades();
            idMatricula = (MatriculaM7)FabricaEntidades.ObtenerMatriculaM7();
            idMatricula.Id = 2;
            detalleMatricula.LaEntidad = idMatricula;
            detalleMatricula.LaEntidad = idMatricula;

        }

        /// <summary>
        /// Método que se ejecuta luego de cada prueba
        /// </summary>
        [TearDown]
        public void Clean()
        {
            fabricaComandos = null;
            detalleMatricula = null;
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
            MatriculaM7 matricula = (MatriculaM7)detalleMatricula.Ejecutar();
            Assert.GreaterOrEqual("CCA1-CAF-CAFE", matricula.Identificador);
        }

        /// <summary>
        /// Método para probar que la matricula obtenida no es nula
        /// </summary>
        [Test]
        public void PruebaMatriculaNoNula()
        {
            MatriculaM7 matricula = (MatriculaM7)detalleMatricula.Ejecutar();
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
            MatriculaM7 matricula = (MatriculaM7)detalleMatricula.Ejecutar();
        }
        #endregion
    }
}
