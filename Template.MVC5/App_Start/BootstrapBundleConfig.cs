using System.Web.Optimization;

namespace AbantwanaWebMaster.MVC5
{
	public class BootstrapBundleConfig
	{
		public static void RegisterBundles(BundleCollection bundles)
		{
			// Add @Styles.Render("~/Content/bootstrap") in the <head/> of your _Layout.cshtml view
			// For Bootstrap theme add @Styles.Render("~/Content/bootstrap-theme") in the <head/> of your _Layout.cshtml view
			// Add @Scripts.Render("~/bundles/bootstrap") after jQuery in your _Layout.cshtml view
			// When <compilation debug="true" />, MVC4 will render the full readable version. When set to <compilation debug="false" />, the minified version will be rendered automatically
			BundleTable.Bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/Scripts/bootstrap.js"));
			BundleTable.Bundles.Add(new StyleBundle("~/Content/bootstrap").Include("~/Content/bootstrap.css"));
			BundleTable.Bundles.Add(new StyleBundle("~/Content/bootstrap-theme").Include("~/Content/bootstrap-theme.css"));
            BundleTable.Bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            BundleTable.Bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            BundleTable.Bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            BundleTable.Bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            BundleTable.Bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                       "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            
        }

        
    }
}
