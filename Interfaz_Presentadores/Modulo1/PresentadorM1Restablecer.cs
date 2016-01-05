using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Threading.Tasks;
using Interfaz_Contratos.Modulo1;
using Interfaz_Presentadores.Master;
using LogicaNegociosSKD.Modulo2;
using LogicaNegociosSKD.Modulo1;

namespace Interfaz_Presentadores.Modulo1
{
    public class PresentadorM1Restablecer
    {
        private IContratoM1Restablecer _iMaster;
        private AlgoritmoDeEncriptacion cripto = new AlgoritmoDeEncriptacion();
        string IdUser = "";
        string value;

        public PresentadorM1Restablecer(IContratoM1Restablecer iMaster)
        {
            _iMaster=iMaster;
        }

        public void MensajeAlert(Boolean Warning, String WarningText, Boolean Info, String InfoText)
        {
            _iMaster.WarningCaracterEtq = Warning;
            _iMaster.WarningCaracterEtqText = WarningText;
            _iMaster.InfoRestablecerEtq = Info;
            _iMaster.InfoRestablecerEtqText = InfoText;
        }

        public void Inicio()
        {
            try
            {

                if (HttpContext.Current.Request.QueryString[RecursosInterfazPresentadorM1.tipoErrMalicioso] != null
                 && HttpContext.Current.Request.QueryString[RecursosInterfazPresentadorM1.tipoErrMalicioso].ToString() == "input_malicioso")
                {
                    MensajeAlert(true, RecursosInterfazPresentadorM1.logCadenaMaliciosa, false, "");
                }
                else
                {
                    MensajeAlert(false, "", true,RecursosInterfazPresentadorM1.LogInfoRestablecer);
                }
                DateTime fechaActual = DateTime.Now;
                string fechaString = HttpContext.Current.Request.QueryString[RecursosLogicaModulo1.variableFecha].ToString();
                fechaString = cripto.DesencriptarCadenaDeCaracteres(fechaString,RecursosLogicaModulo2.claveDES);
                DateTime fecha = Convert.ToDateTime(fechaString);
                if ((fecha.Date.Year != fechaActual.Date.Year) ||
                    (fecha.Date.Month != fechaActual.Date.Month) ||
                    (fecha.Date.Day != fechaActual.Date.Day))
                {
                    value = cripto.EncriptarCadenaDeCaracteres
                       (RecursosInterfazPresentadorM1.parametroURLRestablecerCaducado, RecursosLogicaModulo2.claveDES);

                    HttpContext.Current.Response.Redirect(RecursosInterfazPresentadorM1.direccionM1_Index + "?"
                       + RecursosInterfazPresentadorM1.tipoInfo + "=" + value);
                }


                string idUsuario = HttpContext.Current.Request.QueryString[RecursosLogicaModulo1.variableRestablecer].ToString();

                idUsuario = cripto.DesencriptarCadenaDeCaracteres(idUsuario, RecursosLogicaModulo2.claveDES);
                IdUser = idUsuario;
            }
            catch (NullReferenceException ex)
            {

            }
        }

        public void RedireccionarInicio()
        {
            try
            {
                string pass1 = _iMaster.ClaveEtq;
                string pass2 = _iMaster.ClaveConfirmacionEtq;
                logicaRestablecer Restablecer = new logicaRestablecer();
                if (pass1 != "" && pass1 == pass2
                    && pass1.Length > 7 && IdUser != ""
                    && Restablecer.ValidarCaracteres(pass1))
                {

                    if (Restablecer.restablecerContrasena(IdUser, pass1))
                    {
                        if (HttpContext.Current.Session[RecursosInterfazMaster.sessionUsuarioID] == null)
                        {
                            value = cripto.EncriptarCadenaDeCaracteres
                               (RecursosInterfazPresentadorM1.parametroURLReestablecerExito, RecursosLogicaModulo2.claveDES);
                            HttpContext.Current.Response.Redirect(RecursosInterfazPresentadorM1.direccionM1_Index + "?"
                                + RecursosInterfazPresentadorM1.tipoSucess + "=" + value);
                        }
                        else
                            HttpContext.Current.Response.Redirect(RecursosInterfazMaster.direccionMaster_Inicio);
                    }

                }
                else if (!Restablecer.ValidarCaracteres(pass1))
                {
                    MensajeAlert(true, RecursosInterfazPresentadorM1.logCaracterInvalidos, false, "");
                }
                else
                {
                    MensajeAlert(false, "", true, RecursosInterfazPresentadorM1.LogInfoRestablecer);

                }

            }
            catch (Exception ex)
            {
                //imprimirMensajePorPantallaCnERR
            }
        }
    }
}
