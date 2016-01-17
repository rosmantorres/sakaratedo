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
        Label tipoPlanilla { set; }
        Label planilla { set; }
        CKEditorControl ckEditor { get; set; }
        DropDownList comboDatos { get; set; }
        TextBox campos { get; set; }
        TextBox camposStatic { get; set; }
        String alert { set; }
    }
}
