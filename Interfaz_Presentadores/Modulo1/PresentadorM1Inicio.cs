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
    public class PresentadorM1Inicio
    {
        private IContratoM1Inicio _iMaster;
        private String QuerySuccess;
        private String QueryInfo;
        private String QueryError;
        private String QueryWarning;
        public AlgoritmoDeEncriptacion cripto = new AlgoritmoDeEncriptacion();
        private string des = RecursosLogicaModulo2.claveDES;

        public PresentadorM1Inicio(IContratoM1Inicio iMaster)
        {
           _iMaster = iMaster;
        }

        public void Inicio()
        {
            if (HttpContext.Current.Session[RecursosInterfazMaster.sessionUsuarioID] == null)
            {
                _iMaster.ErrorLogin = false;
                _iMaster.WarningLog = false;
                _iMaster.InfoLog = false;
                _iMaster.SuccessLog = false;

                QuerySuccess = HttpContext.Current.Request.QueryString[RecursosInterfazPresentadorM1.tipoSucess];
                QueryInfo = HttpContext.Current.Request.QueryString[RecursosInterfazPresentadorM1.tipoInfo];
                QueryError = HttpContext.Current.Request.QueryString[RecursosInterfazPresentadorM1.tipoErrMalicioso];
                string sessionRequest;



                if ((QueryInfo != null))
                {
                    sessionRequest =
                   cripto.DesencriptarCadenaDeCaracteres
                   (QueryInfo, RecursosLogicaModulo2.claveDES);

                    if (sessionRequest == RecursosInterfazPresentadorM1.parametroURLCorreoEnviado)
                        mensajeLogin(RecursosInterfazPresentadorM1.logInfo, RecursosInterfazPresentadorM1.tipoInfo);

                    else if (sessionRequest == RecursosInterfazPresentadorM1.parametroURLRestablecerCaducado)
                        mensajeLogin(RecursosInterfazPresentadorM1.logErrRestablecer,RecursosInterfazPresentadorM1.tipoWarning);
                    else
                        _iMaster.WarningLog= false;
                }
                if (QuerySuccess != null)
                {
                    sessionRequest = cripto.DesencriptarCadenaDeCaracteres
                     (QuerySuccess, RecursosLogicaModulo2.claveDES);
                    if (sessionRequest == RecursosInterfazPresentadorM1.parametroURLReestablecerExito)
                        mensajeLogin(RecursosInterfazPresentadorM1.logSuccess, RecursosInterfazPresentadorM1.tipoSucess);
                    else
                        _iMaster.SuccessLog = false;
                }
                if (QueryError == "input_malicioso")
                    mensajeLogin(RecursosInterfazPresentadorM1.logCadenaMaliciosa, RecursosInterfazPresentadorM1.tipoErr);
            }
            else
                HttpContext.Current.Response.Redirect(RecursosInterfazMaster.direccionMaster_Inicio);
        }

        /// <summary>
        /// Metodo que Vuelve visible y no visible los mensajes en el login
        /// </summary>
        /// <param name="success">mensaje de exito: Verde</param>
        /// <param name="info">mensaje de informacion: Azul</param>
        /// <param name="warning">Mensaje de alerta: amarillo</param>
        /// <param name="error">Mensaje de error: rojo</param>
        /// <param name="mensaje">Mensaje a mostrar por pantalla</param>
        public void mensajeVisible(bool success, bool info, bool warning, bool error, string mensaje)
        {
            _iMaster.SuccessLog = success;
            _iMaster.WarningLog = warning;
            _iMaster.ErrorLogin = error;
            _iMaster.InfoLog = info;

            if (success)
                _iMaster.SuccessLogText = mensaje;
            else if (info)
                _iMaster.InfoLogText = mensaje;
            else if (warning)
                _iMaster.WarningLogText = mensaje;
            else if (error)
                _iMaster.ErrorLoginText = mensaje;

        }

        /// <summary>
        /// Metodo para Establecer un mensaje de alerta en el login
        /// </summary>
        /// <param name="visible">Si queremos que sea visible</param>
        /// <param name="mensaje">Mensaje que aparecerá en la alerta</param>
        /// <param name="tipo">stirng Error;Warning;Info;Sucess</param>
        public void mensajeLogin(string mensaje, string tipo)
        {
            switch (tipo)
            {
                case "Error": mensajeVisible(false, false, false, true, mensaje); break;
                case "Warning": mensajeVisible(false, false, true, false, mensaje); break;
                case "Info": mensajeVisible(false, true, false, false, mensaje); break;
                case "Success": mensajeVisible(true, false, false, false, mensaje); break;
            }
        }



        /// <summary>
        /// Metodo para el envio de correo electrónico 
        /// </summary>
        public void EnviarCorreo()
        {
            String CorreoDestino = _iMaster.RestablecerCorreoEtq;
            try
            {
                new logicaLogin().EnviarCorreo(CorreoDestino);
                string value = cripto.EncriptarCadenaDeCaracteres
                 (RecursosInterfazPresentadorM1.parametroURLCorreoEnviado, RecursosLogicaModulo2.claveDES);

                HttpContext.Current.Response.Redirect(RecursosInterfazPresentadorM1.direccionM1_Index + RecursosInterfazPresentadorM1.signoPregunta
                    + RecursosInterfazPresentadorM1.tipoInfo + RecursosInterfazPresentadorM1.signoIgual +
                    value);
            }
            catch (Exception e)
            {
                mensajeLogin(e.Message, RecursosInterfazPresentadorM1.tipoErr);
            }
            finally
            {
                _iMaster.RestablecerCorreoEtq = "";
            }


        }
        /// <summary>
        /// Metodo que valida si la clave y nombre de usuario introducidos son validos y procede a inicias sesión
        /// </summary>
        public void consultarUsuario()
        {
            try
            {
                string correo = _iMaster.UserNameEtq;
                string clave = _iMaster.PasswordEtq;
                string[] Respuesta = new logicaLogin().iniciarSesion(correo, clave);
                if (Respuesta != null)
                {
                    HttpContext.Current.Session[RecursosInterfazMaster.sessionRol] = Respuesta[3];
                    HttpContext.Current.Session[RecursosInterfazMaster.sessionUsuarioNombre] = Respuesta[1];
                    HttpContext.Current.Session[RecursosInterfazMaster.sessionRoles] = Respuesta[2];
                    HttpContext.Current.Session[RecursosInterfazMaster.sessionUsuarioID] = Respuesta[0];
                    HttpContext.Current.Session[RecursosInterfazMaster.sessionImagen] = Respuesta[4];
                    HttpContext.Current.Session[RecursosInterfazMaster.sessionNombreCompleto] = Respuesta[5];
                    HttpContext.Current.Response.Redirect(RecursosInterfazMaster.direccionMaster_Inicio);
                    mensajeLogin(RecursosInterfazPresentadorM1.logErr, RecursosInterfazPresentadorM1.tipoErr);
                }
                else
                    mensajeLogin(RecursosInterfazPresentadorM1.logErr, RecursosInterfazPresentadorM1.tipoErr);
            }
            catch (Exception ex)
            {
                mensajeLogin(ex.Message, RecursosInterfazPresentadorM1.tipoErr);
            }
        }

        public void ValidarUsuario()
        {

            List<String> campos = new List<String>();
            campos.Add(_iMaster.UserNameEtq);
            campos.Add(_iMaster.PasswordEtq);
            logicaLogin validarLogin = new logicaLogin();
            if (validarLogin.ValidarCamposVacios(campos))
            {
                if (validarLogin.ValidarCaracteres(_iMaster.UserNameEtq, true) &&
                   validarLogin.ValidarCaracteres(_iMaster.PasswordEtq, false))
                    consultarUsuario();
                else
                    mensajeLogin(RecursosInterfazPresentadorM1.logCaracterInvalidos, RecursosInterfazPresentadorM1.tipoErr);
            }
        }

    }
}
