using System.Web;
using System.Web.Mvc;

namespace Lr4_Db_MVC_1_
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
