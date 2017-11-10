using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Jipson.Lesson2.website.Models
{
    public class EmployeeView
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Text, ErrorMessage = "required First Name")]
        public string FirstName { get; set; }
        [Required]
        [DataType(DataType.Text, ErrorMessage = "required Last Name")]
        public string LastName { get; set; }
        public int Salary { get; set; }
        public Nullable<int> DepartmentId { get; set; }

        public virtual DepartmentView Department { get; set; }
    }
}