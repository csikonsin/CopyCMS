using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DapperExtensions;

namespace CopyCMS.Data
{
    public interface IMenuRepository : IBaseRepository<Domain.Menu>
    {
        Domain.Menu GetByUrl(string url);
    }

    public class MenuRepository : BaseRepository<Domain.Menu>, IMenuRepository
    {
        public MenuRepository(IUnitOfWork work) : base(work) { }

        public Domain.Menu GetByUrl(string url)
        {
            var p = Predicates.Field<Domain.Menu>(m => m.Url, Operator.Eq, url);
            var result = Connection.GetList<Domain.Menu>(p, null, Transaction).FirstOrDefault();
            return result;
        }
    }
}
