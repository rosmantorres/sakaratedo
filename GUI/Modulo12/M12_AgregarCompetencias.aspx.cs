using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace templateApp.GUI.Modulo12
{
    public partial class M12_AgregarCompetencias : System.Web.UI.Page
    {
        private DominioSKD.Competencia laCompetencia = new DominioSKD.Competencia();
        private LogicaNegociosSKD.Modulo12.LogicaCompetencias laLogica = new LogicaNegociosSKD.Modulo12.LogicaCompetencias();
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "12";


        }

        protected void btn_agregarComp_Click(object sender, EventArgs e)
        {
            try
            {
                laCompetencia.Nombre = nombreComp.Text;
                if (input_tipo_kata.Checked == true)
                    laCompetencia.TipoCompetencia = input_tipo_kata.Text;
                if (input_tipo_kumite.Checked == true)
                    laCompetencia.TipoCompetencia = input_tipo_kumite.Text;
                if (input_tipo_ambos.Checked == true)
                    laCompetencia.TipoCompetencia = input_tipo_ambos.Text;
                if (organizaciones.Checked == true)
                    laCompetencia.OrganizacionTodas = true;
                if (organizaciones.Checked == false)
                {
                    laCompetencia.OrganizacionTodas = false;
                    laCompetencia.Organizacion.Id_organizacion = 1;
                }
                laCompetencia.Categoria.Edad_inicial = int.Parse(edad_desde.Value);
                laCompetencia.Categoria.Edad_final = int.Parse(edad_hasta.Value);
                laCompetencia.Categoria.Cinta_inicial = comboCintaDesde.Text;
                laCompetencia.Categoria.Cinta_final = comboCintaHasta.Text;
                laCompetencia.Categoria.Sexo = comboSexo.Text;
                if (input_status_porIniciar.Checked == true)
                    laCompetencia.Status = input_status_porIniciar.Text;
                if (input_status_enCurso.Checked == true)
                    laCompetencia.Status = input_status_enCurso.Text;
                laCompetencia.Ubicacion.Latitud = txtLAT.Value;
                laCompetencia.Ubicacion.Longitud = txtLONG.Value;

                laLogica.agregarCompetencia(laCompetencia);
                
                    
            }
            catch
            { 
             
            }
        }

        protected void comboSexo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void comboCintaHasta_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void comboCintaDesde_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}