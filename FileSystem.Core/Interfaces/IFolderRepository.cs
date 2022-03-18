using FileSystem.Core.FileSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem.Core.Interfaces
{
    public interface IFolderRepository
    {
        public IEnumerable<FolderModel> GetAll();
        public void Add(string name, int? parentId);
        public void AddToRoot(string name);

       
    }
}
