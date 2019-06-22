using System.Web;
using System.Web.Optimization;

namespace Askrindo
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap4").Include(
                      "~/Scripts/Bootstrap4/bootstrap.bundle.js"));

            bundles.Add(new ScriptBundle("~/bundles/airdatepickerjs").Include(
                      "~/Scripts/AirDatepicker/js/datepicker.js",
                      "~/Scripts/AirDatepicker/js/i18n/datepicker.en.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/askrindo/css").Include(
                      "~/Content/Style/bootstrap.css",
                      "~/Content/Style/Web.css"));

            bundles.Add(new StyleBundle("~/Content/fontawesome").Include(
                      "~/Content/Fontawesome/css/all.css"));

            bundles.Add(new StyleBundle("~/Content/airdatepickercss").Include(
                      "~/Content/AirDatepicker/css/datepicker.css"));

        }
    }
}
