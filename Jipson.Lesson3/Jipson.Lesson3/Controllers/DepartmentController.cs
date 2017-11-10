using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Jipson.Lesson3.FileManagement;
using Jipson.Lesson3.Models;

namespace Jipson.Lesson3.Controllers
{
    public class DepartmentController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            var manager = new FileManager(Helper.DepartmentFile);
            var contents = manager.GetAllContents();
            string[] delim = { Environment.NewLine, "\n" }; // "\n" added in case you manually appended a newline
            string[] lines = contents.ToString().Split(delim, StringSplitOptions.None);
            return lines.ToList();
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public bool Post(string department)
        {
            var mgr = new FileManager(Helper.DepartmentFile);
            var result = mgr.Add(department);
            return result;
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public bool Delete(string department)
        {
            var mgr = new FileManager(Helper.DepartmentFile);
            var result = mgr.Delete(department);
            return result;
        }
    }
}
