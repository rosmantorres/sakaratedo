﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSKD.InterfazDAO.Modulo8;
using DominioSKD;
using System.Data.SqlClient;

namespace LogicaNegociosSKD.Comandos.Modulo8
{
    public class ComandoModificarRestriccionCinta : Comando<Boolean>
    {

        private Entidad parametro;

        public Entidad Parametro
        {
            get { return parametro; }
            set { parametro = value; }
        }

        public ComandoModificarRestriccionCinta(Entidad nuevaEntidad)
            : base()
        {
            this.LaEntidad = nuevaEntidad;
        }

        public override Boolean Ejecutar()
        {
            Boolean resultado = false;
            
            DatosSKD.Fabrica.FabricaDAOSqlServer fabricaDAO = new DatosSKD.Fabrica.FabricaDAOSqlServer();

            IDaoRestriccionCinta daoRestriccionCinta = DatosSKD.Fabrica.FabricaDAOSqlServer.ObtenerDAORestriccionCinta();

            try
            {

                resultado = daoRestriccionCinta.ModificarRestriccionCinta(this.LaEntidad);
            
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (FormatException ex)
            {
                throw ex;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            return resultado;

        }
     
    }
}
