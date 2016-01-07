using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfaz_Contratos.Modulo16;
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
    public class PresentadorListarFactura
    {
        private IContratoListarFactura vista;
        /// <summary>
        /// Constructor del presentador
        /// </summary>
        /// <param name="laVista">instancia de la vista</param>
         public PresentadorListarFactura(IContratoListarFactura laVista)
        {
            vista = laVista;
        }

         /// <summary>
         /// metodo para consultar las facturas
         /// </summary>
         public void consultarFacturas(int persona)
         {
             try
             {
                 Comando<Entidad> comandoListarFacturas = FabricaComandos.CrearComandoConsultarTodasFacturas();

                 PersonaM1 param = new PersonaM1();
                 param._Id = persona;

                 comandoListarFacturas.LaEntidad = param;

                 ListaCompra com = (ListaCompra)comandoListarFacturas.Ejecutar();

                 string tablaFacturasHTML = "";

                 //Recorro La lista de las facturas para anexarlas al GRIDVIEW
                 foreach (Compra c in com.ListaCompras)
                 {
                     tablaFacturasHTML += M16_Recursointerfaz.ABRIR_TR + '"' + c.Com_id.ToString() + '"' + ">";
                     tablaFacturasHTML += M16_Recursointerfaz.ABRIR_TD + c.Com_id.ToString() + M16_Recursointerfaz.CERRAR_TD;
                     tablaFacturasHTML += M16_Recursointerfaz.ABRIR_TD + c.Com_tipo_pago.ToString() + M16_Recursointerfaz.CERRAR_TD;
                     tablaFacturasHTML += M16_Recursointerfaz.ABRIR_TD + c.Com_fecha_compra.ToString() + M16_Recursointerfaz.CERRAR_TD;
                     tablaFacturasHTML += M16_Recursointerfaz.ABRIR_TD + c.Com_estado.ToString() + M16_Recursointerfaz.CERRAR_TD;

                     tablaFacturasHTML += M16_Recursointerfaz.ABRIR_TD;
                     tablaFacturasHTML += M16_Recursointerfaz.BOTON_IMPRIMIR_FACTURA + c.Com_id + M16_Recursointerfaz.BOTON_CERRAR;
                     tablaFacturasHTML += M16_Recursointerfaz.BOTON_INFO_EVENTO + c.Com_id + M16_Recursointerfaz.BOTON_CERRAR;
                     tablaFacturasHTML += M16_Recursointerfaz.CERRAR_TD;

                     tablaFacturasHTML += M16_Recursointerfaz.CERRAR_TR;


                 }

                 vista.tablaFacturas.Text = tablaFacturasHTML;


             }
             catch (Exception ex)
             {
                 throw ex;
             }
         }
    }
}
