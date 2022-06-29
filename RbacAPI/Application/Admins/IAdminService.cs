using ClassLibraryEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IAdminService:IBaseService<Admin,AdminDto>
    {
        ResultDto CreateAdmin(AdminDto dto);
        TokenDto GetLogin(LoginDto dto);
        PageResult<AdminListDto> GetAdmin(Result dto);
    }
}
