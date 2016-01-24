using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using LogicaNegociosSKD.Fabrica;
using LogicaNegociosSKD.Comandos.Modulo14;
using DominioSKD;
using LogicaNegociosSKD;
using DominioSKD.Fabrica;

namespace PruebasUnitariasSKD.Modulo14
{
    [TestFixture]
    public class PruebaComando
    {
        
       
        [SetUp]
        public void Init()
        {
        }
        [Test]
        public void PruebaComandoAgregarDiseno()
        {
            Comando<Boolean> comando = FabricaComandos.ObtenerComandoAgregarDiseno();
            DominioSKD.Entidad laPlanilla = FabricaEntidades.ObtenerPlanilla();
            DominioSKD.Entidad elDiseno = FabricaEntidades.obtenerDiseño();
            ((DominioSKD.Entidades.Modulo14.Planilla)laPlanilla).ID = 19;
            ((DominioSKD.Entidades.Modulo14.Diseño)elDiseno).ID = 16;
            ((DominioSKD.Entidades.Modulo14.Diseño)elDiseno).Contenido = "probando";
            ((ComandoAgregarDiseno)comando).Planilla = laPlanilla;
            ((ComandoAgregarDiseno)comando).Diseño = elDiseno;
            Assert.IsTrue(((ComandoAgregarDiseno)comando).Ejecutar());
        }

        [Test]
        public void PruebaComandoCompetenciasSolicitud()
        {
            Comando<List<Entidad>> comando = FabricaComandos.ObtenerComandoCompetenciasSolicitud();
            ((ComandoCompetenciasSolicitud)comando).IDPersona = 1;
            Assert.IsNotEmpty(((ComandoCompetenciasSolicitud)comando).Ejecutar());
        }

        [Test]
        public void PruebaComandoConsultarPlanillas()
        {
            Assert.IsNotEmpty(((ComandoConsultarPlanillas)FabricaComandos.ObtenerComandConsultarPlanillas()).Ejecutar());
        }

        [Test]
        public void PruebaComandoConsultarPlanillasASolicitar()
        {
            Assert.IsNotEmpty(((ComandoConsultarPlanillasASolicitar)FabricaComandos.ObtenerComandoConsultarPlanillasASolicitar()).Ejecutar());
        }

        [Test]
        public void PruebaComandoDatosRequeridosSolicitud()
        {
            Comando<List<Boolean>> comando = FabricaComandos.ObtenerComandoDatosRequeridosSolicitud();
            comando.LaEntidad = DominioSKD.Fabrica.FabricaEntidades.ObtenerPlanilla();
            comando.LaEntidad.Id = 16;
            Assert.IsNotEmpty(((ComandoDatosRequeridosSolicitud)comando).Ejecutar());
        }
        [Test]
        public void PruebaComandoEliminarSolicitud()
        {
            Comando<Boolean> comando = FabricaComandos.ObtenerComandoEliminarSolicitud();
            ((ComandoEliminarSolicitud)comando).iDSolicitud = 52;
            Assert.IsTrue(((ComandoEliminarSolicitud)comando).Ejecutar());
        }
        [Test]
        public void PruebaComandoEventosSolicitud()
        {
            Comando<List<Entidad>> comando = FabricaComandos.ObtenerComandoEventosSolicitud() ;
            ((ComandoEventosSolicitud)comando).IDPersona = 1;
            Assert.IsNotEmpty(((ComandoEventosSolicitud)comando).Ejecutar());
        }
        [Test]
        public void PruebaComandoListarPlanillasSolicitadas()
        {
            Comando<List<Entidad>> comando = FabricaComandos.ObtenerComandoListarPlanillasSolicitadas();
            ((ComandoListarPlanillasSolicitadas)comando).IDPersona = 1;
            Assert.IsNotEmpty(((ComandoListarPlanillasSolicitadas)comando).Ejecutar());
        }
        [Test]
        public void PruebaComandoModificarDiseno()
        {
            Comando<Boolean> comando = FabricaComandos.ObtenerComandoModificarDiseno();
            DominioSKD.Entidad elDiseno = FabricaEntidades.obtenerDiseño();
            ((DominioSKD.Entidades.Modulo14.Diseño)elDiseno).ID = 52;
            ((DominioSKD.Entidades.Modulo14.Diseño)elDiseno).Contenido = "Modificado por prueba";
            ((ComandoModificarDiseno)comando).Diseño = elDiseno;
            Assert.IsTrue(((ComandoModificarDiseno)comando).Ejecutar());
        }
           [Test]
           public void PruebaComandoModificarPlanillaID()
        {
               List<String> lista = new List<string>();
               lista.Add("DOJO");
            Comando<Entidad> comando = FabricaComandos.ObtenerComandoModificarPlanillaID();
            DominioSKD.Entidad laPlanilla = FabricaEntidades.ObtenerPlanilla(34, "Retiro Nuevo", true,1,lista);
             ((ComandoModificarPlanillaID)comando).LaEntidad = laPlanilla;
            Assert.AreEqual(((DominioSKD.Entidades.Modulo14.Planilla)(((ComandoModificarPlanillaID)comando).Ejecutar())).Nombre,"Retiro Nuevo");
        }

