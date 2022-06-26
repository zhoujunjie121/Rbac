using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{ 
    public class AdminDto
    {
        public int AdminId { get; set; }
        /// <summary>
        /// 管理员账号
        /// </summary>
        public string UserName { get; set; }
        //管理员密码
        public string Password { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        public DateTime? LastLoginTime { get; set; }

    }
}
