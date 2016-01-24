﻿using DominioSKD;
using DominioSKD.Entidades.Modulo6;
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

namespace Interfaz_Presentadores.Modulo7
{
    /// <summary>
    /// Presentador para detallar matricula
    /// </summary>
    public class PresentadorDetallarMatricula
    {
        private FabricaComandos fabricaComandos;
        private IContratoDetallarMatricula vista;
        /// <summary>
        /// Constructor del presentador
        /// </summary>
        /// <param name="laVista">instancia de la ventana</param>
        public PresentadorDetallarMatricula(IContratoDetallarMatricula laVista)
        {
            vista = laVista;
        }

        /// <summary>
        /// Método para cargar los datos de la matricula
        /// </summary>
        /// <param name="idCinta">id de la matricula</param>
        public void cargarDatos(Matricula idMatricula)
        {           
            try
            {
               fabricaComandos = new FabricaComandos();
                ComandoConsultarDetallarMatricula comandoDetallarMatricula =(ComandoConsultarDetallarMatricula)fabricaComandos.ObtenerComandoConsultarDetallarMatricula();
                comandoDetallarMatricula.LaEntidad = idMatricula;
                Matricula matricula = (Matricula)comandoDetallarMatricula.Ejecutar();
                String estadoFinal;
                vista.identificadorMatricula = matricula.Identificador;
                vista.fechaCreacionMatricula = matricula.FechaCreacion.ToString("MM/dd/yyyy");
                vista.fechaPagoMatricula = matricula.UltimaFechaPago.ToString("MM/dd/yyyy");
                estadoFinal = matricula.Status.ToString();

                if (matricula.Status.Equals(true))
                {
                    estadoFinal = "Activa";
                }
                else
                {
                    estadoFinal = "No Activa";
                }
            }
            catch (NumeroEnteroInvalidoException)
            {
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
    M7_RecursosPresentador.Mensaje_Numero_Parametro_invalido, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            catch (FormatException)
            {
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
    M7_RecursosPresentador.Mensaje_Numero_Parametro_invalido, System.Reflection.MethodBase.GetCurrentMethod().Name);
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
