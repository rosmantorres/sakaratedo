﻿using DatosSKD.InterfazDAO.Modulo10;
using DominioSKD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegociosSKD.Comandos.Modulo10
{
    public class ComandoListaNoAsistentesEvento : Comando<List<Entidad>>
    {
        private string idEvento;

        public string IdEvento
        {
            get { return idEvento; }
            set { idEvento = value; }
        }
        public ComandoListaNoAsistentesEvento(string idEvento)
        {
            this.idEvento = idEvento;
        }
        public override List<Entidad> Ejecutar()
        {
            try
            {
                IDaoAsistencia daoAsistencia = DatosSKD.Fabrica.FabricaDAOSqlServer.ObtenerDAOAsistencia();
                List<Entidad> listaEntidad = daoAsistencia.ListaNoAsistentesEvento(idEvento);
                return listaEntidad;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
