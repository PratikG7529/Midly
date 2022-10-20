using System.Web;
using System.Web.Mvc;

namespace Midly
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            //This will add global authorization
            filters.Add(new AuthorizeAttribute());

            filters.Add(new RequireHttpsAttribute());
        }
    }
}
