using System;
using System.Collections.Generic;
using System.Linq;
//using System.Threading.Tasks;

using System.Data;
//using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

using AppCuerdasVibrantes.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppCuerdasVibrantes.Data.DataAccess
{
    public class CuerdasDA
    {

        public IEnumerable<PIEZOMETROS> GetAll(string piezometro = "", string accion = "")
        {
            var result = new List<PIEZOMETROS>();

            using (var db = new ApplicationDbContext())
            {

                IQueryable<PIEZOMETROS> query = db.PIEZOMETROS;

                result = db.PIEZOMETROS.ToList();

                if (!String.IsNullOrWhiteSpace(accion))
                {
                    result = db.PIEZOMETROS.ToList();
                }

                if (!string.IsNullOrWhiteSpace(piezometro))
                {
                    query = query.Where(item => item.piezometro.Contains(piezometro));

                }
                query = query.OrderBy(c => c.piezometro);

                return query.ToList();

            }
        }

        public int InsertPiezometro(PIEZOMETROS piezometro)
        {
            var result = 0;

            using (var db = new ApplicationDbContext())
            {
                db.Add(piezometro);
                result = db.SaveChanges();
            }
            return result;
        }

        public IEnumerable<ARCHIVOS> ListarArchivos(string name, string accion = "")
        {

            var ana = new List<ARCHIVOS>();

            using (var db = new ApplicationDbContext())
            {
                IQueryable<ARCHIVOS> query = db.ARCHIVOS;

                ana = db.ARCHIVOS.ToList();

                if (!String.IsNullOrWhiteSpace(accion))
                {
                    ana = db.ARCHIVOS.ToList();
                }

                if (!String.IsNullOrWhiteSpace(name))
                {
                    query = query.Where(item => item.nombre_archivo.ToLower().Contains(name));
                }

                query = query.OrderByDescending((item => item.fecha_carga));

                return query.ToList();
            }           

        }

        public int insertArchivo(ARCHIVOS archivo)
        {
            var result = 0;
            using (var db = new ApplicationDbContext())
            {
                db.Add(archivo);
                result = db.SaveChanges();
            }
            return result;//asd
        }


        public int InsertExcelReporte(PIEZOMETROS_REPORTES_EXCEL reporte_excel)
        {
            var result = 0;

            using (var db = new ApplicationDbContext())
            {
                db.Add(reporte_excel);
                result = db.SaveChanges();
            }
            return result;
        }

        public int ActualizarEstadoArchivoProceso(string id_piezometro, string estado)
        {
            var result = 0;

            using (var db = new ApplicationDbContext())
            {
                var pi = db.ARCHIVOS
                        .Where(item => item.nombre_archivo == id_piezometro)
                        .FirstOrDefault();
                pi.estado_archivo = estado;

                result = db.SaveChanges();

            }

            return result;
        }



        public IEnumerable<PIEZOMETROS_REPORTES_EXCEL> ListarDetalleExcelCargado(string name)
        {

            var ana = new List<PIEZOMETROS_REPORTES_EXCEL>();

            using (var db = new ApplicationDbContext())
            {
                IQueryable<PIEZOMETROS_REPORTES_EXCEL> query = db.PIEZOMETROS_REPORTES_EXCEL;

                ana = db.PIEZOMETROS_REPORTES_EXCEL.ToList();                 

                if (!String.IsNullOrWhiteSpace(name))
                {
                    query = query.Where(item => item.archivo_excel == name);
                }

                query = query.OrderBy((item => item.piezometro_id));

                return query.ToList();
            }

        }


        public IEnumerable<PIEZOMETROS_REPORTES_EXCEL> BuscaPiezometroDatosCargados(string piezometro = "", string accion = "")
        {
            var result = new List<PIEZOMETROS_REPORTES_EXCEL>();

            using (var db = new ApplicationDbContext())
            {

                IQueryable<PIEZOMETROS_REPORTES_EXCEL> query = db.PIEZOMETROS_REPORTES_EXCEL;

                result = db.PIEZOMETROS_REPORTES_EXCEL.ToList();

                if (!String.IsNullOrWhiteSpace(accion))
                {
                    result = db.PIEZOMETROS_REPORTES_EXCEL.ToList();
                }

                if (!string.IsNullOrWhiteSpace(piezometro))
                {
                    query = query.Where(item => item.piezometro_id.Contains(piezometro));

                }
                query = query.OrderBy(c => c.piezometro_id);

                return query.ToList();

            }
        }

        public IEnumerable<ARCHIVOS> CheckArchivoDuplicado(string fileuploaded)
        {

            var ana = new List<ARCHIVOS>();
            using (var db = new ApplicationDbContext())
            {
                IQueryable<ARCHIVOS> query = db.ARCHIVOS;

                query = query.Where(item => item.nombre_archivo == fileuploaded);

                ana = query.ToList();
            }
            return ana;
        }


        public String USP_PROCESAR_ARCHIVO(string archivo)
        {
            var result = "OK";

            var db = new ApplicationDbContext();
            try
            {
                using (var command = db.Database.GetDbConnection().CreateCommand())
                {
                    db.Database.SetCommandTimeout(180);
                   
                    command.CommandText = "SP_EXPORT_TOPIT_GENERAL_CALCULOS_GRAFICOS";   
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@file_excel", System.Data.SqlDbType.VarChar));
                    command.Parameters["@file_excel"].Value = archivo;

                    db.Database.OpenConnection();
                    command.ExecuteNonQuery();
                    db.Database.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            return result;
        }


        public int UpdateEstadoArchivo(string archivo, string estado)
        {
            var result = 0;
            using (var db = new ApplicationDbContext())
            {
                var file = db.ARCHIVOS.Where(item => item.nombre_archivo == archivo).FirstOrDefault();

                file.estado_archivo = estado;     

                result = db.SaveChanges(); //devuelve cantidad de registros insertados.
            }
            return result;
        }

        public PIEZOMETROS GetPiezometro(string nombre)
        {
            var result = new PIEZOMETROS();
            {
                using (var db = new ApplicationDbContext())
                {
                    result = db.PIEZOMETROS.Where(item => item.piezometro == nombre).FirstOrDefault();
                }
            }
            return result;
        }




        public IEnumerable<PIEZOMETROS_DETALLE> GetDetalleHistoricoPiezometro(string piezometro_sist = "")
        {
            var result = new List<PIEZOMETROS_DETALLE>();

            using (var db = new ApplicationDbContext())
            {

                IQueryable<PIEZOMETROS_DETALLE> query = db.PIEZOMETROS_DETALLE;        


                if (!string.IsNullOrWhiteSpace(piezometro_sist))
                {
                    query = query.Where(item => item.piezometro == piezometro_sist);
                }

                query = query.OrderBy(item => item.fecha);

                return query.ToList();

            }
        }


        public IEnumerable<PIEZOMETROS_DETALLE> ListarDatosToGrafico(DateTime Fecha_Ini, DateTime Fecha_Fin, string piezometro = "")
        {
            var ana = new List<PIEZOMETROS_DETALLE>();

            using (var db = new ApplicationDbContext())
            {
                IQueryable<PIEZOMETROS_DETALLE> query = db.PIEZOMETROS_DETALLE;

                if (!string.IsNullOrWhiteSpace(piezometro))
                {
                    query = query.Where(item => item.piezometro == piezometro);
                }

                query = query.Where(item => item.fecha.Date >= Fecha_Ini.Date
                && item.fecha.Date <= Fecha_Fin.Date);               

                ana = query.OrderBy(item => item.fecha).ToList();
            }
            return ana;

        }



        public IEnumerable<PIEZOMETROS> GetPiezometrosComboCheckBox(string status)
        {
            var ana = new List<PIEZOMETROS>();

            using (var db = new ApplicationDbContext())
            {
                IQueryable<PIEZOMETROS> query = db.PIEZOMETROS;

                if (!String.IsNullOrWhiteSpace(status))
                {
                    query = query.Where(item => item.estado == status);
                }            

                ana = query.ToList();
            }
            return ana;
        }




    }
}
