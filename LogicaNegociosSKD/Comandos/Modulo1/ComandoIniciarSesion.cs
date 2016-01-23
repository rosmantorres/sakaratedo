using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSKD.InterfazDAO.Modulo1;
using DatosSKD.Fabrica;
using DominioSKD.Entidades.Modulo1;
using DominioSKD.Entidades.Modulo2;

namespace LogicaNegociosSKD.Comandos.Modulo1
{
    public class ComandoIniciarSesion:Comando<String[]>
    {
        /// <summary>
        /// Aqui se conectara a la base de datos para ver si el usuario y contraseña son correctos y estanen el sistema
        /// </summary>
        /// <returns>retorna los valores significativos del usuario a utilizar en el sistema</returns>
        public override string[] Ejecutar()
        {
            try
            {
               FabricaDAOSqlServer laFabrica=new FabricaDAOSqlServer();
                IDaoLogin conexionBD = laFabrica.ObtenerDaoLogin();
                Cuenta cta = (Cuenta)LaEntidad;
                Cuenta user =(Cuenta) conexionBD.ObtenerUsuario(cta.Nombre_usuario);
                string[] respuesta = new string[6];
                if (cta.Contrasena == user.Contrasena && cta.Nombre_usuario != "" && cta.Contrasena != "")
                {
                    respuesta[0] = user.PersonaUsuario._Id.ToString();
                    respuesta[1] = user.Nombre_usuario;
                    respuesta[4] = user.Imagen;
                    respuesta[5] = user.PersonaUsuario._Nombre + ' ' + user.PersonaUsuario._Apellido;
                    string rolesConcat = "";
                    string split = RecursosComandoModulo1.splitRoles;
                    int cantRoles = user.Roles.Count;
                    int contador = 0;
                    DateTime fechaRol = new DateTime(1900, 1, 1);
                    foreach (Rol rol in user.Roles)
                    {
                        contador++;
                        //se intenta quitar la palabra Admin del rol si es que la tiene
                        string[] sinAdmin = rol.Nombre.Split(' ');
                        string elRol = sinAdmin[sinAdmin.Length - 1];
                        if (contador == cantRoles)
                            split = "";
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
                        throw new Exception(RecursosComandoModulo1.Mensaje_Error_Roles); ;
                    //ingresó a sistema
                }

                return null;

            }
            catch (Exception e)
            {

                Console.WriteLine(RecursosComandoModulo1.Mensaje_Error_InicioSesion + e);
                Console.WriteLine(RecursosComandoModulo1.mensajeGenerico + e.Message);
                throw e;
            }
        }


    }
}
