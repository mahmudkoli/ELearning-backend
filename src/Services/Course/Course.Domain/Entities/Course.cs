using ELearning.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Domain.Entities
{
    public class Course : AuditableEntity<Guid>
    {
        public string Title { get; set; }
    }
}
