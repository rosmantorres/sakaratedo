using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioSKD;
using LogicaNegociosSKD;
using LogicaNegociosSKD.Modulo16;

namespace templateApp.GUI.Modulo16
{
    public partial class M16_ConsultarProducto : System.Web.UI.Page
    {
        private List<Implemento> laLista = new List<Implemento>();
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "16";

            String detalleString = Request.QueryString["impDetalle"];

            if (detalleString != null)
            {
                llenarModalInfo(int.Parse(detalleString));
            }

            #region Llenar Data Table Con Inventario

            Logicainventario logComp = new Logicainventario();
            if (!IsPostBack)
            {
                try
                {
                    laLista = logComp.obtenerListaDeInventario();
                    foreach (Implemento c in laLista)
                    {
                        this.laTabla.Text += M16_Recursointerfaz.ABRIR_TR;
                        this.laTabla.Text += M16_Recursointerfaz.ABRIR_TD;

                        this.laTabla.Text += M16_Recursointerfaz.ABRIR_TD + c.Id_implemento.ToString() + M16_Recursointerfaz.CERRAR_TD;
                        this.laTabla.Text += M16_Recursointerfaz.ABRIR_TD + c.Imagen.ToString() + M16_Recursointerfaz.CERRAR_TD;
                        this.laTabla.Text += M16_Recursointerfaz.ABRIR_TD + c.Nombre.ToString() + M16_Recursointerfaz.CERRAR_TD;
                        this.laTabla.Text += M16_Recursointerfaz.ABRIR_TD + c.Marca.ToString() + M16_Recursointerfaz.CERRAR_TD;
                        this.laTabla.Text += M16_Recursointerfaz.ABRIR_TD + c.Tipo.ToString() + M16_Recursointerfaz.CERRAR_TD;
                        this.laTabla.Text += M16_Recursointerfaz.ABRIR_TD + c.Precio.ToString() + M16_Recursointerfaz.CERRAR_TD;
                        this.laTabla.Text += M16_Recursointerfaz.ABRIR_TD;

                        this.laTabla.Text += M16_Recursointerfaz.BOTON_INFO_PRODUCTO + c.Id_implemento + M16_Recursointerfaz.BOTON_CERRAR;
                        this.laTabla.Text += M16_Recursointerfaz.BOTON_INFO + c.Id_implemento + M16_Recursointerfaz.BOTON_CERRAR;
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

        #region Llenar el modal de informacion del producto
        protected void llenarModalInfo(int Id_implemento)
        {
            Implemento laCompetencia = new Implemento();
            Logicainventario logica = new Logicainventario();
            laCompetencia = logica.detalleImplementoXId(Id_implemento);
        }
        #endregion

    }
}