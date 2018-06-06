using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CopyCMS.Modules
{
    public partial class Content : System.Web.UI.UserControl, IBaseModule
    {
        public Domain.Module Module { get; set; }

        public Content()
        {
         
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var work = new Data.UnitOfWork())
            {
                var text = work.ContentRepository.GetById(Convert.ToInt32(Module.Settings));
                content.Text = text.Text;
            }
        }
    }

    public class ContentParameter
    {

    }
}