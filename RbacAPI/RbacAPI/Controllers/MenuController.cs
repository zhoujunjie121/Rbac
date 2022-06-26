using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application;
using Repository;
using System.Collections.Generic;
using Fare;
using ClassLibraryEF;
using Microsoft.AspNetCore.Authorization;

namespace RbacAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService menuService;

        public MenuController(IMenuService menuService)
        {
            this.menuService = menuService;
        }
        /// <summary>
        /// 菜单列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<MenuDto> QueryAll()
        {
            return menuService.QueryAll();
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public int DelMenu(int id)
        {
            return menuService.DelMenu(id);
        }

        /// <summary>
        /// 级联选择
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<MenuCreateDto> QueryCreateMeun()
        {
            return menuService.QueryCreateMeun();
        }
        /// <summary>
        /// 添加菜单
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        [HttpPost]
        public int AddMenu(MenuAddDto menu)
        {
            return menuService.AddMenu(menu);
        }

        [HttpGet]
        public Menu GetBity(int id)
        {
            return menuService.GetBity(id);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        [HttpPost]
        public int MenuUpd(MenuAddDto menu)
        {
            return menuService.MenuUpd(menu);
        }
    }
}
