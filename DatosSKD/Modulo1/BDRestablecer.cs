﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

namespace DatosSKD.Modulo1
{
    public class BDRestablecer
    {
        public static bool RestablecerContrasena(string usuarioId,string contraseña)
        {
            BDConexion laConexion;
            List<Parametro> parametros;
            Parametro elParametro = new Parametro();

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();
                Cuenta laCuenta = new Cuenta();
                elParametro = new Parametro(RecursosBDModulo1.AliasIdUsuario, SqlDbType.Int, usuarioId, false);
                parametros.Add(elParametro);
                elParametro = new Parametro(RecursosBDModulo1.AliasContrasena, SqlDbType.VarChar,contraseña, false);
                parametros.Add(elParametro);

                laConexion.EjecutarStoredProcedureTuplas(
                      RecursosBDModulo1.CambiarContraseña, parametros);


                return true;

            }
            catch (Exception e)
            {
                throw e;
            }
        }
   
    
    }
}
