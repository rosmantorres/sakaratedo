﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaz_Contratos.Modulo3
{
    public interface IContratoAgregarOrganizacion
    {
        string obtenerNombreOrg();
        string obtenerEmail();
        string obtenerTelefono();
        string obtenerDireccion();
        string obtenerEstado();
        string obtenerTecnica();
        void alertaCamposVacios();
        void alertaAgregarFallido(ExcepcionesSKD.ExceptionSKD ex);
        void Respuesta();

    }
}
