﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DominioSKD;
using DatosSKD;
using DatosSKD.Modulo10;

namespace PruebasUnitariasSKD.Modulo10
{
    /// <summary>
    /// Clase que se encarga de Realizar las pruebas unitarias de los metodos de la Clase BDAsistencia
    /// </summary>
    /// 

    [TestFixture]
    class M10_PruebasBDAsistencia
    {
        #region Atributos
        List<Evento> laLista;
        private Evento elEvento;
        private string idDeEvento;
        List<Competencia> laListaC;
        private Competencia laCompetencia;
        List<Persona> ListaP;
        Persona laPersona;


        #endregion


        #region SetUp&TearDown

        [SetUp]
        public void init()
        {
            laLista = new List<Evento>();
            Evento elEvento = new Evento();
            Persona laPersona = new Persona();
            Competencia laCompetencia = new Competencia();
            ListaP = new List<Persona>();
            laListaC = new List<Competencia>();
            idDeEvento = "1";
      
        }


        [TearDown]

        public void clean()
        {
            laLista = null;
            laListaC = null;
        }

        #endregion

        #region Pruebas Unitarias

        [Test]
        public void PruebaListarEventosA()
        {
            laLista = BDAsistencia.ListarEventosAsistidos();
            Assert.IsNotNull(laLista);
    
        }

        [Test]
        public void PruebaListarAsistente()
        {

            ListaP = BDAsistencia.listaAsistentes(idDeEvento);
            Assert.IsNotNull(ListaP);

        }

        [Test]
        public  void PruebaListarNoAsistente()
        {

            ListaP = BDAsistencia.listaNoAsistentes(idDeEvento);
            Assert.IsNotNull(ListaP);

        }


        [Test]
        public void PruebaListarCompetenciasA()
        {
            laListaC = BDAsistencia.ListarCompetenciasAsistidas();
            Assert.IsNotNull(laListaC);

        }


        #endregion
    }
}
