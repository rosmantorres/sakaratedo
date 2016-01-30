using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaz_Contratos.Modulo3;
using LogicaNegociosSKD.Fabrica;
using LogicaNegociosSKD.Comandos.Modulo3;
using LogicaNegociosSKD;
using DominioSKD;
using DominioSKD.Fabrica;
using System.Text.RegularExpressions;

namespace Interfaz_Presentadores.Modulo3
{
    public class PresentadorModificarOrganizacion
    {
        private IContratoModificarOrganizacion vista;

        public PresentadorModificarOrganizacion(IContratoModificarOrganizacion vista)
        {
            this.vista = vista;
        }

        /// <summary>
        /// Método para llenar la informacion de la organizacion
        /// </summary>
        public void llenarModificar()
        {
            DominioSKD.Entidades.Modulo3.Organizacion organizacion = (DominioSKD.Entidades.Modulo3.Organizacion)FabricaEntidades.ObtenerOrganizacion_M3();
            organizacion.Id_organizacion = this.vista.obtenerIdOrg;

            Comando<Entidad> _comando = FabricaComandos.ObtenerEjecutarConsultarXIdOrganizacion(organizacion);
            Entidad _miEntidad = _comando.Ejecutar();
            DominioSKD.Entidades.Modulo3.Organizacion laOrganizacion = (DominioSKD.Entidades.Modulo3.Organizacion)_miEntidad;


            this.vista.obtenerNombreOrg = laOrganizacion.Nombre;
            this.vista.obtenerEmail = laOrganizacion.Email;
            this.vista.obtenerTelefono = laOrganizacion.Telefono.ToString();
            this.vista.obtenerDireccion = laOrganizacion.Direccion;
            this.vista.obtenerEstado = laOrganizacion.Estado;
            this.vista.obtenerTecnica = laOrganizacion.Estilo;
        }

        /// <summary>
        /// Método para validar la informacion de la organizacion antes de agregarla 
        /// </summary>
        public bool ValidarExpresionesReg(DominioSKD.Entidades.Modulo3.Organizacion laOrganizacion, string telefono)
        {
            //Validar las expresionnes regulares
            Regex rexNombre = new Regex(RecursosPresentadorM3.expresionNombre);
            Regex resNumero = new Regex(RecursosPresentadorM3.expresionNumero);
            Regex rexNombreNumero = new Regex(RecursosPresentadorM3.expresionNombreNumero);
            Regex rexCorreo = new Regex(RecursosPresentadorM3.expresionesCorreo);
            Regex rexDireccion = new Regex(RecursosPresentadorM3.expresionDireccion);

            if (!rexNombre.IsMatch(laOrganizacion.Nombre))
                return false;
            else if (!rexCorreo.IsMatch(laOrganizacion.Email) || !laOrganizacion.Email.Contains(RecursosPresentadorM3.arroba))
                return false;
            else if (!rexDireccion.IsMatch(laOrganizacion.Direccion))
                return false;
            else if (!rexNombre.IsMatch(laOrganizacion.Estado))
                return false;
            else if (!rexNombre.IsMatch(laOrganizacion.Estilo))
                return false;
            else if (!resNumero.IsMatch(telefono))
                return false;
            else
                return true;
        }

        /// <summary>
        /// Método para obtener los valores de la vista y ejecutar el comando para modificar la organizacion
        /// </summary>
        public void modificarValoresOrganizacion()
        {
            DominioSKD.Entidades.Modulo3.Organizacion laOrganizacion = (DominioSKD.Entidades.Modulo3.Organizacion)FabricaEntidades.ObtenerOrganizacion_M3();

          try
            {
                string telefonoString;

            laOrganizacion.Id_organizacion = this.vista.obtenerIdOrg;
            laOrganizacion.Nombre = this.vista.obtenerNombreOrg;
            laOrganizacion.Email = this.vista.obtenerEmail;
            telefonoString = this.vista.obtenerTelefono;
            laOrganizacion.Direccion = this.vista.obtenerDireccion;
            laOrganizacion.Estado = this.vista.obtenerEstado;
            laOrganizacion.Estilo = this.vista.obtenerTecnica;


             if (ValidarExpresionesReg(laOrganizacion, telefonoString)) {

                     laOrganizacion.Telefono = Int32.Parse(telefonoString);
            Comando<bool> _comando = FabricaComandos.ObtenerEjecutarModificarOrganizacion(laOrganizacion);
            bool resultado = _comando.Ejecutar();

            if (resultado)
                this.vista.Respuesta();
             }
             else
             {
                 this.vista.alertaExpresiones();
             }
            }
          catch (ExcepcionesSKD.Modulo3.EstiloInexistenteException ex)
          {
              this.vista.alertaModificarFallidoEstiloOrg(ex);
          }
          catch (Exception ex)
          {
              this.vista.alertaModificarFallido(ex);
          }
        }
    }
}
