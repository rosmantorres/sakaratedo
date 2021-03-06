﻿using DatosSKD.Fabrica;
using DatosSKD.InterfazDAO.Modulo11;
using DominioSKD;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasUnitariasSKD.Modulo11
{
    /// <summary>
    /// Clase que se encarga de Realizar las pruebas unitarias de los metodos de la Clase DAO
    /// </summary>
    /// 

    [TestFixture]
    public class M11_PruebasDAOResultadoKumite
    {


        #region Atributos
        List<Entidad> listaEntidad;
        string idEvento;
        public string idCompetencia;
        public Entidad entidad;
        List<string> listaString;

        #endregion

        #region setUp
        [SetUp]
        public void init()
        {
            listaEntidad = new List<Entidad>();
            idEvento = "3";
            idCompetencia = "11";

        }


        #endregion

        #region Pruebas Unitarias

        [Test]


        public void ListaAtletasParticipanCompetenciaKumite()
        {

            IDaoResultadoKumite DAO = FabricaDAOSqlServer.ObtenerDAOResultadoKumite();

            Entidad competencia = DominioSKD.Fabrica.FabricaEntidades.ObtenerCompetencia(); 
            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).TipoCompetencia = "2";
            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Id = 6;
            Entidad categoria = DominioSKD.Fabrica.FabricaEntidades.ObtenerCategoria();
            ((DominioSKD.Entidades.Modulo12.Categoria)categoria).Id = 2;
            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Categoria = categoria as DominioSKD.Entidades.Modulo12.Categoria;

            listaEntidad = DAO.ListaAtletasParticipanCompetenciaKumite(competencia);
            Assert.NotNull(listaEntidad);

        }


        [Test]


        public void ListaAtletasParticipanCompetenciaKumiteAmbos() 
        {



            IDaoResultadoKumite DAO = FabricaDAOSqlServer.ObtenerDAOResultadoKumite();
     
            Entidad competencia = DominioSKD.Fabrica.FabricaEntidades.ObtenerCompetencia();
            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).TipoCompetencia = "3";
            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Id = 12;
            Entidad categoria = DominioSKD.Fabrica.FabricaEntidades.ObtenerCategoria();
            ((DominioSKD.Entidades.Modulo12.Categoria)categoria).Id = 1;

            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Categoria = categoria as DominioSKD.Entidades.Modulo12.Categoria;

            listaEntidad = DAO.ListaAtletasParticipanCompetenciaKumiteAmbos(competencia);
            Assert.NotNull(listaEntidad);

        }


        [Test]


        public void ListInscritosCompetencia()
        {


            IDaoResultadoKumite DAO = FabricaDAOSqlServer.ObtenerDAOResultadoKumite();
       
            Entidad competencia = DominioSKD.Fabrica.FabricaEntidades.ObtenerCompetencia();
            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).TipoCompetencia = "1";
            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Id = 6;
            Entidad categoria = DominioSKD.Fabrica.FabricaEntidades.ObtenerCategoria();
            ((DominioSKD.Entidades.Modulo12.Categoria)categoria).Id = 1;

            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Categoria = categoria as DominioSKD.Entidades.Modulo12.Categoria;

            listaEntidad = DAO.ListaInscritosCompetencia(competencia);
            Assert.NotNull(listaEntidad);

        }

        [Test]
        public void AgregarResultadoKumite()

    {
         
            IDaoResultadoKumite DAO = FabricaDAOSqlServer.ObtenerDAOResultadoKumite();
            
            bool e;
            listaEntidad = new List<Entidad>();
            entidad = DominioSKD.Fabrica.FabricaEntidades.ObtenerResultadoKumite();
            ((DominioSKD.Entidades.Modulo11.ResultadoKumite)entidad).Inscripcion1.Id = 4;
            ((DominioSKD.Entidades.Modulo11.ResultadoKumite)entidad).Inscripcion2.Id = 1;
            ((DominioSKD.Entidades.Modulo11.ResultadoKumite)entidad).Puntaje1 = 1;
            ((DominioSKD.Entidades.Modulo11.ResultadoKumite)entidad).Puntaje2 = 1; 
            listaEntidad.Add(entidad);
            e = DAO.Agregar(listaEntidad);
            Assert.IsTrue(e);

        }


        [Test]
        public void ModificarResultadoKumite()
        {
            

            IDaoResultadoKumite DAO = FabricaDAOSqlServer.ObtenerDAOResultadoKumite();

            bool e;
            listaEntidad = new List<Entidad>();
            entidad = DominioSKD.Fabrica.FabricaEntidades.ObtenerResultadoKumite();
            ((DominioSKD.Entidades.Modulo11.ResultadoKumite)entidad).Inscripcion1.Id = 9;
            ((DominioSKD.Entidades.Modulo11.ResultadoKumite)entidad).Inscripcion2.Id = 11;
            ((DominioSKD.Entidades.Modulo11.ResultadoKumite)entidad).Puntaje1 = 2;
            ((DominioSKD.Entidades.Modulo11.ResultadoKumite)entidad).Puntaje2 = 5;
            ((DominioSKD.Entidades.Modulo11.ResultadoKumite)entidad).Inscripcion1.Competencia.Id = 6;
            listaEntidad.Add(entidad);
            e = DAO.Modificar(listaEntidad);
            Assert.IsTrue(e);

        }
        #endregion
    }
}
