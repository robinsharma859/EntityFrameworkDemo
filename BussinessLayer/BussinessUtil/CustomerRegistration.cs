using BussinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BussinessLayer.Enums;
using BussinessLayer.CommonUtility;
using BussinessLayer.Contracts;
using System.Web;
using System.IO;
using System.Web.Util;
using System.Web.Mvc;

namespace BussinessLayer.BussinessUtil
{
    public class CustomerRegistrationUtility : IRegistration
    {
        Entities Entities = null;
        public CustomerRegistrationUtility()
        {
            Entities = new Entities();
        }

        public object GetUserInformation(ViewModel registration)
        {
            var data = Entities.CustomerRegistrations.ToList().Concat(Entities.CustomerLogins.ToList().Select(x => x.CustomerRegistration));
            return data;
        }
        public object GetUserInformation()
        {
            var data = Entities.CustomerRegistrations.ToList().Concat(Entities.CustomerLogins.ToList().Select(x => x.CustomerRegistration));
            return data;
        }


        public void SaveDetails(ViewModel viewModel)
        {

            var customerRegistration = new CustomerRegistration()
            {
                Name = viewModel.Name,
                Gender = CommonHelper.GetValueFromName<Gender>(viewModel.Gender).ToString(),
                Address = viewModel.Address,
                City = viewModel.City,
                Phone = viewModel.Phone,
            };
            var customerLogin = new CustomerLogin()
            {
                UserName = viewModel.UserName,
                Password = viewModel.Password,
                SecurityQuestion = CommonHelper.GetValueFromName<SecurityQuestion>(viewModel.SecurityQuestion).ToString(),
                SecureityAnswer = viewModel.SecureityAnswer,
                CustomerId = customerRegistration.CustomerId
            };
            //if (Entities.CustomerLogins.ToList().Any(x => x.UserName.ToLower().Equals(customerLogin.UserName.ToLower())))
            //{
            //    throw new Exception("User Name already exists");
            //}
            Entities.CustomerRegistrations.Add(customerRegistration);
            Entities.CustomerLogins.Add(customerLogin);
            Entities.SaveChanges();
        }

        public void UploadImage(UploadPicture uploadPicture)
        {
            string path = string.Empty;
            string fileName = string.Empty;
            try
            {
                var allowedExtensions = new[] { ".Jpg", ".png", ".jpg", "jpeg" };
                UploadPicture uploadPicture1 = new UploadPicture()
                {
                    UserId = uploadPicture.UserId,
                    ImageName = uploadPicture.ImageFile.FileName,


                };

                uploadPicture1.ImageFile = uploadPicture.ImageFile;

                if (uploadPicture.ImageFile.ContentType.Length > 0)
                {
                    string extension = Path.GetExtension(uploadPicture1.ImageName);
                    if (allowedExtensions.Contains(extension))
                    {
                        fileName = uploadPicture1.ImageName.Split('.')[0] + DateTime.Now.ToShortDateString() + extension;
                        path = Path.Combine(HttpContext.Current.Server.MapPath("~/Files"), fileName);

                    }
                    else
                    {
                        throw new Exception("Invalid File Extension");
                    }
                    uploadPicture1.ImageFile.SaveAs(path);
                    uploadPicture1.ImageName = fileName;
                    Entities.UploadPictures.Add(uploadPicture1);
                    Entities.SaveChanges();
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine("Error occured while uploading files..." + ex.Message);
            }
        }

        //public object GetFiles()
        //{
        //    Dictionary<int, string> records = new Dictionary<int, string>();
        //    var aa = Entities.UploadPictures.ToList().ToDictionary(x => x.UserId, y => y.ImageName);
        //    var data = from m in Entities.UploadPictures
        //               select new
        //               {
        //                   UserId = m.UserId,
        //                   ImageName = m.ImageName


        //               };


        //    return aa;
        //}
        public object GetFiles()
        {
            Dictionary<int, string> records = new Dictionary<int, string>();
            var aa = Entities.UploadPictures.ToList();


            return aa;
        }

        public object GetProduct()
        {
            //var record = Entities.Quantities.GroupBy(x => x).Select(x => new { ProductName = x.Key.ProductName, Quantity = x.Key.Quanity });
            var record = from data in Entities.Quantities.ToList()
                         group data by data.ProductName into g
                         select new { Product = g.Key, Quanity = g.Count() };

            Dictionary<string, int> dataSet = new Dictionary<string, int>();
            var record1s = Entities.Quantities.ToList();
            foreach (var item in record1s)
            {
                if (dataSet.ContainsKey(item.ProductName))
                {
                    dataSet[item.ProductName]++;
                }
                else
                {
                    dataSet.Add(item.ProductName, 1);
                }
            }
            return dataSet;
        }

       
        public bool IsUserExist(string userName)
        {
            bool isExist = false;

            if (Entities.CustomerLogins.ToList().Any(x => x.UserName.ToLower().Equals(userName.ToLower())))
            {
                isExist = true;
            }
            return isExist;
        }
    }
}
