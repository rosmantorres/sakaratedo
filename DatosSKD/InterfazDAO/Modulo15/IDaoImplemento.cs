using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;

namespace DatosSKD.InterfazDAO.Modulo15
{
    interface IDaoImplemento : IDao<Entidad, bool, Entidad>
    {
        
        List<Implemento> listarInventarioDatos(Dojo dojo);

        List<Implemento> listarInventarioDatos2(Dojo dojo);

        Implemento implementoInventarioDatos(int idImplemento);

        void eliminarInventarioDatos(int idInventario, Dojo dojo);

        void modificarInventarioDatos(Implemento implemento);

        List<Implemento> listarInventarioDatos();

        Implemento implementoInventarioDatosUltimo();

        bool implementoInventarioDatosBool(int idImplemento);

        int usuarioImplementoDatos(String usuario);



    }
}
