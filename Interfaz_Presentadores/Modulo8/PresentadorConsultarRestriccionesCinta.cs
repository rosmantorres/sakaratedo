using DominioSKD;
using DominioSKD.Fabrica;
using ExcepcionesSKD;
using Interfaz_Contratos.Modulo8;
using LogicaNegociosSKD;
using LogicaNegociosSKD.Comandos.Modulo8;
using LogicaNegociosSKD.Fabrica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web;

namespace Interfaz_Presentadores.Modulo8
{
    public class PresentadorConsultarRestriccionesCinta
    {
        private IContratoConsultarResticcionCinta vista;
        List<Entidad> lista;

        public PresentadorConsultarRestriccionesCinta(IContratoConsultarResticcionCinta vista)
        {
            this.vista = vista;
        }

        public void LlenarInformacion()
        {
            try
            {
                Comando<List<Entidad>> command = FabricaComandos.CrearComandoConsultarRestriccionCinta();
                lista = command.Ejecutar();
                foreach (DominioSKD.Entidades.Modulo8.RestriccionCinta rest in lista)
                {
                    vista.RestriccionesCreadas += RecursoPresentadorM8.AbrirTR;
                    vista.RestriccionesCreadas += RecursoPresentadorM8.AbrirTD + rest.IdRestriccionCinta.ToString() + RecursoPresentadorM8.CerrarTD;
                    vista.RestriccionesCreadas += RecursoPresentadorM8.AbrirTD + rest.Descripcion.ToString() + RecursoPresentadorM8.CerrarTD;
                    vista.RestriccionesCreadas += RecursoPresentadorM8.AbrirTD + rest.TiempoMinimo.ToString() + RecursoPresentadorM8.CerrarTD;
                    vista.RestriccionesCreadas += RecursoPresentadorM8.AbrirTD + rest.PuntosMinimos.ToString() + RecursoPresentadorM8.CerrarTD;
                    vista.RestriccionesCreadas += RecursoPresentadorM8.AbrirTD + rest.TiempoDocente.ToString() + RecursoPresentadorM8.CerrarTD;
                    if (rest.Status == 1)
                        vista.RestriccionesCreadas += RecursoPresentadorM8.AbrirTD + "Activa" + RecursoPresentadorM8.CerrarTD;
                    else
                        vista.RestriccionesCreadas += RecursoPresentadorM8.AbrirTD + "Inactiva" + RecursoPresentadorM8.CerrarTD;
                    vista.RestriccionesCreadas += RecursoPresentadorM8.AbrirTD;
                    vista.RestriccionesCreadas += RecursoPresentadorM8.BotonModificarRegistro + rest.IdRestriccionCinta + RecursoPresentadorM8.Nombre + rest.Descripcion + RecursoPresentadorM8.BotonCerrar;
                    vista.RestriccionesCreadas += RecursoPresentadorM8.Status + rest.IdRestriccionCinta +RecursoPresentadorM8.RestriccionStatus + rest.Status + RecursoPresentadorM8.BotonCerrar;
                    vista.RestriccionesCreadas += RecursoPresentadorM8.CerrarTD;
                    vista.RestriccionesCreadas += RecursoPresentadorM8.CerrarTR;

                }
            }
            catch (ExcepcionesSKD.ExceptionSKD ex)
            {
                vista.alertaClase = RecursoPresentadorM8.alertaError;
                vista.alertaRol = RecursoPresentadorM8.tipoAlerta;
                vista.alerta = RecursoPresentadorM8.alertaHtml + ex.Mensaje
                    + RecursoPresentadorM8.alertaHtmlFinal;
            }
            
        }

        public void Alerta(string msj)
        {
            vista.alertaClase = "alert alert-danger alert-dismissible";
            vista.alertaRol = "alert";
            vista.alerta = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" + msj + "</div>";
        }

        public void CambiarStatus(int id, int bitStatus)
        {
            try
            {
                DominioSKD.Entidades.Modulo8.RestriccionCinta laRestCinta = new DominioSKD.Entidades.Modulo8.RestriccionCinta();
                if (bitStatus == 1)
                    bitStatus = 0;
                else
                    bitStatus = 1;
                laRestCinta.Status = bitStatus;
                laRestCinta.IdRestriccionCinta = id;
                LogicaNegociosSKD.Comandos.Modulo8.ComandoModificarStatusCinta _comando =
                    (LogicaNegociosSKD.Comandos.Modulo8.ComandoModificarStatusCinta)LogicaNegociosSKD.Fabrica.FabricaComandos.CrearComandoStatusRestriccionCinta(laRestCinta);
               bool resultado = _comando.Ejecutar();
            }
            catch (SqlException ex)
            {
                Alerta(ex.Message);
            }
            catch (FormatException ex)
            {
                Alerta(ex.Message);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Alerta(ex.Message);
            }
            catch (Exception ex)
            {
                Alerta(ex.Message);
            }
        }

        public void ObtenerVariablesURL()
        {

            String success = HttpContext.Current.Request.QueryString[RecursoPresentadorM8.strSuccess];
            String detalleString = HttpContext.Current.Request.QueryString[RecursoPresentadorM8.strEventoDetalle];


            if (detalleString != null)
            {

            }

            if (success != null)
            {
                if (success.Equals(RecursoPresentadorM8.idAlertAgregar))
                {
                    vista.alertaClase = RecursoPresentadorM8.alertaSuccess;
                    vista.alertaRol = RecursoPresentadorM8.tipoAlerta;
                    vista.alerta = RecursoPresentadorM8.innerHtmlAlertAgregarRCi;

                }

                if (success.Equals(RecursoPresentadorM8.idAlertModificar))
                {
                    vista.alertaClase = RecursoPresentadorM8.alertaSuccess;
                    vista.alertaRol = RecursoPresentadorM8.tipoAlerta;
                    vista.alerta = RecursoPresentadorM8.innerHtmlAlertModificarRCi;
                }

            }
        }

        public void MostrarAgregado(String eventoAgregado)
        {
            vista.alertaClase = RecursoPresentadorM8.alertaError1;
            vista.alertaRol = RecursoPresentadorM8.tipoAlerta;
            vista.alerta = RecursoPresentadorM8.alertaHtml
                + RecursoPresentadorM8.AddRestSuccess
                + RecursoPresentadorM8.alertaHtmlFinal;
        }

        public void MostrarModificado(String eventoAgregado)
        {
            vista.alertaClase = RecursoPresentadorM8.alertaError1;
            vista.alertaRol = RecursoPresentadorM8.tipoAlerta;
            vista.alerta = RecursoPresentadorM8.alertaHtml
                + RecursoPresentadorM8.ModRestSuccess
                + RecursoPresentadorM8.alertaHtmlFinal;
        }
    }
}
