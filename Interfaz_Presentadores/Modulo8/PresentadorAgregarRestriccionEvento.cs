﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using DominioSKD.Fabrica;
using ExcepcionesSKD;
using Interfaz_Contratos.Modulo8;
using LogicaNegociosSKD.Comandos.Modulo8;
using LogicaNegociosSKD.Fabrica;
using LogicaNegociosSKD;
using DominioSKD;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace Interfaz_Presentadores.Modulo8
{
    public class PresentadorAgregarRestriccionEvento
    {
        private IContratoAgregarRestriccionEvento vista;

        public PresentadorAgregarRestriccionEvento(IContratoAgregarRestriccionEvento laVista)
        {
          
            this.vista = laVista;
            
        }

        public DominioSKD.Entidades.Modulo8.RestriccionEvento meterParametrosVistaEnObjeto1(DominioSKD.Entidades.Modulo8.RestriccionEvento laRestriccion)
        {
            DominioSKD.Entidades.Modulo8.RestriccionEvento retriccionEvento = laRestriccion;
            retriccionEvento.EdadMinima = int.Parse(vista.edadMinima.SelectedValue);
            retriccionEvento.EdadMaxima = int.Parse(vista.edadMaxima.SelectedValue);
            retriccionEvento.Sexo = vista.sexo.ToString();

            //generarDescripcion();
            return retriccionEvento;

        }

        public void LlenarComboCinta()
        {
            LogicaNegociosSKD.Comandos.Modulo8.ComandoConsultarCintaTodas comboCinta =
                   (LogicaNegociosSKD.Comandos.Modulo8.ComandoConsultarCintaTodas)LogicaNegociosSKD.Fabrica.FabricaComandos.CrearComandoConsultarCintaTodas();
            List<Entidad> listCinta = new List<Entidad>();
            Dictionary<string, string> options = new Dictionary<string, string>();
            try
            {
                listCinta = comboCinta.Ejecutar();
                foreach (DominioSKD.Entidades.Modulo5.Cinta item in listCinta)
                {
                    options.Add(item.Id_cinta.ToString(), item.Color_nombre);
                }
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
            vista.rangoMaximo.DataSource = options;
            vista.rangoMaximo.DataTextField = RecursoPresentadorM8.value;
            vista.rangoMaximo.DataValueField = RecursoPresentadorM8.key;
            vista.rangoMaximo.DataBind();

        }

        public void LlenarComboEvento()
        {
            LogicaNegociosSKD.Comandos.Modulo8.ComandoConsultarEventosSinRestriccion comboEve =
                   (LogicaNegociosSKD.Comandos.Modulo8.ComandoConsultarEventosSinRestriccion)LogicaNegociosSKD.Fabrica.FabricaComandos.CrearComandoConsultarEventosSinRestriccion();
            List<Entidad> listEve = new List<Entidad>();
            Dictionary<string, string> options = new Dictionary<string, string>();
            try
            {
                listEve = comboEve.Ejecutar();
                foreach (DominioSKD.Entidades.Modulo8.EventoSimple item in listEve)
                {
                    options.Add(item.IdEvento.ToString(), item.NombreEvento);
                }
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                Alerta(ex.Message);
                
            }
            catch (ExcepcionesSKD.Modulo14.BDDiseñoException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                Alerta(ex.Message);
            }
            catch (ExcepcionesSKD.Modulo14.BDDatosException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                Alerta(ex.Message);
            }
            catch (ExcepcionesSKD.Modulo14.BDPLanillaException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                Alerta(ex.Message);
            }
            catch (ExcepcionesSKD.Modulo14.BDSolicitudException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                Alerta(ex.Message);
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                Alerta(ex.Message);
            }
            vista.eventos.DataSource = options;
            vista.eventos.DataTextField = RecursoPresentadorM8.value;
            vista.eventos.DataValueField = RecursoPresentadorM8.key;
            vista.eventos.DataBind();

        }

        public void LlenarComboSexo()
        {
            vista.sexo.Enabled = true;
            Dictionary<string, string> optionsSexo = new Dictionary<string, string>();
            optionsSexo.Add(RecursoPresentadorM8.Masculino, RecursoPresentadorM8.M);
            optionsSexo.Add(RecursoPresentadorM8.Femenino, RecursoPresentadorM8.F);
            optionsSexo.Add(RecursoPresentadorM8.AmbosSexos, RecursoPresentadorM8.B);
            vista.sexo.DataSource = optionsSexo;
            vista.sexo.DataTextField = RecursoPresentadorM8.key;
            vista.sexo.DataValueField = RecursoPresentadorM8.value;
            vista.sexo.DataBind();
        }

        public void LlenarComboEdades()
        {
            int index;
            vista.edadMinima.Enabled = true;
            vista.edadMaxima.Enabled = true;
            Dictionary<string, int> optionsEdad = new Dictionary<string, int>();

            for (index = 4; index <= 65; index++)
            {
                optionsEdad.Add(index.ToString(), index);
            }

            vista.edadMinima.DataSource = optionsEdad;
            vista.edadMaxima.DataSource = optionsEdad;
            vista.edadMinima.DataTextField = RecursoPresentadorM8.key;
            vista.edadMinima.DataValueField = RecursoPresentadorM8.value;
            vista.edadMaxima.DataTextField = RecursoPresentadorM8.key;
            vista.edadMaxima.DataValueField = RecursoPresentadorM8.value;
            vista.edadMinima.DataBind();
            vista.edadMaxima.DataBind();
        }

        public String nombreEvento()
        {
            return this.vista.eventos.SelectedItem.ToString();
        }

        public Boolean agregarRest()
        {
            
            DominioSKD.Entidades.Modulo8.RestriccionEvento laRestEvento = new DominioSKD.Entidades.Modulo8.RestriccionEvento();

            laRestEvento.Descripcion = this.vista.rangoMaximo.SelectedItem.ToString();
            laRestEvento.IdEvento = Int32.Parse(this.vista.eventos.SelectedValue);
            laRestEvento.EdadMinima = Int32.Parse(this.vista.edadMinima.SelectedValue);
            laRestEvento.EdadMaxima = Int32.Parse(this.vista.edadMaxima.SelectedValue);
            laRestEvento.Sexo = this.vista.sexo.SelectedValue.ToString();

            if (laRestEvento.EdadMaxima >= laRestEvento.EdadMinima)
            {
                try
                {
                    LogicaNegociosSKD.Comandos.Modulo8.ComandoAgregarRestriccionEvento _comando =
                        (LogicaNegociosSKD.Comandos.Modulo8.ComandoAgregarRestriccionEvento)LogicaNegociosSKD.Fabrica.FabricaComandos.CrearComandoAgregarRestriccionEvento(laRestEvento);
                    bool resultado = _comando.Ejecutar();
                }
                catch (ExcepcionesSKD.ExceptionSKD ex)
                {
                    vista.alertaClase = RecursoPresentadorM8.alertaError;
                    vista.alertaRol = RecursoPresentadorM8.tipoAlerta;
                    vista.alerta = RecursoPresentadorM8.alertaHtml + ex.Mensaje
                        + RecursoPresentadorM8.alertaHtmlFinal;
                    return false;
                }
                return true;
            }
            else
            {
                vista.alertaClase = RecursoPresentadorM8.alertaError;
                vista.alertaRol = RecursoPresentadorM8.tipoAlerta;
                vista.alerta = RecursoPresentadorM8.alertaHtml
                    + RecursoPresentadorM8.edadErrada
                    + RecursoPresentadorM8.alertaHtmlFinal;
                return false;
            }
        }

        public void Alerta(string msj)
        {
            vista.alertaClase = "alert alert-danger alert-dismissible";
            vista.alertaRol = "alert";
            vista.alerta = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" + msj + "</div>";
        }

    }
}
