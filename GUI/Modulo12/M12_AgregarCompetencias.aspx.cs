using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioSKD;
using System.Text.RegularExpressions;
using System.Globalization;
using Interfaz_Contratos.Modulo12;
using Interfaz_Presentadores.Modulo12;

namespace templateApp.GUI.Modulo12
{
    public partial class M12_AgregarCompetencias : System.Web.UI.Page, IContratoAgregarCompetencias
    {
        private DominioSKD.Competencia laCompetencia = new DominioSKD.Competencia();
        private LogicaNegociosSKD.Modulo12.LogicaCompetencias laLogica = new LogicaNegociosSKD.Modulo12.LogicaCompetencias();
        private List<Organizacion> listaOrg = new List<Organizacion>();
        private List<Cinta> listaCintaDesde = new List<Cinta>();
        private List<Cinta> listaCintaHasta = new List<Cinta>();
        private PresentadorAgregarCompetencia presentador;

        public M12_AgregarCompetencias()
        {
            presentador = new PresentadorAgregarCompetencia(this);
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
            ((SKD)Page.Master).IdModulo = M12_RecursoInterfaz.idModulo;

            presentador.ObtenerVariablesURL();

            #region LLENAR COMBO ORGANIZACIONES DE COMPETENCIA Y COMBOS CINTA
            if (!IsPostBack)
            {
                presentador.LlenarCombos();
            }
            #endregion

        }

        protected void btn_agregarComp_Click(object sender, EventArgs e)
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
            laListaDeInputs.Add(convertirFecha(fechaIni.Value).ToString());
            laListaDeInputs.Add(convertirFecha(fechaFin.Value).ToString());
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
            Regex expresionSQL = new Regex(M12_RecursoInterfaz.expresionSQL);


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
                        laCompetencia.FechaInicio = convertirFecha(fechaIni.Value);
                        laCompetencia.FechaFin = convertirFecha(fechaFin.Value);

                        //STATUS
                        if (input_status_porIniciar.Checked == true)
                            laCompetencia.Status = input_status_porIniciar.Text;
                        if (input_status_enCurso.Checked == true)
                            laCompetencia.Status = input_status_enCurso.Text;

                        //UBICACION
                        laCompetencia.Ubicacion = new Ubicacion();
                        laCompetencia.Ubicacion.Latitud = this.txtLAT.Value;
                        laCompetencia.Ubicacion.Longitud = this.txtLONG.Value;
                        laCompetencia.Ubicacion.Ciudad = "Caracas";
                        laCompetencia.Ubicacion.Estado = "Distrito Capital";
                        laCompetencia.Ubicacion.Direccion = "";

                        //COSTO
                        laCompetencia.Costo = float.Parse(costoComp.Text);

                        //AGREGAR EN LOGICA OBJETO COMPETENCIA

                        if (laLogica.agregarCompetencia(laCompetencia) == true)
                            Response.Redirect(M12_RecursoInterfaz.agregarExito);


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


        #region void
        protected void comboSexo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void comboOrgs_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void comboCintaHasta_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        #endregion
        #region Contrato
        string IContratoAgregarCompetencias.nombreComp
        {
            get { return nombreComp.Text; }
        }

        public string tipoCompKumite
        {
            get { return tipoCompKumite; }
        }

        public bool tipoCompKumiteBool
        {
            get { return tipoCompKumiteBool; }
        }

        public string tipoCompKata
        {
            get { return tipoCompKata; }
        }

        public bool tipoCompKataBool
        {
            get { return tipoCompKataBool; }
        }

        public string tipoCompAmbos
        {
            get { return tipoCompAmbos; }
        }

        public bool tipoCompAmbosBool
        {
            get { return tipoCompAmbosBool; }
        }

        public bool orgCompBool
        {
            get { return orgCompBool; }
        }

        DropDownList IContratoAgregarCompetencias.organizacionComp
        {
            get
            {
                return comboOrgs;
            }
            set
            {
                comboOrgs = value;
            }
        }

        public string statusIniciarComp
        {
            get { return statusIniciarComp; }
        }

        public bool statusIniciarCompBool
        {
            get { return statusIniciarCompBool; }
        }

        public string statusEnCursoComp
        {
            get { return statusEnCursoComp; }
        }

        public bool statusEnCursoCompBool
        {
            get { return statusEnCursoCompBool; }
        }

        string IContratoAgregarCompetencias.costoComp
        {
            get { return costoComp.Text; }
        }

        public string inicioComp
        {
            get { return inicioComp; }
        }

        public string finComp
        {
            get { return finComp; }
        }

        string IContratoAgregarCompetencias.latitudComp
        {
            get { return txtLAT.Value; }
        }

        string IContratoAgregarCompetencias.longitudComp
        {
            get { return txtLONG.Value; }
        }

        DropDownList IContratoAgregarCompetencias.categIniComp
        {
            get
            {
                return comboCintaDesde;
            }
            set
            {
                comboCintaDesde = value;
            }
        }

        DropDownList IContratoAgregarCompetencias.categFinComp
        {
            get
            {
                return comboCintaHasta;
            }
            set
            {
                comboCintaHasta = value;
            }
        }

        public string edadIniComp
        {
            get { return edadIniComp; }
        }

        public string edadFinComp
        {
            get { return edadFinComp; }
        }

        public string categSexoMComp
        {
            get { return categSexoMComp; }
        }

        public bool categSexoMCompBool
        {
            get { return categSexoMCompBool; }
        }

        public string cateSexoFComp
        {
            get { return cateSexoFComp; }
        }

        public bool cateSexoFCompBool
        {
            get { return cateSexoFCompBool; }
        }

        public string alertaClase
        {
            set { alert.Attributes[M12_RecursoInterfaz.alertClase] = value; }
        }

        public string alertaRol
        {
            set { alert.Attributes[M12_RecursoInterfaz.alertRole] = value; }
        }

        public string alerta
        {
            set { alert.InnerHtml = value; }
        }
        #endregion
    }
}