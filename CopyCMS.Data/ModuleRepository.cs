using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyCMS.Data
{
    public interface IModuleRepository : IBaseRepository<Domain.Module>
    {

    }

    public class ModuleRepository : BaseRepository<Domain.Module>, IModuleRepository
    {
        public ModuleRepository(IUnitOfWork work) : base(work) { }


    }
}
