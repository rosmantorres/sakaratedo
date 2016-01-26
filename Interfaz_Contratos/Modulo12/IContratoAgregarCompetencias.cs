using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Interfaz_Contratos.Modulo12
{
    public interface IContratoAgregarCompetencias
    {
        string nombreComp { get; }
        string tipoCompKumite { get; }
        bool tipoCompKumiteBool { get; }
        string tipoCompKata { get; }
        bool tipoCompKataBool { get; }
        string tipoCompAmbos { get; }
        bool tipoCompAmbosBool { get; }
        bool orgCompBool { get; }
        DropDownList organizacionComp { get; set; }
        string statusIniciarComp { get; }
        bool statusIniciarCompBool { get; }
        string statusEnCursoComp { get; }
        bool statusEnCursoCompBool { get; }
        string costoComp { get; }
        string inicioComp { get; set; }
        string finComp { get; set; }
        string latitudComp { get; }
        string longitudComp { get; }
        DropDownList categIniComp { get; set; }
        DropDownList categFinComp { get; set; }
        string edadIniComp { get; }
        string edadFinComp { get; }
        string categSexoMComp { get; }
        bool categSexoMCompBool { get; }
        string cateSexoFComp { get; }
        bool cateSexoFCompBool { get; }
        string alertaClase { set; }
        string alertaRol { set; }
        string alerta { set; }
    }
}
