using FileSystem.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem.Core.Common
{
    public abstract class BaseEntity<TId> : IBaseEntity<TId>
    {
        public TId Id { get; set; }
        public string Name { get; set; }
    }
}
