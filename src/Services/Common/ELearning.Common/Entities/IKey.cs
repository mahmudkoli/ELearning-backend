using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.Common.Entities
{
    public interface IKey<TKey>
    {
        public TKey Id { get; set; }
    }
}
