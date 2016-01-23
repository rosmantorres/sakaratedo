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

namespace Interfaz_Presentadores.Modulo5
{
    public class PresentadorModificarCinta
    {
        private IContratoModificarCinta vista;

        public PresentadorModificarCinta(IContratoModificarCinta vista)
        {
            this.vista = vista;
        }

        /// <summary>
        /// Método para ejecutar el comando ComboOrganizaciones y ontener la lista de organizaciones
        /// </summary>
        public void llenarCombo()
        {
            try
            {
                Comando<List<Entidad>> _comando = FabricaComandos.ObtenerEjecutarComboOrganizaciones();
                List<Entidad> _miLista = _comando.Ejecutar();
                this.asignarInformacionCombo(_miLista);
            }
            catch (ExcepcionesSKD.Modulo5.ListaVaciaExcepcion ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Método para asiganar la informacion en el Combo con las organizaciones 
        /// </summary>
        private void asignarInformacionCombo(List<Entidad> listaOrganizaciones)
        {

            this.vista.agregarOrganizacionCombo(RecursoPresentadorM5.valorNulo, RecursoPresentadorM5.opcionDefecto);
            foreach (Entidad entidad in listaOrganizaciones)
            {
                DominioSKD.Entidades.Modulo3.Organizacion org = (DominioSKD.Entidades.Modulo3.Organizacion)entidad;

                this.vista.agregarOrganizacionCombo(org.Id_organizacion.ToString(), org.Nombre);

            }
            this.vista.agregarOrganizacionCombo(RecursoPresentadorM5.valorOtro, RecursoPresentadorM5.opcionOtro);

        }

        /// <summary>
        /// Método para obtener los valores de la vista y ejecutar el comando para modificar la cinta
        /// </summary>
        public void ModificarValoresCinta()
        {
            DominioSKD.Entidades.Modulo5.Cinta laCinta = new DominioSKD.Entidades.Modulo5.Cinta();
            DominioSKD.Entidades.Modulo3.Organizacion laOrganizacion = new DominioSKD.Entidades.Modulo3.Organizacion();

           try
           {
                 
            laCinta.Id_cinta = this.vista.obtenerIdCInta();
            laCinta.Color_nombre = this.vista.obtenerColorCinta();
            laCinta.Rango = this.vista.obtenerRango();
            laCinta.Clasificacion = this.vista.obtenerCategoria();
            laCinta.Significado = this.vista.obtenerSignificado();
            laCinta.Orden = this.vista.obtenerOrden();
            laOrganizacion.Id_organizacion = this.vista.obtenerIdOrganizacion();
            laOrganizacion.Nombre = this.vista.obtenerNombreOrganizacion();
            laCinta.Organizacion = laOrganizacion;

            Comando<bool> _comando = FabricaComandos.ObtenerEjecutarModificarCinta(laCinta);
            bool resultado = _comando.Ejecutar();
            if (resultado)
                this.vista.Respuesta();

           }
           catch (ExcepcionesSKD.ExceptionSKD ex)
           {
               this.vista.alertaModificarFallido(ex);
           }
        }
    }
}
