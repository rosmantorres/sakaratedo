﻿using DominioSKD;
using DominioSKD.Fabrica;
using ExcepcionesSKD.Modulo7;
using LogicaNegociosSKD.Comandos.Modulo7;
using LogicaNegociosSKD.Fabrica;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasUnitariasSKD.Modulo7.PruebasComando
{
    [TestFixture]
    public class M7_PruebasComandoDetallarCinta
    {
        #region Atributos
        private Cinta idCinta;
        private FabricaComandos fabricaComandos;
        private ComandoConsultarDetallarCinta detalleCinta;
        private FabricaEntidades fabricaEntidades;
        #endregion

        #region SetUp & TearDown
        [SetUp]
        public void Init()
        {
            fabricaComandos = new FabricaComandos();
            detalleCinta  = (ComandoConsultarDetallarCinta)fabricaComandos.ObtenerComandoConsultarDetallarCinta();
            fabricaEntidades = new FabricaEntidades();
            idCinta = new Cinta();//cambiar por fabrica
            idCinta.Id = 2;
            detalleCinta.LaEntidad = idCinta;
        }

        [TearDown]
        public void Clean()
        {
            fabricaComandos = null;
            detalleCinta = null;
            fabricaEntidades = null;
            idCinta = null;
        }
        #endregion

        #region Test
        /// <summary>
        /// Método para probar que la cinta obtenida no esta vacia
        /// </summary>
        [Test]
        public void PruebaCinta()
        {
            Cinta cinta = (Cinta)detalleCinta.Ejecutar();
            Assert.GreaterOrEqual("Amarillo", cinta.Color_nombre);
        }

        /// <summary>
        /// Método para probar que la cinta obtenida no es nula
        /// </summary>
        [Test]
        public void PruebaCintaNoNula()
        {
            Cinta cinta = (Cinta)detalleCinta.Ejecutar();
            Assert.IsNotNull(cinta);
        }

        /// <summary>
        /// Método para probar la excepcion de número entero invalido en detallar cinta
        /// </summary>
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void DetallarCintaNumeroEnteroException()
        {
            idCinta.Id = -1;
            Cinta cinta = (Cinta)detalleCinta.Ejecutar();
        }
        #endregion
    }
}