using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using templateApp.GUI.Master;
using templateApp.GUI.Modulo1;
using DominioSKD;
using LogicaNegociosSKD.Modulo2;
using Interfaz_Contratos.Master;
using Interfaz_Presentadores.Master;

namespace templateApp
{
    public partial class SKD : System.Web.UI.MasterPage, IContratoMasterPage
    {
        private string idModulo;
        private Cuenta userLogin = new Cuenta();
        private string[] rolesUsuario = new string[10];//los roles que el usuario tiene registrado
        private PresentadorMasterPage presentador { get; set;}

        Cuenta IContratoMasterPage.UserLogin
        {
            get { return userLogin; }
            set { userLogin = value; }
        }
        String IContratoMasterPage.MenuSuperiorEtq {
            get { return menuSuperior.InnerHtml; }
            set { menuSuperior.InnerHtml = value; } 
        }
        String IContratoMasterPage.MenuLateralEtq
        {
            get { return menuLateral.InnerHtml; }
            set { menuLateral.InnerHtml = value; }
        }
        String IContratoMasterPage.RolesEtq{
            get { return rolesList.InnerHtml;}
            set { rolesList.InnerHtml = value; }

        }
        String IContratoMasterPage.ImagenUsuarioEtq
        {
            get { return imageUsuario.Src; }
            set { imageUsuario.Src = value; }
        }
        String IContratoMasterPage.ImagenTagEtq
        {
            get { return imageTag.Src; }
            set { imageTag.Src = value; }

        }
         String IContratoMasterPage.NombreEtq
         {
             get { return userName.InnerText; }
             set { userName.InnerText= value; }

         }
         String IContratoMasterPage.NombreTagEtq
         {
             get { return userTag.InnerText; }
             set { userTag.InnerText = value; }

         }
         public String IdModulo
        {
            get { return idModulo; }
            set { idModulo = value; }
        }

         String[] IContratoMasterPage.RolesUsuario
        {
            get { return rolesUsuario; }
            set { rolesUsuario = value; }
        }
         String IContratoMasterPage.LogoutEtq
         {
             get { return LogOut.InnerHtml; }
             set { LogOut.InnerHtml = value; }
         }




        public void cargarMenus()
        {

            presentador.validarSesion();
            presentador.asignarUsuario();
            presentador.CargarMenuSuperior();
            presentador.CargarMenuLateral();
            presentador.CargarRoles();
            
            
        }
        public SKD()
        {
           presentador = new PresentadorMasterPage(this);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    presentador = new PresentadorMasterPage(this);
                    cargarMenus();
                }
            }
            catch (NullReferenceException ex)
            {

                Response.Redirect(RecursosInterfazModulo1.direccionM1_Index);
            }
            catch (Exception ex)
            {

            }
        }
      
    }
}