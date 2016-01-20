﻿using System;
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
    class PruebaComandoDetallarEvento
    {

        #region Atributos
        //Atributos pertinentes a usar
        private ComandoDetallarEvento pruebaComandoDetallarEvento;
        private Entidad elevento;
        private FabricaComandos fabrica;

        #endregion




        /// <summary>
        /// Inicializa  los atributos que utilizaremos para probar
        /// </summary>
        [SetUp]
        public void Iniciar()
        {
      
            //Se inicializa la prueba para consultar un evento existente en particular
            this.pruebaComandoDetallarEvento = (ComandoDetallarEvento)FabricaComandos.CrearComandoDetallarEvento(elevento);

        }


        /// <summary>
        /// Prueba unitaria para asegurar que el comando no sea vacio
        /// </summary>
        [Test]
        public void PruebaVacio()
        {
            Assert.IsNotNull(this.pruebaComandoDetallarEvento);
        }






        /// <summary>
        /// Elimina todos los atributos utilizados al probar
        /// </summary>
        [TearDown]
        public void Limpiar()
        {
            this.pruebaComandoDetallarEvento = null;
            this.fabrica = null;


        }


    }
}
