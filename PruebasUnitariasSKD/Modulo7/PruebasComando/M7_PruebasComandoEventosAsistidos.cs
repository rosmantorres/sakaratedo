﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using LogicaNegociosSKD.Fabrica;
using DominioSKD;
using LogicaNegociosSKD.Comandos.Modulo7;
using DominioSKD.Fabrica;
using ExcepcionesSKD.Modulo7;
using DominioSKD.Entidades.Modulo7;

namespace PruebasUnitariasSKD.Modulo7.PruebasComando
{
    /// <summary>
    /// Clase que contiene las pruebas unitarias para el comando listar eventos asistidos de atleta
    /// </summary>
    [TestFixture]
    public class M7_PruebasComandoEventosAsistidos
    {
        #region Atributos
        private PersonaM7 idPersona;
        private ComandoConsultarListaEventosAsistidos eventosAsistidos;
        #endregion

        #region SetUp & TearDown
        /// <summary>
        /// Método que se ejecuta antes de cada prueba
        /// </summary>
        [SetUp]
        public void Init()
        {
            eventosAsistidos = (ComandoConsultarListaEventosAsistidos)FabricaComandos.ObtenerComandoConsultarListaEventosAsistidos();
            idPersona = (PersonaM7)FabricaEntidades.ObtenerPersonaM7();
            idPersona.Id = 6;
            eventosAsistidos.LaEntidad = idPersona;
        }

        /// <summary>
        /// Método que se ejecuta luego de cada prueba
        /// </summary>
        [TearDown]
        public void Clean()
        {
            eventosAsistidos = null;
            idPersona = null;
        }
        #endregion

        #region Test

        /// <summary>
        /// Método para probar que la tupla obtenida no es nula en eventos asistidos
        /// </summary>
        [Test]
        public void PruebaObtenerTuplaEventosAsistidos()
        {
            Tuple<List<Entidad>, List<Entidad>, List<DateTime>, List<DateTime>> tupla = eventosAsistidos.Ejecutar();
            Assert.IsNotNull(tupla);
        }

        /// <summary>
        /// Método para probar la excepcion de número entero invalido en obtener lista eventos asistidos
        /// </summary>
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void ListaEventosNumeroEnteroException()
        {
            idPersona.Id = -1;
            Tuple<List<Entidad>, List<Entidad>, List<DateTime>, List<DateTime>> tupla = eventosAsistidos.Ejecutar();
        }

        /// <summary>
        /// Método para probar que la lista obtenida de eventos puede tener uno o mas eventos
        /// </summary>
        [Test]
        public void PruebaObtenerListaEventosAsistidos()
        {
            Tuple<List<Entidad>, List<Entidad>, List<DateTime>, List<DateTime>>  tupla = eventosAsistidos.Ejecutar();
            List<Entidad> listaEvento = tupla.Item1;
            Assert.GreaterOrEqual(listaEvento.Count, 1);
        }

        /// <summary>
        /// Método para probar que la lista obtenida de competencias puede tener uno o mas competencias
        /// </summary>
        [Test]
        public void PruebaObtenerListaCompetenciasAsistidas()
        {
            Tuple<List<Entidad>, List<Entidad>, List<DateTime>, List<DateTime>> tupla = eventosAsistidos.Ejecutar();
            List<Entidad> listaCompetencia = tupla.Item2;
            Assert.GreaterOrEqual(listaCompetencia.Count, 1);
        }

        /// <summary>
        /// Método para probar que la lista obtenida de fechas sobre eventos puede tener uno o mas fechas
        /// </summary>
        [Test]
        public void PruebaObtenerListaFechaEventosAsistidos()
        {
            Tuple<List<Entidad>, List<Entidad>, List<DateTime>, List<DateTime>> tupla = eventosAsistidos.Ejecutar();
            List<DateTime> listaFechaEvento = tupla.Item3;
            Assert.GreaterOrEqual(listaFechaEvento.Count, 1);
        }

        /// <summary>
        /// Método para probar que la lista obtenida de fechas sobre competencias puede tener uno o mas competencias
        /// </summary>
        [Test]
        public void PruebaObtenerListaFechaCompetenciasAsistidos()
        {
            Tuple<List<Entidad>, List<Entidad>, List<DateTime>, List<DateTime>> tupla = eventosAsistidos.Ejecutar();
            List<DateTime> listaFechaCompetencia = tupla.Item4;
            Assert.GreaterOrEqual(listaFechaCompetencia.Count, 1);
        }
        #endregion
    }
}
