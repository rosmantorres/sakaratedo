using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioSKD;
using LogicaNegociosSKD.Modulo16;
using templateApp.GUI.Master;

namespace templateApp.GUI.Modulo16
{
    /// <summary>
    /// Code Behind de VerCarrito.aspx
    /// </summary>
    public partial class M16_VerCarrito : System.Web.UI.Page
    {
        /// <summary>
        /// Atributos de la clase
        /// </summary>
        public Carrito carritoCompras;
        public Logicacarrito logicaCarrito;
        public static int usuario = 0;

        /// <summary>
        /// Metodo que carga las configuraciones por defecto y opciones especiales de su ventana correspondiente
        /// </summary>
        /// <param name="sender">Objeto que ejecuta esta accion</param>
        /// <param name="e">Clase base para las clases que contienen la informacion del evento</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "16";

            //Obtengo el ID del usuario
            M16_VerCarrito.usuario = int.Parse(Session[RecursosInterfazMaster.sessionUsuarioID].ToString()); 

            //Si estoy entrando por primera vez lleno la tabla
            if (!IsPostBack)
            {
                try
                {
                    //Lleno la tabla
                    Llenartabla();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }

            //Nos indica si hubo alguna accion de agregar, registrar pago o eliminar
            String accion = Request.QueryString["accion"];
            switch (accion)
            {
                //Si se viene de un registrar pago se procedera a mostrar la alerta correspondiente
                case "2":
                    //Obtenemos el exito o fallo del proceso
                    String exito = Request.QueryString["exito"];

                    //Si el registrar pago fue exitoso o no se procedera dar la alerta correspondiente
                    if (exito.Equals("1"))
                    {
                        //Limpiamos y mostramos la informacion
                        this.carritoCompras.limpiar();
                        alert.Attributes["class"] = "alert alert-success alert-dismissible";
                        alert.Attributes["role"] = "alert";
                        alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                            "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>El pago se ha" +
                            " realizado exitosamente</div>";
                    }
                    else
                    {
                        //Si el registrar pago fue fallido mostramos la alerta
                        alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                        alert.Attributes["role"] = "alert";
                        alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                            "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>El pago no se ha" +
                            " realizado exitosamente</div>";
                    }
                break;

                //Si se viene de un eliminar se procedera a eliminar y mostrar la alerta correspondiente
                case "3":

                    //Se obtiene el exito o fallo de la eliminacion y se evalua
                    bool respuesta = Eliminaritem();
                    if (respuesta)
                    {
                        //Si el eliminar fue exitoso mostramos esta alerta
                        alert.Attributes["class"] = "alert alert-success alert-dismissible";
                        alert.Attributes["role"] = "alert";
                        alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\""+
                            "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>El item ha sido"+ 
                            " eliminado exitosamente</div>";
                    }
                    else
                    {
                        //Si el eliminar no fue exitoso mostramos esta alerta
                        alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                        alert.Attributes["role"] = "alert";
                        alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                            "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>El item no ha"+
                            " sido eliminado</div>";
                    }
                break;
            }

        }

