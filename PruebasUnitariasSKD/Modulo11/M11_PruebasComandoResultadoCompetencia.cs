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

            entidad = DominioSKD.Fabrica.FabricaEntidades.ObtenerCompetencia();
            ((DominioSKD.Entidades.Modulo12.Competencia)entidad).Id = 5;
            ((DominioSKD.Entidades.Modulo12.Competencia)entidad).TipoCompetencia = "1";

            Entidad categoria = DominioSKD.Fabrica.FabricaEntidades.ObtenerCategoria();
            ((DominioSKD.Entidades.Modulo12.Categoria)categoria).Id = 1;

            ((DominioSKD.Entidades.Modulo12.Competencia)entidad).Categoria = categoria as DominioSKD.Entidades.Modulo12.Categoria;

            Comando<List<Entidad>> lista = FabricaComandos.ObtenerComandoListaCategoriaCompetencia(entidad);
           
            Assert.NotNull(lista.Ejecutar());
        }

        [Test]
        public void pruebaListaAtletasParticipanComKumite()
        {

            Entidad competencia = DominioSKD.Fabrica.FabricaEntidades.ObtenerCompetencia();
            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).TipoCompetencia = "2";
            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Id = 6;
            Entidad categoria = DominioSKD.Fabrica.FabricaEntidades.ObtenerCategoria();
            ((DominioSKD.Entidades.Modulo12.Categoria)categoria).Id = 2;

            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Categoria = categoria as DominioSKD.Entidades.Modulo12.Categoria;

            Comando<List<Entidad>> lista = FabricaComandos.ObtenerComandoListaAtletasParticipanCompetenciaKumite(competencia);
            listaEntidad = lista.Ejecutar();
            Assert.NotNull(listaEntidad);
       
        }

        [Test]

        public void pruebaListarAtletasParticipanComKumiteAmbos()
        {



            Entidad competencia = DominioSKD.Fabrica.FabricaEntidades.ObtenerCompetencia();
            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).TipoCompetencia = "3";
            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Id = 12;
            Entidad categoria = DominioSKD.Fabrica.FabricaEntidades.ObtenerCategoria();
            ((DominioSKD.Entidades.Modulo12.Categoria)categoria).Id = 1;
            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Categoria = categoria as DominioSKD.Entidades.Modulo12.Categoria;

            Comando<List<Entidad>> lista = FabricaComandos.ObtenerComandoListaAtletasParticipanCompetenciaKumiteAmbos(competencia);
            Assert.NotNull(lista.Ejecutar());

        }

        [Test]

        public void pruebaListarAtletasParticipanComKata()
        {

            
            Entidad competencia = DominioSKD.Fabrica.FabricaEntidades.ObtenerCompetencia();
            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).TipoCompetencia = "1";
            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Id = 10;
            Entidad categoria = DominioSKD.Fabrica.FabricaEntidades.ObtenerCategoria();
            ((DominioSKD.Entidades.Modulo12.Categoria)categoria).Id = 1;
            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Categoria = categoria as DominioSKD.Entidades.Modulo12.Categoria;

            Comando<List<Entidad>> lista = FabricaComandos.ObtenerComandoListaAtletasParticipanCompetenciaKata(competencia);
            listaEntidad = lista.Ejecutar();
            Assert.NotNull(listaEntidad);

        }


        [Test]
        public void pruebaListarAtletasParticipanComKataAmbos()
        {


            Entidad competencia = DominioSKD.Fabrica.FabricaEntidades.ObtenerCompetencia();
            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).TipoCompetencia = "3";
            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Id = 12;
            Entidad categoria = DominioSKD.Fabrica.FabricaEntidades.ObtenerCategoria();
            ((DominioSKD.Entidades.Modulo12.Categoria)categoria).Id = 1;
            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Categoria = categoria as DominioSKD.Entidades.Modulo12.Categoria;

            Comando<List<Entidad>> lista = FabricaComandos.ObtenerComandoListaAtletasParticipanCompetenciaKataAmbos(competencia);
            listaEntidad = lista.Ejecutar();
            Assert.NotNull(listaEntidad);



        }

        [Test]

        public void pruebaListaAtletasCatYascenso()
        {

            entidad = DominioSKD.Fabrica.FabricaEntidades.ObtenerEventoM10();
            Entidad categoria = DominioSKD.Fabrica.FabricaEntidades.ObtenerCategoria();
            ((DominioSKD.Entidades.Modulo10.Evento)entidad).Id = 3;
            ((DominioSKD.Entidades.Modulo12.Categoria)categoria).Id = 1;
            ((DominioSKD.Entidades.Modulo10.Evento)entidad).Categoria = categoria as DominioSKD.Entidades.Modulo12.Categoria;
            Comando<List<Entidad>> lista = FabricaComandos.ObtenerComandoListaAtletasEnCategoriaYAscenso(entidad);
            listaEntidad = lista.Ejecutar();
            Assert.NotNull(listaEntidad);

        }

        [Test]

        public void pruebaAgregarResultadoKata()
        {
            listaEntidad = new List<Entidad>();
            entidad = DominioSKD.Fabrica.FabricaEntidades.ObtenerResultadoKata();
            ((DominioSKD.Entidades.Modulo11.ResultadoKata)entidad).Inscripcion.Id = 4;
            ((DominioSKD.Entidades.Modulo11.ResultadoKata)entidad).Jurado1 = 2;
            ((DominioSKD.Entidades.Modulo11.ResultadoKata)entidad).Jurado2 = 3;
            ((DominioSKD.Entidades.Modulo11.ResultadoKata)entidad).Jurado3 = 3;
            listaEntidad.Add(entidad);
            Comando<bool> comando = FabricaComandos.ObtenerComandoAgregarResultadoKata(listaEntidad);
            bool a = comando.Ejecutar();
            Assert.IsTrue(a);
         
        }


        [Test]

        public void pruebaAgregarResultadoKumite()
        {

            listaEntidad = new List<Entidad>();
            entidad = DominioSKD.Fabrica.FabricaEntidades.ObtenerResultadoKumite();
            ((DominioSKD.Entidades.Modulo11.ResultadoKumite)entidad).Inscripcion1.Id = 4;
            ((DominioSKD.Entidades.Modulo11.ResultadoKumite)entidad).Inscripcion2.Id = 1;
            ((DominioSKD.Entidades.Modulo11.ResultadoKumite)entidad).Puntaje1 = 2;
            ((DominioSKD.Entidades.Modulo11.ResultadoKumite)entidad).Puntaje2 = 2;
            listaEntidad.Add(entidad);
            Comando<bool> comando = FabricaComandos.ObtenerComandoAgregarResultadoKumite(listaEntidad);
            bool a = comando.Ejecutar();
            Assert.IsTrue(a);
         

        }


        [Test]

        public void pruebaAgregarResultadoAscenso()
        {

            listaEntidad = new List<Entidad>();
            entidad = DominioSKD.Fabrica.FabricaEntidades.ObtenerResultadoAscenso();
            ((DominioSKD.Entidades.Modulo11.ResultadoAscenso)entidad).Aprobado = "S";
            ((DominioSKD.Entidades.Modulo11.ResultadoAscenso)entidad).Inscripcion.Id = 2;
            listaEntidad.Add(entidad);

            Comando<bool> comando = FabricaComandos.ObtenerComandoAgregarResultadoAscenso(listaEntidad);
            bool a = comando.Ejecutar();
            Assert.IsTrue(a);

        }

        [Test]

        public void pruebaModificarResultadoKata()
        {
            listaEntidad = new List<Entidad>();
            entidad = DominioSKD.Fabrica.FabricaEntidades.ObtenerResultadoKata();
            ((DominioSKD.Entidades.Modulo11.ResultadoKata)entidad).Inscripcion.Id = 1;
            ((DominioSKD.Entidades.Modulo11.ResultadoKata)entidad).Inscripcion.Competencia.Id = 5;
            ((DominioSKD.Entidades.Modulo11.ResultadoKata)entidad).Jurado1 = 9;
            ((DominioSKD.Entidades.Modulo11.ResultadoKata)entidad).Jurado2 = 9;
            ((DominioSKD.Entidades.Modulo11.ResultadoKata)entidad).Jurado3 = 1;
            listaEntidad.Add(entidad);

            Comando<bool> comando = FabricaComandos.ObtenerComandoModificarResultadoKata(listaEntidad);
            bool a = comando.Ejecutar();
            Assert.IsTrue(a);
        }


        [Test]

        public void pruebaModificarResultadoKumite()
        {
            listaEntidad = new List<Entidad>();
            entidad = DominioSKD.Fabrica.FabricaEntidades.ObtenerResultadoKumite();
            ((DominioSKD.Entidades.Modulo11.ResultadoKumite)entidad).Inscripcion1.Id = 9;
            ((DominioSKD.Entidades.Modulo11.ResultadoKumite)entidad).Inscripcion2.Id = 11;
            ((DominioSKD.Entidades.Modulo11.ResultadoKumite)entidad).Puntaje1 = 3;
            ((DominioSKD.Entidades.Modulo11.ResultadoKumite)entidad).Puntaje2 = 3;
            ((DominioSKD.Entidades.Modulo11.ResultadoKumite)entidad).Inscripcion1.Competencia.Id = 6;
            listaEntidad.Add(entidad);

            Comando<bool> comando = FabricaComandos.ObtenerComandoModificarResultadoKumite(listaEntidad);
            bool a = comando.Ejecutar();
            Assert.IsTrue(a);
        }


        [Test]

        public void pruebaModificarResultadoAscenso()
        {
            listaEntidad = new List<Entidad>();
            entidad = DominioSKD.Fabrica.FabricaEntidades.ObtenerResultadoAscenso();
            ((DominioSKD.Entidades.Modulo11.ResultadoAscenso)entidad).Aprobado = "N";
            ((DominioSKD.Entidades.Modulo11.ResultadoAscenso)entidad).Inscripcion.Id = 32;
            ((DominioSKD.Entidades.Modulo11.ResultadoAscenso)entidad).Inscripcion.Evento.Id = 3;
            listaEntidad.Add(entidad);

            Comando<bool> comando = FabricaComandos.ObtenerComandoModificarResultadoAscenso(listaEntidad);
            bool a = comando.Ejecutar();
            Assert.IsTrue(a);

        }


        #endregion
    }
}

