using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaz_Presentadores.Modulo8
{
    public class ValidacionesM8
    {
        ///<sumary>
        ///Metodo que se encarga de validar si los datos de la lista alguno de ellos esta vacio  
        ///</sumary>
        ///<param name="datos">Lista de String con los datos a validar</param>
        ///<returns>true, sin ningun dato en la lista esta vacio
        ///         false, si al menos un dato es igual a vacio</returns>
        public bool ValidarCamposVacios(List<String> datos)
        {
            String caracterVacio = "";

            for (int i = 0; i < datos.Count; i++)
            {
                if (datos[i].Equals(caracterVacio))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Metodo que valida los carácteres ingresados en el lógin
        /// </summary>
        /// <param name="cadena">Cadena a validar</param>
        /// <returns>True:Cumple con los parametros;False:No cumple.</returns>
        public bool ValidarCaracteres(String cadena)
        {
            String comparar = RecursoPresentadorM8.Numbers;
            
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
