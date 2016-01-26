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
            FabricaComandos fabricaCo = new FabricaComandos();
            Comando<List<Entidad>> comboCinta = fabricaCo.CrearComandoConsultarCintaTodas();
            List<Entidad> listCinta = new List<Entidad>();
            Dictionary<string, string> options = new Dictionary<string, string>();
            options.Add("-1", "Selecciona una opcion");
            try
            {
                listCinta = comboCinta.Ejecutar();
                foreach (DominioSKD.Entidades.Modulo5.Cinta item in listCinta)
                {
                    options.Add(item.Id_cinta.ToString(), item.Color_nombre);
                }
                options.Add("-2", "OTRO");
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
            vista.rangoMaximo.DataTextField = "value";
            vista.rangoMaximo.DataValueField = "key";
            vista.rangoMaximo.DataBind();

        }

        public void LlenarComboEvento()
        {
            FabricaComandos fabricaCo = new FabricaComandos();
            Comando<List<Entidad>> comboEve = fabricaCo.CrearComandoConsultarEventosSinRestriccion();
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
            vista.eventos.DataSource = options;
            vista.eventos.DataTextField = "value";
            vista.eventos.DataValueField = "key";
            vista.eventos.DataBind();

        }

        public void LlenarComboSexo()
        {
            vista.sexo.Enabled = true;
            Dictionary<string, string> optionsSexo = new Dictionary<string, string>();
            optionsSexo.Add("Masculino", "M");
            optionsSexo.Add("Femenino", "F");
            optionsSexo.Add("Ambos Sexos", "B");
            vista.sexo.DataSource = optionsSexo;
            vista.sexo.DataTextField = "key";
            vista.sexo.DataValueField = "value";
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
            vista.edadMinima.DataTextField = "key";
            vista.edadMinima.DataValueField = "value";
            vista.edadMaxima.DataTextField = "key";
            vista.edadMaxima.DataValueField = "value";
            vista.edadMinima.DataBind();
            vista.edadMaxima.DataBind();
        }

        public void agregarRest()
        {
            try
            {
            DominioSKD.Entidades.Modulo8.RestriccionEvento laRestEvento = new DominioSKD.Entidades.Modulo8.RestriccionEvento();

            laRestEvento.Descripcion = this.vista.rangoMaximo.SelectedItem.ToString();
            laRestEvento.IdEvento = Int32.Parse(this.vista.eventos.SelectedValue);
            laRestEvento.EdadMinima = Int32.Parse(this.vista.edadMinima.SelectedValue);
            laRestEvento.EdadMaxima = Int32.Parse(this.vista.edadMaxima.SelectedValue);
            laRestEvento.Sexo = this.vista.sexo.SelectedValue.ToString();


            FabricaComandos _fabrica = new FabricaComandos();
            Comando<bool> _comando = _fabrica.CrearComandoAgregarRestriccionEvento(laRestEvento);
            bool resultado = _comando.Ejecutar();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (FormatException ex)
            {
                throw ex;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}