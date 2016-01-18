using System;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using templateApp.GUI.Master;
using templateApp.GUI.Modulo1;
using Interfaz_Contratos.Master;
using Interfaz_Contratos.Modulo2;
using Interfaz_Presentadores.Modulo2;


namespace templateApp.GUI.Modulo2
{
    public partial class M2_Prueba : System.Web.UI.Page, IContratoM2
    {

        
        //public Persona usuario;
        private PresentadorM2 presentador;

        String IContratoM2.ImagenEtqSRC
        {
            get { return imageTag.Src; }
            set {imageTag.Src=value; }
        }
        String IContratoM2.RolesUsuario
        {
            get { return TBodyRoles.InnerHtml; }
            set { TBodyRoles.InnerHtml = value; }
        }
        String IContratoM2.RolSelectEqt
        {
            get { return RolSelect.Value; }
        }

        String IContratoM2.NombreUsuaurioEtq
        {
            set { NombreUsuario.InnerText = value; }
        }
        String IContratoM2.NombreApellidoEtq
        {
            set { NombreUsuario.InnerText = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            IContratoMasterPage _iMaster = ((SKD)Page.Master);
            _iMaster.IdModulo = "2";

            presentador = new PresentadorM2(this);
            presentador.inicio();

        }
        protected void EliminarRol(object sender, EventArgs e)
        {
            presentador.EliminarRol();
        }
        protected void AgregarRol(object sender, EventArgs e)
        {
            presentador.AgregarRol();
        }

    }
}