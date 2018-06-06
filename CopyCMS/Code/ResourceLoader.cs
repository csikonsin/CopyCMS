using CopyCMS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace CopyCMS.View
{
    public class ResourceLoader
    {
        private readonly Service.WebsiteService websiteService;
        private readonly AppSettings appSettings;

        public ResourceLoader(AppSettings appSettings, Service.WebsiteService websiteService)
        {
            this.websiteService = websiteService;
            this.appSettings = appSettings;
        }

        public string GetTheme()
        {
            using(var work = new UnitOfWork())
            {
                var theme = work.WebsiteRepository.GetById(appSettings.WebsiteId);

                return theme.Theme;
            }
        }

        public string GetStyleBundleVirtualPath()
        {
            var theme = GetTheme();
            var path = $"~/Content/css/{theme}/bundle";
            return path;
        }

        public Control LoadDefaultPage()
        {
            var theme = GetTheme();

            if (!(HttpContext.Current.Handler is Page page)) return null;

            var defaultControl = page.LoadControl($"~/Content/{theme}/Default.ascx");

            return defaultControl;
        }
    }
}