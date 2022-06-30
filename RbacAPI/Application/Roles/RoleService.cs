using AutoMapper;
using ClassLibraryEF;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class RoleService : BaseService<Role, RoleCreateDto>, IRoleService
    {
        private readonly IRolerepository repository;
        private readonly IRoleMenuRepository roleMenuRepository;

        public RoleService(IRolerepository repository, IMapper mapper,IRoleMenuRepository roleMenuRepository) : base(repository, mapper)
        {
            this.repository = repository;
            this.roleMenuRepository = roleMenuRepository;
        }
        public int CreateRoleMenu(MenuRoleDto dto)
        {
            var ids = dto.MenuId.Select(t => new RoleMenu
            {
                MenuId = t,
                RoleId = dto.RoleId,
            }).ToList();
            return roleMenuRepository.AddAll(ids);
        }

    }
}
