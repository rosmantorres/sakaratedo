using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaz_Contratos.Modulo7
{
    /// <summary>
    /// Contrato para consultar perfil
    /// </summary>
    public interface IContratoConsultarPerfil
    {
        string nombrePersona { get; set; }
        string apellidoPersona { get; set; }
        string fechaNacimiento { get; set; }
        string direccion { get; set; }
        string nombreDojo { get; set; }
        string telefonoDojo { get; set; }
        string emailDojo { get; set; }
        string ubicacionDojo { get; set; }
        string nombreOrganizacion { get; set; }
        string emailOrganizacion { get; set; }
        string ubicacionOrganizacion { get; set; }
        string cintaActual { get; set; }

    }
}
