using Autofac;
using Autofac.Integration.Web;
using CopyCMS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace CopyCMS
{
    public class Global : HttpApplication, IContainerProviderAccessor
    {
        static IContainerProvider _containerProvider;

        public IContainerProvider ContainerProvider
        {
            get
            {
                return _containerProvider;
            }
        }


        void Application_Start(object sender, EventArgs e)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<WebsiteService>();
            builder.RegisterType<View.ResourceLoader>();
            builder.RegisterType<View.AppSettings>();
            builder.RegisterType<BundleConfig>();            
            var httpContext = new HttpContextWrapper(HttpContext.Current);
            builder.RegisterInstance<HttpContextBase>(httpContext);
            builder.RegisterType<Service.MenuService>();

            var container = builder.Build();
            _containerProvider = new ContainerProvider(container);

            DapperExtensions.DapperExtensions.DefaultMapper = typeof(DapperExtensions.Mapper.PluralizedAutoClassMapper<>);

            // Code, der beim Anwendungsstart ausgeführt wird
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            container.Resolve<BundleConfig>().RegisterBundles(BundleTable.Bundles);

            CopyCMS.Code.CmsConfig.InitModules();
        }
    }
}