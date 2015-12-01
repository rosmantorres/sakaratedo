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
                BDRestablecer conexionBD = new BDRestablecer();
                conexionBD.RestablecerContrasena(usuarioID,AlgoritmoDeEncriptacion.hash(contraseña));
                return true;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        /// <summary>
        /// Metodo que valida los carácteres ingresados en el lógin
        /// </summary>
        /// <param name="cadena">Cadena a validar</param>
        /// <param name="userName">¿Nombre de usuario?</param>
        /// <returns>True:Cumple con los parametros;False:No cumple.</returns>
        public bool ValidarCaracteres(String cadena)
        {
            String comparar = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm0123456789 .";
            for (int i = 0; i < cadena.Length; i++)
            {
                Boolean resultado = comparar.Contains(cadena[i]);
                if (resultado != true)
                    return resultado;
            }

            return true;

        }

       

    }
}
