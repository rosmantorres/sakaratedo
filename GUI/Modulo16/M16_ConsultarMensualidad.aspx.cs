using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioSKD;
using LogicaNegociosSKD;
using LogicaNegociosSKD.Modulo16;
using templateApp.GUI.Master;

namespace templateApp.GUI.Modulo16
{
    public partial class M16_ConsultarMensualidad : System.Web.UI.Page
    {
        private List<Matricula> laListaDeMatriculas = new List<Matricula>();
        public static int usuario = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "16";

            M16_ConsultarMensualidad.usuario = int.Parse(Session[RecursosInterfazMaster.sessionUsuarioID].ToString());
            String success = Request.QueryString["success"];
            String usuario = Request.QueryString["compAgregar"];
            String matricula = Request.QueryString["compAgregar"];



            if (success != null)
            {
                if (success.Equals("1"))
                {
                    alert.Attributes["class"] = "alert alert-success alert-dismissible";
                    alert.Attributes["role"] = "alert";
                    alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Matricula agregada exitosamente</div>";
                }
                if (usuario != null && matricula != null)
                {
                   // agregarMatriculaAcarrito(1, 1);
                }

            }



        #region Llenar Data Table Con Matriculas

            Logicamatricula logComp = new Logicamatricula();
            if (!IsPostBack)
            {
                try
                {
                    laListaDeMatriculas = logComp.mostrarMensualidadesmorosas();

                    foreach (Matricula m in laListaDeMatriculas)
                    {


                        this.laTabla.Text += M16_Recursointerfaz.ABRIR_TR;
                        this.laTabla.Text += M16_Recursointerfaz.ABRIR_TD;
                       // this.laTabla.Text += M16_Recursointerfaz.ABRIR_TD + m.Id.ToString() + M16_Recursointerfaz.CERRAR_TD;
                        this.laTabla.Text += M16_Recursointerfaz.ABRIR_TD + m.Identificador.ToString() + M16_Recursointerfaz.CERRAR_TD;
                        this.laTabla.Text += M16_Recursointerfaz.ABRIR_TD + m.FechaCreacion.ToString() + M16_Recursointerfaz.CERRAR_TD;
                        this.laTabla.Text += M16_Recursointerfaz.ABRIR_TD + m.UltimaFechaPago.ToString() + M16_Recursointerfaz.CERRAR_TD;

                        this.laTabla.Text += M16_Recursointerfaz.ABRIR_TD;
                        this.laTabla.Text += M16_Recursointerfaz.BOTON_AGREGAR_MATRICULA_CARRITO + m.ID +  "_" + m.Costo + M16_Recursointerfaz.BOTON_CERRAR;
                        this.laTabla.Text += M16_Recursointerfaz.CERRAR_TD;
                        this.laTabla.Text += M16_Recursointerfaz.CERRAR_TR;




                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
            #endregion

        #region Llamada para Agregar Matricula al Carrito

        [System.Web.Services.WebMethod]
        public static string agregarMatriculaAcarrito(int idMatricula, int precio)
        {

            Logicacarrito logica = new Logicacarrito();

            bool agregar = false;

            agregar = logica.agregarMatriculaaCarrito(usuario, idMatricula,1, precio);

            string json = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(agregar);
            return json;
        }

        #endregion

    }

}
