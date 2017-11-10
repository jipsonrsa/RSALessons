using AutoMapper;
using AutoMapper.Configuration;
using Jipson.Lesson2.Data;
using Jipson.Lesson2.website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jipson.Lesson2.website.App_Start
{
    public static class AutoMapperConfig
    {
        public static void Configure()
        {
            var cfg = new MapperConfigurationExpression();
            cfg.AddProfile<DepartmentProfile>();
            cfg.AddProfile<EmployeeProfile>();
            Mapper.Initialize(cfg);
        }
    }

    public class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            CreateMap<DepartmentView, Department>();
        }
    }

    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeView>();
            CreateMap<EmployeeView, Employee>();
        }
    }
}