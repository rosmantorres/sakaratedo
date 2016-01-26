﻿using DominioSKD;
using DominioSKD.Fabrica;
using ExcepcionesSKD;
using Interfaz_Contratos.Modulo8;
using LogicaNegociosSKD;
using LogicaNegociosSKD.Comandos.Modulo8;
using LogicaNegociosSKD.Fabrica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Interfaz_Presentadores.Modulo8
{
    public class PresentadorConsultarRestriccionesEvento
    {
        private IContratoConsultarRestriccionEvento vista;
        List<Entidad> lista;

        public PresentadorConsultarRestriccionesEvento(IContratoConsultarRestriccionEvento vista)
        {
            this.vista = vista;
        }

        public void Alerta(string msj)
        {
            vista.alertaClase = "alert alert-danger alert-dismissible";
            vista.alertaRol = "alert";
            vista.alert = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" + msj + "</div>";
        }

        public void LlenarInformacion(List<Entidad> lista)
        {
            try
            {
                this.lista = lista;
                foreach (DominioSKD.Entidades.Modulo8.RestriccionEvento rest in lista)
                {
                    vista.RestriccionesCreadas += RecursoPresentadorM8.AbrirTR;
                    vista.RestriccionesCreadas += RecursoPresentadorM8.AbrirTD + rest.IdRestEvento.ToString() + RecursoPresentadorM8.CerrarTD;
                    vista.RestriccionesCreadas += RecursoPresentadorM8.AbrirTD + rest.IdEvento.ToString() + RecursoPresentadorM8.CerrarTD;
                    vista.RestriccionesCreadas += RecursoPresentadorM8.AbrirTD + rest.NombreEvento.ToString() + RecursoPresentadorM8.CerrarTD;
                    vista.RestriccionesCreadas += RecursoPresentadorM8.AbrirTD + rest.EdadMinima.ToString() + RecursoPresentadorM8.CerrarTD;
                    vista.RestriccionesCreadas += RecursoPresentadorM8.AbrirTD + rest.EdadMaxima.ToString() + RecursoPresentadorM8.CerrarTD;
                    vista.RestriccionesCreadas += RecursoPresentadorM8.AbrirTD + rest.Descripcion.ToString() + RecursoPresentadorM8.CerrarTD;
                    vista.RestriccionesCreadas += RecursoPresentadorM8.AbrirTD + rest.Sexo.ToString() + RecursoPresentadorM8.CerrarTD;
                    /*vista.RestriccionesCreadas += RecursoPresentadorM8.AbrirTD;
                    foreach (string dat in plani.Dato)
                    {
                        vista.RestriccionesCreadas += dat + RecursoPresentadorM8.linea;
                    }
                    vista.RestriccionesCreadas += RecursoPresentadorM8.CerrarTD;*/
                    vista.RestriccionesCreadas += RecursoPresentadorM8.AbrirTD;
                    //vista.RestriccionesCreadas += RecursoPresentadorM8.BotonModificar + rest.Id + RecursoPresentadorM8.Nombre + plani.Nombre + RecursoPresentadorM8.Tipo + plani.TipoPlanilla + RecursoPresentadorM8.BotonCerrar;
                    vista.RestriccionesCreadas += RecursoPresentadorM8.BotonModificarRegistroEvento + rest.IdRestEvento + RecursoPresentadorM8.BotonCerrar;
                    /*if (plani.Status)
                        vista.RestriccionesCreadas += RecursoPresentadorM8.BotonActivarPlanilla + plani.ID + RecursoPresentadorM8.BotonCerrar;
                    else*/
                    vista.RestriccionesCreadas += RecursoPresentadorM8.BotonDesactivarPlanilla + rest.Id + RecursoPresentadorM8.BotonCerrar;
                    vista.RestriccionesCreadas += RecursoPresentadorM8.CerrarTD;
                    vista.RestriccionesCreadas += RecursoPresentadorM8.CerrarTR;

                }
            }
            catch (NullReferenceException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
        }

        public List<Entidad> LlenarTabla()
        {
            try
            {
                Comando<List<Entidad>> command = FabricaComandos.CrearComandoConsultarRestriccionEvento();
                return command.Ejecutar();
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (ExcepcionesSKD.Modulo14.BDDiseñoException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (ExcepcionesSKD.Modulo14.BDDatosException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (ExcepcionesSKD.Modulo14.BDPLanillaException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (ExcepcionesSKD.Modulo14.BDSolicitudException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
        }
    }
}