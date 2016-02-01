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
    public class PresentadorAgregarOrganizacion
    {
        private IContratoAgregarOrganizacion vista;

        public PresentadorAgregarOrganizacion(IContratoAgregarOrganizacion vista)
        {
            this.vista = vista;
        }


        /// <summary>
        /// Método para validar la informacion de la organizacion antes de agregarla 
        /// </summary>
        public void ValidarExpresionesReg(DominioSKD.Entidades.Modulo3.Organizacion laOrganizacion, string telefono)
        {
            //Validar las expresionnes regulares
            Regex rexNombre = new Regex(RecursosPresentadorM3.expresionNombre);
            Regex resNumero = new Regex(RecursosPresentadorM3.expresionNumero);
            Regex rexNombreNumero = new Regex(RecursosPresentadorM3.expresionNombreNumero);
            Regex rexCorreo = new Regex(RecursosPresentadorM3.expresionesCorreo);
            Regex rexDireccion = new Regex(RecursosPresentadorM3.expresionDireccion);

            if (!rexNombre.IsMatch(laOrganizacion.Nombre))
                throw new ExcepcionesSKD.Modulo3.ExpresionesRegularesException(RecursosPresentadorM3.Codigo_Error_Expresion_Regular,
                                      RecursosPresentadorM3.Mensaje_Error_Expresion_Regular_Nombre, new Exception());            
            else if (!rexCorreo.IsMatch(laOrganizacion.Email) || !laOrganizacion.Email.Contains(RecursosPresentadorM3.arroba))
                throw new ExcepcionesSKD.Modulo3.ExpresionesRegularesException(RecursosPresentadorM3.Codigo_Error_Expresion_Regular,
                                      RecursosPresentadorM3.Mensaje_Error_Expresion_Regular_Email, new Exception());
            else if (!resNumero.IsMatch(telefono))
                throw new ExcepcionesSKD.Modulo3.ExpresionesRegularesException(RecursosPresentadorM3.Codigo_Error_Expresion_Regular,
                                        RecursosPresentadorM3.Mensaje_Error_Expresion_Regular_Telefono, new Exception()); 
            else if (!rexDireccion.IsMatch(laOrganizacion.Direccion))
                throw new ExcepcionesSKD.Modulo3.ExpresionesRegularesException(RecursosPresentadorM3.Codigo_Error_Expresion_Regular,
                                        RecursosPresentadorM3.Mensaje_Error_Expresion_Regular_Direccion, new Exception());    
            else if (!rexNombre.IsMatch(laOrganizacion.Estado))
                throw new ExcepcionesSKD.Modulo3.ExpresionesRegularesException(RecursosPresentadorM3.Codigo_Error_Expresion_Regular,
                                        RecursosPresentadorM3.Mensaje_Error_Expresion_Regular_Estado, new Exception()); 
            else if (!rexNombre.IsMatch(laOrganizacion.Estilo))
                throw new ExcepcionesSKD.Modulo3.ExpresionesRegularesException(RecursosPresentadorM3.Codigo_Error_Expresion_Regular,
                                        RecursosPresentadorM3.Mensaje_Error_Expresion_Regular_Estilo, new Exception()); 
      
        }


        /// <summary>
        /// Método para obtener los valores de la vista y ejecutar el comando para agregar la organizacion
        /// </summary>
        public void agregarValoresOrganizacion()
        {
            DominioSKD.Entidades.Modulo3.Organizacion laOrganizacion = (DominioSKD.Entidades.Modulo3.Organizacion)FabricaEntidades.ObtenerOrganizacion_M3();

            //Se llena una lista de todos los valores que se piden por pantalla para validar si estan vacios
            List<String> laListaDeInputs = new List<String>();
            laListaDeInputs.Add(this.vista.obtenerNombreOrg);
            laListaDeInputs.Add(this.vista.obtenerEmail);
            laListaDeInputs.Add(this.vista.obtenerTelefono.ToString());
            laListaDeInputs.Add(this.vista.obtenerDireccion);
            laListaDeInputs.Add(this.vista.obtenerEstado);
            laListaDeInputs.Add(this.vista.obtenerTecnica);

            if (Validaciones.ValidarCamposVacios(laListaDeInputs))
            {

                try
                {
                    string telefonoString;

                     laOrganizacion.Nombre = this.vista.obtenerNombreOrg;
                     laOrganizacion.Email = this.vista.obtenerEmail;
                     telefonoString = this.vista.obtenerTelefono;
                     laOrganizacion.Direccion = this.vista.obtenerDireccion;
                     laOrganizacion.Estado = this.vista.obtenerEstado;
                     laOrganizacion.Estilo = this.vista.obtenerTecnica;

                     this.ValidarExpresionesReg(laOrganizacion, telefonoString);
                       laOrganizacion.Telefono = Int32.Parse(telefonoString);

                     Comando<bool> _comando = FabricaComandos.ObtenerEjecutarAgregarOrganizacion(laOrganizacion);
                     bool resultado = _comando.Ejecutar();
                        if (resultado)
                             this.vista.Respuesta();
                }
                catch (ExcepcionesSKD.Modulo3.OrganizacionExistenteException ex)
                {
                    this.vista.alertaAgregarFallidoNombreOrg(ex);
                }
                catch (ExcepcionesSKD.Modulo3.EstiloInexistenteException ex)
                {
                    this.vista.alertaAgregarFallidoEstiloOrg(ex);
                }
                catch (Exception ex)
                {
                    this.vista.alertaAgregarFallido(ex);
                }
            }
            else
            {
                this.vista.alertaCamposVacios();

            }
        }
    }
}
