using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace CopyCMS.Modules
{
    public interface IModuleLoaderView
    {
        ControlCollection ControlCollection { get; }
    }

    public class ModuleLoaderPresenter
    {
        private IModuleLoaderView view;
        private readonly Service.MenuService menuService;


        public ModuleLoaderPresenter(IModuleLoaderView view, Service.MenuService menuService)
        {
            if (view == null) throw new ArgumentException("View must be set!");

            this.view = view;
            this.menuService = menuService;
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
                view.ControlCollection.Add(cnt);
            }
        }

        private List<Control> GetControls()
        {
            Domain.Menu menu = menuService.GetCurrentMenu();

            if (menu == null)
            {
                var lt404 = new LiteralControl() { Text = "404 Seite nicht gefunden" };
                return new List<Control> { lt404 };
            }

            int menuId = menu.Id;

            List<Domain.Module> modules;
            using (var work = new Data.UnitOfWork())
            {
                modules = work.ModuleRepository.GetAllByMenuId(menuId);
                modules = modules.OrderBy((x) =>
                {
                    if (x.Position.HasValue)
                    {
                        return x.Position.Value;
                    }
                    else
                    {
                        return Int32.MaxValue;
                    }
                }).ToList();
            }

            var controls = new List<Control>();

            foreach (var module in modules)
            {

            }


            return controls;
        }

    }
}