           [Test]
           public void PruebaComandoModificarPlanillaIDTipo()
           {
               List<String> lista = new List<string>();
               lista.Add("DOJO");
               Comando<Entidad> comando = FabricaComandos.ObtenerComandoModificarPlanillaIDTipo();
               DominioSKD.Entidad laPlanilla = FabricaEntidades.ObtenerPlanilla(34, "Retiro Nuevo Tipo", true, 1, lista);
               ((ComandoModificarPlanillaIDTipo)comando).LaEntidad = laPlanilla;
               ((ComandoModificarPlanillaIDTipo)comando).TipoPlanilla = "Retiro";
              DominioSKD.Entidades.Modulo14.Planilla planillaM= ((DominioSKD.Entidades.Modulo14.Planilla)(((ComandoModificarPlanillaIDTipo)comando).Ejecutar())); 
               Assert.AreEqual(planillaM.Nombre, "Retiro Nuevo Tipo");
           }

           [Test]
           public void PruebaComandoModificarSolicitudID()
           {
               Comando<Entidad> comando = FabricaComandos.ObtenerComandoModificarSolicitudID();
               DominioSKD.Entidad laSolicitud = FabricaEntidades.ObtenerSolicitudP(38, "01/23/2016", "01/23/2016", "Prueba",2);
               ((ComandoModificarSolicitudID)comando).LaEntidad = laSolicitud;
               DominioSKD.Entidades.Modulo14.SolicitudP solicitudM = ((DominioSKD.Entidades.Modulo14.SolicitudP)(((ComandoModificarSolicitudID)comando).Ejecutar()));
               Assert.AreEqual(solicitudM.Motivo, "Prueba");
           }
           [Test]
           public void PruebaComandoNuevoTipoPlanilla()
           {
               Comando<Boolean> comando = FabricaComandos.ObtenerComandoNuevoTipoPlanilla();
               ((ComandoNuevoTipoPlanilla)comando).NombreTipo = "Prueba";
               Assert.IsTrue(((ComandoNuevoTipoPlanilla)comando).Ejecutar());
           }
           [Test]
           public void PruebaComandoObtenerDatosBD()
           {
               Comando<List<String>> comando = FabricaComandos.ObtenerComandoObtenerDatosBD();
               Assert.IsNotEmpty(((ComandoObtenerDatosBD)comando).Ejecutar());
           }
           [Test]
           public void PruebaComandoObtenerDatosPlanilla()
           {
               Comando<List<String>> comando = FabricaComandos.ObtenerComandoObtenerDatosPlanilla();
               ((ComandoObtenerDatosPlanilla)comando).IdPlanilla = 64;
               Assert.IsNotEmpty(((ComandoObtenerDatosPlanilla)comando).Ejecutar());
           }
           [Test]
           public void PruebaComandoObtenerSolicitudID()
           {
               Comando<Entidad> comando = FabricaComandos.ObtenerComandoObtenerSolicitudID();
               ((ComandoObtenerSolicitudID)comando).IDSolicitud = 29;
              DominioSKD.Entidades.Modulo14.SolicitudP laSolicitud= (DominioSKD.Entidades.Modulo14.SolicitudP)(((ComandoObtenerSolicitudID)comando).Ejecutar());
               Assert.AreEqual(laSolicitud.Motivo,"holaa");
           }
           [Test]
           public void PruebaComandoObtenerTipoPlanilla()
           {
               Comando<List<Entidad>> comando = FabricaComandos.ObtenerComandoObtenerTipoPlanilla();
               Assert.IsNotEmpty(((ComandoObtenerTipoPlanilla)comando).Ejecutar());
           }
           [Test]
           public void PruebaComandoRegistrarPlanilla()
           {
               List<String> lista = new List<string>();
               lista.Add("DOJO");
               Comando<bool> comando = FabricaComandos.ObtenerComandoRegistrarPlanilla();
               DominioSKD.Entidad laPlanilla = FabricaEntidades.ObtenerPlanilla("Registrar Prueba", true, 1, lista);
               ((ComandoRegistrarPlanilla)comando).LaEntidad = laPlanilla;
               Assert.IsTrue(((ComandoRegistrarPlanilla)comando).Ejecutar());
           }
           [Test]
           public void PruebaComandoRegistrarPlanillaTipo()
           {
               List<String> lista = new List<string>();
               lista.Add("DOJO");
               Comando<bool> comando = FabricaComandos.ObtenerComandoRegistrarPlanillaTipo();
               DominioSKD.Entidad laPlanilla = FabricaEntidades.ObtenerPlanilla("Registrar Prueba", true, 1, lista);
               ((ComandoRegistrarPlanillaTipo)comando).LaEntidad = laPlanilla;
               ((ComandoRegistrarPlanillaTipo)comando).NombreTipo = "Retiro";
               Assert.IsTrue(((ComandoRegistrarPlanillaTipo)comando).Ejecutar());
           }
           [Test]
           public void PruebaComandoRegistrarSolicitudIDPersona()
           {
               Comando<Boolean> comando = FabricaComandos.ObtenerComandoRegistrarSolicitudIDPersona();
               DominioSKD.Entidad laPlanilla = FabricaEntidades.ObtenerPlanilla();
               ((DominioSKD.Entidades.Modulo14.Planilla)laPlanilla).ID =82;
               DominioSKD.Entidad laSolicitud = FabricaEntidades.ObtenerSolicitudP("01/23/2016", "01/23/2016",
                                                     "Probando",
                                                     (DominioSKD.Entidades.Modulo14.Planilla
                                                     )laPlanilla, 1);
               ((ComandoRegistrarSolicitudIDPersona)comando).LaEntidad = laSolicitud;
               Assert.IsTrue(((ComandoRegistrarSolicitudIDPersona)comando).Ejecutar());
               
           }
           [Test]
           public void PruebaComandoRegistrarSolicitudPlanilla()
           {
               Comando<bool> comando = FabricaComandos.ObtenerComandoRegistrarSolicitudPlanilla();
               DominioSKD.Entidad laPlanilla = FabricaEntidades.ObtenerPlanilla();
               ((DominioSKD.Entidades.Modulo14.Planilla)laPlanilla).ID = 82;
               DominioSKD.Entidad laSolicitud = FabricaEntidades.ObtenerSolicitudP("01/23/2016", "01/23/2016",
                                                     "Probando",
                                                     (DominioSKD.Entidades.Modulo14.Planilla
                                                     )laPlanilla, 1);
               ((ComandoRegistrarSolicitudPlanilla)comando).LaEntidad = laSolicitud;
               Assert.IsTrue(((ComandoRegistrarSolicitudPlanilla)comando).Ejecutar());
           }
    }

}
