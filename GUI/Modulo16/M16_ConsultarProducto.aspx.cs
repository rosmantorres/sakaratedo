using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioSKD;
using LogicaNegociosSKD;
using LogicaNegociosSKD.Modulo16;
using System.Web.Script.Serialization;

namespace templateApp.GUI.Modulo16
{
    public partial class M16_ConsultarProducto : System.Web.UI.Page
    {
        private List<Implemento> laLista = new List<Implemento>();
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "16";

            String detalleString = Request.QueryString["impDetalle"];
            String usuario = Request.QueryString["compAgregar"];
            String producto = Request.QueryString["compAgregar"];

            if (detalleString != null)
            {
                llenarModalInfo(int.Parse(detalleString));
            }

            if (usuario != null && producto != null)
            {
                agregarImplementoAcarrito(1, 1);
            }

            #region Llenar Data Table Con Inventario
            //Instancio la logica correspondiente
            Logicainventario logComp = new Logicainventario();
            if (!IsPostBack)
            {
                try
                {
                    //me traigo los implementos disponibles
                    laLista = logComp.obtenerListaDeInventario();

                    //Recorro La lista de los implementos en el carrito para anexarlas al GRIDVIEW
                    foreach (Implemento c in laLista)
                    {
                        //Creo la fila de la tabla
                        this.laTabla.Text += M16_Recursointerfaz.ABRIR_TR;

                        //Agrego los datos correspondientes de la tabla
                        this.laTabla.Text += M16_Recursointerfaz.ABRIR_TD;
                        this.laTabla.Text += M16_Recursointerfaz.ABRIR_TD + c.Id_Implemento.ToString() 
                            + M16_Recursointerfaz.CERRAR_TD;
                        this.laTabla.Text += M16_Recursointerfaz.ABRIR_TD + c.Imagen_implemento.ToString() 
                            + M16_Recursointerfaz.CERRAR_TD;
                        this.laTabla.Text += M16_Recursointerfaz.ABRIR_TD + c.Nombre_Implemento.ToString()
                            + M16_Recursointerfaz.CERRAR_TD;
                        this.laTabla.Text += M16_Recursointerfaz.ABRIR_TD + c.Marca_Implemento.ToString() 
                            + M16_Recursointerfaz.CERRAR_TD;
                        this.laTabla.Text += M16_Recursointerfaz.ABRIR_TD + c.Tipo_Implemento.ToString() 
                            + M16_Recursointerfaz.CERRAR_TD;
                        this.laTabla.Text += M16_Recursointerfaz.ABRIR_TD + c.Precio_Implemento.ToString() 
                            + M16_Recursointerfaz.CERRAR_TD;

                        //Agrego los botones
                        this.laTabla.Text += M16_Recursointerfaz.ABRIR_TD;
                        this.laTabla.Text += M16_Recursointerfaz.BOTON_INFO_PRODUCTO + c.Id_Implemento 
                            + M16_Recursointerfaz.BOTON_CERRAR;
                        this.laTabla.Text += M16_Recursointerfaz.BOTON_AGREGAR_IMPLEMENTO_CARRITO + c.Id_Implemento 
                            + M16_Recursointerfaz.BOTON_CERRAR;
                        this.laTabla.Text += M16_Recursointerfaz.CERRAR_TD;

                        //Cierro la fila creada
                        this.laTabla.Text += M16_Recursointerfaz.CERRAR_TR;
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            #endregion
            /*
            //Nos indica si hubo alguna accion de agregar, registrar pago o eliminar
            String accion = Request.QueryString["accion"];
            switch (accion)
            {
                //Si se viene de un agregar se procedera a mostrar la alerta correspondiente
                case "1":
                    //Obtenemos el ID del implemento
                    String exito = Request.QueryString["id"];

                    //Si el Agregar fue exitoso o no se procedera dar la alerta correspondiente
                    if (exito.Equals("1"))
                    {
                        //Limpiamos y mostramos la informacion
                        alert.Attributes["class"] = "alert alert-success alert-dismissible";
                        alert.Attributes["role"] = "alert";
                        alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                            "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>El pago se ha" +
                            " realizado exitosamente</div>";
                    }
                    else
                    {
                        //Si el agregar fue fallido mostramos la alerta
                        alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                        alert.Attributes["role"] = "alert";
                        alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                            "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>El pago no se ha" +
                            " realizado exitosamente</div>";
                    }
                break;
            }*/                
        }

        #region Llamada para el Detalle del Implemento por id
        protected void llenarModalInfo(int Id_implemento)
        {
            Implemento laCompetencia = new Implemento();
            Logicainventario logica = new Logicainventario();
            laCompetencia = logica.detalleImplementoXId(Id_implemento);
        }
        #endregion

        #region Llenado del Modal de Informacion del producto
        [System.Web.Services.WebMethod]
        public static string prueba(string id)
        {
            Implemento laCompetencia = new Implemento();
            Logicainventario logica = new Logicainventario();
            laCompetencia = logica.detalleImplementoXId(int.Parse(id));
            string json = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(laCompetencia);
            return json;
        }
        #endregion


        #region Llenado del Modal para agregar el producto al carrito
        [System.Web.Services.WebMethod]
        protected void agregarImplementoAcarrito(int usuario, int idImplemento)
        {
            bool agregar = false;
            Logicacarrito logica = new Logicacarrito();
            agregar = logica.agregarInventarioaCarrito(usuario, idImplemento, 1, 2);
        }
        #endregion
    }
}