using System;

using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DominioSKD;
using LogicaNegociosSKD.Modulo5;
using LogicaNegociosSKD.Modulo3;


namespace templateApp.GUI.Modulo5
{
    public partial class M5_ListarCintas : System.Web.UI.Page
    {
        private LogicaNegociosSKD.Modulo5.LogicaCinta logica = new LogicaNegociosSKD.Modulo5.LogicaCinta();
        List<DominioSKD.Cinta> lista;


        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "5";

            
            if (!IsPostBack)
            {
                //llenarComboORG();
                //tabla.Visible = false;
                List<DominioSKD.Cinta> listaCinta = LlenarTabla();
                LlenarInformacion(listaCinta);
            }
            
            

           
        }

      

        //Dado el id de org me traigo la lista de cintas
        public List<DominioSKD.Cinta> LlenarTabla()
        {

            return logica.obtenerListaDeCinta();
            
        }

        public void LlenarInformacion(List<DominioSKD.Cinta> lista1)
        {
            this.lista = lista1;
            foreach (DominioSKD.Cinta cinta in lista)
            {

                this.tabla.Text += RecursoInterfazMod5.AbrirTR;
                this.tabla.Text += RecursoInterfazMod5.AbrirTD + cinta.Id_cinta.ToString() + RecursoInterfazMod5.CerrarTD;
                this.tabla.Text += RecursoInterfazMod5.AbrirTD + cinta.Color_nombre.ToString() + RecursoInterfazMod5.CerrarTD;
                this.tabla.Text += RecursoInterfazMod5.AbrirTD + cinta.Rango.ToString() + RecursoInterfazMod5.CerrarTD;
                this.tabla.Text += RecursoInterfazMod5.AbrirTD + cinta.Clasificacion.ToString() + RecursoInterfazMod5.CerrarTD;
                this.tabla.Text += RecursoInterfazMod5.AbrirTD + cinta.Significado.ToString() + RecursoInterfazMod5.CerrarTD;
                this.tabla.Text += RecursoInterfazMod5.AbrirTD + cinta.Orden.ToString() + RecursoInterfazMod5.CerrarTD;
                this.tabla.Text += RecursoInterfazMod5.AbrirTD + cinta.Organizacion.Nombre.ToString() + RecursoInterfazMod5.CerrarTD;
                this.tabla.Text += RecursoInterfazMod5.AbrirTD;
                this.tabla.Text += RecursoInterfazMod5.BotonInfo + cinta.Id_cinta + RecursoInterfazMod5.BotonCerrar;
                this.tabla.Text += RecursoInterfazMod5.BotonModificar + cinta.Id_cinta + RecursoInterfazMod5.BotonCerrar;
            //    this.tabla.Text += RecursoInterfazMod5.BotonDesactivarCintas + cinta.Id_cinta + RecursoInterfazMod5.BotonCerrar;

                if (cinta.Status)
                    this.tabla.Text += RecursoInterfazMod5.BotonActivarCinta + cinta.Id_cinta + RecursoInterfazMod5.BotonCerrar;
                else
                    this.tabla.Text += RecursoInterfazMod5.BotonDesactivarCinta + cinta.Id_cinta + RecursoInterfazMod5.BotonCerrar;           
                this.tabla.Text += RecursoInterfazMod5.CerrarTD;
                this.tabla.Text += RecursoInterfazMod5.CerrarTR;
            }
        }

    }
}