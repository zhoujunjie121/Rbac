using ClassLibraryEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RoleAdminRepository:BaseRepository<RoleAdmin,int>,IRoleAdminRepository
    {
        public RoleAdminRepository(MyDbContext myDbContext)
        {
            this.myDbContext = myDbContext;
        }
    }
}
