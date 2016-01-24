using System;
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
using DominioSKD.Entidades.Modulo15;
using System.Web.UI.HtmlControls;

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
             // usuario y roles***********
             String rol = Session[templateApp.GUI.Master.RecursosInterfazMaster.sessionRol].ToString();
             String usuario = Session[templateApp.GUI.Master.RecursosInterfazMaster.sessionUsuarioNombre].ToString();

             //***************************
             Agregar.Click += new EventHandler(this.agregarImplemento);     
    
        }

        void guardarImagen() {
            string TargetLocation;
            string imagen_implemento = null;
            TargetLocation = Server.MapPath("~/GUI/Modulo15/Imagen/");
            imagen_implemento = this.imagen_implemento.Value;
            this.imagen_implemento.PostedFile.SaveAs(TargetLocation + imagen_implemento);

        }

        public void agregarImplemento(object sender,EventArgs e) {

            try
            {
                if ((this.nombre_implemento.Value != "") && (this.tipo_implemento.Value != "") && (this.marca_implemento.Value != "") && (this.color_implemento.Value != "") && (this.talla_implemento.Value != "") && (this.cantidad_implemento.Value != "") && (this.stock_implemento.Value != "") && (this.descripcion_implemento.Value != "") && (this.precio_implemento.Value != ""))
                {


                    // usuario y roles***********
                    String rol = Session[templateApp.GUI.Master.RecursosInterfazMaster.sessionRol].ToString();
                    String usuario = Session[templateApp.GUI.Master.RecursosInterfazMaster.sessionUsuarioNombre].ToString();
                    //***************************


                    Entidad usuarioDojo = FabricaEntidades.ObtenerUsuario();
                    ((Usuario)usuarioDojo)._Nombre = usuario;
                    Entidad implemento = FabricaEntidades.ObtenerImplemento();
                    ((Implemento)implemento).Dojo_Implemento = (Dojo)FabricaEntidades.tenerDojo();
                    ((Implemento)implemento).Nombre_Implemento = this.nombre_implemento.Value;
                    if (this.tipo_implemento.Value == "otros")
                    {
                        ((Implemento)implemento).Tipo_Implemento = this.tipo_implemento_div.Value;
                    }
                    else
                    {
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
                        ((Implemento)implemento).Color_Implemento = this.color_implemento_div.Value;

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
                    ((Dojo)(((Implemento)implemento).Dojo_Implemento)).Id_dojo = presentador.usuarioDojo(usuarioDojo);
                    ((Implemento)implemento).Dojo_Implemento = (Dojo)presentador.obtenerDojoXId(((Implemento)implemento).Dojo_Implemento);
                    ((Implemento)implemento).Cantida_implemento = Convert.ToInt32(this.cantidad_implemento.Value);
                    ((Implemento)implemento).Stock_Minimo_Implemento = Convert.ToInt32(this.stock_implemento.Value);
                    ((Implemento)implemento).Descripcion_Implemento = this.descripcion_implemento.Value;
                    ((Implemento)implemento).Precio_Implemento = Convert.ToDouble(this.precio_implemento.Value);
                    ((Implemento)implemento).Imagen_implemento = this.imagen_implemento.Value;
                    presentador.agregarImplemento(implemento);

                    guardarImagen();
                    Response.Redirect("web_15_ConsultarImplemento.aspx");
                }
                else
                {
                    this.alert.Attributes["class"] = "alert alert-success alert-dismissible";
                    this.alert.Attributes["role"] = "alert";
                    this.alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Implemento deportivo eliminado exitosamente</div>";
                }
            }catch(ExcepcionesSKD.Modulo15.ExcepcionPresentador.ExcepcionPresentadorAgregarImplemento ex){
 
                this.alert.Attributes["class"] = "alert alert-error alert-dismissible";
                this.alert.Attributes["role"] = "alert";
                this.alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>"+ex.Data+"</div>";
                       
                       
                     
            }catch (Exception ex2){

                this.alert.Attributes["class"] = "alert alert-error alert-dismissible";
                this.alert.Attributes["role"] = "alert";
                this.alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Problema con los campos ingresados</div>";
                       
            
            }
        
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


        DropDownList IContratoAgregarImplemento.marca_implemeto
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

        TextBox IContratoAgregarImplemento.stock_implemeto
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

        string IContratoAgregarImplemento.imagen_implemeto
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