using Jipson.Lesson2.Data;
using Jipson.Lesson2.DataAccessLayer;
using Jipson.Lesson2.website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Jipson.Lesson2.website.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Emplyees
        public List<Employee> Employees { get; set; }
        public EmployeesController()
        {
            //var rep = new Repository<Employee>();
            //this.Employees = rep.GetAll().ToList();
        }
       public ActionResult Index()
        {
            var rep = new Repository<Employee>();
            this.Employees = rep.GetAll().ToList();
            //ViewBag.Data = Data;
            return View(Employees);
        }
        //GET
        public ActionResult Create()
        {
            return View();
        }
        //POST
        [HttpPost]
        public ActionResult Create(Models.EmployeeView model)
        {
            //check for validations
            if (ModelState.IsValid)
            {
                //save  it in db
                var rep = new Repository<Employee>();
                //convert departmentView to department object
                var employee = new Employee();
                employee.FirstName = model.FirstName;
                employee.LastName = model.LastName;
                employee.Salary = model.Salary;
                employee.DepartmentId = model.DepartmentId;
                rep.Add(employee);
            }
            else
            {
                return View(model);
            }
            //display confirmation or redirect
            return RedirectToAction("Index");
        }
        //GET
        public ActionResult Edit(int id = 0)
        {
            var repository = new Repository<Employee>();
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var employee = repository.Get(id);

            var employeeview = new EmployeeView();
            employeeview.Id = employee.Id;
            employeeview.FirstName = employee.FirstName;
            employeeview.LastName = employee.LastName;
            employeeview.Salary = employee.Salary;
            employeeview.DepartmentId = employee.DepartmentId;

            return View(employeeview);
        }
        [HttpPost]
        public ActionResult Edit(Models.EmployeeView model)
        {
            if (ModelState.IsValid)
            {
                var repository = new Repository<Employee>();

                var employee = new Employee();
                employee.FirstName = model.FirstName;
                employee.LastName = model.LastName;
                employee.Salary = model.Salary;
                employee.DepartmentId = model.DepartmentId;
                employee.Id = model.Id;
                repository.Update(employee, employee.Id);
            }
            else
            {
                return View(model);
            }

            return RedirectToAction("Index");
        }
        // GET
        public ActionResult Delete(int id)
        {
            var repository = new Repository<Employee>();
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var employee = repository.Get(id);

            return View(employee);
        }

        //POST
        [HttpPost]
        public ActionResult Delete(Employee model)
        {
            var repository = new Repository<Employee>();
            var employee = repository.Get(model.Id);
            repository.Delete(employee);
            return RedirectToAction("Index");
        }
    }
}