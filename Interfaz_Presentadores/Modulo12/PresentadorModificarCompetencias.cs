using DominioSKD;
using DominioSKD.Fabrica;
using Interfaz_Contratos.Modulo12;
using LogicaNegociosSKD;
using LogicaNegociosSKD.Fabrica;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;

namespace Interfaz_Presentadores.Modulo12
{
    /// <summary>
    /// Presentador para la ventana Modificar Competencias
    /// </summary>
    public class PresentadorModificarCompetencias
    {
        private IContratoModificarCompetencias vista;
        int elIdComp;

        /// <summary>
        /// Constructor del presentador
        /// </summary>
        /// <param name="laVista">instancia de la ventana</param>
        public PresentadorModificarCompetencias(IContratoModificarCompetencias laVista)
        {
            this.vista = laVista;
        }

        public void ObtenerVariablesURL()
        {
            String modificarString = HttpContext.Current.Request.QueryString[M12_RecursoInterfazPresentador.strCompMod];
            String errorMalicioso = HttpContext.Current.Request.QueryString[M12_RecursoInterfazPresentador.errorGet];
           
            if (modificarString != null && !(HttpContext.Current.Handler as Page).IsPostBack)
                obtenerCompetencia(int.Parse(modificarString));

            if (errorMalicioso != null)
            {
                if (errorMalicioso.Equals(M12_RecursoInterfazPresentador.strErrorMalicioso))
                {
                    vista.alertaClase = M12_RecursoInterfazPresentador.alertaError;
                    vista.alertaRol = M12_RecursoInterfazPresentador.tipoAlerta;
                    vista.alerta = M12_RecursoInterfazPresentador.alertaHtml +
                        M12_RecursoInterfazPresentador.inputMalicioso +
                        M12_RecursoInterfazPresentador.alertaHtmlFinal;
                }
            }

        }

