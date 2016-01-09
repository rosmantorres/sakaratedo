using DominioSKD;
using LogicaNegociosSKD.Modulo11;
using LogicaNegociosSKD.Modulo9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace templateApp.GUI.Modulo11
{
    public partial class M11_ModificarResultadoCompetencia : System.Web.UI.Page
    {
        Evento evento = new Evento();
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "11";
            String success = Request.QueryString["eliminacionSuccess"];
            if (success != null)
            {
                if (success.Equals("1"))
                {
                    alert.Attributes["class"] = "alert alert-success alert-dismissible";
                    alert.Attributes["role"] = "alert";
                    alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Resultado modificado exitosamente</div>";
                }
            }

            if (!IsPostBack)
            {
                String idEvento = Request.QueryString[M11_RecursosInterfaz.Modificar];
                String tipo = Request.QueryString[M11_RecursosInterfaz.Tipo];
                Session["M11_IdEvento"] = 3;
                Session["M11_tipo"] = "Evento";

                if (Session["M11_tipo"].Equals(M11_RecursosInterfaz.Evento))
                {
                    LogicaEvento logicaEvento = new LogicaEvento();
                    evento = logicaEvento.ConsultarEvento(Session["M11_IdEvento"].ToString());
                    fechaEvento.Text = evento.Horario.FechaInicio.ToShortDateString();
                    nombreEvento.Text = evento.Nombre;
                    lEspecialidad.Visible = false;
                    comboEspecialidad.Visible = false;
                    llenarComboCategoria(LogicaResultado.listaCategoriasEvento(Session["M11_IdEvento"].ToString()));
                }
                else if (Session["M11_tipo"].Equals(M11_RecursosInterfaz.Competencia))
                {
                    lEspecialidad.Visible = true;
                    comboEspecialidad.Visible = true;
                }

            }
        }

        protected void bModificar_Click(object sender, EventArgs e)
        {
            if (Session["M11_tipo"].Equals(M11_RecursosInterfaz.Evento))
            {
                string texto = dataTable.Text;
                string[] split = texto.Split(new string[] { M11_RecursosInterfaz.parametroSplit1, M11_RecursosInterfaz.parametroSplit2, M11_RecursosInterfaz.parametroSplit3 },
                                 StringSplitOptions.RemoveEmptyEntries);
            }
            else if (Session["M11_tipo"].Equals(M11_RecursosInterfaz.Competencia))
            {

            }
        }

        protected void bCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("M11_ListarResultadoCompetencia.aspx");
        }

        protected void comboEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void comboCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataTable.Text = " ";
            if (Session["M11_tipo"].Equals(M11_RecursosInterfaz.Evento))
            {
                Evento evento = new Evento();
                evento.Id_evento = Convert.ToInt32(Session["M11_IdEvento"].ToString());
                Categoria categoria = new Categoria();
                categoria.Id_categoria = Convert.ToInt32(((DropDownList)sender).SelectedItem.Value);
                evento.Categoria = categoria;

                #region Carga de tabla de Atletas que compiten en un Evento Ascenso
                try
                {
                    List<Inscripcion> inscripciones = LogicaResultado.listaAtletasEnCategoriaYAscenso(evento);
                    foreach (Inscripcion inscripcion in inscripciones)
                    {
                        string aprobado = "";

                        if (inscripcion.ResAscenso.ElementAt(0).Aprobado.Equals("S"))
                        {
                            aprobado = "Aprobado";
                        }
                        else if (inscripcion.ResAscenso.ElementAt(0).Aprobado.Equals("N"))
                        {
                            aprobado = "No Aprobado";
                        }


                        this.dataTable.Text += M11_RecursosInterfaz.AbrirTR;
                        this.dataTable.Text += M11_RecursosInterfaz.AbrirTD + inscripcion.Persona.Nombre + " " + inscripcion.Persona.Apellido + M11_RecursosInterfaz.CerrarTD;
                        this.dataTable.Text += M11_RecursosInterfaz.AbrirTD;
                        this.dataTable.Text += M11_RecursosInterfaz.InputTextAbrir + aprobado + M11_RecursosInterfaz.InputTextCerrar;
                        this.dataTable.Text += M11_RecursosInterfaz.CerrarTD;
                        this.dataTable.Text += M11_RecursosInterfaz.CerrarTR;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                #endregion

            }
            else if (Session["M11_tipo"].Equals(M11_RecursosInterfaz.Competencia))
            {

            }
        }

        private void llenarComboCategoria(List<Categoria> lista)
        {
            Dictionary<int, string> listaCategoria = new Dictionary<int, string>();
            foreach (Categoria categoria in lista)
            {
                string nombre = " ";
                if (categoria.Id_categoria.Equals(0))
                {
                    nombre = M11_RecursosInterfaz.SeleccionarCategoria;
                }
                else
                {
                    nombre = categoria.Edad_inicial.ToString() + " a " + categoria.Edad_final.ToString() + " años " + categoria.Cinta_inicial + " - " + categoria.Cinta_final + " " + categoria.Sexo;
                }
                listaCategoria.Add(categoria.Id_categoria, nombre);
            }
            comboCategoria.DataSource = listaCategoria;
            comboCategoria.DataTextField = M11_RecursosInterfaz.Value;
            comboCategoria.DataValueField = M11_RecursosInterfaz.Key;
            comboCategoria.DataBind();
        }

        protected void RenderDinamicInput()
        {
            DropDownList drop = new DropDownList();
            drop.SelectedIndexChanged += new EventHandler(dropdown_SelectedIndexChanged);

        }

        protected void dropdown_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}