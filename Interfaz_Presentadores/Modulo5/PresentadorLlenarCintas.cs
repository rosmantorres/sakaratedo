using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaz_Contratos.Modulo5;
using LogicaNegociosSKD.Fabrica;
using LogicaNegociosSKD.Comandos.Modulo5;
using LogicaNegociosSKD;
using DominioSKD;
using ExcepcionesSKD.Modulo5;


namespace Interfaz_Presentadores.Modulo5
{
    public class PresentadorLlenarCintas
    {

        private IContratoListarCintas vista;
 
        public PresentadorLlenarCintas(IContratoListarCintas vista)
        {
            this.vista = vista;
        }

        /// <summary>
        /// Método para ejecutar el comando ConsultarTodasCinta y obtener la lista de cintas
        /// </summary>
        public void LlenarInformacion()
        {

            FabricaComandos _fabrica = new FabricaComandos();
            Comando<List<Entidad>> _comando = _fabrica.ObtenerEjecutarConsultarTodosCinta();
            List<Entidad> _miLista = _comando.Ejecutar();
      
            
            if (_miLista != null)
                this.llenarVista(_miLista);
            else
            {
                throw new ExcepcionesSKD.Modulo5.ListaVaciaExcepcion(RecursoPresentadorM5.Codigo_Error_Lista_Vacia,
                                   RecursoPresentadorM5.Mensaje_Error_Lista_Vacia, new Exception());
            }
       }

        /// <summary>
        /// Método para llenar la vista (tabla) con la lista de cintas
        /// </summary>
        private void llenarVista(List<Entidad> lista)
        {
            foreach (Entidad entidad in lista)
            {
                DominioSKD.Entidades.Modulo5.Cinta cinta = (DominioSKD.Entidades.Modulo5.Cinta)entidad;
                this.vista.llenarId(cinta.Id_cinta.ToString());
                this.vista.llenarColorNombre(cinta.Color_nombre);
                this.vista.llenarRango(cinta.Rango);
                this.vista.llenarClasificacion(cinta.Clasificacion);
                this.vista.llenarSignificado(cinta.Significado);
                this.vista.llenarOrden(cinta.Orden);
                this.vista.llenarOrganizacion(cinta.Organizacion.Nombre);
                this.vista.llenarBotones(cinta.Id_cinta);
                if (cinta.Status)
                    this.vista.llenarStatusActivo(cinta.Id_cinta);
                else
                    this.vista.llenarStatusInactivo(cinta.Id_cinta);

            }
        }
    }
}
