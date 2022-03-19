using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem.Core.Interfaces
{
    public interface IBaseEntity<Tid>
    {
        Tid Id { get; set; }
        string Name { get; set; }
    }
}
