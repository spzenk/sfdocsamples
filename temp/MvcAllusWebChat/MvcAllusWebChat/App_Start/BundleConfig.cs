using System.Web;
using System.Web.Optimization;

namespace WebChat
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                          "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
                              "~/Scripts/knockout-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                  "~/Scripts/bootstrap.js",
                  "~/Scripts/bootbox.js"
                  ));
            //bundles.Add(new ScriptBundle("~/bundles/bootstrapjs").Include(
            //           "~/Scripts/bootstrap.min.js"));

            bundles.Add(new StyleBundle("~/Content/bootstrapcss").Include(
                        "~/Content/bootstrap.css"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include("~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/site").Include(
                    "~/Content/Site.css","~/Content/ChatRoom.css"
                ));

            bundles.Add(new ScriptBundle("~/bundles/site").Include(
                "~/Scripts/site.js",
                "~/Scripts/site-helpers.js"
                ));



            Register_JqueryUI(bundles);
        }


        public static void Register_JqueryUI(BundleCollection bundles)
        {

            //string jquery_ui_dir = string.Format("~/Content/themes/{0}/", "blitzer");

            string jquery_ui_dir = string.Format("~/Content/themes/{0}/", "humanity");
        
            bundles.Add(new StyleBundle("~/Content/themes/jq-ui").Include(
                   string.Concat(jquery_ui_dir, "jquery-ui.css"),
                   string.Concat(jquery_ui_dir, "jquery-ui.structure.css"),
                   string.Concat(jquery_ui_dir, "jquery-ui.theme.css")
                   ));
        }
    }
}