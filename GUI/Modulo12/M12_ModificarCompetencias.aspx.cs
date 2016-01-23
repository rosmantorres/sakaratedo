using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioSKD;
using LogicaNegociosSKD.Modulo12;
using System.Text.RegularExpressions;
using System.Globalization;
using Interfaz_Contratos.Modulo12;
using Interfaz_Presentadores.Modulo12;

namespace templateApp.GUI.Modulo12
{
    public partial class M12_ModificarCompetencias : System.Web.UI.Page, IContratoModificarCompetencias
    {
        Competencia laCompetencia = new Competencia();
        LogicaCompetencias laLogica = new LogicaCompetencias();
        private List<Organizacion> listaOrg = new List<Organizacion>();
        private List<Cinta> listaCintaDesde = new List<Cinta>();
        private List<Cinta> listaCintaHasta = new List<Cinta>();
        public string laLatitud;
        public string laLongitud;

        private PresentadorModificarCompetencias presentador;

        public M12_ModificarCompetencias()
        {
            presentador = new PresentadorModificarCompetencias(this);
        }
        protected DateTime convertirFecha(string fechaE)
        {
            string diaFecha;
            string mesFecha;
            string anoFecha;
            string fechaCompleta;
            string fechaCortada = fechaE.Substring(0, 24);
            string formato = "ddd MMM dd yyyy hh:mm:ss";
            DateTime fechaEntrada = DateTime.ParseExact(fechaCortada, formato, CultureInfo.InvariantCulture);

            diaFecha = fechaEntrada.Day.ToString();
            if (int.Parse(diaFecha) < 10)
                diaFecha = "0" + diaFecha.ToString();

            mesFecha = fechaEntrada.Month.ToString();
            if (int.Parse(mesFecha) < 10)
                mesFecha = "0" + mesFecha.ToString();

            anoFecha = fechaEntrada.Year.ToString();
            fechaCompleta = mesFecha + "/" + diaFecha + "/" + anoFecha;

            return DateTime.ParseExact(fechaCompleta, "MM/dd/yyyy", CultureInfo.InvariantCulture);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = M12_RecursoInterfaz.idModuloModificar;
            String modificarString = Request.QueryString[M12_RecursoInterfaz.strCompMod];
            laCompetencia = laLogica.detalleCompetenciaXId(int.Parse(modificarString));
            String errorMalicioso = Request.QueryString[M12_RecursoInterfaz.errorGet];

            if (errorMalicioso != null)
            {
                if (errorMalicioso.Equals(M12_RecursoInterfaz.strErrorMalicioso))
                {
                    alert.Attributes[M12_RecursoInterfaz.alertClase] = M12_RecursoInterfaz.alertaError;
                    alert.Attributes[M12_RecursoInterfaz.alertRole] = M12_RecursoInterfaz.tipoAlerta;
                    alert.InnerHtml = M12_RecursoInterfaz.alertaHtml + M12_RecursoInterfaz.inputMalicioso + M12_RecursoInterfaz.alertaHtmlFinal;
                    alert.Visible = true;
                }
            }

            if (!IsPostBack)
            {
                try
                {
                    #region llenado de combos desde bd
                    //Llena Combo Organizacion
                    Dictionary<string, string> options = new Dictionary<string, string>();
                    listaOrg = laLogica.M12obtenerListaDeOrganizaciones();

                    foreach (Organizacion o in listaOrg)
                    {
                        options.Add(o.Id_organizacion.ToString(), o.Nombre);
                    }
                    comboOrgs.DataSource = options;
                    comboOrgs.DataTextField = M12_RecursoInterfaz.valueCombo;
                    comboOrgs.DataValueField = M12_RecursoInterfaz.keyCombo;
                    comboOrgs.DataBind();

                    //Llena combo Cintas
                    Dictionary<int, string> optionsCin1 = new Dictionary<int, string>();
                    listaCintaDesde = laLogica.M12obtenerListaDeCintas();

                    foreach (Cinta c in listaCintaDesde)
                    {
                        optionsCin1.Add(c.Orden, c.Color_nombre);
                    }
                    comboCintaDesde.DataSource = optionsCin1;
                    comboCintaDesde.DataTextField = M12_RecursoInterfaz.valueCombo;
                    comboCintaDesde.DataValueField = M12_RecursoInterfaz.keyCombo;
                    comboCintaDesde.DataBind();

                    Dictionary<int, string> optionsCin2 = new Dictionary<int, string>();
                    listaCintaHasta = laLogica.M12obtenerListaDeCintas();

                    foreach (Cinta c in listaCintaHasta)
                    {
                        optionsCin2.Add(c.Orden, c.Color_nombre);
                    }
                    comboCintaHasta.DataSource = optionsCin1;
                    comboCintaHasta.DataTextField = M12_RecursoInterfaz.valueCombo;
                    comboCintaHasta.DataValueField = M12_RecursoInterfaz.keyCombo;
                    comboCintaHasta.DataBind();
                    #endregion

                    #region llenado de componentes de formulario desde bd
                    //Carga Nombre
                    this.nombreComp.Text = laCompetencia.Nombre;

                    //Carga tipos
                    if (laCompetencia.TipoCompetencia == M12_RecursoInterfaz.tipoKata)
                        this.input_tipo_kata.Checked = true;
                    if (laCompetencia.TipoCompetencia == M12_RecursoInterfaz.tipoKumite)
                        this.input_tipo_kumite.Checked = true;
                    if (laCompetencia.TipoCompetencia == M12_RecursoInterfaz.tipoAmbos)
                        this.input_tipo_ambos.Checked = true;

                    //Carga de Organizacion
                    if (laCompetencia.OrganizacionTodas == true)
                    {
                        this.organizaciones.Checked = true;
                    }
                    else
                    {
                        this.organizaciones.Checked = false;
                        this.comboOrgs.SelectedItem.Text = laCompetencia.Organizacion.Nombre;
                    }

                    //Carga de Fechas
                    this.fechaIni.Value = String.Format("{0:MM/dd/yyyy}", laCompetencia.FechaInicio);
                    this.fechaFin.Value = String.Format("{0:MM/dd/yyyy}", laCompetencia.FechaFin);


                    // Carga de Ubicacion
                    laLatitud = laCompetencia.Ubicacion.Latitud.ToString();
                    this.txtLAT.Value = laLatitud;
                    laLongitud = laCompetencia.Ubicacion.Longitud.ToString();
                    this.txtLONG.Value = laLongitud;

                    //Carga de Edades
                    this.edad_desde.Text = laCompetencia.Categoria.Edad_inicial.ToString();
                    this.edad_hasta.Text = laCompetencia.Categoria.Edad_final.ToString();

                    // Carga de Status
                    if (laCompetencia.Status == M12_RecursoInterfaz.statusPorIniciar)
                        this.input_status_porIniciar.Checked = true;

                    if (laCompetencia.Status == M12_RecursoInterfaz.statusEnCurso)
                        this.input_status_enCurso.Checked = true;

                    if (laCompetencia.Status == M12_RecursoInterfaz.statusFinalizado)
                        this.input_status_Finalizado.Checked = true;



                    // Carga de Sexo
                    if (laCompetencia.Categoria.Sexo == M12_RecursoInterfaz.sexoM)
                        this.input_sexo_M.Checked = true;
                    if (laCompetencia.Categoria.Sexo == M12_RecursoInterfaz.sexoF)
                        this.input_sexo_F.Checked = true;

                    // Carga Cintas
                    this.comboCintaDesde.SelectedItem.Text = laCompetencia.Categoria.Cinta_inicial;
                    this.comboCintaHasta.SelectedItem.Text = laCompetencia.Categoria.Cinta_final;

                    // Carga Costo
                    this.costoComp.Text = laCompetencia.Costo.ToString();
                    #endregion
                }
                catch (ExcepcionesSKD.ExceptionSKD ex)
                {
                    alert.Attributes[M12_RecursoInterfaz.alertClase] = M12_RecursoInterfaz.alertaError;
                    alert.Attributes[M12_RecursoInterfaz.alertRole] = M12_RecursoInterfaz.tipoAlerta;
                    alert.InnerHtml = M12_RecursoInterfaz.alertaHtml + ex.Mensaje + M12_RecursoInterfaz.alertaHtmlFinal;
                    alert.Visible = true;
                }
            }


        }



