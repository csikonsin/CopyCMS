using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopyCMS
{
    public interface IBaseModule
    {
        Domain.Module Module { get; set; }
    }


    public class BaseModule : IBaseModule
    {
        public Domain.Module Module { get; set; }
    }
}