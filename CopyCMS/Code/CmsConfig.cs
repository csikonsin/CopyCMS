using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopyCMS.Code
{
    public  class CmsConfig
    {
        public static List<CmsModule<IBaseModule>> CmsModules { get; protected set; }

        public CmsConfig()
        {
            InitModules();
        }

        private void InitModules()
        {
            if (CmsModules != null || CmsModules.Count > 0) return;

            CmsModules = new List<CmsModule<IBaseModule>>();

            CmsModules.Add(new CmsModule<Modules.Content>
            {
                ModuleId = 1,
                EditorPath = "~/Modules/edit_content.aspx",
            });

        }
    }

    public class CmsModule<T> where T: IBaseModule
    {
        public int ModuleId { get; set; }
        public string EditorPath { get; set; }        
    }
}