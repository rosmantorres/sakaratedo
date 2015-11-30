using DominioSKD;
using LogicaNegociosSKD.Modulo7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace templateApp.GUI.Modulo7
{
    public partial class M7_ListarOrganizacionYDojo : System.Web.UI.Page
    {
        #region Atributos
        private Organizacion laOrganizacion = new Organizacion();
        private Dojo elDojo = new Dojo();
        private Persona laPersona = new Persona();
        LogicaOrganizacionYDojo laLogica = new LogicaOrganizacionYDojo();
        #endregion

        /// <summary>
        /// Metodo que se ejecuta al cargar la pagina
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
             ((SKD)Page.Master).IdModulo = "7";

             String detalleString = Request.QueryString["compDetalle"];

             if (!IsPostBack) // verificar si la pagina se muestra por primera vez
             {
                 try
                 {

                     laPersona = laLogica.obtenerDetallePersona();
                     this.nombreAtleta.Text = laPersona.Nombre;
                     this.apellidoAtleta.Text = laPersona.Apellido;
                     this.fechaNac.Text = laPersona.FechaNacimiento.ToShortDateString();
                     this.direccion.Text = laPersona.Direccion;
                     this.dojo.Text = elDojo.Nombre_dojo;
                     this.dojoTlf.Text = elDojo.Telefono_dojo.ToString();
                     this.dojoEmail.Text = elDojo.Email_dojo;
                     this.dojoUbicacion.Text = elDojo.Ubicacion.Direccion;
                     this.organizacion.Text = laOrganizacion.Nombre;
                     this.organizacionTlf.Text = laOrganizacion.Telefono.ToString();
                     this.organizacionEmail.Text = laOrganizacion.Email;
                     this.organizacionUbica.Text = laOrganizacion.Direccion;
                 }
                 catch
                 {
                 }
             }

        }
        
    }
}