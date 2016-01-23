using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DatosSKD;
using DatosSKD.Fabrica;
using DatosSKD.DAO.Modulo14;
using DominioSKD.Fabrica;
using DominioSKD.Entidades.Modulo14;

namespace PruebasUnitariasSKD.Modulo14
{
     [TestFixture]
    class PruebaDaoSolicitud
    {
        FabricaDAOSqlServer fabrica;
        DaoSolicitud daosolicitud;
        FabricaEntidades fentidades;
         [SetUp]
         public void Init()
         {
             fabrica = new FabricaDAOSqlServer();
             fentidades = new FabricaEntidades();
             daosolicitud = (DaoSolicitud)fabrica.ObtenerDAOSolicitud();
         }
         [Test]
         public void PruebaAgregar()
         {
             Planilla laPlanilla = (Planilla)fentidades.ObtenerPlanilla();
             laPlanilla.ID = 16;
             DominioSKD.Entidad laSolicitud = fentidades.ObtenerSolicitudP("01/01/2016", "10/01/2016", "motivo", laPlanilla, 16);
             Assert.IsTrue(daosolicitud.Agregar(laSolicitud));

         }
          [Test]
         public void PruebaModificar()
         {
             Planilla laPlanilla = (Planilla)fentidades.ObtenerPlanilla();
             laPlanilla.ID = 16;
             DominioSKD.Entidad laSolicitud = fentidades.ObtenerSolicitudP("01/01/2016", "10/01/2016", "motivo",laPlanilla,16);
             Assert.IsTrue(daosolicitud.Agregar(laSolicitud));

         }

          [Test]
          public void PruebaConsultar()
          {
              SolicitudP laSolicitud = (SolicitudP)fentidades.ObtenerSolicitudP();

              laSolicitud.ID = 14;
              SolicitudP result = (SolicitudP)daosolicitud.ConsultarXId(laSolicitud);
              Assert.IsTrue(result != null);
          }
           [Test]
          public void PruebaRegistrarSolicitudIDPersonaBD()
          {
              Planilla laPlanilla = (Planilla)fentidades.ObtenerPlanilla();
              SolicitudP laSolicitud = (SolicitudP)fentidades.ObtenerSolicitudP("01/01/2016", "10/01/2016", "motivo", laPlanilla, 10);
              laSolicitud.ID = 14;
               Assert.IsTrue(daosolicitud.RegistrarSolicitudIDPersonaBD(laSolicitud));
          }
           [Test]
           public void PruebaObtenerEventosSolicitud()
           {
               Assert.IsNotEmpty(daosolicitud.ObtenerEventosSolicitud(1));
           }
           [Test]
           public void PruebaEliminarSolicitudBD()
           {
               Assert.IsTrue(daosolicitud.EliminarSolicitudBD(34));
           }
           [Test]
           public void PruebaObtenerCompetenciaSolicitud()
           {
               Assert.IsNotEmpty(daosolicitud.ObtenerCompetenciaSolicitud(1));
           }
          [Test]
           public void PruebaConsultarPlanillasASolicitarBD()
           {
               Assert.IsNotEmpty(daosolicitud.ConsultarPlanillasASolicitarBD());
           }

          [Test]
          public void PruebaConsultarSolicitudes()
          {
              Assert.IsNotEmpty(daosolicitud.ConsultarSolicitudes(1));
          }


     
     }

}
