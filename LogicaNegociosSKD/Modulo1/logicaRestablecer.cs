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
        /// <summary>
        /// restablecer contraseña de la parte de logica el cual hace la conexion con la parte de datos
        /// </summary>
        /// <param name="usuarioID">el id del usuario</param>
        /// <param name="contraseña"> la nueva contraseña</param>
        /// <returns>devuelve true si puede hacer el cambio y false si no pudo efectuar el cambio</returns>
        public Boolean restablecerContrasena(string usuarioID, string contraseña)
        {
            AlgoritmoDeEncriptacion cripto = new AlgoritmoDeEncriptacion();
            try
            {
                BDRestablecer conexionBD = new BDRestablecer();
                conexionBD.RestablecerContrasena(usuarioID, cripto.hash(contraseña));
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
