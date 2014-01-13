using System;
using System.Web.Optimization;

namespace Dalaran {
  public class DurandalBundleConfig {
    public static void RegisterBundles(BundleCollection bundles) {
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

    public static void AddDefaultIgnorePatterns(IgnoreList ignoreList) {
      if(ignoreList == null) {
        throw new ArgumentNullException("ignoreList");
      }

      ignoreList.Ignore("*.intellisense.js");
      ignoreList.Ignore("*-vsdoc.js");
      ignoreList.Ignore("*.debug.js", OptimizationMode.WhenEnabled);
      //ignoreList.Ignore("*.min.js", OptimizationMode.WhenDisabled);
      //ignoreList.Ignore("*.min.css", OptimizationMode.WhenDisabled);
    }
  }
}