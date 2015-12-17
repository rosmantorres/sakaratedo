using DominioSKD;
using LogicaNegociosSKD.Modulo3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace templateApp.GUI.Modulo3
{
    public partial class M3_ConsultarOrganizacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "3";
         /*   LogicaOrganizacion logicaOrganizacion = new LogicaOrganizacion();
            List<Organizacion> listOrganizacion = logicaOrganizacion.ListarOrganizacion();
            foreach (Organizacion item in listOrganizacion)
            {
                 this.tabla.Text += M3_RecursoInterfaz.Abrirtr;
                 this.tabla.Text += M3_RecursoInterfaz.Abrirtd + item.Nombre + M3_RecursoInterfaz.Cerrartd;
                 this.tabla.Text += M3_RecursoInterfaz.Abrirtd + item.Email + M3_RecursoInterfaz.Cerrartd;
                 this.tabla.Text += M3_RecursoInterfaz.Abrirtd + item.Telefono + M3_RecursoInterfaz.Cerrartd;
                 this.tabla.Text += M3_RecursoInterfaz.Abrirtd + item.Estilo +  M3_RecursoInterfaz.Cerrartd;
                 this.tabla.Text += M3_RecursoInterfaz.Abrirtd + item.Direccion + M3_RecursoInterfaz.Cerrartd;
                 this.tabla.Text += M3_RecursoInterfaz.Abrirtd + item.Estado + M3_RecursoInterfaz.Cerrartd;
                this.tabla.Text += M3_RecursoInterfaz.Abrirtd;
                 this.tabla.Text += M3_RecursoInterfaz.BotonInfo + item.Id_organizacion + M3_RecursoInterfaz.BotonCerrar;
                 this.tabla.Text += M3_RecursoInterfaz.BotonModificar + item.Id_organizacion + M3_RecursoInterfaz.BotonCerrar;
                 this.tabla.Text += M3_RecursoInterfaz.BotonEliminar + item.Id_organizacion + M3_RecursoInterfaz.BotonCerrar;
                 this.tabla.Text += M3_RecursoInterfaz.Cerrartd;
                 this.tabla.Text += M3_RecursoInterfaz.Cerrartr;
            }*/
        }
    }
}