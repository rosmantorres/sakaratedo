using DominioSKD;
using Interfaz_Contratos.Modulo10;
using LogicaNegociosSKD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Interfaz_Presentadores.Modulo10
{
    public class PresentadorAgregarAsistencia
    {
        IContratoAgregarAsistencia vista;

        public PresentadorAgregarAsistencia(IContratoAgregarAsistencia vista)
        {
            this.vista = vista;
        }

        public List<Entidad> horarioEventos()
        {
            Comando<List<Entidad>> comandoEventos = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoTodasLasFechasEventoM10();
            List<Entidad> eventos = comandoEventos.Ejecutar();
            Comando<List<Entidad>> comandoCompetencias = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoListarHorariosCompetencia();
            List<Entidad> competencias = comandoCompetencias.Ejecutar();

            List<Entidad> listaEventos = new List<Entidad>();
            foreach (Entidad horario in eventos)
            {
                listaEventos.Add(horario);
            }
            foreach (Entidad horario in competencias)
            {
                if (!listaEventos.Contains(horario))
                {
                    listaEventos.Add(horario);
                }
            }
            return listaEventos;
        }

        private void cambioDeEvento()
        {
            vista.inscritos.Items.Clear();
            vista.asistentes.Items.Clear();
            vista.ausentesPlanilla.Text = " ";
        }

        public void CargarComboEvento(string fecha)
        {
            cambioDeEvento();
            Comando<List<Entidad>> comandoListaE = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoEventosPorRangosdeFechaM10(fecha);
            List<Entidad> listaE = comandoListaE.Ejecutar();
            Comando<List<Entidad>> comandoListaC = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoCompetenciasPorFecha(fecha);
            List<Entidad> listaC = comandoListaC.Ejecutar();

            Dictionary<int, string> listaEventos = new Dictionary<int, string>();
            listaEventos.Add(0, "Seleccionar Evento:");
            foreach (Entidad evento in listaE)
            {
                listaEventos.Add(((DominioSKD.Entidades.Modulo10.Evento)evento).Id, ((DominioSKD.Entidades.Modulo10.Evento)evento).Nombre);
            }
            foreach (Entidad competencia in listaC)
            {
                listaEventos.Add(((DominioSKD.Entidades.Modulo12.Competencia)competencia).Id, ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Nombre);
            }
            vista.comboEvento.DataSource = listaEventos;
            vista.comboEvento.DataTextField = M10_RecursosPresentador.Value;
            vista.comboEvento.DataValueField = M10_RecursosPresentador.Key;
            vista.comboEvento.DataBind();
        }

        public List<Entidad> diccionarioEventos(string fecha)
        {
            cambioDeEvento();
            Comando<List<Entidad>> comandoListaE = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoEventosPorRangosdeFechaM10(fecha);
            List<Entidad> listaE = comandoListaE.Ejecutar();
            Comando<List<Entidad>> comandoListaC = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoCompetenciasPorFecha(fecha);
            List<Entidad> listaC = comandoListaC.Ejecutar();

            List<Entidad> listaEventos = new List<Entidad>();
            foreach (Entidad evento in listaE)
            {
                Entidad valores = DominioSKD.Fabrica.FabricaEntidades.ObtenerValores();
                ((DominioSKD.Entidades.Modulo10.Valores)valores).Id = ((DominioSKD.Entidades.Modulo10.Evento)evento).Id;
                ((DominioSKD.Entidades.Modulo10.Valores)valores).Nombre = ((DominioSKD.Entidades.Modulo10.Evento)evento).Nombre;
                ((DominioSKD.Entidades.Modulo10.Valores)valores).Tipo = M10_RecursosPresentador.Evento;
                listaEventos.Add(valores);
            }
            foreach (Entidad competencia in listaC)
            {
                Entidad valores = DominioSKD.Fabrica.FabricaEntidades.ObtenerValores();
                ((DominioSKD.Entidades.Modulo10.Valores)valores).Id = ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Id;
                ((DominioSKD.Entidades.Modulo10.Valores)valores).Nombre = ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Nombre;
                ((DominioSKD.Entidades.Modulo10.Valores)valores).Tipo = M10_RecursosPresentador.Competencia;
                listaEventos.Add(valores);
            }
            return listaEventos;
        }

        public string buscandoTipoEnValores(List<Entidad> listaEventos, object sender)
        {
            string tipo = "";
            foreach (Entidad valores in listaEventos)
            {
                if ((Convert.ToInt32(((DropDownList)sender).SelectedItem.Value).Equals(((DominioSKD.Entidades.Modulo10.Valores)valores).Id)) && (((DropDownList)sender).SelectedItem.Text.Equals(((DominioSKD.Entidades.Modulo10.Valores)valores).Nombre)))
                {
                    tipo = ((DominioSKD.Entidades.Modulo10.Valores)valores).Tipo;
                }
            }
            return tipo;
        }

        public string CargarListaInscritos_InasistentesPlanilla(string tipo, object sender)
        {
            string idEvento = "";
            if (tipo.Equals(M10_RecursosPresentador.Evento))
            {
                Comando<List<Entidad>> comando = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoListaAtletasInscritosEvento(((DropDownList)sender).SelectedItem.Value);
                List<Entidad> atletasIE = comando.Ejecutar();
                idEvento = ((DropDownList)sender).SelectedItem.Value;
                foreach (Entidad persona in atletasIE)
                {
                    vista.inscritos.Items.Add(((DominioSKD.Entidades.Modulo10.Persona)persona).Nombre);
                }
                InasistentesEvento(sender);
            }
            else if (tipo.Equals(M10_RecursosPresentador.Competencia))
            {
                Comando<List<Entidad>> comando = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoListaAtletasInscritosCompetencia(((DropDownList)sender).SelectedItem.Value);
                List<Entidad> atletasIC = comando.Ejecutar();
                idEvento = ((DropDownList)sender).SelectedItem.Value;
                foreach (Entidad persona in atletasIC)
                {
                    vista.inscritos.Items.Add(((DominioSKD.Entidades.Modulo10.Persona)persona).Nombre);
                }
                InasistentesCompetencia(sender);
            }
            return idEvento;
        }

        public void InasistentesEvento(object sender)
        {
            #region Carga de tabla de Atletas inasistentes a dicho evento
            try
            {
                Comando<List<Entidad>> comando = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoListaInasistentesPlanillaEvento(((DropDownList)sender).SelectedItem.Value);
                List<Entidad> inscripciones = comando.Ejecutar();
                foreach (Entidad inscripcion in inscripciones)
                {
                    vista.ausentesPlanilla.Text += M10_RecursosPresentador.AbrirTR;
                    vista.ausentesPlanilla.Text += M10_RecursosPresentador.AbrirTD + ((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion).Persona.Nombre + " " + ((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion).Persona.Apellido + M10_RecursosPresentador.CerrarTD;
                    vista.ausentesPlanilla.Text += M10_RecursosPresentador.AbrirTD + ((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion).Solicitud.Planilla.Nombre + M10_RecursosPresentador.CerrarTD;
                    vista.ausentesPlanilla.Text += M10_RecursosPresentador.CerrarTR;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            #endregion
        }

        public void InasistentesCompetencia(object sender)
        {
            #region Carga de tabla de Atletas inasistentes a dicha competencia
            try
            {
                Comando<List<Entidad>> comando = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoListaInasistentesPlanillaCompetencia(((DropDownList)sender).SelectedItem.Value);
                List<Entidad> inscripciones = comando.Ejecutar();
                foreach (Entidad inscripcion in inscripciones)
                {
                    vista.ausentesPlanilla.Text += M10_RecursosPresentador.AbrirTR;
                    vista.ausentesPlanilla.Text += M10_RecursosPresentador.AbrirTD + ((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion).Persona.Nombre + " " + ((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion).Persona.Apellido + M10_RecursosPresentador.CerrarTD;
                    vista.ausentesPlanilla.Text += M10_RecursosPresentador.AbrirTD + ((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion).Solicitud.Planilla.Nombre + M10_RecursosPresentador.CerrarTD;
                    vista.ausentesPlanilla.Text += M10_RecursosPresentador.CerrarTR;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            #endregion
        }

        public string RedireccionarListarAsistenciaEvento()
        {
            return M10_RecursosPresentador.VentanaListarAsistenciaEvento;
        }

        public void MoverIzquierda()
        {
            for (int i = vista.asistentes.Items.Count - 1; i >= 0; i--)
            {
                if (vista.asistentes.Items[i].Selected == true)
                {
                    vista.inscritos.Items.Add(vista.asistentes.Items[i]);
                    ListItem li = vista.asistentes.Items[i];
                    vista.asistentes.Items.Remove(li);
                }
            }
        }

        public void MoverDerecha()
        {
            for (int i = vista.inscritos.Items.Count - 1; i >= 0; i--)
            {
                if (vista.inscritos.Items[i].Selected == true)
                {
                    vista.asistentes.Items.Add(vista.inscritos.Items[i]);
                    ListItem li = vista.inscritos.Items[i];
                    vista.inscritos.Items.Remove(li);
                }
            }
        }

        public bool AgregarAsistenciaEvento(string idEvento)
        {
            Comando<List<Entidad>> comando = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoListaAtletasInscritosEvento(idEvento);
            List<Entidad> atletasIE = comando.Ejecutar();
            List<Entidad> listaA = new List<Entidad>();
            bool resultado = false;
            foreach (Entidad persona in atletasIE)
            {
                foreach (var listBoxItem in vista.asistentes.Items)
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
                        listaA.Add(asistencia);
                    }
                }

                foreach (var listBoxItem in vista.inscritos.Items)
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
                        listaA.Add(asistencia);
                    }
                }
            }

            Comando<bool> comandoAgregar = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoAgregarAsistenciaEvento(listaA);
            if (comandoAgregar.Ejecutar())
            {
                resultado = true;
            }
            return resultado;
        }

        public bool AgregarAsistenciaCompetencia(string idEvento)
        {
            Comando<List<Entidad>> comando = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoListaAtletasInscritosCompetencia(idEvento);
            List<Entidad> atletasIC = comando.Ejecutar();
            List<Entidad> listaA = new List<Entidad>();
            bool resultado = false;
            foreach (Entidad persona in atletasIC)
            {
                foreach (var listBoxItem in vista.asistentes.Items)
                {
                    if (((DominioSKD.Entidades.Modulo10.Persona)persona).Nombre.Equals(listBoxItem.ToString()))
                    {
                        Entidad asistencia = DominioSKD.Fabrica.FabricaEntidades.ObtenerAsistencia();
                        ((DominioSKD.Entidades.Modulo10.Asistencia)asistencia).Asistio = M10_RecursosPresentador.Si;
                        Entidad competencia = DominioSKD.Fabrica.FabricaEntidades.ObtenerCompetencia();
                        ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Id = Convert.ToInt32(idEvento);
                        Entidad inscripcion = DominioSKD.Fabrica.FabricaEntidades.ObtenerInscripcion();
                        ((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion).Id = ((DominioSKD.Entidades.Modulo10.Persona)persona).IdInscripcion;
                        ((DominioSKD.Entidades.Modulo10.Asistencia)asistencia).Competencia = competencia as DominioSKD.Entidades.Modulo12.Competencia;
                        ((DominioSKD.Entidades.Modulo10.Asistencia)asistencia).Inscripcion = inscripcion as DominioSKD.Entidades.Modulo10.Inscripcion;
                        listaA.Add(asistencia);
                    }
                }

                foreach (var listBoxItem in vista.inscritos.Items)
                {
                    if (((DominioSKD.Entidades.Modulo10.Persona)persona).Nombre.Equals(listBoxItem.ToString()))
                    {
                        Entidad asistencia = DominioSKD.Fabrica.FabricaEntidades.ObtenerAsistencia();
                        ((DominioSKD.Entidades.Modulo10.Asistencia)asistencia).Asistio = M10_RecursosPresentador.No;
                        Entidad competencia = DominioSKD.Fabrica.FabricaEntidades.ObtenerCompetencia();
                        ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Id = Convert.ToInt32(idEvento);
                        Entidad inscripcion = DominioSKD.Fabrica.FabricaEntidades.ObtenerInscripcion();
                        ((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion).Id = ((DominioSKD.Entidades.Modulo10.Persona)persona).IdInscripcion;
                        ((DominioSKD.Entidades.Modulo10.Asistencia)asistencia).Competencia = competencia as DominioSKD.Entidades.Modulo12.Competencia;
                        ((DominioSKD.Entidades.Modulo10.Asistencia)asistencia).Inscripcion = inscripcion as DominioSKD.Entidades.Modulo10.Inscripcion;
                        listaA.Add(asistencia);
                    }
                }
            }

            Comando<bool> comandoAgregar = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoAgregarAsistenciaCompetencia(listaA);
            if (comandoAgregar.Ejecutar())
            {
                resultado = true;
            }
            return resultado;
        }

        public void RenderCalendario(DayRenderEventArgs e, List<Entidad> horariosEventos)
        {
            e.Day.IsSelectable = false;
            if (e.Day.IsSelected)
                e.Cell.Style["background-color"] = "Red";
            #region Horarios de Eventos y Competencias
            foreach (Entidad horario in horariosEventos)
            {
                if (e.Day.IsSelected)
                    e.Cell.Style["background-color"] = "Red";
                else if (e.Day.Date == ((DominioSKD.Entidades.Modulo10.Horario)horario).FechaInicio)
                {
                    e.Cell.Style["background-color"] = "Blue";
                    DateTime date1 = e.Day.Date.Date;
                    DateTime date2 = DateTime.Now.Date;
                    if (date1 >= date2)
                    {
                        e.Day.IsSelectable = true;
                    }
                }
            }
            #endregion
        }
    }
}
