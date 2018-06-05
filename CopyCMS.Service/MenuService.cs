using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CopyCMS.Service
{

    public class MenuService
    {
        private readonly HttpContextBase httpContext;

        public MenuService(HttpContextBase httpContext)
        {
            this.httpContext = httpContext;
        }

        public Domain.Menu GetCurrentMenu()
        {
            Domain.Menu menu = null;

            string url = httpContext.Request.Url.AbsolutePath;

            using (var work = new Data.UnitOfWork())
            {
                menu = work.MenuRepository.GetByUrl(url);
            }

            return menu;
        }
    }
}
