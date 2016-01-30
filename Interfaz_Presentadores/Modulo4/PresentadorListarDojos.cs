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
    public class PresentadorListarDojos
    {
        private IContratoListarDojos vista;

        #region Constructor
        /// <summary>
        /// Constructor del Presentador
        /// </summary>
        /// <param name="laVista">la vista es la interfaz principal</param>
        public PresentadorListarDojos(IContratoListarDojos laVista)
        {
            this.vista = laVista;
        }
        #endregion

        /// <summary>
        /// Método que muestra una lista de los dojos
        /// </summary>
        /// <param name="rol">rol del usuario en sesión</param>
        /// <param name="idlog">id de la persona que esta en sesión</param>
        public void ListarDojos(string rol, int idlog)
        {

            if (vista.Success != null)
            {
                if (vista.Success.Equals("1"))
                {
                    vista.AlertaClase = "alert alert-success alert-dismissible";
                    vista.AlertaRol = "alert";
                    vista.Alerta = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Dojo agregado exitosamente</div>";
                }

                if (vista.Success.Equals("2"))
                {
                    vista.AlertaClase = "alert alert-success alert-dismissible";
                    vista.AlertaRol = "alert";
                    vista.Alerta = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Dojo eliminado exitosamente</div>";
                }

                if (vista.Success.Equals("3"))
                {
                    vista.AlertaClase = "alert alert-success alert-dismissible";
                    vista.AlertaRol = "alert";
                    vista.Alerta = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Dojo modificado exitosamente</div>";
                }
                if (vista.Success.Equals("4"))
                {
                    vista.AlertaClase = "alert alert-danger alert-dismissible";
                    vista.AlertaRol = "alert";
                    vista.Alerta = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Dojo NO se ha modificado exitosamente</div>";
                }
            }


            try
            {
                Comando<List<Entidad>> laListaDojo = FabricaComandos.CrearComandoListarDojos();
                List<Entidad> laLista = FabricaEntidades.ObtenerListaEntidad_M4();

                vista.Cabecera += M4_RecursosPresentador.AbrirTR;
                vista.Cabecera += M4_RecursosPresentador.AbrirTH + "Logo" + M4_RecursosPresentador.CerrarTH;
                vista.Cabecera += M4_RecursosPresentador.AbrirTH + "Rif" + M4_RecursosPresentador.CerrarTH;
                vista.Cabecera += M4_RecursosPresentador.AbrirTH + "Nombtre" + M4_RecursosPresentador.CerrarTH;
                vista.Cabecera += M4_RecursosPresentador.AbrirTH + "Ubicación" + M4_RecursosPresentador.CerrarTH;
                vista.Cabecera += M4_RecursosPresentador.AbrirTH + "Status" + M4_RecursosPresentador.CerrarTH;
                if (String.Compare(rol, "Sistema") == 0)
                {
                    vista.Cabecera += M4_RecursosPresentador.AbrirTH + "Organización" + M4_RecursosPresentador.CerrarTH;
                    vista.Cabecera += M4_RecursosPresentador.AbrirTH + "Acciones" + M4_RecursosPresentador.CerrarTH;
                    vista.Cabecera += M4_RecursosPresentador.CerrarTR;

                    laLista = laListaDojo.Ejecutar();
                    if (laLista.Count != 0)
                        foreach (DojoM4 d in laLista)
                        {

                            vista.LaTabla += M4_RecursosPresentador.AbrirTR;
                            vista.LaTabla += M4_RecursosPresentador.AbrirTD + M4_RecursosPresentador.InicioImagen + d.Logo_dojo + M4_RecursosPresentador.FinalImagen + M4_RecursosPresentador.CerrarTD;
                            vista.LaTabla += M4_RecursosPresentador.AbrirTD + d.Rif_dojo.ToString() + M4_RecursosPresentador.CerrarTD;
                            vista.LaTabla += M4_RecursosPresentador.AbrirTD + d.Nombre_dojo.ToString() + M4_RecursosPresentador.CerrarTD;
                            vista.LaTabla += M4_RecursosPresentador.AbrirTD + d.Ubicacion.Ciudad.ToString() + ", " + d.Ubicacion.Estado.ToString() + M4_RecursosPresentador.CerrarTD;
                            if (d.Status_dojo)
                                vista.LaTabla += M4_RecursosPresentador.AbrirTD + "Activo" + M4_RecursosPresentador.CerrarTD;
                            else
                                vista.LaTabla += M4_RecursosPresentador.AbrirTD + "Bloqueado" + M4_RecursosPresentador.CerrarTD;
                            vista.LaTabla += M4_RecursosPresentador.AbrirTD + d.Organizacion.Nombre.ToString() + M4_RecursosPresentador.CerrarTD;
                            vista.LaTabla += M4_RecursosPresentador.AbrirTD;
                            vista.LaTabla += M4_RecursosPresentador.BotonInfo + d.Id_dojo + M4_RecursosPresentador.BotonCerrar;
                            vista.LaTabla += M4_RecursosPresentador.BotonModificar + d.Id_dojo + M4_RecursosPresentador.BotonCerrar;
                            vista.LaTabla += M4_RecursosPresentador.BotonEliminar + d.Id_dojo + M4_RecursosPresentador.BotonCerrar;
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
                    if (String.Compare(rol, "Organización") == 0)
                    {
                        vista.Cabecera += M4_RecursosPresentador.AbrirTH + "Acciones" + M4_RecursosPresentador.CerrarTH;
                        vista.Cabecera += M4_RecursosPresentador.CerrarTR;
                        laListaDojo.LaEntidad = FabricaEntidades.ObtenerDojo_M4();
                        laListaDojo.LaEntidad.Id = idlog;
                        int id = laListaDojo.LaEntidad.Id;
                        laLista = laListaDojo.Ejecutar();

                        if (laLista.Count != 0)
                        {
                            foreach (DojoM4 d in laLista)
                            {

                                vista.LaTabla += M4_RecursosPresentador.AbrirTR;
                                vista.LaTabla += M4_RecursosPresentador.AbrirTD + M4_RecursosPresentador.InicioImagen + d.Logo_dojo + M4_RecursosPresentador.FinalImagen + M4_RecursosPresentador.CerrarTD;
                                vista.LaTabla += M4_RecursosPresentador.AbrirTD + d.Rif_dojo.ToString() + M4_RecursosPresentador.CerrarTD;
                                vista.LaTabla += M4_RecursosPresentador.AbrirTD + d.Nombre_dojo.ToString() + M4_RecursosPresentador.CerrarTD;
                                vista.LaTabla += M4_RecursosPresentador.AbrirTD + d.Ubicacion.Ciudad.ToString() + ", " + d.Ubicacion.Estado.ToString() + M4_RecursosPresentador.CerrarTD;
                                if (d.Status_dojo)
                                    vista.LaTabla += M4_RecursosPresentador.AbrirTD + "Activo" + M4_RecursosPresentador.CerrarTD;
                                else
                                    vista.LaTabla += M4_RecursosPresentador.AbrirTD + "Bloqueado" + M4_RecursosPresentador.CerrarTD;

                                vista.LaTabla += M4_RecursosPresentador.AbrirTD;
                                vista.LaTabla += M4_RecursosPresentador.BotonInfo + d.Id_dojo + M4_RecursosPresentador.BotonCerrar;
                                vista.LaTabla += M4_RecursosPresentador.BotonModificar + d.Id_dojo + M4_RecursosPresentador.BotonCerrar;
                                vista.LaTabla += M4_RecursosPresentador.BotonEliminar + d.Id_dojo + M4_RecursosPresentador.BotonCerrar;
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
                throw ex;
            }

        }

        /// <summary>
        /// Método que elimina un dojo de bd
        /// </summary>
        /// <param name="id">id del dojo a eliminar</param>
        public void EliminarDojo(int id)
        {
            try
            {

                DominioSKD.Dojo elDojo = (DominioSKD.Dojo)FabricaEntidades.ObtenerDojo_M4();
                elDojo.Id = id;
                Comando<bool> eliminarDojo = FabricaComandos.CrearComandoEliminarDojo();
                eliminarDojo.LaEntidad = elDojo;
                eliminarDojo.Ejecutar();
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
