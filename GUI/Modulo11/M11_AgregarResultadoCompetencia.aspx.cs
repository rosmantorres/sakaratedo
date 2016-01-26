using DominioSKD;
using DominioSKD.Entidades.Modulo11;
using Interfaz_Contratos.Modulo11;
using Interfaz_Presentadores.Modulo11;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace templateApp.GUI.Modulo11
{
    public partial class M11_AgregarResultadoCompetencia : System.Web.UI.Page, IContratoAgregarResultadoCompetencia
    {
        List<Entidad> horariosEventos = new List<Entidad>();
        PresentadorAgregarResultado presentador;

        public M11_AgregarResultadoCompetencia()
        {
            presentador = new PresentadorAgregarResultado(this);
        }

        #region Contrato
        public Calendar Fecha
        {
            get
            {
                return this.calendar;
            }
            set
            {
                this.calendar = value;
            }
        }

        public DropDownList ComboEvento
        {
            get
            {
                return comboEventos;
            }
            set
            {
                comboEventos = value;
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
                return this.dataTable;
            }
            set
            {
                this.dataTable = value;
            }
        }

        public Literal TablaKata
        {
            get
            {
                return this.dataTable2;
            }
            set
            {
                this.dataTable2 = value;
            }
        }

        public Literal TablaKumite
        {
            get
            {
                return this.dataTable3;
            }
            set
            {
                dataTable3 = value;
            }
        }

        public ListBox Posiciones
        {
            get
            {
                return this.listaGanadores;
            }
            set
            {
                this.listaGanadores = value;
            }
        }

        public string alertaClase
        {
            set { alert.Attributes[M11_RecursoInterfaz.alertClase] = value; }
        }

        public string alertaRol
        {
            set { alert.Attributes[M11_RecursoInterfaz.alertRole] = value; }
        }

        public string alerta
        {
            set { alert.InnerHtml = value; }
        }

        public LinkButton Boton
        {
            get
            {
                return this.bAgregar;
            }
            set
            {
                this.bAgregar = value;
            }
        }

        public LinkButton BotonKata
        {
            get
            {
                return this.bAgregarKata;
            }
            set
            {
                bAgregarKata = value;
            }
        }

        public LinkButton BotonKumite
        {
            get
            {
                return this.bAgregarKumite;
            }
            set
            {
                bAgregarKumite = value;
            }
        }

        public LinkButton BotonAmbos
        {
            get
            {
                return this.bAgregarAmbos;
            }
            set
            {
                this.bAgregarAmbos = value;
            }
        }

        public LinkButton BotonSiguiente
        {
            get
            {
                return this.bSiguiente;
            }
            set
            {
                this.bSiguiente = value;
            }
        }

        public LinkButton BotonSiguienteAmbos
        {
            get
            {
                return this.bSiguienteAmbos;
            }
            set
            {
                this.bSiguienteAmbos = value;
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

        public bool LPosicion
        {
            get
            {
                return this.lPosicion.Visible;
            }
            set
            {
                this.lPosicion.Visible = value;
            }
        }

        public bool DivAlerta
        {
            get
            {
                return alert.Visible;
            }
            set
            {
                alert.Visible = value;
            }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "11";
            horariosEventos = presentador.horarioEventos();
        }

        protected void calendar_DayRender(object sender, DayRenderEventArgs e)
        {
            presentador.RenderCalendario(e, horariosEventos);
        }

        protected void calendar_SelectionChanged(object sender, EventArgs e)
        {
            Session[M11_RecursoInterfaz.FechaEvento] = ((Calendar)sender).SelectedDate.ToString();
            presentador.SeleccionandoElCalendario(Session[M11_RecursoInterfaz.FechaEvento].ToString());
        }

        protected void comboEventos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session[M11_RecursoInterfaz.TipoEvento] = presentador.diccionarioEventos(Session[M11_RecursoInterfaz.FechaEvento].ToString(), sender);
            Session[M11_RecursoInterfaz.IdEvento] = ((DropDownList)sender).SelectedItem.Value;
            presentador.LlenarComboCategoria_o_LlenarComboEspecialidad(Session[M11_RecursoInterfaz.IdEvento].ToString(), Session[M11_RecursoInterfaz.TipoEvento].ToString());
        }

        protected void comboEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session[M11_RecursoInterfaz.EspecialidadEvento] = ((DropDownList)sender).SelectedItem.Value;
            presentador.LLenarComboCategoria_DespuesDeEspecialidad(Session[M11_RecursoInterfaz.IdEvento].ToString(), Session[M11_RecursoInterfaz.EspecialidadEvento].ToString());
        }

        protected void comboCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session[M11_RecursoInterfaz.CategoriaEvento] = ((DropDownList)sender).SelectedItem.Value;
            if (Session[M11_RecursoInterfaz.TipoEvento].Equals(M11_RecursoInterfaz.Evento))
            {
                Session[M11_RecursoInterfaz.EspecialidadEvento] = "";
            }
            string numero = "";
            bool respuesta = presentador.CargarTablas_LuegoDeCategoria(Session[M11_RecursoInterfaz.IdEvento].ToString(), Session[M11_RecursoInterfaz.TipoEvento].ToString(), Session[M11_RecursoInterfaz.EspecialidadEvento].ToString(), Session[M11_RecursoInterfaz.CategoriaEvento].ToString(), numero);
            if (respuesta.Equals(true))
            {
                Session[M11_RecursoInterfaz.RangoEvento] = numero;
            }
        }

        protected void bAgregar_Click(object sender, EventArgs e)
        {
            if (Session[M11_RecursoInterfaz.TipoEvento].Equals(M11_RecursoInterfaz.Evento))
            {
                List<ValorEvento> valores = JsonConvert.DeserializeObject<List<ValorEvento>>(rvalue.Value);
                bool respuesta = presentador.BAgregar_Click(Session[M11_RecursoInterfaz.IdEvento].ToString(), Session[M11_RecursoInterfaz.CategoriaEvento].ToString(), valores);
                if (respuesta.Equals(true))
                {
                    Response.Redirect(M11_RecursoInterfaz.ResultadoAscensoAgregarExito);
                }
                else if (respuesta.Equals(false))
                {
                    Response.Redirect(M11_RecursoInterfaz.ResultadoAscensoAgregarError);
                }
            }
        }

        protected void bCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect(presentador.RedireccionarListarAsistenciaEvento());
        }

        protected void bAgregarKata_Click(object sender, EventArgs e)
        {
            if (Session[M11_RecursoInterfaz.TipoEvento].Equals(M11_RecursoInterfaz.Competencia))
            {
                if (Session[M11_RecursoInterfaz.EspecialidadEvento].ToString().Equals(M11_RecursoInterfaz.especialidadKata))
                {
                    List<ValorKataKumite> valores = JsonConvert.DeserializeObject<List<ValorKataKumite>>(rvalue.Value);
                    bool resultado = presentador.BAgregarKata_Click(Session[M11_RecursoInterfaz.IdEvento].ToString(), Session[M11_RecursoInterfaz.EspecialidadEvento].ToString(), Session[M11_RecursoInterfaz.CategoriaEvento].ToString(), valores);
                    if (resultado.Equals(true))
                    {
                        Response.Redirect(M11_RecursoInterfaz.ResultadoKataAgregarExito);
                    }
                    else if (resultado.Equals(false))
                    {
                        Response.Redirect(M11_RecursoInterfaz.ResultadoKataAgregarError);
                    }
                }
            }
        }

        protected void bAgregarKumite_Click(object sender, EventArgs e)
        {
            if (Session[M11_RecursoInterfaz.TipoEvento].Equals(M11_RecursoInterfaz.Competencia))
            {
                if (Session[M11_RecursoInterfaz.EspecialidadEvento].ToString().Equals("2"))
                {
                    if (Convert.ToInt32(Session[M11_RecursoInterfaz.RangoEvento].ToString()) < 1)
                    {
                        List<ValorKataKumite> valores = JsonConvert.DeserializeObject<List<ValorKataKumite>>(rvalue2.Value);
                        bool resultado = presentador.BAgregarKumite_Click(Session[M11_RecursoInterfaz.IdEvento].ToString(), Session[M11_RecursoInterfaz.EspecialidadEvento].ToString(), Session[M11_RecursoInterfaz.CategoriaEvento].ToString(), valores);
                        if (resultado.Equals(true))
                        {
                            Response.Redirect(M11_RecursoInterfaz.ResultadoKumiteAgregarExito);
                        }
                        else if (resultado.Equals(false))
                        {
                            Response.Redirect(M11_RecursoInterfaz.ResultadoKumiteAgregarError);
                        }
                    }
                }
            }
        }

        protected void bAgregarAmbos_Click(object sender, EventArgs e)
        {
            if (Session[M11_RecursoInterfaz.TipoEvento].Equals(M11_RecursoInterfaz.Competencia))
            {
                if (Session[M11_RecursoInterfaz.EspecialidadEvento].ToString().Equals("3"))
                {
                    if (Convert.ToInt32(Session[M11_RecursoInterfaz.RangoEvento].ToString()) < 1)
                    {
                        List<ValorKataKumite> valores = JsonConvert.DeserializeObject<List<ValorKataKumite>>(rvalue2.Value);
                        bool resultado = presentador.BAgregarKumite_Click(Session[M11_RecursoInterfaz.IdEvento].ToString(), Session[M11_RecursoInterfaz.EspecialidadEvento].ToString(), Session[M11_RecursoInterfaz.CategoriaEvento].ToString(), valores);
                        if (resultado.Equals(true))
                        {
                            Response.Redirect(M11_RecursoInterfaz.ResultadoAmbosAgregarExito);
                        }
                        else if (resultado.Equals(false))
                        {
                            Response.Redirect(M11_RecursoInterfaz.ResultadoAmbosAgregarError);
                        }
                    }
                }
            }
        }

        protected void bSiguiente_Click(object sender, EventArgs e)
        {
            if (Session[M11_RecursoInterfaz.TipoEvento].Equals(M11_RecursoInterfaz.Competencia))
            {
                Session[M11_RecursoInterfaz.RangoEvento] = Convert.ToInt32(Session[M11_RecursoInterfaz.RangoEvento].ToString()) / 2;
                List<ValorKataKumite> valores = JsonConvert.DeserializeObject<List<ValorKataKumite>>(rvalue2.Value);
                string numero = "";
                bool resultado = presentador.CargarTablas_LuegoDeSiguiente(Session[M11_RecursoInterfaz.IdEvento].ToString(), Session[M11_RecursoInterfaz.EspecialidadEvento].ToString(), Session[M11_RecursoInterfaz.CategoriaEvento].ToString(), Session[M11_RecursoInterfaz.RangoEvento].ToString(), valores, numero);
                if (resultado.Equals(true))
                {
                    Session[M11_RecursoInterfaz.RangoEvento] = numero;
                }
            }
        }

        protected void bSiguienteAmbos_Click(object sender, EventArgs e)
        {
            if (Session[M11_RecursoInterfaz.TipoEvento].Equals(M11_RecursoInterfaz.Competencia))
            {
                Session[M11_RecursoInterfaz.RangoEvento] = Convert.ToInt32(Session[M11_RecursoInterfaz.RangoEvento].ToString()) / 2;
                List<ValorKataKumite> valores = JsonConvert.DeserializeObject<List<ValorKataKumite>>(rvalue2.Value);
                List<ValorKataKumite> valores2 = JsonConvert.DeserializeObject<List<ValorKataKumite>>(rvalue.Value);
                string numero = "";
                bool resultado = presentador.CargarTablas_LuegoDeSiguienteAmbos(Session[M11_RecursoInterfaz.IdEvento].ToString(), Session[M11_RecursoInterfaz.EspecialidadEvento].ToString(), Session[M11_RecursoInterfaz.CategoriaEvento].ToString(), Session[M11_RecursoInterfaz.RangoEvento].ToString(), valores, numero, valores2);
                if (resultado.Equals(true))
                {
                    Session[M11_RecursoInterfaz.RangoEvento] = numero;
                }
            }
        }
    }
}