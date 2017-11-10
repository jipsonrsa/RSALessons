using Jipson.Lesson1.website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jipson.Lesson1.website.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new EmployeeView();
            model.Age = 35;
            model.Name = "Jipson Thomas";
            model.Salary = 34750.25M;
            //ViewData.Model = model;
            return View(model);
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