using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioSKD;
using LogicaNegociosSKD.Modulo16;

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

        /// <summary>
        /// Metodo que carga las configuraciones por defecto y opciones especiales de su ventana correspondiente
        /// </summary>
        /// <param name="sender">Objeto que ejecuta esta accion</param>
        /// <param name="e">Clase base para las clases que contienen la informacion del evento</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "16";

            //Si estoy entrando por primera vez lleno la tabla
            if (!IsPostBack)
            {
                try
                {
                    //Lleno la tabla
                    //    Llenartabla();
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
                    string exito = Request.QueryString["exito"];

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
                    //Ejecutamos el proceso de eliminar item y evaluamos su exito o fallo
                    bool respuesta = logicaCarrito.eliminarItem(1, 1, 1);
                    if (respuesta)
                    {
                        //Si el eliminar fue exitoso mostramos esta alerta y eliminamos del carrito en la clase
                        this.carritoCompras.eliminarItem(1, 1);
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

        /*
        /// <summary>
        /// Metodo que se encarga de llenar el GRIDVIEW con todos los elementos que hayan en el carrito del Usuario
        /// </summary>
        public void Llenartabla()
        {
            //Instancio la logica correspondiente y me traigo el carrito de compras
            Logicacarrito logicaCarrito = new Logicacarrito();
            carritoCompras = logicaCarrito.verCarrito(0);

            //Recorro La lista de los inventarios en el carrito para anexarlas al GRIDVIEW
            foreach (Inventario inventario in carritoCompras.Listainventario)
            {
                //Creo la fila de la tabla
                this.laTabla1.Text += M16_Recursointerfaz.ABRIR_TR_INVENTARIO + +">";

                //Agrego los datos correspondientes de la tabla con sus botones
                this.laTabla1.Text += M16_Recursointerfaz.ABRIR_TD + "foto" + M16_Recursointerfaz.CERRAR_TD;
                this.laTabla1.Text += M16_Recursointerfaz.ABRIR_TD + "Nombre" + M16_Recursointerfaz.CERRAR_TD;
                this.laTabla1.Text += M16_Recursointerfaz.ABRIR_TD + "256 Bs." + M16_Recursointerfaz.CERRAR_TD;
                this.laTabla1.Text += M16_Recursointerfaz.ABRIR_TD + "2" + M16_Recursointerfaz.CERRAR_TD;
                this.laTabla1.Text += M16_Recursointerfaz.ABRIR_TD + "512 Bs." + M16_Recursointerfaz.CERRAR_TD;

                //Agrego los botones
                this.laTabla1.Text += M12_RecursoInterfaz.AbrirTD;
                this.laTabla1.Text += M12_RecursoInterfaz.BotonInfo + c.Id_competencia + M12_RecursoInterfaz.BotonCerrar;
                this.laTabla1.Text += M12_RecursoInterfaz.BotonModificar + c.Id_competencia + M12_RecursoInterfaz.BotonCerrar;
                this.laTabla1.Text += M12_RecursoInterfaz.BotonEliminar + c.Id_competencia + M12_RecursoInterfaz.BotonCerrar;
                this.laTabla1.Text += M12_RecursoInterfaz.CerrarTD;

                //Cierro la fila creada
                this.laTabla1.Text += M12_RecursoInterfaz.CerrarTR;
            }

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
                this.laTabla2.Text += M12_RecursoInterfaz.AbrirTD;
                this.laTabla2.Text += M12_RecursoInterfaz.BotonInfo + c.Id_competencia + M12_RecursoInterfaz.BotonCerrar;
                this.laTabla2.Text += M12_RecursoInterfaz.BotonModificar + c.Id_competencia + M12_RecursoInterfaz.BotonCerrar;
                this.laTabla2.Text += M12_RecursoInterfaz.BotonEliminar + c.Id_competencia + M12_RecursoInterfaz.BotonCerrar;
                this.laTabla2.Text += M12_RecursoInterfaz.CerrarTD;

                //Cierro la fila creada
                this.laTabla2.Text += M12_RecursoInterfaz.CerrarTR;
            }

            //Recorro la lista de eventos en el carrito para anexarlas al GRIDVIEW
            foreach (Evento evento in carritoCompras.Listaevento)
            {
                //Creo la fila de la tabla
                this.laTabla3.Text += M16_Recursointerfaz.ABRIR_TR_EVENTO + +">";

                //Agrego los datos correspondientes de la tabla con sus botones
                this.laTabla3.Text += M16_Recursointerfaz.ABRIR_TD + "foto" + M16_Recursointerfaz.CERRAR_TD;
                this.laTabla3.Text += M16_Recursointerfaz.ABRIR_TD + "Nombre" + M16_Recursointerfaz.CERRAR_TD;
                this.laTabla3.Text += M16_Recursointerfaz.ABRIR_TD + "256 Bs." + M16_Recursointerfaz.CERRAR_TD;
                this.laTabla3.Text += M16_Recursointerfaz.ABRIR_TD + "2" + M16_Recursointerfaz.CERRAR_TD;
                this.laTabla3.Text += M16_Recursointerfaz.ABRIR_TD + "512 Bs." + M16_Recursointerfaz.CERRAR_TD;

                //Agrego los botones
                this.laTabla3.Text += M12_RecursoInterfaz.AbrirTD;
                this.laTabla3.Text += M12_RecursoInterfaz.BotonInfo + c.Id_competencia + M12_RecursoInterfaz.BotonCerrar;
                this.laTabla3.Text += M12_RecursoInterfaz.BotonModificar + c.Id_competencia + M12_RecursoInterfaz.BotonCerrar;
                this.laTabla3.Text += M12_RecursoInterfaz.BotonEliminar + c.Id_competencia + M12_RecursoInterfaz.BotonCerrar;
                this.laTabla3.Text += M12_RecursoInterfaz.CerrarTD;

                //Cierro la fila creada
                this.laTabla3.Text += M12_RecursoInterfaz.CerrarTR;

            }

        }*/

        #region Eliminar y Registrar
        /// <summary>
        /// Metodo que se encarga de eliminar un item determinado del carrito
        /// </summary>
        public void Eliminaritem()
        {
                        
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

                //Se registra el pago y se obtiene el exito o fallo
                bool exito = this.logicaCarrito.registrarPago(int.Parse(DropDownList1.Value), datosPago);

                //Analizamos las condiciones
                if (exito)
                {
                    //Si se pudo registrar el pago
                    HttpContext.Current.Response.Redirect("M16_VerCarrito.aspx?accion=1&exito=1");
                }
                else
                    //Si no se pudo registrar el pago
                    HttpContext.Current.Response.Redirect("M16_VerCarrito.aspx?accion=1&exito=0");
            }
        }
        #endregion

    }
            
}