        #region LlenarTabla
        /// <summary>
        /// Metodo que se encarga de llenar el GRIDVIEW con todos los elementos que hayan en el carrito del Usuario
        /// </summary>
        public void Llenartabla()
        {
            //Obtengo el ID del usuario
            // Session[RecursosInterfazMaster.sessionUsuarioID] = idUsuario[0];

            //Instancio la logica correspondiente y me traigo el carrito de compras
            Logicacarrito logicaCarrito = new Logicacarrito();
            carritoCompras = logicaCarrito.verCarrito(usuario);

            //Recorro La lista de los implementos en el carrito para anexarlas al GRIDVIEW
            foreach (Implemento implemento in carritoCompras.ListaImplemento)
            {
                //Creo la fila de la tabla
                this.laTabla1.Text += M16_Recursointerfaz.ABRIR_TR_INVENTARIO + implemento.Id_Implemento +">";

                //Agrego los datos correspondientes de la tabla
                this.laTabla1.Text += M16_Recursointerfaz.ABRIR_TD + implemento.Imagen_implemento + 
                    M16_Recursointerfaz.CERRAR_TD;
                this.laTabla1.Text += M16_Recursointerfaz.ABRIR_TD + implemento.Nombre_Implemento + 
                    M16_Recursointerfaz.CERRAR_TD;
                this.laTabla1.Text += M16_Recursointerfaz.ABRIR_TD + implemento.Precio_Implemento + 
                    M16_Recursointerfaz.CERRAR_TD;

                //     this.laTabla1.Text += M16_Recursointerfaz.ABRIR_TD + inventario.Marca + M16_Recursointerfaz.CERRAR_TD;
               // this.laTabla1.Text += M16_Recursointerfaz.ABRIR_TD + inventario.Tipo + M16_Recursointerfaz.CERRAR_TD;
                

                //Agrego los botones
                this.laTabla1.Text += M16_Recursointerfaz.ABRIR_TD;

                //ARREGLAR BOTON INFO!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                this.laTabla1.Text += M16_Recursointerfaz.BOTON_INFO_PRODUCTO + implemento.Id_Implemento+ 
                    M16_Recursointerfaz.BOTON_CERRAR;
                this.laTabla1.Text += M16_Recursointerfaz.BOTON_ELIMINAR_ACCION_IMPLEMENTO + implemento.Id_Implemento +
                    M16_Recursointerfaz.BOTON_CERRAR;
                this.laTabla1.Text += M16_Recursointerfaz.CERRAR_TD;

                //Cierro la fila creada
                this.laTabla1.Text += M16_Recursointerfaz.CERRAR_TR;
            }
            /*
            //Recorro la lista de las matriculas en el carrito para anexarlas al GRIDVIEW
            foreach (Matricula matricula in carritoCompras.Listamatricula)
            {
                //Creo la fila de la tabla
                this.laTabla2.Text += M16_Recursointerfaz.ABRIR_TR_MATRICULA + +">";

                //Agrego los datos correspondientes de la tabla con sus botones
                this.laTabla2.Text += M16_Recursointerfaz.ABRIR_TD + "foto" + M16_Recursointerfaz.CERRAR_TD;
                this.laTabla2.Text += M16_Recursointerfaz.ABRIR_TD + "Nombre" + M16_Recursointerfaz.CERRAR_TD;
                this.laTabla2.Text += M16_Recursointerfaz.ABRIR_TD + "256 Bs." + M16_Recursointerfaz.CERRAR_TD;
                this.laTabla2.Text += M16_Recursointerfaz.ABRIR_TD + "2" + M16_Recursointerfaz.CERRAR_TD;
                this.laTabla2.Text += M16_Recursointerfaz.ABRIR_TD + "512 Bs." + M16_Recursointerfaz.CERRAR_TD;

                //Agrego los botones
                this.laTabla2.Text += M16_RecursoInterfaz.AbrirTD;
              //Arreglar el boton info
                this.laTabla2.Text += M16_RecursoInterfaz.BotonInfo + c.Id_competencia + M12_RecursoInterfaz.BotonCerrar;
                this.laTabla2.Text += M16_RecursoInterfaz.BOTON_ELIMINAR_ACCION_MATRICULA + c.Id_competencia + M12_RecursoInterfaz.BotonCerrar;
                this.laTabla2.Text += M16_RecursoInterfaz.CerrarTD;

                //Cierro la fila creada
                this.laTabla2.Text += M12_RecursoInterfaz.CerrarTR;
            }*/

            //Recorro la lista de eventos en el carrito para anexarlas al GRIDVIEW
            foreach (Evento evento in carritoCompras.Listaevento)
            {
                //Creo la fila de la tabla
                this.laTabla3.Text += M16_Recursointerfaz.ABRIR_TR_EVENTO + evento.Id_evento +">";

                //Agrego los datos correspondientes de la tabla con sus botones
                this.laTabla3.Text += M16_Recursointerfaz.ABRIR_TD + evento.Nombre + M16_Recursointerfaz.CERRAR_TD;
                this.laTabla3.Text += M16_Recursointerfaz.ABRIR_TD + evento.Costo + M16_Recursointerfaz.CERRAR_TD;
                

                //Agrego los botones
                this.laTabla3.Text += M16_Recursointerfaz.ABRIR_TD;
                //Arreglar el boton info
                this.laTabla3.Text += M16_Recursointerfaz.BOTON_INFO_EVENTO_CARRITO + evento.Id_evento + M16_Recursointerfaz.BOTON_CERRAR;
                this.laTabla3.Text += M16_Recursointerfaz.BOTON_ELIMINAR_ACCION_EVENTO + evento.Id_evento + 
                    M16_Recursointerfaz.BOTON_CERRAR;
                this.laTabla3.Text += M16_Recursointerfaz.CERRAR_TD;

                //Cierro la fila creada
                this.laTabla3.Text += M16_Recursointerfaz.CERRAR_TR;

            }

        }
        #endregion

        #region Llenar Modales de Implemento y Evento 

