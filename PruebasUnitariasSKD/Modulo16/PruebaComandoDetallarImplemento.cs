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
using DominioSKD.Entidades.Modulo1;
using LogicaNegociosSKD.Fabrica;
using LogicaNegociosSKD.Comandos;
using LogicaNegociosSKD;

namespace PruebasUnitariasSKD.Modulo16
{
    class PruebaComandoDetallarImplemento
    {


        #region Atributos
        //Atributos pertinentes a usar
        private ComandoDetallarProducto pruebaComandoDetallarImplemento;
        private Entidad implemento;

        #endregion




        /// <summary>
        /// Inicializa  los atributos que utilizaremos para probar
        /// </summary>
        [SetUp]
        public void Iniciar()
        {

            //Se inicializa la prueba para consultar implementos existentes en stock
            this.pruebaComandoDetallarImplemento = (ComandoDetallarProducto)FabricaComandos.CrearComandoDetallarProducto(implemento);

        }


        /// <summary>
        /// Prueba unitaria para asegurar que el comando no sea vacio
        /// </summary>
        [Test]
        public void PruebaVacio()
        {
            Assert.IsNotNull(this.pruebaComandoDetallarImplemento);
        }






        /// <summary>
        /// Elimina todos los atributos utilizados al probar
        /// </summary>
        [TearDown]
        public void Limpiar()
        {
            this.pruebaComandoDetallarImplemento = null;



        }


    }
}
