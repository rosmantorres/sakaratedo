using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioSKD;
using LogicaNegociosSKD;
using LogicaNegociosSKD.Modulo8;
using System.Data.Odbc;
using System.Data.SqlClient;

namespace templateApp.GUI.Modulo8
{
    public partial class interfazRestriccionesAvanceCinta : System.Web.UI.Page
    {
        private LogicaRestriccionCinta logica = new LogicaRestriccionCinta();
        List<RestriccionCinta> lista;

        protected void Page_Load(object sender, EventArgs e)
        {

            ((SKD)Page.Master).IdModulo = "8";
            if (!IsPostBack)
            {
                List<RestriccionCinta> listaRestriccion = LlenarTabla();
                LlenarInformacion(listaRestriccion);
            }
            

        }

        public List<RestriccionCinta> LlenarTabla()
        {
            return logica.obtenerListaDeRestriccionCinta();
        }

        public void LlenarInformacion(List<RestriccionCinta> lista)
        {
            this.lista = lista;
            foreach (RestriccionCinta rest in lista)
            {
                this.tabla.Text += RecursoInterfazMod8.AbrirTR;
                this.tabla.Text += RecursoInterfazMod8.AbrirTD + rest.IdRestriccionCinta.ToString() + RecursoInterfazMod8.CerrarTD;
                this.tabla.Text += RecursoInterfazMod8.AbrirTD + rest.Descripcion.ToString() + RecursoInterfazMod8.CerrarTD;
                this.tabla.Text += RecursoInterfazMod8.AbrirTD + rest.TiempoMinimo.ToString() + RecursoInterfazMod8.CerrarTD;
                this.tabla.Text += RecursoInterfazMod8.AbrirTD + rest.PuntosMinimos.ToString() + RecursoInterfazMod8.CerrarTD;
                this.tabla.Text += RecursoInterfazMod8.AbrirTD + rest.TiempoDocente.ToString() + RecursoInterfazMod8.CerrarTD;
                this.tabla.Text += RecursoInterfazMod8.AbrirTD;
                this.tabla.Text += RecursoInterfazMod8.BotonInfo + rest.IdRestriccionCinta + RecursoInterfazMod8.BotonCerrar;
                this.tabla.Text += RecursoInterfazMod8.BotonModificarRegistro + rest.IdRestriccionCinta + RecursoInterfazMod8.Nombre + rest.Descripcion + RecursoInterfazMod8.Tipo + RecursoInterfazMod8.BotonCerrar;
                this.tabla.Text += RecursoInterfazMod8.BotonDesactivarPlanilla + rest.IdRestriccionCinta + RecursoInterfazMod8.BotonCerrar;
                this.tabla.Text += RecursoInterfazMod8.CerrarTD;
                this.tabla.Text += RecursoInterfazMod8.CerrarTR;
            }
        }
    }
}