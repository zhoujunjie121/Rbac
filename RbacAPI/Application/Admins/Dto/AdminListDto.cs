using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class AdminListDto
    {
        public int AdminId { get; set; }
        /// <summary>
        /// 管理员账号
        /// </summary>
        public string UserName { get; set; }
        //是否锁定
        public bool IsLock { get; set; }

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
