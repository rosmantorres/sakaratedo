﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegociosSKD.Modulo14
{
    public class LogicaDiseño
    {
        private DatosSKD.Modulo14.BDDiseño datos = new DatosSKD.Modulo14.BDDiseño();
        private DominioSKD.Diseño diseñoPlanilla;

        public Boolean AgregarDiseño(DominioSKD.Diseño diseño, DominioSKD.Planilla planilla)
        {
            diseño.Base64Encode();
            return  datos.GuardarDiseñoBD(diseño, planilla);
        }

        public DominioSKD.Diseño ConsultarDiseño(int planilla)
        {
            try
            {
                diseñoPlanilla = datos.ConsultarDiseño(planilla);
                diseñoPlanilla.Contenido = ReemplazarElementos(diseñoPlanilla.Contenido);
                return diseñoPlanilla;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        public DominioSKD.Diseño ConsultarDiseñoPuro(int planilla)
        {
            return diseñoPlanilla = datos.ConsultarDiseño(planilla);
        }
   
        public string ReemplazarElementos(string info)
        {
            info = info.Replace("$per_imagen", "<img src='img/perfil.jpg' Height='80' Width='90'/>");
            info = info.Replace("$per_nombre", "María");
            info = info.Replace("$per_apellido","Vargas");
            info = info.Replace("$per_tipo_doc_id", "Cedula");
            info = info.Replace("$per_nacionalidad", "Venezolana");
            info = info.Replace("$per_num_doc_id", "22768304");
            info = info.Replace("$per_direccion", "Caracas");
            info = info.Replace("$per_sexo", "Femenino");
            info = info.Replace("$per_fecha_nacimiento", "30/03/1993");

            info = info.Replace("$doj_nombre", "Dojo Soduko");
            info = info.Replace("$doj_telefono", "0212 263 7898");
            info = info.Replace("$doj_rif", "L369229-j");
            info = info.Replace("$doj_email", "sudoku@gmail.com");

            info = info.Replace("$sol_pla_fecha_creacion",DateTime.Now.ToString());
            info = info.Replace("$sol_pla_fecha_retiro", DateTime.Now.AddDays(2).ToString());
            info = info.Replace("$sol_pla_fecha_reincorporacion", DateTime.Now.AddDays(8).ToString());
            info = info.Replace("$sol_pla_motivo", "No puedo ir, porque no me da la gana");
            return info;

        }

        public Boolean ModificarDiseño(DominioSKD.Diseño diseño)
        {
            diseño.Base64Encode();
            return datos.ModificarDiseño(diseño);
        }
    }
}
