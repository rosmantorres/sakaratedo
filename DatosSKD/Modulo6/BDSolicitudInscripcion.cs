using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DominioSKD;

namespace DatosSKD.Modulo6
{
    public class BDSolicitudInscripcion
    {
        public static void GuardarSolicitud(SolicitudInscripcionDojo solicitud)
        {
            Parametro parametro;
            List<Parametro> parametros;
            List<Resultado> res;

            if (solicitud == null)
                return;

            parametros = new List<Parametro>();

            parametro = new Parametro("@" + RecursosBDModulo6.Atribute_Persona_Id, SqlDbType.Int, solicitud.Solicitante.ID.ToString(), false);
            parametros.Add(parametro);
            parametro = new Parametro("@" + RecursosBDModulo6.Atribute_Dojo_Id, SqlDbType.Int, solicitud.Dojo.Id_dojo.ToString(), false);
            parametros.Add(parametro);

            res = BDUtils.getValues(RecursosBDModulo6.SP_Add_Solicitud, parametros);
        }
    }
}
