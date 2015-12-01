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
                //ARMAR OBJETO COMPETENCIA---->
                //NOMBRE
                laCompetencia.Nombre = nombreComp.Text;

                //TIPO COMPETENCIA
                if (input_tipo_kata.Checked == true)
                    laCompetencia.TipoCompetencia = input_tipo_kata.Text;
                if (input_tipo_kumite.Checked == true)
                    laCompetencia.TipoCompetencia = input_tipo_kumite.Text;
                if (input_tipo_ambos.Checked == true)
                    laCompetencia.TipoCompetencia = input_tipo_ambos.Text;

                //ORGANIZACIONES
                if (organizaciones.Checked == true)
                    laCompetencia.OrganizacionTodas = true;
                if (organizaciones.Checked == false)
                {
                    laCompetencia.OrganizacionTodas = false;
                    laCompetencia.Organizacion.Id_organizacion = 1;
                }

                //EDADES
                laCompetencia.Categoria.Edad_inicial = int.Parse(edad_desde.Value);
                laCompetencia.Categoria.Edad_final = int.Parse(edad_hasta.Value);

                //CINTAS
                laCompetencia.Categoria.Cinta_inicial = "Azul"; //comboCintaDesde.Text;
                laCompetencia.Categoria.Cinta_final = "Purpura"; //comboCintaHasta.Text;
                
                //SEXO
                if (input_sexo_M.Checked == true)
                    laCompetencia.Categoria.Sexo = input_sexo_M.Text;
                if (input_sexo_F.Checked == true)
                    laCompetencia.Categoria.Sexo = input_sexo_F.Text;

                //FECHAS INI-FIN
                laCompetencia.FechaInicio =  Convert.ToDateTime("01/02/2015"); //Convert.ToDateTime(input_fecha_ini.Value);
                laCompetencia.FechaFin = Convert.ToDateTime("02/04/2015"); //Convert.ToDateTime(input_fecha_fin.Value);
               
                //STATUS
                if (input_status_porIniciar.Checked == true)
                    laCompetencia.Status = input_status_porIniciar.Text;
                if (input_status_enCurso.Checked == true)
                    laCompetencia.Status = input_status_enCurso.Text;

                //UBICACION
                laCompetencia.Ubicacion.Latitud = txtLAT.Value;
                laCompetencia.Ubicacion.Longitud = txtLONG.Value;
                laCompetencia.Ubicacion.Ciudad = "Caracas";
                laCompetencia.Ubicacion.Estado = "Distrito Capital";
                laCompetencia.Ubicacion.Direccion = "";

                //COSTO
                laCompetencia.Costo = 900;

                //AGREGAR EN LOGICA OBJETO COMPETENCIA
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