        public void LlenarCombos()
        {
            try
            {
                //Llena combo Organizaciones
                Dictionary<string, string> options = new Dictionary<string, string>();
                options.Add("-1", M12_RecursoInterfazPresentador.selectOrganizacion);

                Comando<List<Entidad>> comandoListarOrganizacion =
                    FabricaComandos.ObtenerComandoConsultarOrgazaniciones();
                Comando<List<Entidad>> comandoListarCintas =
                    FabricaComandos.ObtenerComandoConsultarCintas();

                List<Entidad> listaOrg = comandoListarOrganizacion.Ejecutar();

                foreach (Organizacion o in listaOrg)
                {
                    options.Add(o.Id.ToString(), o.Nombre);
                }
                vista.organizacionComp.DataSource = options;
                vista.organizacionComp.DataTextField = M12_RecursoInterfazPresentador.valueCombo;
                vista.organizacionComp.DataValueField = M12_RecursoInterfazPresentador.keyCombo;
                vista.organizacionComp.DataBind();

                //Llena combo Cintas
                Dictionary<int, string> optionsCin1 = new Dictionary<int, string>();
                optionsCin1.Add(-1, M12_RecursoInterfazPresentador.selectCinta);
                List<Entidad> listaCintaDesde = comandoListarCintas.Ejecutar();
                List<Entidad> listaCintaHasta = comandoListarCintas.Ejecutar();

                foreach (Cinta c in listaCintaDesde)
                {
                    optionsCin1.Add(c.Orden, c.Color_nombre);
                }
                vista.categIniComp.DataSource = optionsCin1;
                vista.categIniComp.DataTextField = M12_RecursoInterfazPresentador.valueCombo;
                vista.categIniComp.DataValueField = M12_RecursoInterfazPresentador.keyCombo;
                vista.categIniComp.SelectedValue = null;
                vista.categIniComp.DataBind();

                Dictionary<int, string> optionsCin2 = new Dictionary<int, string>();
                optionsCin2.Add(-1, M12_RecursoInterfazPresentador.selectCinta);

                foreach (Cinta c in listaCintaHasta)
                {
                    optionsCin2.Add(c.Orden, c.Color_nombre);
                }
                vista.categFinComp.DataSource = optionsCin2;
                vista.categFinComp.DataTextField = M12_RecursoInterfazPresentador.valueCombo;
                vista.categFinComp.DataValueField = M12_RecursoInterfazPresentador.keyCombo;
                vista.categFinComp.SelectedValue = null;
                vista.categFinComp.DataBind();
            }
            catch (ExcepcionesSKD.ExceptionSKD ex)
            {
                vista.alertaClase = M12_RecursoInterfazPresentador.alertaError;
                vista.alertaRol = M12_RecursoInterfazPresentador.tipoAlerta;
                vista.alerta = M12_RecursoInterfazPresentador.alertaHtml + ex.Mensaje + M12_RecursoInterfazPresentador.alertaHtmlFinal;
            }
        }
        protected DateTime convertirFecha(string fechaE)
        {
            string diaFecha;
            string mesFecha;
            string anoFecha;
            string fechaCompleta;
            string fechaCortada;
            if (fechaE.Length == 24)
            {
                fechaCortada = fechaE.Substring(0, 24);

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
            else
            {
                return DateTime.ParseExact(fechaE,"MM/dd/yyyy",CultureInfo.InvariantCulture);
            }
        }

        public void obtenerCompetencia(int elIdCompetencia) 
        {
            LlenarCombos();
            try
            {
                Entidad entidad = FabricaEntidades.ObtenerCompetencia();

                entidad.Id = elIdCompetencia;
                elIdComp = entidad.Id;
                Comando<Entidad> comandoObtenerCompetenciaXID =
                    FabricaComandos.ObtenerComandoDetallarCompetencia(entidad);

                DominioSKD.Entidades.Modulo12.Competencia laCompetencia =
                    (DominioSKD.Entidades.Modulo12.Competencia)comandoObtenerCompetenciaXID.Ejecutar();

                //Carga Nombre
                this.vista.nombreComp = laCompetencia.Nombre;

                //Carga tipos
                if (laCompetencia.TipoCompetencia == M12_RecursoInterfazPresentador.tipoKata)
                    this.vista.tipoCompKataBool = true;
                if (laCompetencia.TipoCompetencia == M12_RecursoInterfazPresentador.tipoKumite)
                    this.vista.tipoCompKumiteBool = true;
                if (laCompetencia.TipoCompetencia == M12_RecursoInterfazPresentador.tipoAmbos)
                    this.vista.tipoCompAmbosBool = true;

                //Carga de Organizacion
                if (laCompetencia.OrganizacionTodas == true)
                {
                    this.vista.orgCompBool = true;
                }
                else
                {
                    this.vista.orgCompBool = false;
                    this.vista.organizacionComp.SelectedValue = Convert.ToString(laCompetencia.Organizacion.Id_organizacion);
                    //vista.organizacionComp.Items.FindByValue(Convert.ToString(laCompetencia.Organizacion.Id)).Selected = true;
                }

                //Carga de Fechas
                this.vista.inicioComp = String.Format("{0:MM/dd/yyyy}", laCompetencia.FechaInicio);
                this.vista.finComp = String.Format("{0:MM/dd/yyyy}", laCompetencia.FechaFin);


                // Carga de Ubicacion
                vista.latitudComp = laCompetencia.Ubicacion.Latitud.ToString();
                vista.longitudComp = laCompetencia.Ubicacion.Longitud.ToString();

                //Carga de Edades
                this.vista.edadIniComp = laCompetencia.Categoria.Edad_inicial.ToString();
                this.vista.edadFinComp = laCompetencia.Categoria.Edad_final.ToString();

                // Carga de Status
                if (laCompetencia.Status == M12_RecursoInterfazPresentador.statusPorIniciar)
                    this.vista.statusIniciarCompBool = true;

                if (laCompetencia.Status == M12_RecursoInterfazPresentador.statusEnCurso)
                    this.vista.statusEnCursoCompBool = true;

                if (laCompetencia.Status == M12_RecursoInterfazPresentador.statusFinalizado)
                    this.vista.statusFinalizadoCompBool = true;



                // Carga de Sexo
                if (laCompetencia.Categoria.Sexo == M12_RecursoInterfazPresentador.sexoM)
                    this.vista.categSexoMCompBool = true;
                if (laCompetencia.Categoria.Sexo == M12_RecursoInterfazPresentador.sexoF)
                    this.vista.cateSexoFCompBool = true;

                // Carga Cintas
                if (laCompetencia.Categoria.Cinta_inicial == "Blanco")
                    this.vista.categIniComp.SelectedValue = "1";
                else
                    if (laCompetencia.Categoria.Cinta_inicial == "Amarillo")
                        this.vista.categIniComp.SelectedValue = "2";
                    else
                        if (laCompetencia.Categoria.Cinta_inicial == "Naranja")
                            this.vista.categIniComp.SelectedValue = "3";
                        else
                            if (laCompetencia.Categoria.Cinta_inicial == "Marron")
                                this.vista.categIniComp.SelectedValue = "4";
                            else
                                if (laCompetencia.Categoria.Cinta_inicial == "Negro")
                                    this.vista.categIniComp.SelectedValue = "5";


                if (laCompetencia.Categoria.Cinta_final == "Blanco")
                    this.vista.categFinComp.SelectedValue = "1";
                else
                    if (laCompetencia.Categoria.Cinta_final == "Amarillo")
                        this.vista.categFinComp.SelectedValue = "2";
                    else
                        if (laCompetencia.Categoria.Cinta_final == "Naranja")
                            this.vista.categFinComp.SelectedValue = "3";
                        else
                            if (laCompetencia.Categoria.Cinta_final == "Marron")
                                this.vista.categFinComp.SelectedValue = "4";
                            else
                                if (laCompetencia.Categoria.Cinta_final == "Negro")
                                    this.vista.categFinComp.SelectedValue = "5";

                // Carga Costo
                this.vista.costoComp = laCompetencia.Costo.ToString();
                
            }
            catch (ExcepcionesSKD.ExceptionSKD ex)
            {
                vista.alertaClase = M12_RecursoInterfazPresentador.alertaError;
                vista.alertaRol = M12_RecursoInterfazPresentador.tipoAlerta;
                vista.alerta = M12_RecursoInterfazPresentador.alertaHtml
                    + ex.Mensaje + M12_RecursoInterfazPresentador.alertaHtmlFinal;
            }
        
        }

        public void ModificarCompetencia() 
        {
            List<String> laListaDeInputs = new List<String>();
            List<String> expresionesRegInput = new List<String>();

            laListaDeInputs.Add(vista.nombreComp);
            if (vista.tipoCompKataBool == true)
                laListaDeInputs.Add(vista.tipoCompKata);
            if (vista.tipoCompKumiteBool == true)
                laListaDeInputs.Add(vista.tipoCompKumite);
            if (vista.tipoCompAmbosBool == true)
                laListaDeInputs.Add(vista.tipoCompAmbos);
            if (vista.orgCompBool == true)
                laListaDeInputs.Add(M12_RecursoInterfazPresentador.orgTodas);
            if (vista.orgCompBool == false)
                laListaDeInputs.Add(vista.organizacionComp.SelectedItem.Text);
            
            laListaDeInputs.Add(vista.longitudComp);
            laListaDeInputs.Add(vista.latitudComp);

            if (vista.inicioComp != "" || vista.finComp != "")
            {
                laListaDeInputs.Add(convertirFecha(vista.inicioComp).ToString());
                laListaDeInputs.Add(convertirFecha(vista.finComp).ToString());
            }

            laListaDeInputs.Add(vista.edadIniComp);
            laListaDeInputs.Add(vista.edadFinComp);
            laListaDeInputs.Add(vista.categIniComp.Text);
            laListaDeInputs.Add(vista.categFinComp.Text);

            if (vista.categSexoMCompBool == true)
                laListaDeInputs.Add(vista.categSexoMComp);
            if (vista.cateSexoFCompBool == true)
                laListaDeInputs.Add(vista.cateSexoFComp);

            if (vista.statusIniciarCompBool== true)
                laListaDeInputs.Add(vista.statusIniciarComp);
            if (vista.statusEnCursoCompBool == true)
                laListaDeInputs.Add(vista.statusEnCursoComp);
            laListaDeInputs.Add(vista.costoComp);

            expresionesRegInput.Add(vista.nombreComp);
            expresionesRegInput.Add(vista.inicioComp);
            expresionesRegInput.Add(vista.finComp);
            Regex expresionSQL = new Regex(M12_RecursoInterfazPresentador.expresionSQL);
            Regex expresionCaracteresEspeciales = new Regex(@"^[a-zA-Z0-9_@.-]*$");


            if (Validaciones.ValidarCamposVacios(laListaDeInputs))
            {
                try
                {
                    String modificarString = 
                        HttpContext.Current.Request.QueryString[M12_RecursoInterfazPresentador.strCompMod];

                    Comando<bool> comandoModificarCompetencia;

                    DominioSKD.Entidades.Modulo12.Competencia laCompetencia =
                        (DominioSKD.Entidades.Modulo12.Competencia)FabricaEntidades.ObtenerCompetencia(int.Parse(modificarString),vista.nombreComp,"",false,"");

                    //ARMAR OBJETO COMPETENCIA---->
                    //NOMBRE
                    //laCompetencia.Id = elIdComp;
                    laCompetencia.Nombre = vista.nombreComp;

                    //TIPO COMPETENCIA
                    if (vista.tipoCompKataBool == true)
                        laCompetencia.TipoCompetencia = vista.tipoCompKata;
                    if (vista.tipoCompKumiteBool == true)
                        laCompetencia.TipoCompetencia = vista.tipoCompKumite;
                    if (vista.tipoCompAmbosBool == true)
                        laCompetencia.TipoCompetencia = vista.tipoCompAmbos;

                    //ORGANIZACIONES
                    if (vista.orgCompBool == true)
                        laCompetencia.OrganizacionTodas = true;
                    if (vista.orgCompBool == false)
                    {
                        //laCompetencia.Organizacion = new Organizacion();
                        laCompetencia.Organizacion = (Organizacion)FabricaEntidades.ObtenerOrganizacion();
                        laCompetencia.OrganizacionTodas = false;
                        laCompetencia.Organizacion.Nombre = vista.organizacionComp.SelectedItem.Text;
                    }

                    //laCompetencia.Categoria = new Categoria();
                    laCompetencia.Categoria = (DominioSKD.Entidades.Modulo12.Categoria)FabricaEntidades.ObtenerCategoria();
                    //EDADES
                    laCompetencia.Categoria.Edad_inicial = int.Parse(vista.edadIniComp);
                    laCompetencia.Categoria.Edad_final = int.Parse(vista.edadFinComp);

                    //CINTAS
                    laCompetencia.Categoria.Cinta_inicial = vista.categIniComp.SelectedItem.Text;
                    laCompetencia.Categoria.Cinta_final = vista.categFinComp.SelectedItem.Text;
                    //SEXO
                    if (vista.categSexoMCompBool == true)
                        laCompetencia.Categoria.Sexo = vista.categSexoMComp;
                    if (vista.cateSexoFCompBool == true)
                        laCompetencia.Categoria.Sexo = vista.cateSexoFComp;

                    //FECHAS INI-FIN
                    laCompetencia.FechaInicio = Convert.ToDateTime(vista.inicioComp);
                    laCompetencia.FechaFin = Convert.ToDateTime(vista.finComp);

                    //STATUS
                    if (vista.statusIniciarCompBool == true)
                        laCompetencia.Status = vista.statusIniciarComp;
                    if (vista.statusEnCursoCompBool == true)
                        laCompetencia.Status = vista.statusEnCursoComp;

                    //UBICACION
                    //laCompetencia.Ubicacion = new Ubicacion();
                    laCompetencia.Ubicacion = (DominioSKD.Entidades.Modulo12.Ubicacion)FabricaEntidades.ObtenerUbicacion();
                    laCompetencia.Ubicacion.Latitud = this.vista.latitudComp;
                    laCompetencia.Ubicacion.Longitud = this.vista.longitudComp;
                    laCompetencia.Ubicacion.Ciudad = "Caracas";
                    laCompetencia.Ubicacion.Estado = "Distrito Capital";
                    laCompetencia.Ubicacion.Direccion = "";

                    //COSTO
                    laCompetencia.Costo = float.Parse(vista.costoComp);

                    //AGREGAR EN LOGICA OBJETO COMPETENCIA
                    comandoModificarCompetencia = FabricaComandos.ObtenerComandoModificarCompetencia(laCompetencia);

                    if (comandoModificarCompetencia.Ejecutar() == true)
                        HttpContext.Current.Response.Redirect(M12_RecursoInterfazPresentador.modificarExito);


                }
                catch (ExcepcionesSKD.ExceptionSKD ex)
                {
                    vista.alertaClase = M12_RecursoInterfazPresentador.alertaError;
                    vista.alertaRol = M12_RecursoInterfazPresentador.tipoAlerta;
                    vista.alerta = M12_RecursoInterfazPresentador.alertaHtml
                        + ex.Mensaje + M12_RecursoInterfazPresentador.alertaHtmlFinal;
                }
            }
            else
            {
                vista.alertaClase = M12_RecursoInterfazPresentador.alertaError;
                vista.alertaRol = M12_RecursoInterfazPresentador.tipoAlerta;
                vista.alerta = M12_RecursoInterfazPresentador.alertaHtml
                    + M12_RecursoInterfazPresentador.camposVacios
                    + M12_RecursoInterfazPresentador.alertaHtmlFinal;
            }
        }
    }
}
