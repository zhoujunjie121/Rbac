using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application;
using ClassLibraryEF;
using System.Collections.Generic;

namespace RbacAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService roleService;

        public RoleController(IRoleService roleService)
        {
            this.roleService = roleService;
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public int Create(RoleCreateDto dto)
        {
            return roleService.Create(dto);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public int Delete(int id)
        {
            return roleService.Delete(id);
        }

        [HttpGet]
        public RoleCreateDto GetBity(int id)
        {
            return roleService.Find(id);
        }

        [HttpPost]
        public int Update(RoleCreateDto dto)
        {
            return roleService.Update(dto);
        }
        [HttpGet]
        public List<Role> Query()
        {
            return roleService.Query();
        }

        /// <summary>
        /// 权限分配
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public int CreateRoleMenu(MenuRoleDto dto)
        {
            return roleService.CreateRoleMenu(dto);
        }


    }
}
