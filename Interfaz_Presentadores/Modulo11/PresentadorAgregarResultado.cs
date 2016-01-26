using DominioSKD;
using DominioSKD.Entidades.Modulo11;
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

        public bool CargarTablas_LuegoDeCategoria(string idEvento, string tipoEvento, string especialidad, string idCategoria, Entidad numero)
        {
            bool rango = false;
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
                rango = CargarTablas_Kata_Kumite_Ambos(competencia, especialidad, numero);
            }
            return rango;
        }

        public bool CargarTablas_LuegoDeSiguiente(string idEvento, string especialidad, string idCategoria, string rango, List<ValorKataKumite> valores, Entidad numero)
        {
            bool and = false;
            vista.DivAlerta = false;
            Entidad competencia = DominioSKD.Fabrica.FabricaEntidades.ObtenerCompetencia();
            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Id = Convert.ToInt32(idEvento);
            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).TipoCompetencia = especialidad;
            Entidad categoria = DominioSKD.Fabrica.FabricaEntidades.ObtenerCategoria();
            ((DominioSKD.Entidades.Modulo12.Categoria)categoria).Id = Convert.ToInt32(idCategoria);
            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Categoria = categoria as DominioSKD.Entidades.Modulo12.Categoria;

            if (especialidad.ToString().Equals(M11_RecursosPresentador.especialidadKumite))
            {
                #region Carga de tabla de Atletas compitiendo
                try
                {
                    if (Convert.ToInt32(rango.ToString()) >= 1)
                    {
                        Comando<List<Entidad>> comandoIns = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoListaInscritosCompetencia(competencia);
                        List<Entidad> listaInscripciones = comandoIns.Ejecutar();
                        List<Entidad> inscripciones = new List<Entidad>();
                        List<Entidad> listaKumite = new List<Entidad>();

                        bool bleh = listaAtletasCompitiendo_AgregandoAnteriores(listaInscripciones, valores, inscripciones, listaKumite);
                        if (bleh.Equals(false))
                        {
                            listaKumite = crearRandomPeleas(inscripciones, Convert.ToInt32(rango));
                            CargarKumite(listaKumite);
                        }
                        else if (bleh.Equals(true))
                        {
                            int num = Convert.ToInt32(rango) * 2;
                            ((DominioSKD.Entidades.Modulo10.Valores)numero).Nombre = num.ToString();
                            and = true;
                            ListaEmpate(listaKumite);
                            vista.DivAlerta = true;
                            vista.alertaClase = M11_RecursosPresentador.AlertaWarning;
                            vista.alertaRol = M11_RecursosPresentador.Alerta;
                            vista.alerta = M11_RecursosPresentador.EmpatesNoPermitidos;
                        }
                    }
                    else if (Convert.ToInt32(rango.ToString()) < 1)
                    {
                        if (!verificandoEmpate(valores))
                        {
                            ListaFinal(valores);
                            primeroSegundo(valores);
                            vista.BotonSiguiente.Visible = false;
                            vista.BotonKumite.Enabled = true;
                        }
                        else if (verificandoEmpate(valores))
                        {
                            ListaFinal(valores);
                            vista.BotonSiguiente.Visible = true;
                            vista.BotonKumite.Enabled = false;
                            int num = Convert.ToInt32(rango) + 1;
                            ((DominioSKD.Entidades.Modulo10.Valores)numero).Nombre = num.ToString();
                            and = true;
                            vista.DivAlerta = true;
                            vista.alertaClase = M11_RecursosPresentador.AlertaWarning;
                            vista.alertaRol = M11_RecursosPresentador.Alerta;
                            vista.alerta = M11_RecursosPresentador.EmpatesNoPermitidos;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                #endregion
            }
            else if (especialidad.ToString().Equals(M11_RecursosPresentador.especialidadAmbos))
            {
                #region Carga de tabla de Atletas compitiendo ambos
                try
                {
                    if (Convert.ToInt32(rango.ToString()) >= 1)
                    {
                        Comando<List<Entidad>> comandoIns = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoListaInscritosCompetencia(competencia);
                        List<Entidad> listaInscripciones = comandoIns.Ejecutar();
                        List<Entidad> inscripciones = new List<Entidad>();
                        List<Entidad> listaKumite = new List<Entidad>();

                        bool bleh = listaAtletasCompitiendo_AgregandoAnteriores(listaInscripciones, valores, inscripciones, listaKumite);
                        if (bleh.Equals(false))
                        {
                            listaKumite = crearRandomPeleas(inscripciones, Convert.ToInt32(rango));
                            CargarKumite(listaKumite);
                        }
                        else if (bleh.Equals(true))
                        {
                            int num = Convert.ToInt32(rango) * 2;
                            ((DominioSKD.Entidades.Modulo10.Valores)numero).Nombre = num.ToString();
                            and = true;
                            ListaEmpate(listaKumite);
                            vista.DivAlerta = true;
                            vista.alertaClase = M11_RecursosPresentador.AlertaWarning;
                            vista.alertaRol = M11_RecursosPresentador.Alerta;
                            vista.alerta = M11_RecursosPresentador.EmpatesNoPermitidos;
                        }
                    }
                    else if (Convert.ToInt32(rango.ToString()) < 1)
                    {
                        if (!verificandoEmpate(valores))
                        {
                            ListaFinal(valores);
                            primeroSegundo(valores);
                            vista.BotonSiguiente.Visible = false;
                            vista.BotonAmbos.Enabled = true;
                        }
                        else if (verificandoEmpate(valores))
                        {
                            ListaFinal(valores);
                            vista.BotonSiguiente.Visible = true;
                            vista.BotonAmbos.Enabled = false;
                            int num = Convert.ToInt32(rango) + 1;
                            ((DominioSKD.Entidades.Modulo10.Valores)numero).Nombre = num.ToString();
                            and = true;
                            vista.DivAlerta = true;
                            vista.alertaClase = M11_RecursosPresentador.AlertaWarning;
                            vista.alertaRol = M11_RecursosPresentador.Alerta;
                            vista.alerta = M11_RecursosPresentador.EmpatesNoPermitidos;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                #endregion
            }
            return and;
        }

        public bool CargarTablas_LuegoDeSiguienteAmbos(string idEvento, string especialidad, string idCategoria, string rango, List<ValorKataKumite> valores, Entidad numero, List<ValorKataKumite> valores2)
        {
            bool and = false;
            Entidad competencia = DominioSKD.Fabrica.FabricaEntidades.ObtenerCompetencia();
            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Id = Convert.ToInt32(idEvento);
            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).TipoCompetencia = especialidad;
            Entidad categoria = DominioSKD.Fabrica.FabricaEntidades.ObtenerCategoria();
            ((DominioSKD.Entidades.Modulo12.Categoria)categoria).Id = Convert.ToInt32(idCategoria);
            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Categoria = categoria as DominioSKD.Entidades.Modulo12.Categoria;

            if (especialidad.ToString().Equals(M11_RecursosPresentador.especialidadAmbos))
            {
                #region Carga de tabla de Atletas compitiendo ambos
                try
                {
                    if (Convert.ToInt32(rango.ToString()) >= 1)
                    {
                        Comando<List<Entidad>> comandoIns = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoListaInscritosCompetencia(competencia);
                        List<Entidad> listaInscripciones = comandoIns.Ejecutar();
                        List<Entidad> inscripciones = new List<Entidad>();
                        List<Entidad> listaKumite = new List<Entidad>();

                        bool bleh = listaAtletasCompitiendo_AgregandoAnteriores(listaInscripciones, valores, inscripciones, listaKumite);
                        if (bleh.Equals(false))
                        {
                            listaKumite = crearRandomPeleas(inscripciones, Convert.ToInt32(rango));
                            CargarKumite(listaKumite);
                        }
                        else if (bleh.Equals(true))
                        {
                            int num = Convert.ToInt32(rango) * 2;
                            ((DominioSKD.Entidades.Modulo10.Valores)numero).Nombre = num.ToString();
                            and = true;
                            ListaEmpate(listaKumite);
                            vista.DivAlerta = true;
                            vista.alertaClase = M11_RecursosPresentador.AlertaWarning;
                            vista.alertaRol = M11_RecursosPresentador.Alerta;
                            vista.alerta = M11_RecursosPresentador.EmpatesNoPermitidos;
                        }
                    }

                    #region Agregar Competencia tipo kata
                    Comando<List<Entidad>> comando = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoListaInscritosCompetencia(competencia);
                    List<Entidad> inscripciones2 = comando.Ejecutar();
                    List<Entidad> listaResultado = new List<Entidad>();

                    foreach (Entidad inscripcion in inscripciones2)
                    {
                        foreach (ValorKataKumite valor in valores2)
                        {
                            if (((((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion).Persona.Nombre + " " + ((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion).Persona.Apellido).Equals(valor.Nombre)))
                            {
                                Entidad resultado = DominioSKD.Fabrica.FabricaEntidades.ObtenerResultadoKata();
                                ((DominioSKD.Entidades.Modulo11.ResultadoKata)resultado).Inscripcion = inscripcion as DominioSKD.Entidades.Modulo10.Inscripcion;
                                ((DominioSKD.Entidades.Modulo11.ResultadoKata)resultado).Inscripcion.Competencia.Id = Convert.ToInt32(idEvento);
                                ((DominioSKD.Entidades.Modulo11.ResultadoKata)resultado).Jurado1 = Convert.ToInt32(valor.Resultado1);
                                ((DominioSKD.Entidades.Modulo11.ResultadoKata)resultado).Jurado2 = Convert.ToInt32(valor.Resultado2);
                                ((DominioSKD.Entidades.Modulo11.ResultadoKata)resultado).Jurado3 = Convert.ToInt32(valor.Resultado3);
                                listaResultado.Add(resultado);
                            }
                        }
                    }
                    Comando<bool> comandoAgregar = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoAgregarResultadoKata(listaResultado);
                    comandoAgregar.Ejecutar();
                    #endregion
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                #endregion
            }
            vista.BotonSiguienteAmbos.Visible = false;
            vista.BotonSiguiente.Visible = true;
            vista.TablaKata.Text = " ";
            return and;
        }

        public string RedireccionarListarAsistenciaEvento()
        {
            return M11_RecursosPresentador.VentanaListarResultadoCompetencia;
        }

        public bool BAgregar_Click(string idEvento, string idCategoria, List<ValorEvento> valores)
        {
            #region Agregar Examen de Ascenso
            bool respuesta = false;
            Entidad evento = DominioSKD.Fabrica.FabricaEntidades.ObtenerEventoM10();
            ((DominioSKD.Entidades.Modulo10.Evento)evento).Id = Convert.ToInt32(idEvento);
            Entidad categoria = DominioSKD.Fabrica.FabricaEntidades.ObtenerCategoria();
            ((DominioSKD.Entidades.Modulo12.Categoria)categoria).Id = Convert.ToInt32(idCategoria);
            ((DominioSKD.Entidades.Modulo10.Evento)evento).Categoria = categoria as DominioSKD.Entidades.Modulo12.Categoria;
            try
            {
                Comando<List<Entidad>> comandoInscritos = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoListaInscritosExamenAscenso(evento);
                List<Entidad> inscripciones = comandoInscritos.Ejecutar();
                List<Entidad> listaResultado = new List<Entidad>();

                foreach (Entidad inscripcion in inscripciones)
                {
                    foreach (ValorEvento valor in valores)
                    {
                        string aprobado = buscarAprobado(valor);
                        if ((((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion).Persona.Nombre + " " + ((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion).Persona.Apellido).Equals(valor.Nombre))
                        {
                            Entidad resultado = DominioSKD.Fabrica.FabricaEntidades.ObtenerResultadoAscenso();
                            ((DominioSKD.Entidades.Modulo11.ResultadoAscenso)resultado).Inscripcion = inscripcion as DominioSKD.Entidades.Modulo10.Inscripcion;
                            ((DominioSKD.Entidades.Modulo11.ResultadoAscenso)resultado).Inscripcion.Evento.Id = Convert.ToInt32(idEvento);
                            ((DominioSKD.Entidades.Modulo11.ResultadoAscenso)resultado).Aprobado = aprobado;
                            listaResultado.Add(resultado);
                        }
                    }
                }

                Comando<bool> comandoAgregar = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoAgregarResultadoAscenso(listaResultado);
                if (comandoAgregar.Ejecutar())
                {
                    respuesta = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return respuesta;
            #endregion
        }

        public bool BAgregarKata_Click(string idEvento, string especialidad, string idCategoria, List<ValorKataKumite> valores)
        {
            #region Agregar Competencia tipo kata
            bool respuesta = false;
            Entidad competencia = DominioSKD.Fabrica.FabricaEntidades.ObtenerCompetencia();
            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Id = Convert.ToInt32(idEvento);
            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).TipoCompetencia = especialidad;
            Entidad categoria = DominioSKD.Fabrica.FabricaEntidades.ObtenerCategoria();
            ((DominioSKD.Entidades.Modulo12.Categoria)categoria).Id = Convert.ToInt32(idCategoria);
            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Categoria = categoria as DominioSKD.Entidades.Modulo12.Categoria;

            try
            {
                Comando<List<Entidad>> comandoIns = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoListaInscritosCompetencia(competencia);
                List<Entidad> inscripciones = comandoIns.Ejecutar();
                List<Entidad> listaResultado = new List<Entidad>();

                foreach (Entidad inscripcion in inscripciones)
                {
                    foreach (ValorKataKumite valor in valores)
                    {
                        if (((((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion).Persona.Nombre + " " + ((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion).Persona.Apellido).Equals(valor.Nombre)))
                        {
                            Entidad resultado = DominioSKD.Fabrica.FabricaEntidades.ObtenerResultadoKata();
                            ((DominioSKD.Entidades.Modulo11.ResultadoKata)resultado).Inscripcion = inscripcion as DominioSKD.Entidades.Modulo10.Inscripcion;
                            ((DominioSKD.Entidades.Modulo11.ResultadoKata)resultado).Inscripcion.Competencia.Id = Convert.ToInt32(idEvento);
                            ((DominioSKD.Entidades.Modulo11.ResultadoKata)resultado).Jurado1 = Convert.ToInt32(valor.Resultado1);
                            ((DominioSKD.Entidades.Modulo11.ResultadoKata)resultado).Jurado2 = Convert.ToInt32(valor.Resultado2);
                            ((DominioSKD.Entidades.Modulo11.ResultadoKata)resultado).Jurado3 = Convert.ToInt32(valor.Resultado3);
                            listaResultado.Add(resultado);
                        }
                    }
                }

                Comando<bool> comandoAgregar = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoAgregarResultadoKata(listaResultado);
                if (comandoAgregar.Ejecutar())
                {
                    respuesta = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return respuesta;
            #endregion
        }

        public bool BAgregarKumite_Click(string idEvento, string especialidad, string idCategoria, List<ValorKataKumite> valores)
        {
            #region Agregar Competencia tipo kumite
            bool respuesta = false;
            Entidad competencia = DominioSKD.Fabrica.FabricaEntidades.ObtenerCompetencia();
            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Id = Convert.ToInt32(idEvento);
            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).TipoCompetencia = especialidad;
            Entidad categoria = DominioSKD.Fabrica.FabricaEntidades.ObtenerCategoria();
            ((DominioSKD.Entidades.Modulo12.Categoria)categoria).Id = Convert.ToInt32(idCategoria);
            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Categoria = categoria as DominioSKD.Entidades.Modulo12.Categoria;
            try
            {
                Comando<List<Entidad>> comandoIns = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoListaInscritosCompetencia(competencia);
                List<Entidad> inscripciones = comandoIns.Ejecutar();
                List<Entidad> listaKumite = new List<Entidad>();

                foreach (ValorKataKumite valor in valores)
                {
                    Entidad resultadok = DominioSKD.Fabrica.FabricaEntidades.ObtenerResultadoKumite();
                    foreach (Entidad inscripcion in inscripciones)
                    {
                        if ((valor.Nombre.Equals(((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion).Persona.Nombre + " " + ((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion).Persona.Apellido)))
                        {
                            ((DominioSKD.Entidades.Modulo11.ResultadoKumite)resultadok).Puntaje1 = Convert.ToInt32(valor.Resultado1);
                            ((DominioSKD.Entidades.Modulo11.ResultadoKumite)resultadok).Inscripcion1 = inscripcion as DominioSKD.Entidades.Modulo10.Inscripcion;
                        }
                        if ((valor.Resultado2.Equals(((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion).Persona.Nombre + " " + ((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion).Persona.Apellido)))
                        {
                            ((DominioSKD.Entidades.Modulo11.ResultadoKumite)resultadok).Puntaje2 = Convert.ToInt32(valor.Resultado3);
                            ((DominioSKD.Entidades.Modulo11.ResultadoKumite)resultadok).Inscripcion2 = inscripcion as DominioSKD.Entidades.Modulo10.Inscripcion;
                        }
                    }
                    listaKumite.Add(resultadok);
                }
                Comando<bool> comando = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoAgregarResultadoKumite(listaKumite);
                if (comando.Ejecutar())
                {
                    respuesta = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return respuesta;
            #endregion
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

        private bool CargarTablas_Kata_Kumite_Ambos(Entidad competencia, string especialidad, Entidad numero)
        {
            bool rango = false;
            if (especialidad.ToString().Equals(M11_RecursosPresentador.especialidadKata))
            {
                vista.Boton.Visible = false;
                vista.BotonKata.Visible = true;
                #region Carga de tabla de Atletas que compiten en una competencia de tipo kata
                Comando<List<Entidad>> comando = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoListaInscritosCompetencia(competencia);
                List<Entidad> inscripciones = comando.Ejecutar();
                CargarKata(inscripciones);
                #endregion
            }
            else if (especialidad.ToString().Equals(M11_RecursosPresentador.especialidadKumite))
            {
                vista.Boton.Visible = false;
                vista.BotonKumite.Visible = true;
                vista.BotonKumite.Enabled = false;
                vista.BotonSiguiente.Visible = true;
                #region Carga de tabla de Atletas que compiten en una competencia de tipo kumite
                Comando<List<Entidad>> comando = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoListaInscritosCompetencia(competencia);
                List<Entidad> inscripciones = comando.Ejecutar();
                if ((inscripciones.Count != 1) && (inscripciones.Count != 0))
                {
                    rango = true;
                    int rango2 = buscarNumeroPermitido(inscripciones) / 2;
                    ((DominioSKD.Entidades.Modulo10.Valores)numero).Nombre = rango2.ToString();
                    List<Entidad> listaKumite = crearRandomPeleas(inscripciones, rango2);
                    CargarKumite(listaKumite);
                }
                #endregion
            }
            else if (especialidad.ToString().Equals(M11_RecursosPresentador.especialidadAmbos))
            {
                vista.Boton.Visible = false;
                vista.BotonAmbos.Visible = true;
                vista.BotonAmbos.Enabled = false;
                vista.BotonSiguienteAmbos.Visible = true;
                #region Carga de tabla de Atletas que compiten en una competencia de tipo kata Ambos
                Comando<List<Entidad>> comando = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoListaInscritosCompetencia(competencia);
                List<Entidad> inscripciones = comando.Ejecutar();
                CargarKata(inscripciones);
                #endregion
                #region Carga de tabla de Atletas que compiten en una competencia de tipo kumite Ambos
                Comando<List<Entidad>> comando2 = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoListaInscritosCompetencia(competencia);
                List<Entidad> inscripciones2 = comando2.Ejecutar();
                if ((inscripciones2.Count != 1) && (inscripciones2.Count != 0))
                {
                    rango = true;
                    int rango2 = buscarNumeroPermitido(inscripciones2) / 2;
                    ((DominioSKD.Entidades.Modulo10.Valores)numero).Nombre = rango2.ToString();
                    List<Entidad> listaKumite = crearRandomPeleas(inscripciones2, rango2);
                    CargarKumite(listaKumite);
                }
                #endregion

            }
            return rango;
        }

        private void CargarKata(List<Entidad> inscripciones)
        {
            try
            {
                foreach (Entidad inscripcion in inscripciones)
                {
                    vista.TablaKata.Text += M11_RecursosPresentador.AbrirTR;
                    vista.TablaKata.Text += M11_RecursosPresentador.AbrirTD + ((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion).Persona.Nombre + " " + ((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion).Persona.Apellido + M11_RecursosPresentador.CerrarTD;
                    vista.TablaKata.Text += M11_RecursosPresentador.AbrirTD;
                    vista.TablaKata.Text += M11_RecursosPresentador.SeleccionarCombo1;
                    vista.TablaKata.Text += M11_RecursosPresentador.CerrarTD;
                    vista.TablaKata.Text += M11_RecursosPresentador.AbrirTD;
                    vista.TablaKata.Text += M11_RecursosPresentador.SeleccionarCombo2;
                    vista.TablaKata.Text += M11_RecursosPresentador.CerrarTD;
                    vista.TablaKata.Text += M11_RecursosPresentador.AbrirTD;
                    vista.TablaKata.Text += M11_RecursosPresentador.SeleccionarCombo3;
                    vista.TablaKata.Text += M11_RecursosPresentador.CerrarTD;
                    vista.TablaKata.Text += M11_RecursosPresentador.CerrarTR;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarKumite(List<Entidad> listaKumite)
        {
            try
            {
                foreach (Entidad resultado in listaKumite)
                {
                    vista.TablaKumite.Text += M11_RecursosPresentador.AbrirTR;
                    vista.TablaKumite.Text += M11_RecursosPresentador.AbrirTDNombre1 + ((DominioSKD.Entidades.Modulo11.ResultadoKumite)resultado).Inscripcion1.Persona.Nombre + " " + ((DominioSKD.Entidades.Modulo11.ResultadoKumite)resultado).Inscripcion1.Persona.Apellido + M11_RecursosPresentador.CerrarTD;
                    vista.TablaKumite.Text += M11_RecursosPresentador.AbrirTD;
                    vista.TablaKumite.Text += M11_RecursosPresentador.SeleccionarCombo1;
                    vista.TablaKumite.Text += M11_RecursosPresentador.CerrarTD;
                    vista.TablaKumite.Text += M11_RecursosPresentador.AbrirTDNombre2 + ((DominioSKD.Entidades.Modulo11.ResultadoKumite)resultado).Inscripcion2.Persona.Nombre + " " + ((DominioSKD.Entidades.Modulo11.ResultadoKumite)resultado).Inscripcion2.Persona.Apellido + M11_RecursosPresentador.CerrarTD;
                    vista.TablaKumite.Text += M11_RecursosPresentador.AbrirTD;
                    vista.TablaKumite.Text += M11_RecursosPresentador.SeleccionarCombo2;
                    vista.TablaKumite.Text += M11_RecursosPresentador.CerrarTD;
                    vista.TablaKumite.Text += M11_RecursosPresentador.CerrarTR;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private int buscarNumeroPermitido(List<Entidad> lista)
        {
            int n = lista.Count();
            if (n >= 16)
            {
                n = 16;
            }
            else if ((n >= 8) && (n <= 16))
            {
                n = 8;
            }
            else if ((n >= 4) && (n <= 8))
            {
                n = 4;
            }
            else if ((n >= 2) && (n <= 4))
            {
                n = 2;
            }
            return n;
        }

        private List<Entidad> crearRandomPeleas(List<Entidad> inscripciones, int rango)
        {
            List<Entidad> listaKumite = new List<Entidad>();
            while (rango != 0)
            {
                Entidad resultado = DominioSKD.Fabrica.FabricaEntidades.ObtenerResultadoKumite();
                Random rnd = new Random();
                int r = rnd.Next(inscripciones.Count);
                Entidad inscripcion = DominioSKD.Fabrica.FabricaEntidades.ObtenerInscripcion();
                inscripcion = inscripciones.ElementAt(r);
                ((DominioSKD.Entidades.Modulo11.ResultadoKumite)resultado).Inscripcion1 = inscripcion as DominioSKD.Entidades.Modulo10.Inscripcion;
                inscripciones.RemoveAt(r);
                r = rnd.Next(inscripciones.Count);
                Entidad inscripcion2 = DominioSKD.Fabrica.FabricaEntidades.ObtenerInscripcion();
                inscripcion2 = inscripciones.ElementAt(r);
                ((DominioSKD.Entidades.Modulo11.ResultadoKumite)resultado).Inscripcion2 = inscripcion2 as DominioSKD.Entidades.Modulo10.Inscripcion;
                inscripciones.RemoveAt(r);
                listaKumite.Add(resultado);
                rango--;
            }
            return listaKumite;
        }

        private bool listaAtletasCompitiendo_AgregandoAnteriores(List<Entidad> inscripciones, List<ValorKataKumite> valores, List<Entidad> lista, List<Entidad> listaKumite)
        {
            bool empate = false;
            try
            {
                foreach (ValorKataKumite valor in valores)
                {
                    Entidad resultadok = DominioSKD.Fabrica.FabricaEntidades.ObtenerResultadoKumite();
                    foreach (Entidad inscripcion in inscripciones)
                    {
                        if ((valor.Nombre.Equals(((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion).Persona.Nombre + " " + ((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion).Persona.Apellido)))
                        {
                            ((DominioSKD.Entidades.Modulo11.ResultadoKumite)resultadok).Puntaje1 = Convert.ToInt32(valor.Resultado1);
                            ((DominioSKD.Entidades.Modulo11.ResultadoKumite)resultadok).Inscripcion1 = inscripcion as DominioSKD.Entidades.Modulo10.Inscripcion;
                        }
                        if ((valor.Resultado2.Equals(((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion).Persona.Nombre + " " + ((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion).Persona.Apellido)))
                        {
                            ((DominioSKD.Entidades.Modulo11.ResultadoKumite)resultadok).Puntaje2 = Convert.ToInt32(valor.Resultado3);
                            ((DominioSKD.Entidades.Modulo11.ResultadoKumite)resultadok).Inscripcion2 = inscripcion as DominioSKD.Entidades.Modulo10.Inscripcion;
                        }
                    }
                    listaKumite.Add(resultadok);
                }
                empate = inscripcionesEnCurso(listaKumite, lista);
                if (empate.Equals(false))
                {
                    Comando<bool> comandoAgregar = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoAgregarResultadoKumite(listaKumite);
                    comandoAgregar.Ejecutar();
                }
                vista.TablaKumite.Text = "";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return empate;
        }

        private bool inscripcionesEnCurso(List<Entidad> listaKumite, List<Entidad> lista)
        {
            bool aprobado = false;
            foreach (Entidad resultado in listaKumite)
            {
                Entidad enCurso = DominioSKD.Fabrica.FabricaEntidades.ObtenerInscripcion();
                if (((DominioSKD.Entidades.Modulo11.ResultadoKumite)resultado).Puntaje1 > ((DominioSKD.Entidades.Modulo11.ResultadoKumite)resultado).Puntaje2)
                {
                    enCurso = ((DominioSKD.Entidades.Modulo11.ResultadoKumite)resultado).Inscripcion1;
                }
                else if (((DominioSKD.Entidades.Modulo11.ResultadoKumite)resultado).Puntaje2 > ((DominioSKD.Entidades.Modulo11.ResultadoKumite)resultado).Puntaje1)
                {
                    enCurso = ((DominioSKD.Entidades.Modulo11.ResultadoKumite)resultado).Inscripcion2;
                }
                if (((DominioSKD.Entidades.Modulo11.ResultadoKumite)resultado).Puntaje1 == ((DominioSKD.Entidades.Modulo11.ResultadoKumite)resultado).Puntaje2)
                {
                    aprobado = true;
                    break;
                }
                else if (((DominioSKD.Entidades.Modulo11.ResultadoKumite)resultado).Puntaje2 == ((DominioSKD.Entidades.Modulo11.ResultadoKumite)resultado).Puntaje1)
                {
                    aprobado = true;
                    break;
                }
                lista.Add(enCurso);
            }
            return aprobado;
        }

        private void ListaEmpate(List<Entidad> valores)
        {
            vista.TablaKumite.Text = " ";
            foreach (Entidad resultado in valores)
            {
                vista.TablaKumite.Text += M11_RecursosPresentador.AbrirTR;
                vista.TablaKumite.Text += M11_RecursosPresentador.AbrirTDNombre1 + ((DominioSKD.Entidades.Modulo11.ResultadoKumite)resultado).Inscripcion1.Persona.Nombre + " " + ((DominioSKD.Entidades.Modulo11.ResultadoKumite)resultado).Inscripcion1.Persona.Apellido + M11_RecursosPresentador.CerrarTD;
                vista.TablaKumite.Text += M11_RecursosPresentador.AbrirTD;
                vista.TablaKumite.Text += resultadosComboTablas(((DominioSKD.Entidades.Modulo11.ResultadoKumite)resultado).Puntaje1, 1);
                vista.TablaKumite.Text += M11_RecursosPresentador.CerrarTD;
                vista.TablaKumite.Text += M11_RecursosPresentador.AbrirTDNombre2 + ((DominioSKD.Entidades.Modulo11.ResultadoKumite)resultado).Inscripcion2.Persona.Nombre + " " + ((DominioSKD.Entidades.Modulo11.ResultadoKumite)resultado).Inscripcion2.Persona.Apellido + M11_RecursosPresentador.CerrarTD;
                vista.TablaKumite.Text += M11_RecursosPresentador.AbrirTD;
                vista.TablaKumite.Text += resultadosComboTablas(((DominioSKD.Entidades.Modulo11.ResultadoKumite)resultado).Puntaje2, 2);
                vista.TablaKumite.Text += M11_RecursosPresentador.CerrarTD;
                vista.TablaKumite.Text += M11_RecursosPresentador.CerrarTR;
            }
        }

        private string resultadosComboTablas(int valor, int combo)
        {
            string resultado = "";
            switch (valor)
            {
                case 1:
                    if (combo.Equals(1))
                        resultado = M11_RecursosPresentador.r1Combo1;
                    else if (combo.Equals(2))
                        resultado = M11_RecursosPresentador.r2Combo1;
                    else if (combo.Equals(3))
                        resultado = M11_RecursosPresentador.r3Combo1;
                    break;
                case 2:
                    if (combo.Equals(1))
                        resultado = M11_RecursosPresentador.r1Combo2;
                    else if (combo.Equals(2))
                        resultado = M11_RecursosPresentador.r2Combo2;
                    else if (combo.Equals(3))
                        resultado = M11_RecursosPresentador.r3Combo2;
                    break;
                case 3:
                    if (combo.Equals(1))
                        resultado = M11_RecursosPresentador.r1Combo3;
                    else if (combo.Equals(2))
                        resultado = M11_RecursosPresentador.r2Combo3;
                    else if (combo.Equals(3))
                        resultado = M11_RecursosPresentador.r3Combo3;
                    break;
                case 4:
                    if (combo.Equals(1))
                        resultado = M11_RecursosPresentador.r1Combo4;
                    else if (combo.Equals(2))
                        resultado = M11_RecursosPresentador.r2Combo4;
                    else if (combo.Equals(3))
                        resultado = M11_RecursosPresentador.r3Combo4;
                    break;
                case 5:
                    if (combo.Equals(1))
                        resultado = M11_RecursosPresentador.r1Combo5;
                    else if (combo.Equals(2))
                        resultado = M11_RecursosPresentador.r2Combo5;
                    else if (combo.Equals(3))
                        resultado = M11_RecursosPresentador.r3Combo5;
                    break;
                case 6:
                    if (combo.Equals(1))
                        resultado = M11_RecursosPresentador.r1Combo6;
                    else if (combo.Equals(2))
                        resultado = M11_RecursosPresentador.r2Combo6;
                    else if (combo.Equals(3))
                        resultado = M11_RecursosPresentador.r3Combo6;
                    break;
                case 7:
                    if (combo.Equals(1))
                        resultado = M11_RecursosPresentador.r1Combo7;
                    else if (combo.Equals(2))
                        resultado = M11_RecursosPresentador.r2Combo7;
                    else if (combo.Equals(3))
                        resultado = M11_RecursosPresentador.r3Combo7;
                    break;
                case 8:
                    if (combo.Equals(1))
                        resultado = M11_RecursosPresentador.r1Combo8;
                    else if (combo.Equals(2))
                        resultado = M11_RecursosPresentador.r2Combo8;
                    else if (combo.Equals(3))
                        resultado = M11_RecursosPresentador.r3Combo8;
                    break;
                case 9:
                    if (combo.Equals(1))
                        resultado = M11_RecursosPresentador.r1Combo9;
                    else if (combo.Equals(2))
                        resultado = M11_RecursosPresentador.r2Combo9;
                    else if (combo.Equals(3))
                        resultado = M11_RecursosPresentador.r3Combo9;
                    break;
                case 10:
                    if (combo.Equals(1))
                        resultado = M11_RecursosPresentador.r1Combo10;
                    else if (combo.Equals(2))
                        resultado = M11_RecursosPresentador.r2Combo10;
                    else if (combo.Equals(3))
                        resultado = M11_RecursosPresentador.r3Combo10;
                    break;
            }
            return resultado;
        }

        private bool verificandoEmpate(List<ValorKataKumite> lista)
        {
            bool aprobado = false;
            foreach (ValorKataKumite resultado in lista)
            {
                if ((Convert.ToInt32(resultado.Resultado1) > Convert.ToInt32(resultado.Resultado3)) || (Convert.ToInt32(resultado.Resultado3) > Convert.ToInt32(resultado.Resultado1)))
                {
                    aprobado = false;
                }
                else if ((Convert.ToInt32(resultado.Resultado1) == Convert.ToInt32(resultado.Resultado3)) || (Convert.ToInt32(resultado.Resultado3) == Convert.ToInt32(resultado.Resultado1)))
                {
                    aprobado = true;
                }
            }
            return aprobado;
        }

        private void ListaFinal(List<ValorKataKumite> valores)
        {
            vista.TablaKumite.Text = " ";
            foreach (ValorKataKumite resultado in valores)
            {
                vista.TablaKumite.Text += M11_RecursosPresentador.AbrirTR;
                vista.TablaKumite.Text += M11_RecursosPresentador.AbrirTDNombre1 + resultado.Nombre + M11_RecursosPresentador.CerrarTD;
                vista.TablaKumite.Text += M11_RecursosPresentador.AbrirTD;
                vista.TablaKumite.Text += resultadosComboTablas(Convert.ToInt32(resultado.Resultado1), 1);
                vista.TablaKumite.Text += M11_RecursosPresentador.CerrarTD;
                vista.TablaKumite.Text += M11_RecursosPresentador.AbrirTDNombre2 + resultado.Resultado2 + M11_RecursosPresentador.CerrarTD;
                vista.TablaKumite.Text += M11_RecursosPresentador.AbrirTD;
                vista.TablaKumite.Text += resultadosComboTablas(Convert.ToInt32(resultado.Resultado3), 2);
                vista.TablaKumite.Text += M11_RecursosPresentador.CerrarTD;
                vista.TablaKumite.Text += M11_RecursosPresentador.CerrarTR;
            }
        }

        private void primeroSegundo(List<ValorKataKumite> valores)
        {
            if (Convert.ToInt32(valores.ElementAt(0).Resultado1) > Convert.ToInt32(valores.ElementAt(0).Resultado3))
            {
                vista.Posiciones.Items.Add("1er Lugar -----------" + valores.ElementAt(0).Nombre);
                vista.Posiciones.Items.Add("2do Lugar -----------" + valores.ElementAt(0).Resultado2);
            }
            else if (Convert.ToInt32(valores.ElementAt(0).Resultado3) > Convert.ToInt32(valores.ElementAt(0).Resultado1))
            {
                vista.Posiciones.Items.Add("1er Lugar -----------" + valores.ElementAt(0).Resultado2);
                vista.Posiciones.Items.Add("2do Lugar -----------" + valores.ElementAt(0).Nombre);
            }
        }

        private string buscarAprobado(ValorEvento valor)
        {
            string aprobado = "";
            if (valor.Resultado.Equals(M11_RecursosPresentador.Aprobado))
            {
                aprobado = M11_RecursosPresentador.valorSi;
            }
            else if (valor.Resultado.Equals(M11_RecursosPresentador.NoAprobado))
            {
                aprobado = M11_RecursosPresentador.valorNo;
            }
            return aprobado;
        }
    }
}
