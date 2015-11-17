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

    }
            
}
