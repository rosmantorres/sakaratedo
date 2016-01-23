using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSKD.InterfazDAO.Modulo10;
using DominioSKD;
using DatosSKD.DAO.Modulo10;
using DatosSKD.Fabrica;


namespace PruebasUnitariasSKD.Modulo10
{
    /// <summary>
    /// Clase que se encarga de Realizar las pruebas unitarias de los metodos de la Clase DAO
    /// </summary>
    /// 

    [TestFixture]

    public class M10_PruebasDAO
    {
        #region Atributos

        List<Entidad> listaEntidad;
        public string idEvento;
        public string idCompetencia;
        public Entidad entidad;
     
       
    

        #endregion



        [SetUp]
        public void init()
        {
            listaEntidad = new List<Entidad>();
            idEvento = "3";
            idCompetencia = "11";


        }


        [TearDown]

        public void clean()
        {
            listaEntidad = null;
            entidad = null;
        }

        #region Pruebas Unitarias

        [Test]

        public void PruebaListarEventosA()
        {

            IDaoAsistencia DAO = FabricaDAOSqlServer.ObtenerDAOAsistencia();
            listaEntidad =  DAO.ListarEventosAsistidos();
            Assert.NotNull(listaEntidad);
            
        }

       [Test]

        public void PruebaListarEventosAcount()
        {

            IDaoAsistencia DAO = FabricaDAOSqlServer.ObtenerDAOAsistencia();
            listaEntidad =  DAO.ListarEventosAsistidos();
            Assert.AreEqual(1, listaEntidad.ToArray().Length);

      
        }

       [Test]

       public void PruebaListarCompetenciasAsistidas()
       {

           IDaoAsistencia DAO = FabricaDAOSqlServer.ObtenerDAOAsistencia();
           listaEntidad = DAO.ListarCompetenciasAsistidas();
           Assert.AreEqual(5, listaEntidad.ToArray().Length);


       }

       [Test]

       public void PruebaListarCompetenciasAsistidasVacio()
       {

           IDaoAsistencia DAO = FabricaDAOSqlServer.ObtenerDAOAsistencia();
           listaEntidad = DAO.ListarCompetenciasAsistidas();
           Assert.NotNull(listaEntidad);


       }

       [Test]

       public void PruebaListarAsistenteAevento()
       {

           IDaoAsistencia DAO = FabricaDAOSqlServer.ObtenerDAOAsistencia();
           listaEntidad = DAO.ListaAsistentesEvento(idEvento);
           Assert.NotNull(listaEntidad);


       }

       [Test]

       public void PruebaListarAsistenteAeventoContar()
       {

           IDaoAsistencia DAO = FabricaDAOSqlServer.ObtenerDAOAsistencia();
           listaEntidad = DAO.ListaAsistentesEvento(idEvento);
           Assert.AreEqual(14, listaEntidad.ToArray().Length);


       }

       [Test]

       public void PruebaListarNoAsistenteAeventoContar()
       {

           IDaoAsistencia DAO = FabricaDAOSqlServer.ObtenerDAOAsistencia();
           listaEntidad = DAO.ListaNoAsistentesEvento(idEvento);
           Assert.AreEqual(2, listaEntidad.ToArray().Length);


       }

       [Test]

       public void PruebaListarNoAsistenteAeventoVacio()
       {

           IDaoAsistencia DAO = FabricaDAOSqlServer.ObtenerDAOAsistencia();
           listaEntidad = DAO.ListaNoAsistentesEvento(idEvento);
           Assert.NotNull(listaEntidad);


       }

       [Test]

       public void PruebaListarAsistenteAcompetenciaVacio()
       {

           IDaoAsistencia DAO = FabricaDAOSqlServer.ObtenerDAOAsistencia();
           listaEntidad = DAO.ListaAsistentesCompetencia(idCompetencia);
           Assert.NotNull(listaEntidad);


       }


       [Test]

       public void PruebaListarAsistenteAcompetenciaContar()
       {

           IDaoAsistencia DAO = FabricaDAOSqlServer.ObtenerDAOAsistencia();
           listaEntidad = DAO.ListaAsistentesCompetencia(idCompetencia);
           Assert.AreEqual(11, listaEntidad.ToArray().Length);


       }

       [Test]

