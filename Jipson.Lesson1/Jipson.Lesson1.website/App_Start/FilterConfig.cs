using System.Web;
using System.Web.Mvc;

namespace Jipson.Lesson1.website
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
