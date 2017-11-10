using Jipson.Lesson2.Data;
using Jipson.Lesson2.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jipson.Lesson2.website.Models
{
    public static class Helper
    {

        public static SelectList AllDepartments
        {
            get
            {
                var rep = new Repository<Department>();
                var departments = rep.GetAll();
                var selectList = new SelectList(departments,"Id","Name");
                return selectList;
            }

        }


    }
}