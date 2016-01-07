using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfaz_Contratos.Modulo16;
using DominioSKD.Entidades.Modulo6;
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
   public class PresentadorListarMensualidad
    {
        private IContratoListarMensualidad vista;
        /// <summary>
        /// Constructor del presentador
        /// </summary>
        /// <param name="laVista">instancia de la vista</param>
        public PresentadorListarMensualidad(IContratoListarMensualidad laVista)
        {
            vista = laVista;
        }

        /// <summary>
        /// metodo para consultar las facturas
        /// </summary>
        public void consultarMensualidades(int persona)
        {
            try
            {
                Comando<Entidad> comandoListarMensualidades = FabricaComandos.CrearComandoConsultarTodasMensualidades();

                PersonaM1 param = new PersonaM1();
                param._Id = persona;

                comandoListarMensualidades.LaEntidad = param;

                ListaMatricula com = (ListaMatricula)comandoListarMensualidades.Ejecutar();

                string tablaMatriculasHTML = "";

                //Recorro La lista de las Mensualidades para anexarlas al GRIDVIEW
                foreach (Matricula c in com.ListaMatriculas)
                {
                    tablaMatriculasHTML += M16_Recursointerfaz.ABRIR_TR + '"' + c.Id.ToString() + '"' + ">";
                    tablaMatriculasHTML += M16_Recursointerfaz.ABRIR_TD + c.Id.ToString() + M16_Recursointerfaz.CERRAR_TD;
                    tablaMatriculasHTML += M16_Recursointerfaz.ABRIR_TD + c.Identificador.ToString() + M16_Recursointerfaz.CERRAR_TD;
                    tablaMatriculasHTML += M16_Recursointerfaz.ABRIR_TD + c.Costo.ToString() + M16_Recursointerfaz.CERRAR_TD;
                    tablaMatriculasHTML += M16_Recursointerfaz.ABRIR_TD + c.UltimaFechaPago.ToString() + M16_Recursointerfaz.CERRAR_TD;
                    tablaMatriculasHTML += M16_Recursointerfaz.ABRIR_TD + c.Mes.ToString() + M16_Recursointerfaz.CERRAR_TD;
                    tablaMatriculasHTML += M16_Recursointerfaz.ABRIR_TD + c.Anio.ToString() + M16_Recursointerfaz.CERRAR_TD;

                    tablaMatriculasHTML += M16_Recursointerfaz.ABRIR_TD;
                    tablaMatriculasHTML += M16_Recursointerfaz.BOTON_IMPRIMIR_FACTURA + c.Id + M16_Recursointerfaz.BOTON_CERRAR;
                    tablaMatriculasHTML += M16_Recursointerfaz.BOTON_INFO_EVENTO + c.Id + M16_Recursointerfaz.BOTON_CERRAR;
                    tablaMatriculasHTML += M16_Recursointerfaz.CERRAR_TD;

                    tablaMatriculasHTML += M16_Recursointerfaz.CERRAR_TR;


                }

                vista.tablaMensualidades.Text = tablaMatriculasHTML;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
