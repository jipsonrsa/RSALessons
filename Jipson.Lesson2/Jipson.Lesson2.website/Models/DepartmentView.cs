using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Jipson.Lesson2.website.Models
{
    public class DepartmentView
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Text, ErrorMessage = "required string")]
        public string Name { get; set; } 

        public bool HasEmployees { get; set; }
    }
}