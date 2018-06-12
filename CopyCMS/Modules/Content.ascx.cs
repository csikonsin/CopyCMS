using CopyCMS.Code.ModuleParameters;
using CopyCMS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CopyCMS.Modules
{
    public partial class Content : System.Web.UI.UserControl, IBaseModule, IContentView
    {
        ContentPresenter presenter;

        public void SetParameter(BaseParameter parameter)
        {
            presenter = new ContentPresenter(this, (ContentParameter)parameter);
        }

        public string Text
        {
            get
            {
                return content.Text;
            }
            set
            {
                content.Text = value;
            }
        }
       

        protected void Page_Load(object sender, EventArgs e)
        {
            presenter.Initalize();
        }
    }

    public interface IContentView
    {
        string Text { get; set; }
    }


    public class ContentPresenter
    {
        IContentView view;
        ContentParameter parameter;
        public ContentPresenter(IContentView view, ContentParameter parameter)
        {
            this.view = view ?? throw new ArgumentException();
            this.parameter = parameter;
        }

        public void Initalize()
        {
            using (var work = new UnitOfWork())
            {
                view.Text = work.ContentRepository.GetById(parameter.ContentId).Text;
            }
        }
    }

}