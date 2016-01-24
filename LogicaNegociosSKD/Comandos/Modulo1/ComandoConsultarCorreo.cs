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
    /// <summary>
    /// Comando para consultar si el correo existe en la BD
    /// </summary>
    /// <returns>True: El correo existe; False: No existe</returns>
    public class ComandoConsultarCorreo: Comando<String>
    {

        public override String Ejecutar()
        {
            String respuesta;
            try
            {
                FabricaDAOSqlServer laFabrica=new FabricaDAOSqlServer();
                IDaoLogin conexionBD = laFabrica.ObtenerDaoLogin();
                Cuenta cta = (Cuenta)LaEntidad;
                respuesta = conexionBD.ValidarCorreoUsuario(cta.PersonaUsuario._CorreoElectronico);
            }
            catch (Exception e)
            {
                throw e;
            }
            return respuesta;
        }

    }
}
