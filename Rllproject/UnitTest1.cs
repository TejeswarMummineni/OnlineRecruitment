using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BussinessEntites;
using BussinessLogic;
namespace Rllproject
{
    [TestClass]
    public class UnitTest1
    {
      
        [TestMethod]
        public void TestMethod1()
        {
            LoginEntites le = new LoginEntites();
            le.Email = "Mphasis@gmail.com";
            le.Password = "Password";

            LoginBL bL = new LoginBL();
            var res = bL.Loginvalidate(le);
            Assert.AreEqual(3, res);

        }
        [TestMethod]
        public void TestMethod2()
        {
            LoginEntites le = new LoginEntites();
            le.Email = "sarvo@gmail.com";
            le.Password = "1234";

            LoginBL bL = new LoginBL();
            var res = bL.Loginvalidate(le);
            Assert.AreEqual(2, res);

        }
        [TestMethod]
        public void TestMethod3()
        {
            LoginEntites le = new LoginEntites();
            le.Email = "teja@gmail.com";
            le.Password = "Teja12345";

            LoginBL bL = new LoginBL();
            var res = bL.Loginvalidate(le);
            Assert.AreEqual(1, res);
        }

        [TestMethod]
        public void TestMethod4()
        {
            CompanyPortalEntites ce = new CompanyPortalEntites();
            ce.CompanyId = "CMP10003";
            ce.Email = "wipro123@gmail.com";
            ce.Password = "xwipro123";
            ce.CompanyName = "fwipro";
            ce.CompanyDesc = "MNC";
            ce.Location = "banglore";
            ce.Logo = "lglogo.png";

            WelcomeBL rb = new WelcomeBL();
            var res = rb.companyportal(ce);
            Assert.AreEqual(1, res);
        }
            
        [TestMethod]
        public void TestMethod5()
        {
            JobApplicantEntites je = new JobApplicantEntites();
            je.CandidateId = "APP10003";
            je.Name = "AAA";
            je.Dob = DateTime.Parse("2021-01-02");
            je.Phone = "4518522222";
            je.Email = "fun@gmail.com";
            je.Password = "eee";
            je.Gender = Convert.ToBoolean(0);
            je.UniversityName = "mysore";
            je.Location = "banglore";
            je.JobType = "deveoper";
            je.resume = "cer.pdf";
            addapp a = new addapp();
            var res = a.addapplicant(je);
            Assert.AreEqual(1, res);


        }
    }





    
}
