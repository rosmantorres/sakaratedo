using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace PruebasUnitariasSKD.Modulo8
{
     [TestFixture]
    class PruebaDAORestriccionCompetencia
    {
       DominioSKD.Entidades.Modulo8.RestriccionCompetencia laRestriccion;
       DominioSKD.Fabrica.FabricaEntidades fabricaEntidad;
       DatosSKD.Fabrica.FabricaDAOSqlServer fabricaDAO;
       DatosSKD.InterfazDAO.Modulo8.IDaoRestriccionCompetencia DAORestriccionCompetencia;
       //laRestriccion = fabrica.ObtenerRestriccionCompetencia();
       //List<Competencia> laListaCompetencias;
       //Competencia laCompetencia;
       //List<RestriccionCompetencia> laListaRestriccionCompetencia;
       //RestriccionCompetencia laRestriccionCompetencia, laRestriccionCompetencia2;
       //DatosSKD.Modulo8.BDRestriccionCompetencia BDRestComp;
       //Persona atleta;

       [SetUp]
       public void init()
       {   fabricaDAO = new DatosSKD.Fabrica.FabricaDAOSqlServer();
           fabricaEntidad = new DominioSKD.Fabrica.FabricaEntidades();
           DAORestriccionCompetencia = fabricaDAO.ObtenerDAORestriccionCompetencia();
           laRestriccion = (DominioSKD.Entidades.Modulo8.RestriccionCompetencia)fabricaEntidad.ObtenerRestriccionCompetencia();
           
           laRestriccion.Descripcion = "Restriccion Prueba";
           laRestriccion.EdadMaxima = 75;
           laRestriccion.EdadMinima=75;
           laRestriccion.Modalidad= "Modalidad";
           laRestriccion.RangoMaximo=21;
           laRestriccion.RangoMinimo=-1;
           laRestriccion.Sexo="P";
           
           //laListaCompetencias = new List<Competencia>();
           //laCompetencia = new Competencia(47);
           //laListaRestriccionCompetencia = new List<RestriccionCompetencia>();
           //laRestriccionCompetencia = new RestriccionCompetencia("Restriccion Prueba",10,40,1,20,"B","Ambos") ;
           //laRestriccionCompetencia2 = new RestriccionCompetencia("Restriccion Prueba", 20, 40, 10, 20, "M", "Kumite");
           //BDRestComp = new BDRestriccionCompetencia();
           //atleta = new Persona(1);
       }

       [Test]
       public void PruebaAgregar()
       {
           try
           {
               Assert.IsTrue(DAORestriccionCompetencia.Agregar(laRestriccion));


           }
           catch (Exception e)
           {
               
               throw e;
           }
       }

       [Test]
       public void pruebaEliminarRestriccionCompetencia()
       {


           try
           {

               Assert.IsTrue(DAORestriccionCompetencia.Eliminar(laRestriccion));
           }
           catch (Exception e)
           {

               throw e;
           }
       }



    //   [Test]
    //   public void PruebaExisteRestriccionCompetenciaSimilar()
    //   {
    //       try
    //       {
    //           DatosSKD.Modulo8.BDRestriccionCompetencia.AgregarRestriccionCompetencia(laRestriccionCompetencia);
    //           Assert.IsTrue(DatosSKD.Modulo8.BDRestriccionCompetencia.ExisteRestriccionCompetenciaSimilar(laRestriccionCompetencia));
    //       }
    //       catch (Exception e)
    //       {
               
    //           throw e;
    //       }
    //   }

    //   [Test]
    //   public void pruebaVacioListaRestriccionCompetencias()
    //   {

    //       try
    //       {
    //           Assert.IsNotNull(DatosSKD.Modulo8.BDRestriccionCompetencia.ListarRestriccionesCompetencia());
    //       }
    //       catch (Exception e)
    //       {
               
    //           throw e;
    //       }
    //   }

    //   [Test]
    //   public void pruebaAtletasQueCumplenRestriccion()
    //   {

    //       try
    //       {
    //           Assert.IsNotNull(DatosSKD.Modulo8.BDRestriccionCompetencia.atletasQueCumplenRestriccion(laRestriccionCompetencia));
    //       }
    //       catch (Exception e)
    //       {
               
    //           throw e;
    //       }
    //   }






    //   [Test]
    //   public void pruebaTraerIdRestriccionCompetencia()
    //   {

    //       try
    //       {
    //           DatosSKD.Modulo8.BDRestriccionCompetencia.AgregarRestriccionCompetencia(laRestriccionCompetencia);
    //           int Id = DatosSKD.Modulo8.BDRestriccionCompetencia.traerIdRestriccionCompetencia(laRestriccionCompetencia);
    //           Assert.IsTrue(DatosSKD.Modulo8.BDRestriccionCompetencia.ExisteRestriccionCompetenciaSimilar(laRestriccionCompetencia));
    //           Assert.AreEqual(DatosSKD.Modulo8.BDRestriccionCompetencia.traerIdRestriccionCompetencia(laRestriccionCompetencia), Id);
    //       }
    //       catch (Exception e)
    //       {
               
    //           throw e;
    //       }
    //   }




    //   [Test]
    //   public void pruebaModificarCompetencia()
    //   {

    //       try
    //       {
    //           int Id = DatosSKD.Modulo8.BDRestriccionCompetencia.traerIdRestriccionCompetencia(laRestriccionCompetencia);
    //           RestriccionCompetencia modificada = new RestriccionCompetencia(Id, "prueba modificar", 20, 40, 10, 20, "M", "Kumite");
    //           Assert.IsTrue(DatosSKD.Modulo8.BDRestriccionCompetencia.ModificarRestriccionCompetencia(modificada));
    //       }
    //       catch (Exception e)
    //       {
               
    //           throw e;
    //       }
    //   }

       
    //   [Test]
    //       public void pruebaCompetenciasQuePuedeIrUnAtleta()
    //   {
    //       try
    //       {
               
    //           Assert.IsNotNull(DatosSKD.Modulo8.BDRestriccionCompetencia.competenciasQuePuedeIrUnAtleta(atleta));
    //       }
    //       catch (Exception e)
    //       {
               
    //           throw e;
    //       }
    //   }



    //    [Test]
    //       public void pruebaListarCompetenciasAsociadasALaRestriccion()
    //   {

    //       try
    //       {
    //           Assert.IsNotNull(DatosSKD.Modulo8.BDRestriccionCompetencia.ListarCompetenciasAsociadasALaRestriccion(laRestriccionCompetencia));
    //       }
    //       catch (Exception e)
    //       {
               
    //           throw e;
    //       }
    //   }

       
    //       [Test]
    //       public void pruebaListarCompetenciasNoAsociadasALaRestriccion()
    //   {

    //       try
    //       {
    //           Assert.IsNotNull(DatosSKD.Modulo8.BDRestriccionCompetencia.ListarCompetenciasNoAsociadasALaRestriccion(laRestriccionCompetencia));
    //       }
    //       catch (Exception e)
    //       {
               
    //           throw e;
    //       }
    //   }


    //    [Test]
    //       public void pruebaCrearCompetenciaRestriccionCompetencia()
    //   {
    //       try
    //       {
    //           laCompetencia = new Competencia(46);
    //           laRestriccionCompetencia = new RestriccionCompetencia(6);
    //           Assert.IsTrue(DatosSKD.Modulo8.BDRestriccionCompetencia.AgregarCompetenciaRestriccionCompetencia(laRestriccionCompetencia, laCompetencia));
    //       }
    //       catch (Exception e)
    //       {
               
    //           throw e;
    //       }
               
    //   }

       

    //       [Test]
    //       public void pruebaEliminarCompetenciaRestriccionCompetencia()
    //   {
    //       try
    //       {
    //           laCompetencia = new Competencia(46);
    //           laRestriccionCompetencia = new RestriccionCompetencia(6);
    //           Assert.IsTrue(DatosSKD.Modulo8.BDRestriccionCompetencia.EliminarCompetenciaRestriccionCompetencia(laRestriccionCompetencia, laCompetencia));

    //       }
    //       catch (Exception e)
    //       {
               
    //           throw e;
    //       }
    //   }
       

       [TearDown]
       public void limpiar()
       {
           fabricaDAO = null;
           fabricaEntidad = null;
           DAORestriccionCompetencia = null;
           laRestriccion = null;

       }
    }

}


//}