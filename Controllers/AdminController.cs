using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Topicos.Models;
using System.Data.SqlClient;

namespace Topicos.Controllers
{
    public class AdminController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        // GET: Admin
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        void connectionString()
        {
            con.ConnectionString = "data source = den1.mssql7.gear.host; user id = pizzadeprizza; password = Os36P?-0gUm4";
            //con.ConnectionString = "data source=DESKTOP-5K8EOFN;Trusted_Connection=True;initial catalog=PIZZADEPRIZZA";
        }
        [HttpPost]
        public ActionResult Verify(Account adm)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            //com.CommandText = "SELECT * FROM LOGIN1 WHERE usuario ='" + adm.usuario + "' AND contra='" + adm.contra + "'";
            com.CommandText = "SELECT * FROM LOGIN1 WHERE usuario ='" + adm.usuario + "' AND contra='" + adm.contra + "'AND tipousuario='1'";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                //agregar la vista que se creara en la carpeta AdminActions de Index
                return RedirectToAction("Index", "AdminActions");
            }
            else
            {
                con.Close();
                return View("Error");
            }
        }
    }
}