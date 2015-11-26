using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSKD.Modulo1;

namespace LogicaNegociosSKD.Modulo1
{
    public class Restablecer
    {

        public Boolean restablecerContrasena(string usuarioID, string contraseña)
        {
            try
            {
                BDReestablecer.ReestablecerContrasena(usuarioID, login.hash(contraseña));
                return true;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
