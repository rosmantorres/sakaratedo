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

namespace PruebasUnitariasSKD.Modulo7.PruebasDAO
{
    /// <summary>
    /// Clase que contiene las pruebas unitarias para DaoHorario
    /// </summary>
    [TestFixture]
    public class M7_PruebasDAOHorario
    {
        #region Atributos
        private Horario idHorario;
        private FabricaEntidades fabricaEntidades;
        private FabricaDAOSqlServer fabricaSql;
        private DaoHorario baseDeDatosHorario;
        #endregion

        #region SetUp & TearDown
        [SetUp]
        public void Init()
        {
            fabricaSql = new FabricaDAOSqlServer();
            baseDeDatosHorario = fabricaSql.ObtenerDaoHorarioM7();
            fabricaEntidades = new FabricaEntidades();
            idHorario = new Horario(); //se sustituye por fabrica
            idHorario.Id = 6;
        }

        [TearDown]
        public void Clean()
        {
            idHorario = null;
            fabricaEntidades = null;
            fabricaSql = null;
            baseDeDatosHorario = null;
        }
        #endregion

        /// <summary>
        /// Método para probar que se detalla un horario en DAO
        /// </summary>
        [Test]
        public void PruebaDetallarHorarioXId()
        {
            Horario horario = (Horario)baseDeDatosHorario.ConsultarXId(idHorario);
            Assert.AreEqual("03/10/2015", horario.FechaFin.ToString("MM/dd/yyyy"));
        }

        /// <summary>
        /// Método para probar que el horario no es nulo en DAO
        /// </summary>
        [Test]
        public void PruebaDetallarHorarioXIdNoNulo()
        {
            Horario horario = (Horario)baseDeDatosHorario.ConsultarXId(idHorario);
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
            Horario horario = (Horario)baseDeDatosHorario.ConsultarXId(idHorario);
        }
    }
}

