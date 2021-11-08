using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace AppCuerdasVibrantes.Models.Entities
{
    public class PIEZOMETROS_DETALLE
    {
        [Key]
        [Display(Name = "ID")]
        public int id { get; set; }

        [Display(Name = "Piezometer")]
        public string piezometro { get; set; }

        [Display(Name = "Fecha")]
        public DateTime fecha { get; set; }

        [Display(Name = "T1 (°C)")]
        public decimal to_valor { get; set; }

        [Display(Name = "R1 digit")]
        public decimal ro_valor { get; set; }

        [Display(Name = "S1 (hPa)")]
        public decimal so_valor { get; set; }

        [Display(Name = "S1 (kPa)")]
        public decimal so_valor_kpa { get; set; }

        [Display(Name = "P1 (kPa)")]
        public decimal p_valor_kpa { get; set; }

        [Display(Name = "Piezometric Head(m)")]
        public decimal piezometric_head { get; set; }

        [Display(Name = "Delta H2O")]
        public decimal mh2o { get; set; }

        [Display(Name = "Water Level(m)")]
        public decimal water_level { get; set; }

        [Display(Name = "Fecha Archivo")]
        public DateTime fecha_archivo { get; set; }

        [Display(Name = "Fecha Proceso")]
        public DateTime fecha_proceso { get; set; }

    }
}
