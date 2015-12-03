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
using ExcepcionesSKD;
using System.Globalization;

namespace DatosSKD.Modulo8
{
    public class BDRestriccionEvento
    {
        public bool AgregarRestriccionEvento(RestriccionEvento laRestriccion)
        {

            try
            {
                List<Parametro> parametros = new List<Parametro>(); //declaras lista de parametros

                Parametro elParametro = new Parametro(RecursosBDRestriccionEvento.ParamDescripcionRestricionEvento, SqlDbType.VarChar,
                    laRestriccion.Descripcion, false);
                //parametro recibe: el alias de la accion (en este caso es la descripcion de mi restriccion de cinta que apunta a un atributo que se llama @DescripcionRestriccionCinta), SqlDbType es el tipo de dato que tiene ese atributo en la base de datos (en este caso es varchar), el elemento que se desea poner en ese lugar (aqui se usa la clase dominio), el false lo dejas asi
                parametros.Add(elParametro);
                //agregas eso que acabas de hacer a la lista de parametros.
                //repites hasta que tengas todos los parametros de tu stored procedure asociado
                elParametro = new Parametro(RecursosBDRestriccionEvento.ParamEdadMinimaRestricionEvento, SqlDbType.Int,
                        laRestriccion.EdadMinima.ToString(), false);
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosBDRestriccionEvento.ParamEdadMaximaRestricionEvento, SqlDbType.Int,
                        laRestriccion.EdadMaxima.ToString(), false);
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosBDRestriccionEvento.ParamSexoRestricionEvento, SqlDbType.VarChar,
                        laRestriccion.Sexo.ToString(), false);
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosBDRestriccionEvento.ParamIdEvento, SqlDbType.Int,
                        laRestriccion.IdEvento.ToString(), false);
                parametros.Add(elParametro);

