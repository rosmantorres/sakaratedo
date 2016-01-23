﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DominioSKD;
//using DominioSKD.Entidades.Modulo1;
using DominioSKD.Entidades.Modulo6;
using DominioSKD.Entidades.Modulo15;
using DatosSKD.DAO.Modulo16;
using DatosSKD;
using DatosSKD.DAO;
using DatosSKD.Fabrica;
using DatosSKD.InterfazDAO.Modulo16;
using DatosSKD.InterfazDAO.Modulo15;
using DatosSKD.DAO.Modulo15;

namespace PruebasUnitariasSKD.Modulo16
{
    class PruebaDaoConsultarImplementos
    {
 
        #region Atributos
        //Atributos pertinentes a usar
        private DaoImplemento pruebaDao;
        private IDaoImplemento daoImplemento;
        private FabricaDAOSqlServer fabrica;
        #endregion


        /// <summary>
        /// Prepara todos los atributos que utilizaremos para probar
        /// </summary>
        [SetUp]
        public void Iniciar()
        {
            //La fabrica
            fabrica = new FabricaDAOSqlServer();

            //Obtengo el comando
            this.pruebaDao = (DaoImplemento)fabrica.ObtenerDaoProductos();


        }



        /// <summary>
        /// prueba para consultar implementos
        /// </summary>
        [Test]
        public void pruebaConsultarImplementos()
        {
            daoImplemento = fabrica.ObtenerDaoProductos();
            Assert.IsNotNull(daoImplemento.ListarImplemento());

        }





        /// <summary>
        /// Elimina todos los atributos utilizados al probar
        /// </summary>
        [TearDown]
        public void Limpiar()
        {
            this.fabrica = null;
            this.pruebaDao = null;
            this.daoImplemento = null;
        }
  
 
    }
}
