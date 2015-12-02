using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioSKD;
using LogicaNegociosSKD;
using LogicaNegociosSKD.Modulo16;
using templateApp.GUI.Master;


namespace templateApp.GUI.Modulo16
{
    public partial class M16_ListarFacturas : System.Web.UI.Page
    {
        private List<Compra> laLista = new List<Compra>();
        public static int usuario = 0;
         
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "16";

            M16_ListarFacturas.usuario = int.Parse(Session[RecursosInterfazMaster.sessionUsuarioID].ToString()); 

            String detalleString = Request.QueryString["impDetalle"];

            if (detalleString != null)
            {
               // MetodoM14ListarFacturas(int.Parse(detalleString));
            }

            #region Llenar Data Table Con Facturas del Usuario 

            Logicacompra logComp = new Logicacompra();
            if (!IsPostBack)
            {
                try
                {
                    laLista = logComp.obtenerListaDeCompra(usuario);
                    foreach (Compra c in laLista)
                    {
                        this.laTabla.Text += M16_Recursointerfaz.ABRIR_TR;
                        this.laTabla.Text += M16_Recursointerfaz.ABRIR_TD;

                        this.laTabla.Text += M16_Recursointerfaz.ABRIR_TD + c.Com_id.ToString() + M16_Recursointerfaz.CERRAR_TD;
                        this.laTabla.Text += M16_Recursointerfaz.ABRIR_TD + c.Com_tipo_pago.ToString() + M16_Recursointerfaz.CERRAR_TD;
                        this.laTabla.Text += M16_Recursointerfaz.ABRIR_TD + c.Com_fecha_compra.ToString() + M16_Recursointerfaz.CERRAR_TD;
                        this.laTabla.Text += M16_Recursointerfaz.ABRIR_TD + c.Com_estado.ToString() + M16_Recursointerfaz.CERRAR_TD;
                        this.laTabla.Text += M16_Recursointerfaz.ABRIR_TD;

                        this.laTabla.Text += M16_Recursointerfaz.BOTON_IMPRIMIR_FACTURA + c.Com_id + M16_Recursointerfaz.BOTON_CERRAR;
                        this.laTabla.Text += M16_Recursointerfaz.CERRAR_TD;
                        this.laTabla.Text += M16_Recursointerfaz.CERRAR_TR;
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