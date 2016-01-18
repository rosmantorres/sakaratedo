using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaz_Contratos.Modulo12;
using System.Web;
using LogicaNegociosSKD.Fabrica;
using DominioSKD;
using LogicaNegociosSKD.Comandos.Modulo12;
using LogicaNegociosSKD;


namespace Interfaz_Presentadores.Modulo12
{
    public class PresentadorListarCompetencias
    {
        private IContratoListarCompetencias vista;

        public PresentadorListarCompetencias(IContratoListarCompetencias laVista)
        {
            this.vista = laVista;
        }

        public void ObtenerVariablesURL()
        {

            String success = HttpContext.Current.Request.QueryString[M12_RecursoInterfazPresentador.strSuccess];
            String detalleString = HttpContext.Current.Request.QueryString[M12_RecursoInterfazPresentador.strCompDetalle];


            if (detalleString != null)
            {

            }

            if (success != null)
            {
                if (success.Equals(M12_RecursoInterfazPresentador.idAlertAgregar))
                {
                    vista.alertaClase = M12_RecursoInterfazPresentador.alertaSuccess;
                    vista.alertaRol = M12_RecursoInterfazPresentador.tipoAlerta;
                    vista.alerta = M12_RecursoInterfazPresentador.innerHtmlAlertAgregar;
                    
                }

                if (success.Equals(M12_RecursoInterfazPresentador.idAlertModificar))
                {
                    vista.alertaClase = M12_RecursoInterfazPresentador.alertaSuccess;
                    vista.alertaRol = M12_RecursoInterfazPresentador.tipoAlerta;
                    vista.alerta = M12_RecursoInterfazPresentador.innerHtmlAlertAgregar;
                }

            }
        }

        public void ConsultarCompetencias() 
        {
                try
                {
                    
                    //LogicaCompetencias logComp = new LogicaCompetencias();
                    //laLista = logComp.obtenerListaDeCompetencias();
                    FabricaComandos laFabrica = new FabricaComandos();

                    Comando<List<Entidad>> comandoListarCompetencias = 
                        laFabrica.ObtenerComandoConsultarCompetencias();

                    List<Entidad> laLista = comandoListarCompetencias.Ejecutar();

                    foreach (DominioSKD.Entidades.Modulo12.Competencia c in laLista)
                    {
                        vista.laTabla += M12_RecursoInterfazPresentador.AbrirTR;
                        vista.laTabla += M12_RecursoInterfazPresentador.AbrirTD + c.Nombre.ToString() + M12_RecursoInterfazPresentador.CerrarTD;
                        vista.laTabla += M12_RecursoInterfazPresentador.AbrirTD + c.TipoCompetencia.ToString() + M12_RecursoInterfazPresentador.CerrarTD;
                        vista.laTabla += M12_RecursoInterfazPresentador.AbrirTD + c.Organizacion.Nombre.ToString() + M12_RecursoInterfazPresentador.CerrarTD;
                        vista.laTabla += M12_RecursoInterfazPresentador.AbrirTD + c.Ubicacion.Ciudad.ToString() + M12_RecursoInterfazPresentador.coma + c.Ubicacion.Estado.ToString() + M12_RecursoInterfazPresentador.CerrarTD;
                        vista.laTabla += M12_RecursoInterfazPresentador.AbrirTD + c.Status.ToString() + M12_RecursoInterfazPresentador.CerrarTD;
                        vista.laTabla += M12_RecursoInterfazPresentador.AbrirTD;
                        vista.laTabla += M12_RecursoInterfazPresentador.BotonInfo + c.Id + M12_RecursoInterfazPresentador.BotonCerrar;
                        vista.laTabla += M12_RecursoInterfazPresentador.BotonModificar + c.Id + M12_RecursoInterfazPresentador.BotonCerrar;
                        vista.laTabla += M12_RecursoInterfazPresentador.CerrarTD;
                        vista.laTabla += M12_RecursoInterfazPresentador.CerrarTR;
                    }

                }
                catch (ExcepcionesSKD.ExceptionSKD ex)
                {
                    vista.alertaClase = M12_RecursoInterfazPresentador.alertaError;
                    vista.alertaRol = M12_RecursoInterfazPresentador.tipoAlerta;
                    vista.alerta = M12_RecursoInterfazPresentador.alertaHtml + ex.Mensaje + M12_RecursoInterfazPresentador.alertaHtmlFinal;
                    
                }
            }
        }

        
    }

