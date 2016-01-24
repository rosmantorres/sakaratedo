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
using DatosSKD.InterfazDAO.Modulo14;

namespace PruebasUnitariasSKD.Modulo14
{
     [TestFixture]
    class PruebaDaoSolicitud
    {
        IDaoSolicitud daosolicitud;
         [SetUp]
         public void Init()
         {
             daosolicitud = (IDaoSolicitud)FabricaDAOSqlServer.ObtenerDAOSolicitud();
         }
         [Test]
         public void PruebaAgregar()
         {
             Planilla laPlanilla = (Planilla)FabricaEntidades.ObtenerPlanilla();
             laPlanilla.ID = 16;
             DominioSKD.Entidad laSolicitud = FabricaEntidades.ObtenerSolicitudP("01/01/2016", "10/01/2016", "motivo", laPlanilla, 16);
             Assert.IsTrue(daosolicitud.Agregar(laSolicitud));

         }
          [Test]
         public void PruebaModificar()
         {
             Planilla laPlanilla = (Planilla)FabricaEntidades.ObtenerPlanilla();
             laPlanilla.ID = 16;
             DominioSKD.Entidad laSolicitud = FabricaEntidades.ObtenerSolicitudP("01/01/2016", "10/01/2016", "motivo", laPlanilla, 16);
             Assert.IsTrue(daosolicitud.Agregar(laSolicitud));

         }

          [Test]
          public void PruebaConsultar()
          {
              DominioSKD.Entidades.Modulo14.SolicitudP laSolicitud = (DominioSKD.Entidades.Modulo14.SolicitudP)FabricaEntidades.ObtenerSolicitudP();

              laSolicitud.ID = 56;
              DominioSKD.Entidades.Modulo14.SolicitudP result = (DominioSKD.Entidades.Modulo14.SolicitudP)daosolicitud.ConsultarXId(laSolicitud);
              Assert.IsTrue(result != null);
          }
           [Test]
          public void PruebaRegistrarSolicitudIDPersonaBD()
          {
              DominioSKD.Entidades.Modulo14.Planilla laPlanilla = (DominioSKD.Entidades.Modulo14.Planilla)FabricaEntidades.ObtenerPlanilla();
              laPlanilla.ID = 82;
               DominioSKD.Entidades.Modulo14.SolicitudP laSolicitud = (DominioSKD.Entidades.Modulo14.SolicitudP)FabricaEntidades.ObtenerSolicitudP("01/01/2016", "10/01/2016", "motivo", laPlanilla, 1);
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
