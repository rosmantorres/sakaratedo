using DominioSKD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using templateApp.GUI.Master;
using LogicaNegociosSKD.Modulo9;

namespace templateApp.GUI.Modulo9
{
    public partial class M9_DetalleEvento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String idEvento = Request.QueryString["EventDetalle"];
            Evento evento = new Evento();
            LogicaEvento logica = new LogicaEvento();
            if (!IsPostBack) 
            {

                try
                {

                    evento = logica.ConsultarEvento(idEvento);
                    this.nombreEvento.Text = evento.Nombre;
                    this.tipoEvento.Text = evento.TipoEvento.Nombre;
                    this.costoEvento.Text = evento.Costo.ToString();
                    this.descripcionEvento.Text = evento.Descripcion;
                    this.fechaInicio.Text = evento.Horario.FechaInicio.ToShortDateString();
                    this.fechaFin.Text = evento.Horario.FechaFin.ToShortDateString();
                    this.horaInicio.Text = evento.Horario.HoraInicio.ToString()+":00";
                    this.horaFin.Text = evento.Horario.HoraFin.ToString() + ":00";
                    if (evento.Estado) {
                        this.statusEvento.Text = "Activo";
                    }
                    else {
                        this.statusEvento.Text = "Inactivo";    
                    }
  
                }
                catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
                {
                    alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                    alert.Attributes["role"] = "alert";
                    alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Error de Conxeion con BD</div>";

                }
                catch (ExcepcionesSKD.Modulo12.FormatoIncorrectoException ex)
                {
                    alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                    alert.Attributes["role"] = "alert";
                    alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Formato de Atributos Incorrecto</div>";

                }
                catch (ExcepcionesSKD.ExceptionSKD ex)
                {
                    alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                    alert.Attributes["role"] = "alert";
                    alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" + ex.Message + "</div>";

                }
                catch (NullReferenceException ex)
                {

                    alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                    alert.Attributes["role"] = "alert";
                    alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" + ex.Message + "</div>";

                }
                catch (Exception ex)
                {

                    alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                    alert.Attributes["role"] = "alert";
                    alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" + ex.Message + "</div>";

                }
            }

        }
    }
}