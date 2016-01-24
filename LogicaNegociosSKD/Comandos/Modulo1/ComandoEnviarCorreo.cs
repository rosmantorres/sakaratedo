using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD.Entidades.Modulo1;
using LogicaNegociosSKD.Comandos.Modulo2;
using System.Net;
using System.Net.Mail;

namespace LogicaNegociosSKD.Comandos.Modulo1
{
    public class ComandoEnviarCorreo: Comando<Boolean>
    {
       /// <summary>
       /// Comando para enviar el correo de restauración de contraseña
       /// </summary>
       /// <returns>True: El correo se envio con exito</returns>
        public override Boolean Ejecutar()
        {
            try
            {
              
                MailMessage Mail = new MailMessage();
                SmtpClient SMTP = new SmtpClient();
                Cuenta cta = (Cuenta)LaEntidad;
                PersonaM1 cuenta = cta.PersonaUsuario;


                String mensajeDireccion = RecursosComandoModulo1.lineBreak + cuenta._Descripcion + RecursosComandoModulo1.slashLineBreak;
                Mail.From = new MailAddress(RecursosComandoModulo1.cuentaCorreoSAKARATEDO);
                Mail.To.Add(new MailAddress(cuenta._CorreoElectronico));
                Mail.Body = RecursosComandoModulo1.mensajeSAKARATEDO + mensajeDireccion;
                Mail.BodyEncoding = System.Text.Encoding.UTF8;
                Mail.IsBodyHtml = true;//si queremos que se envie como codigo HTML
                Mail.Subject = RecursosComandoModulo1.asuntoSAKARATEDO;
                Mail.SubjectEncoding = System.Text.Encoding.UTF8;
                //Envia una copia de correo a sakaratedo@
                Mail.Bcc.Add(RecursosComandoModulo1.cuentaCorreoSAKARATEDO);
                //configuracion SMTP
                SMTP.Host = RecursosComandoModulo1.hostSAKARATEDO;
                SMTP.Port = int.Parse(RecursosComandoModulo1.puertoEnvioSAKARATEDO);
                SMTP.Credentials = new NetworkCredential(RecursosComandoModulo1.cuentaCorreoSAKARATEDO, RecursosComandoModulo1.cuentaClaveSAKARATEDO);
                SMTP.EnableSsl = true;
                SMTP.Send(Mail);
                return true;

            }
            catch (Exception e)
            {
                Console.Write(RecursosComandoModulo1.errorGenerico);
                Console.Write(e.StackTrace);
                Console.Write(e.ToString());
                Console.Write(e.Data.ToString());
                Console.Write(e.Message);
                throw e;
            }
        }
    }
}
