using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using DominioSKD;

namespace DatosSKD.Modulo7
{
    public class BDCinta
    {
        /// <summary>
        /// Método para listar las cintas obtenidas del atleta
        /// </summary>
        /// <returns>Lista de cintas</returns>
        public static List<Cinta> ListarCintasObtenidas()
        {
            int idPersona = 1;
            BDConexion laConexion;
            List<Parametro> parametros;
            Parametro elParametro = new Parametro();
            List<Cinta> laListaDeCintas = new List<Cinta>();

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();

                elParametro = new Parametro(RecursosBDModulo7.ParamIdPersona, SqlDbType.Int, idPersona.ToString(), false);
                parametros.Add(elParametro);

                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                               RecursosBDModulo7.ConsultarCintas, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    Cinta cinta = new Cinta();
                    cinta.Id_cinta = int.Parse(row[RecursosBDModulo7.AliasIdCinta].ToString());
                    cinta.Color_nombre = row[RecursosBDModulo7.AliasCintaNombre].ToString();
                    cinta.Rango = row[RecursosBDModulo7.AliasCintaRango].ToString();
                    cinta.Clasificacion = row[RecursosBDModulo7.AliasCintaClasificacion].ToString();
                    cinta.Significado = row[RecursosBDModulo7.AliasCintaSignificado].ToString();
                    cinta.Orden = int.Parse(row[RecursosBDModulo7.AliasCintaOrden].ToString());

                    laListaDeCintas.Add(cinta);
                }

                return laListaDeCintas;

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

        /// <summary>
        /// Método para detallar una cinta
        /// </summary>
        /// <param name="idCinta">Número entero que representa el ID de la cinta</param>
        /// <returns>Objeto de tipo Cinta</returns>
        /*public static Cinta DetallarCinta(int idCinta)
        {
            int id = 1;
            String color_nombre = "Blanca";
            String rango = "kyu";
            String clasificacion = "quinto";
            String significado = "nose";
            int orden = 5;
            Cinta cinta = new Cinta(id, color_nombre, rango, clasificacion, significado, orden);

            return cinta;
        }*/
    }
}
