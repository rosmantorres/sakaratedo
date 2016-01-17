using DominioSKD;
using DominioSKD.Fabrica;
using ExcepcionesSKD;
using Interfaz_Contratos.Modulo14;
using LogicaNegociosSKD;
using LogicaNegociosSKD.Comandos.Modulo14;
using LogicaNegociosSKD.Fabrica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Interfaz_Presentadores.Modulo14
{
    class PresentadorM14DisenoPlanilla
    {
        private IContratoM14DisenoPlanilla vista;

        public PresentadorM14DisenoPlanilla(IContratoM14DisenoPlanilla vista)
        {
            this.vista = vista;
        }

        public void llenarCombo()
        {

            if (vista.comboDatos.SelectedValue == RecursosPresentadorModulo14.Dojo)
            {
                vista.campos.Text= "";
                vista.campos.Text += RecursosPresentadorModulo14.DojRif;
                vista.campos.Text += RecursosPresentadorModulo14.DojNombre;
                vista.campos.Text += RecursosPresentadorModulo14.DojTlf;
                vista.campos.Text += RecursosPresentadorModulo14.DojEmail;
            }
            else if (vista.comboDatos.SelectedValue == RecursosPresentadorModulo14.Persona)
            {
                vista.campos.Text = "";
                vista.campos.Text += RecursosPresentadorModulo14.PerFechaNac;
                vista.campos.Text += RecursosPresentadorModulo14.PerNumDoc;
                vista.campos.Text += RecursosPresentadorModulo14.PerNombre;
                vista.campos.Text += RecursosPresentadorModulo14.PerApellido;
                vista.campos.Text += RecursosPresentadorModulo14.PerDir;
                vista.campos.Text += RecursosPresentadorModulo14.PerNacionalidad;
                vista.campos.Text += RecursosPresentadorModulo14.PerPeso;
                vista.campos.Text += RecursosPresentadorModulo14.PerEstatura;
                vista.campos.Text += RecursosPresentadorModulo14.PerImagen;
            }
            else if (vista.comboDatos.SelectedValue == RecursosPresentadorModulo14.Evento)
            {
                vista.campos.Text = "";
                vista.campos.Text += "$eve_descripcion<br/>";
                vista.campos.Text += "$eve_nombre<br/>";
                vista.campos.Text += "$eve_costo<br/>";
                vista.campos.Text += "$CATEGORIA_cat<br/>";
                vista.campos.Text += "$HORARIO_hor<br/>";
                vista.campos.Text += "$TIPO_EVENTO<br/>";
            }
            else if (vista.comboDatos.SelectedValue == RecursosPresentadorModulo14.Competencia)
            {
                vista.campos.Text = "";
                vista.campos.Text += "$comp_nombre<br/>";
                vista.campos.Text += "$comp_tipo<br/>";
                vista.campos.Text += "$CATEGORIA_comp<br/>";
                vista.campos.Text += "$comp_fecha_ini<br/>";
                vista.campos.Text += "$comp_fecha_fin<br/>";
                vista.campos.Text += "$comp_costo<br/>";
            }
            else if (vista.comboDatos.SelectedValue == RecursosPresentadorModulo14.Organizacion)
            {
                vista.campos.Text = "";
                vista.campos.Text += "$org_nombre<br/>";
                vista.campos.Text += "$org_direccion<br/>";
                vista.campos.Text += "$org_telefono<br/>";
                vista.campos.Text += "$org_email<br/>";
            }
            else if (vista.comboDatos.SelectedValue == RecursosPresentadorModulo14.Matricula)
            {
                vista.campos.Text = "";
                vista.campos.Text += "$mat_identificador<br/>";
                vista.campos.Text += "$mat_fecha_creacion<br/>";
                vista.campos.Text += "$mat_activa<br/>";
                vista.campos.Text += "$mat_fecha_ultimo_pago<br/>";
                vista.campos.Text += "$mat_precio<br/>";
            }
            else
                vista.campos.Text = "";
        }
    }
}
