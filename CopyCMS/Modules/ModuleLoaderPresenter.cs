using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace CopyCMS.Modules
{
    public interface IModuleLoaderView
    {
        List<Control> Controls { get; set; }
    }

    public class ModuleLoaderPresenter
    {
        private IModuleLoaderView view;
        public ModuleLoaderPresenter(IModuleLoaderView view)
        {
            if (this.view == null) throw new ArgumentException("View must be set!");

            this.view = view;
        }

        public void Initialize()
        {
            LoadModules();
        }

        private void LoadModules()
        {
            var controls = GetControls();
            foreach (var cnt in controls)
            {
                view.Controls.Add(cnt);
            }
        }

        private List<Control> GetControls()
        {
            var modules = 
        }

    }
}