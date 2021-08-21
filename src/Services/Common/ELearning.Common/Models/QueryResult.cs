using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.Common.Models
{
    public class QueryResult<T>
    {
        public int Total { get; set; }
        public int TotalFilter { get; set; }
        public IList<T> Items { get; set; }
    }
}