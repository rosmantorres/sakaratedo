using DatosSKD.DAO.Modulo14;
using DatosSKD.InterfazDAO.Modulo14;
using DatosSKD.Fabrica;
using DominioSKD;
using DominioSKD.Fabrica;
using ExcepcionesSKD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegociosSKD.Comandos.Modulo14
{
    public class ComandoDatosRequeridosSolicitud : Comando<List<Boolean>>
    {
        private int idPlanilla;

        public int IdPlanilla
        {
            get { return idPlanilla; }
            set { idPlanilla = value; }
        }
          public override List<Boolean> Ejecutar()
          {
              List<Boolean> datosRequeridos = new List<Boolean>();

              try
              {

                  IDaoDiseno diseno = FabricaDAOSqlServer.ObtenerDAODiseno();
                  DominioSKD.Entidades.Modulo14.Planilla planilla = (DominioSKD.Entidades.Modulo14.Planilla)FabricaEntidades.ObtenerPlanilla();
                  planilla.ID = LaEntidad.Id;
                  Entidad resultDiseño = diseno.ConsultarXId(planilla);


                  datosRequeridos.Add(((DominioSKD.Entidades.Modulo14.Diseño)resultDiseño).Contenido.Contains(RecursosComandoModulo14.FechaRetiro));
                  datosRequeridos.Add(((DominioSKD.Entidades.Modulo14.Diseño)resultDiseño).Contenido.Contains(RecursosComandoModulo14.FechaReincor));
                  datosRequeridos.Add(((DominioSKD.Entidades.Modulo14.Diseño)resultDiseño).Contenido.Contains(RecursosComandoModulo14.EveNombre));
                  datosRequeridos.Add(((DominioSKD.Entidades.Modulo14.Diseño)resultDiseño).Contenido.Contains(RecursosComandoModulo14.CompNombre));
                  datosRequeridos.Add(((DominioSKD.Entidades.Modulo14.Diseño)resultDiseño).Contenido.Contains(RecursosComandoModulo14.Motivo));

               
              }
              catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
              {
                  Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                  throw ex;
              }
              catch (ExcepcionesSKD.Modulo14.BDSolicitudException ex)
              {
                  Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                  throw ex;
              }
              catch (Exception ex)
              {
                  Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                  throw ex;
              }
              return datosRequeridos; 
          }
    }
}
