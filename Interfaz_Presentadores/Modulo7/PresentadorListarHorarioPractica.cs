﻿using DominioSKD;
using DominioSKD.Entidades.Modulo7;
using DominioSKD.Fabrica;
using ExcepcionesSKD;
using ExcepcionesSKD.Modulo7;
using Interfaz_Contratos.Modulo7;
using LogicaNegociosSKD;
using LogicaNegociosSKD.Fabrica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaz_Presentadores.Modulo7
{
    /// <summary>
    /// Presentador para listar horario de practica
    /// </summary>
    public class PresentadorListarHorarioPractica
    {
         private IContratoListarHorarioPractica vista;

        /// <summary>
        /// Constructor del presentador
        /// </summary>
        /// <param name="laVista">instancia de la vista</param>
         public PresentadorListarHorarioPractica(IContratoListarHorarioPractica laVista)
        {
            vista = laVista;
        }

        /// <summary>
        /// Método para consultar los horarios de practica del atleta
        /// </summary>
        public void ConsultarHorarioPractica(Entidad idPersona)
        {
            try
            {
                Comando<Tuple<List<Entidad>>> comandoListaHorarioPractica = 
                    FabricaComandos.ObtenerComandoConsultarListaHorarioPractica();

                comandoListaHorarioPractica.LaEntidad = idPersona;
                Tuple<List<Entidad>> tupla = comandoListaHorarioPractica.Ejecutar();

                List<Entidad> listaEvento = tupla.Item1;

                using (var e1 = listaEvento.GetEnumerator())
                {
                    while (e1.MoveNext())
                    {
                        EventoM7 evento = (EventoM7)e1.Current;
                        vista.laTabla += M7_RecursosPresentador.AbrirTR;
                        vista.laTabla += M7_RecursosPresentador.AbrirTD + evento.Nombre.ToString() + M7_RecursosPresentador.CerrarTD;
                        vista.laTabla += M7_RecursosPresentador.AbrirTD + evento.Horario.HoraInicio.ToString() + M7_RecursosPresentador.CerrarTD;
                        vista.laTabla += M7_RecursosPresentador.AbrirTD + evento.Horario.HoraFin.ToString() + M7_RecursosPresentador.CerrarTD;
                        vista.laTabla += M7_RecursosPresentador.AbrirTD + evento.Ubicacion.Ciudad.ToString() + M7_RecursosPresentador.CerrarTD;
                        vista.laTabla += M7_RecursosPresentador.AbrirTD;
                        vista.laTabla += M7_RecursosPresentador.BotonInfoHorariodePractica + evento.Id + M7_RecursosPresentador.BotonCerrar;
                        vista.laTabla += M7_RecursosPresentador.CerrarTD;
                        vista.laTabla += M7_RecursosPresentador.CerrarTR;
                    }
                }

            }
            catch (NumeroEnteroInvalidoException)
            {

            }
            catch (FormatException)
            {

            }
            catch (Exception)
            {

            }
        }
    }
}
