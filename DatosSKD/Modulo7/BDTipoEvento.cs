using DominioSKD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosSKD.Modulo7
{
    class BDTipoEvento
    {
        public static TipoEvento DetallarTipoEvento(int idTipoEvento)
        {
            BDConexion laConexion;
            List<Parametro> parametros;
            Parametro elParametro = new Parametro();

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();
                TipoEvento tipoE = new TipoEvento();

                elParametro = new Parametro(RecursosBDModulo7.ParamIdTipoEvento, SqlDbType.Int, idTipoEvento.ToString(),
                                            false);
                parametros.Add(elParametro);

                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                               RecursosBDModulo7.ConsultarTipoEventoXId, parametros);

                foreach (DataRow row in dt.Rows)
                {

                    tipoE.Id = int.Parse(row[RecursosBDModulo7.AliasIdTipoEvento].ToString());
                    tipoE.Nombre = row[RecursosBDModulo7.AliasNombreEvento].ToString();

                }

                return tipoE;

            }
            catch (SqlException ex)
            {
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }/*
            catch (ExcepcionesSKD.Modulo12.CompetenciaInexistenteException ex)
            {
                throw ex;
            }*/
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ExcepcionesSKD.ExceptionSKD("No se pudo completar la operacion", ex);
            }


        }
    }
}
