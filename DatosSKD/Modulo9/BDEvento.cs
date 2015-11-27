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
        /// <param name="evento"></param>
        /// <returns></returns>
        public bool CrearEvento(Evento evento)
        {
            /*try
                {
                    //parametros para insertar un evento
                    List<Parametro> parametros = new List<Parametro>();
                    Parametro parametro = new Parametro(RecursosBDModulo9.ParametroNombreEvento, SqlDbType.VarChar, evento.Nombre, false);
                    parametros.Add(parametro);        
                    parametro = new Parametro(RecursosBDModulo9.ParametroDescripcionEvento, SqlDbType.VarChar, evento.Descripcion, false);
                    parametros.Add(parametro);
                    parametro = new Parametro(RecursosBDModulo9.ParametroCostoEvento, SqlDbType.Float, evento.Costo.ToString(), false);
                    parametros.Add(parametro);
                    parametro = new Parametro(RecursosBDModulo9.ParametroEstadoEvento, SqlDbType.VarChar, proyecto.Moneda, false);
                    parametros.Add(parametro);

                    BDConexion con = new BDConexion();
                    List<Resultado> resultados = con.EjecutarStoredProcedure(RecursosBDModulo4.ProcedimientoAgregarProyecto, parametros);

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
            else
                //el codigo existe por lo tanto no se crea el proyecto
                throw new ExcepcionesTotem.Modulo4.CodigoRepetidoException(RecursosBDModulo4.CodigoProyectoExiste,
                           RecursosBDModulo4.MensajeCodigoProyectoExiste, new Exception());*/
                           throw new NotImplementedException();
        }


        }
    }
