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

        public ModuleLoader()
        {
            presenter = new ModuleLoaderPresenter(this);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            presenter.Initialize();
        }
    }
}