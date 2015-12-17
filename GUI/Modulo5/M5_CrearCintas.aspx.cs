using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioSKD;
using LogicaNegociosSKD.Modulo5;
using LogicaNegociosSKD.Modulo3;

namespace templateApp.GUI.Modulo5
{
    public partial class M5_CrearCintas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "5";

            // Controlador

            if (!IsPostBack)
            {
                llenarComboORG();
            }
            
        }

        protected void llenarComboORG()
        {

            LogicaNegociosSKD.Modulo3.LogicaOrganizacion lO = new LogicaNegociosSKD.Modulo3.LogicaOrganizacion();
            List<Organizacion> listOrganizacion = new List<Organizacion>();
            listOrganizacion = lO.ListarOrganizacion();
            Dictionary<string, string> options = new Dictionary<string, string>();

            options.Add("-1", "Selecciona una opcion");
            try
            {
                foreach (Organizacion item in listOrganizacion)
                {
                    options.Add(item.Id_organizacion.ToString(), item.Nombre);
                }
                options.Add("-2", "OTRO");
            }
            catch (Exception e)
            {

            }

            ListOrg.DataSource = options;
            ListOrg.DataTextField = "value";
            ListOrg.DataValueField = "key";
            ListOrg.DataBind();
        }

        protected void btnCrearCinta(object sender, EventArgs e){

            LogicaCinta lO = new LogicaNegociosSKD.Modulo5.LogicaCinta();
            string organizacion = "";
            string nombre = "";
            Cinta laCinta = new Cinta();
            Organizacion laOrganizacion = new Organizacion();

            if (this.ListOrg.SelectedValue != "-1" && this.ListOrg.SelectedValue != "-2")
            {           
                organizacion = this.ListOrg.SelectedValue;
                nombre = this.ListOrg.Text;
            }
                          
            string color = cinta.Value;
            string rango = ran.Value;
            string categoria = cate.Value;
            string significado = signi.Value;
            string orden = ord.Value;

            laCinta.Color_nombre = color;
            laCinta.Rango = rango;
            laCinta.Clasificacion = categoria;
            laCinta.Significado = significado;
            laCinta.Orden = Int32.Parse(orden);
            laOrganizacion.Id_organizacion = Int32.Parse(organizacion);
            laOrganizacion.Nombre = nombre;
            laCinta.Organizacion = laOrganizacion;
            //try
           try{
               lO.agregarCinta(laCinta);
           }
           catch (ExcepcionesSKD.Modulo5.FormatoIncorrectoException ex)
           {
               
           }

        }

    }

}