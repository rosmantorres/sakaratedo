using DominioSKD;
using DominioSKD.Entidades.Modulo11;
using Interfaz_Contratos.Modulo11;
using LogicaNegociosSKD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaz_Presentadores.Modulo11
{
    public class PresentadorModificarResultado
    {
        IContratoModificarResultadoCompetencia vista;

        public PresentadorModificarResultado(IContratoModificarResultadoCompetencia vista)
        {
            this.vista = vista;
        }

        public void CargarVentana(string idEvento, string tipoEvento)
        {
            if (tipoEvento.Equals(M11_RecursosPresentador.Evento))
            {
                Entidad evento = DominioSKD.Fabrica.FabricaEntidades.ObtenerEventoM10();
                Comando<Entidad> comandoEvento = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoConsultarEventoM10XId(idEvento);
                evento = comandoEvento.Ejecutar();
                vista.Fecha.Text = ((DominioSKD.Entidades.Modulo10.Evento)evento).Horario.FechaInicio.ToShortDateString();
                vista.Nombre.Text = ((DominioSKD.Entidades.Modulo10.Evento)evento).Nombre;
                vista.ComboEspecialidad.Visible = false;
                vista.LEspecialidad = false;
                Comando<List<Entidad>> comandoCategoriaE = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoListaCategoriaEvento(idEvento);
                llenarComboCategoria(comandoCategoriaE.Ejecutar());
            }
            else if (tipoEvento.Equals(M11_RecursosPresentador.Competencia))
            {
                vista.LEspecialidad = true;
                vista.ComboEspecialidad.Visible = true;
                Entidad competencia = DominioSKD.Fabrica.FabricaEntidades.ObtenerCompetencia();
                Comando<Entidad> comandoCompetencia = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoConsultarCompetenciasXId(idEvento);
                competencia = comandoCompetencia.Ejecutar();
                vista.Fecha.Text = ((DominioSKD.Entidades.Modulo12.Competencia)competencia).FechaInicio.ToShortDateString();
                vista.Nombre.Text = ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Nombre;
                Comando<List<string>> comandoEspecialidad = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoListaEspecialidadesCompetencia(idEvento);
                llenarComboEspecialidad(comandoEspecialidad.Ejecutar());
            }
        }

        public void CargarComboCategoria_LuegoDeEspecialidad(string idEvento, string especialidadEvento)
        {
            vista.TablaAscenso.Text = " ";
            vista.TablaKata.Text = " ";
            vista.TablaKumite.Text = " ";
            Entidad competencia = DominioSKD.Fabrica.FabricaEntidades.ObtenerCompetencia();
            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Id = Convert.ToInt32(idEvento);
            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).TipoCompetencia = especialidadEvento;
            Comando<List<Entidad>> comandoCategoria = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoListaCategoriaCompetencia(competencia);
            llenarComboCategoria(comandoCategoria.Ejecutar());
        }    

        public string RedireccionarListarAsistenciaEvento()
        {
            return M11_RecursosPresentador.VentanaListarResultadoCompetencia;
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

        public bool BModificar_Click(string idEvento, string idCategoria, List<ValorEvento> valores)
        {
            bool resultado = false;
            Entidad evento = DominioSKD.Fabrica.FabricaEntidades.ObtenerEventoM10();
            ((DominioSKD.Entidades.Modulo10.Evento)evento).Id = Convert.ToInt32(idEvento);
            Entidad categoria = DominioSKD.Fabrica.FabricaEntidades.ObtenerCategoria();
            ((DominioSKD.Entidades.Modulo12.Categoria)categoria).Id = Convert.ToInt32(idCategoria);
            ((DominioSKD.Entidades.Modulo10.Evento)evento).Categoria = categoria as DominioSKD.Entidades.Modulo12.Categoria;

            try
            {
                Comando<List<Entidad>> comando = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoListaAtletasEnCategoriaYAscenso(evento);
                List<Entidad> inscripciones = comando.Ejecutar();
                List<Entidad> listaResultado = new List<Entidad>();

                foreach (Entidad inscripcion in inscripciones)
                {
                    string aprobar = buscarValorSiNo(inscripcion);
                    foreach (ValorEvento valor in valores)
                    {
                        string aprobado = buscarAprobado(valor);
                        Entidad resAscenso = ((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion).ResAscenso.ElementAt(0);
                        if (((((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion).Persona.Nombre + " " + ((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion).Persona.Apellido).Equals(valor.Nombre)) && (!((DominioSKD.Entidades.Modulo11.ResultadoAscenso)resAscenso).Aprobado.Equals(aprobado)))
                        {
                            Entidad ascenso = DominioSKD.Fabrica.FabricaEntidades.ObtenerResultadoAscenso();
                            ((DominioSKD.Entidades.Modulo11.ResultadoAscenso)ascenso).Inscripcion = inscripcion as DominioSKD.Entidades.Modulo10.Inscripcion;
                            ((DominioSKD.Entidades.Modulo11.ResultadoAscenso)ascenso).Inscripcion.Evento.Id = Convert.ToInt32(idEvento);
                            ((DominioSKD.Entidades.Modulo11.ResultadoAscenso)ascenso).Aprobado = aprobado;
                            listaResultado.Add(ascenso);
                        }
                    }
                }

                Comando<bool> comandoModificar = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoModificarResultadoAscenso(listaResultado);
                if (comandoModificar.Ejecutar())
                {
                    resultado = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return resultado;
        }

        public bool BModificarKata_Click(string idEvento, string idCategoria, string especialidad, List<ValorKataKumite> valores)
        {
            bool respuesta = false;
            Entidad competencia = DominioSKD.Fabrica.FabricaEntidades.ObtenerCompetencia();
            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Id = Convert.ToInt32(idEvento);
            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).TipoCompetencia = especialidad;
            Entidad categoria = DominioSKD.Fabrica.FabricaEntidades.ObtenerCategoria();
            ((DominioSKD.Entidades.Modulo12.Categoria)categoria).Id = Convert.ToInt32(idCategoria);
            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Categoria = categoria as DominioSKD.Entidades.Modulo12.Categoria;
            try
            {
                Comando<List<Entidad>> comandoInscripcion = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoListaAtletasParticipanCompetenciaKata(competencia);
                List<Entidad> inscripciones = comandoInscripcion.Ejecutar();
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
                Comando<bool> comando = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoModificarResultadoKata(listaResultado);
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
        }

        public bool BModificarKumite_Click(string idEvento, string idCategoria, string especialidad, List<ValorKataKumite> valores)
        {
            bool respuesta = false;

            Entidad competencia = DominioSKD.Fabrica.FabricaEntidades.ObtenerCompetencia();
            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Id = Convert.ToInt32(idEvento);
            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).TipoCompetencia = especialidad;
            Entidad categoria = DominioSKD.Fabrica.FabricaEntidades.ObtenerCategoria();
            ((DominioSKD.Entidades.Modulo12.Categoria)categoria).Id = Convert.ToInt32(idCategoria);
            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Categoria = categoria as DominioSKD.Entidades.Modulo12.Categoria;

            try
            {
                Comando<List<Entidad>> comando = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoListaAtletasParticipanCompetenciaKumite(competencia);
                List<Entidad> listaKumite = comando.Ejecutar();
                List<Entidad> listaResultado = new List<Entidad>();

                foreach (Entidad resultado in listaKumite)
                {
                    foreach (ValorKataKumite valor in valores)
                    {
                        if (((((DominioSKD.Entidades.Modulo11.ResultadoKumite)resultado).Inscripcion1.Persona.Nombre + " " + ((DominioSKD.Entidades.Modulo11.ResultadoKumite)resultado).Inscripcion1.Persona.Apellido).Equals(valor.Nombre)) && ((((DominioSKD.Entidades.Modulo11.ResultadoKumite)resultado).Inscripcion2.Persona.Nombre + " " + ((DominioSKD.Entidades.Modulo11.ResultadoKumite)resultado).Inscripcion2.Persona.Apellido).Equals(valor.Resultado2)))
                        {
                            Entidad resultadoK = DominioSKD.Fabrica.FabricaEntidades.ObtenerResultadoKumite();
                            ((DominioSKD.Entidades.Modulo11.ResultadoKumite)resultadoK).Puntaje1 = Convert.ToInt32(valor.Resultado1);
                            ((DominioSKD.Entidades.Modulo11.ResultadoKumite)resultadoK).Puntaje2 = Convert.ToInt32(valor.Resultado3);
                            Entidad inscripcion1 = ((DominioSKD.Entidades.Modulo11.ResultadoKumite)resultado).Inscripcion1;
                            Entidad inscripcion2 = ((DominioSKD.Entidades.Modulo11.ResultadoKumite)resultado).Inscripcion2;
                            ((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion1).Competencia.Id = Convert.ToInt32(idEvento);
                            ((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion1).Competencia.Id = Convert.ToInt32(idEvento);
                            ((DominioSKD.Entidades.Modulo11.ResultadoKumite)resultadoK).Inscripcion1 = inscripcion1 as DominioSKD.Entidades.Modulo10.Inscripcion;
                            ((DominioSKD.Entidades.Modulo11.ResultadoKumite)resultadoK).Inscripcion2 = inscripcion2 as DominioSKD.Entidades.Modulo10.Inscripcion;
                            listaResultado.Add(resultadoK);
                        }
                    }
                }
                Comando<bool> modificar = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoModificarResultadoKumite(listaResultado);
                if (modificar.Ejecutar())
                {
                    respuesta = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return respuesta;
        }

        public bool BModificarAmbos_Click(string idEvento, string idCategoria, string especialidad, List<ValorKataKumite> valores, List<ValorKataKumite> valores2)
        {
            bool resultado = false;
            Entidad competencia = DominioSKD.Fabrica.FabricaEntidades.ObtenerCompetencia();
            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Id = Convert.ToInt32(idEvento);
            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).TipoCompetencia = especialidad;
            Entidad categoria = DominioSKD.Fabrica.FabricaEntidades.ObtenerCategoria();
            ((DominioSKD.Entidades.Modulo12.Categoria)categoria).Id = Convert.ToInt32(idCategoria);
            ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Categoria = categoria as DominioSKD.Entidades.Modulo12.Categoria;

            try
            {
                Comando<List<Entidad>> comando1 = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoListaAtletasParticipanCompetenciaKataAmbos(competencia);
                List<Entidad> inscripciones = comando1.Ejecutar();
                List<Entidad> listaResultado = new List<Entidad>();

                foreach (Entidad inscripcion in inscripciones)
                {
                    foreach (ValorKataKumite valor in valores)
                    {
                        if (((((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion).Persona.Nombre + " " + ((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion).Persona.Apellido).Equals(valor.Nombre)))
                        {
                            Entidad resultadoka = DominioSKD.Fabrica.FabricaEntidades.ObtenerResultadoKata();
                            ((DominioSKD.Entidades.Modulo11.ResultadoKata)resultadoka).Inscripcion = inscripcion as DominioSKD.Entidades.Modulo10.Inscripcion;
                            ((DominioSKD.Entidades.Modulo11.ResultadoKata)resultadoka).Inscripcion.Competencia.Id = Convert.ToInt32(idEvento);
                            ((DominioSKD.Entidades.Modulo11.ResultadoKata)resultadoka).Jurado1 = Convert.ToInt32(valor.Resultado1);
                            ((DominioSKD.Entidades.Modulo11.ResultadoKata)resultadoka).Jurado2 = Convert.ToInt32(valor.Resultado2);
                            ((DominioSKD.Entidades.Modulo11.ResultadoKata)resultadoka).Jurado3 = Convert.ToInt32(valor.Resultado3);
                            listaResultado.Add(resultadoka);
                        }
                    }
                }

                ((DominioSKD.Entidades.Modulo12.Competencia)competencia).TipoCompetencia = M11_RecursosPresentador.especialidadKataKumite;
                Comando<List<Entidad>> comando2 = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoListaAtletasParticipanCompetenciaKumiteAmbos(competencia);
                List<Entidad> listaKumite = comando2.Ejecutar();
                List<Entidad> listaResultado2 = new List<Entidad>();

                foreach (Entidad resultadok in listaKumite)
                {
                    foreach (ValorKataKumite valor in valores2)
                    {
                        if (((((DominioSKD.Entidades.Modulo11.ResultadoKumite)resultadok).Inscripcion1.Persona.Nombre + " " + ((DominioSKD.Entidades.Modulo11.ResultadoKumite)resultadok).Inscripcion1.Persona.Apellido).Equals(valor.Nombre)) && ((((DominioSKD.Entidades.Modulo11.ResultadoKumite)resultadok).Inscripcion2.Persona.Nombre + " " + ((DominioSKD.Entidades.Modulo11.ResultadoKumite)resultadok).Inscripcion2.Persona.Apellido).Equals(valor.Resultado2)))
                        {
                            Entidad resultadoku = DominioSKD.Fabrica.FabricaEntidades.ObtenerResultadoKumite();
                            ((DominioSKD.Entidades.Modulo11.ResultadoKumite)resultadoku).Puntaje1 = Convert.ToInt32(valor.Resultado1);
                            ((DominioSKD.Entidades.Modulo11.ResultadoKumite)resultadoku).Puntaje2 = Convert.ToInt32(valor.Resultado3);
                            Entidad inscripcion1 = ((DominioSKD.Entidades.Modulo11.ResultadoKumite)resultadok).Inscripcion1;
                            Entidad inscripcion2 = ((DominioSKD.Entidades.Modulo11.ResultadoKumite)resultadok).Inscripcion2;
                            ((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion1).Competencia.Id = Convert.ToInt32(idEvento);
                            ((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion2).Competencia.Id = Convert.ToInt32(idEvento);
                            ((DominioSKD.Entidades.Modulo11.ResultadoKumite)resultadoku).Inscripcion1 = inscripcion1 as DominioSKD.Entidades.Modulo10.Inscripcion;
                            ((DominioSKD.Entidades.Modulo11.ResultadoKumite)resultadoku).Inscripcion2 = inscripcion2 as DominioSKD.Entidades.Modulo10.Inscripcion;
                            listaResultado2.Add(resultadoku);
                        }
                    }
                }

                Comando<bool> modificarKata = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoModificarResultadoKata(listaResultado);
                Comando<bool> modificarKumite = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoModificarResultadoKumite(listaResultado2);
                if ((modificarKata.Ejecutar()) && (modificarKumite.Ejecutar()))
                {
                    resultado = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return resultado;
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
                Comando<List<Entidad>> comando = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoListaAtletasEnCategoriaYAscenso(evento);
                List<Entidad> inscripciones = comando.Ejecutar();

                foreach (Entidad inscripcion in inscripciones)
                {
                    vista.TablaAscenso.Text += M11_RecursosPresentador.AbrirTR;
                    vista.TablaAscenso.Text += M11_RecursosPresentador.AbrirTD + ((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion).Persona.Nombre + " " + ((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion).Persona.Apellido + M11_RecursosPresentador.CerrarTD;
                    vista.TablaAscenso.Text += M11_RecursosPresentador.AbrirTD;
                    Entidad resAscenso = ((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion).ResAscenso.ElementAt(0);
                    if (((DominioSKD.Entidades.Modulo11.ResultadoAscenso)resAscenso).Aprobado.Equals(M11_RecursosPresentador.valorSi))
                    {
                        vista.TablaAscenso.Text += M11_RecursosPresentador.selectAprobado;
                    }
                    else if (((DominioSKD.Entidades.Modulo11.ResultadoAscenso)resAscenso).Aprobado.Equals(M11_RecursosPresentador.valorNo))
                    {
                        vista.TablaAscenso.Text += M11_RecursosPresentador.selectNoAprobado;
                    }
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
                Comando<List<Entidad>> comando = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoListaAtletasParticipanCompetenciaKata(competencia);
                List<Entidad> inscripciones = comando.Ejecutar();
                CargarKata(inscripciones);
                #endregion
            }
            else if (especialidad.ToString().Equals(M11_RecursosPresentador.especialidadKumite))
            {
                vista.Boton.Visible = false;
                vista.BotonKumite.Visible = true;
                #region Carga de tabla de Atletas que compiten en una competencia de tipo kumite
                Comando<List<Entidad>> comando = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoListaAtletasParticipanCompetenciaKumite(competencia);
                List<Entidad> listaKumite = comando.Ejecutar();
                CargarKumite(listaKumite);
                #endregion
            }
            else if (especialidad.ToString().Equals(M11_RecursosPresentador.especialidadAmbos))
            {
                vista.Boton.Visible = false;
                vista.BotonAmbos.Visible = true;
                #region Carga de tabla de Atletas que compiten en una competencia de tipo kata Ambos
                Comando<List<Entidad>> comando = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoListaAtletasParticipanCompetenciaKataAmbos(competencia);
                List<Entidad> inscripciones = comando.Ejecutar();
                CargarKata(inscripciones);
                #endregion
                #region Carga de tabla de Atletas que compiten en una competencia de tipo kumite Ambos
                ((DominioSKD.Entidades.Modulo12.Competencia)competencia).TipoCompetencia = M11_RecursosPresentador.especialidadKataKumite;
                Comando<List<Entidad>> comandoKumite = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoListaAtletasParticipanCompetenciaKumiteAmbos(competencia);
                List<Entidad> listaKumite = comandoKumite.Ejecutar();
                CargarKumite(listaKumite);
                #endregion

            }
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

        private void CargarKata(List<Entidad> inscripciones)
        {
            try
            {
                foreach (Entidad inscripcion in inscripciones)
                {
                    Entidad resKata = ((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion).ResKata.ElementAt(0);
                    vista.TablaKata.Text += M11_RecursosPresentador.AbrirTR;
                    vista.TablaKata.Text += M11_RecursosPresentador.AbrirTD + ((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion).Persona.Nombre + " " + ((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion).Persona.Apellido + M11_RecursosPresentador.CerrarTD;
                    vista.TablaKata.Text += M11_RecursosPresentador.AbrirTD;
                    vista.TablaKata.Text += resultadosComboTablas(((DominioSKD.Entidades.Modulo11.ResultadoKata)resKata).Jurado1, 1);
                    vista.TablaKata.Text += M11_RecursosPresentador.CerrarTD;
                    vista.TablaKata.Text += M11_RecursosPresentador.AbrirTD;
                    vista.TablaKata.Text += resultadosComboTablas(((DominioSKD.Entidades.Modulo11.ResultadoKata)resKata).Jurado2, 2);
                    vista.TablaKata.Text += M11_RecursosPresentador.CerrarTD;
                    vista.TablaKata.Text += M11_RecursosPresentador.AbrirTD;
                    vista.TablaKata.Text += resultadosComboTablas(((DominioSKD.Entidades.Modulo11.ResultadoKata)resKata).Jurado3, 3);
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
                    vista.TablaKumite.Text += M11_RecursosPresentador.AbrirTD + ((DominioSKD.Entidades.Modulo11.ResultadoKumite)resultado).Id + M11_RecursosPresentador.CerrarTD;
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string buscarValorSiNo(Entidad inscripcion)
        {
            string aprobado = "";
            Entidad resAscenso = ((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion).ResAscenso.ElementAt(0);
            if (((DominioSKD.Entidades.Modulo11.ResultadoAscenso)resAscenso).Aprobado.Equals(M11_RecursosPresentador.valorSi))
            {
                aprobado = M11_RecursosPresentador.Aprobado;
            }
            else if (((DominioSKD.Entidades.Modulo11.ResultadoAscenso)resAscenso).Aprobado.Equals(M11_RecursosPresentador.valorNo))
            {
                aprobado = M11_RecursosPresentador.NoAprobado;
            }
            return aprobado;
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
