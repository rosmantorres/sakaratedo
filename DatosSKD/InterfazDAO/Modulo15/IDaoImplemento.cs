using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;


namespace DatosSKD.InterfazDAO.Modulo15
{
   public interface IDaoImplemento : IDao<Entidad, bool, Entidad>
    {
        
         List<Entidad> listarInventarioDatos(Entidad parametroDojo);

         List<Entidad> listarInventarioDatos2(Entidad parametroDojo);

         Entidad implementoInventarioDatos(int idImplemento);

         bool eliminarInventarioDatos(int idInventario, Entidad parametroDojo);

         bool modificarInventarioDatos(Entidad parametroImplemento);

         List<Entidad> listarInventarioDatos();

         Entidad implementoInventarioDatosUltimo();

         bool implementoInventarioDatosBool(int idImplemento);

         int usuarioImplementoDatos(String usuario);



    }
}
