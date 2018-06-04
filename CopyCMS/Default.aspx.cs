using CopyCMS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CopyCMS
{
    public partial class Default : Page
    {
        public ResourceLoader Res { get; set;  }

        protected void Page_Load(object sender, EventArgs e)
        {
            phDefault.Controls.Add(Res.LoadDefaultPage());
        }
    }
}