using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DominioSKD;

namespace DatosSKD.Modulo9
{
    public class BDEvento
    {
        /// <summary>
        /// Metodo que permite agregar un Evento a la BD
        /// </summary>
        /// <param name="evento">El Evento a Agregar</param>
        /// <returns>Retorna true o false</returns>
        public bool CrearEvento(Evento evento)
        {
            try
                {
                    //parametros para insertar un evento
                    List<Parametro> parametros = new List<Parametro>();
                    Parametro parametro = new Parametro(RecursosBDModulo9.ParametroNombreEvento, SqlDbType.VarChar, evento.Nombre, false);
                    parametros.Add(parametro);        
                    parametro = new Parametro(RecursosBDModulo9.ParametroDescripcionEvento, SqlDbType.VarChar, evento.Descripcion, false);
                    parametros.Add(parametro);
                    parametro = new Parametro(RecursosBDModulo9.ParametroCostoEvento, SqlDbType.Float, evento.Costo.ToString(), false);
                    parametros.Add(parametro);
                    parametro = new Parametro(RecursosBDModulo9.ParametroEstadoEvento, SqlDbType.VarChar, evento.Estado.ToString(), false);
                    parametros.Add(parametro);
                    parametro = new Parametro(RecursosBDModulo9.ParametroIdPersona, SqlDbType.Int,"1", false);
                    parametros.Add(parametro);
                    parametro = new Parametro(RecursosBDModulo9.ParametroIdUbicacion, SqlDbType.Int, evento.Ubicacion.Id_ubicacion.ToString(), false);
                    parametros.Add(parametro);
                    parametro = new Parametro(RecursosBDModulo9.ParametroIdTipoEvento, SqlDbType.Int, evento.TipoEvento.Id.ToString(), false);
                    parametros.Add(parametro);
                    parametro = new Parametro(RecursosBDModulo9.ParametroIdCategoria, SqlDbType.Int,evento.Categoria.Id_categoria.ToString(), false);
                    parametros.Add(parametro);
                    parametro = new Parametro(RecursosBDModulo9.ParametroFechaInicio, SqlDbType.Date, evento.Horario.FechaInicio.ToString(), false);
                    parametros.Add(parametro);
                    parametro = new Parametro(RecursosBDModulo9.ParametroFechaFin, SqlDbType.Date, evento.Horario.FechaFin.ToString(), false);
                    parametros.Add(parametro);
                    parametro = new Parametro(RecursosBDModulo9.ParametroHoraInicio, SqlDbType.Int, evento.Horario.HoraInicio.ToString(), false);
                    parametros.Add(parametro);
                    parametro = new Parametro(RecursosBDModulo9.ParametroHoraFin, SqlDbType.Int, evento.Horario.HoraFin.ToString(), false);
                    parametros.Add(parametro);





                    BDConexion con = new BDConexion();
                    List<Resultado> resultados = con.EjecutarStoredProcedure(RecursosBDModulo9.ProcedimientoAgregarEvento, parametros);

                    //si la creacion es correcta retorna true

                    if (resultados != null)
                    {
                        return true;
                    }
                    else
                    {
                        throw new NotImplementedException();

                    }

                }
                catch (NotImplementedException e)
                {
                    throw e;
                }
            }

        }


}

