using System.Web;
using System.Web.Optimization;

namespace Re2017MVC
{
    public class BundleConfig
    {
        // Per altre informazioni sulla creazione di bundle, vedere https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            //// Utilizzare la versione di sviluppo di Modernizr per eseguire attività di sviluppo e formazione. Successivamente, quando si è
            //// pronti per passare alla produzione, usare lo strumento di compilazione disponibile all'indirizzo https://modernizr.com per selezionare solo i test necessari.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js",
            //          "~/Scripts/respond.js"));

            //bundles.Add(new ScriptBundle("~/bundles/JavascriptREM").Include(
            //        "~/vendor/DropzoneJs_scripts/dropzone.js",
            //        "~/vendor/source/jquery.fancybox.pack.js?v=2.1.7",
            //        "~/vendor/plugin/cookies/jquery.cookie.js"));

            ////bundles.Add(new StyleBundle("~/Content/css").Include(
            ////          "~/Content/bootstrap.css",
            ////          "~/Content/site.css"));

            //bundles.Add(new StyleBundle("~/ContentREM/css").Include(
            //         "~/vendor/bootstrap/css/bootstrap.min.css",
            //         "~/vendor/tagsInput/bootstrap-tagsinput.css",
            //         "~/vendor/metisMenu/metisMenu.min.css"));

            //bundles.Add(new StyleBundle("~/OtherREM/css").Include(
            //       "~/vendor/datatables-plugins/dataTables.bootstrap.css",
            //       "~/vendor/datatables-responsive/dataTables.responsive.css",
            //       "~/dist/css/sb-admin-2.css",
            //        "~/vendor/morrisjs/morris.css",
            //         "~/vendor/font-awesome/css/font-awesome.min.css",
            //          "~/vendor/DropzoneJs_scripts/dropzone.css",
            //          "~/vendor/source/jquery.fancybox.css?v=2.1.7",
            //          "~/css/AiChatbot.css",
            //          "~/css/AiChatbot.css",
            //          "~/css/AiChatbot.css"));
            ////***************************************
            //"~/vendor/source/jquery.fancybox.pack.js?v=2.1.7",
            bundles.Add(new ScriptBundle("~/bundles/REMJs").Include(
                  "~/vendor/DropzoneJs_scripts/jquery.min.js",
                  "~/vendor/DropzoneJs_scripts/dropzone.js",
                 
                  "~/vendor/bootstrap/js/bootstrap.min.js",
                  "~/vendor/plugin/cookies/jquery.cookie.js",
                  "~/vendor/metisMenu/metisMenu.min.js",
                  "~/vendor/datatables/js/jquery.dataTables.min.js",
                  "~/vendor/datatables-plugins/dataTables.bootstrap.min.js",
                  "~/vendor/datatables-responsive/dataTables.responsive.js",
                  "~/dist/js/sb-admin-2.js",
                  "~/vendor/tagsInput/bootstrap-tagsinput.min.js"));
            //,"~/vendor/source/jquery.fancybox.css?v=2.1.7"
            bundles.Add(new StyleBundle("~/bundles/REMCss").Include(
                "~/vendor/bootstrap/css/bootstrap.min.css",
                "~/vendor/tagsInput/bootstrap-tagsinput.css",
                "~/vendor/metisMenu/metisMenu.min.css",
                "~/vendor/datatables-plugins/dataTables.bootstrap.css",
                "~/vendor/datatables-responsive/dataTables.responsive.css",
                "~/dist/css/sb-admin-2.css",
                "~/vendor/morrisjs/morris.css",
                "~/vendor/font-awesome/css/font-awesome.min.css",
                "~/css/AiChatbot.css",
                "~/vendor/DropzoneJs_scripts/dropzone.css"));

            //bundles.Add(new StyleBundle("~/bundles/REMCss").Include(
            //   "~/vendor/bootstrap/css/bootstrap.min.css"));


        }
    }
}
