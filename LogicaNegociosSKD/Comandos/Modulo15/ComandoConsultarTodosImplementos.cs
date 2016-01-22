﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSKD.Fabrica;
using DominioSKD;
using DatosSKD.InterfazDAO.Modulo15;
namespace LogicaNegociosSKD.Comandos.Modulo15
{
    public class ComandoConsultarTodosImplementos : Comando<List<Entidad>>
    {

        public override List<Entidad> Ejecutar()
        {
            List<Entidad> lista=new List<Entidad>();
            try
            {
                lista = FabricaDAOSqlServer.ObtenerDAOImplemento().listarInventarioDatos(this.LaEntidad);

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return lista;
        }
    }
}