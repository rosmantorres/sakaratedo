using DominioSKD.Entidades.Modulo14;
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

              return new List<Boolean>();
        /*      try
              {
                  Diseño resultDiseño = diseño.ConsultarDiseño(idPlanilla);

                  List<Boolean> datosRequeridos = new List<Boolean>();

                  datosRequeridos.Add(resultDiseño.Contenido.Contains(RecursosComandoModulo14.FechaRetiro));
                  datosRequeridos.Add(resultDiseño.Contenido.Contains(RecursosComandoModulo14.FechaReincor));
                  datosRequeridos.Add(resultDiseño.Contenido.Contains(RecursosComandoModulo14.EveNombre));
                  datosRequeridos.Add(resultDiseño.Contenido.Contains(RecursosComandoModulo14.CompNombre));
                  datosRequeridos.Add(resultDiseño.Contenido.Contains(RecursosComandoModulo14.Motivo));

               
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
              return datosRequeridos;*/ 
          }
    }
}
