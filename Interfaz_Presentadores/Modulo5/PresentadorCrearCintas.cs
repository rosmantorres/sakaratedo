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
    public class PresentadorCrearCintas
    {
         private IContratoCrearCinta vista;

         public PresentadorCrearCintas(IContratoCrearCinta vista)
        {
            this.vista = vista;
        }

         /// <summary>
         /// Método para ejecutar el comando ComboOrganizaciones
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
            foreach(Entidad entidad in listaOrganizaciones)
            {
                DominioSKD.Entidades.Modulo3.Organizacion org = (DominioSKD.Entidades.Modulo3.Organizacion)entidad;

                this.vista.agregarOrganizacionCombo(org.Id_organizacion.ToString(), org.Nombre);

            }
            this.vista.agregarOrganizacionCombo(RecursoPresentadorM5.valorOtro, RecursoPresentadorM5.opcionOtro);

        }

        /// <summary>
        /// Método para obtener los valores de la vista y ejecutar el comando para agregar la cinta
        /// </summary>
        public void agregarValoresCinta()
        {
            DominioSKD.Entidades.Modulo5.Cinta laCinta = new DominioSKD.Entidades.Modulo5.Cinta();
            DominioSKD.Entidades.Modulo3.Organizacion laOrganizacion = new DominioSKD.Entidades.Modulo3.Organizacion();

            //Se llena una lista de todos los valores que se piden por pantalla para validar si estan vacios
            List<String> laListaDeInputs = new List<String>();
            laListaDeInputs.Add(this.vista.obtenerColorCinta());
            laListaDeInputs.Add(this.vista.obtenerRango());
            laListaDeInputs.Add(this.vista.obtenerCategoria());
            laListaDeInputs.Add(this.vista.obtenerSignificado());
            laListaDeInputs.Add(this.vista.obtenerOrden().ToString());
            laListaDeInputs.Add(this.vista.obtenerNombreOrganizacion());

            if (Validaciones.ValidarCamposVacios(laListaDeInputs))
            {
                try
                {
                    laCinta.Color_nombre = this.vista.obtenerColorCinta();
                    laCinta.Rango = this.vista.obtenerRango();
                    laCinta.Clasificacion = this.vista.obtenerCategoria();
                    laCinta.Significado = this.vista.obtenerSignificado();
                    laCinta.Orden = this.vista.obtenerOrden();
                    laOrganizacion.Id_organizacion = this.vista.obtenerIdOrganizacion();
                    laOrganizacion.Nombre = this.vista.obtenerNombreOrganizacion();
                    laCinta.Organizacion = laOrganizacion;

                    Comando<bool> _comando = FabricaComandos.ObtenerEjecutarAgregarCinta(laCinta);
                    bool resultado = _comando.Ejecutar();
                    if (resultado)
                        this.vista.Respuesta();
                }
                catch (ExcepcionesSKD.Modulo5.OrdenCintaRepetidoException ex)
                {
                    this.vista.alertaAgregarFallidoOrden(ex);
                }
                catch (ExcepcionesSKD.Modulo5.CintaRepetidaException ex)
                {
                    this.vista.alertaAgregarFallidoRepetida(ex);
                }
            }
            else
            {
                this.vista.alertaCamposVacios();

            }
        }

    }
}
