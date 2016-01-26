﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaz_Contratos.Modulo4
{
    /// <summary>
    /// Firma de Métodos que deben ser implementados en el 
    /// presentador del LitarDojo 
    /// </summary>
    public interface IContratoListarDojos
    {
        string Success { get; set; }
        string DetalleString { get; set; }
        string EliminarString { get; set; }
        string Cabecera { get; set; }
        string LaTabla { get; set; }
        string alertaClase { set; }
        string alertaRol { set; }
        string alerta { set; }
    }
}
