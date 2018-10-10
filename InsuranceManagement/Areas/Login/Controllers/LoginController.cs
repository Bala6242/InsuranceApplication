using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace InsuranceManagement.Areas.Login.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login/Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(InsuranceManagement.Areas.Login.Models.Login objLogin)
        {
            if(objLogin.UserName=="Member1" && objLogin.Password=="member@123")
            {
                return View("LoginSuccess");
            }
            else
            {
                ViewBag.Message = "Invalid Cridentials";
                return View("Login");
            }
            
        }
    }
}