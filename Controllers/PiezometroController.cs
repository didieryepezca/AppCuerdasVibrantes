using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AppCuerdasVibrantes.Models;
using AppCuerdasVibrantes.Models.Entities;

using AppCuerdasVibrantes.Data.DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;

namespace AppCuerdasVibrantes.Controllers
{
    public class PiezometroController : Controller
    {

        private IHostingEnvironment hostingEnv;
        private readonly UserManager<IdentityUser> userManager;


        public PiezometroController(IHostingEnvironment hostingEnv, UserManager<IdentityUser> userManager)
        {
            this.hostingEnv = hostingEnv;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult piezometro_Nuevo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult piezometro_Nuevo(PIEZOMETROS pis)
        {
            var colaborador = userManager.GetUserName(User).ToUpper();

            CuerdasDA da = new CuerdasDA();

            pis.estado = "ACTIVO";
            pis.usuario = colaborador;
            pis.fecha_registro = DateTime.Now;

            var result = da.InsertPiezometro(pis);
            
            if (result > 0)
            {
                ViewBag.exito = "EXITO";

                return View(pis);
                //return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.error = "ERROR";

                return View(pis);
            }            
        }

        public IActionResult VerDetalleHistorico(string piezometro)
        {
            CuerdasDA da = new CuerdasDA();

            var model = da.GetPiezometro(piezometro);

            ViewBag.piezometro = model.piezometro;

            return View(model);
        }

        public List<PIEZOMETROS_DETALLE> FunPiezometroDetalleTabla(string nombre)
        {
            CuerdasDA da = new CuerdasDA();            

            var model = da.GetDetalleHistoricoPiezometro(nombre).ToList();

            return model;

        }

        public IActionResult PiezometricHeadsCharts(DateTime Fecha_Ini, DateTime Fecha_Fin)
        {

            if (Fecha_Ini.Date == Convert.ToDateTime("01/01/0001").Date)
            {
                Fecha_Ini = DateTime.Now.AddMonths(-1);
            }

            if (Fecha_Fin.Date == Convert.ToDateTime("01/01/0001").Date)
            {
                Fecha_Fin = DateTime.Now;
            }

            ViewBag.Fecha_Ini = Fecha_Ini.ToString("yyyy-MM-dd");
            ViewBag.Fecha_Fin = Fecha_Fin.ToString("yyyy-MM-dd");

            return View();
        }
        public IActionResult WaterLevelsCharts(DateTime Fecha_Ini, DateTime Fecha_Fin)
        {
            if (Fecha_Ini.Date == Convert.ToDateTime("01/01/0001").Date)
            {
                Fecha_Ini = DateTime.Now.AddMonths(-1);
            }

            if (Fecha_Fin.Date == Convert.ToDateTime("01/01/0001").Date)
            {
                Fecha_Fin = DateTime.Now;
            }

            ViewBag.Fecha_Ini = Fecha_Ini.ToString("yyyy-MM-dd");
            ViewBag.Fecha_Fin = Fecha_Fin.ToString("yyyy-MM-dd");
            
            return View();
        }


        public List<PIEZOMETROS_DETALLE> FunGraficar(DateTime fecha_inicio, DateTime fecha_fin, string piezometro)
        {
            CuerdasDA da = new CuerdasDA();

            var model = da.ListarDatosToGrafico(fecha_inicio, fecha_fin, piezometro).ToList();

            return model;

        }

        public List<PIEZOMETROS> FunTraerPiezometrosComboCheckBox(string status)
        {
            CuerdasDA da = new CuerdasDA();

            var model = da.GetPiezometrosComboCheckBox(status).ToList();

            return model;

        }


    }
}