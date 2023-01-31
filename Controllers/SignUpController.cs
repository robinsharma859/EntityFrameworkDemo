using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BussinessLayer.Models;
using BussinessLayer.Enums;
using BussinessLayer.BussinessUtil;
namespace EntityFrameworkDemo.Controllers
{
    public class SignUpController : BaseController
    {
        private readonly CustomerRegistrationUtility CustomeRegistration;
        public SignUpController()
        {
            CustomeRegistration = new CustomerRegistrationUtility();
        }
        public ActionResult Index()
        {
         
            ViewBag.Data = base.Entities.CustomerLogins;
            return View(ViewBag.Data);
        }

        // GET: SignUp/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SignUp/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SignUp/Create
        [HttpPost]
        public ActionResult Create(ViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CustomeRegistration.SaveDetails(viewModel);
                    RedirectToAction("Index", "Home");
                }
            }
            catch(Exception ex)
            {
                return View("Exception" + ex);
            }
            return View();
        }

        // GET: SignUp/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SignUp/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SignUp/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SignUp/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public JsonResult IsAlreadySigned(string UserEmailId)
        {

            return Json(CustomeRegistration.IsUserExist(UserEmailId), JsonRequestBehavior.AllowGet);

        }
    }
}
