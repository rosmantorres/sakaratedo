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
    public partial class M16_ConsultarEvento : System.Web.UI.Page
    {
        private List<Evento> laLista = new List<Evento>();
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "16";

            String detalleString = Request.QueryString["impDetalle"];
            String usuario = Request.QueryString["compAgregar"];
            String evento = Request.QueryString["compAgregar"];


            if (detalleString != null)
            {
                llenarModalInfo(int.Parse(detalleString));
            }



            if (usuario != null && evento != null)
            {
                agregarEventoaCarrito(1, 1);
            }

        #region Llenar Data Table Con Evento

            Logicaevento logComp = new Logicaevento();
            if (!IsPostBack)
            {
                try
                {
                    laLista = logComp.obtenerListaDeEvento();

                    foreach (Evento c in laLista)
                    {
                        this.laTabla.Text += M16_Recursointerfaz.ABRIR_TR;
                        this.laTabla.Text += M16_Recursointerfaz.ABRIR_TD + c.Id_evento.ToString() + M16_Recursointerfaz.CERRAR_TD;
                        this.laTabla.Text += M16_Recursointerfaz.ABRIR_TD + c.Nombre.ToString() + M16_Recursointerfaz.CERRAR_TD;
                        this.laTabla.Text += M16_Recursointerfaz.ABRIR_TD + c.Costo.ToString() + M16_Recursointerfaz.CERRAR_TD;
                        this.laTabla.Text += M16_Recursointerfaz.ABRIR_TD;

                        this.laTabla.Text += M16_Recursointerfaz.BOTON_INFO_PRODUCTO + c.Id_evento + M16_Recursointerfaz.BOTON_CERRAR;
                        this.laTabla.Text += M16_Recursointerfaz.BOTON_INFO + c.Id_evento + M16_Recursointerfaz.BOTON_CERRAR;
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

        #region Llamada para el Detalle del Evento por id
        protected void llenarModalInfo(int Id_evento)
        {
            Evento elEvento = new Evento();
            Logicaevento logica = new Logicaevento();
            elEvento = logica.detalleEventoXId(Id_evento);
        }
        #endregion

        #region Llenado del Modal de Informacion del evento
        [System.Web.Services.WebMethod]
        public static string prueba(string id)
        {
            Evento elEvento = new Evento();
            Logicaevento logica = new Logicaevento();
            elEvento = logica.detalleEventoXId(int.Parse(id));
            string json = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(elEvento);
            return json;
        }
        #endregion

        #region Llenado del Modal para agregar el producto al carrito
        [System.Web.Services.WebMethod]
        protected void agregarEventoaCarrito(int usuario, int idMatricula)
        {
            bool agregar = false;
            Logicacarrito logica = new Logicacarrito();
            agregar = logica.agregarEventoaCarrito(1, 1);
        }
        #endregion




    }
}