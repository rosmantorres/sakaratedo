using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioSKD;
using LogicaNegociosSKD.Modulo5;
using LogicaNegociosSKD.Modulo3;
using Interfaz_Presentadores.Modulo5;
using Interfaz_Contratos.Modulo5;

namespace templateApp.GUI.Modulo5
{
    public partial class M5_CrearCintas : System.Web.UI.Page, IContratoCrearCinta
    {

        private PresentadorCrearCintas presentador;
        private Dictionary<string, string> options = new Dictionary<string, string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "5";

            // Controlador

            if (!IsPostBack)
            {
                // la vista herda de la interfaz contrato 
                //el presentador al final recive un tipo de dato IContratoCrearCinta
                // la vista ES UN IContratoCrearCinta 
                this.presentador = new PresentadorCrearCintas(this);
                this.presentador.llenarCombo();
                this.ListOrg.DataSource = options;
                this.ListOrg.DataTextField = "value";
                this.ListOrg.DataValueField = "key";
                this.ListOrg.DataBind();
              
            }
            
        }

        #region Contrato
        public void agregarOrganizacionCombo(string id, string nombre) 
        {
            this.options.Add(id, nombre);
        }

        public int obtenerIdOrganizacion()
        {
            return Int32.Parse(this.ListOrg.SelectedValue); 
        }

        public string obtenerNombreOrganizacion()
        {
            return this.ListOrg.Text;
        }

        public string obtenerColorCinta()
        {
            return this.color.Value;
        }

        public string obtenerRango()
        {
            return this.ran.Value;
        }

        public string obtenerCategoria()
        {
            return this.cate.Value;
        }

        public string obtenerSignificado()
        {
            return this.signi.Value;
        }

        public string obtenerOrden()
        {
            return this.ord.Value;
        }
        #endregion


        protected void btnCrearCinta(object sender, EventArgs e){

            this.presentador.agregarValoresCinta(); 
        }

    }

}