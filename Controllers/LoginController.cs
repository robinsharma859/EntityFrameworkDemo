using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BussinessLayer.Models;
using BussinessLayer.BussinessUtil;
using System.Web.Security;

namespace EntityFrameworkDemo.Controllers
{
    public class LoginController : BaseController
    {
        private LoginUtility LoginUtility;

        public LoginController()
        {
            LoginUtility = new LoginUtility();
            ViewBag.Data = new LoginModel();
        }
        [HttpGet]
        public ActionResult Authenticate()
        {

            RedirectToAction("Authenticate");
            return View(ViewBag.Data);
        }
        [HttpPost]
        
        public ActionResult Authenticate([Bind(Include = "UserName,Password")] LoginModel loginModel)
        {
            
           bool found =  LoginUtility.Authenticate(loginModel);
            if (!found)
            {
                ViewBag.ErrorInvalid = "USer Name and Password does not match";
                return View(ViewBag.Data);
            }
            else
            {
                FormsAuthentication.SetAuthCookie(loginModel.UserName, true);
                return RedirectToAction("Index", "Home");
            }

            return View();
        }
       
    }
}
