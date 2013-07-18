using System.Web.Mvc;
using ThemedViewEngine.Entity;

namespace ThemedViewEngine.Infrastructure
{
    public class ThemedRazorViewEngine : RazorViewEngine
    {
        private readonly Theme _theme;

        public ThemedRazorViewEngine(Theme theme)
        {
            _theme = theme;

            base.ViewLocationFormats = new[]
            {
                _theme.Path + "/Views/{1}/{0}.cshtml",
                _theme.Path + "/Views/Shared/{0}.cshtml",
                "~/Themes/Default/Views/{1}/{0}.cshtml"
            };

            base.PartialViewLocationFormats = new[]
            {
                _theme.Path + "/Views/{1}/{0}.cshtml",
                _theme.Path + "/Views/Shared/{0}.cshtml",
                "~/Themes/Default/Views/Shared/{0}.cshtml"
            };

            base.AreaViewLocationFormats = new[]
            {
                _theme.Path + "/Views/{2}/{1}/{0}.cshtml",
                _theme.Path + "/Views/Shared/{0}.cshtml",
                "~/Themes/Default/Views/{1}/{0}.cshtml"
            };
            base.AreaPartialViewLocationFormats = new[]
            {
                _theme.Path + "/Views/{2}/{1}/{0}.cshtml",
                _theme.Path + "/Views/{1}/{0}.cshtml",
                _theme.Path + "/Views/Shared/{0}.cshtml",
                "~/Themes/Default/Views/Shared/{0}.cshtml"
            };
        }

        /// <summary>
        ///     Finds the specified view by using the specified controller context and master view name.
        /// </summary>
        /// <param name="controllerContext">The controller context.</param>
        /// <param name="viewName">The name of the view.</param>
        /// <param name="masterName">The name of the master view.</param>
        /// <param name="useCache">true to use the cached view.</param>
        /// <returns>
        ///     The page view.
        /// </returns>
        public override ViewEngineResult FindView(ControllerContext controllerContext, string viewName,
            string masterName, bool useCache)
        {
            // bypass the view cache, the view will change depending on the current theme
            const bool useViewCache = false;

            return base.FindView(controllerContext, viewName, masterName, useViewCache);
        }
    }
}