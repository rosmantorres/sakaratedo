using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSKD.Fabrica;
using DatosSKD.InterfazDAO.Modulo1;
using DominioSKD.Entidades.Modulo1;

namespace LogicaNegociosSKD.Comandos.Modulo1
{
    public class ComandoRestablecerContraseña:Comando<Boolean>
    {

        /// <summary>
        /// restablecer contraseña de la parte de logica el cual hace la conexion con la parte de datos
        /// </summary>
        /// <returns>devuelve true si puede hacer el cambio y false si no pudo efectuar el cambio</returns>
        public override Boolean Ejecutar()
        {
            FabricaDAOSqlServer laFabrica = new FabricaDAOSqlServer();
            try
            {

                IDaoRestablecer conexionBD =laFabrica.ObtenerDaoRestablecer();
                Cuenta cta=(Cuenta)LaEntidad;
                conexionBD.RestablecerContrasena(cta.Id.ToString(),cta.Contrasena);
                return true;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
