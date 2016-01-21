using DatosSKD.DAO.Modulo14;
using DatosSKD.Fabrica;
using DominioSKD;
using ExcepcionesSKD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegociosSKD.Comandos.Modulo14
{
    public class ComandoReemplazarElementos : Comando<string>
    {
        private string info;
        private Entidad laPersona;
        private Entidad elDojo;
        private Entidad elEvento;
        private Entidad laCompetencia;
        private List<string> matricula;
        private Entidad laOrganizacion;
        private Entidad laSolicitud;

        public string Info
        {
            get { return info; }
            set { info = value; }
        }
        public Entidad Persona
        {
            get { return laPersona; }
            set { laPersona = value; }
        }
        public Entidad Dojo
        {
            get { return elDojo; }
            set { elDojo = value; }
        }
        public Entidad Evento
        {
            get { return elEvento; }
            set { elEvento = value; }
        }
        public Entidad Competencia
        {
            get { return laCompetencia; }
            set { laCompetencia = value; }
        }
        public List<string> Matricula
        {
            get { return matricula; }
            set { matricula = value; }
        }
        public Entidad Organizacion
        {
            get { return laOrganizacion; }
            set { laOrganizacion = value; }
        }
        public Entidad Solicitud
        {
            get { return laSolicitud; }
            set { laSolicitud = value; }
        }

        public override string Ejecutar()
        {
            
            try
            {
                Persona persona = (Persona)Persona;
                if (persona != null)
                {
                    info = info.Replace(RecursosComandoModulo14.PerImagen, 
                        RecursosComandoModulo14.ImageSRC +
                        persona.Alergias + RecursosComandoModulo14.MedidasImagen);
                    info = info.Replace(RecursosComandoModulo14.PerNombre, persona.Nombre);
                    info = info.Replace(RecursosComandoModulo14.PerApellido, persona.Apellido);
                    info = info.Replace(RecursosComandoModulo14.PerNumDocId, 
                        persona.DocumentoID.Numero.ToString());
                    info = info.Replace(RecursosComandoModulo14.PerDireccion, persona.Direccion);
                    info = info.Replace(RecursosComandoModulo14.PerFechaNac, 
                        persona.FechaNacimiento.ToShortDateString());
                    info = info.Replace(RecursosComandoModulo14.PerPeso, 
                        persona.Peso.ToString());
                    info = info.Replace(RecursosComandoModulo14.PerEstatura, 
                        persona.Estatura.ToString());
                    info = info.Replace(RecursosComandoModulo14.PerNacionalidad, 
                        persona.Nacionalidad.ToString());
                }
                else
                {
                    info = info.Replace(RecursosComandoModulo14.PerImagen, "");
                    info = info.Replace(RecursosComandoModulo14.PerNombre, "");
                    info = info.Replace(RecursosComandoModulo14.PerApellido, "");
                    info = info.Replace(RecursosComandoModulo14.PerNumDocId, "");
                    info = info.Replace(RecursosComandoModulo14.PerDireccion, "");
                    info = info.Replace(RecursosComandoModulo14.PerFechaNac, "");
                    info = info.Replace(RecursosComandoModulo14.PerPeso, "");
                    info = info.Replace(RecursosComandoModulo14.PerEstatura, "");
                    info = info.Replace(RecursosComandoModulo14.PerNacionalidad, "");
                }

                DominioSKD.Entidades.Modulo14.SolicitudPlanilla solicitud =
                    (DominioSKD.Entidades.Modulo14.SolicitudPlanilla)laSolicitud;
                if (solicitud != null)
                {
                    info = info.Replace(RecursosComandoModulo14.FechaCreacionPlanilla, 
                        solicitud.FechaCreacion.ToShortDateString());
                    info = info.Replace(RecursosComandoModulo14.FechaRetiro,
                        solicitud.FechaRetiro.ToShortTimeString());
                    info = info.Replace(RecursosComandoModulo14.FechaReincor, 
                        solicitud.FechaReincorporacion.ToShortDateString());
                    info = info.Replace(RecursosComandoModulo14.Motivo, solicitud.Motivo);
                }
                else
                {
                    info = info.Replace(RecursosComandoModulo14.FechaCreacionPlanilla, "");
                    info = info.Replace(RecursosComandoModulo14.FechaRetiro, "");
                    info = info.Replace(RecursosComandoModulo14.FechaReincor, "");
                    info = info.Replace(RecursosComandoModulo14.Motivo, "");
                }

                Dojo dojo= (Dojo)elDojo;
                if (dojo != null)
                {
                    info = info.Replace(RecursosComandoModulo14.DojNombre, dojo.Nombre_dojo);
                    info = info.Replace(RecursosComandoModulo14.DojTelefono, 
                        dojo.Telefono_dojo.ToString());
                    info = info.Replace(RecursosComandoModulo14.DojRif, dojo.Rif_dojo);
                    info = info.Replace(RecursosComandoModulo14.DojEmail, dojo.Email_dojo);
                }
                else
                {
                    info = info.Replace(RecursosComandoModulo14.DojNombre, "");
                    info = info.Replace(RecursosComandoModulo14.DojTelefono, "");
                    info = info.Replace(RecursosComandoModulo14.DojRif, "");
                    info = info.Replace(RecursosComandoModulo14.DojEmail, "");
                }
                if (matricula != null)
                {
                    info = info.Replace(RecursosComandoModulo14.MatIdenti, matricula[0]);
                    info = info.Replace(RecursosComandoModulo14.MatFechaCreacion, matricula[1]);
                    info = info.Replace(RecursosComandoModulo14.MatFechaPago, matricula[2]);
                    info = info.Replace(RecursosComandoModulo14.MatActiva, matricula[3]);
                    info = info.Replace(RecursosComandoModulo14.MatPrecio, matricula[4]);
                }
                else
                {
                    info = info.Replace(RecursosComandoModulo14.MatIdenti, "");
                    info = info.Replace(RecursosComandoModulo14.MatFechaCreacion, "");
                    info = info.Replace(RecursosComandoModulo14.MatFechaPago, "");
                    info = info.Replace(RecursosComandoModulo14.MatActiva, "");
                    info = info.Replace(RecursosComandoModulo14.MatPrecio, "");
                }

                Organizacion organizacion = (Organizacion)laOrganizacion;
                if (organizacion != null)
                {
                    info = info.Replace(RecursosComandoModulo14.OrgNombre, organizacion.Nombre);
                    info = info.Replace(RecursosComandoModulo14.OrgDireccion, 
                        organizacion.Direccion);
                    info = info.Replace(RecursosComandoModulo14.OrgTelefono, 
                        organizacion.Telefono.ToString());
                    info = info.Replace(RecursosComandoModulo14.OrgEmail, 
                        organizacion.Email.ToString());
                }
                else
                {
                    info = info.Replace(RecursosComandoModulo14.OrgNombre, "");
                    info = info.Replace(RecursosComandoModulo14.OrgDireccion, "");
                    info = info.Replace(RecursosComandoModulo14.OrgTelefono, "");
                    info = info.Replace(RecursosComandoModulo14.OrgEmail, "");
                }
                DominioSKD.Entidades.Modulo9.Evento evento =
                    (DominioSKD.Entidades.Modulo9.Evento)elEvento;
                if (evento != null)
                {
                    info = info.Replace(RecursosComandoModulo14.EveNombre, evento.Nombre);
                    info = info.Replace(RecursosComandoModulo14.EveDescripcion, 
                        evento.Descripcion);
                    info = info.Replace(RecursosComandoModulo14.EveCosto, 
                        evento.Costo.ToString());
                    string categoria = RecursosComandoModulo14.CategoriaSexo + 
                        evento.Categoria.Sexo + RecursosComandoModulo14.Linea;
                    categoria += RecursosComandoModulo14.CintaInicial +
                        evento.Categoria.Cinta_inicial + RecursosComandoModulo14.Linea;
                    categoria += RecursosComandoModulo14.CintaFinal + 
                        evento.Categoria.Cinta_final + RecursosComandoModulo14.Linea;
                    categoria += RecursosComandoModulo14.EdadInicial + 
                        evento.Categoria.Edad_inicial + RecursosComandoModulo14.Linea;
                    categoria += RecursosComandoModulo14.EdadFinal + 
                        evento.Categoria.Edad_final + RecursosComandoModulo14.Linea;
                    info = info.Replace(RecursosComandoModulo14.CategoriaCat, categoria);
                    info = info.Replace(RecursosComandoModulo14.TipoEvento, 
                        evento.TipoEvento.Nombre);
                    string horario = RecursosComandoModulo14.HorarioDeEventoFI + 
                        evento.Horario.FechaInicio.ToShortDateString() + 
                        RecursosComandoModulo14.Linea;
                    horario += RecursosComandoModulo14.FechaFin + 
                        evento.Horario.FechaFin.ToShortDateString() + 
                        RecursosComandoModulo14.Linea;
                    horario += RecursosComandoModulo14.HoraInicio + 
                        evento.Horario.HoraInicio.ToString() + RecursosComandoModulo14.Linea;
                    horario += RecursosComandoModulo14.HoraFinal + 
                        evento.Horario.HoraFin.ToString() + RecursosComandoModulo14.Linea;
                    info = info.Replace(RecursosComandoModulo14.HorarioHor, horario) + 
                        RecursosComandoModulo14.Linea;

                }
                else
                {
                    info = info.Replace(RecursosComandoModulo14.EveNombre, "");
                    info = info.Replace(RecursosComandoModulo14.EveDescripcion, "");
                    info = info.Replace(RecursosComandoModulo14.EveCosto, "");
                    info = info.Replace(RecursosComandoModulo14.CategoriaCat, "");
                    info = info.Replace(RecursosComandoModulo14.TipoEvento, "");
                    info = info.Replace(RecursosComandoModulo14.HorarioHor, "") + 
                        RecursosComandoModulo14.Linea;
                }

                DominioSKD.Entidades.Modulo12.Competencia competencia =
                    (DominioSKD.Entidades.Modulo12.Competencia)laCompetencia;
                if (competencia != null)
                {
                    info = info.Replace(RecursosComandoModulo14.CompNombre, competencia.Nombre);
                    info = info.Replace(RecursosComandoModulo14.CompTipo, 
                        competencia.TipoCompetencia);
                    info = info.Replace(RecursosComandoModulo14.CompFechaIni,
                        competencia.FechaInicio.ToShortDateString());
                    info = info.Replace(RecursosComandoModulo14.CompFechaFin, 
                        competencia.FechaFin.ToShortDateString());
                    info = info.Replace(RecursosComandoModulo14.CompCosto, 
                        competencia.Costo.ToString());
                    string categoria = RecursosComandoModulo14.CategoriaSexo + 
                        competencia.Categoria.Sexo + RecursosComandoModulo14.Linea;
                    categoria += RecursosComandoModulo14.CintaInicial + 
                        competencia.Categoria.Cinta_inicial + RecursosComandoModulo14.Linea;
                    categoria += RecursosComandoModulo14.CintaFinal + 
                        competencia.Categoria.Cinta_final + RecursosComandoModulo14.Linea;
                    categoria += RecursosComandoModulo14.EdadInicial + 
                        competencia.Categoria.Edad_inicial + RecursosComandoModulo14.Linea;
                    categoria += RecursosComandoModulo14.EdadFinal + 
                        competencia.Categoria.Edad_final + RecursosComandoModulo14.Linea;
                    info = info.Replace(RecursosComandoModulo14.CategoriaComp, categoria);
                }
                else
                {
                    info = info.Replace(RecursosComandoModulo14.CompNombre, "");
                    info = info.Replace(RecursosComandoModulo14.CompTipo, "");
                    info = info.Replace(RecursosComandoModulo14.CompFechaIni, "");
                    info = info.Replace(RecursosComandoModulo14.CompFechaFin, "");
                    info = info.Replace(RecursosComandoModulo14.CompCosto, "");
                    info = info.Replace(RecursosComandoModulo14.CategoriaComp, "");
                }

                return info;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (ExcepcionesSKD.Modulo14.BDDiseñoException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (ExcepcionesSKD.Modulo14.BDDatosException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }

        }
    }
}
