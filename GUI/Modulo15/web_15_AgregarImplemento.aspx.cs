﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaNegociosSKD.Modulo15;
using DominioSKD;
using ExcepcionesSKD;
using ExcepcionesSKD.Modulo15;
using templateApp.GUI.Modulo1;
using templateApp.GUI.Master;
using System.Web.SessionState;
using DominioSKD.Fabrica;
using Interfaz_Contratos.Modulo15;
using Interfaz_Presentadores.Modulo15;

namespace templateApp.GUI.Modulo15
{
    public partial class web_15_AgregarImplemento : System.Web.UI.Page, IContratoAgregarImplemento
    {

        private PresentadorAgregarImplemento presentador;


           public web_15_AgregarImplemento()
        {
            presentador = new PresentadorAgregarImplemento(this);
        }


        protected void Page_Load(object sender, EventArgs e)
        {
             ((SKD)Page.Master).IdModulo = "15";
            //variables agregar

             Agregar.Click += new EventHandler(this.agregarImplemento);     
    
        }

        public void agregarImplemento(object sender,EventArgs e) {

            FabricaEntidades fabrica = new FabricaEntidades();
            Entidad implemento = fabrica.ObtenerImplemento();
            ((Implemento)implemento).Dojo_Implemento = (Dojo)fabrica.ObtenerDojo();
            ((Implemento)implemento).Nombre_Implemento = this.nombre_implemento.Value;
            ((Implemento)implemento).Tipo_Implemento = this.tipo_implemento.Value;
            ((Implemento)implemento).Marca_Implemento = this.marca_implemento.Value;
            ((Implemento)implemento).Color_Implemento = this.color_implemento.Value;
            ((Implemento)implemento).Talla_Implemento= this.talla_implemento.Value;
            ((Implemento)implemento).Dojo_Implemento.Id_dojo= 1;
            ((Implemento)implemento).Cantida_implemento= Convert.ToInt16(this.cantidad_implemento.Value);
            ((Implemento)implemento).Stock_Minimo_Implemento= Convert.ToInt16(this.stock_implemento.Value);
            ((Implemento)implemento).Descripcion_Implemento = this.descripcion_implemento.Value;
            ((Implemento)implemento).Precio_Implemento= Convert.ToDouble(this.precio_implemento.Value);
            ((Implemento)implemento).Imagen_implemento = "Hola mundo";
            presentador.agregarImplemento(implemento);
        
        
        }

        TextBox IContratoAgregarImplemento.nombre_implemento
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        DropDownList IContratoAgregarImplemento.tipo_implemento
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        TextBox IContratoAgregarImplemento.cantidad_implemento
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        TextBox IContratoAgregarImplemento.precio_implemento
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        DropDownList IContratoAgregarImplemento.color_implemento
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public DropDownList marca_implemeto
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        DropDownList IContratoAgregarImplemento.talla_implemento
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public TextBox stock_implemeto
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        TextBox IContratoAgregarImplemento.descripcion_implemento
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string imagen_implemeto
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}