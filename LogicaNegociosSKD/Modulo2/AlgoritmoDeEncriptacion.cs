using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;

namespace LogicaNegociosSKD.Modulo2
{
    public class AlgoritmoDeEncriptacion
    {
        /// <summary>
        /// metodo que aplica hash con MD5 y SHA1
        /// </summary>
        /// <param name="cadena"> recibe la cadena a la que la aplicara el hash</param>
        /// <returns>devuelve la cadena con el hash hecho</returns>
        public static string hash(string cadena)
        {
            try
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
            catch (Exception e)
            {
                throw new ExcepcionesSKD.Modulo1.HashException(RecursosLogicaModulo2.Codigo_Error_Hash,
                        RecursosLogicaModulo2.Mensaje_Error_Hash, e);
            }
        }

        public static TripleDES CrearDES(string clave)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            TripleDES des = new TripleDESCryptoServiceProvider();
            des.Key = md5.ComputeHash(Encoding.Unicode.GetBytes(clave));
            des.IV = new byte[des.BlockSize / 8];
            return des;
        }

        public static string EncriptarCadenaDeCaracteres(string textoPlano, string contrasegnia)
        {
            try
            {
                // Primero debemos convertir el texto plano en `textoPlano`
                // en un arreglo de bytes:
                byte[] textoPlanoBytes = Encoding.Unicode.GetBytes(textoPlano);

                // Uso de un flujo de memoria para la contención de los bytes:
                MemoryStream flujoMemoria = new MemoryStream();

                // Creación de la clave de protección y el vector de inicialización:
                TripleDES des = CrearDES(contrasegnia);

                // Creación del codificador para la escritura al flujo de memoria:
                CryptoStream flujoEncriptacion = new CryptoStream(flujoMemoria, des.CreateEncryptor(), CryptoStreamMode.Write);

                // Escritura del arreglo de bytes sobre el flujo de memoria:
                flujoEncriptacion.Write(textoPlanoBytes, 0, textoPlanoBytes.Length);
                flujoEncriptacion.FlushFinalBlock();

                // Retorna representación legible de la cadena encriptada:
                return Convert.ToBase64String(flujoMemoria.ToArray());
            }
            catch(FormatException ex)
            {
                throw ex;
            }
        }
    
        public static string DesencriptarCadenaDeCaracteres(string textoEncriptado, string contrasegnia)
        {
            try
            {
                string[] idSplit = textoEncriptado.Split(' ');
                if (idSplit.Count() > 1)
                {
                    textoEncriptado = idSplit[0];
                    for (int i = 1; idSplit.Count() > i; i++)
                    {
                        textoEncriptado = textoEncriptado + '+' + idSplit[i];
                    }
                }
                // Primero debemos convertir el texto plano en `textoPlano`
                // en un arreglo de bytes:
                byte[] bytesEncriptados = Convert.FromBase64String(textoEncriptado);

                // Uso de un flujo de memoria para la contención de los bytes:
                MemoryStream flujoMemoria = new MemoryStream();

                // Creación de la clave de protección y el vector de inicialización:
                TripleDES des = CrearDES(contrasegnia);

                // Creación de decodificador:
                CryptoStream flujoDesencriptacion = new CryptoStream(flujoMemoria, des.CreateDecryptor(), CryptoStreamMode.Write);

                // Escritura del arreglo de bytes sobre el flujo de memoria:
                flujoDesencriptacion.Write(bytesEncriptados, 0, bytesEncriptados.Length);
                flujoDesencriptacion.FlushFinalBlock();

                // Conversión del flujo de datos en una cadena de caracteres:
                return Encoding.Unicode.GetString(flujoMemoria.ToArray());
            }
            catch (FormatException ex)
            {
                throw ex;
            }
        }
    }
    
}
