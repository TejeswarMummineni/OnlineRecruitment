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
        AdminBL ab = new AdminBL();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginEntites log)
        {

            LoginBL lb = new LoginBL();
            int res = lb.Loginvalidate(log);
            if (res == 1)
            {
                Session["user"] = log.Email;
               
                // Session["master"] = "EmployeeView";
                // return View("Login", "EmployeeView");
                return RedirectToAction("Cantact");

            }
            else if (res == 2)
            {
                Session["user"] = log.Email;
                TempData["a"] = log.Email;
                TempData.Keep();
                // Session["master"] = "CandidateView";
                //  return View("Login", "CandidateView");
                return RedirectToAction("Index");
            }
            else if (res == 3)
            {
                Session["user"] = log.Email;
                //  Session["master"] = "CompanyView";
                // return View("Login", "CompanyView");
                return RedirectToAction("About");
            }
            else
            {
                ViewData["err"] = "Access Denied!! invalid credentials";
                return View();

            }

        }
        public ActionResult Index(string Search, int? page)
        {
            TempData.Keep();
            WelcomeBL wb = new WelcomeBL();
            var res = wb.Welcomepage(Search);
            return View(res.ToList().ToPagedList(page ?? 1, 3));
            
        }

            
        public ActionResult CandidateClick(JobAppliedEntites ja,string Email)
        {
            Email=TempData["a"].ToString();
            TempData.Keep();
            JobAppliedBL jd = new JobAppliedBL();
            var res=jd.CandidateClick(ja, Email);
            if (res > 0)
            {
                ViewData["a"] = "Applied Sucessfully";
                Response.Redirect("Index");

            }
            else
            {
                ViewData["a"] = "You Are Already Exist";
            }
            return View();
        }
        public ActionResult Admin(AdminEntites ae)
        {
            
            ab.Registered(ae);
            return View(ae);
        }
        public ActionResult RegisterUser(string Search, int? page)
        {
            var res = ab.RegisterUser(Search);
            return View(res.ToList().ToPagedList(page ?? 1, 5));
        }
        public ActionResult RegistredCompines(string Search, int? page)
        {
            var res = ab.RegistredCompines(Search);
            return View(res.ToList().ToPagedList(page ?? 1, 5));
        }
        public ActionResult PLacedApplicants( int? page)
        {
            var res = ab.PLacedApplicants();
            return View(res.ToList().ToPagedList(page ?? 1, 5));
        }
        public ActionResult JanuaryMonthApplieds(int? page)
        {
            var res = ab.JanuaryMonthApplieds();
            return View(res.ToList().ToPagedList(page ?? 1, 5));
        }

        public ActionResult TotalApplied(int? page)
        {
            var res = ab.TotalApplied();
            return View(res.ToList().ToPagedList(page ?? 1, 5));
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