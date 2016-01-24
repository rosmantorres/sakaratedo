using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioSKD;
using DominioSKD.Entidades.Modulo15;
using DominioSKD.Fabrica;
using Interfaz_Contratos.Modulo15;
using Interfaz_Presentadores.Modulo15;
using System.Web.UI.HtmlControls;

namespace templateApp.GUI.Modulo15
{
    public partial class web_15_ModificarImplemento : System.Web.UI.Page, IContratoModificarImplemento
    {
        private PresentadorModificarImplemento presentador;

        public web_15_ModificarImplemento()
        {
            presentador = new PresentadorModificarImplemento(this);
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "15";
            //variables agregar

            if (this.id_implemento.Value == "")
            {
                Entidad implemento = presentador.precargarImplemento(Convert.ToInt32(Request.QueryString["idImplemento"]));
                this.id_implemento.Value = (((Implemento)implemento).Id_Implemento).ToString();
                this.nombre_implemento.Value = ((Implemento)implemento).Nombre_Implemento;
                this.tipo_implemento.Value = ((Implemento)implemento).Tipo_Implemento;
                this.marca_implemento.Value = ((Implemento)implemento).Marca_Implemento;
                this.color_implemento.Value = ((Implemento)implemento).Color_Implemento;
                this.talla_implemento.Value = ((Implemento)implemento).Talla_Implemento;
                this.cantidad_implemento.Value = (((Implemento)implemento).Cantida_implemento).ToString();
                this.stock_implemento.Value = (((Implemento)implemento).Stock_Minimo_Implemento).ToString();
                this.descripcion_implemento.Value = ((Implemento)implemento).Descripcion_Implemento;
                this.precio_implemento.Value = (((Implemento)implemento).Precio_Implemento).ToString();
                this.estatus_implemento.Value = ((Implemento)implemento).Estatus_Implemento;
                this.imagen_img.Src = "~/GUI/Modulo15/Imagen/"+((Implemento)implemento).Imagen_implemento;
                
                //this.imagen_implemento.Value = (HtmlInputFile)("~/GUI/Modulo15/imagen" + ((Implemento)implemento).Imagen_implemento);
            }
                Modificar.Click += new EventHandler(this.modificarImplemento);
            
           
        }
        void guardarImagen()
        {
            string TargetLocation;
            string imagen_implemento = null;
            TargetLocation = Server.MapPath("~/GUI/Modulo15/Imagen/");
            imagen_implemento = this.imagen_implemento.Value;
            this.imagen_implemento.PostedFile.SaveAs(TargetLocation + imagen_implemento);

        }
        public void modificarImplemento(object sender,EventArgs e) {

            Entidad implementoCargado = presentador.precargarImplemento(Convert.ToInt32(this.id_implemento.Value));

            if ((this.nombre_implemento.Value != "") && (this.tipo_implemento.Value != "") && (this.marca_implemento.Value != "") && (this.color_implemento.Value != "") && (this.talla_implemento.Value != "") && (this.cantidad_implemento.Value != "") && (this.stock_implemento.Value != "") && (this.descripcion_implemento.Value != "") && (this.precio_implemento.Value != ""))
            {

                Entidad implemento = FabricaEntidades.ObtenerImplemento();
                ((Implemento)implemento).Id_Implemento = Convert.ToInt16(this.id_implemento.Value);
                ((Implemento)implemento).Dojo_Implemento = (Dojo)FabricaEntidades.tenerDojo();
                ((Implemento)implemento).Nombre_Implemento = this.nombre_implemento.Value;
                ((Implemento)implemento).Tipo_Implemento = this.tipo_implemento.Value;
                ((Implemento)implemento).Marca_Implemento = this.marca_implemento.Value;
                ((Implemento)implemento).Color_Implemento = this.color_implemento.Value;
                ((Implemento)implemento).Talla_Implemento = this.talla_implemento.Value;
                ((Dojo)(((Implemento)implemento).Dojo_Implemento)).Id_dojo = 1;
                ((Implemento)implemento).Cantida_implemento = Convert.ToInt16(this.cantidad_implemento.Value);
                ((Implemento)implemento).Stock_Minimo_Implemento = Convert.ToInt16(this.stock_implemento.Value);
                ((Implemento)implemento).Descripcion_Implemento = this.descripcion_implemento.Value;
                ((Implemento)implemento).Precio_Implemento = Convert.ToDouble(this.precio_implemento.Value);
                if (this.imagen_implemento.Value == "")
                {
                    ((Implemento)implemento).Imagen_implemento = ((Implemento)implementoCargado).Imagen_implemento;
                }
                else {
                    ((Implemento)implemento).Imagen_implemento = this.imagen_implemento.Value;
                    guardarImagen();
                }
                ((Implemento)implemento).Estatus_Implemento = this.estatus_implemento.Value;
                presentador.modificarImplemento(implemento);
                Response.Redirect("web_15_ConsultarImplemento.aspx");

            }
        }

        TextBox IContratoModificarImplemento.nombre_implemento
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

        DropDownList IContratoModificarImplemento.tipo_implemento
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

        TextBox IContratoModificarImplemento.cantidad_implemento
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

        TextBox IContratoModificarImplemento.precio_implemento
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

        DropDownList IContratoModificarImplemento.color_implemento
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

        DropDownList IContratoModificarImplemento.talla_implemento
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

        TextBox IContratoModificarImplemento.descripcion_implemento
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