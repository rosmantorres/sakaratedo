using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Interfaz_Contratos.Modulo15
{
    public interface IContratoAgregarImplemento
    {
        TextBox nombre_implemento { get; set; }
        DropDownList tipo_implemento { get; set; }
        TextBox cantidad_implemento { get; set; }
        TextBox precio_implemento { get; set; }
        DropDownList color_implemento { get; set; }
        DropDownList marca_implemeto { get; set; }
        DropDownList talla_implemento { get; set; }
        TextBox stock_implemeto { get; set; }
        TextBox descripcion_implemento { get; set; }
        string imagen_implemeto { get; set; }
    }
}
