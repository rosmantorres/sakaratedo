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
                catch
                {
                }
            }

        }
    }
}