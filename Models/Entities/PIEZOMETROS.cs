using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AppCuerdasVibrantes.Models.Entities
{
    public class PIEZOMETROS
    {
        [Key]
        [Display(Name = "ID")]
        public int id { get; set; }

        [Display(Name = "Piezometer")]
        public string piezometro { get; set; }

        [Display(Name = "Numero de Serie")]
        public string numero_serie { get; set; }
        [Display(Name = "Modelo")]
        public string modelo { get; set; }

        [Display(Name = "G (kPa/digit)")]
        public decimal g_valor { get; set; }

        [Display(Name = "K (kPa/°C)")]
        public decimal k_valor { get; set; }

        [Display(Name = "Ro digit")]
        public decimal ro_valor { get; set; }

        [Display(Name = "To (°C)")]
        public decimal to_valor { get; set; }

        [Display(Name = "So (kPa)")]
        public decimal so_valor { get; set; }

        [Display(Name = "Northing (m)")]
        public decimal northing { get; set; }
        [Display(Name = "Easting (m)")]
        public decimal easting { get; set; }

        [Display(Name = "Elevation (m)")]
        public decimal elevation { get; set; }

        [Display(Name = "Instrument Tip Elevation (m)")]
        public decimal instrument_tip_elevation { get; set; }

        [Display(Name = "Geomembrane Elevation (m)")]
        public decimal geomembrane_elevation { get; set; }

        [Display(Name = "Estimated data")]
        public decimal estimated_data { get; set; }
        [Display(Name = "Recorded data")]
        public decimal recorded_data { get; set; }
        [Display(Name = "Calculated value")]
        public decimal calculated_value { get; set; }

        [Display(Name = "Estado")]
        public string estado { get; set; }

        [Display(Name = "Usuario")]
        public string usuario { get; set; }

        [Display(Name = "Fecha de Registro")]
        public DateTime fecha_registro { get; set; }

    }
}
