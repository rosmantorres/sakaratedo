using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Net.Mail;
using DominioSKD;
using DatosSKD;

namespace DatosSKD.Modulo6
{
    public class BDUsuarios
    {
        private static DataTable getTable(string query, List<Parametro> parametros)
        {
            DataTable ret;
            BDConexion con = new BDConexion();
            try
            {
                ret = con.EjecutarStoredProcedureTuplas(query, parametros);
            }
            catch ( ExcepcionesSKD.ExceptionSKDConexionBD e){
                throw e;
            }
            catch (ExcepcionesSKD.ParametroInvalidoException e)
            {
                throw e;
            }
            return ret;
        }

        private static List<Resultado> getValues(string query, List<Parametro> parametros)
        {
            List<Resultado> ret;
            BDConexion con = new BDConexion();
            try
            {
                ret = con.EjecutarStoredProcedure(query, parametros);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD e)
            {
                throw e;
            }
            catch (ExcepcionesSKD.ParametroInvalidoException e)
            {
                throw e;
            }
            return ret;
        }


        private static String EnumDocId(Persona per)
        {
            if (per.DocumentoID.Tipo == TipoDocumento.Pasaporte)
                return RecursosBDModulo6.Documento_Pasaporte;
            else
                if (per.DocumentoID.TipoCedula == TipoCedula.Nacional)
                    return RecursosBDModulo6.Documento_Cedula_Nacional;
                else
                    return RecursosBDModulo6.Documento_Cedula_Extranjera;
        }

        private static String EnumSexo(Sexo sex)
        {
            if (sex == Sexo.Femenino)
                return RecursosBDModulo6.Sexo_Femenino;
            else
                return RecursosBDModulo6.Sexo_Masculino;
        }

        private static String EnumSangre(Sangre san)
        {
            switch (san)
            {
                case Sangre.ABN:
                    return RecursosBDModulo6.Sangre_ABN;
                case Sangre.ABP:
                    return RecursosBDModulo6.Sangre_ABP;
                case Sangre.AN:
                    return RecursosBDModulo6.Sangre_AN;
                case Sangre.AP:
                    return RecursosBDModulo6.Sangre_AP;
                case Sangre.BN:
                    return RecursosBDModulo6.Sangre_BN;
                case Sangre.BP:
                    return RecursosBDModulo6.Sangre_BP;
                case Sangre.ON:
                    return RecursosBDModulo6.Sangre_ON;
                case Sangre.OP:
                    return RecursosBDModulo6.Sangre_OP;
            }
            return RecursosBDModulo6.Sangre_OP;
        }

        public static void GuardarDatosDePersona(Persona per)
        {
            Parametro parametro;
            List<Parametro> parametros;
            List<Resultado> res;

            parametros = new List<Parametro>();

            parametro = new Parametro("@" + RecursosBDModulo6.Atribute_Persona_Tipo_Documento, SqlDbType.VarChar, EnumDocId(per), false);
            parametros.Add(parametro);

            parametro = new Parametro("@" + RecursosBDModulo6.Atribute_Persona_Numero_Documento, SqlDbType.Int, per.DocumentoID.Numero.ToString(), false);
            parametros.Add(parametro);

            parametro = new Parametro("@" + RecursosBDModulo6.Atribute_Persona_Nombre, SqlDbType.VarChar, per.Nombre, false);
            parametros.Add(parametro);

            parametro = new Parametro("@" + RecursosBDModulo6.Atribute_Persona_Apellido, SqlDbType.VarChar, per.Apellido, false);
            parametros.Add(parametro);

            parametro = new Parametro("@" + RecursosBDModulo6.Atribute_Persona_Nacionalidad, SqlDbType.VarChar, per.Nacionalidad, false);
            parametros.Add(parametro);

            parametro = new Parametro("@" + RecursosBDModulo6.Atribute_Persona_Alergias, SqlDbType.Text, per.Alergias, false);
            parametros.Add(parametro);

            parametro = new Parametro("@" + RecursosBDModulo6.Atribute_Persona_direccion, SqlDbType.Text, per.Direccion, false);
            parametros.Add(parametro);

            parametro = new Parametro("@" + RecursosBDModulo6.Atribute_Persona_Sexo, SqlDbType.Char, EnumSexo(per.Sexo), false);
            parametros.Add(parametro);

            parametro = new Parametro("@" + RecursosBDModulo6.Atribute_Persona_Sangre, SqlDbType.VarChar, EnumSangre(per.TipoSangre), false);
            parametros.Add(parametro);

            parametro = new Parametro("@" + RecursosBDModulo6.Atribute_Persona_Nacimiento, SqlDbType.DateTime, per.FechaNacimiento.ToString(), false);
            parametros.Add(parametro);

            parametro = new Parametro("@" + RecursosBDModulo6.Atribute_Persona_Peso, SqlDbType.Float, per.Peso.ToString(), false);
            parametros.Add(parametro);

            parametro = new Parametro("@" + RecursosBDModulo6.Atribute_Persona_Estatura, SqlDbType.Float, per.Estatura.ToString(), false);
            parametros.Add(parametro);

            if (per.ID == -1)
            {
                parametro = new Parametro("@" + RecursosBDModulo6.Atribute_Persona_Id, SqlDbType.Int, true);
                parametros.Add(parametro);
                res = getValues(RecursosBDModulo6.SP_Add_Persona, parametros);
                per.ID = int.Parse(res.ToArray()[0].valor);
            }
            else
            {
                parametro = new Parametro("@" + RecursosBDModulo6.Atribute_Persona_Id, SqlDbType.Int, per.ID.ToString(), false);
                parametros.Add(parametro);
                res = getValues(RecursosBDModulo6.SP_Chg_Persona, parametros);
            }
        }
    }
}