       public void PruebaListarNoAsistenteAcompetenciaVacio()
       {

           IDaoAsistencia DAO = FabricaDAOSqlServer.ObtenerDAOAsistencia();
           listaEntidad = DAO.ListaNoAsistentesCompetencia(idCompetencia);
           Assert.NotNull(listaEntidad);


       }


       [Test]

       public void PruebaListarNoAsistenteAcompetenciaContar()
       {

           IDaoAsistencia DAO = FabricaDAOSqlServer.ObtenerDAOAsistencia();
           listaEntidad = DAO.ListaNoAsistentesCompetencia(idCompetencia);
           Assert.AreEqual(1, listaEntidad.ToArray().Length);


       }


       [Test]
       public void PruebaModificarAsitenteE()
       {

           IDaoAsistencia DAO = FabricaDAOSqlServer.ObtenerDAOAsistencia();
           bool a;
           entidad = DominioSKD.Fabrica.FabricaEntidades.ObtenerAsistencia();
           ((DominioSKD.Entidades.Modulo10.Asistencia)entidad).Asistio = "N";
           ((DominioSKD.Entidades.Modulo10.Asistencia)entidad).Evento.Id = 3;
           ((DominioSKD.Entidades.Modulo10.Asistencia)entidad).Inscripcion.Id = 33;
           listaEntidad.Add(entidad);
           a = DAO.ModificarAsistenciaEvento(listaEntidad);
           Assert.IsTrue(a);

       }


       [Test]
       public void PruebaConsultarCompetenciaXID()
       {
           IDaoAsistencia DAO = FabricaDAOSqlServer.ObtenerDAOAsistencia();
           entidad = DAO.ConsultarCompetenciasXId(idCompetencia);

       }

       [Test]
       public void PruebaModificarAsitenteCompetencia()
       {
           IDaoAsistencia DAO = FabricaDAOSqlServer.ObtenerDAOAsistencia();
           bool a;
           entidad = DominioSKD.Fabrica.FabricaEntidades.ObtenerAsistencia();
           ((DominioSKD.Entidades.Modulo10.Asistencia)entidad).Asistio = "N";
           ((DominioSKD.Entidades.Modulo10.Asistencia)entidad).Competencia.Id = 6;
           ((DominioSKD.Entidades.Modulo10.Asistencia)entidad).Inscripcion.Id = 9;
           listaEntidad.Add(entidad);
           a = DAO.ModificarAsistenciaCompetencia(listaEntidad);
           Assert.IsTrue(a);

       }

       [Test]
       public void PruebaListaAtletaIncritosEventoVacio()
       {
           IDaoAsistencia DAO = FabricaDAOSqlServer.ObtenerDAOAsistencia();
           listaEntidad = DAO.ListaAtletasInscritosEvento(idEvento);
           Assert.IsNotNull(listaEntidad);

       }


       [Test]
       public void PruebaListaAtletaIncritosEventoContar()
       {
           IDaoAsistencia DAO = FabricaDAOSqlServer.ObtenerDAOAsistencia();
           listaEntidad = DAO.ListaAtletasInscritosEvento(idEvento);
           Assert.AreEqual(15, listaEntidad.ToArray().Length);

       }

       [Test]
       public void PruebaListaInasistentesporPlanillaVacio()
       {
           IDaoAsistencia DAO = FabricaDAOSqlServer.ObtenerDAOAsistencia();
           listaEntidad = DAO.ListaInasistentesPlanilla(idEvento);
           Assert.IsNotNull(listaEntidad);
       }



       [Test]
       public void PruebaListaInasistentesporPlanillaContar()
       {
           IDaoAsistencia DAO = FabricaDAOSqlServer.ObtenerDAOAsistencia();
           listaEntidad = DAO.ListaInasistentesPlanilla(idEvento);
           Assert.AreEqual(1, listaEntidad.ToArray().Length);
       }


       [Test]
       public void PruebaAgregarAsistenciaEvento()
       {

           
           IDaoAsistencia DAO = FabricaDAOSqlServer.ObtenerDAOAsistencia();
           bool a;
           listaEntidad = new List<Entidad>();
           entidad = DominioSKD.Fabrica.FabricaEntidades.ObtenerAsistencia();
           ((DominioSKD.Entidades.Modulo10.Asistencia)entidad).Asistio = "N";
           ((DominioSKD.Entidades.Modulo10.Asistencia)entidad).Evento.Id = 3;
           ((DominioSKD.Entidades.Modulo10.Asistencia)entidad).Inscripcion.Id = 50;
           listaEntidad.Add(entidad);
           a = DAO.AgregarAsistenciaEvento(listaEntidad);
           Assert.IsTrue(a);
       }

