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
    public class M7_PruebasComandoListarCintas
    {
        #region Atributos
        private Persona idPersona;
        private FabricaComandos fabricaComandos;
        private ComandoConsultarListaCinta cintas;
        private FabricaEntidades fabricaEntidades;
        #endregion

        #region SetUp & TearDown
        [SetUp]
        public void Init()
        {
            fabricaComandos = new FabricaComandos();
            cintas = (ComandoConsultarListaCinta)fabricaComandos.ObtenerComandoConsultarListaCinta();
            fabricaEntidades = new FabricaEntidades();
            idPersona = new Persona();//cambiar por fabrica
            idPersona.ID = 6;
            cintas.LaEntidad = idPersona;
        }

        [TearDown]
        public void Clean()
        {
            fabricaComandos = null;
            cintas = null;
            fabricaEntidades = null;
            idPersona = null;
        }
        #endregion

        #region Test
        /// <summary>
        /// Método para probar que la tupla obtenida no es nula en cintas obtenidas
        /// </summary>
        [Test]
        public void PruebaObtenerTuplaCintasObtenidas()
        {
            Tuple<List<Entidad>, List<DateTime>> tupla = cintas.Ejecutar();
            Assert.IsNotNull(tupla);
        }

        /// <summary>
        /// Método para probar la excepcion de número entero invalido en obtener lista cintas obtenidas
        /// </summary>
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void ListaCintasNumeroEnteroException()
        {
            idPersona.ID = -1;
            Tuple<List<Entidad>, List<DateTime>> tupla = cintas.Ejecutar();
        }

        /// <summary>
        /// Método para probar que la lista obtenida de cintas puede tener uno o mas cintas
        /// </summary>
        [Test]
        public void PruebaObtenerListaCintasObtenidas()
        {
            Tuple<List<Entidad>, List<DateTime>> tupla = cintas.Ejecutar();
            List<Entidad> listaCintas = tupla.Item1;
            Assert.GreaterOrEqual(listaCintas.Count, 1);
        }


        /// <summary>
        /// Método para probar que la lista obtenida de fechas sobre cintas puede tener uno o mas fechas
        /// </summary>
        [Test]
        public void PruebaObtenerListaFechaCintasObtenidas()
        {
            Tuple<List<Entidad>, List<DateTime>> tupla = cintas.Ejecutar();
            List<DateTime> listaFechaCinta = tupla.Item2;
            Assert.GreaterOrEqual(listaFechaCinta.Count, 1);
        }

        #endregion
    }
}
