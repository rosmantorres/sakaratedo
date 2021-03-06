﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DominioSKD;
using DatosSKD;
using DatosSKD.Modulo8;
using DatosSKD.Fabrica;
using DatosSKD.InterfazDAO.Modulo8;


namespace PruebasUnitariasSKD.Modulo8
{
    [TestFixture]
    public class PruebaBDRestriccionCompetencia
    {
        List<Competencia> laListaCompetencias;
        Competencia laCompetencia;
        List<RestriccionCompetencia> laListaRestriccionCompetencia;
        Entidad laRestriccionCompetencia;
        DatosSKD.Fabrica.FabricaDAOSqlServer fabricaDao;
        DatosSKD.DAO.Modulo8.DAORestriccionCompetencia Dao;
        IDaoRestriccionCompetencia daoRestriccionCompetencia;

        DatosSKD.Fabrica.FabricaDAOSqlServer fabricaDAO;

        FabricaDAOSqlServer fabrica;




        [SetUp]
        public void init()
        {
            daoRestriccionCompetencia=DatosSKD.Fabrica.FabricaDAOSqlServer.ObtenerDAORestriccionCompetencia();
            fabrica = new FabricaDAOSqlServer();
            fabricaDAO = new DatosSKD.Fabrica.FabricaDAOSqlServer();
            laListaCompetencias = new List<Competencia>();
            laCompetencia = new Competencia();
            laListaRestriccionCompetencia = new List<RestriccionCompetencia>();

            laRestriccionCompetencia = new DominioSKD.Entidades.Modulo8.RestriccionCompetencia( "prueba", -1, 66, -1,
                                      21, "p", "M_prueba");

        }

        [Test]
        public void PruebaCrearRestriccion()
        {
            Assert.IsTrue(daoRestriccionCompetencia.Agregar(laRestriccionCompetencia));
        }

        //[Test]
        //public void PruebaExisteRestriccionCompetenciaSimilar()
        //{
        //    Assert.IsTrue(DatosSKD.Modulo8.BDRestriccionCompetencia.ExisteRestriccionCompetenciaSimilar(laRestriccionCompetencia));
        //}

        //[Test]
        //public void pruebaVacioListaRestriccionCompetencias()
        //{
        //    ///laListaRestriccionCompetencia = BDRestriccionCompetencia.ListarRestriccionesCompetencia();
        //    ///Assert.IsNotNull(laListaRestriccionCompetencia);
        //    Assert.IsNotNull(DatosSKD.Modulo8.BDRestriccionCompetencia.ListarRestriccionesCompetencia());
        //}

        //[Test]
        //public void pruebaAtletasQueCumplenRestriccion()
        //{
        //    ///laListaRestriccionCompetencia = BDRestriccionCompetencia.ListarRestriccionesCompetencia();
        //    ///Assert.IsNotNull(laListaRestriccionCompetencia);
        //    Assert.IsNotNull(DatosSKD.Modulo8.BDRestriccionCompetencia.atletasQueCumplenRestriccion(laRestriccionCompetencia));
        //}



        //[Test]
        //public void pruebaEliminarRestriccionCompetencia()
        //{
        //    ///laListaRestriccionCompetencia = BDRestriccionCompetencia.ListarRestriccionesCompetencia();
        //    ///Assert.IsNotNull(laListaRestriccionCompetencia);
        //    Assert.IsTrue(DatosSKD.Modulo8.BDRestriccionCompetencia.EliminarRestriccionCompetencia(laRestriccionCompetencia));
        //}



        [TearDown]
        public void limpiar()
        {
            laListaCompetencias = null;
            laCompetencia = null;
            laListaRestriccionCompetencia = null;
            laRestriccionCompetencia = null;
        }
    }
}
