using System.Web;
using System.Web.Mvc;

namespace ECommerce_Shop_Online_MVC_Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
