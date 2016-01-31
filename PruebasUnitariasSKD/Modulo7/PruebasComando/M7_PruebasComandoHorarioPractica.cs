using System;
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
    /// Clase que contiene las pruebas unitarias para el comando listar el horario de practica del atleta
    /// </summary>
    
    [TestFixture]
    public class M7_PruebasComandoHorarioPractica
    {
        #region Atributos
        private PersonaM7 idPersona;
        private ComandoConsultarListaHorarioPractica horarioPractica;
        #endregion

        #region SetUp & TearDown
        /// <summary>
        /// Método que se ejecuta antes de cada prueba
        /// </summary>
        [SetUp]
        public void Init()
        {
            horarioPractica = (ComandoConsultarListaHorarioPractica)FabricaComandos.ObtenerComandoConsultarListaHorarioPractica();
            idPersona = (PersonaM7)FabricaEntidades.ObtenerPersonaM7();
            idPersona.Id = 6;
            horarioPractica.LaEntidad = idPersona;
        }

        /// <summary>
        /// Método que se ejecuta luego de cada prueba
        /// </summary>
        [TearDown]
        public void Clean()
        {
            horarioPractica = null;
            idPersona = null;
        }
        #endregion

        #region Test

        /// <summary>
        /// Método para probar que la tupla obtenida no es nula en eventos horario practica
        /// </summary>
        [Test]
        public void PruebaObtenerTuplaHorarioPractica()
        {
            Tuple<List<Entidad>> tupla = horarioPractica.Ejecutar();
            Assert.IsNotNull(tupla);
        }

        /// <summary>
        /// Método para probar la excepcion de número entero invalido en obtener lista eventos horario practica
        /// </summary>
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void ListaEventosNumeroEnteroException()
        {
            idPersona.Id = -1;
            Tuple<List<Entidad>> tupla = horarioPractica.Ejecutar();
        }

        /// <summary>
        /// Método para probar que la lista obtenida de eventos puede tener uno o mas eventos
        /// </summary>
        [Test]
        public void PruebaObtenerListaHorarioPractica()
        {
            Tuple<List<Entidad>> tupla = horarioPractica.Ejecutar();
            List<Entidad> listaEvento = tupla.Item1;
            Assert.GreaterOrEqual(listaEvento.Count, 1);
        }
        #endregion
    }
}
