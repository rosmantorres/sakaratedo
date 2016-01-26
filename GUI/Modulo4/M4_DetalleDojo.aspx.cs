using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioSKD;
using LogicaNegociosSKD;
using LogicaNegociosSKD.Modulo4;
using Interfaz_Presentadores.Modulo4;
using Interfaz_Contratos.Modulo4;

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
            public string logo
            {
                set { logDojo.ImageUrl = value; }
            }

            public string rif
            {
                set { rifDojo.Text = value; }
            }
            public string nombre
            {
                set { nombreDojo.Text = value; }
            }
            public string telefono
            {
                set { telefonoDojo.Text = value; }
            }
            public string email
            {
               set { emailDojo.Text = value; }
            }
            public string statusAct
            {
                set { statusDojo.Text = value; }
            }
            public string statusIn
            {
               set { statusDojo.Text = value; }
            }
            public string nombreOrg
            {
                set { orgDojo.Text = value; }
            }
            public string estilo
            {
                set { estiloDojo.Text = value; }
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