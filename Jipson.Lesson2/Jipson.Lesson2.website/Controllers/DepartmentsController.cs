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
    public class DepartmentsController : Controller
    {
        public List<Department> Departments { get; set; }
        // GET: Departments
        public ActionResult Index()
        {
            //get all departments from db
            var repository = new Repository<Department>();
            Departments = repository.GetAll().ToList();
            //now convert department list to a departmentView list
            var departmentViewList = new List<DepartmentView>();
            foreach (var dep in Departments)
            {
                var depView = new DepartmentView()
                {
                    Id = dep.Id,
                    Name = dep.Name,
                    HasEmployees = dep.Employees.Any()                    
                };
                departmentViewList.Add(depView);
            }
            //pass the departmentView list to the View
            return View(departmentViewList);
        }

        //GET
        public ActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        public ActionResult Create(Models.DepartmentView model)
        {
            //check for validations
            if (ModelState.IsValid)
            {
                //save  it in db
                var rep = new Repository<Department>();
                //convert departmentView to department object
                var deparment = new Department()
                {
                    Name = model.Name
                };
                rep.Add(deparment);
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
            var repository = new Repository<Department>();
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var department = repository.Get(id);
            var departmentView = AutoMapper.Mapper.Map<DepartmentView>(department);

            //var departmentview = new DepartmentView();
            //departmentview.Id = department.Id;
            //departmentview.Name = department.Name;

            return View(departmentView);
        }
        [HttpPost]
        public ActionResult Edit(Models.DepartmentView model)
        {
            if (ModelState.IsValid)
            {
                var repository = new Repository<Department>();
                var department = AutoMapper.Mapper.Map<Department>(model);
                //var department = new Department();
                //department.Name = model.Name;
                //department.Id = model.Id;
                repository.Update(department, department.Id);
            }else
            {
                return View(model);
            }

            return RedirectToAction("Index");
        }
        // GET
        public ActionResult Delete(int id)
        {
            var repository = new Repository<Department>();
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var department = repository.Get(id);

            return View(department);
        }
        //POST
        [HttpPost]
        public ActionResult Delete(Department model)
        {
            var repository = new Repository<Department>();
            var department = repository.Get(model.Id);
            repository.Delete(department);
            return RedirectToAction("Index");
        }
    }
}
