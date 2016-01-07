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

    /// <summary>
    /// Prueba unitaria del Caso de Uso Agregar Item
    /// </summary>
    [TestFixture]
    public class PruebaDaoEliminarItem
    {
        #region Atributos
        //Atributos pertinentes a usar
        private DaoCarrito pruebaDao;
        private IdaoCarrito daoCarrito;
        private Entidad persona;
        private Entidad implemento;
        private Matricula matricula;

        #endregion


        /// <summary>
        /// Prepara todos los atributos que utilizaremos para probar
        /// </summary>
        [SetUp]
        public void Iniciar()
        {
            //La persona
            this.persona = new Persona();
            this.persona.Id = 11;


            //Dos implementos distintos
            this.implemento = new Implemento();
            this.implemento.Id = 1;
 

            //Dos matriculas distintas
            this.matricula = new Matricula();
            this.matricula.Id = 1;
            this.matricula.Costo = 5000;


            //Obtengo el comando
            this.pruebaDao = (DaoCarrito)FabricaDAOSqlServer.ObtenerdaoCarrito();

        
        }

        /// <summary>
        /// prueba para eliminar matricula
        /// </summary>
        [Test]
        public void pruebaEliminarMatricula()
        {
            daoCarrito = FabricaDAOSqlServer.ObtenerdaoCarrito();
            Assert.IsTrue(daoCarrito.eliminarItem(1,1,persona));

        }



        /// <summary>
        /// prueba para eliminar evento
        /// </summary>
        [Test]
        public void pruebaEliminarEvento()
        {
            daoCarrito = FabricaDAOSqlServer.ObtenerdaoCarrito();
            Assert.IsTrue(daoCarrito.eliminarItem(3, 3, persona));

        }



        /// <summary>
        /// prueba para eliminar implemento
        /// </summary>
        [Test]
        public void pruebaEliminarImplemento()
        {
            daoCarrito = FabricaDAOSqlServer.ObtenerdaoCarrito();
            Assert.IsTrue(daoCarrito.eliminarItem(1, 2, persona));

        }



        /// <summary>
        /// Elimina todos los atributos utilizados al probar
        /// </summary>
        [TearDown]
        public void Limpiar()
        {
             
            this.persona = null;
            this.implemento = null;
            this.matricula = null;
            this.pruebaDao = null;
            this.daoCarrito = null;


        }
    }
}
