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
        private readonly IMapper mapper;
        private readonly IRoleMenuRepository roleMenuRepository;

        public RoleService(IRolerepository repository, IMapper mapper,IRoleMenuRepository roleMenuRepository) : base(repository, mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.roleMenuRepository = roleMenuRepository;
        }
        /// <summary>
        /// 分配权限
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public int CreateRoleMenu(MenuRoleDto dto)
        {
            roleMenuRepository.Deletelame(t => t.RoleId == dto.RoleId);
            var ids = dto.MenuId.Select(t => new RoleMenu
            {
                MenuId = t,
                RoleId = dto.RoleId,
            }).ToList();
            return roleMenuRepository.AddAll(ids);
        }
        /// <summary>
        /// 权限分配反填
        /// </summary>
        /// <param name="RoleId"></param>
        /// <returns></returns>
        public List<MenuRoleByIdDto> GetRoleMenuById(int RoleId)
        {
            return mapper.Map<List<MenuRoleByIdDto>>(roleMenuRepository.QueryAll().Where(t=>t.RoleId==RoleId).ToList());

        }
    }
}
