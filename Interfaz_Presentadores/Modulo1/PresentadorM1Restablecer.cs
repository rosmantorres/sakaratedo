using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Threading.Tasks;
using Interfaz_Contratos.Modulo1;
using Interfaz_Presentadores.Master;
using Interfaz_Presentadores.Modulo2;
using LogicaNegociosSKD.Fabrica;
using LogicaNegociosSKD.Comandos.Modulo1;
using DominioSKD.Entidades.Modulo1;
using DominioSKD.Fabrica;

namespace Interfaz_Presentadores.Modulo1
{
    public class PresentadorM1Restablecer
    {
        private IContratoM1Restablecer _iMaster;
        private string IdUser = "";
        private string value;
        private FabricaComandos laFabrica=new FabricaComandos();
        private FabricaEntidades laFabricaE=new FabricaEntidades();
        private Encriptacion cripto = new Encriptacion();
        private ComandoRestablecerContraseña restablecer;
        private ValidacionesM1 validar = new ValidacionesM1();
        private Cuenta cuenta;
        private String des = RecursosInterfazPresentadorM2.claveDES;

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
                string fechaString = HttpContext.Current.Request.QueryString[RecursosInterfazPresentadorM1.variableFecha].ToString();
                fechaString = cripto.DesencriptarCadenaDeCaracteres(fechaString, des);
                DateTime fecha = Convert.ToDateTime(fechaString);
                if ((fecha.Date.Year != fechaActual.Date.Year) ||
                    (fecha.Date.Month != fechaActual.Date.Month) ||
                    (fecha.Date.Day != fechaActual.Date.Day))
                {
                    value = cripto.EncriptarCadenaDeCaracteres
                       (RecursosInterfazPresentadorM1.parametroURLRestablecerCaducado,des);

                    HttpContext.Current.Response.Redirect(RecursosInterfazPresentadorM1.direccionM1_Index + "?"
                       + RecursosInterfazPresentadorM1.tipoInfo + "=" + value);
                }


                string idUsuario = HttpContext.Current.Request.QueryString[RecursosInterfazPresentadorM1.variableRestablecer].ToString();

                idUsuario = cripto.DesencriptarCadenaDeCaracteres(idUsuario,des);
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
                restablecer =(ComandoRestablecerContraseña) laFabrica.ObtenerRestablecerContraseña();
                cuenta = (Cuenta)laFabricaE.ObtenerCuenta_M1();
                if (pass1 != "" && pass1 == pass2
                    && pass1.Length > 7 && IdUser != ""
                    && validar.ValidarCaracteres(pass1))
                {
                    cuenta.Id = int.Parse(IdUser);
                    cuenta.Contrasena = cripto.hash(pass1);
                    restablecer.LaEntidad = cuenta;
                    if (restablecer.Ejecutar())
                    {
                        if (HttpContext.Current.Session[RecursosInterfazMaster.sessionUsuarioID] == null)
                        {
                            value = cripto.EncriptarCadenaDeCaracteres
                               (RecursosInterfazPresentadorM1.parametroURLReestablecerExito, des);
                            HttpContext.Current.Response.Redirect(RecursosInterfazPresentadorM1.direccionM1_Index + "?"
                                + RecursosInterfazPresentadorM1.tipoSucess + "=" + value);
                        }
                        else
                            HttpContext.Current.Response.Redirect(RecursosInterfazMaster.direccionMaster_Inicio);
                    }

                }
                else if (!validar.ValidarCaracteres(pass1))
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
