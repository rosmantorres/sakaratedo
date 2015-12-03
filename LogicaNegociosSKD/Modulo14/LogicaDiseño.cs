using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSKD.Modulo14;
using ExcepcionesSKD;


namespace LogicaNegociosSKD.Modulo14
{
    public class LogicaDiseño
    {
        #region atributos

        private DatosSKD.Modulo14.BDDiseño datos = new DatosSKD.Modulo14.BDDiseño();
        private DatosSKD.Modulo14.BDDatos datos1 = new DatosSKD.Modulo14.BDDatos();
        private DominioSKD.Diseño diseñoPlanilla;

        #endregion

        #region Metodos
        /// <summary>
        /// Metodo que comunica con la Bd para agregar un diseño nuevo
        /// </summary>
        /// <param name="diseño">Clase diseño</param>
        /// <param name="planilla">Clase Planilla para unir con el diseño en la BD</param>
        /// <returns>Retorna True, si se realizo la operación satisfactoriamente.
        /// De lo contrario devuelve false</returns>
        public Boolean AgregarDiseño(DominioSKD.Diseño diseño, DominioSKD.Planilla planilla)
        {
            try
            {
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosLogicaModulo14.MsjLoggerInfo, System.Reflection.MethodBase.GetCurrentMethod().Name);
                diseño.Base64Encode();
                return datos.GuardarDiseñoBD(diseño, planilla);
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

        /// <summary>
        /// Método que se comunica con la BD para consultar el diseño de un 
        /// planilla y reemplaza los valores con los datos necesarios del Atleta
        /// </summary>
        /// <param name="planilla">Id de la Planilla que contiene el diseño</param>
        /// <param name="idPersona">Id de la persona de los datos</param>
        /// <param name="idSolicitud">Id de la solicitud de la planilla que 
        /// contiene el diseño a consultar</param>
        /// <returns>Retorna la clase diseño, con los datos reemplazados</returns>
        public DominioSKD.Diseño ConsultarDiseño(int planilla, int idPersona, int idIns, int idSolici)
        {
            try
            {
                DominioSKD.Persona persona = new DominioSKD.Persona();
                DominioSKD.Dojo dojo = new DominioSKD.Dojo();
                DominioSKD.Evento evento = new DominioSKD.Evento();
                DominioSKD.Competencia competencia = new DominioSKD.Competencia();
                DominioSKD.Organizacion organizacion = new DominioSKD.Organizacion();
                DominioSKD.SolicitudPlanilla solicitud = new DominioSKD.SolicitudPlanilla();
                List<string> matricula = new List<string>();
                diseñoPlanilla = datos.ConsultarDiseño(planilla);
                persona = datos1.ConsultarPersona(idPersona);
                dojo = datos1.ConsultarDojo(persona.ID);
                matricula = datos1.ConsultarMatricula(dojo.Id_dojo, idPersona);
                evento = datos1.ConsultarEvento(idIns);
                competencia = datos1.ConsultarCompetencia(idIns);
                organizacion = datos1.ConsultarOrganizacion(dojo.Organizacion_dojo);
                solicitud = datos1.ConsultarSolicitud(idSolici);
                diseñoPlanilla.Contenido = ReemplazarElementos(diseñoPlanilla.Contenido, persona, dojo,
                    evento, competencia, matricula, organizacion, solicitud);
                return diseñoPlanilla;
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

        /// <summary>
        /// Método que devuelve el diseño, tal cual se creo
        /// </summary>
        /// <param name="planilla">Id de la planilla que contiene el diseño a consultar</param>
        /// <returns>Retorna la clase diseño a consultar</returns>
        public DominioSKD.Diseño ConsultarDiseñoPuro(int planilla)
        {
            try
            {
                return diseñoPlanilla = datos.ConsultarDiseño(planilla);
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

        /// <summary>
        /// Método que reemplaza cada uno de los elementos del diseño de la panilla
        /// con datos reales del atleta
        /// </summary>
        /// <param name="info">Contenido del diseño</param>
        /// <param name="persona">Clase persona</param>
        /// <param name="dojo">Clase Dojo</param>
        /// <param name="evento">Clase Evento</param>
        /// <param name="competencia">Clase Competencia</param>
        /// <param name="matricula">Clase Matricula</param>
        /// <param name="organizacion">Clase Organizacion</param>
        /// Todas estas clases, son datos que se reemplazan en el diseño original
        /// <returns>Retorna el contenido del diseño, modificado por los datos</returns>
        public string ReemplazarElementos(string info, DominioSKD.Persona persona, DominioSKD.Dojo dojo,
            DominioSKD.Evento evento, DominioSKD.Competencia competencia, List<string> matricula,
            DominioSKD.Organizacion organizacion, DominioSKD.SolicitudPlanilla solicitud)
        {
            try
            {
                if (persona != null)
                {
                    info = info.Replace(RecursosLogicaModulo14.PerImagen, "<img src='" +
                        persona.Alergias + "'Height='80' Width='90'/>");
                    info = info.Replace(RecursosLogicaModulo14.PerNombre, persona.Nombre);
                    info = info.Replace(RecursosLogicaModulo14.PerApellido, persona.Apellido);
                    info = info.Replace(RecursosLogicaModulo14.PerNumDocId, persona.DocumentoID.Numero.ToString());
                    info = info.Replace(RecursosLogicaModulo14.PerDireccion, persona.Direccion);
                    info = info.Replace(RecursosLogicaModulo14.PerFechaNac, persona.FechaNacimiento.ToShortDateString());
                    info = info.Replace(RecursosLogicaModulo14.PerPeso, persona.Peso.ToString());
                    info = info.Replace(RecursosLogicaModulo14.PerEstatura, persona.Estatura.ToString());
                    info = info.Replace(RecursosLogicaModulo14.PerNacionalidad, persona.Nacionalidad.ToString());
                }
                else
                {
                    info = info.Replace(RecursosLogicaModulo14.PerImagen, "");
                    info = info.Replace(RecursosLogicaModulo14.PerNombre, "");
                    info = info.Replace(RecursosLogicaModulo14.PerApellido, "");
                    info = info.Replace(RecursosLogicaModulo14.PerNumDocId, "");
                    info = info.Replace(RecursosLogicaModulo14.PerDireccion, "");
                    info = info.Replace(RecursosLogicaModulo14.PerFechaNac, "");
                    info = info.Replace(RecursosLogicaModulo14.PerPeso, "");
                    info = info.Replace(RecursosLogicaModulo14.PerEstatura, "");
                    info = info.Replace(RecursosLogicaModulo14.PerNacionalidad, "");
                }

                if (solicitud != null)
                {
                    info = info.Replace(RecursosLogicaModulo14.FechaCreacionPlanilla, solicitud.FechaCreacion.ToShortDateString());
                    info = info.Replace(RecursosLogicaModulo14.FechaRetiro, solicitud.FechaRetiro.ToShortTimeString());
                    info = info.Replace(RecursosLogicaModulo14.FechaReincor, solicitud.FechaReincorporacion.ToShortDateString());
                    info = info.Replace(RecursosLogicaModulo14.Motivo, solicitud.Motivo);
                }
                else
                {
                    info = info.Replace(RecursosLogicaModulo14.FechaCreacionPlanilla, "");
                    info = info.Replace(RecursosLogicaModulo14.FechaRetiro, "");
                    info = info.Replace(RecursosLogicaModulo14.FechaReincor, "");
                    info = info.Replace(RecursosLogicaModulo14.Motivo, "");
                }

                if (dojo != null)
                {
                    info = info.Replace(RecursosLogicaModulo14.DojNombre, dojo.Nombre_dojo);
                    info = info.Replace(RecursosLogicaModulo14.DojTelefono, dojo.Telefono_dojo.ToString());
                    info = info.Replace(RecursosLogicaModulo14.DojRif, dojo.Rif_dojo);
                    info = info.Replace(RecursosLogicaModulo14.DojEmail, dojo.Email_dojo);
                }
                else
                {
                    info = info.Replace(RecursosLogicaModulo14.DojNombre, "");
                    info = info.Replace(RecursosLogicaModulo14.DojTelefono, "");
                    info = info.Replace(RecursosLogicaModulo14.DojRif, "");
                    info = info.Replace(RecursosLogicaModulo14.DojEmail, "");
                }
                if (matricula != null)
                {
                    info = info.Replace(RecursosLogicaModulo14.MatIdenti, matricula[0]);
                    info = info.Replace(RecursosLogicaModulo14.MatFechaCreacion, matricula[1]);
                    info = info.Replace(RecursosLogicaModulo14.MatFechaPago, matricula[2]);
                    info = info.Replace(RecursosLogicaModulo14.MatActiva, matricula[3]);
                    info = info.Replace(RecursosLogicaModulo14.MatPrecio, matricula[4]);
                }
                else
                {
                    info = info.Replace(RecursosLogicaModulo14.MatIdenti, "");
                    info = info.Replace(RecursosLogicaModulo14.MatFechaCreacion, "");
                    info = info.Replace(RecursosLogicaModulo14.MatFechaPago, "");
                    info = info.Replace(RecursosLogicaModulo14.MatActiva, "");
                    info = info.Replace(RecursosLogicaModulo14.MatPrecio, "");
                }
                if (organizacion != null)
                {
                    info = info.Replace(RecursosLogicaModulo14.OrgNombre, organizacion.Nombre);
                    info = info.Replace(RecursosLogicaModulo14.OrgDireccion, organizacion.Direccion);
                    info = info.Replace(RecursosLogicaModulo14.OrgTelefono, organizacion.Telefono.ToString());
                    info = info.Replace(RecursosLogicaModulo14.OrgEmail, organizacion.Email.ToString());
                }
                else
                {
                    info = info.Replace(RecursosLogicaModulo14.OrgNombre, "");
                    info = info.Replace(RecursosLogicaModulo14.OrgDireccion, "");
                    info = info.Replace(RecursosLogicaModulo14.OrgTelefono, "");
                    info = info.Replace(RecursosLogicaModulo14.OrgEmail, "");
                }
                if (evento != null)
                {
                    info = info.Replace(RecursosLogicaModulo14.EveNombre, evento.Nombre);
                    info = info.Replace(RecursosLogicaModulo14.EveDescripcion, evento.Descripcion);
                    info = info.Replace(RecursosLogicaModulo14.EveCosto, evento.Costo.ToString());
                    string categoria = "Categoria: Sexo: "+ evento.Categoria.Sexo + RecursosLogicaModulo14.Linea;
                    categoria += "Cinta Inicial: "+ evento.Categoria.Cinta_inicial + RecursosLogicaModulo14.Linea;
                    categoria += "Cinta Final: "+evento.Categoria.Cinta_final + RecursosLogicaModulo14.Linea;
                    categoria += "Edad Inicial: "+evento.Categoria.Edad_inicial + RecursosLogicaModulo14.Linea;
                    categoria += "Edad Final: "+evento.Categoria.Edad_final + RecursosLogicaModulo14.Linea;
                    info = info.Replace(RecursosLogicaModulo14.CategoriaCat, categoria);
                    info = info.Replace(RecursosLogicaModulo14.TipoEvento, evento.TipoEvento.Nombre);
                    string horario = "Horario de Evento: Fecha Inicio:"+evento.Horario.FechaInicio.ToShortDateString() + RecursosLogicaModulo14.Linea;
                    horario += "Fecha Fin:"+evento.Horario.FechaFin.ToShortDateString() + RecursosLogicaModulo14.Linea;
                    horario += "Hora Inicio: "+evento.Horario.HoraInicio.ToString() + RecursosLogicaModulo14.Linea;
                    horario += "Hora Final: "+evento.Horario.HoraFin.ToString() + RecursosLogicaModulo14.Linea;
                    info = info.Replace(RecursosLogicaModulo14.HorarioHor, horario) + RecursosLogicaModulo14.Linea;

                }
                else
                {
                    info = info.Replace(RecursosLogicaModulo14.EveNombre, "");
                    info = info.Replace(RecursosLogicaModulo14.EveDescripcion, "");
                    info = info.Replace(RecursosLogicaModulo14.EveCosto, "");
                    info = info.Replace(RecursosLogicaModulo14.CategoriaCat, "");
                    info = info.Replace(RecursosLogicaModulo14.TipoEvento, "");
                    info = info.Replace(RecursosLogicaModulo14.HorarioHor, "") + RecursosLogicaModulo14.Linea;
                }
                if (competencia != null)
                {
                    info = info.Replace(RecursosLogicaModulo14.CompNombre, competencia.Nombre);
                    info = info.Replace(RecursosLogicaModulo14.CompTipo, competencia.TipoCompetencia);
                    info = info.Replace(RecursosLogicaModulo14.CompFechaIni, competencia.FechaInicio.ToShortDateString());
                    info = info.Replace(RecursosLogicaModulo14.CompFechaFin, competencia.FechaFin.ToShortDateString());
                    info = info.Replace(RecursosLogicaModulo14.CompCosto, competencia.Costo.ToString());
                    string categoria ="Categoria: Sexo: "+ competencia.Categoria.Sexo + RecursosLogicaModulo14.Linea;
                    categoria += "Cinta Inicial: " + competencia.Categoria.Cinta_inicial + RecursosLogicaModulo14.Linea;
                    categoria += "Cinta Final: " + competencia.Categoria.Cinta_final + RecursosLogicaModulo14.Linea;
                    categoria += "Edad Inicial: " + competencia.Categoria.Edad_inicial + RecursosLogicaModulo14.Linea;
                    categoria += "Edad Final: "+competencia.Categoria.Edad_final + RecursosLogicaModulo14.Linea;
                    info = info.Replace(RecursosLogicaModulo14.CategoriaComp, categoria);
                }
                else
                {
                    info = info.Replace(RecursosLogicaModulo14.CompNombre, "");
                    info = info.Replace(RecursosLogicaModulo14.CompTipo, "");
                    info = info.Replace(RecursosLogicaModulo14.CompFechaIni, "");
                    info = info.Replace(RecursosLogicaModulo14.CompFechaFin, "");
                    info = info.Replace(RecursosLogicaModulo14.CompCosto, "");
                    info = info.Replace(RecursosLogicaModulo14.CategoriaComp, "");
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

        /// <summary>
        /// Método que modifica un diseño
        /// </summary>
        /// <param name="diseño">La clase diseño que se desea modificar</param>
        /// <returns>Retorna True si se realizo satisfactoriamente la modificación.
        /// De lo contrario devuelve False</returns>
        public Boolean ModificarDiseño(DominioSKD.Diseño diseño)
        {
            try
            {
                diseño.Base64Encode();
                return datos.ModificarDiseño(diseño);
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
        #endregion
    }
}
