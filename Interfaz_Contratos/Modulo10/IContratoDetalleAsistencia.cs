using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Interfaz_Contratos.Modulo10
{
    public interface IContratoDetalleAsistencia
    {
        TextBox Fecha { get; set; }

        TextBox Nombre { get; set; }

        ListBox NoAsistieron { get; set; }

        ListBox Asistieron { get; set; }
    }
}
