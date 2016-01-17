using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using CKEditor;
using CKEditor.NET;

namespace Interfaz_Contratos.Modulo14
{
    public interface IContratoM14DisenoPlanilla
    {
        Label tipoPlanilla { get; set; }
        Label planilla { get; set; }
        CKEditorControl CKEditor1 { get; set; }
        DropDownList comboDatos { get; set; }
        Label campos { get; set; }
        Label camposStatic { get; set; }
        string alertaClase { set; }
        string alertaRol { set; }
        string alert { set; }
    }
}
