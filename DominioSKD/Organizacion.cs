﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioSKD
{
    public class Organizacion
    {
        private int id_organizacion;
        private String nombre;
        private String direccion;
        private int telefono;
        private String email;
        private String estado;
        private String estilo;

        public int Id_organizacion
        {
            get { return id_organizacion; }
            set { id_organizacion = value; }
        }

        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public String Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public int Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        public String Email
        {
            get { return email; }
            set { email = value; }
        }

        public String Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public String Estilo
        {
            get { return estilo; }
            set { estilo = value; }
        }



        public Organizacion(int elId, String elNombre)
        {
            id_organizacion = elId;
            nombre = elNombre;
        }

        public Organizacion(String elNombre)
        {
            nombre = elNombre;
        }

        public Organizacion()
        {
            id_organizacion = 0;
            nombre = "";
            direccion = "";
            telefono = 0;
            email = "";
            estado = "";
            estilo = "";
        }

        public Organizacion(int elId, String elNombre, String laDireccion, int elTelefono, String elEmail, String elEstado, String elEstilo)
        {
            id_organizacion = elId;
            nombre = elNombre;
            direccion = laDireccion;
            telefono = elTelefono;
            email = elEmail;
            estado = elEstado;
            estilo = elEstilo;

        }

        public Organizacion(String elNombre, String laDireccion, int elTelefono, String elEmail, String elEstado, String elEstilo)
        {
            nombre = elNombre;
            direccion = laDireccion;
            telefono = elTelefono;
            email = elEmail;
            estado = elEstado;
            estilo = elEstilo;
        }


    }
}