﻿using DominioSKD;
using DominioSKD.Fabrica;
using ExcepcionesSKD;
using ExcepcionesSKD.Modulo7;
using Interfaz_Contratos.Modulo7;
using LogicaNegociosSKD;
using LogicaNegociosSKD.Comandos.Modulo7;
using LogicaNegociosSKD.Fabrica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD.Entidades.Modulo7;

namespace Interfaz_Presentadores.Modulo7
{
    /// <summary>
    /// Presentador para detallar cinta
    /// </summary>
    public class PresentadorDetallarCinta
    {
        private IContratoDetallarCinta vista;
        /// <summary>
        /// Constructor del presentador
        /// </summary>
        /// <param name="laVista">instancia de la ventana</param>
        public PresentadorDetallarCinta(IContratoDetallarCinta laVista)
        {
            vista = laVista;
        }


        /// <summary>
        /// Método para cargar los datos de la cinta
        /// </summary>
        /// <param name="idCinta">id de la cinta</param>
        /// <param name="idPersona">id de la persona</param>
        public void CargarDatos(Entidad idCinta, Entidad idPersona)
        {           
            try
            {
                ComandoConsultarDetallarCinta comandoDetallarCinta =(ComandoConsultarDetallarCinta)FabricaComandos.ObtenerComandoConsultarDetallarCinta();
                comandoDetallarCinta.LaEntidad = idCinta;
                comandoDetallarCinta.IdPersona = (PersonaM7)idPersona;
                Tuple<Entidad, DateTime> tupla = comandoDetallarCinta.Ejecutar();
                CintaM7 cinta = (CintaM7)tupla.Item1;
                DateTime fechaObtencionCinta = tupla.Item2;
                
                vista.clasificacionCinta = cinta.Clasificacion;
                vista.colorCinta = cinta.Color_nombre;
                vista.fechaObtencionCinta = fechaObtencionCinta.ToString(M7_RecursosPresentador.FormatoFecha);
                vista.ordenCinta = cinta.Orden.ToString();
                vista.rangoCinta = cinta.Rango;
                vista.significadoCinta = cinta.Significado;
                
            }
            catch (NumeroEnteroInvalidoException)
            {
            }
            catch (FormatException)
            {
            }
            catch (NullReferenceException)
            {               
            }
            catch (Exception)
            {               
            }
        }
    }
}
