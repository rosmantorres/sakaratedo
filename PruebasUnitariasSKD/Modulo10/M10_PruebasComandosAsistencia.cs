using DominioSKD.Entidades.Modulo10;
using DominioSKD.Entidades.Modulo12;
using LogicaNegociosSKD.Modulo10;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegociosSKD.Fabrica;
using LogicaNegociosSKD.Comandos;
using DatosSKD.InterfazDAO.Modulo10;
using DominioSKD;
using LogicaNegociosSKD.Comandos.Modulo10;
using LogicaNegociosSKD;



namespace PruebasUnitariasSKD.Modulo10
{
   public class M10_PruebasComandosAsistencia 
    {

       List<Entidad> listaEntidad;
       string idEvento;
       string idCompetencia;
     
  

        [SetUp]

        public void Init()
        {
            idEvento = "3";
            idCompetencia = "6";
        }

        [TearDown]

        public void Reset()
        {
            listaEntidad = null;
        }
        #region Pruebas

        [Test]
        public void pruebaListarHorarioCompetenciasVacio() // Vacio!
        {
            Comando<List<Entidad>> comandoHorarios= FabricaComandos.ObtenerComandoListarHorariosCompetencia();
            listaEntidad = comandoHorarios.Ejecutar();
            Assert.NotNull(listaEntidad);
        }


        [Test]
        public void pruebaListarHorarioCompetenciasContar() // Contar!
        {
            Comando<List<Entidad>> comandoHorarios = FabricaComandos.ObtenerComandoListarHorariosCompetencia();
            listaEntidad = comandoHorarios.Ejecutar();
            Assert.AreEqual(1, listaEntidad.ToArray().Length);
        }


        [Test]
        public void pruebaListarEventosAsistidosContar() // Contar!
        {
            Comando<List<Entidad>> comandoEventosAsistidos = FabricaComandos.ObtenerComandoListarEventosAsistidos();
            listaEntidad = comandoEventosAsistidos.Ejecutar();
            Assert.AreEqual(1, listaEntidad.ToArray().Length);
        }


        [Test]
        public void pruebaListarEventosAsistidosVacio() // Vacio!
        {
            Comando<List<Entidad>> comandoEventosAsistidos = FabricaComandos.ObtenerComandoListarEventosAsistidos();
            listaEntidad = comandoEventosAsistidos.Ejecutar();
            Assert.NotNull(listaEntidad);
        }

        [Test]
        public void pruebaListarCompetenciasAsistidasVacio() // Vacio!
        {
            Comando<List<Entidad>> comandoCompetenciasAsistidas = FabricaComandos.ObtenerComandoListarCompetenciasAsistidas();
            listaEntidad = comandoCompetenciasAsistidas.Ejecutar();
            Assert.NotNull(listaEntidad);
        }

        [Test]
        public void pruebaListarCompetenciasAsistidasContar() // Contar!
        {
            Comando<List<Entidad>> comandoCompetenciasAsistidas = FabricaComandos.ObtenerComandoListarCompetenciasAsistidas();
            listaEntidad = comandoCompetenciasAsistidas.Ejecutar();
            Assert.AreEqual(5, listaEntidad.ToArray().Length);
        }


        [Test]
        public void pruebaListarNoAsistenteEventoVacio() // Vacio!
        {
            Comando<List<Entidad>> comandoNoAsististenteEvento = FabricaComandos.ObtenerComandoListaNoAsistentesEvento(idEvento);
            listaEntidad = comandoNoAsististenteEvento.Ejecutar();
            Assert.NotNull(listaEntidad);
        }

        [Test]
        public void pruebaListarNoAsistenteEventoContar() // Contar!
        {
            Comando<List<Entidad>> comandoNoAsististenteEvento = FabricaComandos.ObtenerComandoListaNoAsistentesEvento(idEvento);
            listaEntidad = comandoNoAsististenteEvento.Ejecutar();
            Assert.AreEqual(4, listaEntidad.ToArray().Length);
        }

        [Test]
        public void pruebaListarNoAsistenteCompeContar() // Contar!
        {
            Comando<List<Entidad>> comandoNoAsististenteComp = FabricaComandos.ObtenerComandoListaNoAsistentesCompetencia(idCompetencia);
            listaEntidad = comandoNoAsististenteComp.Ejecutar();
            Assert.AreEqual(5, listaEntidad.ToArray().Length);
        }


        [Test]
        public void pruebaListarNoAsistenteCompeVacio() // Vacio!
        {
            Comando<List<Entidad>> comandoNoAsististenteComp = FabricaComandos.ObtenerComandoListaNoAsistentesCompetencia(idCompetencia);
            listaEntidad = comandoNoAsististenteComp.Ejecutar();
            Assert.NotNull(listaEntidad);
        }

        [Test]
        public void pruebaListarInasistentePlanillaComp() // Vacio!
        {
            Comando<List<Entidad>> comandoInasistentePComp = FabricaComandos.ObtenerComandoListaInasistentesPlanillaCompetencia(idCompetencia);
            listaEntidad = comandoInasistentePComp.Ejecutar();
            Assert.NotNull(listaEntidad);
        }

        [Test]
        public void pruebaListarInasistentePlanillaCompC() // Contar!
        {
            Comando<List<Entidad>> comandoInasistentePComp = FabricaComandos.ObtenerComandoListaInasistentesPlanillaCompetencia(idCompetencia);
            listaEntidad = comandoInasistentePComp.Ejecutar();
            Assert.AreEqual(5, listaEntidad.ToArray().Length);
        }
        #endregion
    }
}
