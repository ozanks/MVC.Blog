using System.Web;
using System.Web.Mvc;

namespace MVC.Blog_Ozan
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
