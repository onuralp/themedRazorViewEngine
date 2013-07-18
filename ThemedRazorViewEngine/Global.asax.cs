using System.Configuration;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using ThemedViewEngine.Entity;
using ThemedViewEngine.Infrastructure;

namespace ThemedViewEngine
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            RegisterViewEngine(ViewEngines.Engines);
        }

        public static void RegisterViewEngine(ViewEngineCollection viewEngines)
        {
            // We do not need the default view engine

            viewEngines.Clear();

            var basePath = ConfigurationManager.AppSettings["ThemeBasePath"];
            var themeName = ConfigurationManager.AppSettings["ThemeName"];

            var theme = new Theme(basePath,themeName);

            var themeableRazorViewEngine = new ThemedRazorViewEngine(theme);

            viewEngines.Add(themeableRazorViewEngine);
        }
    }
}