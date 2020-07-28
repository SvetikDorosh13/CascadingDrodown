using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CascadingDrodown.Models;
using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CascadingDrodown.Controllers
{
    public class HomeController : Controller
    {
        database_access_layer.db dbop = new database_access_layer.db();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            DataSet ds = dbop.GetCountry();
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new SelectListItem { Text = dr["Country_name"].ToString(), Value = dr["Country_id"].ToString() });
            }
            ViewBag.Counrtylist = list;
            return View();
        }
        public JsonResult GetStatelist(int cid)
        {
            DataSet ds = dbop.GetState(cid);
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new SelectListItem { Text = dr["State_name"].ToString(), Value = dr["State_id"].ToString() });
            }
            return Json(list);
        }
        public JsonResult GetCitylist(int Sid)
        {
            DataSet ds = dbop.GetCity(Sid);
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new SelectListItem { Text = dr["City_name"].ToString(), Value = dr["City_id"].ToString() });
            }
            return Json(list);
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
