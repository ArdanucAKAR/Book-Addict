using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Book_Addict
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            if (ex is HttpException && ((HttpException)ex).GetHttpCode() == 403)
                Response.Redirect("Error/403");
            if (ex is HttpException && ((HttpException)ex).GetHttpCode() == 404)
                Response.Redirect("Error/404");
            if (ex is HttpException && ((HttpException)ex).GetHttpCode() == 500)
                Response.Redirect("Error/500");
        }
    }
}