                #region Llamada para el Detalle del Implemento por id
                protected void llenarModalInfoImplemento(int Id_implemento)
                {
                    Implemento elProducto = new Implemento();
                    Logicainventario logica = new Logicainventario();
                    elProducto = logica.detalleImplementoXId(Id_implemento);
                }
                #endregion


                #region Llamada para el Detalle del Evento por id
                protected void llenarModalInfoEvento(int Id_evento)
                {
                    Evento elEvento = new Evento();
                    Logicaevento logica = new Logicaevento();
                    elEvento = logica.detalleEventoXId(Id_evento);
                }
                
                #endregion

        #endregion

        #region Pintar la informacion en el modal

                #region Llenado del Modal de Informacion del Implemento
                [System.Web.Services.WebMethod]
                public static string pruebaImplemento(string id)
                {
                    Implemento elProducto = new Implemento();
                    Logicainventario logica = new Logicainventario();
                    elProducto = logica.detalleImplementoXId(int.Parse(id));
                    string json = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(elProducto);
                    return json;
                }
                #endregion

                #region Llenado del Modal de Informacion del evento
                [System.Web.Services.WebMethod]
                public static string pruebaEvento(string id)
                {
                    Evento elEvento = new Evento();
                    Logicaevento logica = new Logicaevento();
                    elEvento = logica.detalleEventoXId(int.Parse(id));
                    string json = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(elEvento);
                    return json;
                }
                #endregion

        #endregion

        #region Eliminar y Registrar
                /// <summary>
        /// Metodo que se encarga de eliminar un item determinado del carrito
        /// </summary>
        /// <returns>El exito o fallo del proceso</returns>
        public bool Eliminaritem()
        {
            //Obtenemos el tipo de item al que nos estamos refiriendo
            String item = Request.QueryString["item"];
            int tipoObjeto = 0;
            if (item.Equals("I"))
                tipoObjeto = 1;
            else if (item.Equals("M"))
                tipoObjeto = 2;
            else
                tipoObjeto = 3;

            //Obtenemos el id del objeto a borrar
            int objetoBorrar = int.Parse(Request.QueryString["id"]);

            //Obtengo el ID del usuario
            int idUsuario = (int)(Session[RecursosInterfazMaster.sessionUsuarioID]);

            //Ejecutamos el proceso de eliminar item y evaluamos su exito o fallo
            bool respuesta = logicaCarrito.eliminarItem(tipoObjeto, objetoBorrar, idUsuario);

            if (respuesta)
                this.carritoCompras.eliminarItem(tipoObjeto, objetoBorrar);

            //Retornamos la respuesta
            return respuesta;

        }

        /// <summary>
        /// Metodo que se encarga de efectuar el pago de los productos en el carrito
        /// </summary>

        protected void registrarPago(object sender, EventArgs e)
        {
            //Lista que almacenara los datos correspondientes segun el tipo de pago
            List<int> datosPago = new List<int>();

            //Si se ha elegido un tipo de pago correcto
            if(!DropDownList1.Value.Equals("-1"))
            {
                //Si se ha elegido tarjeta se procede a guardar sus datos
                if (DropDownList1.Equals("1"))
                {
                    datosPago.Add(int.Parse(Text1.Value));
                    datosPago.Add(int.Parse(Text2.Value));
                    datosPago.Add(int.Parse(Text3.Value));
                    datosPago.Add(int.Parse(Text4.Value));
                }
                //Si se ha elegido deposito se procede a guardar sus datos
                else if (DropDownList1.Equals("2"))
                {
                    datosPago.Add(int.Parse(Text5.Value));
                    datosPago.Add(int.Parse(Text6.Value));
                    datosPago.Add(int.Parse(Text7.Value));
                }
                //Si se ha elegido transferencia se procede a guardar sus datos
                else
                {
                    datosPago.Add(int.Parse(Text8.Value));
                    datosPago.Add(int.Parse(Text9.Value));
                    datosPago.Add(int.Parse(Text10.Value));
                }

                //Obtengo el ID del usuario
                int idUsuario = (int)(Session[RecursosInterfazMaster.sessionUsuarioID]);

                //Se registra el pago y se obtiene el exito o fallo
                bool exito = this.logicaCarrito.registrarPago(int.Parse(DropDownList1.Value), datosPago, idUsuario);

                //Analizamos las condiciones
                if (exito)
                {
                    //Si se pudo registrar el pago
                    HttpContext.Current.Response.Redirect("M16_VerCarrito.aspx?accion=2&exito=1");
                }
                else
                    //Si no se pudo registrar el pago
                    HttpContext.Current.Response.Redirect("M16_VerCarrito.aspx?accion=2&exito=0");
            }
        }
        #endregion

    }
            
}