        protected void comboCintaDesde_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void comboCintaHasta_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void comboSexo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void comboOrgs_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btn_modificarComp_Click_Click(object sender, EventArgs e)
        {
            List<String> laListaDeInputs = new List<String>();
            List<String> expresionesRegInput = new List<String>();

            laListaDeInputs.Add(nombreComp.Text);
            if (input_tipo_kata.Checked == true)
                laListaDeInputs.Add(input_tipo_kata.Text);
            if (input_tipo_kumite.Checked == true)
                laListaDeInputs.Add(input_tipo_kumite.Text);
            if (input_tipo_ambos.Checked == true)
                laListaDeInputs.Add(input_tipo_ambos.Text);
            if (organizaciones.Checked == true)
                laListaDeInputs.Add(M12_RecursoInterfaz.orgTodas);
            if (organizaciones.Checked == false)
                laListaDeInputs.Add(comboOrgs.SelectedItem.Text);
            laListaDeInputs.Add(txtLAT.Value);
            laListaDeInputs.Add(txtLONG.Value);
            laListaDeInputs.Add(fechaIni.Value);
            laListaDeInputs.Add(fechaFin.Value);
            laListaDeInputs.Add(edad_desde.Text);
            laListaDeInputs.Add(edad_hasta.Text);
            laListaDeInputs.Add(comboCintaDesde.Text);
            laListaDeInputs.Add(comboCintaHasta.Text);
            if (input_sexo_M.Checked == true)
                laListaDeInputs.Add(input_sexo_M.Text);
            if (input_sexo_F.Checked == true)
                laListaDeInputs.Add(input_sexo_F.Text);
            if (input_status_porIniciar.Checked == true)
                laListaDeInputs.Add(input_status_porIniciar.Text);
            if (input_status_enCurso.Checked == true)
                laListaDeInputs.Add(input_status_enCurso.Text);
            laListaDeInputs.Add(costoComp.Text);

            expresionesRegInput.Add(nombreComp.Text);
            expresionesRegInput.Add(fechaIni.Value);
            expresionesRegInput.Add(fechaFin.Value);
            Regex expresionSQL = new Regex(M12_RecursoInterfaz.expresionSQL);
            Regex expresionCaracteresEspeciales = new Regex(@"^[a-zA-Z0-9_@.-]*$");


            if (Validaciones.ValidarCamposVacios(laListaDeInputs))
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
                                laCompetencia.Organizacion = new Organizacion();
                                laCompetencia.OrganizacionTodas = false;
                                laCompetencia.Organizacion.Nombre = comboOrgs.SelectedItem.Text;
                            }

