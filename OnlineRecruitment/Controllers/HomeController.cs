using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
using BussinessEntites;
using BussinessLogic;
using System.Net;
using System.Net.Mail;
using MimeKit;
using System.IO;

namespace OnlineRecruitment.Controllers
{
    public class HomeController : Controller
    {
        string Email;
        AptitudeBL ba = new AptitudeBL();
        AdminBL ab = new AdminBL();
        ApplicantBL ap = new ApplicantBL();
        WelcomeBL wb = new WelcomeBL();
        CompanyBL cb = new CompanyBL();
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
                return RedirectToAction("ApllicantDashBoard");

            }
            else if (res == 2)
            {
                Session["user"] = log.Email;
                // Session["master"] = "CandidateView";
                  return View("Login", "Applicant");
               // return RedirectToAction("Index");
            }
            else if (res == 3)
            {
                Session["user"] = log.Email;
                //  Session["master"] = "CompanyView";
                 return View("Login", "CompanyView");
               // return RedirectToAction("About");
            }
            else
            {
                ViewData["err"] = "Access Denied!! invalid credentials";
                return View();

            }

        }
      
            public ActionResult Index(string Search, int? page)
        {
      
            var res = wb.Welcomepage(Search);
            return View(res.ToList().ToPagedList(page ?? 1, 1));
            
        }      
        public ActionResult CandidateClick(JobAppliedEntites ja,string Email)
        {
            Email = Session["user"].ToString();
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
        public ActionResult NewRequirment(int? page)
        {
            var res = ab.NewRequirment();
            return View(res.ToList().ToPagedList(page ?? 1, 5));
        }
        public ActionResult PostApprove(NewRequirmentEntites ne)
        {

            var res = ab.PostApprove(ne);
            if (res > 0)
            {
                ViewData["a"] = "Application Approved Sucessfully";
                Response.Redirect("NewRequirment");

            }
            else
            {
                ViewData["a"] = "Invalid Details please Check";
            }
            return View();
        }
        public ActionResult PostReject(NewRequirmentEntites ne)
        {
            var res = ab.PostReject(ne);
            if (res > 0)
            {
                ViewData["a"] = "Application Rejected Sucessfully";
                Response.Redirect("NewRequirment");

            }
            else
            {
                ViewData["a"] = "Invalid Details please Check";
            }
            return View();
        }

       
        public ActionResult Appliedjobs(JobApplicantEntites je, int? page)
        {
            je.Email = Session["user"].ToString();
            var res=ap.Appliedjobs(je);
            return View(res.ToList().ToPagedList(page ?? 1, 5));
        }
        public ActionResult profile(JobApplicantEntites je)
        {
            je.Email = Session["user"].ToString();
            return View();
        }
        
            public ActionResult Gmail(JobApplicantEntites jp)
        {

            ab.Gamil(jp);
            MailMessage mm = new MailMessage();
            MailAddress ma = new MailAddress("tejamummineni25@gmail.com", jp.Email);
            mm.From = ma;
            mm.To.Add((MailAddress)MailboxAddress.Parse(jp.Email));
            mm.Subject = "you are Eligible for Job";
            mm.Body = "Please Take Test https://localhost:44346/Home/AptitudeTest";
            mm.IsBodyHtml = false;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            NetworkCredential nc = new NetworkCredential("tejamummineni25@gmail.com", "Teja5467");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = nc;
            smtp.Send(mm);
            ViewBag.Message = "Mail Has Been Sucessfully Sent";
            return View();
        }
        public ActionResult AptitudeTest()
        {
            
            var a = ba.storedproc();

            return View(a);

            // return View(db.Aptitude());
            // return RedirectToAction("Index");

        }
        [HttpPost]
        public ActionResult AptitudeTest(string marks)
        {
            var b = ba.storedproc();
            AptitudeBL wb = new AptitudeBL();
            Email = Session["user"].ToString();
            // var user = Session["user"].ToString();
            //  var user="linga@gmail.com";
            //    var res = wb.saveresult(Int32.Parse(marks), Email);
            var res = ba.saveresult(Int32.Parse(marks), Email);
            return View(b);

        }
        
        public ActionResult PreviousPost()
        {
            if (Session["user"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult SelectedCandidates(CompanyPortalEntites se,int? page)
        {
            se.Email = Session["user"].ToString();
            var res = cb.SelectCandidate(se);
            return View(res.ToList().ToPagedList(page ?? 1, 2));
            
        }
        public ActionResult Rejectedpost(CompanyPortalEntites re, int? page)
        {
            re.Email = Session["user"].ToString();
            var res = cb.rejectedpost(re);
            return View(res.ToList().ToPagedList(page ?? 1, 2));

        }
        public ActionResult Newreq()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Newreq(NewRequirmentEntites ne)
        {
            var res = cb.Newreq(ne);
            ViewData["a"] = "Posted Sucessfully";
            return View();
        }
        public ActionResult company()
        {
            return View();
        }
        [HttpPost]
        public ActionResult company(CompanyPortalEntites cp, HttpPostedFileBase Logo)

        {
           // if (ModelState.IsValid)
           // {
                string path = Server.MapPath("~/Logo");

                string FileName = Path.GetFileName(Logo.FileName);
                string fullPath = Path.Combine(path, FileName);

                try
                {
                    Logo.SaveAs(fullPath);
                    cp.Logo = fullPath;

                }

                catch (Exception ex)
                {
                    ViewBag.Message = "error!please try again";
                }

                int res = wb.companyportal(cp);
                if (res > 0)
                {
                    ViewData["status"] = "Thanks for Registered with us..!!!";
                }
                else
                {
                    ViewData["status"] = "Something went wrong..!!";
                }
                return View();
           // }
            //else
            //{
                //return View();
            //}
        }
        public ActionResult openacc()
        {
            return View();
        }
        [HttpPost]
        // [ValidateAntiForgeryToken]
        public ActionResult openacc(JobApplicantEntites ap, HttpPostedFileBase resume)
        {
            addapp wd = new addapp();
            if (!(resume.ContentType == "application/pdf"))
            {
                ModelState.AddModelError("customerror", "only .pdf file allowed");
                return View();
            }

            if (ModelState.IsValid)
            {
                string path = Server.MapPath("~/resume");

                string FileName = Path.GetFileName(resume.FileName);
                string fullPath = Path.Combine(path, FileName);
                //path = path + DateTime.Now.ToString("yymmssfff") + FileName;
                try
                {
                    // string FileName = Path.GetFileName(resume.FileName);
                    //string FileName = Guid.NewGuid() + Path.GetExtension(resume.FileName);


                    resume.SaveAs(fullPath);
                    ap.resume = FileName;

                }

                catch (Exception ex)
                {
                    ViewBag.Message = "error!please try again";
                }


                int res = wd.addapplicant(ap);

                if (res > 0)
                {
                    ViewData["status"] = "Thanks for Registered with us..!!!";
                }
                else
                {
                    ViewData["status"] = "Something went wrong..!!";
                }
                return View();
            }
            else
            {
                return View();
            }
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
        public ActionResult Logout()
        {
            Session["user"] = null;
            return RedirectToAction("Login");
        }

    }
}