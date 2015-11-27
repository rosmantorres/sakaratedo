using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioSKD;
using LogicaNegociosSKD;
using LogicaNegociosSKD.Modulo12;

namespace templateApp.GUI.Modulo12
{
    public partial class M12_DetalleCompetencia : System.Web.UI.Page
    {
        Competencia laCompetencia = new Competencia();
        LogicaCompetencias laLogica = new LogicaCompetencias();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "12";
            String detalleString = Request.QueryString["compDetalle"];

            if (!IsPostBack) // verificar si la pagina se muestra por primera vez
            {
                 laCompetencia = laLogica.detalleCompetenciaXId(int.Parse(detalleString));
                 this.nombreComp.Value = laCompetencia.Nombre;
                 this.tipoComp.Value = laCompetencia.TipoCompetencia.ToString();//Preguntar xq la competencia es un int
                 if (laCompetencia.OrganizacionTodas.Equals(true))
                     this.orgComp.Value = laCompetencia.Organizacion.Nombre;
                 else
                     this.orgComp.Value = "Todas";
                
            }
            if (IsPostBack)
            {
               
            }
        }
    }
}