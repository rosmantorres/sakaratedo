using DominioSKD;
using DominioSKD.Entidades.Modulo11;
using Interfaz_Contratos.Modulo11;
using Interfaz_Presentadores.Modulo11;
using LogicaNegociosSKD.Modulo10;
using LogicaNegociosSKD.Modulo11;
using LogicaNegociosSKD.Modulo9;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace templateApp.GUI.Modulo11
{
    public partial class M11_ModificarResultadoCompetencia : System.Web.UI.Page, IContratoModificarResultadoCompetencia
    {
        PresentadorModificarResultado presentador;
        public M11_ModificarResultadoCompetencia()
        {
            this.presentador = new PresentadorModificarResultado(this);
        }

        #region Contrato
        public TextBox Fecha
        {
            get
            {
                return fechaEvento;
            }
            set
            {
                fechaEvento = value;
            }
        }

        public TextBox Nombre
        {
            get
            {
                return nombreEvento;
            }
            set
            {
                nombreEvento = value;
            }
        }

        public DropDownList ComboEspecialidad
        {
            get
            {
                return comboEspecialidad;
            }
            set
            {
                comboEspecialidad = value;
            }
        }

        public DropDownList ComboCategoria
        {
            get
            {
                return comboCategoria;
            }
            set
            {
                comboCategoria = value;
            }
        }

        public Literal TablaAscenso
        {
            get
            {
                return dataTable;
            }
            set
            {
                dataTable = value;
            }
        }

        public Literal TablaKata
        {
            get
            {
                return dataTable2;
            }
            set
            {
                dataTable2 = value;
            }
        }

        public Literal TablaKumite
        {
            get
            {
                return dataTable3;
            }
            set
            {
                dataTable3 = value;
            }
        }

        public bool LEspecialidad
        {
            get
            {
                return lEspecialidad.Visible;
            }
            set
            {
                lEspecialidad.Visible = value;
            }
        }

        public LinkButton Boton
        {
            get
            {
                return bModificar;
            }
            set
            {
                bModificar = value;
            }
        }

        public LinkButton BotonKata
        {
            get
            {
                return bModificarKata;
            }
            set
            {
                bModificarKata = value;
            }
        }

        public LinkButton BotonKumite
        {
            get
            {
                return bModificarKumite;
            }
            set
            {
                bModificarKumite = value;
            }
        }

        public LinkButton BotonAmbos
        {
            get
            {
                return bModificarAmbas;
            }
            set
            {
                bModificarAmbas = value;
            }
        }
        public HiddenField Resultado1
        {
            get
            {
                return rvalue;
            }
            set
            {
                rvalue = value;
            }
        }

        public HiddenField Resultado2
        {
            get
            {
                return rvalue2;
            }
            set
            {
                rvalue2 = value;
            }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "11";
            if (!IsPostBack)
            {
                Session[M11_RecursoInterfaz.IdEvento] = HttpContext.Current.Request.QueryString[M11_RecursoInterfaz.Modificar]; ;
                Session[M11_RecursoInterfaz.TipoEvento] = HttpContext.Current.Request.QueryString[M11_RecursoInterfaz.Tipo]; ;
                presentador.CargarVentana(Session[M11_RecursoInterfaz.IdEvento].ToString(), Session[M11_RecursoInterfaz.TipoEvento].ToString());
            }
        }

        protected void bModificar_Click(object sender, EventArgs e)
        {
            if (Session[M11_RecursoInterfaz.TipoEvento].Equals(M11_RecursoInterfaz.Evento))
            {
                #region Modificar Examen de Ascenso
                List<ValorEvento> valores = JsonConvert.DeserializeObject<List<ValorEvento>>(rvalue.Value);
                bool respuesta = presentador.BModificar_Click(Session[M11_RecursoInterfaz.IdEvento].ToString(), Session[M11_RecursoInterfaz.CategoriaEvento].ToString(), valores);
                if (respuesta.Equals(true))
                {
                    Response.Redirect(M11_RecursoInterfaz.ResultadoModificadoExito);
                }
                else if (respuesta.Equals(false))
                {
                    Response.Redirect(M11_RecursoInterfaz.ResultadoModificadoError);
                }
                #endregion
            }
        }

        protected void bCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect(presentador.RedireccionarListarAsistenciaEvento());
        }

        protected void comboEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session[M11_RecursoInterfaz.EspecialidadEvento] = ((DropDownList)sender).SelectedItem.Value;
            presentador.CargarComboCategoria_LuegoDeEspecialidad(Session[M11_RecursoInterfaz.IdEvento].ToString(), Session[M11_RecursoInterfaz.EspecialidadEvento].ToString());
        }

        protected void comboCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session[M11_RecursoInterfaz.CategoriaEvento] = ((DropDownList)sender).SelectedItem.Value;
            if (Session[M11_RecursoInterfaz.TipoEvento].Equals(M11_RecursoInterfaz.Evento))
            {
                Session[M11_RecursoInterfaz.EspecialidadEvento] = "";
            }
            presentador.CargarTablas_LuegoDeCategoria(Session[M11_RecursoInterfaz.IdEvento].ToString(), Session[M11_RecursoInterfaz.TipoEvento].ToString(), Session[M11_RecursoInterfaz.EspecialidadEvento].ToString(), Session[M11_RecursoInterfaz.CategoriaEvento].ToString());
        }

        protected void bModificarKata_Click(object sender, EventArgs e)
        {
            if (Session[M11_RecursoInterfaz.TipoEvento].Equals(M11_RecursoInterfaz.Competencia))
            {
                if (Session[M11_RecursoInterfaz.EspecialidadEvento].ToString().Equals(M11_RecursoInterfaz.especialidadKata))
                {
                    #region Modificar Competencia tipo kata
                    List<ValorKataKumite> valores = JsonConvert.DeserializeObject<List<ValorKataKumite>>(rvalue.Value);
                    bool resultado = presentador.BModificarKata_Click(Session[M11_RecursoInterfaz.IdEvento].ToString(), Session[M11_RecursoInterfaz.CategoriaEvento].ToString(), Session[M11_RecursoInterfaz.EspecialidadEvento].ToString(), valores);
                    if (resultado.Equals(true))
                    {
                        Response.Redirect(M11_RecursoInterfaz.ResultadoKataModificadoExito);
                    }
                    else if (resultado.Equals(false))
                    {
                        Response.Redirect(M11_RecursoInterfaz.ResultadoKataModificadoError);
                    }
                    #endregion
                }
            }
        }

        protected void bModificarKumite_Click(object sender, EventArgs e)
        {
            if (Session[M11_RecursoInterfaz.TipoEvento].Equals(M11_RecursoInterfaz.Competencia))
            {
                if (Session[M11_RecursoInterfaz.EspecialidadEvento].ToString().Equals(M11_RecursoInterfaz.especialidadKumite))
                {
                    #region Modificar Competencia tipo kumite
                    List<ValorKataKumite> valores = JsonConvert.DeserializeObject<List<ValorKataKumite>>(rvalue2.Value);
                    bool resultado = presentador.BModificarKumite_Click(Session[M11_RecursoInterfaz.IdEvento].ToString(), Session[M11_RecursoInterfaz.CategoriaEvento].ToString(), Session[M11_RecursoInterfaz.EspecialidadEvento].ToString(), valores);
                    if (resultado.Equals(true))
                    {
                        Response.Redirect(M11_RecursoInterfaz.ResultadoKumiteModificadoExito);
                    }
                    else if (resultado.Equals(false))
                    {
                        Response.Redirect(M11_RecursoInterfaz.ResultadoKumiteModificadoError);
                    }
                    #endregion
                }
            }
        }

        protected void bModificarAmbas_Click(object sender, EventArgs e)
        {
            if (Session[M11_RecursoInterfaz.TipoEvento].Equals(M11_RecursoInterfaz.Competencia))
            {
                if (Session[M11_RecursoInterfaz.EspecialidadEvento].ToString().Equals(M11_RecursoInterfaz.especialidadAmbos))
                {
                    #region Modificar Competencia tipo Kata y Kumite (Ambos)
                    List<ValorKataKumite> valores = JsonConvert.DeserializeObject<List<ValorKataKumite>>(rvalue.Value);
                    List<ValorKataKumite> valores2 = JsonConvert.DeserializeObject<List<ValorKataKumite>>(rvalue2.Value);
                    bool resultado = presentador.BModificarAmbos_Click(Session[M11_RecursoInterfaz.IdEvento].ToString(), Session[M11_RecursoInterfaz.CategoriaEvento].ToString(), Session[M11_RecursoInterfaz.EspecialidadEvento].ToString(), valores, valores2);
                    if (resultado.Equals(true))
                    {
                        Response.Redirect(M11_RecursoInterfaz.ResultadoAmbosModificadoExito);
                    }
                    else if (resultado.Equals(false))
                    {
                        Response.Redirect(M11_RecursoInterfaz.ResultadoAmbosModificadoError);
                    }
                    #endregion
                }
            }
        }
    }
}