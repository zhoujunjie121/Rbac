using ClassLibraryEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IRoleService:IBaseService<Role, RoleCreateDto>
    {
        int CreateRoleMenu(MenuRoleDto dto);
        List<MenuRoleByIdDto> GetRoleMenuById(int RoleId);
    }
}
