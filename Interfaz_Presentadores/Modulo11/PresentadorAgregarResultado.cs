using DominioSKD;
using Interfaz_Contratos.Modulo11;
using LogicaNegociosSKD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Interfaz_Presentadores.Modulo11
{
    public class PresentadorAgregarResultado
    {
        IContratoAgregarResultadoCompetencia vista;

        public PresentadorAgregarResultado(IContratoAgregarResultadoCompetencia vista)
        {
            this.vista = vista;
        }

        public List<Entidad> horarioEventos()
        {
            Comando<List<Entidad>> comandoEventos = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoTodasLasFechasAscensosM10();
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

        public void SeleccionandoElCalendario(string fecha)
        {
            vista.ComboEvento.Items.Clear();
            vista.ComboEspecialidad.Items.Clear();
            vista.ComboCategoria.Items.Clear();
            Comando<List<Entidad>> comandoE = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoAscensosPorFechaM10(fecha);
            Comando<List<Entidad>> comandoC = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoCompetenciasPorFecha(fecha);
            llenarComboEventoCompetencia(comandoE.Ejecutar(), comandoC.Ejecutar());
        }

        public string diccionarioEventos(string fecha, object sender)
        {
            string resultado = "";
            vista.TablaAscenso.Text = " ";
            vista.ComboEspecialidad.Items.Clear();
            vista.ComboCategoria.Items.Clear();
            vista.TablaKata.Text = " ";
            vista.TablaKumite.Text = " ";
            Comando<List<Entidad>> comandoE = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoAscensosPorFechaM10(fecha);
            List<Entidad> listaE = comandoE.Ejecutar();
            Comando<List<Entidad>> comandoC = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoCompetenciasPorFecha(fecha);
            List<Entidad> listaC = comandoC.Ejecutar();

            List<Entidad> listaEventos = new List<Entidad>();
            foreach (Entidad evento in listaE)
            {
                Entidad valor = DominioSKD.Fabrica.FabricaEntidades.ObtenerValores();
                ((DominioSKD.Entidades.Modulo10.Valores)valor).Id = ((DominioSKD.Entidades.Modulo10.Evento)evento).Id;
                ((DominioSKD.Entidades.Modulo10.Valores)valor).Nombre = ((DominioSKD.Entidades.Modulo10.Evento)evento).Nombre;
                ((DominioSKD.Entidades.Modulo10.Valores)valor).Tipo = M11_RecursosPresentador.Evento;
                listaEventos.Add(valor);
            }
            foreach (Entidad competencia in listaC)
            {
                Entidad valor = DominioSKD.Fabrica.FabricaEntidades.ObtenerValores();
                ((DominioSKD.Entidades.Modulo10.Valores)valor).Id = ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Id;
                ((DominioSKD.Entidades.Modulo10.Valores)valor).Nombre = ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Nombre;
                ((DominioSKD.Entidades.Modulo10.Valores)valor).Tipo = M11_RecursosPresentador.Competencia;
                listaEventos.Add(valor);
            }

            foreach (Entidad valores in listaEventos)
            {
                if ((Convert.ToInt32(((DropDownList)sender).SelectedItem.Value).Equals(((DominioSKD.Entidades.Modulo10.Valores)valores).Id)) && (((DropDownList)sender).SelectedItem.Text.Equals(((DominioSKD.Entidades.Modulo10.Valores)valores).Nombre)))
                {
                    resultado = ((DominioSKD.Entidades.Modulo10.Valores)valores).Tipo;
                }
            }
            return resultado;
        }

        public void LlenarComboCategoria_o_LlenarComboEspecialidad(string idEvento, string tipo)
        {
            if (tipo.Equals(M11_RecursosPresentador.Evento))
            {
                vista.LEspecialidad = false;
                vista.ComboEspecialidad.Visible = false;
                Comando<List<Entidad>> comandoCategoriasEvento = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoListaCategoriaEvento(idEvento);
                llenarComboCategoria(comandoCategoriasEvento.Ejecutar());
            }
            else if (tipo.Equals(M11_RecursosPresentador.Competencia))
            {
                vista.LEspecialidad = true;
                vista.ComboEspecialidad.Visible = true;
                vista.LPosicion = true;
                vista.Posiciones.Visible = true;
                Comando<List<string>> comandoEspecialidad = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoListaEspecialidadesCompetencia(idEvento);
                llenarComboEspecialidad(comandoEspecialidad.Ejecutar());
            }
        }

        public void LLenarComboCategoria_DespuesDeEspecialidad(string idEvento, string especialidad)
        {
            vista.TablaAscenso.Text = " ";
            vista.ComboCategoria.Items.Clear();
            vista.TablaKata.Text = " ";
            vista.TablaKumite.Text = " ";
            Entidad competencia = DominioSKD.Fabrica.FabricaEntidades.ObtenerCompetencia();
            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Id = Convert.ToInt32(idEvento);
            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).TipoCompetencia = especialidad;
            Comando<List<Entidad>> comando = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoListaCategoriaCompetencia(competencia);
            llenarComboCategoria(comando.Ejecutar());
        }

        public void CargarTablas_LuegoDeCategoria(string idEvento, string tipoEvento, string especialidad, string idCategoria)
        {
            vista.TablaAscenso.Text = " ";
            vista.TablaKata.Text = " ";
            vista.TablaKumite.Text = " ";
            if (tipoEvento.Equals(M11_RecursosPresentador.Evento))
            {
                #region Carga de tabla de Atletas que compiten en un Evento Ascenso
                CargarTablaAscenso(idEvento, idCategoria);
                #endregion
            }
            else if (tipoEvento.Equals(M11_RecursosPresentador.Competencia))
            {
                Entidad competencia = DominioSKD.Fabrica.FabricaEntidades.ObtenerCompetencia();
                ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Id = Convert.ToInt32(idEvento);
                ((DominioSKD.Entidades.Modulo12.Competencia)competencia).TipoCompetencia = especialidad;
                Entidad categoria = DominioSKD.Fabrica.FabricaEntidades.ObtenerCategoria();
                ((DominioSKD.Entidades.Modulo12.Categoria)categoria).Id = Convert.ToInt32(idCategoria);
                ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Categoria = categoria as DominioSKD.Entidades.Modulo12.Categoria;
                CargarTablas_Kata_Kumite_Ambos(competencia, especialidad);
            }
        }

        private void llenarComboEventoCompetencia(List<Entidad> eventos, List<Entidad> competencias)
        {
            Dictionary<int, string> listaEventos = new Dictionary<int, string>();
            listaEventos.Add(0, "Seleccionar Evento:");
            foreach (Entidad evento in eventos)
            {
                listaEventos.Add(((DominioSKD.Entidades.Modulo10.Evento)evento).Id, ((DominioSKD.Entidades.Modulo10.Evento)evento).Nombre);
            }
            foreach (Entidad competencia in competencias)
            {
                listaEventos.Add(((DominioSKD.Entidades.Modulo12.Competencia)competencia).Id, ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Nombre);
            }
            vista.ComboEvento.DataSource = listaEventos;
            vista.ComboEvento.DataTextField = M11_RecursosPresentador.Value;
            vista.ComboEvento.DataValueField = M11_RecursosPresentador.Key;
            vista.ComboEvento.DataBind();
        }

        private void llenarComboCategoria(List<Entidad> lista)
        {
            Dictionary<int, string> listaCategoria = new Dictionary<int, string>();
            listaCategoria.Add(0, M11_RecursosPresentador.SeleccionarCategoria);
            foreach (Entidad categoria in lista)
            {
                string nombre = " ";
                nombre = ((DominioSKD.Entidades.Modulo12.Categoria)categoria).Edad_inicial.ToString() + " a " + ((DominioSKD.Entidades.Modulo12.Categoria)categoria).Edad_final.ToString() + " años " + ((DominioSKD.Entidades.Modulo12.Categoria)categoria).Cinta_inicial + " - " + ((DominioSKD.Entidades.Modulo12.Categoria)categoria).Cinta_final + " " + ((DominioSKD.Entidades.Modulo12.Categoria)categoria).Sexo;
                listaCategoria.Add(((DominioSKD.Entidades.Modulo12.Categoria)categoria).Id, nombre);
            }
            vista.ComboCategoria.DataSource = listaCategoria;
            vista.ComboCategoria.DataTextField = M11_RecursosPresentador.Value;
            vista.ComboCategoria.DataValueField = M11_RecursosPresentador.Key;
            vista.ComboCategoria.DataBind();
        }

        private void llenarComboEspecialidad(List<string> lista)
        {
            Dictionary<int, string> listaEspecialidad = new Dictionary<int, string>();
            listaEspecialidad.Add(0, M11_RecursosPresentador.SeleccionarEspecialidad);
            foreach (string especialidad in lista)
            {
                string nuevo = "";
                if (especialidad.Equals("1"))
                {
                    nuevo = "Kata";
                }
                else if (especialidad.Equals("2"))
                {
                    nuevo = "Kumite";
                }
                else if (especialidad.Equals("3"))
                {
                    nuevo = "Kata y Kumite";
                }
                listaEspecialidad.Add(Convert.ToInt32(especialidad), nuevo);
            }
            vista.ComboEspecialidad.DataSource = listaEspecialidad;
            vista.ComboEspecialidad.DataTextField = M11_RecursosPresentador.Value;
            vista.ComboEspecialidad.DataValueField = M11_RecursosPresentador.Key;
            vista.ComboEspecialidad.DataBind();
        }
        private void CargarTablaAscenso(string idEvento, string idCategoria)
        {
            try
            {
                Entidad evento = DominioSKD.Fabrica.FabricaEntidades.ObtenerEventoM10();
                ((DominioSKD.Entidades.Modulo10.Evento)evento).Id = Convert.ToInt32(idEvento);
                Entidad categoria = DominioSKD.Fabrica.FabricaEntidades.ObtenerCategoria();
                ((DominioSKD.Entidades.Modulo12.Categoria)categoria).Id = Convert.ToInt32(idCategoria);
                ((DominioSKD.Entidades.Modulo10.Evento)evento).Categoria = categoria as DominioSKD.Entidades.Modulo12.Categoria;

                Comando<List<Entidad>> comando = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoListaInscritosExamenAscenso(evento);
                List<Entidad> inscripciones = comando.Ejecutar();

                foreach (Entidad inscripcion in inscripciones)
                {
                    vista.TablaAscenso.Text += M11_RecursosPresentador.AbrirTR;
                    vista.TablaAscenso.Text += M11_RecursosPresentador.AbrirTD + ((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion).Persona.Nombre + " " + ((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion).Persona.Apellido + M11_RecursosPresentador.CerrarTD;
                    vista.TablaAscenso.Text += M11_RecursosPresentador.AbrirTD;
                    vista.TablaAscenso.Text += M11_RecursosPresentador.Seleccionar;
                    vista.TablaAscenso.Text += M11_RecursosPresentador.CerrarTD;
                    vista.TablaAscenso.Text += M11_RecursosPresentador.CerrarTR;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarTablas_Kata_Kumite_Ambos(Entidad competencia, string especialidad)
        {
            if (especialidad.ToString().Equals(M11_RecursosPresentador.especialidadKata))
            {
                vista.Boton.Visible = false;
                vista.BotonKata.Visible = true;
                #region Carga de tabla de Atletas que compiten en una competencia de tipo kata
                Comando<List<Entidad>> comando = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoListaInscritosCompetencia(competencia);
                List<Entidad> inscripciones = comando.Ejecutar();
                //CargarKata(inscripciones);
                #endregion
            }
            else if (especialidad.ToString().Equals(M11_RecursosPresentador.especialidadKumite))
            {
                vista.Boton.Visible = false;
                vista.BotonKumite.Visible = true;
                #region Carga de tabla de Atletas que compiten en una competencia de tipo kumite
                Comando<List<Entidad>> comando = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoListaInscritosCompetencia(competencia);
                List<Entidad> listaKumite = comando.Ejecutar();
                //CargarKumite(listaKumite);
                #endregion
            }
            else if (especialidad.ToString().Equals(M11_RecursosPresentador.especialidadAmbos))
            {
                vista.Boton.Visible = false;
                vista.BotonAmbos.Visible = true;
                #region Carga de tabla de Atletas que compiten en una competencia de tipo kata Ambos
                Comando<List<Entidad>> comando = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoListaAtletasParticipanCompetenciaKataAmbos(competencia);
                List<Entidad> inscripciones = comando.Ejecutar();
                //CargarKata(inscripciones);
                #endregion
                #region Carga de tabla de Atletas que compiten en una competencia de tipo kumite Ambos
                ((DominioSKD.Entidades.Modulo12.Competencia)competencia).TipoCompetencia = M11_RecursosPresentador.especialidadKataKumite;
                Comando<List<Entidad>> comandoKumite = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoListaAtletasParticipanCompetenciaKumiteAmbos(competencia);
                List<Entidad> listaKumite = comandoKumite.Ejecutar();
                //CargarKumite(listaKumite);
                #endregion

            }
        }
    }
}
