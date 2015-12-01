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
                    Response.Redirect(RecursosInterfazModulo1.direccionM1_Index + "?"
                       + RecursosInterfazModulo1.tipoErr + "=" +
                       RecursosInterfazModulo1.logErrRestablecer);


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
                if (pass1 != "" && pass1 == pass2 && pass1.Length > 7 && IdUser != "")
                {
                    if (Restablecer.restablecerContrasena(IdUser, pass1))
                        Response.Redirect(RecursosInterfazModulo1.direccionM1_Index + "?"
                            + RecursosInterfazModulo1.tipoSucess + "=" +
                            RecursosInterfazModulo1.parametroURLReestablecerExito);
                }
               
            }
            catch (Exception ex)
            {
               //imprimirMensajePorPantallaCnERR
            }
        }
      
    }
}