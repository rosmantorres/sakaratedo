using DominioSKD;
using Interfaz_Contratos.Modulo11;
using LogicaNegociosSKD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaz_Presentadores.Modulo11
{
    public class PresentadorDetalleResultado
    {
        IContratoDetalleResultadoCompetencia vista;

        public PresentadorDetalleResultado(IContratoDetalleResultadoCompetencia vista)
        {
            this.vista = vista;
        }

        public void CargarVentana(string idEvento, string tipoEvento)
        {
            if (tipoEvento.Equals(M11_RecursosPresentador.Evento))
            {
                #region Detalle de Eventos Examen de Ascenso
                Entidad evento = DominioSKD.Fabrica.FabricaEntidades.ObtenerEventoM10();
                Comando<Entidad> comandoEvento = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoConsultarEventoDetalle(idEvento);
                evento = comandoEvento.Ejecutar();
                vista.FechaEvento.Text = ((DominioSKD.Entidades.Modulo10.Evento)evento).Horario.FechaInicio.ToShortDateString();
                vista.NombreEvento.Text = ((DominioSKD.Entidades.Modulo10.Evento)evento).Nombre;
                ((DominioSKD.Entidades.Modulo10.Evento)evento).Id = Convert.ToInt32(idEvento);
                vista.CategoriaEvento.Text = ((DominioSKD.Entidades.Modulo10.Evento)evento).Categoria.Edad_inicial.ToString() + " a " + ((DominioSKD.Entidades.Modulo10.Evento)evento).Categoria.Edad_final.ToString() + " años " + ((DominioSKD.Entidades.Modulo10.Evento)evento).Categoria.Cinta_inicial + " - " + ((DominioSKD.Entidades.Modulo10.Evento)evento).Categoria.Cinta_final + " " + ((DominioSKD.Entidades.Modulo10.Evento)evento).Categoria.Sexo;
                try
                {
                    Comando<List<Entidad>> comandoInscripcion = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoListaAtletasEnCategoriaYAscenso(evento);
                    List<Entidad> inscripciones = comandoInscripcion.Ejecutar();
                    foreach (Entidad inscripcion in inscripciones)
                    {
                        Entidad resultadoAs = DominioSKD.Fabrica.FabricaEntidades.ObtenerResultadoAscenso();
                        resultadoAs = ((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion).ResAscenso.ElementAt(0);
                        vista.TablaAscenso.Text += M11_RecursosPresentador.AbrirTR;
                        vista.TablaAscenso.Text += M11_RecursosPresentador.AbrirTD + ((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion).Persona.Nombre + " " + ((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion).Persona.Apellido + M11_RecursosPresentador.CerrarTD;
                        vista.TablaAscenso.Text += M11_RecursosPresentador.AbrirTD;
                        if (((DominioSKD.Entidades.Modulo11.ResultadoAscenso)resultadoAs).Aprobado.Equals(M11_RecursosPresentador.valorSi))
                        {
                            vista.TablaAscenso.Text += M11_RecursosPresentador.Aprobado;
                        }
                        else if (((DominioSKD.Entidades.Modulo11.ResultadoAscenso)resultadoAs).Aprobado.Equals(M11_RecursosPresentador.valorNo))
                        {
                            vista.TablaAscenso.Text += M11_RecursosPresentador.NoAprobado;
                        }
                        vista.TablaAscenso.Text += M11_RecursosPresentador.CerrarTD;
                        vista.TablaAscenso.Text += M11_RecursosPresentador.CerrarTR;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                #endregion
            }
            else if (tipoEvento.Equals(M11_RecursosPresentador.Competencia))
            {
                vista.LEspecialidad = true;
                vista.EspecialidadEvento.Visible = true;
                Entidad competencia = DominioSKD.Fabrica.FabricaEntidades.ObtenerCompetencia();
                Comando<Entidad> comandoCompetencia = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoConsultarCompetenciaXIdDetalle(idEvento);
                competencia = comandoCompetencia.Ejecutar();

                vista.FechaEvento.Text = ((DominioSKD.Entidades.Modulo12.Competencia)competencia).FechaInicio.ToShortDateString();
                vista.NombreEvento.Text = ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Nombre;
                vista.EspecialidadEvento.Text = calcularEspecialidad(competencia);
                ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Id = Convert.ToInt32(idEvento);
                vista.CategoriaEvento.Text = ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Categoria.Edad_inicial.ToString() + " a " + ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Categoria.Edad_final.ToString() + " años " + ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Categoria.Cinta_inicial + " - " + ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Categoria.Cinta_final + " " + ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Categoria.Sexo;

                if (vista.EspecialidadEvento.Text.Equals(M11_RecursosPresentador.Kata))
                {
                    #region Detalle de Competencia tipo Kata
                    try
                    {
                        Comando<List<Entidad>> comandoKata = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoListaAtletasParticipanCompetenciaKata(competencia);
                        List<Entidad> inscripciones = comandoKata.Ejecutar();
                        foreach (Entidad inscripcion in inscripciones)
                        {
                            Entidad resultadoKata = DominioSKD.Fabrica.FabricaEntidades.ObtenerResultadoKata();
                            resultadoKata = ((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion).ResKata.ElementAt(0);
                            vista.TablaKata.Text += M11_RecursosPresentador.AbrirTR;
                            vista.TablaKata.Text += M11_RecursosPresentador.AbrirTD + ((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion).Persona.Nombre + " " + ((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion).Persona.Apellido + M11_RecursosPresentador.CerrarTD;
                            vista.TablaKata.Text += M11_RecursosPresentador.AbrirTD + ((DominioSKD.Entidades.Modulo11.ResultadoKata)resultadoKata).Jurado1 + M11_RecursosPresentador.CerrarTD;
                            vista.TablaKata.Text += M11_RecursosPresentador.AbrirTD + ((DominioSKD.Entidades.Modulo11.ResultadoKata)resultadoKata).Jurado2 + M11_RecursosPresentador.CerrarTD;
                            vista.TablaKata.Text += M11_RecursosPresentador.AbrirTD + ((DominioSKD.Entidades.Modulo11.ResultadoKata)resultadoKata).Jurado3 + M11_RecursosPresentador.CerrarTD;
                            vista.TablaKata.Text += M11_RecursosPresentador.CerrarTR;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    #endregion
                }
                else if (vista.EspecialidadEvento.Text.Equals(M11_RecursosPresentador.Kumite))
                {
                    #region Detalle de Competencia tipo Kumite
                    try
                    {
                        Comando<List<Entidad>> comandoKumite = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoListaAtletasParticipanCompetenciaKumite(competencia);
                        List<Entidad> listaKumite = comandoKumite.Ejecutar();
                        foreach (Entidad resultado in listaKumite)
                        {
                            vista.TablaKumite.Text += M11_RecursosPresentador.AbrirTR;
                            vista.TablaKumite.Text += M11_RecursosPresentador.AbrirTD + ((DominioSKD.Entidades.Modulo11.ResultadoKumite)resultado).Id + M11_RecursosPresentador.CerrarTD;
                            vista.TablaKumite.Text += M11_RecursosPresentador.AbrirTDNombre1 + ((DominioSKD.Entidades.Modulo11.ResultadoKumite)resultado).Inscripcion1.Persona.Nombre + " " + ((DominioSKD.Entidades.Modulo11.ResultadoKumite)resultado).Inscripcion1.Persona.Apellido + M11_RecursosPresentador.CerrarTD;
                            vista.TablaKumite.Text += M11_RecursosPresentador.AbrirTD;
                            vista.TablaKumite.Text += ((DominioSKD.Entidades.Modulo11.ResultadoKumite)resultado).Puntaje1;
                            vista.TablaKumite.Text += M11_RecursosPresentador.CerrarTD;
                            vista.TablaKumite.Text += M11_RecursosPresentador.AbrirTDNombre2 + ((DominioSKD.Entidades.Modulo11.ResultadoKumite)resultado).Inscripcion2.Persona.Nombre + " " + ((DominioSKD.Entidades.Modulo11.ResultadoKumite)resultado).Inscripcion2.Persona.Apellido + M11_RecursosPresentador.CerrarTD;
                            vista.TablaKumite.Text += M11_RecursosPresentador.AbrirTD;
                            vista.TablaKumite.Text += ((DominioSKD.Entidades.Modulo11.ResultadoKumite)resultado).Puntaje2;
                            vista.TablaKumite.Text += M11_RecursosPresentador.CerrarTD;
                            vista.TablaKumite.Text += M11_RecursosPresentador.CerrarTR;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    #endregion
                }
                else if (vista.EspecialidadEvento.Text.Equals(M11_RecursosPresentador.Kata_Kumite))
                {
                    #region Detalle de Competencia tipo Kata Ambos
                    try
                    {
                        Comando<List<Entidad>> comandoKataAmbos = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoListaAtletasParticipanCompetenciaKataAmbos(competencia);
                        List<Entidad> inscripciones = comandoKataAmbos.Ejecutar();
                        foreach (Entidad inscripcion in inscripciones)
                        {
                            Entidad resKata = DominioSKD.Fabrica.FabricaEntidades.ObtenerResultadoKata();
                            resKata = ((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion).ResKata.ElementAt(0);
                            vista.TablaKata.Text += M11_RecursosPresentador.AbrirTR;
                            vista.TablaKata.Text += M11_RecursosPresentador.AbrirTD + ((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion).Persona.Nombre + " " + ((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion).Persona.Apellido + M11_RecursosPresentador.CerrarTD;
                            vista.TablaKata.Text += M11_RecursosPresentador.AbrirTD + ((DominioSKD.Entidades.Modulo11.ResultadoKata)resKata).Jurado1 + M11_RecursosPresentador.CerrarTD;
                            vista.TablaKata.Text += M11_RecursosPresentador.AbrirTD + ((DominioSKD.Entidades.Modulo11.ResultadoKata)resKata).Jurado2 + M11_RecursosPresentador.CerrarTD;
                            vista.TablaKata.Text += M11_RecursosPresentador.AbrirTD + ((DominioSKD.Entidades.Modulo11.ResultadoKata)resKata).Jurado3 + M11_RecursosPresentador.CerrarTD;
                            vista.TablaKata.Text += M11_RecursosPresentador.CerrarTR;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    #endregion
                    #region Detalle de Competencia tipo Kumite Ambos
                    try
                    {
                        ((DominioSKD.Entidades.Modulo12.Competencia)competencia).TipoCompetencia = M11_RecursosPresentador.especialidadKataKumite;
                        Comando<List<Entidad>> comandoAmbos = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoListaAtletasParticipanCompetenciaKumiteAmbos(competencia);
                        List<Entidad> listaKumite = comandoAmbos.Ejecutar();
                        foreach (Entidad resultado in listaKumite)
                        {
                            vista.TablaKumite.Text += M11_RecursosPresentador.AbrirTR;
                            vista.TablaKumite.Text += M11_RecursosPresentador.AbrirTD + ((DominioSKD.Entidades.Modulo11.ResultadoKumite)resultado).Id + M11_RecursosPresentador.CerrarTD;
                            vista.TablaKumite.Text += M11_RecursosPresentador.AbrirTDNombre1 + ((DominioSKD.Entidades.Modulo11.ResultadoKumite)resultado).Inscripcion1.Persona.Nombre + " " + ((DominioSKD.Entidades.Modulo11.ResultadoKumite)resultado).Inscripcion1.Persona.Apellido + M11_RecursosPresentador.CerrarTD;
                            vista.TablaKumite.Text += M11_RecursosPresentador.AbrirTD;
                            vista.TablaKumite.Text += ((DominioSKD.Entidades.Modulo11.ResultadoKumite)resultado).Puntaje1;
                            vista.TablaKumite.Text += M11_RecursosPresentador.CerrarTD;
                            vista.TablaKumite.Text += M11_RecursosPresentador.AbrirTDNombre2 + ((DominioSKD.Entidades.Modulo11.ResultadoKumite)resultado).Inscripcion2.Persona.Nombre + " " + ((DominioSKD.Entidades.Modulo11.ResultadoKumite)resultado).Inscripcion2.Persona.Apellido + M11_RecursosPresentador.CerrarTD;
                            vista.TablaKumite.Text += M11_RecursosPresentador.AbrirTD;
                            vista.TablaKumite.Text += ((DominioSKD.Entidades.Modulo11.ResultadoKumite)resultado).Puntaje2;
                            vista.TablaKumite.Text += M11_RecursosPresentador.CerrarTD;
                            vista.TablaKumite.Text += M11_RecursosPresentador.CerrarTR;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    #endregion
                }
            }
        }

        private string calcularEspecialidad(Entidad competencia)
        {
            string nuevo = "";
            if (((DominioSKD.Entidades.Modulo12.Competencia)competencia).TipoCompetencia.Equals(M11_RecursosPresentador.especialidadKata))
            {
                nuevo = M11_RecursosPresentador.Kata;
            }
            else if (((DominioSKD.Entidades.Modulo12.Competencia)competencia).TipoCompetencia.Equals(M11_RecursosPresentador.especialidadKumite))
            {
                nuevo = M11_RecursosPresentador.Kumite;
            }
            else if (((DominioSKD.Entidades.Modulo12.Competencia)competencia).TipoCompetencia.Equals(M11_RecursosPresentador.especialidadAmbos))
            {
                nuevo = M11_RecursosPresentador.Kata_Kumite;
            }
            return nuevo;
        }
    }
}
