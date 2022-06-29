using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class PageResult<T>
    {
        public int totalCount { get; set; }
        public List<T> Data { get; set; }
    }
}
