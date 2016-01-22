﻿using DatosSKD.InterfazDAO.Modulo11;
using DominioSKD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegociosSKD.Comandos.Modulo11
{
    public class ComandoListaAtletasParticipanCompetenciaKataAmbos : Comando<List<Entidad>>
    {
        public ComandoListaAtletasParticipanCompetenciaKataAmbos(Entidad entidad)
        {
            this.LaEntidad = entidad;
        }
        public override List<Entidad> Ejecutar()
        {
            try
            {
                IDaoResultadoKata daoResultado = DatosSKD.Fabrica.FabricaDAOSqlServer.ObtenerDAOResultadoKata();
                List<Entidad> listaEntidad = daoResultado.ListaAtletasParticipanCompetenciaKataAmbos(this.LaEntidad);
                return listaEntidad;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
