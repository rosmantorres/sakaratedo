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

namespace Interfaz_Presentadores.Modulo12
{
    /// <summary>
    /// Presentador para la ventana Agregar Competencia
    /// </summary>
    public class PresentadorAgregarCompetencia
    {
        private IContratoAgregarCompetencias vista;

        /// <summary>
        /// Constructor del presentador
        /// </summary>
        /// <param name="laVista">instancia de la ventana</param>
        public PresentadorAgregarCompetencia(IContratoAgregarCompetencias laVista)
        {
            this.vista = laVista;
        }

        /// <summary>
        /// Metodo para consultar las variables del url
        /// </summary>
        public void ObtenerVariablesURL()
        { 
            String errorMalicioso = HttpContext.Current.Request.QueryString[M12_RecursoInterfazPresentador.errorGet];

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

        /// <summary>
        /// Metodo para llenar los comboboxes organizaciones y cintas
        /// </summary>
        public void LlenarCombos()
        {
            try
            {
                //FabricaComandos laFabrica = new FabricaComandos();
                Comando<List<Entidad>> comandoListarOrganizacion =
                    FabricaComandos.ObtenerComandoConsultarOrgazaniciones();

                Comando<List<Entidad>> comandoListarCintas =
                    FabricaComandos.ObtenerComandoConsultarCintas();

                Dictionary<string, string> options = new Dictionary<string, string>();
                options.Add("-1", M12_RecursoInterfazPresentador.selectOrganizacion);

                List<Entidad> listaOrg = comandoListarOrganizacion.Ejecutar();


                foreach (Organizacion o in listaOrg)
                {
                    options.Add(o.Id.ToString(), o.Nombre);
                }
                vista.organizacionComp.DataSource = options;
                vista.organizacionComp.DataTextField = M12_RecursoInterfazPresentador.valueCombo;
                vista.organizacionComp.DataValueField = M12_RecursoInterfazPresentador.keyCombo;
                vista.organizacionComp.DataBind();

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
                vista.categIniComp.DataBind();

                Dictionary<int, string> optionsCin2 = new Dictionary<int, string>();
                optionsCin2.Add(-1, M12_RecursoInterfazPresentador.selectCinta);
                vista.categFinComp.DataSource = optionsCin2;
                vista.categFinComp.DataTextField = M12_RecursoInterfazPresentador.valueCombo;
                vista.categFinComp.DataValueField = M12_RecursoInterfazPresentador.keyCombo;
                vista.categFinComp.DataBind();

                foreach (Cinta c in listaCintaHasta)
                {
                    optionsCin2.Add(c.Orden, c.Color_nombre);
                }
                vista.categFinComp.DataSource = optionsCin2;
                vista.categFinComp.DataTextField = M12_RecursoInterfazPresentador.valueCombo;
                vista.categFinComp.DataValueField = M12_RecursoInterfazPresentador.keyCombo;
                vista.categFinComp.DataBind();

            }
            catch (ExcepcionesSKD.ExceptionSKD ex)
            {
                vista.alertaClase = M12_RecursoInterfazPresentador.alertaError;
                vista.alertaRol = M12_RecursoInterfazPresentador.tipoAlerta;
                vista.alerta = M12_RecursoInterfazPresentador.alertaHtml 
                    + ex.Mensaje + M12_RecursoInterfazPresentador.alertaHtmlFinal;
            }
        
        }

        /// <summary>
        /// Metodo para modificar fechas
        /// </summary>
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

        /// <summary>
        /// Metodo que se encarga del evento del boton para agregar una competencia
        /// </summary>
        /// <returns></returns>
        public void AgregarCompetencia()
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

            laListaDeInputs.Add(vista.latitudComp);
            laListaDeInputs.Add(vista.longitudComp);

            if (vista.inicioComp != "" || vista.finComp != "")
            {
                laListaDeInputs.Add(convertirFecha(vista.inicioComp).ToString());
                laListaDeInputs.Add(convertirFecha(vista.finComp).ToString());
            }
            else
            { 
                laListaDeInputs.Add(vista.inicioComp.ToString());
                laListaDeInputs.Add(vista.finComp.ToString());
            }
            

            laListaDeInputs.Add(vista.edadIniComp);
            laListaDeInputs.Add(vista.edadFinComp);
            laListaDeInputs.Add(vista.categIniComp.Text);
            laListaDeInputs.Add(vista.categIniComp.Text);
            if (vista.categSexoMCompBool == true)
                laListaDeInputs.Add(vista.categSexoMComp);
            if (vista.cateSexoFCompBool == true)
                laListaDeInputs.Add(vista.cateSexoFComp);
            if (vista.statusIniciarCompBool == true)
                laListaDeInputs.Add(vista.statusIniciarComp);
            if (vista.statusEnCursoCompBool == true)
                laListaDeInputs.Add(vista.statusEnCursoComp);
            laListaDeInputs.Add(vista.costoComp);

            expresionesRegInput.Add(vista.nombreComp);
            Regex expresionSQL = new Regex(M12_RecursoInterfazPresentador.expresionSQL);


            if (Validaciones.ValidarCamposVacios(laListaDeInputs))
            {
              Regex rex = new Regex(M12_RecursoInterfazPresentador.expresionNombre);
              if (rex.IsMatch(vista.nombreComp))
              {
                  try
                  {
                      //FabricaEntidades laFabricaEntidades = new FabricaEntidades();
                      //FabricaComandos laFabricaComando = new FabricaComandos();

                      Comando<bool> comandoAgregarCompetencia;

                      DominioSKD.Entidades.Modulo12.Competencia laCompetencia =
                          (DominioSKD.Entidades.Modulo12.Competencia)FabricaEntidades.ObtenerCompetencia();

                      //ARMAR OBJETO COMPETENCIA---->
                      //NOMBRE
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

                          laCompetencia.Organizacion = (Organizacion)FabricaEntidades.ObtenerOrganizacion();
                          //laCompetencia.Organizacion = new Organizacion();
                          laCompetencia.OrganizacionTodas = false;
                          laCompetencia.Organizacion.Nombre = vista.organizacionComp.SelectedItem.Text;
                      }

                      laCompetencia.Categoria =
                          (DominioSKD.Entidades.Modulo12.Categoria)FabricaEntidades.ObtenerCategoria();
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
                      laCompetencia.FechaInicio = convertirFecha(vista.inicioComp);
                      laCompetencia.FechaFin = convertirFecha(vista.finComp);

                      //STATUS
                      if (vista.statusIniciarCompBool == true)
                          laCompetencia.Status = vista.statusIniciarComp;
                      if (vista.statusEnCursoCompBool == true)
                          laCompetencia.Status = vista.statusEnCursoComp;

                      //UBICACION
                      laCompetencia.Ubicacion =
                          (DominioSKD.Entidades.Modulo12.Ubicacion)FabricaEntidades.ObtenerUbicacion();
                      laCompetencia.Ubicacion.Latitud = this.vista.latitudComp;
                      laCompetencia.Ubicacion.Longitud = this.vista.longitudComp;
                      laCompetencia.Ubicacion.Ciudad = "Caracas";
                      laCompetencia.Ubicacion.Estado = "Distrito Capital";
                      laCompetencia.Ubicacion.Direccion = "";

                      //COSTO
                      laCompetencia.Costo = float.Parse(vista.costoComp);

                      //AGREGAR EN LOGICA OBJETO COMPETENCIA
                      comandoAgregarCompetencia = FabricaComandos.ObtenerComandoAgregarCompetencia(laCompetencia);
                      if (comandoAgregarCompetencia.Ejecutar() == true)
                          HttpContext.Current.Response.Redirect(M12_RecursoInterfazPresentador.agregarExito);


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
                  + M12_RecursoInterfazPresentador.nombreInvalido
                  + M12_RecursoInterfazPresentador.alertaHtmlFinal;
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
