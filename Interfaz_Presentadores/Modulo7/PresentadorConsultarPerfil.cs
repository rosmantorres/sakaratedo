using DominioSKD;
using ExcepcionesSKD;
using ExcepcionesSKD.Modulo7;
using Interfaz_Contratos.Modulo7;
using LogicaNegociosSKD.Comandos.Modulo7;
using LogicaNegociosSKD.Fabrica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaz_Presentadores.Modulo7
{
    /// <summary>
    /// Presentador para consultar perfil
    /// </summary>
    public class PresentadorConsultarPerfil
    {
        private FabricaComandos fabricaComandos;
        private IContratoConsultarPerfil vista;
        /// <summary>
        /// Constructor del presentador
        /// </summary>
        /// <param name="laVista">instancia de la ventana</param>
        public PresentadorConsultarPerfil(IContratoConsultarPerfil laVista)
        {
            vista = laVista;
        }


        /// <summary>
        /// Método para cargar los datos de la persona
        /// </summary>
        /// <param name="idPersona">id de la persona</param>
        public void cargarDatos(Persona idPersona)
        {
            try
            {
                fabricaComandos = new FabricaComandos();
                ComandoConsultarPerfil comandoDetallarPersona = (ComandoConsultarPerfil)fabricaComandos.ObtenerComandoConsultarPerfil();
                comandoDetallarPersona.LaEntidad = idPersona;
                Tuple <Entidad, Entidad, Entidad, Entidad, String, Entidad> tupla = comandoDetallarPersona.Ejecutar();

                Persona persona = (Persona)tupla.Item1;
                Dojo dojo = (Dojo)tupla.Item2;
                Ubicacion ubicacionDojo = (Ubicacion)tupla.Item3;
                Organizacion organizacion = (Organizacion)tupla.Item4;
                string ubicacionOrganizacion = tupla.Item5;
                Cinta ultimaCinta = (Cinta)tupla.Item6;

                vista.apellidoPersona = persona.Apellido;
                vista.cintaActual = ultimaCinta.Color_nombre;
                vista.direccion = persona.Direccion;
                vista.emailDojo = dojo.Email_dojo;
                vista.emailOrganizacion = organizacion.Email;
                vista.fechaNacimiento= persona.FechaNacimiento.ToString("MM/dd/yyyy");
                vista.nombreDojo = dojo.Nombre_dojo;
                vista.nombreOrganizacion = organizacion.Nombre;
                vista.nombrePersona = persona.Nombre;
                vista.telefonoDojo = dojo.Telefono_dojo.ToString();
                vista.ubicacionDojo = ubicacionDojo.Direccion;
                vista.ubicacionOrganizacion = ubicacionOrganizacion;

            }
            catch (NumeroEnteroInvalidoException)
            {
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
    M7_RecursosPresentador.Mensaje_Numero_Parametro_invalido, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            catch (FormatException)
            {
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
    M7_RecursosPresentador.Mensaje_Numero_Parametro_invalido, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            catch (NullReferenceException)
            {
            }
            catch (Exception)
            {
            }
        }
    }
}
