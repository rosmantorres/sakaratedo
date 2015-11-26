using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using DatosSKD.Modulo1;
using DominioSKD;

namespace LogicaNegociosSKD.Modulo1
{
    public class login
    {
        MailMessage Mail = new MailMessage();
        SmtpClient SMTP = new SmtpClient();
        /// <summary>
        /// Procedimiento para el envio de correo para el reestablecimiento de la contraseña
        /// </summary>
        /// <param name="CorreoOrigen">Correo emitente</param>
        /// <param name="Clave">contraseña del correo emitente</param>
        /// <param name="Destino">Correo destino</param>
        /// <param name="Mensaje">Mensaje a enviar</param>
        /// <returns>True si se envio, false si ocurrio un error</returns>
        public Boolean EnviarCorreo(String Destino)
        {
            try
            {
                String DireccionHTTP = "http://localhost:" + RecursosLogicaModulo1.puertoSAKARATEDO +
                RecursosLogicaModulo1.direccionM1_RestablecerContraseña;
                String mensajeDireccion = "<br>" +  DireccionHTTP + "</br>";
                Mail.From = new MailAddress(RecursosLogicaModulo1.cuentaCorreoSAKARATEDO);
                Mail.To.Add(new MailAddress(Destino));
                Mail.Body = RecursosLogicaModulo1.mensajeSAKARATEDO+mensajeDireccion;
                Mail.BodyEncoding = System.Text.Encoding.UTF8;
                Mail.IsBodyHtml = true;//si queremos que se envie como codigo HTML
                Mail.Subject =RecursosLogicaModulo1.asuntoSAKARATEDO ;
                Mail.SubjectEncoding = System.Text.Encoding.UTF8;
                //Envia una copia de correo a sakaratedo@
                Mail.Bcc.Add(RecursosLogicaModulo1.cuentaCorreoSAKARATEDO);
                //configuracion SMTP
                SMTP.Host = RecursosLogicaModulo1.hostSAKARATEDO;
                SMTP.Port = int.Parse(RecursosLogicaModulo1.puertoEnvioSAKARATEDO);
                SMTP.Credentials = new NetworkCredential(RecursosLogicaModulo1.cuentaCorreoSAKARATEDO,RecursosLogicaModulo1.cuentaClaveSAKARATEDO);
                SMTP.EnableSsl = true;
                SMTP.Send(Mail);
                return true;

            }
            catch (Exception e)
            {
                Console.Write("Erro encontrado aqui:");
                Console.Write(e.StackTrace);
                Console.Write(e.ToString());
                Console.Write(e.Data.ToString());
                Console.Write(e.Message);
                return false;
            }
        }
        /// <summary>
        /// Proceso que conectara con la base de datos para pedir los usuarios en base a los datos introducidos en el login 
        /// </summary>
        /// <param name="id">Es el usuario que se introduce en el login</param>
        /// <param name="contraseña">contraseña</param>
        /// <param name="registro">se debe eliminar esto era para validar en base a los datos preguardados de cuentas</param>
        /// <returns></returns>
        public Boolean validaUsuario(string id, string contraseña,string[] registro)
        {
            if (registro[0] == id && registro[1] == contraseña)
                return true;
            
            return false;
        }

        /// <summary>
        /// Aqui se conectara a la base de datos para ver si el usuario y contraseña son correctos y estanen el sistema
        /// </summary>
        /// <param name="usuario">usuario</param>
        /// <param name="contraseña">contraseña</param>
        /// <returns>retorna los valores significativos del usuario a utilizar en el sistema</returns>
        public string[] iniciarSesion(string usuario, string contraseña)
        {
            try
            {
               //consularbasededatos(usuario,contrasea);
                Cuenta user= BDLogin.ObtenerUsuario(usuario);
                string[] respuesta = new string[4];
                /*
                string[] admin = { "admin@gmail.com", "12345","Sistema","juan","Perez","Atleta-Dojo-Sistema"};
                string[] dojo = { "dojo@gmail.com", "12345", "Dojo","Javier","Dominguez","Dojo"};
                string[] organizacion = { "organizacion@gmail.com", "12345", "Organizacion","Pepe","Lopez","Organizacion" };
                string[] entrenador = { "entrenador@gmail.com", "12345", "Entrenador" ,"Rebeca","Larez","Entrenador"};
                string[] atleta = { "atleta@gmail.com", "12345", "Atleta","Sandra","Villa","Atleta" };
                string[] representante = { "representante@gmail.com", "12345", "Representante","Maria","Paz","Representante" };
                string[] menorEdad = { "atletaM@gmail.com", "12345", "Atleta(Menor)", "Armando", "Paredes", "Atleta(Menor)" };
                */
               string hashClave = hash(contraseña);
               if (hashClave == hash(user.Contrasena) && usuario!="" && contraseña!="")//en la Bd debe estar guardado en hash CAMBIAR ESTO!!!
               {
                   respuesta[0] = user.Id_usuario.ToString();
                   respuesta[1] = user.Nombre_usuario;
                   string rolesConcat = "";
                   string split= RecursosLogicaModulo1.splitRoles;
                   int cantRoles=user.Roles.Count;
                   int contador=0;
                   DateTime fechaRol= new DateTime(1900,1,1);
                   foreach (Rol rol in user.Roles)
                   {
                       contador++;
                       //se intenta quitar la palabra Admin del rol si es que la tiene
                       string[] sinAdmin = rol.Nombre.Split(' ');
                       string elRol = sinAdmin[sinAdmin.Length - 1];
                       if(contador==cantRoles)
                           split="";
                      // if(elRol==RecursosLogicaModulo1.rolAtleta ) verificar si es menor de edad
                       rolesConcat = rolesConcat + elRol + split;
                       int d = DateTime.Compare(fechaRol, rol.Fecha_creacion);
                       if (DateTime.Compare(fechaRol, rol.Fecha_creacion) == -1)
                       {
                           fechaRol = rol.Fecha_creacion;
                           respuesta[3] = elRol;
                       }

                   }
                   respuesta[2] = rolesConcat;
                   if (rolesConcat != "")
                       return respuesta;
                   else
                       return null;
                   //ingresó a sistema
               }

                    return null;
               
            }
            catch (Exception e)
            {
                Console.WriteLine("Error encontrado en login.iniciarSesion: " + e);
                Console.WriteLine("Mensaje: " + e.Message);
                return null;
            }
        }



        public static string hash(string cadena)
        {
            HashAlgorithm sha = new SHA1CryptoServiceProvider(); //se crea la variable que contrenda el SHA1
            MD5 md5Hash = MD5.Create();// se crea la variable que contendrá el MD5
            byte[] cadenaByte = Encoding.UTF8.GetBytes(cadena);// se pasa la cadena de caracteres a un arreglo de byte
            byte[] hashByte = sha.ComputeHash(cadenaByte);// se realiza el hash SHA1
            byte[] md5Byte = md5Hash.ComputeHash(hashByte);// se le aplica el hash MD5 al hash SHA1 para mayor seguridad
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < md5Byte.Length; i++)
            {
                sBuilder.Append(md5Byte[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }
    }
}