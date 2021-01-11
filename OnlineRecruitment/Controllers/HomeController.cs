using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
using BussinessEntites;
using BussinessLogic;

namespace OnlineRecruitment.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string Search, int? page)
        {
            WelcomeBL wb = new WelcomeBL();
            var res = wb.Welcomepage(Search);
            return View(res.ToList().ToPagedList(page ?? 1, 3));
            
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}