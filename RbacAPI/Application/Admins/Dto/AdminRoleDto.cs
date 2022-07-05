using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class AdminRoleDto
    {
        public int Id { get; set; }
        /// <summary>
        /// 角色表
        /// </summary>
        public int RoleId { get; set; }
        /// <summary>
        /// 管理员表
        /// </summary>
        public int AdminId { get; set; }
    }
}
