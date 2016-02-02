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
    public class PresentadorConsultarRestriccionesEvento
    {
        private IContratoConsultarRestriccionEvento vista;
        List<Entidad> lista;

        public PresentadorConsultarRestriccionesEvento(IContratoConsultarRestriccionEvento vista)
        {
            this.vista = vista;
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
                    vista.alerta = RecursoPresentadorM8.innerHtmlAlertAgregar;

                }

                if (success.Equals(RecursoPresentadorM8.idAlertModificar))
                {
                    vista.alertaClase = RecursoPresentadorM8.alertaSuccess;
                    vista.alertaRol = RecursoPresentadorM8.tipoAlerta;
                    vista.alerta = RecursoPresentadorM8.innerHtmlAlertModificar;
                }

            }
        }

        public void LlenarInformacion()
        {
            try
            {
                Comando<List<Entidad>> command = FabricaComandos.CrearComandoConsultarRestriccionEvento();
                lista = command.Ejecutar();
                foreach (DominioSKD.Entidades.Modulo8.RestriccionEvento rest in lista)
                {
                    vista.RestriccionesCreadas += RecursoPresentadorM8.AbrirTR;
                    vista.RestriccionesCreadas += RecursoPresentadorM8.AbrirTD + rest.IdRestEvento.ToString() + RecursoPresentadorM8.CerrarTD;
                    vista.RestriccionesCreadas += RecursoPresentadorM8.AbrirTD + rest.IdEvento.ToString() + RecursoPresentadorM8.CerrarTD;
                    vista.RestriccionesCreadas += RecursoPresentadorM8.AbrirTD + rest.NombreEvento.ToString() + RecursoPresentadorM8.CerrarTD;
                    vista.RestriccionesCreadas += RecursoPresentadorM8.AbrirTD + rest.EdadMinima.ToString() + RecursoPresentadorM8.CerrarTD;
                    vista.RestriccionesCreadas += RecursoPresentadorM8.AbrirTD + rest.EdadMaxima.ToString() + RecursoPresentadorM8.CerrarTD;
                    vista.RestriccionesCreadas += RecursoPresentadorM8.AbrirTD + rest.Descripcion.ToString() + RecursoPresentadorM8.CerrarTD;
                    vista.RestriccionesCreadas += RecursoPresentadorM8.AbrirTD + rest.Sexo.ToString() + RecursoPresentadorM8.CerrarTD;
                    if (rest.Status == 1)
                        vista.RestriccionesCreadas += RecursoPresentadorM8.AbrirTD + RecursoPresentadorM8.Activa + RecursoPresentadorM8.CerrarTD;
                    else
                        vista.RestriccionesCreadas += RecursoPresentadorM8.AbrirTD + RecursoPresentadorM8.Inactiva + RecursoPresentadorM8.CerrarTD;
                    vista.RestriccionesCreadas += RecursoPresentadorM8.AbrirTD;
                    vista.RestriccionesCreadas += RecursoPresentadorM8.BotonModificarRegistroEvento + rest.IdRestEvento + RecursoPresentadorM8.Nombre + rest.NombreEvento + RecursoPresentadorM8.Emin + rest.EdadMinima + RecursoPresentadorM8.Emax + rest.EdadMaxima + RecursoPresentadorM8.Sexo + rest.Sexo + RecursoPresentadorM8.Descripcion + rest.Descripcion + RecursoPresentadorM8.BotonCerrar;
                    vista.RestriccionesCreadas += RecursoPresentadorM8.StatusEvento + rest.IdRestEvento + RecursoPresentadorM8.RestriccionStatus + rest.Status + RecursoPresentadorM8.BotonCerrar;
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

        public void MostrarAgregado(String eventoAgregado)
        {
            vista.alertaClase = RecursoPresentadorM8.alertaError1;
            vista.alertaRol = RecursoPresentadorM8.tipoAlerta;
            vista.alerta = RecursoPresentadorM8.alertaHtml
                + RecursoPresentadorM8.restAgregada + eventoAgregado + RecursoPresentadorM8.restAgregada2
                + RecursoPresentadorM8.alertaHtmlFinal;
        }

        public void MostrarModificado(String eventoAgregado)
        {
            vista.alertaClase = RecursoPresentadorM8.alertaError;
            vista.alertaRol = RecursoPresentadorM8.tipoAlerta;
            vista.alerta = RecursoPresentadorM8.alertaHtml
                + RecursoPresentadorM8.restModificada + eventoAgregado + RecursoPresentadorM8.restModificada2
                + RecursoPresentadorM8.alertaHtmlFinal;
        }

        public void CambiarStatus(int id, int bitStatus)
        {
            try
            {
                DominioSKD.Entidades.Modulo8.RestriccionEvento laRestEvento = new DominioSKD.Entidades.Modulo8.RestriccionEvento();
                if (bitStatus == 1)
                    bitStatus = 0;
                else
                    bitStatus = 1;
                laRestEvento.Status = bitStatus;
                laRestEvento.IdRestEvento = id;
                LogicaNegociosSKD.Comandos.Modulo8.ComandoEliminarRestriccionEvento _comando =
                    (LogicaNegociosSKD.Comandos.Modulo8.ComandoEliminarRestriccionEvento)LogicaNegociosSKD.Fabrica.FabricaComandos.CrearComandoEliminarRestriccionEvento(laRestEvento);
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

        public void Alerta(string msj)
        {
            vista.alertaClase = "alert alert-danger alert-dismissible";
            vista.alertaRol = "alert";
            vista.alerta = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" + msj + "</div>";
        }

       
    }
}
