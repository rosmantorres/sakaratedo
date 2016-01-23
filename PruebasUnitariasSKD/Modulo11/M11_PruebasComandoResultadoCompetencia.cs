using DominioSKD;
using LogicaNegociosSKD;
using LogicaNegociosSKD.Fabrica;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasUnitariasSKD.Modulo11
{
    class M11_PruebasComandoResultadoCompetencia
    {
        
       List<Entidad> listaEntidad;
       string idEvento;
       string idCompetencia;
       private Entidad entidad;
       List<string> listaString;
     
  

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
            listaString = null;
        }
        #region Pruebas

        [Test]
        public void pruebaListarResultadosEventosPasados() // Vacio!
        {
            Comando<List<Entidad>> comandoResEvenPasados = FabricaComandos.ObtenerComandoListarResultadosEventosPasados();
            listaEntidad = comandoResEvenPasados.Ejecutar();
            Assert.NotNull(listaEntidad);
        }


        [Test]
        public void pruebaListarResultadosEventosPasadosC() // Contar!
        {
            Comando<List<Entidad>> comandoResEvenPasados = FabricaComandos.ObtenerComandoListarResultadosEventosPasados();
            listaEntidad = comandoResEvenPasados.Ejecutar();
            Assert.AreEqual(1, listaEntidad.ToArray().Length);
        }

        [Test]
        public void pruebaListarResultadosCompPasadosC() // Contar!
        {
            Comando<List<Entidad>> comandoResComPasados = FabricaComandos.ObtenerComandoListarResultadosCompetenciasPasado();
            listaEntidad = comandoResComPasados.Ejecutar();
            Assert.AreEqual(4, listaEntidad.ToArray().Length);
        }

        [Test]
        public void pruebaListarResultadosCompPasados() // Vacio!
        {
            Comando<List<Entidad>> comandoResComPasados = FabricaComandos.ObtenerComandoListarResultadosCompetenciasPasado();
            listaEntidad = comandoResComPasados.Ejecutar();
            Assert.NotNull(listaEntidad);
        }


        [Test]
        public void pruebaInscritosExamenAscenso() // Vacio!
        {

            entidad = DominioSKD.Fabrica.FabricaEntidades.ObtenerAsistencia();
            Comando<List<Entidad>> comandoInscritosExamenA = FabricaComandos.ObtenerComandoListaInscritosExamenAscenso(entidad);
     
        }

        [Test]
        public void pruebaInscritosCompetencia() // Vacio!
        {
            Comando<List<Entidad>> comandoInscritosComp = FabricaComandos.ObtenerComandoListaInscritosCompetencia(entidad);

        }

        [Test]
        public void pruebaEspecialidadesComp() // Vacio!
        {
            Comando<List<string>> comandoEspecialidadComp = FabricaComandos.ObtenerComandoListaEspecialidadesCompetencia(idCompetencia);
            listaString = comandoEspecialidadComp.Ejecutar();
            Assert.NotNull(listaString);
            
        }

        [Test]
        public void pruebaEspecialidadesCompC() // Contar!
        {
            Comando<List<string>> comandoEspecialidadComp = FabricaComandos.ObtenerComandoListaEspecialidadesCompetencia(idCompetencia);
            listaString = comandoEspecialidadComp.Ejecutar();
            Assert.AreEqual(2, listaString.ToArray().Length);

        }

        [Test]
        public void pruebaCategoriaEventosC() // Contar!
        {
            Comando<List<Entidad>> comandoCategoriaEvento = FabricaComandos.ObtenerComandoListaCategoriaEvento(idEvento);
            listaEntidad = comandoCategoriaEvento.Ejecutar();
            Assert.AreEqual(1, listaEntidad.ToArray().Length);

        }

        [Test]
        public void pruebaCategoriaEventosV() // Vacio!
        {
            Comando<List<Entidad>> comandoCategoriaEvento = FabricaComandos.ObtenerComandoListaCategoriaEvento(idEvento);
            listaEntidad = comandoCategoriaEvento.Ejecutar();
            Assert.NotNull(listaEntidad);

        }

        [Test]
        public void pruebaConsultarEventoDetalle() // Vacio!
        {
            Comando<Entidad> ComandoEventoDetalle = FabricaComandos.ObtenerComandoConsultarEventoDetalle(idEvento);
            entidad = ComandoEventoDetalle.Ejecutar();
            Assert.NotNull(entidad);

        }

        [Test]
        public void pruebaConsultarEventoDetalleC() // Contar!
        {
            Comando<Entidad> ComandoEventoDetalle = FabricaComandos.ObtenerComandoConsultarEventoDetalle(idEvento);
            entidad = ComandoEventoDetalle.Ejecutar();
            Assert.AreEqual(36, entidad.ToString().ToArray().Length);

        }

        [Test]
        public void pruebaCategoriaCompetencia()
        {

            DominioSKD.Fabrica.FabricaEntidades fabrica = new DominioSKD.Fabrica.FabricaEntidades();

            entidad = fabrica.ObtenerCompetencia();
            ((DominioSKD.Entidades.Modulo12.Competencia)entidad).Id = 5;
            ((DominioSKD.Entidades.Modulo12.Competencia)entidad).TipoCompetencia = "1";

            Entidad categoria = fabrica.ObtenerCategoria();
            ((DominioSKD.Entidades.Modulo12.Categoria)categoria).Id = 1;

            ((DominioSKD.Entidades.Modulo12.Competencia)entidad).Categoria = categoria as DominioSKD.Entidades.Modulo12.Categoria;

            Comando<List<Entidad>> lista = FabricaComandos.ObtenerComandoListaCategoriaCompetencia(entidad);
           
            Assert.NotNull(lista.Ejecutar());
        }

        [Test]
        public void pruebaListaAtletasParticipanComKumite()
        {

            DominioSKD.Fabrica.FabricaEntidades fabrica = new DominioSKD.Fabrica.FabricaEntidades();

            Entidad competencia = fabrica.ObtenerCompetencia();
            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).TipoCompetencia = "2";
            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Id = 6;
            Entidad categoria = fabrica.ObtenerCategoria();
            ((DominioSKD.Entidades.Modulo12.Categoria)categoria).Id = 2;

            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Categoria = categoria as DominioSKD.Entidades.Modulo12.Categoria;

            Comando<List<Entidad>> lista = FabricaComandos.ObtenerComandoListaAtletasParticipanCompetenciaKumite(competencia);
            listaEntidad = lista.Ejecutar();
            Assert.NotNull(listaEntidad);
       
        }

        [Test]

        public void pruebaListarAtletasParticipanComKumiteAmbos()
        {


            DominioSKD.Fabrica.FabricaEntidades fabrica = new DominioSKD.Fabrica.FabricaEntidades();
            Entidad competencia = fabrica.ObtenerCompetencia();
            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).TipoCompetencia = "3";
            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Id = 12;
            Entidad categoria = fabrica.ObtenerCategoria();
            ((DominioSKD.Entidades.Modulo12.Categoria)categoria).Id = 1;
            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Categoria = categoria as DominioSKD.Entidades.Modulo12.Categoria;

            Comando<List<Entidad>> lista = FabricaComandos.ObtenerComandoListaAtletasParticipanCompetenciaKumiteAmbos(competencia);
            Assert.NotNull(lista.Ejecutar());

        }

        [Test]

        public void pruebaListarAtletasParticipanComKata()
        {

            
            DominioSKD.Fabrica.FabricaEntidades fabrica = new DominioSKD.Fabrica.FabricaEntidades();
            Entidad competencia = fabrica.ObtenerCompetencia();
            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).TipoCompetencia = "1";
            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Id = 10;
            Entidad categoria = fabrica.ObtenerCategoria();
            ((DominioSKD.Entidades.Modulo12.Categoria)categoria).Id = 1;
            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Categoria = categoria as DominioSKD.Entidades.Modulo12.Categoria;

            Comando<List<Entidad>> lista = FabricaComandos.ObtenerComandoListaAtletasParticipanCompetenciaKata(competencia);
            listaEntidad = lista.Ejecutar();
            Assert.NotNull(listaEntidad);

        }


        [Test]
        public void pruebaListarAtletasParticipanComKataAmbos()
        {


            DominioSKD.Fabrica.FabricaEntidades fabrica = new DominioSKD.Fabrica.FabricaEntidades();
            Entidad competencia = fabrica.ObtenerCompetencia();
            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).TipoCompetencia = "3";
            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Id = 12;
            Entidad categoria = fabrica.ObtenerCategoria();
            ((DominioSKD.Entidades.Modulo12.Categoria)categoria).Id = 1;
            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Categoria = categoria as DominioSKD.Entidades.Modulo12.Categoria;

            Comando<List<Entidad>> lista = FabricaComandos.ObtenerComandoListaAtletasParticipanCompetenciaKataAmbos(competencia);
            listaEntidad = lista.Ejecutar();
            Assert.NotNull(listaEntidad);



        }

        [Test]

        public void pruebaListaAtletasCatYascenso()
        {



        }

        [Test]

        public void pruebaAgregarResultadoKata()
        {

         
        }

        #endregion
    }
}

