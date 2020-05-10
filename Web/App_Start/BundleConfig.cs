using System.Web;
using System.Web.Optimization;

namespace ChurchSMS_offline
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/churchsms").Include(
                         "~/Scripts/jquery-2.0.2.min.js",
                         "~/Content/js/jquery-ui-1.10.3.min.js",
                //"~/Content/js/plugins/iCheck/icheck.min.js",
                         "~/Content/js/plugins/jqueryKnob/jquery.knob.js",
                         "~/Content/js/bootstrap.min.js",
                         "~/Content/js/AdminLTE/app.js",
                         "~/Content/js/toaster.js",
                         "~/Scripts/highcharts.js",
                         "~/Scripts/angular.js",
                         "~/Scripts/bootstrap-datepicker.js",
                         "~/Scripts/angular-multi-select.js",
                         "~/Contents/js/bootstrap-switch.js",
                         "~/Scripts/bootbox.js",
                         "~/Content/js/jquery.dataTables.js",
                         "~/Content/js/dataTables.bootstrap.js",
                         "~/Content/js/plugins/input-mask/jquery.inputmask.js",
                         "~/Content/js/plugins/input-mask/jquery.inputmask.date.extensions.js",
                         "~/Content/js/plugins/input-mask/jquery.inputmask.extensions.js",
                         "~/Content/js/bootstrap-switch.js",
                         "~/Scripts/jquery.signalR-2.1.2.js",
                         "~/Scripts/jasny-bootstrap.min.js",
                         "~/Scripts/cropper.js",
                         "~/Scripts/cropper-helper.js",
                         "~/Scripts/highcharts-ng.js",
                         "~/Scripts/dataTables.scroller.js",
                         "~/Scripts/smart-table.js",
                         "~/Scripts/dataTables.responsive.js",
                          "~/Scripts/angular-datatables.js"
                         ));

            bundles.Add(new ScriptBundle("~/bundles/login").Include(
                        "~/Scripts/jquery-2.0.2.min.js",
                        "~/Content/js/jquery-ui-1.10.3.min.js",
                        "~/Scripts/modernizr-*",
                        "~/Scripts/jquery.validate*"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                    ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/cssAzure").Include(
                    "~/Content/site.css",
                    "~/Content/css/bootstrap.min.css",
                    "~/Content/datepicker3.css",
                    "~/Content/css/font-awesome.min.css",
                    "~/Content/css/ionicons.min.css",
                    "~/Content/css/AdminLTE.css",
                //"~/Content/css/minimal/blue.css",
                    "~/Content/css/angular-multi-select.css",
                    "~/Content/css/bootstrap-switch.css",
                    "~/Content/bootsnip_timeline.css",
                    "~/Content/css/dataTables.bootstrap.css",
                    "~/Content/css/jquery.dataTables.css",
                    "~/Content/css/toaster.css",
                    "~/Content/css/jasny-bootstrap.min.css",
                    "~/Content/css/cropper.css",
                    "~/Content/css/dataTables.scroller.css",
                    "~/Content/css/dataTables.responsive.css"
                    ));

            bundles.Add(new StyleBundle("~/Content/login").Include(
                   "~/Content/site.css",
                   "~/Content/css/bootstrap.min.css",
                   "~/Content/css/font-awesome.min.css",
                   "~/Content/css/AdminLTE.css",
                   "~/Content/css/minimal/blue.css"
                   ));
        }
    }
}
