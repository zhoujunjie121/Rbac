using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryEF;

namespace Repository
{
    public class RoleMenuRepository : BaseRepository<RoleMenu, int>, IRoleMenuRepository
    {

        public RoleMenuRepository(MyDbContext myDbContext)
        {
            this.myDbContext = myDbContext;
        }
    }
}
