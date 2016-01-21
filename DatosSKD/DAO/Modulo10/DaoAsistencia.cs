using DatosSKD.InterfazDAO.Modulo10;
using DominioSKD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosSKD.DAO.Modulo10
{
    public class DaoAsistencia : DAOGeneral, IDaoAsistencia
    {

        public List<Entidad> ListarEventosAsistidos()
        {
            List<Entidad> listaEventos = new List<Entidad>();
            List<Parametro> parametros;

            try
            {
                Conectar();
                parametros = new List<Parametro>();
                DataTable dt = EjecutarStoredProcedureTuplas(RecursosDAOModulo10.ProcedimentoConsultarEventoAsistido, parametros);
                foreach (DataRow row in dt.Rows)
                {
                    DominioSKD.Fabrica.FabricaEntidades fabrica = new DominioSKD.Fabrica.FabricaEntidades();
                    Entidad evento = fabrica.ObtenerEvento();
                    ((DominioSKD.Entidades.Modulo9.Evento) evento).Id = int.Parse(row[RecursosDAOModulo10.aliasIdEvento].ToString());
                    ((DominioSKD.Entidades.Modulo9.Evento) evento).Nombre = row[RecursosDAOModulo10.aliasNombreEvento].ToString();
                    Entidad horario = fabrica.ObtenerHorario();
                    ((DominioSKD.Entidades.Modulo9.Horario) horario).FechaInicio = DateTime.Parse(row[RecursosDAOModulo10.aliasFechaEvento].ToString());
                    Entidad tipo = fabrica.ObtenerTipoEvento();
                    ((DominioSKD.Entidades.Modulo9.TipoEvento) tipo).Nombre = row[RecursosDAOModulo10.aliasTipoEvento].ToString();
                    ((DominioSKD.Entidades.Modulo9.Evento) evento).Horario  = horario as DominioSKD.Entidades.Modulo9.Horario;
                    ((DominioSKD.Entidades.Modulo9.Evento) evento).TipoEvento = tipo as DominioSKD.Entidades.Modulo9.TipoEvento;
                    listaEventos.Add(evento);
                }

            }
            catch (SqlException ex)
            {
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                /*throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosBDModulo9.CodigoErrorFormato,
                     RecursosBDModulo9.MensajeErrorFormato, ex);*/
                throw ex;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            return listaEventos;
        }

        public List<Entidad> ListarCompetenciasAsistidas()
        {
            throw new NotImplementedException();
        }

        public List<Entidad> ListaAsistentesEvento(string idEvento)
        {
            throw new NotImplementedException();
        }

        public List<Entidad> ListaNoAsistentesEvento(string idEvento)
        {
            throw new NotImplementedException();
        }

        public string ModificarFechas(string fecha)
        {
            throw new NotImplementedException();
        }

        public List<Entidad> ListaAsistentesCompetencia(string idCompetencia)
        {
            throw new NotImplementedException();
        }

        public List<Entidad> ListaNoAsistentesCompetencia(string idCompetencia)
        {
            throw new NotImplementedException();
        }

        public bool ModificarAsistenciaEvento(List<Entidad> listaEntidad)
        {
            throw new NotImplementedException();
        }

        public Entidad ConsultarCompetenciasXId(string idCompetencia)
        {
            throw new NotImplementedException();
        }

        public bool ModificarAsistenciaCompetencia(List<Entidad> listaEntidad)
        {
            throw new NotImplementedException();
        }

        public List<Entidad> ListaAtletasInscritosEvento(string idEvento)
        {
            throw new NotImplementedException();
        }

        public List<Entidad> ListaInasistentesPlanilla(string idEvento)
        {
            throw new NotImplementedException();
        }

        public bool AgregarAsistenciaEvento(List<Entidad> listaEntidad)
        {
            throw new NotImplementedException();
        }

        public bool AgregarAsistenciaCompetencia(List<Entidad> listaEntidad)
        {
            throw new NotImplementedException();
        }

        public List<Entidad> ListarHorariosCompetencia()
        {
            throw new NotImplementedException();
        }

        public List<Entidad> CompetenciasPorFecha(string fechaInicio)
        {
            throw new NotImplementedException();
        }

        public List<Entidad> ListaAtletasInscritosCompetencia(string idCompetencia)
        {
            throw new NotImplementedException();
        }

        public List<Entidad> ListaInasistentesPlanillaCompetencia(string idCompetencia)
        {
            throw new NotImplementedException();
        }

        #region IDAO
        public bool Agregar(List<Entidad> parametro)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(List<Entidad> parametro)
        {
            throw new NotImplementedException();
        }

        public Entidad ConsultarXId(List<Entidad> parametro)
        {
            throw new NotImplementedException();
        }

        public List<Entidad> ConsultarTodos()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
