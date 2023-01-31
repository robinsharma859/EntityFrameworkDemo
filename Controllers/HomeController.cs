using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BussinessLayer.BussinessUtil;
using BussinessLayer.Models;

namespace EntityFrameworkDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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
        [HttpGet]
        public ActionResult UserDataGrid()
        {
            CustomerRegistrationUtility customerRegistrationUtility = new CustomerRegistrationUtility();
            return View (customerRegistrationUtility.GetUserInformation());
        }

        [HttpGet]
        public ActionResult LoadCounties()
        {
            CountriesUtility countries = new CountriesUtility();
            var result = countries.LoadCounties();
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var item in result)
            {
                list.Add(new SelectListItem() { Text = item.Value, Value = item.Key.ToString() });
            }
            ViewBag.Countries = list;
          
            list = new List<SelectListItem>();
            foreach (var item in this.Get(2))
            {
                list.Add(new SelectListItem() { Text = item.ToString() });
            }
            ViewBag.State = list;
            
            return View(ViewBag);
        }


        private IEnumerable<string> Get(int id=0)
        {
            CountriesUtility countries = new CountriesUtility();
            var result = countries.LoadStates(id);
            return result.ToList().AsEnumerable();
        }

        [HttpPost]
        public JsonResult GetStates(string id)
        {
            List<SelectListItem> states = new List<SelectListItem>();
            switch (id)
            {
                case "1":
                    states.Add(new SelectListItem { Text = "Select", Value = "0" });
                    states.Add(new SelectListItem { Text = "ANDAMAN & NIKOBAR ISLANDS", Value = "1" });
                    states.Add(new SelectListItem { Text = "ANDHRA PRADESH", Value = "2" });
                    states.Add(new SelectListItem { Text = "ARUNACHAL PRADESH", Value = "3" });
                    states.Add(new SelectListItem { Text = "ASSAM", Value = "4" });
                    states.Add(new SelectListItem { Text = "BIHAR", Value = "5" });
                    states.Add(new SelectListItem { Text = "CHANDIGARH", Value = "6" });
                    states.Add(new SelectListItem { Text = "CHHATTISGARH", Value = "7" });
                    states.Add(new SelectListItem { Text = "DADRA & NAGAR HAVELI", Value = "8" });
                    states.Add(new SelectListItem { Text = "DAMAN & DIU", Value = "9" });
                    states.Add(new SelectListItem { Text = "GOA", Value = "10" });
                    states.Add(new SelectListItem { Text = "GUJARAT", Value = "11" });
                    states.Add(new SelectListItem { Text = "HARYANA", Value = "12" });
                    states.Add(new SelectListItem { Text = "HIMACHAL PRADESH", Value = "13" });
                    states.Add(new SelectListItem { Text = "JAMMU & KASHMIR", Value = "14" });
                    states.Add(new SelectListItem { Text = "JHARKHAND", Value = "15" });
                    states.Add(new SelectListItem { Text = "KARNATAKA", Value = "16" });
                    states.Add(new SelectListItem { Text = "KERALA", Value = "17" });
                    states.Add(new SelectListItem { Text = "LAKSHADWEEP", Value = "18" });
                    states.Add(new SelectListItem { Text = "MADHYA PRADESH", Value = "19" });
                    states.Add(new SelectListItem { Text = "MAHARASHTRA", Value = "20" });
                    states.Add(new SelectListItem { Text = "MANIPUR", Value = "21" });
                    states.Add(new SelectListItem { Text = "MEGHALAYA", Value = "22" });
                    states.Add(new SelectListItem { Text = "MIZORAM", Value = "23" });
                    states.Add(new SelectListItem { Text = "NAGALAND", Value = "24" });
                    states.Add(new SelectListItem { Text = "NCT OF DELHI", Value = "25" });
                    states.Add(new SelectListItem { Text = "ORISSA", Value = "26" });
                    states.Add(new SelectListItem { Text = "PUDUCHERRY", Value = "27" });
                    states.Add(new SelectListItem { Text = "PUNJAB", Value = "28" });
                    states.Add(new SelectListItem { Text = "RAJASTHAN", Value = "29" });
                    states.Add(new SelectListItem { Text = "SIKKIM", Value = "30" });
                    states.Add(new SelectListItem { Text = "TAMIL NADU", Value = "31" });
                    states.Add(new SelectListItem { Text = "TRIPURA", Value = "32" });
                    states.Add(new SelectListItem { Text = "UTTAR PRADESH", Value = "33" });
                    states.Add(new SelectListItem { Text = "UTTARAKHAND", Value = "34" });
                    states.Add(new SelectListItem { Text = "WEST BENGAL", Value = "35" });
                    break;
                case "UK":
                    break;
                case "India":
                    break;
            }
            return Json(new SelectList(states, "Value", "Text"));
        }
    }
}