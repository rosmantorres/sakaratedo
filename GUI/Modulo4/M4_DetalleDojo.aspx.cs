using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioSKD;
using LogicaNegociosSKD;
using LogicaNegociosSKD.Modulo4;

namespace templateApp.GUI.Modulo4
{
    public partial class M4_DetalleDojo : System.Web.UI.Page
    {
            Dojo elDojo = new Dojo();
            LogicaDojo laLogica = new LogicaDojo();
            public string laLatitud;
            public string laLongitud;

            protected void Page_Load(object sender, EventArgs e)
            {
                ((SKD)Page.Master).IdModulo = "4";
                String detalleString = Request.QueryString["dojoDetalle"];

                if (!IsPostBack) // verificar si la pagina se muestra por primera vez
                {
                    try
                    {

                        elDojo = laLogica.detalleDojoXId(int.Parse(detalleString));
                        this.nombreDojo.Text = elDojo.Nombre_dojo;
                        this.imgDojo.Text = elDojo.Logo_dojo.ToString();
                        this.rifDojo.Text = elDojo.OrgNombre_dojo.ToString();
                        this.telefonoDojo.Text = elDojo.Telefono_dojo.ToString();
                        this.emailDojo.Text = elDojo.Email_dojo.ToString();
                        this.estiloDojo.Text = elDojo.Estilo_dojo.ToString();
                        this.orgDojo.Text = elDojo.OrgNombre_dojo.ToString();
                        if (String.Compare(elDojo.Status_dojo, "True") == 0)
                           this.statusDojo.Text = "Activo";
                        else
                            this.statusDojo.Text = "Inactivo";
                        laLatitud = elDojo.Ubicacion.Latitud;
                        laLongitud = elDojo.Ubicacion.Longitud;
                    }
                    catch (ExcepcionesSKD.ExceptionSKD ex)
                    {
                        throw ex;
                    }
                }
            }
        }
    }