using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyCMS.Domain
{
    public class Module : BasePoco
    {
        public int ModuleId { get; set; }

        public int MenuId { get; set; }

        public string Settings { get; set; }

        public int? Position { get; set; }
    }
}