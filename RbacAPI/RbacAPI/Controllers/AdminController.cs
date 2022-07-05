using Application;
using ClassLibraryEF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RbacAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService adminService;

        public AdminController(IAdminService adminService)
        {
            this.adminService = adminService;
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpGet]
        public TokenDto GetLogin([FromQuery]LoginDto dto)
        {
            return adminService.GetLogin(dto);
        }

        /// <summary>
        /// 生成验证码
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public int verificationcode()
        {
            Random random = new Random();
            var code = random.Next(1000, 9999);
            return code;
        }


        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public ResultDto Create(AdminDto dto)
        {
            return adminService.CreateAdmin(dto);
        }
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public int Delete(int id)
        {
            return adminService.Delete(id);
        }
        /// <summary>
        /// 查询单条数据  反填
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public AdminDto GetAdmin(int id)
        {
            return adminService.Find(id);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public int Update(AdminDto dto)
        {
            return adminService.Update(dto);
        }
        /// <summary>
        /// 用户名列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public PageResult<AdminListDto> GetQuery([FromQuery]Result dto)
        {
            return adminService.GetAdmin(dto);
        }

    }
}
