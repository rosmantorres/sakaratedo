using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DominioSKD;
using DatosSKD;
using DatosSKD.Modulo7;

namespace PruebasUnitariasSKD.Modulo7
{
    /// <summary>
    /// Clase de pruebas para la clase BDMaticula
    /// </summary>
    [TestFixture]
    public class M7_PruebasBDMatricula
    {

        #region Atributos
        /// <summary>
        /// Atributo que representa el id de la persona o atleta
        /// </summary>
        private int idPersona;
        #endregion

        #region SetUp & TearDown
        [SetUp]
        public void Init()
        {
            idPersona = 25;
        }

        [TearDown]
        public void Clean()
        {
            idPersona = 0;
        }
        #endregion

        #region Test

        /// <summary>
        /// Método para probar que se detalla una matricula
        /// </summary>
        [Test]
        public void PruebaDetallarMatriculaXId()
        {
            BDMatricula baseDeDatosMatricula = new BDMatricula();
            Matricula matricula = baseDeDatosMatricula.DetallarMatricula(4);
            Assert.AreEqual("A11", matricula.Identificador);
        }

        /// <summary>
        /// Método para probar que una matriculada detallado no sea nulo
        /// </summary>
        [Test]
        public void PruebaDetallarMatriculaXIdNoNulo()
        {
            BDMatricula baseDeDatosMatricula = new BDMatricula();
            Matricula matricula = baseDeDatosMatricula.DetallarMatricula(4);
            Assert.NotNull(matricula);
        }

     
       
        /// <summary>
        /// Método para probar que la lista obtenida tiene  cero o mas matriculas pagas
        /// </summary>
        [Test]
        public void PruebaListarMatriculasPagas()
        {
            BDMatricula baseDeDatosMatricula = new BDMatricula();
            List<Matricula> listaMatricula = baseDeDatosMatricula.ListarMatriculasPagas(idPersona);
            Assert.GreaterOrEqual(listaMatricula.Count, 0);
        }

        /// <summary>
        /// Método para probar que la lista obtenida de matriculas sea distinto de  nulo nulo
        /// </summary>
        [Test]
        public void PruebaListarMatriculasPagasNulas()
        {
            BDMatricula baseDeDatosMatricula = new BDMatricula();
            List<Matricula> listaMatricula = baseDeDatosMatricula.ListarMatriculasPagas(idPersona);
            Assert.NotNull(listaMatricula);
        }
       

        #endregion


    }
}
