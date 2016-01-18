﻿using System;

using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DominioSKD;
using LogicaNegociosSKD.Modulo5;
using LogicaNegociosSKD.Modulo3;
using Interfaz_Contratos.Modulo5;
using Interfaz_Presentadores.Modulo5;

namespace templateApp.GUI.Modulo5
{
    public partial class M5_ListarCintas : System.Web.UI.Page, IContratoListarCintas
    {
      //  private LogicaNegociosSKD.Modulo5.LogicaCinta logica = new LogicaNegociosSKD.Modulo5.LogicaCinta();
//        List<DominioSKD.Cinta> lista;

        private PresentadorLlenarCintas presentador;

        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "5";

            
            if (!IsPostBack)
            {

                this.presentador = new PresentadorLlenarCintas(this);
                this.presentador.LlenarInformacion();
            }
           
        }

      

       #region IContratos
        public void llenarId(string id)
        {
            this.tabla.Text += RecursoInterfazMod5.AbrirTR;
            this.tabla.Text += RecursoInterfazMod5.AbrirTD + id + RecursoInterfazMod5.CerrarTD;
        }

        public void llenarColorNombre(string colorNombre)
        {
            this.tabla.Text += RecursoInterfazMod5.AbrirTD + colorNombre + RecursoInterfazMod5.CerrarTD;
        }

        public void llenarRango(string rango)
        {
            this.tabla.Text += RecursoInterfazMod5.AbrirTD + rango + RecursoInterfazMod5.CerrarTD;
        }
        public void llenarClasificacion(string clasificacion)
        {
            this.tabla.Text += RecursoInterfazMod5.AbrirTD + clasificacion + RecursoInterfazMod5.CerrarTD;
        }
        public void llenarSignificado(string significado)
        {
            this.tabla.Text += RecursoInterfazMod5.AbrirTD + significado + RecursoInterfazMod5.CerrarTD;
        }
        public void llenarOrden(int orden)
        {
            this.tabla.Text += RecursoInterfazMod5.AbrirTD + orden + RecursoInterfazMod5.CerrarTD;
        }
        public void llenarOrganizacion(string organizacion)
        {
            this.tabla.Text += RecursoInterfazMod5.AbrirTD + organizacion + RecursoInterfazMod5.CerrarTD;
        }

        public void llenarBotones(int id)
        {
            this.tabla.Text += RecursoInterfazMod5.AbrirTD;
            this.tabla.Text += RecursoInterfazMod5.BotonInfo + id + RecursoInterfazMod5.BotonCerrar;
            this.tabla.Text += RecursoInterfazMod5.BotonModificar + id + RecursoInterfazMod5.BotonCerrar;
        }

        public void llenarStatusActivo(int id)
        {
            this.tabla.Text += RecursoInterfazMod5.BotonActivarCin + id + RecursoInterfazMod5.BotonCerrar;
            this.tabla.Text += RecursoInterfazMod5.CerrarTD;
            this.tabla.Text += RecursoInterfazMod5.CerrarTR;
        }

        public void llenarStatusInactivo(int id)
        {
            this.tabla.Text += RecursoInterfazMod5.BotonDesactivarCin + id + RecursoInterfazMod5.BotonCerrar;
            this.tabla.Text += RecursoInterfazMod5.CerrarTD;
            this.tabla.Text += RecursoInterfazMod5.CerrarTR;
        }
        #endregion


    }
}