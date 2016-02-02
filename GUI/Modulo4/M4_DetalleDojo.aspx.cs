using Interfaz_Contratos.Modulo4;
using Interfaz_Presentadores.Modulo4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace templateApp.GUI.Modulo4
{
    public partial class M4_DetalleDojo : System.Web.UI.Page, IContratoDetalleDojo
    {
            //Dojo elDojo = new Dojo();
            PresentadorDetallarDojo _presentador;
            //public string laLatitud;
            //public string laLongitud;

            #region Implementacion de Contrato
            /// <summary>
            /// Se implementan todos los metodos que indica el contrato
            /// </summary>
            public string Logo
            {
                set { logDojo.ImageUrl = value; }
            }

            public string Rif
            {
                set { rifDojo.Text = value; }
            }
            public string Nombre
            {
                set { nombreDojo.Text = value; }
            }
            public string Telefono
            {
                set { telefonoDojo.Text = value; }
            }
            public string Email
            {
               set { emailDojo.Text = value; }
            }
            public string StatusAct
            {
                set { statusDojo.Text = value; }
            }
            public string StatusIn
            {
               set { statusDojo.Text = value; }
            }
            public string NombreOrg
            {
                set { orgDojo.Text = value; }
            }
            public string Estilo
            {
                set { estiloDojo.Text = value; }
            }
            public string AlertaClase
            {
                set { alert1.Attributes[M4_RecursoInterfaz.alertClase] = value; }
            }
            public string AlertaRol
            {
                set { alert1.Attributes[M4_RecursoInterfaz.alertRole] = value; }
            }
            public string Alerta
            {
                set { alert1.InnerHtml = value; }
            }
            #endregion


         #region Constructor
        /// <summary>
        /// Es el constructor de la clase M4_AgregarDojo
        /// </summary>
        public M4_DetalleDojo()
		{
			_presentador = new PresentadorDetallarDojo(this);
		}

		#endregion

            protected void Page_Load(object sender, EventArgs e)
            {
                ((SKD)Page.Master).IdModulo = "4";
                String detalleString = Request.QueryString["dojoDetalle"];

                if (!IsPostBack) // verificar si la pagina se muestra por primera vez
                {
                    try
                    {
                        if (detalleString != null)
                        {
                            int idDojo = int.Parse(detalleString.ToString());
                            _presentador.DetalleDojo(idDojo);

                           
                        }// else con el alerta de que el id es null
                    }
                    catch (ExcepcionesSKD.ExceptionSKD ex)
                    {
                        throw ex;
                    }
                }
            }
    }
}