﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DatosSKD.Fabrica;
using DatosSKD.DAO.Modulo7;
using DominioSKD.Fabrica;
using DominioSKD;
using ExcepcionesSKD.Modulo7;
namespace PruebasUnitariasSKD.Modulo7.PruebasDAO
{
    /// <summary>
    /// Clase que contiene las pruebas unitarias para DaoCinta
    /// </summary>
    [TestFixture]
    public class M7_PruebasDAOMatricula
    {
        #region Atributos
        private Persona idPersona;
        private FabricaEntidades fabricaEntidades;
        private FabricaDAOSqlServer fabricaSql;
        #endregion

        #region SetUp & TearDown
        [SetUp]
        public void Init()
        {
            fabricaSql = new FabricaDAOSqlServer();
            fabricaEntidades = new FabricaEntidades();
            idPersona = new Persona();
            idPersona.ID = 6;
        }

        [TearDown]
        public void Clean()
        {
            idPersona = null;
            fabricaEntidades = null;
            fabricaSql = null;
        }
        #endregion

        #region Test
        /// <summary>
        /// Método de prueba para ConSultarXId en DAO
        /// </summary>
        [Test]
        public void PruebaDetallarMatriculaXId()
        {
            
            DaoMatricula baseDeDatosMatricula = new DaoMatricula();//esto se sustituye con la fabrica
            Matricula idMatricula = (Matricula)fabricaEntidades.ObtenerMatricula();
            idMatricula.Id =25;
            Matricula matricula = (Matricula)baseDeDatosMatricula.ConsultarXId(idMatricula);
            Assert.AreEqual("CCA1-CAF-CAFE", matricula.Identificador);
        }


        /// <summary>
        /// Método para probar que una matriculada detallado no sea nulo
        /// </summary>
        [Test]
        public void PruebaDetallarMatriculaXIdNoNulo()
        {
            DaoMatricula baseDeDatosMatricula = new DaoMatricula();//esto se sustituye con la fabrica
            Matricula idMatricula = (Matricula)fabricaEntidades.ObtenerMatricula();
            idMatricula.Id = 1;
             Matricula matricula = (Matricula)baseDeDatosMatricula.ConsultarXId(idMatricula);
            Assert.NotNull(matricula);
        }

        /// <summary>
        /// Método para probar la exception de número entero invalido de detallar matricula pagada
        /// </summary>
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void DetallarMatriculaPagaNumeroEnteroException()
        {
            DaoMatricula baseDeDatosMatricula = new DaoMatricula();//esto se sustituye con la fabrica
            Matricula idMatricula = (Matricula)fabricaEntidades.ObtenerMatricula();
            idMatricula.Id = -1;
            Matricula matricula = (Matricula)baseDeDatosMatricula.ConsultarXId(idMatricula);
        }
       
        
        /// Método de prueba para ListarMatriculasObtenidas en DAO
        /// </summary>
        [Test]
        public void PruebaListarMatriculasObtenidasDAO()
        {
           
            DaoMatricula baseDeDatosMatricula = new DaoMatricula();//esto se sustituye con la fabrica
            List<Entidad> listaMatricula = baseDeDatosMatricula.ListarMatriculasPagas(idPersona);
            Assert.GreaterOrEqual(listaMatricula.Count, 0);
        }

        /// <summary>
        /// Método para probar que la lista obtenida de matriculas sea distinto de  nulo nulo
        /// </summary>
        [Test]
        public void PruebaListarMatriculasPagasNulas()
        {
            DaoMatricula baseDeDatosMatricula = new DaoMatricula();//esto se sustituye con la fabrica
            List<Entidad> listaMatricula = baseDeDatosMatricula.ListarMatriculasPagas(idPersona);
            Assert.NotNull(listaMatricula);
        }


        /// <summary>
        /// Método para probar la exception de número entero invalido de listar matriculas pagas
        /// </summary>
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void ListarMatriculasPagasEnteroException()
        {
            DaoMatricula baseDeDatosMatricula = new DaoMatricula();//esto se sustituye con la fabrica
            idPersona.ID = -1;
            List<Entidad> listaMatricula = baseDeDatosMatricula.ListarMatriculasPagas(idPersona);
        }
        #endregion
    }
}