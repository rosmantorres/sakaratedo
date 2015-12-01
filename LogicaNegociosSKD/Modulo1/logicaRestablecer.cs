using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSKD.Modulo1;
using LogicaNegociosSKD.Modulo2;

namespace LogicaNegociosSKD.Modulo1
{
    public class logicaRestablecer
    {

        public Boolean restablecerContrasena(string usuarioID, string contraseña)
        {
            try
            {
                BDRestablecer.RestablecerContrasena(usuarioID,AlgoritmoDeEncriptacion.hash(contraseña));
                return true;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
       

    }
}
