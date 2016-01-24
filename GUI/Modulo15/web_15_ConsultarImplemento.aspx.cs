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
using LogicaNegociosSKD.Fabrica;

namespace templateApp.GUI.Modulo15
{
    public partial class web_15_ConsultarImplemento : System.Web.UI.Page,IContratoConsultarImplemento
    {
        
        private List<Entidad> laLista = new List<Entidad>();
        private PresentadorConsultarImplemento presentador;
       
        public web_15_ConsultarImplemento()
        {
            presentador = new PresentadorConsultarImplemento(this);
        }


        string IContratoConsultarImplemento.tabla
        {
            get
            {
                return tabla.Text;
            }
            set
            {
                tabla.Text = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "15";
            String usuario=null;
            String rol ;
            try
            {
                // usuario y roles***********
                 rol = Session[templateApp.GUI.Master.RecursosInterfazMaster.sessionRol].ToString();
                usuario = Session[templateApp.GUI.Master.RecursosInterfazMaster.sessionUsuarioNombre].ToString();

                //***************************

                //      btnEliminar.Click += new EventHandler(this.eliminarImplemento);     
            }
            catch (Exception ex)
            {
                Response.Redirect("~/GUI/Modulo1/Index.aspx");


            }

            try
            {
                /// <summary>
                /// Consulta los datos de un implemento
                /// </summary>
                /// 
                Entidad usuarioLogear = FabricaEntidades.ObtenerUsuario();
                ((Usuario)usuarioLogear)._Nombre = usuario;
                int dojoUsuario = presentador.usuarioDojo(usuarioLogear);
                Entidad dojo = FabricaEntidades.tenerDojo();
                ((Dojo)dojo).Dojo_Id = dojoUsuario;
                dojo = presentador.obtenerDojoXId(dojo);
                this.nombre_dojo.InnerText = ((Dojo)dojo).Nombre_dojo;

                string consultar = Request.QueryString["consultar"];
                string mensajeModificar = Request.QueryString["modificar"];
                string mensajeAgregar = Request.QueryString["agregar"];

                string eliminar = "";
                List<Entidad> listaImplementos = null;
                if (mensajeAgregar == "exito") {

                    this.alert.Attributes["class"] = "alert alert-success alert-dismissible";
                    this.alert.Attributes["role"] = "alert";
                    this.alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Se agrego con exito</div>";
                    
                }
                if (mensajeModificar == "exito")
                {
                    this.alert.Attributes["class"] = "alert alert-success alert-dismissible";
                    this.alert.Attributes["role"] = "alert";
                    this.alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Se modifico con exito</div>";
                    

                }
                if (consultar == "Inactivo")
                {
                    listaImplementos = presentador.cargarListaImplementos2(dojo);
                }
                else
                {
                    if (consultar == "eliminar")
                    {
                        eliminar = Request.QueryString["idImplemento"];
                        presentador.eliminarImplemento(eliminar, ((Dojo)dojo).Dojo_Id);
                    }
                    listaImplementos = presentador.cargarListaImplementos(dojo);

                }
                foreach (Entidad valorActual in listaImplementos)
                {
                    this.tabla.Text += "<tr>";
                    this.tabla.Text += "<td>" + ((Implemento)valorActual).Id_Implemento + "</td>";
                    this.tabla.Text += "<td>" + ((Implemento)valorActual).Nombre_Implemento + "</td>";
                    this.tabla.Text += "<td>" + ((Implemento)valorActual).Tipo_Implemento + "</td>";
                    this.tabla.Text += "<td>" + ((Implemento)valorActual).Marca_Implemento + "</td>";
                    this.tabla.Text += "<td>" + ((Implemento)valorActual).Color_Implemento + "</td>";
                    this.tabla.Text += "<td>" + ((Implemento)valorActual).Talla_Implemento + "</td>";
                    this.tabla.Text += "<td>" + ((Implemento)valorActual).Cantida_implemento + "</td>";
                    this.tabla.Text += "<td>" + ((Implemento)valorActual).Stock_Minimo_Implemento + "</td>";


                    if (((Implemento)valorActual).Stock_Minimo_Implemento > ((Implemento)valorActual).Cantida_implemento)
                    {
                        this.tabla.Text += "<td><div class='panel panel-default caja'><div class='panel-body alert-error'></div></td>";
                    }
                    else
                    {
                        if (((Implemento)valorActual).Stock_Minimo_Implemento == ((Implemento)valorActual).Cantida_implemento)
                        {
                            this.tabla.Text += "<td><div class='panel panel-default caja'><div class='panel-body alert-warning'></div></td>";

                        }
                        else
                        {
                            if (((Implemento)valorActual).Stock_Minimo_Implemento < ((Implemento)valorActual).Cantida_implemento)
                            {
                                this.tabla.Text += "<td><div class='panel panel-default caja'><div class='panel-body alert-success'></div></td>";
                            }
                        }

                    }
                    this.tabla.Text += "<td>" + ((Implemento)valorActual).Precio_Implemento + "</td>";
                    this.tabla.Text += "<td>" + ((Implemento)valorActual).Precio_Implemento * ((Implemento)valorActual).Cantida_implemento + "</td>";
                    this.tabla.Text += "<td>";
                    this.tabla.Text += "<a class='btn btn-primary glyphicon glyphicon-info-sign' data-toggle='modal' data-target='#modal-info' href='#'></a>";
                    this.tabla.Text += "<a class='btn btn-default glyphicon glyphicon-pencil'  href='web_15_ModificarImplemento.aspx?idImplemento=" + ((Implemento)valorActual).Id_Implemento + "'></a>";
                    this.tabla.Text += "<a id='nombre_2' class='eliminar_clase btn btn-danger glyphicon glyphicon-remove-sign' data-id=" + ((Implemento)valorActual).Id_Implemento + " data-toggle='modal' data-target='#modal-delete'></a>";
                    this.tabla.Text += "</td>";
                    this.tabla.Text += "</tr>";


                }
            }
            catch (ExcepcionesSKD.Modulo15.ExcepcionPresentador.ExcepcionPresentadorConsultarImplemento ex)
            {
                this.alert.Attributes["class"] = "alert alert-error alert-dismissible";
                this.alert.Attributes["role"] = "alert";
                this.alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>"+ex.Data+"</div>";
                       
            


            }
            catch (Exception ex) {

                this.alert.Attributes["class"] = "alert alert-error alert-dismissible";
                this.alert.Attributes["role"] = "alert";
                this.alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Problema Cargando los Datos</div>";
                       
            
            
            }
        }

 
    }
}