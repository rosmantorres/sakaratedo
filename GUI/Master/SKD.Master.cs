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
using Interfaz_Contratos;
using Interfaz_Presentadores.Master;

namespace templateApp
{
    public partial class SKD : System.Web.UI.MasterPage, IContratoMasterPage
    {
        private string idModulo;
        private Cuenta userLogin = new Cuenta();
        private string des=RecursosLogicaModulo2.claveDES;
        public AlgoritmoDeEncriptacion cripto=new AlgoritmoDeEncriptacion();
        private string[] rolesUsuario = new string[10];//los roles que el usuario tiene registrado
        private PresentadorMasterPage presentador { get; set;}


        String IContratoMasterPage.MenuSuperiorList {
            get { return menuSuperior.InnerHtml; }
            set { menuSuperior.InnerHtml = value; } 
        }
        String IContratoMasterPage.MenuLateralList
        {
            get { return menuLateral.InnerHtml; }
            set { menuLateral.InnerHtml = value; }
        }
        public String RolEnUso {
            get { return Session[RecursosInterfazMaster.sessionRol].ToString(); }
            set { Session[RecursosInterfazMaster.sessionRol] = value; }
        }     
        public String IdModulo
        {
            get { return idModulo; }
            set { idModulo = value; }
        }
        public String DES
        {
            get { return des; }
            set { des = value; }
        }
        public String RolesList
        {
            get { return Session[RecursosInterfazMaster.sessionRoles].ToString(); }
            set { Session[RecursosInterfazMaster.sessionRoles] = value; }
        }
        public String[] RolesUsuario
        {
            get { return rolesUsuario; }
            set { rolesUsuario = value; }
        }
        public String SessionImagen
        {
            get { return Session[RecursosInterfazMaster.sessionImagen].ToString(); }
            set { Session[RecursosInterfazMaster.sessionImagen] = value; }
        }
        public String SessionUsuarioNombre 
        {
            get { return Session[RecursosInterfazMaster.sessionUsuarioNombre].ToString(); }
            set { Session[RecursosInterfazMaster.sessionUsuarioNombre] = value; }
        }
        public String SessionNombreCompleto
        {
            get { return Session[RecursosInterfazMaster.sessionUsuarioNombre].ToString(); }
            set { Session[RecursosInterfazMaster.sessionUsuarioNombre] = value; }
        }

        public void cargarMenus()
        {
            //presentador.validarPermiso();
            //presentador.ValidarSesion();
            presentador.CargarMenuSuperior();
            presentador.CargarMenuLateral();
        }
        public SKD()
        {
            presentador = new PresentadorMasterPage(this);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                    presentador = new PresentadorMasterPage(this);
                    cargarMenus();
                    asignarUsuario();
            }
            catch (NullReferenceException ex)
            {

                Response.Redirect(RecursosInterfazModulo1.direccionM1_Index);
            }
            catch (Exception ex)
            {

            }
        }
        public void imagenSet(String imagen)
        {
            if (imagen == "")
            {
                imagen = "../../dist/img/AvatarSKD.jpg";
            }
            imageUsuario.Src = imagen;
            imageTag.Src = imagen;
        }

        /// <summary>
        /// Se realizan la asignacion de los datos de usuario a la plantilla (nombre,apellido, roles etc)
        /// </summary>
        protected void asignarUsuario()
        {
            
            string imagen = Session[RecursosInterfazMaster.sessionImagen].ToString();
            imagenSet(imagen);
          

            userName.InnerText = (string)Session[RecursosInterfazMaster.sessionUsuarioNombre];
            userTag.InnerText = (string)Session[RecursosInterfazMaster.sessionNombreCompleto] ;
            string[] roles = Session[RecursosInterfazMaster.sessionRoles].ToString().Split(char.Parse(RecursosInterfazMaster.splitRoles));
            int cont = 0;
            foreach (string perfil in roles)
            {
                rolesUsuario[cont] = perfil;
                cont++;
            }
            if (Request.QueryString[RecursosInterfazMaster.sessionRol] == RecursosInterfazMaster.sessionLogout)
                logout();

                string rol = cripto.DesencriptarCadenaDeCaracteres
                    (Request.QueryString[RecursosInterfazMaster.sessionRol], RecursosLogicaModulo2.claveDES);


                if (rol != null)
                {
                    Session[RecursosInterfazMaster.sessionRol] = rol;
                    RolEnUso = rol;
                }

        }


        private Cuenta objetoCuenta()
        {
            Cuenta usuario = new Cuenta();
            PersonaM1 persona = new PersonaM1();
            persona._Nombre = Session[RecursosInterfazMaster.sessionNombreCompleto].ToString().Split(' ')[0];
            persona._Apellido = Session[RecursosInterfazMaster.sessionNombreCompleto].ToString().Split(' ')[1];
            usuario.Nombre_usuario = (string)Session[RecursosInterfazMaster.sessionUsuarioNombre];
            usuario.Imagen = Session[RecursosInterfazMaster.sessionImagen].ToString();
            usuario.PersonaUsuario = persona;

            return usuario;
        }
        
        /// <summary>
        /// Metodo para el boto Sing Out de la tabla de usuario
        /// </summary>
        protected void logout()
        {
            Session.Remove(RecursosInterfazMaster.sessionRol);
            Session.Remove(RecursosInterfazMaster.sessionRoles);
            Session.Remove(RecursosInterfazMaster.sessionUsuarioID);
            Session.Remove(RecursosInterfazMaster.sessionUsuarioNombre);
            Session.Remove(RecursosInterfazMaster.sessionImagen);
            Response.Redirect(RecursosInterfazModulo1.direccionM1_Index);
        }
    }
}