using System.Web;
using System.Web.Optimization;

namespace FxSaude.Produto.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Vendors/Limitless/js/core/libraries/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Vendors/Limitless/js/core/libraries/bootstrap.js",
                "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/limitless/css").Include(
                "~/Vendors/Limitless/css/bootstrap.css",
                "~/Vendors/Limitless/css/icons/icomoon/styles.css",
                "~/Vendors/Limitless/css/core.css",
                "~/Vendors/Limitless/css/components.css",
                "~/Vendors/Limitless/css/colors.css"));

            bundles.Add(new ScriptBundle("~/limitless/js").Include(
                "~/Vendors/Limitless/js/core/app.js",
                "~/Scripts/main_sidebar.js"));


            bundles.Add(new ScriptBundle("~/limitless/theme/js").Include(
                "~/Vendors/Limitless/js/plugins/loaders/pace.min.js",
                "~/Vendors/Limitless/js/plugins/loaders/blockui.min.js",
                "~/Vendors/Limitless/js/plugins/visualization/d3/d3.min.js",
                "~/Vendors/Limitless/js/plugins/visualization/d3/d3_tooltip.js",
                "~/Vendors/Limitless/js/plugins/forms/styling/switchery.min.js",
                "~/Vendors/Limitless/js/plugins/forms/styling/uniform.min.js",
                "~/Vendors/Limitless/js/plugins/forms/selects/bootstrap_multiselect.js",
                "~/Vendors/Limitless/js/plugins/ui/moment/moment.min.js",
                "~/Vendors/Limitless/js/plugins/pickers/daterangepicker.js",
                "~/Vendors/Limitless/js/pages/dashboard.js"
                ));

        }

    }
}
