using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DominioSKD;
using DominioSKD.Entidades.Modulo6;
using DominioSKD.Entidades.Modulo15;
using DatosSKD.DAO.Modulo16;
using DatosSKD;
using DatosSKD.DAO;
using DatosSKD.Fabrica;
using DatosSKD.InterfazDAO.Modulo16;

namespace PruebasUnitariasSKD.Modulo16
{
    [TestFixture]
    public class PruebaDaoDetallarMatricula
    {

        #region Atributos
        //Atributos pertinentes a usar
        private DaoMensualidad pruebaDao;
        private IdaoMensualidad daoMatricula;
        private FabricaDAOSqlServer fabrica;
        #endregion


        /// <summary>
        /// Prepara todos los atributos que utilizaremos para probar
        /// </summary>
        [SetUp]
        public void Iniciar()
        {
          
            //Obtengo el comando
            this.pruebaDao = (DaoMensualidad)FabricaDAOSqlServer.ObtenerDaoMensualidades();


        }



        /// <summary>
        /// prueba para consultar matriculas
        /// </summary>
        [Test]
        public void pruebaConsultarImplementos()
        {
            daoMatricula = FabricaDAOSqlServer.ObtenerDaoMensualidades();
        //    Assert.IsNotNull(daoMatricula.DetallarMensualidad(1));

        }





        /// <summary>
        /// Elimina todos los atributos utilizados al probar
        /// </summary>
        [TearDown]
        public void Limpiar()
        {
            this.pruebaDao = null;
            this.daoMatricula = null;
            this.fabrica = null;
        }
          
    }
}
