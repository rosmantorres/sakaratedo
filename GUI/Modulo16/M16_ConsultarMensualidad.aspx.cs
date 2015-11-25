using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioSKD;
using LogicaNegociosSKD;
using LogicaNegociosSKD.Modulo16;

namespace templateApp.GUI.Modulo16
{
    public partial class M16_ConsultarMensualidad : System.Web.UI.Page
    {
        private List<Matricula> laListaDeMatriculas = new List<Matricula>();





        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "16";
            String success = Request.QueryString["success"];



            if (success != null)
            {
                if (success.Equals("1"))
                {
                    alert.Attributes["class"] = "alert alert-success alert-dismissible";
                    alert.Attributes["role"] = "alert";
                    alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Matricula agregada exitosamente</div>";
                }

            }



            #region Llenar Data Table Con Matriculas

            Logicamatricula logComp = new Logicamatricula();
            if (!IsPostBack)
            {
                try
                {
                    laListaDeMatriculas = logComp.mostrarMensualidadesmorosas(1);

                    foreach (Matricula m in laListaDeMatriculas)
                    {


                        this.laTabla.Text += M16_Recursointerfaz.ABRIR_TR;
                        this.laTabla.Text += M16_Recursointerfaz.ABRIR_TD;

                        this.laTabla.Text += M16_Recursointerfaz.ABRIR_TD + m.Mat_identificador.ToString() + M16_Recursointerfaz.CERRAR_TD;
                        this.laTabla.Text += M16_Recursointerfaz.ABRIR_TD + m.FechaCreacion.ToString() + M16_Recursointerfaz.CERRAR_TD;
                        this.laTabla.Text += M16_Recursointerfaz.ABRIR_TD + m.FechaTope.ToString() + M16_Recursointerfaz.CERRAR_TD;

                        this.laTabla.Text += M16_Recursointerfaz.ABRIR_TD;
                        this.laTabla.Text += M16_Recursointerfaz.BOTON_AGREGAR_CARRITO + m.IdentificadorUsuario + M16_Recursointerfaz.BOTON_CERRAR;
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


    }

}
