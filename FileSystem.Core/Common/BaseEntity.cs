using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem.Core.Common
{
    public abstract class BaseEntity<TId>
    {
        public TId Id { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public bool IsDeleted { get; set; } = false;
    }
}
