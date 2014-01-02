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
			.Include("~/Scripts/bootstrap.js")
			.Include("~/Scripts/knockout-{version}.js")
		);

      /*bundles.Add(new ScriptBundle("~/Scripts/webscripts")
      .Include("~/Scripts/website/bookblock.js")
      .Include("~/Scripts/website/bs.js")
      .Include("~/Scripts/website/modernizr.js")
      .Include("~/Scripts/website/bxslider.js")
      .Include("~/Scripts/website/easing.js")
      .Include("~/Scripts/website/input-clear.js")
      .Include("~/Scripts/website/jquery-zoom.js")
      .Include("~/Scripts/website/ranger-slider.js")
      .Include("~/Scripts/website/social.js")
      .Include("~/Scripts/website/ui.js"));*/

      bundles.Add(
        new StyleBundle("~/Content/css")
          .Include("~/Content/ie10mobile.css")
          .Include("~/Content/bootstrap.min.css")
          .Include("~/Content/bootstrap-responsive.min.css")
          .Include("~/Content/font-awesome.min.css")
		  .Include("~/Content/durandal.css")
          .Include("~/Content/starterkit.css")
          .Include("~/Content/bs.css")
          .Include("~/Content/bxslider.css")
          .Include("~/Content/customIE.css")
          .Include("~/Content/flip.css")
          .Include("~/Content/flip-demo.css")
          .Include("~/Content/main-slider.css")
          .Include("~/Content/noJS.css")
          .Include("~/Content/range-slider.css")
          .Include("~/Content/social.css")
          .Include("~/Content/style.css")
        );
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