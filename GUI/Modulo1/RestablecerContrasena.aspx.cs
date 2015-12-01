using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaNegociosSKD.Modulo1;
using LogicaNegociosSKD.Modulo2;

namespace templateApp.GUI.Modulo1
{
    public partial class RestablecerContraseña : System.Web.UI.Page
    {
        
        string IdUser = "";
        string value;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

              

                DateTime fechaActual = DateTime.Now;
                string fechaString = Request.QueryString[RecursosLogicaModulo1.variableFecha].ToString();
                fechaString = AlgoritmoDeEncriptacion.DesencriptarCadenaDeCaracteres(fechaString,
                    RecursosLogicaModulo2.claveDES);
                DateTime fecha = Convert.ToDateTime(fechaString);
                if ((fecha.Date.Year != fechaActual.Date.Year) ||
                    (fecha.Date.Month != fechaActual.Date.Month) ||
                    (fecha.Date.Day != fechaActual.Date.Day))
                {
                     value=AlgoritmoDeEncriptacion.EncriptarCadenaDeCaracteres
                        (RecursosInterfazModulo1.parametroURLRestablecerCaducado, RecursosLogicaModulo2.claveDES);

                    Response.Redirect(RecursosInterfazModulo1.direccionM1_Index + "?"
                       + RecursosInterfazModulo1.tipoInfo + "=" +value);
                }


                string idUsuario = Request.QueryString[RecursosLogicaModulo1.variableRestablecer].ToString();
                
                idUsuario = AlgoritmoDeEncriptacion.DesencriptarCadenaDeCaracteres(idUsuario, RecursosLogicaModulo2.claveDES);
                IdUser = idUsuario;
            }
            catch (NullReferenceException ex)
            {
            }
        }
        public void redireccionarInicio(object sender, EventArgs e)
        {
            try
            {
                string pass1 = password3.Value;
                string pass2 = password4.Value;
                logicaRestablecer Restablecer = new logicaRestablecer();
                if (pass1 != "" && pass1 == pass2
                    && pass1.Length > 7 && IdUser != ""
                    && Restablecer.ValidarCaracteres(pass1))
                {

                    if (Restablecer.restablecerContrasena(IdUser, pass1))
                    {
                        value = AlgoritmoDeEncriptacion.EncriptarCadenaDeCaracteres
                           (RecursosInterfazModulo1.parametroURLReestablecerExito, RecursosLogicaModulo2.claveDES);
                        Response.Redirect(RecursosInterfazModulo1.direccionM1_Index + "?"
                            + RecursosInterfazModulo1.tipoSucess + "=" + value);
                    }

                }
                else if (!Restablecer.ValidarCaracteres(pass1))
                {
                    warningCaracteres.Visible = true;
                    warningCaracteres.InnerText = RecursosInterfazModulo1.logCaracterInvalidos;
                    infoRestablecer.Visible = false;
                }
                else
                {
                    infoRestablecer.Visible = true;
                    warningCaracteres.Visible = false;
                    warningCaracteres.InnerText = "";

                }
               
            }
            catch (Exception ex)
            {
               //imprimirMensajePorPantallaCnERR
            }
        }
      
    }
}