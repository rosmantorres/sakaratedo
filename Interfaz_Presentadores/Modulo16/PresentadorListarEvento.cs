using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfaz_Contratos.Modulo16;
using DominioSKD.Entidades.Modulo9;
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
    public class PresentadorListarEvento
    {
        private IContratoListarEvento vista;
        /// <summary>
        /// Constructor del presentador
        /// </summary>
        /// <param name="laVista">instancia de la vista</param>
        public PresentadorListarEvento(IContratoListarEvento laVista)
        {
            vista = laVista;
        }
        /// <summary>
        /// metodo para consultar la lista de los Eventos
        /// </summary>
        public void consultarEventos()
        {
            try
            {
                Comando<List<Entidad>> comandoListarEventos = FabricaComandos.CrearComandoConsultarTodosEventos();

                List<Entidad> laLista = comandoListarEventos.Ejecutar();

                string tablaEventosHTML = "";

                //Recorro La lista de los eventos en el carrito para anexarlas al GRIDVIEW
                foreach (Evento c in laLista)
                {
                    tablaEventosHTML += M16_Recursointerfaz.ABRIR_TR + '"' + c.Id_evento.ToString() + '"' + ">";
                    tablaEventosHTML += M16_Recursointerfaz.ABRIR_TD + c.Nombre.ToString() + M16_Recursointerfaz.CERRAR_TD;
                    tablaEventosHTML += M16_Recursointerfaz.ABRIR_TD + c.Descripcion.ToString() + M16_Recursointerfaz.CERRAR_TD;
                    tablaEventosHTML += M16_Recursointerfaz.ABRIR_TD + c.Costo.ToString() + M16_Recursointerfaz.CERRAR_TD;

                    tablaEventosHTML += M16_Recursointerfaz.ABRIR_TD;
                    tablaEventosHTML += M16_Recursointerfaz.COMBOCANTIDAD + c.Id_evento.ToString() + "_combo" + M16_Recursointerfaz.CERRAR_COMBO;
                    tablaEventosHTML += M16_Recursointerfaz.CERRAR_TD;
                    tablaEventosHTML += M16_Recursointerfaz.ABRIR_TD;
                    tablaEventosHTML += M16_Recursointerfaz.BOTON_INFO_EVENTO + c.Id_evento + M16_Recursointerfaz.BOTON_CERRAR;
                    tablaEventosHTML += M16_Recursointerfaz.BOTON_AGREGAR_EVENTO_CARRITO + c.Id_evento + "_" + c.Costo + M16_Recursointerfaz.BOTON_CERRAR;
                    tablaEventosHTML += M16_Recursointerfaz.CERRAR_TD;
                    tablaEventosHTML += M16_Recursointerfaz.CERRAR_TR;


                }

                vista.tablaEventos.Text = tablaEventosHTML;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
