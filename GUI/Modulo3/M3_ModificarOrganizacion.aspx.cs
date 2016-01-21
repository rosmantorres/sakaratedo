using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioSKD;
using LogicaNegociosSKD.Modulo3;

namespace templateApp.GUI.Modulo3
{
    public partial class M3_ModificarOrganizacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String idOrg = Request.QueryString["idOrg"];

            ((SKD)Page.Master).IdModulo = "3";
        }


        protected void btnModificarOrganizaciones(object sender, EventArgs e)
        {
            string estado = "";
            string tecnica = "";
          //  LogicaOrganizacion lO = new LogicaNegociosSKD.Modulo3.LogicaOrganizacion();
            Organizacion laOrganizacion = new Organizacion();

            if (this.ListEstados.SelectedValue != "-1")
            {
                estado = this.ListEstados.SelectedValue;

            }

            if (this.ListTecnica.SelectedValue != "-1")
            {
                tecnica = this.ListTecnica.SelectedValue;

            }

            String idOrg = Request.QueryString["idOrg"];
            string nombreOrg = nombre.Value;
            string correo = email.Value;
            string tel = telefono.Value;
            string dir = direccion.Value;

            laOrganizacion.Id_organizacion = Int32.Parse(idOrg);
            laOrganizacion.Nombre = nombreOrg;
            laOrganizacion.Email = correo;
            laOrganizacion.Telefono = Int32.Parse(tel);
            laOrganizacion.Direccion = dir;
            laOrganizacion.Estado = estado;
            laOrganizacion.Estilo = tecnica;

            //try
            try
            {
               // lO.modificarOrganizacion(laOrganizacion);
            }
            catch (ExcepcionesSKD.Modulo5.FormatoIncorrectoException ex)
            {

            }

        }
 


    }


}