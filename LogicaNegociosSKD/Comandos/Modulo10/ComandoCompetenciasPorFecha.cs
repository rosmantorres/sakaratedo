using DatosSKD.InterfazDAO.Modulo10;
using DominioSKD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegociosSKD.Comandos.Modulo10
{
    public class ComandoCompetenciasPorFecha : Comando<List<Entidad>>
    {
        private string fechaInicio;

        public string FechaInicio
        {
            get { return fechaInicio; }
            set { fechaInicio = value; }
        }

        public ComandoCompetenciasPorFecha(string fechaInicio)
        {
            this.fechaInicio = fechaInicio;
        }
        public override List<Entidad> Ejecutar()
        {
            try
            {
                IDaoAsistencia daoAsistencia = DatosSKD.Fabrica.FabricaDAOSqlServer.ObtenerDAOAsistencia();
                List<Entidad> listaEntidad = daoAsistencia.CompetenciasPorFecha(fechaInicio);
                return listaEntidad;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
