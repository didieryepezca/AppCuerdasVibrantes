using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AppCuerdasVibrantes.Models.Entities;

using AppCuerdasVibrantes.Data.DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;

using Microsoft.AspNetCore.Hosting;
using System.IO;
//using ExcelDataReader;

using Excel;
using System.Data;

namespace AppCuerdasVibrantes.Controllers
{
    public class ArchivosController : Controller
    {

        private IHostingEnvironment hostingEnv;
        private readonly UserManager<IdentityUser> userManager;


        public ArchivosController(IHostingEnvironment hostingEnv, UserManager<IdentityUser> userManager)
        {
            this.hostingEnv = hostingEnv;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

      
        [Authorize]
        [HttpGet]
        public IActionResult VerArchivos(string nombre = "", string accion = "")
        {
            CuerdasDA da = new CuerdasDA();            

            string vAccion = "";

            if (!String.IsNullOrWhiteSpace(nombre))
            {
                vAccion = accion;
            }

            var model = da.ListarArchivos(nombre, vAccion);

            return View(model);
        }

        [Authorize]
        public IActionResult ArchivoNuevo()
        {
            var colaborador = userManager.GetUserName(User).ToUpper();

            ViewBag.user = colaborador;




            return View();
        }
       

        [Authorize]
        public IActionResult adjuntarArchivo(ICollection<Microsoft.AspNetCore.Http.IFormFile> files, string user, string obs)
        {
            var colaborador = userManager.GetUserName(User).ToUpper();

            CuerdasDA da = new CuerdasDA();

            ARCHIVOS xfile = new ARCHIVOS();

            var jres = new { msg = "", registros = "" };
            var arch = Request.Form.Files;


            if (arch.Count() == 0)
            {
                jres = new { msg = "Debe seleccionar un archivo excel. ", registros = "" };
                return Json(jres);
            }

            if (String.IsNullOrWhiteSpace(obs))
            {
                jres = new { msg = "El campo descripcion/comentario debe ser llenado.", registros = "" };
                return Json(jres);
            }


            var uploads = Path.Combine(hostingEnv.WebRootPath, "uploads");

            int i = 0;

            //string[] paths = { @"\\172.17.1.66\CarpetaUbicacionDeRed\", "CarpetaNombre" };
            //var uploads = Path.Combine(paths);

            foreach (var file in arch)
            {

                // -----------------------REGISTRO DE ENTIDAD ARCHIVO
                try
                {

                xfile.estado_archivo = "PENDIENTE";
                xfile.nombre_archivo = file.FileName;
                xfile.observaciones = obs;
                xfile.usuario = user;
                xfile.fecha_carga = DateTime.Now;

                var model = da.insertArchivo(xfile);

                    if (model < 0)
                    {
                        jres = new { msg = "No se pudo grabar la información", registros = "" };
                        return Json(jres);
                        //return View();
                    }

                }
                catch (Exception ex)
                {
                    jres = new { msg = "No se pudo grabar la información enlace. " + ex.Message, registros = "" };

                    return Json(jres);
                }
                // -----------------------REGISTRO DE ENTIDAD ARCHIVO



                // -----------------------CREACION Y GUARDADO DE ARCHIVO

                if (file.Length > 0)
                {
                    using (var fileStream = new FileStream(Path.Combine(uploads, file.FileName), FileMode.Create))
                    {

                        file.CopyTo(fileStream);
                        //----
                        IExcelDataReader reader = null;
                        if (file.FileName.EndsWith(".xls"))
                        {
                            reader = ExcelReaderFactory.CreateBinaryReader(fileStream, true);
                        }
                        else if (file.FileName.EndsWith(".xlsx"))
                        {
                            reader = ExcelReaderFactory.CreateOpenXmlReader(fileStream);
                        }
                        else
                        {
                            jres = new { msg = "El archivo selecionado no es un documento Excel.Verifique que la extención del documento sea .XLS o .XLSX", registros = "" };
                            return Json(jres);

                        }

                        reader.IsFirstRowAsColumnNames = true;

                        DataSet resul = reader.AsDataSet(true);

                        foreach (DataTable table in (resul.Tables))
                        {

                            foreach (DataRow dr in table.Rows)
                            {

                                try
                                {
                                    PIEZOMETROS_REPORTES_EXCEL x = new PIEZOMETROS_REPORTES_EXCEL();

                                    //var lon = result.Tables[0].Rows[i]["codigo"].ToString();
                                    //if (lon.Length == 18)
                                    //{
                                    x.piezometro_id = resul.Tables[0].Rows[i]["ID PIEZOMETRO"].ToString();
                                    x.fecha = resul.Tables[0].Rows[i]["FECHA"].ToString(); 
                                    x.to_valor = resul.Tables[0].Rows[i]["T1(oC)"].ToString(); 
                                    x.ro_valor = resul.Tables[0].Rows[i]["R1(Digit)"].ToString();
                                    x.so_valor = resul.Tables[0].Rows[i]["S1(hPa)"].ToString();
                                    x.elevacion_superficie = resul.Tables[0].Rows[i]["Elevacion Superficie"].ToString();
                                    x.observacion = resul.Tables[0].Rows[i]["Observation"].ToString();
                                    x.archivo_excel = file.FileName; //Para ver la data del archivo cargado.
                                    x.usuario = colaborador;
                                    x.fecha_carga = DateTime.Now;
                                                    
                                    //var dat = new CuerdasDA();
                                    var result2 = da.InsertExcelReporte(x);

                                    //---INI--FG
                                    if (result2 == -1)
                                    {
                                        jres = new { msg = "Error al insertar ", registros = "" };
                                        return Json(jres);
                                    }                        
                                    
                                    i++;
                                }
                                catch (Exception ex)
                                {
                                    jres = new { msg = "El formato de una o varias columnas no es el establecido, por favor revisar el Excel." + " Error: " + ex.Message, registros = "" };
                                    return Json(jres);
                                }


                            }
                        }
                        reader.Close();
                    }

                    // -----------------------CREACION Y GUARDADO DE ARCHIVO

                }
                else { 

                    jres = new { msg = "Hubo un error con el archivo", registros = "ERROR" };

                    return Json(jres);
                }
            }

            jres = new { msg = "Archivo subido con exito.", registros = "OK" };

            return Json(jres);
        }

        [Authorize]
        //[HttpGet]
        public IActionResult VerDetalleExcelCargado(string filenombre)
        {
            var colaborador = userManager.GetUserName(User).ToUpper();

            ViewBag.user = colaborador;

            CuerdasDA da = new CuerdasDA();
           
            var model = da.ListarDetalleExcelCargado(filenombre);

            return View(model);
        }


        [Authorize]
        [HttpPost]
        public IActionResult VerDetalleExcelCargado(string piezometer_name, string accion = "")
        {
            var colaborador = userManager.GetUserName(User).ToUpper();

            ViewBag.user = colaborador;

            CuerdasDA da = new CuerdasDA();

            string vAccion = "";

            if (!String.IsNullOrWhiteSpace(accion))
            {
                vAccion = accion;

            }
            var model = da.BuscaPiezometroDatosCargados(piezometer_name, vAccion);

            return View(model);
        }

        public string ComprobarArchivoDuplicado(string fileuploaded)
        {
            CuerdasDA da = new CuerdasDA();

            var model = da.CheckArchivoDuplicado(fileuploaded).Count();
           
            return model.ToString();
        }


        public IActionResult ProcesarArchivo(string archivo)
        {
            CuerdasDA da = new CuerdasDA();

            try
            {
                var process = da.USP_PROCESAR_ARCHIVO(archivo);

                if (process == "OK")
                {
                    da.UpdateEstadoArchivo(archivo, "ACTUALIZADO");

                    ViewBag.successupdate = "EXITO";
                }
                else
                {
                    ViewBag.errorupdate = "Hubo un error al actualizar el archivo" + archivo;
                }

                return Json("OK");
            }

            catch (Exception e)
            {
                ViewBag.error = e;
                return ViewBag.error;
            }            
        }



    }
}