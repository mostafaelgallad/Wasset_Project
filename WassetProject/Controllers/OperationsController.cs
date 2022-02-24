using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using WassetPortal_DAL.Models;

namespace WassetPortal.Controllers
{
    public class OperationsController : Controller
    {
        private WassetPortalDBEntities db = new WassetPortalDBEntities();
        // GET: Operations
        public ActionResult Index()
        {
            ViewBag.Fk_Hospital_ID = new SelectList(db.Hospitals, "HospitalID", "HospitalNameAr");
            return View();
        }


        [HttpPost]
        public string UploadFile()
        {
            try
            {
                var file = Request.Files;
                if (file.Count > 0)
                {
                    if (!Directory.Exists(Server.MapPath("~/Uploads")))
                    {
                        Directory.CreateDirectory(Server.MapPath("~/Uploads"));
                    }
                    file[0].SaveAs(Server.MapPath("~/Uploads/") + file[0].FileName);
                    return file[0].FileName;
                }
                else
                {
                    return "failed";
                }
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

        public DataTable ReadExcelFile(string path, string sheetName = "Sheet1")
        {
            using (OleDbConnection conn = new OleDbConnection())
            {
                DataTable dt = new DataTable();
                string Import_FileName = path;
                string fileExtension = Path.GetExtension(Import_FileName);
                if (fileExtension == ".xls")
                    conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Import_FileName + ";" + "Extended Properties='Excel 8.0;HDR=YES;'";
                if (fileExtension == ".xlsx")
                    conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Import_FileName + ";" + "Extended Properties='Excel 12.0 Xml;HDR=YES;'";
                using (OleDbCommand comm = new OleDbCommand())
                {
                    comm.CommandText = "Select * from [" + sheetName + "$A2:end]";
                    comm.Connection = conn;
                    using (OleDbDataAdapter da = new OleDbDataAdapter())
                    {
                        da.SelectCommand = comm;
                        da.Fill(dt);
                    }
                }
                bool flag = false;
                for (int i = 0; i <= dt.Columns.Count; i++)
                {
                    try
                    {
                        if (dt.Columns[i].ColumnName.Trim() == "CASE")
                            flag = true;
                        if (flag && dt.Columns[i].ColumnName.Trim() != "CASE")
                        {
                            dt.Columns.RemoveAt(i);
                            i = i - 1;
                        }
                    }
                    catch (Exception)
                    {
                        break;
                    }
                }
                dt.Columns.RemoveAt(0);
                dt.Columns["ID/IQAMA"].ColumnName = "ID_IQAMA";
                dt.Columns["CASE "].ColumnName = "_CASE";
                dt.Columns["HESN NO#"].ColumnName = "HESN_NO";
                dt = dt.Rows.Cast<DataRow>()
                            .Where(row => !row.ItemArray.All(
                                field => field is DBNull ||
                                string.IsNullOrWhiteSpace(field as string)
                                )).CopyToDataTable();
                return dt;
            }
        }

        public ActionResult RenderExcelData(string fileName)
        {
            var dt = ReadExcelFile(Server.MapPath("~/Uploads/") + fileName);
            if (dt != null)
            {
                var res = JsonConvert.SerializeObject(dt);
                return Json(new { Result = res, success = true }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult InsertExcelData(string Patients, int? testsIDs)
        {

            //var commandText = "exec USP_InsertPatientInfo @PatientsInfo";
            //var name = new SqlParameter("@PatientsInfo", dt);
            //name.TypeName = "dbo.PatientInfo";
            //db.Database.ExecuteSqlCommand(commandText, name);
            //string table = JsonConvert.SerializeObject(dt);
            return Json(new { Success = true }, JsonRequestBehavior.AllowGet);
        }

    }
}