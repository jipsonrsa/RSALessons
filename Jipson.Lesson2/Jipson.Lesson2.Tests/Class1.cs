using Jipson.Lesson2.Data;
using Jipson.Lesson2.DataAccessLayer;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jipson.Lesson2.Tests
{
    [TestFixture]
    public class Respoiroty_Testing_Class
    {

        [TestCase(6)]
        [TestCase(5)]
        public void GetAll_Fetches_All_Departments_From_Database(int exepctedCount)
        {
            var rep = new Repository<Department>();
            var allEmployees = rep.GetAll();
            var dbCount = allEmployees.Count();
            Assert.AreEqual(exepctedCount, dbCount);
        }

        [Test]
        public void Get_Claims_Employee_Count()
        {
            var rep = new Repository<Employee>();
            var expectCount = 1;
            var dbCount = rep.FindAll(e => e.Department.Name.ToLower() == "claims").Count();
            Assert.AreEqual(expectCount, dbCount);
        }
        [TestCase(10,10,20)]
        [TestCase(10, 11, 21)]
        [TestCase(10, 40, 50)]
        public void AddingTwoNumbers_returnsCorrectValue(int a, int b, int expected)
        {
            var sum = a + b; //this is done by the function being tested
            Assert.AreEqual(expected, sum);
        }

    }
}
