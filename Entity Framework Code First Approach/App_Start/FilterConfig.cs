using System.Web;
using System.Web.Mvc;

namespace Entity_Framework_Code_First_Approach
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
