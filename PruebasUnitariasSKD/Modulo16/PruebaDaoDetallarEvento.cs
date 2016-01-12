using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DominioSKD;
using DominioSKD.Entidades.Modulo1;
using DominioSKD.Entidades.Modulo6;
using DominioSKD.Entidades.Modulo15;
using DatosSKD.DAO.Modulo16;
using DatosSKD;
using DatosSKD.DAO;
using DatosSKD.Fabrica;
using DatosSKD.InterfazDAO.Modulo16;


namespace PruebasUnitariasSKD.Modulo16
{
    class PruebaDaoDetallarEvento
    {

        #region Atributos
        //Atributos pertinentes a usar
        private DaoEvento pruebaDao;
        private IdaoEvento daoEvento;
        #endregion


        /// <summary>
        /// Prepara todos los atributos que utilizaremos para probar
        /// </summary>
        [SetUp]
        public void Iniciar()
        {

            //Obtengo el comando
            this.pruebaDao = (DaoEvento)FabricaDAOSqlServer.ObtenerDaoEventos();


        }



        /// <summary>
        /// prueba para consultar eventos
        /// </summary>
        [Test]
        public void pruebaConsultarEventos()
        {
            daoEvento = FabricaDAOSqlServer.ObtenerDaoEventos();
            Assert.IsNotNull(daoEvento.DetallarEvento(1));

        }





        /// <summary>
        /// Elimina todos los atributos utilizados al probar
        /// </summary>
        [TearDown]
        public void Limpiar()
        {
            this.pruebaDao = null;
            this.daoEvento = null;
        }












    }
}
