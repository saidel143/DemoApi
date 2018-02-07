using System.Web;
using System.Web.Optimization;

namespace Portales
{
    public class BundleConfig
    {
        // Para obtener más información sobre Bundles, visite http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            //// Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            //// preparado para la producción y podrá utilizar la herramienta de compilación disponible en http://modernizr.com para seleccionar solo las pruebas que necesite.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js",
            //          "~/Scripts/respond.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));



            //UIF
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-migrate-1.2.1.js",
                        "~/Scripts/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/uif/lib").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/jquery-migrate-{version}.js",
                "~/Scripts/jquery.unobtrusive*",
                "~/Scripts/jquery.validate*",
                "~/Lib/jquery-number/jquery.number.js",
                "~/Lib/bootstrap36/js/bootstrap.js",
                "~/Lib/DataTables-1.10.0/js/jquery.dataTables.js",
                "~/Lib/DataTables-1.10.0/js/fnStandingRedraw.js",
                "~/Lib/DataTables-1.10.0/js/DT_bootstrap.js",
                "~/Lib/DataTables-1.10.0/js/jquery.floatThead.js",
                "~/Lib/datepicker/js/bootstrap-datepicker.js",
                "~/Lib/datepicker/js/locales/bootstrap-datepicker.es.js",
                "~/Lib/typeahead/typeahead.js",
                "~/Lib/jquery-mask/jquery-mask.js",
                "~/Lib/jstree/jstree.js",
                "~/Lib/jquerysteps/jquery.steps.js",
                "~/Lib/nprogress/nprogress.js",
                "~/Lib/multiselect/js/bootstrap-multiselect.js",
                "~/Lib/bootstrap-notify/js/bootstrap-notify.js",
                "~/Lib/boostrap-filestyle/js/bootstrap-filestyle.js",
                "~/Lib/handlebars/handlebars-v3.0.3.js",
                "~/Lib/ckeditor/ckeditor.js",
                "~/Lib/ckeditor/ckeditor-adapter.js",
                "~/Lib/slim-scroll/jquery.slimscroll.js",
                "~/Lib/moment/moment.js"
                ));

            bundles.Add(new ScriptBundle("~/uif/theme").Include(
                "~/Lib/framework/theme/app/js/dependencies.js",
                "~/Lib/framework/theme/app/js/main.js"
                ));

            bundles.Add(new ScriptBundle("~/uifr2/theme").Include(
                 "~/Lib/framework/theme/scripts/layout.js"
                 ));

            bundles.Add(new ScriptBundle("~/uifr2/themedark").Include(
                "~/Lib/framework/themedark/scripts/layout.js"
                ));

            bundles.Add(new ScriptBundle("~/uif/framework").Include(
                "~/Lib/framework/js/uif-touch-core.js",
                "~/Lib/framework/js/uif-touch-alert.js",
                "~/Lib/framework/js/uif-touch-autocomplete.js",
                "~/Lib/framework/js/uif-touch-datatable.js",
                "~/Lib/framework/js/uif-touch-datepicker.js",
                "~/Lib/framework/js/uif-touch-gridsystem.js",
                "~/Lib/framework/js/uif-touch-inline.js",
                "~/Lib/framework/js/uif-touch-inputsearch.js",
                "~/Lib/framework/js/uif-touch-list.js",
                "~/Lib/framework/js/uif-touch-mask.js",
                "~/Lib/framework/js/uif-touch-modal.js",
                "~/Lib/framework/js/uif-touch-multiselect.js",
                "~/Lib/framework/js/uif-touch-panel2.js",
                "~/Lib/framework/js/uif-touch-select.js",
                "~/Lib/framework/js/uif-touch-tab.js",
                "~/Lib/framework/js/uif-touch-treeview.js",
                "~/Lib/framework/js/uif-touch-wizard.js",
                "~/Lib/framework/js/uif-touch-notify.js",
                "~/Lib/framework/js/uif-touch-fileinput.js",
                "~/Lib/framework/js/uif-touch-dialog.js",
                "~/Lib/framework/js/uif-touch-editor.js",
                "~/Lib/framework/js/uif-touch-listview.js"
                ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/site.css",
                "~/Content/bootstrap.min.css"));

            BundleTable.EnableOptimizations = false;
        }
    }
}
