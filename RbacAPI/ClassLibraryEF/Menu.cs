using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ClassLibraryEF
{
    public class Menu:BaseInfo
    {
        public int MenuId { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string MenuName { get; set; }
        /// <summary>
        /// 父类id
        /// </summary>
        public int PId { get; set; }
        /// <summary>
        /// 菜单链接
        /// </summary>
        public string MenuLink { get; set; }
        public bool IsShow { get; set; }
    }
}
