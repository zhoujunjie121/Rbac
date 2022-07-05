using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ClassLibraryEF
{
    /// <summary>
    /// 管理员
    /// </summary>
    public class Admin:BaseInfo
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
        //最后登录的时间
        public DateTime? LastLoginTime { get; set; }
        public string LastLoginIP { get; set; }
        ///<summary>
        ///是否锁定
        ///</summary>
        public Boolean IsLock { get; set; }
        /// <summary>
        /// 多个角色  使用list创建一个外键
        /// </summary>
        public List<RoleAdmin> RoleAdmin { get; set; }
    }
}
