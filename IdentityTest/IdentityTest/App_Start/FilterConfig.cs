using System.Web;
using System.Web.Mvc;
//using IdentityTest.App_Start;

namespace IdentityTest
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
       
        }
    }
}