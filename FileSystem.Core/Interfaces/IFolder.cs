using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem.Core.Interfaces
{
    public interface IFolder : IBaseEntity<int>
    {
        IFolder AddSubfolder(string name);
        void Delete();
        void  DeleteSubFolderById(int subfolderId);
        IFile CreateFile(string fileName);
        void DeleteFile(IFile file);
        void DeleteFileById(int fileId);
    }
}
