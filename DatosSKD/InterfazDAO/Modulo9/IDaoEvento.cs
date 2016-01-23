﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;

namespace DatosSKD.InterfazDAO.Modulo9
{
    public interface IDaoEvento : IDao<Entidad, bool, Entidad>
    {
        
        bool CrearEventoConTipo(Entidad eventoParametro);
       
        bool ModificarEventoConTipo(Entidad eventoParametro);
        List<Entidad> ListarEventos(int idPersona);
        List<Entidad> ListarTiposEventos();
        List<Entidad> ListarHorarios();
        List<Entidad> EventosPorFecha(String fechaInicio, String fechaFin);
        List<Entidad> ListarHorariosAscensos();
        List<Entidad> AcsensosPorFecha(String fechaInicio, String fechaFin);

    }
}
