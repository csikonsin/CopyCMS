using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CopyCMS.Modules
{
    public partial class ModuleLoader : System.Web.UI.UserControl, IModuleLoaderView
    {
        private ModuleLoaderPresenter presenter;

        public ControlCollection ControlCollection
        {
            get
            {
                return ph.Controls;
            }
        }

        public ModuleLoader()
        {
            var provider = ((Global)HttpContext.Current.ApplicationInstance).ContainerProvider;

            Service.MenuService service = provider.RequestLifetime.Resolve<Service.MenuService>();
            HttpContextBase httpContext = provider.RequestLifetime.Resolve<HttpContextBase>();

            presenter = new ModuleLoaderPresenter(this, service, httpContext);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            presenter.Initialize();
        }
    }
}