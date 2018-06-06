using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CopyCMS.Modules
{
    public partial class BaseModuleWrapper : System.Web.UI.UserControl
    {
        public Domain.Module Module { get; set; }
        public CopyCMS.Code.CmsModule CmsModule { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            var classes = new List<string>() { "module", CmsModule.CssClass };

            pnModule.CssClass = String.Join(" ", classes);

            pnModule.ID = "";
        }
    }
}