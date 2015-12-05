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
        public string laLatitud;
        public string laLongitud;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "12";
            String detalleString = Request.QueryString["compDetalle"];

            if (!IsPostBack) // verificar si la pagina se muestra por primera vez
            {
                try
                {

                    laCompetencia = laLogica.detalleCompetenciaXId(int.Parse(detalleString));
                    this.nombreComp.Text = laCompetencia.Nombre;
                    this.tipoComp.Text = laCompetencia.TipoCompetencia.ToString();
                    if (laCompetencia.OrganizacionTodas.Equals(false))
                        this.orgComp.Text = laCompetencia.Organizacion.Nombre;
                    else
                        this.orgComp.Text = "Todas";
                    this.statusComp.Text = laCompetencia.Status;
                    this.inicioComp.Text = laCompetencia.FechaInicio.ToShortDateString();
                    this.finComp.Text = laCompetencia.FechaFin.ToShortDateString();
                    this.categIniComp.Text = laCompetencia.Categoria.Cinta_inicial;
                    this.categFinComp.Text = laCompetencia.Categoria.Cinta_final;
                    this.categEdadIniComp.Text = laCompetencia.Categoria.Edad_inicial.ToString();
                    this.categEdadFinComp.Text = laCompetencia.Categoria.Edad_final.ToString();
                    this.categSexoComp.Text = laCompetencia.Categoria.Sexo;
                    this.costoComp.Text = "Bs." + " " + laCompetencia.Costo.ToString();
                    laLatitud = laCompetencia.Ubicacion.Latitud.ToString();
                    laLongitud = laCompetencia.Ubicacion.Longitud.ToString();
                }
                catch 
                {
                }
            }
        }
    }
}