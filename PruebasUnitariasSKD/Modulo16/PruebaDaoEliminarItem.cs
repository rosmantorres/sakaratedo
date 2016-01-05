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
        private DaoCarrito pruebaDaoeliminarImplemento1;
        private DaoCarrito pruebaDaoeliminarEvento1;
        private DaoCarrito pruebaDaoeliminarMatricula1;
        private List<Entidad> eventos;
        private Entidad persona;
        private Entidad implemento;
        private List<Entidad> listaEventos;
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


            //Eventos
            //  this.eventos = FabricaDAOSqlServer.CrearComandoConsultarTodosEventos();
            // this.listaEventos = this.eventos.Ejecutar();

            //Dos matriculas distintas
            this.matricula = new Matricula();
            this.matricula.Id = 1;
            this.matricula.Costo = 5000;


            //Obtengo el comando
            this.pruebaDao = (DaoCarrito)FabricaDAOSqlServer.ObtenerdaoCarrito();

            //Diferentes valores para Eliminar un Implemento
            this.pruebaDaoeliminarImplemento1 = (DaoCarrito)FabricaDAOSqlServer.ObtenerdaoCarrito();
            //   this.pruebaDaoeliminarImplemento1 = this.pruebaDaoeliminarImplemento1.eliminarItem(1,1,);






        }








    }
}
