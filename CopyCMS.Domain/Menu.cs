using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyCMS.Domain
{
    public class Menu : BasePoco
    {
        public string Title { get; set; }

        public string Url { get; set; }
    }
}
