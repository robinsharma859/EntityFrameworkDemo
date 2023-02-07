using BussinessLayer.BussinessUtil;
using BussinessLayer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EntityFrameworkDemo.Controllers
{
    [Authorize]
    public class ProfileController : BaseController
    {
        // GET: Profile
        private UploadPicture UploadPicture;
        private CustomerRegistrationUtility customerRegistration;
        public ProfileController()
        {
            UploadPicture = new UploadPicture();
            customerRegistration = new CustomerRegistrationUtility();
        }
        
        [HttpGet]
        public ActionResult UploadImage()
        {
        
            ViewBag.Data = UploadPicture;
            return View(ViewBag.Data);
        }

        [HttpPost]
        public ActionResult UploadImage([Bind(Exclude = "ImageId")] UploadPicture uploadPicture)
        {
            if (ModelState.IsValid)
            {
                customerRegistration.UploadImage(uploadPicture);

            }
            return View(uploadPicture);
        }

        [HttpGet]
        public ActionResult FetchDetails()
        {
            customerRegistration = new CustomerRegistrationUtility();
            ViewBag.Records = customerRegistration.GetFiles();
            var data = customerRegistration.GetProduct();

            List<DataPoint> dataPoints = new List<DataPoint>();

            foreach (KeyValuePair<string,int> item in data as Dictionary<string, int>)
            {
                dataPoints.Add(new DataPoint(item.Key, item.Value));
            }
            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

            return View();
        }  
    
        public FileResult DownloadImage(string ImageName)
        {
            string fullPath = Path.Combine(Server.MapPath("~/Files"), ImageName);
            string extension = ImageName.Split('.')[1];
            string contentType = this.GetfileContent(extension.ToLower());
            return  File(fullPath, contentType,ImageName);
          
        }

        private string GetfileContent(string fileType)
        {
            var data = new Dictionary<string, string>()
            {
                {
                    "png","image//png"
                },
                {
                    "gif","image//gif"
                },
                {
                    "jpeg","image//jpeg"
                }
            };
            return data[fileType];
        }
    }
}