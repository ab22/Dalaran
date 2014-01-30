using Dalaran.Infrastructure.Interfaces;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Dalaran.Infrastructure
{
    public class WebConfiguration : IGlobalConfiguration
    {
        public void Configure()
        {
            //AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            RegisterBundles(BundleTable.Bundles);
        }

        private void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        private void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }


        private void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();
            AddDefaultIgnorePatterns(bundles.IgnoreList);

            bundles.Add(
              new ScriptBundle("~/Scripts/vendor")
                  .Include("~/Scripts/jquery-{version}.js")
                  .Include("~/Scripts/knockout-{version}.js")
              );

            bundles.Add(
            new StyleBundle("~/Content/css")
              .Include("~/Content/animations.css")
              .Include("~/Content/editor.css")
              .Include("~/Content/fonts.css")
              .Include("~/Content/foundation.css")
              .Include("~/Content/website.css")
              .Include("~/Content/ie8.css"));
        }

        private void AddDefaultIgnorePatterns(IgnoreList ignoreList)
        {
            if (ignoreList == null)
            {
                throw new System.ArgumentNullException("ignoreList");
            }

            ignoreList.Ignore("*.intellisense.js");
            ignoreList.Ignore("*-vsdoc.js");
            ignoreList.Ignore("*.debug.js", OptimizationMode.WhenEnabled);
            //ignoreList.Ignore("*.min.js", OptimizationMode.WhenDisabled);
            //ignoreList.Ignore("*.min.css", OptimizationMode.WhenDisabled);
        }
    }
}