         [Test]
        public void PruebaAgregarAsistenciaCompetencia()
        {


           IDaoAsistencia DAO = FabricaDAOSqlServer.ObtenerDAOAsistencia();
           bool a;
           listaEntidad = new List<Entidad>();
           entidad = DominioSKD.Fabrica.FabricaEntidades.ObtenerAsistencia();
           ((DominioSKD.Entidades.Modulo10.Asistencia)entidad).Asistio = "N";
           ((DominioSKD.Entidades.Modulo10.Asistencia)entidad).Competencia.Id = 6;
           ((DominioSKD.Entidades.Modulo10.Asistencia)entidad).Inscripcion.Id = 9;
           listaEntidad.Add(entidad);
           a = DAO.AgregarAsistenciaCompetencia(listaEntidad);
           Assert.IsTrue(a);


        }

         [Test]
         public void PruebaListarHorarioCompetencia()
         {
             IDaoAsistencia DAO = FabricaDAOSqlServer.ObtenerDAOAsistencia();
             listaEntidad = DAO.ListarHorariosCompetencia();
             Assert.AreEqual(1, listaEntidad.ToArray().Length);

         }

         [Test]
         public void PruebaListarHorarioCompetenciaVacio()
         {
             IDaoAsistencia DAO = FabricaDAOSqlServer.ObtenerDAOAsistencia();
             listaEntidad = DAO.ListarHorariosCompetencia();
             Assert.NotNull(listaEntidad);

         }

         [Test]
         public void PruebaCompetenciaPorFecha()
         {
             IDaoAsistencia DAO = FabricaDAOSqlServer.ObtenerDAOAsistencia();
             listaEntidad = DAO.CompetenciasPorFecha("15/10/2015");
             Assert.AreEqual(listaEntidad, DAO.CompetenciasPorFecha("15/10/2015"));

         }


         [Test]
         public void PruebaListarAtletasInscritosCompetenciaVacio()
         {
             IDaoAsistencia DAO = FabricaDAOSqlServer.ObtenerDAOAsistencia();

             listaEntidad = DAO.ListaAtletasInscritosCompetencia(idCompetencia);
             Assert.IsNotNull(listaEntidad);
         }


         [Test]
         public void PruebaListarAtletasInscritosCompetenciaContar()
         {
             IDaoAsistencia DAO = FabricaDAOSqlServer.ObtenerDAOAsistencia();

             listaEntidad = DAO.ListaAtletasInscritosCompetencia(idCompetencia);
             Assert.AreEqual(12, listaEntidad.ToArray().Length);
         }


         [Test]
         public void PruebaInasistentesPlanillaCompetencia()
         {
             IDaoAsistencia DAO = FabricaDAOSqlServer.ObtenerDAOAsistencia();
             listaEntidad = DAO.ListaInasistentesPlanillaCompetencia(idCompetencia);
             Assert.IsNotNull(listaEntidad);
         }


         [Test]
         public void ConsultarCompetenciaXIdDetalle()
         {
             DominioSKD.Fabrica.FabricaEntidades fabrica = new DominioSKD.Fabrica.FabricaEntidades();
             IDaoAsistencia DAO = FabricaDAOSqlServer.ObtenerDAOAsistencia();

             entidad = fabrica.ObtenerCompetencia();
             ((DominioSKD.Entidades.Modulo12.Competencia)entidad).Id = 6;
             Assert.IsNotNull(entidad);
         }


         [Test]
         public void ConsultarCompetenciaXIdDetalleC() // CONtar
         {
             DominioSKD.Fabrica.FabricaEntidades fabrica = new DominioSKD.Fabrica.FabricaEntidades();
             IDaoAsistencia DAO = FabricaDAOSqlServer.ObtenerDAOAsistencia();

             entidad = fabrica.ObtenerCompetencia();
             ((DominioSKD.Entidades.Modulo12.Competencia)entidad).Id = 6;
             Assert.AreEqual(0, listaEntidad.ToArray().Length);
         }

        
       }
        #endregion

    }
