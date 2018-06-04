using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.UI;

namespace CopyCMS
{
    public class BundleConfig
    {
        public View.ResourceLoader ResourceLoader { get; set; }

        private View.ResourceLoader resourceLoader;

        public BundleConfig(View.ResourceLoader resourceLoader)
        {
            this.resourceLoader = resourceLoader;
        }

        // Weitere Informationen zur Bündelung finden Sie unter https://go.microsoft.com/fwlink/?LinkID=303951
        public void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/WebFormsJs").Include(
                            "~/Scripts/WebForms/WebForms.js",
                            "~/Scripts/WebForms/WebUIValidation.js",
                            "~/Scripts/WebForms/MenuStandards.js",
                            "~/Scripts/WebForms/Focus.js",
                            "~/Scripts/WebForms/GridView.js",
                            "~/Scripts/WebForms/DetailsView.js",
                            "~/Scripts/WebForms/TreeView.js",
                            "~/Scripts/WebForms/WebParts.js"));

            // Die Reihenfolge ist sehr wichtig, damit diese Dateien funktionieren. Sie weisen ausdrückliche Abhängigkeiten auf.
            bundles.Add(new ScriptBundle("~/bundles/MsAjaxJs").Include(
                    "~/Scripts/WebForms/MsAjax/MicrosoftAjax.js",
                    "~/Scripts/WebForms/MsAjax/MicrosoftAjaxApplicationServices.js",
                    "~/Scripts/WebForms/MsAjax/MicrosoftAjaxTimer.js",
                    "~/Scripts/WebForms/MsAjax/MicrosoftAjaxWebForms.js"));

            // Verwenden Sie die Entwicklungsversion von Modernizr als Entwicklungs- und Lerngrundlage. Wenn Sie dann
            // bereit für die Produktion, verwenden Sie das Buildtool unter https://modernizr.com, um nur die benötigten Tests auszuwählen.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                            "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle(resourceLoader.GetStyleBundleVirtualPath()).IncludeDirectory($"~/Content/{resourceLoader.GetTheme()}", "*.css"));
        }
    }
}