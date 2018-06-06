using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyCMS.Data
{
    public interface IContentRepository : IBaseRepository<Domain.Content>
    {

    }
    public class ContentRepository : BaseRepository<Domain.Content>, IContentRepository
    {
        public ContentRepository(IUnitOfWork work): base(work)
        {

        }
    }
}
