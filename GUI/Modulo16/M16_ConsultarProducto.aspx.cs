using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaNegociosSKD.Modulo16;
using DominioSKD;


namespace templateApp.GUI.Modulo16
{
    public partial class M16_ConsultarProducto : System.Web.UI.Page
    {
        private List<Inventario> laLista = new List<Inventario>();
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "16";
        

        #region Llenar Data Table Con Productos - Inventario

            Logicainventario logComp = new Logicainventario();
            if (!IsPostBack)
            {
                try
                {
                    //laLista = logComp.obtenerListaDeInventario();

                    foreach (Inventario c in laLista)
                    {
                        /*
                        //this.laTabla.Text += Recursointerfaz.AbrirTR;
                        */
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        #endregion

    }
}