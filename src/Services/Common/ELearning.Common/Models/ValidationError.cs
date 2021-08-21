using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.Common.Models
{
    public class ValidationError
    {
        public string PropertyName { get; set; }
        public IList<string> PropertyFailures { get; set; }
    }
}
