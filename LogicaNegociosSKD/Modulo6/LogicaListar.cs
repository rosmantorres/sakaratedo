using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD.Entidades.Modulo1;
using DatosSKD.Modulo6;

namespace LogicaNegociosSKD.Modulo6
{
    public class LogicaListar
    {

        public List<Cuenta> Listar()
        {try
        {
            BDListarUsuarios listar=new BDListarUsuarios();
            return listar.ListarUsuarios();
            }
            catch(Exception ex){
                return null;
            }
        }
    }
}
