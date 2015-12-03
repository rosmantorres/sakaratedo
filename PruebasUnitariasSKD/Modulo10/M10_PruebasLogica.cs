using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using LogicaNegociosSKD;
using LogicaNegociosSKD.Modulo10;
using DominioSKD;
using DatosSKD.Modulo10;



namespace PruebasUnitariasSKD.Modulo10
{
    [TestFixture]
    class M10_PruebasLogica
    {
        List<Evento> laLista;
        Evento elEvento;
        private string idPersona;
        List<Competencia> laListaC;
        Competencia laCompetencia;
        private LogicaAsistencia logica;
        Persona laPersona;

        [SetUp]

        public void Init()
        {
            laLista = new List<Evento>();
            elEvento = new Evento();
            laListaC = new List<Competencia>();
            laCompetencia = new Competencia();
            logica = new LogicaAsistencia();
            laPersona = new Persona();
            idPersona = "1";
        }

        [TearDown]

        public void Reset()
        {
            logica = null;
            laListaC = null;

        }


#region Pruebas
        [Test]
        public void pruebaListarEvento()
        {
            LogicaAsistencia.ListarEventosAsistidos();
            Assert.IsNotNull(logica);
        }


        [Test]
        public void pruebaListarCompetencias()
        {
            LogicaAsistencia.listaAsistentes(idPersona);
            Assert.IsNotNull(logica);
        }

#endregion
    }
}
