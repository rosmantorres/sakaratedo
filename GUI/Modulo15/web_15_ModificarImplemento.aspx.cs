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
            try
            {
                if (this.id_implemento.Value == "")
                {
                    Entidad implemento = presentador.precargarImplemento(Convert.ToInt32(Request.QueryString["idImplemento"]));
                    this.id_implemento.Value = (((Implemento)implemento).Id_Implemento).ToString();
                    this.nombre_implemento.Value = ((Implemento)implemento).Nombre_Implemento;
                    
                    if ((((Implemento)implemento).Tipo_Implemento != "Vestimenta") && (((Implemento)implemento).Tipo_Implemento != "Accesorios"))
                    {
                        this.tipo_implemento.Value = "otros";
                        this.tipo_implemento_div.Visible = true;
                        this.tipo_implemento_div.Value = ((Implemento)implemento).Tipo_Implemento;

                    }
                    else {
                        this.tipo_implemento_div.Attributes.Add("style", "DISPLAY: none");
                        this.tipo_implemento.Value = ((Implemento)implemento).Tipo_Implemento;
                    
                    }

                    if ((((Implemento)implemento).Marca_Implemento != "ADIDAS") && (((Implemento)implemento).Marca_Implemento != "ARENA") && (((Implemento)implemento).Marca_Implemento != "PUMA") && (((Implemento)implemento).Marca_Implemento != "NIKE") && (((Implemento)implemento).Marca_Implemento != "KOMBA") && (((Implemento)implemento).Marca_Implemento != "RS21"))
                    {
                        this.marca_implemento.Value = "otros";
                        this.marca_implemento_div.Visible = true;
                        this.marca_implemento_div.Value = ((Implemento)implemento).Marca_Implemento;

                    }
                    else
                    {
                        this.marca_implemento_div.Attributes.Add("style", "DISPLAY: none");
                        this.marca_implemento.Value = ((Implemento)implemento).Marca_Implemento;

                    }
                    if ((((Implemento)implemento).Talla_Implemento != "XS") && (((Implemento)implemento).Talla_Implemento != "S") && (((Implemento)implemento).Talla_Implemento != "M") && (((Implemento)implemento).Talla_Implemento != "L") && (((Implemento)implemento).Talla_Implemento != "XL"))
                    {
                        this.talla_implemento.Value = "otros";
                        this.talla_implemento_div.Visible = true;
                        this.talla_implemento_div.Value = ((Implemento)implemento).Talla_Implemento;

                    }
                    else
                    {
                        this.talla_implemento_div.Attributes.Add("style", "DISPLAY: none");
                        this.talla_implemento.Value = ((Implemento)implemento).Talla_Implemento;

                    }
                    if ((((Implemento)implemento).Color_Implemento != "AZUL") && (((Implemento)implemento).Color_Implemento != "VERDE") && (((Implemento)implemento).Color_Implemento != "AMARILLO") && (((Implemento)implemento).Color_Implemento != "ROJO") && (((Implemento)implemento).Color_Implemento != "NEGRO") && (((Implemento)implemento).Color_Implemento != "ROSADO"))
                    {
                        this.color_implemento.Value = "otros";
                        this.color_impolemento_div.Visible = true;
                        this.color_impolemento_div.Value = ((Implemento)implemento).Color_Implemento;

                    }
                    else
                    {
                        this.color_impolemento_div.Attributes.Add("style", "DISPLAY: none");
                        this.color_implemento.Value = ((Implemento)implemento).Color_Implemento;

                    }

                    this.cantidad_implemento.Value = (((Implemento)implemento).Cantida_implemento).ToString();
                    this.stock_implemento.Value = (((Implemento)implemento).Stock_Minimo_Implemento).ToString();
                    this.descripcion_implemento.Value = ((Implemento)implemento).Descripcion_Implemento;
                    this.precio_implemento.Value = (((Implemento)implemento).Precio_Implemento).ToString();
                    this.estatus_implemento.Value = ((Implemento)implemento).Estatus_Implemento;
                    this.imagen_img.Src =((Implemento)implemento).Imagen_implemento;

                    //this.imagen_implemento.Value = (HtmlInputFile)("~/GUI/Modulo15/imagen" + ((Implemento)implemento).Imagen_implemento);
                }
                Modificar.Click += new EventHandler(this.modificarImplemento);
            }
            catch (ExcepcionesSKD.Modulo15.ExcepcionPresentador.ExcepcionPresentadorModificarImplemento ex)
            {

                this.alert.Attributes["class"] = "alert alert-error alert-dismissible";
                this.alert.Attributes["role"] = "alert";
                this.alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" + ex.Data + "</div>";

            }
            catch (Exception ex) {

                this.alert.Attributes["class"] = "alert alert-error alert-dismissible";
                this.alert.Attributes["role"] = "alert";
                this.alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Problema Cargando los Datos en los Campos</div>";
                       
            
            }
           
        }
        void guardarImagen()
        {
            string TargetLocation;
            string imagen_implemento = null;
            TargetLocation = Server.MapPath("~/GUI/Modulo15/Imagenes/");
            imagen_implemento = this.imagen_implemento.Value;
            this.imagen_implemento.PostedFile.SaveAs(TargetLocation + imagen_implemento);

        }
        public void modificarImplemento(object sender,EventArgs e) {
            try
            {
                /// <summary>
                /// Método que modifica los datos de un implemento
                /// </summary>
                Entidad implementoCargado = presentador.precargarImplemento(Convert.ToInt32(this.id_implemento.Value));

                if ((this.nombre_implemento.Value != "") && (this.tipo_implemento.Value != "") && (this.marca_implemento.Value != "") && (this.color_implemento.Value != "") && (this.talla_implemento.Value != "") && (this.cantidad_implemento.Value != "") && (this.stock_implemento.Value != "") && (this.descripcion_implemento.Value != "") && (this.precio_implemento.Value != ""))
                {

                    Entidad implemento = FabricaEntidades.ObtenerImplemento();
                    ((Implemento)implemento).Id_Implemento = Convert.ToInt32(this.id_implemento.Value);
                    ((Implemento)implemento).Dojo_Implemento = (Dojo)FabricaEntidades.tenerDojo();
                    ((Implemento)implemento).Nombre_Implemento = this.nombre_implemento.Value;
                    if (this.tipo_implemento.Value == "otros")
                    {
                        ((Implemento)implemento).Tipo_Implemento = this.tipo_implemento_div.Value;

                    }
                    else {
                        ((Implemento)implemento).Tipo_Implemento = this.tipo_implemento.Value;

                    }
                    if (this.marca_implemento.Value == "otros")
                    {
                        ((Implemento)implemento).Marca_Implemento = this.marca_implemento_div.Value;

                    }
                    else
                    {
                        ((Implemento)implemento).Marca_Implemento = this.marca_implemento.Value;

                    }
                    if (this.color_implemento.Value == "otros")
                    {
                        ((Implemento)implemento).Color_Implemento = this.color_impolemento_div.Value;

                    }
                    else
                    {
                        ((Implemento)implemento).Color_Implemento = this.color_implemento.Value;

                    }
                    if (this.talla_implemento.Value == "otros")
                    {
                        ((Implemento)implemento).Talla_Implemento = this.talla_implemento_div.Value;

                    }
                    else
                    {
                        ((Implemento)implemento).Talla_Implemento = this.talla_implemento.Value;

                    }
                    ((Dojo)(((Implemento)implemento).Dojo_Implemento)).Id_dojo = 1;
                    ((Implemento)implemento).Cantida_implemento = Convert.ToInt32(this.cantidad_implemento.Value);
                    ((Implemento)implemento).Stock_Minimo_Implemento = Convert.ToInt32(this.stock_implemento.Value);
                    ((Implemento)implemento).Descripcion_Implemento = this.descripcion_implemento.Value;
                    ((Implemento)implemento).Precio_Implemento = Convert.ToDouble(this.precio_implemento.Value);
                    if (this.imagen_implemento.Value == "")
                    {
                        ((Implemento)implemento).Imagen_implemento =((Implemento)implementoCargado).Imagen_implemento;
                    }
                    else
                    {
                        ((Implemento)implemento).Imagen_implemento = "~/GUI/Modulo15/Imagenes/" +this.imagen_implemento.Value;
                        guardarImagen();
                    }
                    ((Implemento)implemento).Estatus_Implemento = this.estatus_implemento.Value;
                    presentador.modificarImplemento(implemento);
                    Response.Redirect("web_15_ConsultarImplemento.aspx?modificar=exito");

                }
            }
            catch (ExcepcionesSKD.Modulo15.ExcepcionPresentador.ExcepcionPresentadorModificarImplemento ex)
            {
                this.alert.Attributes["class"] = "alert alert-error alert-dismissible";
                this.alert.Attributes["role"] = "alert";
                this.alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>"+ex.Data+"</div>";
                       

            }
            catch (Exception ex) {

                this.alert.Attributes["class"] = "alert alert-error alert-dismissible";
                this.alert.Attributes["role"] = "alert";
                this.alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Problema con los campos ingresados</div>";
                       
            
            
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