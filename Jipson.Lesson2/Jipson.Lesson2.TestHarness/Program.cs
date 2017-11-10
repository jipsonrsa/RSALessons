using Jipson.Lesson2.Data;
using Jipson.Lesson2.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jipson.Lesson2.TestHarness
{
    class Program
    {
        static void Main(string[] args)
        {
            var rep = new Repository<Department>();
            var departments = rep.GetAll();
            foreach(var department in departments)
            {
                Console.WriteLine($"{department.Id} : {department.Name}");
            }
            Console.ReadKey();
        }
    }
}
