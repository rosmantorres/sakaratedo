using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Interfaz_Contratos.Modulo12
{
    public interface IContratoModificarCompetencias
    {

        string nombreComp { get; set; }
        string tipoCompKumite { get; set; }
        bool tipoCompKumiteBool { get; set; }
        string tipoCompKata { get; set; }
        bool tipoCompKataBool { get; set; }
        string tipoCompAmbos { get; set; }
        bool tipoCompAmbosBool { get; set; }
        bool orgCompBool { get; set; }
        DropDownList organizacionComp { get; set; }
        string statusIniciarComp { get; set; }
        bool statusIniciarCompBool { get; set; }
        string statusEnCursoComp { get; set; }
        bool statusEnCursoCompBool { get; set; }
        string statusFinalizadoComp { get; set; }
        bool statusFinalizadoCompBool { get; set; }
        string costoComp { get; set; }
        string inicioComp { get; set; }
        string finComp { get; set; }
        string latitudComp { get; set; }
        string longitudComp { get; set; }
        DropDownList categIniComp { get; set; }
        DropDownList categFinComp { get; set; }
        string edadIniComp { get; set; }
        string edadFinComp { get; set; }
        string categSexoMComp { get; set; }
        bool categSexoMCompBool { get; set; }
        string cateSexoFComp { get; set; }
        bool cateSexoFCompBool { get; set; }
        string alertaClase { set; }
        string alertaRol { set; }
        string alerta { set; }
    }
}
