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
using DominioSKD.Fabrica;


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
            try
            {
                DominioSKD.Entidades.Modulo3.Organizacion laOrg = (DominioSKD.Entidades.Modulo3.Organizacion)FabricaEntidades.ObtenerOrganizacion_M3();
                laOrg.Id_organizacion = Int32.Parse(this.vista.obtenerIdOrg);

                Comando<List<Entidad>> _comando = FabricaComandos.ObtenerEjecutarConsultarCintaXOrganizacion(laOrg);
                List<Entidad> _miLista = _comando.Ejecutar();
                this.llenarVista(_miLista);
            }
            catch (ExcepcionesSKD.Modulo5.ListaVaciaExcepcion ex){
                throw ex;
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

        public void llenarComboOrganizacion()
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
        /// 
        /// </summary>
        public void cambiarStatus()
        {
            DominioSKD.Entidades.Modulo5.Cinta laCinta = (DominioSKD.Entidades.Modulo5.Cinta)FabricaEntidades.ObtenerCinta_M5();

            laCinta.Id_cinta = this.vista.obtenerIdCinta;
            DominioSKD.Entidades.Modulo3.Organizacion laOrg = (DominioSKD.Entidades.Modulo3.Organizacion)FabricaEntidades.ObtenerOrganizacion_M3();
            laOrg.Nombre = this.vista.obtenerNombreOrg;
            laCinta.Organizacion = laOrg;

            Comando<bool> _comando = FabricaComandos.ObtenerEjecutarModificarStatusCinta(laCinta);
            bool _resultado = _comando.Ejecutar();
           
        }


        /// <summary>
        /// Método para asiganar la informacion en el Combo con las organizaciones 
        /// </summary>
        private void asignarInformacionCombo(List<Entidad> listaOrganizaciones)
        {

            //this.vista.agregarOrganizacionCombo(RecursoPresentadorM5.valorNulo, RecursoPresentadorM5.opcionDefecto);
            foreach (Entidad entidad in listaOrganizaciones)
            {
                DominioSKD.Entidades.Modulo3.Organizacion org = (DominioSKD.Entidades.Modulo3.Organizacion)entidad;

                this.vista.agregarOrganizacionCombo(org.Id_organizacion.ToString(), org.Nombre);

            }
            //this.vista.agregarOrganizacionCombo(RecursoPresentadorM5.valorOtro, RecursoPresentadorM5.opcionOtro);

        }

    }
}
