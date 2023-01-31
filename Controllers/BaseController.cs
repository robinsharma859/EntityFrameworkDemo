using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BussinessLayer.Models;
namespace EntityFrameworkDemo.Controllers
{
    public class BaseController : Controller
    {
        protected Entities Entities;
        // GET: Base
        public BaseController()
        {
            Entities = new Entities();
        }
      
        //public int SaveRecord<T>(T model)
        //{
        //    int saved =  Entities.m
        //}
    }
}