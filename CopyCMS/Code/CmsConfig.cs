using CopyCMS.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopyCMS.Code
{
    public  class CmsConfig
    {
        public static Dictionary<int, CmsModule> CmsModules { get; protected set; }

        public CmsConfig()
        {
            InitModules();
        }

        public static void InitModules()
        {
            if (CmsModules != null || CmsModules?.Count > 0) return;

            CmsModules = new Dictionary<int, CmsModule>();

            CmsModules.Add(1, new CmsModule()
            {
                ControlPath = "~/Modules/Content.ascx",
                EditorPath = "~/Modules/edit_content.aspx",
                ParameterType = typeof(ModuleParameters.ContentParameter),
                CssClass = "content"
            });

        }
    }

    public class CmsModule
    {
        public int ModuleId { get; set; }

        public string ControlPath { get; set; }
        public string EditorPath { get; set; }

        public Type ParameterType { get; set; }

        public string CssClass { get; set; }
    }
}