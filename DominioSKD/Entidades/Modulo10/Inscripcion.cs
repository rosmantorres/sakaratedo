﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioSKD.Entidades.Modulo10
{
    public class Inscripcion : Entidad
    {
        #region Atributos
        private DateTime fecha;
        private Persona persona;
        private DominioSKD.Entidades.Modulo14.SolicitudPlanilla solicitud;
        private DominioSKD.Entidades.Modulo12.Competencia competencia;
        private Evento evento;
        private List<Asistencia> asistencias;
        private List<Entidad> resAscenso;
        private List<Entidad> resKata;
        private List<ResultadoKumite> resKumite;
        #endregion

        #region Constructores
        public Inscripcion(DateTime fecha, Persona persona, Evento evento)
        {
            this.fecha = fecha;
            this.persona = persona;
            this.evento = evento;
            this.competencia = new Modulo12.Competencia();
            this.asistencias = new List<Asistencia>();
            this.resAscenso = new List<Entidad>();
            this.resKata = new List<Entidad>();
            this.resKumite = new List<ResultadoKumite>();

        }
        public Inscripcion(DateTime fecha, Persona persona, DominioSKD.Entidades.Modulo12.Competencia competencia)
        {
            this.fecha = fecha;
            this.persona = persona;
            this.competencia = competencia;
            this.evento = new Evento();
            this.asistencias = new List<Asistencia>();
            this.resAscenso = new List<Entidad>();
            this.resKata = new List<Entidad>();
            this.resKumite = new List<ResultadoKumite>();
        }

        public Inscripcion(DateTime fecha, Persona persona, Evento evento, DominioSKD.Entidades.Modulo14.SolicitudPlanilla solicitud)
        {
            this.fecha = fecha;
            this.persona = persona;
            this.evento = evento;
            this.solicitud = solicitud;
            this.competencia = new Modulo12.Competencia();
            this.asistencias = new List<Asistencia>();
            this.resAscenso = new List<Entidad>();
            this.resKata = new List<Entidad>();
            this.resKumite = new List<ResultadoKumite>();

        }
        public Inscripcion(DateTime fecha, Persona persona, DominioSKD.Entidades.Modulo12.Competencia competencia, DominioSKD.Entidades.Modulo14.SolicitudPlanilla solicitud)
        {
            this.fecha = fecha;
            this.persona = persona;
            this.competencia = competencia;
            this.solicitud = solicitud;
            this.evento = new Evento();
            this.asistencias = new List<Asistencia>();
            this.resAscenso = new List<Entidad>();
            this.resKata = new List<Entidad>();
            this.resKumite = new List<ResultadoKumite>();
        }
        public Inscripcion()
        {
            this.fecha = new DateTime();
            this.persona = new Persona();
            this.competencia = new Modulo12.Competencia();
            this.evento = new Evento();
            this.asistencias = new List<Asistencia>();
            this.resAscenso = new List<Entidad>();
            this.resKata = new List<Entidad>();
            this.resKumite = new List<ResultadoKumite>();
        }
        #endregion

        #region Propiedades
        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        public Persona Persona
        {
            get { return persona; }
            set { persona = value; }
        }
        public DominioSKD.Entidades.Modulo14.SolicitudPlanilla Solicitud
        {
            get { return solicitud; }
            set { solicitud = value; }
        }
        public DominioSKD.Entidades.Modulo12.Competencia Competencia
        {
            get { return competencia; }
            set { competencia = value; }
        }
        public Evento Evento
        {
            get { return evento; }
            set { evento = value; }
        }
        public List<Asistencia> Asistencias
        {
            get { return asistencias; }
            set { asistencias = value; }
        }
        public List<Entidad> ResAscenso
        {
            get { return resAscenso; }
            set { resAscenso = value; }
        }
        public List<Entidad> ResKata
        {
            get { return resKata; }
            set { resKata = value; }
        }
        public List<ResultadoKumite> ResKumite
        {
            get { return resKumite; }
            set { resKumite = value; }
        }
        #endregion
    }
}
