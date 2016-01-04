using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfaz_Contratos.Modulo16;
using DominioSKD.Entidades.Modulo15;
using DominioSKD.Entidades.Modulo16;
using DominioSKD.Fabrica;
using DominioSKD;
using LogicaNegociosSKD.Fabrica;
using LogicaNegociosSKD;
using LogicaNegociosSKD.Comandos.Modulo16;
using System.Web;
using System.Web.UI.WebControls;

namespace Interfaz_Presentadores.Modulo16
{
    public class PresentadorListarProducto
    {
        // Definir las variables session del dojo
        private IContratoListarProducto vista;
        /// <summary>
        /// Constructor del presentador
        /// </summary>
        /// <param name="laVista">instancia de la vista</param>
        public PresentadorListarProducto(IContratoListarProducto laVista)
        {
            vista = laVista;
        }
        /// <summary>
        /// metodo para consultar la lista de los Productos
        /// </summary>
        public void consultarProductos()
        {
            try
            {
                Comando<List<Entidad>> comandoListarProductos = FabricaComandos.CrearComandoConsultarTodosProductos();

                List<Entidad> laLista = comandoListarProductos.Ejecutar();

                string tablaImplementosHTML = "";

                //Recorro La lista de los implementos en el carrito para anexarlas al GRIDVIEW
                foreach (Implemento c in laLista)
                {
                    tablaImplementosHTML += M16_Recursointerfaz.ABRIR_TR + '"' + c.Id_Implemento.ToString() + '"' + ">";
                    tablaImplementosHTML += M16_Recursointerfaz.ABRIR_TR + '"' + c.Dojo_Implemento.Nombre_dojo.ToString() + '"' + ">";
                    tablaImplementosHTML += M16_Recursointerfaz.ABRIR_TD + c.Nombre_Implemento.ToString() + M16_Recursointerfaz.CERRAR_TD;
                    tablaImplementosHTML += M16_Recursointerfaz.ABRIR_TD + c.Tipo_Implemento.ToString() + M16_Recursointerfaz.CERRAR_TD;
                    tablaImplementosHTML += M16_Recursointerfaz.ABRIR_TD + c.Marca_Implemento.ToString() + M16_Recursointerfaz.CERRAR_TD;
                    tablaImplementosHTML += M16_Recursointerfaz.ABRIR_TD + c.Precio_Implemento.ToString() + M16_Recursointerfaz.CERRAR_TD;
                    tablaImplementosHTML += M16_Recursointerfaz.ABRIR_TD + c.Cantida_implemento.ToString() + M16_Recursointerfaz.CERRAR_TD;
                    tablaImplementosHTML += M16_Recursointerfaz.ABRIR_TD + c.Dojo_Implemento.Nombre_dojo.ToString() + M16_Recursointerfaz.CERRAR_TD;

                    tablaImplementosHTML += M16_Recursointerfaz.ABRIR_TD;
                    tablaImplementosHTML += M16_Recursointerfaz.COMBOCANTIDAD + c.Id_Implemento.ToString() + "_combo" + M16_Recursointerfaz.CERRAR_COMBO;
                    tablaImplementosHTML += M16_Recursointerfaz.CERRAR_TD;
                    tablaImplementosHTML += M16_Recursointerfaz.ABRIR_TD;
                    tablaImplementosHTML += M16_Recursointerfaz.BOTON_INFO_EVENTO + c.Id_Implemento + M16_Recursointerfaz.BOTON_CERRAR;
                    tablaImplementosHTML += M16_Recursointerfaz.BOTON_AGREGAR_EVENTO_CARRITO + c.Id_Implemento + "_" + c.Precio_Implemento + M16_Recursointerfaz.BOTON_CERRAR;
                    tablaImplementosHTML += M16_Recursointerfaz.CERRAR_TD;
                    tablaImplementosHTML += M16_Recursointerfaz.CERRAR_TR;


                }

                vista.tablaProductos.Text = tablaImplementosHTML;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
