using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using DominioSKD;
using ExcepcionesSKD;
using ExcepcionesSKD.Modulo6;
using DatosSKD.Modulo6;

namespace LogicaNegociosSKD.Modulo6
{
    public class LogicaSolicitudInscripcion
    {

        public static void ProcesarSolicitudInscripcion(NameValueCollection datos)
        {
            SolicitudInscripcionDojo solicitud = new SolicitudInscripcionDojo();
            Persona solicitante = new Persona();
            Correo mail;
            Telefono telf;
            DocumentoIdentidad doc;

            solicitante.Nombre = datos[RecursosLogicaModulo6.Form_Solicitante_Nombre];
            solicitante.Apellido = datos[RecursosLogicaModulo6.Form_Solicitante_Apellido];
            solicitante.Direccion = datos[RecursosLogicaModulo6.From_Solicitante_Direccion];
            solicitante.Alergias = datos[RecursosLogicaModulo6.From_Solicitante_Alergias];
            solicitante.Estatura = Convert.ToDouble(datos[RecursosLogicaModulo6.From_Solicitante_Estatura]);
            solicitante.Peso = Convert.ToDouble(datos[RecursosLogicaModulo6.From_Solicitante_Peso]);
            solicitante.Nacionalidad = datos[RecursosLogicaModulo6.Form_Solicitante_Nacionalidad];
            try
            {
                mail = new Correo(datos[RecursosLogicaModulo6.From_Solicitante_Correo]);
                mail.Primario = true;
                solicitante.agregarEmail(mail);
                telf = new Telefono();
                telf.Numero = datos[RecursosLogicaModulo6.From_Solicitante_Telefono1];
                solicitante.agregarTelefono(telf);
                telf = new Telefono();
                telf.Numero = datos[RecursosLogicaModulo6.From_Solicitante_Telefono2];
                solicitante.agregarTelefono(telf);
            }
            catch (InformacionPersonalInvalidaException e)
            {
                throw new SolicitudException("0", "Error en los datos" + ":" + e.Mensaje, e);
            }
            

            doc = new DocumentoIdentidad();
            // TODO Topo de sedula en formulario
            doc.Tipo = TipoDocumento.Cedula;
            if (datos[RecursosLogicaModulo6.Form_Solicitante_Nacionalidad].Equals("Venezolano"))
                doc.TipoCedula = TipoCedula.Nacional;
            else
                doc.TipoCedula = TipoCedula.Extranjera;
            doc.Numero = Convert.ToInt32(datos[RecursosLogicaModulo6.Form_Solicitante_Numero_ID]);
            solicitante.DocumentoID = doc;

            solicitante.FechaNacimiento = Convert.ToDateTime(datos[RecursosLogicaModulo6.Form_Solicitante_Nacimiento]);

            solicitante.Sexo = BDUsuarios.EnumSexo(datos[RecursosLogicaModulo6.Form_Solicitante_Sexo]);
            solicitante.TipoSangre = BDUsuarios.EnumSangre(datos[RecursosLogicaModulo6.From_Solicitante_Sangre]);

            if (solicitante.Edad < 18)
            {
                Persona representante = new Persona();
                representante.Nombre = datos[RecursosLogicaModulo6.Form_Representante_Nombre];
                representante.Apellido = datos[RecursosLogicaModulo6.Form_Representante_Apellido];
                representante.FechaNacimiento = Convert.ToDateTime(datos[RecursosLogicaModulo6.Form_Representante_Nacimiento]);
                representante.Nacionalidad = datos[RecursosLogicaModulo6.Form_Solicitante_Nacionalidad];

                doc = new DocumentoIdentidad();
                // TODO Topo de sedula en formulario
                doc.Tipo = TipoDocumento.Cedula;
                if (datos[RecursosLogicaModulo6.Form_Representante_Nacionalidad].Equals("Venezolano"))
                    doc.TipoCedula = TipoCedula.Nacional;
                else
                    doc.TipoCedula = TipoCedula.Extranjera;
                doc.Numero = Convert.ToInt32(datos[RecursosLogicaModulo6.Form_Representante_Numero_ID]);
                representante.DocumentoID = doc;
                representante.Sexo = BDUsuarios.EnumSexo(datos[RecursosLogicaModulo6.Form_Representante_Sexo]);
                try
                {
                    mail = new Correo(datos[RecursosLogicaModulo6.Form_Representante_Correo]);
                    mail.Primario = true;
                    representante.agregarEmail(mail);
                    telf = new Telefono();
                    telf.Numero = datos[RecursosLogicaModulo6.Form_Representante_Telefono1];
                    representante.agregarTelefono(telf);
                    telf = new Telefono();
                    telf.Numero = datos[RecursosLogicaModulo6.Form_Representante_Telefono2];
                    representante.agregarTelefono(telf);
                }
                catch (InformacionPersonalInvalidaException e)
                {
                    throw new SolicitudException("0", "Error en los datos" + ": " + e.Mensaje, e);
                }

                representante.addRepresentado(solicitante);

                try
                {
                    BDUsuarios.GuardarDatosDeRepresentante(representante);
                }
                catch (ExceptionSKDConexionBD e)
                {
                    throw new SolicitudException("0","Error en la Base de datos.", e);
                }
                catch (ParametroInvalidoException e)
                {
                    throw new SolicitudException("0","Error en la Base de datos.", e);
                }
            }
            else
            {
                Persona contacto = new Persona();

                contacto.Nombre = datos[RecursosLogicaModulo6.Form_Contacto_Nombre];
                contacto.Apellido = datos[RecursosLogicaModulo6.Form_Contacto_Apellido];

                contacto.Sexo = BDUsuarios.EnumSexo(datos[RecursosLogicaModulo6.Form_Contacto_Sexo]);
                try
                {
                    mail = new Correo(datos[RecursosLogicaModulo6.Form_Contacto_Correo]);
                    mail.Primario = true;
                    contacto.agregarEmail(mail);
                    telf = new Telefono();
                    telf.Numero = datos[RecursosLogicaModulo6.Form_Contacto_Telefono1];
                    contacto.agregarTelefono(telf);
                    telf = new Telefono();
                    telf.Numero = datos[RecursosLogicaModulo6.Form_Contacto_Telefono2];
                    contacto.agregarTelefono(telf);
                }
                catch (InformacionPersonalInvalidaException e)
                {
                    throw new SolicitudException(e.Mensaje, e);
                }

                solicitante.ContactoEmergencia = contacto;

                BDUsuarios.GuardarDatosDePersona(solicitante);
            }

            solicitud.Solicitante = solicitante;
            solicitud.Dojo = new Dojo();
            solicitud.Dojo.Id_dojo = Convert.ToInt32(datos[RecursosLogicaModulo6.Form_Dojo_ID]);
            try
            {
                BDSolicitudInscripcion.GuardarSolicitud(solicitud);
            }
            catch (ExceptionSKDConexionBD e)
            {
                throw new SolicitudException("Error en la Base de datos.", e);
            }
            catch (ParametroInvalidoException e)
            {
                throw new SolicitudException("Error en la Base de datos.", e);
            }
        }

    }
}
