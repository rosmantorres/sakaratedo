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
            FabricaComandos _fabrica = new FabricaComandos();
            Comando<List<Entidad>> _comando = _fabrica.ObtenerEjecutarComboOrganizaciones();
            List<Entidad> _miLista = _comando.Ejecutar();

            if (_miLista != null)
                this.asignarInformacionCombo(_miLista);
            else
            {
                throw new ExcepcionesSKD.Modulo5.ListaVaciaExcepcion(RecursoPresentadorM5.Codigo_Error_Lista_Vacia,
                                   RecursoPresentadorM5.Mensaje_Error_Lista_Vacia, new Exception());
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

            laCinta.Color_nombre = this.vista.obtenerColorCinta();
            laCinta.Rango = this.vista.obtenerRango();
            laCinta.Clasificacion = this.vista.obtenerCategoria();
            laCinta.Significado = this.vista.obtenerSignificado();
            laCinta.Orden = this.vista.obtenerOrden();
            laOrganizacion.Id_organizacion = this.vista.obtenerIdOrganizacion();
            laOrganizacion.Nombre = this.vista.obtenerNombreOrganizacion();
            laCinta.Organizacion = laOrganizacion;

            FabricaComandos _fabrica = new FabricaComandos();
            Comando<bool> _comando = _fabrica.ObtenerEjecutarAgregarCinta(laCinta);
            bool resultado = _comando.Ejecutar();   
        }

    }
}
