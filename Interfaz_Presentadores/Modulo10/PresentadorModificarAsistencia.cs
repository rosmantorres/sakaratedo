using DominioSKD;
using Interfaz_Contratos.Modulo10;
using LogicaNegociosSKD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Interfaz_Presentadores.Modulo10
{
    public class PresentadorModificarAsistencia
    {
        IContratoModificarAsistencia vista;

        public PresentadorModificarAsistencia(IContratoModificarAsistencia vista)
        {
            this.vista = vista;
        }

        public void CargaVentana(string idEvento, string tipoEvento)
        {
            if (tipoEvento.Equals(M10_RecursosPresentador.Evento))
            {
                Entidad evento = DominioSKD.Fabrica.FabricaEntidades.ObtenerEventoM10();
                Comando<Entidad> comando = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoConsultarEventoM10XId(idEvento);
                evento = comando.Ejecutar();
                vista.Fecha.Text = ((DominioSKD.Entidades.Modulo10.Evento)evento).Horario.FechaInicio.ToShortDateString();
                vista.Nombre.Text = ((DominioSKD.Entidades.Modulo10.Evento)evento).Nombre;
                Comando<List<Entidad>> comandoListaA = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoListaAsistentesEvento(idEvento);
                List<Entidad> listaA = comandoListaA.Ejecutar();
                Comando<List<Entidad>> comandoListaI = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoListaNoAsistentesEvento(idEvento);
                List<Entidad> listaI = comandoListaI.Ejecutar();

                foreach (Entidad persona in listaA)
                {
                    vista.ListaAsis.Items.Add(((DominioSKD.Entidades.Modulo10.Persona)persona).Nombre);
                }

                foreach (Entidad persona in listaI)
                {
                    vista.ListaNo.Items.Add(((DominioSKD.Entidades.Modulo10.Persona)persona).Nombre);
                }
            }
            else if (tipoEvento.Equals(M10_RecursosPresentador.Competencia))
            {
                DominioSKD.Fabrica.FabricaEntidades fabrica = new DominioSKD.Fabrica.FabricaEntidades();
                Entidad competencia = fabrica.ObtenerCompetencia();
                Comando<Entidad> comando = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoConsultarCompetenciasXId(idEvento);
                competencia = comando.Ejecutar();
                vista.Fecha.Text = ((DominioSKD.Entidades.Modulo12.Competencia)competencia).FechaInicio.ToShortDateString();
                vista.Nombre.Text = ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Nombre;
                Comando<List<Entidad>> comandoListaAC = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoListaAsistentesCompetencia(idEvento);
                List<Entidad> listaAC = comandoListaAC.Ejecutar();
                Comando<List<Entidad>> comandoListaIC = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoListaNoAsistentesCompetencia(idEvento);
                List<Entidad> listaIC = comandoListaIC.Ejecutar();

                foreach (Entidad persona in listaAC)
                {
                    vista.ListaAsis.Items.Add(((DominioSKD.Entidades.Modulo10.Persona)persona).Nombre);
                }

                foreach (Entidad persona in listaIC)
                {
                    vista.ListaNo.Items.Add(((DominioSKD.Entidades.Modulo10.Persona)persona).Nombre);
                }
            }
        }

        public bool EventoClick_Modificar(string idEvento, string tipoEvento)
        {
            bool resultado = false;
            if (tipoEvento.Equals(M10_RecursosPresentador.Evento))
            {
                #region modificarEvento
                Comando<List<Entidad>> comandoListaA = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoListaAsistentesEvento(idEvento);
                List<Entidad> listaA = comandoListaA.Ejecutar();
                Comando<List<Entidad>> comandoListaI = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoListaNoAsistentesEvento(idEvento);
                List<Entidad> listaI = comandoListaI.Ejecutar();
                List<Entidad> listaA2 = new List<Entidad>();

                foreach (Entidad persona in listaA)
                {
                    foreach (var listBoxItem in vista.ListaAsis.Items)
                    {
                        if (((DominioSKD.Entidades.Modulo10.Persona)persona).Nombre.Equals(listBoxItem.ToString()))
                        {
                            Entidad asistencia = DominioSKD.Fabrica.FabricaEntidades.ObtenerAsistencia();
                            ((DominioSKD.Entidades.Modulo10.Asistencia)asistencia).Asistio = M10_RecursosPresentador.Si;
                            Entidad evento = DominioSKD.Fabrica.FabricaEntidades.ObtenerEventoM10();
                            ((DominioSKD.Entidades.Modulo10.Evento)evento).Id = Convert.ToInt32(idEvento);
                            Entidad inscripcion = DominioSKD.Fabrica.FabricaEntidades.ObtenerInscripcion();
                            ((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion).Id = ((DominioSKD.Entidades.Modulo10.Persona)persona).IdInscripcion;
                            ((DominioSKD.Entidades.Modulo10.Asistencia)asistencia).Evento = evento as DominioSKD.Entidades.Modulo10.Evento;
                            ((DominioSKD.Entidades.Modulo10.Asistencia)asistencia).Inscripcion = inscripcion as DominioSKD.Entidades.Modulo10.Inscripcion;
                            listaA2.Add(asistencia);
                        }
                    }

                    foreach (var listBoxItem in vista.ListaNo.Items)
                    {
                        if (((DominioSKD.Entidades.Modulo10.Persona)persona).Nombre.Equals(listBoxItem.ToString()))
                        {
                            Entidad asistencia = DominioSKD.Fabrica.FabricaEntidades.ObtenerAsistencia();
                            ((DominioSKD.Entidades.Modulo10.Asistencia)asistencia).Asistio = M10_RecursosPresentador.No;
                            Entidad evento = DominioSKD.Fabrica.FabricaEntidades.ObtenerEventoM10();
                            ((DominioSKD.Entidades.Modulo10.Evento)evento).Id = Convert.ToInt32(idEvento);
                            Entidad inscripcion = DominioSKD.Fabrica.FabricaEntidades.ObtenerInscripcion();
                            ((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion).Id = ((DominioSKD.Entidades.Modulo10.Persona)persona).IdInscripcion;
                            ((DominioSKD.Entidades.Modulo10.Asistencia)asistencia).Evento = evento as DominioSKD.Entidades.Modulo10.Evento;
                            ((DominioSKD.Entidades.Modulo10.Asistencia)asistencia).Inscripcion = inscripcion as DominioSKD.Entidades.Modulo10.Inscripcion;
                            listaA2.Add(asistencia);
                        }
                    }
                }

                foreach (Entidad persona in listaI)
                {
                    foreach (var listBoxItem in vista.ListaAsis.Items)
                    {
                        if (((DominioSKD.Entidades.Modulo10.Persona)persona).Nombre.Equals(listBoxItem.ToString()))
                        {
                            Entidad asistencia = DominioSKD.Fabrica.FabricaEntidades.ObtenerAsistencia();
                            ((DominioSKD.Entidades.Modulo10.Asistencia)asistencia).Asistio = M10_RecursosPresentador.Si; 
                            Entidad evento = DominioSKD.Fabrica.FabricaEntidades.ObtenerEventoM10();
                            ((DominioSKD.Entidades.Modulo10.Evento)evento).Id = Convert.ToInt32(idEvento);
                            Entidad inscripcion = DominioSKD.Fabrica.FabricaEntidades.ObtenerInscripcion();
                            ((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion).Id = ((DominioSKD.Entidades.Modulo10.Persona)persona).IdInscripcion;
                            ((DominioSKD.Entidades.Modulo10.Asistencia)asistencia).Evento = evento as DominioSKD.Entidades.Modulo10.Evento;
                            ((DominioSKD.Entidades.Modulo10.Asistencia)asistencia).Inscripcion = inscripcion as DominioSKD.Entidades.Modulo10.Inscripcion;
                            listaA2.Add(asistencia);
                        }
                    }

                    foreach (var listBoxItem in vista.ListaNo.Items)
                    {
                        if (((DominioSKD.Entidades.Modulo10.Persona)persona).Nombre.Equals(listBoxItem.ToString()))
                        {
                            Entidad asistencia = DominioSKD.Fabrica.FabricaEntidades.ObtenerAsistencia();
                            ((DominioSKD.Entidades.Modulo10.Asistencia)asistencia).Asistio = M10_RecursosPresentador.No;
                            Entidad evento = DominioSKD.Fabrica.FabricaEntidades.ObtenerEventoM10();
                            ((DominioSKD.Entidades.Modulo10.Evento)evento).Id = Convert.ToInt32(idEvento);
                            Entidad inscripcion = DominioSKD.Fabrica.FabricaEntidades.ObtenerInscripcion();
                            ((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion).Id = ((DominioSKD.Entidades.Modulo10.Persona)persona).IdInscripcion;
                            ((DominioSKD.Entidades.Modulo10.Asistencia)asistencia).Evento = evento as DominioSKD.Entidades.Modulo10.Evento;
                            ((DominioSKD.Entidades.Modulo10.Asistencia)asistencia).Inscripcion = inscripcion as DominioSKD.Entidades.Modulo10.Inscripcion;
                            listaA2.Add(asistencia);
                        }
                    }
                }

                Comando<bool> comando = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoModificarAsistenciaEvento(listaA2);
                if (comando.Ejecutar())
                {
                    resultado = true;
                }

                #endregion
            }
            else if (tipoEvento.Equals(M10_RecursosPresentador.Competencia))
            {
                #region modificarCompetencia
                Comando<List<Entidad>> comandoListaAC = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoListaAsistentesCompetencia(idEvento);
                List<Entidad> listaAC = comandoListaAC.Ejecutar();
                Comando<List<Entidad>> comandoListaIC = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoListaNoAsistentesCompetencia(idEvento);
                List<Entidad> listaIC = comandoListaIC.Ejecutar();
                List<Entidad> listaAC2 = new List<Entidad>();

                foreach (Entidad persona in listaAC)
                {
                    foreach (var listBoxItem in vista.ListaAsis.Items)
                    {
                        if (((DominioSKD.Entidades.Modulo10.Persona)persona).Nombre.Equals(listBoxItem.ToString()))
                        {
                            Entidad asistencia = DominioSKD.Fabrica.FabricaEntidades.ObtenerAsistencia();
                            ((DominioSKD.Entidades.Modulo10.Asistencia)asistencia).Asistio = M10_RecursosPresentador.Si;
                            DominioSKD.Fabrica.FabricaEntidades fabrica = new DominioSKD.Fabrica.FabricaEntidades();
                            Entidad competencia = fabrica.ObtenerCompetencia();
                            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Id = Convert.ToInt32(idEvento);
                            Entidad inscripcion = DominioSKD.Fabrica.FabricaEntidades.ObtenerInscripcion();
                            ((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion).Id = ((DominioSKD.Entidades.Modulo10.Persona)persona).IdInscripcion;
                            ((DominioSKD.Entidades.Modulo10.Asistencia)asistencia).Competencia = competencia as DominioSKD.Entidades.Modulo12.Competencia;
                            ((DominioSKD.Entidades.Modulo10.Asistencia)asistencia).Inscripcion = inscripcion as DominioSKD.Entidades.Modulo10.Inscripcion;
                            listaAC2.Add(asistencia);
                        }
                    }

                    foreach (var listBoxItem in vista.ListaNo.Items)
                    {
                        if (((DominioSKD.Entidades.Modulo10.Persona)persona).Nombre.Equals(listBoxItem.ToString()))
                        {
                            Entidad asistencia = DominioSKD.Fabrica.FabricaEntidades.ObtenerAsistencia();
                            ((DominioSKD.Entidades.Modulo10.Asistencia)asistencia).Asistio = M10_RecursosPresentador.No;
                            DominioSKD.Fabrica.FabricaEntidades fabrica = new DominioSKD.Fabrica.FabricaEntidades();
                            Entidad competencia = fabrica.ObtenerCompetencia();
                            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Id = Convert.ToInt32(idEvento);
                            Entidad inscripcion = DominioSKD.Fabrica.FabricaEntidades.ObtenerInscripcion();
                            ((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion).Id = ((DominioSKD.Entidades.Modulo10.Persona)persona).IdInscripcion;
                            ((DominioSKD.Entidades.Modulo10.Asistencia)asistencia).Competencia = competencia as DominioSKD.Entidades.Modulo12.Competencia;
                            ((DominioSKD.Entidades.Modulo10.Asistencia)asistencia).Inscripcion = inscripcion as DominioSKD.Entidades.Modulo10.Inscripcion;
                            listaAC2.Add(asistencia);
                        }
                    }
                }

                foreach (Entidad persona in listaIC)
                {
                    foreach (var listBoxItem in vista.ListaAsis.Items)
                    {
                        if (((DominioSKD.Entidades.Modulo10.Persona)persona).Nombre.Equals(listBoxItem.ToString()))
                        {
                            Entidad asistencia = DominioSKD.Fabrica.FabricaEntidades.ObtenerAsistencia();
                            ((DominioSKD.Entidades.Modulo10.Asistencia)asistencia).Asistio = M10_RecursosPresentador.Si;
                            DominioSKD.Fabrica.FabricaEntidades fabrica = new DominioSKD.Fabrica.FabricaEntidades();
                            Entidad competencia = fabrica.ObtenerCompetencia();
                            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Id = Convert.ToInt32(idEvento);
                            Entidad inscripcion = DominioSKD.Fabrica.FabricaEntidades.ObtenerInscripcion();
                            ((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion).Id = ((DominioSKD.Entidades.Modulo10.Persona)persona).IdInscripcion;
                            ((DominioSKD.Entidades.Modulo10.Asistencia)asistencia).Competencia = competencia as DominioSKD.Entidades.Modulo12.Competencia;
                            ((DominioSKD.Entidades.Modulo10.Asistencia)asistencia).Inscripcion = inscripcion as DominioSKD.Entidades.Modulo10.Inscripcion;
                            listaAC2.Add(asistencia);
                        }
                    }

                    foreach (var listBoxItem in vista.ListaNo.Items)
                    {
                        if (((DominioSKD.Entidades.Modulo10.Persona)persona).Nombre.Equals(listBoxItem.ToString()))
                        {
                            Entidad asistencia = DominioSKD.Fabrica.FabricaEntidades.ObtenerAsistencia();
                            ((DominioSKD.Entidades.Modulo10.Asistencia)asistencia).Asistio = M10_RecursosPresentador.No;
                            DominioSKD.Fabrica.FabricaEntidades fabrica = new DominioSKD.Fabrica.FabricaEntidades();
                            Entidad competencia = fabrica.ObtenerCompetencia();
                            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Id = Convert.ToInt32(idEvento);
                            Entidad inscripcion = DominioSKD.Fabrica.FabricaEntidades.ObtenerInscripcion();
                            ((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion).Id = ((DominioSKD.Entidades.Modulo10.Persona)persona).IdInscripcion;
                            ((DominioSKD.Entidades.Modulo10.Asistencia)asistencia).Competencia = competencia as DominioSKD.Entidades.Modulo12.Competencia;
                            ((DominioSKD.Entidades.Modulo10.Asistencia)asistencia).Inscripcion = inscripcion as DominioSKD.Entidades.Modulo10.Inscripcion;
                            listaAC2.Add(asistencia);
                        }
                    }
                }

                Comando<bool> comando = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoModificarAsistenciaCompetencia(listaAC2);
                if (comando.Ejecutar())
                {
                    resultado = true;
                }
                #endregion
            }
            return resultado;
        }

        public string RedireccionarListarAsistenciaEvento()
        {
            return M10_RecursosPresentador.VentanaListarAsistenciaEvento;
        }
    }
}
