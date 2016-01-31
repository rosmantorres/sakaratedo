using DominioSKD;
using DominioSKD.Entidades.Modulo4;
using DominioSKD.Fabrica;
using ExcepcionesSKD;
using Interfaz_Contratos.Modulo4;
using LogicaNegociosSKD;
using LogicaNegociosSKD.Fabrica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaz_Presentadores.Modulo4
{
    public class PresentadorListarHistorialM
    {
         private IContratoListarHistorialM vista;

        #region Constructor
        /// <summary>
        /// Constructor del Presentador
        /// </summary>
        /// <param name="laVista">la vista es la interfaz principal</param>
         public PresentadorListarHistorialM(IContratoListarHistorialM laVista)
        {
            this.vista = laVista;
        }
        #endregion

         /// <summary>
         /// Método que muestra una lista de los Historial Matricula
         /// </summary>
         /// <param name="rol">rol del usuario en sesión</param>
         /// <param name="idlog">id de la persona que esta en sesión</param>
         public void ListarHistorialM(string rol, int idlog)
         {

             if (vista.Success != null)
             {
                 if (vista.Success.Equals("1"))
                 {
                     vista.AlertaClase = "alert alert-success alert-dismissible";
                     vista.AlertaRol = "alert";
                     vista.Alerta = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Historial Matricula agregado exitosamente</div>";
                 }

                 if (vista.Success.Equals("2"))
                 {
                     vista.AlertaClase = "alert alert-success alert-dismissible";
                     vista.AlertaRol = "alert";
                     vista.Alerta = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Historial Matricula eliminado exitosamente</div>";
                 }

                 if (vista.Success.Equals("3"))
                 {
                     vista.AlertaClase = "alert alert-success alert-dismissible";
                     vista.AlertaRol = "alert";
                     vista.Alerta = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Historial Matricula modificado exitosamente</div>";
                 }
                 if (vista.Success.Equals("4"))
                 {
                     vista.AlertaClase = "alert alert-danger alert-dismissible";
                     vista.AlertaRol = "alert";
                     vista.Alerta = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Historial Matricula NO se ha modificado exitosamente</div>";
                 }
             }


             try
             {
                 Comando<List<Entidad>> laListaHistM = FabricaComandos.CrearComandoListarHistorialM();
                 List<Entidad> laLista = FabricaEntidades.ObtenerListaEntidad_M4();

                 vista.Cabecera += M4_RecursosPresentador.AbrirTR;
                 vista.Cabecera += M4_RecursosPresentador.AbrirTH + "Fecha" + M4_RecursosPresentador.CerrarTH;
                 vista.Cabecera += M4_RecursosPresentador.AbrirTH + "Modalidad" + M4_RecursosPresentador.CerrarTH;
                 vista.Cabecera += M4_RecursosPresentador.AbrirTH + "Monto BsF." + M4_RecursosPresentador.CerrarTH;
                 if (String.Compare(rol, "Sistema") == 0)
                 {
                     vista.Cabecera += M4_RecursosPresentador.AbrirTH + "Dojo" + M4_RecursosPresentador.CerrarTH;
                     vista.Cabecera += M4_RecursosPresentador.AbrirTH + "Acciones" + M4_RecursosPresentador.CerrarTH;
                     vista.Cabecera += M4_RecursosPresentador.CerrarTR;

                     laLista = laListaHistM.Ejecutar();
                     if (laLista.Count != 0)
                         foreach (HistorialM h in laLista)
                         {

                             vista.LaTabla += M4_RecursosPresentador.AbrirTR;
                             vista.LaTabla += M4_RecursosPresentador.AbrirTD + h.Fecha_historial_matricula.ToString("dd/MM/yyyy") + M4_RecursosPresentador.CerrarTD;
                             vista.LaTabla += M4_RecursosPresentador.AbrirTD + h.Modalidad_historial_matricula.ToString() + M4_RecursosPresentador.CerrarTD;
                             vista.LaTabla += M4_RecursosPresentador.AbrirTD + "Bsf. " + h.Monto_historial_matricula.ToString() + M4_RecursosPresentador.CerrarTD;
                             vista.LaTabla += M4_RecursosPresentador.AbrirTD + h.Dojo_historial_matricula.Nombre_dojo.ToString() + M4_RecursosPresentador.CerrarTD;
                             vista.LaTabla += M4_RecursosPresentador.AbrirTD;
                             vista.LaTabla += M4_RecursosPresentador.BotonModificarM + h.Id_historial_matricula + M4_RecursosPresentador.BotonCerrar;
                             vista.LaTabla += M4_RecursosPresentador.BotonEliminar + h.Id_historial_matricula + M4_RecursosPresentador.BotonCerrar;
                             vista.LaTabla += M4_RecursosPresentador.CerrarTD;
                             vista.LaTabla += M4_RecursosPresentador.CerrarTR;
                         }
                     else
                     {
                         vista.AlertaClase = "alert alert-info alert-dismissible";
                         vista.AlertaRol = "alert";
                         vista.Alerta = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>No se encontraron registros asociados a su solicitud</div>";

                     }
                 }
                 else
                 {
                     if (String.Compare(rol, "Organización") == 0)
                     {
                         vista.Cabecera += M4_RecursosPresentador.AbrirTH + "Acciones" + M4_RecursosPresentador.CerrarTH;
                         vista.Cabecera += M4_RecursosPresentador.CerrarTR;
                         laListaHistM.LaEntidad.Id = idlog;
                         laLista = laListaHistM.Ejecutar();
                         if (laLista.Count != 0)
                             foreach (HistorialM h in laLista)
                             {
                                 vista.LaTabla += M4_RecursosPresentador.AbrirTR;
                                 vista.LaTabla += M4_RecursosPresentador.AbrirTD + h.Fecha_historial_matricula.ToString("dd/MM/yyyy") + M4_RecursosPresentador.CerrarTD;
                                 vista.LaTabla += M4_RecursosPresentador.AbrirTD + h.Modalidad_historial_matricula.ToString() + M4_RecursosPresentador.CerrarTD;
                                 vista.LaTabla += M4_RecursosPresentador.AbrirTD + "Bsf. " + h.Monto_historial_matricula.ToString() + M4_RecursosPresentador.CerrarTD;
                                 vista.LaTabla += M4_RecursosPresentador.AbrirTD;
                                 vista.LaTabla += M4_RecursosPresentador.BotonModificarM + h.Id + M4_RecursosPresentador.BotonCerrar;
                                 vista.LaTabla += M4_RecursosPresentador.BotonEliminar + h.Id + M4_RecursosPresentador.BotonCerrar;
                                 vista.LaTabla += M4_RecursosPresentador.CerrarTD;
                                 vista.LaTabla += M4_RecursosPresentador.CerrarTR;
                             }
                         }
                         else
                         {
                             vista.AlertaClase = "alert alert-info alert-dismissible";
                             vista.AlertaRol = "alert";
                             vista.Alerta = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>No se encontraron registros asociados a su solicitud</div>";

                         }
                     }




             }
             catch (Exception ex)
             {
                 vista.AlertaClase = "alert alert-info alert-dismissible";
                 vista.AlertaRol = "alert";
                 vista.Alerta = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>No se encontraron registros asociados a su solicitud</div>";

             }

         }

         /// <summary>
         /// Método que elimina un Historial Matricula de bd
         /// </summary>
         /// <param name="id">id del Historial Matricula a eliminar</param>
         public void EliminarMatricula(int matriculaEliminar)
         {
             try
             {

                 HistorialM elHistM = (HistorialM)FabricaEntidades.ObtenerHistorialMatricula();
                 elHistM.Id = matriculaEliminar;
                 Comando<bool> eliminarHistM = FabricaComandos.CrearComandoEliminarHistorialM();
                 eliminarHistM.LaEntidad = elHistM;
                 eliminarHistM.Ejecutar();
             }
             catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
             {
                 Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                 throw ex;
             }
             catch (ExcepcionesSKD.ExceptionSKD ex)
             {
                 Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                 throw ex;
             }
         }
    }
}