                BDConexion laConexion = new BDConexion();// abres la conexion
                laConexion.EjecutarStoredProcedure(RecursosBDRestriccionEvento.AgregarRestriccionEvento
                                             , parametros);//ejecutas el stored procedure que quieres pasandole la lista de parametros
            }

            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }


            return true;
        }

        public bool ModificarRestriccionEvento(RestriccionEvento laRestriccion)
        {
            try
            {
                List<Parametro> parametros = new List<Parametro>(); //declaras lista de parametros

                Parametro elParametro = new Parametro(RecursosBDRestriccionEvento.ParamIdRestriccionEvento, SqlDbType.Int,
                    laRestriccion.IdRestEvento.ToString(), false);
                //parametro recibe: el alias de la accion (en este caso es la descripcion de mi restriccion de cinta que apunta a un atributo que se llama @DescripcionRestriccionCinta), SqlDbType es el tipo de dato que tiene ese atributo en la base de datos (en este caso es varchar), el elemento que se desea poner en ese lugar (aqui se usa la clase dominio), el false lo dejas asi
                parametros.Add(elParametro);
                //agregas eso que acabas de hacer a la lista de parametros.
                //repites hasta que tengas todos los parametros de tu stored procedure asociado
                elParametro = new Parametro(RecursosBDRestriccionEvento.ParamDescripcionRestricionEvento, SqlDbType.VarChar,
                    laRestriccion.Descripcion, false);
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosBDRestriccionEvento.ParamEdadMinimaRestricionEvento, SqlDbType.Int,
                        laRestriccion.EdadMinima.ToString(), false);
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosBDRestriccionEvento.ParamEdadMaximaRestricionEvento, SqlDbType.Int,
                        laRestriccion.EdadMaxima.ToString(), false);
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosBDRestriccionEvento.ParamSexoRestricionEvento, SqlDbType.VarChar,
                        laRestriccion.Sexo.ToString(), false);
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosBDRestriccionEvento.ParamIdEvento, SqlDbType.Int,
                        laRestriccion.IdEvento.ToString(), false);
                parametros.Add(elParametro);


                BDConexion laConexion = new BDConexion();// abres la conexion
                laConexion.EjecutarStoredProcedure(RecursosBDRestriccionEvento.ModificarRestriccionEvento
                                             , parametros);//ejecutas el stored procedure que quieres pasandole la lista de parametros
            }

            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }


            return true;
        }

        public bool EliminarRestriccionEvento(RestriccionEvento laRestriccion)
        {
            try
            {
                List<Parametro> parametros = new List<Parametro>(); //declaras lista de parametros

                Parametro elParametro = new Parametro(RecursosBDRestriccionEvento.ParamIdRestriccionEvento, SqlDbType.Int,
                    laRestriccion.IdRestEvento.ToString(), false);
                //parametro recibe: el alias de la accion (en este caso es la descripcion de mi restriccion de cinta que apunta a un atributo que se llama @DescripcionRestriccionCinta), SqlDbType es el tipo de dato que tiene ese atributo en la base de datos (en este caso es varchar), el elemento que se desea poner en ese lugar (aqui se usa la clase dominio), el false lo dejas asi
                parametros.Add(elParametro);
                //agregas eso que acabas de hacer a la lista de parametros.
                //repites hasta que tengas todos los parametros de tu stored procedure asociado

                BDConexion laConexion = new BDConexion();// abres la conexion
                laConexion.EjecutarStoredProcedure(RecursosBDRestriccionEvento.EliminarRHCinta
                                             , parametros);

                laConexion = new BDConexion();// abres la conexion
                laConexion.EjecutarStoredProcedure(RecursosBDRestriccionEvento.EliminarRestriccionEvento
                                             , parametros);//ejecutas el stored procedure que quieres pasandole la lista de parametros
            }

            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }


            return true;
        }

        public bool AgregarRh_Cinta(RestriccionEvento laRestriccion, int IdCinta)
        {
            try
            {
                List<Parametro> parametros = new List<Parametro>(); //declaras lista de parametros

                Parametro elParametro = new Parametro(RecursosBDRestriccionEvento.ParamIdCinta, SqlDbType.Int,
                    IdCinta.ToString(), false);
                //parametro recibe: el alias de la accion (en este caso es la descripcion de mi restriccion de cinta que apunta a un atributo que se llama @DescripcionRestriccionCinta), SqlDbType es el tipo de dato que tiene ese atributo en la base de datos (en este caso es varchar), el elemento que se desea poner en ese lugar (aqui se usa la clase dominio), el false lo dejas asi
                parametros.Add(elParametro);
                //agregas eso que acabas de hacer a la lista de parametros.
                //repites hasta que tengas todos los parametros de tu stored procedure asociado
                elParametro = new Parametro(RecursosBDRestriccionEvento.ParamIdRestriccionEvento, SqlDbType.Int,
                    laRestriccion.IdRestEvento.ToString(), false);
                parametros.Add(elParametro);

                BDConexion laConexion = new BDConexion();// abres la conexion
                laConexion.EjecutarStoredProcedure(RecursosBDRestriccionEvento.AgregarRestriccionEvento
                                             , parametros);//ejecutas el stored procedure que quieres pasandole la lista de parametros
            }

            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }


            return true;
        }

        public bool EliminarRh_Cinta(RestriccionEvento laRestriccion)
        {
            try
            {
                List<Parametro> parametros = new List<Parametro>(); //declaras lista de parametros

                Parametro elParametro = new Parametro(RecursosBDRestriccionEvento.ParamIdRestriccionEvento, SqlDbType.Int,
                    laRestriccion.IdRestEvento.ToString(), false);
                //parametro recibe: el alias de la accion (en este caso es la descripcion de mi restriccion de cinta que apunta a un atributo que se llama @DescripcionRestriccionCinta), SqlDbType es el tipo de dato que tiene ese atributo en la base de datos (en este caso es varchar), el elemento que se desea poner en ese lugar (aqui se usa la clase dominio), el false lo dejas asi
                parametros.Add(elParametro);
                //agregas eso que acabas de hacer a la lista de parametros.
                //repites hasta que tengas todos los parametros de tu stored procedure asociado

                BDConexion laConexion = new BDConexion();// abres la conexion
                laConexion.EjecutarStoredProcedure(RecursosBDRestriccionEvento.EliminarRHCinta
                                             , parametros);
            }

            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }


            return true;
        }

        public List<EventoSimple> ConsultarEventosSinRestriccion()
        {
            BDConexion laConexion;
            List<EventoSimple> losEventosSimple = new List<EventoSimple>();
            List<Parametro> parametros = new List<Parametro>();

            try
            {
                laConexion = new BDConexion();

                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                               RecursosBDRestriccionEvento.ConsultarEventosSinRestriccion, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    EventoSimple elEvento = new EventoSimple();

                    elEvento.IdEvento = int.Parse(row[RecursosBDRestriccionEvento.AliasIdEvento].ToString());
                    elEvento.NombreEvento = row[RecursosBDRestriccionEvento.AliasNombreEvento].ToString();

                    losEventosSimple.Add(elEvento);

                }

            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursoBDRestriccionCinta.Codigo_Error_Formato,
                      RecursoBDRestriccionCinta.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            return losEventosSimple;
        }

        public List<RestriccionEvento> ConsultarEventosConRestriccion()
        {
            BDConexion laConexion;
            List<RestriccionEvento> laListaRestriccionesEvento = new List<RestriccionEvento>();
            List<Parametro> parametros = new List<Parametro>();

            try
            {
                laConexion = new BDConexion();

                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                               RecursosBDRestriccionEvento.ConsultarEventosConRestriccion, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    RestriccionEvento laRestriccionEvento = new RestriccionEvento();

                    laRestriccionEvento.IdRestEvento = int.Parse(row[RecursosBDRestriccionEvento.AliasIdRestriccionEvento].ToString());
                    laRestriccionEvento.Descripcion = row[RecursosBDRestriccionEvento.AliasResDescripcion].ToString();
                    laRestriccionEvento.EdadMinima = int.Parse(row[RecursosBDRestriccionEvento.AliasEdadMin].ToString());
                    laRestriccionEvento.EdadMaxima = int.Parse(row[RecursosBDRestriccionEvento.AliasEdadMax].ToString());
                    laRestriccionEvento.Sexo = row[RecursosBDRestriccionEvento.AliasSexo].ToString();
                    laRestriccionEvento.IdEvento = int.Parse(row[RecursosBDRestriccionEvento.AliasIdEvento].ToString());
                    laRestriccionEvento.NombreEvento = row[RecursosBDRestriccionEvento.AliasNombreEvento].ToString();

                    laListaRestriccionesEvento.Add(laRestriccionEvento);

                }

            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursoBDRestriccionCinta.Codigo_Error_Formato,
                      RecursoBDRestriccionCinta.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            return laListaRestriccionesEvento;
        }

        public List<CintaSimple> ConsultarCintasRestriccionEvento(int RestEventoId)
        {
            BDConexion laConexion;
            List<CintaSimple> laListaCintasSimple = new List<CintaSimple>();
            List<Parametro> parametros = new List<Parametro>();

            Parametro elParametro = new Parametro(RecursosBDRestriccionEvento.ParamIdRestriccionEvento, SqlDbType.Int,
                    RestEventoId.ToString(), false);

            parametros.Add(elParametro);

            try
            {
                laConexion = new BDConexion();

                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                               RecursosBDRestriccionEvento.ConsultarCintasDeRestriccionEvento, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    CintaSimple laCinta = new CintaSimple();

                    laCinta.IdCinta = int.Parse(row[RecursosBDRestriccionEvento.AliasIdCinta].ToString());
                    laCinta.ColorCinta = row[RecursosBDRestriccionEvento.AliasCintaColorNombre].ToString();

                    laListaCintasSimple.Add(laCinta);

                }

            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursoBDRestriccionCinta.Codigo_Error_Formato,
                      RecursoBDRestriccionCinta.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            return laListaCintasSimple;
        }

        public List<PersonaSimple> AtletasCumplenRestriccionEvento(int EventoId)
        {
            BDConexion laConexion;
            List<PersonaSimple> laListaPersonasSimple = new List<PersonaSimple>();
            List<Parametro> parametros = new List<Parametro>();

            Parametro elParametro = new Parametro(RecursosBDRestriccionEvento.ParamIdEvento, SqlDbType.Int,
                    EventoId.ToString(), false);

            parametros.Add(elParametro);

            try
            {
                laConexion = new BDConexion();

                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                               RecursosBDRestriccionEvento.ConsultarAtletasCumplanRE, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    PersonaSimple laPersona = new PersonaSimple();

                    laPersona.IdPersona = int.Parse(row[RecursosBDRestriccionEvento.AliasIdAtleta].ToString());

                    laListaPersonasSimple.Add(laPersona);

                }

            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursoBDRestriccionCinta.Codigo_Error_Formato,
                      RecursoBDRestriccionCinta.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            return laListaPersonasSimple;
        }

        public List<EventoSimple> EventosQuePuedeAsistirAtleta(int PersonaId)
        {
            BDConexion laConexion;
            List<EventoSimple> laListaEventosSimple = new List<EventoSimple>();
            List<Parametro> parametros = new List<Parametro>();

            Parametro elParametro = new Parametro(RecursosBDRestriccionEvento.ParamIdPersona, SqlDbType.Int,
                    PersonaId.ToString(), false);

            parametros.Add(elParametro);

            try
            {
                laConexion = new BDConexion();

                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                               RecursosBDRestriccionEvento.ConsultarEventosCumplaREAtleta, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    EventoSimple elEvento = new EventoSimple();

                    elEvento.IdEvento = int.Parse(row[RecursosBDRestriccionEvento.AliasIdEvento].ToString());
                    elEvento.NombreEvento = row[RecursosBDRestriccionEvento.AliasNombreEvento].ToString();

                    laListaEventosSimple.Add(elEvento);

                }

            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursoBDRestriccionCinta.Codigo_Error_Formato,
                      RecursoBDRestriccionCinta.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            return laListaEventosSimple;
        }

    }
}