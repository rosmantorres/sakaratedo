﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using templateApp.GUI.Master;
using DominioSKD;
using LogicaNegociosSKD;
using LogicaNegociosSKD.Modulo7;
using templateApp.GUI.Master;

namespace templateApp.GUI.Modulo7
{
    public partial class M7_ListarOrganizacionYDojo : System.Web.UI.Page
    {
        Persona persona = new Persona();
        Dojo dojo = new Dojo();
        Organizacion organizacion = new Organizacion();
        LogicaOrganizacionYDojo laLogica = new LogicaOrganizacionYDojo();
        

        /// <summary>
        /// Método que se ejecuta al cargar la página
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "7";
            try
            {
                String rolUsuario = Session[RecursosInterfazMaster.sessionRol].ToString();
                Boolean permitido = false;
                List<String> rolesPermitidos = new List<string>
                    (new string[] { "Sistema", "Dojo", "Organización", "Atleta", "Representante", "Atleta(Menor)" });
                foreach (String rol in rolesPermitidos)
                {
                    if (rol == rolUsuario)
                        permitido = true;
                }
                if (permitido)
                {

                    persona = laLogica.obtenerDetallePersona(int.Parse(Session[RecursosInterfazMaster.sessionUsuarioID].ToString()));
                    dojo = laLogica.obtenerDetalleDojo(persona.DojoPersona);
                    organizacion = laLogica.obtenerDetalleOrganizacion(dojo.Organizacion_dojo);
                    this.nombrePersona.Text = persona.Nombre;
                    this.apellidoPersona.Text = persona.Apellido;
                    this.fechaNacimiento.Text = persona.FechaNacimiento.ToShortDateString();
                    this.direccion.Text = persona.Direccion;
                    this.nombreDojo.Text = dojo.Nombre_dojo;
                    this.telefonoDojo.Text = dojo.Telefono_dojo.ToString();
                    this.emailDojo.Text = dojo.Email_dojo;
                    this.ubicacionDojo.Text = dojo.Ubicacion.Direccion;
                    this.nombreOrganizacion.Text = organizacion.Nombre;
                    this.emailOrganizacion.Text = organizacion.Email;
                    this.ubicacionOrganizacion.Text = organizacion.Direccion;
                    
                }
                else
                {
                    Response.Redirect(RecursosInterfazMaster.direccionMaster_Inicio);
                }

            }
            catch (NullReferenceException ex)
            {


            }
        }
    }
}