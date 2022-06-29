using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class MenuAddDto
    {
        public int MenuId { get; set; }

        public string MenuName { get; set; }

        public string MenuLink { get; set; }

       public int PId { get; set; }
       public virtual bool IsShow { get; set; }
    }
    public class MenuListDto : MenuAddDto
    {
        public override bool IsShow { get; set; }
    }
}
