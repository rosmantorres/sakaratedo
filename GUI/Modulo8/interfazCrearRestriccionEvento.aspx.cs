﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Interfaz_Contratos;
using Interfaz_Presentadores;

namespace templateApp.GUI.Modulo8
{
    public partial class interfazCrearRestriccionEvento : System.Web.UI.Page, Interfaz_Contratos.Modulo8.IContratoAgregarRestriccionCompetencia
    {
        //Declaramos el presentador de esta vista
        private Interfaz_Presentadores.Modulo8.PresentadorAgregarRestriccionCompetencia presentador;


        public String id { get; set; }
        public String descripcion { get; set; }
        //ListBox competenciasRelacionadas { get; set; }
        //ListBox competeciasNoRelacionadas { get; set; }
        public DropDownList rangoMinimo 
        { 
            get 
            {
                 return this.comboRangoMinimo;   
            } 
            
            set
            {
                this.comboRangoMinimo = value;
            }

        }
        public DropDownList rangoMaximo
        {
            get
            {
                return this.comboRangoMaximo;
            }

            set
            {
                this.comboRangoMaximo = value;
            }

        }
        public DropDownList edadMinima
        {
            get
            {
                return this.comboEdadMinima;
            }

            set
            {
                this.comboEdadMinima = value;
            }

        }
        public DropDownList edadMaxima
        {
            get
            {
                return this.comboEdadMaxima;
            }

            set
            {
                this.comboEdadMaxima = value;
            }

        }
            
        public DropDownList sexo
        {
            get
            {
                return this.comboSexo;
            }

            set
            {
                this.comboSexo = value;
            }

        }

        public DropDownList modalidad
        {
            get
            {
                return this.comboModalidad;
            }

            set
            {
                this.comboModalidad = value;
            }

        }
        //public String alert { set; }
        //public String alertClase { set; }
        //public String alertRol { set; }
        
        
        
        protected void Page_Load(object sender, EventArgs e)
        {
            presentador = new Interfaz_Presentadores.Modulo8.PresentadorAgregarRestriccionCompetencia(this);
            presentador.LlenarComboEdades();
            presentador.LlenarComboModalidad();
            presentador.LlenarComboRangos();
            presentador.LlenarComboSexo();
        }
    }
}