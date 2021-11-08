using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace AppCuerdasVibrantes.Models.Entities
{
    public class PIEZOMETROS_REPORTES_EXCEL_CONVERT
    {        
        [Key]
        [Display(Name = "ID")]
        public int id { get; set; }

        [Display(Name = "Piezometer id")]
        public string piezometro_id { get; set; }

        [Display(Name = "Fecha")]
        public DateTime fecha { get; set; }

        [Display(Name = "To (°C)")]
        public decimal to_valor { get; set; }

        [Display(Name = "Ro digit")]
        public decimal ro_valor { get; set; }

        [Display(Name = "So (kPa)")]
        public decimal so_valor { get; set; }

        [Display(Name = "Archivo")]
        public string archivo_excel { get; set; }

        [Display(Name = "Usuario")]
        public string usuario { get; set; }

        [Display(Name = "Fecha de Carga")]
        public DateTime fecha_carga { get; set; }
    }
}
