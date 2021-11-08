using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AppCuerdasVibrantes.Models.Entities
{
    public class PIEZOMETROS_REPORTES_EXCEL
    {
        [Key]
        [Display(Name = "ID")]
        public int id { get; set; }
            
        [Display(Name = "Piezometer id")]
        public string piezometro_id { get; set; }

        [Display(Name = "Fecha")]
        public string fecha { get; set; }

        [Display(Name = "To (°C)")]
        public string to_valor { get; set; }

        [Display(Name = "Ro digit")]
        public string ro_valor { get; set; }

        [Display(Name = "So (kPa)")]
        public string so_valor { get; set; }

        [Display(Name = "Elevacion superficie (m)")]
        public string elevacion_superficie { get; set; }

        [Display(Name = "Observacion")]
        public string observacion { get; set; }

        [Display(Name = "Archivo")]
        public string archivo_excel { get; set; }

        [Display(Name = "Usuario")]
        public string usuario { get; set; }

        [Display(Name = "Fecha de Carga")]
        public DateTime fecha_carga { get; set; }       


    }
}
