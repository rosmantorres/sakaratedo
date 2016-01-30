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
                    vista.RestriccionesCreadas += RecursoPresentadorM8.AbrirTD; vista.RestriccionesCreadas += RecursoPresentadorM8.BotonModificarRegistroEvento + rest.IdRestEvento + RecursoPresentadorM8.BotonCerrar;
                    vista.RestriccionesCreadas += RecursoPresentadorM8.BotonDesactivarPlanilla + rest.Id + RecursoPresentadorM8.BotonCerrar;
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

        public List<Entidad> LlenarTabla()
        {
            this.lista = null;
            Comando<List<Entidad>> command = FabricaComandos.CrearComandoConsultarRestriccionEvento();
            try
            {

                lista = command.Ejecutar();
            }
            catch (ExcepcionesSKD.ExceptionSKD ex)
            {
                vista.alertaClase = RecursoPresentadorM8.alertaError;
                vista.alertaRol = RecursoPresentadorM8.tipoAlerta;
                vista.alerta = RecursoPresentadorM8.alertaHtml + ex.Mensaje
                    + RecursoPresentadorM8.alertaHtmlFinal;

            }
            return lista;
        }
    }
}
