using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.Abstracts
{
    public abstract class EntityBase
    {
        public int Id { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public string LastModified { get; set; }

        public DateTime LastModifiedDate{ get; set; }
    }
}
