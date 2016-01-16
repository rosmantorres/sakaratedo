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
        String tipoPlanilla {set; }
        String planilla { set; }
        CKEditorControl ckEditor { get; set; }
        DropDownList ComboDatos { get; set; }
        String campos {set; }
        String camposStatic {set; }
    }
}
