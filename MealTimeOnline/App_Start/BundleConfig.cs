using System.Web;
using System.Web.Optimization;

namespace MealTimeOnline
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/mto.js",
                      "~/Scripts/respond.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/css/user").Include(
                      "~/Content/css/font-awesome.css",
                      "~/Content/css/bootstrap.css",
                      "~/Content/css/Site.css"));

            bundles.Add(new StyleBundle("~/Content/css/account").Include(
                        "~/Content/css/account.css"));

            bundles.Add(new ScriptBundle("~/bundles/nicescroll", "//cdn.bootcss.com/jquery.nicescroll/3.6.8/jquery.nicescroll.min.js").Include(
                      "~/Scripts/jquery.nicescroll.min.js"));

            #region Common

            bundles.Add(new ScriptBundle("~/bundles/DataTables").Include(
                "~/Scripts/jquery.dataTables.min.js",
                "~/Scripts/dataTables.bootstrap.min.js"
                ));

            bundles.Add(new StyleBundle("~/Content/DataTables").Include(
                "~/Content/css/dataTables.bootstrap.min.css"));

            #endregion // Common

            #region Admin

            bundles.Add(new StyleBundle("~/Content/style/admin").Include(
                "~/Content/admin/bootstrap.css",
                "~/Content/admin/bootstrap-reset.css",
                "~/Content/admin/jquery-ui-1.10.3.css",
                "~/Content/admin/style.css",
                "~/Content/admin/style-responsive.css",
                "~/Content/admin/Site.css"));

            bundles.Add(new ScriptBundle("~/bundles/Admin/Scripts").Include(
                "~/Scripts/jquery-ui-1.9.2.custom.min.js",
                "~/Scripts/jquery-migrate-1.2.1.min.js",
                "~/Scripts/admin/scripts.js"));

            #endregion // Admin

            bundles.UseCdn = true;

        }
    }
}
