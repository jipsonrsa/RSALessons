using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.IO;

namespace Jipson.Lesson3.Models
{
    public static class Helper
    {

        private static string DataFolderPath
        {
            get
            {
                return ConfigurationManager.AppSettings["DataFolderPath"];
            }
        }

        public static string DepartmentFile
        {
            get
            {
                return Path.Combine(DataFolderPath, "Departments.txt");
            }
        }


    }
}