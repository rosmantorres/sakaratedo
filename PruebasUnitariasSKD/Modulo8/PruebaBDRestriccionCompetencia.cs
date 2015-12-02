using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DominioSKD;
using DatosSKD;
using DatosSKD.Modulo12;


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

       }

    }
}
