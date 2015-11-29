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
    /// <summary>
    /// Clase con metos estaticos para interactuar con
    /// la basede datos. Todo lo relacionado con Personas
    /// y Usuarios.
    /// </summary>
    public class BDUsuarios
    {

        /// <summary>
        /// Metodo para obtener el string correspontiente
        /// al tipo de documento en la base de datos
        /// </summary>
        /// <param name="per">Objeto persona</param>
        /// <returns>String de como se guarda en base de datos</returns>
        private static String EnumDocId(Persona per)
        {
            if (per.DocumentoID == null)
                return null;
            if (per.DocumentoID.Tipo == TipoDocumento.Pasaporte)
                return RecursosBDModulo6.Documento_Pasaporte;
            else
                if (per.DocumentoID.TipoCedula == TipoCedula.Nacional)
                    return RecursosBDModulo6.Documento_Cedula_Nacional;
                else
                    return RecursosBDModulo6.Documento_Cedula_Extranjera;
        }

        /// <summary>
        /// Configura el tipo de documento de ua parsona
        /// a partir de un String del campo correspondiente
        /// en la base de datos
        /// </summary>
        /// <param name="Tipo">Valor del campo en la base de datos</param>
        /// <param name="per">Objeto persona a condigurar</param>
        private static void EnumDocId(String Tipo, Persona per)
        {
            if (Tipo.Equals(RecursosBDModulo6.Documento_Cedula_Nacional))
            {
                per.DocumentoID.Tipo = TipoDocumento.Cedula;
                per.DocumentoID.TipoCedula = TipoCedula.Nacional;
            }
            else if (Tipo.Equals(RecursosBDModulo6.Documento_Cedula_Extranjera))
            {
                per.DocumentoID.Tipo = TipoDocumento.Cedula;
                per.DocumentoID.TipoCedula = TipoCedula.Extranjera;
            }
            else if (Tipo.Equals(RecursosBDModulo6.Documento_Pasaporte))
            {
                per.DocumentoID.Tipo = TipoDocumento.Pasaporte;
            }
                
        }

        /// <summary>
        /// Metodo para obtener el caracter correspontiente
        /// al la enumeracion de Sexo para la base de datos
        /// </summary>
        /// <param name="sex">Valor de la enumeracion Sexo</param>
        /// <returns>Caracter guardado en base de datos.</returns>
        private static String EnumSexo(Sexo sex)
        {
            if (sex == Sexo.Femenino)
                return RecursosBDModulo6.Sexo_Femenino;
            else
                return RecursosBDModulo6.Sexo_Masculino;
        }

        /// <summary>
        /// Metodo para obtener el valor de una enumeracion
        /// a partir de un charater en el campo de la base de datos
        /// </summary>
        /// <param name="sex">Valor en el campo de la base de datos</param>
        /// <returns>Valor de la enumeracion Sexo</returns>
        private static Sexo EnumSexo(String sex)
        {
            if (sex == RecursosBDModulo6.Sexo_Femenino)
                return Sexo.Femenino;
            else
                return Sexo.Masculino;
        }

        /// <summary>
        /// Obtine el valor en base de datos de la enumeracion
        /// Sangre
        /// </summary>
        /// <param name="san">Valor de la enumeracion Sange</param>
        /// <returns>String a guardar en la base de datos</returns>
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
            return null;
        }


        /// <summary>
        /// Apartir del valor del campo en la base de datos
        /// retorna el valor correspondiente de la enumeracion Sangre
        /// </summary>
        /// <param name="san">Strig del campo de la base de datos</param>
        /// <returns>Valor de la enumeracion Sangre</returns>
        private static Sangre EnumSangre(String san)
        {
            if (san.Equals(RecursosBDModulo6.Sangre_ABN))
                return Sangre.ABN;
            else if (san.Equals(RecursosBDModulo6.Sangre_ABP))
                return Sangre.ABP;
            else if (san.Equals(RecursosBDModulo6.Sangre_AN))
                return Sangre.AN;
            else if (san.Equals(RecursosBDModulo6.Sangre_AP))
                return Sangre.AP;
            else if (san.Equals(RecursosBDModulo6.Sangre_BN))
                return Sangre.BN;
            else if (san.Equals(RecursosBDModulo6.Sangre_BP))
                return Sangre.BP;
            else if (san.Equals(RecursosBDModulo6.Sangre_ON))
                return Sangre.ON;

            return Sangre.OP;
        }

        /// <summary>
        /// Guarda la estructura de una persona en la base de datos
        /// </summary>
        /// <param name="per">Objeto persona</param>
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
                // Si es una nueva persona
                parametro = new Parametro("@" + RecursosBDModulo6.Atribute_Persona_Id, SqlDbType.Int, true);
                parametros.Add(parametro);
                res = BDUtils.getValues(RecursosBDModulo6.SP_Add_Persona, parametros);
                per.ID = int.Parse(res.ToArray()[0].valor);
            }
            else
            {
                // Si ya tiene un id en base de datos
                parametro = new Parametro("@" + RecursosBDModulo6.Atribute_Persona_Id, SqlDbType.Int, per.ID.ToString(), false);
                parametros.Add(parametro);
                res = BDUtils.getValues(RecursosBDModulo6.SP_Chg_Persona, parametros);
            }

            // Guardar telefonos y correos
            GuardarTelefonos(per);
            GuardarCorreos(per);

            if (per.ContatoEmergencia != null)
            {
                // Si tiene una persona de contacto, tambien guardarla.
                BDUsuarios.GuardarDatosContacto(per.ContatoEmergencia);
                BDUsuarios.GuardarContacto(per);
            }
        }

        /// <summary>
        /// Guarda en base de datos la información de una persona 
        /// Representante
        /// </summary>
        /// <param name="per">Objeto Persona</param>
        public static void GuardarDatosDeRepresentante(Persona per)
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

            parametro = new Parametro("@" + RecursosBDModulo6.Atribute_Persona_Sexo, SqlDbType.Char, EnumSexo(per.Sexo), false);
            parametros.Add(parametro);

            parametro = new Parametro("@" + RecursosBDModulo6.Atribute_Persona_Nacimiento, SqlDbType.DateTime, per.FechaNacimiento.ToString(), false);
            parametros.Add(parametro);

            if (per.ID == -1)
            {
                parametro = new Parametro("@" + RecursosBDModulo6.Atribute_Persona_Id, SqlDbType.Int, true);
                parametros.Add(parametro);
                res = BDUtils.getValues(RecursosBDModulo6.SP_Add_Persona_Representante, parametros);
                per.ID = int.Parse(res.ToArray()[0].valor);
            }
            else
            {
                parametro = new Parametro("@" + RecursosBDModulo6.Atribute_Persona_Id, SqlDbType.Int, per.ID.ToString(), false);
                parametros.Add(parametro);
                /*
                res = BDUtils.getValues(RecursosBDModulo6.SP_Chg_Persona_Contacto, parametros);*/
            }
            GuardarTelefonos(per);
            GuardarCorreos(per);

            // Guardar sus representados
            foreach (Persona representado in per.Representados)
                BDUsuarios.GuardarDatosDePersona(representado);

            BDUsuarios.GuardarRepresentados(per);
        }

        /// <summary>
        /// Guarda los datos de un contacto de emergencia
        /// </summary>
        /// <param name="per">Objeto persona a guardar</param>
        private static void GuardarDatosContacto(Persona per)
        {

            Parametro parametro;
            List<Parametro> parametros;
            List<Resultado> res;

            parametros = new List<Parametro>();

            parametro = new Parametro("@" + RecursosBDModulo6.Atribute_Persona_Nombre, SqlDbType.VarChar, per.Nombre, false);
            parametros.Add(parametro);

            parametro = new Parametro("@" + RecursosBDModulo6.Atribute_Persona_Apellido, SqlDbType.VarChar, per.Apellido, false);
            parametros.Add(parametro);

            parametro = new Parametro("@" + RecursosBDModulo6.Atribute_Persona_Sexo, SqlDbType.Char, EnumSexo(per.Sexo), false);
            parametros.Add(parametro);

            if (per.ID == -1)
            {
                parametro = new Parametro("@" + RecursosBDModulo6.Atribute_Persona_Id, SqlDbType.Int, true);
                parametros.Add(parametro);
                res = BDUtils.getValues(RecursosBDModulo6.SP_Add_Contacto, parametros);
                per.ID = int.Parse(res.ToArray()[0].valor);
            }
            else
            {
                parametro = new Parametro("@" + RecursosBDModulo6.Atribute_Persona_Id, SqlDbType.Int, per.ID.ToString(), false);
                parametros.Add(parametro);
                res = BDUtils.getValues(RecursosBDModulo6.SP_Chg_Persona_Contacto, parametros); ;
            }
            GuardarTelefonos(per);
            GuardarCorreos(per);
        }

        /// <summary>
        /// Guarda los telefonos de una persona
        /// </summary>
        /// <param name="per">Objeto persona a cuardar sus telefonos</param>
        private static void GuardarTelefonos(Persona per)
        {
            Parametro parametro;
            List<Parametro> parametros;
            List<Resultado> res;


            foreach (Telefono tel in per.Telefonos)
            {
                parametros = new List<Parametro>();

                parametro = new Parametro("@" + RecursosBDModulo6.Atribute_Telefono_numero, SqlDbType.VarChar, tel.Numero.ToString(), false);
                parametros.Add(parametro);

                if (tel.ID == -1)
                {
                    parametro = new Parametro("@" + RecursosBDModulo6.Atribute_Persona_Id, SqlDbType.Int, per.ID.ToString(), false);
                    parametros.Add(parametro);
                    parametro = new Parametro("@" + RecursosBDModulo6.Atribute_Telefono_Id, SqlDbType.Int, true);
                    parametros.Add(parametro);

                    res = BDUtils.getValues(RecursosBDModulo6.SP_Add_Telefono, parametros);
                    tel.ID = int.Parse(res.ToArray()[0].valor);
                }
                else
                {
                    parametro = new Parametro("@" + RecursosBDModulo6.Atribute_Telefono_Id, SqlDbType.Int, tel.ID.ToString(), false);
                    parametros.Add(parametro);

                    res = BDUtils.getValues(RecursosBDModulo6.SP_Chg_Telefono, parametros);
                }
            }
        }

        /// <summary>
        /// Guarda  los correos electronicos de una persona
        /// </summary>
        /// <param name="per">Objeto persona a cuardar sus correos</param>
        private static void GuardarCorreos(Persona per)
        {
            Parametro parametro;
            List<Parametro> parametros;
            List<Resultado> res;


            foreach (Correo email in per.Correos)
            {
                parametros = new List<Parametro>();

                parametro = new Parametro("@" + RecursosBDModulo6.Atribute_Correo_Direccion, SqlDbType.VarChar, email.ToString(), false);
                parametros.Add(parametro);

                if (email.ID == -1)
                {
                    parametro = new Parametro("@" + RecursosBDModulo6.Atribute_Persona_Id, SqlDbType.Int, per.ID.ToString(), false);
                    parametros.Add(parametro);
                    parametro = new Parametro("@" + RecursosBDModulo6.Atribute_Correo_Id, SqlDbType.Int, true);
                    parametros.Add(parametro);

                    res = BDUtils.getValues(RecursosBDModulo6.SP_Add_Correo, parametros);
                    email.ID = int.Parse(res.ToArray()[0].valor);
                }
                else
                {
                    parametro = new Parametro("@" + RecursosBDModulo6.Atribute_Correo_Id, SqlDbType.Int, email.ID.ToString(), false);
                    parametros.Add(parametro);

                    res = BDUtils.getValues(RecursosBDModulo6.SP_Chg_Correo, parametros);
                }
                if (email.Primario)
                {
                    parametros = new List<Parametro>();

                    parametro = new Parametro("@" + RecursosBDModulo6.Atribute_Persona_Id, SqlDbType.Int, per.ID.ToString(), false);
                    parametros.Add(parametro);

                    parametro = new Parametro("@" + RecursosBDModulo6.Atribute_Correo_Id, SqlDbType.Int, email.ID.ToString(), false);
                    parametros.Add(parametro);

                    BDUtils.getValues(RecursosBDModulo6.SP_Set_Correo_Principal, parametros);
                }
            }
        }

        /// <summary>
        /// Crea una objeto persona a partir de su id en base de datos.
        /// </summary>
        /// <param name="dbid">Id en base de datos</param>
        /// <returns>Objeto persona constuido.</returns>
        public static Persona GetInfoPersonaByID(int dbid)
        {
            Parametro parametro;
            List<Parametro> parametros;
            DataTable table;
            Persona per;

            parametros = new List<Parametro>();

            parametro = new Parametro("@" + RecursosBDModulo6.Atribute_Persona_Id, SqlDbType.Int, dbid.ToString(), false);
            parametros.Add(parametro);

            table = BDUtils.getTable(RecursosBDModulo6.SP_Get_Persona, parametros);

            if (table.Rows.Count != 1)
            {
                // Lanza Excpcion;
            }
            
            foreach (DataRow row in table.Rows)
            {
                per = new Persona(Convert.ToInt32(row[RecursosBDModulo6.Atribute_Persona_Id].ToString()));
                per.Nombre = row[RecursosBDModulo6.Atribute_Persona_Nombre].ToString();
                per.Apellido = row[RecursosBDModulo6.Atribute_Persona_Apellido].ToString();
                per.Nacionalidad = row[RecursosBDModulo6.Atribute_Persona_Nacionalidad].ToString();
                per.Alergias = row[RecursosBDModulo6.Atribute_Persona_Alergias].ToString();
                per.Direccion = row[RecursosBDModulo6.Atribute_Persona_direccion].ToString();

                if (!String.IsNullOrEmpty(row[RecursosBDModulo6.Atribute_Persona_Nacimiento].ToString()))
                    per.FechaNacimiento = Convert.ToDateTime(row[RecursosBDModulo6.Atribute_Persona_Nacimiento].ToString());

                if (!String.IsNullOrEmpty(row[RecursosBDModulo6.Atribute_Persona_Peso].ToString()))
                    per.Peso = Convert.ToDouble(row[RecursosBDModulo6.Atribute_Persona_Peso].ToString());

                if (!String.IsNullOrEmpty(row[RecursosBDModulo6.Atribute_Persona_Estatura].ToString()))
                    per.Estatura = Convert.ToDouble(row[RecursosBDModulo6.Atribute_Persona_Estatura].ToString());

                per.DocumentoID = new DocumentoIdentidad();

                if (!String.IsNullOrEmpty(row[RecursosBDModulo6.Atribute_Persona_Tipo_Documento].ToString()))
                    BDUsuarios.EnumDocId(row[RecursosBDModulo6.Atribute_Persona_Tipo_Documento].ToString(), per);

                if (!String.IsNullOrEmpty(row[RecursosBDModulo6.Atribute_Persona_Numero_Documento].ToString()))
                    per.DocumentoID.Numero = Convert.ToInt32(row[RecursosBDModulo6.Atribute_Persona_Numero_Documento].ToString());

                if (!String.IsNullOrEmpty(row[RecursosBDModulo6.Atribute_Persona_Sexo].ToString()))
                    per.Sexo = BDUsuarios.EnumSexo(row[RecursosBDModulo6.Atribute_Persona_Sexo].ToString());

                if (!String.IsNullOrEmpty(row[RecursosBDModulo6.Atribute_Persona_Sangre].ToString()))
                    per.TipoSangre = BDUsuarios.EnumSangre(row[RecursosBDModulo6.Atribute_Persona_Sangre].ToString());


                BDUsuarios.ListaTelefonos(per);
                BDUsuarios.ListCorreos(per);

                return per;
            }
            return null;
        }

        /// <summary>
        /// Agrega los telefonos de una persona guardados en la
        /// base de datos
        /// </summary>
        /// <param name="per">Objeto Persona</param>
        private static void ListaTelefonos(Persona per)
        {
            Telefono telf;
            Parametro parametro;
            List<Parametro> parametros;
            DataTable res;

            parametros = new List<Parametro>();

            parametro = new Parametro("@" + RecursosBDModulo6.Atribute_Persona_Id, SqlDbType.Int, per.ID.ToString(), false);
            parametros.Add(parametro);

            res = BDUtils.getTable(RecursosBDModulo6.SP_Get_Telefonos, parametros);

            foreach (DataRow row in res.Rows)
            {
                telf = new Telefono(int.Parse(row[RecursosBDModulo6.Atribute_Telefono_Id].ToString()));
                telf.Numero = row[RecursosBDModulo6.Atribute_Telefono_numero].ToString();
                per.agregarTelefono(telf);
            }

        }
        /// <summary>
        /// Agrega los correos de una persona guardados en la
        /// base de datos
        /// </summary>
        /// <param name="per"></param>
        private static void ListCorreos(Persona per)
        {
            Correo mail;
            Parametro parametro;
            List<Parametro> parametros;
            DataTable res;

            parametros = new List<Parametro>();

            parametro = new Parametro("@" + RecursosBDModulo6.Atribute_Persona_Id, SqlDbType.Int, per.ID.ToString(), false);
            parametros.Add(parametro);

            res = BDUtils.getTable(RecursosBDModulo6.SP_Get_Emails, parametros);

            foreach (DataRow row in res.Rows)
            {
                mail = new Correo(int.Parse(row[RecursosBDModulo6.Atribute_Correo_Id].ToString()), row[RecursosBDModulo6.Atribute_Correo_Direccion].ToString());
                mail.Primario = bool.Parse(row[RecursosBDModulo6.Atribute_Correo_Principal].ToString());
                per.agregarEmail(mail);
            }
        }

        /// <summary>
        /// Guarda la relacion Contacto de emergencia de una persona
        /// </summary>
        /// <param name="per">Objeto persona</param>
        private static void GuardarContacto(Persona per)
        {
            Parametro parametro;
            List<Parametro> parametros;

            if (per.ContatoEmergencia == null)
                return;

            parametros = new List<Parametro>();

            parametro = new Parametro("@" + RecursosBDModulo6.Atribute_Persona_Id, SqlDbType.Int, per.ID.ToString(), false);
            parametros.Add(parametro);

            parametro = new Parametro("@" + RecursosBDModulo6.Atribute_Persona_Relacion, SqlDbType.Int, per.ContatoEmergencia.ID.ToString(), false);
            parametros.Add(parametro);

            parametro = new Parametro("@" + RecursosBDModulo6.Atribute_Relacion_Tipo, SqlDbType.VarChar, RecursosBDModulo6.Relacion_Contacto, false);
            parametros.Add(parametro);

            BDUtils.getValues(RecursosBDModulo6.SP_Add_Relacion, parametros);

        }

        /// <summary>
        /// Guarda la relazion de representante
        /// </summary>
        /// <param name="per">Objeto Persona </param>
        private static void GuardarRepresentados(Persona per)
        {
            Parametro parametro;
            List<Parametro> parametros;

            if (per.Representados == null)
                return;

            foreach (Persona repre in per.Representados)
            {
                parametros = new List<Parametro>();

                parametro = new Parametro("@" + RecursosBDModulo6.Atribute_Persona_Id, SqlDbType.Int, per.ID.ToString(), false);
                parametros.Add(parametro);

                parametro = new Parametro("@" + RecursosBDModulo6.Atribute_Persona_Relacion, SqlDbType.Int, repre.ID.ToString(), false);
                parametros.Add(parametro);

                parametro = new Parametro("@" + RecursosBDModulo6.Atribute_Relacion_Tipo, SqlDbType.VarChar, RecursosBDModulo6.Relacion_Representante, false);
                parametros.Add(parametro);

                BDUtils.getValues(RecursosBDModulo6.SP_Add_Relacion, parametros);
            }
        }

        /// <summary>
        /// Obtiene el contacto de emergencia de una persona
        /// </summary>
        /// <param name="per">Objeto persona</param>
        public static void GetContacto(Persona per)
        {
            Parametro parametro;
            List<Parametro> parametros;
            List<Resultado> res;

            parametros = new List<Parametro>();

            parametro = new Parametro("@" + RecursosBDModulo6.Atribute_Persona_Id, SqlDbType.Int, per.ID.ToString(), false);
            parametros.Add(parametro);

            parametro = new Parametro("@" + RecursosBDModulo6.Atribute_Persona_Relacion, SqlDbType.Int, true);
            parametros.Add(parametro);

            res = BDUtils.getValues(RecursosBDModulo6.SP_Get_Contacto, parametros);

            if (res.Count == 1)
            {
                per.ContatoEmergencia = BDUsuarios.GetInfoPersonaByID(Convert.ToInt32(res[0].valor.ToString()));
            }

        }

        /// <summary>
        /// Obtiene los representados de una persona
        /// </summary>
        /// <param name="per">Persona</param>
        public static void CargarRepresentados(Persona per)
        {
            Persona representado;
            Parametro parametro;
            List<Parametro> parametros;
            DataTable res;


            parametros = new List<Parametro>();

            parametro = new Parametro("@" + RecursosBDModulo6.Atribute_Persona_Id, SqlDbType.Int, per.ID.ToString(), false);
            parametros.Add(parametro);

            res = BDUtils.getTable(RecursosBDModulo6.SP_Get_Representados, parametros);

            foreach (DataRow row in res.Rows)
            {
                representado = BDUsuarios.GetInfoPersonaByID(int.Parse(row[RecursosBDModulo6.Atribute_Persona_Id].ToString()));
                per.addRepresentado(representado);
            }
        }

    }
}
