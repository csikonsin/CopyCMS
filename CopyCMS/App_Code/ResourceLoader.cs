using CopyCMS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace CopyCMS
{
    public class ResourceLoader
    {
        public Service.WebsiteService WebsiteService { get; set; }

        public ResourceLoader()
        {

        }

        public string GetTheme()
        {
            using(var work = new UnitOfWork())
            {
                var theme = work.WebsiteRepository.GetById(1);

                return theme.Name;
            }
        }

        public Control LoadDefaultPage()
        {
            var theme = GetTheme();

            var page = HttpContext.Current.Handler as Page;
            if (page == null) return null;

            var defaultControl = page.LoadControl($"~/Content/{theme}/Default.ascx");

            return defaultControl;
        }
    }
}