                            laCompetencia.Categoria = new Categoria();
                            //EDADES
                            laCompetencia.Categoria.Edad_inicial = int.Parse(edad_desde.Text);
                            laCompetencia.Categoria.Edad_final = int.Parse(edad_hasta.Text);

                            //CINTAS
                            laCompetencia.Categoria.Cinta_inicial = comboCintaDesde.SelectedItem.Text;
                            laCompetencia.Categoria.Cinta_final = comboCintaHasta.SelectedItem.Text;
                            //SEXO
                            if (input_sexo_M.Checked == true)
                                laCompetencia.Categoria.Sexo = input_sexo_M.Text;
                            if (input_sexo_F.Checked == true)
                                laCompetencia.Categoria.Sexo = input_sexo_F.Text;

                            //FECHAS INI-FIN
                            laCompetencia.FechaInicio = Convert.ToDateTime(fechaIni.Value);
                            laCompetencia.FechaFin = Convert.ToDateTime(fechaFin.Value);

                            //STATUS
                            if (input_status_porIniciar.Checked == true)
                                laCompetencia.Status = input_status_porIniciar.Text;
                            if (input_status_enCurso.Checked == true)
                                laCompetencia.Status = input_status_enCurso.Text;

                            //UBICACION
                            laCompetencia.Ubicacion = new Ubicacion();
                            laCompetencia.Ubicacion.Latitud = txtLAT.Value;
                            laCompetencia.Ubicacion.Longitud = txtLONG.Value;
                            laCompetencia.Ubicacion.Ciudad = "Caracas";
                            laCompetencia.Ubicacion.Estado = "Distrito Capital";
                            laCompetencia.Ubicacion.Direccion = "";

                            //COSTO
                            laCompetencia.Costo = float.Parse(costoComp.Text);

                            //AGREGAR EN LOGICA OBJETO COMPETENCIA
                            if (laLogica.modificarCompetencia(laCompetencia) == true)
                                Response.Redirect(M12_RecursoInterfaz.modificarExito);


                        }
                        catch (ExcepcionesSKD.ExceptionSKD ex)
                        {
                            this.alert.Attributes[M12_RecursoInterfaz.alertClase] = M12_RecursoInterfaz.alertaError;
                            this.alert.Attributes[M12_RecursoInterfaz.alertRole] = M12_RecursoInterfaz.tipoAlerta;
                            this.alert.InnerHtml = M12_RecursoInterfaz.alertaHtml + ex.Mensaje + M12_RecursoInterfaz.alertaHtmlFinal;
                            this.alert.Visible = true;
                        }
                    }
            
            else
            {
                this.alert.Attributes[M12_RecursoInterfaz.alertClase] = M12_RecursoInterfaz.alertaError;
                this.alert.Attributes[M12_RecursoInterfaz.alertRole] = M12_RecursoInterfaz.tipoAlerta;
                this.alert.InnerHtml = M12_RecursoInterfaz.alertaHtml + M12_RecursoInterfaz.camposVacios + M12_RecursoInterfaz.alertaHtmlFinal;
                this.alert.Visible = true;
            }


        }

    }
}