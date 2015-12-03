using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DominioSKD;
using DatosSKD;
using DatosSKD.Modulo8;


namespace PruebasUnitariasSKD.Modulo8
{
   [TestFixture]
    public class PruebaBDRestriccionCompetencia
    {
       List<Competencia> laListaCompetencias;
       Competencia laCompetencia;
       List<RestriccionCompetencia> laListaRestriccionCompetencia;
       RestriccionCompetencia laRestriccionCompetencia;

       [SetUp]
       public void init()
       {
           laListaCompetencias = new List<Competencia>();
           laCompetencia = new Competencia();
           laListaRestriccionCompetencia = new List<RestriccionCompetencia>();
           laRestriccionCompetencia = new RestriccionCompetencia("Restriccion Prueba",10,40,1,20,"B","Ambos") ;
        
       }

       [Test]
       public void PruebaCrearRestriccion()
       {
               Assert.IsTrue(DatosSKD.Modulo8.BDRestriccionCompetencia.AgregarRestriccionCompetencia(laRestriccionCompetencia));
       }

       [Test]
       public void PruebaExisteRestriccionCompetenciaSimilar()
       {
           Assert.IsTrue(DatosSKD.Modulo8.BDRestriccionCompetencia.ExisteRestriccionCompetenciaSimilar(laRestriccionCompetencia));
       }

       [Test]
       public void pruebaVacioListaRestriccionCompetencias()
       {
           ///laListaRestriccionCompetencia = BDRestriccionCompetencia.ListarRestriccionesCompetencia();
           ///Assert.IsNotNull(laListaRestriccionCompetencia);
           Assert.IsNotNull(DatosSKD.Modulo8.BDRestriccionCompetencia.ListarRestriccionesCompetencia());
       }

       [Test]
       public void pruebaAtletasQueCumplenRestriccion()
       {
           ///laListaRestriccionCompetencia = BDRestriccionCompetencia.ListarRestriccionesCompetencia();
           ///Assert.IsNotNull(laListaRestriccionCompetencia);
           Assert.IsNotNull(DatosSKD.Modulo8.BDRestriccionCompetencia.atletasQueCumplenRestriccion(laRestriccionCompetencia));
       }



       [Test]
       public void pruebaEliminarRestriccionCompetencia()
       {
           ///laListaRestriccionCompetencia = BDRestriccionCompetencia.ListarRestriccionesCompetencia();
           ///Assert.IsNotNull(laListaRestriccionCompetencia);
           Assert.IsTrue(DatosSKD.Modulo8.BDRestriccionCompetencia.EliminarRestriccionCompetencia(laRestriccionCompetencia));
       }

       

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
