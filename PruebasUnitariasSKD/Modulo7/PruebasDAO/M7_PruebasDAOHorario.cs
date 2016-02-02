using DatosSKD.DAO.Modulo7;
using DatosSKD.Fabrica;
using DominioSKD;
using DominioSKD.Fabrica;
using ExcepcionesSKD.Modulo7;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD.Entidades.Modulo7;

namespace PruebasUnitariasSKD.Modulo7.PruebasDAO
{
    /// <summary>
    /// Clase que contiene las pruebas unitarias para DaoHorario
    /// </summary>
    [TestFixture]
    public class M7_PruebasDAOHorario
    {
        #region Atributos
        private HorarioM7 idHorario;
        private DaoHorario baseDeDatosHorario;
        #endregion

        #region SetUp & TearDown
        /// <summary>
        /// Método que se ejecuta antes de cada prueba
        /// </summary>
        [SetUp]
        public void Init()
        {
            baseDeDatosHorario = FabricaDAOSqlServer.ObtenerDaoHorarioM7();
            idHorario = (HorarioM7)FabricaEntidades.ObtenerHorarioM7();
            idHorario.Id = 6;
        }

        /// <summary>
        /// Método que se ejecuta luego de cada prueba
        /// </summary>
        [TearDown]
        public void Clean()
        {
            idHorario = null;
            baseDeDatosHorario = null;
        }
        #endregion

        /// <summary>
        /// Método para probar que se detalla un horario en DAO
        /// </summary>
        [Test]
        public void PruebaDetallarHorarioXId()
        {
            HorarioM7 horario = (HorarioM7)baseDeDatosHorario.ConsultarXId(idHorario);
            Assert.AreEqual("03/10/2015", horario.FechaFin.ToString("MM/dd/yyyy"));
        }

        /// <summary>
        /// Método para probar que el horario no es nulo en DAO
        /// </summary>
        [Test]
        public void PruebaDetallarHorarioXIdNoNulo()
        {
            HorarioM7 horario = (HorarioM7)baseDeDatosHorario.ConsultarXId(idHorario);
            Assert.IsNotNull(horario);
        }
        /// <summary>
        /// Método para probar la exception de número entero invalido de prueba detalle horario en DAO
        /// </summary>

        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void PruebaDetallarHorarioNumeroEnteroException()
        {
            idHorario.Id = -1;
            HorarioM7 horario = (HorarioM7)baseDeDatosHorario.ConsultarXId(idHorario);
        }
    }
}

