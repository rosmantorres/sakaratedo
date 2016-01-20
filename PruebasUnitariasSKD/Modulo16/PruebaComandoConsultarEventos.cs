using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using LogicaNegociosSKD.Comandos.Modulo16;
using DominioSKD;
using DominioSKD.Entidades.Modulo15;
using DominioSKD.Entidades.Modulo6;
using LogicaNegociosSKD.Fabrica;
using LogicaNegociosSKD.Comandos;
using LogicaNegociosSKD;

namespace PruebasUnitariasSKD.Modulo16
{
    
    /// <summary>
    /// Prueba unitaria del Caso de Uso consultar eventos
    /// </summary>
    [TestFixture]
    
    class PruebaComandoConsultarEventos
    {

        #region Atributos
        //Atributos pertinentes a usar
        private ComandoConsultarTodosEventos pruebaComandoConsultarEventos;
        private FabricaComandos fabrica;
        
        #endregion

         


        /// <summary>
        /// Inicializa  los atributos que utilizaremos para probar
        /// </summary>
        [SetUp]
        public void Iniciar()
        {
            //La fabrica
            fabrica = new FabricaComandos();
             
            //Se inicializa la prueba para consultar un evento existente en particular
            this.pruebaComandoConsultarEventos = (ComandoConsultarTodosEventos)fabrica.CrearComandoConsultarTodosEventos();
          
         }


        /// <summary>
        /// Prueba unitaria para asegurar que el comando no sea vacio
        /// </summary>
        [Test]
        public void PruebaVacio()
        {
            Assert.IsNotNull(this.pruebaComandoConsultarEventos);
        }






        /// <summary>
        /// Elimina todos los atributos utilizados al probar
        /// </summary>
        [TearDown]
        public void Limpiar()
        {
            this.fabrica = null;
            this.pruebaComandoConsultarEventos = null;
        
 

        }







    }
}
