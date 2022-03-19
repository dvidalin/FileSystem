using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem.Core.Interfaces
{
    public interface IFile : IBaseEntity<int>
    {
        int ParentFolderId { get; set; }
        void Delete();
    }
}
