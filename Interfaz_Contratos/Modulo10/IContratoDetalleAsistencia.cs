﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Interfaz_Contratos.Modulo10
{
    public interface IContratoDetalleAsistencia
    {
        TextBox fechaEvento { set; }

        TextBox nombreEvento { set; }

        ListBox noAsistieron { set; }

        ListBox asistieron { set; }
    }
}
