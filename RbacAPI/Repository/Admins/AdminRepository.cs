using ClassLibraryEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AdminRepository : BaseRepository<Admin, int>, IAdminRepoitstory
    {

        public AdminRepository(MyDbContext myDbContext)
        {
            this.myDbContext = myDbContext;
        }
    }
}
