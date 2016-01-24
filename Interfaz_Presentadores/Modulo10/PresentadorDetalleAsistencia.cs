using DominioSKD;
using Interfaz_Contratos.Modulo10;
using LogicaNegociosSKD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaz_Presentadores.Modulo10
{
    public class PresentadorDetalleAsistencia
    {
        IContratoDetalleAsistencia vista;
        public PresentadorDetalleAsistencia(IContratoDetalleAsistencia vista)
        {
            this.vista = vista;
        }

        public void CargarVentanaDetalle(string idEvento, string tipo)
        {
            if (tipo.Equals(M10_RecursosPresentador.Evento))
            {
                Comando<Entidad> comando = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoConsultarEventoM10XId(idEvento);
                Entidad evento = comando.Ejecutar();
                vista.Fecha.Text = ((DominioSKD.Entidades.Modulo10.Evento)evento).Horario.FechaInicio.ToShortDateString();
                vista.Nombre.Text = ((DominioSKD.Entidades.Modulo10.Evento)evento).Nombre;
                Comando<List<Entidad>> comandoListaA = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoListaAsistentesEvento(idEvento);
                List<Entidad> listaA = comandoListaA.Ejecutar();
                Comando<List<Entidad>> comandoListaI = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoListaNoAsistentesEvento(idEvento);
                List<Entidad> listaI = comandoListaI.Ejecutar();

                foreach (Entidad persona in listaA)
                {
                    vista.Asistieron.Items.Add(((DominioSKD.Entidades.Modulo10.Persona)persona).Nombre);
                }

                foreach (Entidad persona in listaI)
                {
                    vista.NoAsistieron.Items.Add(((DominioSKD.Entidades.Modulo10.Persona)persona).Nombre);
                }
            }
            else if (tipo.Equals(M10_RecursosPresentador.Competencia))
            {
                Comando<Entidad> comando = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoConsultarCompetenciasXId(idEvento);
                Entidad competencia = comando.Ejecutar();
                vista.Fecha.Text = ((DominioSKD.Entidades.Modulo12.Competencia)competencia).FechaInicio.ToShortDateString();
                vista.Nombre.Text = ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Nombre;
                Comando<List<Entidad>> comandoListaAC = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoListaAsistentesCompetencia(idEvento);
                List<Entidad> listaAC = comandoListaAC.Ejecutar();
                Comando<List<Entidad>> comandoListaIC = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoListaNoAsistentesCompetencia(idEvento);
                List<Entidad> listaIC = comandoListaIC.Ejecutar();

                foreach (Entidad persona in listaAC)
                {
                    vista.Asistieron.Items.Add(((DominioSKD.Entidades.Modulo10.Persona)persona).Nombre);
                }

                foreach (Entidad persona in listaIC)
                {
                    vista.NoAsistieron.Items.Add(((DominioSKD.Entidades.Modulo10.Persona)persona).Nombre);
                }
            }
        }
    }
}
